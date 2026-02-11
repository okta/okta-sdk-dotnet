// <copyright file="GroupApiTests.cs" company="Okta, Inc">
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
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    public class GroupApiTestFixture : IAsyncLifetime
    {
        private readonly UserApi _userApi = new();
        private readonly ApplicationApi _applicationApi = new();

        public string TestUser1Id { get; private set; }
        public string TestUser2Id { get; private set; }
        public string TestUser3Id { get; private set; }
        public string TestApplicationId { get; private set; }

        public async Task InitializeAsync()
        {
            var guid = Guid.NewGuid();
            
            var user1 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "GroupTest1",
                    LastName = "User",
                    Email = $"group-test1-{guid}@example.com",
                    Login = $"group-test1-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var user2 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "GroupTest2",
                    LastName = "User",
                    Email = $"group-test2-{guid}@example.com",
                    Login = $"group-test2-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var user3 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "GroupTest3",
                    LastName = "User",
                    Email = $"group-test3-{guid}@example.com",
                    Login = $"group-test3-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var createdUser1 = await _userApi.CreateUserAsync(user1, activate: true);
            var createdUser2 = await _userApi.CreateUserAsync(user2, activate: true);
            var createdUser3 = await _userApi.CreateUserAsync(user3, activate: true);

            TestUser1Id = createdUser1.Id;
            TestUser2Id = createdUser2.Id;
            TestUser3Id = createdUser3.Id;

            var application = new BookmarkApplication
            {
                Name = "bookmark",
                Label = $"GroupTestApp-{guid}",
                SignOnMode = "BOOKMARK",
                Settings = new BookmarkApplicationSettings
                {
                    App = new BookmarkApplicationSettingsApplication
                    {
                        Url = "https://example.com",
                        RequestIntegration = false
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(application);
            TestApplicationId = createdApp.Id;
        }

        public async Task DisposeAsync()
        {
            if (!string.IsNullOrEmpty(TestUser1Id))
            {
                try
                {
                    await _userApi.DeleteUserAsync(TestUser1Id);
                    await _userApi.DeleteUserAsync(TestUser1Id);
                }
                catch (ApiException) { }
            }

            if (!string.IsNullOrEmpty(TestUser2Id))
            {
                try
                {
                    await _userApi.DeleteUserAsync(TestUser2Id);
                    await _userApi.DeleteUserAsync(TestUser2Id);
                }
                catch (ApiException) { }
            }

            if (!string.IsNullOrEmpty(TestUser3Id))
            {
                try
                {
                    await _userApi.DeleteUserAsync(TestUser3Id);
                    await _userApi.DeleteUserAsync(TestUser3Id);
                }
                catch (ApiException) { }
            }

            if (!string.IsNullOrEmpty(TestApplicationId))
            {
                try
                {
                    await _applicationApi.DeactivateApplicationAsync(TestApplicationId);
                    await _applicationApi.DeleteApplicationAsync(TestApplicationId);
                }
                catch (ApiException) { }
            }
        }
    }

    [CollectionDefinition(nameof(GroupApiTests))]
    public class GroupApiTestsCollection : ICollectionFixture<GroupApiTestFixture>;

    [Collection(nameof(GroupApiTests))]
    public class GroupApiTests(GroupApiTestFixture fixture) : IDisposable
    {
        private readonly GroupApi _groupApi = new();
        private readonly ApplicationGroupsApi _appGroupsApi = new();
        private readonly List<string> _createdGroupIds = new List<string>();

        public void Dispose()
        {
            CleanupGroups().GetAwaiter().GetResult();
        }

        private async Task CleanupGroups()
        {
            foreach (var groupId in _createdGroupIds)
            {
                try
                {
                    await _groupApi.DeleteGroupAsync(groupId);
                }
                catch (ApiException) { }
            }
            _createdGroupIds.Clear();
        }

        private string GetGroupName(GroupProfile profile)
        {
            if (profile?.ActualInstance is OktaUserGroupProfile userProfile)
                return userProfile.Name;
            else if (profile?.ActualInstance is OktaActiveDirectoryGroupProfile adProfile)
                return adProfile.Name;
            return null;
        }

        private string GetGroupDescription(GroupProfile profile)
        {
            if (profile?.ActualInstance is OktaUserGroupProfile userProfile)
                return userProfile.Description;
            else if (profile?.ActualInstance is OktaActiveDirectoryGroupProfile adProfile)
                return adProfile.Description;
            return null;
        }

        /// <summary>
        /// Comprehensive test covering all Group API operations, endpoints, and methods.
        /// Tests CRUD operations, user membership, application assignments, HttpInfo variants,
        /// pagination, filtering, sorting, error handling, and edge cases.
        /// </summary>
        [Fact]
        public async Task GivenGroupApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();
            var testGroupName = $"ComprehensiveTest-{guid}";
            var testGroupDesc = "Comprehensive test group";

            // ==================== CREATE OPERATIONS ====================
            
            //AddGroup - Create a group with valid data
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = testGroupName,
                    Description = testGroupDesc
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            createdGroup.Should().NotBeNull();
            createdGroup.Id.Should().NotBeNullOrEmpty();
            GetGroupName(createdGroup.Profile).Should().Be(testGroupName);
            GetGroupDescription(createdGroup.Profile).Should().Be(testGroupDesc);
            createdGroup.Type.Should().Be(GroupType.OKTAGROUP);
            createdGroup.Created.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
            createdGroup.LastUpdated.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
            createdGroup.LastMembershipUpdated.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
            createdGroup.ObjectClass.Should().Contain("okta:user_group");

            var groupId = createdGroup.Id;

            //AddGroupWithHttpInfo - Verify HTTP response details
            var httpInfoGroupName = $"HttpInfoTest-{guid}";
            var httpInfoRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = httpInfoGroupName,
                    Description = "Test group with HTTP info"
                }
            };

            var addResponse = await _groupApi.AddGroupWithHttpInfoAsync(httpInfoRequest);
            _createdGroupIds.Add(addResponse.Data.Id);

            addResponse.Should().NotBeNull();
            addResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            addResponse.Headers.Should().NotBeNull();
            addResponse.Data.Should().NotBeNull();
            addResponse.Data.Id.Should().NotBeNullOrEmpty();
            GetGroupName(addResponse.Data.Profile).Should().Be(httpInfoGroupName);
            addResponse.Data.Type.Should().Be(GroupType.OKTAGROUP);

            //Create a group with name only (no description)
            var nameOnlyRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"NameOnly-{guid}"
                }
            };

            var nameOnlyGroup = await _groupApi.AddGroupAsync(nameOnlyRequest);
            _createdGroupIds.Add(nameOnlyGroup.Id);

            nameOnlyGroup.Should().NotBeNull();
            GetGroupName(nameOnlyGroup.Profile).Should().Be($"NameOnly-{guid}");
            GetGroupDescription(nameOnlyGroup.Profile).Should().BeNull();

            // ==================== READ OPERATIONS ====================

            // GetGroup - Retrieve group by ID
            var retrievedGroup = await _groupApi.GetGroupAsync(groupId);

            retrievedGroup.Should().NotBeNull();
            retrievedGroup.Id.Should().Be(groupId);
            GetGroupName(retrievedGroup.Profile).Should().Be(testGroupName);
            GetGroupDescription(retrievedGroup.Profile).Should().Be(testGroupDesc);
            retrievedGroup.Type.Should().Be(GroupType.OKTAGROUP);

            // GetGroupWithHttpInfo - Verify HTTP response
            var getResponse = await _groupApi.GetGroupWithHttpInfoAsync(groupId);

            getResponse.Should().NotBeNull();
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.Headers.Should().NotBeNull();
            getResponse.Data.Should().NotBeNull();
            getResponse.Data.Id.Should().Be(groupId);
            GetGroupName(getResponse.Data.Profile).Should().Be(testGroupName);

            // ListGroups - Basic listing
            var allGroups = await _groupApi.ListGroups().ToListAsync();

            allGroups.Should().NotBeNull();
            allGroups.Should().NotBeEmpty();
            allGroups.Should().Contain(g => g.Id == groupId);

            // ListGroups with search parameter (with retry for search index)
            var searchQuery = $"profile.name eq \"{testGroupName}\"";
            List<Group> searchResults = null;
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(3000);
                searchResults = await _groupApi.ListGroups(search: searchQuery).ToListAsync();
                if (searchResults.Any(g => g.Id == groupId))
                    break;
            }

            searchResults.Should().NotBeNull();
            searchResults.Should().Contain(g => g.Id == groupId);

            // ListGroups with query parameter (partial match)
            var queryPrefix = testGroupName.Substring(0, Math.Min(15, testGroupName.Length));
            var queryResults = await _groupApi.ListGroups(q: queryPrefix).ToListAsync();

            queryResults.Should().NotBeNull();
            queryResults.Should().Contain(g => g.Id == groupId);

            // ListGroups with filter parameter
            var filterQuery = "type eq \"OKTA_GROUP\"";
            var filterResults = await _groupApi.ListGroups(filter: filterQuery).ToListAsync();

            filterResults.Should().NotBeNull();
            filterResults.Should().NotBeEmpty();
            filterResults.Should().OnlyContain(g => g.Type == GroupType.OKTAGROUP);

            var limitedResponse = await _groupApi.ListGroupsWithHttpInfoAsync(limit: 5);

            limitedResponse.Should().NotBeNull();
            limitedResponse.Data.Should().NotBeNull();
            limitedResponse.Data.Should().HaveCountLessThanOrEqualTo(5);

            // ListGroups with sorting (ascending and descending)
            var ascGroups = await _groupApi.ListGroups(limit: 10, sortBy: "profile.name", sortOrder: "asc").ToListAsync();
            ascGroups.Should().NotBeNull();
            ascGroups.Should().NotBeEmpty();

            var descGroups = await _groupApi.ListGroups(limit: 10, sortBy: "profile.name", sortOrder: "desc").ToListAsync();
            descGroups.Should().NotBeNull();
            descGroups.Should().NotBeEmpty();

            // ListGroupsWithHttpInfo with pagination
            var firstPageResponse = await _groupApi.ListGroupsWithHttpInfoAsync(limit: 2);

            firstPageResponse.Should().NotBeNull();
            firstPageResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            firstPageResponse.Headers.Should().NotBeNull();
            firstPageResponse.Data.Should().NotBeNull();
            firstPageResponse.Data.Should().HaveCountLessThanOrEqualTo(2);

            // Test pagination with 'after' cursor if available
            if (firstPageResponse.Headers.TryGetValue("Link", out var linkHeaders) && linkHeaders.Any())
            {
                var linkHeader = linkHeaders.First();
                if (linkHeader.Contains("after="))
                {
                    var afterMatch = System.Text.RegularExpressions.Regex.Match(linkHeader, @"after=([^&>]+)");
                    if (afterMatch.Success)
                    {
                        var afterCursor = afterMatch.Groups[1].Value;
                        var secondPageResponse = await _groupApi.ListGroupsWithHttpInfoAsync(after: afterCursor, limit: 2);

                        secondPageResponse.Should().NotBeNull();
                        secondPageResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                        secondPageResponse.Data.Should().NotBeNull();

                        var firstPageIds = firstPageResponse.Data.Select(g => g.Id).ToList();
                        var secondPageIds = secondPageResponse.Data.Select(g => g.Id).ToList();
                        secondPageIds.Should().NotContain(firstPageIds, "Second page should have different groups");
                    }
                }
            }

            // ListGroups with expanded parameter (stats)
            var expandedGroups = await _groupApi.ListGroups(filter: $"id eq \"{groupId}\"", expand: "stats").ToListAsync();
            expandedGroups.Should().NotBeNull();
            expandedGroups.Should().ContainSingle();

            // ==================== UPDATE OPERATIONS ====================

            // ReplaceGroup - Update group profile
            var updatedName = $"Updated-{guid}";
            var updatedDesc = "Updated description";
            var updateRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = updatedName,
                    Description = updatedDesc
                }
            };

            var updatedGroup = await _groupApi.ReplaceGroupAsync(groupId, updateRequest);

            updatedGroup.Should().NotBeNull();
            updatedGroup.Id.Should().Be(groupId);
            GetGroupName(updatedGroup.Profile).Should().Be(updatedName);
            GetGroupDescription(updatedGroup.Profile).Should().Be(updatedDesc);
            updatedGroup.LastUpdated.Should().BeAfter(createdGroup.LastUpdated);

            // ReplaceGroupWithHttpInfo - Verify HTTP response
            var secondUpdateName = $"SecondUpdate-{guid}";
            var secondUpdateRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = secondUpdateName,
                    Description = "Second update"
                }
            };

            var replaceResponse = await _groupApi.ReplaceGroupWithHttpInfoAsync(groupId, secondUpdateRequest);

            replaceResponse.Should().NotBeNull();
            replaceResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            replaceResponse.Headers.Should().NotBeNull();
            replaceResponse.Data.Should().NotBeNull();
            replaceResponse.Data.Id.Should().Be(groupId);
            GetGroupName(replaceResponse.Data.Profile).Should().Be(secondUpdateName);
            GetGroupDescription(replaceResponse.Data.Profile).Should().Be("Second update");

            // Update group - remove description (set to null)
            var removeDescRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = secondUpdateName,
                    Description = null
                }
            };

            var noDescGroup = await _groupApi.ReplaceGroupAsync(groupId, removeDescRequest);
            noDescGroup.Should().NotBeNull();
            GetGroupDescription(noDescGroup.Profile).Should().BeNullOrEmpty();

            // ==================== USER MEMBERSHIP OPERATIONS ====================

            // AssignUserToGroup - Add first user
            await _groupApi.AssignUserToGroupAsync(groupId, fixture.TestUser1Id);
            await Task.Delay(1500);

            var usersAfterFirstAssign = await _groupApi.ListGroupUsers(groupId).ToListAsync();
            usersAfterFirstAssign.Should().Contain(u => u.Id == fixture.TestUser1Id);

            // AssignUserToGroupWithHttpInfo - Add second user
            var assignResponse = await _groupApi.AssignUserToGroupWithHttpInfoAsync(groupId, fixture.TestUser2Id);

            assignResponse.Should().NotBeNull();
            assignResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

            await Task.Delay(1500);

            // ListGroupUsers - Verify multiple users (with retry for eventual consistency)
            List<User> usersAfterSecondAssign = null;
            for (int i = 0; i < 5; i++)
            {
                usersAfterSecondAssign = await _groupApi.ListGroupUsers(groupId).ToListAsync();
                if (usersAfterSecondAssign.Count >= 2)
                    break;
                await Task.Delay(2000);
            }

            usersAfterSecondAssign.Should().HaveCountGreaterThanOrEqualTo(2);
            usersAfterSecondAssign.Should().Contain(u => u.Id == fixture.TestUser1Id);
            usersAfterSecondAssign.Should().Contain(u => u.Id == fixture.TestUser2Id);

            // Assign third user
            await _groupApi.AssignUserToGroupAsync(groupId, fixture.TestUser3Id);
            await Task.Delay(1500);

            var allUsers = await _groupApi.ListGroupUsers(groupId).ToListAsync();
            allUsers.Should().HaveCount(3);
            allUsers.Should().Contain(u => u.Id == fixture.TestUser3Id);

            // ListGroupUsersWithHttpInfo - Verify HTTP response
            var listUsersResponse = await _groupApi.ListGroupUsersWithHttpInfoAsync(groupId, limit: 10);

            listUsersResponse.Should().NotBeNull();
            listUsersResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            listUsersResponse.Headers.Should().NotBeNull();
            listUsersResponse.Data.Should().NotBeNull();
            listUsersResponse.Data.Should().HaveCount(3);
            listUsersResponse.Data.Should().Contain(u => u.Id == fixture.TestUser1Id);

            // ListGroupUsers with pagination
            var firstUserPageResponse = await _groupApi.ListGroupUsersWithHttpInfoAsync(groupId, limit: 1);

            firstUserPageResponse.Should().NotBeNull();
            firstUserPageResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            firstUserPageResponse.Data.Should().HaveCountLessThanOrEqualTo(1);

            if (firstUserPageResponse.Headers.TryGetValue("Link", out var userLinkHeaders) && userLinkHeaders.Any())
            {
                var userLinkHeader = userLinkHeaders.First();
                if (userLinkHeader.Contains("after="))
                {
                    var afterMatch = System.Text.RegularExpressions.Regex.Match(userLinkHeader, @"after=([^&>]+)");
                    if (afterMatch.Success)
                    {
                        var afterCursor = afterMatch.Groups[1].Value;
                        var secondUserPageResponse = await _groupApi.ListGroupUsersWithHttpInfoAsync(groupId, after: afterCursor, limit: 1);

                        secondUserPageResponse.Should().NotBeNull();
                        secondUserPageResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                        secondUserPageResponse.Data.Should().NotBeNull();

                        var firstPageUserIds = firstUserPageResponse.Data.Select(u => u.Id).ToList();
                        var secondPageUserIds = secondUserPageResponse.Data.Select(u => u.Id).ToList();
                        secondPageUserIds.Should().NotContain(firstPageUserIds, "Second page should have different users");
                    }
                }
            }

            // UnassignUserFromGroup - Remove user
            await _groupApi.UnassignUserFromGroupAsync(groupId, fixture.TestUser2Id);
            await Task.Delay(1500);

            var usersAfterRemoval = await _groupApi.ListGroupUsers(groupId).ToListAsync();
            usersAfterRemoval.Should().HaveCount(2);
            usersAfterRemoval.Should().NotContain(u => u.Id == fixture.TestUser2Id);
            usersAfterRemoval.Should().Contain(u => u.Id == fixture.TestUser1Id);
            usersAfterRemoval.Should().Contain(u => u.Id == fixture.TestUser3Id);

            // UnassignUserFromGroupWithHttpInfo - Verify HTTP response
            var unassignResponse = await _groupApi.UnassignUserFromGroupWithHttpInfoAsync(groupId, fixture.TestUser3Id);

            unassignResponse.Should().NotBeNull();
            unassignResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

            await Task.Delay(1500);

            // Verify users after unassignment (with retry for eventual consistency)
            List<User> finalUsers = null;
            for (int i = 0; i < 5; i++)
            {
                finalUsers = await _groupApi.ListGroupUsers(groupId).ToListAsync();
                if (finalUsers.Count == 1)
                    break;
                await Task.Delay(2000);
            }
            finalUsers.Should().HaveCount(1);
            finalUsers.Should().Contain(u => u.Id == fixture.TestUser1Id);

            // Idempotency - Assign same user multiple times
            await _groupApi.AssignUserToGroupAsync(groupId, fixture.TestUser1Id);
            await _groupApi.AssignUserToGroupAsync(groupId, fixture.TestUser1Id);
            await Task.Delay(1000);

            var idempotentUsers = await _groupApi.ListGroupUsers(groupId).ToListAsync();
            idempotentUsers.Should().HaveCount(1, "Multiple assignments should be idempotent");

            // Idempotency - Unassign user not in group (should not throw)
            await _groupApi.UnassignUserFromGroupAsync(groupId, fixture.TestUser2Id);

            // ==================== APPLICATION ASSIGNMENT OPERATIONS ====================

            // Assign application to group
            var appGroupAssignment = new ApplicationGroupAssignment { Priority = 0 };
            await _appGroupsApi.AssignGroupToApplicationAsync(fixture.TestApplicationId, groupId, appGroupAssignment);
            await Task.Delay(1500);

            // ListAssignedApplicationsForGroup - Verify assignment
            var assignedApps = await _groupApi.ListAssignedApplicationsForGroup(groupId).ToListAsync();

            assignedApps.Should().NotBeNull();
            assignedApps.Should().Contain(a => a.Id == fixture.TestApplicationId);

            // ListAssignedApplicationsForGroupWithHttpInfo - Verify HTTP response
            var listAppsResponse = await _groupApi.ListAssignedApplicationsForGroupWithHttpInfoAsync(groupId, limit: 10);

            listAppsResponse.Should().NotBeNull();
            listAppsResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            listAppsResponse.Headers.Should().NotBeNull();
            listAppsResponse.Data.Should().NotBeNull();
            listAppsResponse.Data.Should().Contain(a => a.Id == fixture.TestApplicationId);

            // ListAssignedApplicationsForGroup with pagination
            var firstAppPageResponse = await _groupApi.ListAssignedApplicationsForGroupWithHttpInfoAsync(groupId, limit: 1);

            firstAppPageResponse.Should().NotBeNull();
            firstAppPageResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            firstAppPageResponse.Data.Should().NotBeNull();

            if (firstAppPageResponse.Headers.TryGetValue("Link", out var appLinkHeaders) && appLinkHeaders.Any())
            {
                var appLinkHeader = appLinkHeaders.First();
                if (appLinkHeader.Contains("after="))
                {
                    var afterMatch = System.Text.RegularExpressions.Regex.Match(appLinkHeader, @"after=([^&>]+)");
                    if (afterMatch.Success)
                    {
                        var afterCursor = afterMatch.Groups[1].Value;
                        var secondAppPageResponse = await _groupApi.ListAssignedApplicationsForGroupWithHttpInfoAsync(groupId, after: afterCursor, limit: 1);

                        secondAppPageResponse.Should().NotBeNull();
                        secondAppPageResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                        secondAppPageResponse.Data.Should().NotBeNull();

                        var firstPageAppIds = firstAppPageResponse.Data.Select(a => a.Id).ToList();
                        var secondPageAppIds = secondAppPageResponse.Data.Select(a => a.Id).ToList();
                        secondPageAppIds.Should().NotContain(firstPageAppIds, "Second page should have different apps");
                    }
                }
            }

            // Cleanup application assignment
            await _appGroupsApi.UnassignApplicationFromGroupAsync(fixture.TestApplicationId, groupId);

            // ==================== DELETE OPERATIONS ====================

            // Create a separate group for delete testing
            var deleteTestGroup = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"DeleteTest-{guid}",
                    Description = "Group for delete testing"
                }
            };

            var groupToDelete = await _groupApi.AddGroupAsync(deleteTestGroup);
            var deleteGroupId = groupToDelete.Id;

            // DeleteGroupWithHttpInfo - Verify HTTP response
            var deleteResponse = await _groupApi.DeleteGroupWithHttpInfoAsync(deleteGroupId);

            deleteResponse.Should().NotBeNull();
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // A verified group is deleted
            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.GetGroupAsync(deleteGroupId));

            ex.Should().NotBeNull();
            ex.ErrorCode.Should().Be(404);
            ex.Message.Should().Contain("Not found");

            // DeleteGroup - Delete main test group
            await _groupApi.DeleteGroupAsync(groupId);
            _createdGroupIds.Remove(groupId);

            var deleteEx = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.GetGroupAsync(groupId));

            deleteEx.Should().NotBeNull();
            deleteEx.ErrorCode.Should().Be(404);

            // ==================== EDGE CASES ====================

            // Create and immediately query an empty group
            var emptyGroup = await _groupApi.AddGroupAsync(new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"EmptyGroup-{guid}",
                    Description = "Empty group test"
                }
            });
            _createdGroupIds.Add(emptyGroup.Id);

            var emptyGroupUsers = await _groupApi.ListGroupUsers(emptyGroup.Id).ToListAsync();
            emptyGroupUsers.Should().NotBeNull();
            emptyGroupUsers.Should().BeEmpty();

            var emptyGroupApps = await _groupApi.ListAssignedApplicationsForGroup(emptyGroup.Id).ToListAsync();
            emptyGroupApps.Should().NotBeNull();
            emptyGroupApps.Should().BeEmpty();
        }

        /// <summary>
        /// Test error handling and response validation for Group API operations.
        /// Ensures proper error codes and meaningful error messages.
        /// </summary>
        [Fact]
        public async Task GivenInvalidOperations_WhenCallingApi_ThenCorrectErrorCodesAreReturned()
        {
            var guid = Guid.NewGuid();

            // Get a group with invalid ID
            var invalidGetEx = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.GetGroupAsync("invalid_group_id_12345"));

            invalidGetEx.Should().NotBeNull();
            invalidGetEx.ErrorCode.Should().Be(404);
            invalidGetEx.Message.Should().NotBeNullOrEmpty();

            // Update group with invalid ID
            var updateRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile { Name = "Test" }
            };

            var invalidUpdateEx = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.ReplaceGroupAsync("invalid_group_id_12345", updateRequest));

            invalidUpdateEx.Should().NotBeNull();
            invalidUpdateEx.ErrorCode.Should().Be(404);

            // Delete group with invalid ID
            var invalidDeleteEx = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.DeleteGroupAsync("invalid_group_id_12345"));

            invalidDeleteEx.Should().NotBeNull();
            invalidDeleteEx.ErrorCode.Should().Be(404);

            // Delete already deleted a group
            var tempGroup = await _groupApi.AddGroupAsync(new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile { Name = $"TempGroup-{guid}" }
            });
            await _groupApi.DeleteGroupAsync(tempGroup.Id);

            var doubleDeleteEx = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.DeleteGroupAsync(tempGroup.Id));

            doubleDeleteEx.Should().NotBeNull();
            doubleDeleteEx.ErrorCode.Should().Be(404);

            // Assign user to an invalid group
            var invalidGroupAssignEx = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.AssignUserToGroupAsync("invalid_group_id", fixture.TestUser1Id));

            invalidGroupAssignEx.Should().NotBeNull();
            invalidGroupAssignEx.ErrorCode.Should().Be(404);

            // Assign invalid user to group
            var validGroup = await _groupApi.AddGroupAsync(new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile { Name = $"ValidGroup-{guid}" }
            });
            _createdGroupIds.Add(validGroup.Id);

            var invalidUserAssignEx = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.AssignUserToGroupAsync(validGroup.Id, "invalid_user_id"));

            invalidUserAssignEx.Should().NotBeNull();
            invalidUserAssignEx.ErrorCode.Should().Be(404);

            // Create a group with null name
            var nullNameEx = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.AddGroupAsync(new AddGroupRequest
                {
                    Profile = new OktaUserGroupProfile
                    {
                        Name = null,
                        Description = "Group without name"
                    }
                }));

            nullNameEx.Should().NotBeNull();
            nullNameEx.ErrorCode.Should().Be(400);
            nullNameEx.Message.Should().NotBeNullOrEmpty();

            // Create a group with empty name
            var emptyNameEx = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.AddGroupAsync(new AddGroupRequest
                {
                    Profile = new OktaUserGroupProfile
                    {
                        Name = "",
                        Description = "Group with empty name"
                    }
                }));

            emptyNameEx.Should().NotBeNull();
            emptyNameEx.ErrorCode.Should().Be(400);

            // Unassign user from an invalid group
            var invalidUnassignEx = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.UnassignUserFromGroupAsync("invalid_group_id", fixture.TestUser1Id));

            invalidUnassignEx.Should().NotBeNull();
            invalidUnassignEx.ErrorCode.Should().Be(404);

            // List users from an invalid group
            var invalidListUsersEx = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.ListGroupUsers("invalid_group_id").ToListAsync());

            invalidListUsersEx.Should().NotBeNull();
            invalidListUsersEx.ErrorCode.Should().Be(404);

            // List applications for an invalid group
            var invalidListAppsEx = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.ListAssignedApplicationsForGroup("invalid_group_id").ToListAsync());

            invalidListAppsEx.Should().NotBeNull();
            invalidListAppsEx.ErrorCode.Should().Be(404);
        }

        /// <summary>
        /// Reproduces Issue #812: Group enumeration broken in SDK 10.0.0
        /// Tests that ListGroups() correctly handles Active Directory-synced groups
        /// and doesn't silently fail on deserialization errors.
        /// 
        /// This test verifies the fix for the GroupProfile deserialization issue with OktaActiveDirectoryGroupProfile.
        /// Requires an Okta org with AD-synced groups for full validation.
        /// </summary>
        [Fact]
        public async Task ListGroups_WithADGroups_ShouldEnumerateAllGroupsSuccessfully()
        {
            // Act - Try to get raw API response first to verify deserialization works
            var directResponse = await _groupApi.ListGroupsWithHttpInfoAsync();
            
            // Assert - HttpInfo should not throw exceptions
            directResponse.Should().NotBeNull();
            directResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            directResponse.Data.Should().NotBeNull();
            directResponse.RawContent.Should().NotBeNullOrEmpty("API should return JSON content");

            // Verify if there are AD groups, they deserialize correctly
            if (directResponse.Data.Any())
            {
                var firstGroup = directResponse.Data.First();
                firstGroup.Id.Should().NotBeNullOrEmpty();
                firstGroup.Profile.Should().NotBeNull();
                firstGroup.Profile.ActualInstance.Should().NotBeNull("Profile should deserialize to concrete type");

                // If it's an AD group, verify AD-specific properties
                if (firstGroup.Profile.ActualInstance is OktaActiveDirectoryGroupProfile adProfile)
                {
                    adProfile.Name.Should().NotBeNullOrEmpty("AD profile should have name");
                    // Verify the 4 properties that were missing and causing issues
                    // These properties may be null but should not cause deserialization errors
                    adProfile.Should().NotBeNull();
                }
            }
            
            // Act - Enumerate all groups using async enumeration
            var groups = new List<Group>();
            Exception enumerationException = null;

            try
            {
                await foreach (var group in _groupApi.ListGroups().ConfigureAwait(false))
                {
                    groups.Add(group);
                }
            }
            catch (Exception ex)
            {
                enumerationException = ex;
            }

            // Assert - Groups should be returned without exceptions
            enumerationException.Should().BeNull("ListGroups() should not throw exceptions during enumeration");
            groups.Should().NotBeEmpty("ListGroups() should return groups, not an empty collection");

            // Verify we can access group properties
            foreach (var group in groups)
            {
                group.Id.Should().NotBeNullOrEmpty("Each group should have an ID");
                group.Profile.Should().NotBeNull("Each group should have a Profile");

                // Verify we can determine the profile type
                var isUserGroup = group.Profile.ActualInstance is OktaUserGroupProfile;
                var isAdGroup = group.Profile.ActualInstance is OktaActiveDirectoryGroupProfile;

                (isUserGroup || isAdGroup).Should().BeTrue(
                    "Group profile should be either OktaUserGroupProfile or OktaActiveDirectoryGroupProfile");

                // Specifically, check AD groups can be deserialized
                if (group.ObjectClass != null && group.ObjectClass.Contains("okta:windows_security_principal"))
                {
                    isAdGroup.Should().BeTrue("Groups with objectClass 'okta:windows_security_principal' should deserialize as OktaActiveDirectoryGroupProfile");
                    
                    var adProfile = group.Profile.ActualInstance as OktaActiveDirectoryGroupProfile;
                    adProfile.Should().NotBeNull();
                    adProfile?.Name.Should().NotBeNullOrEmpty("AD group should have a name");
                    
                    // Verify AD-specific properties exist (they were missing and causing deserialization failures)
                    // These properties may be null but must be present on the model
                    var properties = typeof(OktaActiveDirectoryGroupProfile).GetProperties();
                    properties.Should().Contain(p => p.Name == "GroupType", "GroupType property should exist");
                    properties.Should().Contain(p => p.Name == "GroupScope", "GroupScope property should exist");
                    properties.Should().Contain(p => p.Name == "ObjectSid", "ObjectSid property should exist");
                    properties.Should().Contain(p => p.Name == "ManagedBy", "ManagedBy property should exist");
                }
            }

            // Also test the HttpInfo variant to ensure it doesn't throw deserialization errors
            var httpInfoResponse = await _groupApi.ListGroupsWithHttpInfoAsync();
            httpInfoResponse.Should().NotBeNull();
            httpInfoResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            httpInfoResponse.Data.Should().NotBeNull();
            httpInfoResponse.Data.Should().NotBeEmpty();

            // Note: HttpInfo returns only first page, while enumeration gets all pages,
            // So we just verify both return valid data
            var httpInfoGroups = httpInfoResponse.Data.ToList();
            httpInfoGroups.Should().NotBeEmpty("HttpInfo should return groups from first page");
            groups.Count.Should().BeGreaterThanOrEqualTo(httpInfoGroups.Count, 
                "Enumeration should return at least as many groups as first page");
        }

        /// <summary>
        /// Tests direct deserialization of OktaActiveDirectoryGroupProfile from JSON
        /// to ensure all required AD-specific properties can be deserialized.
        /// </summary>
        [Fact]
        public void OktaActiveDirectoryGroupProfile_ShouldDeserializeFromJson()
        {
            // Arrange - This is actual JSON from the Okta API for an AD group
            var adGroupJson = @"{
                ""name"": ""Allowed RODC Password Replication Group"",
                ""description"": ""Members in this group can have their passwords replicated to all read-only domain controllers in the domain"",
                ""windowsDomainQualifiedName"": ""CORP\\Allowed RODC Password Replication Group"",
                ""groupType"": ""Security"",
                ""groupScope"": ""DomainLocal"",
                ""samAccountName"": ""Allowed RODC Password Replication Group"",
                ""objectSid"": ""S-1-5-21-2804467693-3687138896-2975958527-571"",
                ""externalId"": ""jI/S8DQ1qESwPIxvK+M8Kw=="",
                ""dn"": ""CN=Allowed RODC Password Replication Group,CN=Users,DC=corp,DC=okta1,DC=com"",
                ""managedBy"": null
            }";

            // Act - Deserialize as OktaActiveDirectoryGroupProfile directly
            var adProfile = Newtonsoft.Json.JsonConvert.DeserializeObject<OktaActiveDirectoryGroupProfile>(adGroupJson);

            // Assert - Verify all properties are correctly deserialized
            adProfile.Should().NotBeNull();
            adProfile.Name.Should().Be("Allowed RODC Password Replication Group");
            adProfile.Description.Should().Be("Members in this group can have their passwords replicated to all read-only domain controllers in the domain");
            adProfile.WindowsDomainQualifiedName.Should().Be("CORP\\Allowed RODC Password Replication Group");
            adProfile.GroupType.Should().Be("Security");
            adProfile.GroupScope.Should().Be("DomainLocal");
            adProfile.SamAccountName.Should().Be("Allowed RODC Password Replication Group");
            adProfile.ObjectSid.Should().Be("S-1-5-21-2804467693-3687138896-2975958527-571");
            adProfile.ExternalId.Should().Be("jI/S8DQ1qESwPIxvK+M8Kw==");
            adProfile.Dn.Should().Be("CN=Allowed RODC Password Replication Group,CN=Users,DC=corp,DC=okta1,DC=com");
            adProfile.ManagedBy.Should().BeNull();
        }

        /// <summary>
        /// Tests deserialization through the GroupProfile anyOf discriminator
        /// to ensure it correctly identifies and deserializes as OktaActiveDirectoryGroupProfile.
        /// </summary>
        [Fact]
        public void GroupProfile_ShouldDeserializeADGroupThroughAnyOfDiscriminator()
        {
            // Arrange - JSON for an AD group profile
            var adGroupProfileJson = @"{
                ""name"": ""Domain Admins"",
                ""description"": ""Designated administrators of the domain"",
                ""windowsDomainQualifiedName"": ""CORP\\Domain Admins"",
                ""groupType"": ""Security"",
                ""groupScope"": ""Global"",
                ""samAccountName"": ""Domain Admins"",
                ""objectSid"": ""S-1-5-21-123456789-987654321-1357924680-512"",
                ""externalId"": ""abc123def456=="",
                ""dn"": ""CN=Domain Admins,CN=Users,DC=corp,DC=local"",
                ""managedBy"": ""CN=IT Admin,CN=Users,DC=corp,DC=local""
            }";

            // Act - Deserialize through GroupProfile (anyOf discriminator)
            var profile = GroupProfile.FromJson(adGroupProfileJson);

            // Assert - Verify it's correctly identified as OktaActiveDirectoryGroupProfile
            profile.Should().NotBeNull();
            profile.ActualInstance.Should().BeOfType<OktaActiveDirectoryGroupProfile>();
            
            var adProfile = profile.ActualInstance as OktaActiveDirectoryGroupProfile;
            if (adProfile == null) return;
            adProfile.Should().NotBeNull();
            adProfile.Name.Should().Be("Domain Admins");
            adProfile.GroupType.Should().Be("Security");
            adProfile.GroupScope.Should().Be("Global");
            adProfile.ObjectSid.Should().Be("S-1-5-21-123456789-987654321-1357924680-512");
            adProfile.ManagedBy.Should().Be("CN=IT Admin,CN=Users,DC=corp,DC=local");
        }

        /// <summary>
        /// Tests deserialization of a complete Group object with an AD profile
        /// to ensure the entire deserialization chain works correctly.
        /// </summary>
        [Fact]
        public void Group_ShouldDeserializeWithADProfile()
        {
            // Arrange - Complete Group JSON with AD profile
            var fullGroupJson = @"{
                ""id"": ""00grwh8qvnvG8HJzV1d7"",
                ""created"": ""2025-11-17T12:54:11.000Z"",
                ""lastUpdated"": ""2025-11-17T12:54:11.000Z"",
                ""lastMembershipUpdated"": ""2025-11-17T12:54:11.000Z"",
                ""objectClass"": [""okta:windows_security_principal""],
                ""type"": ""APP_GROUP"",
                ""profile"": {
                    ""name"": ""Enterprise Admins"",
                    ""description"": ""Designated administrators of the enterprise"",
                    ""windowsDomainQualifiedName"": ""CORP\\Enterprise Admins"",
                    ""groupType"": ""Security"",
                    ""groupScope"": ""Universal"",
                    ""samAccountName"": ""Enterprise Admins"",
                    ""objectSid"": ""S-1-5-21-2804467693-3687138896-2975958527-519"",
                    ""externalId"": ""xyz789abc123=="",
                    ""dn"": ""CN=Enterprise Admins,CN=Users,DC=corp,DC=okta1,DC=com"",
                    ""managedBy"": null
                }
            }";

            // Act - Deserialize a full Group object
            var group = Newtonsoft.Json.JsonConvert.DeserializeObject<Group>(fullGroupJson);

            // Assert - Verify Group and its AD profile
            group.Should().NotBeNull();
            group.Id.Should().Be("00grwh8qvnvG8HJzV1d7");
            group.Type.Should().Be(GroupType.APPGROUP);
            group.ObjectClass.Should().Contain("okta:windows_security_principal");
            
            group.Profile.Should().NotBeNull();
            group.Profile.ActualInstance.Should().BeOfType<OktaActiveDirectoryGroupProfile>();
            
            var adProfile = group.Profile.ActualInstance as OktaActiveDirectoryGroupProfile;
            adProfile.Should().NotBeNull();
            if (adProfile != null)
            {
                adProfile.Name.Should().Be("Enterprise Admins");
                adProfile.GroupType.Should().Be("Security");
                adProfile.GroupScope.Should().Be("Universal");
                adProfile.ObjectSid.Should().Be("S-1-5-21-2804467693-3687138896-2975958527-519");
                adProfile.WindowsDomainQualifiedName.Should().Be("CORP\\Enterprise Admins");
            }
        }

        /// <summary>
        /// Tests deserialization of a complete Group object with an Okta User profile
        /// to ensure standard groups correctly deserialize as OktaUserGroupProfile.
        /// </summary>
        [Fact]
        public void Group_ShouldDeserializeWithUserProfile()
        {
            // Arrange - Complete Group JSON with standard Okta user profile
            var fullGroupJson = @"{
                ""id"": ""00g1234567890abcdef"",
                ""created"": ""2025-12-01T10:00:00.000Z"",
                ""lastUpdated"": ""2025-12-01T10:00:00.000Z"",
                ""lastMembershipUpdated"": ""2025-12-01T10:00:00.000Z"",
                ""objectClass"": [""okta:user_group""],
                ""type"": ""OKTA_GROUP"",
                ""profile"": {
                    ""name"": ""Engineering Team"",
                    ""description"": ""All engineers in the company""
                }
            }";

            // Act - Deserialize a full Group object
            var group = Newtonsoft.Json.JsonConvert.DeserializeObject<Group>(fullGroupJson);

            // Assert - Verify Group and its user profile
            group.Should().NotBeNull();
            group.Id.Should().Be("00g1234567890abcdef");
            group.Type.Should().Be(GroupType.OKTAGROUP);
            group.ObjectClass.Should().Contain("okta:user_group");
            
            group.Profile.Should().NotBeNull();
            group.Profile.ActualInstance.Should().BeOfType<OktaUserGroupProfile>(
                "Groups with objectClass 'okta:user_group' should deserialize as OktaUserGroupProfile");
            
            var userProfile = group.Profile.ActualInstance as OktaUserGroupProfile;
            userProfile.Should().NotBeNull();
            if (userProfile != null)
            {
                userProfile.Name.Should().Be("Engineering Team");
                userProfile.Description.Should().Be("All engineers in the company");
            }
        }

        /// <summary>
        /// Reproduces lewis-green's exact code pattern from Issue #812.
        /// Tests that ListGroups().ToArrayAsync() returns groups (not empty array).
        /// This was the exact code from documentation that failed in v10.0.0.
        /// </summary>
        [Fact]
        public async Task ListGroups_WithADGroups_ToArrayAsync_ShouldReturnGroups()
        {
            // Act - This is lewis-green's exact code pattern from the issue
            Group[] groups = await _groupApi.ListGroups().ToArrayAsync();

            // Assert
            groups.Should().NotBeNull("ToArrayAsync() should not return null");
            groups.Should().NotBeEmpty("ToArrayAsync() should return groups, not an empty array");
            groups.Length.Should().BeGreaterThan(0, "Should enumerate multiple groups");

            // Verify all groups have required properties
            foreach (var group in groups)
            {
                group.Id.Should().NotBeNullOrEmpty("Each group should have an ID");
                group.Profile.Should().NotBeNull("Each group should have a Profile");
                group.Profile.ActualInstance.Should().NotBeNull("Profile should deserialize to concrete type");
            }

            // Verify AD groups (if present) are included and deserialize correctly
            var adGroups = groups.Where(g => 
                g.ObjectClass != null && 
                g.ObjectClass.Contains("okta:windows_security_principal")).ToList();
            
            // If there are AD groups, verify they deserialize correctly
            if (adGroups.Any())
            {
                foreach (var adGroup in adGroups)
                {
                    adGroup.Profile.Should().NotBeNull();
                    adGroup.Profile.ActualInstance.Should().BeOfType<OktaActiveDirectoryGroupProfile>(
                        because: "AD groups should deserialize as OktaActiveDirectoryGroupProfile");

                    var adProfile = adGroup.Profile.ActualInstance as OktaActiveDirectoryGroupProfile;
                    adProfile?.Name.Should().NotBeNullOrEmpty("AD group should have a name");
                    
                    // Verify the 4 properties that were missing exist on the model
                    var properties = typeof(OktaActiveDirectoryGroupProfile).GetProperties();
                    properties.Should().Contain(p => p.Name == "GroupType");
                    properties.Should().Contain(p => p.Name == "GroupScope");
                    properties.Should().Contain(p => p.Name == "ObjectSid");
                    properties.Should().Contain(p => p.Name == "ManagedBy");
                }
            }
        }

        /// <summary>
        /// Reproduces lewis-green's exact loop pattern without ConfigureAwait.
        /// Tests that enumeration works without ConfigureAwait (which was in the doc example).
        /// </summary>
        [Fact]
        public async Task ListGroups_WithADGroups_WithoutConfigureAwait_ShouldEnumerate()
        {
            // Act - Enumerate WITHOUT ConfigureAwait (lewis-green's exact pattern)
            var groupIds = new List<string>();
            await foreach (var group in _groupApi.ListGroups())
            {
                groupIds.Add(group.Id);
            }

            // Assert
            groupIds.Should().NotBeEmpty("Should enumerate groups without ConfigureAwait");
            groupIds.Should().HaveCountGreaterThan(0, "Should find multiple groups");
            groupIds.Should().OnlyContain(id => !string.IsNullOrEmpty(id), "All group IDs should be valid");
        }

        /// <summary>
        /// Reproduces PaskeS's workaround from Issue #812.
        /// Tests that manually deserializing RawContent with JsonConvert work.
        /// This verifies the JSON structure is correct and can be deserialized.
        /// </summary>
        [Fact]
        public async Task ListGroups_RawContentDeserialization_ShouldWork()
        {
            // Act - PaskeS's workaround: get raw content and manually deserialize
            var groupResponse = await _groupApi.ListGroupsWithHttpInfoAsync();
            groupResponse.Should().NotBeNull();
            groupResponse.RawContent.Should().NotBeNullOrEmpty("Should have raw JSON content");

            // This is what PaskeS tried that should now work with our fix
            List<Group> groups = null;
            Exception deserializationException = null;
            
            try
            {
                groups = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Group>>(groupResponse.RawContent);
            }
            catch (Exception ex)
            {
                deserializationException = ex;
            }

            // Assert
            deserializationException.Should().BeNull(
                "Manual deserialization with JsonConvert should not throw 'cannot be deserialized into any schema defined' error");
            groups.Should().NotBeNull("Deserialization should produce a list");
            groups.Should().NotBeEmpty("Deserialized list should contain groups");

            // Verify all groups have required properties
            if (groups != null)
            {
                foreach (var group in groups)
                {
                    group.Id.Should().NotBeNullOrEmpty("Each group should have an ID");
                    group.Profile.Should().NotBeNull("Each group should have a profile");
                    group.Profile.ActualInstance.Should().NotBeNull("Profile should deserialize to concrete type");
                }

                // Verify AD groups (if present) deserialized correctly
                var adGroups = groups.Where(g =>
                    g.ObjectClass != null &&
                    g.ObjectClass.Contains("okta:windows_security_principal")).ToList();

                // If there are AD groups, verify they deserialize correctly
                if (adGroups.Any())
                {
                    foreach (var adGroup in adGroups)
                    {
                        adGroup.Profile.Should().NotBeNull("AD group should have a profile");
                        adGroup.Profile.ActualInstance.Should().BeOfType<OktaActiveDirectoryGroupProfile>(
                            "AD group profile should be OktaActiveDirectoryGroupProfile, not fail with 'cannot be deserialized into any schema'");

                        var adProfile = adGroup.Profile.ActualInstance as OktaActiveDirectoryGroupProfile;
                        adProfile?.Name.Should().NotBeNullOrEmpty("AD group should have a name");

                        // Verify the 4 problematic properties exist on the model
                        // (they were missing and caused the "cannot be deserialized into any schema" error)
                        var properties = typeof(OktaActiveDirectoryGroupProfile).GetProperties();
                        properties.Should().Contain(p => p.Name == "GroupType",
                            "GroupType property should exist to prevent deserialization errors");
                        properties.Should().Contain(p => p.Name == "GroupScope",
                            "GroupScope property should exist to prevent deserialization errors");
                        properties.Should().Contain(p => p.Name == "ObjectSid",
                            "ObjectSid property should exist to prevent deserialization errors");
                        properties.Should().Contain(p => p.Name == "ManagedBy",
                            "ManagedBy property should exist to prevent deserialization errors");
                    }
                }
            }
        }

        /// <summary>
        /// Tests Issue #814: JSON parsing errors should be propagated to API caller
        /// Before the fix for Issue #812, JSON parsing errors during enumeration were silently
        /// suppressed, returning empty collections instead of throwing exceptions.
        /// This test verifies that deserialization now works correctly and doesn't silently fail.
        /// </summary>
        [Fact]
        public async Task ListGroups_WithDeserializationIssues_ShouldNotReturnEmptyCollection()
        {
            // Arrange - This test verifies that the fix for Issue #812 also resolves Issue #814
            // Issue #814: JSON parsing errors were not propagated, resulting in empty collections
            // Issue #812: OktaActiveDirectoryGroupProfile was missing 4 properties causing deserialization to fail
            
            // Act - Try to list groups (should not return empty collection due to silent errors)
            var groups = new List<Group>();
            Exception enumerationException = null;

            try
            {
                await foreach (var group in _groupApi.ListGroups())
                {
                    groups.Add(group);
                    
                    // Verify each group's profile can be accessed (no silent deserialization failures)
                    group.Profile.Should().NotBeNull("Profile should deserialize successfully");
                    group.Profile.ActualInstance.Should().NotBeNull("Profile should deserialize to concrete type");
                }
            }
            catch (ApiException)
            {
                // If there's a legitimate API error, that's expected and should be thrown
                throw;
            }
            catch (Exception ex)
            {
                // Any other exception is unexpected
                enumerationException = ex;
            }

            // Assert - Issue #814: Errors should be propagated, not silently suppressed
            if (enumerationException != null && !(enumerationException is ApiException))
            {
                // If there's a non-API exception, it means deserialization failed
                // This should NOT happen with the fix - it should either succeed or throw ApiException
                enumerationException.Should().BeNull(
                    $"Unexpected exception during enumeration (Issue #814): {enumerationException.Message}");
            }

            // Groups should be returned (not an empty collection due to silent errors)
            groups.Should().NotBeEmpty(
                "ListGroups() should return groups, not an empty collection due to silent deserialization errors (Issue #814)");

            // Verify all groups deserialized successfully
            foreach (var group in groups)
            {
                group.Id.Should().NotBeNullOrEmpty("Each group should have an ID");
                group.Profile.Should().NotBeNull("Each group's profile should deserialize");
                group.Profile.ActualInstance.Should().NotBeNull(
                    "Profile should deserialize to concrete type, not fail silently (Issue #814)");

                // Verify a profile type is one of the expected types
                var isUserGroup = group.Profile.ActualInstance is OktaUserGroupProfile;
                var isAdGroup = group.Profile.ActualInstance is OktaActiveDirectoryGroupProfile;

                (isUserGroup || isAdGroup).Should().BeTrue(
                    "Group profile should deserialize to a known type without silent failures");

                // For AD groups, verify they have the properties that were causing silent failures
                if (isAdGroup)
                {
                    var adProfile = group.Profile.ActualInstance as OktaActiveDirectoryGroupProfile;
                    adProfile.Should().NotBeNull();
                    
                    // These properties were missing and caused silent deserialization failures
                    // Now they should be accessible (even if null)
                    var _ = adProfile?.GroupType;    // Should not throw
                    var __ = adProfile?.GroupScope;  // Should not throw
                    var ___ = adProfile?.ObjectSid;  // Should not throw
                    var ____ = adProfile?.ManagedBy; // Should not throw
                }
            }
        }

        /// <summary>
        /// Tests Issue #814: Verifies that List methods across all APIs properly propagate errors
        /// This test specifically checks ListGroups with WithHttpInfoAsync to ensure
        /// deserialization errors are not suppressed at the HTTP response level.
        /// </summary>
        [Fact]
        public async Task ListGroupsWithHttpInfo_ShouldNotSuppressDeserializationErrors()
        {
            // Arrange & Act
            var httpInfoResponse = await _groupApi.ListGroupsWithHttpInfoAsync();

            // Assert - HTTP response should be successful
            httpInfoResponse.Should().NotBeNull();
            httpInfoResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            httpInfoResponse.RawContent.Should().NotBeNullOrEmpty("Raw content should be present");

            // Data should be deserialized without silent failures
            httpInfoResponse.Data.Should().NotBeNull("Response data should deserialize");
            httpInfoResponse.Data.Should().NotBeEmpty(
                "If deserialization succeeded, data should not be empty (unless org truly has no groups)");

            // Verify each group in the response deserialized correctly
            foreach (var group in httpInfoResponse.Data)
            {
                group.Should().NotBeNull("Each group should deserialize");
                group.Id.Should().NotBeNullOrEmpty("Each group should have an ID");
                group.Profile.Should().NotBeNull(
                    "Each group's profile should deserialize, not fail silently (Issue #814)");
                group.Profile.ActualInstance.Should().NotBeNull(
                    "Profile should deserialize to concrete type without silent failures");
            }

            // Specifically, check for AD groups that were causing silent failures before the fix
            var adGroups = httpInfoResponse.Data.Where(g =>
                g.ObjectClass != null &&
                g.ObjectClass.Contains("okta:windows_security_principal")).ToList();

            if (adGroups.Any())
            {
                foreach (var adGroup in adGroups)
                {
                    // Before fix: These would cause silent deserialization failure → empty collection
                    // After fix: These should deserialize successfully
                    adGroup.Profile.ActualInstance.Should().BeOfType<OktaActiveDirectoryGroupProfile>(
                        "AD groups should deserialize successfully, not fail silently (Issue #814 root cause from Issue #812)");
                }
            }
        }

        /// <summary>
        /// Tests Issue #814: Verifies collection enumeration doesn't return an empty collection on deserialization errors
        /// This test validates that the IOktaCollectionClient properly propagates exceptions.
        /// </summary>
        [Fact]
        public async Task CollectionEnumeration_WithValidData_ShouldNotReturnEmptyCollectionDueToSilentErrors()
        {
            // Arrange
            var collectionClient = _groupApi.ListGroups();
            var enumeratedGroups = new List<Group>();

            // Act - Enumerate using the collection client
            await foreach (var group in collectionClient)
            {
                enumeratedGroups.Add(group);
            }

            // Assert - Issue #814: Should not return empty collection due to silent deserialization errors
            enumeratedGroups.Should().NotBeEmpty(
                "Collection enumeration should return items, not empty collection from silent errors (Issue #814)");

            // Verify all enumerated items are valid (no partial deserialization failures)
            foreach (var group in enumeratedGroups)
            {
                group.Should().NotBeNull("Each enumerated group should be valid");
                group.Id.Should().NotBeNullOrEmpty("Each group should have an ID");
                group.Profile.Should().NotBeNull("Each group should have a profile");
                group.Profile.ActualInstance.Should().NotBeNull(
                    "Profile should fully deserialize, not partially fail (Issue #814)");
            }

            // Verify we can convert to array without silent failures
            var arrayResult = await _groupApi.ListGroups().ToArrayAsync();
            arrayResult.Should().NotBeEmpty("ToArrayAsync should return items, not empty array from silent errors");
            arrayResult.Length.Should().Be(enumeratedGroups.Count, 
                "ToArrayAsync should return same count as enumeration");
        }

        /// <summary>
        /// Verifies that group profiles expose AdditionalProperties for custom schema attributes.
        /// 
        /// Group profiles should have an additional dictionary to access custom attributes
        /// that are defined in the group schema but not part of the standard profile properties.
        /// 
        /// USAGE EXAMPLE for custom group schema attributes:
        /// 
        /// // If your Okta org has custom group schema attributes (e.g., "alias", "department"):
        /// var group = await groupApi.GetGroupAsync(groupId);
        /// var profile = group.Profile.ActualInstance as OktaUserGroupProfile;
        /// 
        /// // Check if custom attributes exist
        /// if (profile?.AdditionalProperties != null && 
        ///     profile.AdditionalProperties.ContainsKey("alias"))
        /// {
        ///     var aliasValue = profile.AdditionalProperties["alias"];
        ///     Console.WriteLine($"Group alias: {aliasValue}");
        /// }
        /// 
        /// NOTE: AdditionalProperties is NULL if the API response contains only standard properties.
        /// It will be populated automatically by [JsonExtensionData] when custom attributes exist in the JSON.
        /// 
        /// Related: https://github.com/okta/okta-sdk-dotnet/issues/815
        /// </summary>
        [Fact]
        public async Task GroupProfile_Should_Expose_AdditionalProperties_For_Custom_Attributes()
        {
            // Arrange - Create a group
            var groupName = $"Test Group AdditionalProperties {Guid.NewGuid()}";
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = groupName,
                    Description = "Test to verify AdditionalProperties dictionary exists"
                }
            };

            Group createdGroup = null;

            try
            {
                // Act - Create and retrieve a group
                createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
                var response = await _groupApi.GetGroupWithHttpInfoAsync(createdGroup.Id);

                // Assert
                response.Should().NotBeNull();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Data.Should().NotBeNull("Response should contain group data");

                var group = response.Data;
                group.Profile.Should().NotBeNull("Group should have a profile");
                
                var profileInstance = group.Profile.ActualInstance;
                profileInstance.Should().NotBeNull("Profile should have an actual instance");
                
                // Both OktaUserGroupProfile AND OktaActiveDirectoryGroupProfile should have AdditionalProperties
                if (profileInstance is OktaUserGroupProfile oktaUserProfile)
                {
                    // Verify basic properties still work
                    oktaUserProfile.Name.Should().Be(groupName);
                    oktaUserProfile.Description.Should().Be("Test to verify AdditionalProperties dictionary exists");

                    // Verify AdditionalProperties property exists using reflection
                    // NOTE: AdditionalProperties may be NULL if there are no custom attributes in the JSON response
                    // This is expected behavior with [JsonExtensionData] - it only populates when unmapped properties exist
                    var type = oktaUserProfile.GetType();
                    var additionalPropertiesProperty = type.GetProperty("AdditionalProperties");
                    
                    additionalPropertiesProperty.Should().NotBeNull(
                        "OktaUserGroupProfile should have AdditionalProperties property for custom group attributes");

                    // Verify the property has the [JsonExtensionData] attribute
                    var jsonExtensionDataAttr = additionalPropertiesProperty?.GetCustomAttributes(typeof(Newtonsoft.Json.JsonExtensionDataAttribute), false);
                    jsonExtensionDataAttr.Should().NotBeEmpty(
                        "AdditionalProperties should have [JsonExtensionData] attribute to capture custom fields");
                }
                else if (profileInstance is OktaActiveDirectoryGroupProfile adProfile)
                {
                    // OktaActiveDirectoryGroupProfile also needs AdditionalProperties
                    // to Verify basic properties still work
                    adProfile.Name.Should().Be(groupName);
                    adProfile.Description.Should().Be("Test to verify AdditionalProperties dictionary exists");

                    // Verify AdditionalProperties property exists using reflection
                    var type = adProfile.GetType();
                    var additionalPropertiesProperty = type.GetProperty("AdditionalProperties");
                    
                    additionalPropertiesProperty.Should().NotBeNull(
                        "OktaActiveDirectoryGroupProfile should have AdditionalProperties property for custom group attributes");

                    // Verify the property is of the correct type
                    additionalPropertiesProperty?.PropertyType.Should().BeAssignableTo<IDictionary<string, object>>(
                        "AdditionalProperties should be IDictionary<string, object>");

                    // NOTE: AdditionalProperties may be NULL if there are no custom attributes in the JSON response
                    // This is expected behavior with [JsonExtensionData] - it only populates when unmapped properties exist
                    // The important fix is that the PROPERTY EXISTS and has the correct attribute
                    var jsonExtensionDataAttr = additionalPropertiesProperty?.GetCustomAttributes(typeof(Newtonsoft.Json.JsonExtensionDataAttribute), false);
                    jsonExtensionDataAttr.Should().NotBeEmpty(
                        "AdditionalProperties should have [JsonExtensionData] attribute to capture custom fields");
                }
                else
                {
                    // Log what we actually got
                    throw new Exception($"Unexpected profile type: {profileInstance.GetType().Name}");
                }
            }
            finally
            {
                // Cleanup
                if (createdGroup != null)
                {
                    await _groupApi.DeleteGroupAsync(createdGroup.Id);
                }
            }
        }

        /// <summary>
        /// Verifies that group profile types have the AdditionalProperties property with correct attributes.
        /// 
        /// Both OktaUserGroupProfile and OktaActiveDirectoryGroupProfile should have an AdditionalProperties
        /// property decorated with [JsonExtensionData] to capture custom profile attributes that are not
        /// part of the standard schema.
        /// 
        /// This ensures custom group schema attributes can be accessed at runtime via the AdditionalProperties
        /// dictionary, maintaining compatibility with custom group profile extensions.
        /// 
        /// Related: https://github.com/okta/okta-sdk-dotnet/issues/815
        /// </summary>
        [Fact]
        public async Task GroupProfile_Should_Have_JsonExtensionData_Attribute_On_AdditionalProperties()
        {
            // Arrange - Create a group
            var groupName = $"Test Group JsonExtensionData {Guid.NewGuid()}";
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = groupName,
                    Description = "Test group to verify JsonExtensionData attribute on AdditionalProperties"
                }
            };

            Group createdGroup = null;

            try
            {
                // Act
                createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
                var retrievedGroup = await _groupApi.GetGroupAsync(createdGroup.Id);

                // Assert
                retrievedGroup.Should().NotBeNull("Group should be retrieved successfully");
                var profileInstance = retrievedGroup.Profile.ActualInstance;
                profileInstance.Should().NotBeNull("Profile should have an actual instance");

                // Both OktaUserGroupProfile AND OktaActiveDirectoryGroupProfile should have AdditionalProperties
                if (profileInstance is OktaUserGroupProfile oktaUserProfile)
                {
                    // Verify basic properties work
                    oktaUserProfile.Name.Should().Be(groupName);
                    oktaUserProfile.Description.Should().Be("Test group to verify JsonExtensionData attribute on AdditionalProperties");

                    // Verify AdditionalProperties property exists
                    var type = oktaUserProfile.GetType();
                    var additionalPropertiesProperty = type.GetProperty("AdditionalProperties");
                    
                    additionalPropertiesProperty.Should().NotBeNull(
                        "OktaUserGroupProfile should have AdditionalProperties property for custom group attributes");

                    // Verify the property is of the correct type
                    additionalPropertiesProperty?.PropertyType.Should().BeAssignableTo<IDictionary<string, object>>(
                        "AdditionalProperties should be IDictionary<string, object>");

                    // Verify the property has the [JsonExtensionData] attribute
                    var jsonExtensionDataAttr = additionalPropertiesProperty?.GetCustomAttributes(typeof(Newtonsoft.Json.JsonExtensionDataAttribute), false);
                    jsonExtensionDataAttr.Should().NotBeEmpty(
                        "AdditionalProperties should have [JsonExtensionData] attribute to capture custom fields");

                    // NOTE: AdditionalProperties may be NULL if there are no custom attributes in the JSON response
                    // This is expected behavior with [JsonExtensionData] - it only populates when unmapped properties exist
                    // If custom attributes were added to the group schema and set on this group, they would appear here
                }
                else if (profileInstance is OktaActiveDirectoryGroupProfile adProfile)
                {
                    // OktaActiveDirectoryGroupProfile also needs AdditionalProperties
                    // to Verify basic properties work
                    adProfile.Name.Should().Be(groupName);
                    adProfile.Description.Should().Be("Test group to verify JsonExtensionData attribute on AdditionalProperties");

                    // Verify AdditionalProperties property exists
                    var type = adProfile.GetType();
                    var additionalPropertiesProperty = type.GetProperty("AdditionalProperties");
                    
                    additionalPropertiesProperty.Should().NotBeNull(
                        "OktaActiveDirectoryGroupProfile should have AdditionalProperties property for custom group attributes");

                    // Verify the property is of the correct type
                    additionalPropertiesProperty?.PropertyType.Should().BeAssignableTo<IDictionary<string, object>>(
                        "AdditionalProperties should be IDictionary<string, object>");

                    // Verify the property has the [JsonExtensionData] attribute
                    var jsonExtensionDataAttr = additionalPropertiesProperty?.GetCustomAttributes(typeof(Newtonsoft.Json.JsonExtensionDataAttribute), false);
                    jsonExtensionDataAttr.Should().NotBeEmpty(
                        "AdditionalProperties should have [JsonExtensionData] attribute to capture custom fields");

                    // NOTE: AdditionalProperties may be NULL if there are no custom attributes in the JSON response
                    // This is expected behavior with [JsonExtensionData] - it only populates when unmapped properties exist
                }
                else
                {
                    throw new Exception($"Unexpected profile type: {profileInstance.GetType().Name}");
                }
            }
            finally
            {
                // Cleanup
                if (createdGroup != null)
                {
                    await _groupApi.DeleteGroupAsync(createdGroup.Id);
                }
            }
        }

        /// <summary>
        /// Verifies that group profiles support dynamic property access through AdditionalProperties.
        /// 
        /// This test ensures that both OktaUserGroupProfile and OktaActiveDirectoryGroupProfile have
        /// the necessary infrastructure to support custom schema attributes:
        /// - AdditionalProperties property of type IDictionary&lt;string, object&gt;
        /// - [JsonExtensionData] attribute for automatic deserialization of unmapped JSON properties
        /// 
        /// Expected behavior with [JsonExtensionData]:
        /// - If JSON contains ONLY known properties (name, description, etc.), AdditionalProperties will be NULL
        /// - If JSON contains ANY unknown/custom properties, AdditionalProperties will be populated automatically
        /// - Custom attributes are accessible via: profile.AdditionalProperties["customAttribute"]
        /// 
        /// This enables organizations to extend group profiles with custom attributes while maintaining
        /// backward compatibility with the standard schema.
        /// 
        /// Related: https://github.com/okta/okta-sdk-dotnet/issues/815
        /// </summary>
        [Fact]
        public async Task GroupProfile_Should_Support_Dynamic_Property_Access_Through_AdditionalProperties()
        {
            // Arrange
            var groupName = $"Test Group AdditionalProperties {Guid.NewGuid()}";
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = groupName,
                    Description = "Test group to verify AdditionalProperties support"
                }
            };

            Group createdGroup = null;

            try
            {
                // Act
                createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
                var retrievedGroup = await _groupApi.GetGroupAsync(createdGroup.Id);

                // Assert - Verify basic functionality works
                retrievedGroup.Should().NotBeNull();
                retrievedGroup.Id.Should().NotBeNullOrEmpty();
                
                var profileInstance = retrievedGroup.Profile.ActualInstance;
                
                // Both OktaUserGroupProfile AND OktaActiveDirectoryGroupProfile should have AdditionalProperties
                if (profileInstance is OktaUserGroupProfile oktaProfile)
                {
                    oktaProfile.Name.Should().Be(groupName);

                    // .NET SDK Implementation:
                    // File: src/Okta.Sdk/Model/OktaUserGroupProfile.cs
                    // - Standard properties: Description, Name
                    // - AdditionalProperties: IDictionary<string, object> with [JsonExtensionData] attribute
                    //
                    // The [JsonExtensionData] attribute enables automatic capture of custom schema attributes
                    // during JSON deserialization. Any properties not mapped to known fields are stored in
                    // AdditionalProperties dictionary and can be accessed via profile.AdditionalProperties["customField"].
                    //
                    // Fix Applied:
                    // - File: openapi3/management.yaml (OktaUserGroupProfile)
                    // - Added: additionalProperties: true
                    // - Result: SDK now generates AdditionalProperties with [JsonExtensionData] attribute

                    // Verify the fix - check property exists and has the correct attribute
                    var type = oktaProfile.GetType();
                    var additionalPropertiesProperty = type.GetProperty("AdditionalProperties");
                    
                    additionalPropertiesProperty.Should().NotBeNull(
                        "OktaUserGroupProfile should have AdditionalProperties property for custom attributes");
                    
                    var jsonExtensionDataAttr = additionalPropertiesProperty?.GetCustomAttributes(typeof(Newtonsoft.Json.JsonExtensionDataAttribute), false);
                    jsonExtensionDataAttr.Should().NotBeEmpty(
                        "AdditionalProperties should have [JsonExtensionData] attribute for automatic deserialization");
                }
                else if (profileInstance is OktaActiveDirectoryGroupProfile adProfile)
                {
                    // AD groups also need AdditionalProperties
                    adProfile.Name.Should().Be(groupName);
                    
                    // Verify AD profile has the same support - check property exists and has the correct attribute
                    var type = adProfile.GetType();
                    var additionalPropertiesProperty = type.GetProperty("AdditionalProperties");
                    
                    additionalPropertiesProperty.Should().NotBeNull(
                        "OktaActiveDirectoryGroupProfile should have AdditionalProperties property for custom attributes");
                    
                    var jsonExtensionDataAttr = additionalPropertiesProperty?.GetCustomAttributes(typeof(Newtonsoft.Json.JsonExtensionDataAttribute), false);
                    jsonExtensionDataAttr.Should().NotBeEmpty(
                        "AdditionalProperties should have [JsonExtensionData] attribute for automatic deserialization");
                }
                else
                {
                    throw new Exception($"Unexpected profile type: {profileInstance.GetType().Name}");
                }
            }
            finally
            {
                // Cleanup
                if (createdGroup != null)
                {
                    await _groupApi.DeleteGroupAsync(createdGroup.Id);
                }
            }
        }

        /// <summary>
        /// Diagnostic test to verify both OktaUserGroupProfile and OktaActiveDirectoryGroupProfile
        /// are correctly identified based on the objectClass discriminator when fetching live groups.
        /// </summary>
        [Fact]
        public async Task ListGroups_ShouldCorrectlyIdentifyProfileTypesBasedOnObjectClass()
        {
            // Act - Fetch groups from the live Okta org
            int userGroupCount = 0;
            int adGroupCount = 0;
            var groups = new List<Group>();

            await foreach (var group in _groupApi.ListGroups(limit: 20))
            {
                groups.Add(group);
                
                // Verify each group has required properties
                group.Id.Should().NotBeNullOrEmpty();
                group.Profile.Should().NotBeNull();
                group.Profile.ActualInstance.Should().NotBeNull();
                group.ObjectClass.Should().NotBeNullOrEmpty();

                if (group.Profile.ActualInstance is OktaUserGroupProfile userProfile)
                {
                    userGroupCount++;
                    // Verify objectClass matches
                    group.ObjectClass.Should().Contain("okta:user_group",
                        "OktaUserGroupProfile should have 'okta:user_group' in objectClass");
                    userProfile.Name.Should().NotBeNullOrEmpty();
                }
                else if (group.Profile.ActualInstance is OktaActiveDirectoryGroupProfile adProfile)
                {
                    adGroupCount++;
                    // Verify objectClass matches
                    group.ObjectClass.Should().Contain("okta:windows_security_principal",
                        "OktaActiveDirectoryGroupProfile should have 'okta:windows_security_principal' in objectClass");
                    adProfile.Name.Should().NotBeNullOrEmpty();
                }
            }

            // Assert - Should have fetched some groups
            groups.Should().NotBeEmpty("Should fetch at least some groups from the org");
            (userGroupCount + adGroupCount).Should().Be(groups.Count,
                "All groups should be either OktaUserGroupProfile or OktaActiveDirectoryGroupProfile");
        }
    }
}
