// <copyright file="RoleBTargetAdminApiTests.cs" company="Okta, Inc">
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
    public class RoleBTargetAdminApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _userId = "00u1234567890abcde";
        private readonly string _roleAssignmentId = "ra1234567890abcdef";
        private readonly string _roleIdOrEncodedRoleId = "SUPER_ADMIN";
        private readonly string _appName = "salesforce";
        private readonly string _appId = "0oa1234567890abcde";
        private readonly string _groupId = "00g1234567890abcde";

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            var act = () => new RoleBTargetAdminApi(null, new Configuration { BasePath = BaseUrl });
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new RoleBTargetAdminApi(new MockAsyncClient("{}"), null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Api_ImplementsIRoleBTargetAdminApi()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().BeAssignableTo<IRoleBTargetAdminApi>();
        }

        #endregion

        #region AssignAllAppsAsTargetToRoleForUserAsync Tests

        [Fact]
        public async Task AssignAllAppsAsTargetToRoleForUserAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.AssignAllAppsAsTargetToRoleForUserAsync(_userId, _roleAssignmentId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles/{roleAssignmentId}/targets/catalog/apps");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
        }

        [Fact]
        public async Task AssignAllAppsAsTargetToRoleForUserAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAllAppsAsTargetToRoleForUserAsync(null, _roleAssignmentId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task AssignAllAppsAsTargetToRoleForUserAsync_WithNullRoleAssignmentId_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAllAppsAsTargetToRoleForUserAsync(_userId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleAssignmentId*");
        }

        [Fact]
        public async Task AssignAllAppsAsTargetToRoleForUserWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AssignAllAppsAsTargetToRoleForUserWithHttpInfoAsync(_userId, _roleAssignmentId);

            response.Should().NotBeNull();
        }

        #endregion

        #region AssignAppInstanceTargetToAppAdminRoleForUserAsync Tests

        [Fact]
        public async Task AssignAppInstanceTargetToAppAdminRoleForUserAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.AssignAppInstanceTargetToAppAdminRoleForUserAsync(_userId, _roleAssignmentId, _appName, _appId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}/{appId}");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["appName"].Should().Contain(_appName);
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task AssignAppInstanceTargetToAppAdminRoleForUserAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppInstanceTargetToAppAdminRoleForUserAsync(null, _roleAssignmentId, _appName, _appId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task AssignAppInstanceTargetToAppAdminRoleForUserAsync_WithNullAppName_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppInstanceTargetToAppAdminRoleForUserAsync(_userId, _roleAssignmentId, null, _appId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appName*");
        }

        [Fact]
        public async Task AssignAppInstanceTargetToAppAdminRoleForUserAsync_WithNullAppId_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppInstanceTargetToAppAdminRoleForUserAsync(_userId, _roleAssignmentId, _appName, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appId*");
        }

        [Fact]
        public async Task AssignAppInstanceTargetToAppAdminRoleForUserWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AssignAppInstanceTargetToAppAdminRoleForUserWithHttpInfoAsync(_userId, _roleAssignmentId, _appName, _appId);

            response.Should().NotBeNull();
        }

        #endregion

        #region AssignAppTargetToAdminRoleForUserAsync Tests

        [Fact]
        public async Task AssignAppTargetToAdminRoleForUserAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.AssignAppTargetToAdminRoleForUserAsync(_userId, _roleAssignmentId, _appName);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["appName"].Should().Contain(_appName);
        }

        [Fact]
        public async Task AssignAppTargetToAdminRoleForUserAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppTargetToAdminRoleForUserAsync(null, _roleAssignmentId, _appName);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task AssignAppTargetToAdminRoleForUserAsync_WithNullAppName_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppTargetToAdminRoleForUserAsync(_userId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appName*");
        }

        [Fact]
        public async Task AssignAppTargetToAdminRoleForUserWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AssignAppTargetToAdminRoleForUserWithHttpInfoAsync(_userId, _roleAssignmentId, _appName);

            response.Should().NotBeNull();
        }

        #endregion

        #region AssignGroupTargetToUserRoleAsync Tests

        [Fact]
        public async Task AssignGroupTargetToUserRoleAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.AssignGroupTargetToUserRoleAsync(_userId, _roleAssignmentId, _groupId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles/{roleAssignmentId}/targets/groups/{groupId}");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        [Fact]
        public async Task AssignGroupTargetToUserRoleAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignGroupTargetToUserRoleAsync(null, _roleAssignmentId, _groupId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task AssignGroupTargetToUserRoleAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignGroupTargetToUserRoleAsync(_userId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task AssignGroupTargetToUserRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AssignGroupTargetToUserRoleWithHttpInfoAsync(_userId, _roleAssignmentId, _groupId);

            response.Should().NotBeNull();
        }

        #endregion

        #region GetRoleTargetsByUserIdAndRoleId Tests

        [Fact]
        public void GetRoleTargetsByUserIdAndRoleId_WithValidParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.GetRoleTargetsByUserIdAndRoleId(_userId, _roleIdOrEncodedRoleId);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<RoleTarget>>();
        }

        [Fact]
        public void GetRoleTargetsByUserIdAndRoleId_WithOptionalParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.GetRoleTargetsByUserIdAndRoleId(_userId, _roleIdOrEncodedRoleId, after: "cursor123", limit: 20);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRoleTargetsByUserIdAndRoleIdWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"[{ ""name"": ""salesforce"" }]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetRoleTargetsByUserIdAndRoleIdWithHttpInfoAsync(_userId, _roleIdOrEncodedRoleId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region ListApplicationTargetsForApplicationAdministratorRoleForUser Tests

        [Fact]
        public void ListApplicationTargetsForApplicationAdministratorRoleForUser_WithValidParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListApplicationTargetsForApplicationAdministratorRoleForUser(_userId, _roleAssignmentId);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<CatalogApplication>>();
        }

        [Fact]
        public void ListApplicationTargetsForApplicationAdministratorRoleForUser_WithPaginationParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListApplicationTargetsForApplicationAdministratorRoleForUser(_userId, _roleAssignmentId, after: "cursor123", limit: 25);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ListApplicationTargetsForApplicationAdministratorRoleForUserWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListApplicationTargetsForApplicationAdministratorRoleForUserWithHttpInfoAsync(_userId, _roleAssignmentId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region ListGroupTargetsForRole Tests

        [Fact]
        public void ListGroupTargetsForRole_WithValidParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListGroupTargetsForRole(_userId, _roleAssignmentId);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<Group>>();
        }

        [Fact]
        public void ListGroupTargetsForRole_WithPaginationParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListGroupTargetsForRole(_userId, _roleAssignmentId, after: "cursor456", limit: 10);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ListGroupTargetsForRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListGroupTargetsForRoleWithHttpInfoAsync(_userId, _roleAssignmentId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region UnassignAppInstanceTargetFromAdminRoleForUserAsync Tests

        [Fact]
        public async Task UnassignAppInstanceTargetFromAdminRoleForUserAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.UnassignAppInstanceTargetFromAdminRoleForUserAsync(_userId, _roleAssignmentId, _appName, _appId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}/{appId}");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
            mockClient.ReceivedPathParams["appName"].Should().Contain(_appName);
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task UnassignAppInstanceTargetFromAdminRoleForUserAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignAppInstanceTargetFromAdminRoleForUserAsync(null, _roleAssignmentId, _appName, _appId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task UnassignAppInstanceTargetFromAdminRoleForUserAsync_WithNullAppName_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignAppInstanceTargetFromAdminRoleForUserAsync(_userId, _roleAssignmentId, null, _appId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appName*");
        }

        [Fact]
        public async Task UnassignAppInstanceTargetFromAdminRoleForUserAsync_WithNullAppId_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignAppInstanceTargetFromAdminRoleForUserAsync(_userId, _roleAssignmentId, _appName, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appId*");
        }

        [Fact]
        public async Task UnassignAppInstanceTargetFromAdminRoleForUserWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.UnassignAppInstanceTargetFromAdminRoleForUserWithHttpInfoAsync(_userId, _roleAssignmentId, _appName, _appId);

            response.Should().NotBeNull();
        }

        #endregion

        #region UnassignAppTargetFromAppAdminRoleForUserAsync Tests

        [Fact]
        public async Task UnassignAppTargetFromAppAdminRoleForUserAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.UnassignAppTargetFromAppAdminRoleForUserAsync(_userId, _roleAssignmentId, _appName);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["appName"].Should().Contain(_appName);
        }

        [Fact]
        public async Task UnassignAppTargetFromAppAdminRoleForUserAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignAppTargetFromAppAdminRoleForUserAsync(null, _roleAssignmentId, _appName);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task UnassignAppTargetFromAppAdminRoleForUserAsync_WithNullAppName_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignAppTargetFromAppAdminRoleForUserAsync(_userId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appName*");
        }

        [Fact]
        public async Task UnassignAppTargetFromAppAdminRoleForUserWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.UnassignAppTargetFromAppAdminRoleForUserWithHttpInfoAsync(_userId, _roleAssignmentId, _appName);

            response.Should().NotBeNull();
        }

        #endregion

        #region UnassignGroupTargetFromUserAdminRoleAsync Tests

        [Fact]
        public async Task UnassignGroupTargetFromUserAdminRoleAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.UnassignGroupTargetFromUserAdminRoleAsync(_userId, _roleAssignmentId, _groupId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{userId}/roles/{roleAssignmentId}/targets/groups/{groupId}");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        [Fact]
        public async Task UnassignGroupTargetFromUserAdminRoleAsync_WithNullUserId_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignGroupTargetFromUserAdminRoleAsync(null, _roleAssignmentId, _groupId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*userId*");
        }

        [Fact]
        public async Task UnassignGroupTargetFromUserAdminRoleAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleBTargetAdminApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignGroupTargetFromUserAdminRoleAsync(_userId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task UnassignGroupTargetFromUserAdminRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetAdminApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.UnassignGroupTargetFromUserAdminRoleWithHttpInfoAsync(_userId, _roleAssignmentId, _groupId);

            response.Should().NotBeNull();
        }

        #endregion
    }
}
