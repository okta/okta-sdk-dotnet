// <copyright file="UserOAuthApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    [Collection(nameof(UserOAuthApiTests))]
    public class UserOAuthApiTests : IDisposable
    {
        private readonly UserApi _userApi = new();
        private readonly ApplicationApi _applicationApi = new();
        private readonly UserOAuthApi _userOAuthApi = new();
        private readonly List<string> _createdUserIds = [];
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
                catch (ApiException) { }
            }
            _createdAppIds.Clear();

            foreach (var userId in _createdUserIds)
            {
                try
                {
                    await _userApi.DeleteUserAsync(userId);
                    await _userApi.DeleteUserAsync(userId);
                }
                catch (ApiException) { }
            }
            _createdUserIds.Clear();
        }

        [Fact]
        public async Task GivenUserOAuth_WhenPerformingCrudOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);

            // LIST: ListRefreshTokensForUserAndClient
            var tokens = await _userOAuthApi.ListRefreshTokensForUserAndClient(user.Id, clientId).ToListAsync();
            tokens.Should().NotBeNull();

            // LIST with pagination: expand and limit parameters
            var tokensWithParams = await _userOAuthApi.ListRefreshTokensForUserAndClient(
                user.Id, clientId, expand: "scope", limit: 20).ToListAsync();
            tokensWithParams.Should().NotBeNull();

            // GET: GetRefreshTokenForUserAndClient - test with non-existent token
            var fakeTokenId = GenerateFakeTokenId();
            var getException = await Assert.ThrowsAsync<ApiException>(
                () => _userOAuthApi.GetRefreshTokenForUserAndClientAsync(user.Id, clientId, fakeTokenId));
            getException.ErrorCode.Should().Be(404);

            // GET with expanded parameter
            var getExpandException = await Assert.ThrowsAsync<ApiException>(
                () => _userOAuthApi.GetRefreshTokenForUserAndClientAsync(user.Id, clientId, fakeTokenId, expand: "scope"));
            getExpandException.ErrorCode.Should().Be(404);

            // DELETE single: RevokeTokenForUserAndClient
            var revokeException = await Assert.ThrowsAsync<ApiException>(
                () => _userOAuthApi.RevokeTokenForUserAndClientAsync(user.Id, clientId, fakeTokenId));
            revokeException.ErrorCode.Should().Be(404);

            // DELETE all: RevokeTokensForUserAndClient
            await _userOAuthApi.RevokeTokensForUserAndClientAsync(user.Id, clientId);
        }

        [Fact]
        public async Task GivenNoTokens_WhenListingRefreshTokens_ThenEmptyResultsAreHandled()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);

            var tokens = await _userOAuthApi.ListRefreshTokensForUserAndClient(user.Id, clientId).ToListAsync();

            tokens.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenFilters_WhenListingRefreshTokens_ThenFiltersAreApplied()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);

            var tokensExpanded = await _userOAuthApi.ListRefreshTokensForUserAndClient(
                user.Id, clientId, expand: "scope", limit: 5).ToListAsync();
            tokensExpanded.Should().NotBeNull();

            var tokensLimited = await _userOAuthApi.ListRefreshTokensForUserAndClient(
                user.Id, clientId, limit: 10).ToListAsync();
            tokensLimited.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenNonExistentToken_WhenGettingRefreshToken_Then404IsReturned()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);
            var fakeTokenId = GenerateFakeTokenId();

            var exception = await Assert.ThrowsAsync<ApiException>(
                () => _userOAuthApi.GetRefreshTokenForUserAndClientAsync(user.Id, clientId, fakeTokenId));

            exception.ErrorCode.Should().Be(404);
            exception.Message.Should().Contain("Not found");
        }

        [Fact]
        public async Task GivenNonExistentToken_WhenGettingRefreshTokenWithExpand_Then404IsReturned()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);
            var fakeTokenId = GenerateFakeTokenId();

            var exception = await Assert.ThrowsAsync<ApiException>(
                () => _userOAuthApi.GetRefreshTokenForUserAndClientAsync(user.Id, clientId, fakeTokenId, expand: "scope"));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GivenNonExistentToken_WhenRevokingToken_Then404IsReturned()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);
            var fakeTokenId = GenerateFakeTokenId();

            var exception = await Assert.ThrowsAsync<ApiException>(
                () => _userOAuthApi.RevokeTokenForUserAndClientAsync(user.Id, clientId, fakeTokenId));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GivenUser_WhenRevokingAllTokens_ThenOperationSucceeds()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);

            await _userOAuthApi.RevokeTokensForUserAndClientAsync(user.Id, clientId);
        }

        [Fact]
        public async Task GivenHttpInfoMethod_WhenListingRefreshTokens_ThenMetadataIsReturned()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);

            var response = await _userOAuthApi.ListRefreshTokensForUserAndClientWithHttpInfoAsync(
                user.Id, clientId, expand: "scope", limit: 10);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Headers.Should().NotBeNull();
            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenNonExistentToken_WhenGettingRefreshTokenWithHttpInfo_Then404IsReturned()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);
            var fakeTokenId = GenerateFakeTokenId();

            var exception = await Assert.ThrowsAsync<ApiException>(
                () => _userOAuthApi.GetRefreshTokenForUserAndClientWithHttpInfoAsync(user.Id, clientId, fakeTokenId));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GivenNonExistentToken_WhenGettingRefreshTokenWithHttpInfoAndExpand_Then404IsReturned()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);
            var fakeTokenId = GenerateFakeTokenId();

            var exception = await Assert.ThrowsAsync<ApiException>(
                () => _userOAuthApi.GetRefreshTokenForUserAndClientWithHttpInfoAsync(
                    user.Id, clientId, fakeTokenId, expand: "scope"));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GivenNonExistentToken_WhenRevokingTokenWithHttpInfo_Then404IsReturned()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);
            var fakeTokenId = GenerateFakeTokenId();

            var exception = await Assert.ThrowsAsync<ApiException>(
                () => _userOAuthApi.RevokeTokenForUserAndClientWithHttpInfoAsync(user.Id, clientId, fakeTokenId));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GivenUser_WhenRevokingAllTokensWithHttpInfo_ThenOperationSucceeds()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);

            var response = await _userOAuthApi.RevokeTokensForUserAndClientWithHttpInfoAsync(user.Id, clientId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            response.Headers.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenInvalidUserId_WhenCallingApi_Then404IsReturned()
        {
            var invalidUserId = GenerateFakeUserId();
            var invalidClientId = GenerateFakeClientId();

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
                await _userOAuthApi.ListRefreshTokensForUserAndClient(invalidUserId, invalidClientId).ToListAsync());

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GivenInvalidClientId_WhenCallingApi_Then404IsReturned()
        {
            var guid = Guid.NewGuid();
            var user = await CreateTestUser(guid);
            var invalidClientId = GenerateFakeClientId();

            var exception = await Assert.ThrowsAsync<ApiException>(
                () => _userOAuthApi.ListRefreshTokensForUserAndClientWithHttpInfoAsync(user.Id, invalidClientId));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GivenInvalidTokenId_WhenCallingApi_Then404IsReturned()
        {
            var guid = Guid.NewGuid();
            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);
            var invalidTokenId = GenerateFakeTokenId();

            var exception = await Assert.ThrowsAsync<ApiException>(
                () => _userOAuthApi.GetRefreshTokenForUserAndClientAsync(user.Id, clientId, invalidTokenId));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GivenMultipleOperations_WhenExecutingInSequence_ThenAllOperationsWork()
        {
            var guid = Guid.NewGuid();

            var user = await CreateTestUser(guid);
            var clientId = await CreateOAuthApp(guid);

            // List tokens
            var tokens1 = await _userOAuthApi.ListRefreshTokensForUserAndClient(user.Id, clientId).ToListAsync();
            tokens1.Should().NotBeNull();

            // List with HttpInfo
            var response = await _userOAuthApi.ListRefreshTokensForUserAndClientWithHttpInfoAsync(user.Id, clientId);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Revoke all tokens
            await _userOAuthApi.RevokeTokensForUserAndClientAsync(user.Id, clientId);

            // List again after revoke
            var tokens2 = await _userOAuthApi.ListRefreshTokensForUserAndClient(user.Id, clientId).ToListAsync();
            tokens2.Should().NotBeNull();
        }

        private async Task<User> CreateTestUser(Guid guid)
        {
            const int maxRetries = 3;
            const int retryDelay = 2000;

            for (var attempt = 0; attempt < maxRetries; attempt++)
            {
                try
                {
                    var user = await _userApi.CreateUserAsync(new CreateUserRequest
                    {
                        Profile = new UserProfile
                        {
                            FirstName = "UserOAuth",
                            LastName = $"Test{guid.ToString().Substring(0, 8)}",
                            Email = $"useroauth-{guid}@example.com",
                            Login = $"useroauth-{guid}@example.com"
                        },
                        Credentials = new UserCredentialsWritable
                        {
                            Password = new PasswordCredential { Value = "ComplexP@ssw0rd!2024" }
                        }
                    }, activate: true);

                    _createdUserIds.Add(user.Id);

                    user.Should().NotBeNull();
                    user.Id.Should().NotBeNullOrEmpty();
                    user.Status.Should().Be(UserStatus.ACTIVE);

                    await Task.Delay(2000);
                    return user;
                }
                catch (TimeoutException) when (attempt < maxRetries - 1)
                {
                    // Wait with exponential backoff before retrying
                    await Task.Delay(retryDelay * (attempt + 1));
                }
                catch (TaskCanceledException) when (attempt < maxRetries - 1)
                {
                    // Wait with exponential backoff before retrying
                    await Task.Delay(retryDelay * (attempt + 1));
                }
            }

            // If we get here, all retries failed
            throw new InvalidOperationException($"Failed to create test user after {maxRetries} attempts");
        }

        private async Task<string> CreateOAuthApp(Guid guid)
        {
            int maxRetries = 3;
            int retryDelay = 2000;

            for (int attempt = 0; attempt < maxRetries; attempt++)
            {
                try
                {
                    var app = await _applicationApi.CreateApplicationAsync(new OpenIdConnectApplication
                    {
                        Name = "oidc_client",
                        Label = $"SDK-OAuth-{guid.ToString().Substring(0, 8)}",
                        SignOnMode = ApplicationSignOnMode.OPENIDCONNECT,
                        Credentials = new OAuthApplicationCredentials
                        {
                            OauthClient = new ApplicationCredentialsOAuthClient
                            {
                                TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretBasic,
                                AutoKeyRotation = true
                            }
                        },
                        Settings = new OpenIdConnectApplicationSettings
                        {
                            OauthClient = new OpenIdConnectApplicationSettingsClient
                            {
                                ClientUri = "https://example.com",
                                RedirectUris = ["https://example.com/oauth2/callback"],
                                ResponseTypes = [OAuthResponseType.Code],
                                GrantTypes = [GrantType.AuthorizationCode, GrantType.RefreshToken],
                                ApplicationType = OpenIdConnectApplicationType.Web
                            }
                        }
                    }, activate: true);

                    _createdAppIds.Add(app.Id);

                    app.Should().NotBeNull();
                    app.Id.Should().NotBeNullOrEmpty();
                    app.Status.Should().Be(ApplicationLifecycleStatus.ACTIVE);

                    await Task.Delay(2000);
                    return app.Id;
                }
                catch (TimeoutException) when (attempt < maxRetries - 1)
                {
                    // Wait with exponential backoff before retrying
                    await Task.Delay(retryDelay * (attempt + 1));
                }
                catch (TaskCanceledException) when (attempt < maxRetries - 1)
                {
                    // Wait with exponential backoff before retrying
                    await Task.Delay(retryDelay * (attempt + 1));
                }
            }

            // If we get here, all retries failed
            throw new InvalidOperationException($"Failed to create OAuth app after {maxRetries} attempts");
        }

        private static string GenerateFakeTokenId() =>
            "oar" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 17);

        private static string GenerateFakeUserId() =>
            "00u" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 17);

        private static string GenerateFakeClientId() =>
            "0oa" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 17);
    }
}
