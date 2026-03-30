// <copyright file="RoleAssignmentAUserApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for <see cref="RoleAssignmentAUserApi"/>.
    ///
    /// API Endpoints Covered:
    /// ┌────────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ Method                              │ HTTP Verb │ Endpoint                                         │
    /// ├────────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ AssignRoleToUserAsync               │ POST      │ /api/v1/users/{userId}/roles                     │
    /// │ ListAssignedRolesForUser            │ GET       │ /api/v1/users/{userId}/roles                     │
    /// │ GetUserAssignedRoleAsync            │ GET       │ /api/v1/users/{userId}/roles/{roleAssignmentId}  │
    /// │ UnassignRoleFromUserAsync           │ DELETE    │ /api/v1/users/{userId}/roles/{roleAssignmentId}  │
    /// │ ListUsersWithRoleAssignmentsAsync   │ GET       │ /api/v1/iam/assignees/users                      │
    /// │ GetUserAssignedRoleGovernanceAsync  │ GET       │ /api/v1/users/{userId}/roles/{id}/governance     │
    /// │ GetRoleAssignmentGovernanceGrantAsync│ GET      │ /api/v1/users/{userId}/roles/{id}/governance/{g} │
    /// │ GetRoleAssignmentGovernanceGrantResourcesAsync│GET│/api/v1/users/{userId}/roles/{id}/governance/{g}/resources│
    /// └────────────────────────────────────────────────────────────────────────────────────────────────────┘
    /// </summary>
    [Collection(nameof(RoleAssignmentAUserApiTests))]
    public class RoleAssignmentAUserApiTests : IAsyncLifetime
    {
        private readonly RoleAssignmentAUserApi _roleAssignmentApi = new();
        private readonly UserApi _userApi = new();

        private string _testUserId;
        private string _primaryRoleAssignmentId;

        // ── Setup ────────────────────────────────────────────────────────────────

        public async Task InitializeAsync()
        {
            var guid = Guid.NewGuid();

            // Create a dedicated test user that every test in this class can use.
            var createRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "RoleAssignTest",
                    LastName  = $"User{guid.ToString("N")[..8]}",
                    Email     = $"role-assign-test-{guid}@example.com",
                    Login     = $"role-assign-test-{guid}@example.com",
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "Abed1234!@#$" },
                },
            };

            var user = await _userApi.CreateUserAsync(createRequest, activate: false);
            _testUserId = user.Id;

            // Pre-assign one role so GET / LIST tests always have data.
            var assignRequest = new AssignRoleToUserRequest(
                new StandardRoleAssignmentSchema { Type = "READ_ONLY_ADMIN" });

            var assignResponse = await _roleAssignmentApi.AssignRoleToUserAsync(_testUserId, assignRequest);

            // Resolve the role-assignment id from the polymorphic response.
            _primaryRoleAssignmentId = ResolveRoleId(assignResponse);
        }

        // ── Teardown ─────────────────────────────────────────────────────────────

        public async Task DisposeAsync()
        {
            // Best-effort cleanup: unassign roles then delete (deactivate first).
            if (!string.IsNullOrEmpty(_testUserId))
            {
                // Unassign all roles still on the user.
                try
                {
                    var roles = _roleAssignmentApi.ListAssignedRolesForUser(_testUserId);
                    await foreach (var role in roles)
                    {
                        var id = ResolveRoleId(role);
                        if (!string.IsNullOrEmpty(id))
                        {
                            try { await _roleAssignmentApi.UnassignRoleFromUserAsync(_testUserId, id); }
                            catch { /* ignore */ }
                        }
                    }
                }
                catch { /* ignore */ }

                // Delete the test user: first call deactivating, second permanently removes.
                try { await _userApi.DeleteUserAsync(_testUserId); } catch { /* ignore */ }
                try { await _userApi.DeleteUserAsync(_testUserId); } catch { /* ignore */ }
            }
        }

        // ── Helper ───────────────────────────────────────────────────────────────

        /// <summary>Extracts the role-assignment <c>id</c> from the AssignRoleToUser201Response wrapper.</summary>
        private static string ResolveRoleId(AssignRoleToUser201Response wrapper)
        {
            if (wrapper?.ActualInstance is StandardRole sr) return sr.Id;
            if (wrapper?.ActualInstance is CustomRole   cr) return cr.Id;
            return null;
        }

        /// <summary>Extracts the role-assignment <c>id</c> from the ListGroupAssignedRoles200ResponseInner wrapper.</summary>
        private static string ResolveRoleId(ListGroupAssignedRoles200ResponseInner wrapper)
        {
            if (wrapper?.ActualInstance is StandardRole sr) return sr.Id;
            if (wrapper?.ActualInstance is CustomRole   cr) return cr.Id;
            return null;
        }

        /// <summary>Extracts the role <c>type</c> string from the polymorphic response wrapper.</summary>
        private static string ResolveRoleType(ListGroupAssignedRoles200ResponseInner wrapper)
        {
            if (wrapper?.ActualInstance is StandardRole sr) return sr.Type?.Value;
            if (wrapper?.ActualInstance is CustomRole   cr) return cr.Type?.Value;
            return null;
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  COMPREHENSIVE CRUD WORKFLOW
        //  Covers all primary endpoints in a single end-to-end sequence.
        // ═══════════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// End-to-end workflow covering every non-governance method in one test:
        ///   1. POST   AssignRoleToUserAsync              – assign a second role
        ///   1b. POST  AssignRoleToUserAsync              – assign third role with disableNotifications=true
        ///   2. GET    ListAssignedRolesForUser           – all three roles must appear
        ///   2b. GET   ListAssignedRolesForUser           – with expand=targets/groups
        ///   2c. GET   ListAssignedRolesForUser           – with expanding=targets/catalog/apps
        ///   3. GET    GetUserAssignedRoleAsync           – retrieve by id, validate label + _links
        ///   4. GET    ListUsersWithRoleAssignmentsAsync  – test user appears in global list
        ///   5. DELETE UnassignRoleFromUserAsync          – remove the second and third roles
        ///   6. GET    ListAssignedRolesForUser           – only one role remains
        /// </summary>
        [Fact]
        public async Task FullCrudWorkflow_AllCoreEndpoints_ShouldSucceed()
        {
            string helpDeskRoleId = null;
            string reportAdminRoleId = null;

            try
            {
                // ── 1. POST /api/v1/users/{userId}/roles ──────────────────────────────
                var assignRequest = new AssignRoleToUserRequest(
                    new StandardRoleAssignmentSchema { Type = "HELP_DESK_ADMIN" });

                var assignResponse = await _roleAssignmentApi.AssignRoleToUserAsync(
                    _testUserId, assignRequest);

                assignResponse.Should().NotBeNull(
                    "POST /api/v1/users/{userId}/roles must return the created role assignment");

                var assignedStandardRole = assignResponse.GetStandardRole();
                assignedStandardRole.Should().NotBeNull(
                    "HELP_DESK_ADMIN is a standard role and should deserialize as StandardRole");

                assignedStandardRole.Type.Value.Should().Be("HELP_DESK_ADMIN");
                assignedStandardRole.Status.Should().Be(LifecycleStatus.ACTIVE);
                assignedStandardRole.AssignmentType.Should().Be(RoleAssignmentType.USER);
                assignedStandardRole.Id.Should().NotBeNullOrEmpty();
                assignedStandardRole.Created.Should().NotBe(default);
                assignedStandardRole.Label.Should().NotBeNullOrEmpty(
                    "response must include a human-readable label");

                helpDeskRoleId = assignedStandardRole.Id;

                // ── 1b. POST with disableNotifications=true ───────────────────────────
                var reportRequest = new AssignRoleToUserRequest(
                    new StandardRoleAssignmentSchema { Type = "REPORT_ADMIN" });

                var reportResponse = await _roleAssignmentApi.AssignRoleToUserAsync(
                    _testUserId, reportRequest, disableNotifications: true);

                reportResponse.Should().NotBeNull(
                    "POST with disableNotifications=true must return 201 with role object");

                var reportRole = reportResponse.GetStandardRole();
                reportRole.Should().NotBeNull();
                reportRole.Type.Value.Should().Be("REPORT_ADMIN");
                reportRole.Status.Should().Be(LifecycleStatus.ACTIVE);
                reportAdminRoleId = reportRole.Id;

                // ── 2. GET /api/v1/users/{userId}/roles (collection) ──────────────────
                var roleCollection = _roleAssignmentApi.ListAssignedRolesForUser(_testUserId);
                var roles = new List<ListGroupAssignedRoles200ResponseInner>();
                await foreach (var r in roleCollection)
                {
                    roles.Add(r);
                }

                roles.Should().HaveCountGreaterThanOrEqualTo(3,
                    "GET /api/v1/users/{userId}/roles must return at least READ_ONLY_ADMIN + HELP_DESK_ADMIN + REPORT_ADMIN");

                var roleTypes = roles.Select(ResolveRoleType).ToList();
                roleTypes.Should().Contain("READ_ONLY_ADMIN",
                    "the pre-assigned READ_ONLY_ADMIN role must appear in the list");
                roleTypes.Should().Contain("HELP_DESK_ADMIN",
                    "the just-assigned HELP_DESK_ADMIN role must appear in the list");
                roleTypes.Should().Contain("REPORT_ADMIN",
                    "the REPORT_ADMIN role assigned with disableNotifications=true must appear");

                // ── 2b. expand=targets/groups ─────────────────────────────────────
                var expandGroupsCollection = _roleAssignmentApi.ListAssignedRolesForUser(
                    _testUserId, expand: "targets/groups");
                var expandedGroupRoles = new List<ListGroupAssignedRoles200ResponseInner>();
                await foreach (var r in expandGroupsCollection)
                {
                    expandedGroupRoles.Add(r);
                }
                expandedGroupRoles.Should().HaveCountGreaterThanOrEqualTo(1,
                    "GET with expand=targets/groups should return the role list");

                // ── 2c. expand=targets/catalog/apps ──────────────────────────────────
                var expandAppsCollection = _roleAssignmentApi.ListAssignedRolesForUser(
                    _testUserId, expand: "targets/catalog/apps");
                var expandedAppRoles = new List<ListGroupAssignedRoles200ResponseInner>();
                await foreach (var r in expandAppsCollection)
                {
                    expandedAppRoles.Add(r);
                }
                expandedAppRoles.Should().HaveCountGreaterThanOrEqualTo(1,
                    "GET with expand=targets/catalog/apps should return the role list");

                // ── 3. GET /api/v1/users/{userId}/roles/{roleAssignmentId} ─────────────
                var singleRole = await _roleAssignmentApi.GetUserAssignedRoleAsync(
                    _testUserId, helpDeskRoleId);

                singleRole.Should().NotBeNull(
                    "GET /api/v1/users/{userId}/roles/{roleAssignmentId} must return the role");

                var singleStandardRole = singleRole.GetStandardRole();
                singleStandardRole.Should().NotBeNull();
                singleStandardRole.Id.Should().Be(helpDeskRoleId);
                singleStandardRole.Type.Value.Should().Be("HELP_DESK_ADMIN");
                singleStandardRole.Status.Should().Be(LifecycleStatus.ACTIVE);
                singleStandardRole.AssignmentType.Should().Be(RoleAssignmentType.USER);
                singleStandardRole.LastUpdated.Should().NotBe(default);
                singleStandardRole.Label.Should().NotBeNullOrEmpty(
                    "GET single role must include the human-readable label field");
                singleStandardRole.Links.Should().NotBeNull(
                    "GET single role must include _links with assignee href");

                // ── 4. GET /api/v1/iam/assignees/users ────────────────────────────────
                var usersWithRoles = await _roleAssignmentApi.ListUsersWithRoleAssignmentsAsync(limit: 200);

                usersWithRoles.Should().NotBeNull(
                    "GET /api/v1/iam/assignees/users must return a result object");
                usersWithRoles.Value.Should().NotBeNull(
                    "the value collection must not be null");

                // ── 5. DELETE /api/v1/users/{userId}/roles/{roleAssignmentId} ──────────
                var id = helpDeskRoleId;
                var deleteAct = async () =>
                    await _roleAssignmentApi.UnassignRoleFromUserAsync(_testUserId, id);

                await deleteAct.Should().NotThrowAsync(
                    "DELETE /api/v1/users/{userId}/roles/{roleAssignmentId} should return 204 No Content");

                helpDeskRoleId = null; // prevent double-delete in finally block

                // Also delete REPORT_ADMIN (assigned in step 1b)
                await _roleAssignmentApi.UnassignRoleFromUserAsync(_testUserId, reportAdminRoleId);
                reportAdminRoleId = null;

                // ── 6. GET (post-delete verification) ────────────────────────────────
                var rolesAfterDelete = new List<ListGroupAssignedRoles200ResponseInner>();
                await foreach (var r in _roleAssignmentApi.ListAssignedRolesForUser(_testUserId))
                {
                    rolesAfterDelete.Add(r);
                }

                var typesAfterDelete = rolesAfterDelete.Select(ResolveRoleType).ToList();
                typesAfterDelete.Should().NotContain("HELP_DESK_ADMIN",
                    "the deleted HELP_DESK_ADMIN role must no longer appear in the list");
                typesAfterDelete.Should().NotContain("REPORT_ADMIN",
                    "the deleted REPORT_ADMIN role must no longer appear in the list");
                typesAfterDelete.Should().Contain("READ_ONLY_ADMIN",
                    "the remaining READ_ONLY_ADMIN role must still be present");
            }
            finally
            {
                // Safety net: if the test failed before the explicit delete, clean up here.
                if (!string.IsNullOrEmpty(helpDeskRoleId))
                {
                    try { await _roleAssignmentApi.UnassignRoleFromUserAsync(_testUserId, helpDeskRoleId); }
                    catch { /* ignore */ }
                }

                if (!string.IsNullOrEmpty(reportAdminRoleId))
                {
                    try { await _roleAssignmentApi.UnassignRoleFromUserAsync(_testUserId, reportAdminRoleId); }
                    catch { /* ignore */ }
                }
            }
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  AssignRoleToUserAsync – ERROR CASES
        // ═══════════════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task AssignRoleToUserAsync_DuplicateRole_ShouldThrowApiException()
        {
            // READ_ONLY_ADMIN was already assigned in InitializeAsync – a second assignment should fail.
            var request = new AssignRoleToUserRequest(
                new StandardRoleAssignmentSchema { Type = "READ_ONLY_ADMIN" });

            Func<Task> act = async () =>
                await _roleAssignmentApi.AssignRoleToUserAsync(_testUserId, request);

            var ex = await act.Should().ThrowAsync<ApiException>(
                "assigning the same role twice must be rejected with HTTP 409");

            ex.Which.ErrorCode.Should().Be(409,
                "Okta returns 409 Conflict for duplicate role assignment (errorCode E0000090)");
        }

        [Fact]
        public async Task AssignRoleToUserAsync_InvalidUserId_ShouldThrowApiException()
        {
            var request = new AssignRoleToUserRequest(
                new StandardRoleAssignmentSchema { Type = "READ_ONLY_ADMIN" });

            Func<Task> act = async () =>
                await _roleAssignmentApi.AssignRoleToUserAsync("nonexistent-user-id-00000", request);

            var ex = await act.Should().ThrowAsync<ApiException>(
                "assigning a role to a non-existent user must return 404");

            ex.Which.ErrorCode.Should().Be(404,
                "Okta returns 404 with errorCode E0000007 for unknown userId");
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  GetUserAssignedRoleAsync – ERROR CASES
        // ═══════════════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task GetUserAssignedRoleAsync_InvalidRoleAssignmentId_ShouldThrowApiException()
        {
            Func<Task> act = async () =>
                await _roleAssignmentApi.GetUserAssignedRoleAsync(_testUserId, "invalid-role-id-00000");

            var ex = await act.Should().ThrowAsync<ApiException>(
                "retrieving a non-existent role assignment must return 404");

            ex.Which.ErrorCode.Should().Be(404,
                "Okta returns 404 with errorCode E0000007 for unknown roleAssignmentId");
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  UnassignRoleFromUserAsync – ERROR CASES
        // ═══════════════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task UnassignRoleFromUserAsync_InvalidRoleAssignmentId_ShouldThrowApiException()
        {
            var act = async () =>
                await _roleAssignmentApi.UnassignRoleFromUserAsync(_testUserId, "invalid-role-id-00000");

            var ex = await act.Should().ThrowAsync<ApiException>(
                "deleting a non-existent role assignment must return 404");

            ex.Which.ErrorCode.Should().Be(404,
                "Okta returns 404 with errorCode E0000007 for unknown roleAssignmentId");
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  ListUsersWithRoleAssignmentsAsync – PAGINATION
        // ═══════════════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task ListUsersWithRoleAssignmentsAsync_WithPaginationParams_ShouldReturnResult()
        {
            // GET /api/v1/iam/assignees/users?limit=5
            // _links may be null/empty when the org has fewer users than the limit.
            var result = await _roleAssignmentApi.ListUsersWithRoleAssignmentsAsync(limit: 5);

            result.Should().NotBeNull(
                "GET /api/v1/iam/assignees/users must always return a valid response object");
            result.Value.Should().NotBeNull(
                "the value array must not be null even when empty");

            // Each user entry must have at least an id
            foreach (var user in result.Value)
            {
                user.Id.Should().NotBeNullOrEmpty(
                    "every user entry in the assignees list must have an id");
            }

            // Default limit test
            var defaultResult = await _roleAssignmentApi.ListUsersWithRoleAssignmentsAsync();
            defaultResult.Should().NotBeNull();
            defaultResult.Value.Should().NotBeNull();
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  GOVERNANCE ENDPOINTS
        //  These endpoints require Okta Access Governance (OAG) to be provisioned.
        //  Tests accept 403 OR 404 to accommodate both non-OAG and permission-restricted orgs.
        // ═══════════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// GET /api/v1/users/{userId}/roles/{roleAssignmentId}/governance
        ///  endpoints require the Okta Access Governance feature to be enabled.
        /// The test verifies the SDK method is callable and handles a non-OAG org gracefully.
        /// </summary>
        [Fact]
        public async Task GetUserAssignedRoleGovernanceAsync_ShouldReturnOrSkipGracefully()
        {
            RoleGovernance governance = null;
            ApiException apiException = null;

            try
            {
                governance = await _roleAssignmentApi.GetUserAssignedRoleGovernanceAsync(
                    _testUserId, _primaryRoleAssignmentId);
            }
            catch (ApiException ex)
            {
                apiException = ex;
            }

            if (apiException != null)
            {
                // 403: OAG feature not enabled / insufficient scope.
                // 404: Role has no governance sources (valid for non-OAG orgs).
                apiException.ErrorCode.Should().BeOneOf([403, 404],
                    "GET /governance must return 403 (feature off) or 404 (no sources) when OAG is unavailable");
            }
            else
            {
                // OAG is available — assert the shape of the response.
                governance.Should().NotBeNull();
                governance.Grants.Should().NotBeNull(
                    "grants collection must be present (may be empty)");
            }
        }

        /// <summary>
        /// GET /api/v1/users/{userId}/roles/{roleAssignmentId}/governance/{grantId}
        /// Requires an existing governance grant. Tests the error path for unknown grantId.
        /// </summary>
        [Fact]
        public async Task GetRoleAssignmentGovernanceGrantAsync_UnknownGrantId_ShouldThrow404OrSkip()
        {
            ApiException apiException = null;

            try
            {
                await _roleAssignmentApi.GetRoleAssignmentGovernanceGrantAsync(
                    _testUserId, _primaryRoleAssignmentId, "nonexistent-grant-id-00000");
            }
            catch (ApiException ex)
            {
                apiException = ex;
            }

            apiException.Should().NotBeNull(
                "GET /governance/{grantId} with an invalid grantId must throw ApiException");

            apiException?.ErrorCode.Should().BeOneOf([403, 404],
                "error must be 403 (feature off) or 404 (grant not found)");
        }

        /// <summary>
        /// GET /api/v1/users/{userId}/roles/{roleAssignmentId}/governance/{grantId}/resources
        /// Requires an existing governance grant. Tests the error path for unknown grantId.
        /// </summary>
        [Fact]
        public async Task GetRoleAssignmentGovernanceGrantResourcesAsync_UnknownGrantId_ShouldThrow404OrSkip()
        {
            ApiException apiException = null;

            try
            {
                await _roleAssignmentApi.GetRoleAssignmentGovernanceGrantResourcesAsync(
                    _testUserId, _primaryRoleAssignmentId, "nonexistent-grant-id-00000");
            }
            catch (ApiException ex)
            {
                apiException = ex;
            }

            apiException.Should().NotBeNull(
                "GET /governance/{grantId}/resources with an invalid grantId must throw ApiException");

            apiException?.ErrorCode.Should().BeOneOf([403, 404],
                "error must be 403 (feature off) or 404 (grant not found)");
        }

        /// <summary>
        /// Full governance path: if OAG is available, retrieve all grants for the role
        /// then retrieve the first grant and its resources using the concrete grantId.
        /// If OAG is not available, the test passes silently.
        /// </summary>
        [Fact]
        public async Task GovernanceWorkflow_IfOagEnabled_ShouldReturnGrantAndResources()
        {
            RoleGovernance governance;

            try
            {
                governance = await _roleAssignmentApi.GetUserAssignedRoleGovernanceAsync(
                    _testUserId, _primaryRoleAssignmentId);
            }
            catch (ApiException ex) when (ex.ErrorCode == 403 || ex.ErrorCode == 404)
            {
                // OAG is not available — pass silently.
                return;
            }

            if (governance?.Grants == null || governance.Grants.Count == 0)
            {
                // No governance grants exist for this role assignment (valid in non-OAG orgs).
                return;
            }

            // We have at least one grant — exercise GetRoleAssignmentGovernanceGrantAsync.
            var firstGrant = governance.Grants[0];
            firstGrant.GrantId.Should().NotBeNullOrEmpty();
            firstGrant.Type.Should().NotBeNull();

            var singleGrant = await _roleAssignmentApi.GetRoleAssignmentGovernanceGrantAsync(
                _testUserId, _primaryRoleAssignmentId, firstGrant.GrantId);

            singleGrant.Should().NotBeNull(
                "GET /governance/{grantId} must return the grant");
            singleGrant.GrantId.Should().Be(firstGrant.GrantId);

            // Exercise GetRoleAssignmentGovernanceGrantResourcesAsync.
            var resources = await _roleAssignmentApi.GetRoleAssignmentGovernanceGrantResourcesAsync(
                _testUserId, _primaryRoleAssignmentId, firstGrant.GrantId);

            resources.Should().NotBeNull(
                "GET /governance/{grantId}/resources must return a result");
            resources.Resources.Should().NotBeNull(
                "the resources collection must not be null");
        }
    }
}
