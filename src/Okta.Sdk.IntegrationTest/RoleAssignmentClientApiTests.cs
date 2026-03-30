// <copyright file="RoleAssignmentClientApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
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
    /// Integration tests for <see cref="RoleAssignmentClientApi"/>.
    ///
    /// SDK Methods &amp; Endpoints Covered:
    /// ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ Method                                  │ HTTP   │ Status │ Endpoint                                                 │
    /// ├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ AssignRoleToClientAsync                 │ POST   │ 201    │ /oauth2/v1/clients/{clientId}/roles                      │
    /// │ AssignRoleToClientWithHttpInfoAsync     │ POST   │ 201    │ /oauth2/v1/clients/{clientId}/roles                      │
    /// │ ListRolesForClient                      │ GET    │ 200    │ /oauth2/v1/clients/{clientId}/roles                      │
    /// │ ListRolesForClientWithHttpInfoAsync     │ GET    │ 200    │ /oauth2/v1/clients/{clientId}/roles                      │
    /// │ RetrieveClientRoleAsync                 │ GET    │ 200    │ /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}   │
    /// │ RetrieveClientRoleWithHttpInfoAsync     │ GET    │ 200    │ /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}   │
    /// │ DeleteRoleFromClientAsync               │ DELETE │ 204    │ /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}   │
    /// │ DeleteRoleFromClientWithHttpInfoAsync   │ DELETE │ 204    │ /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}   │
    /// └──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
    ///
    /// Prerequisites:
    ///   Only OIDC service (M2M) apps support client role assignment.
    ///   The test creates a dedicated service app in InitializeAsync and tears it down in DisposeAsync.
    /// </summary>
    [Collection(nameof(RoleAssignmentClientApiTests))]
    public class RoleAssignmentClientApiTests : IAsyncLifetime
    {
        private readonly RoleAssignmentClientApi _roleAssignmentApi = new();
        private readonly ApplicationApi         _applicationApi    = new();

        private string _testClientId;
        private string _primaryRoleAssignmentId;

        // ── Setup ────────────────────────────────────────────────────────────────

        public async Task InitializeAsync()
        {
            var guid = Guid.NewGuid();

            // Create a dedicated OIDC service (M2M) app.
            // Only service-type apps accept client role assignments.
            var app = new OpenIdConnectApplication
            {
                Name        = "oidc_client",
                Label       = $"role-assign-client-{guid.ToString("N")[..12]}",
                SignOnMode  = ApplicationSignOnMode.OPENIDCONNECT,
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        TokenEndpointAuthMethod = "client_secret_post",
                        AutoKeyRotation         = true,
                    },
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        RedirectUris    = new List<string> { "https://example.com/callback" },
                        ResponseTypes   = new List<OAuthResponseType>(),
                        GrantTypes      = new List<GrantType> { GrantType.ClientCredentials },
                        ApplicationType = OpenIdConnectApplicationType.Service,
                    },
                },
            };

            var created = await _applicationApi.CreateApplicationAsync(app);
            _testClientId = created.Id;

            // Pre-assign READ_ONLY_ADMIN so that GET / LIST tests always have at least one role.
            var assignRequest = new AssignRoleToGroupRequest(
                new StandardRoleAssignmentSchema { Type = "READ_ONLY_ADMIN" });

            var assignResponse = await _roleAssignmentApi.AssignRoleToClientAsync(_testClientId, assignRequest);
            _primaryRoleAssignmentId = assignResponse.GetStandardRole()?.Id;
        }

        // ── Teardown ─────────────────────────────────────────────────────────────

        public async Task DisposeAsync()
        {
            if (string.IsNullOrEmpty(_testClientId))
                return;

            // Remove all role assignments first.
            try
            {
                var roles = _roleAssignmentApi.ListRolesForClient(_testClientId);
                await foreach (var role in roles)
                {
                    var id = role.GetStandardRole()?.Id;
                    if (!string.IsNullOrEmpty(id))
                    {
                        try { await _roleAssignmentApi.DeleteRoleFromClientAsync(_testClientId, id); }
                        catch { /* ignore */ }
                    }
                }
            }
            catch { /* ignore */ }

            // Deactivate then delete the service app.
            try { await _applicationApi.DeactivateApplicationAsync(_testClientId); }
            catch { /* ignore */ }

            try { await _applicationApi.DeleteApplicationAsync(_testClientId); }
            catch { /* ignore */ }
        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        /// <summary>
        /// Creates a new OIDC service app with no role assignments.
        /// Used by tests that need a clean client (e.g., empty-list scenarios).
        /// </summary>
        private async Task<string> CreateFreshServiceAppAsync()
        {
            var app = new OpenIdConnectApplication
            {
                Name       = "oidc_client",
                Label      = $"role-empty-{Guid.NewGuid().ToString("N")[..12]}",
                SignOnMode = ApplicationSignOnMode.OPENIDCONNECT,
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        TokenEndpointAuthMethod = "client_secret_post",
                        AutoKeyRotation         = true,
                    },
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        RedirectUris    = new List<string> { "https://example.com/callback" },
                        ResponseTypes   = new List<OAuthResponseType>(),
                        GrantTypes      = new List<GrantType> { GrantType.ClientCredentials },
                        ApplicationType = OpenIdConnectApplicationType.Service,
                    },
                },
            };

            var created = await _applicationApi.CreateApplicationAsync(app);
            return created.Id;
        }

        /// <summary>Deactivates and deletes a service app (best-effort, swallows all errors).</summary>
        private async Task DeleteServiceAppAsync(string clientId)
        {
            try { await _applicationApi.DeactivateApplicationAsync(clientId); } catch { /* ignore */ }
            try { await _applicationApi.DeleteApplicationAsync(clientId); }     catch { /* ignore */ }
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  HAPPY-PATH — covers all four SDK methods in one flow
        // ═══════════════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task ClientRoleAssignment_FullCrudWorkflow_ShouldSucceed()
        {
            string helpDeskRoleId = null;

            try
            {
                // ── 1. POST /oauth2/v1/clients/{clientId}/roles ────────────────────────
                var assignRequest = new AssignRoleToGroupRequest(
                    new StandardRoleAssignmentSchema { Type = "HELP_DESK_ADMIN" });

                var assignResponse = await _roleAssignmentApi.AssignRoleToClientAsync(_testClientId, assignRequest);

                assignResponse.Should().NotBeNull(
                    "POST /oauth2/v1/clients/{clientId}/roles must return the created role assignment");

                var assignedRole = assignResponse.GetStandardRole();
                assignedRole.Should().NotBeNull(
                    "HELP_DESK_ADMIN is a standard role and must deserialise as StandardRole");

                assignedRole.Type.Value.Should().Be("HELP_DESK_ADMIN");
                assignedRole.Status.Should().Be(LifecycleStatus.ACTIVE);
                assignedRole.AssignmentType.Should().Be(RoleAssignmentType.CLIENT,
                    "roles assigned to a client app have assignmentType CLIENT");
                assignedRole.Id.Should().NotBeNullOrEmpty();
                assignedRole.Created.Should().NotBe(default);
                assignedRole.LastUpdated.Should().NotBe(default,
                    "the API always returns lastUpdated on a role assignment");
                assignedRole.Label.Should().NotBeNullOrEmpty(
                    "the response must contain a human-readable label");
                assignedRole.Links.Should().NotBeNull(
                    "_links must be present in the response");
                assignedRole.Links.Assignee.Should().NotBeNull(
                    "_links.assignee must be present");
                assignedRole.Links.Assignee.Href.Should().Contain(_testClientId,
                    "_links.assignee.href must contain the clientId");

                helpDeskRoleId = assignedRole.Id;

                // ── 2. GET /oauth2/v1/clients/{clientId}/roles (list) ─────────────────
                var roleCollection = _roleAssignmentApi.ListRolesForClient(_testClientId);
                var roles = new List<ListGroupAssignedRoles200ResponseInner>();
                await foreach (var r in roleCollection)
                {
                    roles.Add(r);
                }

                roles.Should().HaveCountGreaterThanOrEqualTo(2,
                    "list must include at least READ_ONLY_ADMIN (pre-assigned) and HELP_DESK_ADMIN (just assigned)");

                var types = new List<string>();
                foreach (var r in roles)
                {
                    var t = r.GetStandardRole()?.Type?.Value;
                    if (t != null)
                        types.Add(t);
                }
                types.Should().Contain("READ_ONLY_ADMIN",
                    "the pre-assigned READ_ONLY_ADMIN role must appear in the list");
                types.Should().Contain("HELP_DESK_ADMIN",
                    "the just-assigned HELP_DESK_ADMIN role must appear in the list");

                // Validate field-level data on every list item.
                foreach (var roleItem in roles)
                {
                    var itemRole = roleItem.GetStandardRole();
                    if (itemRole == null)
                        continue;
                    itemRole.Id.Should().NotBeNullOrEmpty(
                        "each list item must carry its role-assignment id");
                    itemRole.Label.Should().NotBeNullOrEmpty(
                        "label must be present on each list item");
                    itemRole.Status.Should().Be(LifecycleStatus.ACTIVE,
                        "all assigned roles must be ACTIVE");
                    itemRole.AssignmentType.Should().Be(RoleAssignmentType.CLIENT,
                        "roles assigned to a client always have assignmentType CLIENT");
                    itemRole.Created.Should().NotBe(default,
                        "created timestamp must be present on each list item");
                    itemRole.LastUpdated.Should().NotBe(default,
                        "lastUpdated must be present on each list item");
                    itemRole.Links.Should().NotBeNull(
                        "_links must be present on each list item");
                    itemRole.Links.Assignee.Href.Should().Contain(_testClientId,
                        "_links.assignee.href must contain the clientId on each list item");
                }

                // ── 3. GET /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId} ─────
                var singleRole = await _roleAssignmentApi.RetrieveClientRoleAsync(_testClientId, helpDeskRoleId);

                singleRole.Should().NotBeNull(
                    "GET /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId} must return the role");

                var singleStandardRole = singleRole.GetStandardRole();
                singleStandardRole.Should().NotBeNull();
                singleStandardRole.Id.Should().Be(helpDeskRoleId);
                singleStandardRole.Type.Value.Should().Be("HELP_DESK_ADMIN");
                singleStandardRole.Status.Should().Be(LifecycleStatus.ACTIVE);
                singleStandardRole.AssignmentType.Should().Be(RoleAssignmentType.CLIENT);
                singleStandardRole.Created.Should().NotBe(default);
                singleStandardRole.LastUpdated.Should().NotBe(default,
                    "lastUpdated must be present on the retrieved role");
                singleStandardRole.Label.Should().NotBeNullOrEmpty(
                    "label must be present on the retrieved role");
                singleStandardRole.Links.Should().NotBeNull(
                    "_links must be present on the retrieved role");
                singleStandardRole.Links.Assignee.Href.Should().Contain(_testClientId,
                    "_links.assignee.href must contain the clientId on the retrieved role");

                // ── 4. DELETE /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId} ──
                Func<Task> deleteAct = async () =>
                    await _roleAssignmentApi.DeleteRoleFromClientAsync(_testClientId, helpDeskRoleId);

                await deleteAct.Should().NotThrowAsync(
                    "DELETE must return 204 No Content");

                helpDeskRoleId = null; // prevent double-delete in finally

                // Verify the role is gone from the list.
                var afterDelete = _roleAssignmentApi.ListRolesForClient(_testClientId);
                var afterDeleteList = new List<ListGroupAssignedRoles200ResponseInner>();
                await foreach (var r in afterDelete)
                    afterDeleteList.Add(r);

                var afterTypes = new List<string>();
                foreach (var r in afterDeleteList)
                {
                    var t = r.GetStandardRole()?.Type?.Value;
                    if (t != null)
                        afterTypes.Add(t);
                }
                afterTypes.Should().NotContain("HELP_DESK_ADMIN",
                    "HELP_DESK_ADMIN must not appear after it is deleted");
            }
            finally
            {
                if (!string.IsNullOrEmpty(helpDeskRoleId))
                {
                    try { await _roleAssignmentApi.DeleteRoleFromClientAsync(_testClientId, helpDeskRoleId); }
                    catch { /* ignore */ }
                }
            }
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  HAPPY-PATH — WithHttpInfo variants (verifies raw HTTP status codes)
        // ═══════════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Exercises all four WithHttpInfo methods and asserts the raw HTTP status codes:
        ///   AssignRoleToClientWithHttpInfoAsync   → 201 Created
        ///   ListRolesForClientWithHttpInfoAsync   → 200 OK
        ///   RetrieveClientRoleWithHttpInfoAsync   → 200 OK
        ///   DeleteRoleFromClientWithHttpInfoAsync → 204 No Content
        /// </summary>
        [Fact]
        public async Task WithHttpInfo_FullCrudWorkflow_ShouldReturn_CorrectStatusCodes()
        {
            string reportAdminRoleId = null;

            try
            {
                // ── 1. POST → 201 Created ─────────────────────────────────────────
                var assignRequest = new AssignRoleToGroupRequest(
                    new StandardRoleAssignmentSchema { Type = "REPORT_ADMIN" });

                var assignResponse = await _roleAssignmentApi.AssignRoleToClientWithHttpInfoAsync(
                    _testClientId, assignRequest);

                ((int)assignResponse.StatusCode).Should().Be(201,
                    "POST /oauth2/v1/clients/{clientId}/roles must return HTTP 201 Created");
                assignResponse.Data.Should().NotBeNull(
                    "the response body must contain the newly created role assignment");

                var assignedRole = assignResponse.Data.GetStandardRole();
                assignedRole.Should().NotBeNull();
                assignedRole.Type.Value.Should().Be("REPORT_ADMIN");
                assignedRole.AssignmentType.Should().Be(RoleAssignmentType.CLIENT);
                assignedRole.Id.Should().NotBeNullOrEmpty();

                reportAdminRoleId = assignedRole.Id;

                // ── 2. GET list → 200 OK ──────────────────────────────────────────
                var listResponse = await _roleAssignmentApi.ListRolesForClientWithHttpInfoAsync(_testClientId);

                ((int)listResponse.StatusCode).Should().Be(200,
                    "GET /oauth2/v1/clients/{clientId}/roles must return HTTP 200 OK");
                listResponse.Data.Should().NotBeNull();
                listResponse.Data.Should().HaveCountGreaterThanOrEqualTo(2,
                    "list must contain at least READ_ONLY_ADMIN (pre-assigned) and REPORT_ADMIN (just assigned)");

                // ── 3. GET single → 200 OK ────────────────────────────────────────
                var retrieveResponse = await _roleAssignmentApi.RetrieveClientRoleWithHttpInfoAsync(
                    _testClientId, reportAdminRoleId);

                ((int)retrieveResponse.StatusCode).Should().Be(200,
                    "GET /oauth2/v1/clients/{clientId}/roles/{id} must return HTTP 200 OK");
                retrieveResponse.Data.Should().NotBeNull();

                var retrievedRole = retrieveResponse.Data.GetStandardRole();
                retrievedRole.Should().NotBeNull();
                retrievedRole.Id.Should().Be(reportAdminRoleId);
                retrievedRole.Type.Value.Should().Be("REPORT_ADMIN");

                // ── 4. DELETE → 204 No Content ────────────────────────────────────
                var deleteResponse = await _roleAssignmentApi.DeleteRoleFromClientWithHttpInfoAsync(
                    _testClientId, reportAdminRoleId);

                ((int)deleteResponse.StatusCode).Should().Be(204,
                    "DELETE /oauth2/v1/clients/{clientId}/roles/{id} must return HTTP 204 No Content");

                reportAdminRoleId = null; // prevent double-delete in finally
            }
            finally
            {
                if (!string.IsNullOrEmpty(reportAdminRoleId))
                {
                    try { await _roleAssignmentApi.DeleteRoleFromClientAsync(_testClientId, reportAdminRoleId); }
                    catch { /* ignore */ }
                }
            }
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  EDGE-CASE — empty role list before any assignment
        // ═══════════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// A fresh service app with no role assignments must return an empty list (HTTP 200).
        /// Exercises both <see cref="RoleAssignmentClientApi.ListRolesForClient"/> (streaming)
        /// and <see cref="RoleAssignmentClientApi.ListRolesForClientWithHttpInfoAsync"/>.
        /// </summary>
        [Fact]
        public async Task ListRolesForClient_BeforeAnyAssignment_ShouldReturnEmptyList()
        {
            var freshClientId = await CreateFreshServiceAppAsync();

            try
            {
                // Via streaming collection (plain async method).
                var collection = _roleAssignmentApi.ListRolesForClient(freshClientId);
                var roles = new List<ListGroupAssignedRoles200ResponseInner>();
                await foreach (var r in collection)
                    roles.Add(r);

                roles.Should().BeEmpty(
                    "a service app with no role assignments must return an empty list");

                // Via WithHttpInfo (verifies HTTP 200 + empty data payload).
                var httpResponse = await _roleAssignmentApi.ListRolesForClientWithHttpInfoAsync(freshClientId);

                ((int)httpResponse.StatusCode).Should().Be(200,
                    "an empty list must still return HTTP 200 OK");
                httpResponse.Data.Should().NotBeNull();
                httpResponse.Data.Should().BeEmpty(
                    "the data payload must be an empty collection when no roles are assigned");
            }
            finally
            {
                await DeleteServiceAppAsync(freshClientId);
            }
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  ERROR-PATH TESTS
        // ═══════════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// POST duplicate role → 409 (E0000090)
        /// </summary>
        [Fact]
        public async Task AssignRoleToClientAsync_DuplicateRole_ShouldThrow409()
        {
            // READ_ONLY_ADMIN is already assigned in InitializeAsync.
            var request = new AssignRoleToGroupRequest(
                new StandardRoleAssignmentSchema { Type = "READ_ONLY_ADMIN" });

            var ex = await Assert.ThrowsAsync<ApiException>(() =>
                _roleAssignmentApi.AssignRoleToClientAsync(_testClientId, request));

            ex.ErrorCode.Should().Be(409,
                "assigning the same role twice must return HTTP 409 (role already assigned)");
        }

        /// <summary>
        /// POST with invalid clientId → 404 (E0000007)
        /// </summary>
        [Fact]
        public async Task AssignRoleToClientAsync_InvalidClientId_ShouldThrow404()
        {
            var request = new AssignRoleToGroupRequest(
                new StandardRoleAssignmentSchema { Type = "READ_ONLY_ADMIN" });

            var ex = await Assert.ThrowsAsync<ApiException>(() =>
                _roleAssignmentApi.AssignRoleToClientAsync("INVALID_CLIENT_ID_00000", request));

            ex.ErrorCode.Should().Be(404,
                "a non-existent clientId must return HTTP 404");
        }

        /// <summary>
        /// GET single with invalid roleAssignmentId → 404 (E0000007)
        /// </summary>
        [Fact]
        public async Task RetrieveClientRoleAsync_InvalidRoleAssignmentId_ShouldThrow404()
        {
            var ex = await Assert.ThrowsAsync<ApiException>(() =>
                _roleAssignmentApi.RetrieveClientRoleAsync(_testClientId, "INVALID_ROLE_ID_00000"));

            ex.ErrorCode.Should().Be(404,
                "a non-existent roleAssignmentId must return HTTP 404");
        }

        /// <summary>
        /// DELETE with invalid roleAssignmentId → 404 (E0000007)
        /// </summary>
        [Fact]
        public async Task DeleteRoleFromClientAsync_InvalidRoleAssignmentId_ShouldThrow404()
        {
            var ex = await Assert.ThrowsAsync<ApiException>(() =>
                _roleAssignmentApi.DeleteRoleFromClientAsync(_testClientId, "INVALID_ROLE_ID_00000"));

            ex.ErrorCode.Should().Be(404,
                "a non-existent roleAssignmentId on DELETE must return HTTP 404");
        }

        /// <summary>
        /// GET single with invalid clientId → 404 (E0000007)
        /// </summary>
        [Fact]
        public async Task RetrieveClientRoleAsync_InvalidClientId_ShouldThrow404()
        {
            var ex = await Assert.ThrowsAsync<ApiException>(() =>
                _roleAssignmentApi.RetrieveClientRoleAsync("INVALID_CLIENT_ID_00000", _primaryRoleAssignmentId));

            ex.ErrorCode.Should().Be(404,
                "a non-existent clientId on GET single must return HTTP 404");
        }

        /// <summary>
        /// DELETE with invalid clientId → 404 (E0000007)
        /// </summary>
        [Fact]
        public async Task DeleteRoleFromClientAsync_InvalidClientId_ShouldThrow404()
        {
            var ex = await Assert.ThrowsAsync<ApiException>(() =>
                _roleAssignmentApi.DeleteRoleFromClientAsync("INVALID_CLIENT_ID_00000", _primaryRoleAssignmentId));

            ex.ErrorCode.Should().Be(404,
                "a non-existent clientId on DELETE must return HTTP 404");
        }
    }
}
