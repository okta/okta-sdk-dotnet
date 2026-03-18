// <copyright file="RoleBTargetBGroupApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for <see cref="RoleBTargetBGroupApi"/>.
    ///
    /// SDK Methods &amp; Endpoints Covered (all 16 signatures — 8 functional + 8 WithHttpInfo):
    /// ┌─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ Method                                                                                        │ HTTP   │ Status │ Endpoint                                                         │
    /// ├─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ ListApplicationTargetsForApplicationAdministratorRoleForGroup                                 │ GET    │ 200    │ /api/v1/groups/{gid}/roles/{rid}/targets/catalog/apps             │
    /// │   — called with default params (empty list, non-empty list) and with limit=1                  │        │        │                                                                  │
    /// │ ListApplicationTargetsForApplicationAdministratorRoleForGroupWithHttpInfoAsync                │ GET    │ 200    │ same (empty, limit=1)                                            │
    /// │ AssignAppTargetToAdminRoleForGroupAsync                                                       │ PUT    │ 204    │ /api/v1/groups/{gid}/roles/{rid}/targets/catalog/apps/{appName}   │
    /// │ AssignAppTargetToAdminRoleForGroupWithHttpInfoAsync                                           │ PUT    │ 204    │ same                                                             │
    /// │ AssignAppInstanceTargetToAppAdminRoleForGroupAsync                                            │ PUT    │ 204    │ /api/v1/groups/{gid}/roles/{rid}/targets/catalog/apps/{appName}/{appId} │
    /// │ AssignAppInstanceTargetToAppAdminRoleForGroupWithHttpInfoAsync                                │ PUT    │ 204    │ same                                                             │
    /// │ UnassignAppInstanceTargetToAppAdminRoleForGroupAsync                                          │ DELETE │ 204    │ /api/v1/groups/{gid}/roles/{rid}/targets/catalog/apps/{appName}/{appId} │
    /// │ UnassignAppInstanceTargetToAppAdminRoleForGroupWithHttpInfoAsync                              │ DELETE │ 204    │ same                                                             │
    /// │ UnassignAppTargetToAdminRoleForGroupAsync                                                     │ DELETE │ 204    │ /api/v1/groups/{gid}/roles/{rid}/targets/catalog/apps/{appName}   │
    /// │ UnassignAppTargetToAdminRoleForGroupWithHttpInfoAsync                                         │ DELETE │ 204    │ same                                                             │
    /// │ ListGroupTargetsForGroupRole                                                                  │ GET    │ 200    │ /api/v1/groups/{gid}/roles/{rid}/targets/groups                   │
    /// │   — called with default params (empty list, non-empty list) and with limit=1                  │        │        │                                                                  │
    /// │ ListGroupTargetsForGroupRoleWithHttpInfoAsync                                                 │ GET    │ 200    │ same (empty, limit=1 non-empty)                                   │
    /// │ AssignGroupTargetToGroupAdminRoleAsync                                                        │ PUT    │ 204    │ /api/v1/groups/{gid}/roles/{rid}/targets/groups/{targetGroupId}   │
    /// │ AssignGroupTargetToGroupAdminRoleWithHttpInfoAsync                                            │ PUT    │ 204    │ same                                                             │
    /// │ UnassignGroupTargetFromGroupAdminRoleAsync                                                    │ DELETE │ 204    │ /api/v1/groups/{gid}/roles/{rid}/targets/groups/{targetGroupId}   │
    /// │ UnassignGroupTargetFromGroupAdminRoleWithHttpInfoAsync                                        │ DELETE │ 204    │ same                                                             │
    /// └─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
    ///
    /// </summary>
    [Collection(nameof(RoleBTargetBGroupApiTests))]
    public class RoleBTargetBGroupApiTests : IAsyncLifetime
    {
        // ── API Clients ─────────────────────────────────────────────────────────
        private readonly RoleBTargetBGroupApi   _targetApi      = new();
        private readonly RoleAssignmentBGroupApi _roleAssignApi = new();
        private readonly GroupApi               _groupApi       = new();
        private readonly ApplicationApi         _appApi         = new();

        // ── Test state ──────────────────────────────────────────────────────────
        private string _adminGroupId;     // group that receives role assignments
        private string _appAdminRoleId;   // APP_ADMIN role assignment id
        private string _userAdminRoleId;  // USER_ADMIN role assignment id
        private string _targetGroup1Id;   // first group used as a group-target
        private string _targetGroup2Id;   // second group used as a group-target
        private string _app1Id;           // first bookmark app instance
        private string _app2Id;           // second bookmark app instance

        // ── Setup ───────────────────────────────────────────────────────────────

        public async Task InitializeAsync()
        {
            var suffix = Guid.NewGuid().ToString("N")[..12];

            // 1. Create the admin group that will receive role assignments.
            var adminGroup = await _groupApi.AddGroupAsync(new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile { Name = $"rbtbg-admin-{suffix}" },
            });
            _adminGroupId = adminGroup.Id;

            // 2. Create two target groups (need 2 to safely test group-target unassign
            //    without hitting the "cannot remove last target" 400 constraint).
            var tgt1 = await _groupApi.AddGroupAsync(new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile { Name = $"rbtbg-target1-{suffix}" },
            });
            _targetGroup1Id = tgt1.Id;

            var tgt2 = await _groupApi.AddGroupAsync(new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile { Name = $"rbtbg-target2-{suffix}" },
            });
            _targetGroup2Id = tgt2.Id;

            // 3. Create two bookmark app instances (need 2 to safely test app-instance-target
            //    unassign without hitting the "cannot remove last target" 400 constraint).
            var bookmarkApp = new BookmarkApplication
            {
                Name      = "bookmark",
                SignOnMode = ApplicationSignOnMode.BOOKMARK,
                Settings  = new BookmarkApplicationSettings
                {
                    App = new BookmarkApplicationSettingsApplication
                    {
                        Url                = "https://example.com",
                        RequestIntegration = false,
                    },
                },
            };

            bookmarkApp.Label = $"rbtbg-app1-{suffix}";
            var app1 = await _appApi.CreateApplicationAsync(bookmarkApp);
            _app1Id = app1.Id;

            bookmarkApp.Label = $"rbtbg-app2-{suffix}";
            var app2 = await _appApi.CreateApplicationAsync(bookmarkApp);
            _app2Id = app2.Id;

            // 4. Assign APP_ADMIN role to the admin group (for app-target tests).
            var appAdminResp = await _roleAssignApi.AssignRoleToGroupAsync(
                _adminGroupId,
                new AssignRoleToGroupRequest(new StandardRoleAssignmentSchema { Type = "APP_ADMIN" }));
            _appAdminRoleId = ResolveRoleId(appAdminResp);

            // 5. Assign USER_ADMIN role to the admin group (for group-target tests).
            var userAdminResp = await _roleAssignApi.AssignRoleToGroupAsync(
                _adminGroupId,
                new AssignRoleToGroupRequest(new StandardRoleAssignmentSchema { Type = "USER_ADMIN" }));
            _userAdminRoleId = ResolveRoleId(userAdminResp);
        }

        // ── Teardown ────────────────────────────────────────────────────────────

        public async Task DisposeAsync()
        {
            // Unassign roles (implicitly clears all targets on the admin group).
            if (!string.IsNullOrEmpty(_adminGroupId))
            {
                if (!string.IsNullOrEmpty(_appAdminRoleId))
                    try { await _roleAssignApi.UnassignRoleFromGroupAsync(_adminGroupId, _appAdminRoleId); } catch { /* ignore */ }

                if (!string.IsNullOrEmpty(_userAdminRoleId))
                    try { await _roleAssignApi.UnassignRoleFromGroupAsync(_adminGroupId, _userAdminRoleId); } catch { /* ignore */ }
            }

            // Deactivate + delete both app instances.
            foreach (var appId in new[] { _app1Id, _app2Id })
            {
                if (string.IsNullOrEmpty(appId)) continue;
                try { await _appApi.DeactivateApplicationAsync(appId); } catch { /* ignore */ }
                try { await _appApi.DeleteApplicationAsync(appId); }     catch { /* ignore */ }
            }

            // Delete all three groups (admin group + 2 target groups).
            foreach (var groupId in new[] { _adminGroupId, _targetGroup1Id, _targetGroup2Id })
            {
                if (string.IsNullOrEmpty(groupId)) continue;
                try { await _groupApi.DeleteGroupAsync(groupId); } catch { /* ignore */ }
            }
        }

        // ── Helper ──────────────────────────────────────────────────────────────

        private static string ResolveRoleId(ListGroupAssignedRoles200ResponseInner wrapper)
        {
            if (wrapper?.ActualInstance is StandardRole sr) return sr.Id;
            if (wrapper?.ActualInstance is CustomRole   cr) return cr.Id;
            return null;
        }

        // ═══════════════════════════════════════════════════════════════════════
        //  SINGLE COMPREHENSIVE TEST — covers all 16 SDK signatures in one flow
        // ═══════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task GroupRoleTargets_FullWorkflow_ShouldSucceed()
        {
            // ══════════════════════════════════════════════════════════════════
            //  APP TARGETS  (APP_ADMIN role assigned to admin group)
            // ══════════════════════════════════════════════════════════════════
            //
            // The "bookmark" OIN key represents all bookmark app instances in the
            // catalog.  "mfa_rdp" is a second assignable catalog entry used to
            // reach the required ≥2 target count before testing OIN deletion.

            // ──────────────────────────────────────────────────────────────────
            // 1. GET initial app-target list — must be empty.
            // ──────────────────────────────────────────────────────────────────
            var initialAppTargets = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForGroup(
                    _adminGroupId, _appAdminRoleId)
                .ToListAsync();

            initialAppTargets.Should().BeEmpty(
                "a freshly assigned APP_ADMIN role has no scoped app targets yet");

            // WithHttpInfo variant — status 200
            var initialAppTargetsHttp = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForGroupWithHttpInfoAsync(
                    _adminGroupId, _appAdminRoleId);

            ((int)initialAppTargetsHttp.StatusCode).Should().Be(200,
                "GET .../targets/catalog/apps must return 200");
            initialAppTargetsHttp.Data.Should().BeEmpty();

            // ──────────────────────────────────────────────────────────────────
            // 2. PUT .../targets/catalog/apps/bookmark — AssignAppTarget (OIN scope).
            //    Curl-validated: returns 204 (doc lists 200 but actual is 204).
            //    Subsequent GET returns 1 catalogue entry with Name="bookmark" and
            //    no Id (OIN-level target, not a specific instance).
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.AssignAppTargetToAdminRoleForGroupAsync(
                _adminGroupId, _appAdminRoleId, "bookmark");

            var afterAssignOin = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForGroup(
                    _adminGroupId, _appAdminRoleId)
                .ToListAsync();

            afterAssignOin.Should().HaveCount(1,
                "assigning an OIN app target scopes the APP_ADMIN role to that catalog entry");
            afterAssignOin[0].Name.Should().Be("bookmark");
            afterAssignOin[0].Id.Should().BeNullOrEmpty(
                "a catalog-level target has no instance id");

            // WithHttpInfo variant — must also return 204
            var assignOinHttp = await _targetApi
                .AssignAppTargetToAdminRoleForGroupWithHttpInfoAsync(
                    _adminGroupId, _appAdminRoleId, "bookmark");

            ((int)assignOinHttp.StatusCode).Should().Be(204,
                "PUT .../targets/catalog/apps/{appName} must return 204");

            // ──────────────────────────────────────────────────────────────────
            // 3. PUT .../targets/catalog/apps/bookmark/{app1Id} — AssignAppInstance.
            //    Assigning a specific instance replaces the OIN-level target.
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.AssignAppInstanceTargetToAppAdminRoleForGroupAsync(
                _adminGroupId, _appAdminRoleId, "bookmark", _app1Id);

            // Assign second instance via WithHttpInfo — status 204
            var assignInstanceHttp = await _targetApi
                .AssignAppInstanceTargetToAppAdminRoleForGroupWithHttpInfoAsync(
                    _adminGroupId, _appAdminRoleId, "bookmark", _app2Id);

            ((int)assignInstanceHttp.StatusCode).Should().Be(204,
                "PUT .../targets/catalog/apps/{appName}/{appId} must return 204");

            var afterTwoInstances = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForGroup(
                    _adminGroupId, _appAdminRoleId)
                .ToListAsync();

            afterTwoInstances.Should().HaveCount(2,
                "both app instances should appear as separate targets");
            afterTwoInstances.Should().OnlyContain(t => t.Id != null,
                "instance-level targets carry an id field");
            afterTwoInstances.Should().Contain(t => t.Id == _app1Id);
            afterTwoInstances.Should().Contain(t => t.Id == _app2Id);

            // ──────────────────────────────────────────────────────────────────
            // 3b. List with limit=1 — exercises the optional `limit` parameter.
            //     IOktaCollectionClient.ToListAsync() auto-follows pagination links
            //     so it returns ALL items regardless of page size; the limit param
            //     controls the server-side page size per request, not the total.
            //     The WithHttpInfo variant returns the raw single page, so
            //     limit=1 is observable there (exactly 1 item per page).
            // ──────────────────────────────────────────────────────────────────

            // Collection client with limit — fetches all pages, count still equals total.
            var limitedAppTargets = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForGroup(
                    _adminGroupId, _appAdminRoleId, limit: 1)
                .ToListAsync();

            limitedAppTargets.Should().HaveCount(2,
                "ToListAsync() follows all pagination links so all 2 targets are returned even with limit=1");

            // WithHttpInfo with limit=1 — raw single page, must contain exactly 1 item.
            var limitedAppTargetsHttp = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForGroupWithHttpInfoAsync(
                    _adminGroupId, _appAdminRoleId, limit: 1);

            ((int)limitedAppTargetsHttp.StatusCode).Should().Be(200,
                "GET .../targets/catalog/apps?limit=1 must return 200");
            limitedAppTargetsHttp.Data.Should().HaveCount(1,
                "WithHttpInfo returns a raw single page; limit=1 restricts it to 1 entry");

            // ──────────────────────────────────────────────────────────────────
            // 4. DELETE .../targets/catalog/apps/bookmark/{app1Id} — UnassignAppInstance.
            //    app2 remains, so we are NOT removing the last target (avoids HTTP 400).
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.UnassignAppInstanceTargetToAppAdminRoleForGroupAsync(
                _adminGroupId, _appAdminRoleId, "bookmark", _app1Id);

            var afterRemoveInstance = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForGroup(
                    _adminGroupId, _appAdminRoleId)
                .ToListAsync();

            afterRemoveInstance.Should().HaveCount(1,
                "after removing app1 only app2 should remain");
            afterRemoveInstance[0].Id.Should().Be(_app2Id);

            // WithHttpInfo variant — re-assign app1 so we have 2 again, then remove via WithHttpInfo.
            await _targetApi.AssignAppInstanceTargetToAppAdminRoleForGroupAsync(
                _adminGroupId, _appAdminRoleId, "bookmark", _app1Id);

            var unassignInstanceHttp = await _targetApi
                .UnassignAppInstanceTargetToAppAdminRoleForGroupWithHttpInfoAsync(
                    _adminGroupId, _appAdminRoleId, "bookmark", _app1Id);

            ((int)unassignInstanceHttp.StatusCode).Should().Be(204,
                "DELETE .../targets/catalog/apps/{appName}/{appId} must return 204");

            // State: [app2 instance only]

            // ──────────────────────────────────────────────────────────────────
            // 5. UnassignAppTarget (OIN level) — DELETE .../targets/catalog/apps/{appName}.
            //    Need ≥2 targets before removing one.  Add the "mfa_rdp" OIN target
            //    alongside the existing app2 instance; then delete mfa_rdp safely.
            // ──────────────────────────────────────────────────────────────────

            // Add second entry: mfa_rdp OIN target coexists with app2 bookmark instance.
            await _targetApi.AssignAppTargetToAdminRoleForGroupAsync(
                _adminGroupId, _appAdminRoleId, "mfa_rdp");

            var beforeOinDelete = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForGroup(
                    _adminGroupId, _appAdminRoleId)
                .ToListAsync();

            beforeOinDelete.Should().HaveCount(2,
                "mfa_rdp OIN and app2 instance should coexist as separate entries");

            // Plain method — removes mfa_rdp OIN; app2 instance still remains.
            await _targetApi.UnassignAppTargetToAdminRoleForGroupAsync(
                _adminGroupId, _appAdminRoleId, "mfa_rdp");

            var afterOinDelete = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForGroup(
                    _adminGroupId, _appAdminRoleId)
                .ToListAsync();

            afterOinDelete.Should().HaveCount(1,
                "only the app2 instance should remain after removing the mfa_rdp OIN target");
            afterOinDelete[0].Id.Should().Be(_app2Id);

            // WithHttpInfo variant — re-add mfa_rdp, then remove via WithHttpInfo.
            await _targetApi.AssignAppTargetToAdminRoleForGroupAsync(
                _adminGroupId, _appAdminRoleId, "mfa_rdp");

            var unassignOinHttp = await _targetApi
                .UnassignAppTargetToAdminRoleForGroupWithHttpInfoAsync(
                    _adminGroupId, _appAdminRoleId, "mfa_rdp");

            ((int)unassignOinHttp.StatusCode).Should().Be(204,
                "DELETE .../targets/catalog/apps/{appName} must return 204");

            // State: [app2 instance only]

            // ──────────────────────────────────────────────────────────────────
            // 5b. Documented behavior: assigning an OIN target overrides any
            //     existing instance targets of the same app.
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.AssignAppTargetToAdminRoleForGroupAsync(
                _adminGroupId, _appAdminRoleId, "bookmark");

            var afterOinOverridesInstance = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForGroup(
                    _adminGroupId, _appAdminRoleId)
                .ToListAsync();

            afterOinOverridesInstance.Should().HaveCount(1,
                "assigning the OIN bookmark target must override the existing app2 instance target");
            afterOinOverridesInstance[0].Name.Should().Be("bookmark");
            afterOinOverridesInstance[0].Id.Should().BeNullOrEmpty(
                "the entry is now a catalog-level target (no instance id)");

            // ══════════════════════════════════════════════════════════════════
            //  GROUP TARGETS  (USER_ADMIN role assigned to admin group)
            // ══════════════════════════════════════════════════════════════════
            //
            // Note: _targetGroup1Id / _targetGroup2Id are the groups BEING targeted.
            //       _adminGroupId is the group that HOLDS the role assignment.
            //       These are three distinct groups.

            // ──────────────────────────────────────────────────────────────────
            // 6. GET initial group-target list — must be empty.
            // ──────────────────────────────────────────────────────────────────
            var initialGroupTargets = await _targetApi
                .ListGroupTargetsForGroupRole(_adminGroupId, _userAdminRoleId)
                .ToListAsync();

            initialGroupTargets.Should().BeEmpty(
                "a freshly assigned USER_ADMIN role has no scoped group targets yet");

            // WithHttpInfo variant — status 200
            var initialGroupTargetsHttp = await _targetApi
                .ListGroupTargetsForGroupRoleWithHttpInfoAsync(_adminGroupId, _userAdminRoleId);

            ((int)initialGroupTargetsHttp.StatusCode).Should().Be(200,
                "GET .../targets/groups must return 200");
            initialGroupTargetsHttp.Data.Should().BeEmpty();

            // ──────────────────────────────────────────────────────────────────
            // 7. PUT .../targets/groups/{targetGroup1Id} — AssignGroupTarget.
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.AssignGroupTargetToGroupAdminRoleAsync(
                _adminGroupId, _userAdminRoleId, _targetGroup1Id);

            // Assign second target via WithHttpInfo — status 204
            var assignGroupHttp = await _targetApi
                .AssignGroupTargetToGroupAdminRoleWithHttpInfoAsync(
                    _adminGroupId, _userAdminRoleId, _targetGroup2Id);

            ((int)assignGroupHttp.StatusCode).Should().Be(204,
                "PUT .../targets/groups/{targetGroupId} must return 204");

            var afterTwoGroups = await _targetApi
                .ListGroupTargetsForGroupRole(_adminGroupId, _userAdminRoleId)
                .ToListAsync();

            afterTwoGroups.Should().HaveCount(2,
                "both target groups should appear after assignment");
            afterTwoGroups.Should().Contain(g => g.Id == _targetGroup1Id);
            afterTwoGroups.Should().Contain(g => g.Id == _targetGroup2Id);

            // ──────────────────────────────────────────────────────────────────
            // 7b. List with limit=1 — exercises the optional `limit` parameter.
            //     Same pagination behavior as above: ToListAsync() auto-follows
            //     links and returns the total count; WithHttpInfo returns one raw
            //     page so limit=1 is directly observable there.
            // ──────────────────────────────────────────────────────────────────

            // Collection client with limit — fetches all pages, count still equals total.
            var limitedGroupTargets = await _targetApi
                .ListGroupTargetsForGroupRole(
                    _adminGroupId, _userAdminRoleId, limit: 1)
                .ToListAsync();

            limitedGroupTargets.Should().HaveCount(2,
                "ToListAsync() follows all pagination links so all 2 group targets are returned even with limit=1");

            // WithHttpInfo with limit=1 — raw single page, must contain exactly 1 item.
            var limitedGroupTargetsHttp = await _targetApi
                .ListGroupTargetsForGroupRoleWithHttpInfoAsync(
                    _adminGroupId, _userAdminRoleId, limit: 1);

            ((int)limitedGroupTargetsHttp.StatusCode).Should().Be(200,
                "GET .../targets/groups?limit=1 must return 200");
            limitedGroupTargetsHttp.Data.Should().HaveCount(1,
                "WithHttpInfo returns a raw single page; limit=1 restricts it to 1 entry");
            limitedGroupTargetsHttp.Data[0].Id.Should().NotBeNullOrEmpty(
                "group target in the paginated response must carry an Id");

            // ──────────────────────────────────────────────────────────────────
            // 8. DELETE .../targets/groups/{targetGroup1Id} — UnassignGroupTarget.
            //    targetGroup2 remains, so we are NOT removing the last target.
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.UnassignGroupTargetFromGroupAdminRoleAsync(
                _adminGroupId, _userAdminRoleId, _targetGroup1Id);

            var afterRemoveGroup = await _targetApi
                .ListGroupTargetsForGroupRole(_adminGroupId, _userAdminRoleId)
                .ToListAsync();

            afterRemoveGroup.Should().HaveCount(1,
                "only targetGroup2 should remain after removing targetGroup1");
            afterRemoveGroup[0].Id.Should().Be(_targetGroup2Id);

            // WithHttpInfo variant — re-add targetGroup1, then remove via WithHttpInfo.
            await _targetApi.AssignGroupTargetToGroupAdminRoleAsync(
                _adminGroupId, _userAdminRoleId, _targetGroup1Id);

            var unassignGroupHttp = await _targetApi
                .UnassignGroupTargetFromGroupAdminRoleWithHttpInfoAsync(
                    _adminGroupId, _userAdminRoleId, _targetGroup1Id);

            ((int)unassignGroupHttp.StatusCode).Should().Be(204,
                "DELETE .../targets/groups/{targetGroupId} must return 204");

            // ──────────────────────────────────────────────────────────────────
            // Final state verification — targetGroup2 is the sole remaining target.
            // ──────────────────────────────────────────────────────────────────
            var finalGroupTargets = await _targetApi
                .ListGroupTargetsForGroupRole(_adminGroupId, _userAdminRoleId)
                .ToListAsync();

            finalGroupTargets.Should().HaveCount(1,
                "targetGroup2 should be the only remaining group target");
            finalGroupTargets[0].Id.Should().Be(_targetGroup2Id);
            finalGroupTargets[0].Type.Should().NotBeNull(
                "group target should carry a type field (e.g. OKTA_GROUP)");
            finalGroupTargets[0].Profile.Should().NotBeNull(
                "group target should carry the group profile");
        }
    }
}
