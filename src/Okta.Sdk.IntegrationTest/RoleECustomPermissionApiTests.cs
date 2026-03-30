// <copyright file="RoleECustomPermissionApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
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
    /// Integration tests for <see cref="RoleECustomPermissionApi"/>.
    ///
    /// SDK Methods &amp; Endpoints Covered (all 10 signatures — 5 functional + 5 WithHttpInfo):
    /// ┌─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ Method                                  │ HTTP   │ Status │ Endpoint                                                                                            │
    /// ├─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ ListRolePermissionsAsync                │ GET    │ 200    │ /api/v1/iam/roles/{roleIdOrLabel}/permissions (by id)                                               │
    /// │ ListRolePermissionsWithHttpInfoAsync    │ GET    │ 200    │ same (by label — label routing confirmed working)                                                   │
    /// │ CreateRolePermissionAsync               │ POST   │ 204    │ /api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType} (by id — void return)                │
    /// │ CreateRolePermissionWithHttpInfoAsync   │ POST   │ 204    │ same (by label — WithHttpInfo; explicit HTTP 204 assertion)                                         │
    /// │ GetRolePermissionAsync                  │ GET    │ 200    │ /api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType} (by id)                              │
    /// │ GetRolePermissionWithHttpInfoAsync      │ GET    │ 200    │ same (by label — label routing confirmed working)                                                   │
    /// │ ReplaceRolePermissionAsync              │ PUT    │ 200    │ /api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType} (by id)                              │
    /// │ ReplaceRolePermissionWithHttpInfoAsync  │ PUT    │ 200    │ same (by label — label routing confirmed working)                                                   │
    /// │ DeleteRolePermissionWithHttpInfoAsync   │ DELETE │ 204    │ /api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType} (by id — explicit status assertion)  │
    /// │ DeleteRolePermissionAsync               │ DELETE │ 204    │ same (by label — void-return variant; confirmed via subsequent 404 GET)                             │
    /// └─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
    ///
    /// </summary>
    [Collection(nameof(RoleECustomPermissionApiTests))]
    public class RoleECustomPermissionApiTests : IAsyncLifetime
    {
        // Permission types used throughout the test — two stable, non-overlapping read permissions.
        private const string Perm1 = "okta.users.read";
        private const string Perm2 = "okta.groups.read";
        private const string Perm3 = "okta.users.manage";

        // ── API clients ────────────────────────────────────────────────────────
        private readonly RoleECustomPermissionApi _api     = new();
        private readonly RoleECustomApi _roleApi = new();

        // ── Fixture state ──────────────────────────────────────────────────────
        private string _roleId;
        private string _roleLabel;

        // ══════════════════════════════════════════════════════════════════════
        //  SETUP — create one custom role seeded with Perm1
        // ══════════════════════════════════════════════════════════════════════

        public async Task InitializeAsync()
        {
            var suffix = new Random().Next(100_000_000, 999_999_999).ToString();
            _roleLabel = $"roleeperm-{suffix}";

            var role = await _roleApi.CreateRoleAsync(new CreateIamRoleRequest
            {
                Label       = _roleLabel,
                Description = "Integration test — RoleECustomPermissionApi",
                Permissions = new System.Collections.Generic.List<string> { Perm1 },
            });
            _roleId = role.Id;
        }

        // ══════════════════════════════════════════════════════════════════════
        //  TEARDOWN — delete the fixture role (removes all its permissions too)
        // ══════════════════════════════════════════════════════════════════════

        public async Task DisposeAsync()
        {
            if (string.IsNullOrEmpty(_roleId)) return;
            try { await _roleApi.DeleteRoleAsync(_roleId); } catch { /* ignore */ }
        }

        // ══════════════════════════════════════════════════════════════════════
        //  SINGLE COMPREHENSIVE TEST — covers all 10 SDK signatures in one flow
        // ══════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task CustomRolePermissions_FullWorkflow_ShouldSucceed()
        {
            // ─────────────────────────────────────────────────────────────────
            // Step 1 — ListRolePermissionsAsync (GET /permissions by role id)
            //   The role was seeded with Perm1, so exactly one permission must
            //   appear. Validate every field of the Permission object and all
            //   _links on both the collection and the individual item.
            // ─────────────────────────────────────────────────────────────────
            var list1 = await _api.ListRolePermissionsAsync(_roleId);

            list1.Should().NotBeNull();
            list1._Permissions.Should().HaveCount(1,
                "the role was seeded with exactly one permission (Perm1)");

            var perm1Item = list1._Permissions[0];
            perm1Item.Label.Should().Be(Perm1,
                "the seeded permission label must match");
            perm1Item.Created.Should().NotBe(default(DateTimeOffset),
                "Created timestamp must be populated");
            perm1Item.LastUpdated.Should().NotBe(default(DateTimeOffset),
                "LastUpdated timestamp must be populated");
            perm1Item.Links.Should().NotBeNull(
                "each permission in the list must have _links");
            perm1Item.Links.Self.Should().NotBeNull(
                "_links.self must be present");
            perm1Item.Links.Self.Href.Should().Contain(Perm1,
                "_links.self href must include the permission type");
            perm1Item.Links.Self.Href.Should().Contain(_roleId,
                "_links.self href must include the role id");
            perm1Item.Links.Role.Should().NotBeNull(
                "_links.role must be present");
            perm1Item.Links.Role.Href.Should().Contain(_roleId,
                "_links.role href must reference the parent role id");

            // ─────────────────────────────────────────────────────────────────
            // Step 2 — CreateRolePermissionAsync (POST by role id — void return)
            //   Add Perm2 to the role using the by-id code path.
            //   Response is 204 No Content; verify by listing afterwards.
            // ─────────────────────────────────────────────────────────────────
            await _api.CreateRolePermissionAsync(_roleId, Perm2);

            var listAfterAdd1 = await _api.ListRolePermissionsAsync(_roleId);
            listAfterAdd1._Permissions.Should().HaveCount(2,
                "Perm2 was just added — count must increase to 2");
            listAfterAdd1._Permissions.Should().Contain(p => p.Label == Perm2,
                "Perm2 must appear in the list after creation");

            // ─────────────────────────────────────────────────────────────────
            // Step 3 — CreateRolePermissionWithHttpInfoAsync (POST by label)
            //   Add Perm3 using the role label (not id) and assert HTTP 204.
            // ─────────────────────────────────────────────────────────────────
            var createPerm3Http = await _api.CreateRolePermissionWithHttpInfoAsync(_roleLabel, Perm3);

            ((int)createPerm3Http.StatusCode).Should().Be(204,
                "POST /permissions/{permissionType} must return HTTP 204 No Content");

            var listAfterAdd2 = await _api.ListRolePermissionsAsync(_roleId);
            listAfterAdd2._Permissions.Should().HaveCount(3,
                "Perm3 was just added — count must increase to 3");
            listAfterAdd2._Permissions.Should().Contain(p => p.Label == Perm3,
                "Perm3 must appear in the list after creation by label");

            // ─────────────────────────────────────────────────────────────────
            // Step 4 — ListRolePermissionsWithHttpInfoAsync (GET by label)
            //   Exercise the WithHttpInfo code path and label routing.
            //   All 3 permissions must appear.
            // ─────────────────────────────────────────────────────────────────
            var listByLabelHttp = await _api.ListRolePermissionsWithHttpInfoAsync(_roleLabel);

            ((int)listByLabelHttp.StatusCode).Should().Be(200,
                "GET /permissions (by label) must return HTTP 200");
            listByLabelHttp.Data.Should().NotBeNull();
            listByLabelHttp.Data._Permissions.Should().HaveCount(3,
                "all 3 permissions must appear when listing by role label");
            listByLabelHttp.Data._Permissions.Should().Contain(p => p.Label == Perm1,
                "Perm1 must appear in the list fetched by label");
            listByLabelHttp.Data._Permissions.Should().Contain(p => p.Label == Perm2,
                "Perm2 must appear in the list fetched by label");
            listByLabelHttp.Data._Permissions.Should().Contain(p => p.Label == Perm3,
                "Perm3 must appear in the list fetched by label");

            // Verify per-item field completeness in the WithHttpInfo list response.
            foreach (var p in listByLabelHttp.Data._Permissions)
            {
                p.Label.Should().NotBeNullOrEmpty(
                    "every listed permission must have a non-empty label");
                p.Created.Should().NotBe(default(DateTimeOffset),
                    "every listed permission must have a Created timestamp");
                p.LastUpdated.Should().NotBe(default(DateTimeOffset),
                    "every listed permission must have a LastUpdated timestamp");
                p.Links.Should().NotBeNull(
                    "every listed permission must include _links");
                p.Links.Self.Should().NotBeNull(
                    "every listed permission must include _links.self");
                p.Links.Self.Href.Should().NotBeNullOrEmpty(
                    "every listed permission _links.self must have a non-empty href");
                p.Links.Role.Should().NotBeNull(
                    "every listed permission must include _links.role");
                p.Links.Role.Href.Should().Contain(_roleId,
                    "every listed permission _links.role must reference the parent role id");
            }

            // ─────────────────────────────────────────────────────────────────
            // Step 5 — GetRolePermissionAsync (GET by role id + permissionType)
            //   Retrieve Perm1 by role id and validate all response fields.
            // ─────────────────────────────────────────────────────────────────
            var getPerm1 = await _api.GetRolePermissionAsync(_roleId, Perm1);

            getPerm1.Should().NotBeNull();
            getPerm1.Label.Should().Be(Perm1,
                "GET must return the permission with the correct label");
            getPerm1.Created.Should().NotBe(default(DateTimeOffset),
                "Created timestamp must be populated");
            getPerm1.LastUpdated.Should().NotBe(default(DateTimeOffset),
                "LastUpdated timestamp must be populated");
            getPerm1.Links.Should().NotBeNull(
                "GET /permissions/{type} must return _links");
            getPerm1.Links.Self.Should().NotBeNull(
                "_links.self must be present");
            getPerm1.Links.Self.Href.Should().Contain(Perm1,
                "_links.self href must include the permission type");
            getPerm1.Links.Self.Href.Should().Contain(_roleId,
                "_links.self href must include the role id");
            getPerm1.Links.Role.Should().NotBeNull(
                "_links.role must be present");
            getPerm1.Links.Role.Href.Should().Contain(_roleId,
                "_links.role href must reference the parent role id");

            // ─────────────────────────────────────────────────────────────────
            // Step 6 — GetRolePermissionWithHttpInfoAsync (GET by label)
            //   Verify label routing for GET single permission.
            // ─────────────────────────────────────────────────────────────────
            var getPerm1ByLabelHttp = await _api.GetRolePermissionWithHttpInfoAsync(_roleLabel, Perm1);

            ((int)getPerm1ByLabelHttp.StatusCode).Should().Be(200,
                "GET /permissions/{type} (by role label) must return HTTP 200");
            getPerm1ByLabelHttp.Data.Should().NotBeNull();
            getPerm1ByLabelHttp.Data.Label.Should().Be(Perm1,
                "fetching by label must resolve to the same permission");
            getPerm1ByLabelHttp.Data.Created.Should().NotBe(default(DateTimeOffset),
                "Created timestamp must be populated when fetched via label routing");
            getPerm1ByLabelHttp.Data.LastUpdated.Should().NotBe(default(DateTimeOffset),
                "LastUpdated timestamp must be populated when fetched via label routing");
            getPerm1ByLabelHttp.Data.Links.Should().NotBeNull(
                "GET by label must return _links");
            getPerm1ByLabelHttp.Data.Links.Self.Should().NotBeNull(
                "_links.self must be present when fetched via label routing");
            getPerm1ByLabelHttp.Data.Links.Self.Href.Should().Contain(Perm1,
                "_links.self href must include the permission type when fetched via label routing");
            getPerm1ByLabelHttp.Data.Links.Self.Href.Should().Contain(_roleId,
                "_links.self href must contain the canonical role id even when fetched via label");
            getPerm1ByLabelHttp.Data.Links.Role.Should().NotBeNull(
                "_links.role must be present when fetched via label routing");
            getPerm1ByLabelHttp.Data.Links.Role.Href.Should().Contain(_roleId,
                "_links.role href must reference the canonical role id when fetched via label");

            // ─────────────────────────────────────────────────────────────────
            // Step 7 — ReplaceRolePermissionAsync (PUT by role id)
            //   PUT is an idempotent re-upsert of the same permission type.
            //   The server must return HTTP 200 with the full Permission body.
            // ─────────────────────────────────────────────────────────────────
            var replacePerm1 = await _api.ReplaceRolePermissionAsync(_roleId, Perm1);

            replacePerm1.Should().NotBeNull();
            replacePerm1.Label.Should().Be(Perm1,
                "PUT must return the permission with the correct label");
            replacePerm1.Created.Should().NotBe(default(DateTimeOffset),
                "Created timestamp must be populated after PUT");
            replacePerm1.LastUpdated.Should().NotBe(default(DateTimeOffset),
                "LastUpdated timestamp must be populated after PUT");
            replacePerm1.Links.Should().NotBeNull(
                "PUT /permissions/{type} must return _links");
            replacePerm1.Links.Self.Should().NotBeNull(
                "_links.self must be present after PUT by id");
            replacePerm1.Links.Self.Href.Should().Contain(Perm1,
                "_links.self href must include the permission type after PUT by id");
            replacePerm1.Links.Self.Href.Should().Contain(_roleId,
                "_links.self href must include the role id after PUT by id");
            replacePerm1.Links.Role.Should().NotBeNull(
                "_links.role must be present after PUT by id");
            replacePerm1.Links.Role.Href.Should().Contain(_roleId,
                "_links.role href must reference the role id after PUT by id");

            // ─────────────────────────────────────────────────────────────────
            // Step 8 — ReplaceRolePermissionWithHttpInfoAsync (PUT by label)
            //   Exercise label routing for PUT and the WithHttpInfo code path.
            // ─────────────────────────────────────────────────────────────────
            var replacePerm2ByLabelHttp = await _api.ReplaceRolePermissionWithHttpInfoAsync(_roleLabel, Perm2);

            ((int)replacePerm2ByLabelHttp.StatusCode).Should().Be(200,
                "PUT /permissions/{type} (by role label) must return HTTP 200");
            replacePerm2ByLabelHttp.Data.Should().NotBeNull();
            replacePerm2ByLabelHttp.Data.Label.Should().Be(Perm2,
                "PUT by label must return the correct permission");
            replacePerm2ByLabelHttp.Data.Created.Should().NotBe(default(DateTimeOffset),
                "Created timestamp must be populated after PUT by label");
            replacePerm2ByLabelHttp.Data.LastUpdated.Should().NotBe(default(DateTimeOffset),
                "LastUpdated timestamp must be populated after PUT by label");
            replacePerm2ByLabelHttp.Data.Links.Should().NotBeNull(
                "PUT by label must return _links");
            replacePerm2ByLabelHttp.Data.Links.Self.Should().NotBeNull(
                "_links.self must be present after PUT by label");
            replacePerm2ByLabelHttp.Data.Links.Self.Href.Should().Contain(Perm2,
                "_links.self href must include the permission type after PUT by label");
            replacePerm2ByLabelHttp.Data.Links.Self.Href.Should().Contain(_roleId,
                "_links.self href must reference the canonical role id after PUT by label");
            replacePerm2ByLabelHttp.Data.Links.Role.Should().NotBeNull(
                "_links.role must be present after PUT by label");
            replacePerm2ByLabelHttp.Data.Links.Role.Href.Should().Contain(_roleId,
                "_links.role href must reference the canonical role id after PUT by label");

            // ─────────────────────────────────────────────────────────────────
            // Step 9 — DeleteRolePermissionWithHttpInfoAsync (DELETE by role id)
            //   Remove Perm3 and assert the response is HTTP 204 No Content.
            //   A subsequent GET must throw ApiException (404).
            // ─────────────────────────────────────────────────────────────────
            var deletePerm3Http = await _api.DeleteRolePermissionWithHttpInfoAsync(_roleId, Perm3);

            ((int)deletePerm3Http.StatusCode).Should().Be(204,
                "DELETE /permissions/{type} (by id) must return HTTP 204 No Content");

            Func<Task> getPerm3AfterDelete = async () =>
                await _api.GetRolePermissionAsync(_roleId, Perm3);
            await getPerm3AfterDelete.Should().ThrowAsync<ApiException>(
                "GET on a deleted permission must throw ApiException (404)");

            // ─────────────────────────────────────────────────────────────────
            // Step 10 — DeleteRolePermissionAsync (DELETE by label — Perm2)
            //   Void-return variant using role label (not id).
            //   Confirm deletion via a subsequent GET that must throw.
            // ─────────────────────────────────────────────────────────────────
            await _api.DeleteRolePermissionAsync(_roleLabel, Perm2);

            Func<Task> getPerm2AfterDelete = async () =>
                await _api.GetRolePermissionAsync(_roleId, Perm2);
            await getPerm2AfterDelete.Should().ThrowAsync<ApiException>(
                "GET on a deleted permission must throw ApiException (404)");

            // ─────────────────────────────────────────────────────────────────
            // Step 11 — ListRolePermissionsAsync (GET — only Perm1 remains)
            //   After deleting Perm2 and Perm3, only the seeded Perm1 must
            //   remain, confirming no leaked permissions.
            // ─────────────────────────────────────────────────────────────────
            var finalList = await _api.ListRolePermissionsAsync(_roleId);

            finalList.Should().NotBeNull();
            finalList._Permissions.Should().HaveCount(1,
                "Perm2 and Perm3 were deleted — only the seeded Perm1 must remain");
            finalList._Permissions[0].Label.Should().Be(Perm1,
                "the sole remaining permission must be the originally seeded Perm1");
        }
    }
}
