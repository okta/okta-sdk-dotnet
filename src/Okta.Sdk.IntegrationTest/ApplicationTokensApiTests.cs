// <copyright file="ApplicationTokensApiTests.cs" company="Okta, Inc">
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
    /// <summary>
    /// Integration tests for ApplicationTokensApi - manages OAuth 2.0 refresh tokens for applications.
    /// 
    /// Test Limitations:
    /// - Cannot create OAuth 2.0 refresh tokens (requires authorization_code flow with browser-based user consent)
    /// - Note: OAuth access tokens (from client_credentials) are different and not managed by this API
    /// - Cannot test 403 Forbidden (requires permission issues)
    /// - Cannot test 429 Too Many Requests (rate limiting)
    /// - Cannot test pagination with real 'after' cursor (requires actual tokens)
    /// - Cannot verify 'expand' parameter effect (requires tokens with scopes to embed)
    /// </summary>
    [Collection(nameof(ApplicationTokensApiTests))]
    public class ApplicationTokensApiTests : IDisposable
    {
        private readonly ApplicationTokensApi _appTokensApi = new();
        private readonly ApplicationApi _applicationApi = new();
        private readonly UserApi _userApi = new();
        private readonly UserLifecycleApi _userLifecycleApi = new();
        private readonly List<string> _createdUserIds = [];
        private readonly List<string> _createdAppIds = [];

        public void Dispose()
        {
            Cleanup().GetAwaiter().GetResult();
        }

        private async Task Cleanup()
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
                    await _userLifecycleApi.DeactivateUserAsync(userId);
                    await _userApi.DeleteUserAsync(userId);
                }
                catch (ApiException) { }
            }
            _createdUserIds.Clear();
        }

        private async Task<string> CreateTestOAuthApp()
        {
            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = $"Test OAuth App {Guid.NewGuid()}",
                SignOnMode = "OPENID_CONNECT",
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        ClientId = null,
                        AutoKeyRotation = true,
                        TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretBasic
                    }
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        ClientUri = "https://example.com",
                        LogoUri = "https://example.com/logo.png",
                        ResponseTypes = [OAuthResponseType.Code],
                        GrantTypes =
                        [
                            GrantType.AuthorizationCode,
                            GrantType.RefreshToken
                        ],
                        ApplicationType = OpenIdConnectApplicationType.Web,
                        RedirectUris = ["https://example.com/callback"],
                        PostLogoutRedirectUris = ["https://example.com"]
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);
            _createdAppIds.Add(createdApp.Id);
            return createdApp.Id;
        }

        private string GenerateFakeTokenId() => "oar" + Guid.NewGuid().ToString().Replace("-", "");

        [Fact]
        public async Task GivenApplicationTokens_WhenPerformingAllOperations_ThenOperationsWorkCorrectly()
        {
            // Note: This API manages OAuth 2.0 REFRESH tokens (from authorization_code flow), not access tokens
            // Refresh tokens require browser-based user authentication/consent, cannot be automated in tests
            // Testing API structure, parameters, error handling, and empty result scenarios
            var appId = await CreateTestOAuthApp();
            appId.Should().NotBeNullOrEmpty();

            // ==================== LIST OPERATIONS ====================
            var tokensCollection = _appTokensApi.ListOAuth2TokensForApplication(appId);
            tokensCollection.Should().NotBeNull();
            var tokensList = await tokensCollection.ToListAsync();
            tokensList.Should().NotBeNull().And.BeEmpty("no OAuth flow was performed");

            // Test with parameters: expand adds _embedded.scopes when tokens exist
            var tokensWithParams = _appTokensApi.ListOAuth2TokensForApplication(appId, expand: "scope", after: null, limit: 20);
            var paramsTokensList = await tokensWithParams.ToListAsync();
            paramsTokensList.Should().NotBeNull().And.BeEmpty();

            // Test HttpInfo variant - validates HTTP response structure
            var listResponse = await _appTokensApi.ListOAuth2TokensForApplicationWithHttpInfoAsync(appId, expand: "scope", limit: 10);
            listResponse.Should().NotBeNull();
            listResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            listResponse.Data.Should().NotBeNull().And.BeEmpty();
            listResponse.Headers.Should().NotBeNull()
                .And.ContainKey("Content-Type")
                .And.ContainKey("Date");
            
            // ==================== GET OPERATIONS ====================
            var fakeTokenId = GenerateFakeTokenId();
            
            // Test Get with non-existent token - validates 404 error handling
            var getException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.GetOAuth2TokenForApplicationAsync(appId, fakeTokenId));
            getException.Should().NotBeNull();
            getException.ErrorCode.Should().Be(404);
            getException.Message.Should().NotBeNullOrEmpty().And.Contain("Not found");
            getException.ErrorContent.Should().NotBeNull();

            // Test Get with expanding parameter - expand adds _embedded.scopes to response
            var getExpandException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.GetOAuth2TokenForApplicationAsync(appId, fakeTokenId, expand: "scope"));
            getExpandException.ErrorCode.Should().Be(404);

            // Test GetWithHttpInfo variant
            var getHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.GetOAuth2TokenForApplicationWithHttpInfoAsync(appId, fakeTokenId, expand: "scope"));
            getHttpException.ErrorCode.Should().Be(404);

            // ==================== REVOKE SINGLE TOKEN OPERATIONS ====================
            var revokeException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.RevokeOAuth2TokenForApplicationAsync(appId, fakeTokenId));
            revokeException.Should().NotBeNull();
            revokeException.ErrorCode.Should().Be(404);
            revokeException.Message.Should().NotBeNullOrEmpty();
            revokeException.ErrorContent.Should().NotBeNull();

            // Test RevokeWithHttpInfo variant
            var revokeHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.RevokeOAuth2TokenForApplicationWithHttpInfoAsync(appId, fakeTokenId));
            revokeHttpException.ErrorCode.Should().Be(404);

            // ==================== REVOKE ALL TOKENS OPERATIONS ====================
            // Succeeds with 204 even when no tokens exist
            await _appTokensApi.RevokeOAuth2TokensForApplicationAsync(appId);

            var revokeAllResponse = await _appTokensApi.RevokeOAuth2TokensForApplicationWithHttpInfoAsync(appId);
            revokeAllResponse.Should().NotBeNull();
            revokeAllResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
            revokeAllResponse.Headers.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenInvalidAppId_WhenPerformingOperations_ThenNotFoundIsThrown()
        {
            // Tests all 8 API methods with non-existent app ID
            var fakeAppId = "0oa" + Guid.NewGuid().ToString().Replace("-", "");
            var fakeTokenId = GenerateFakeTokenId();

            // List operations
            var listException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _appTokensApi.ListOAuth2TokensForApplication(fakeAppId).ToListAsync();
            });
            listException.Should().NotBeNull();
            listException.ErrorCode.Should().Be(404);
            listException.Message.Should().Contain("Not found");

            var listHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.ListOAuth2TokensForApplicationWithHttpInfoAsync(fakeAppId));
            listHttpException.ErrorCode.Should().Be(404);

            // Get operations
            var getException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.GetOAuth2TokenForApplicationAsync(fakeAppId, fakeTokenId));
            getException.ErrorCode.Should().Be(404);

            var getHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.GetOAuth2TokenForApplicationWithHttpInfoAsync(fakeAppId, fakeTokenId));
            getHttpException.ErrorCode.Should().Be(404);

            // Revoke single operations
            var revokeException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.RevokeOAuth2TokenForApplicationAsync(fakeAppId, fakeTokenId));
            revokeException.ErrorCode.Should().Be(404);

            var revokeHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.RevokeOAuth2TokenForApplicationWithHttpInfoAsync(fakeAppId, fakeTokenId));
            revokeHttpException.ErrorCode.Should().Be(404);

            // Revoke all operations
            var revokeAllException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.RevokeOAuth2TokensForApplicationAsync(fakeAppId));
            revokeAllException.ErrorCode.Should().Be(404);

            var revokeAllHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.RevokeOAuth2TokensForApplicationWithHttpInfoAsync(fakeAppId));
            revokeAllHttpException.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GivenNullParameters_WhenCallingApi_ThenApiExceptionIsThrown()
        {
            // Validates null parameter handling for all token-specific methods
            var appId = await CreateTestOAuthApp();

            var getException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.GetOAuth2TokenForApplicationAsync(appId, null));
            getException.Should().NotBeNull();
            getException.ErrorCode.Should().BeGreaterThan(0);

            var getHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.GetOAuth2TokenForApplicationWithHttpInfoAsync(appId, null));
            getHttpException.Should().NotBeNull();

            var revokeException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.RevokeOAuth2TokenForApplicationAsync(appId, null));
            revokeException.Should().NotBeNull();
            revokeException.ErrorCode.Should().BeGreaterThan(0);

            var revokeHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _appTokensApi.RevokeOAuth2TokenForApplicationWithHttpInfoAsync(appId, null));
            revokeHttpException.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenApplicationWithNoTokens_WhenListingTokens_ThenEmptyListIsReturned()
        {
            // Tests parameter combinations: expand (scope), after (pagination), limit (1-200, default 20)
            var appId = await CreateTestOAuthApp();

            // Test expand only
            var tokens1 = await _appTokensApi.ListOAuth2TokensForApplication(appId, expand: "scope").ToListAsync();
            tokens1.Should().NotBeNull().And.BeEmpty();

            // Test limit boundary values
            var tokens2 = await _appTokensApi.ListOAuth2TokensForApplication(appId, limit: 1).ToListAsync();
            tokens2.Should().NotBeNull().And.BeEmpty();

            var tokens3 = await _appTokensApi.ListOAuth2TokensForApplication(appId, limit: 200).ToListAsync();
            tokens3.Should().NotBeNull().And.BeEmpty();

            // Test default limit (20)
            var tokens4 = await _appTokensApi.ListOAuth2TokensForApplication(appId).ToListAsync();
            tokens4.Should().NotBeNull().And.BeEmpty();

            // Test all parameters (after requires actual pagination cursor from previous response)
            var tokens5 = await _appTokensApi.ListOAuth2TokensForApplication(
                appId, expand: "scope", after: null, limit: 50).ToListAsync();
            tokens5.Should().NotBeNull().And.BeEmpty();

            // Test HttpInfo variant with full parameters
            var response = await _appTokensApi.ListOAuth2TokensForApplicationWithHttpInfoAsync(
                appId, expand: "scope", after: null, limit: 100);
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull().And.BeEmpty();
            response.Headers.Should().ContainKey("Content-Type");
        }
    }
}
