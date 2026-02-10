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
    public class DevicePostureCheckApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestPostureCheckId = "dpc4a5u7JHHhjXrMK0g4";

        #region CreateDevicePostureCheckAsync Tests

        [Fact]
        public async Task CreateDevicePostureCheckAsync_WithValidCheck_ReturnsCreatedCheck()
        {
            var responseJson = @"{
                ""id"": ""dpc4a5u7JHHhjXrMK0g4"",
                ""name"": ""Test Posture Check"",
                ""description"": ""A test posture check"",
                ""platform"": ""MACOS"",
                ""mappingType"": ""CHECKBOX"",
                ""type"": ""CUSTOM"",
                ""query"": ""device.managed == true"",
                ""variableName"": ""testVar"",
                ""createdDate"": ""2025-01-15T10:00:00.000Z"",
                ""createdBy"": ""00u1234567890"",
                ""lastUpdate"": ""2025-01-15T10:00:00.000Z"",
                ""lastUpdatedBy"": ""00u1234567890"",
                ""remediationSettings"": {
                    ""message"": {
                        ""customText"": ""Please enable device management""
                    }
                },
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-posture-checks/dpc4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new DevicePostureCheckApi(mockClient, new Configuration { BasePath = BaseUrl });

            var postureCheck = new DevicePostureCheck
            {
                Name = "Test Posture Check",
                Description = "A test posture check",
                Platform = DevicePostureChecksPlatform.MACOS,
                MappingType = DevicePostureChecksMappingType.CHECKBOX,
                Query = "device.managed == true",
                VariableName = "testVar"
            };

            var result = await api.CreateDevicePostureCheckAsync(postureCheck);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestPostureCheckId);
            result.Name.Should().Be("Test Posture Check");
            result.Platform.Should().Be(DevicePostureChecksPlatform.MACOS);
            result.Type.Should().Be(DevicePostureChecksType.CUSTOM);
            mockClient.ReceivedPath.Should().Be("/api/v1/device-posture-checks");
            mockClient.ReceivedBody.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateDevicePostureCheckWithHttpInfoAsync_WithValidCheck_ReturnsCreatedResponse()
        {
            var responseJson = @"{
                ""id"": ""dpc4a5u7JHHhjXrMK0g4"",
                ""name"": ""Windows Security Check"",
                ""description"": ""Security check for Windows devices"",
                ""platform"": ""WINDOWS"",
                ""mappingType"": ""TEXTBOX"",
                ""type"": ""CUSTOM"",
                ""query"": ""device.securitySoftware.firewall.enabled == true"",
                ""variableName"": ""winSecurityCheck"",
                ""createdDate"": ""2025-01-15T10:00:00.000Z"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-posture-checks/dpc4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new DevicePostureCheckApi(mockClient, new Configuration { BasePath = BaseUrl });

            var postureCheck = new DevicePostureCheck
            {
                Name = "Windows Security Check",
                Description = "Security check for Windows devices",
                Platform = DevicePostureChecksPlatform.WINDOWS,
                MappingType = DevicePostureChecksMappingType.TEXTBOX,
                Query = "device.securitySoftware.firewall.enabled == true",
                VariableName = "winSecurityCheck"
            };

            var response = await api.CreateDevicePostureCheckWithHttpInfoAsync(postureCheck);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestPostureCheckId);
            response.Data.Name.Should().Be("Windows Security Check");
            response.Data.Platform.Should().Be(DevicePostureChecksPlatform.WINDOWS);
        }

        #endregion

        #region GetDevicePostureCheckAsync Tests

        [Fact]
        public async Task GetDevicePostureCheckAsync_WithValidId_ReturnsCheck()
        {
            var responseJson = @"{
                ""id"": ""dpc4a5u7JHHhjXrMK0g4"",
                ""name"": ""Managed Device Check"",
                ""description"": ""Check if device is managed"",
                ""platform"": ""MACOS"",
                ""mappingType"": ""CHECKBOX"",
                ""type"": ""CUSTOM"",
                ""query"": ""device.managed == true"",
                ""variableName"": ""managedCheck"",
                ""createdDate"": ""2025-01-15T10:00:00.000Z"",
                ""createdBy"": ""00u1234567890"",
                ""lastUpdate"": ""2025-01-20T10:00:00.000Z"",
                ""lastUpdatedBy"": ""00u1234567890"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-posture-checks/dpc4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DevicePostureCheckApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetDevicePostureCheckAsync(TestPostureCheckId);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestPostureCheckId);
            result.Name.Should().Be("Managed Device Check");
            result.Description.Should().Be("Check if device is managed");
            result.Platform.Should().Be(DevicePostureChecksPlatform.MACOS);
            result.MappingType.Should().Be(DevicePostureChecksMappingType.CHECKBOX);
            result.Type.Should().Be(DevicePostureChecksType.CUSTOM);
            mockClient.ReceivedPath.Should().Contain("/api/v1/device-posture-checks/");
            mockClient.ReceivedPathParams.Should().ContainKey("postureCheckId");
            mockClient.ReceivedPathParams["postureCheckId"].Should().Be(TestPostureCheckId);
        }

        [Fact]
        public async Task GetDevicePostureCheckWithHttpInfoAsync_WithValidId_ReturnsOkResponse()
        {
            var responseJson = @"{
                ""id"": ""dpc4a5u7JHHhjXrMK0g4"",
                ""name"": ""Encryption Check"",
                ""description"": ""Check disk encryption"",
                ""platform"": ""WINDOWS"",
                ""mappingType"": ""CHECKBOX"",
                ""type"": ""BUILTIN"",
                ""query"": ""device.diskEncryptionType != NONE"",
                ""variableName"": ""encryptionCheck"",
                ""createdDate"": ""2025-01-15T10:00:00.000Z"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-posture-checks/dpc4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DevicePostureCheckApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetDevicePostureCheckWithHttpInfoAsync(TestPostureCheckId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestPostureCheckId);
            response.Data.Type.Should().Be(DevicePostureChecksType.BUILTIN);
        }

        #endregion

        #region ListDevicePostureChecksWithHttpInfoAsync Tests

        [Fact]
        public async Task ListDevicePostureChecksWithHttpInfoAsync_ReturnsChecksList()
        {
            var responseJson = @"[
                {
                    ""id"": ""dpc4a5u7JHHhjXrMK0g4"",
                    ""name"": ""Custom Check 1"",
                    ""platform"": ""MACOS"",
                    ""mappingType"": ""CHECKBOX"",
                    ""type"": ""CUSTOM"",
                    ""query"": ""device.managed == true"",
                    ""createdDate"": ""2025-01-15T10:00:00.000Z""
                },
                {
                    ""id"": ""dpc4a5u7JHHhjXrMK0g5"",
                    ""name"": ""Custom Check 2"",
                    ""platform"": ""WINDOWS"",
                    ""mappingType"": ""TEXTBOX"",
                    ""type"": ""CUSTOM"",
                    ""query"": ""device.osVersion >= 11"",
                    ""createdDate"": ""2025-01-10T10:00:00.000Z""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DevicePostureCheckApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListDevicePostureChecksWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);

            response.Data[0].Id.Should().Be("dpc4a5u7JHHhjXrMK0g4");
            response.Data[0].Name.Should().Be("Custom Check 1");
            response.Data[0].Platform.Should().Be(DevicePostureChecksPlatform.MACOS);
            response.Data[0].Type.Should().Be(DevicePostureChecksType.CUSTOM);

            response.Data[1].Id.Should().Be("dpc4a5u7JHHhjXrMK0g5");
            response.Data[1].Name.Should().Be("Custom Check 2");
            response.Data[1].Platform.Should().Be(DevicePostureChecksPlatform.WINDOWS);

            mockClient.ReceivedPath.Should().Be("/api/v1/device-posture-checks");
        }

        [Fact]
        public async Task ListDevicePostureChecksWithHttpInfoAsync_WithEmptyList_ReturnsEmptyList()
        {
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DevicePostureCheckApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListDevicePostureChecksWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().BeEmpty();
        }

        #endregion

        #region ListDefaultDevicePostureChecksWithHttpInfoAsync Tests

        [Fact]
        public async Task ListDefaultDevicePostureChecksWithHttpInfoAsync_ReturnsDefaultChecksList()
        {
            var responseJson = @"[
                {
                    ""id"": ""dpc_default_1"",
                    ""name"": ""Disk Encryption Check"",
                    ""platform"": ""MACOS"",
                    ""mappingType"": ""CHECKBOX"",
                    ""type"": ""BUILTIN"",
                    ""query"": ""device.diskEncryptionType != NONE"",
                    ""createdDate"": ""2024-01-01T00:00:00.000Z""
                },
                {
                    ""id"": ""dpc_default_2"",
                    ""name"": ""Firewall Enabled Check"",
                    ""platform"": ""WINDOWS"",
                    ""mappingType"": ""CHECKBOX"",
                    ""type"": ""BUILTIN"",
                    ""query"": ""device.securitySoftware.firewall.enabled == true"",
                    ""createdDate"": ""2024-01-01T00:00:00.000Z""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DevicePostureCheckApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListDefaultDevicePostureChecksWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);

            response.Data[0].Type.Should().Be(DevicePostureChecksType.BUILTIN);
            response.Data[1].Type.Should().Be(DevicePostureChecksType.BUILTIN);

            mockClient.ReceivedPath.Should().Be("/api/v1/device-posture-checks/default");
        }

        #endregion

        #region ReplaceDevicePostureCheckAsync Tests

        [Fact]
        public async Task ReplaceDevicePostureCheckAsync_WithValidCheck_ReturnsUpdatedCheck()
        {
            var responseJson = @"{
                ""id"": ""dpc4a5u7JHHhjXrMK0g4"",
                ""name"": ""Updated Posture Check"",
                ""description"": ""Updated description"",
                ""platform"": ""MACOS"",
                ""mappingType"": ""CHECKBOX"",
                ""type"": ""CUSTOM"",
                ""query"": ""device.managed == true && device.osVersion >= 13"",
                ""variableName"": ""updatedCheck"",
                ""createdDate"": ""2025-01-15T10:00:00.000Z"",
                ""lastUpdate"": ""2025-01-20T15:00:00.000Z"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-posture-checks/dpc4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DevicePostureCheckApi(mockClient, new Configuration { BasePath = BaseUrl });

            var postureCheck = new DevicePostureCheck
            {
                Name = "Updated Posture Check",
                Description = "Updated description",
                Platform = DevicePostureChecksPlatform.MACOS,
                MappingType = DevicePostureChecksMappingType.CHECKBOX,
                Query = "device.managed == true && device.osVersion >= 13",
                VariableName = "updatedCheck"
            };

            var result = await api.ReplaceDevicePostureCheckAsync(TestPostureCheckId, postureCheck);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestPostureCheckId);
            result.Name.Should().Be("Updated Posture Check");
            result.Description.Should().Be("Updated description");
            mockClient.ReceivedPath.Should().Contain("/api/v1/device-posture-checks/");
            mockClient.ReceivedPathParams.Should().ContainKey("postureCheckId");
            mockClient.ReceivedPathParams["postureCheckId"].Should().Be(TestPostureCheckId);
            mockClient.ReceivedBody.Should().NotBeNull();
        }

        [Fact]
        public async Task ReplaceDevicePostureCheckWithHttpInfoAsync_WithValidCheck_ReturnsOkResponse()
        {
            var responseJson = @"{
                ""id"": ""dpc4a5u7JHHhjXrMK0g4"",
                ""name"": ""Modified Check"",
                ""platform"": ""WINDOWS"",
                ""mappingType"": ""TEXTBOX"",
                ""type"": ""CUSTOM"",
                ""query"": ""device.osVersion >= 10"",
                ""createdDate"": ""2025-01-15T10:00:00.000Z"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/device-posture-checks/dpc4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DevicePostureCheckApi(mockClient, new Configuration { BasePath = BaseUrl });

            var postureCheck = new DevicePostureCheck
            {
                Name = "Modified Check",
                Platform = DevicePostureChecksPlatform.WINDOWS,
                MappingType = DevicePostureChecksMappingType.TEXTBOX,
                Query = "device.osVersion >= 10"
            };

            var response = await api.ReplaceDevicePostureCheckWithHttpInfoAsync(TestPostureCheckId, postureCheck);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestPostureCheckId);
            response.Data.Name.Should().Be("Modified Check");
        }

        #endregion

        #region DeleteDevicePostureCheckAsync Tests

        [Fact]
        public async Task DeleteDevicePostureCheckAsync_WithValidId_CompletesSuccessfully()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DevicePostureCheckApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.DeleteDevicePostureCheckAsync(TestPostureCheckId);

            mockClient.ReceivedPath.Should().Contain("/api/v1/device-posture-checks/");
            mockClient.ReceivedPathParams.Should().ContainKey("postureCheckId");
            mockClient.ReceivedPathParams["postureCheckId"].Should().Be(TestPostureCheckId);
        }

        [Fact]
        public async Task DeleteDevicePostureCheckWithHttpInfoAsync_WithValidId_ReturnsNoContentResponse()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DevicePostureCheckApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.DeleteDevicePostureCheckWithHttpInfoAsync(TestPostureCheckId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPathParams["postureCheckId"].Should().Be(TestPostureCheckId);
        }

        #endregion
    }
}
