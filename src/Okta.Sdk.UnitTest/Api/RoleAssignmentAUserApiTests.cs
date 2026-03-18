// <copyright file="RoleAssignmentAUserApiTests.cs" company="Okta, Inc">
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
    public class RoleAssignmentAUserApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _userId = "00u1234567890abcde";
        private readonly string _roleAssignmentId = "ra1234567890abcdef";
        private readonly string _grantId = "grt1234567890abcde";

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });
            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            var act = () => new RoleAssignmentAUserApi(null, new Configuration { BasePath = BaseUrl });
            act.Should().Throw<System.ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var mockClient = new MockAsyncClient("{}");
            var act = () => new RoleAssignmentAUserApi(mockClient, null);
            act.Should().Throw<System.ArgumentNullException>();
        }

        #endregion

        #region AssignRoleToUserAsync Tests

        [Fact]
        public async Task AssignRoleToUserAsync_WithStandardRole_ReturnsAssignRoleResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""label"": ""Super Organization Administrator"",
                ""type"": ""SUPER_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""USER""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new AssignRoleToUserRequest(new StandardRoleAssignmentSchema { Type = "SUPER_ADMIN" });

            // Act
            var result = await api.AssignRoleToUserAsync(_userId, request);

            // Assert
            result.Should().NotBeNull();
            result.GetStandardRole().Should().NotBeNull();
            result.GetStandardRole().Id.Should().Be(_roleAssignmentId);
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
        }

        [Fact]
        public async Task AssignRoleToUserAsync_WithDisableNotificationsTrue_SetsQueryParam()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""type"": ""ORG_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""USER""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new AssignRoleToUserRequest(new StandardRoleAssignmentSchema { Type = "ORG_ADMIN" });

            // Act
            var result = await api.AssignRoleToUserAsync(_userId, request, disableNotifications: true);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("disableNotifications");
            mockClient.ReceivedQueryParams["disableNotifications"].Should().Contain("true");
        }

        [Fact]
        public async Task AssignRoleToUserAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            var request = new AssignRoleToUserRequest(new StandardRoleAssignmentSchema { Type = "ORG_ADMIN" });

            Func<Task> act = async () => await api.AssignRoleToUserAsync(null, request);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task AssignRoleToUserAsync_WithNullRequest_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignRoleToUserAsync(_userId, null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*assignRoleRequest*");
        }

        [Fact]
        public async Task AssignRoleToUserWithHttpInfoAsync_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""type"": ""SUPER_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""USER""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AssignRoleToUserRequest(new StandardRoleAssignmentSchema { Type = "SUPER_ADMIN" });

            // Act
            var response = await api.AssignRoleToUserWithHttpInfoAsync(_userId, request);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region GetRoleAssignmentGovernanceGrantAsync Tests

        [Fact]
        public async Task GetRoleAssignmentGovernanceGrantAsync_WithValidParams_ReturnsGovernanceSource()
        {
            // Arrange
            var responseJson = @"{
                ""grantId"": """ + _grantId + @""",
                ""type"": ""GOVERNANCE"",
                ""expirationDate"": ""2026-01-01T00:00:00.000Z"",
                ""bundleId"": ""bundle123"",
                ""_links"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetRoleAssignmentGovernanceGrantAsync(_userId, _roleAssignmentId, _grantId);

            // Assert
            result.Should().NotBeNull();
            result.GrantId.Should().Be(_grantId);
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles/{roleAssignmentId}/governance/{grantId}");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["grantId"].Should().Contain(_grantId);
        }

        [Fact]
        public async Task GetRoleAssignmentGovernanceGrantAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetRoleAssignmentGovernanceGrantAsync(null, _roleAssignmentId, _grantId);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task GetRoleAssignmentGovernanceGrantAsync_WithNullRoleAssignmentId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetRoleAssignmentGovernanceGrantAsync(_userId, null, _grantId);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*roleAssignmentId*");
        }

        [Fact]
        public async Task GetRoleAssignmentGovernanceGrantAsync_WithNullGrantId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetRoleAssignmentGovernanceGrantAsync(_userId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*grantId*");
        }

        [Fact]
        public async Task GetRoleAssignmentGovernanceGrantWithHttpInfoAsync_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""grantId"": """ + _grantId + @""",
                ""type"": ""GOVERNANCE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetRoleAssignmentGovernanceGrantWithHttpInfoAsync(_userId, _roleAssignmentId, _grantId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.GrantId.Should().Be(_grantId);
        }

        #endregion

        #region GetRoleAssignmentGovernanceGrantResourcesAsync Tests

        [Fact]
        public async Task GetRoleAssignmentGovernanceGrantResourcesAsync_WithValidParams_ReturnsGovernanceResources()
        {
            // Arrange
            var responseJson = @"{
                ""resources"": [],
                ""_links"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetRoleAssignmentGovernanceGrantResourcesAsync(_userId, _roleAssignmentId, _grantId);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles/{roleAssignmentId}/governance/{grantId}/resources");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["grantId"].Should().Contain(_grantId);
        }

        [Fact]
        public async Task GetRoleAssignmentGovernanceGrantResourcesAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetRoleAssignmentGovernanceGrantResourcesAsync(null, _roleAssignmentId, _grantId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task GetRoleAssignmentGovernanceGrantResourcesAsync_WithNullRoleAssignmentId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetRoleAssignmentGovernanceGrantResourcesAsync(_userId, null, _grantId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleAssignmentId*");
        }

        [Fact]
        public async Task GetRoleAssignmentGovernanceGrantResourcesAsync_WithNullGrantId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetRoleAssignmentGovernanceGrantResourcesAsync(_userId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*grantId*");
        }

        [Fact]
        public async Task GetRoleAssignmentGovernanceGrantResourcesWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{ ""resources"": [] }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetRoleAssignmentGovernanceGrantResourcesWithHttpInfoAsync(_userId, _roleAssignmentId, _grantId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region GetUserAssignedRoleAsync Tests

        [Fact]
        public async Task GetUserAssignedRoleAsync_WithValidParams_ReturnsRole()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""label"": ""Super Organization Administrator"",
                ""type"": ""SUPER_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""USER""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetUserAssignedRoleAsync(_userId, _roleAssignmentId);

            // Assert
            result.Should().NotBeNull();
            result.GetStandardRole().Should().NotBeNull();
            result.GetStandardRole().Id.Should().Be(_roleAssignmentId);
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles/{roleAssignmentId}");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
        }

        [Fact]
        public async Task GetUserAssignedRoleAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetUserAssignedRoleAsync(null, _roleAssignmentId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task GetUserAssignedRoleAsync_WithNullRoleAssignmentId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetUserAssignedRoleAsync(_userId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleAssignmentId*");
        }

        [Fact]
        public async Task GetUserAssignedRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""type"": ""SUPER_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""USER""
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetUserAssignedRoleWithHttpInfoAsync(_userId, _roleAssignmentId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region GetUserAssignedRoleGovernanceAsync Tests

        [Fact]
        public async Task GetUserAssignedRoleGovernanceAsync_WithValidParams_ReturnsRoleGovernance()
        {
            // Arrange
            var responseJson = @"{
                ""grants"": [],
                ""_links"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetUserAssignedRoleGovernanceAsync(_userId, _roleAssignmentId);

            // Assert
            result.Should().NotBeNull();
            result.Grants.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles/{roleAssignmentId}/governance");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
        }

        [Fact]
        public async Task GetUserAssignedRoleGovernanceAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetUserAssignedRoleGovernanceAsync(null, _roleAssignmentId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task GetUserAssignedRoleGovernanceAsync_WithNullRoleAssignmentId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetUserAssignedRoleGovernanceAsync(_userId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleAssignmentId*");
        }

        [Fact]
        public async Task GetUserAssignedRoleGovernanceWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{ ""grants"": [] }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetUserAssignedRoleGovernanceWithHttpInfoAsync(_userId, _roleAssignmentId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region ListAssignedRolesForUser Tests

        [Fact]
        public void ListAssignedRolesForUser_WithValidUserId_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListAssignedRolesForUser(_userId);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<ListGroupAssignedRoles200ResponseInner>>();
        }

        [Fact]
        public void ListAssignedRolesForUser_WithExpandParameter_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListAssignedRolesForUser(_userId, expand: "targets/groups");

            result.Should().NotBeNull();
        }

        #endregion

        #region ListUsersWithRoleAssignmentsAsync Tests

        [Fact]
        public async Task ListUsersWithRoleAssignmentsAsync_ReturnsRoleAssignedUsers()
        {
            // Arrange
            var responseJson = @"{
                ""value"": [
                    { ""id"": ""00u1111111111111111"" },
                    { ""id"": ""00u2222222222222222"" }
                ],
                ""_links"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListUsersWithRoleAssignmentsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().HaveCount(2);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/assignees/users");
        }

        [Fact]
        public async Task ListUsersWithRoleAssignmentsAsync_WithAfterParam_SetsQueryParam()
        {
            // Arrange
            var responseJson = @"{ ""value"": [], ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListUsersWithRoleAssignmentsAsync(after: "cursor123");

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor123");
        }

        [Fact]
        public async Task ListUsersWithRoleAssignmentsAsync_WithLimitParam_SetsQueryParam()
        {
            var responseJson = @"{ ""value"": [], ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListUsersWithRoleAssignmentsAsync(limit: 10);

            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("10");
        }

        [Fact]
        public async Task ListUsersWithRoleAssignmentsWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{ ""value"": [] }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListUsersWithRoleAssignmentsWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region UnassignRoleFromUserAsync Tests

        [Fact]
        public async Task UnassignRoleFromUserAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.UnassignRoleFromUserAsync(_userId, _roleAssignmentId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles/{roleAssignmentId}");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
        }

        [Fact]
        public async Task UnassignRoleFromUserAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignRoleFromUserAsync(null, _roleAssignmentId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task UnassignRoleFromUserAsync_WithNullRoleAssignmentId_ThrowsApiException()
        {
            var api = new RoleAssignmentAUserApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignRoleFromUserAsync(_userId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleAssignmentId*");
        }

        [Fact]
        public async Task UnassignRoleFromUserWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.UnassignRoleFromUserWithHttpInfoAsync(_userId, _roleAssignmentId);

            response.Should().NotBeNull();
        }

        #endregion

        #region Interface Implementation Tests

        [Fact]
        public void Api_ImplementsIRoleAssignmentAUserApi()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new RoleAssignmentAUserApi(mockClient, new Configuration { BasePath = BaseUrl });

            api.Should().BeAssignableTo<IRoleAssignmentAUserApi>();
            api.Should().BeAssignableTo<IRoleAssignmentAUserApiAsync>();
        }

        #endregion
    }
}
