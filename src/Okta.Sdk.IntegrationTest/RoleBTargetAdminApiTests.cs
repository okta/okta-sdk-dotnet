// <copyright file="RoleBTargetAdminApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for <see cref="RoleBTargetAdminApi"/>.
    ///
    /// SDK Methods &amp; Endpoints Covered (all 20 signatures — 10 functional + 10 WithHttpInfo):
    /// ┌────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ Method                                                                  │ HTTP   │ Status │ Endpoint                                       │
    /// ├────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ AssignAllAppsAsTargetToRoleForUserAsync                                 │ PUT    │ 204    │ /api/v1/users/{uid}/roles/{rid}/targets/catalog/apps                          │
    /// │ AssignAllAppsAsTargetToRoleForUserWithHttpInfoAsync                     │ PUT    │ 204    │ same                                           │
    /// │ AssignAppTargetToAdminRoleForUserAsync                                  │ PUT    │ 204    │ /api/v1/users/{uid}/roles/{rid}/targets/catalog/apps/{appName}                │
    /// │ AssignAppTargetToAdminRoleForUserWithHttpInfoAsync                      │ PUT    │ 204    │ same                                           │
    /// │ AssignAppInstanceTargetToAppAdminRoleForUserAsync                       │ PUT    │ 204    │ /api/v1/users/{uid}/roles/{rid}/targets/catalog/apps/{appName}/{appId}        │
    /// │ AssignAppInstanceTargetToAppAdminRoleForUserWithHttpInfoAsync           │ PUT    │ 204    │ same                                           │
    /// │ UnassignAppInstanceTargetFromAdminRoleForUserAsync                      │ DELETE │ 204    │ /api/v1/users/{uid}/roles/{rid}/targets/catalog/apps/{appName}/{appId}        │
    /// │ UnassignAppInstanceTargetFromAdminRoleForUserWithHttpInfoAsync          │ DELETE │ 204    │ same                                           │
    /// │ UnassignAppTargetFromAppAdminRoleForUserAsync                           │ DELETE │ 204    │ /api/v1/users/{uid}/roles/{rid}/targets/catalog/apps/{appName}                │
    /// │ UnassignAppTargetFromAppAdminRoleForUserWithHttpInfoAsync               │ DELETE │ 204    │ same                                           │
    /// │ ListApplicationTargetsForApplicationAdministratorRoleForUser            │ GET    │ 200    │ /api/v1/users/{uid}/roles/{rid}/targets/catalog/apps                          │
    /// │ ListApplicationTargetsForApplicationAdministratorRoleForUserWithHttpInfoAsync │ GET │ 200 │ same                                         │
    /// │ AssignGroupTargetToUserRoleAsync                                        │ PUT    │ 204    │ /api/v1/users/{uid}/roles/{rid}/targets/groups/{groupId}                      │
    /// │ AssignGroupTargetToUserRoleWithHttpInfoAsync                            │ PUT    │ 204    │ same                                           │
    /// │ UnassignGroupTargetFromUserAdminRoleAsync                               │ DELETE │ 204    │ /api/v1/users/{uid}/roles/{rid}/targets/groups/{groupId}                      │
    /// │ UnassignGroupTargetFromUserAdminRoleWithHttpInfoAsync                   │ DELETE │ 204    │ same                                           │
    /// │ ListGroupTargetsForRole                                                 │ GET    │ 200    │ /api/v1/users/{uid}/roles/{rid}/targets/groups                                │
    /// │ ListGroupTargetsForRoleWithHttpInfoAsync                                │ GET    │ 200    │ same                                           │
    /// │ GetRoleTargetsByUserIdAndRoleId                                         │ GET    │ 200    │ /api/v1/users/{uid}/roles/{rid}/targets                                       │
    /// │ GetRoleTargetsByUserIdAndRoleIdWithHttpInfoAsync                        │ GET    │ 200    │ same                                           │
    /// └────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
    ///
    /// </summary>
    [Collection(nameof(RoleBTargetAdminApiTests))]
    public class RoleBTargetAdminApiTests : IAsyncLifetime
    {
        // ── API Clients ─────────────────────────────────────────────────────────
        private readonly RoleBTargetAdminApi  _targetApi        = new();
        private readonly RoleAssignmentAUserApi _roleAssignApi  = new();
        private readonly UserApi              _userApi          = new();
        private readonly GroupApi             _groupApi         = new();
        private readonly ApplicationApi       _applicationApi   = new();

        // ── Test state ──────────────────────────────────────────────────────────
        private string _testUserId;
        private string _appAdminRoleId;   // APP_ADMIN role assignment id
        private string _userAdminRoleId;  // USER_ADMIN role assignment id
        private string _group1Id;
        private string _group2Id;
        private string _app1Id;           // first bookmark app instance id
        private string _app2Id;           // second bookmark app instance id

        // ── Setup ───────────────────────────────────────────────────────────────

        public async Task InitializeAsync()
        {
            var suffix = Guid.NewGuid().ToString("N")[..12];

            // 1. Create test user (no activation needed — role targets don't require active users).
            var user = await _userApi.CreateUserAsync(new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "RoleBTarget",
                    LastName  = $"Test{suffix}",
                    Email     = $"rolebtest-{suffix}@example.com",
                    Login     = $"rolebtest-{suffix}@example.com",
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "Abed1234!@#$" },
                },
            }, activate: false);
            _testUserId = user.Id;

            // 2. Create two groups (need 2 to safely test group-target unassign without hitting "last target" 400).
            var grp1 = await _groupApi.AddGroupAsync(new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile { Name = $"rolebtest-grp1-{suffix}" },
            });
            _group1Id = grp1.Id;

            var grp2 = await _groupApi.AddGroupAsync(new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile { Name = $"rolebtest-grp2-{suffix}" },
            });
            _group2Id = grp2.Id;

            // 3. Create two bookmark app instances (need 2 to safely test app-instance-target unassign).
            var bookmarkApp1 = new BookmarkApplication
            {
                Name      = "bookmark",
                Label     = $"rolebtest-app1-{suffix}",
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
            var createdApp1 = await _applicationApi.CreateApplicationAsync(bookmarkApp1);
            _app1Id = createdApp1.Id;

            var bookmarkApp2 = new BookmarkApplication
            {
                Name      = "bookmark",
                Label     = $"rolebtest-app2-{suffix}",
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
            var createdApp2 = await _applicationApi.CreateApplicationAsync(bookmarkApp2);
            _app2Id = createdApp2.Id;

            // 4. Assign APP_ADMIN role (for app-target tests).
            var appAdminResp = await _roleAssignApi.AssignRoleToUserAsync(
                _testUserId,
                new AssignRoleToUserRequest(new StandardRoleAssignmentSchema { Type = "APP_ADMIN" }));
            _appAdminRoleId = ResolveRoleId(appAdminResp);

            // 5. Assign USER_ADMIN role (for group-target tests).
            var userAdminResp = await _roleAssignApi.AssignRoleToUserAsync(
                _testUserId,
                new AssignRoleToUserRequest(new StandardRoleAssignmentSchema { Type = "USER_ADMIN" }));
            _userAdminRoleId = ResolveRoleId(userAdminResp);
        }

        // ── Teardown ────────────────────────────────────────────────────────────

        public async Task DisposeAsync()
        {
            // Remove role assignments (implicitly clears all targets).
            if (!string.IsNullOrEmpty(_testUserId))
            {
                if (!string.IsNullOrEmpty(_appAdminRoleId))
                    try { await _roleAssignApi.UnassignRoleFromUserAsync(_testUserId, _appAdminRoleId); } catch { /* ignore */ }

                if (!string.IsNullOrEmpty(_userAdminRoleId))
                    try { await _roleAssignApi.UnassignRoleFromUserAsync(_testUserId, _userAdminRoleId); } catch { /* ignore */ }

                // Delete user (call twice: first call deactivates, second permanently removes).
                try { await _userApi.DeleteUserAsync(_testUserId); } catch { /* ignore */ }
                try { await _userApi.DeleteUserAsync(_testUserId); } catch { /* ignore */ }
            }

            // Deactivate + delete both app instances.
            foreach (var appId in new[] { _app1Id, _app2Id })
            {
                if (string.IsNullOrEmpty(appId)) continue;
                try { await _applicationApi.DeactivateApplicationAsync(appId); } catch { /* ignore */ }
                try { await _applicationApi.DeleteApplicationAsync(appId); }     catch { /* ignore */ }
            }

            // Delete both groups.
            foreach (var groupId in new[] { _group1Id, _group2Id })
            {
                if (string.IsNullOrEmpty(groupId)) continue;
                try { await _groupApi.DeleteGroupAsync(groupId); } catch { /* ignore */ }
            }
        }

        // ── Helper ──────────────────────────────────────────────────────────────

        private static string ResolveRoleId(AssignRoleToUser201Response wrapper)
        {
            if (wrapper?.ActualInstance is StandardRole sr) return sr.Id;
            if (wrapper?.ActualInstance is CustomRole   cr) return cr.Id;
            return null;
        }

        // ═══════════════════════════════════════════════════════════════════════
        //  SINGLE COMPREHENSIVE TEST — covers all 20 SDK signatures in one flow
        // ═══════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task UserRoleTargets_FullWorkflow_ShouldSucceed()
        {
            // ── APP TARGETS (APP_ADMIN role) ─────────────────────────────────────
            //
            // The bookmark OIN key is "bookmark".  We use it as the app-name
            // throughout the app-target section so that OIN-level and instance-
            // level targets remain consistent with the same catalog entry.

            // ─────────────────────────────────────────────────────────────────────
            // 1. GET initial list — must be empty (role just assigned, no targets set).
            // ─────────────────────────────────────────────────────────────────────
            var initialAppTargets = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForUser(
                    _testUserId, _appAdminRoleId)
                .ToListAsync();

            initialAppTargets.Should().BeEmpty(
                "a freshly assigned APP_ADMIN role has no scoped app targets yet");

            // WithHttpInfo variant — status 200
            var initialAppTargetsHttp = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForUserWithHttpInfoAsync(
                    _testUserId, _appAdminRoleId);

            ((int)initialAppTargetsHttp.StatusCode).Should().Be(200,
                "GET .../targets/catalog/apps must return 200");
            initialAppTargetsHttp.Data.Should().BeEmpty();

            // ─────────────────────────────────────────────────────────────────────
            // 2. PUT /targets/catalog/apps — AssignAllApps (unrestricted scope).
            //    Returns 204; subsequent GET returns empty list (= "all apps" state).
            // ─────────────────────────────────────────────────────────────────────
            await _targetApi.AssignAllAppsAsTargetToRoleForUserAsync(_testUserId, _appAdminRoleId);

            var afterAssignAll = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForUser(
                    _testUserId, _appAdminRoleId)
                .ToListAsync();

            afterAssignAll.Should().BeEmpty(
                "when all apps are assigned the API returns an empty list (unrestricted state)");

            // WithHttpInfo variant — status 204
            var assignAllHttp = await _targetApi
                .AssignAllAppsAsTargetToRoleForUserWithHttpInfoAsync(_testUserId, _appAdminRoleId);

            ((int)assignAllHttp.StatusCode).Should().Be(204,
                "PUT .../targets/catalog/apps must return 204");

            // ─────────────────────────────────────────────────────────────────────
            // 3. PUT /targets/catalog/apps/bookmark — AssignAppTarget (OIN scope).
            //    Scopes the role to the bookmark OIN entry; list returns 1 item with
            //    Name="bookmark" and no Id (catalogue-level, not instance-level).
            // ─────────────────────────────────────────────────────────────────────
            await _targetApi.AssignAppTargetToAdminRoleForUserAsync(
                _testUserId, _appAdminRoleId, "bookmark");

            var afterAssignOin = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForUser(
                    _testUserId, _appAdminRoleId)
                .ToListAsync();

            afterAssignOin.Should().HaveCount(1,
                "assigning an OIN app target scopes the role to that catalogue entry");
            afterAssignOin[0].Name.Should().Be("bookmark");
            afterAssignOin[0].Id.Should().BeNullOrEmpty(
                "an OIN catalogue-level target has no instance id");

            // WithHttpInfo variant — status 204
            var assignOinHttp = await _targetApi
                .AssignAppTargetToAdminRoleForUserWithHttpInfoAsync(
                    _testUserId, _appAdminRoleId, "bookmark");

            ((int)assignOinHttp.StatusCode).Should().Be(204,
                "PUT .../targets/catalog/apps/{appName} must return 204");

            // ─────────────────────────────────────────────────────────────────────
            // 4. PUT .../targets/catalog/apps/bookmark/{app1Id} — AssignAppInstance.
            //    Scopes to the first specific app instance; replaces OIN-level target.
            // ─────────────────────────────────────────────────────────────────────
            await _targetApi.AssignAppInstanceTargetToAppAdminRoleForUserAsync(
                _testUserId, _appAdminRoleId, "bookmark", _app1Id);

            // WithHttpInfo variant for second instance — status 204
            var assignInstanceHttp = await _targetApi
                .AssignAppInstanceTargetToAppAdminRoleForUserWithHttpInfoAsync(
                    _testUserId, _appAdminRoleId, "bookmark", _app2Id);

            ((int)assignInstanceHttp.StatusCode).Should().Be(204,
                "PUT .../targets/catalog/apps/{appName}/{appId} must return 204");

            var afterTwoInstances = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForUser(
                    _testUserId, _appAdminRoleId)
                .ToListAsync();

            afterTwoInstances.Should().HaveCount(2,
                "both app instances should appear as separate targets");
            afterTwoInstances.Should().OnlyContain(t => t.Id != null,
                "instance-level targets carry an id field");
            afterTwoInstances.Should().Contain(t => t.Id == _app1Id);
            afterTwoInstances.Should().Contain(t => t.Id == _app2Id);

            // ─────────────────────────────────────────────────────────────────────
            // 5. DELETE .../targets/catalog/apps/bookmark/{app1Id} — UnassignAppInstance.
            //    app2 remains, so we are not removing the last target (avoids HTTP 400).
            // ─────────────────────────────────────────────────────────────────────
            await _targetApi.UnassignAppInstanceTargetFromAdminRoleForUserAsync(
                _testUserId, _appAdminRoleId, "bookmark", _app1Id);

            var afterRemoveInstance = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForUser(
                    _testUserId, _appAdminRoleId)
                .ToListAsync();

            afterRemoveInstance.Should().HaveCount(1,
                "after removing app1 only app2 should remain");
            afterRemoveInstance[0].Id.Should().Be(_app2Id);

            // WithHttpInfo variant — first re-assign app1 so we have 2 again, then remove via WithHttpInfo.
            await _targetApi.AssignAppInstanceTargetToAppAdminRoleForUserAsync(
                _testUserId, _appAdminRoleId, "bookmark", _app1Id);

            var unassignInstanceHttp = await _targetApi
                .UnassignAppInstanceTargetFromAdminRoleForUserWithHttpInfoAsync(
                    _testUserId, _appAdminRoleId, "bookmark", _app1Id);

            ((int)unassignInstanceHttp.StatusCode).Should().Be(204,
                "DELETE .../targets/catalog/apps/{appName}/{appId} must return 204");

            // ─────────────────────────────────────────────────────────────────────
            // 5b. Documented behavior: "Assigning an OIN app target overrides any
            //     existing app instance targets of the OIN app."
            //     app2 is the only remaining instance target.  Assigning the OIN
            //     "bookmark" entry must replace it with a catalogue-level target.
            // ─────────────────────────────────────────────────────────────────────
            await _targetApi.AssignAppTargetToAdminRoleForUserAsync(
                _testUserId, _appAdminRoleId, "bookmark");

            var afterOinOverridesInstance = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForUser(
                    _testUserId, _appAdminRoleId)
                .ToListAsync();

            afterOinOverridesInstance.Should().HaveCount(1,
                "assigning an OIN catalog target overrides all existing instance targets for the same app");
            afterOinOverridesInstance[0].Name.Should().Be("bookmark");
            afterOinOverridesInstance[0].Id.Should().BeNullOrEmpty(
                "an OIN catalog entry has no instance id — the instance target was replaced");

            // ─────────────────────────────────────────────────────────────────────
            // 6. Re-assign the OIN target so we have 2 catalogue entries, then
            //    DELETE /bookmark — UnassignAppTarget.
            //    Bookmark-OIN + app2-instance are the 2 targets, so removing the
            //    OIN target is safe (app2 remains).
            // ─────────────────────────────────────────────────────────────────────

            // Re-scope back to OIN level (replaces remaining instance target).
            await _targetApi.AssignAllAppsAsTargetToRoleForUserAsync(_testUserId, _appAdminRoleId);

            // Now assign two OIN targets: "bookmark" and "salesforce"
            await _targetApi.AssignAppTargetToAdminRoleForUserAsync(
                _testUserId, _appAdminRoleId, "bookmark");
            await _targetApi.AssignAppTargetToAdminRoleForUserAsync(
                _testUserId, _appAdminRoleId, "salesforce");

            var beforeOinDelete = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForUser(
                    _testUserId, _appAdminRoleId)
                .ToListAsync();

            beforeOinDelete.Should().HaveCount(2,
                "two OIN-level targets should be present before the delete test");

            // DELETE via plain method — removes "bookmark", "salesforce" remains.
            await _targetApi.UnassignAppTargetFromAppAdminRoleForUserAsync(
                _testUserId, _appAdminRoleId, "bookmark");

            var afterOinDelete = await _targetApi
                .ListApplicationTargetsForApplicationAdministratorRoleForUser(
                    _testUserId, _appAdminRoleId)
                .ToListAsync();

            afterOinDelete.Should().HaveCount(1,
                "only salesforce should remain after removing bookmark OIN target");
            afterOinDelete[0].Name.Should().Be("salesforce");

            // WithHttpInfo variant — re-add bookmark, then remove via WithHttpInfo.
            await _targetApi.AssignAppTargetToAdminRoleForUserAsync(
                _testUserId, _appAdminRoleId, "bookmark");

            var unassignOinHttp = await _targetApi
                .UnassignAppTargetFromAppAdminRoleForUserWithHttpInfoAsync(
                    _testUserId, _appAdminRoleId, "bookmark");

            ((int)unassignOinHttp.StatusCode).Should().Be(204,
                "DELETE .../targets/catalog/apps/{appName} must return 204");

            // ─────────────────────────────────────────────────────────────────────
            // 6b. GetRoleTargetsByUserIdAndRoleId also works for APP_ADMIN roles.
            //     The salesforce OIN target is still on the APP_ADMIN role.
            //     App-target ORNs use the 'apps' namespace segment instead of 'groups'.
            // ─────────────────────────────────────────────────────────────────────
            var appAdminRoleTargets = await _targetApi
                .GetRoleTargetsByUserIdAndRoleId(_testUserId, _appAdminRoleId)
                .ToListAsync();

            appAdminRoleTargets.Should().NotBeEmpty(
                "APP_ADMIN role still has salesforce as an OIN target");
            appAdminRoleTargets[0].Orn.Should().NotBeNullOrEmpty(
                "app role target must carry an ORN");
            appAdminRoleTargets[0].Orn.Should().Contain("apps",
                "ORN for an app target contains the 'apps' resource-type segment");
            appAdminRoleTargets[0].AssignmentType.Should().NotBeNullOrEmpty(
                "app role target must have an assignmentType");

            // ── GROUP TARGETS (USER_ADMIN role) ──────────────────────────────────

            // ─────────────────────────────────────────────────────────────────────
            // 7. GET initial group target list — must be empty.
            // ─────────────────────────────────────────────────────────────────────
            var initialGroupTargets = await _targetApi
                .ListGroupTargetsForRole(_testUserId, _userAdminRoleId)
                .ToListAsync();

            initialGroupTargets.Should().BeEmpty(
                "a freshly assigned USER_ADMIN role has no scoped group targets yet");

            // WithHttpInfo variant — status 200
            var initialGroupTargetsHttp = await _targetApi
                .ListGroupTargetsForRoleWithHttpInfoAsync(_testUserId, _userAdminRoleId);

            ((int)initialGroupTargetsHttp.StatusCode).Should().Be(200,
                "GET .../targets/groups must return 200");
            initialGroupTargetsHttp.Data.Should().BeEmpty();

            // ─────────────────────────────────────────────────────────────────────
            // 8. PUT .../targets/groups/{group1Id} — AssignGroupTarget.
            // ─────────────────────────────────────────────────────────────────────
            await _targetApi.AssignGroupTargetToUserRoleAsync(
                _testUserId, _userAdminRoleId, _group1Id);

            // Assign second group via WithHttpInfo — status 204
            var assignGroupHttp = await _targetApi
                .AssignGroupTargetToUserRoleWithHttpInfoAsync(
                    _testUserId, _userAdminRoleId, _group2Id);

            ((int)assignGroupHttp.StatusCode).Should().Be(204,
                "PUT .../targets/groups/{groupId} must return 204");

            var afterTwoGroups = await _targetApi
                .ListGroupTargetsForRole(_testUserId, _userAdminRoleId)
                .ToListAsync();

            afterTwoGroups.Should().HaveCount(2,
                "both groups should appear as targets after assignment");
            afterTwoGroups.Should().Contain(g => g.Id == _group1Id);
            afterTwoGroups.Should().Contain(g => g.Id == _group2Id);

            // ─────────────────────────────────────────────────────────────────────
            // 9. DELETE .../targets/groups/{group2Id} — UnassignGroupTarget.
            //    group1 remains, so we are not removing the last target.
            // ─────────────────────────────────────────────────────────────────────
            await _targetApi.UnassignGroupTargetFromUserAdminRoleAsync(
                _testUserId, _userAdminRoleId, _group2Id);

            var afterRemoveGroup = await _targetApi
                .ListGroupTargetsForRole(_testUserId, _userAdminRoleId)
                .ToListAsync();

            afterRemoveGroup.Should().HaveCount(1,
                "only group1 should remain after removing group2");
            afterRemoveGroup[0].Id.Should().Be(_group1Id);

            // WithHttpInfo variant — re-add group2, then remove via WithHttpInfo.
            await _targetApi.AssignGroupTargetToUserRoleAsync(
                _testUserId, _userAdminRoleId, _group2Id);

            var unassignGroupHttp = await _targetApi
                .UnassignGroupTargetFromUserAdminRoleWithHttpInfoAsync(
                    _testUserId, _userAdminRoleId, _group2Id);

            ((int)unassignGroupHttp.StatusCode).Should().Be(204,
                "DELETE .../targets/groups/{groupId} must return 204");

            var finalGroupTargets = await _targetApi
                .ListGroupTargetsForRole(_testUserId, _userAdminRoleId)
                .ToListAsync();

            finalGroupTargets.Should().HaveCount(1,
                "group1 should be the only remaining group target");
            finalGroupTargets[0].Id.Should().Be(_group1Id);
            finalGroupTargets[0].Type.Should().NotBeNull(
                "group target should have a type field (e.g. OKTA_GROUP)");
            finalGroupTargets[0].Profile.Should().NotBeNull(
                "group target should carry the group profile");

            // ── GetRoleTargetsByUserIdAndRoleId (USER_ADMIN role — group targets) ─

            // ─────────────────────────────────────────────────────────────────────
            // 10. GET /targets — GetRoleTargetsByUserIdAndRoleId (plain).
            //     Returns RoleTarget objects with Orn and AssignmentType fields.
            // ─────────────────────────────────────────────────────────────────────
            var roleTargets = await _targetApi
                .GetRoleTargetsByUserIdAndRoleId(_testUserId, _userAdminRoleId)
                .ToListAsync();

            roleTargets.Should().NotBeEmpty(
                "USER_ADMIN role still has group1 as a target");
            var rt = roleTargets[0];
            rt.Orn.Should().NotBeNullOrEmpty(
                "RoleTarget must carry an ORN (Okta Resource Name)");
            rt.Orn.Should().Contain(_group1Id,
                "the ORN should reference the assigned group");
            rt.AssignmentType.Should().NotBeNullOrEmpty(
                "RoleTarget must have an assignmentType (USER or GROUP)");

            // WithHttpInfo variant — status 200
            var roleTargetsHttp = await _targetApi
                .GetRoleTargetsByUserIdAndRoleIdWithHttpInfoAsync(_testUserId, _userAdminRoleId);

            ((int)roleTargetsHttp.StatusCode).Should().Be(200,
                "GET .../targets must return 200");
            roleTargetsHttp.Data.Should().NotBeEmpty();

            // ─────────────────────────────────────────────────────────────────────
            // 10b. GetRoleTargetsByUserIdAndRoleId with assignmentType filter.
            //      The assignmentType query param filters by HOW the role itself
            //      was assigned to the user (USER = direct; GROUP = via a group).
            //      Our USER_ADMIN role was assigned directly, so:
            //        USER filter  → returns group1 target (non-empty)
            //        GROUP filter → returns empty (role not assigned via a group)
            // ─────────────────────────────────────────────────────────────────────
            var userAssignedTargets = await _targetApi
                .GetRoleTargetsByUserIdAndRoleId(
                    _testUserId, _userAdminRoleId, assignmentType: AssignmentTypeParameter.USER)
                .ToListAsync();

            userAssignedTargets.Should().NotBeEmpty(
                "USER_ADMIN was assigned directly; USER filter must return the group target");
            userAssignedTargets.Should().OnlyContain(t => t.AssignmentType == "USER",
                "directly-assigned role targets all carry assignmentType=USER");

            var groupAssignedTargets = await _targetApi
                .GetRoleTargetsByUserIdAndRoleId(
                    _testUserId, _userAdminRoleId, assignmentType: AssignmentTypeParameter.GROUP)
                .ToListAsync();

            groupAssignedTargets.Should().BeEmpty(
                "the USER_ADMIN role was not assigned via a group, so GROUP filter returns empty");

            // WithHttpInfo with assignmentType filter — verify 200 and non-empty payload
            var filteredHttpResponse = await _targetApi
                .GetRoleTargetsByUserIdAndRoleIdWithHttpInfoAsync(
                    _testUserId, _userAdminRoleId, assignmentType: AssignmentTypeParameter.USER);

            ((int)filteredHttpResponse.StatusCode).Should().Be(200,
                "filtered GET .../targets must return 200");
            filteredHttpResponse.Data.Should().NotBeEmpty(
                "USER filter should yield at least the group1 target");
        }
    }
}
