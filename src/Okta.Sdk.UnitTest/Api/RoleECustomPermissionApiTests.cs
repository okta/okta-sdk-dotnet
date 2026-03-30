// <copyright file="RoleECustomPermissionApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
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
    public class RoleECustomPermissionApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _roleId = "cr0Yq6IJxGIr0ouum0g3";
        private readonly string _roleLabel = "UserAdmin";
        private readonly string _permissionType = "okta.users.manage";

        private string PermissionJson => @"{
            ""label"": """ + _permissionType + @""",
            ""created"": ""2021-02-06T16:20:57.000Z"",
            ""lastUpdated"": ""2021-02-06T16:20:57.000Z"",
            ""_links"": {}
        }";

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var api = new RoleECustomPermissionApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            var act = () => new RoleECustomPermissionApi(null, new Configuration { BasePath = BaseUrl });
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new RoleECustomPermissionApi(new MockAsyncClient("{}"), null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Api_ImplementsIRoleECustomPermissionApi()
        {
            var api = new RoleECustomPermissionApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().BeAssignableTo<IRoleECustomPermissionApi>();
        }

        #endregion

        #region CreateRolePermissionAsync Tests

        [Fact]
        public async Task CreateRolePermissionAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.CreateRolePermissionAsync(_roleId, _permissionType);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType}");
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
            mockClient.ReceivedPathParams["permissionType"].Should().Contain(_permissionType);
        }

        [Fact]
        public async Task CreateRolePermissionAsync_WithLabel_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.CreateRolePermissionAsync(_roleLabel, _permissionType);

            // Assert
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleLabel);
        }

        [Fact]
        public async Task CreateRolePermissionAsync_WithOptionalBody_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new CreateUpdateIamRolePermissionRequest();

            // Act
            await api.CreateRolePermissionAsync(_roleId, _permissionType, request);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType}");
        }

        [Fact]
        public async Task CreateRolePermissionAsync_WithNullRoleId_ThrowsApiException()
        {
            var api = new RoleECustomPermissionApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.CreateRolePermissionAsync(null, _permissionType);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task CreateRolePermissionAsync_WithNullPermissionType_ThrowsApiException()
        {
            var api = new RoleECustomPermissionApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.CreateRolePermissionAsync(_roleId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*permissionType*");
        }

        [Fact]
        public async Task CreateRolePermissionWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.CreateRolePermissionWithHttpInfoAsync(_roleId, _permissionType);

            response.Should().NotBeNull();
        }

        #endregion

        #region DeleteRolePermissionAsync Tests

        [Fact]
        public async Task DeleteRolePermissionAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteRolePermissionAsync(_roleId, _permissionType);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType}");
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
            mockClient.ReceivedPathParams["permissionType"].Should().Contain(_permissionType);
        }

        [Fact]
        public async Task DeleteRolePermissionAsync_WithLabel_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteRolePermissionAsync(_roleLabel, _permissionType);

            // Assert
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleLabel);
        }

        [Fact]
        public async Task DeleteRolePermissionAsync_WithNullRoleId_ThrowsApiException()
        {
            var api = new RoleECustomPermissionApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.DeleteRolePermissionAsync(null, _permissionType);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task DeleteRolePermissionAsync_WithNullPermissionType_ThrowsApiException()
        {
            var api = new RoleECustomPermissionApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.DeleteRolePermissionAsync(_roleId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*permissionType*");
        }

        [Fact]
        public async Task DeleteRolePermissionWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.DeleteRolePermissionWithHttpInfoAsync(_roleId, _permissionType);

            response.Should().NotBeNull();
        }

        #endregion

        #region GetRolePermissionAsync Tests

        [Fact]
        public async Task GetRolePermissionAsync_WithValidParams_ReturnsPermission()
        {
            // Arrange
            var mockClient = new MockAsyncClient(PermissionJson);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetRolePermissionAsync(_roleId, _permissionType);

            // Assert
            result.Should().NotBeNull();
            result.Label.Should().Be(_permissionType);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType}");
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
            mockClient.ReceivedPathParams["permissionType"].Should().Contain(_permissionType);
        }

        [Fact]
        public async Task GetRolePermissionAsync_WithLabel_ReturnsPermission()
        {
            // Arrange
            var mockClient = new MockAsyncClient(PermissionJson);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetRolePermissionAsync(_roleLabel, _permissionType);

            result.Should().NotBeNull();
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleLabel);
        }

        [Fact]
        public async Task GetRolePermissionAsync_WithNullRoleId_ThrowsApiException()
        {
            var api = new RoleECustomPermissionApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetRolePermissionAsync(null, _permissionType);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task GetRolePermissionAsync_WithNullPermissionType_ThrowsApiException()
        {
            var api = new RoleECustomPermissionApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetRolePermissionAsync(_roleId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*permissionType*");
        }

        [Fact]
        public async Task GetRolePermissionWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient(PermissionJson);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetRolePermissionWithHttpInfoAsync(_roleId, _permissionType);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Label.Should().Be(_permissionType);
        }

        #endregion

        #region ListRolePermissionsAsync Tests

        [Fact]
        public async Task ListRolePermissionsAsync_WithValidRoleId_ReturnsPermissions()
        {
            // Arrange
            var responseJson = @"{
                ""permissions"": [
                    {
                        ""label"": """ + _permissionType + @""",
                        ""created"": ""2021-02-06T16:20:57.000Z"",
                        ""lastUpdated"": ""2021-02-06T16:20:57.000Z"",
                        ""_links"": {}
                    }
                ]
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListRolePermissionsAsync(_roleId);

            // Assert
            result.Should().NotBeNull();
            result._Permissions.Should().HaveCount(1);
            result._Permissions[0].Label.Should().Be(_permissionType);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/roles/{roleIdOrLabel}/permissions");
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
        }

        [Fact]
        public async Task ListRolePermissionsAsync_WithLabel_ReturnsPermissions()
        {
            // Arrange
            var responseJson = @"{ ""permissions"": [] }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.ListRolePermissionsAsync(_roleLabel);

            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleLabel);
        }

        [Fact]
        public async Task ListRolePermissionsAsync_WithNullRoleId_ThrowsApiException()
        {
            var api = new RoleECustomPermissionApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ListRolePermissionsAsync(null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task ListRolePermissionsWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{ ""permissions"": [] }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListRolePermissionsWithHttpInfoAsync(_roleId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region ReplaceRolePermissionAsync Tests

        [Fact]
        public async Task ReplaceRolePermissionAsync_WithValidParams_ReturnsPermission()
        {
            // Arrange
            var mockClient = new MockAsyncClient(PermissionJson);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ReplaceRolePermissionAsync(_roleId, _permissionType);

            // Assert
            result.Should().NotBeNull();
            result.Label.Should().Be(_permissionType);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType}");
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
            mockClient.ReceivedPathParams["permissionType"].Should().Contain(_permissionType);
        }

        [Fact]
        public async Task ReplaceRolePermissionAsync_WithOptionalBody_ReturnsPermission()
        {
            // Arrange
            var mockClient = new MockAsyncClient(PermissionJson);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new CreateUpdateIamRolePermissionRequest();

            // Act
            var result = await api.ReplaceRolePermissionAsync(_roleId, _permissionType, request);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ReplaceRolePermissionAsync_WithLabel_ReturnsPermission()
        {
            // Arrange
            var mockClient = new MockAsyncClient(PermissionJson);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ReplaceRolePermissionAsync(_roleLabel, _permissionType);

            result.Should().NotBeNull();
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleLabel);
        }

        [Fact]
        public async Task ReplaceRolePermissionAsync_WithNullRoleId_ThrowsApiException()
        {
            var api = new RoleECustomPermissionApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ReplaceRolePermissionAsync(null, _permissionType);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task ReplaceRolePermissionAsync_WithNullPermissionType_ThrowsApiException()
        {
            var api = new RoleECustomPermissionApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ReplaceRolePermissionAsync(_roleId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*permissionType*");
        }

        [Fact]
        public async Task ReplaceRolePermissionWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient(PermissionJson);
            var api = new RoleECustomPermissionApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ReplaceRolePermissionWithHttpInfoAsync(_roleId, _permissionType);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Label.Should().Be(_permissionType);
        }

        #endregion
    }
}
