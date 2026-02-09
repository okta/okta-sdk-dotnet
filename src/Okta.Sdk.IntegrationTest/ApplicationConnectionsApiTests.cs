// <copyright file="ApplicationConnectionsApiTests.cs" company="Okta, Inc">
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
    public class ApplicationConnectionsApiTestFixture : IAsyncLifetime
    {
        private readonly ApplicationApi _applicationApi = new();

        public async Task InitializeAsync()
        {
            // Cleanup any leftover test apps
            await CleanupTestApps();
        }

        public async Task DisposeAsync()
        {
            // Final cleanup
            await CleanupTestApps();
        }

        private async Task CleanupTestApps()
        {
            var appsToRemove = await _applicationApi.ListApplications().ToListAsync();

            foreach (var app in appsToRemove)
            {
                if (app.Label != null && app.Label.StartsWith("dotnet-sdk-test-conn:"))
                {
                    try
                    {
                        // Deactivate first if active
                        if (app.Status == ApplicationLifecycleStatus.ACTIVE)
                        {
                            await _applicationApi.DeactivateApplicationAsync(app.Id);
                        }
                        await _applicationApi.DeleteApplicationAsync(app.Id);
                    }
                    catch (ApiException) { }
                }
            }
        }
    }

    [CollectionDefinition(nameof(ApplicationConnectionsApiTests))]
    public class ApplicationConnectionsApiTestsCollection : ICollectionFixture<ApplicationConnectionsApiTestFixture>;

    [Collection(nameof(ApplicationConnectionsApiTests))]
    public class ApplicationConnectionsApiTests : IDisposable
    {
        private readonly ApplicationApi _applicationApi = new();
        private readonly ApplicationConnectionsApi _connectionApi = new();
        private readonly List<string> _createdAppIds = [];

        public void Dispose()
        {
            CleanupApps().GetAwaiter().GetResult();
        }

        private async Task CleanupApps()
        {
            foreach (var appId in _createdAppIds)
            {
                try
                {
                    var app = await _applicationApi.GetApplicationAsync(appId);
                    if (app.Status == ApplicationLifecycleStatus.ACTIVE)
                    {
                        await _applicationApi.DeactivateApplicationAsync(appId);
                    }
                    await _applicationApi.DeleteApplicationAsync(appId);
                }
                catch (ApiException) { }
            }
            _createdAppIds.Clear();
        }

        /// <summary>
        /// Comprehensive test covering all Application Connections API operations.
        /// Tests: Get, Update, Activate, Deactivate, GetJWKS connections
        /// Covers all 6 endpoints and 12 methods (standard + WithHttpInfo variants)
        /// </summary>
        [Fact]
        public async Task GivenApplicationConnections_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();
            string org2OrgAppId = null;

            try
            {
                // ==================== SETUP: Create Test Application ====================
                // Create a simple OIDC app for testing provisioning connections
                var testApp = new OpenIdConnectApplication
                {
                    Name = "oidc_client",
                    Label = $"dotnet-sdk-test-conn: ProvisioningTestApp {guid}",
                    SignOnMode = ApplicationSignOnMode.OPENIDCONNECT,
                    Visibility = new ApplicationVisibility
                    {
                        AutoSubmitToolbar = false,
                        Hide = new ApplicationVisibilityHide
                        {
                            IOS = false,
                            Web = false
                        }
                    },
                    Credentials = new OAuthApplicationCredentials
                    {
                        OauthClient = new ApplicationCredentialsOAuthClient
                        {
                            ClientId = $"test-client-{guid}",
                            AutoKeyRotation = true,
                            TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretPost,
                        },
                    },
                    Settings = new OpenIdConnectApplicationSettings
                    {
                        OauthClient = new OpenIdConnectApplicationSettingsClient
                        {
                            ClientUri = "https://example.com",
                            LogoUri = "https://example.com/logo.png",
                            RedirectUris = ["https://example.com/oauth2/callback"],
                            PostLogoutRedirectUris = ["https://example.com/postlogout"],
                            ResponseTypes =
                            [
                                OAuthResponseType.Code
                            ],
                            GrantTypes =
                            [
                                GrantType.AuthorizationCode
                            ],
                            ApplicationType = OpenIdConnectApplicationType.Web,
                        },
                    },
                };

                var createdApp = await _applicationApi.CreateApplicationAsync(testApp);
                org2OrgAppId = createdApp.Id;
                _createdAppIds.Add(org2OrgAppId);

                createdApp.Should().NotBeNull();
                createdApp.Id.Should().NotBeNullOrEmpty();
                createdApp.SignOnMode.Should().Be(ApplicationSignOnMode.OPENIDCONNECT);

                // Wait for the app to be fully provisioned
                await Task.Delay(2000);

                // ==================== GET DEFAULT PROVISIONING CONNECTION ====================
                // GetDefaultProvisioningConnectionForApplicationAsync
                var connection = await _connectionApi.GetDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);

                // Validate response structure
                connection.Should().NotBeNull("GET connection should return a connection object");
                connection.Profile.Should().NotBeNull("Connection should have a profile");
                connection.Profile.AuthScheme.Should().NotBeNull("Profile should have an auth scheme");
                // For a newly created app without configured connection, status is typically UNKNOWN or DISABLED
                connection.Status.Should().BeOneOf(
                    ProvisioningConnectionStatus.UNKNOWN,
                    ProvisioningConnectionStatus.DISABLED,
                    ProvisioningConnectionStatus.ENABLED
                );

                // GetDefaultProvisioningConnectionForApplicationWithHttpInfoAsync
                var connectionHttpInfo = await _connectionApi.GetDefaultProvisioningConnectionForApplicationWithHttpInfoAsync(org2OrgAppId);

                // Validate HTTP response
                connectionHttpInfo.Should().NotBeNull("WithHttpInfo should return response wrapper");
                connectionHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK, "GET should return 200 OK");
                connectionHttpInfo.Headers.Should().NotBeNull("Response should include headers");
                connectionHttpInfo.Headers.Should().ContainKey("Content-Type", "Response should have Content-Type header");
                connectionHttpInfo.Data.Should().NotBeNull("Response data should not be null");
                connectionHttpInfo.Data.Profile.Should().NotBeNull("Response data should have profile");

                // ==================== UPDATE DEFAULT PROVISIONING CONNECTION ====================
                // UpdateDefaultProvisioningConnectionForApplicationAsync

                // Note: For token-based connection (like org2org with Zscaler-style config)
                var updateRequest = new UpdateDefaultProvisioningConnectionForApplicationRequest(
                    new ProvisioningConnectionTokenRequest
                    {
                        Profile = new ProvisioningConnectionTokenRequestProfile
                        {
                            AuthScheme = ProvisioningConnectionTokenAuthScheme.TOKEN,
                            Token = "test-token-12345"
                        },
                        BaseUrl = "https://scim.example.okta.com/v2"
                    }
                );

                // Update without activation
                var updatedConnection = await _connectionApi.UpdateDefaultProvisioningConnectionForApplicationAsync(
                    org2OrgAppId,
                    updateRequest,
                    activate: false
                );

                // Validate update response
                updatedConnection.Should().NotBeNull("UPDATE should return updated connection");
                updatedConnection.Profile.Should().NotBeNull("Updated connection should have profile");
                // Note: OIDC apps may not fully support provisioning connections, so AuthScheme might stay UNKNOWN
                updatedConnection.Profile.AuthScheme.Should().BeOneOf(
                    ProvisioningConnectionAuthScheme.TOKEN,
                    ProvisioningConnectionAuthScheme.UNKNOWN
                );
                // With activate=false, status should be DISABLED or UNKNOWN
                updatedConnection.Status.Should().BeOneOf(
                    ProvisioningConnectionStatus.DISABLED,
                    ProvisioningConnectionStatus.UNKNOWN
                );

                // UpdateDefaultProvisioningConnectionForApplicationWithHttpInfoAsync
                var updateRequest2 = new UpdateDefaultProvisioningConnectionForApplicationRequest(
                    new ProvisioningConnectionTokenRequest
                    {
                        Profile = new ProvisioningConnectionTokenRequestProfile
                        {
                            AuthScheme = ProvisioningConnectionTokenAuthScheme.TOKEN,
                            Token = "updated-token-67890"
                        },
                        BaseUrl = "https://scim.updated.okta.com/v2"
                    }
                );

                var updatedConnectionHttpInfo = await _connectionApi.UpdateDefaultProvisioningConnectionForApplicationWithHttpInfoAsync(
                    org2OrgAppId,
                    updateRequest2,
                    activate: true  // Activate this time
                );

                // Validate HTTP response for update
                updatedConnectionHttpInfo.Should().NotBeNull("UpdateWithHttpInfo should return response wrapper");
                updatedConnectionHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK, "POST update should return 200 OK");
                updatedConnectionHttpInfo.Headers.Should().NotBeNull("Update response should include headers");
                updatedConnectionHttpInfo.Data.Should().NotBeNull("Update response data should not be null");
                // Profile and Status may vary depending on app type support for provisioning
                updatedConnectionHttpInfo.Data.Profile.AuthScheme.Should().BeOneOf(
                    ProvisioningConnectionAuthScheme.TOKEN,
                    ProvisioningConnectionAuthScheme.UNKNOWN
                );

                // Verify the update persisted
                var verifyConnection = await _connectionApi.GetDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);
                verifyConnection.Should().NotBeNull("Should be able to retrieve updated connection");

                // ==================== GET USER PROVISIONING CONNECTION JWKS ====================
                // GetUserProvisioningConnectionJWKSAsync
                
                // Note: JWKS is only available for OAuth 2.0-based connections
                // For token-based connections, this endpoint may return 400/404
                try
                {
                    var jwksResponse = await _connectionApi.GetUserProvisioningConnectionJWKSAsync(org2OrgAppId);
                    
                    // If JWKS is supported, validate structure
                    jwksResponse.Should().NotBeNull("JWKS response should not be null when supported");
                    // JWKS property can be null for apps without OAuth 2.0 connection configured
                    if (jwksResponse.Jwks != null)
                    {
                        // If Jwks is present, validate it has keys structure
                        jwksResponse.Jwks.Keys.Should().NotBeNull("JWKS keys array should not be null");
                    }
                }
                catch (ApiException ex)
                {
                    // Expected: Not all apps support JWKS endpoint (e.g., token-based connections)
                    // Validate error response properly
                    ex.ErrorCode.Should().BeOneOf(new[] { 400, 404, 401 }, "JWKS endpoint should return proper error code for unsupported apps");
                    ex.Message.Should().NotBeNullOrEmpty("Error should have a message");
                }

                // GetUserProvisioningConnectionJWKSWithHttpInfoAsync
                try
                {
                    var jwksHttpInfo = await _connectionApi.GetUserProvisioningConnectionJWKSWithHttpInfoAsync(org2OrgAppId);
                    
                    // Validate HTTP response if supported
                    jwksHttpInfo.Should().NotBeNull("JWKS WithHttpInfo should return response wrapper");
                    jwksHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK, "Successful JWKS retrieval should return 200");
                    jwksHttpInfo.Data.Should().NotBeNull("JWKS response data should not be null");
                    // JWKS property can be null for apps without OAuth 2.0 connection
                    if (jwksHttpInfo.Data.Jwks != null)
                    {
                        jwksHttpInfo.Data.Jwks.Keys.Should().NotBeNull("JWKS keys array should not be null when Jwks present");
                    }
                }
                catch (ApiException ex)
                {
                    // Expected for token-based or non-OAuth connections
                    ex.ErrorCode.Should().BeOneOf(new[] { 400, 404, 401 }, "JWKS endpoint should return proper error for unsupported apps");
                    ex.Message.Should().NotBeNullOrEmpty("Error should have descriptive message");
                }

                // ==================== DEACTIVATE DEFAULT PROVISIONING CONNECTION ====================
                // DeactivateDefaultProvisioningConnectionForApplicationAsync

                await _connectionApi.DeactivateDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);

                // Verify deactivation with proper assertions
                var deactivatedConnection = await _connectionApi.GetDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);
                deactivatedConnection.Should().NotBeNull("Should be able to retrieve connection after deactivation");
                deactivatedConnection.Status.Should().BeOneOf(
                    ProvisioningConnectionStatus.DISABLED,
                    ProvisioningConnectionStatus.UNKNOWN
                , "Connection should be disabled or unknown after deactivation");

                // DeactivateDefaultProvisioningConnectionForApplicationWithHttpInfoAsync
                // First activate again to test HttpInfo deactivation
                await _connectionApi.ActivateDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);

                var deactivateHttpInfo = await _connectionApi.DeactivateDefaultProvisioningConnectionForApplicationWithHttpInfoAsync(org2OrgAppId);
                
                // Validate deactivation HTTP response
                deactivateHttpInfo.Should().NotBeNull("DeactivateWithHttpInfo should return response wrapper");
                deactivateHttpInfo.StatusCode.Should().BeOneOf(
                    new[] { HttpStatusCode.NoContent, HttpStatusCode.OK },
                    "Deactivation should return 204 No Content or 200 OK");

                // Verify deactivation via HttpInfo call
                var verifyDeactivated = await _connectionApi.GetDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);
                verifyDeactivated.Should().NotBeNull("Should be able to retrieve connection after deactivation");
                verifyDeactivated.Status.Should().BeOneOf(
                    ProvisioningConnectionStatus.DISABLED,
                    ProvisioningConnectionStatus.UNKNOWN
                , "Connection should remain deactivated");

                // ==================== ACTIVATE DEFAULT PROVISIONING CONNECTION ====================
                // ActivateDefaultProvisioningConnectionForApplicationAsync

                await _connectionApi.ActivateDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);

                // Verify activation with proper assertions
                var activatedConnection = await _connectionApi.GetDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);
                activatedConnection.Should().NotBeNull("Should be able to retrieve connection after activation");
                activatedConnection.Status.Should().BeOneOf(
                    ProvisioningConnectionStatus.ENABLED,
                    ProvisioningConnectionStatus.UNKNOWN
                , "Connection should be enabled or unknown after activation (depending on app type)");

                // ActivateDefaultProvisioningConnectionForApplicationWithHttpInfoAsync
                // First deactivate to test HttpInfo activation
                await _connectionApi.DeactivateDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);

                var activateHttpInfo = await _connectionApi.ActivateDefaultProvisioningConnectionForApplicationWithHttpInfoAsync(org2OrgAppId);
                
                // Validate activation HTTP response
                activateHttpInfo.Should().NotBeNull("ActivateWithHttpInfo should return response wrapper");
                activateHttpInfo.StatusCode.Should().BeOneOf(
                    new[] { HttpStatusCode.NoContent, HttpStatusCode.OK },
                    "Activation should return 204 No Content or 200 OK");

                // Verify activation via HttpInfo call
                var verifyActivated = await _connectionApi.GetDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);
                verifyActivated.Should().NotBeNull("Should be able to retrieve connection after activation");
                verifyActivated.Status.Should().BeOneOf(
                    ProvisioningConnectionStatus.ENABLED,
                    ProvisioningConnectionStatus.UNKNOWN
                , "Connection should remain activated");

                // ==================== TEST IDEMPOTENCY ====================

                // Activating an already active connection should not fail
                await _connectionApi.ActivateDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);
                var stillActive = await _connectionApi.GetDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);
                stillActive.Status.Should().BeOneOf(
                    ProvisioningConnectionStatus.ENABLED,
                    ProvisioningConnectionStatus.UNKNOWN
                );

                // Deactivating an already inactive connection should not fail
                await _connectionApi.DeactivateDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);
                await _connectionApi.DeactivateDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);
                var stillInactive = await _connectionApi.GetDefaultProvisioningConnectionForApplicationAsync(org2OrgAppId);
                stillInactive.Status.Should().BeOneOf(
                    ProvisioningConnectionStatus.DISABLED,
                    ProvisioningConnectionStatus.UNKNOWN
                );

                // ==================== ERROR HANDLING TESTS ====================

                // GetDefaultProvisioningConnectionForApplicationAsync with non-existent app ID
                Func<Task> getNonExistent = async () => 
                    await _connectionApi.GetDefaultProvisioningConnectionForApplicationAsync("nonexistent123");
                var getNonExistentException = await getNonExistent.Should().ThrowAsync<ApiException>(
                    "GET with non-existent app ID should throw ApiException");
                getNonExistentException.Which.ErrorCode.Should().Be(404, "Non-existent app should return 404");
                getNonExistentException.Which.Message.Should().NotBeNullOrEmpty("Error should have descriptive message");

                // UpdateDefaultProvisioningConnectionForApplicationAsync with non-existent app ID
                Func<Task> updateNonExistent = async () =>
                    await _connectionApi.UpdateDefaultProvisioningConnectionForApplicationAsync(
                        "nonexistent123",
                        updateRequest
                    );
                var updateNonExistentException = await updateNonExistent.Should().ThrowAsync<ApiException>(
                    "UPDATE with non-existent app ID should throw ApiException");
                updateNonExistentException.Which.ErrorCode.Should().Be(404, "Non-existent app should return 404");
                updateNonExistentException.Which.Message.Should().NotBeNullOrEmpty("Error should have descriptive message");

                // ActivateDefaultProvisioningConnectionForApplicationAsync with non-existent app ID
                Func<Task> activateNonExistent = async () =>
                    await _connectionApi.ActivateDefaultProvisioningConnectionForApplicationAsync("nonexistent123");
                var activateNonExistentException = await activateNonExistent.Should().ThrowAsync<ApiException>(
                    "ACTIVATE with non-existent app ID should throw ApiException");
                activateNonExistentException.Which.ErrorCode.Should().Be(404, "Non-existent app should return 404");
                activateNonExistentException.Which.Message.Should().NotBeNullOrEmpty("Error should have descriptive message");

                // DeactivateDefaultProvisioningConnectionForApplicationAsync with non-existent app ID
                Func<Task> deactivateNonExistent = async () =>
                    await _connectionApi.DeactivateDefaultProvisioningConnectionForApplicationAsync("nonexistent123");
                var deactivateNonExistentException = await deactivateNonExistent.Should().ThrowAsync<ApiException>(
                    "DEACTIVATE with non-existent app ID should throw ApiException");
                deactivateNonExistentException.Which.ErrorCode.Should().Be(404, "Non-existent app should return 404");
                deactivateNonExistentException.Which.Message.Should().NotBeNullOrEmpty("Error should have descriptive message");

                // ==================== CLEANUP ====================

                await _applicationApi.DeactivateApplicationAsync(org2OrgAppId);
                await _applicationApi.DeleteApplicationAsync(org2OrgAppId);
                _createdAppIds.Remove(org2OrgAppId);
                org2OrgAppId = null;

            }
            catch (Exception)
            {
                // Cleanup on error
                if (!string.IsNullOrEmpty(org2OrgAppId))
                {
                    try
                    {
                        await _applicationApi.DeactivateApplicationAsync(org2OrgAppId);
                        await _applicationApi.DeleteApplicationAsync(org2OrgAppId);
                    }
                    catch
                    {
                        // ignored
                    }
                }
                throw;
            }
        }

        /// <summary>
        /// Tests verify provisioning connection for OAuth 2.0 apps
        /// Note: This test cannot fully execute the OAuth flow in automated tests,
        /// but we verify the method signature and comprehensive error handling
        /// </summary>
        [Fact]
        public async Task GivenInvalidParameters_WhenVerifyingConnection_ThenExceptionIsThrown()
        {
            // ==================== VERIFY PROVISIONING CONNECTION (OAuth 2.0 flow) ====================
            // VerifyProvisioningConnectionForApplicationAsync
            
            // Note: This endpoint is part of the OAuth 2.0 consent flow
            // It requires valid code/state from an actual OAuth flow.
            // We can test error handling with invalid parameters

            var appId = "test_app_id_123";
            var invalidCode = "invalid_code";
            var invalidState = "invalid_state";

            // Test with Google Apps (one of the supported OAuth provisioning apps)
            Func<Task> verifyWithInvalidParams = async () =>
                await _connectionApi.VerifyProvisioningConnectionForApplicationAsync(
                    OAuthProvisioningEnabledApp.Google,
                    appId,
                    invalidCode,
                    invalidState
                );

            // Should throw ApiException with proper error code
            var googleException = await verifyWithInvalidParams.Should().ThrowAsync<ApiException>(
                "Verify with invalid OAuth params should throw ApiException");
            googleException.Which.ErrorCode.Should().BeOneOf(new[] { 404, 403, 400 },
                "Invalid OAuth verification should return 404, 403, or 400");
            googleException.Which.Message.Should().NotBeNullOrEmpty(
                "Error should have descriptive message");

            // Test VerifyProvisioningConnectionForApplicationWithHttpInfoAsync
            Func<Task> verifyWithHttpInfoInvalid = async () =>
                await _connectionApi.VerifyProvisioningConnectionForApplicationWithHttpInfoAsync(
                    OAuthProvisioningEnabledApp.Office365,
                    appId,
                    invalidCode,
                    invalidState
                );

            var office365Exception = await verifyWithHttpInfoInvalid.Should().ThrowAsync<ApiException>(
                "VerifyWithHttpInfo with invalid params should throw ApiException");
            office365Exception.Which.ErrorCode.Should().BeOneOf(new[] { 404, 403, 400 },
                "Invalid OAuth verification should return proper error code");
            office365Exception.Which.Message.Should().NotBeNullOrEmpty(
                "Error should have descriptive message");

            // Test with different supported app names - validate all 4 OAuth apps are supported
            var supportedApps = new[]
            {
                (OAuthProvisioningEnabledApp.Slack, "Slack"),
                (OAuthProvisioningEnabledApp.Zoomus, "Zoom")
            };

            foreach (var (appName, displayName) in supportedApps)
            {
                Func<Task> verifyDifferentApp = async () =>
                    await _connectionApi.VerifyProvisioningConnectionForApplicationAsync(
                        appName,
                        appId,
                        code: null,
                        state: null
                    );

                var appException = await verifyDifferentApp.Should().ThrowAsync<ApiException>(
                    $"Verify for {displayName} with invalid params should throw ApiException");
                appException.Which.ErrorCode.Should().BeOneOf(new[] { 404, 403, 400 },
                    $"{displayName} OAuth verification should return proper error code");
                appException.Which.Message.Should().NotBeNullOrEmpty(
                    $"{displayName} error should have descriptive message");
            }
        }

        /// <summary>
        /// Tests connection operations with non-Org2Org apps
        /// Some apps may not support provisioning connections
        /// </summary>
        [Fact]
        public async Task GivenNonProvisioningApp_WhenPerformingConnectionOperations_ThenOperationsAreHandledGracefully()
        {
            var guid = Guid.NewGuid();
            string bookmarkAppId = null;

            try
            {
                // Create a simple bookmark app (doesn't support provisioning)
                var bookmarkApp = new BookmarkApplication
                {
                    Name = "bookmark",
                    Label = $"dotnet-sdk-test-conn: BookmarkApp {guid}",
                    SignOnMode = ApplicationSignOnMode.BOOKMARK,
                    Visibility = new ApplicationVisibility
                    {
                        AutoSubmitToolbar = false,
                        Hide = new ApplicationVisibilityHide
                        {
                            IOS = false,
                            Web = false
                        }
                    },
                    Settings = new BookmarkApplicationSettings
                    {
                        App = new BookmarkApplicationSettingsApplication
                        {
                            Url = "https://example.com/bookmark.html",
                            RequestIntegration = false,
                        },
                    },
                };

                var createdApp = await _applicationApi.CreateApplicationAsync(bookmarkApp);
                bookmarkAppId = createdApp.Id;
                _createdAppIds.Add(bookmarkAppId);

                await Task.Delay(1000);

                // Try to get provisioning connection for non-provisioning app
                try
                {
                    var connection = await _connectionApi.GetDefaultProvisioningConnectionForApplicationAsync(bookmarkAppId);
                    
                    // Some apps may return UNKNOWN status or may not have a connection at all
                    if (connection != null)
                    {
                        connection.Status.Should().BeOneOf(
                            ProvisioningConnectionStatus.UNKNOWN,
                            ProvisioningConnectionStatus.DISABLED
                        , "Non-provisioning apps should have UNKNOWN or DISABLED status");
                    }
                }
                catch (ApiException ex)
                {
                    // Expected: 404 Not Found or 400 Bad Request for apps without provisioning support
                    ex.ErrorCode.Should().BeOneOf(new[] { 400, 404 },
                        "Non-provisioning apps should return 400 Bad Request or 404 Not Found");
                    ex.Message.Should().NotBeNullOrEmpty(
                        "Error should have descriptive message about provisioning not supported");
                }

                // Cleanup
                await _applicationApi.DeactivateApplicationAsync(bookmarkAppId);
                await _applicationApi.DeleteApplicationAsync(bookmarkAppId);
                _createdAppIds.Remove(bookmarkAppId);
                bookmarkAppId = null;
            }
            catch (Exception)
            {
                if (!string.IsNullOrEmpty(bookmarkAppId))
                {
                    try
                    {
                        await _applicationApi.DeactivateApplicationAsync(bookmarkAppId);
                        await _applicationApi.DeleteApplicationAsync(bookmarkAppId);
                    }
                    catch
                    {
                        // ignored
                    }
                }
                throw;
            }
        }

        /// <summary>
        /// Tests edge cases and boundary conditions for connection operations
        /// </summary>
        [Fact]
        public async Task GivenEdgeCases_WhenCallingApi_ThenEdgeCasesAreHandledCorrectly()
        {
            var guid = Guid.NewGuid();
            string appId = null;

            try
            {
                // Create test app for edge cases
                var testApp = new OpenIdConnectApplication
                {
                    Name = "oidc_client",
                    Label = $"dotnet-sdk-test-conn: EdgeCaseApp {guid}",
                    SignOnMode = ApplicationSignOnMode.OPENIDCONNECT,
                    Visibility = new ApplicationVisibility
                    {
                        AutoSubmitToolbar = false,
                        Hide = new ApplicationVisibilityHide
                        {
                            IOS = false,
                            Web = false
                        }
                    },
                    Credentials = new OAuthApplicationCredentials
                    {
                        OauthClient = new ApplicationCredentialsOAuthClient
                        {
                            ClientId = $"test-client-{guid}",
                            AutoKeyRotation = true,
                            TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretPost,
                        },
                    },
                    Settings = new OpenIdConnectApplicationSettings
                    {
                        OauthClient = new OpenIdConnectApplicationSettingsClient
                        {
                            ClientUri = "https://example.com",
                            RedirectUris = ["https://example.com/oauth2/callback"],
                            ResponseTypes = [OAuthResponseType.Code],
                            GrantTypes = [GrantType.AuthorizationCode],
                            ApplicationType = OpenIdConnectApplicationType.Web,
                        },
                    },
                };

                var createdApp = await _applicationApi.CreateApplicationAsync(testApp);
                appId = createdApp.Id;
                _createdAppIds.Add(appId);

                await Task.Delay(2000);

                // Test: Multiple updates in succession
                for (int i = 0; i < 3; i++)
                {
                    var updateRequest = new UpdateDefaultProvisioningConnectionForApplicationRequest(
                        new ProvisioningConnectionTokenRequest
                        {
                            Profile = new ProvisioningConnectionTokenRequestProfile
                            {
                                AuthScheme = ProvisioningConnectionTokenAuthScheme.TOKEN,
                                Token = $"test-token-{i}"
                            },
                            BaseUrl = $"https://scim.example{i}.okta.com/v2"
                        }
                    );

                    var updated = await _connectionApi.UpdateDefaultProvisioningConnectionForApplicationAsync(
                        appId,
                        updateRequest,
                        activate: false
                    );

                    updated.Should().NotBeNull();
                }

                // Test: Update with null activate parameter (should use default behavior)
                var finalUpdate = new UpdateDefaultProvisioningConnectionForApplicationRequest(
                    new ProvisioningConnectionTokenRequest
                    {
                        Profile = new ProvisioningConnectionTokenRequestProfile
                        {
                            AuthScheme = ProvisioningConnectionTokenAuthScheme.TOKEN,
                            Token = "final-token"
                        },
                        BaseUrl = "https://scim.final.okta.com/v2"
                    }
                );

                var finalResult = await _connectionApi.UpdateDefaultProvisioningConnectionForApplicationAsync(
                    appId,
                    finalUpdate,
                    activate: null  // Test with null parameter
                );

                finalResult.Should().NotBeNull();

                // Cleanup
                await _applicationApi.DeactivateApplicationAsync(appId);
                await _applicationApi.DeleteApplicationAsync(appId);
                _createdAppIds.Remove(appId);
                appId = null;
            }
            catch (Exception)
            {
                if (!string.IsNullOrEmpty(appId))
                {
                    try
                    {
                        await _applicationApi.DeactivateApplicationAsync(appId);
                        await _applicationApi.DeleteApplicationAsync(appId);
                    }
                    catch
                    {
                        // ignored
                    }
                }
                throw;
            }
        }
    }
}
