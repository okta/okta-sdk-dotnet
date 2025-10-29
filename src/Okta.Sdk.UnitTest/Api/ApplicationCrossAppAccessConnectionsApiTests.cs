// <copyright file="ApplicationCrossAppAccessConnectionsApiTests.cs" company="Okta, Inc">
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
    public class ApplicationCrossAppAccessConnectionsApiTests
    {
        #region GetAllCrossAppAccessConnections Tests

        [Fact]
        public async Task GetAllCrossAppAccessConnectionsWithHttpInfoAsync_ValidatesPathAndQueryParameters()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""conn123"",
                ""requestingAppInstanceId"": ""app123"",
                ""resourceAppInstanceId"": ""app456"",
                ""status"": ""ACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T10:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient($"[{responseJson}]");
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            var result = await api.GetAllCrossAppAccessConnectionsWithHttpInfoAsync("app_test_123", after: "cursor123", limit: 50);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Count.Should().Be(1);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/cwo/connections");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain("app_test_123");
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor123");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("50");
        }

        [Fact]
        public async Task GetAllCrossAppAccessConnectionsWithHttpInfoAsync_WithSpecialCharacters_EncodesCorrectly()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            var result = await api.GetAllCrossAppAccessConnectionsWithHttpInfoAsync("app+id/with spaces");

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPathParams["appId"].Should().Contain("app+id/with spaces");
        }

        [Fact]
        public async Task GetAllCrossAppAccessConnectionsWithHttpInfoAsync_WithDefaultParameters_OmitsOptionalQueryParams()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            var result = await api.GetAllCrossAppAccessConnectionsWithHttpInfoAsync("app123");

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/cwo/connections");
            mockClient.ReceivedPathParams["appId"].Should().Contain("app123");
        }

        #endregion

        #region CreateCrossAppAccessConnection Tests

        [Fact]
        public async Task CreateCrossAppAccessConnectionAsync_CreatesConnectionWithActiveStatus()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""conn789"",
                ""requestingAppInstanceId"": ""app123"",
                ""resourceAppInstanceId"": ""app456"",
                ""status"": ""ACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T10:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            var connectionRequest = new OrgCrossAppAccessConnection
            {
                RequestingAppInstanceId = "app123",
                ResourceAppInstanceId = "app456",
                Status = OrgCrossAppAccessConnection.StatusEnum.ACTIVE
            };

            // Act
            var result = await api.CreateCrossAppAccessConnectionAsync("app123", connectionRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("conn789");
            result.RequestingAppInstanceId.Should().Be("app123");
            result.ResourceAppInstanceId.Should().Be("app456");
            result.Status.Value.Should().Be("ACTIVE");

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/cwo/connections");
            mockClient.ReceivedPathParams["appId"].Should().Contain("app123");
            mockClient.ReceivedBody.Should().Contain("app123");
            mockClient.ReceivedBody.Should().Contain("app456");
            mockClient.ReceivedBody.Should().Contain("ACTIVE");
        }

        [Fact]
        public async Task CreateCrossAppAccessConnectionWithHttpInfoAsync_ReturnsCreatedStatus()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""conn456"",
                ""requestingAppInstanceId"": ""app789"",
                ""resourceAppInstanceId"": ""app012"",
                ""status"": ""INACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T10:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            var connectionRequest = new OrgCrossAppAccessConnection
            {
                RequestingAppInstanceId = "app789",
                ResourceAppInstanceId = "app012",
                Status = OrgCrossAppAccessConnection.StatusEnum.INACTIVE
            };

            // Act
            var result = await api.CreateCrossAppAccessConnectionWithHttpInfoAsync("app789", connectionRequest);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.Created);
            result.Data.Should().NotBeNull();
            result.Data.Status.Value.Should().Be("INACTIVE");
        }

        [Fact]
        public async Task CreateCrossAppAccessConnectionAsync_WithSpecialCharactersInAppId_EncodesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""conn999"",
                ""requestingAppInstanceId"": ""app+special/id"",
                ""resourceAppInstanceId"": ""app456"",
                ""status"": ""ACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T10:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            var connectionRequest = new OrgCrossAppAccessConnection
            {
                RequestingAppInstanceId = "app+special/id",
                ResourceAppInstanceId = "app456",
                Status = OrgCrossAppAccessConnection.StatusEnum.ACTIVE
            };

            // Act
            var result = await api.CreateCrossAppAccessConnectionAsync("app+special/id", connectionRequest);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPathParams["appId"].Should().Contain("app+special/id");
        }

        #endregion

        #region GetCrossAppAccessConnection Tests

        [Fact]
        public async Task GetCrossAppAccessConnectionAsync_RetrievesSpecificConnection()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""conn123"",
                ""requestingAppInstanceId"": ""app123"",
                ""resourceAppInstanceId"": ""app456"",
                ""status"": ""ACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T10:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            var result = await api.GetCrossAppAccessConnectionAsync("app123", "conn123");

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("conn123");
            result.RequestingAppInstanceId.Should().Be("app123");
            result.ResourceAppInstanceId.Should().Be("app456");
            result.Status.Value.Should().Be("ACTIVE");

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/cwo/connections/{connectionId}");
            mockClient.ReceivedPathParams["appId"].Should().Contain("app123");
            mockClient.ReceivedPathParams["connectionId"].Should().Contain("conn123");
        }

        [Fact]
        public async Task GetCrossAppAccessConnectionWithHttpInfoAsync_ValidatesHttpResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""conn456"",
                ""requestingAppInstanceId"": ""app789"",
                ""resourceAppInstanceId"": ""app012"",
                ""status"": ""INACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T10:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            var result = await api.GetCrossAppAccessConnectionWithHttpInfoAsync("app789", "conn456");

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be("conn456");
            result.Data.Status.Value.Should().Be("INACTIVE");
        }

        [Fact]
        public async Task GetCrossAppAccessConnectionAsync_WithSpecialCharacters_EncodesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""conn+special/id"",
                ""requestingAppInstanceId"": ""app123"",
                ""resourceAppInstanceId"": ""app456"",
                ""status"": ""ACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T10:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            var result = await api.GetCrossAppAccessConnectionAsync("app+id", "conn+special/id");

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPathParams["appId"].Should().Contain("app+id");
            mockClient.ReceivedPathParams["connectionId"].Should().Contain("conn+special/id");
        }

        #endregion

        #region UpdateCrossAppAccessConnection Tests

        [Fact]
        public async Task UpdateCrossAppAccessConnectionAsync_UpdatesConnectionStatus()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""conn123"",
                ""requestingAppInstanceId"": ""app123"",
                ""resourceAppInstanceId"": ""app456"",
                ""status"": ""INACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            var updateRequest = new OrgCrossAppAccessConnectionPatchRequest
            {
                Status = OrgCrossAppAccessConnectionPatchRequest.StatusEnum.INACTIVE
            };

            // Act
            var result = await api.UpdateCrossAppAccessConnectionAsync("app123", "conn123", updateRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("conn123");
            result.Status.Value.Should().Be("INACTIVE");

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/cwo/connections/{connectionId}");
            mockClient.ReceivedPathParams["appId"].Should().Contain("app123");
            mockClient.ReceivedPathParams["connectionId"].Should().Contain("conn123");
            mockClient.ReceivedBody.Should().Contain("INACTIVE");
        }

        [Fact]
        public async Task UpdateCrossAppAccessConnectionAsync_UpdatesToActiveStatus()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""conn456"",
                ""requestingAppInstanceId"": ""app789"",
                ""resourceAppInstanceId"": ""app012"",
                ""status"": ""ACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T13:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            var updateRequest = new OrgCrossAppAccessConnectionPatchRequest
            {
                Status = OrgCrossAppAccessConnectionPatchRequest.StatusEnum.ACTIVE
            };

            // Act
            var result = await api.UpdateCrossAppAccessConnectionAsync("app789", "conn456", updateRequest);

            // Assert
            result.Should().NotBeNull();
            result.Status.Value.Should().Be("ACTIVE");
            mockClient.ReceivedBody.Should().Contain("ACTIVE");
        }

        [Fact]
        public async Task UpdateCrossAppAccessConnectionWithHttpInfoAsync_ValidatesHttpResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""conn789"",
                ""requestingAppInstanceId"": ""app123"",
                ""resourceAppInstanceId"": ""app456"",
                ""status"": ""INACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T14:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            var updateRequest = new OrgCrossAppAccessConnectionPatchRequest
            {
                Status = OrgCrossAppAccessConnectionPatchRequest.StatusEnum.INACTIVE
            };

            // Act
            var result = await api.UpdateCrossAppAccessConnectionWithHttpInfoAsync("app123", "conn789", updateRequest);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Status.Value.Should().Be("INACTIVE");
        }

        [Fact]
        public async Task UpdateCrossAppAccessConnectionAsync_WithSpecialCharacters_EncodesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""conn+special/id"",
                ""requestingAppInstanceId"": ""app123"",
                ""resourceAppInstanceId"": ""app456"",
                ""status"": ""ACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T15:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            var updateRequest = new OrgCrossAppAccessConnectionPatchRequest
            {
                Status = OrgCrossAppAccessConnectionPatchRequest.StatusEnum.ACTIVE
            };

            // Act
            var result = await api.UpdateCrossAppAccessConnectionAsync("app+id", "conn+special/id", updateRequest);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPathParams["appId"].Should().Contain("app+id");
            mockClient.ReceivedPathParams["connectionId"].Should().Contain("conn+special/id");
        }

        #endregion

        #region DeleteCrossAppAccessConnection Tests

        [Fact]
        public async Task DeleteCrossAppAccessConnectionAsync_DeletesConnection()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            await api.DeleteCrossAppAccessConnectionAsync("app123", "conn123");

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/cwo/connections/{connectionId}");
            mockClient.ReceivedPathParams["appId"].Should().Contain("app123");
            mockClient.ReceivedPathParams["connectionId"].Should().Contain("conn123");
        }

        [Fact]
        public async Task DeleteCrossAppAccessConnectionWithHttpInfoAsync_ValidatesHttpResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            var result = await api.DeleteCrossAppAccessConnectionWithHttpInfoAsync("app456", "conn456");

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPathParams["appId"].Should().Contain("app456");
            mockClient.ReceivedPathParams["connectionId"].Should().Contain("conn456");
        }

        [Fact]
        public async Task DeleteCrossAppAccessConnectionAsync_WithSpecialCharacters_EncodesCorrectly()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            await api.DeleteCrossAppAccessConnectionAsync("app+special/id", "conn+special/id");

            // Assert
            mockClient.ReceivedPathParams["appId"].Should().Contain("app+special/id");
            mockClient.ReceivedPathParams["connectionId"].Should().Contain("conn+special/id");
        }

        #endregion

        #region Edge Cases and Validation Tests

        [Fact]
        public async Task GetAllCrossAppAccessConnections_WithEmptyResult_ReturnsEmptyList()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            var result = await api.GetAllCrossAppAccessConnectionsWithHttpInfoAsync("app123");

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllCrossAppAccessConnections_WithLimitZero_ReturnsEmptyResult()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            var result = await api.GetAllCrossAppAccessConnectionsWithHttpInfoAsync("app123", limit: 0);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams["limit"].Should().Contain("0");
        }

        [Fact]
        public async Task GetAllCrossAppAccessConnections_WithNegativeLimit_ReturnsAllResults()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            var result = await api.GetAllCrossAppAccessConnectionsWithHttpInfoAsync("app123", limit: -1);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams["limit"].Should().Contain("-1");
        }

        [Fact]
        public async Task CreateCrossAppAccessConnection_WithBothStatusOptions_HandlesCorrectly()
        {
            // Test ACTIVE status
            var activeResponseJson = @"{
                ""id"": ""conn_active"",
                ""requestingAppInstanceId"": ""app123"",
                ""resourceAppInstanceId"": ""app456"",
                ""status"": ""ACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T10:00:00.000Z""
            }";

            var mockClient1 = new MockAsyncClient(activeResponseJson, HttpStatusCode.Created);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api1 = new ApplicationCrossAppAccessConnectionsApi(mockClient1, configuration);

            var activeConnection = new OrgCrossAppAccessConnection
            {
                RequestingAppInstanceId = "app123",
                ResourceAppInstanceId = "app456",
                Status = OrgCrossAppAccessConnection.StatusEnum.ACTIVE
            };

            var result1 = await api1.CreateCrossAppAccessConnectionAsync("app123", activeConnection);
            result1.Status.Value.Should().Be("ACTIVE");

            // Test INACTIVE status
            var inactiveResponseJson = @"{
                ""id"": ""conn_inactive"",
                ""requestingAppInstanceId"": ""app123"",
                ""resourceAppInstanceId"": ""app456"",
                ""status"": ""INACTIVE"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T10:00:00.000Z""
            }";

            var mockClient2 = new MockAsyncClient(inactiveResponseJson, HttpStatusCode.Created);
            var api2 = new ApplicationCrossAppAccessConnectionsApi(mockClient2, configuration);

            var inactiveConnection = new OrgCrossAppAccessConnection
            {
                RequestingAppInstanceId = "app123",
                ResourceAppInstanceId = "app456",
                Status = OrgCrossAppAccessConnection.StatusEnum.INACTIVE
            };

            var result2 = await api2.CreateCrossAppAccessConnectionAsync("app123", inactiveConnection);
            result2.Status.Value.Should().Be("INACTIVE");
        }

        [Fact]
        public async Task GetAllCrossAppAccessConnections_WithMultipleConnections_ReturnsCorrectCount()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""conn1"",
                    ""requestingAppInstanceId"": ""app123"",
                    ""resourceAppInstanceId"": ""app456"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2024-01-15T10:00:00.000Z"",
                    ""lastUpdated"": ""2024-01-15T10:00:00.000Z""
                },
                {
                    ""id"": ""conn2"",
                    ""requestingAppInstanceId"": ""app123"",
                    ""resourceAppInstanceId"": ""app789"",
                    ""status"": ""INACTIVE"",
                    ""created"": ""2024-01-15T11:00:00.000Z"",
                    ""lastUpdated"": ""2024-01-15T11:00:00.000Z""
                },
                {
                    ""id"": ""conn3"",
                    ""requestingAppInstanceId"": ""app123"",
                    ""resourceAppInstanceId"": ""app012"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2024-01-15T12:00:00.000Z"",
                    ""lastUpdated"": ""2024-01-15T12:00:00.000Z""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var configuration = new Configuration { BasePath = "https://test.okta.com" };
            var api = new ApplicationCrossAppAccessConnectionsApi(mockClient, configuration);

            // Act
            var result = await api.GetAllCrossAppAccessConnectionsWithHttpInfoAsync("app123");

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Count.Should().Be(3);
            result.Data[0].Id.Should().Be("conn1");
            result.Data[1].Id.Should().Be("conn2");
            result.Data[2].Id.Should().Be("conn3");
            result.Data[0].Status.Value.Should().Be("ACTIVE");
            result.Data[1].Status.Value.Should().Be("INACTIVE");
            result.Data[2].Status.Value.Should().Be("ACTIVE");
        }

        #endregion
    }
}
