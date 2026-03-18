// <copyright file="RoleAssignmentBGroupApiTests.cs" company="Okta, Inc">
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
    public class RoleAssignmentBGroupApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _groupId = "00g1234567890abcde";
        private readonly string _roleAssignmentId = "ra1234567890abcdef";

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new RoleAssignmentBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });
            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            var act = () => new RoleAssignmentBGroupApi(null, new Configuration { BasePath = BaseUrl });
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var mockClient = new MockAsyncClient("{}");
            var act = () => new RoleAssignmentBGroupApi(mockClient, null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Api_ImplementsIRoleAssignmentBGroupApi()
        {
            var api = new RoleAssignmentBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().BeAssignableTo<IRoleAssignmentBGroupApi>();
            api.Should().BeAssignableTo<IRoleAssignmentBGroupApiAsync>();
        }

        #endregion

        #region AssignRoleToGroupAsync Tests

        [Fact]
        public async Task AssignRoleToGroupAsync_WithStandardRole_ReturnsRoleAssignment()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""label"": ""Organization Administrator"",
                ""type"": ""ORG_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""GROUP""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AssignRoleToGroupRequest(new StandardRoleAssignmentSchema { Type = "ORG_ADMIN" });

            // Act
            var result = await api.AssignRoleToGroupAsync(_groupId, request);

            // Assert
            result.Should().NotBeNull();
            result.GetStandardRole().Should().NotBeNull();
            result.GetStandardRole().Id.Should().Be(_roleAssignmentId);
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/{groupId}/roles");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        [Fact]
        public async Task AssignRoleToGroupAsync_WithDisableNotificationsTrue_SetsQueryParam()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""type"": ""ORG_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""GROUP""
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AssignRoleToGroupRequest(new StandardRoleAssignmentSchema { Type = "ORG_ADMIN" });

            // Act
            var result = await api.AssignRoleToGroupAsync(_groupId, request, disableNotifications: true);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("disableNotifications");
            mockClient.ReceivedQueryParams["disableNotifications"].Should().Contain("true");
        }

        [Fact]
        public async Task AssignRoleToGroupAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleAssignmentBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            var request = new AssignRoleToGroupRequest(new StandardRoleAssignmentSchema { Type = "ORG_ADMIN" });

            Func<Task> act = async () => await api.AssignRoleToGroupAsync(null, request);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task AssignRoleToGroupAsync_WithNullRequest_ThrowsApiException()
        {
            var api = new RoleAssignmentBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignRoleToGroupAsync(_groupId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*assignRoleRequest*");
        }

        [Fact]
        public async Task AssignRoleToGroupWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""type"": ""ORG_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""GROUP""
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AssignRoleToGroupRequest(new StandardRoleAssignmentSchema { Type = "ORG_ADMIN" });

            var response = await api.AssignRoleToGroupWithHttpInfoAsync(_groupId, request);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region GetGroupAssignedRoleAsync Tests

        [Fact]
        public async Task GetGroupAssignedRoleAsync_WithValidParams_ReturnsRole()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""label"": ""Group Administrator"",
                ""type"": ""GROUP_MEMBERSHIP_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""GROUP""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetGroupAssignedRoleAsync(_groupId, _roleAssignmentId);

            // Assert
            result.Should().NotBeNull();
            result.GetStandardRole().Should().NotBeNull();
            result.GetStandardRole().Id.Should().Be(_roleAssignmentId);
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/{groupId}/roles/{roleAssignmentId}");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
        }

        [Fact]
        public async Task GetGroupAssignedRoleAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleAssignmentBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetGroupAssignedRoleAsync(null, _roleAssignmentId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task GetGroupAssignedRoleAsync_WithNullRoleAssignmentId_ThrowsApiException()
        {
            var api = new RoleAssignmentBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetGroupAssignedRoleAsync(_groupId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleAssignmentId*");
        }

        [Fact]
        public async Task GetGroupAssignedRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""type"": ""GROUP_MEMBERSHIP_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""GROUP""
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetGroupAssignedRoleWithHttpInfoAsync(_groupId, _roleAssignmentId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region ListGroupAssignedRoles Tests

        [Fact]
        public void ListGroupAssignedRoles_WithValidGroupId_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleAssignmentBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListGroupAssignedRoles(_groupId);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<ListGroupAssignedRoles200ResponseInner>>();
        }

        [Fact]
        public void ListGroupAssignedRoles_WithExpandParameter_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleAssignmentBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListGroupAssignedRoles(_groupId, expand: "targets/groups");

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ListGroupAssignedRolesWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"[
                {
                    ""id"": """ + _roleAssignmentId + @""",
                    ""type"": ""ORG_ADMIN"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2019-02-06T16:20:57.000Z"",
                    ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                    ""assignmentType"": ""GROUP""
                }
            ]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListGroupAssignedRolesWithHttpInfoAsync(_groupId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(1);
        }

        #endregion

        #region UnassignRoleFromGroupAsync Tests

        [Fact]
        public async Task UnassignRoleFromGroupAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleAssignmentBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.UnassignRoleFromGroupAsync(_groupId, _roleAssignmentId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/{groupId}/roles/{roleAssignmentId}");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
        }

        [Fact]
        public async Task UnassignRoleFromGroupAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleAssignmentBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignRoleFromGroupAsync(null, _roleAssignmentId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task UnassignRoleFromGroupAsync_WithNullRoleAssignmentId_ThrowsApiException()
        {
            var api = new RoleAssignmentBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignRoleFromGroupAsync(_groupId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleAssignmentId*");
        }

        [Fact]
        public async Task UnassignRoleFromGroupWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleAssignmentBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.UnassignRoleFromGroupWithHttpInfoAsync(_groupId, _roleAssignmentId);

            response.Should().NotBeNull();
        }

        #endregion
    }
}
