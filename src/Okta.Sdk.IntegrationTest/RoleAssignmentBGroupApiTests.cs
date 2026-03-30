// <copyright file="RoleAssignmentBGroupApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for <see cref="RoleAssignmentBGroupApi"/>.
    ///
    /// API Endpoints Covered:
    /// ┌──────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ Method                      │ HTTP   │ Endpoint                                                  │
    /// ├──────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ AssignRoleToGroupAsync      │ POST   │ /api/v1/groups/{groupId}/roles                            │
    /// │ ListGroupAssignedRoles      │ GET    │ /api/v1/groups/{groupId}/roles                            │
    /// │ GetGroupAssignedRoleAsync   │ GET    │ /api/v1/groups/{groupId}/roles/{roleAssignmentId}         │
    /// │ UnassignRoleFromGroupAsync  │ DELETE │ /api/v1/groups/{groupId}/roles/{roleAssignmentId}         │
    /// └──────────────────────────────────────────────────────────────────────────────────────────────────┘
    /// </summary>
    [Collection(nameof(RoleAssignmentBGroupApiTests))]
    public class RoleAssignmentBGroupApiTests : IAsyncLifetime
    {
        private readonly RoleAssignmentBGroupApi _roleAssignmentApi = new();
        private readonly GroupApi _groupApi = new();

        private string _testGroupId;
        private string _primaryRoleAssignmentId;

        // ── Setup ────────────────────────────────────────────────────────────────

        public async Task InitializeAsync()
        {
            var guid = Guid.NewGuid();

            // Create a dedicated test group.
            var createRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name        = $"role-assign-group-{guid.ToString("N")[..12]}",
                    Description = "Integration test group for RoleAssignmentBGroupApi",
                },
            };

            var group = await _groupApi.AddGroupAsync(createRequest);
            _testGroupId = group.Id;

            // Pre-assign READ_ONLY_ADMIN so GET / LIST tests always have at least one role.
            var assignRequest = new AssignRoleToGroupRequest(
                new StandardRoleAssignmentSchema { Type = "READ_ONLY_ADMIN" });

            var assignResponse = await _roleAssignmentApi.AssignRoleToGroupAsync(_testGroupId, assignRequest);
            _primaryRoleAssignmentId = ResolveRoleId(assignResponse);
        }

        // ── Teardown ─────────────────────────────────────────────────────────────

        public async Task DisposeAsync()
        {
            if (!string.IsNullOrEmpty(_testGroupId))
            {
                // Unassign all remaining roles from the group.
                try
                {
                    var roles = _roleAssignmentApi.ListGroupAssignedRoles(_testGroupId);
                    await foreach (var role in roles)
                    {
                        var id = ResolveRoleId(role);
                        if (!string.IsNullOrEmpty(id))
                        {
                            try { await _roleAssignmentApi.UnassignRoleFromGroupAsync(_testGroupId, id); }
                            catch { /* ignore */ }
                        }
                    }
                }
                catch { /* ignore */ }

                // Delete the test group.
                try { await _groupApi.DeleteGroupAsync(_testGroupId); } catch { /* ignore */ }
            }
        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        /// <summary>Extracts the role-assignment <c>id</c> from the polymorphic AssignRoleToGroupAsync response.</summary>
        private static string ResolveRoleId(ListGroupAssignedRoles200ResponseInner wrapper)
        {
            if (wrapper?.ActualInstance is StandardRole sr) return sr.Id;
            if (wrapper?.ActualInstance is CustomRole   cr) return cr.Id;
            return null;
        }

        /// <summary>Extracts the <c>type</c> string from the polymorphic response wrapper.</summary>
        private static string ResolveRoleType(ListGroupAssignedRoles200ResponseInner wrapper)
        {
            if (wrapper?.ActualInstance is StandardRole sr) return sr.Type?.Value;
            if (wrapper?.ActualInstance is CustomRole   cr) return cr.Type?.Value;
            return null;
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  COMPREHENSIVE CRUD WORKFLOW
        //  Exercises all four API methods end-to-end in a single test.
        //
        //  Steps:
        //    1.  POST  AssignRoleToGroupAsync   – assign HELP_DESK_ADMIN (standard)
        //    1b. POST  AssignRoleToGroupAsync   – assign REPORT_ADMIN with disableNotifications=true
        //    2.  GET   ListGroupAssignedRoles   – all three roles appear
        //    2b. GET   ListGroupAssignedRoles   – with expand=targets/groups
        //    2c. GET   ListGroupAssignedRoles   – with expand=targets/catalog/apps
        //    3.  GET   GetGroupAssignedRoleAsync – single role by id; validate label + _links
        //    4.  DELETE UnassignRoleFromGroupAsync – remove HELP_DESK_ADMIN and REPORT_ADMIN
        //    5.  GET   ListGroupAssignedRoles   – only READ_ONLY_ADMIN remains
        // ═══════════════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task FullCrudWorkflow_AllCoreEndpoints_ShouldSucceed()
        {
            string helpDeskRoleId   = null;
            string reportAdminRoleId = null;

            try
            {
                // ── 1. POST /api/v1/groups/{groupId}/roles (HELP_DESK_ADMIN) ──────────
                var assignRequest = new AssignRoleToGroupRequest(
                    new StandardRoleAssignmentSchema { Type = "HELP_DESK_ADMIN" });

                var assignResponse = await _roleAssignmentApi.AssignRoleToGroupAsync(
                    _testGroupId, assignRequest);

                assignResponse.Should().NotBeNull(
                    "POST /api/v1/groups/{groupId}/roles must return the created role assignment");

                var helpDeskRole = assignResponse.GetStandardRole();
                helpDeskRole.Should().NotBeNull(
                    "HELP_DESK_ADMIN is a standard role and must deserialise as StandardRole");

                helpDeskRole.Type.Value.Should().Be("HELP_DESK_ADMIN");
                helpDeskRole.Status.Should().Be(LifecycleStatus.ACTIVE);
                helpDeskRole.AssignmentType.Should().Be(RoleAssignmentType.GROUP,
                    "roles assigned to a group have assignmentType GROUP");
                helpDeskRole.Id.Should().NotBeNullOrEmpty();
                helpDeskRole.Created.Should().NotBe(default);
                helpDeskRole.Label.Should().NotBeNullOrEmpty(
                    "the response must contain a human-readable label");
                helpDeskRole.Links.Should().NotBeNull(
                    "_links must be present in the response");

                helpDeskRoleId = helpDeskRole.Id;

                // ── 1b. POST with disableNotifications=true (REPORT_ADMIN) ────────────
                var reportRequest = new AssignRoleToGroupRequest(
                    new StandardRoleAssignmentSchema { Type = "REPORT_ADMIN" });

                var reportResponse = await _roleAssignmentApi.AssignRoleToGroupAsync(
                    _testGroupId, reportRequest, disableNotifications: true);

                reportResponse.Should().NotBeNull(
                    "POST with disableNotifications=true must return 201 with the role object");

                var reportRole = reportResponse.GetStandardRole();
                reportRole.Should().NotBeNull();
                reportRole.Type.Value.Should().Be("REPORT_ADMIN");
                reportRole.Status.Should().Be(LifecycleStatus.ACTIVE);
                reportRole.AssignmentType.Should().Be(RoleAssignmentType.GROUP);
                reportRole.Label.Should().NotBeNullOrEmpty();

                reportAdminRoleId = reportRole.Id;

                // ── 2. GET /api/v1/groups/{groupId}/roles (list, no expand) ──────────
                var roleCollection = _roleAssignmentApi.ListGroupAssignedRoles(_testGroupId);
                var roles = new List<ListGroupAssignedRoles200ResponseInner>();
                await foreach (var r in roleCollection)
                {
                    roles.Add(r);
                }

                roles.Should().HaveCountGreaterThanOrEqualTo(3,
                    "GET /api/v1/groups/{groupId}/roles must return at least READ_ONLY_ADMIN + HELP_DESK_ADMIN + REPORT_ADMIN");

                var roleTypes = roles.Select(ResolveRoleType).ToList();
                roleTypes.Should().Contain("READ_ONLY_ADMIN",
                    "the pre-assigned READ_ONLY_ADMIN role must appear in the list");
                roleTypes.Should().Contain("HELP_DESK_ADMIN",
                    "the just-assigned HELP_DESK_ADMIN role must appear in the list");
                roleTypes.Should().Contain("REPORT_ADMIN",
                    "the REPORT_ADMIN role assigned with disableNotifications=true must appear");

                // Validate field-level data on every list item (id, status, assignmentType, label, created).
                foreach (var roleItem in roles)
                {
                    var itemRole = roleItem.GetStandardRole();
                    if (itemRole != null)
                    {
                        itemRole.Id.Should().NotBeNullOrEmpty(
                            "each list item must carry its role-assignment id");
                        itemRole.Label.Should().NotBeNullOrEmpty(
                            "label must be present on each list item");
                        itemRole.Status.Should().Be(LifecycleStatus.ACTIVE,
                            "all assigned roles must be ACTIVE");
                        itemRole.AssignmentType.Should().Be(RoleAssignmentType.GROUP,
                            "roles assigned to a group always have assignmentType GROUP");
                        itemRole.Created.Should().NotBe(default,
                            "created timestamp must be present on each list item");
                    }
                }

                // ── 2b. GET with expand=targets/groups ───────────────────────────────
                var expandedGroupRoles = _roleAssignmentApi.ListGroupAssignedRoles(
                    _testGroupId, expand: "targets/groups");
                var expandedGroupList = new List<ListGroupAssignedRoles200ResponseInner>();
                await foreach (var r in expandedGroupRoles)
                {
                    expandedGroupList.Add(r);
                }

                expandedGroupList.Should().HaveCountGreaterThanOrEqualTo(1,
                    "GET with expand=targets/groups must still return the assigned roles");

                // ── 2c. GET with expand=targets/catalog/apps ─────────────────────────
                var expandedAppRoles = _roleAssignmentApi.ListGroupAssignedRoles(
                    _testGroupId, expand: "targets/catalog/apps");
                var expandedAppList = new List<ListGroupAssignedRoles200ResponseInner>();
                await foreach (var r in expandedAppRoles)
                {
                    expandedAppList.Add(r);
                }

                expandedAppList.Should().HaveCountGreaterThanOrEqualTo(1,
                    "GET with expand=targets/catalog/apps must still return the assigned roles");

                // ── 3. GET /api/v1/groups/{groupId}/roles/{roleAssignmentId} ─────────
                var singleRole = await _roleAssignmentApi.GetGroupAssignedRoleAsync(
                    _testGroupId, helpDeskRoleId);

                singleRole.Should().NotBeNull(
                    "GET /api/v1/groups/{groupId}/roles/{roleAssignmentId} must return the role");

                var singleStandardRole = singleRole.GetStandardRole();
                singleStandardRole.Should().NotBeNull();
                singleStandardRole.Id.Should().Be(helpDeskRoleId);
                singleStandardRole.Type.Value.Should().Be("HELP_DESK_ADMIN");
                singleStandardRole.Status.Should().Be(LifecycleStatus.ACTIVE);
                singleStandardRole.AssignmentType.Should().Be(RoleAssignmentType.GROUP);
                singleStandardRole.Label.Should().NotBeNullOrEmpty(
                    "label must be present on the retrieved role");
                singleStandardRole.Links.Should().NotBeNull(
                    "_links must be present on the retrieved role");

                // ── 4. DELETE /api/v1/groups/{groupId}/roles/{roleAssignmentId} ──────
                await _roleAssignmentApi.UnassignRoleFromGroupAsync(_testGroupId, helpDeskRoleId);
                await _roleAssignmentApi.UnassignRoleFromGroupAsync(_testGroupId, reportAdminRoleId);

                // Mark as cleaned up so finally block skips double-delete.
                helpDeskRoleId   = null;
                reportAdminRoleId = null;

                // ── 5. GET list after deletes ────────────────────────────────────────
                var postDeleteCollection = _roleAssignmentApi.ListGroupAssignedRoles(_testGroupId);
                var postDeleteRoles = new List<ListGroupAssignedRoles200ResponseInner>();
                await foreach (var r in postDeleteCollection)
                {
                    postDeleteRoles.Add(r);
                }

                var typesAfterDelete = postDeleteRoles.Select(ResolveRoleType).ToList();
                typesAfterDelete.Should().NotContain("HELP_DESK_ADMIN",
                    "HELP_DESK_ADMIN was unassigned in step 4");
                typesAfterDelete.Should().NotContain("REPORT_ADMIN",
                    "REPORT_ADMIN was unassigned in step 4");
                typesAfterDelete.Should().Contain("READ_ONLY_ADMIN",
                    "READ_ONLY_ADMIN was pre-assigned and not deleted");
            }
            finally
            {
                // Best-effort cleanup for any roles not deleted in the happy path.
                if (!string.IsNullOrEmpty(helpDeskRoleId))
                {
                    try { await _roleAssignmentApi.UnassignRoleFromGroupAsync(_testGroupId, helpDeskRoleId); }
                    catch { /* ignore */ }
                }
                if (!string.IsNullOrEmpty(reportAdminRoleId))
                {
                    try { await _roleAssignmentApi.UnassignRoleFromGroupAsync(_testGroupId, reportAdminRoleId); }
                    catch { /* ignore */ }
                }
            }
        }

        // ═══════════════════════════════════════════════════════════════════════════════
        //  ERROR-PATH TESTS
        // ═══════════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// POST duplicate role → 409 (E0000090)
        /// </summary>
        [Fact]
        public async Task AssignRoleToGroupAsync_DuplicateRole_ShouldThrow409()
        {
            // READ_ONLY_ADMIN is already assigned in InitializeAsync.
            var request = new AssignRoleToGroupRequest(
                new StandardRoleAssignmentSchema { Type = "READ_ONLY_ADMIN" });

            var ex = await Assert.ThrowsAsync<ApiException>(() =>
                _roleAssignmentApi.AssignRoleToGroupAsync(_testGroupId, request));

            ex.ErrorCode.Should().Be(409,
                "assigning the same role twice must return HTTP 409 (role already assigned)");
        }

        /// <summary>
        /// POST with invalid groupId → 404 (E0000007 "UserGroup")
        /// </summary>
        [Fact]
        public async Task AssignRoleToGroupAsync_InvalidGroupId_ShouldThrow404()
        {
            var request = new AssignRoleToGroupRequest(
                new StandardRoleAssignmentSchema { Type = "READ_ONLY_ADMIN" });

            var ex = await Assert.ThrowsAsync<ApiException>(() =>
                _roleAssignmentApi.AssignRoleToGroupAsync("INVALID_GROUP_ID_00000", request));

            ex.ErrorCode.Should().Be(404,
                "a non-existent groupId must return HTTP 404");
        }

        /// <summary>
        /// GET single role with invalid roleAssignmentId → 404 (E0000007 "RoleAssignment")
        /// </summary>
        [Fact]
        public async Task GetGroupAssignedRoleAsync_InvalidRoleAssignmentId_ShouldThrow404()
        {
            var ex = await Assert.ThrowsAsync<ApiException>(() =>
                _roleAssignmentApi.GetGroupAssignedRoleAsync(_testGroupId, "INVALID_ROLE_ID"));

            ex.ErrorCode.Should().Be(404,
                "a non-existent roleAssignmentId must return HTTP 404");
        }

        /// <summary>
        /// DELETE with invalid roleAssignmentId → 404 (E0000007 "RoleAssignment")
        /// Note: deleting an already-deleted role is idempotent (204), but a truly unknown id → 404.
        /// </summary>
        [Fact]
        public async Task UnassignRoleFromGroupAsync_InvalidRoleAssignmentId_ShouldThrow404()
        {
            var ex = await Assert.ThrowsAsync<ApiException>(() =>
                _roleAssignmentApi.UnassignRoleFromGroupAsync(_testGroupId, "INVALID_ROLE_ID"));

            ex.ErrorCode.Should().Be(404,
                "a non-existent roleAssignmentId on DELETE must return HTTP 404");
        }

        /// <summary>
        /// GET list with invalid groupId → 200 with empty array []
        /// it silently returns HTTP 200 with an empty array.
        /// </summary>
        [Fact]
        public async Task ListGroupAssignedRoles_InvalidGroupId_ShouldReturnEmptyList()
        {
            var roles = _roleAssignmentApi.ListGroupAssignedRoles("INVALID_GROUP_ID_00000");
            var list = new List<ListGroupAssignedRoles200ResponseInner>();
            await foreach (var r in roles)
            {
                list.Add(r);
            }

            list.Should().BeEmpty();
        }

        /// <summary>
        /// GET single role with invalid groupId → 404 (E0000007 "GroupRoleAssignment")
        /// Note: error resource type is "GroupRoleAssignment" (not "UserGroup"), because the API
        /// resolves the role assignment by id and fails to find it under the given group.
        /// </summary>
        [Fact]
        public async Task GetGroupAssignedRoleAsync_InvalidGroupId_ShouldThrow404()
        {
            var ex = await Assert.ThrowsAsync<ApiException>(() =>
                _roleAssignmentApi.GetGroupAssignedRoleAsync("INVALID_GROUP_ID_00000", _primaryRoleAssignmentId));

            ex.ErrorCode.Should().Be(404,
                "a non-existent groupId on GET single must return HTTP 404");
        }

        /// <summary>
        /// DELETE with invalid groupId → 404 (E0000007 "UserGroup")
        /// Note: the API validates the group exists before resolving the role assignment.
        /// </summary>
        [Fact]
        public async Task UnassignRoleFromGroupAsync_InvalidGroupId_ShouldThrow404()
        {
            var ex = await Assert.ThrowsAsync<ApiException>(() =>
                _roleAssignmentApi.UnassignRoleFromGroupAsync("INVALID_GROUP_ID_00000", _primaryRoleAssignmentId));

            ex.ErrorCode.Should().Be(404,
                "a non-existent groupId on DELETE must return HTTP 404");
        }
    }
}
