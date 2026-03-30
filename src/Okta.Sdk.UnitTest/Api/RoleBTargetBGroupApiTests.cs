// <copyright file="RoleBTargetBGroupApiTests.cs" company="Okta, Inc">
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
    public class RoleBTargetBGroupApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _groupId = "00g1234567890abcde";
        private readonly string _roleAssignmentId = "ra1234567890abcdef";
        private readonly string _appName = "salesforce";
        private readonly string _appId = "0oa1234567890abcde";
        private readonly string _targetGroupId = "00g9876543210fedcb";

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            var act = () => new RoleBTargetBGroupApi(null, new Configuration { BasePath = BaseUrl });
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new RoleBTargetBGroupApi(new MockAsyncClient("{}"), null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Api_ImplementsIRoleBTargetBGroupApi()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().BeAssignableTo<IRoleBTargetBGroupApi>();
        }

        #endregion

        #region AssignAppInstanceTargetToAppAdminRoleForGroupAsync Tests

        [Fact]
        public async Task AssignAppInstanceTargetToAppAdminRoleForGroupAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.AssignAppInstanceTargetToAppAdminRoleForGroupAsync(_groupId, _roleAssignmentId, _appName, _appId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}/{appId}");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["appName"].Should().Contain(_appName);
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task AssignAppInstanceTargetToAppAdminRoleForGroupAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppInstanceTargetToAppAdminRoleForGroupAsync(null, _roleAssignmentId, _appName, _appId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task AssignAppInstanceTargetToAppAdminRoleForGroupAsync_WithNullAppName_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppInstanceTargetToAppAdminRoleForGroupAsync(_groupId, _roleAssignmentId, null, _appId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appName*");
        }

        [Fact]
        public async Task AssignAppInstanceTargetToAppAdminRoleForGroupAsync_WithNullAppId_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppInstanceTargetToAppAdminRoleForGroupAsync(_groupId, _roleAssignmentId, _appName, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appId*");
        }

        [Fact]
        public async Task AssignAppInstanceTargetToAppAdminRoleForGroupWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AssignAppInstanceTargetToAppAdminRoleForGroupWithHttpInfoAsync(_groupId, _roleAssignmentId, _appName, _appId);

            response.Should().NotBeNull();
        }

        #endregion

        #region AssignAppTargetToAdminRoleForGroupAsync Tests

        [Fact]
        public async Task AssignAppTargetToAdminRoleForGroupAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.AssignAppTargetToAdminRoleForGroupAsync(_groupId, _roleAssignmentId, _appName);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["appName"].Should().Contain(_appName);
        }

        [Fact]
        public async Task AssignAppTargetToAdminRoleForGroupAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppTargetToAdminRoleForGroupAsync(null, _roleAssignmentId, _appName);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task AssignAppTargetToAdminRoleForGroupAsync_WithNullAppName_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppTargetToAdminRoleForGroupAsync(_groupId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appName*");
        }

        [Fact]
        public async Task AssignAppTargetToAdminRoleForGroupWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AssignAppTargetToAdminRoleForGroupWithHttpInfoAsync(_groupId, _roleAssignmentId, _appName);

            response.Should().NotBeNull();
        }

        #endregion

        #region AssignGroupTargetToGroupAdminRoleAsync Tests

        [Fact]
        public async Task AssignGroupTargetToGroupAdminRoleAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.AssignGroupTargetToGroupAdminRoleAsync(_groupId, _roleAssignmentId, _targetGroupId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/groups/{targetGroupId}");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["targetGroupId"].Should().Contain(_targetGroupId);
        }

        [Fact]
        public async Task AssignGroupTargetToGroupAdminRoleAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignGroupTargetToGroupAdminRoleAsync(null, _roleAssignmentId, _targetGroupId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task AssignGroupTargetToGroupAdminRoleAsync_WithNullTargetGroupId_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignGroupTargetToGroupAdminRoleAsync(_groupId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*targetGroupId*");
        }

        [Fact]
        public async Task AssignGroupTargetToGroupAdminRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AssignGroupTargetToGroupAdminRoleWithHttpInfoAsync(_groupId, _roleAssignmentId, _targetGroupId);

            response.Should().NotBeNull();
        }

        #endregion

        #region ListApplicationTargetsForApplicationAdministratorRoleForGroup Tests

        [Fact]
        public void ListApplicationTargetsForApplicationAdministratorRoleForGroup_WithValidParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListApplicationTargetsForApplicationAdministratorRoleForGroup(_groupId, _roleAssignmentId);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<CatalogApplication>>();
        }

        [Fact]
        public void ListApplicationTargetsForApplicationAdministratorRoleForGroup_WithPaginationParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListApplicationTargetsForApplicationAdministratorRoleForGroup(_groupId, _roleAssignmentId, after: "cursor123", limit: 50);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ListApplicationTargetsForApplicationAdministratorRoleForGroupWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListApplicationTargetsForApplicationAdministratorRoleForGroupWithHttpInfoAsync(_groupId, _roleAssignmentId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region ListGroupTargetsForGroupRole Tests

        [Fact]
        public void ListGroupTargetsForGroupRole_WithValidParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListGroupTargetsForGroupRole(_groupId, _roleAssignmentId);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<Group>>();
        }

        [Fact]
        public void ListGroupTargetsForGroupRole_WithPaginationParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListGroupTargetsForGroupRole(_groupId, _roleAssignmentId, after: "cursor456", limit: 10);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ListGroupTargetsForGroupRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListGroupTargetsForGroupRoleWithHttpInfoAsync(_groupId, _roleAssignmentId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region UnassignAppInstanceTargetToAppAdminRoleForGroupAsync Tests

        [Fact]
        public async Task UnassignAppInstanceTargetToAppAdminRoleForGroupAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.UnassignAppInstanceTargetToAppAdminRoleForGroupAsync(_groupId, _roleAssignmentId, _appName, _appId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}/{appId}");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedPathParams["appName"].Should().Contain(_appName);
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task UnassignAppInstanceTargetToAppAdminRoleForGroupAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignAppInstanceTargetToAppAdminRoleForGroupAsync(null, _roleAssignmentId, _appName, _appId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task UnassignAppInstanceTargetToAppAdminRoleForGroupAsync_WithNullAppName_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignAppInstanceTargetToAppAdminRoleForGroupAsync(_groupId, _roleAssignmentId, null, _appId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appName*");
        }

        [Fact]
        public async Task UnassignAppInstanceTargetToAppAdminRoleForGroupWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.UnassignAppInstanceTargetToAppAdminRoleForGroupWithHttpInfoAsync(_groupId, _roleAssignmentId, _appName, _appId);

            response.Should().NotBeNull();
        }

        #endregion

        #region UnassignAppTargetToAdminRoleForGroupAsync Tests

        [Fact]
        public async Task UnassignAppTargetToAdminRoleForGroupAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.UnassignAppTargetToAdminRoleForGroupAsync(_groupId, _roleAssignmentId, _appName);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["appName"].Should().Contain(_appName);
        }

        [Fact]
        public async Task UnassignAppTargetToAdminRoleForGroupAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignAppTargetToAdminRoleForGroupAsync(null, _roleAssignmentId, _appName);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task UnassignAppTargetToAdminRoleForGroupAsync_WithNullAppName_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignAppTargetToAdminRoleForGroupAsync(_groupId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appName*");
        }

        [Fact]
        public async Task UnassignAppTargetToAdminRoleForGroupWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.UnassignAppTargetToAdminRoleForGroupWithHttpInfoAsync(_groupId, _roleAssignmentId, _appName);

            response.Should().NotBeNull();
        }

        #endregion

        #region UnassignGroupTargetFromGroupAdminRoleAsync Tests

        [Fact]
        public async Task UnassignGroupTargetFromGroupAdminRoleAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.UnassignGroupTargetFromGroupAdminRoleAsync(_groupId, _roleAssignmentId, _targetGroupId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/groups/{targetGroupId}");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["targetGroupId"].Should().Contain(_targetGroupId);
        }

        [Fact]
        public async Task UnassignGroupTargetFromGroupAdminRoleAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignGroupTargetFromGroupAdminRoleAsync(null, _roleAssignmentId, _targetGroupId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task UnassignGroupTargetFromGroupAdminRoleAsync_WithNullTargetGroupId_ThrowsApiException()
        {
            var api = new RoleBTargetBGroupApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignGroupTargetFromGroupAdminRoleAsync(_groupId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*targetGroupId*");
        }

        [Fact]
        public async Task UnassignGroupTargetFromGroupAdminRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetBGroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.UnassignGroupTargetFromGroupAdminRoleWithHttpInfoAsync(_groupId, _roleAssignmentId, _targetGroupId);

            response.Should().NotBeNull();
        }

        #endregion
    }
}
