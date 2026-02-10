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
    public class DeviceAssuranceApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestDeviceAssuranceId = "dae4a5u7JHHhjXrMK0g4";

        #region CreateDeviceAssurancePolicyAsync Tests

        [Fact]
        public async Task CreateDeviceAssurancePolicyAsync_WithValidPolicy_ReturnsCreatedPolicy()
        {
            var responseJson = @"{
                ""id"": ""dae4a5u7JHHhjXrMK0g4"",
                ""name"": ""Test Device Assurance Policy"",
                ""platform"": ""MACOS"",
                ""displayRemediationMode"": ""SHOW"",
                ""createdDate"": ""2025-01-15T10:00:00.000Z"",
                ""createdBy"": ""00u1234567890"",
                ""lastUpdate"": ""2025-01-15T10:00:00.000Z"",
                ""lastUpdatedBy"": ""00u1234567890"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-assurances/dae4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new DeviceAssuranceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var deviceAssurance = new DeviceAssurance
            {
                Name = "Test Device Assurance Policy",
                Platform = Platform.MACOS,
                DisplayRemediationMode = DeviceAssurance.DisplayRemediationModeEnum.SHOW
            };

            var result = await api.CreateDeviceAssurancePolicyAsync(deviceAssurance);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestDeviceAssuranceId);
            result.Name.Should().Be("Test Device Assurance Policy");
            result.Platform.Should().Be(Platform.MACOS);
            mockClient.ReceivedPath.Should().Be("/api/v1/device-assurances");
            mockClient.ReceivedBody.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateDeviceAssurancePolicyWithHttpInfoAsync_WithValidPolicy_ReturnsCreatedResponse()
        {
            var responseJson = @"{
                ""id"": ""dae4a5u7JHHhjXrMK0g4"",
                ""name"": ""Windows Policy"",
                ""platform"": ""WINDOWS"",
                ""displayRemediationMode"": ""HIDE"",
                ""createdDate"": ""2025-01-15T10:00:00.000Z"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-assurances/dae4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new DeviceAssuranceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var deviceAssurance = new DeviceAssurance
            {
                Name = "Windows Policy",
                Platform = Platform.WINDOWS,
                DisplayRemediationMode = DeviceAssurance.DisplayRemediationModeEnum.HIDE
            };

            var response = await api.CreateDeviceAssurancePolicyWithHttpInfoAsync(deviceAssurance);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestDeviceAssuranceId);
            response.Data.Name.Should().Be("Windows Policy");
            response.Data.Platform.Should().Be(Platform.WINDOWS);
        }

        #endregion

        #region GetDeviceAssurancePolicyAsync Tests

        [Fact]
        public async Task GetDeviceAssurancePolicyAsync_WithValidId_ReturnsPolicy()
        {
            var responseJson = @"{
                ""id"": ""dae4a5u7JHHhjXrMK0g4"",
                ""name"": ""iOS Device Assurance"",
                ""platform"": ""IOS"",
                ""displayRemediationMode"": ""SHOW"",
                ""createdDate"": ""2025-01-15T10:00:00.000Z"",
                ""createdBy"": ""00u1234567890"",
                ""lastUpdate"": ""2025-01-20T10:00:00.000Z"",
                ""lastUpdatedBy"": ""00u1234567890"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-assurances/dae4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAssuranceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetDeviceAssurancePolicyAsync(TestDeviceAssuranceId);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestDeviceAssuranceId);
            result.Name.Should().Be("iOS Device Assurance");
            result.Platform.Should().Be(Platform.IOS);
            mockClient.ReceivedPath.Should().Contain("/api/v1/device-assurances/");
            mockClient.ReceivedPathParams.Should().ContainKey("deviceAssuranceId");
            mockClient.ReceivedPathParams["deviceAssuranceId"].Should().Be(TestDeviceAssuranceId);
        }

        [Fact]
        public async Task GetDeviceAssurancePolicyWithHttpInfoAsync_WithValidId_ReturnsOkResponse()
        {
            var responseJson = @"{
                ""id"": ""dae4a5u7JHHhjXrMK0g4"",
                ""name"": ""Android Policy"",
                ""platform"": ""ANDROID"",
                ""displayRemediationMode"": ""HIDE"",
                ""createdDate"": ""2025-01-15T10:00:00.000Z"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-assurances/dae4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAssuranceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetDeviceAssurancePolicyWithHttpInfoAsync(TestDeviceAssuranceId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestDeviceAssuranceId);
            response.Data.Name.Should().Be("Android Policy");
            response.Data.Platform.Should().Be(Platform.ANDROID);
        }

        #endregion

        #region ListDeviceAssurancePoliciesWithHttpInfoAsync Tests

        [Fact]
        public async Task ListDeviceAssurancePoliciesWithHttpInfoAsync_ReturnsPoliciesList()
        {
            var responseJson = @"[
                {
                    ""id"": ""dae4a5u7JHHhjXrMK0g4"",
                    ""name"": ""macOS Policy"",
                    ""platform"": ""MACOS"",
                    ""displayRemediationMode"": ""SHOW"",
                    ""createdDate"": ""2025-01-15T10:00:00.000Z""
                },
                {
                    ""id"": ""dae4a5u7JHHhjXrMK0g5"",
                    ""name"": ""iOS Policy"",
                    ""platform"": ""IOS"",
                    ""displayRemediationMode"": ""HIDE"",
                    ""createdDate"": ""2025-01-10T10:00:00.000Z""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAssuranceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListDeviceAssurancePoliciesWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);

            response.Data[0].Id.Should().Be("dae4a5u7JHHhjXrMK0g4");
            response.Data[0].Name.Should().Be("macOS Policy");
            response.Data[0].Platform.Should().Be(Platform.MACOS);

            response.Data[1].Id.Should().Be("dae4a5u7JHHhjXrMK0g5");
            response.Data[1].Name.Should().Be("iOS Policy");
            response.Data[1].Platform.Should().Be(Platform.IOS);

            mockClient.ReceivedPath.Should().Be("/api/v1/device-assurances");
        }

        [Fact]
        public async Task ListDeviceAssurancePoliciesWithHttpInfoAsync_WithEmptyList_ReturnsEmptyList()
        {
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAssuranceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListDeviceAssurancePoliciesWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().BeEmpty();
        }

        #endregion

        #region ReplaceDeviceAssurancePolicyAsync Tests

        [Fact]
        public async Task ReplaceDeviceAssurancePolicyAsync_WithValidPolicy_ReturnsUpdatedPolicy()
        {
            var responseJson = @"{
                ""id"": ""dae4a5u7JHHhjXrMK0g4"",
                ""name"": ""Updated Device Assurance Policy"",
                ""platform"": ""MACOS"",
                ""displayRemediationMode"": ""HIDE"",
                ""createdDate"": ""2025-01-15T10:00:00.000Z"",
                ""lastUpdate"": ""2025-01-20T15:00:00.000Z"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-assurances/dae4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAssuranceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var deviceAssurance = new DeviceAssurance
            {
                Name = "Updated Device Assurance Policy",
                Platform = Platform.MACOS,
                DisplayRemediationMode = DeviceAssurance.DisplayRemediationModeEnum.HIDE
            };

            var result = await api.ReplaceDeviceAssurancePolicyAsync(TestDeviceAssuranceId, deviceAssurance);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestDeviceAssuranceId);
            result.Name.Should().Be("Updated Device Assurance Policy");
            result.DisplayRemediationMode.Should().Be(DeviceAssurance.DisplayRemediationModeEnum.HIDE);
            mockClient.ReceivedPath.Should().Contain("/api/v1/device-assurances/");
            mockClient.ReceivedPathParams.Should().ContainKey("deviceAssuranceId");
            mockClient.ReceivedPathParams["deviceAssuranceId"].Should().Be(TestDeviceAssuranceId);
            mockClient.ReceivedBody.Should().NotBeNull();
        }

        [Fact]
        public async Task ReplaceDeviceAssurancePolicyWithHttpInfoAsync_WithValidPolicy_ReturnsOkResponse()
        {
            var responseJson = @"{
                ""id"": ""dae4a5u7JHHhjXrMK0g4"",
                ""name"": ""Modified Policy"",
                ""platform"": ""WINDOWS"",
                ""displayRemediationMode"": ""SHOW"",
                ""createdDate"": ""2025-01-15T10:00:00.000Z"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-assurances/dae4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAssuranceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var deviceAssurance = new DeviceAssurance
            {
                Name = "Modified Policy",
                Platform = Platform.WINDOWS,
                DisplayRemediationMode = DeviceAssurance.DisplayRemediationModeEnum.SHOW
            };

            var response = await api.ReplaceDeviceAssurancePolicyWithHttpInfoAsync(TestDeviceAssuranceId, deviceAssurance);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestDeviceAssuranceId);
            response.Data.Name.Should().Be("Modified Policy");
        }

        #endregion

        #region DeleteDeviceAssurancePolicyAsync Tests

        [Fact]
        public async Task DeleteDeviceAssurancePolicyAsync_WithValidId_CompletesSuccessfully()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DeviceAssuranceApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.DeleteDeviceAssurancePolicyAsync(TestDeviceAssuranceId);

            mockClient.ReceivedPath.Should().Contain("/api/v1/device-assurances/");
            mockClient.ReceivedPathParams.Should().ContainKey("deviceAssuranceId");
            mockClient.ReceivedPathParams["deviceAssuranceId"].Should().Be(TestDeviceAssuranceId);
        }

        [Fact]
        public async Task DeleteDeviceAssurancePolicyWithHttpInfoAsync_WithValidId_ReturnsNoContentResponse()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DeviceAssuranceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.DeleteDeviceAssurancePolicyWithHttpInfoAsync(TestDeviceAssuranceId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPathParams["deviceAssuranceId"].Should().Be(TestDeviceAssuranceId);
        }

        #endregion
    }
}
