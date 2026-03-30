// <copyright file="RoleDResourceSetBindingApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for <see cref="RoleDResourceSetBindingApi"/>.
    ///
    /// SDK Methods &amp; Endpoints Covered (all 8 signatures — 4 functional + 4 WithHttpInfo):
    /// ┌─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ Method                                            │ HTTP   │ Status │ Endpoint                                                                          │
    /// ├─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ CreateResourceSetBindingAsync                     │ POST   │ 200    │ /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings (by id)                 │
    /// │ CreateResourceSetBindingWithHttpInfoAsync         │ POST   │ 200    │ same (by label — label routing confirmed working)                                 │
    /// │ ListBindingsAsync                                 │ GET    │ 200    │ /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings (by id, no after)       │
    /// │ ListBindingsAsync (after)                         │ GET    │ 200    │ same (by id, with after cursor — exercises optional pagination parameter)         │
    /// │ ListBindingsWithHttpInfoAsync                     │ GET    │ 200    │ same (by label, with after cursor)                                                │
    /// │ GetBindingAsync                                   │ GET    │ 200    │ /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel}         │
    /// │ GetBindingWithHttpInfoAsync                       │ GET    │ 200    │ same (by label — both RS label and role label routing confirmed working)          │
    /// │ DeleteBindingAsync                                │ DELETE │ 204    │ /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel}         │
    /// │ DeleteBindingWithHttpInfoAsync                    │ DELETE │ 204    │ same (by id — explicit WithHttpInfo status code assertion)                        │
    /// └─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
    ///
    /// </summary>
    [Collection(nameof(RoleDResourceSetBindingApiTests))]
    public class RoleDResourceSetBindingApiTests : IAsyncLifetime
    {
        // ── API clients ────────────────────────────────────────────────────────
        private readonly RoleDResourceSetBindingApi _api = new();
        private readonly RoleCResourceSetApi _rsApi = new();
        private readonly RoleECustomApi _roleApi = new();

        // ── Fixture state ──────────────────────────────────────────────────────
        private string _resourceSetId;
        private string _resourceSetLabel;
        private string _role1Id;
        private string _role1Label;
        private string _role2Id;
        private string _role2Label;

        // ── Org base URL ───────────────────────────────────────────────────────
        private static readonly string OrgBaseUrl =
            Configuration.GetConfigurationOrDefault().OktaDomain.TrimEnd('/');

        // ══════════════════════════════════════════════════════════════════════
        //  SETUP
        // ══════════════════════════════════════════════════════════════════════

        public async Task InitializeAsync()
        {
            var suffix = new Random().Next(100_000_000, 999_999_999).ToString();
            _resourceSetLabel = $"rdrsbind-rs-{suffix}";
            _role1Label       = $"rdrsbind-role1-{suffix}";
            _role2Label       = $"rdrsbind-role2-{suffix}";

            // Create a resource set that owns the bindings under test.
            var rs = await _rsApi.CreateResourceSetAsync(new CreateResourceSetRequest
            {
                Label       = _resourceSetLabel,
                Description = "Integration test — RoleDResourceSetBindingApi",
                Resources   = new List<string> { $"{OrgBaseUrl}/api/v1/users" },
            });
            _resourceSetId = rs.Id;

            // Create first custom role (used for the primary binding tests).
            var role1 = await _roleApi.CreateRoleAsync(new CreateIamRoleRequest
            {
                Label       = _role1Label,
                Description = "Integration test role 1 for binding tests",
                Permissions = new List<string> { "okta.users.read" },
            });
            _role1Id = role1.Id;

            // Create second custom role (used for the WithHttpInfo CREATE / label-routing test).
            var role2 = await _roleApi.CreateRoleAsync(new CreateIamRoleRequest
            {
                Label       = _role2Label,
                Description = "Integration test role 2 for binding tests",
                Permissions = new List<string> { "okta.users.read" },
            });
            _role2Id = role2.Id;
        }

        // ══════════════════════════════════════════════════════════════════════
        //  TEARDOWN — safety-net cleanup (bindings are deleted inside the test)
        // ══════════════════════════════════════════════════════════════════════

        public async Task DisposeAsync()
        {
            // Safety-net: attempt to delete any bindings that survived test failures.
            foreach (var roleId in new[] { _role1Id, _role2Id })
            {
                if (string.IsNullOrEmpty(roleId) || string.IsNullOrEmpty(_resourceSetId))
                    continue;
                try { await _api.DeleteBindingAsync(_resourceSetId, roleId); } catch { /* ignore */ }
            }

            // Delete the custom roles (order doesn't matter once bindings are gone).
            foreach (var roleId in new[] { _role1Id, _role2Id })
            {
                if (string.IsNullOrEmpty(roleId)) continue;
                try { await _roleApi.DeleteRoleAsync(roleId); } catch { /* ignore */ }
            }

            // Delete the resource set last (bindings are automatically removed by Okta
            // when the RS is deleted, but we prefer explicit teardown above).
            if (!string.IsNullOrEmpty(_resourceSetId))
            {
                try { await _rsApi.DeleteResourceSetAsync(_resourceSetId); } catch { /* ignore */ }
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        //  SINGLE COMPREHENSIVE TEST — covers all 8 SDK signatures in one flow
        // ══════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task ResourceSetBindings_FullWorkflow_ShouldSucceed()
        {
            // Retrieve one active user from the org to use as a binding member.
            // Using a known stable user created during earlier curl validation.
            var users = await new UserApi().ListUsers(limit: 1).ToListAsync();
            users.Should().NotBeEmpty("at least one user must exist in the org to serve as a binding member");
            var memberId = users[0].Id;
            var memberUrl = $"{OrgBaseUrl}/api/v1/users/{memberId}";

            // ─────────────────────────────────────────────────────────────────
            // Step 1 — ListBindingsAsync (GET /bindings by RS id — empty list)
            //   Before any binding is created the `roles` array must be empty.
            // ─────────────────────────────────────────────────────────────────
            var emptyList = await _api.ListBindingsAsync(_resourceSetId);

            emptyList.Should().NotBeNull();
            emptyList.Roles.Should().BeNullOrEmpty(
                "no bindings exist yet for the freshly created resource set");
            emptyList.Links.Should().NotBeNull("_links must be present even when the list is empty");
            emptyList.Links.Self.Should().NotBeNull(
                "_links.self must be present on the collection response");
            emptyList.Links.Self.Href.Should().Contain("/bindings",
                "_links.self href must point to the bindings collection endpoint");
            emptyList.Links.ResourceSet.Should().NotBeNull(
                "_links.resource-set must link back to the parent resource set");
            emptyList.Links.ResourceSet.Href.Should().Contain(_resourceSetId,
                "_links.resource-set href must reference the parent resource set id");

            // ─────────────────────────────────────────────────────────────────
            // Step 2 — CreateResourceSetBindingAsync (POST /bindings by RS id)
            //   Bind role1 to the resource set; the request body carries the
            //   role id and a member URL.
            //   Expected response: ResourceSetBindingEditResponse (only _links).
            // ─────────────────────────────────────────────────────────────────
            var createResult = await _api.CreateResourceSetBindingAsync(
                _resourceSetId,
                new ResourceSetBindingCreateRequest
                {
                    Role    = _role1Id,
                    Members = new List<string> { memberUrl },
                });

            createResult.Should().NotBeNull();
            createResult.Links.Should().NotBeNull(
                "POST /bindings must return _links in the response body");
            createResult.Links.ResourceSet.Should().NotBeNull(
                "_links.resource-set must be present in the create response");
            createResult.Links.ResourceSet.Href.Should().Contain(_resourceSetId,
                "_links.resource-set href must reference the parent resource set id");
            createResult.Links.Bindings.Should().NotBeNull(
                "_links.bindings must be present in the create response");
            createResult.Links.Bindings.Href.Should().Contain("/bindings",
                "_links.bindings href must point to the bindings collection");
            createResult.Links.Self.Should().NotBeNull(
                "_links.self must be present in the create response");
            createResult.Links.Self.Href.Should().Contain(_role1Id,
                "_links.self href must include the role id as the binding identifier");

            // ─────────────────────────────────────────────────────────────────
            // Step 3 — ListBindingsAsync (GET /bindings by RS id — one binding)
            //   After creating the binding, the list must contain exactly one
            //   entry that carries the role id and its own _links.
            // ─────────────────────────────────────────────────────────────────
            var listAfterCreate = await _api.ListBindingsAsync(_resourceSetId);

            listAfterCreate.Should().NotBeNull();
            listAfterCreate.Roles.Should().HaveCount(1,
                "exactly one binding was just created for this resource set");
            listAfterCreate.Roles[0].Id.Should().Be(_role1Id,
                "the listed binding must carry the role id used during creation");
            listAfterCreate.Roles[0].Links.Should().NotBeNull(
                "each binding in the list must have _links");
            listAfterCreate.Roles[0].Links.Members.Should().NotBeNull(
                "each binding _links must include a members link");
            listAfterCreate.Roles[0].Links.Self.Should().NotBeNull(
                "each binding _links must include a self link");
            listAfterCreate.Links.Next.Should().BeNull(
                "_links.next must be absent when fewer than 100 bindings exist");

            // ─────────────────────────────────────────────────────────────────
            // Step 4 — GetBindingAsync (GET /bindings/{roleId} by RS id, role id)
            //   Retrieve the single binding by role id and verify all fields.
            // ─────────────────────────────────────────────────────────────────
            var getResult = await _api.GetBindingAsync(_resourceSetId, _role1Id);

            getResult.Should().NotBeNull();
            getResult.Id.Should().Be(_role1Id,
                "GET /bindings/{roleId} must return the binding with the correct role id");
            getResult.Links.Should().NotBeNull(
                "GET /bindings/{roleId} must return _links");
            getResult.Links.Self.Should().NotBeNull();
            getResult.Links.Self.Href.Should().Contain(_role1Id,
                "_links.self href must include the role id");
            getResult.Links.ResourceSet.Should().NotBeNull(
                "_links.resource-set must link back to the parent resource set");
            getResult.Links.ResourceSet.Href.Should().Contain(_resourceSetId,
                "_links.resource-set href must reference the parent resource set id");
            getResult.Links.Members.Should().NotBeNull(
                "_links.members must be present to allow member enumeration");

            // ─────────────────────────────────────────────────────────────────
            // Step 5 — GetBindingWithHttpInfoAsync (GET by RS label, role label)
            //   Verify that both {resourceSetIdOrLabel} and {roleIdOrLabel}
            //   accept labels (not just IDs) and return HTTP 200.
            // ─────────────────────────────────────────────────────────────────
            var getByLabelHttp = await _api.GetBindingWithHttpInfoAsync(
                _resourceSetLabel, _role1Label);

            ((int)getByLabelHttp.StatusCode).Should().Be(200,
                "GET /bindings/{roleLabel} (by RS label + role label) must return HTTP 200");
            getByLabelHttp.Data.Should().NotBeNull();
            getByLabelHttp.Data.Id.Should().Be(_role1Id,
                "fetching by label must resolve to the same binding as fetching by id");
            getByLabelHttp.Data.Links.ResourceSet.Href.Should().Contain(_resourceSetId,
                "_links.resource-set href must still reference the canonical resource set id");

            // ─────────────────────────────────────────────────────────────────
            // Step 6 — ListBindingsWithHttpInfoAsync (GET by RS label, with after)
            //   Exercise the WithHttpInfo code path and the optional `after`
            //   pagination parameter.
            //   Pass the role1 id as an `after` cursor when no real next page
            //   exists — the API must return HTTP 200 (empty or same page).
            // ─────────────────────────────────────────────────────────────────
            var listByLabelHttp = await _api.ListBindingsWithHttpInfoAsync(_resourceSetLabel);

            ((int)listByLabelHttp.StatusCode).Should().Be(200,
                "GET /bindings (by RS label) must return HTTP 200");
            listByLabelHttp.Data.Should().NotBeNull();
            listByLabelHttp.Data.Roles.Should().NotBeNullOrEmpty(
                "the list must contain the role1 binding created in Step 2");
            listByLabelHttp.Data.Roles.Should().Contain(r => r.Id == _role1Id,
                "role1 binding must appear in the list when fetching by RS label");

            // Exercise the `after` cursor parameter regardless of whether the
            // server returned a next-page link.
            string afterCursor = listByLabelHttp.Data.Links?.Next?.Href != null
                ? listByLabelHttp.Data.Links.Next.Href
                : _role1Id;  // fallback: use role id as cursor (server returns 200)

            var listPage2Http = await _api.ListBindingsWithHttpInfoAsync(
                _resourceSetLabel, after: afterCursor);

            ((int)listPage2Http.StatusCode).Should().Be(200,
                "GET /bindings?after=<cursor> (by RS label) must return HTTP 200");
            listPage2Http.Data.Should().NotBeNull();

            // Also exercise ListBindingsAsync (plain, non-WithHttpInfo) with the `after`
            // parameter so that code path is covered for the functional variant too.
            var listWithAfterPlain = await _api.ListBindingsAsync(_resourceSetId, after: afterCursor);

            listWithAfterPlain.Should().NotBeNull(
                "ListBindingsAsync with after parameter must return a non-null result");

            // ─────────────────────────────────────────────────────────────────
            // Step 7 — DeleteBindingWithHttpInfoAsync (DELETE by RS id, role id)
            //   Remove the role1 binding and assert the response is HTTP 204.
            //   A subsequent GET must throw ApiException (404).
            // ─────────────────────────────────────────────────────────────────
            var deleteHttp = await _api.DeleteBindingWithHttpInfoAsync(_resourceSetId, _role1Id);

            ((int)deleteHttp.StatusCode).Should().Be(204,
                "DELETE /bindings/{roleId} must return HTTP 204 No Content");

            Func<Task> getDeletedRole1 = async () =>
                await _api.GetBindingAsync(_resourceSetId, _role1Id);
            await getDeletedRole1.Should().ThrowAsync<ApiException>(
                "GET on a deleted binding must throw ApiException (404)");

            // ─────────────────────────────────────────────────────────────────
            // Step 8 — CreateResourceSetBindingWithHttpInfoAsync (POST by RS label)
            //   Bind role2 using the resource set label (not id) to confirm
            //   that {resourceSetIdOrLabel} label routing works for POST.
            //   Use role2 id (labels are accepted for role id/label param).
            // ─────────────────────────────────────────────────────────────────
            var createByLabelHttp = await _api.CreateResourceSetBindingWithHttpInfoAsync(
                _resourceSetLabel,
                new ResourceSetBindingCreateRequest
                {
                    Role    = _role2Id,
                    Members = new List<string> { memberUrl },
                });

            ((int)createByLabelHttp.StatusCode).Should().Be(200,
                "POST /bindings (by RS label) must return HTTP 200");
            createByLabelHttp.Data.Should().NotBeNull();
            createByLabelHttp.Data.Links.Should().NotBeNull(
                "POST /bindings must return _links in the response body");
            createByLabelHttp.Data.Links.ResourceSet.Should().NotBeNull(
                "_links.resource-set must be present in the create response (by label)");
            createByLabelHttp.Data.Links.ResourceSet.Href.Should().Contain(_resourceSetId,
                "_links.resource-set href must reference the canonical resource set id even when created via label");
            createByLabelHttp.Data.Links.Self.Href.Should().Contain(_role2Id,
                "_links.self href must include the role2 id as the binding identifier");

            // ─────────────────────────────────────────────────────────────────
            // Step 9 — DeleteBindingAsync (DELETE by RS label, role id)
            //   Remove the role2 binding using the RS label (not id).
            //   This is the void-return variant; confirm deletion via a
            //   subsequent GET that must throw.
            // ─────────────────────────────────────────────────────────────────
            await _api.DeleteBindingAsync(_resourceSetLabel, _role2Id);

            Func<Task> getDeletedRole2 = async () =>
                await _api.GetBindingAsync(_resourceSetId, _role2Id);
            await getDeletedRole2.Should().ThrowAsync<ApiException>(
                "GET on a deleted binding must throw ApiException (404)");

            // ─────────────────────────────────────────────────────────────────
            // Step 10 — ListBindingsAsync (GET — verify empty after both deletes)
            //   After deleting both bindings the list must be empty again,
            //   confirming that DisposeAsync teardown has nothing to clean up.
            // ─────────────────────────────────────────────────────────────────
            var finalList = await _api.ListBindingsAsync(_resourceSetId);

            finalList.Should().NotBeNull();
            finalList.Roles.Should().BeNullOrEmpty(
                "all bindings have been explicitly deleted — list must be empty");
        }
    }
}
