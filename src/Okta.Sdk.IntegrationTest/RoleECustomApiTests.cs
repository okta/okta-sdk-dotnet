// <copyright file="RoleECustomApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for <see cref="RoleECustomApi"/>.
    ///
    /// SDK Methods &amp; Endpoints Covered (all 10 signatures — 5 functional + 5 WithHttpInfo):
    /// ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ Method                             │ HTTP   │ Status │ Endpoint                                                                                  │
    /// ├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ CreateRoleAsync                    │ POST   │ 200    │ /api/v1/iam/roles (returns full IamRole with id, label, description, timestamps, _links)  │
    /// │ CreateRoleWithHttpInfoAsync        │ POST   │ 200    │ same (second role — exercises WithHttpInfo code path)                                     │
    /// │ ListRolesAsync                     │ GET    │ 200    │ /api/v1/iam/roles (no after — count baseline + post-create verification)                  │
    /// │ ListRolesAsync (after)             │ GET    │ 200    │ same (with after cursor — exercises optional pagination parameter)                        │
    /// │ ListRolesWithHttpInfoAsync         │ GET    │ 200    │ same (no after — exercises WithHttpInfo code path)                                        │
    /// │ ListRolesWithHttpInfoAsync (after) │ GET    │ 200    │ same (with after cursor — WithHttpInfo + pagination combined)                             │
    /// │ GetRoleAsync                       │ GET    │ 200    │ /api/v1/iam/roles/{roleIdOrLabel} (by id)                                                 │
    /// │ GetRoleWithHttpInfoAsync           │ GET    │ 200    │ same (by label — label routing confirmed working)                                         │
    /// │ ReplaceRoleAsync                   │ PUT    │ 200    │ /api/v1/iam/roles/{roleIdOrLabel} (by id — updates label/description)                     │
    /// │ ReplaceRoleWithHttpInfoAsync       │ PUT    │ 200    │ same (by label — label routing confirmed working)                                         │
    /// │ DeleteRoleWithHttpInfoAsync        │ DELETE │ 204    │ /api/v1/iam/roles/{roleIdOrLabel} (by id — explicit status code assertion)                │
    /// │ DeleteRoleAsync                    │ DELETE │ 204    │ same (by label — void-return variant; confirmed via subsequent 404 GET)                   │
    /// └──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
    ///
    /// </summary>
    [Collection(nameof(RoleECustomApiTests))]
    public class RoleECustomApiTests : IAsyncLifetime
    {
        // ── API client ─────────────────────────────────────────────────────────
        private readonly RoleECustomApi _api = new();

        // ── Fixture state ──────────────────────────────────────────────────────
        private string _role1Id;
        private string _role1Label;
        private string _role2Id;
        private string _role2Label;

        // ══════════════════════════════════════════════════════════════════════
        //  SETUP  — nothing to pre-create; roles are created inside the test
        // ══════════════════════════════════════════════════════════════════════

        public Task InitializeAsync() => Task.CompletedTask;

        // ══════════════════════════════════════════════════════════════════════
        //  TEARDOWN — safety-net: delete any roles that survived a test failure
        // ══════════════════════════════════════════════════════════════════════

        public async Task DisposeAsync()
        {
            foreach (var roleId in new[] { _role1Id, _role2Id })
            {
                if (string.IsNullOrEmpty(roleId)) continue;
                try { await _api.DeleteRoleAsync(roleId); } catch { /* already deleted or never created */ }
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        //  SINGLE COMPREHENSIVE TEST — covers all 10 SDK signatures in one flow
        // ══════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task CustomRoles_FullWorkflow_ShouldSucceed()
        {
            var suffix = new Random().Next(100_000_000, 999_999_999).ToString();
            _role1Label = $"roleecustom-1-{suffix}";
            _role2Label = $"roleecustom-2-{suffix}";
            const string updatedDescription  = "integration test — updated description";
            const string updatedDescription2 = "integration test — updated description 2";

            // ─────────────────────────────────────────────────────────────────
            // Step 1 — ListRolesAsync (GET /api/v1/iam/roles — baseline count)
            //   Record how many custom roles exist before the test creates any,
            //   so we can verify the count increases exactly by 2 after creation.
            // ─────────────────────────────────────────────────────────────────
            var baselineList = await _api.ListRolesAsync();

            baselineList.Should().NotBeNull();
            baselineList.Roles.Should().NotBeNull(
                "the roles array must be present even when no custom roles exist");
            baselineList.Links.Should().NotBeNull(
                "_links must be present in the list response");
            // _links.next is absent when the result fits on one page; tolerate either.
            int baselineCount = baselineList.Roles.Count;

            // ─────────────────────────────────────────────────────────────────
            // Step 2 — CreateRoleAsync (POST /api/v1/iam/roles — role1)
            //   Create the first custom role and validate every field the API
            //   returns: id, label, description, created, lastUpdated, _links.
            // ─────────────────────────────────────────────────────────────────
            var role1 = await _api.CreateRoleAsync(new CreateIamRoleRequest
            {
                Label       = _role1Label,
                Description = "integration test role 1",
                Permissions = new List<string> { "okta.users.read" },
            });
            _role1Id = role1.Id;

            role1.Should().NotBeNull();
            role1.Id.Should().NotBeNullOrEmpty(
                "server must assign an id to the newly created role");
            role1.Label.Should().Be(_role1Label,
                "label must match the value supplied in the create request");
            role1.Description.Should().Be("integration test role 1",
                "description must match the value supplied in the create request");
            role1.Created.Should().NotBe(default(DateTimeOffset),
                "server must populate the Created timestamp");
            role1.LastUpdated.Should().NotBe(default(DateTimeOffset),
                "server must populate the LastUpdated timestamp");
            role1.Links.Should().NotBeNull(
                "POST /api/v1/iam/roles must return _links");
            role1.Links.Self.Should().NotBeNull(
                "_links.self must be present in the create response");
            role1.Links.Self.Href.Should().Contain(role1.Id,
                "_links.self href must reference the role id");
            role1.Links.Permissions.Should().NotBeNull(
                "_links.permissions must be present in the create response");
            role1.Links.Permissions.Href.Should().Contain(role1.Id,
                "_links.permissions href must reference the role id");

            // ─────────────────────────────────────────────────────────────────
            // Step 3 — CreateRoleWithHttpInfoAsync (POST — role2)
            //   Exercise the WithHttpInfo code path and assert HTTP 200.
            // ─────────────────────────────────────────────────────────────────
            var createRole2Http = await _api.CreateRoleWithHttpInfoAsync(new CreateIamRoleRequest
            {
                Label       = _role2Label,
                Description = "integration test role 2",
                Permissions = new List<string> { "okta.users.read" },
            });
            _role2Id = createRole2Http.Data.Id;

            ((int)createRole2Http.StatusCode).Should().Be(200,
                "POST /api/v1/iam/roles must return HTTP 200");
            createRole2Http.Data.Should().NotBeNull();
            createRole2Http.Data.Id.Should().NotBeNullOrEmpty(
                "server must assign an id to the second created role");
            createRole2Http.Data.Label.Should().Be(_role2Label,
                "label must match the value supplied for role2");
            createRole2Http.Data.Description.Should().Be("integration test role 2",
                "description must match the value supplied for role2");
            createRole2Http.Data.Created.Should().NotBe(default(DateTimeOffset),
                "server must populate the Created timestamp for role2");
            createRole2Http.Data.LastUpdated.Should().NotBe(default(DateTimeOffset),
                "server must populate the LastUpdated timestamp for role2");
            createRole2Http.Data.Links.Should().NotBeNull(
                "POST /api/v1/iam/roles must return _links for role2");
            createRole2Http.Data.Links.Self.Should().NotBeNull(
                "_links.self must be present in the create response for role2");
            createRole2Http.Data.Links.Self.Href.Should().Contain(createRole2Http.Data.Id,
                "_links.self href must reference the role2 id");
            createRole2Http.Data.Links.Permissions.Should().NotBeNull(
                "_links.permissions must be present in the create response for role2");
            createRole2Http.Data.Links.Permissions.Href.Should().Contain(createRole2Http.Data.Id,
                "_links.permissions href must reference the role2 id");

            // ─────────────────────────────────────────────────────────────────
            // Step 4 — ListRolesAsync (GET — count increased by 2)
            //   After creating both roles the list must contain at least
            //   baselineCount + 2 entries, and both new roles must appear.
            // ─────────────────────────────────────────────────────────────────
            var listAfterCreate = await _api.ListRolesAsync();

            listAfterCreate.Should().NotBeNull();
            listAfterCreate.Roles.Should().NotBeNull();
            listAfterCreate.Roles.Count.Should().Be(baselineCount + 2,
                "exactly 2 new roles were created since the baseline snapshot");
            listAfterCreate.Roles.Should().Contain(r => r.Id == _role1Id,
                "role1 must appear in the full list");
            listAfterCreate.Roles.Should().Contain(r => r.Id == _role2Id,
                "role2 must appear in the full list");
            listAfterCreate.Links.Should().NotBeNull("_links must be present");

            // Verify that list items carry full role details (not stubs).
            foreach (var listedRole in listAfterCreate.Roles)
            {
                listedRole.Id.Should().NotBeNullOrEmpty(
                    "every listed role must have a non-empty id");
                listedRole.Label.Should().NotBeNullOrEmpty(
                    "every listed role must have a non-empty label");
                listedRole.Links.Should().NotBeNull(
                    "every listed role must include _links");
                listedRole.Links.Self.Should().NotBeNull(
                    "every listed role must include _links.self");
                listedRole.Links.Self.Href.Should().NotBeNullOrEmpty(
                    "every listed role _links.self must have a non-empty href");
            }

            // ─────────────────────────────────────────────────────────────────
            // Step 5 — ListRolesAsync with after cursor
            //   Use role1Id as a fallback cursor (or a real next-page link if
            //   one was issued) to exercise the optional `after` parameter.
            //   The server must return HTTP 200 regardless.
            // ─────────────────────────────────────────────────────────────────
            string afterCursor = listAfterCreate.Links?.Next?.Href ?? _role1Id;

            var listWithAfter = await _api.ListRolesAsync(after: afterCursor);

            listWithAfter.Should().NotBeNull(
                "ListRolesAsync with after parameter must return a non-null result");
            listWithAfter.Roles.Should().NotBeNull(
                "roles array must be present even when the cursor page is empty");

            // ─────────────────────────────────────────────────────────────────
            // Step 6 — ListRolesWithHttpInfoAsync (GET — WithHttpInfo variant)
            //   Verify the wrapper returns HTTP 200 and the same data.
            // ─────────────────────────────────────────────────────────────────
            var listHttp = await _api.ListRolesWithHttpInfoAsync();

            ((int)listHttp.StatusCode).Should().Be(200,
                "GET /api/v1/iam/roles must return HTTP 200");
            listHttp.Data.Should().NotBeNull();
            listHttp.Data.Roles.Should().Contain(r => r.Id == _role1Id,
                "role1 must appear via the WithHttpInfo list code path");
            listHttp.Data.Roles.Should().Contain(r => r.Id == _role2Id,
                "role2 must appear via the WithHttpInfo list code path");

            // ─────────────────────────────────────────────────────────────────
            // Step 7 — ListRolesWithHttpInfoAsync with after cursor
            //   Exercise both WithHttpInfo and the pagination parameter together.
            // ─────────────────────────────────────────────────────────────────
            string afterCursor2 = listHttp.Data.Links?.Next?.Href ?? _role1Id;

            var listWithAfterHttp = await _api.ListRolesWithHttpInfoAsync(after: afterCursor2);

            ((int)listWithAfterHttp.StatusCode).Should().Be(200,
                "GET /api/v1/iam/roles?after=<cursor> must return HTTP 200");
            listWithAfterHttp.Data.Should().NotBeNull();
            listWithAfterHttp.Data.Roles.Should().NotBeNull(
                "roles array must be present in paginated response");

            // ─────────────────────────────────────────────────────────────────
            // Step 8 — GetRoleAsync (GET /api/v1/iam/roles/{roleId} by id)
            //   Retrieve role1 by id and validate every field.
            // ─────────────────────────────────────────────────────────────────
            var getRole1 = await _api.GetRoleAsync(_role1Id);

            getRole1.Should().NotBeNull();
            getRole1.Id.Should().Be(_role1Id,
                "GET must return the role with the correct id");
            getRole1.Label.Should().Be(_role1Label,
                "label must not have changed since creation");
            getRole1.Description.Should().Be("integration test role 1",
                "description must not have changed since creation");
            getRole1.Created.Should().NotBe(default(DateTimeOffset),
                "Created timestamp must be populated");
            getRole1.LastUpdated.Should().NotBe(default(DateTimeOffset),
                "LastUpdated timestamp must be populated");
            getRole1.Links.Should().NotBeNull("GET must return _links");
            getRole1.Links.Self.Should().NotBeNull(
                "_links.self must be present");
            getRole1.Links.Self.Href.Should().Contain(_role1Id,
                "_links.self href must reference the role id");
            getRole1.Links.Permissions.Should().NotBeNull(
                "_links.permissions must be present");
            getRole1.Links.Permissions.Href.Should().Contain(_role1Id,
                "_links.permissions href must reference the role id");

            // ─────────────────────────────────────────────────────────────────
            // Step 9 — GetRoleWithHttpInfoAsync (GET by label)
            //   Verify that {roleIdOrLabel} accepts a label (not just an id)
            //   and that the response is HTTP 200 with the correct role.
            // ─────────────────────────────────────────────────────────────────
            var getRole1ByLabelHttp = await _api.GetRoleWithHttpInfoAsync(_role1Label);

            ((int)getRole1ByLabelHttp.StatusCode).Should().Be(200,
                "GET /api/v1/iam/roles/{label} must return HTTP 200");
            getRole1ByLabelHttp.Data.Should().NotBeNull();
            getRole1ByLabelHttp.Data.Id.Should().Be(_role1Id,
                "fetching by label must resolve to the same role as fetching by id");
            getRole1ByLabelHttp.Data.Label.Should().Be(_role1Label,
                "label must be preserved when fetched via label routing");
            getRole1ByLabelHttp.Data.Description.Should().Be("integration test role 1",
                "description must be preserved when fetched via label routing");
            getRole1ByLabelHttp.Data.Created.Should().NotBe(default(DateTimeOffset),
                "Created timestamp must be populated when fetched via label routing");
            getRole1ByLabelHttp.Data.LastUpdated.Should().NotBe(default(DateTimeOffset),
                "LastUpdated timestamp must be populated when fetched via label routing");
            getRole1ByLabelHttp.Data.Links.Should().NotBeNull(
                "GET by label must return _links");
            getRole1ByLabelHttp.Data.Links.Self.Href.Should().Contain(_role1Id,
                "_links.self href must reference the canonical role id even when fetched via label");
            getRole1ByLabelHttp.Data.Links.Permissions.Should().NotBeNull(
                "_links.permissions must be present when fetched via label routing");
            getRole1ByLabelHttp.Data.Links.Permissions.Href.Should().Contain(_role1Id,
                "_links.permissions href must reference the canonical role id when fetched via label");

            // ─────────────────────────────────────────────────────────────────
            // Step 10 — ReplaceRoleAsync (PUT /api/v1/iam/roles/{roleId} by id)
            //   Update role1's description (UpdateIamRoleRequest accepts label +
            //   description; label is required and must be unchanged or updated).
            //   Assert the description is updated and lastUpdated is refreshed.
            // ─────────────────────────────────────────────────────────────────
            var replaceByIdResult = await _api.ReplaceRoleAsync(_role1Id, new UpdateIamRoleRequest
            {
                Label       = _role1Label,
                Description = updatedDescription,
            });

            replaceByIdResult.Should().NotBeNull();
            replaceByIdResult.Id.Should().Be(_role1Id,
                "id must not change after a PUT");
            replaceByIdResult.Label.Should().Be(_role1Label,
                "label must match the value supplied in the replace request");
            replaceByIdResult.Description.Should().Be(updatedDescription,
                "description must reflect the new value supplied in the replace request");
            replaceByIdResult.LastUpdated.Should().BeAfter(role1.LastUpdated,
                "LastUpdated must be refreshed when a replace is performed");
            replaceByIdResult.Links.Self.Href.Should().Contain(_role1Id,
                "_links.self href must still reference the same role id after replace");
            replaceByIdResult.Links.Permissions.Should().NotBeNull(
                "_links.permissions must still be present after a PUT by id");
            replaceByIdResult.Links.Permissions.Href.Should().Contain(_role1Id,
                "_links.permissions href must still reference the role id after a PUT by id");

            // ─────────────────────────────────────────────────────────────────
            // Step 11 — ReplaceRoleWithHttpInfoAsync (PUT by label)
            //   Exercise label routing for PUT and the WithHttpInfo code path.
            // ─────────────────────────────────────────────────────────────────
            var replaceByLabelHttp = await _api.ReplaceRoleWithHttpInfoAsync(
                _role1Label,
                new UpdateIamRoleRequest
                {
                    Label       = _role1Label,
                    Description = updatedDescription2,
                });

            ((int)replaceByLabelHttp.StatusCode).Should().Be(200,
                "PUT /api/v1/iam/roles/{label} must return HTTP 200");
            replaceByLabelHttp.Data.Should().NotBeNull();
            replaceByLabelHttp.Data.Id.Should().Be(_role1Id,
                "id must not change after a PUT by label");
            replaceByLabelHttp.Data.Description.Should().Be(updatedDescription2,
                "description must reflect the second update");
            replaceByLabelHttp.Data.LastUpdated.Should().BeAfter(replaceByIdResult.LastUpdated,
                "LastUpdated must be refreshed again after the second replace");
            replaceByLabelHttp.Data.Links.Should().NotBeNull(
                "PUT by label must return _links");
            replaceByLabelHttp.Data.Links.Self.Should().NotBeNull(
                "_links.self must be present after a PUT by label");
            replaceByLabelHttp.Data.Links.Self.Href.Should().Contain(_role1Id,
                "_links.self href must reference the canonical role id after a PUT by label");
            replaceByLabelHttp.Data.Links.Permissions.Should().NotBeNull(
                "_links.permissions must be present after a PUT by label");
            replaceByLabelHttp.Data.Links.Permissions.Href.Should().Contain(_role1Id,
                "_links.permissions href must reference the canonical role id after a PUT by label");

            // ─────────────────────────────────────────────────────────────────
            // Step 12 — DeleteRoleWithHttpInfoAsync (DELETE by id — role1)
            //   Remove role1 and assert the response is HTTP 204.
            //   A subsequent GET must throw ApiException (404).
            // ─────────────────────────────────────────────────────────────────
            var deleteRole1Http = await _api.DeleteRoleWithHttpInfoAsync(_role1Id);

            ((int)deleteRole1Http.StatusCode).Should().Be(204,
                "DELETE /api/v1/iam/roles/{id} must return HTTP 204 No Content");

            Func<Task> getDeletedRole1 = async () => await _api.GetRoleAsync(_role1Id);
            await getDeletedRole1.Should().ThrowAsync<ApiException>(
                "GET on a deleted role must throw ApiException (404)");

            _role1Id = null; // prevent DisposeAsync from attempting a redundant delete

            // ─────────────────────────────────────────────────────────────────
            // Step 13 — DeleteRoleAsync (DELETE by label — role2, void-return variant)
            //   Remove role2 using its label (not id) to confirm label routing
            //   works for DELETE.  Confirm deletion via a subsequent GET.
            // ─────────────────────────────────────────────────────────────────
            await _api.DeleteRoleAsync(_role2Label);

            Func<Task> getDeletedRole2 = async () => await _api.GetRoleAsync(_role2Id);
            await getDeletedRole2.Should().ThrowAsync<ApiException>(
                "GET on a deleted role must throw ApiException (404)");

            _role2Id = null; // prevent DisposeAsync from attempting a redundant delete

            // ─────────────────────────────────────────────────────────────────
            // Step 14 — ListRolesAsync (GET — count back to baseline)
            //   After deleting both roles the list must be back to the baseline
            //   count, confirming no leaked resources.
            // ─────────────────────────────────────────────────────────────────
            var finalList = await _api.ListRolesAsync();

            finalList.Should().NotBeNull();
            finalList.Roles.Should().NotBeNull();
            finalList.Roles.Count.Should().Be(baselineCount,
                "both test roles have been deleted — count must return to baseline");
        }
    }
}
