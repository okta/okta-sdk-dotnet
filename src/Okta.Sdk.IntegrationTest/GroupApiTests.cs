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

            // ListGroups with search parameter
            await Task.Delay(2000); // Wait for indexing

            var searchQuery = $"profile.name eq \"{testGroupName}\"";
            var searchResults = await _groupApi.ListGroups(search: searchQuery).ToListAsync();

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

            // ListGroups with limit parameter
            var limitedGroups = await _groupApi.ListGroups(limit: 5).ToListAsync();

            limitedGroups.Should().NotBeNull();
            limitedGroups.Count.Should().BeLessOrEqualTo(5);

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
            firstPageResponse.Data.Should().HaveCountLessOrEqualTo(2);

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

            // ListGroupUsers - Verify multiple users
            var usersAfterSecondAssign = await _groupApi.ListGroupUsers(groupId).ToListAsync();

            usersAfterSecondAssign.Should().HaveCountGreaterOrEqualTo(2);
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
            firstUserPageResponse.Data.Should().HaveCountLessOrEqualTo(1);

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

            var finalUsers = await _groupApi.ListGroupUsers(groupId).ToListAsync();
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
    }
}
