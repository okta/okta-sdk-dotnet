// <copyright file="RoleECustomApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
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
    public class RoleECustomApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _roleId = "cr0Yq6IJxGIr0ouum0g3";
        private readonly string _roleLabel = "UserAdmin";

        private string RoleJson => @"{
            ""id"": """ + _roleId + @""",
            ""label"": """ + _roleLabel + @""",
            ""description"": ""Manages all users"",
            ""created"": ""2021-02-06T16:20:57.000Z"",
            ""lastUpdated"": ""2021-02-06T16:20:57.000Z"",
            ""_links"": {}
        }";

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var api = new RoleECustomApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            var act = () => new RoleECustomApi(null, new Configuration { BasePath = BaseUrl });
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new RoleECustomApi(new MockAsyncClient("{}"), null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Api_ImplementsIRoleECustomApi()
        {
            var api = new RoleECustomApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().BeAssignableTo<IRoleECustomApi>();
        }

        #endregion

        #region CreateRoleAsync Tests

        [Fact]
        public async Task CreateRoleAsync_WithValidRequest_ReturnsIamRole()
        {
            // Arrange
            var mockClient = new MockAsyncClient(RoleJson);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new CreateIamRoleRequest
            {
                Label = _roleLabel,
                Description = "Manages all users",
                Permissions = new List<string> { "okta.users.manage" }
            };

            // Act
            var result = await api.CreateRoleAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_roleId);
            result.Label.Should().Be(_roleLabel);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/roles");
            mockClient.ReceivedBody.Should().Contain(_roleLabel);
        }

        [Fact]
        public async Task CreateRoleAsync_WithNullRequest_ThrowsApiException()
        {
            var api = new RoleECustomApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.CreateRoleAsync(null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*instance*");
        }

        [Fact]
        public async Task CreateRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient(RoleJson);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.CreateRoleWithHttpInfoAsync(new CreateIamRoleRequest { Label = _roleLabel });

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_roleId);
        }

        #endregion

        #region DeleteRoleAsync Tests

        [Fact]
        public async Task DeleteRoleAsync_WithId_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteRoleAsync(_roleId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/roles/{roleIdOrLabel}");
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
        }

        [Fact]
        public async Task DeleteRoleAsync_WithLabel_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteRoleAsync(_roleLabel);

            // Assert
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleLabel);
        }

        [Fact]
        public async Task DeleteRoleAsync_WithNullId_ThrowsApiException()
        {
            var api = new RoleECustomApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.DeleteRoleAsync(null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task DeleteRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.DeleteRoleWithHttpInfoAsync(_roleId);

            response.Should().NotBeNull();
        }

        #endregion

        #region GetRoleAsync Tests

        [Fact]
        public async Task GetRoleAsync_WithId_ReturnsIamRole()
        {
            // Arrange
            var mockClient = new MockAsyncClient(RoleJson);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetRoleAsync(_roleId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_roleId);
            result.Label.Should().Be(_roleLabel);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/roles/{roleIdOrLabel}");
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
        }

        [Fact]
        public async Task GetRoleAsync_WithLabel_ReturnsIamRole()
        {
            // Arrange
            var mockClient = new MockAsyncClient(RoleJson);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetRoleAsync(_roleLabel);

            result.Should().NotBeNull();
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleLabel);
        }

        [Fact]
        public async Task GetRoleAsync_WithNullId_ThrowsApiException()
        {
            var api = new RoleECustomApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetRoleAsync(null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task GetRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient(RoleJson);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetRoleWithHttpInfoAsync(_roleId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_roleId);
        }

        #endregion

        #region ListRolesAsync Tests

        [Fact]
        public async Task ListRolesAsync_ReturnsIamRoles()
        {
            // Arrange
            var responseJson = @"{
                ""roles"": [
                    {
                        ""id"": """ + _roleId + @""",
                        ""label"": """ + _roleLabel + @""",
                        ""description"": ""Manages all users"",
                        ""created"": ""2021-02-06T16:20:57.000Z"",
                        ""lastUpdated"": ""2021-02-06T16:20:57.000Z"",
                        ""_links"": {}
                    }
                ],
                ""_links"": {}
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListRolesAsync();

            // Assert
            result.Should().NotBeNull();
            result.Roles.Should().HaveCount(1);
            result.Roles[0].Id.Should().Be(_roleId);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/roles");
        }

        [Fact]
        public async Task ListRolesAsync_WithAfterParam_SetsQueryParam()
        {
            // Arrange
            var responseJson = @"{ ""roles"": [], ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListRolesAsync(after: "cursor123");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor123");
        }

        [Fact]
        public async Task ListRolesWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{ ""roles"": [], ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListRolesWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region ReplaceRoleAsync Tests

        [Fact]
        public async Task ReplaceRoleAsync_WithValidRequest_ReturnsUpdatedIamRole()
        {
            // Arrange
            var updatedLabel = "UpdatedUserAdmin";
            var responseJson = @"{
                ""id"": """ + _roleId + @""",
                ""label"": """ + updatedLabel + @""",
                ""description"": ""Updated description"",
                ""created"": ""2021-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2022-01-01T00:00:00.000Z"",
                ""_links"": {}
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new UpdateIamRoleRequest
            {
                Label = updatedLabel,
                Description = "Updated description"
            };

            // Act
            var result = await api.ReplaceRoleAsync(_roleId, request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_roleId);
            result.Label.Should().Be(updatedLabel);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/roles/{roleIdOrLabel}");
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
        }

        [Fact]
        public async Task ReplaceRoleAsync_WithNullId_ThrowsApiException()
        {
            var api = new RoleECustomApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ReplaceRoleAsync(null, new UpdateIamRoleRequest());

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task ReplaceRoleAsync_WithNullBody_ThrowsApiException()
        {
            var api = new RoleECustomApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ReplaceRoleAsync(_roleId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*instance*");
        }

        [Fact]
        public async Task ReplaceRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient(RoleJson);
            var api = new RoleECustomApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ReplaceRoleWithHttpInfoAsync(_roleId, new UpdateIamRoleRequest { Label = _roleLabel });

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion
    }
}
