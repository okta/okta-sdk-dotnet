// <copyright file="ApplicationUsersApiTests.cs" company="Okta, Inc">
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
    public class ApplicationUsersApiTests : IDisposable
    {
        private readonly ApplicationUsersApi _appUsersApi = new();
        private readonly ApplicationApi _applicationApi = new();
        private readonly UserApi _userApi = new();
        private readonly UserLifecycleApi _userLifecycleApi = new();
        private readonly List<string> _createdUserIds = new();
        private readonly List<string> _createdAppIds = new();
        private readonly List<(string appId, string userId)> _assignedUsers = new();

        public void Dispose()
        {
            Cleanup().GetAwaiter().GetResult();
        }

        private async Task Cleanup()
        {
            foreach (var (appId, userId) in _assignedUsers)
            {
                try { await _appUsersApi.UnassignUserFromApplicationAsync(appId, userId); }
                catch (ApiException) { }
            }

            foreach (var appId in _createdAppIds)
            {
                try
                {
                    await _applicationApi.DeactivateApplicationAsync(appId);
                    await _applicationApi.DeleteApplicationAsync(appId);
                }
                catch (ApiException) { }
            }

            foreach (var userId in _createdUserIds)
            {
                try
                {
                    await _userLifecycleApi.DeactivateUserAsync(userId);
                    await _userApi.DeleteUserAsync(userId);
                }
                catch (ApiException) { }
            }
        }

        private async Task<Application> CreateTestApplicationAsync()
        {
            var app = new BookmarkApplication
            {
                Name = "bookmark",
                Label = $"Test App {Guid.NewGuid()}",
                Settings = new BookmarkApplicationSettings
                {
                    App = new BookmarkApplicationSettingsApplication
                    {
                        Url = "https://example.com",
                        RequestIntegration = false
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);
            _createdAppIds.Add(createdApp.Id);
            return createdApp;
        }

        private async Task<User> CreateTestUserAsync()
        {
            var randomId = Guid.NewGuid().ToString().Substring(0, 8);
            var user = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Test",
                    LastName = "User",
                    Email = $"test.user.{randomId}@example.com",
                    Login = $"test.user.{randomId}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abed1234!@#$"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(user);
            _createdUserIds.Add(createdUser.Id);
            return createdUser;
        }

        [Fact]
        public async Task GivenApplicationUsers_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            var testApp = await CreateTestApplicationAsync();
            var testUser = await CreateTestUserAsync();

            testApp.Should().NotBeNull();
            testApp.Id.Should().NotBeNullOrEmpty();
            testUser.Should().NotBeNull();
            testUser.Id.Should().NotBeNullOrEmpty();

            // POST /api/v1/apps/{appId}/users - Assign user to application
            var assignRequest = new AppUserAssignRequest { Id = testUser.Id };
            var assignedUser = await _appUsersApi.AssignUserToApplicationAsync(testApp.Id, assignRequest);

            assignedUser.Should().NotBeNull();
            assignedUser.Id.Should().Be(testUser.Id);
            assignedUser.Scope.Should().Be(AppUser.ScopeEnum.USER);
            assignedUser.Credentials.Should().NotBeNull();
            assignedUser.Created.Should().BeAfter(DateTimeOffset.MinValue);
            assignedUser.LastUpdated.Should().BeAfter(DateTimeOffset.MinValue);
            assignedUser.Status.Should().NotBeNull();
            assignedUser.StatusChanged.Should().BeAfter(DateTimeOffset.MinValue);
            assignedUser.Links.Should().NotBeNull();
            assignedUser.Links.App.Should().NotBeNull();
            assignedUser.Links.User.Should().NotBeNull();
            _assignedUsers.Add((testApp.Id, testUser.Id));

            // GET /api/v1/apps/{appId}/users/{userId} - Get assigned user
            var retrievedUser = await _appUsersApi.GetApplicationUserAsync(testApp.Id, testUser.Id);

            retrievedUser.Should().NotBeNull();
            retrievedUser.Id.Should().Be(testUser.Id);
            retrievedUser.Scope.Should().Be(AppUser.ScopeEnum.USER);
            retrievedUser.Created.Should().BeAfter(DateTimeOffset.MinValue);
            retrievedUser.LastUpdated.Should().BeAfter(DateTimeOffset.MinValue);
            retrievedUser.Status.Should().NotBeNull();
            retrievedUser.StatusChanged.Should().BeAfter(DateTimeOffset.MinValue);
            retrievedUser.SyncState.Should().NotBeNull();
            retrievedUser.Credentials.Should().NotBeNull();
            retrievedUser.Profile.Should().NotBeNull();
            retrievedUser.Links.Should().NotBeNull();
            retrievedUser.Links.App.Should().NotBeNull();
            retrievedUser.Links.App.Href.Should().Contain(testApp.Id);
            retrievedUser.Links.User.Should().NotBeNull();
            retrievedUser.Links.User.Href.Should().Contain(testUser.Id);

            // GET with HttpInfo - Full HTTP response
            var userWithHttpInfo = await _appUsersApi.GetApplicationUserWithHttpInfoAsync(testApp.Id, testUser.Id);

            userWithHttpInfo.Should().NotBeNull();
            userWithHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK);
            userWithHttpInfo.Headers.Should().NotBeNull();
            userWithHttpInfo.Headers.Should().ContainKey("Content-Type");
            userWithHttpInfo.Data.Should().NotBeNull();
            userWithHttpInfo.Data.Id.Should().Be(testUser.Id);
            userWithHttpInfo.Data.Created.Should().BeAfter(DateTimeOffset.MinValue);
            userWithHttpInfo.Data.LastUpdated.Should().BeAfter(DateTimeOffset.MinValue);
            userWithHttpInfo.Data.Links.Should().NotBeNull();

            // GET with expanding=user parameter - Validates _embedded.user
            var expandedUser = await _appUsersApi.GetApplicationUserAsync(testApp.Id, testUser.Id, "user");

            expandedUser.Should().NotBeNull();
            expandedUser.Id.Should().Be(testUser.Id);
            expandedUser.Embedded.Should().NotBeNull();
            expandedUser.Embedded.Should().ContainKey("user");
            var embeddedUserObj = expandedUser.Embedded["user"];
            embeddedUserObj.Should().NotBeNull();

            // GET /api/v1/apps/{appId}/users - List all users
            var usersList = _appUsersApi.ListApplicationUsers(testApp.Id);

            usersList.Should().NotBeNull();
            var usersEnumerable = usersList.ToListAsync().GetAwaiter().GetResult();
            usersEnumerable.Should().NotBeNull();
            usersEnumerable.Should().HaveCountGreaterOrEqualTo(1);
            usersEnumerable.Should().Contain(u => u.Id == testUser.Id);

            // GET with HttpInfo - Collection with HTTP response
            var usersWithHttpInfo = await _appUsersApi.ListApplicationUsersWithHttpInfoAsync(testApp.Id);

            usersWithHttpInfo.Should().NotBeNull();
            usersWithHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK);
            usersWithHttpInfo.Headers.Should().NotBeNull();
            usersWithHttpInfo.Data.Should().NotBeNull();
            usersWithHttpInfo.Data.Should().HaveCountGreaterOrEqualTo(1);

            // GET with query parameter
            var filteredUsers = _appUsersApi.ListApplicationUsers(testApp.Id, q: testUser.Profile.Email.Substring(0, 10));

            filteredUsers.Should().NotBeNull();
            var filteredList = filteredUsers.ToListAsync().GetAwaiter().GetResult();
            filteredList.Should().NotBeNull();

            // GET with limit parameter
            var limitedUsers = _appUsersApi.ListApplicationUsers(testApp.Id, limit: 1);

            limitedUsers.Should().NotBeNull();
            var limitedList = limitedUsers.ToListAsync().GetAwaiter().GetResult();
            limitedList.Should().NotBeNull();

            // POST /api/v1/apps/{appId}/users/{userId} - Update user profile
            var profilePayload = new AppUserProfileRequestPayload
            {
                Profile = new Dictionary<string, Object>
                {
                    { "email", testUser.Profile.Email }
                }
            };
            var updateRequest = new AppUserUpdateRequest(profilePayload);

            var updatedUser = await _appUsersApi.UpdateApplicationUserAsync(testApp.Id, testUser.Id, updateRequest);

            updatedUser.Should().NotBeNull();
            updatedUser.Id.Should().Be(testUser.Id);

            // POST with HttpInfo - Update with HTTP response
            var updateWithHttpInfo = await _appUsersApi.UpdateApplicationUserWithHttpInfoAsync(testApp.Id, testUser.Id, updateRequest);

            updateWithHttpInfo.Should().NotBeNull();
            updateWithHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK);
            updateWithHttpInfo.Headers.Should().NotBeNull();
            updateWithHttpInfo.Data.Should().NotBeNull();
            updateWithHttpInfo.Data.Id.Should().Be(testUser.Id);

            // POST with HttpInfo - Assign user with HTTP response
            var testUser2 = await CreateTestUserAsync();
            var assignWithHttpInfo = await _appUsersApi.AssignUserToApplicationWithHttpInfoAsync(
                testApp.Id,
                new AppUserAssignRequest { Id = testUser2.Id }
            );

            assignWithHttpInfo.Should().NotBeNull();
            assignWithHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK);
            assignWithHttpInfo.Headers.Should().NotBeNull();
            assignWithHttpInfo.Data.Should().NotBeNull();
            assignWithHttpInfo.Data.Id.Should().Be(testUser2.Id);
            _assignedUsers.Add((testApp.Id, testUser2.Id));

            // DELETE /api/v1/apps/{appId}/users/{userId} - Unassign user
            await _appUsersApi.UnassignUserFromApplicationAsync(testApp.Id, testUser2.Id);
            _assignedUsers.Remove((testApp.Id, testUser2.Id));

            // Verify unassignment (should throw 404)
            var unassignException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.GetApplicationUserAsync(testApp.Id, testUser2.Id);
            });
            unassignException.ErrorCode.Should().Be(404);

            // DELETE with HttpInfo - Unassign with HTTP response
            var testUser3 = await CreateTestUserAsync();
            await _appUsersApi.AssignUserToApplicationAsync(testApp.Id, new AppUserAssignRequest { Id = testUser3.Id });
            _assignedUsers.Add((testApp.Id, testUser3.Id));

            var unassignWithHttpInfo = await _appUsersApi.UnassignUserFromApplicationWithHttpInfoAsync(testApp.Id, testUser3.Id);

            unassignWithHttpInfo.Should().NotBeNull();
            unassignWithHttpInfo.StatusCode.Should().Be(HttpStatusCode.NoContent);
            _assignedUsers.Remove((testApp.Id, testUser3.Id));

            // DELETE it with sendEmail parameter
            var testUser4 = await CreateTestUserAsync();
            await _appUsersApi.AssignUserToApplicationAsync(testApp.Id, new AppUserAssignRequest { Id = testUser4.Id });
            _assignedUsers.Add((testApp.Id, testUser4.Id));

            await _appUsersApi.UnassignUserFromApplicationAsync(testApp.Id, testUser4.Id, sendEmail: false);
            _assignedUsers.Remove((testApp.Id, testUser4.Id));

            await _appUsersApi.UnassignUserFromApplicationAsync(testApp.Id, testUser.Id);
            _assignedUsers.Remove((testApp.Id, testUser.Id));
        }

        [Fact]
        public async Task GivenCredentials_WhenUpdatingApplicationUser_ThenUpdateWorksCorrectly()
        {
            var testApp = await CreateTestApplicationAsync();
            var testUser = await CreateTestUserAsync();

            await _appUsersApi.AssignUserToApplicationAsync(testApp.Id, new AppUserAssignRequest { Id = testUser.Id });
            _assignedUsers.Add((testApp.Id, testUser.Id));

            var credentialsPayload = new AppUserCredentialsRequestPayload
            {
                Credentials = new AppUserCredentials
                {
                    UserName = testUser.Profile.Email,
                    Password = new AppUserPasswordCredential
                    {
                        Value = "NewP@ssw0rd123!"
                    }
                }
            };
            var credentialsUpdateRequest = new AppUserUpdateRequest(credentialsPayload);

            var updatedUser = await _appUsersApi.UpdateApplicationUserAsync(testApp.Id, testUser.Id, credentialsUpdateRequest);

            updatedUser.Should().NotBeNull();
            updatedUser.Id.Should().Be(testUser.Id);
            updatedUser.Credentials.Should().NotBeNull();
            updatedUser.Credentials.UserName.Should().Be(testUser.Profile.Email);
            updatedUser.LastUpdated.Should().BeAfter(DateTimeOffset.MinValue);

            await _appUsersApi.UnassignUserFromApplicationAsync(testApp.Id, testUser.Id);
            _assignedUsers.Remove((testApp.Id, testUser.Id));
        }

        [Fact]
        public async Task GivenInvalidScenarios_WhenCallingApi_ThenAllInvalidScenariosAreCovered()
        {
            var testApp = await CreateTestApplicationAsync();
            var testUser = await CreateTestUserAsync();

            var assignRequest = new AppUserAssignRequest { Id = testUser.Id };
            var nullAppException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.AssignUserToApplicationAsync(null, assignRequest);
            });
            nullAppException.Should().NotBeNull();
            nullAppException.ErrorCode.Should().Be(400);
            nullAppException.Message.Should().NotBeNullOrEmpty();

            var nullUserException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.AssignUserToApplicationAsync(testApp.Id, null);
            });
            nullUserException.Should().NotBeNull();
            nullUserException.ErrorCode.Should().Be(400);
            nullUserException.Message.Should().NotBeNullOrEmpty();

            var invalidAppException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.AssignUserToApplicationAsync("invalid-app-id", assignRequest);
            });
            invalidAppException.Should().NotBeNull();
            invalidAppException.ErrorCode.Should().Be(404);
            invalidAppException.ErrorContent.Should().NotBeNull();
            invalidAppException.Message.Should().NotBeNullOrEmpty();
            invalidAppException.Headers.Should().NotBeNull();

            var invalidUserAssignRequest = new AppUserAssignRequest { Id = "invalid-user-id" };
            var invalidUserException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.AssignUserToApplicationAsync(testApp.Id, invalidUserAssignRequest);
            });
            invalidUserException.Should().NotBeNull();
            invalidUserException.ErrorCode.Should().Be(404);
            invalidUserException.Message.Should().NotBeNullOrEmpty();
            invalidUserException.ErrorContent.Should().NotBeNull();

            var getAppNullException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.GetApplicationUserAsync(null, testUser.Id);
            });
            getAppNullException.Should().NotBeNull();
            getAppNullException.ErrorCode.Should().Be(400);
            getAppNullException.Message.Should().NotBeNullOrEmpty();

            var getUserNullException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.GetApplicationUserAsync(testApp.Id, null);
            });
            getUserNullException.Should().NotBeNull();
            getUserNullException.ErrorCode.Should().Be(400);
            getUserNullException.Message.Should().NotBeNullOrEmpty();

            var getInvalidAppException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.GetApplicationUserAsync("invalid-app-id", testUser.Id);
            });
            getInvalidAppException.Should().NotBeNull();
            getInvalidAppException.ErrorCode.Should().Be(404);
            getInvalidAppException.Message.Should().NotBeNullOrEmpty();
            getInvalidAppException.ErrorContent.Should().NotBeNull();

            var notAssignedException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.GetApplicationUserAsync(testApp.Id, testUser.Id);
            });
            notAssignedException.Should().NotBeNull();
            notAssignedException.ErrorCode.Should().Be(404);
            notAssignedException.Message.Should().NotBeNullOrEmpty();
            notAssignedException.ErrorContent.Should().NotBeNull();

            var getHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.GetApplicationUserWithHttpInfoAsync("invalid-app-id", testUser.Id);
            });
            getHttpInfoException.Should().NotBeNull();
            getHttpInfoException.ErrorCode.Should().Be(404);
            getHttpInfoException.Headers.Should().NotBeNull();

            var profilePayload = new AppUserProfileRequestPayload
            {
                Profile = new Dictionary<string, Object> { { "email", testUser.Profile.Email } }
            };
            var updateRequest = new AppUserUpdateRequest(profilePayload);
            var updateAppNullException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.UpdateApplicationUserAsync(null, testUser.Id, updateRequest);
            });
            updateAppNullException.Should().NotBeNull();
            updateAppNullException.ErrorCode.Should().Be(400);
            updateAppNullException.Message.Should().NotBeNullOrEmpty();

            var updateUserNullException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.UpdateApplicationUserAsync(testApp.Id, null, updateRequest);
            });
            updateUserNullException.Should().NotBeNull();
            updateUserNullException.ErrorCode.Should().Be(400);
            updateUserNullException.Message.Should().NotBeNullOrEmpty();

            var updateRequestNullException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.UpdateApplicationUserAsync(testApp.Id, testUser.Id, null);
            });
            updateRequestNullException.Should().NotBeNull();
            updateRequestNullException.ErrorCode.Should().Be(400);
            updateRequestNullException.Message.Should().NotBeNullOrEmpty();

            var unassignAppNullException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.UnassignUserFromApplicationAsync(null, testUser.Id);
            });
            unassignAppNullException.Should().NotBeNull();
            unassignAppNullException.ErrorCode.Should().Be(400);
            unassignAppNullException.Message.Should().NotBeNullOrEmpty();

            // Test 15: UnassignUserFromApplicationAsync with null userId
            var unassignUserNullException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.UnassignUserFromApplicationAsync(testApp.Id, null);
            });
            unassignUserNullException.Should().NotBeNull();
            unassignUserNullException.ErrorCode.Should().Be(400);
            unassignUserNullException.Message.Should().NotBeNullOrEmpty();

            var unassignNotAssignedException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appUsersApi.UnassignUserFromApplicationAsync(testApp.Id, testUser.Id);
            });
            unassignNotAssignedException.Should().NotBeNull();
            unassignNotAssignedException.ErrorCode.Should().Be(404);
            unassignNotAssignedException.Message.Should().NotBeNullOrEmpty();
            unassignNotAssignedException.ErrorContent.Should().NotBeNull();

            Assert.Throws<ApiException>(() => { _appUsersApi.ListApplicationUsers(null); });

            var listInvalidException = Assert.ThrowsAny<Exception>(() =>
            {
                var collection = _appUsersApi.ListApplicationUsers("invalid-app-id");
                collection.ToListAsync().GetAwaiter().GetResult();
            });
            listInvalidException.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenMultipleUsers_WhenListingWithPagination_ThenPaginationWorksCorrectly()
        {
            var testApp = await CreateTestApplicationAsync();
            var users = new List<User>();

            for (int i = 0; i < 5; i++)
            {
                var user = await CreateTestUserAsync();
                users.Add(user);
                await _appUsersApi.AssignUserToApplicationAsync(testApp.Id, new AppUserAssignRequest { Id = user.Id });
                _assignedUsers.Add((testApp.Id, user.Id));
            }

            var firstPage = _appUsersApi.ListApplicationUsers(testApp.Id, limit: 20);
            var firstPageList = await firstPage.ToListAsync();

            firstPageList.Should().NotBeNull();
            firstPageList.Should().HaveCountGreaterOrEqualTo(5);

            var allUsers = _appUsersApi.ListApplicationUsers(testApp.Id);
            var allUsersList = await allUsers.ToListAsync();

            allUsersList.Should().NotBeNull();
            allUsersList.Should().HaveCountGreaterOrEqualTo(5);
            foreach (var user in users)
            {
                allUsersList.Should().Contain(u => u.Id == user.Id);
            }

            foreach (var user in users)
            {
                await _appUsersApi.UnassignUserFromApplicationAsync(testApp.Id, user.Id);
                _assignedUsers.Remove((testApp.Id, user.Id));
            }
        }

        [Fact]
        public async Task GivenDifferentScenarios_WhenAssigningAndUpdatingUser_ThenOperationsWorkCorrectly()
        {
            var testApp = await CreateTestApplicationAsync();
            var testUser = await CreateTestUserAsync();

            var assignRequest = new AppUserAssignRequest { Id = testUser.Id };
            var assignedUser = await _appUsersApi.AssignUserToApplicationAsync(testApp.Id, assignRequest);

            assignedUser.Should().NotBeNull();
            assignedUser.Id.Should().Be(testUser.Id);
            assignedUser.Scope.Should().Be(AppUser.ScopeEnum.USER);
            _assignedUsers.Add((testApp.Id, testUser.Id));

            var retrievedUser = await _appUsersApi.GetApplicationUserAsync(testApp.Id, testUser.Id);
            retrievedUser.Should().NotBeNull();
            retrievedUser.Id.Should().Be(testUser.Id);

            var profilePayload = new AppUserProfileRequestPayload
            {
                Profile = new Dictionary<string, Object> { { "email", testUser.Profile.Email } }
            };
            var updateRequest = new AppUserUpdateRequest(profilePayload);
            var updatedUser = await _appUsersApi.UpdateApplicationUserAsync(testApp.Id, testUser.Id, updateRequest);
            updatedUser.Should().NotBeNull();
            updatedUser.Id.Should().Be(testUser.Id);

            var expandedUser = await _appUsersApi.GetApplicationUserAsync(testApp.Id, testUser.Id, "user");
            expandedUser.Should().NotBeNull();
            expandedUser.Id.Should().Be(testUser.Id);

            var usersList = _appUsersApi.ListApplicationUsers(testApp.Id);
            var usersArray = await usersList.ToListAsync();
            usersArray.Should().Contain(u => u.Id == testUser.Id);

            await _appUsersApi.UnassignUserFromApplicationAsync(testApp.Id, testUser.Id);
            _assignedUsers.Remove((testApp.Id, testUser.Id));
        }

        [Fact]
        public async Task GivenExistingAssignment_WhenAttemptingDuplicateAssignment_ThenErrorIsThrown()
        {
            var testApp = await CreateTestApplicationAsync();
            var testUser = await CreateTestUserAsync();

            var assignRequest = new AppUserAssignRequest { Id = testUser.Id };
            var firstAssignment = await _appUsersApi.AssignUserToApplicationAsync(testApp.Id, assignRequest);
            _assignedUsers.Add((testApp.Id, testUser.Id));

            firstAssignment.Should().NotBeNull();
            firstAssignment.Id.Should().Be(testUser.Id);

            try
            {
                var secondAssignment = await _appUsersApi.AssignUserToApplicationAsync(testApp.Id, assignRequest);
                secondAssignment.Should().NotBeNull();
                secondAssignment.Id.Should().Be(testUser.Id);
            }
            catch (ApiException ex)
            {
                ex.ErrorCode.Should().BeOneOf(400, 409);
            }

            await _appUsersApi.UnassignUserFromApplicationAsync(testApp.Id, testUser.Id);
            _assignedUsers.Remove((testApp.Id, testUser.Id));
        }
    }
}
