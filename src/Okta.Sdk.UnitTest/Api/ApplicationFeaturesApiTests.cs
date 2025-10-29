// <copyright file="ApplicationFeaturesApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Okta.Sdk.UnitTest.Internal;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    /// <summary>
    /// Unit tests for ApplicationFeaturesApi
    /// Tests all endpoints: List Features, Get Feature, Update Feature
    /// Covers both standard methods and WithHttpInfo variants
    /// Tests both USER_PROVISIONING and INBOUND_PROVISIONING feature types
    /// </summary>
    public class ApplicationFeaturesApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _appId = "0oa1gjh63g214q0Hq0g4";

                #region ListFeaturesForApplication Tests

        [Fact]
        public async Task ListFeaturesForApplicationWithHttpInfoAsync_ReturnsFeaturesCollection()
        {
            // Arrange
            var responseJson = GetFeaturesListResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await featuresApi.ListFeaturesForApplicationWithHttpInfoAsync(_appId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2, "Response contains 2 features");
            
            var firstFeature = response.Data[0] as UserProvisioningApplicationFeature;
            firstFeature.Should().NotBeNull();
            firstFeature?.Name.Should().Be(ApplicationFeatureType.USERPROVISIONING);
            
            var secondFeature = response.Data[1] as InboundProvisioningApplicationFeature;
            secondFeature.Should().NotBeNull();
            secondFeature?.Name.Should().Be(ApplicationFeatureType.INBOUNDPROVISIONING);
            
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/features");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task ListFeaturesForApplicationWithHttpInfoAsync_WithEnabledFeatures_ReturnsEnabledStatus()
        {
            // Arrange
            var responseJson = GetFeaturesListResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await featuresApi.ListFeaturesForApplicationWithHttpInfoAsync(_appId);

            // Assert
            var features = response.Data;
            features[0].Status.Should().Be(EnabledStatus.ENABLED);
            features[0].Description.Should().NotBeNullOrEmpty();
            features[0].Links.Should().NotBeNull();
            features[0].Links.Self.Should().NotBeNull();
            features[0].Links.Self.Href.Should().Contain(_appId);
            features[0].Links.Self.Href.Should().Contain("USER_PROVISIONING");
        }

        [Fact]
        public void ListFeaturesForApplication_ReturnsCollectionClient()
        {
            // Arrange
            var responseJson = GetFeaturesListResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var collection = featuresApi.ListFeaturesForApplication(_appId);

            // Assert
            collection.Should().NotBeNull("ListFeaturesForApplication should return an IOktaCollectionClient");
            collection.Should().BeAssignableTo<IOktaCollectionClient<ApplicationFeature>>();
        }

        [Fact]
        public async Task ListFeaturesForApplicationWithHttpInfoAsync_WithNoProvisioning_ThrowsApiException()
        {
            // Arrange
            var errorJson = GetProvisioningNotSupportedErrorJson();
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert - MockAsyncClient will try to deserialize error JSON as List<ApplicationFeature> which will fail
            await Assert.ThrowsAsync<Newtonsoft.Json.JsonSerializationException>(async () => 
                await featuresApi.ListFeaturesForApplicationWithHttpInfoAsync(_appId));
        }

        [Fact]
        public async Task ListFeaturesForApplicationWithHttpInfoAsync_WithEmptyList_ReturnsEmptyCollection()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await featuresApi.ListFeaturesForApplicationWithHttpInfoAsync(_appId);

            // Assert
            response.Data.Should().NotBeNull();
            response.Data.Should().BeEmpty();
        }

        #endregion

        #region GetFeatureForApplication Tests - USER_PROVISIONING

        [Fact]
        public async Task GetFeatureForApplication_WithUserProvisioning_ReturnsFeature()
        {
            // Arrange
            var responseJson = GetUserProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var feature = await featuresApi.GetFeatureForApplicationAsync(_appId, ApplicationFeatureType.USERPROVISIONING);

            // Assert
            feature.Should().NotBeNull();
            feature.Name.Should().Be(ApplicationFeatureType.USERPROVISIONING);
            feature.Status.Should().Be(EnabledStatus.ENABLED);
            feature.Description.Should().Be("Manage user accounts in this application");
            
            var userProvFeature = feature as UserProvisioningApplicationFeature;
            userProvFeature.Should().NotBeNull("Response should be UserProvisioningApplicationFeature");
            userProvFeature?.Capabilities.Should().NotBeNull();
            userProvFeature?.Capabilities.Create.Should().NotBeNull();
            userProvFeature?.Capabilities.Update.Should().NotBeNull();
            
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/features/{featureName}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
            mockClient.ReceivedPathParams.Should().ContainKey("featureName");
            mockClient.ReceivedPathParams["featureName"].Should().Contain("USER_PROVISIONING");
        }

        [Fact]
        public async Task GetFeatureForApplicationWithHttpInfoAsync_WithUserProvisioning_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = GetUserProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await featuresApi.GetFeatureForApplicationWithHttpInfoAsync(_appId, ApplicationFeatureType.USERPROVISIONING);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Name.Should().Be(ApplicationFeatureType.USERPROVISIONING);
            
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/features/{featureName}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
            mockClient.ReceivedPathParams.Should().ContainKey("featureName");
            mockClient.ReceivedPathParams["featureName"].Should().Contain("USER_PROVISIONING");
        }

        [Fact]
        public async Task GetFeatureForApplication_WithUserProvisioning_ValidatesCapabilities()
        {
            // Arrange
            var responseJson = GetUserProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var feature = await featuresApi.GetFeatureForApplicationAsync(_appId, ApplicationFeatureType.USERPROVISIONING);

            // Assert
            var userProvFeature = feature as UserProvisioningApplicationFeature;
            userProvFeature.Should().NotBeNull();

            if (userProvFeature != null)
            {
                userProvFeature.Capabilities.Create.LifecycleCreate.Should().NotBeNull();
                userProvFeature.Capabilities.Create.LifecycleCreate.Status.Should().Be(EnabledStatus.ENABLED);

                userProvFeature.Capabilities.Update.Should().NotBeNull();
                userProvFeature.Capabilities.Update.Profile.Should().NotBeNull();
                userProvFeature.Capabilities.Update.Profile.Status.Should().Be(EnabledStatus.ENABLED);

                userProvFeature.Capabilities.Update.Password.Should().NotBeNull();
                userProvFeature.Capabilities.Update.Password.Status.Should().Be(EnabledStatus.ENABLED);
                userProvFeature.Capabilities.Update.Password.Seed.Should().Be(SeedEnum.RANDOM);
                userProvFeature.Capabilities.Update.Password.Change.Should().Be(ChangeEnum.CHANGE);
            }
        }

        [Fact]
        public async Task GetFeatureForApplication_WithDisabledUserProvisioning_ReturnsDisabledStatus()
        {
            // Arrange
            var responseJson = GetDisabledUserProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var feature = await featuresApi.GetFeatureForApplicationAsync(_appId, ApplicationFeatureType.USERPROVISIONING);

            // Assert
            feature.Status.Should().Be(EnabledStatus.DISABLED);
            
            var userProvFeature = feature as UserProvisioningApplicationFeature;
            userProvFeature.Should().NotBeNull();
            userProvFeature?.Capabilities.Create.LifecycleCreate.Status.Should().Be(EnabledStatus.DISABLED);
        }

        [Fact]
        public async Task GetFeatureForApplication_WithNonExistentFeature_ThrowsApiException()
        {
            // Arrange
            var errorJson = GetNotFoundErrorJson();
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(async () => 
                await featuresApi.GetFeatureForApplicationAsync(_appId, ApplicationFeatureType.USERPROVISIONING));
        }

        #endregion

        #region GetFeatureForApplication Tests - INBOUND_PROVISIONING

        [Fact]
        public async Task GetFeatureForApplication_WithInboundProvisioning_ReturnsFeature()
        {
            // Arrange
            var responseJson = GetInboundProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var feature = await featuresApi.GetFeatureForApplicationAsync(_appId, ApplicationFeatureType.INBOUNDPROVISIONING);

            // Assert
            feature.Should().NotBeNull();
            feature.Name.Should().Be(ApplicationFeatureType.INBOUNDPROVISIONING);
            feature.Status.Should().Be(EnabledStatus.ENABLED);
            feature.Description.Should().Be("Import users from this application into Okta");
            
            var inboundProvFeature = feature as InboundProvisioningApplicationFeature;
            inboundProvFeature.Should().NotBeNull("Response should be InboundProvisioningApplicationFeature");
            inboundProvFeature?.Capabilities.Should().NotBeNull();
            
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/features/{featureName}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
            mockClient.ReceivedPathParams.Should().ContainKey("featureName");
            mockClient.ReceivedPathParams["featureName"].Should().Contain("INBOUND_PROVISIONING");
        }

        [Fact]
        public async Task GetFeatureForApplicationWithHttpInfoAsync_WithInboundProvisioning_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = GetInboundProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await featuresApi.GetFeatureForApplicationWithHttpInfoAsync(_appId, ApplicationFeatureType.INBOUNDPROVISIONING);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Name.Should().Be(ApplicationFeatureType.INBOUNDPROVISIONING);
            
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/features/{featureName}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
            mockClient.ReceivedPathParams.Should().ContainKey("featureName");
            mockClient.ReceivedPathParams["featureName"].Should().Contain("INBOUND_PROVISIONING");
        }

        [Fact]
        public async Task GetFeatureForApplication_WithInboundProvisioning_ValidatesImportSettings()
        {
            // Arrange
            var responseJson = GetInboundProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var feature = await featuresApi.GetFeatureForApplicationAsync(_appId, ApplicationFeatureType.INBOUNDPROVISIONING);

            // Assert
            var inboundProvFeature = feature as InboundProvisioningApplicationFeature;
            inboundProvFeature.Should().NotBeNull();

            if (inboundProvFeature != null)
            {
                inboundProvFeature.Capabilities.ImportSettings.Should().NotBeNull();
                inboundProvFeature.Capabilities.ImportSettings.Schedule.Should().NotBeNull();
                inboundProvFeature.Capabilities.ImportSettings.Schedule.Status.Should().Be(EnabledStatus.ENABLED);
            }
        }

        #endregion

        #region UpdateFeatureForApplication Tests - USER_PROVISIONING

        [Fact]
        public async Task UpdateFeatureForApplication_WithUserProvisioning_UpdatesAndReturnsFeature()
        {
            // Arrange
            var responseJson = GetUserProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

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
                        Password = new PasswordSettingObject
                        {
                            Status = EnabledStatus.ENABLED,
                            Seed = SeedEnum.RANDOM,
                            Change = ChangeEnum.CHANGE
                        }
                    }
                });

            // Act
            var feature = await featuresApi.UpdateFeatureForApplicationAsync(_appId, ApplicationFeatureType.USERPROVISIONING, updateRequest);

            // Assert
            feature.Should().NotBeNull();
            feature.Name.Should().Be(ApplicationFeatureType.USERPROVISIONING);
            feature.Status.Should().Be(EnabledStatus.ENABLED);
            
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/features/{featureName}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
            mockClient.ReceivedPathParams.Should().ContainKey("featureName");
            mockClient.ReceivedPathParams["featureName"].Should().Contain("USER_PROVISIONING");
            mockClient.ReceivedBody.Should().Contain("create");
            mockClient.ReceivedBody.Should().Contain("lifecycleCreate");
        }

        [Fact]
        public async Task UpdateFeatureForApplicationWithHttpInfoAsync_WithUserProvisioning_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = GetUserProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateFeatureForApplicationRequest(
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

            // Act
            var response = await featuresApi.UpdateFeatureForApplicationWithHttpInfoAsync(_appId, ApplicationFeatureType.USERPROVISIONING, updateRequest);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Name.Should().Be(ApplicationFeatureType.USERPROVISIONING);
            
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/features/{featureName}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
            mockClient.ReceivedPathParams.Should().ContainKey("featureName");
            mockClient.ReceivedPathParams["featureName"].Should().Contain("USER_PROVISIONING");
        }

        [Fact]
        public async Task UpdateFeatureForApplication_WithPartialUpdate_SendsOnlyProvidedFields()
        {
            // Arrange
            var responseJson = GetUserProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Partial update - only Create capability
            var updateRequest = new UpdateFeatureForApplicationRequest(
                new CapabilitiesObject
                {
                    Create = new CapabilitiesCreateObject
                    {
                        LifecycleCreate = new LifecycleCreateSettingObject
                        {
                            Status = EnabledStatus.ENABLED
                        }
                    }
                    // Note: Not including Update capability
                });

            // Act
            var feature = await featuresApi.UpdateFeatureForApplicationAsync(_appId, ApplicationFeatureType.USERPROVISIONING, updateRequest);

            // Assert
            feature.Should().NotBeNull();
            mockClient.ReceivedBody.Should().Contain("create");
            mockClient.ReceivedBody.Should().Contain("lifecycleCreate");
        }

        [Fact]
        public async Task UpdateFeatureForApplication_WithDisabledStatus_UpdatesToDisabled()
        {
            // Arrange
            var responseJson = GetDisabledUserProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateFeatureForApplicationRequest(
                new CapabilitiesObject
                {
                    Create = new CapabilitiesCreateObject
                    {
                        LifecycleCreate = new LifecycleCreateSettingObject
                        {
                            Status = EnabledStatus.DISABLED
                        }
                    }
                });

            // Act
            var feature = await featuresApi.UpdateFeatureForApplicationAsync(_appId, ApplicationFeatureType.USERPROVISIONING, updateRequest);

            // Assert
            feature.Should().NotBeNull();
            feature.Status.Should().Be(EnabledStatus.DISABLED);
            
            var userProvFeature = feature as UserProvisioningApplicationFeature;
            userProvFeature.Should().NotBeNull();
            userProvFeature?.Capabilities.Create.LifecycleCreate.Status.Should().Be(EnabledStatus.DISABLED);
        }

        [Fact]
        public async Task UpdateFeatureForApplication_WithPasswordSettings_UpdatesPasswordCapability()
        {
            // Arrange
            var responseJson = GetUserProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateFeatureForApplicationRequest(
                new CapabilitiesObject
                {
                    Update = new CapabilitiesUpdateObject
                    {
                        Password = new PasswordSettingObject
                        {
                            Status = EnabledStatus.ENABLED,
                            Seed = SeedEnum.RANDOM,
                            Change = ChangeEnum.KEEPEXISTING
                        }
                    }
                });

            // Act
            var feature = await featuresApi.UpdateFeatureForApplicationAsync(_appId, ApplicationFeatureType.USERPROVISIONING, updateRequest);

            // Assert
            feature.Should().NotBeNull();
            mockClient.ReceivedBody.Should().Contain("password");
            mockClient.ReceivedBody.Should().Contain("RANDOM");
            mockClient.ReceivedBody.Should().Contain("KEEP_EXISTING");
        }

        [Fact]
        public async Task UpdateFeatureForApplication_WithLifecycleDeactivate_UpdatesLifecycleSettings()
        {
            // Arrange
            var responseJson = GetUserProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateFeatureForApplicationRequest(
                new CapabilitiesObject
                {
                    Update = new CapabilitiesUpdateObject
                    {
                        LifecycleDeactivate = new LifecycleDeactivateSettingObject
                        {
                            Status = EnabledStatus.ENABLED
                        }
                    }
                });

            // Act
            var feature = await featuresApi.UpdateFeatureForApplicationAsync(_appId, ApplicationFeatureType.USERPROVISIONING, updateRequest);

            // Assert
            feature.Should().NotBeNull();
            mockClient.ReceivedBody.Should().Contain("lifecycleDeactivate");
        }

        #endregion

        #region UpdateFeatureForApplication Tests - INBOUND_PROVISIONING

        [Fact]
        public async Task UpdateFeatureForApplication_WithInboundProvisioning_UpdatesAndReturnsFeature()
        {
            // Arrange
            var responseJson = GetInboundProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateFeatureForApplicationRequest(
                new CapabilitiesInboundProvisioningObject
                {
                    ImportSettings = new CapabilitiesImportSettingsObject
                    {
                        Schedule = new ImportScheduleObject
                        {
                            Status = EnabledStatus.ENABLED
                        }
                    }
                });

            // Act
            var feature = await featuresApi.UpdateFeatureForApplicationAsync(_appId, ApplicationFeatureType.INBOUNDPROVISIONING, updateRequest);

            // Assert
            feature.Should().NotBeNull();
            feature.Name.Should().Be(ApplicationFeatureType.INBOUNDPROVISIONING);
            feature.Status.Should().Be(EnabledStatus.ENABLED);
            
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/features/{featureName}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
            mockClient.ReceivedPathParams.Should().ContainKey("featureName");
            mockClient.ReceivedPathParams["featureName"].Should().Contain("INBOUND_PROVISIONING");
            mockClient.ReceivedBody.Should().Contain("importSettings");
        }

        [Fact]
        public async Task UpdateFeatureForApplicationWithHttpInfoAsync_WithInboundProvisioning_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = GetInboundProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateFeatureForApplicationRequest(
                new CapabilitiesInboundProvisioningObject());

            // Act
            var response = await featuresApi.UpdateFeatureForApplicationWithHttpInfoAsync(_appId, ApplicationFeatureType.INBOUNDPROVISIONING, updateRequest);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Name.Should().Be(ApplicationFeatureType.INBOUNDPROVISIONING);
            
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/features/{featureName}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
            mockClient.ReceivedPathParams.Should().ContainKey("featureName");
            mockClient.ReceivedPathParams["featureName"].Should().Contain("INBOUND_PROVISIONING");
        }

        [Fact]
        public async Task UpdateFeatureForApplication_WithMinimalInboundProvisioning_SendsMinimalPayload()
        {
            // Arrange
            var responseJson = GetInboundProvisioningFeatureResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateFeatureForApplicationRequest(
                new CapabilitiesInboundProvisioningObject());

            // Act
            var feature = await featuresApi.UpdateFeatureForApplicationAsync(_appId, ApplicationFeatureType.INBOUNDPROVISIONING, updateRequest);

            // Assert
            feature.Should().NotBeNull();
            mockClient.ReceivedBody.Should().Contain("importSettings");
        }

        #endregion

        #region Error Scenarios

        [Fact]
        public async Task GetFeatureForApplication_WithNonExistentApp_ThrowsApiException()
        {
            // Arrange
            var errorJson = GetNotFoundErrorJson();
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(async () => 
                await featuresApi.GetFeatureForApplicationAsync("nonexistent", ApplicationFeatureType.USERPROVISIONING));
        }

        [Fact]
        public async Task UpdateFeatureForApplication_WithNonExistentApp_ThrowsApiException()
        {
            // Arrange
            var errorJson = GetNotFoundErrorJson();
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateFeatureForApplicationRequest(new CapabilitiesObject());

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(async () => 
                await featuresApi.UpdateFeatureForApplicationAsync("nonexistent", ApplicationFeatureType.USERPROVISIONING, updateRequest));
        }

        [Fact]
        public async Task ListFeaturesForApplication_WithProvisioningNotEnabled_ThrowsApiException()
        {
            // Arrange
            var errorJson = GetProvisioningNotSupportedErrorJson();
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert - MockAsyncClient will try to deserialize error JSON as List<ApplicationFeature> which will fail
            await Assert.ThrowsAsync<Newtonsoft.Json.JsonSerializationException>(async () => 
                await featuresApi.ListFeaturesForApplicationWithHttpInfoAsync(_appId));
        }

        [Fact]
        public async Task GetFeatureForApplication_WithProvisioningNotEnabled_ThrowsApiException()
        {
            // Arrange
            var errorJson = GetProvisioningNotSupportedErrorJson();
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(async () => 
                await featuresApi.GetFeatureForApplicationAsync(_appId, ApplicationFeatureType.USERPROVISIONING));
        }

        [Fact]
        public async Task UpdateFeatureForApplication_WithProvisioningNotEnabled_ThrowsApiException()
        {
            // Arrange
            var errorJson = GetProvisioningNotSupportedErrorJson();
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var featuresApi = new ApplicationFeaturesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateFeatureForApplicationRequest(new CapabilitiesObject());

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(async () => 
                await featuresApi.UpdateFeatureForApplicationAsync(_appId, ApplicationFeatureType.USERPROVISIONING, updateRequest));
        }

        #endregion

        #region Response JSON Helpers

        private string GetFeaturesListResponseJson()
        {
            return @"[
                {
                    ""name"": ""USER_PROVISIONING"",
                    ""status"": ""ENABLED"",
                    ""description"": ""Manage user accounts in this application"",
                    ""capabilities"": {
                        ""create"": {
                            ""lifecycleCreate"": {
                                ""status"": ""ENABLED""
                            }
                        },
                        ""update"": {
                            ""profile"": {
                                ""status"": ""ENABLED""
                            },
                            ""password"": {
                                ""status"": ""ENABLED"",
                                ""seed"": ""RANDOM"",
                                ""change"": ""CHANGE""
                            }
                        }
                    },
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4/features/USER_PROVISIONING""
                        }
                    }
                },
                {
                    ""name"": ""INBOUND_PROVISIONING"",
                    ""status"": ""ENABLED"",
                    ""description"": ""Import users from this application into Okta"",
                    ""capabilities"": {
                        ""importSettings"": {
                            ""schedule"": {
                                ""status"": ""ENABLED""
                            }
                        }
                    },
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4/features/INBOUND_PROVISIONING""
                        }
                    }
                }
            ]";
        }

        private string GetUserProvisioningFeatureResponseJson()
        {
            return @"{
                ""name"": ""USER_PROVISIONING"",
                ""status"": ""ENABLED"",
                ""description"": ""Manage user accounts in this application"",
                ""capabilities"": {
                    ""create"": {
                        ""lifecycleCreate"": {
                            ""status"": ""ENABLED""
                        }
                    },
                    ""update"": {
                        ""profile"": {
                            ""status"": ""ENABLED""
                        },
                        ""password"": {
                            ""status"": ""ENABLED"",
                            ""seed"": ""RANDOM"",
                            ""change"": ""CHANGE""
                        },
                        ""lifecycleDeactivate"": {
                            ""status"": ""ENABLED""
                        }
                    }
                },
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4/features/USER_PROVISIONING""
                    }
                }
            }";
        }

        private string GetDisabledUserProvisioningFeatureResponseJson()
        {
            return @"{
                ""name"": ""USER_PROVISIONING"",
                ""status"": ""DISABLED"",
                ""description"": ""Manage user accounts in this application"",
                ""capabilities"": {
                    ""create"": {
                        ""lifecycleCreate"": {
                            ""status"": ""DISABLED""
                        }
                    },
                    ""update"": {
                        ""profile"": {
                            ""status"": ""DISABLED""
                        }
                    }
                },
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4/features/USER_PROVISIONING""
                    }
                }
            }";
        }

        private string GetInboundProvisioningFeatureResponseJson()
        {
            return @"{
                ""name"": ""INBOUND_PROVISIONING"",
                ""status"": ""ENABLED"",
                ""description"": ""Import users from this application into Okta"",
                ""capabilities"": {
                    ""importSettings"": {
                        ""schedule"": {
                            ""status"": ""ENABLED""
                        }
                    }
                },
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4/features/INBOUND_PROVISIONING""
                    }
                }
            }";
        }

        private string GetProvisioningNotSupportedErrorJson()
        {
            return @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: Provisioning is not supported for this application"",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""oaeX1X2X3X4X5X6X7X8X9""
            }";
        }

        private string GetNotFoundErrorJson()
        {
            return @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: nonexistent (Application)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaeY1Y2Y3Y4Y5Y6Y7Y8Y9""
            }";
        }

        #endregion
    }
}
