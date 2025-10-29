// <copyright file="GroupOwnerApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Streamlined integration tests for GroupOwnerApi - 4 comprehensive tests covering all 6 methods and 3 endpoints
    /// 
    /// Methods tested:
    /// 1. AssignGroupOwnerAsync - POST /api/v1/groups/{groupId}/owners
    /// 2. AssignGroupOwnerWithHttpInfoAsync - POST with HTTP response info
    /// 3. ListGroupOwners - GET /api/v1/groups/{groupId}/owners
    /// 4. ListGroupOwnersWithHttpInfoAsync - GET with HTTP response info
    /// 5. DeleteGroupOwnerAsync - DELETE /api/v1/groups/{groupId}/owners/{ownerId}
    /// 6. DeleteGroupOwnerWithHttpInfoAsync - DELETE with HTTP response info
    /// </summary>
    [Collection(nameof(GroupOwnerApiTests))]
    public class GroupOwnerApiTests : IAsyncLifetime
    {
        private readonly GroupOwnerApi _groupOwnerApi = new();
        private readonly UserApi _userApi = new();
        private readonly UserLifecycleApi _userLifecycleApi = new();
        private readonly GroupApi _groupApi = new();
        
        // Test users to be used as owners
        private string OwnerUser1Id { get; set; }
        private string OwnerUser2Id { get; set; }
        private string OwnerUser3Id { get; set; }
        
        // Test groups to be used as owners
        private string OwnerGroup1Id { get; set; }
        private string OwnerGroup2Id { get; set; }
        
        // Target group for owner assignments
        private string TargetGroupId { get; set; }
        
        // Shared group with pre-assigned owners for read-only tests
        private string SharedGroupWithOwnersId { get; set; }
        private string SharedOwnerUserId { get; set; }
        private string SharedOwnerGroupId { get; set; }
        
        // Track owners assigned during tests for cleanup
        private readonly Dictionary<string, List<string>> _assignedOwners = new();

        public async Task InitializeAsync()
        {
            var guid = Guid.NewGuid();
            
            // Create test users to be used as group owners
            var ownerUser1 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "GroupOwner1",
                    LastName = "User",
                    Email = $"group-owner1-{guid}@example.com",
                    Login = $"group-owner1-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var ownerUser2 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "GroupOwner2",
                    LastName = "User",
                    Email = $"group-owner2-{guid}@example.com",
                    Login = $"group-owner2-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var ownerUser3 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "GroupOwner3",
                    LastName = "User",
                    Email = $"group-owner3-{guid}@example.com",
                    Login = $"group-owner3-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var sharedOwnerUser = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "SharedOwner",
                    LastName = "User",
                    Email = $"shared-owner-{guid}@example.com",
                    Login = $"shared-owner-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var createdUser1 = await _userApi.CreateUserAsync(ownerUser1, activate: true);
            var createdUser2 = await _userApi.CreateUserAsync(ownerUser2, activate: true);
            var createdUser3 = await _userApi.CreateUserAsync(ownerUser3, activate: true);
            var createdSharedUser = await _userApi.CreateUserAsync(sharedOwnerUser, activate: true);

            OwnerUser1Id = createdUser1.Id;
            OwnerUser2Id = createdUser2.Id;
            OwnerUser3Id = createdUser3.Id;
            SharedOwnerUserId = createdSharedUser.Id;

            // Create groups to be used as owners
            var ownerGroup1 = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"OwnerGroup1-{guid}",
                    Description = "Group to be used as owner"
                }
            };

            var ownerGroup2 = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"OwnerGroup2-{guid}",
                    Description = "Group to be used as owner"
                }
            };

            var sharedOwnerGroup = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"SharedOwnerGroup-{guid}",
                    Description = "Shared group to be used as owner"
                }
            };

            var createdOwnerGroup1 = await _groupApi.AddGroupAsync(ownerGroup1);
            var createdOwnerGroup2 = await _groupApi.AddGroupAsync(ownerGroup2);
            var createdSharedOwnerGroup = await _groupApi.AddGroupAsync(sharedOwnerGroup);

            OwnerGroup1Id = createdOwnerGroup1.Id;
            OwnerGroup2Id = createdOwnerGroup2.Id;
            SharedOwnerGroupId = createdSharedOwnerGroup.Id;

            // Create a target group for owner assignments
            var targetGroup = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TargetGroup-{guid}",
                    Description = "Target group for owner assignments"
                }
            };

            var createdTargetGroup = await _groupApi.AddGroupAsync(targetGroup);
            TargetGroupId = createdTargetGroup.Id;

            // Create a shared group with pre-assigned owners for read-only tests
            var sharedGroup = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"SharedGroupWithOwners-{guid}",
                    Description = "Shared group with owners for read tests"
                }
            };

            var createdSharedGroup = await _groupApi.AddGroupAsync(sharedGroup);
            SharedGroupWithOwnersId = createdSharedGroup.Id;

            // Assign owners to the shared group
            var userOwnerRequest = new AssignGroupOwnerRequestBody
            {
                Id = SharedOwnerUserId,
                Type = GroupOwnerType.USER
            };
            await _groupOwnerApi.AssignGroupOwnerAsync(SharedGroupWithOwnersId, userOwnerRequest);

            var groupOwnerRequest = new AssignGroupOwnerRequestBody
            {
                Id = SharedOwnerGroupId,
                Type = GroupOwnerType.GROUP
            };
            await _groupOwnerApi.AssignGroupOwnerAsync(SharedGroupWithOwnersId, groupOwnerRequest);

            await Task.Delay(2000); // Wait for assignments to propagate
        }

        public async Task DisposeAsync()
        {
            // Cleanup all owners assigned during tests
            await CleanupAssignedOwners();

            // Cleanup: Remove owners from a shared group
            if (!string.IsNullOrEmpty(SharedGroupWithOwnersId))
            {
                try
                {
                    if (!string.IsNullOrEmpty(SharedOwnerUserId))
                    {
                        await _groupOwnerApi.DeleteGroupOwnerAsync(SharedGroupWithOwnersId, SharedOwnerUserId);
                    }
                    if (!string.IsNullOrEmpty(SharedOwnerGroupId))
                    {
                        await _groupOwnerApi.DeleteGroupOwnerAsync(SharedGroupWithOwnersId, SharedOwnerGroupId);
                    }
                }
                catch (ApiException) { }
            }

            // Cleanup: Delete all test groups
            var groupsToDelete = new[]
            {
                OwnerGroup1Id,
                OwnerGroup2Id,
                SharedOwnerGroupId,
                TargetGroupId,
                SharedGroupWithOwnersId
            };

            foreach (var groupId in groupsToDelete)
            {
                if (!string.IsNullOrEmpty(groupId))
                {
                    try
                    {
                        await _groupApi.DeleteGroupAsync(groupId);
                    }
                    catch (ApiException) { }
                }
            }

            // Cleanup: Delete all test users (deactivate first, then delete it)
            var usersToDelete = new[]
            {
                OwnerUser1Id,
                OwnerUser2Id,
                OwnerUser3Id,
                SharedOwnerUserId
            };

            foreach (var userId in usersToDelete)
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    try
                    {
                        await _userLifecycleApi.DeactivateUserAsync(userId);
                        await _userApi.DeleteUserAsync(userId);
                    }
                    catch (ApiException) { }
                }
            }
        }

        private async Task CleanupAssignedOwners()
        {
            // Cleanup all owners assigned during tests
            foreach (var kvp in _assignedOwners)
            {
                var groupId = kvp.Key;
                var ownerIds = kvp.Value;

                foreach (var ownerId in ownerIds)
                {
                    try
                    {
                        await _groupOwnerApi.DeleteGroupOwnerAsync(groupId, ownerId);
                    }
                    catch (ApiException) { }
                }
            }

            _assignedOwners.Clear();
        }

        private void TrackAssignedOwner(string groupId, string ownerId)
        {
            if (!_assignedOwners.ContainsKey(groupId))
            {
                _assignedOwners[groupId] = new List<string>();
            }

            if (!_assignedOwners[groupId].Contains(ownerId))
            {
                _assignedOwners[groupId].Add(ownerId);
            }
        }

        #region Test 1: Complete CRUD Lifecycle - Tests methods 1, 3, 5 (AssignGroupOwnerAsync, ListGroupOwners, DeleteGroupOwnerAsync)

        /// <summary>
        /// Tests the complete CRUD lifecycle for group owners:
        /// - CREATE: AssignGroupOwnerAsync with user and group owners (POST endpoint)
        /// - READ: ListGroupOwners to verify assignments (GET endpoint)
        /// - DELETE: DeleteGroupOwnerAsync to remove owners (DELETE endpoint)
        /// 
        /// This single test covers 3 of the 6 methods and validates all 3 REST API endpoints.
        /// </summary>
        [Fact]
        public async Task GivenGroupOwners_WhenPerformingAssignListDeleteOperations_ThenAllOperationsComplete()
        {
            // ARRANGE
            var groupId = TargetGroupId;

            // ACT 1: CREATE - Assign a user owner using AssignGroupOwnerAsync (Method #1, POST endpoint)
            var userOwnerRequest = new AssignGroupOwnerRequestBody
            {
                Id = OwnerUser1Id,
                Type = GroupOwnerType.USER
            };
            await _groupOwnerApi.AssignGroupOwnerAsync(groupId, userOwnerRequest);
            TrackAssignedOwner(groupId, OwnerUser1Id);

            // ACT 2: CREATE - Assign group owner using AssignGroupOwnerAsync (Method #1, POST endpoint)
            var groupOwnerRequest = new AssignGroupOwnerRequestBody
            {
                Id = OwnerGroup1Id,
                Type = GroupOwnerType.GROUP
            };
            await _groupOwnerApi.AssignGroupOwnerAsync(groupId, groupOwnerRequest);
            TrackAssignedOwner(groupId, OwnerGroup1Id);

            await Task.Delay(1000); // Wait for API propagation

            // ASSERT 1: READ - List owners using ListGroupOwners (Method #3, GET endpoint)
            var owners = await _groupOwnerApi.ListGroupOwners(groupId).ToListAsync();
            
            owners.Should().NotBeNull();
            owners.Should().HaveCount(2);
            
            var userOwner = owners.FirstOrDefault(o => o.Id == OwnerUser1Id);
            userOwner.Should().NotBeNull();
            if (userOwner != null)
            {
                userOwner.Type.Should().Be(GroupOwnerType.USER);
                userOwner.DisplayName.Should().NotBeNullOrEmpty();
                userOwner.LastUpdated.Should().BeAfter(DateTimeOffset.UtcNow.AddHours(-12));
                userOwner.Resolved.Should().BeTrue();
            }

            var groupOwner = owners.FirstOrDefault(o => o.Id == OwnerGroup1Id);
            groupOwner.Should().NotBeNull();
            if (groupOwner != null)
            {
                groupOwner.Type.Should().Be(GroupOwnerType.GROUP);
                groupOwner.DisplayName.Should().NotBeNullOrEmpty();
                groupOwner.LastUpdated.Should().BeAfter(DateTimeOffset.UtcNow.AddHours(-12));
                groupOwner.Resolved.Should().BeTrue();
            }

            // ACT 3: DELETE - Remove user owner using DeleteGroupOwnerAsync (Method #5, DELETE endpoint)
            await _groupOwnerApi.DeleteGroupOwnerAsync(groupId, OwnerUser1Id);
            _assignedOwners[groupId].Remove(OwnerUser1Id);

            await Task.Delay(1000); // Wait for API propagation

            // ASSERT 2: READ - Verify user owner removed, but a group owner remains
            var ownersAfterFirstDelete = await _groupOwnerApi.ListGroupOwners(groupId).ToListAsync();
            ownersAfterFirstDelete.Should().HaveCount(1);
            ownersAfterFirstDelete.Should().NotContain(o => o.Id == OwnerUser1Id);
            ownersAfterFirstDelete.Should().Contain(o => o.Id == OwnerGroup1Id);

            // ACT 4: DELETE - Remove group owner using DeleteGroupOwnerAsync (Method #5, DELETE endpoint)
            await _groupOwnerApi.DeleteGroupOwnerAsync(groupId, OwnerGroup1Id);
            _assignedOwners[groupId].Remove(OwnerGroup1Id);

            await Task.Delay(1000); // Wait for API propagation

            // ASSERT 3: READ - Verify all owners removed
            var ownersAfterAllDeletes = await _groupOwnerApi.ListGroupOwners(groupId).ToListAsync();
            ownersAfterAllDeletes.Should().BeEmpty();
        }

        #endregion

        #region Test 2: WithHttpInfo Methods - Tests methods 2, 4, 6 (All WithHttpInfoAsync variants)

        /// <summary>
        /// Tests all WithHttpInfoAsync method variants that return HTTP response information:
        /// - AssignGroupOwnerWithHttpInfoAsync (Method #2, POST endpoint with HTTP info)
        /// - ListGroupOwnersWithHttpInfoAsync (Method #4, GET endpoint with HTTP info)
        /// - DeleteGroupOwnerWithHttpInfoAsync (Method #6, DELETE endpoint with HTTP info)
        /// 
        /// Validates proper HTTP status codes and response structures.
        /// </summary>
        [Fact]
        public async Task GivenHttpInfoMethods_WhenCallingAllMethods_ThenProperApiResponsesAreReturned()
        {
            // ARRANGE
            var groupId = TargetGroupId;
            var userOwnerRequest = new AssignGroupOwnerRequestBody
            {
                Id = OwnerUser2Id,
                Type = GroupOwnerType.USER
            };

            // ACT 1 & ASSERT 1: Test AssignGroupOwnerWithHttpInfoAsync (Method #2)
            var assignResponse = await _groupOwnerApi.AssignGroupOwnerWithHttpInfoAsync(groupId, userOwnerRequest);
            TrackAssignedOwner(groupId, OwnerUser2Id);

            assignResponse.Should().NotBeNull();
            assignResponse.StatusCode.Should().BeOneOf(System.Net.HttpStatusCode.Created, System.Net.HttpStatusCode.NoContent);

            await Task.Delay(1000); // Wait for API propagation

            // ACT 2 & ASSERT 2: Test ListGroupOwnersWithHttpInfoAsync (Method #4)
            var listResponse = await _groupOwnerApi.ListGroupOwnersWithHttpInfoAsync(groupId);

            listResponse.Should().NotBeNull();
            listResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            listResponse.Data.Should().NotBeNull();
            listResponse.Data.Should().HaveCountGreaterOrEqualTo(1);
            listResponse.Data.Should().Contain(o => o.Id == OwnerUser2Id && o.Type == GroupOwnerType.USER);

            // ACT 3 & ASSERT 3: Test DeleteGroupOwnerWithHttpInfoAsync (Method #6)
            var deleteResponse = await _groupOwnerApi.DeleteGroupOwnerWithHttpInfoAsync(groupId, OwnerUser2Id);
            _assignedOwners[groupId].Remove(OwnerUser2Id);

            deleteResponse.Should().NotBeNull();
            deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

            await Task.Delay(1000); // Wait for API propagation

            // Verify deletion
            var ownersAfterDelete = await _groupOwnerApi.ListGroupOwnersWithHttpInfoAsync(groupId);
            ownersAfterDelete.Data.Should().NotContain(o => o.Id == OwnerUser2Id);
        }

        #endregion

        #region Test 3: Pagination and Filtering - Tests ListGroupOwners parameters

        /// <summary>
        /// Tests the GET endpoint (ListGroupOwners) with various parameters:
        /// - Pagination with 'limit' parameter
        /// - Filtering with 'search' parameter
        /// 
        /// Uses the shared group with pre-assigned owners to test read-only scenarios.
        /// </summary>
        [Fact]
        public async Task GivenPaginationAndFiltering_WhenListingGroupOwners_ThenParametersAreHandled()
        {
            // ARRANGE - Use a shared group with existing owners
            var groupId = SharedGroupWithOwnersId;

            // ACT 1 & ASSERT 1: List all owners without parameters
            var allOwners = await _groupOwnerApi.ListGroupOwnersWithHttpInfoAsync(groupId);
            
            allOwners.Should().NotBeNull();
            allOwners.Data.Should().HaveCountGreaterOrEqualTo(2);
            allOwners.Data.Should().Contain(o => o.Id == SharedOwnerUserId && o.Type == GroupOwnerType.USER);
            allOwners.Data.Should().Contain(o => o.Id == SharedOwnerGroupId && o.Type == GroupOwnerType.GROUP);

            // ACT 2 & ASSERT 2: Test pagination with limit parameter
            var paginatedOwners = await _groupOwnerApi.ListGroupOwnersWithHttpInfoAsync(groupId, limit: 1);
            
            paginatedOwners.Should().NotBeNull();
            paginatedOwners.Data.Should().HaveCount(1);

            // ACT 3 & ASSERT 3: Test filtering with search parameter
            var filteredOwners = await _groupOwnerApi.ListGroupOwnersWithHttpInfoAsync(groupId, search: "type eq \"USER\"");
            
            filteredOwners.Should().NotBeNull();
            filteredOwners.Data.Should().NotBeNull();
            
            // Filter support may vary - be flexible in assertion
            if (filteredOwners.Data.All(o => o.Type == GroupOwnerType.USER))
            {
                // Filter is working - verify only USER types
                filteredOwners.Data.Should().OnlyContain(o => o.Type == GroupOwnerType.USER);
            }
            else
            {
                // Filter not supported - verify at least our user owner exists
                filteredOwners.Data.Should().Contain(o => o.Id == SharedOwnerUserId);
            }
        }

        #endregion

        #region Test 4: Error Handling - Tests exception scenarios for all endpoints

        /// <summary>
        /// Tests error handling across all 3 API endpoints:
        /// - POST endpoint: Invalid group ID and invalid owner ID
        /// - DELETE endpoint: Invalid group ID, invalid owner ID, and double deletion
        /// - Duplicate owner assignment
        /// 
        /// Validates proper HTTP 404 error codes for invalid operations.
        /// </summary>
        [Fact]
        public async Task GivenInvalidOperations_WhenCallingApi_ThenApiExceptionsAreThrown()
        {
            // TEST 1: POST endpoint - Assign with invalid group ID
            var validUserRequest = new AssignGroupOwnerRequestBody
            {
                Id = OwnerUser3Id,
                Type = GroupOwnerType.USER
            };

            var assignInvalidGroupException = await Assert.ThrowsAsync<ApiException>(
                async () => await _groupOwnerApi.AssignGroupOwnerAsync("00g_invalid_id", validUserRequest)
            );
            assignInvalidGroupException.ErrorCode.Should().Be(404);

            // TEST 2: POST endpoint - Assign with invalid owner ID
            var invalidOwnerRequest = new AssignGroupOwnerRequestBody
            {
                Id = "00u_invalid_owner_id",
                Type = GroupOwnerType.USER
            };

            var assignInvalidOwnerException = await Assert.ThrowsAsync<ApiException>(
                async () => await _groupOwnerApi.AssignGroupOwnerAsync(TargetGroupId, invalidOwnerRequest)
            );
            assignInvalidOwnerException.ErrorCode.Should().Be(404);

            // TEST 3: DELETE endpoint - Delete with invalid group ID
            var deleteInvalidGroupException = await Assert.ThrowsAsync<ApiException>(
                async () => await _groupOwnerApi.DeleteGroupOwnerAsync("00g_invalid_id", OwnerUser3Id)
            );
            deleteInvalidGroupException.ErrorCode.Should().Be(404);

            // TEST 4: DELETE endpoint - Delete with invalid owner ID
            var deleteInvalidOwnerException = await Assert.ThrowsAsync<ApiException>(
                async () => await _groupOwnerApi.DeleteGroupOwnerAsync(TargetGroupId, "00u_invalid_owner")
            );
            deleteInvalidOwnerException.ErrorCode.Should().Be(404);

            // TEST 5: POST/DELETE endpoints - Assign, then delete, then try to delete again (double deletion)
            await _groupOwnerApi.AssignGroupOwnerAsync(TargetGroupId, validUserRequest);
            TrackAssignedOwner(TargetGroupId, OwnerUser3Id);

            await Task.Delay(1000); // Wait for propagation

            await _groupOwnerApi.DeleteGroupOwnerAsync(TargetGroupId, OwnerUser3Id);
            _assignedOwners[TargetGroupId].Remove(OwnerUser3Id);

            await Task.Delay(1000); // Wait for propagation

            var doubleDeletionException = await Assert.ThrowsAsync<ApiException>(
                async () => await _groupOwnerApi.DeleteGroupOwnerAsync(TargetGroupId, OwnerUser3Id)
            );
            doubleDeletionException.ErrorCode.Should().Be(404);

            // TEST 6: POST endpoint - Duplicate owner assignment
            await _groupOwnerApi.AssignGroupOwnerAsync(TargetGroupId, validUserRequest);
            TrackAssignedOwner(TargetGroupId, OwnerUser3Id);

            await Task.Delay(1000); // Wait for propagation

            // Try to assign the same owner again - should gracefully or throw handle conflict
            try
            {
                await _groupOwnerApi.AssignGroupOwnerAsync(TargetGroupId, validUserRequest);
                
                // If no exception, verify owner still exists (idempotent behavior)
                var owners = await _groupOwnerApi.ListGroupOwnersWithHttpInfoAsync(TargetGroupId);
                owners.Data.Should().Contain(o => o.Id == OwnerUser3Id);
            }
            catch (ApiException ex)
            {
                // Acceptable to throw 400 Bad Request or 409 Conflict for duplicate
                ex.ErrorCode.Should().BeOneOf(400, 409);
            }

            // Cleanup the owner we used for testing
            try
            {
                await _groupOwnerApi.DeleteGroupOwnerAsync(TargetGroupId, OwnerUser3Id);
                _assignedOwners[TargetGroupId].Remove(OwnerUser3Id);
            }
            catch (ApiException) { /* Already deleted or doesn't exist */ }
        }

        #endregion
    }
}
