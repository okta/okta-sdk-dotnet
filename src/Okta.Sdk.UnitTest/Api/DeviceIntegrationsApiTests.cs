using System.Collections.Generic;
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
    public class DeviceIntegrationsApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestDeviceIntegrationId = "odi4a5u7JHHhjXrMK0g4";

        #region ListDeviceIntegrationsWithHttpInfoAsync Tests

        [Fact]
        public async Task ListDeviceIntegrationsWithHttpInfoAsync_ReturnsIntegrationsList()
        {
            var responseJson = @"[
                {
                    ""id"": ""odi4a5u7JHHhjXrMK0g4"",
                    ""name"": ""com.okta.device.osquery"",
                    ""platform"": ""WINDOWS"",
                    ""status"": ""DEACTIVATED"",
                    ""displayName"": ""Okta Device Osquery"",
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/device-integrations/odi4a5u7JHHhjXrMK0g4""
                        },
                        ""activate"": {
                            ""href"": ""https://test.okta.com/api/v1/device-integrations/odi4a5u7JHHhjXrMK0g4/lifecycle/activate""
                        }
                    }
                },
                {
                    ""id"": ""odi4a5u7JHHhjXrMK0g5"",
                    ""name"": ""com.crowdstrike.zta"",
                    ""platform"": ""MACOS"",
                    ""status"": ""ACTIVE"",
                    ""displayName"": ""CrowdStrike ZTA"",
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/device-integrations/odi4a5u7JHHhjXrMK0g5""
                        }
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceIntegrationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListDeviceIntegrationsWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);

            response.Data[0].Id.Should().Be("odi4a5u7JHHhjXrMK0g4");
            response.Data[0].Name.Should().Be(DeviceIntegrationsName.OktaDeviceOsquery);
            response.Data[0].Platform.Should().Be(DeviceIntegrationsPlatform.WINDOWS);
            response.Data[0].Status.Should().Be(DeviceIntegrationsStatus.DEACTIVATED);
            response.Data[0].DisplayName.Should().Be("Okta Device Osquery");

            response.Data[1].Id.Should().Be("odi4a5u7JHHhjXrMK0g5");
            response.Data[1].Name.Should().Be(DeviceIntegrationsName.CrowdstrikeZta);
            response.Data[1].Platform.Should().Be(DeviceIntegrationsPlatform.MACOS);
            response.Data[1].Status.Should().Be(DeviceIntegrationsStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/device-integrations");
        }

        [Fact]
        public async Task ListDeviceIntegrationsWithHttpInfoAsync_WithEmptyList_ReturnsEmptyList()
        {
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceIntegrationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListDeviceIntegrationsWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().BeEmpty();
        }

        #endregion

        #region GetDeviceIntegrationAsync Tests

        [Fact]
        public async Task GetDeviceIntegrationAsync_WithValidId_ReturnsIntegration()
        {
            var responseJson = @"{
                ""id"": ""odi4a5u7JHHhjXrMK0g4"",
                ""name"": ""com.okta.device.osquery"",
                ""platform"": ""WINDOWS"",
                ""status"": ""DEACTIVATED"",
                ""displayName"": ""Okta Device Osquery"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-integrations/odi4a5u7JHHhjXrMK0g4""
                    },
                    ""activate"": {
                        ""href"": ""https://test.okta.com/api/v1/device-integrations/odi4a5u7JHHhjXrMK0g4/lifecycle/activate""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceIntegrationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetDeviceIntegrationAsync(TestDeviceIntegrationId);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestDeviceIntegrationId);
            result.Name.Should().Be(DeviceIntegrationsName.OktaDeviceOsquery);
            result.Platform.Should().Be(DeviceIntegrationsPlatform.WINDOWS);
            result.Status.Should().Be(DeviceIntegrationsStatus.DEACTIVATED);
            result.DisplayName.Should().Be("Okta Device Osquery");
            mockClient.ReceivedPath.Should().Contain("/api/v1/device-integrations/");
            mockClient.ReceivedPathParams.Should().ContainKey("deviceIntegrationId");
            mockClient.ReceivedPathParams["deviceIntegrationId"].Should().Be(TestDeviceIntegrationId);
        }

        [Fact]
        public async Task GetDeviceIntegrationWithHttpInfoAsync_WithValidId_ReturnsOkResponse()
        {
            var responseJson = @"{
                ""id"": ""odi4a5u7JHHhjXrMK0g4"",
                ""name"": ""com.google.dtc"",
                ""platform"": ""IOS"",
                ""status"": ""ACTIVE"",
                ""displayName"": ""Google DTC"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-integrations/odi4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceIntegrationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetDeviceIntegrationWithHttpInfoAsync(TestDeviceIntegrationId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestDeviceIntegrationId);
            response.Data.Name.Should().Be(DeviceIntegrationsName.GoogleDtc);
            response.Data.Status.Should().Be(DeviceIntegrationsStatus.ACTIVE);
        }

        #endregion

        #region ActivateDeviceIntegrationAsync Tests

        [Fact]
        public async Task ActivateDeviceIntegrationAsync_WithValidId_ReturnsActivatedIntegration()
        {
            var responseJson = @"{
                ""id"": ""odi4a5u7JHHhjXrMK0g4"",
                ""name"": ""com.okta.device.osquery"",
                ""platform"": ""WINDOWS"",
                ""status"": ""ACTIVE"",
                ""displayName"": ""Okta Device Osquery"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-integrations/odi4a5u7JHHhjXrMK0g4""
                    },
                    ""deactivate"": {
                        ""href"": ""https://test.okta.com/api/v1/device-integrations/odi4a5u7JHHhjXrMK0g4/lifecycle/deactivate""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceIntegrationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ActivateDeviceIntegrationAsync(TestDeviceIntegrationId);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestDeviceIntegrationId);
            result.Status.Should().Be(DeviceIntegrationsStatus.ACTIVE);
            mockClient.ReceivedPath.Should().Contain("/api/v1/device-integrations/");
            mockClient.ReceivedPath.Should().Contain("/lifecycle/activate");
            mockClient.ReceivedPathParams.Should().ContainKey("deviceIntegrationId");
            mockClient.ReceivedPathParams["deviceIntegrationId"].Should().Be(TestDeviceIntegrationId);
        }

        [Fact]
        public async Task ActivateDeviceIntegrationWithHttpInfoAsync_WithValidId_ReturnsOkResponse()
        {
            var responseJson = @"{
                ""id"": ""odi4a5u7JHHhjXrMK0g4"",
                ""name"": ""com.crowdstrike.zta"",
                ""platform"": ""MACOS"",
                ""status"": ""ACTIVE"",
                ""displayName"": ""CrowdStrike ZTA"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-integrations/odi4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceIntegrationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ActivateDeviceIntegrationWithHttpInfoAsync(TestDeviceIntegrationId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Status.Should().Be(DeviceIntegrationsStatus.ACTIVE);
        }

        #endregion

        #region DeactivateDeviceIntegrationAsync Tests

        [Fact]
        public async Task DeactivateDeviceIntegrationAsync_WithValidId_ReturnsDeactivatedIntegration()
        {
            var responseJson = @"{
                ""id"": ""odi4a5u7JHHhjXrMK0g4"",
                ""name"": ""com.okta.device.osquery"",
                ""platform"": ""WINDOWS"",
                ""status"": ""DEACTIVATED"",
                ""displayName"": ""Okta Device Osquery"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-integrations/odi4a5u7JHHhjXrMK0g4""
                    },
                    ""activate"": {
                        ""href"": ""https://test.okta.com/api/v1/device-integrations/odi4a5u7JHHhjXrMK0g4/lifecycle/activate""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceIntegrationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.DeactivateDeviceIntegrationAsync(TestDeviceIntegrationId);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestDeviceIntegrationId);
            result.Status.Should().Be(DeviceIntegrationsStatus.DEACTIVATED);
            mockClient.ReceivedPath.Should().Contain("/api/v1/device-integrations/");
            mockClient.ReceivedPath.Should().Contain("/lifecycle/deactivate");
            mockClient.ReceivedPathParams.Should().ContainKey("deviceIntegrationId");
            mockClient.ReceivedPathParams["deviceIntegrationId"].Should().Be(TestDeviceIntegrationId);
        }

        [Fact]
        public async Task DeactivateDeviceIntegrationWithHttpInfoAsync_WithValidId_ReturnsOkResponse()
        {
            var responseJson = @"{
                ""id"": ""odi4a5u7JHHhjXrMK0g4"",
                ""name"": ""com.google.dtc"",
                ""platform"": ""IOS"",
                ""status"": ""DEACTIVATED"",
                ""displayName"": ""Google DTC"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-integrations/odi4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceIntegrationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.DeactivateDeviceIntegrationWithHttpInfoAsync(TestDeviceIntegrationId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Status.Should().Be(DeviceIntegrationsStatus.DEACTIVATED);
        }

        #endregion
    }
}
