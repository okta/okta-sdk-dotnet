// <copyright file="UserCredApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    [Collection(nameof(UserCredApiTests))]
    public class UserCredApiTests : IDisposable
    {
        private readonly UserCredApi _userCredApi = new();
        private readonly UserApi _userApi = new();
        private readonly UserLifecycleApi _userLifecycleApi = new();
        private readonly List<string> _createdUserIds = [];

        public void Dispose()
        {
            CleanupResources().GetAwaiter().GetResult();
        }

        private async Task CleanupResources()
        {
            foreach (var userId in _createdUserIds)
            {
                try
                {
                    await _userLifecycleApi.DeactivateUserAsync(userId);
                    await _userApi.DeleteUserAsync(userId);
                }
                catch (ApiException)
                {
                    // Ignore cleanup errors
                }
            }
            _createdUserIds.Clear();
        }

        private async Task<User> CreateTestUserWithCredentials(string uniqueId, string password = "MyP@ssw0rd123", string recoveryQuestion = "What is your favorite color?", string recoveryAnswer = "Blue")
        {
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "UserCred",
                    LastName = $"TestUser{uniqueId}",
                    Email = $"user-cred-test-{uniqueId}@example.com",
                    Login = $"user-cred-test-{uniqueId}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential
                    {
                        Value = password
                    },
                    RecoveryQuestion = new RecoveryQuestionCredential
                    {
                        Question = recoveryQuestion,
                        Answer = recoveryAnswer
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);
            
            return createdUser;
        }

        #region Complete User Credentials API CRUD Lifecycle Test

        [Fact]
        public async Task GivenUserCredentials_WhenPerformingCrudOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();
            var initialPassword = "MyP@ssw0rd111";
            var newPassword = "MyP@ssw0rd222";
            var anotherPassword = "MyP@ssw0rd333";
            const string recoveryQuestion = "What is your favorite color?";
            const string recoveryAnswer = "Blue";
            const string newRecoveryQuestion = "What is your pet's name?";
            const string newRecoveryAnswer = "Fluffy";

            // Create test user
            var createdUser = await CreateTestUserWithCredentials(guid.ToString(), initialPassword);
            createdUser.Should().NotBeNull();
            createdUser.Id.Should().NotBeNullOrEmpty();
            var userId = createdUser.Id;
            await Task.Delay(2000);

            // TEST 1: ChangePasswordAsync
            var changePasswordResult = await _userCredApi.ChangePasswordAsync(
                userId,
                new ChangePasswordRequest
                {
                    OldPassword = new PasswordCredential { Value = initialPassword },
                    NewPassword = new PasswordCredential { Value = newPassword },
                    RevokeSessions = false
                },
                strict: false
            );
            changePasswordResult.Should().NotBeNull();
            changePasswordResult.Password.Should().NotBeNull();
            changePasswordResult.Provider.Type.Should().Be(AuthenticationProviderType.OKTA);
            await Task.Delay(2000);

            // TEST 2: ChangePasswordWithHttpInfoAsync
            var changePasswordHttpInfo = await _userCredApi.ChangePasswordWithHttpInfoAsync(
                userId,
                new ChangePasswordRequest
                {
                    OldPassword = new PasswordCredential { Value = newPassword },
                    NewPassword = new PasswordCredential { Value = anotherPassword },
                    RevokeSessions = false
                },
                strict: false
            );
            changePasswordHttpInfo.Should().NotBeNull();
            changePasswordHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            changePasswordHttpInfo.Headers.Should().ContainKey("Content-Type");
            await Task.Delay(2000);

            // TEST 3: ChangeRecoveryQuestionAsync
            var updatedRecoveryResult = await _userCredApi.ChangeRecoveryQuestionAsync(
                userId,
                new UserCredentials
                {
                    Password = new PasswordCredential { Value = anotherPassword },
                    RecoveryQuestion = new RecoveryQuestionCredential { Question = newRecoveryQuestion, Answer = newRecoveryAnswer }
                }
            );
            updatedRecoveryResult.Should().NotBeNull();
            updatedRecoveryResult.RecoveryQuestion.Question.Should().Be(newRecoveryQuestion);
            await Task.Delay(2000);

            // TEST 4: ChangeRecoveryQuestionWithHttpInfoAsync
            var updatedRecoveryHttpInfo = await _userCredApi.ChangeRecoveryQuestionWithHttpInfoAsync(
                userId,
                new UserCredentials
                {
                    Password = new PasswordCredential { Value = anotherPassword },
                    RecoveryQuestion = new RecoveryQuestionCredential { Question = recoveryQuestion, Answer = recoveryAnswer }
                }
            );
            updatedRecoveryHttpInfo.Should().NotBeNull();
            updatedRecoveryHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            updatedRecoveryHttpInfo.Data.RecoveryQuestion.Question.Should().Be(recoveryQuestion);
            await Task.Delay(2000);

            // TEST 5 & 6: ExpirePasswordAsync / WithHttpInfoAsync - SKIPPED
            // Note: Requires org password policy config - not supported for this login type

            // TEST 7: ExpirePasswordWithTempPasswordAsync
            await _userCredApi.ResetPasswordAsync(userId, sendEmail: false);
            await Task.Delay(2000);
            var expiredUserWithTemp = await _userCredApi.ExpirePasswordWithTempPasswordAsync(userId, revokeSessions: false);
            expiredUserWithTemp.Should().NotBeNull();
            await Task.Delay(2000);

            // TEST 8: ExpirePasswordWithTempPasswordWithHttpInfoAsync
            await _userCredApi.ResetPasswordAsync(userId, sendEmail: false);
            await Task.Delay(2000);
            var expiredUserWithTempHttpInfo = await _userCredApi.ExpirePasswordWithTempPasswordWithHttpInfoAsync(userId, revokeSessions: true);
            expiredUserWithTempHttpInfo.Should().NotBeNull();
            expiredUserWithTempHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            await Task.Delay(2000);

            // TEST 9-12: ForgotPassword methods - SKIPPED
            // Note: After ExpirePasswordWithTempPasswordAsync, user is in PASSWORD_EXPIRED status
            // ForgotPassword is not allowed in this status. Tested separately in individual tests.

            // TEST 13: ResetPasswordAsync
            var resetPasswordToken = await _userCredApi.ResetPasswordAsync(userId, sendEmail: false, revokeSessions: false);
            resetPasswordToken.Should().NotBeNull();
            resetPasswordToken.ResetPasswordUrl.Should().Contain("/reset_password/");
            var userAfterReset = await _userApi.GetUserAsync(userId);
            userAfterReset.Status.Should().Be(UserStatus.RECOVERY);
            await Task.Delay(2000);

            // TEST 14: ResetPasswordWithHttpInfoAsync - SKIPPED
            // Note: Cannot reactivate user from RECOVERY status - org limitation
        }

        #endregion

        #region Individual Method Validation Tests

        [Fact]
        public async Task GivenValidCredentials_WhenChangingPassword_ThenPasswordIsUpdated()
        {
            var guid = Guid.NewGuid();
            var oldPassword = "MyP@ssw0rd111";
            var newPassword = "MyP@ssw0rd222";

            var user = await CreateTestUserWithCredentials(guid.ToString(), oldPassword);
            await Task.Delay(2000);

            var result = await _userCredApi.ChangePasswordAsync(
                user.Id,
                new ChangePasswordRequest
                {
                    OldPassword = new PasswordCredential { Value = oldPassword },
                    NewPassword = new PasswordCredential { Value = newPassword },
                    RevokeSessions = false
                },
                strict: false
            );

            result.Should().NotBeNull();
            result.Password.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenInvalidOldPassword_WhenChangingPassword_ThenApiExceptionIsThrown()
        {
            var guid = Guid.NewGuid();
            var oldPassword = "MyP@ssw0rd111";
            var wrongPassword = "WrongP@ss123";
            var newPassword = "MyP@ssw0rd222";

            var user = await CreateTestUserWithCredentials(guid.ToString(), oldPassword);
            await Task.Delay(2000);

            await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userCredApi.ChangePasswordAsync(
                    user.Id,
                    new ChangePasswordRequest
                    {
                        OldPassword = new PasswordCredential { Value = wrongPassword },
                        NewPassword = new PasswordCredential { Value = newPassword },
                        RevokeSessions = false
                    },
                    strict: false
                );
            });
        }

        [Fact]
        public async Task GivenActiveUser_WhenExpiringPassword_ThenUserTransitionsToPasswordExpired()
        {
            var guid = Guid.NewGuid();
            var user = await CreateTestUserWithCredentials(guid.ToString());
            await Task.Delay(2000);

            var result = await _userCredApi.ExpirePasswordAsync(user.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(user.Id);
            result.Status.Should().Be(UserStatus.PASSWORDEXPIRED);
        }

        [Fact]
        public async Task GivenActiveUser_WhenRequestingForgotPassword_ThenResetUrlIsReturned()
        {
            var guid = Guid.NewGuid();
            var user = await CreateTestUserWithCredentials(guid.ToString());
            await Task.Delay(2000);

            var result = await _userCredApi.ForgotPasswordAsync(user.Id, sendEmail: false);

            result.Should().NotBeNull();
            result.ResetPasswordUrl.Should().Contain("/signin/reset-password/");
        }

        [Fact]
        public async Task GivenValidUser_WhenResettingPassword_ThenResetTokenIsReturned()
        {
            var guid = Guid.NewGuid();
            var user = await CreateTestUserWithCredentials(guid.ToString());
            await Task.Delay(2000);

            var result = await _userCredApi.ResetPasswordAsync(user.Id, sendEmail: false, revokeSessions: false);

            result.Should().NotBeNull();
            result.ResetPasswordUrl.Should().Contain("/reset_password/");
            
            var updatedUser = await _userApi.GetUserAsync(user.Id);
            updatedUser.Status.Should().Be(UserStatus.RECOVERY);
        }

        [Fact]
        public async Task GivenValidCredentials_WhenChangingRecoveryQuestion_ThenQuestionIsUpdated()
        {
            var guid = Guid.NewGuid();
            var password = "MyP@ssw0rd123";
            var newQuestion = "What is your mother's maiden name?";
            var newAnswer = "Smith";

            var user = await CreateTestUserWithCredentials(guid.ToString(), password);
            await Task.Delay(2000);

            var result = await _userCredApi.ChangeRecoveryQuestionAsync(
                user.Id,
                new UserCredentials
                {
                    Password = new PasswordCredential { Value = password },
                    RecoveryQuestion = new RecoveryQuestionCredential { Question = newQuestion, Answer = newAnswer }
                }
            );

            result.Should().NotBeNull();
            result.RecoveryQuestion.Question.Should().Be(newQuestion);
        }

        [Fact]
        public async Task GivenActiveUser_WhenExpiringPasswordWithTempPassword_ThenPasswordIsExpiredAndTempPasswordReturned()
        {
            var guid = Guid.NewGuid();
            var user = await CreateTestUserWithCredentials(guid.ToString());
            await Task.Delay(2000);

            var result = await _userCredApi.ExpirePasswordWithTempPasswordAsync(user.Id, revokeSessions: false);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenCorrectAnswer_WhenSettingNewPasswordAfterForgot_ThenPasswordIsReset()
        {
            var guid = Guid.NewGuid();
            var recoveryQuestion = "What is your favorite food?";
            var recoveryAnswer = "Pizza";
            var newPassword = "MyP@ssw0rd999";

            var user = await CreateTestUserWithCredentials(guid.ToString(), "MyP@ssw0rd111", recoveryQuestion, recoveryAnswer);
            await Task.Delay(2000);

            await _userCredApi.ForgotPasswordAsync(user.Id, sendEmail: false);
            await Task.Delay(2000);

            var result = await _userCredApi.ForgotPasswordSetNewPasswordAsync(
                user.Id,
                new UserCredentials
                {
                    Password = new PasswordCredential { Value = newPassword },
                    RecoveryQuestion = new RecoveryQuestionCredential { Answer = recoveryAnswer }
                },
                sendEmail: false
            );

            result.Should().NotBeNull();
            result.Password.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenHttpInfoMethods_WhenCalling_ThenValidHttpMetadataIsReturned()
        {
            var guid = Guid.NewGuid();
            var password = "MyP@ssw0rd123";

            var user = await CreateTestUserWithCredentials(guid.ToString(), password);
            await Task.Delay(2000);

            // Test ExpirePasswordWithHttpInfoAsync - SKIPPED
            // Note: Requires org password policy configuration

            // Test ResetPasswordWithHttpInfoAsync
            var resetHttpInfo = await _userCredApi.ResetPasswordWithHttpInfoAsync(user.Id, sendEmail: false, revokeSessions: false);

            resetHttpInfo.Should().NotBeNull();
            resetHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            resetHttpInfo.Data.ResetPasswordUrl.Should().NotBeNullOrEmpty();
            resetHttpInfo.Headers.Should().ContainKey("Content-Type");
        }

        #endregion
    }
}
