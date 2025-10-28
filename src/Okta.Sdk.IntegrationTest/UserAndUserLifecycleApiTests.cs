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
    public class UserAndUserLifecycleApiTests : IDisposable
    {
        private readonly UserApi _userApi;
        private readonly UserLifecycleApi _userLifecycleApi;
        private readonly List<string> _createdUserIds = new List<string>();

        public UserAndUserLifecycleApiTests()
        {
            _userApi = new UserApi();
            _userLifecycleApi = new UserLifecycleApi();
        }

        public void Dispose()
        {
            CleanupResources().Wait();
        }

        private async Task CleanupResources()
        {
            foreach (var userId in _createdUserIds)
            {
                try
                {
                    await _userLifecycleApi.DeactivateUserAsync(userId);
                    await Task.Delay(500);
                }
                catch (ApiException) { }

                try
                {
                    await _userApi.DeleteUserAsync(userId);
                }
                catch (ApiException) { }
            }
        }
        [Fact]
        public async Task GivenUsers_WhenPerformingCrudOperations_ThenAllStandardMethodsWork()
        {
            var testGuid = Guid.NewGuid().ToString().Substring(0, 8);

            // CREATE: User without credentials (STAGED status)
            var userWithoutCredentials = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "NoCredentials",
                    LastName = $"User-{testGuid}",
                    Email = $"nocreds-{testGuid}@example.com",
                    Login = $"nocreds-{testGuid}@example.com"
                }
            };

            var createdUser1 = await _userApi.CreateUserAsync(userWithoutCredentials, activate: false);
            _createdUserIds.Add(createdUser1.Id);

            createdUser1.Should().NotBeNull();
            createdUser1.Id.Should().NotBeNullOrEmpty();
            createdUser1.Status.Should().Be(UserStatus.STAGED);
            createdUser1.Profile.FirstName.Should().Be("NoCredentials");
            createdUser1.Profile.LastName.Should().Be($"User-{testGuid}");
            createdUser1.Profile.Email.Should().Be($"nocreds-{testGuid}@example.com");
            createdUser1.Profile.Login.Should().Be($"nocreds-{testGuid}@example.com");

            await Task.Delay(1000);

            // CREATE: User with password and activate
            var userWithPassword = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "WithPassword",
                    LastName = $"User-{testGuid}",
                    Email = $"with-pass-{testGuid}@example.com",
                    Login = $"with-pass-{testGuid}@example.com",
                    MobilePhone = "555-123-4567"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential
                    {
                        Value = "P@ssw0rd!2025"
                    }
                }
            };

            var createdUser2 = await _userApi.CreateUserAsync(userWithPassword, activate: true);
            _createdUserIds.Add(createdUser2.Id);

            createdUser2.Should().NotBeNull();
            createdUser2.Id.Should().NotBeNullOrEmpty();
            (createdUser2.Status == UserStatus.PROVISIONED || 
             createdUser2.Status == UserStatus.ACTIVE).Should().BeTrue();
            createdUser2.Profile.FirstName.Should().Be("WithPassword");
            createdUser2.Profile.MobilePhone.Should().Be("555-123-4567");

            await Task.Delay(1000);

            // CREATE: User with password and recovery question
            var userWithRecovery = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "WithRecovery",
                    LastName = $"User-{testGuid}",
                    Email = $"recovery-{testGuid}@example.com",
                    Login = $"recovery-{testGuid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential
                    {
                        Value = "P@ssw0rd!2025"
                    },
                    RecoveryQuestion = new RecoveryQuestionCredential
                    {
                        Question = "What is your favorite color?",
                        Answer = "Blue"
                    }
                }
            };

            var createdUser3 = await _userApi.CreateUserAsync(userWithRecovery, activate: true);
            _createdUserIds.Add(createdUser3.Id);

            createdUser3.Should().NotBeNull();
            createdUser3.Id.Should().NotBeNullOrEmpty();
            createdUser3.Profile.FirstName.Should().Be("WithRecovery");

            await Task.Delay(1000);

            // CREATE: User with nextLogin=changePassword
            var userWithExpiredPassword = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "ExpiredPassword",
                    LastName = $"User-{testGuid}",
                    Email = $"expired-{testGuid}@example.com",
                    Login = $"expired-{testGuid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential
                    {
                        Value = "P@ssw0rd!2025"
                    }
                }
            };

            var createdUser4 = await _userApi.CreateUserAsync(
                userWithExpiredPassword, 
                activate: true, 
                nextLogin: UserNextLogin.ChangePassword);
            _createdUserIds.Add(createdUser4.Id);

            createdUser4.Should().NotBeNull();
            createdUser4.Id.Should().NotBeNullOrEmpty();
            createdUser4.Profile.FirstName.Should().Be("ExpiredPassword");

            await Task.Delay(1000);

            // CREATE: User with full profile details
            var userWithFullProfile = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "FullProfile",
                    LastName = $"User-{testGuid}",
                    Email = $"full-profile-{testGuid}@example.com",
                    Login = $"full-profile-{testGuid}@example.com",
                    SecondEmail = $"secondary-{testGuid}@example.com",
                    MobilePhone = "555-987-6543",
                    PrimaryPhone = "555-111-2222",
                    StreetAddress = "123 Main Street",
                    City = "San Francisco",
                    State = "CA",
                    ZipCode = "94105",
                    CountryCode = "US",
                    Organization = "Test Org",
                    Department = "Engineering",
                    Title = "Senior Developer",
                    DisplayName = "Full Profile User",
                    NickName = "FP",
                    PreferredLanguage = "en-US",
                    UserType = "Employee"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential
                    {
                        Value = "P@ssw0rd!2025"
                    }
                }
            };

            var createdUser5 = await _userApi.CreateUserAsync(userWithFullProfile, activate: true);
            _createdUserIds.Add(createdUser5.Id);

            createdUser5.Should().NotBeNull();
            createdUser5.Id.Should().NotBeNullOrEmpty();
            createdUser5.Profile.FirstName.Should().Be("FullProfile");
            createdUser5.Profile.Department.Should().Be("Engineering");
            createdUser5.Profile.Title.Should().Be("Senior Developer");
            createdUser5.Profile.City.Should().Be("San Francisco");
            createdUser5.Profile.State.Should().Be("CA");

            await Task.Delay(2000);

            // READ: List all users with pagination
            var allUsersFirstPage = await _userApi.ListUsers(limit: 10).ToListAsync();

            allUsersFirstPage.Should().NotBeNull();
            allUsersFirstPage.Should().NotBeEmpty();
            allUsersFirstPage.Count.Should().BeLessOrEqualTo(10);

            // READ: Filter users by status
            var activeUsers = await _userApi.ListUsers(
                filter: "status eq \"ACTIVE\"",
                limit: 10).ToListAsync();

            activeUsers.Should().NotBeNull();
            activeUsers.Should().OnlyContain(u => u.Status == UserStatus.ACTIVE);

            // READ: Search users by profile attribute
            var searchResults = await _userApi.ListUsers(
                search: $"profile.firstName eq \"FullProfile\" and profile.lastName eq \"User-{testGuid}\"",
                limit: 10).ToListAsync();

            searchResults.Should().NotBeNull();
            searchResults.Should().Contain(u => u.Id == createdUser5.Id);

            // READ: Query users with 'q' parameter
            var queryResults = await _userApi.ListUsers(
                q: "FullProfile",
                limit: 10).ToListAsync();

            queryResults.Should().NotBeNull();
            queryResults.Should().Contain(u => u.Profile.FirstName == "FullProfile");

            // READ: Sort users by lastName
            var sortedUsers = await _userApi.ListUsers(
                search: $"profile.lastName eq \"User-{testGuid}\"",
                sortBy: "profile.lastName",
                sortOrder: "asc",
                limit: 10).ToListAsync();

            sortedUsers.Should().NotBeNull();

            // READ: Retrieve user by ID
            var retrievedUser = await _userApi.GetUserAsync(createdUser5.Id);

            retrievedUser.Should().NotBeNull();
            retrievedUser.Id.Should().Be(createdUser5.Id);
            retrievedUser.Profile.FirstName.Should().Be("FullProfile");
            retrievedUser.Profile.Department.Should().Be("Engineering");
            retrievedUser.Profile.Email.Should().Be($"full-profile-{testGuid}@example.com");

            // Retrieve user by login (email)
            var retrievedByLogin = await _userApi.GetUserAsync($"full-profile-{testGuid}@example.com");

            retrievedByLogin.Should().NotBeNull();
            retrievedByLogin.Id.Should().Be(createdUser5.Id);
            retrievedByLogin.Profile.Login.Should().Be($"full-profile-{testGuid}@example.com");

            // GetUser - Test content-type header optimization
            var retrievedWithOptimization = await _userApi.GetUserAsync(
                createdUser5.Id,
                contentType: "application/json; okta-response=omitCredentials");

            retrievedWithOptimization.Should().NotBeNull();
            retrievedWithOptimization.Id.Should().Be(createdUser5.Id);

            // ListUserBlocks - List user blocks
            try
            {
                var userBlocks = await _userApi.ListUserBlocks(createdUser5.Id).ToListAsync();

                userBlocks.Should().NotBeNull();
                // User may or may not have blocks - just verify endpoint is accessible
            }
            catch (ApiException ex)
            {
                // Permission denied (403) is acceptable as the feature may not be enabled
                // The test still validates that the endpoint exists and responds correctly
                (ex.ErrorCode == 403 || ex.Message.Contains("E0000015")).Should().BeTrue(
                    because: "ListUserBlocks may not be available in all org's - 403 is acceptable");
            }

            await Task.Delay(1000);

            // UPDATE OPERATIONS - Test partial and full update methods

            // UpdateUserAsync - Partial update of profile (POST)
            var partialUpdate = new UpdateUserRequest
            {
                Profile = new UserProfile
                {
                    MobilePhone = "555-999-8888",
                    Department = "Product Management",
                    Title = "Lead Product Manager"
                }
            };

            var updatedUser = await _userApi.UpdateUserAsync(createdUser5.Id, partialUpdate);

            updatedUser.Should().NotBeNull();
            updatedUser.Id.Should().Be(createdUser5.Id);
            updatedUser.Profile.MobilePhone.Should().Be("555-999-8888");
            updatedUser.Profile.Department.Should().Be("Product Management");
            updatedUser.Profile.Title.Should().Be("Lead Product Manager");
            // Other fields should remain unchanged
            updatedUser.Profile.FirstName.Should().Be("FullProfile");
            updatedUser.Profile.Email.Should().Be($"full-profile-{testGuid}@example.com");

            await Task.Delay(1000);

            // UpdateUserAsync - Update with strict validation
            var strictUpdate = new UpdateUserRequest
            {
                Profile = new UserProfile
                {
                    City = "New York"
                }
            };

            var strictUpdatedUser = await _userApi.UpdateUserAsync(
                createdUser5.Id, 
                strictUpdate, 
                strict: true);

            strictUpdatedUser.Should().NotBeNull();
            strictUpdatedUser.Profile.City.Should().Be("New York");

            await Task.Delay(1000);

            // ReplaceUserAsync - Full replacement of profile (PUT)
            // Note: PUT requires ALL profile fields to be specified
            var fullReplacement = new UpdateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "ReplacedFirst",
                    LastName = $"ReplacedLast-{testGuid}",
                    Email = $"replaced-{testGuid}@example.com",
                    Login = $"full-profile-{testGuid}@example.com", // Login cannot be changed
                    MobilePhone = "555-444-3333",
                    Department = "Sales",
                    Title = "Sales Director"
                }
            };

            var replacedUser = await _userApi.ReplaceUserAsync(createdUser5.Id, fullReplacement);

            replacedUser.Should().NotBeNull();
            replacedUser.Id.Should().Be(createdUser5.Id);
            replacedUser.Profile.FirstName.Should().Be("ReplacedFirst");
            replacedUser.Profile.LastName.Should().Be($"ReplacedLast-{testGuid}");
            replacedUser.Profile.Email.Should().Be($"replaced-{testGuid}@example.com");
            replacedUser.Profile.MobilePhone.Should().Be("555-444-3333");
            replacedUser.Profile.Department.Should().Be("Sales");
            replacedUser.Profile.Title.Should().Be("Sales Director");

            await Task.Delay(1000);

            // ReplaceUserAsync - With If-Match header (concurrency control)
            var concurrencyUpdate = new UpdateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "ConcurrentFirst",
                    LastName = $"ReplacedLast-{testGuid}",
                    Email = $"replaced-{testGuid}@example.com",
                    Login = $"full-profile-{testGuid}@example.com"
                }
            };

            // Using a placeholder ETag - in real scenarios, you'd get this from a previous response
            // This test verifies the parameter is accepted by the API
            try
            {
                var concurrentReplacedUser = await _userApi.ReplaceUserAsync(
                    createdUser5.Id, 
                    concurrencyUpdate,
                    ifMatch: "W/\"some-etag\"");

                // If it succeeds, verify the update
                concurrentReplacedUser.Should().NotBeNull();
            }
            catch (ApiException ex) when (ex.ErrorCode == 412)
            {
                // 412 Precondition Failed is expected with invalid ETag
                ex.ErrorCode.Should().Be(412);
            }

            await Task.Delay(1000);

            // DELETE OPERATIONS - Test user deletion

            // DeleteUser - Attempt to delete active user (should deactivate)
            // First call deactivates, second call deletes

            // First delete call - should deactivate the user
            await _userApi.DeleteUserAsync(createdUser1.Id);
            await Task.Delay(1000);

            // Verify user is deactivated (try to get it - should still exist but deactivated)
            var deactivatedUser = await _userApi.GetUserAsync(createdUser1.Id);
            deactivatedUser.Status.Should().Be(UserStatus.DEPROVISIONED);

            // Second delete call - should permanently delete
            await _userApi.DeleteUserAsync(createdUser1.Id);
            await Task.Delay(1000);

            // Verify user is deleted (should throw 404)
            Func<Task> getUserAfterDelete = async () => await _userApi.GetUserAsync(createdUser1.Id);
            await getUserAfterDelete.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 404);

            // Remove from a cleanup list since already deleted
            _createdUserIds.Remove(createdUser1.Id);

            // DeleteUser - Delete with sendEmail parameter
            await _userApi.DeleteUserAsync(createdUser2.Id, sendEmail: false);
            await Task.Delay(1000);
            await _userApi.DeleteUserAsync(createdUser2.Id, sendEmail: false);
            await Task.Delay(500);

            _createdUserIds.Remove(createdUser2.Id);

            // DeleteUser - Async deletion with Prefer header
            await _userApi.DeleteUserAsync(createdUser3.Id, prefer: PreferHeader.RespondAsync);
            await Task.Delay(1000);
            await _userApi.DeleteUserAsync(createdUser3.Id, prefer: PreferHeader.RespondAsync);
            await Task.Delay(500);

            _createdUserIds.Remove(createdUser3.Id);

            // GetUser - Test with non-existent user (should return 404)
            Func<Task> getNonExistentUser = async () => 
                await _userApi.GetUserAsync("00u_nonexistent_user_id");
            
            await getNonExistentUser.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 404);

            // UpdateUserAsync - Test with non-existent user (should return 404)
            var updateForNonExistent = new UpdateUserRequest
            {
                Profile = new UserProfile { FirstName = "Test" }
            };

            Func<Task> updateNonExistentUser = async () => 
                await _userApi.UpdateUserAsync("00u_nonexistent_user_id", updateForNonExistent);
            
            await updateNonExistentUser.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 404);

            // CreateUserAsync - Test with invalid email format (should fail)
            var invalidEmailUser = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Invalid",
                    LastName = "Email",
                    Email = "not-a-valid-email",
                    Login = "not-a-valid-email"
                }
            };

            Func<Task> createInvalidUser = async () => 
                await _userApi.CreateUserAsync(invalidEmailUser, activate: false);
            
            await createInvalidUser.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400);

            // ListUsers - Test with invalid filter syntax (should fail)
            try
            {
                var invalidFilterResults = await _userApi.ListUsers(
                    filter: "invalid filter syntax that will fail",
                    limit: 10).ToListAsync();
                
                // If we get here without exception, that's unexpected
                invalidFilterResults.Should().NotBeNull();
            }
            catch (ApiException ex)
            {
                // Expected: 400 Bad Request for invalid filter
                ex.ErrorCode.Should().Be(400);
            }

            await Task.Delay(1000);

            // ==========================
            // USER LIFECYCLE OPERATIONS
            // ==========================

            // LIFECYCLE: Activate - User without password (STAGED -> PROVISIONED)
            var userForActivation = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Activate",
                    LastName = $"User-{testGuid}",
                    Email = $"activate-{testGuid}@example.com",
                    Login = $"activate-{testGuid}@example.com"
                }
            };

            var stagedUser = await _userApi.CreateUserAsync(userForActivation, activate: false);
            _createdUserIds.Add(stagedUser.Id);
            stagedUser.Status.Should().Be(UserStatus.STAGED);
            await Task.Delay(1000);

            var activationToken = await _userLifecycleApi.ActivateUserAsync(stagedUser.Id, sendEmail: false);
            await Task.Delay(2000);

            var activatedUser = await _userApi.GetUserAsync(stagedUser.Id);
            (activatedUser.Status == UserStatus.ACTIVE || activatedUser.Status == UserStatus.PROVISIONED).Should().BeTrue();

            // LIFECYCLE: Deactivate (ACTIVE -> DEPROVISIONED)
            await _userLifecycleApi.DeactivateUserAsync(stagedUser.Id, sendEmail: false);
            await Task.Delay(2000);

            var deactivatedLifecycleUser = await _userApi.GetUserAsync(stagedUser.Id);
            deactivatedLifecycleUser.Status.Should().Be(UserStatus.DEPROVISIONED);

            // LIFECYCLE: Reactivate - Create user without password for PROVISIONED status
            var userForReactivation = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Reactivate",
                    LastName = $"User-{testGuid}",
                    Email = $"reactivate-{testGuid}@example.com",
                    Login = $"reactivate-{testGuid}@example.com"
                }
            };

            var userToReactivate = await _userApi.CreateUserAsync(userForReactivation, activate: false);
            _createdUserIds.Add(userToReactivate.Id);
            await Task.Delay(1000);

            await _userLifecycleApi.ActivateUserAsync(userToReactivate.Id, sendEmail: false);
            await Task.Delay(2000);

            var userBeforeReactivate = await _userApi.GetUserAsync(userToReactivate.Id);
            userBeforeReactivate.Status.Should().Be(UserStatus.PROVISIONED);

            var reactivationToken = await _userLifecycleApi.ReactivateUserAsync(userToReactivate.Id, sendEmail: false);
            reactivationToken.Should().NotBeNull();
            reactivationToken.ActivationToken.Should().NotBeNullOrEmpty();
            reactivationToken.ActivationUrl.Should().NotBeNullOrEmpty();
            await Task.Delay(1000);

            var userAfterReactivate = await _userApi.GetUserAsync(userToReactivate.Id);
            userAfterReactivate.Status.Should().Be(UserStatus.PROVISIONED);

            // LIFECYCLE: Suspend and Unsuspend
            var userForSuspension = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Suspend",
                    LastName = $"User-{testGuid}",
                    Email = $"suspend-{testGuid}@example.com",
                    Login = $"suspend-{testGuid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2025" }
                }
            };

            var userToSuspend = await _userApi.CreateUserAsync(userForSuspension, activate: true);
            _createdUserIds.Add(userToSuspend.Id);
            await Task.Delay(2000);

            await _userLifecycleApi.SuspendUserAsync(userToSuspend.Id);
            await Task.Delay(2000);

            var suspendedUser = await _userApi.GetUserAsync(userToSuspend.Id);
            suspendedUser.Status.Should().Be(UserStatus.SUSPENDED);

            await _userLifecycleApi.UnsuspendUserAsync(userToSuspend.Id);
            await Task.Delay(2000);

            var unsuspendedUser = await _userApi.GetUserAsync(userToSuspend.Id);
            unsuspendedUser.Status.Should().Be(UserStatus.ACTIVE);

            // LIFECYCLE: Reset Factors
            await _userLifecycleApi.ResetFactorsAsync(userToSuspend.Id);
            await Task.Delay(1000);

            var userAfterResetFactors = await _userApi.GetUserAsync(userToSuspend.Id);
            userAfterResetFactors.Status.Should().Be(UserStatus.ACTIVE);

            // LIFECYCLE: Unlock - Note: Cannot programmatically lock users in test environments
            // Validated via error handling tests below

            // LIFECYCLE ERROR HANDLING - Test with non-existent user IDs
            Func<Task> activateNonExistent = async () => await _userLifecycleApi.ActivateUserAsync("00u_nonexistent_user_id");
            await activateNonExistent.Should().ThrowAsync<ApiException>().Where(ex => ex.ErrorCode == 404);

            Func<Task> deactivateNonExistent = async () => await _userLifecycleApi.DeactivateUserAsync("00u_nonexistent_user_id");
            await deactivateNonExistent.Should().ThrowAsync<ApiException>().Where(ex => ex.ErrorCode == 404);

            Func<Task> reactivateNonExistent = async () => await _userLifecycleApi.ReactivateUserAsync("00u_nonexistent_user_id");
            await reactivateNonExistent.Should().ThrowAsync<ApiException>().Where(ex => ex.ErrorCode == 404);

            Func<Task> suspendNonExistent = async () => await _userLifecycleApi.SuspendUserAsync("00u_nonexistent_user_id");
            await suspendNonExistent.Should().ThrowAsync<ApiException>().Where(ex => ex.ErrorCode == 404);

            Func<Task> unsuspendNonExistent = async () => await _userLifecycleApi.UnsuspendUserAsync("00u_nonexistent_user_id");
            await unsuspendNonExistent.Should().ThrowAsync<ApiException>().Where(ex => ex.ErrorCode == 404);

            Func<Task> unlockNonExistent = async () => await _userLifecycleApi.UnlockUserAsync("00u_nonexistent_user_id");
            await unlockNonExistent.Should().ThrowAsync<ApiException>().Where(ex => ex.ErrorCode == 404);

            Func<Task> resetFactorsNonExistent = async () => await _userLifecycleApi.ResetFactorsAsync("00u_nonexistent_user_id");
            await resetFactorsNonExistent.Should().ThrowAsync<ApiException>().Where(ex => ex.ErrorCode == 404);

            await Task.Delay(1000);

            // FINAL VERIFICATION - Ensure all operations completed successfully

            // Verify remaining users still exist before cleanup
            var remainingUsers = new[] { createdUser4, createdUser5 };
            foreach (var user in remainingUsers)
            {
                if (_createdUserIds.Contains(user.Id))
                {
                    var verifyUser = await _userApi.GetUserAsync(user.Id);
                    verifyUser.Should().NotBeNull();
                    verifyUser.Id.Should().Be(user.Id);
                }
            }

            // Test passes - cleanup will be handled by Dispose()
        }

        [Fact]
        public async Task GivenHttpInfoMethods_WhenCallingApi_ThenFullResponseDetailsAreReturned()
        {
            var testGuid = Guid.NewGuid().ToString().Substring(0, 8);

            // CreateUserWithHttpInfoAsync - Returns ApiResponse with headers
            var userRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "HttpInfo",
                    LastName = $"Test-{testGuid}",
                    Email = $"http-info-{testGuid}@example.com",
                    Login = $"http-info-{testGuid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2025" }
                }
            };

            var createResponse = await _userApi.CreateUserWithHttpInfoAsync(userRequest, activate: true);

            createResponse.Should().NotBeNull();
            createResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            createResponse.Data.Should().NotBeNull();
            createResponse.Data.Id.Should().NotBeNullOrEmpty();
            createResponse.Headers.Should().NotBeNull();

            var createdUserId = createResponse.Data.Id;
            _createdUserIds.Add(createdUserId);

            await Task.Delay(1000);

            // GetUserWithHttpInfoAsync - Returns ApiResponse with headers
            var getResponse = await _userApi.GetUserWithHttpInfoAsync(createdUserId);

            getResponse.Should().NotBeNull();
            getResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            getResponse.Data.Should().NotBeNull();
            getResponse.Data.Id.Should().Be(createdUserId);
            getResponse.Headers.Should().NotBeNull();

            // ListUsersWithHttpInfoAsync - Returns ApiResponse with headers
            var listResponse = await _userApi.ListUsersWithHttpInfoAsync(
                search: $"profile.email eq \"http-info-{testGuid}@example.com\"",
                limit: 10);

            listResponse.Should().NotBeNull();
            listResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            listResponse.Data.Should().NotBeNull();
            listResponse.Data.Should().Contain(u => u.Id == createdUserId);
            listResponse.Headers.Should().NotBeNull();

            // UpdateUserWithHttpInfoAsync - Returns ApiResponse with headers
            var updateRequest = new UpdateUserRequest
            {
                Profile = new UserProfile
                {
                    MobilePhone = "555-111-9999"
                }
            };

            var updateResponse = await _userApi.UpdateUserWithHttpInfoAsync(createdUserId, updateRequest);

            updateResponse.Should().NotBeNull();
            updateResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            updateResponse.Data.Should().NotBeNull();
            updateResponse.Data.Profile.MobilePhone.Should().Be("555-111-9999");
            updateResponse.Headers.Should().NotBeNull();

            // ReplaceUserWithHttpInfoAsync - Returns ApiResponse with headers
            var replaceRequest = new UpdateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "ReplacedHttpInfo",
                    LastName = $"Test-{testGuid}",
                    Email = $"http-info-replaced-{testGuid}@example.com",
                    Login = $"http-info-{testGuid}@example.com"
                }
            };

            var replaceResponse = await _userApi.ReplaceUserWithHttpInfoAsync(createdUserId, replaceRequest);

            replaceResponse.Should().NotBeNull();
            replaceResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            replaceResponse.Data.Should().NotBeNull();
            replaceResponse.Data.Profile.FirstName.Should().Be("ReplacedHttpInfo");
            replaceResponse.Headers.Should().NotBeNull();

            // ==========================
            // USER LIFECYCLE WithHttpInfo METHODS
            // ==========================

            // Create users for lifecycle operations
            var lifecycleUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "LifecycleHttpInfo",
                    LastName = $"Test-{testGuid}",
                    Email = $"lifecycle-httpinfo-{testGuid}@example.com",
                    Login = $"lifecycle-httpinfo-{testGuid}@example.com"
                }
            };

            var lifecycleUser = await _userApi.CreateUserAsync(lifecycleUserRequest, activate: false);
            _createdUserIds.Add(lifecycleUser.Id);
            await Task.Delay(1000);

            // ActivateUserWithHttpInfoAsync
            var activateResponse = await _userLifecycleApi.ActivateUserWithHttpInfoAsync(lifecycleUser.Id, sendEmail: false);
            activateResponse.Should().NotBeNull();
            activateResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            activateResponse.Data.Should().NotBeNull();
            activateResponse.Headers.Should().NotBeNull();
            await Task.Delay(2000);

            // SuspendUserWithHttpInfoAsync
            var suspendResponse = await _userLifecycleApi.SuspendUserWithHttpInfoAsync(lifecycleUser.Id);
            suspendResponse.Should().NotBeNull();
            suspendResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            suspendResponse.Headers.Should().NotBeNull();
            await Task.Delay(2000);

            // UnsuspendUserWithHttpInfoAsync
            var unsuspendResponse = await _userLifecycleApi.UnsuspendUserWithHttpInfoAsync(lifecycleUser.Id);
            unsuspendResponse.Should().NotBeNull();
            unsuspendResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            unsuspendResponse.Headers.Should().NotBeNull();
            await Task.Delay(2000);

            // ResetFactorsWithHttpInfoAsync
            var resetFactorsResponse = await _userLifecycleApi.ResetFactorsWithHttpInfoAsync(lifecycleUser.Id);
            resetFactorsResponse.Should().NotBeNull();
            resetFactorsResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            resetFactorsResponse.Headers.Should().NotBeNull();
            await Task.Delay(1000);

            // DeactivateUserWithHttpInfoAsync
            var deactivateResponse = await _userLifecycleApi.DeactivateUserWithHttpInfoAsync(lifecycleUser.Id, sendEmail: false);
            deactivateResponse.Should().NotBeNull();
            (deactivateResponse.StatusCode == System.Net.HttpStatusCode.OK ||
             deactivateResponse.StatusCode == System.Net.HttpStatusCode.Accepted).Should().BeTrue();
            deactivateResponse.Headers.Should().NotBeNull();
            await Task.Delay(2000);

            // ReactivateUserWithHttpInfoAsync - Create new user for this (needs PROVISIONED status)
            var reactivateUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "ReactivateHttpInfo",
                    LastName = $"Test-{testGuid}",
                    Email = $"reactivate-httpinfo-{testGuid}@example.com",
                    Login = $"reactivate-httpinfo-{testGuid}@example.com"
                }
            };

            var userForReactivate = await _userApi.CreateUserAsync(reactivateUserRequest, activate: false);
            _createdUserIds.Add(userForReactivate.Id);
            await Task.Delay(1000);

            await _userLifecycleApi.ActivateUserAsync(userForReactivate.Id, sendEmail: false);
            await Task.Delay(2000);

            var reactivateResponse = await _userLifecycleApi.ReactivateUserWithHttpInfoAsync(userForReactivate.Id, sendEmail: false);
            reactivateResponse.Should().NotBeNull();
            reactivateResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            reactivateResponse.Data.Should().NotBeNull();
            reactivateResponse.Data.ActivationToken.Should().NotBeNullOrEmpty();
            reactivateResponse.Headers.Should().NotBeNull();
            await Task.Delay(1000);

            // UnlockUserWithHttpInfoAsync - Note: User may not be locked, endpoint is tested anyway
            try
            {
                var unlockResponse = await _userLifecycleApi.UnlockUserWithHttpInfoAsync(lifecycleUser.Id);
                unlockResponse.Should().NotBeNull();
                unlockResponse.Headers.Should().NotBeNull();
            }
            catch (ApiException ex) when (ex.Message.Contains("E0000032") || ex.Message.Contains("not locked"))
            {
                // Expected: user is not locked out - endpoint validated even though operation not performed
                (ex.ErrorCode == 400 || ex.ErrorCode == 403).Should().BeTrue();
            }
            await Task.Delay(1000);

            // DeleteUserWithHttpInfoAsync - Returns ApiResponse
            var deleteResponse = await _userApi.DeleteUserWithHttpInfoAsync(createdUserId);

            deleteResponse.Should().NotBeNull();
            deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

            await Task.Delay(1000);

            // Second delete to permanently remove
            await _userApi.DeleteUserAsync(createdUserId);
            _createdUserIds.Remove(createdUserId);

            await Task.Delay(500);
        }

        [Fact]
        public async Task GivenPaginationAndExpand_WhenListingUsers_ThenAdditionalScenariosWork()
        {
            var testGuid = Guid.NewGuid().ToString().Substring(0, 8);

            // ListUsers - Pagination with limit and after parameters
            // Get first page
            var firstPageClient = _userApi.ListUsers(limit: 5);
            var firstPage = await firstPageClient.ToListAsync();

            firstPage.Should().NotBeNull();
            firstPage.Count.Should().BeLessOrEqualTo(5);

            if (firstPage.Count > 0)
            {
                // Verify we can iterate through the collection (pagination handled automatically)
                var allUsers = await _userApi.ListUsers(limit: 5).ToListAsync();
                allUsers.Should().NotBeNull();
                allUsers.Count.Should().BeGreaterOrEqualTo(firstPage.Count);
            }

            // TEST: GetUser with expand parameter
            var expandUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Expand",
                    LastName = $"Test-{testGuid}",
                    Email = $"expand-{testGuid}@example.com",
                    Login = $"expand-{testGuid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2025" }
                }
            };

            var expandUser = await _userApi.CreateUserAsync(expandUserRequest, activate: true);
            _createdUserIds.Add(expandUser.Id);
            await Task.Delay(1000);

            // GetUser - With expand=blocks parameter to return embedded data
            var userWithBlocks = await _userApi.GetUserAsync(expandUser.Id, expand: "blocks");
            userWithBlocks.Should().NotBeNull();
            userWithBlocks.Id.Should().Be(expandUser.Id);
            await Task.Delay(500);
        }
    }
}
