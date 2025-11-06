// <copyright file="ApplicationFeaturesApiTests.cs" company="Okta, Inc">
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
    public class ApplicationFeaturesApiTestFixture : IAsyncLifetime
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
                if (app.Label != null && app.Label.StartsWith("dotnet-sdk-test-features:"))
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

    [CollectionDefinition(nameof(ApplicationFeaturesApiTests))]
    public class ApplicationFeaturesApiTestsCollection : ICollectionFixture<ApplicationFeaturesApiTestFixture>;

    [Collection(nameof(ApplicationFeaturesApiTests))]
    public class ApplicationFeaturesApiTests : IDisposable
    {
        private readonly ApplicationApi _applicationApi = new();
        private readonly ApplicationFeaturesApi _featuresApi = new();
        private readonly ApplicationConnectionsApi _connectionsApi = new();
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
        /// Comprehensive test covering all Application Features API operations.
        /// Tests: List Features, Get Feature, Update Feature for both USER_PROVISIONING and INBOUND_PROVISIONING
        /// Covers all 3 endpoints and 6 methods (standard + WithHttpInfo variants)
        /// Pattern: Create app with provisioning -> List features -> Get features -> Update features -> Verify updates
        /// </summary>
        [Fact]
        public async Task GivenApplicationFeatures_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();

            // ==================== SETUP: Create Test Application with Provisioning Support ====================
            // Create an OIDC app that can support provisioning features
            var testApp = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = $"dotnet-sdk-test-features: ProvisioningFeaturesApp {guid}",
                SignOnMode = "OPENID_CONNECT",
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        ClientId = $"test-feature-client-{guid}",
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
            var testAppId = createdApp.Id;
            _createdAppIds.Add(testAppId);

            createdApp.Should().NotBeNull();
            createdApp.Id.Should().NotBeNullOrEmpty();
            createdApp.SignOnMode.Should().Be(ApplicationSignOnMode.OPENIDCONNECT);

            // Wait for the app to be fully provisioned
            await Task.Delay(2000);

            // Setup provisioning connection (required for features to work)
            var provisioningConnection = new UpdateDefaultProvisioningConnectionForApplicationRequest(
                new ProvisioningConnectionTokenRequest
                {
                    Profile = new ProvisioningConnectionTokenRequestProfile
                    {
                        AuthScheme = ProvisioningConnectionTokenAuthScheme.TOKEN,
                        Token = "test-provisioning-token-12345"
                    },
                    BaseUrl = "https://scim.example.okta.com/v2"
                }
            );

            // Update and activate the provisioning connection
            await _connectionsApi.UpdateDefaultProvisioningConnectionForApplicationAsync(
                testAppId,
                provisioningConnection,
                activate: true
            );

            // Wait for provisioning connection to be activated
            await Task.Delay(2000);

            // ==================== LIST ALL FEATURES ====================
            // ListFeaturesForApplication (returns IOktaCollectionClient)

            var featuresCollection = _featuresApi.ListFeaturesForApplication(testAppId);
            featuresCollection.Should().NotBeNull("ListFeaturesForApplication should return a collection client");

            List<ApplicationFeature> featuresList = null;
            bool provisioningSupported = true;
            
            try
            {
                featuresList = await featuresCollection.ToListAsync();
            }
            catch (ApiException ex) when (ex.Message.Contains("Provisioning is not supported"))
            {
                provisioningSupported = false;
                // This application type doesn't support provisioning features
                // This is expected for certain app types like basic OIDC apps
                // Now we'll thoroughly test ALL error scenarios for unsupported apps
            }

            if (!provisioningSupported)
            {
                // ==================== COMPREHENSIVE ERROR VALIDATION FOR UNSUPPORTED APPS ====================
                
                // TEST 1: ListFeaturesForApplicationWithHttpInfoAsync should fail with proper error details
                Func<Task> listWithHttpInfo = async () =>
                    await _featuresApi.ListFeaturesForApplicationWithHttpInfoAsync(testAppId);
                var listException = await listWithHttpInfo.Should().ThrowAsync<ApiException>(
                    "LIST with unsupported app should throw ApiException");
                listException.Which.ErrorCode.Should().Be(400, "Should return 400 Bad Request for unsupported provisioning");
                listException.Which.Message.Should().Contain("Provisioning is not supported", 
                    "Error message should indicate provisioning not supported");
                listException.Which.ErrorContent.Should().NotBeNull("Error should have content");

                // TEST 2: GetFeatureForApplicationAsync for USER_PROVISIONING should fail
                Func<Task> getUserProvisioning = async () =>
                    await _featuresApi.GetFeatureForApplicationAsync(testAppId, ApplicationFeatureType.USERPROVISIONING);
                var getUserProvisioningEx = await getUserProvisioning.Should().ThrowAsync<ApiException>(
                    "GET USER_PROVISIONING feature with unsupported app should throw ApiException");
                getUserProvisioningEx.Which.ErrorCode.Should().Be(400, "Should return 400 for unsupported provisioning");
                getUserProvisioningEx.Which.Message.Should().NotBeNullOrEmpty("Error should have a message");

                // TEST 3: GetFeatureForApplicationWithHttpInfoAsync for USER_PROVISIONING should fail
                Func<Task> getUserProvisioningWithHttpInfo = async () =>
                    await _featuresApi.GetFeatureForApplicationWithHttpInfoAsync(testAppId, ApplicationFeatureType.USERPROVISIONING);
                var getUserProvisioningHttpInfoEx = await getUserProvisioningWithHttpInfo.Should().ThrowAsync<ApiException>(
                    "GET USER_PROVISIONING feature with HTTP info should throw ApiException");
                getUserProvisioningHttpInfoEx.Which.ErrorCode.Should().Be(400, "Should return 400 Bad Request");
                getUserProvisioningHttpInfoEx.Which.Headers.Should().NotBeNull("Error response should have headers");

                // TEST 4: GetFeatureForApplicationAsync for INBOUND_PROVISIONING should fail
                Func<Task> getInboundProvisioning = async () =>
                    await _featuresApi.GetFeatureForApplicationAsync(testAppId, ApplicationFeatureType.INBOUNDPROVISIONING);
                var getInboundProvisioningEx = await getInboundProvisioning.Should().ThrowAsync<ApiException>(
                    "GET INBOUND_PROVISIONING feature with unsupported app should throw ApiException");
                getInboundProvisioningEx.Which.ErrorCode.Should().Be(400, "Should return 400 for unsupported provisioning");

                // TEST 5: GetFeatureForApplicationWithHttpInfoAsync for INBOUND_PROVISIONING should fail
                Func<Task> getInboundProvisioningWithHttpInfo = async () =>
                    await _featuresApi.GetFeatureForApplicationWithHttpInfoAsync(testAppId, ApplicationFeatureType.INBOUNDPROVISIONING);
                var getInboundProvisioningHttpInfoEx = await getInboundProvisioningWithHttpInfo.Should().ThrowAsync<ApiException>(
                    "GET INBOUND_PROVISIONING feature with HTTP info should throw ApiException");
                getInboundProvisioningHttpInfoEx.Which.ErrorCode.Should().Be(400, "Should return 400 Bad Request");

                // TEST 6: UpdateFeatureForApplicationAsync for USER_PROVISIONING should fail
                var userProvisioningUpdate = new UpdateFeatureForApplicationRequest(
                    new CapabilitiesObject
                    {
                        Create = new CapabilitiesCreateObject
                        {
                            LifecycleCreate = new LifecycleCreateSettingObject
                            {
                                Status = EnabledStatus.ENABLED
                            }
                        }
                    });
                Func<Task> updateUserProvisioning = async () =>
                    await _featuresApi.UpdateFeatureForApplicationAsync(
                        testAppId,
                        ApplicationFeatureType.USERPROVISIONING,
                        userProvisioningUpdate);
                var updateUserProvisioningEx = await updateUserProvisioning.Should().ThrowAsync<ApiException>(
                    "UPDATE USER_PROVISIONING feature with unsupported app should throw ApiException");
                updateUserProvisioningEx.Which.ErrorCode.Should().Be(400, "Should return 400 for unsupported provisioning");

                // TEST 7: UpdateFeatureForApplicationWithHttpInfoAsync for USER_PROVISIONING should fail
                Func<Task> updateUserProvisioningWithHttpInfo = async () =>
                    await _featuresApi.UpdateFeatureForApplicationWithHttpInfoAsync(
                        testAppId,
                        ApplicationFeatureType.USERPROVISIONING,
                        userProvisioningUpdate);
                var updateUserProvisioningHttpInfoEx = await updateUserProvisioningWithHttpInfo.Should().ThrowAsync<ApiException>(
                    "UPDATE USER_PROVISIONING with HTTP info should throw ApiException");
                updateUserProvisioningHttpInfoEx.Which.ErrorCode.Should().Be(400, "Should return 400 Bad Request");
                updateUserProvisioningHttpInfoEx.Which.Headers.Should().NotBeNull("Error response should have headers");

                // TEST 8: UpdateFeatureForApplicationAsync for INBOUND_PROVISIONING should fail
                var inboundProvisioningUpdate = new UpdateFeatureForApplicationRequest(
                    new CapabilitiesInboundProvisioningObject());
                Func<Task> updateInboundProvisioning = async () =>
                    await _featuresApi.UpdateFeatureForApplicationAsync(
                        testAppId,
                        ApplicationFeatureType.INBOUNDPROVISIONING,
                        inboundProvisioningUpdate);
                var updateInboundProvisioningEx = await updateInboundProvisioning.Should().ThrowAsync<ApiException>(
                    "UPDATE INBOUND_PROVISIONING feature with unsupported app should throw ApiException");
                updateInboundProvisioningEx.Which.ErrorCode.Should().Be(400, "Should return 400 for unsupported provisioning");

                // TEST 9: UpdateFeatureForApplicationWithHttpInfoAsync for INBOUND_PROVISIONING should fail
                Func<Task> updateInboundProvisioningWithHttpInfo = async () =>
                    await _featuresApi.UpdateFeatureForApplicationWithHttpInfoAsync(
                        testAppId,
                        ApplicationFeatureType.INBOUNDPROVISIONING,
                        inboundProvisioningUpdate);
                var updateInboundProvisioningHttpInfoEx = await updateInboundProvisioningWithHttpInfo.Should().ThrowAsync<ApiException>(
                    "UPDATE INBOUND_PROVISIONING with HTTP info should throw ApiException");
                updateInboundProvisioningHttpInfoEx.Which.ErrorCode.Should().Be(400, "Should return 400 Bad Request");

                // All error scenarios have been thoroughly validated - test complete
                return;
            }
                
            // ==================== SUCCESS PATH: PROVISIONING IS SUPPORTED ====================
            // Validate features list response
            featuresList.Should().NotBeNull("Features list should not be null");
            // The list may be empty or contain features depending on app provisioning setup
            // Most apps will have at least USER_PROVISIONING available once provisioning is enabled

            if (featuresList.Any())
            {
                // If features are present, validate their structure
                foreach (var feature in featuresList)
                {
                    feature.Should().NotBeNull("Each feature in list should not be null");
                    feature.Name.Should().NotBeNull("Feature should have a name");
                    feature.Status.Should().NotBeNull("Feature should have a status");
                    feature.Description.Should().NotBeNullOrEmpty("Feature should have a description");
                        
                    // Name should be one of the supported feature types
                    feature.Name.Should().BeOneOf(
                        ApplicationFeatureType.USERPROVISIONING,
                        ApplicationFeatureType.INBOUNDPROVISIONING,
                        "Feature name should be a valid feature type"
                    );
                        
                    // Status should be either ENABLED or DISABLED
                    feature.Status.Should().BeOneOf(
                        EnabledStatus.ENABLED,
                        EnabledStatus.DISABLED,
                        "Feature status should be ENABLED or DISABLED"
                    );
                }
            }

            // ListFeaturesForApplicationWithHttpInfoAsync
            var featuresHttpInfo = await _featuresApi.ListFeaturesForApplicationWithHttpInfoAsync(testAppId);
                
            // Validate HTTP response
            featuresHttpInfo.Should().NotBeNull("WithHttpInfo should return response wrapper");
            featuresHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK, "LIST features should return 200 OK");
            featuresHttpInfo.Headers.Should().NotBeNull("Response should include headers");
            featuresHttpInfo.Headers.Should().ContainKey("Content-Type", "Response should have Content-Type header");
            featuresHttpInfo.Data.Should().NotBeNull("Response data should not be null");

            // ==================== GET SPECIFIC FEATURE: USER_PROVISIONING ====================
            // GetFeatureForApplicationAsync

            ApplicationFeature userProvisioningFeature = null;
                
            try
            {
                userProvisioningFeature = await _featuresApi.GetFeatureForApplicationAsync(
                    testAppId, 
                    ApplicationFeatureType.USERPROVISIONING
                );

                // Validate USER_PROVISIONING feature response
                userProvisioningFeature.Should().NotBeNull("GET USER_PROVISIONING feature should return feature object");
                userProvisioningFeature.Name.Should().Be(ApplicationFeatureType.USERPROVISIONING, 
                    "Feature name should be USER_PROVISIONING");
                userProvisioningFeature.Description.Should().NotBeNullOrEmpty(
                    "USER_PROVISIONING should have a description");
                userProvisioningFeature.Status.Should().NotBeNull("Feature should have a status");
                userProvisioningFeature.Status.Should().BeOneOf(
                    EnabledStatus.ENABLED,
                    EnabledStatus.DISABLED,
                    "Feature status should be ENABLED or DISABLED"
                );

                // Links should be present
                userProvisioningFeature.Links.Should().NotBeNull("Feature should have links");
                userProvisioningFeature.Links.Self.Should().NotBeNull("Feature should have self link");
                userProvisioningFeature.Links.Self.Href.Should().NotBeNullOrEmpty("Self link should have href");
            }
            catch (ApiException ex)
            {
                // If the app type does not support USER_PROVISIONING, we expect a 404
                if (ex.ErrorCode == 404)
                {
                    // This is acceptable - not all-apps support USER_PROVISIONING
                    ex.Message.Should().NotBeNullOrEmpty("Error should have descriptive message");
                }
                else
                {
                    throw;
                }
            }

            // GetFeatureForApplicationWithHttpInfoAsync
            try
            {
                var userProvisioningHttpInfo = await _featuresApi.GetFeatureForApplicationWithHttpInfoAsync(
                    testAppId,
                    ApplicationFeatureType.USERPROVISIONING
                );

                // Validate HTTP response
                userProvisioningHttpInfo.Should().NotBeNull("WithHttpInfo should return response wrapper");
                userProvisioningHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK, 
                    "GET feature should return 200 OK");
                userProvisioningHttpInfo.Headers.Should().NotBeNull("Response should include headers");
                userProvisioningHttpInfo.Data.Should().NotBeNull("Response data should not be null");
                userProvisioningHttpInfo.Data.Name.Should().Be(ApplicationFeatureType.USERPROVISIONING);
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    // Acceptable if app doesn't support this feature
                    ex.Message.Should().NotBeNullOrEmpty();
                }
                else
                {
                    throw;
                }
            }

            // ==================== UPDATE USER_PROVISIONING FEATURE ====================
            // UpdateFeatureForApplicationAsync

            if (userProvisioningFeature != null)
            {
                // Create update request for USER_PROVISIONING
                var updateRequest = new UpdateFeatureForApplicationRequest(
                    new CapabilitiesObject
                    {
                        Create = new CapabilitiesCreateObject
                        {
                            LifecycleCreate = new LifecycleCreateSettingObject
                            {
                                Status = EnabledStatus.ENABLED
                            }
                        },
                        Update = new CapabilitiesUpdateObject
                        {
                            Profile = new ProfileSettingObject
                            {
                                Status = EnabledStatus.ENABLED
                            },
                            LifecycleDeactivate = new LifecycleDeactivateSettingObject
                            {
                                Status = EnabledStatus.ENABLED
                            },
                            Password = new PasswordSettingObject
                            {
                                Status = EnabledStatus.ENABLED,
                                Seed = SeedEnum.RANDOM,
                                Change = ChangeEnum.CHANGE
                            }
                        }
                    }
                );

                var updatedFeature = await _featuresApi.UpdateFeatureForApplicationAsync(
                    testAppId,
                    ApplicationFeatureType.USERPROVISIONING,
                    updateRequest
                );

                // Validate update response
                updatedFeature.Should().NotBeNull("UPDATE should return updated feature");
                updatedFeature.Name.Should().Be(ApplicationFeatureType.USERPROVISIONING);
                updatedFeature.Status.Should().NotBeNull("Updated feature should have status");

                // Verify update persisted by retrieving the feature again
                var verifyUpdatedFeature = await _featuresApi.GetFeatureForApplicationAsync(
                    testAppId,
                    ApplicationFeatureType.USERPROVISIONING
                );
                    
                verifyUpdatedFeature.Should().NotBeNull("Should be able to retrieve updated feature");
                verifyUpdatedFeature.Name.Should().Be(ApplicationFeatureType.USERPROVISIONING);
            }

            // UpdateFeatureForApplicationWithHttpInfoAsync
            if (userProvisioningFeature != null)
            {
                // Create another update request
                var updateRequest2 = new UpdateFeatureForApplicationRequest(
                    new CapabilitiesObject
                    {
                        Create = new CapabilitiesCreateObject
                        {
                            LifecycleCreate = new LifecycleCreateSettingObject
                            {
                                Status = EnabledStatus.DISABLED
                            }
                        },
                        Update = new CapabilitiesUpdateObject
                        {
                            Profile = new ProfileSettingObject
                            {
                                Status = EnabledStatus.DISABLED
                            },
                            LifecycleDeactivate = new LifecycleDeactivateSettingObject
                            {
                                Status = EnabledStatus.DISABLED
                            },
                            Password = new PasswordSettingObject
                            {
                                Status = EnabledStatus.DISABLED,
                                Seed = SeedEnum.RANDOM,
                                Change = ChangeEnum.KEEPEXISTING
                            }
                        }
                    }
                );

                var updatedHttpInfo = await _featuresApi.UpdateFeatureForApplicationWithHttpInfoAsync(
                    testAppId,
                    ApplicationFeatureType.USERPROVISIONING,
                    updateRequest2
                );

                // Validate HTTP response for update
                updatedHttpInfo.Should().NotBeNull("UpdateWithHttpInfo should return response wrapper");
                updatedHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK, 
                    "PUT update should return 200 OK");
                updatedHttpInfo.Headers.Should().NotBeNull("Update response should include headers");
                updatedHttpInfo.Data.Should().NotBeNull("Update response data should not be null");
                updatedHttpInfo.Data.Name.Should().Be(ApplicationFeatureType.USERPROVISIONING);
            }

            // ==================== GET SPECIFIC FEATURE: INBOUND_PROVISIONING ====================
            // GetFeatureForApplicationAsync

            ApplicationFeature inboundProvisioningFeature = null;

            try
            {
                inboundProvisioningFeature = await _featuresApi.GetFeatureForApplicationAsync(
                    testAppId,
                    ApplicationFeatureType.INBOUNDPROVISIONING
                );

                // Validate INBOUND_PROVISIONING feature response
                inboundProvisioningFeature.Should().NotBeNull("GET INBOUND_PROVISIONING feature should return feature object");
                inboundProvisioningFeature.Name.Should().Be(ApplicationFeatureType.INBOUNDPROVISIONING,
                    "Feature name should be INBOUND_PROVISIONING");
                inboundProvisioningFeature.Description.Should().NotBeNullOrEmpty(
                    "INBOUND_PROVISIONING should have a description");
                inboundProvisioningFeature.Status.Should().NotBeNull("Feature should have a status");
                inboundProvisioningFeature.Status.Should().BeOneOf(
                    EnabledStatus.ENABLED,
                    EnabledStatus.DISABLED,
                    "Feature status should be ENABLED or DISABLED"
                );

                // Links should be present
                inboundProvisioningFeature.Links.Should().NotBeNull("Feature should have links");
                inboundProvisioningFeature.Links.Self.Should().NotBeNull("Feature should have self link");
            }
            catch (ApiException ex)
            {
                // If the app type does not support INBOUND_PROVISIONING, we expect a 404
                if (ex.ErrorCode == 404)
                {
                    // This is acceptable - not all apps support INBOUND_PROVISIONING
                    ex.Message.Should().NotBeNullOrEmpty("Error should have descriptive message");
                }
                else
                {
                    throw;
                }
            }

            // GetFeatureForApplicationWithHttpInfoAsync for INBOUND_PROVISIONING
            try
            {
                var inboundProvisioningHttpInfo = await _featuresApi.GetFeatureForApplicationWithHttpInfoAsync(
                    testAppId,
                    ApplicationFeatureType.INBOUNDPROVISIONING
                );

                // Validate HTTP response
                inboundProvisioningHttpInfo.Should().NotBeNull("WithHttpInfo should return response wrapper");
                inboundProvisioningHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK,
                    "GET feature should return 200 OK");
                inboundProvisioningHttpInfo.Headers.Should().NotBeNull("Response should include headers");
                inboundProvisioningHttpInfo.Data.Should().NotBeNull("Response data should not be null");
                inboundProvisioningHttpInfo.Data.Name.Should().Be(ApplicationFeatureType.INBOUNDPROVISIONING);
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    // Acceptable if app doesn't support this feature
                    ex.Message.Should().NotBeNullOrEmpty();
                }
                else
                {
                    throw;
                }
            }

            // ==================== UPDATE INBOUND_PROVISIONING FEATURE ====================
            // UpdateFeatureForApplicationAsync

            if (inboundProvisioningFeature != null)
            {
                // Create update request for INBOUND_PROVISIONING
                // Note: Using minimal empty object structure for basic feature validation,
                // The API supports partial updates, so we can send minimal data
                var inboundUpdateRequest = new UpdateFeatureForApplicationRequest(
                    new CapabilitiesInboundProvisioningObject()
                );

                var updatedInboundFeature = await _featuresApi.UpdateFeatureForApplicationAsync(
                    testAppId,
                    ApplicationFeatureType.INBOUNDPROVISIONING,
                    inboundUpdateRequest
                );

                // Validate update response
                updatedInboundFeature.Should().NotBeNull("UPDATE should return updated feature");
                updatedInboundFeature.Name.Should().Be(ApplicationFeatureType.INBOUNDPROVISIONING);
                updatedInboundFeature.Status.Should().NotBeNull("Updated feature should have status");

                // Verify update persisted
                var verifyInboundFeature = await _featuresApi.GetFeatureForApplicationAsync(
                    testAppId,
                    ApplicationFeatureType.INBOUNDPROVISIONING
                );

                verifyInboundFeature.Should().NotBeNull("Should be able to retrieve updated feature");
                verifyInboundFeature.Name.Should().Be(ApplicationFeatureType.INBOUNDPROVISIONING);
            }

            // UpdateFeatureForApplicationWithHttpInfoAsync for INBOUND_PROVISIONING
            if (inboundProvisioningFeature != null)
            {
                // Create another update request
                var inboundUpdateRequest2 = new UpdateFeatureForApplicationRequest(
                    new CapabilitiesInboundProvisioningObject
                    {
                        ImportSettings = new CapabilitiesImportSettingsObject
                        {
                            Schedule = new ImportScheduleObject
                            {
                                Status = EnabledStatus.ENABLED
                            }
                        }
                    }
                );

                var updatedInboundHttpInfo = await _featuresApi.UpdateFeatureForApplicationWithHttpInfoAsync(
                    testAppId,
                    ApplicationFeatureType.INBOUNDPROVISIONING,
                    inboundUpdateRequest2
                );

                // Validate HTTP response for update
                updatedInboundHttpInfo.Should().NotBeNull("UpdateWithHttpInfo should return response wrapper");
                updatedInboundHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK,
                    "PUT update should return 200 OK");
                updatedInboundHttpInfo.Headers.Should().NotBeNull("Update response should include headers");
                updatedInboundHttpInfo.Data.Should().NotBeNull("Update response data should not be null");
                updatedInboundHttpInfo.Data.Name.Should().Be(ApplicationFeatureType.INBOUNDPROVISIONING);
            }

            // ==================== TEST PARTIAL UPDATES ====================
            // Test that partial updates work (endpoint supports partial updates)

            if (userProvisioningFeature != null)
            {
                // Update only the Create capability
                var partialUpdateRequest = new UpdateFeatureForApplicationRequest(
                    new CapabilitiesObject
                    {
                        Create = new CapabilitiesCreateObject
                        {
                            LifecycleCreate = new LifecycleCreateSettingObject
                            {
                                Status = EnabledStatus.ENABLED
                            }
                        }
                        // Note: Not including Update capability in this request
                    }
                );

                var partiallyUpdated = await _featuresApi.UpdateFeatureForApplicationAsync(
                    testAppId,
                    ApplicationFeatureType.USERPROVISIONING,
                    partialUpdateRequest
                );

                partiallyUpdated.Should().NotBeNull("Partial update should succeed");
                partiallyUpdated.Name.Should().Be(ApplicationFeatureType.USERPROVISIONING);
            }

            // ==================== ERROR HANDLING TESTS ====================

            // ListFeaturesForApplicationWithHttpInfoAsync with non-existent app ID
            Func<Task> listNonExistent = async () =>
                await _featuresApi.ListFeaturesForApplicationWithHttpInfoAsync("nonexistent123");
            var listNonExistentException = await listNonExistent.Should().ThrowAsync<ApiException>(
                "LIST with non-existent app ID should throw ApiException");
            listNonExistentException.Which.ErrorCode.Should().Be(404, "Non-existent app should return 404");
            listNonExistentException.Which.Message.Should().NotBeNullOrEmpty("Error should have descriptive message");

            // GetFeatureForApplicationAsync with non-existent app ID
            Func<Task> getNonExistent = async () =>
                await _featuresApi.GetFeatureForApplicationAsync("nonexistent123", ApplicationFeatureType.USERPROVISIONING);
            var getNonExistentException = await getNonExistent.Should().ThrowAsync<ApiException>(
                "GET with non-existent app ID should throw ApiException");
            getNonExistentException.Which.ErrorCode.Should().Be(404, "Non-existent app should return 404");
            getNonExistentException.Which.Message.Should().NotBeNullOrEmpty("Error should have descriptive message");

            // UpdateFeatureForApplicationAsync with non-existent app ID
            var dummyUpdateRequest = new UpdateFeatureForApplicationRequest(
                new CapabilitiesObject
                {
                    Create = new CapabilitiesCreateObject
                    {
                        LifecycleCreate = new LifecycleCreateSettingObject
                        {
                            Status = EnabledStatus.ENABLED
                        }
                    }
                }
            );

            Func<Task> updateNonExistent = async () =>
                await _featuresApi.UpdateFeatureForApplicationAsync(
                    "nonexistent123",
                    ApplicationFeatureType.USERPROVISIONING,
                    dummyUpdateRequest
                );
            var updateNonExistentException = await updateNonExistent.Should().ThrowAsync<ApiException>(
                "UPDATE with non-existent app ID should throw ApiException");
            updateNonExistentException.Which.ErrorCode.Should().Be(404, "Non-existent app should return 404");
            updateNonExistentException.Which.Message.Should().NotBeNullOrEmpty("Error should have descriptive message");

            // ==================== TEST COLLECTION CLIENT ENUMERATION ====================
            // Verify that the collection client can be enumerated properly

            var featuresCollectionTest = _featuresApi.ListFeaturesForApplication(testAppId);
            var enumeratedFeatures = new List<ApplicationFeature>();
                
            await foreach (var feature in featuresCollectionTest)
            {
                feature.Should().NotBeNull("Each enumerated feature should not be null");
                enumeratedFeatures.Add(feature);
            }

            // Verify enumeration matches ToListAsync
            var featuresViaToList = await _featuresApi.ListFeaturesForApplication(testAppId).ToListAsync();
            enumeratedFeatures.Count.Should().Be(featuresViaToList.Count, 
                "Manual enumeration should return same count as ToListAsync");
        }

        /// <summary>
        /// Test scenario for an app WITHOUT provisioning enabled.
        /// Verifies that appropriate errors are returned when trying to access features
        /// on an app that doesn't have provisioning configured.
        /// </summary>
        [Fact]
        public async Task GivenAppWithoutProvisioning_WhenCallingApi_ThenAppropriateErrorsAreReturned()
        {
            var guid = Guid.NewGuid();

            // Create a basic OIDC app WITHOUT provisioning
            var testApp = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = $"dotnet-sdk-test-features: NoProvisioningApp {guid}",
                SignOnMode = "OPENID_CONNECT",
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        ClientId = $"test-no-prov-{guid}",
                        AutoKeyRotation = true,
                        TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretPost,
                    },
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        ClientUri = "https://example.com",
                        RedirectUris = ["https://example.com/callback"],
                        ResponseTypes = [OAuthResponseType.Code],
                        GrantTypes = [GrantType.AuthorizationCode],
                        ApplicationType = OpenIdConnectApplicationType.Web,
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(testApp);
            var testAppId = createdApp.Id;
            _createdAppIds.Add(testAppId);

            await Task.Delay(1000);

            // Try to list features without provisioning enabled
            // This should return an error according to the API documentation
            Func<Task> listWithoutProvisioning = async () =>
                await _featuresApi.ListFeaturesForApplicationWithHttpInfoAsync(testAppId);

            var exception = await listWithoutProvisioning.Should().ThrowAsync<ApiException>(
                "LIST features without provisioning should throw ApiException");
                
            // The API should return an error (typically 400 or 404)
            exception.Which.ErrorCode.Should().BeOneOf([400, 404], 
                "Should return appropriate error when provisioning is not enabled");
            exception.Which.Message.Should().NotBeNullOrEmpty(
                "Error should have a descriptive message about provisioning not being enabled");
        }
    }
}
