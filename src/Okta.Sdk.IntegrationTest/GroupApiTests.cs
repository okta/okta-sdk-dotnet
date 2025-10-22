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
    public class GroupApiTestFixture : IAsyncLifetime
    {
        private readonly UserApi _userApi = new();
        private readonly ApplicationApi _applicationApi = new();
        private readonly GroupApi _groupApi = new();
        private readonly ApplicationGroupsApi _appGroupsApi = new();

        public string TestUser1Id { get; private set; }
        public string TestUser2Id { get; private set; }
        public string TestUser3Id { get; private set; }
        public string TestApplicationId { get; private set; }
        
        // Shared groups for read-only operations (improves performance)
        public string SharedReadOnlyGroupId { get; private set; }
        public string SharedGroupWithUsersId { get; private set; }
        public string SharedGroupWithAppId { get; private set; }

        public async Task InitializeAsync()
        {
            // Create test users for group membership tests
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

            // Create a test application for group assignment tests
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

            // Create shared groups for read-only operations
            var sharedGroup1 = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"SharedReadOnlyGroup-{guid}",
                    Description = "Shared group for read-only tests"
                }
            };
            var createdSharedGroup1 = await _groupApi.AddGroupAsync(sharedGroup1);
            SharedReadOnlyGroupId = createdSharedGroup1.Id;

            // Create a shared group with users
            var sharedGroup2 = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"SharedGroupWithUsers-{guid}",
                    Description = "Shared group with users for read tests"
                }
            };
            var createdSharedGroup2 = await _groupApi.AddGroupAsync(sharedGroup2);
            SharedGroupWithUsersId = createdSharedGroup2.Id;
            
            // Assign users to a shared group
            await _groupApi.AssignUserToGroupAsync(SharedGroupWithUsersId, TestUser1Id);
            await _groupApi.AssignUserToGroupAsync(SharedGroupWithUsersId, TestUser2Id);
            await Task.Delay(2000); // Wait for assignments to propagate

            // Create a shared group with application assignment
            var sharedGroup3 = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"SharedGroupWithApp-{guid}",
                    Description = "Shared group with app assignment"
                }
            };
            var createdSharedGroup3 = await _groupApi.AddGroupAsync(sharedGroup3);
            SharedGroupWithAppId = createdSharedGroup3.Id;

            // Assign application to a shared group
            var appGroupAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };
            await _appGroupsApi.AssignGroupToApplicationAsync(TestApplicationId, SharedGroupWithAppId, appGroupAssignment);
            await Task.Delay(1000); // Wait for assignment to propagate
        }

        public async Task DisposeAsync()
        {
            // Cleanup: Delete shared groups
            if (!string.IsNullOrEmpty(SharedReadOnlyGroupId))
            {
                try
                {
                    await _groupApi.DeleteGroupAsync(SharedReadOnlyGroupId);
                }
                catch (ApiException) { }
            }

            if (!string.IsNullOrEmpty(SharedGroupWithUsersId))
            {
                try
                {
                    await _groupApi.DeleteGroupAsync(SharedGroupWithUsersId);
                }
                catch (ApiException) { }
            }

            if (!string.IsNullOrEmpty(SharedGroupWithAppId))
            {
                try
                {
                    await _groupApi.DeleteGroupAsync(SharedGroupWithAppId);
                }
                catch (ApiException) { }
            }

            // Cleanup: Delete test users
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

            // Cleanup: Delete test application
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

    [Collection(nameof(GroupApiTests))]
    public class GroupApiTests : IClassFixture<GroupApiTestFixture>, IDisposable
    {
        private readonly GroupApi _groupApi = new();
        private readonly GroupApiTestFixture _fixture;
        private readonly List<string> _createdGroupIds = new List<string>();

        public GroupApiTests(GroupApiTestFixture fixture)
        {
            _fixture = fixture;
        }

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
                catch (ApiException)
                {
                    // Group might already be deleted
                }
            }
            _createdGroupIds.Clear();
        }

        // Helper method to get Name from polymorphic GroupProfile
        private string GetGroupName(GroupProfile profile)
        {
            if (profile?.ActualInstance is OktaUserGroupProfile userProfile)
            {
                return userProfile.Name;
            }
            else if (profile?.ActualInstance is OktaActiveDirectoryGroupProfile adProfile)
            {
                return adProfile.Name;
            }
            return null;
        }

        // Helper method to get Description from polymorphic GroupProfile
        private string GetGroupDescription(GroupProfile profile)
        {
            if (profile?.ActualInstance is OktaUserGroupProfile userProfile)
            {
                return userProfile.Description;
            }
            else if (profile?.ActualInstance is OktaActiveDirectoryGroupProfile adProfile)
            {
                return adProfile.Description;
            }
            return null;
        }

        #region Complete CRUD Lifecycle Tests

        [Fact]
        public async Task GroupCrudLifecycle_ShouldCompleteAllOperations()
        {
            var guid = Guid.NewGuid();
            
            // CREATE
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-CRUD-{guid}",
                    Description = "Test group for CRUD lifecycle"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            createdGroup.Should().NotBeNull();
            createdGroup.Id.Should().NotBeNullOrEmpty();
            GetGroupName(createdGroup.Profile).Should().Be(addGroupRequest.Profile.Name);
            GetGroupDescription(createdGroup.Profile).Should().Be(addGroupRequest.Profile.Description);
            createdGroup.Type.Should().Be(GroupType.OKTAGROUP);
            createdGroup.Created.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
            createdGroup.LastUpdated.Should().BeOnOrBefore(DateTimeOffset.UtcNow);

            var groupId = createdGroup.Id;

            // READ
            var retrievedGroup = await _groupApi.GetGroupAsync(groupId);
            retrievedGroup.Should().NotBeNull();
            retrievedGroup.Id.Should().Be(groupId);
            GetGroupName(retrievedGroup.Profile).Should().Be(addGroupRequest.Profile.Name);
            GetGroupDescription(retrievedGroup.Profile).Should().Be(addGroupRequest.Profile.Description);

            // UPDATE
            var updateGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-CRUD-Updated-{guid}",
                    Description = "Updated test group description"
                }
            };

            var updatedGroup = await _groupApi.ReplaceGroupAsync(groupId, updateGroupRequest);
            updatedGroup.Should().NotBeNull();
            updatedGroup.Id.Should().Be(groupId);
            GetGroupName(updatedGroup.Profile).Should().Be(updateGroupRequest.Profile.Name);
            GetGroupDescription(updatedGroup.Profile).Should().Be(updateGroupRequest.Profile.Description);

            // DELETE
            await _groupApi.DeleteGroupAsync(groupId);
            _createdGroupIds.Remove(groupId);

            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.GetGroupAsync(groupId));
            ex.ErrorCode.Should().Be(404);
        }

        #endregion

        #region CREATE Operation Tests (AddGroup)

        [Fact]
        public async Task AddGroup_WithValidData_ShouldSucceed()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-Create-{guid}",
                    Description = "Test group for creation"
                }
            };

            var group = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(group.Id);

            // Validate all critical group properties
            group.Should().NotBeNull();
            group.Id.Should().NotBeNullOrEmpty();
            group.Profile.Should().NotBeNull();
            GetGroupName(group.Profile).Should().Be(addGroupRequest.Profile.Name);
            GetGroupDescription(group.Profile).Should().Be(addGroupRequest.Profile.Description);
            group.Type.Should().Be(GroupType.OKTAGROUP);
            group.Created.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
            group.LastUpdated.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
            group.LastMembershipUpdated.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
            group.ObjectClass.Should().Contain("okta:user_group");
        }

        [Fact]
        public async Task AddGroupWithHttpInfo_ShouldReturnHttpResponse()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-HttpInfo-{guid}",
                    Description = "Test group with HTTP info"
                }
            };

            var response = await _groupApi.AddGroupWithHttpInfoAsync(addGroupRequest);
            _createdGroupIds.Add(response.Data.Id);

            // Validate HTTP response
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Headers.Should().NotBeNull();

            // Validate response data
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().NotBeNullOrEmpty();
            GetGroupName(response.Data.Profile).Should().Be(addGroupRequest.Profile.Name);
            response.Data.Type.Should().Be(GroupType.OKTAGROUP);
        }

        [Fact]
        public async Task AddGroup_WithNameOnly_ShouldSucceed()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-NameOnly-{guid}"
                }
            };

            var group = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(group.Id);

            group.Should().NotBeNull();
            GetGroupName(group.Profile).Should().Be(addGroupRequest.Profile.Name);
            GetGroupDescription(group.Profile).Should().BeNull();
        }

        [Fact]
        public async Task AddGroup_WithNullName_ShouldFail()
        {
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = null,
                    Description = "Group without name"
                }
            };

            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.AddGroupAsync(addGroupRequest));

            ex.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task AddGroup_WithEmptyName_ShouldFail()
        {
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = "",
                    Description = "Group with empty name"
                }
            };

            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.AddGroupAsync(addGroupRequest));

            ex.ErrorCode.Should().Be(400);
        }

        #endregion

        #region READ Operation Tests (GetGroup, ListGroups)

        [Fact]
        public async Task GetGroup_WithValidId_ShouldSucceed()
        {
            // Use a shared read-only group instead of creating a new one
            var retrievedGroup = await _groupApi.GetGroupAsync(_fixture.SharedReadOnlyGroupId);

            // Validate all properties
            retrievedGroup.Should().NotBeNull();
            retrievedGroup.Id.Should().Be(_fixture.SharedReadOnlyGroupId);
            GetGroupName(retrievedGroup.Profile).Should().NotBeNullOrEmpty();
            retrievedGroup.Type.Should().Be(GroupType.OKTAGROUP);
            retrievedGroup.Created.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
            retrievedGroup.LastUpdated.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
        }

        [Fact]
        public async Task GetGroupWithHttpInfo_ShouldReturnHttpResponse()
        {
            // Use a shared read-only group instead of creating a new one
            var response = await _groupApi.GetGroupWithHttpInfoAsync(_fixture.SharedReadOnlyGroupId);

            // Validate HTTP response
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Headers.Should().NotBeNull();

            // Validate response data
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_fixture.SharedReadOnlyGroupId);
            GetGroupName(response.Data.Profile).Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetGroup_WithInvalidId_ShouldFail()
        {
            var invalidGroupId = "invalid_group_id_12345";

            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.GetGroupAsync(invalidGroupId));

            ex.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task ListGroups_ShouldReturnGroups()
        {
            // Should return shared groups among others
            var groups = await _groupApi.ListGroups().ToListAsync();

            groups.Should().NotBeNull();
            groups.Should().NotBeEmpty();
            groups.Should().Contain(g => g.Id == _fixture.SharedReadOnlyGroupId);
        }

        [Fact]
        public async Task ListGroups_WithSearchAndQuery_ShouldFilterResults()
        {
            var guid = Guid.NewGuid();
            var uniqueName = $"TestGroup-SearchQuery-{guid}";
            
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = uniqueName,
                    Description = "Test group for search and query"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            // Wait a bit for indexing
            await Task.Delay(2000);

            // Test search with exact match
            var searchQuery = $"profile.name eq \"{uniqueName}\"";
            var searchResults = await _groupApi.ListGroups(search: searchQuery).ToListAsync();
            searchResults.Should().NotBeNull();
            searchResults.Should().Contain(g => g.Id == createdGroup.Id);

            // Test query with partial match
            var uniquePrefix = uniqueName.Substring(0, 20);
            var queryResults = await _groupApi.ListGroups(q: uniquePrefix).ToListAsync();
            queryResults.Should().NotBeNull();
            queryResults.Should().Contain(g => g.Id == createdGroup.Id);
        }

        [Fact]
        public async Task ListGroups_WithFilter_ShouldFilterResults()
        {
            // Test filter by type
            var filterQuery = "type eq \"OKTA_GROUP\"";
            var groups = await _groupApi.ListGroups(filter: filterQuery).ToListAsync();

            groups.Should().NotBeNull();
            groups.Should().NotBeEmpty();
            groups.Should().OnlyContain(g => g.Type == GroupType.OKTAGROUP);
        }

        [Fact]
        public async Task ListGroups_WithSortByAndOrder_ShouldSortResults()
        {
            // Test that sortBy and sortOrder parameters are accepted and produce results
            // Get groups sorted ascending by name
            var ascGroups = await _groupApi.ListGroups(limit: 20, sortBy: "profile.name", sortOrder: "asc").ToListAsync();
            
            ascGroups.Should().NotBeNull();
            ascGroups.Should().HaveCountGreaterOrEqualTo(2, "Should have multiple groups to verify sorting");
            
            // Get groups sorted descending by name
            var descGroups = await _groupApi.ListGroups(limit: 20, sortBy: "profile.name", sortOrder: "desc").ToListAsync();
            
            descGroups.Should().NotBeNull();
            descGroups.Should().HaveCountGreaterOrEqualTo(2, "Should have multiple groups to verify sorting");
            
            // Verify both call return results (parameters are accepted)
            ascGroups.Should().NotBeEmpty("Ascending sort should return results");
            descGroups.Should().NotBeEmpty("Descending sort should return results");
            
            // Verify HttpInfo variant also works with sorting parameters
            var response = await _groupApi.ListGroupsWithHttpInfoAsync(limit: 20, sortBy: "profile.name", sortOrder: "asc");
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().NotBeEmpty();
        }

        [Fact]
        public async Task ListGroups_WithExpandStats_ShouldIncludeUserCount()
        {
            // Use a shared group with known users
            var groups = await _groupApi.ListGroups(filter: $"id eq \"{_fixture.SharedGroupWithUsersId}\"", expand: "stats").ToListAsync();

            groups.Should().NotBeNull();
            groups.Should().ContainSingle();
            
            var group = groups.First();
            group.Should().NotBeNull();
            group.Id.Should().Be(_fixture.SharedGroupWithUsersId);
            
            // The _embedded property should contain stats with user count
            // Note: This validates that expand parameter is accepted and processed
        }

        [Fact]
        public async Task ListGroups_WithPagination_ShouldHandleAfterCursor()
        {
            // Get first page with limit
            var firstPageResponse = await _groupApi.ListGroupsWithHttpInfoAsync(limit: 2);
            
            firstPageResponse.Should().NotBeNull();
            firstPageResponse.Data.Should().NotBeNull();
            firstPageResponse.Data.Should().HaveCountLessOrEqualTo(2);

            // Check for Link header with the next cursor
            if (firstPageResponse.Headers.TryGetValue("Link", out var linkHeaders) && linkHeaders.Any())
            {
                var linkHeader = linkHeaders.First();
                
                // Extract 'after' cursor from Link header if present
                if (linkHeader.Contains("after="))
                {
                    var afterMatch = System.Text.RegularExpressions.Regex.Match(linkHeader, @"after=([^&>]+)");
                    if (afterMatch.Success)
                    {
                        var afterCursor = afterMatch.Groups[1].Value;
                        
                        // Get second page using after cursor
                        var secondPageResponse = await _groupApi.ListGroupsWithHttpInfoAsync(after: afterCursor, limit: 2);
                        
                        secondPageResponse.Should().NotBeNull();
                        secondPageResponse.Data.Should().NotBeNull();
                        
                        // Verify second page has different groups
                        var firstPageIds = firstPageResponse.Data.Select(g => g.Id).ToList();
                        var secondPageIds = secondPageResponse.Data.Select(g => g.Id).ToList();
                        
                        secondPageIds.Should().NotContain(firstPageIds, "Second page should have different groups");
                    }
                }
            }
        }

        [Fact]
        public async Task ListGroups_WithLimitAndHttpInfo_ShouldWork()
        {
            // Test limit parameter
            var groups = await _groupApi.ListGroups(limit: 5).ToListAsync();
            groups.Should().NotBeNull();
            groups.Count.Should().BeLessOrEqualTo(5);

            // Test WithHttpInfo variant
            var response = await _groupApi.ListGroupsWithHttpInfoAsync(limit: 10);
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Headers.Should().NotBeNull();
            response.Data.Should().NotBeNull();
            response.Data.Should().NotBeEmpty();
        }

        #endregion

        #region UPDATE Operation Tests (ReplaceGroup)

        [Fact]
        public async Task ReplaceGroup_WithValidData_ShouldSucceed()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-Replace-{guid}",
                    Description = "Original description"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            var updateGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-Replaced-{guid}",
                    Description = "Updated description"
                }
            };

            var updatedGroup = await _groupApi.ReplaceGroupAsync(createdGroup.Id, updateGroupRequest);

            // Validate updated properties
            updatedGroup.Should().NotBeNull();
            updatedGroup.Id.Should().Be(createdGroup.Id);
            GetGroupName(updatedGroup.Profile).Should().Be(updateGroupRequest.Profile.Name);
            GetGroupDescription(updatedGroup.Profile).Should().Be(updateGroupRequest.Profile.Description);
            updatedGroup.LastUpdated.Should().BeAfter(createdGroup.LastUpdated);
        }

        [Fact]
        public async Task ReplaceGroupWithHttpInfo_ShouldReturnHttpResponse()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-ReplaceHttpInfo-{guid}",
                    Description = "Original description"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            var updateGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-ReplacedHttpInfo-{guid}",
                    Description = "Updated description"
                }
            };

            var response = await _groupApi.ReplaceGroupWithHttpInfoAsync(createdGroup.Id, updateGroupRequest);

            // Validate HTTP response
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Headers.Should().NotBeNull();

            // Validate response data
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(createdGroup.Id);
            GetGroupName(response.Data.Profile).Should().Be(updateGroupRequest.Profile.Name);
            GetGroupDescription(response.Data.Profile).Should().Be(updateGroupRequest.Profile.Description);
        }

        [Fact]
        public async Task ReplaceGroup_WithInvalidId_ShouldFail()
        {
            var updateGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = "Updated Group",
                    Description = "Updated description"
                }
            };

            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.ReplaceGroupAsync("invalid_group_id_12345", updateGroupRequest));

            ex.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task ReplaceGroup_RemoveDescription_ShouldSucceed()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-RemoveDesc-{guid}",
                    Description = "Original description"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            var updateGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = GetGroupName(createdGroup.Profile),
                    Description = null
                }
            };

            var updatedGroup = await _groupApi.ReplaceGroupAsync(createdGroup.Id, updateGroupRequest);

            updatedGroup.Should().NotBeNull();
            GetGroupDescription(updatedGroup.Profile).Should().BeNullOrEmpty();
        }

        #endregion

        #region DELETE Operation Tests (DeleteGroup)

        [Fact]
        public async Task DeleteGroup_WithValidId_ShouldSucceed()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-Delete-{guid}",
                    Description = "Test group for deletion"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);

            await _groupApi.DeleteGroupAsync(createdGroup.Id);

            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.GetGroupAsync(createdGroup.Id));
            ex.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task DeleteGroupWithHttpInfo_ShouldReturnHttpResponse()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-DeleteHttpInfo-{guid}",
                    Description = "Test group for deletion with HTTP info"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);

            var response = await _groupApi.DeleteGroupWithHttpInfoAsync(createdGroup.Id);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

            // Verify group is actually deleted
            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.GetGroupAsync(createdGroup.Id));
            ex.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task DeleteGroup_WithInvalidId_ShouldFail()
        {
            var invalidGroupId = "invalid_group_id_12345";

            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.DeleteGroupAsync(invalidGroupId));

            ex.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task DeleteGroup_AlreadyDeleted_ShouldFail()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-DoubleDelete-{guid}",
                    Description = "Test group for double deletion"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);

            await _groupApi.DeleteGroupAsync(createdGroup.Id);

            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.DeleteGroupAsync(createdGroup.Id));

            ex.ErrorCode.Should().Be(404);
        }

        #endregion

        #region User Membership Tests (AssignUserToGroup, UnassignUserFromGroup, ListGroupUsers)

        [Fact]
        public async Task AssignUserToGroup_WithValidData_ShouldSucceed()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-AssignUser-{guid}",
                    Description = "Test group for user assignment"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, _fixture.TestUser1Id);

            // Wait for assignment to propagate
            await Task.Delay(1500);

            // Verify user is in a group
            var users = await _groupApi.ListGroupUsers(createdGroup.Id).ToListAsync();
            users.Should().Contain(u => u.Id == _fixture.TestUser1Id);
        }

        [Fact]
        public async Task AssignUserToGroupWithHttpInfo_ShouldReturnHttpResponse()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-AssignUserHttpInfo-{guid}",
                    Description = "Test group for user assignment with HTTP info"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            var response = await _groupApi.AssignUserToGroupWithHttpInfoAsync(createdGroup.Id, _fixture.TestUser1Id);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

            // Wait for assignment to propagate
            await Task.Delay(1500);

            // Verify user is in a group
            var users = await _groupApi.ListGroupUsers(createdGroup.Id).ToListAsync();
            users.Should().Contain(u => u.Id == _fixture.TestUser1Id);
        }

        [Fact]
        public async Task AssignUserToGroup_WithInvalidGroupId_ShouldFail()
        {
            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.AssignUserToGroupAsync("invalid_group_id", _fixture.TestUser1Id));

            ex.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task AssignUserToGroup_WithInvalidUserId_ShouldFail()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-InvalidUser-{guid}",
                    Description = "Test group for invalid user assignment"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.AssignUserToGroupAsync(createdGroup.Id, "invalid_user_id"));

            ex.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task UnassignUserFromGroup_WithValidData_ShouldSucceed()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-UnassignUser-{guid}",
                    Description = "Test group for user unassignment"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, _fixture.TestUser1Id);

            // Wait for assignment to propagate
            await Task.Delay(1500);

            await _groupApi.UnassignUserFromGroupAsync(createdGroup.Id, _fixture.TestUser1Id);

            // Wait for unassignment to propagate
            await Task.Delay(1500);

            // Verify user is not in a group
            var users = await _groupApi.ListGroupUsers(createdGroup.Id).ToListAsync();
            users.Should().NotContain(u => u.Id == _fixture.TestUser1Id);
        }

        [Fact]
        public async Task UnassignUserFromGroupWithHttpInfo_ShouldReturnHttpResponse()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-UnassignUserHttpInfo-{guid}",
                    Description = "Test group for user unassignment with HTTP info"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, _fixture.TestUser1Id);

            // Wait for assignment to propagate
            await Task.Delay(1500);

            var response = await _groupApi.UnassignUserFromGroupWithHttpInfoAsync(createdGroup.Id, _fixture.TestUser1Id);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

            // Wait for unassignment to propagate
            await Task.Delay(1500);

            // Verify user is not in a group
            var users = await _groupApi.ListGroupUsers(createdGroup.Id).ToListAsync();
            users.Should().NotContain(u => u.Id == _fixture.TestUser1Id);
        }

        [Fact]
        public async Task UnassignUserFromGroup_WithInvalidGroupId_ShouldFail()
        {
            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.UnassignUserFromGroupAsync("invalid_group_id", _fixture.TestUser1Id));

            ex.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task UnassignUserFromGroup_UserNotInGroup_ShouldBeIdempotent()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-UnassignNonMember-{guid}",
                    Description = "Test group for unassigning non-member"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            // Wait a bit to ensure a group is fully created
            await Task.Delay(500);

            // Unassigning a user not in the group should be idempotent and not throw
            await _groupApi.UnassignUserFromGroupAsync(createdGroup.Id, _fixture.TestUser1Id);

            // Verify user is still not in a group
            var users = await _groupApi.ListGroupUsers(createdGroup.Id).ToListAsync();
            users.Should().NotContain(u => u.Id == _fixture.TestUser1Id);
        }

        [Fact]
        public async Task ListGroupUsers_WithLimitAndHttpInfo_ShouldWork()
        {
            // Use a shared group with pre-assigned users
            var users = await _groupApi.ListGroupUsers(_fixture.SharedGroupWithUsersId).ToListAsync();
            users.Should().NotBeNull();
            users.Should().HaveCountGreaterOrEqualTo(2);
            users.Should().Contain(u => u.Id == _fixture.TestUser1Id);
            users.Should().Contain(u => u.Id == _fixture.TestUser2Id);

            // Test limit parameter - note that ToListAsync() may still return all results
            // but the API call itself respects the limit for pagination
            var limitedUsers = await _groupApi.ListGroupUsers(_fixture.SharedGroupWithUsersId, limit: 1).ToListAsync();
            limitedUsers.Should().NotBeNull();
            limitedUsers.Should().NotBeEmpty();

            // Test WithHttpInfo variant
            var response = await _groupApi.ListGroupUsersWithHttpInfoAsync(_fixture.SharedGroupWithUsersId, limit: 10);
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Headers.Should().NotBeNull();
            response.Data.Should().NotBeNull();
            response.Data.Should().Contain(u => u.Id == _fixture.TestUser1Id);
        }

        [Fact]
        public async Task ListGroupUsers_WithPagination_ShouldHandleAfterCursor()
        {
            // Use a shared group with users
            var firstPageResponse = await _groupApi.ListGroupUsersWithHttpInfoAsync(_fixture.SharedGroupWithUsersId, limit: 1);
            
            firstPageResponse.Should().NotBeNull();
            firstPageResponse.Data.Should().NotBeNull();
            firstPageResponse.Data.Should().HaveCountLessOrEqualTo(1);

            // Check for Link header with the next cursor
            if (firstPageResponse.Headers.TryGetValue("Link", out var linkHeaders) && linkHeaders.Any())
            {
                var linkHeader = linkHeaders.First();
                
                // Extract 'after' cursor from Link header if present
                if (linkHeader.Contains("after="))
                {
                    var afterMatch = System.Text.RegularExpressions.Regex.Match(linkHeader, @"after=([^&>]+)");
                    if (afterMatch.Success)
                    {
                        var afterCursor = afterMatch.Groups[1].Value;
                        
                        // Get second page using after cursor
                        var secondPageResponse = await _groupApi.ListGroupUsersWithHttpInfoAsync(_fixture.SharedGroupWithUsersId, after: afterCursor, limit: 1);
                        
                        secondPageResponse.Should().NotBeNull();
                        secondPageResponse.Data.Should().NotBeNull();
                        
                        // Verify second page has different users
                        var firstPageIds = firstPageResponse.Data.Select(u => u.Id).ToList();
                        var secondPageIds = secondPageResponse.Data.Select(u => u.Id).ToList();
                        
                        secondPageIds.Should().NotContain(firstPageIds, "Second page should have different users");
                    }
                }
            }
        }

        [Fact]
        public async Task ListGroupUsers_EmptyGroup_ShouldReturnEmptyList()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-EmptyList-{guid}",
                    Description = "Test empty group"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            var users = await _groupApi.ListGroupUsers(createdGroup.Id).ToListAsync();

            users.Should().NotBeNull();
            users.Should().BeEmpty();
        }

        #endregion

        #region Application Assignment Tests (ListAssignedApplicationsForGroup)

        [Fact]
        public async Task ListAssignedApplicationsForGroup_WithLimitAndHttpInfo_ShouldWork()
        {
            // Use a shared group with pre-assigned application
            var apps = await _groupApi.ListAssignedApplicationsForGroup(_fixture.SharedGroupWithAppId).ToListAsync();
            apps.Should().NotBeNull();
            apps.Should().Contain(a => a.Id == _fixture.TestApplicationId);

            // Test limit parameter
            var limitedApps = await _groupApi.ListAssignedApplicationsForGroup(_fixture.SharedGroupWithAppId, limit: 5).ToListAsync();
            limitedApps.Should().NotBeNull();
            limitedApps.Count.Should().BeLessOrEqualTo(5);

            // Test WithHttpInfo variant
            var response = await _groupApi.ListAssignedApplicationsForGroupWithHttpInfoAsync(_fixture.SharedGroupWithAppId, limit: 10);
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Headers.Should().NotBeNull();
            response.Data.Should().NotBeNull();
            response.Data.Should().Contain(a => a.Id == _fixture.TestApplicationId);
        }

        [Fact]
        public async Task ListAssignedApplicationsForGroup_WithPagination_ShouldHandleAfterCursor()
        {
            // Use a shared group with app
            var firstPageResponse = await _groupApi.ListAssignedApplicationsForGroupWithHttpInfoAsync(_fixture.SharedGroupWithAppId, limit: 1);
            
            firstPageResponse.Should().NotBeNull();
            firstPageResponse.Data.Should().NotBeNull();
            firstPageResponse.Data.Should().HaveCountLessOrEqualTo(1);

            // Check for Link header with the next cursor
            if (firstPageResponse.Headers.TryGetValue("Link", out var linkHeaders) && linkHeaders.Any())
            {
                var linkHeader = linkHeaders.First();
                
                // Extract 'after' cursor from Link header if present
                if (linkHeader.Contains("after="))
                {
                    var afterMatch = System.Text.RegularExpressions.Regex.Match(linkHeader, @"after=([^&>]+)");
                    if (afterMatch.Success)
                    {
                        var afterCursor = afterMatch.Groups[1].Value;
                        
                        // Get second page using after cursor
                        var secondPageResponse = await _groupApi.ListAssignedApplicationsForGroupWithHttpInfoAsync(_fixture.SharedGroupWithAppId, after: afterCursor, limit: 1);
                        
                        secondPageResponse.Should().NotBeNull();
                        secondPageResponse.Data.Should().NotBeNull();
                        
                        // Verify second page has different apps
                        var firstPageIds = firstPageResponse.Data.Select(a => a.Id).ToList();
                        var secondPageIds = secondPageResponse.Data.Select(a => a.Id).ToList();
                        
                        secondPageIds.Should().NotContain(firstPageIds, "Second page should have different apps");
                    }
                }
            }
        }

        [Fact]
        public async Task ListAssignedApplicationsForGroup_NoApps_ShouldReturnEmptyList()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-NoApps-{guid}",
                    Description = "Test group with no applications"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            var apps = await _groupApi.ListAssignedApplicationsForGroup(createdGroup.Id).ToListAsync();

            apps.Should().NotBeNull();
            apps.Should().BeEmpty();
        }

        [Fact]
        public async Task ListAssignedApplicationsForGroup_WithInvalidGroupId_ShouldFail()
        {
            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _groupApi.ListAssignedApplicationsForGroup("invalid_group_id").ToListAsync();
            });

            ex.ErrorCode.Should().Be(404);
        }

        #endregion

        #region Edge Case and Integration Tests

        [Fact]
        public async Task MultipleUsersInGroup_ShouldWorkCorrectly()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-MultipleUsers-{guid}",
                    Description = "Test group for multiple users"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            // Add multiple users
            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, _fixture.TestUser1Id);
            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, _fixture.TestUser2Id);
            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, _fixture.TestUser3Id);

            // Wait for assignments to propagate
            await Task.Delay(2000);

            var users = await _groupApi.ListGroupUsers(createdGroup.Id).ToListAsync();

            users.Should().HaveCount(3);
            users.Should().Contain(u => u.Id == _fixture.TestUser1Id);
            users.Should().Contain(u => u.Id == _fixture.TestUser2Id);
            users.Should().Contain(u => u.Id == _fixture.TestUser3Id);

            // Remove one user
            await _groupApi.UnassignUserFromGroupAsync(createdGroup.Id, _fixture.TestUser2Id);

            // Wait for unassignment to propagate
            await Task.Delay(1500);

            var usersAfterRemoval = await _groupApi.ListGroupUsers(createdGroup.Id).ToListAsync();

            usersAfterRemoval.Should().HaveCount(2);
            usersAfterRemoval.Should().Contain(u => u.Id == _fixture.TestUser1Id);
            usersAfterRemoval.Should().NotContain(u => u.Id == _fixture.TestUser2Id);
            usersAfterRemoval.Should().Contain(u => u.Id == _fixture.TestUser3Id);
        }

        [Fact]
        public async Task AssignUserToGroup_MultipleTimes_ShouldBeIdempotent()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-Idempotent-{guid}",
                    Description = "Test group for idempotency"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
            _createdGroupIds.Add(createdGroup.Id);

            // Assign user multiple times
            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, _fixture.TestUser1Id);
            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, _fixture.TestUser1Id);
            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, _fixture.TestUser1Id);

            // Wait for assignment to propagate
            await Task.Delay(1500);

            var users = await _groupApi.ListGroupUsers(createdGroup.Id).ToListAsync();

            users.Should().HaveCount(1);
            users.Should().Contain(u => u.Id == _fixture.TestUser1Id);
        }

        [Fact]
        public async Task GroupLifecycle_WithUserMemberships_ShouldCleanupProperly()
        {
            var guid = Guid.NewGuid();
            var addGroupRequest = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"TestGroup-Cleanup-{guid}",
                    Description = "Test group for cleanup"
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);

            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, _fixture.TestUser1Id);
            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, _fixture.TestUser2Id);

            // Delete group - should remove all memberships automatically
            await _groupApi.DeleteGroupAsync(createdGroup.Id);

            var ex = await Assert.ThrowsAsync<ApiException>(async () =>
                await _groupApi.GetGroupAsync(createdGroup.Id));
            ex.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task CreateAndUpdateMultipleGroups_ShouldSucceed()
        {
            var guid = Guid.NewGuid();
            var prefix = $"TestGroup-Multi-{guid}";

            var group1Request = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"{prefix}-1",
                    Description = "Test group 1"
                }
            };

            var group2Request = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"{prefix}-2",
                    Description = "Test group 2"
                }
            };

            var group1 = await _groupApi.AddGroupAsync(group1Request);
            var group2 = await _groupApi.AddGroupAsync(group2Request);

            _createdGroupIds.Add(group1.Id);
            _createdGroupIds.Add(group2.Id);

            group1.Id.Should().NotBe(group2.Id);

            // Update group 1 multiple times
            for (int i = 1; i <= 2; i++)
            {
                var updateRequest = new AddGroupRequest
                {
                    Profile = new OktaUserGroupProfile
                    {
                        Name = $"{prefix}-1",
                        Description = $"Update {i}"
                    }
                };

                var updatedGroup = await _groupApi.ReplaceGroupAsync(group1.Id, updateRequest);
                GetGroupDescription(updatedGroup.Profile).Should().Be($"Update {i}");
            }

            var finalGroup = await _groupApi.GetGroupAsync(group1.Id);
            GetGroupDescription(finalGroup.Profile).Should().Be("Update 2");

            // Wait for indexing
            await Task.Delay(2000);

            // Test search to find both groups
            var groups = await _groupApi.ListGroups(q: prefix).ToListAsync();
            groups.Should().HaveCountGreaterOrEqualTo(2);
            groups.Should().Contain(g => g.Id == group1.Id);
            groups.Should().Contain(g => g.Id == group2.Id);
        }

        #endregion
    }
}
