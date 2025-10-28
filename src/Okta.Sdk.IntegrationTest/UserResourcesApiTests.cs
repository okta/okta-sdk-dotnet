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
    [Collection(nameof(UserResourcesApiTests))]
    public class UserResourcesApiTests : IDisposable
    {
        private readonly UserResourcesApi _userResourcesApi = new();
        private readonly UserApi _userApi = new();
        private readonly GroupApi _groupApi = new();
        private readonly ApplicationApi _applicationApi = new();
        private readonly List<string> _createdUserIds = [];
        private readonly List<string> _createdGroupIds = [];
        private readonly List<string> _createdAppIds = [];

        public void Dispose()
        {
            CleanupResources().GetAwaiter().GetResult();
        }

        private async Task CleanupResources()
        {
            foreach (var appId in _createdAppIds)
            {
                try
                {
                    await _applicationApi.DeactivateApplicationAsync(appId);
                    await _applicationApi.DeleteApplicationAsync(appId);
                }
                catch (ApiException)
                {
                    // Ignore cleanup errors
                }
            }
            _createdAppIds.Clear();

            foreach (var groupId in _createdGroupIds)
            {
                try
                {
                    await _groupApi.DeleteGroupAsync(groupId);
                }
                catch (ApiException)
                {
                    // Ignore cleanup errors
                }
            }
            _createdGroupIds.Clear();

            foreach (var userId in _createdUserIds)
            {
                try
                {
                    await _userApi.DeleteUserAsync(userId);
                    await _userApi.DeleteUserAsync(userId);
                }
                catch (ApiException)
                {
                    // Ignore cleanup errors
                }
            }
            _createdUserIds.Clear();
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

        [Fact]
        public async Task GivenUserResources_WhenPerformingCrudOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();

            // Setup: Create test user
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "UserResources",
                    LastName = "Test",
                    Email = $"user-resources-{guid}@example.com",
                    Login = $"user-resources-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);

            createdUser.Should().NotBeNull();
            createdUser.Id.Should().NotBeNullOrEmpty();

            await Task.Delay(2000);

            // Setup: Create a test group and add user
            var groupProfile = new OktaUserGroupProfile { Name = $"UserResourcesTestGroup_{guid}" };
            var createdGroup = await _groupApi.AddGroupAsync(new AddGroupRequest { Profile = groupProfile });
            _createdGroupIds.Add(createdGroup.Id);

            await Task.Delay(1000); // Wait for group creation to propagate

            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, createdUser.Id);
            await Task.Delay(5000); // Increased delay for group assignment propagation

            // ListUserGroups - List all groups users are member of
            var userGroups = await _userResourcesApi.ListUserGroups(createdUser.Id).ToListAsync();

            userGroups.Should().NotBeNull();
            userGroups.Should().NotBeEmpty();
            userGroups.Should().Contain(g => g.Id == createdGroup.Id);
            
            // Validate the group properties
            var foundGroup = userGroups.FirstOrDefault(g => g.Id == createdGroup.Id);
            foundGroup.Should().NotBeNull();
            foundGroup?.Profile.Should().NotBeNull();
            GetGroupName(foundGroup?.Profile).Should().Be($"UserResourcesTestGroup_{guid}");

            // ListAppLinks - List all app links for user
            var appLinks = await _userResourcesApi.ListAppLinks(createdUser.Id).ToListAsync();

            appLinks.Should().NotBeNull();
            // Maybe empty if no apps assigned, which is acceptable

            // ListUserClients - List all OAuth clients for user
            var userClients = await _userResourcesApi.ListUserClients(createdUser.Id).ToListAsync();

            userClients.Should().NotBeNull();
            // May be empty if no OAuth grants exist, which is acceptable

            // ListUserDevices - List all devices for user
            try
            {
                var userDevices = await _userResourcesApi.ListUserDevices(createdUser.Id).ToListAsync();

                userDevices.Should().NotBeNull();
                // May be empty if no devices enrolled, which is acceptable
            }
            catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 403)
            {
                // Device API may not be enabled in all org's (Identity Engine feature)
                // This is acceptable
            }
        }

        [Fact]
        public async Task GivenHttpInfoMethods_WhenCallingApi_ThenHttpMetadataIsReturned()
        {
            var guid = Guid.NewGuid();

            // Setup: Create test user
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "UserResources",
                    LastName = "HttpInfo",
                    Email = $"user-resources-http-{guid}@example.com",
                    Login = $"user-resources-http-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);

            await Task.Delay(2000);

            // Setup: Create a test group and add user
            var groupProfile = new OktaUserGroupProfile { Name = $"UserResourcesHttpInfoGroup_{guid}" };
            var createdGroup = await _groupApi.AddGroupAsync(new AddGroupRequest { Profile = groupProfile });
            _createdGroupIds.Add(createdGroup.Id);

            await Task.Delay(1000); // Wait for group creation to propagate

            await _groupApi.AssignUserToGroupAsync(createdGroup.Id, createdUser.Id);
            await Task.Delay(5000); // Increased delay for group assignment propagation

            // ListUserGroupsWithHttpInfoAsync - List groups with HTTP metadata
            var groupsResponse = await _userResourcesApi.ListUserGroupsWithHttpInfoAsync(createdUser.Id);

            groupsResponse.Should().NotBeNull();
            groupsResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            groupsResponse.Data.Should().NotBeNull();
            groupsResponse.Data.Should().NotBeEmpty();
            groupsResponse.Data.Should().Contain(g => g.Id == createdGroup.Id);
            groupsResponse.Headers.Should().NotBeNull();
            
            // Validate group properties in HttpInfo response
            var foundGroupInHttpInfo = groupsResponse.Data.FirstOrDefault(g => g.Id == createdGroup.Id);
            foundGroupInHttpInfo.Should().NotBeNull();
            if (foundGroupInHttpInfo != null)
            {
                foundGroupInHttpInfo.Profile.Should().NotBeNull();
                GetGroupName(foundGroupInHttpInfo.Profile).Should().Be($"UserResourcesHttpInfoGroup_{guid}");
            }

            // ListAppLinksWithHttpInfoAsync - List app links with HTTP metadata
            var appLinksResponse = await _userResourcesApi.ListAppLinksWithHttpInfoAsync(createdUser.Id);

            appLinksResponse.Should().NotBeNull();
            appLinksResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            appLinksResponse.Data.Should().NotBeNull();
            appLinksResponse.Headers.Should().NotBeNull();

            // ListUserClientsWithHttpInfoAsync - List OAuth clients with HTTP metadata
            var clientsResponse = await _userResourcesApi.ListUserClientsWithHttpInfoAsync(createdUser.Id);

            clientsResponse.Should().NotBeNull();
            clientsResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            clientsResponse.Data.Should().NotBeNull();
            clientsResponse.Headers.Should().NotBeNull();

            // ListUserDevicesWithHttpInfoAsync - List devices with HTTP metadata
            try
            {
                var devicesResponse = await _userResourcesApi.ListUserDevicesWithHttpInfoAsync(createdUser.Id);

                devicesResponse.Should().NotBeNull();
                devicesResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                devicesResponse.Data.Should().NotBeNull();
                devicesResponse.Headers.Should().NotBeNull();
            }
            catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 403)
            {
                // Device API may not be enabled in all org's (Identity Engine feature)
                // This is acceptable
            }
        }

        [Fact]
        public async Task GivenErrorScenarios_WhenCallingApi_ThenApiExceptionIsThrown()
        {
            const string invalidUserId = "invalid_user_id_12345";

            // ListUserGroups with invalid userId - should throw 404
            var groupsException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userResourcesApi.ListUserGroups(invalidUserId).ToListAsync();
            });
            groupsException.ErrorCode.Should().Be(404);

            // ListAppLinks with invalid userId - should throw 404
            var appLinksException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userResourcesApi.ListAppLinks(invalidUserId).ToListAsync();
            });
            appLinksException.ErrorCode.Should().Be(404);

            // ListUserClients with invalid userId - should throw 404
            var clientsException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userResourcesApi.ListUserClients(invalidUserId).ToListAsync();
            });
            clientsException.ErrorCode.Should().Be(404);

            // ListUserDevices with invalid userId - should throw 404 or 400
            var devicesException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userResourcesApi.ListUserDevices(invalidUserId).ToListAsync();
            });
            devicesException.ErrorCode.Should().BeOneOf(400, 404);

            // ListUserGroupsWithHttpInfoAsync with invalid userId - should throw 404
            var groupsHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userResourcesApi.ListUserGroupsWithHttpInfoAsync(invalidUserId);
            });
            groupsHttpInfoException.ErrorCode.Should().Be(404);

            // ListAppLinksWithHttpInfoAsync with invalid userId - should throw 404
            var appLinksHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userResourcesApi.ListAppLinksWithHttpInfoAsync(invalidUserId);
            });
            appLinksHttpInfoException.ErrorCode.Should().Be(404);

            // ListUserClientsWithHttpInfoAsync with invalid userId - should throw 404
            var clientsHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userResourcesApi.ListUserClientsWithHttpInfoAsync(invalidUserId);
            });
            clientsHttpInfoException.ErrorCode.Should().Be(404);

            // ListUserDevicesWithHttpInfoAsync with invalid userId - should throw 404 or 400
            var devicesHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userResourcesApi.ListUserDevicesWithHttpInfoAsync(invalidUserId);
            });
            devicesHttpInfoException.ErrorCode.Should().BeOneOf(400, 404);
        }
    }
}
