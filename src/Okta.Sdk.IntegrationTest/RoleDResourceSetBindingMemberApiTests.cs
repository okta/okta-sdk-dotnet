// <copyright file="RoleDResourceSetBindingMemberApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for <see cref="RoleDResourceSetBindingMemberApi"/>.
    ///
    /// SDK Methods &amp; Endpoints Covered (all 8 signatures — 4 functional + 4 WithHttpInfo):
    /// ┌────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ Method                                              │ HTTP   │ Status │ Endpoint                                                                                       │
    /// ├────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ ListMembersOfBindingAsync                           │ GET    │ 200    │ /api/v1/iam/resource-sets/{rsId}/bindings/{roleId}/members (by id, no after)                   │
    /// │ ListMembersOfBindingAsync (after)                   │ GET    │ 200    │ same (by id, with after cursor — exercises optional pagination parameter)                      │
    /// │ ListMembersOfBindingWithHttpInfoAsync               │ GET    │ 200    │ same (by RS label + role label); also with after cursor                                        │
    /// │ GetMemberOfBindingAsync                             │ GET    │ 200    │ /api/v1/iam/resource-sets/{rsId}/bindings/{roleId}/members/{memberId} (by id)                  │
    /// │ GetMemberOfBindingWithHttpInfoAsync                 │ GET    │ 200    │ same (by RS label + role label)                                                                │
    /// │ AddMembersToBindingAsync                            │ PATCH  │ 200    │ /api/v1/iam/resource-sets/{rsId}/bindings/{roleId}/members (by id)                             │
    /// │ AddMembersToBindingWithHttpInfoAsync                │ PATCH  │ 200    │ same (by RS label + role label — idempotent re-add, HTTP 200)                                  │
    /// │ UnassignMemberFromBindingWithHttpInfoAsync          │ DELETE │ 204    │ /api/v1/iam/resource-sets/{rsId}/bindings/{roleId}/members/{memberId} (by RS label+role label) │
    /// │ UnassignMemberFromBindingAsync                      │ DELETE │ 204    │ same (by RS id + role id — last member; Okta auto-deletes binding, confirmed via 404 GET)      │
    /// └────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
    ///
    ///</summary>
    [Collection(nameof(RoleDResourceSetBindingMemberApiTests))]
    public class RoleDResourceSetBindingMemberApiTests : IAsyncLifetime
    {
        // ── API clients ────────────────────────────────────────────────────────
        private readonly RoleDResourceSetBindingMemberApi _api     = new();
        private readonly RoleDResourceSetBindingApi       _bindApi = new();
        private readonly RoleCResourceSetApi              _rsApi   = new();
        private readonly RoleECustomApi                   _roleApi = new();

        // ── Fixture state ──────────────────────────────────────────────────────
        private string _resourceSetId;
        private string _resourceSetLabel;
        private string _roleId;
        private string _roleLabel;
        private bool   _bindingCreated; // tracks whether the binding was created inside the test

        // ── Org base URL ───────────────────────────────────────────────────────
        private static readonly string OrgBaseUrl =
            Configuration.GetConfigurationOrDefault().OktaDomain.TrimEnd('/');

        // ══════════════════════════════════════════════════════════════════════
        //  SETUP
        // ══════════════════════════════════════════════════════════════════════

        public async Task InitializeAsync()
        {
            var suffix = new Random().Next(100_000_000, 999_999_999).ToString();
            _resourceSetLabel = $"rdrsbmem-rs-{suffix}";
            _roleLabel        = $"rdrsbmem-role-{suffix}";

            // Create the parent resource set.
            var rs = await _rsApi.CreateResourceSetAsync(new CreateResourceSetRequest
            {
                Label       = _resourceSetLabel,
                Description = "Integration test — RoleDResourceSetBindingMemberApi",
                Resources   = new List<string> { $"{OrgBaseUrl}/api/v1/users" },
            });
            _resourceSetId = rs.Id;

            // Create the custom role that will own the binding.
            var role = await _roleApi.CreateRoleAsync(new CreateIamRoleRequest
            {
                Label       = _roleLabel,
                Description = "Integration test role for member binding tests",
                Permissions = new List<string> { "okta.users.read" },
            });
            _roleId = role.Id;
        }

        // ══════════════════════════════════════════════════════════════════════
        //  TEARDOWN — safety-net cleanup
        // ══════════════════════════════════════════════════════════════════════

        public async Task DisposeAsync()
        {
            // Safety-net: delete binding if the test left it alive.
            if (_bindingCreated && !string.IsNullOrEmpty(_resourceSetId) && !string.IsNullOrEmpty(_roleId))
            {
                try { await _bindApi.DeleteBindingAsync(_resourceSetId, _roleId); } catch { /* ignore */ }
            }

            if (!string.IsNullOrEmpty(_roleId))
            {
                try { await _roleApi.DeleteRoleAsync(_roleId); } catch { /* ignore */ }
            }

            if (!string.IsNullOrEmpty(_resourceSetId))
            {
                try { await _rsApi.DeleteResourceSetAsync(_resourceSetId); } catch { /* ignore */ }
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        //  SINGLE COMPREHENSIVE TEST — covers all 8 SDK signatures in one flow
        // ══════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task ResourceSetBindingMembers_FullWorkflow_ShouldSucceed()
        {
            // Fetch two distinct users from the org to use as binding members.
            var users = await new UserApi().ListUsers(limit: 2).ToListAsync();
            users.Should().HaveCountGreaterThanOrEqualTo(2,
                "at least two users must exist in the org to exercise add/unassign member flows");
            var user1Id  = users[0].Id;
            var user1Url = $"{OrgBaseUrl}/api/v1/users/{user1Id}";
            var user2Id  = users[1].Id;
            var user2Url = $"{OrgBaseUrl}/api/v1/users/{user2Id}";

            // Create the binding with user1 as the initial member.
            // (Okta requires at least one member in the creation payload.)
            await _bindApi.CreateResourceSetBindingAsync(
                _resourceSetId,
                new ResourceSetBindingCreateRequest
                {
                    Role    = _roleId,
                    Members = new List<string> { user1Url },
                });
            _bindingCreated = true;

            // ─────────────────────────────────────────────────────────────────
            // Step 1 — ListMembersOfBindingAsync (GET /members by RS id, role id)
            //   The binding was seeded with user1, so exactly one member must
            //   appear.  The binding-scoped member id (≠ user id) is extracted
            //   here and used in later steps.
            // ─────────────────────────────────────────────────────────────────
            var list1 = await _api.ListMembersOfBindingAsync(_resourceSetId, _roleId);

            list1.Should().NotBeNull();
            list1.Members.Should().HaveCount(1,
                "the binding was seeded with exactly one member (user1)");
            list1.Members[0].Id.Should().NotBeNullOrEmpty(
                "each member entry must carry a server-assigned binding-scoped id");
            list1.Members[0].Links.Should().NotBeNull(
                "each member entry must have _links");
            list1.Members[0].Links.Self.Should().NotBeNull(
                "_links.self must be present for every member");
            list1.Members[0].Links.Self.Href.Should().Contain(user1Id,
                "_links.self href must reference the underlying user");
            list1.Links.Should().NotBeNull("_links must be present in the list response");
            list1.Links.Self.Should().NotBeNull("_links.self must be present (collection self link)");
            list1.Links.Binding.Should().NotBeNull(
                "_links.binding must link back to the parent binding");
            list1.Links.Next.Should().BeNull(
                "_links.next must be absent when fewer than 100 members exist");

            var member1Id = list1.Members[0].Id; // binding-scoped member id for user1

            // ─────────────────────────────────────────────────────────────────
            // Step 2 — GetMemberOfBindingAsync (GET /members/{memberId} by RS id, role id)
            //   Retrieve the member detail by the binding-scoped member id.
            // ─────────────────────────────────────────────────────────────────
            var getMember1 = await _api.GetMemberOfBindingAsync(_resourceSetId, _roleId, member1Id);

            getMember1.Should().NotBeNull();
            getMember1.Id.Should().Be(member1Id,
                "GET must return the member with the correct binding-scoped id");
            getMember1.Created.Should().NotBe(default(DateTimeOffset),
                "Created timestamp must be populated by the server");
            getMember1.LastUpdated.Should().NotBe(default(DateTimeOffset),
                "LastUpdated timestamp must be populated by the server");
            getMember1.Links.Should().NotBeNull("GET /members/{memberId} must return _links");
            getMember1.Links.Self.Href.Should().Contain(user1Id,
                "_links.self href must reference the underlying user");

            // ─────────────────────────────────────────────────────────────────
            // Step 3 — GetMemberOfBindingWithHttpInfoAsync (GET by RS label, role label)
            //   Verifies that both {resourceSetIdOrLabel} and {roleIdOrLabel}
            //   accept labels and that the response is HTTP 200.
            // ─────────────────────────────────────────────────────────────────
            var getMemberHttp = await _api.GetMemberOfBindingWithHttpInfoAsync(
                _resourceSetLabel, _roleLabel, member1Id);

            ((int)getMemberHttp.StatusCode).Should().Be(200,
                "GET /members/{memberId} (by RS label + role label) must return HTTP 200");
            getMemberHttp.Data.Should().NotBeNull();
            getMemberHttp.Data.Id.Should().Be(member1Id,
                "fetching by label must resolve to the same member as fetching by id");
            getMemberHttp.Data.Links.Self.Href.Should().Contain(user1Id,
                "_links.self href must still reference user1 when fetched via label routing");

            // ─────────────────────────────────────────────────────────────────
            // Step 4 — AddMembersToBindingAsync (PATCH /members by RS id, role id)
            //   Add user2 to the binding; response is ResourceSetBindingEditResponse.
            // ─────────────────────────────────────────────────────────────────
            var addResult = await _api.AddMembersToBindingAsync(
                _resourceSetId,
                _roleId,
                new ResourceSetBindingAddMembersRequest
                {
                    Additions = new List<string> { user2Url },
                });

            addResult.Should().NotBeNull();
            addResult.Links.Should().NotBeNull(
                "PATCH /members must return _links in the response body");
            addResult.Links.ResourceSet.Should().NotBeNull(
                "_links.resource-set must be present in the PATCH response");
            addResult.Links.ResourceSet.Href.Should().Contain(_resourceSetId,
                "_links.resource-set href must reference the parent resource set id");
            addResult.Links.Bindings.Should().NotBeNull(
                "_links.bindings must be present in the PATCH response");
            addResult.Links.Self.Should().NotBeNull(
                "_links.self must be present in the PATCH response");
            addResult.Links.Self.Href.Should().Contain(_roleId,
                "_links.self href must include the role id as the binding identifier");

            // ─────────────────────────────────────────────────────────────────
            // Step 5 — ListMembersOfBindingWithHttpInfoAsync
            //   (GET by RS label, role label — two members now)
            //   Extracts the binding-scoped member id for user2 for use in
            //   the unassign steps below.
            // ─────────────────────────────────────────────────────────────────
            var list2Http = await _api.ListMembersOfBindingWithHttpInfoAsync(
                _resourceSetLabel, _roleLabel);

            ((int)list2Http.StatusCode).Should().Be(200,
                "GET /members (by RS label + role label) must return HTTP 200");
            list2Http.Data.Should().NotBeNull();
            list2Http.Data.Members.Should().HaveCount(2,
                "user1 (seeded) + user2 (added via PATCH) = 2 members");
            list2Http.Data.Members.Should().Contain(m => m.Links.Self.Href.Contains(user1Id),
                "user1 must still appear in the list after adding user2");
            list2Http.Data.Members.Should().Contain(m => m.Links.Self.Href.Contains(user2Id),
                "user2 must appear in the list after being added via PATCH");

            var member2Id = list2Http.Data.Members
                .First(m => m.Links.Self.Href.Contains(user2Id))
                .Id; // binding-scoped id for user2

            // ─────────────────────────────────────────────────────────────────
            // Step 6 — ListMembersOfBindingAsync with `after` cursor (plain variant)
            //   Exercise the optional `after` pagination parameter on the
            //   functional (non-WithHttpInfo) variant.  Use member1Id as a
            //   fallback cursor when no server-issued next-page link exists.
            // ─────────────────────────────────────────────────────────────────
            string afterCursor = list2Http.Data.Links?.Next?.Href ?? member1Id;

            var listWithAfter = await _api.ListMembersOfBindingAsync(
                _resourceSetId, _roleId, after: afterCursor);

            listWithAfter.Should().NotBeNull(
                "ListMembersOfBindingAsync with after parameter must return a non-null result");

            // Also exercise ListMembersOfBindingWithHttpInfoAsync with after cursor.
            var listWithAfterHttp = await _api.ListMembersOfBindingWithHttpInfoAsync(
                _resourceSetLabel, _roleLabel, after: afterCursor);

            ((int)listWithAfterHttp.StatusCode).Should().Be(200,
                "GET /members?after=<cursor> (by RS label + role label) must return HTTP 200");
            listWithAfterHttp.Data.Should().NotBeNull();

            // ─────────────────────────────────────────────────────────────────
            // Step 7 — AddMembersToBindingWithHttpInfoAsync
            //   (PATCH by RS label, role label — idempotent re-add of user2)
            //   Re-adding an already-present member must return HTTP 200.
            // ─────────────────────────────────────────────────────────────────
            var addByLabelHttp = await _api.AddMembersToBindingWithHttpInfoAsync(
                _resourceSetLabel,
                _roleLabel,
                new ResourceSetBindingAddMembersRequest
                {
                    Additions = new List<string> { user2Url },
                });

            ((int)addByLabelHttp.StatusCode).Should().Be(200,
                "PATCH /members (idempotent re-add by RS label + role label) must return HTTP 200");
            addByLabelHttp.Data.Should().NotBeNull();
            addByLabelHttp.Data.Links.Should().NotBeNull(
                "PATCH response must still include _links when called via label routing");
            addByLabelHttp.Data.Links.ResourceSet.Href.Should().Contain(_resourceSetId,
                "_links.resource-set href must reference the canonical RS id even when requested via label");

            // ─────────────────────────────────────────────────────────────────
            // Step 8 — UnassignMemberFromBindingWithHttpInfoAsync
            //   (DELETE by RS label, role label, member1Id)
            //   Remove user1 from the binding and assert HTTP 204.
            //   A subsequent GET on that member must throw ApiException (404).
            // ─────────────────────────────────────────────────────────────────
            var unassignHttp = await _api.UnassignMemberFromBindingWithHttpInfoAsync(
                _resourceSetLabel, _roleLabel, member1Id);

            ((int)unassignHttp.StatusCode).Should().Be(204,
                "DELETE /members/{memberId} (by RS label + role label) must return HTTP 204");

            Func<Task> getMember1AfterDelete = async () =>
                await _api.GetMemberOfBindingAsync(_resourceSetId, _roleId, member1Id);
            await getMember1AfterDelete.Should().ThrowAsync<ApiException>(
                "GET on an unassigned member must throw ApiException (404)");

            // ─────────────────────────────────────────────────────────────────
            // Step 9 — UnassignMemberFromBindingAsync
            //   (DELETE by RS id, role id, member2Id — void-return variant)
            //   Remove user2 — the last member.
            //   Okta auto-deletes the binding when the last member is unassigned,
            //   so a subsequent GET on the binding must throw ApiException (404).
            // ─────────────────────────────────────────────────────────────────
            await _api.UnassignMemberFromBindingAsync(_resourceSetId, _roleId, member2Id);

            // Verify the binding was auto-deleted by Okta.
            Func<Task> getBindingAfterLastUnassign = async () =>
                await _bindApi.GetBindingAsync(_resourceSetId, _roleId);
            await getBindingAfterLastUnassign.Should().ThrowAsync<ApiException>(
                "Okta auto-deletes the binding when the last member is unassigned");

            _bindingCreated = false; // binding auto-deleted — skip DisposeAsync safety-net
        }
    }
}
