// <copyright file="RoleBTargetClientApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for <see cref="RoleBTargetClientApi"/>.
    ///
    /// SDK Methods &amp; Endpoints Covered (all 16 signatures — 8 functional + 8 WithHttpInfo):
    /// ┌───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ Method                                                                              │ HTTP   │ Status │ Endpoint                                                                          │
    /// ├───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ ListAppTargetRoleToClient                                                           │ GET    │ 200    │ /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/catalog/apps       │
    /// │   — called empty, non-empty, and with limit=1                                       │        │        │                                                                                   │
    /// │ ListAppTargetRoleToClientWithHttpInfoAsync                                          │ GET    │ 200    │ same (empty, limit=1)                                                             │
    /// │ AssignAppTargetRoleToClientAsync                                                    │ PUT    │ 204    │ .../targets/catalog/apps/{appName}                                                │
    /// │ AssignAppTargetRoleToClientWithHttpInfoAsync                                        │ PUT    │ 204    │ same                                                                              │
    /// │ AssignAppTargetInstanceRoleForClientAsync                                           │ PUT    │ 204    │ .../targets/catalog/apps/{appName}/{appId}                                        │
    /// │ AssignAppTargetInstanceRoleForClientWithHttpInfoAsync                               │ PUT    │ 204    │ same                                                                              │
    /// │ RemoveAppTargetInstanceRoleForClientAsync                                           │ DELETE │ 204    │ .../targets/catalog/apps/{appName}/{appId}                                        │
    /// │ RemoveAppTargetInstanceRoleForClientWithHttpInfoAsync                               │ DELETE │ 204    │ same                                                                              │
    /// │ RemoveAppTargetRoleFromClientAsync                                                  │ DELETE │ 204    │ .../targets/catalog/apps/{appName}                                                │
    /// │ RemoveAppTargetRoleFromClientWithHttpInfoAsync                                      │ DELETE │ 204    │ same                                                                              │
    /// │ ListGroupTargetRoleForClient                                                        │ GET    │ 200    │ /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/groups             │
    /// │   — called empty, non-empty, and with limit=1                                       │        │        │                                                                                   │
    /// │ ListGroupTargetRoleForClientWithHttpInfoAsync                                       │ GET    │ 200    │ same (empty, limit=1)                                                             │
    /// │ AssignGroupTargetRoleForClientAsync                                                 │ PUT    │ 204    │ .../targets/groups/{groupId}                                                      │
    /// │ AssignGroupTargetRoleForClientWithHttpInfoAsync                                     │ PUT    │ 204    │ same                                                                              │
    /// │ RemoveGroupTargetRoleFromClientAsync                                                │ DELETE │ 204    │ .../targets/groups/{groupId}                                                      │
    /// │ RemoveGroupTargetRoleFromClientWithHttpInfoAsync                                    │ DELETE │ 204    │ same                                                                              │
    /// └───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
    ///
    /// </summary>
    [Collection(nameof(RoleBTargetClientApiTests))]
    public class RoleBTargetClientApiTests : IAsyncLifetime
    {
        // ── API Clients ──────────────────────────────────────────────────────────
        private readonly RoleBTargetClientApi      _targetApi      = new();
        private readonly RoleAssignmentClientApi   _roleAssignApi  = new();
        private readonly ApplicationApi            _appApi         = new();
        private readonly GroupApi                  _groupApi       = new();

        // ── Test state ────────────────────────────────────────────────────────────
        private string _clientAppId;       // Okta App ID (== client_id) of the service OIDC app
        private string _appAdminRoleId;    // APP_ADMIN role assignment id
        private string _userAdminRoleId;   // USER_ADMIN role assignment id
        private string _targetGroup1Id;    // first group used as a group-target
        private string _targetGroup2Id;    // second group used as a group-target
        private string _bookmarkApp1Id;    // first bookmark app instance (for app-instance-target tests)
        private string _bookmarkApp2Id;    // second bookmark app instance

        // ── Setup ─────────────────────────────────────────────────────────────────

        public async Task InitializeAsync()
        {
            var suffix = Guid.NewGuid().ToString("N")[..12];

            // 1. Create a service-type OIDC app.
            //    Only "service" application_type clients can receive role assignments.
            //    The client_id for the RoleBTargetClientApi equals the app's Okta ID.
            var serviceApp = new OpenIdConnectApplication
            {
                Name       = OpenIdConnectApplication.NameEnum.OidcClient,
                Label      = $"rbtc-client-{suffix}",
                SignOnMode = ApplicationSignOnMode.OPENIDCONNECT,
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretBasic,
                    },
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        ApplicationType = OpenIdConnectApplicationType.Service,
                        GrantTypes      = new List<GrantType> { GrantType.ClientCredentials },
                        ResponseTypes   = new List<OAuthResponseType> { OAuthResponseType.Token },
                    },
                },
            };

            var createdApp = await _appApi.CreateApplicationAsync(serviceApp);
            _clientAppId = createdApp.Id;   // client_id == app.Id for OIDC apps

            // 2. Create two bookmark apps for app-instance-target tests.
            //    Two instances are needed to safely test instance unassignment
            //    without hitting the "cannot remove last target" 400 constraint.
            var bookmarkTemplate = new BookmarkApplication
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

            bookmarkTemplate.Label = $"rbtc-bm1-{suffix}";
            var bm1 = await _appApi.CreateApplicationAsync(bookmarkTemplate);
            _bookmarkApp1Id = bm1.Id;

            bookmarkTemplate.Label = $"rbtc-bm2-{suffix}";
            var bm2 = await _appApi.CreateApplicationAsync(bookmarkTemplate);
            _bookmarkApp2Id = bm2.Id;

            // 3. Create two target groups (used as group-targets for the USER_ADMIN role).
            //    Two groups are needed to safely test group unassignment.
            var tgt1 = await _groupApi.AddGroupAsync(new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile { Name = $"rbtc-tgt1-{suffix}" },
            });
            _targetGroup1Id = tgt1.Id;

            var tgt2 = await _groupApi.AddGroupAsync(new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile { Name = $"rbtc-tgt2-{suffix}" },
            });
            _targetGroup2Id = tgt2.Id;

            // 4. Assign APP_ADMIN role to the service-app client (for app-target tests).
            var appAdminResp = await _roleAssignApi.AssignRoleToClientAsync(
                _clientAppId,
                new AssignRoleToGroupRequest(new StandardRoleAssignmentSchema { Type = "APP_ADMIN" }));
            _appAdminRoleId = ResolveRoleId(appAdminResp);

            // 5. Assign USER_ADMIN role to the service-app client (for group-target tests).
            var userAdminResp = await _roleAssignApi.AssignRoleToClientAsync(
                _clientAppId,
                new AssignRoleToGroupRequest(new StandardRoleAssignmentSchema { Type = "USER_ADMIN" }));
            _userAdminRoleId = ResolveRoleId(userAdminResp);
        }

        // ── Teardown ──────────────────────────────────────────────────────────────

        public async Task DisposeAsync()
        {
            // Unassign roles (implicitly clears all targets on the client).
            if (!string.IsNullOrEmpty(_clientAppId))
            {
                if (!string.IsNullOrEmpty(_appAdminRoleId))
                    try { await _roleAssignApi.DeleteRoleFromClientAsync(_clientAppId, _appAdminRoleId); } catch { /* ignore */ }

                if (!string.IsNullOrEmpty(_userAdminRoleId))
                    try { await _roleAssignApi.DeleteRoleFromClientAsync(_clientAppId, _userAdminRoleId); } catch { /* ignore */ }
            }

            // Deactivate + delete the service app (deactivation is always done via ApplicationApi).
            if (!string.IsNullOrEmpty(_clientAppId))
            {
                try { await _appApi.DeactivateApplicationAsync(_clientAppId); } catch { /* ignore */ }
                try { await _appApi.DeleteApplicationAsync(_clientAppId); }     catch { /* ignore */ }
            }

            // Deactivate + delete bookmark app instances.
            foreach (var appId in new[] { _bookmarkApp1Id, _bookmarkApp2Id })
            {
                if (string.IsNullOrEmpty(appId)) continue;
                try { await _appApi.DeactivateApplicationAsync(appId); } catch { /* ignore */ }
                try { await _appApi.DeleteApplicationAsync(appId); }     catch { /* ignore */ }
            }

            // Delete target groups.
            foreach (var groupId in new[] { _targetGroup1Id, _targetGroup2Id })
            {
                if (string.IsNullOrEmpty(groupId)) continue;
                try { await _groupApi.DeleteGroupAsync(groupId); } catch { /* ignore */ }
            }
        }

        // ── Helper ────────────────────────────────────────────────────────────────

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
        public async Task ClientRoleTargets_FullWorkflow_ShouldSucceed()
        {
            // ══════════════════════════════════════════════════════════════════
            //  APP TARGETS  (APP_ADMIN role assigned to the service-app client)
            // ══════════════════════════════════════════════════════════════════
            //
            // Endpoint base: /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/catalog/apps
            //
            // "bookmark" is the OIN catalog key for all bookmark app instances.
            // "mfa_rdp" is used as a second assignable OIN entry to safely test
            // OIN deletion (a minimum of 2 targets must exist before removing one).

            // ──────────────────────────────────────────────────────────────────
            // 1. GET initial app-target list — must be empty.
            // ──────────────────────────────────────────────────────────────────
            var initialAppTargets = await _targetApi
                .ListAppTargetRoleToClient(_clientAppId, _appAdminRoleId)
                .ToListAsync();

            initialAppTargets.Should().BeEmpty(
                "a freshly assigned APP_ADMIN role has no scoped app targets yet");

            // WithHttpInfo variant — status 200
            var initialAppTargetsHttp = await _targetApi
                .ListAppTargetRoleToClientWithHttpInfoAsync(_clientAppId, _appAdminRoleId);

            ((int)initialAppTargetsHttp.StatusCode).Should().Be(200,
                "GET .../targets/catalog/apps must return 200");
            initialAppTargetsHttp.Data.Should().BeEmpty();

            // ──────────────────────────────────────────────────────────────────
            // 2. PUT .../targets/catalog/apps/bookmark — AssignAppTargetRoleToClient (OIN scope).
            //    Curl-validated: returns 204.
            //    Subsequent GET returns 1 catalogue entry with Name="bookmark" and
            //    no Id (OIN-level target, not a specific instance).
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.AssignAppTargetRoleToClientAsync(
                _clientAppId, _appAdminRoleId, "bookmark");

            var afterAssignOin = await _targetApi
                .ListAppTargetRoleToClient(_clientAppId, _appAdminRoleId)
                .ToListAsync();

            afterAssignOin.Should().HaveCount(1,
                "assigning an OIN app target scopes the APP_ADMIN role to that catalog entry");
            afterAssignOin[0].Name.Should().Be("bookmark");
            afterAssignOin[0].Id.Should().BeNullOrEmpty(
                "a catalog-level target has no instance id");

            // WithHttpInfo variant — must return 204
            var assignOinHttp = await _targetApi
                .AssignAppTargetRoleToClientWithHttpInfoAsync(
                    _clientAppId, _appAdminRoleId, "bookmark");

            ((int)assignOinHttp.StatusCode).Should().Be(204,
                "PUT .../targets/catalog/apps/{appName} must return 204");

            // ──────────────────────────────────────────────────────────────────
            // 3. PUT .../targets/catalog/apps/bookmark/{bookmarkApp1Id}
            //    — AssignAppTargetInstanceRoleForClient.
            //    Assigning a specific instance replaces the OIN-level catalog target.
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.AssignAppTargetInstanceRoleForClientAsync(
                _clientAppId, _appAdminRoleId, "bookmark", _bookmarkApp1Id);

            // Verify the OIN catalog entry was replaced by the app1 instance.
            // Docs: "When you assign the first app instance target, the role no longer applies to all
            //        app targets, but applies only to the specified target."
            var afterApp1Instance = await _targetApi
                .ListAppTargetRoleToClient(_clientAppId, _appAdminRoleId)
                .ToListAsync();

            afterApp1Instance.Should().HaveCount(1,
                "assigning an app instance target must replace the existing OIN catalog entry for the same app");
            afterApp1Instance[0].Id.Should().Be(_bookmarkApp1Id,
                "the single remaining entry is the app1 instance, not an OIN catalog target");
            // For instance-level targets the Name field carries the app's display label,
            // NOT the OIN catalog key ("bookmark").  Only OIN catalog-level entries use "bookmark".
            afterApp1Instance[0].Name.Should().NotBe("bookmark",
                "instance-level targets expose the app's display label as Name, not the OIN catalog key");

            // Assign second instance via WithHttpInfo — status 204
            var assignInstanceHttp = await _targetApi
                .AssignAppTargetInstanceRoleForClientWithHttpInfoAsync(
                    _clientAppId, _appAdminRoleId, "bookmark", _bookmarkApp2Id);

            ((int)assignInstanceHttp.StatusCode).Should().Be(204,
                "PUT .../targets/catalog/apps/{appName}/{appId} must return 204");

            var afterTwoInstances = await _targetApi
                .ListAppTargetRoleToClient(_clientAppId, _appAdminRoleId)
                .ToListAsync();

            afterTwoInstances.Should().HaveCount(2,
                "both bookmark app instances should appear as separate targets");
            afterTwoInstances.Should().OnlyContain(t => t.Id != null,
                "instance-level targets carry an id field");
            afterTwoInstances.Should().Contain(t => t.Id == _bookmarkApp1Id);
            afterTwoInstances.Should().Contain(t => t.Id == _bookmarkApp2Id);

            // ──────────────────────────────────────────────────────────────────
            // 3b. List with limit=1 — exercises the optional `limit` parameter.
            //     IOktaCollectionClient.ToListAsync() auto-follows all Link headers
            //     (pagination), so it always returns ALL items regardless of page size.
            //     The WithHttpInfo variant returns the raw single page, so limit=1
            //     is directly observable there (exactly 1 entry per raw page).
            // ──────────────────────────────────────────────────────────────────

            // Collection client with limit=1 — fetches all pages, count equals total.
            var limitedAppTargets = await _targetApi
                .ListAppTargetRoleToClient(_clientAppId, _appAdminRoleId, limit: 1)
                .ToListAsync();

            limitedAppTargets.Should().HaveCount(2,
                "ToListAsync() follows all pagination links so all 2 targets are returned even with limit=1");

            // WithHttpInfo with limit=1 — raw single page, must contain exactly 1 item.
            var limitedAppTargetsHttp = await _targetApi
                .ListAppTargetRoleToClientWithHttpInfoAsync(
                    _clientAppId, _appAdminRoleId, limit: 1);

            ((int)limitedAppTargetsHttp.StatusCode).Should().Be(200,
                "GET .../targets/catalog/apps?limit=1 must return 200");
            limitedAppTargetsHttp.Data.Should().HaveCount(1,
                "WithHttpInfo returns a raw single page; limit=1 restricts it to 1 entry");

            // `after` cursor — the Link response header carries rel="next" when more pages exist.
            // Extract the cursor and fetch the second page to exercise the `after` parameter.
            var appLinkKey = limitedAppTargetsHttp.Headers.Keys
                .FirstOrDefault(k => k.Equals("Link", StringComparison.OrdinalIgnoreCase));
            appLinkKey.Should().NotBeNull(
                "a paginated response with limit=1 and 2 items must include a Link response header");

            var appNextLinkEntry = limitedAppTargetsHttp.Headers[appLinkKey]
                .FirstOrDefault(h => h.Contains("rel=\"next\""));
            appNextLinkEntry.Should().NotBeNullOrEmpty(
                "the Link header must include a rel=\"next\" entry when there is a next page");

            var appAfterMatch = Regex.Match(appNextLinkEntry, @"after=([^&>]+)");
            appAfterMatch.Success.Should().BeTrue("the next Link URL must contain an 'after' cursor parameter");
            var appAfterCursor = Uri.UnescapeDataString(appAfterMatch.Groups[1].Value);

            var appSecondPageHttp = await _targetApi
                .ListAppTargetRoleToClientWithHttpInfoAsync(
                    _clientAppId, _appAdminRoleId, after: appAfterCursor, limit: 1);

            ((int)appSecondPageHttp.StatusCode).Should().Be(200,
                "GET .../targets/catalog/apps?after=CURSOR must return 200");
            appSecondPageHttp.Data.Should().HaveCount(1,
                "the second page fetched via 'after' cursor must contain the 1 remaining app target");

            // ──────────────────────────────────────────────────────────────────
            // 4. DELETE .../targets/catalog/apps/bookmark/{bookmarkApp1Id}
            //    — RemoveAppTargetInstanceRoleForClient.
            //    bookmarkApp2 remains, so we are NOT removing the last target.
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.RemoveAppTargetInstanceRoleForClientAsync(
                _clientAppId, _appAdminRoleId, "bookmark", _bookmarkApp1Id);

            var afterRemoveInstance = await _targetApi
                .ListAppTargetRoleToClient(_clientAppId, _appAdminRoleId)
                .ToListAsync();

            afterRemoveInstance.Should().HaveCount(1,
                "after removing bookmarkApp1 only bookmarkApp2 should remain");
            afterRemoveInstance[0].Id.Should().Be(_bookmarkApp2Id);

            // WithHttpInfo variant — re-assign bookmarkApp1 so we have 2, then remove via WithHttpInfo.
            await _targetApi.AssignAppTargetInstanceRoleForClientAsync(
                _clientAppId, _appAdminRoleId, "bookmark", _bookmarkApp1Id);

            var removeInstanceHttp = await _targetApi
                .RemoveAppTargetInstanceRoleForClientWithHttpInfoAsync(
                    _clientAppId, _appAdminRoleId, "bookmark", _bookmarkApp1Id);

            ((int)removeInstanceHttp.StatusCode).Should().Be(204,
                "DELETE .../targets/catalog/apps/{appName}/{appId} must return 204");

            // State: [bookmarkApp2 instance only]

            // ──────────────────────────────────────────────────────────────────
            // 5. DELETE .../targets/catalog/apps/{appName}
            //    — RemoveAppTargetRoleFromClient (OIN-level unassign).
            //    Need ≥2 targets before removing one.  Add "mfa_rdp" OIN alongside
            //    the existing bookmarkApp2 instance; then remove mfa_rdp safely.
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.AssignAppTargetRoleToClientAsync(
                _clientAppId, _appAdminRoleId, "mfa_rdp");

            var beforeOinDelete = await _targetApi
                .ListAppTargetRoleToClient(_clientAppId, _appAdminRoleId)
                .ToListAsync();

            beforeOinDelete.Should().HaveCount(2,
                "mfa_rdp OIN and bookmarkApp2 instance should coexist as separate entries");

            // Plain method — removes mfa_rdp OIN; bookmarkApp2 instance still remains.
            await _targetApi.RemoveAppTargetRoleFromClientAsync(
                _clientAppId, _appAdminRoleId, "mfa_rdp");

            var afterOinDelete = await _targetApi
                .ListAppTargetRoleToClient(_clientAppId, _appAdminRoleId)
                .ToListAsync();

            afterOinDelete.Should().HaveCount(1,
                "only bookmarkApp2 instance should remain after removing the mfa_rdp OIN target");
            afterOinDelete[0].Id.Should().Be(_bookmarkApp2Id);

            // WithHttpInfo variant — re-add mfa_rdp, then remove via WithHttpInfo.
            await _targetApi.AssignAppTargetRoleToClientAsync(
                _clientAppId, _appAdminRoleId, "mfa_rdp");

            var removeOinHttp = await _targetApi
                .RemoveAppTargetRoleFromClientWithHttpInfoAsync(
                    _clientAppId, _appAdminRoleId, "mfa_rdp");

            ((int)removeOinHttp.StatusCode).Should().Be(204,
                "DELETE .../targets/catalog/apps/{appName} must return 204");

            // State: [bookmarkApp2 instance only]

            // ──────────────────────────────────────────────────────────────────
            // 5b. Documented behavior: assigning an OIN target overrides any
            //     existing instance targets of the same app.
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.AssignAppTargetRoleToClientAsync(
                _clientAppId, _appAdminRoleId, "bookmark");

            var afterOinOverridesInstance = await _targetApi
                .ListAppTargetRoleToClient(_clientAppId, _appAdminRoleId)
                .ToListAsync();

            afterOinOverridesInstance.Should().HaveCount(1,
                "assigning the OIN bookmark target must override the existing bookmarkApp2 instance");
            afterOinOverridesInstance[0].Name.Should().Be("bookmark");
            afterOinOverridesInstance[0].Id.Should().BeNullOrEmpty(
                "the entry is now a catalog-level target (no instance id)");

            // ══════════════════════════════════════════════════════════════════
            //  GROUP TARGETS  (USER_ADMIN role assigned to the service-app client)
            // ══════════════════════════════════════════════════════════════════
            //
            // Endpoint base: /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/groups
            //
            // _targetGroup1Id / _targetGroup2Id are the groups BEING targeted.
            // They are distinct from the client app itself.

            // ──────────────────────────────────────────────────────────────────
            // 6. GET initial group-target list — must be empty.
            // ──────────────────────────────────────────────────────────────────
            var initialGroupTargets = await _targetApi
                .ListGroupTargetRoleForClient(_clientAppId, _userAdminRoleId)
                .ToListAsync();

            initialGroupTargets.Should().BeEmpty(
                "a freshly assigned USER_ADMIN role has no scoped group targets yet");

            // WithHttpInfo variant — status 200
            var initialGroupTargetsHttp = await _targetApi
                .ListGroupTargetRoleForClientWithHttpInfoAsync(_clientAppId, _userAdminRoleId);

            ((int)initialGroupTargetsHttp.StatusCode).Should().Be(200,
                "GET .../targets/groups must return 200");
            initialGroupTargetsHttp.Data.Should().BeEmpty();

            // ──────────────────────────────────────────────────────────────────
            // 7. PUT .../targets/groups/{targetGroup1Id} — AssignGroupTargetRoleForClient.
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.AssignGroupTargetRoleForClientAsync(
                _clientAppId, _userAdminRoleId, _targetGroup1Id);

            // Assign second target group via WithHttpInfo — status 204
            var assignGroupHttp = await _targetApi
                .AssignGroupTargetRoleForClientWithHttpInfoAsync(
                    _clientAppId, _userAdminRoleId, _targetGroup2Id);

            ((int)assignGroupHttp.StatusCode).Should().Be(204,
                "PUT .../targets/groups/{groupId} must return 204");

            var afterTwoGroups = await _targetApi
                .ListGroupTargetRoleForClient(_clientAppId, _userAdminRoleId)
                .ToListAsync();

            afterTwoGroups.Should().HaveCount(2,
                "both target groups should appear after assignment");
            afterTwoGroups.Should().Contain(g => g.Id == _targetGroup1Id);
            afterTwoGroups.Should().Contain(g => g.Id == _targetGroup2Id);

            // ──────────────────────────────────────────────────────────────────
            // 7b. List with limit=1 — exercises the optional `limit` parameter.
            //     Same pagination behavior: ToListAsync() auto-follows links and
            //     returns all items; WithHttpInfo returns one raw page.
            // ──────────────────────────────────────────────────────────────────

            // Collection client with limit=1 — fetches all pages, count equals total.
            var limitedGroupTargets = await _targetApi
                .ListGroupTargetRoleForClient(_clientAppId, _userAdminRoleId, limit: 1)
                .ToListAsync();

            limitedGroupTargets.Should().HaveCount(2,
                "ToListAsync() follows all pagination links so all 2 group targets are returned even with limit=1");

            // WithHttpInfo with limit=1 — raw single page, must contain exactly 1 item.
            var limitedGroupTargetsHttp = await _targetApi
                .ListGroupTargetRoleForClientWithHttpInfoAsync(
                    _clientAppId, _userAdminRoleId, limit: 1);

            ((int)limitedGroupTargetsHttp.StatusCode).Should().Be(200,
                "GET .../targets/groups?limit=1 must return 200");
            limitedGroupTargetsHttp.Data.Should().HaveCount(1,
                "WithHttpInfo returns a raw single page; limit=1 restricts it to 1 entry");
            limitedGroupTargetsHttp.Data[0].Id.Should().NotBeNullOrEmpty(
                "group target in the paginated response must carry an Id");

            // `after` cursor for group targets — same pattern as app targets above.
            var groupLinkKey = limitedGroupTargetsHttp.Headers.Keys
                .FirstOrDefault(k => k.Equals("Link", StringComparison.OrdinalIgnoreCase));
            groupLinkKey.Should().NotBeNull(
                "a paginated response with limit=1 and 2 groups must include a Link response header");

            var groupNextLinkEntry = limitedGroupTargetsHttp.Headers[groupLinkKey]
                .FirstOrDefault(h => h.Contains("rel=\"next\""));
            groupNextLinkEntry.Should().NotBeNullOrEmpty(
                "the Link header must include a rel=\"next\" entry when there is a next page");

            var groupAfterMatch = Regex.Match(groupNextLinkEntry, @"after=([^&>]+)");
            groupAfterMatch.Success.Should().BeTrue("the next Link URL must contain an 'after' cursor parameter");
            var groupAfterCursor = Uri.UnescapeDataString(groupAfterMatch.Groups[1].Value);

            var groupSecondPageHttp = await _targetApi
                .ListGroupTargetRoleForClientWithHttpInfoAsync(
                    _clientAppId, _userAdminRoleId, after: groupAfterCursor, limit: 1);

            ((int)groupSecondPageHttp.StatusCode).Should().Be(200,
                "GET .../targets/groups?after=CURSOR must return 200");
            groupSecondPageHttp.Data.Should().HaveCount(1,
                "the second page fetched via 'after' cursor must contain the 1 remaining group target");

            // ──────────────────────────────────────────────────────────────────
            // 8. DELETE .../targets/groups/{targetGroup1Id}
            //    — RemoveGroupTargetRoleFromClient.
            //    targetGroup2 remains, so we are NOT removing the last target.
            // ──────────────────────────────────────────────────────────────────
            await _targetApi.RemoveGroupTargetRoleFromClientAsync(
                _clientAppId, _userAdminRoleId, _targetGroup1Id);

            var afterRemoveGroup = await _targetApi
                .ListGroupTargetRoleForClient(_clientAppId, _userAdminRoleId)
                .ToListAsync();

            afterRemoveGroup.Should().HaveCount(1,
                "only targetGroup2 should remain after removing targetGroup1");
            afterRemoveGroup[0].Id.Should().Be(_targetGroup2Id);

            // WithHttpInfo variant — re-add targetGroup1, then remove via WithHttpInfo.
            await _targetApi.AssignGroupTargetRoleForClientAsync(
                _clientAppId, _userAdminRoleId, _targetGroup1Id);

            var removeGroupHttp = await _targetApi
                .RemoveGroupTargetRoleFromClientWithHttpInfoAsync(
                    _clientAppId, _userAdminRoleId, _targetGroup1Id);

            ((int)removeGroupHttp.StatusCode).Should().Be(204,
                "DELETE .../targets/groups/{groupId} must return 204");

            // ──────────────────────────────────────────────────────────────────
            // Final state verification — targetGroup2 is the sole remaining target.
            // ──────────────────────────────────────────────────────────────────
            var finalGroupTargets = await _targetApi
                .ListGroupTargetRoleForClient(_clientAppId, _userAdminRoleId)
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
