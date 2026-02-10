// <copyright file="DeviceApiTests.cs" company="Okta, Inc">
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
    /// Unit tests for DeviceApi covering all 12 methods.
    /// Tests cover: GetDevice, ListDevices, DeleteDevice, ActivateDevice, DeactivateDevice, SuspendDevice, UnsuspendDevice
    /// </summary>
    public class DeviceApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestDeviceId = "guo4a5u7JHHhjXrMK0g4";

        #region GetDeviceAsync Tests

        [Fact]
        public async Task GetDeviceAsync_WithValidId_ReturnsDevice()
        {
            var responseJson = @"{
                ""id"": ""guo4a5u7JHHhjXrMK0g4"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2025-01-20T10:00:00.000Z"",
                ""profile"": {
                    ""displayName"": ""Test iPhone"",
                    ""platform"": ""IOS"",
                    ""manufacturer"": ""Apple"",
                    ""model"": ""iPhone 15 Pro"",
                    ""osVersion"": ""17.2.1""
                },
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/devices/guo4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetDeviceAsync(TestDeviceId);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestDeviceId);
            result.Status.Should().Be(DeviceStatus.ACTIVE);
            result.Profile.Should().NotBeNull();
            result.Profile.DisplayName.Should().Be("Test iPhone");
            result.Profile.Platform.Should().Be(DevicePlatform.IOS);
            result.Profile.Manufacturer.Should().Be("Apple");
            result.Profile.Model.Should().Be("iPhone 15 Pro");
            mockClient.ReceivedPath.Should().Contain("/api/v1/devices/");
            mockClient.ReceivedPathParams.Should().ContainKey("deviceId");
            mockClient.ReceivedPathParams["deviceId"].Should().Be(TestDeviceId);
        }

        [Fact]
        public async Task GetDeviceWithHttpInfoAsync_WithValidId_ReturnsApiResponse()
        {
            var responseJson = @"{
                ""id"": ""guo4a5u7JHHhjXrMK0g4"",
                ""status"": ""SUSPENDED"",
                ""created"": ""2025-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2025-01-20T10:00:00.000Z"",
                ""profile"": {
                    ""displayName"": ""Test MacBook"",
                    ""platform"": ""MACOS"",
                    ""manufacturer"": ""Apple""
                },
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/devices/guo4a5u7JHHhjXrMK0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetDeviceWithHttpInfoAsync(TestDeviceId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestDeviceId);
            response.Data.Status.Should().Be(DeviceStatus.SUSPENDED);
            response.Data.Profile.DisplayName.Should().Be("Test MacBook");
        }

        #endregion

        #region ListDevicesWithHttpInfoAsync Tests

        [Fact]
        public async Task ListDevicesWithHttpInfoAsync_ReturnsDeviceList()
        {
            var responseJson = @"[
                {
                    ""id"": ""guo4a5u7JHHhjXrMK0g4"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2025-01-15T10:00:00.000Z"",
                    ""profile"": {
                        ""displayName"": ""iPhone 15 Pro"",
                        ""platform"": ""IOS""
                    }
                },
                {
                    ""id"": ""guo4a5u7JHHhjXrMK0g5"",
                    ""status"": ""SUSPENDED"",
                    ""created"": ""2025-01-10T10:00:00.000Z"",
                    ""profile"": {
                        ""displayName"": ""MacBook Pro"",
                        ""platform"": ""MACOS""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListDevicesWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);

            response.Data[0].Id.Should().Be("guo4a5u7JHHhjXrMK0g4");
            response.Data[0].Status.Should().Be(DeviceStatus.ACTIVE);
            response.Data[0].Profile.DisplayName.Should().Be("iPhone 15 Pro");

            response.Data[1].Id.Should().Be("guo4a5u7JHHhjXrMK0g5");
            response.Data[1].Status.Should().Be(DeviceStatus.SUSPENDED);
            response.Data[1].Profile.DisplayName.Should().Be("MacBook Pro");

            mockClient.ReceivedPath.Should().Be("/api/v1/devices");
        }

        [Fact]
        public async Task ListDevicesWithHttpInfoAsync_WithSearchQuery_IncludesQueryParameter()
        {
            var responseJson = @"[
                {
                    ""id"": ""guo4a5u7JHHhjXrMK0g4"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2025-01-15T10:00:00.000Z"",
                    ""profile"": {
                        ""displayName"": ""Test Device"",
                        ""platform"": ""WINDOWS""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListDevicesWithHttpInfoAsync(search: "status eq \"ACTIVE\"");

            response.Should().NotBeNull();
            response.Data.Should().HaveCount(1);
            mockClient.ReceivedQueryParams.Should().ContainKey("search");
        }

        #endregion

        #region DeleteDeviceAsync Tests

        [Fact]
        public async Task DeleteDeviceAsync_WithValidId_CompletesSuccessfully()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.DeleteDeviceAsync(TestDeviceId);

            mockClient.ReceivedPath.Should().Contain("/api/v1/devices/");
            mockClient.ReceivedPathParams.Should().ContainKey("deviceId");
            mockClient.ReceivedPathParams["deviceId"].Should().Be(TestDeviceId);
        }

        [Fact]
        public async Task DeleteDeviceWithHttpInfoAsync_WithValidId_ReturnsNoContentResponse()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.DeleteDeviceWithHttpInfoAsync(TestDeviceId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPathParams["deviceId"].Should().Be(TestDeviceId);
        }

        #endregion

        #region ActivateDeviceAsync Tests

        [Fact]
        public async Task ActivateDeviceAsync_WithValidId_CompletesSuccessfully()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.ActivateDeviceAsync(TestDeviceId);

            mockClient.ReceivedPath.Should().Contain("/api/v1/devices/");
            mockClient.ReceivedPath.Should().Contain("/lifecycle/activate");
            mockClient.ReceivedPathParams.Should().ContainKey("deviceId");
            mockClient.ReceivedPathParams["deviceId"].Should().Be(TestDeviceId);
        }

        [Fact]
        public async Task ActivateDeviceWithHttpInfoAsync_WithValidId_ReturnsNoContentResponse()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ActivateDeviceWithHttpInfoAsync(TestDeviceId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Contain("/lifecycle/activate");
        }

        #endregion

        #region DeactivateDeviceAsync Tests

        [Fact]
        public async Task DeactivateDeviceAsync_WithValidId_CompletesSuccessfully()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.DeactivateDeviceAsync(TestDeviceId);

            mockClient.ReceivedPath.Should().Contain("/api/v1/devices/");
            mockClient.ReceivedPath.Should().Contain("/lifecycle/deactivate");
            mockClient.ReceivedPathParams.Should().ContainKey("deviceId");
            mockClient.ReceivedPathParams["deviceId"].Should().Be(TestDeviceId);
        }

        [Fact]
        public async Task DeactivateDeviceWithHttpInfoAsync_WithValidId_ReturnsNoContentResponse()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.DeactivateDeviceWithHttpInfoAsync(TestDeviceId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Contain("/lifecycle/deactivate");
        }

        #endregion

        #region SuspendDeviceAsync Tests

        [Fact]
        public async Task SuspendDeviceAsync_WithValidId_CompletesSuccessfully()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.SuspendDeviceAsync(TestDeviceId);

            mockClient.ReceivedPath.Should().Contain("/api/v1/devices/");
            mockClient.ReceivedPath.Should().Contain("/lifecycle/suspend");
            mockClient.ReceivedPathParams.Should().ContainKey("deviceId");
            mockClient.ReceivedPathParams["deviceId"].Should().Be(TestDeviceId);
        }

        [Fact]
        public async Task SuspendDeviceWithHttpInfoAsync_WithValidId_ReturnsNoContentResponse()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.SuspendDeviceWithHttpInfoAsync(TestDeviceId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Contain("/lifecycle/suspend");
        }

        #endregion

        #region UnsuspendDeviceAsync Tests

        [Fact]
        public async Task UnsuspendDeviceAsync_WithValidId_CompletesSuccessfully()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.UnsuspendDeviceAsync(TestDeviceId);

            mockClient.ReceivedPath.Should().Contain("/api/v1/devices/");
            mockClient.ReceivedPath.Should().Contain("/lifecycle/unsuspend");
            mockClient.ReceivedPathParams.Should().ContainKey("deviceId");
            mockClient.ReceivedPathParams["deviceId"].Should().Be(TestDeviceId);
        }

        [Fact]
        public async Task UnsuspendDeviceWithHttpInfoAsync_WithValidId_ReturnsNoContentResponse()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new DeviceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.UnsuspendDeviceWithHttpInfoAsync(TestDeviceId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Contain("/lifecycle/unsuspend");
        }

        #endregion
    }
}
