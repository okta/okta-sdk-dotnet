// <copyright file="UserSessionsApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    [Collection(nameof(UserSessionsApiTests))]
    public class UserSessionsApiTests : IDisposable
    {
        private readonly UserSessionsApi _userSessionsApi = new();
        private readonly UserApi _userApi = new();
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

        [Fact]
        public async Task GivenUserSessions_WhenPerformingCrudOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();

            // Create test user
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "UserSessions",
                    LastName = $"Test{guid.ToString().Substring(0, 8)}",
                    Email = $"user-sessions-test-{guid}@example.com",
                    Login = $"user-sessions-test-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "ComplexP@ssw0rd!2024" }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);

            createdUser.Should().NotBeNull();
            createdUser.Id.Should().NotBeNullOrEmpty();

            await Task.Delay(2000);

            // RevokeUserSessionsAsync - Revoke all sessions (no OAuth tokens, no forgotten devices)
            // This is idempotent - works even if user has no active sessions
            await _userSessionsApi.RevokeUserSessionsAsync(createdUser.Id);

            await Task.Delay(1000);

            // RevokeUserSessionsAsync - Revoke with OAuth tokens
            await _userSessionsApi.RevokeUserSessionsAsync(createdUser.Id, oauthTokens: true);

            await Task.Delay(1000);

            // RevokeUserSessionsAsync - Revoke with forgotten devices
            await _userSessionsApi.RevokeUserSessionsAsync(createdUser.Id, forgetDevices: true);

            await Task.Delay(1000);

            // RevokeUserSessionsAsync - Revoke with both OAuth tokens and forget devices
            await _userSessionsApi.RevokeUserSessionsAsync(
                createdUser.Id,
                oauthTokens: true,
                forgetDevices: true
            );

            // Note: EndUserSessionsAsync requires a session cookie and cannot be tested with API tokens
            // It's designed for browser-based apps where the user is currently signed in
        }

        [Fact]
        public async Task GivenHttpInfoMethods_WhenCallingApi_ThenHttpMetadataIsReturned()
        {
            var guid = Guid.NewGuid();

            // Create test user
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "UserSessions",
                    LastName = $"HttpInfo{guid.ToString().Substring(0, 8)}",
                    Email = $"user-sessions-http-{guid}@example.com",
                    Login = $"user-sessions-http-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "ComplexP@ssw0rd!2024" }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);

            await Task.Delay(2000);

            // RevokeUserSessionsWithHttpInfoAsync - Revoke sessions with HTTP metadata
            var revokeResponse = await _userSessionsApi.RevokeUserSessionsWithHttpInfoAsync(createdUser.Id);

            revokeResponse.Should().NotBeNull();
            revokeResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
            revokeResponse.Headers.Should().NotBeNull();

            await Task.Delay(1000);

            // RevokeUserSessionsWithHttpInfoAsync - Revoke with OAuth tokens
            var revokeWithTokensResponse = await _userSessionsApi.RevokeUserSessionsWithHttpInfoAsync(
                createdUser.Id,
                oauthTokens: true
            );

            revokeWithTokensResponse.Should().NotBeNull();
            revokeWithTokensResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
            revokeWithTokensResponse.Headers.Should().NotBeNull();

            await Task.Delay(1000);

            // RevokeUserSessionsWithHttpInfoAsync - Revoke with forgotten devices
            var revokeWithForgetResponse = await _userSessionsApi.RevokeUserSessionsWithHttpInfoAsync(
                createdUser.Id,
                forgetDevices: true
            );

            revokeWithForgetResponse.Should().NotBeNull();
            revokeWithForgetResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
            revokeWithForgetResponse.Headers.Should().NotBeNull();

            await Task.Delay(1000);

            // RevokeUserSessionsWithHttpInfoAsync - Revoke with both parameters
            var revokeWithBothResponse = await _userSessionsApi.RevokeUserSessionsWithHttpInfoAsync(
                createdUser.Id,
                oauthTokens: true,
                forgetDevices: true
            );

            revokeWithBothResponse.Should().NotBeNull();
            revokeWithBothResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
            revokeWithBothResponse.Headers.Should().NotBeNull();

            // Note: EndUserSessionsWithHttpInfoAsync requires a session cookie 
            // and cannot be tested with API tokens
        }

        [Fact]
        public async Task GivenErrorScenarios_WhenCallingApi_ThenApiExceptionIsThrown()
        {
            const string invalidUserId = "invalid_user_id_12345";

            // RevokeUserSessionsAsync with invalid userId - should throw 404
            var revokeException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userSessionsApi.RevokeUserSessionsAsync(invalidUserId);
            });
            revokeException.ErrorCode.Should().Be(404);

            // RevokeUserSessionsAsync with invalid userId and parameters - should throw 404
            var revokeWithParamsException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userSessionsApi.RevokeUserSessionsAsync(
                    invalidUserId,
                    oauthTokens: true,
                    forgetDevices: true
                );
            });
            revokeWithParamsException.ErrorCode.Should().Be(404);

            // RevokeUserSessionsWithHttpInfoAsync with invalid userId - should throw 404
            var revokeHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userSessionsApi.RevokeUserSessionsWithHttpInfoAsync(invalidUserId);
            });
            revokeHttpInfoException.ErrorCode.Should().Be(404);

            // RevokeUserSessionsWithHttpInfoAsync with invalid userId and parameters - should throw 404
            var revokeHttpInfoWithParamsException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userSessionsApi.RevokeUserSessionsWithHttpInfoAsync(
                    invalidUserId,
                    oauthTokens: true,
                    forgetDevices: true
                );
            });
            revokeHttpInfoWithParamsException.ErrorCode.Should().Be(404);

            // EndUserSessionsAsync - Cannot be tested with API tokens
            // This endpoint requires a session cookie, so it will always fail with API token authentication
            // The expected behavior is a 401 or 403 error
            var endSessionException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userSessionsApi.EndUserSessionsAsync();
            });
            endSessionException.ErrorCode.Should().BeOneOf(401, 403);

            // EndUserSessionsWithHttpInfoAsync - Cannot be tested with API tokens
            var endSessionHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userSessionsApi.EndUserSessionsWithHttpInfoAsync();
            });
            endSessionHttpInfoException.ErrorCode.Should().BeOneOf(401, 403);

            // EndUserSessionsAsync with keepCurrent parameter - Cannot be tested with API tokens
            var endSessionWithParamException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userSessionsApi.EndUserSessionsAsync(keepCurrent: new KeepCurrent { _KeepCurrent = false });
            });
            endSessionWithParamException.ErrorCode.Should().BeOneOf(401, 403);

            // EndUserSessionsWithHttpInfoAsync with keepCurrent parameter - Cannot be tested with API tokens
            var endSessionHttpInfoWithParamException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userSessionsApi.EndUserSessionsWithHttpInfoAsync(keepCurrent: new KeepCurrent { _KeepCurrent = true });
            });
            endSessionHttpInfoWithParamException.ErrorCode.Should().BeOneOf(401, 403);
        }
    }
}
