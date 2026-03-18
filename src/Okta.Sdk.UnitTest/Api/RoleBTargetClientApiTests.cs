// <copyright file="RoleBTargetClientApiTests.cs" company="Okta, Inc">
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
    public class RoleBTargetClientApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _clientId = "0oa1234567890abcde";
        private readonly string _roleAssignmentId = "ra1234567890abcdef";
        private readonly string _appName = "salesforce";
        private readonly string _appId = "0oa9876543210fedcb";
        private readonly string _groupId = "00g1234567890abcde";

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            var act = () => new RoleBTargetClientApi(null, new Configuration { BasePath = BaseUrl });
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new RoleBTargetClientApi(new MockAsyncClient("{}"), null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Api_ImplementsIRoleBTargetClientApi()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().BeAssignableTo<IRoleBTargetClientApi>();
        }

        #endregion

        #region AssignAppTargetInstanceRoleForClientAsync Tests

        [Fact]
        public async Task AssignAppTargetInstanceRoleForClientAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.AssignAppTargetInstanceRoleForClientAsync(_clientId, _roleAssignmentId, _appName, _appId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}/{appId}");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["appName"].Should().Contain(_appName);
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task AssignAppTargetInstanceRoleForClientAsync_WithNullClientId_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppTargetInstanceRoleForClientAsync(null, _roleAssignmentId, _appName, _appId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*clientId*");
        }

        [Fact]
        public async Task AssignAppTargetInstanceRoleForClientAsync_WithNullAppName_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppTargetInstanceRoleForClientAsync(_clientId, _roleAssignmentId, null, _appId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appName*");
        }

        [Fact]
        public async Task AssignAppTargetInstanceRoleForClientAsync_WithNullAppId_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppTargetInstanceRoleForClientAsync(_clientId, _roleAssignmentId, _appName, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appId*");
        }

        [Fact]
        public async Task AssignAppTargetInstanceRoleForClientWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AssignAppTargetInstanceRoleForClientWithHttpInfoAsync(_clientId, _roleAssignmentId, _appName, _appId);

            response.Should().NotBeNull();
        }

        #endregion

        #region AssignAppTargetRoleToClientAsync Tests

        [Fact]
        public async Task AssignAppTargetRoleToClientAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.AssignAppTargetRoleToClientAsync(_clientId, _roleAssignmentId, _appName);

            // Assert
            mockClient.ReceivedPath.Should().Be("/oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["appName"].Should().Contain(_appName);
        }

        [Fact]
        public async Task AssignAppTargetRoleToClientAsync_WithNullClientId_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppTargetRoleToClientAsync(null, _roleAssignmentId, _appName);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*clientId*");
        }

        [Fact]
        public async Task AssignAppTargetRoleToClientAsync_WithNullAppName_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignAppTargetRoleToClientAsync(_clientId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appName*");
        }

        [Fact]
        public async Task AssignAppTargetRoleToClientWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AssignAppTargetRoleToClientWithHttpInfoAsync(_clientId, _roleAssignmentId, _appName);

            response.Should().NotBeNull();
        }

        #endregion

        #region AssignGroupTargetRoleForClientAsync Tests

        [Fact]
        public async Task AssignGroupTargetRoleForClientAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.AssignGroupTargetRoleForClientAsync(_clientId, _roleAssignmentId, _groupId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/groups/{groupId}");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        [Fact]
        public async Task AssignGroupTargetRoleForClientAsync_WithNullClientId_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignGroupTargetRoleForClientAsync(null, _roleAssignmentId, _groupId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*clientId*");
        }

        [Fact]
        public async Task AssignGroupTargetRoleForClientAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignGroupTargetRoleForClientAsync(_clientId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task AssignGroupTargetRoleForClientWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AssignGroupTargetRoleForClientWithHttpInfoAsync(_clientId, _roleAssignmentId, _groupId);

            response.Should().NotBeNull();
        }

        #endregion

        #region ListAppTargetRoleToClient Tests

        [Fact]
        public void ListAppTargetRoleToClient_WithValidParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListAppTargetRoleToClient(_clientId, _roleAssignmentId);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<CatalogApplication>>();
        }

        [Fact]
        public void ListAppTargetRoleToClient_WithPaginationParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListAppTargetRoleToClient(_clientId, _roleAssignmentId, after: "cursor123", limit: 25);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ListAppTargetRoleToClientWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListAppTargetRoleToClientWithHttpInfoAsync(_clientId, _roleAssignmentId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region ListGroupTargetRoleForClient Tests

        [Fact]
        public void ListGroupTargetRoleForClient_WithValidParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListGroupTargetRoleForClient(_clientId, _roleAssignmentId);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<Group>>();
        }

        [Fact]
        public void ListGroupTargetRoleForClient_WithPaginationParams_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListGroupTargetRoleForClient(_clientId, _roleAssignmentId, after: "cursor456", limit: 10);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ListGroupTargetRoleForClientWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListGroupTargetRoleForClientWithHttpInfoAsync(_clientId, _roleAssignmentId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region RemoveAppTargetInstanceRoleForClientAsync Tests

        [Fact]
        public async Task RemoveAppTargetInstanceRoleForClientAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.RemoveAppTargetInstanceRoleForClientAsync(_clientId, _roleAssignmentId, _appName, _appId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}/{appId}");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
            mockClient.ReceivedPathParams["appName"].Should().Contain(_appName);
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task RemoveAppTargetInstanceRoleForClientAsync_WithNullClientId_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.RemoveAppTargetInstanceRoleForClientAsync(null, _roleAssignmentId, _appName, _appId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*clientId*");
        }

        [Fact]
        public async Task RemoveAppTargetInstanceRoleForClientAsync_WithNullAppName_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.RemoveAppTargetInstanceRoleForClientAsync(_clientId, _roleAssignmentId, null, _appId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appName*");
        }

        [Fact]
        public async Task RemoveAppTargetInstanceRoleForClientAsync_WithNullAppId_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.RemoveAppTargetInstanceRoleForClientAsync(_clientId, _roleAssignmentId, _appName, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appId*");
        }

        [Fact]
        public async Task RemoveAppTargetInstanceRoleForClientWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.RemoveAppTargetInstanceRoleForClientWithHttpInfoAsync(_clientId, _roleAssignmentId, _appName, _appId);

            response.Should().NotBeNull();
        }

        #endregion

        #region RemoveAppTargetRoleFromClientAsync Tests

        [Fact]
        public async Task RemoveAppTargetRoleFromClientAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.RemoveAppTargetRoleFromClientAsync(_clientId, _roleAssignmentId, _appName);

            // Assert
            mockClient.ReceivedPath.Should().Be("/oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["appName"].Should().Contain(_appName);
        }

        [Fact]
        public async Task RemoveAppTargetRoleFromClientAsync_WithNullClientId_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.RemoveAppTargetRoleFromClientAsync(null, _roleAssignmentId, _appName);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*clientId*");
        }

        [Fact]
        public async Task RemoveAppTargetRoleFromClientAsync_WithNullAppName_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.RemoveAppTargetRoleFromClientAsync(_clientId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*appName*");
        }

        [Fact]
        public async Task RemoveAppTargetRoleFromClientWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.RemoveAppTargetRoleFromClientWithHttpInfoAsync(_clientId, _roleAssignmentId, _appName);

            response.Should().NotBeNull();
        }

        #endregion

        #region RemoveGroupTargetRoleFromClientAsync Tests

        [Fact]
        public async Task RemoveGroupTargetRoleFromClientAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.RemoveGroupTargetRoleFromClientAsync(_clientId, _roleAssignmentId, _groupId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/groups/{groupId}");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        [Fact]
        public async Task RemoveGroupTargetRoleFromClientAsync_WithNullClientId_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.RemoveGroupTargetRoleFromClientAsync(null, _roleAssignmentId, _groupId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*clientId*");
        }

        [Fact]
        public async Task RemoveGroupTargetRoleFromClientAsync_WithNullGroupId_ThrowsApiException()
        {
            var api = new RoleBTargetClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.RemoveGroupTargetRoleFromClientAsync(_clientId, _roleAssignmentId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*groupId*");
        }

        [Fact]
        public async Task RemoveGroupTargetRoleFromClientWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleBTargetClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.RemoveGroupTargetRoleFromClientWithHttpInfoAsync(_clientId, _roleAssignmentId, _groupId);

            response.Should().NotBeNull();
        }

        #endregion
    }
}
