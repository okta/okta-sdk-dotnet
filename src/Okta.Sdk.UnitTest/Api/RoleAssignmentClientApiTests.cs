// <copyright file="RoleAssignmentClientApiTests.cs" company="Okta, Inc">
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
    public class RoleAssignmentClientApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _clientId = "0oa1234567890abcde";
        private readonly string _roleAssignmentId = "ra1234567890abcdef";

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var api = new RoleAssignmentClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            var act = () => new RoleAssignmentClientApi(null, new Configuration { BasePath = BaseUrl });
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new RoleAssignmentClientApi(new MockAsyncClient("{}"), null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Api_ImplementsIRoleAssignmentClientApi()
        {
            var api = new RoleAssignmentClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().BeAssignableTo<IRoleAssignmentClientApi>();
            api.Should().BeAssignableTo<IRoleAssignmentClientApiAsync>();
        }

        #endregion

        #region AssignRoleToClientAsync Tests

        [Fact]
        public async Task AssignRoleToClientAsync_WithStandardRole_ReturnsRoleAssignment()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""label"": ""Organization Administrator"",
                ""type"": ""ORG_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""CLIENT""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentClientApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AssignRoleToGroupRequest(new StandardRoleAssignmentSchema { Type = "ORG_ADMIN" });

            // Act
            var result = await api.AssignRoleToClientAsync(_clientId, request);

            // Assert
            result.Should().NotBeNull();
            result.GetStandardRole().Should().NotBeNull();
            result.GetStandardRole().Id.Should().Be(_roleAssignmentId);
            mockClient.ReceivedPath.Should().Be("/oauth2/v1/clients/{clientId}/roles");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
            mockClient.ReceivedBody.Should().Contain("ORG_ADMIN");
        }

        [Fact]
        public async Task AssignRoleToClientAsync_WithNullClientId_ThrowsApiException()
        {
            var api = new RoleAssignmentClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            var request = new AssignRoleToGroupRequest(new StandardRoleAssignmentSchema { Type = "ORG_ADMIN" });

            Func<Task> act = async () => await api.AssignRoleToClientAsync(null, request);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*clientId*");
        }

        [Fact]
        public async Task AssignRoleToClientAsync_WithNullRequest_ThrowsApiException()
        {
            var api = new RoleAssignmentClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AssignRoleToClientAsync(_clientId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*assignRoleToGroupRequest*");
        }

        [Fact]
        public async Task AssignRoleToClientWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""type"": ""ORG_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""CLIENT""
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentClientApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AssignRoleToGroupRequest(new StandardRoleAssignmentSchema { Type = "ORG_ADMIN" });

            var response = await api.AssignRoleToClientWithHttpInfoAsync(_clientId, request);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region DeleteRoleFromClientAsync Tests

        [Fact]
        public async Task DeleteRoleFromClientAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleAssignmentClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteRoleFromClientAsync(_clientId, _roleAssignmentId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
        }

        [Fact]
        public async Task DeleteRoleFromClientAsync_WithNullClientId_ThrowsApiException()
        {
            var api = new RoleAssignmentClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.DeleteRoleFromClientAsync(null, _roleAssignmentId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*clientId*");
        }

        [Fact]
        public async Task DeleteRoleFromClientAsync_WithNullRoleAssignmentId_ThrowsApiException()
        {
            var api = new RoleAssignmentClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.DeleteRoleFromClientAsync(_clientId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleAssignmentId*");
        }

        [Fact]
        public async Task DeleteRoleFromClientWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleAssignmentClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.DeleteRoleFromClientWithHttpInfoAsync(_clientId, _roleAssignmentId);

            response.Should().NotBeNull();
        }

        #endregion

        #region ListRolesForClient Tests

        [Fact]
        public void ListRolesForClient_WithValidClientId_ReturnsCollectionClient()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new RoleAssignmentClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = api.ListRolesForClient(_clientId);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<ListGroupAssignedRoles200ResponseInner>>();
        }

        [Fact]
        public async Task ListRolesForClientWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"[
                {
                    ""id"": """ + _roleAssignmentId + @""",
                    ""type"": ""ORG_ADMIN"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2019-02-06T16:20:57.000Z"",
                    ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                    ""assignmentType"": ""CLIENT""
                }
            ]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListRolesForClientWithHttpInfoAsync(_clientId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(1);
        }

        #endregion

        #region RetrieveClientRoleAsync Tests

        [Fact]
        public async Task RetrieveClientRoleAsync_WithValidParams_ReturnsRole()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""label"": ""Organization Administrator"",
                ""type"": ""ORG_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""CLIENT""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.RetrieveClientRoleAsync(_clientId, _roleAssignmentId);

            // Assert
            result.Should().NotBeNull();
            result.GetStandardRole().Should().NotBeNull();
            result.GetStandardRole().Id.Should().Be(_roleAssignmentId);
            mockClient.ReceivedPath.Should().Be("/oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
            mockClient.ReceivedPathParams["roleAssignmentId"].Should().Contain(_roleAssignmentId);
        }

        [Fact]
        public async Task RetrieveClientRoleAsync_WithNullClientId_ThrowsApiException()
        {
            var api = new RoleAssignmentClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.RetrieveClientRoleAsync(null, _roleAssignmentId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*clientId*");
        }

        [Fact]
        public async Task RetrieveClientRoleAsync_WithNullRoleAssignmentId_ThrowsApiException()
        {
            var api = new RoleAssignmentClientApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.RetrieveClientRoleAsync(_clientId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleAssignmentId*");
        }

        [Fact]
        public async Task RetrieveClientRoleWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{
                ""id"": """ + _roleAssignmentId + @""",
                ""type"": ""ORG_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2019-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2019-02-06T16:20:57.000Z"",
                ""assignmentType"": ""CLIENT""
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleAssignmentClientApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.RetrieveClientRoleWithHttpInfoAsync(_clientId, _roleAssignmentId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion
    }
}
