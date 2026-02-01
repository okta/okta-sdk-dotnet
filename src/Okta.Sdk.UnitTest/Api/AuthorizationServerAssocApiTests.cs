// <copyright file="AuthorizationServerAssocApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

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
    /// <summary>
    /// Unit tests for AuthorizationServerAssocApi covering all 3 endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/associatedServers - ListAssociatedServersByTrustedType
    /// 2. POST /api/v1/authorizationServers/{authServerId}/associatedServers - CreateAssociatedServers
    /// 3. DELETE /api/v1/authorizationServers/{authServerId}/associatedServers/{associatedServerId} - DeleteAssociatedServerAsync
    /// 
    /// Each method is tested with:
    /// - Regular async method
    /// - WithHttpInfo variant for response metadata
    /// </summary>
    public class AuthorizationServerAssocApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _authServerId = "aus1234567890abcdef";
        private readonly string _associatedServerId = "ausAssociated12345";

        #region ListAssociatedServersByTrustedType Tests

        [Fact]
        public async Task ListAssociatedServersByTrustedType_ReturnsAssociatedServersList()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""aus1111111111111111"",
                    ""name"": ""Associated Server 1"",
                    ""description"": ""First associated server"",
                    ""audiences"": [""https://api1.example.com""],
                    ""status"": ""ACTIVE"",
                    ""issuer"": ""https://test.okta.com/oauth2/aus1111111111111111"",
                    ""issuerMode"": ""ORG_URL""
                },
                {
                    ""id"": ""aus2222222222222222"",
                    ""name"": ""Associated Server 2"",
                    ""description"": ""Second associated server"",
                    ""audiences"": [""https://api2.example.com""],
                    ""status"": ""ACTIVE"",
                    ""issuer"": ""https://test.okta.com/oauth2/aus2222222222222222"",
                    ""issuerMode"": ""ORG_URL""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Name.Should().Be("Associated Server 1");
            result.Data[1].Name.Should().Be("Associated Server 2");

            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/associatedServers");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
        }

        [Fact]
        public async Task ListAssociatedServersByTrustedType_WithTrustedParameter_IncludesQueryParam()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""aus1111111111111111"",
                    ""name"": ""Trusted Server"",
                    ""audiences"": [""https://api.example.com""],
                    ""status"": ""ACTIVE""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(_authServerId, trusted: true);

            // Assert
            result.Data.Should().HaveCount(1);
            mockClient.ReceivedQueryParams.Should().ContainKey("trusted");
            mockClient.ReceivedQueryParams["trusted"].Should().Contain("true");
        }

        [Fact]
        public async Task ListAssociatedServersByTrustedType_WithUntrustedParameter_IncludesQueryParam()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(_authServerId, trusted: false);

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("trusted");
            mockClient.ReceivedQueryParams["trusted"].Should().Contain("false");
        }

        [Fact]
        public async Task ListAssociatedServersByTrustedType_WithSearchQuery_IncludesQueryParam()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""ausSearchResult"",
                    ""name"": ""Custom API Server"",
                    ""audiences"": [""https://custom-api.example.com""],
                    ""status"": ""ACTIVE""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(_authServerId, q: "Custom");

            // Assert
            result.Data.Should().HaveCount(1);
            result.Data[0].Name.Should().Be("Custom API Server");
            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams["q"].Should().Contain("Custom");
        }

        [Fact]
        public async Task ListAssociatedServersByTrustedType_WithLimitParameter_IncludesQueryParam()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""ausLimited"",
                    ""name"": ""Limited Server"",
                    ""audiences"": [""https://api.example.com""],
                    ""status"": ""ACTIVE""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(_authServerId, limit: 10);

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("10");
        }

        [Fact]
        public async Task ListAssociatedServersByTrustedType_WithAfterParameter_IncludesQueryParam()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(_authServerId, after: "cursor123");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor123");
        }

        [Fact]
        public async Task ListAssociatedServersByTrustedType_WithAllParameters_IncludesAllQueryParams()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(
                _authServerId,
                trusted: true,
                q: "test",
                limit: 50,
                after: "cursorABC"
            );

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("trusted");
            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
        }

        [Fact]
        public async Task ListAssociatedServersByTrustedType_WhenEmpty_ReturnsEmptyList()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().NotBeNull();
            result.Data.Should().BeEmpty();
        }

        [Fact]
        public async Task ListAssociatedServersByTrustedTypeWithHttpInfo_ReturnsCorrectStatusCode()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(_authServerId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region CreateAssociatedServers Tests

        [Fact]
        public async Task CreateAssociatedServersWithHttpInfoAsync_WithValidData_ReturnsAssociatedServers()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": """ + _associatedServerId + @""",
                    ""name"": ""Newly Associated Server"",
                    ""description"": ""A newly associated authorization server"",
                    ""audiences"": [""https://new-api.example.com""],
                    ""status"": ""ACTIVE"",
                    ""issuer"": ""https://test.okta.com/oauth2/" + _associatedServerId + @""",
                    ""issuerMode"": ""ORG_URL""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            var associatedServerMediated = new AssociatedServerMediated
            {
                Trusted = new List<string> { _associatedServerId }
            };

            // Act
            var result = await api.CreateAssociatedServersWithHttpInfoAsync(_authServerId, associatedServerMediated);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNullOrEmpty();
            result.Data[0].Id.Should().Be(_associatedServerId);
            result.Data[0].Name.Should().Be("Newly Associated Server");

            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/associatedServers");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
            mockClient.ReceivedBody.Should().Contain(_associatedServerId);
        }

        [Fact]
        public async Task CreateAssociatedServersWithHttpInfoAsync_WithMultipleTrustedServers_IncludesAllInRequest()
        {
            // Arrange
            var server1 = "ausServer1";
            var server2 = "ausServer2";
            var server3 = "ausServer3";

            var responseJson = @"[
                {
                    ""id"": """ + server1 + @""",
                    ""name"": ""Server 1"",
                    ""audiences"": [""https://api1.example.com""],
                    ""status"": ""ACTIVE""
                },
                {
                    ""id"": """ + server2 + @""",
                    ""name"": ""Server 2"",
                    ""audiences"": [""https://api2.example.com""],
                    ""status"": ""ACTIVE""
                },
                {
                    ""id"": """ + server3 + @""",
                    ""name"": ""Server 3"",
                    ""audiences"": [""https://api3.example.com""],
                    ""status"": ""ACTIVE""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            var associatedServerMediated = new AssociatedServerMediated
            {
                Trusted = new List<string> { server1, server2, server3 }
            };

            // Act
            var result = await api.CreateAssociatedServersWithHttpInfoAsync(_authServerId, associatedServerMediated);

            // Assert
            result.Data.Should().HaveCount(3);
            mockClient.ReceivedBody.Should().Contain(server1);
            mockClient.ReceivedBody.Should().Contain(server2);
            mockClient.ReceivedBody.Should().Contain(server3);
        }

        [Fact]
        public async Task CreateAssociatedServersWithHttpInfoAsync_WithDifferentAuthServerId_PathContainsCorrectId()
        {
            // Arrange
            var customAuthServerId = "ausCustomPrimary";
            var responseJson = @"[
                {
                    ""id"": ""ausAssociated"",
                    ""name"": ""Associated Server"",
                    ""audiences"": [""https://api.example.com""],
                    ""status"": ""ACTIVE""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            var associatedServerMediated = new AssociatedServerMediated
            {
                Trusted = new List<string> { "ausAssociated" }
            };

            // Act
            var result = await api.CreateAssociatedServersWithHttpInfoAsync(customAuthServerId, associatedServerMediated);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/associatedServers");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(customAuthServerId);
        }

        [Fact]
        public async Task CreateAssociatedServersWithHttpInfoAsync_RequestBodyContainsTrustedArray()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""ausResult"",
                    ""name"": ""Result Server"",
                    ""audiences"": [""https://api.example.com""],
                    ""status"": ""ACTIVE""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            var associatedServerMediated = new AssociatedServerMediated
            {
                Trusted = new List<string> { "ausTarget123" }
            };

            // Act
            await api.CreateAssociatedServersWithHttpInfoAsync(_authServerId, associatedServerMediated);

            // Assert
            mockClient.ReceivedBody.Should().Contain("trusted");
            mockClient.ReceivedBody.Should().Contain("ausTarget123");
        }

        #endregion

        #region DeleteAssociatedServer Tests

        [Fact]
        public async Task DeleteAssociatedServerAsync_WithValidIds_RequestIsCorrectlyFormed()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteAssociatedServerAsync(_authServerId, _associatedServerId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/associatedServers/{associatedServerId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("associatedServerId");
            mockClient.ReceivedPathParams["associatedServerId"].Should().Contain(_associatedServerId);
        }

        [Fact]
        public async Task DeleteAssociatedServerWithHttpInfoAsync_ReturnsNoContentStatus()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteAssociatedServerWithHttpInfoAsync(_authServerId, _associatedServerId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteAssociatedServerAsync_WithDifferentIds_PathContainsCorrectIds()
        {
            // Arrange
            var customAuthServerId = "ausPrimaryCustom";
            var customAssociatedServerId = "ausAssociatedCustom";
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteAssociatedServerAsync(customAuthServerId, customAssociatedServerId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/associatedServers/{associatedServerId}");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(customAuthServerId);
            mockClient.ReceivedPathParams["associatedServerId"].Should().Contain(customAssociatedServerId);
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task DeleteAssociatedServerAsync_WhenNotFound_ThrowsApiException()
        {
            // Arrange
            var errorResponse = @"{""errorCode"": ""E0000007"", ""errorSummary"": ""Not found: Resource not found""}";
            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.NotFound);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                async () => await api.DeleteAssociatedServerAsync(_authServerId, "aus_nonexistent"));
        }

        [Fact]
        public async Task DeleteAssociatedServerAsync_WhenUnauthorized_ThrowsApiException()
        {
            // Arrange
            var errorResponse = @"{""errorCode"": ""E0000011"", ""errorSummary"": ""Invalid token provided""}";
            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.Unauthorized);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                async () => await api.DeleteAssociatedServerAsync(_authServerId, _associatedServerId));
        }

        [Fact]
        public async Task DeleteAssociatedServerAsync_WhenForbidden_ThrowsApiException()
        {
            // Arrange
            var errorResponse = @"{""errorCode"": ""E0000006"", ""errorSummary"": ""You do not have permission to perform the requested action""}";
            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.Forbidden);
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                async () => await api.DeleteAssociatedServerAsync(_authServerId, _associatedServerId));
        }

        #endregion

        #region Collection Client Tests

        [Fact]
        public void ListAssociatedServersByTrustedType_ReturnsOktaCollectionClient()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = api.ListAssociatedServersByTrustedType(_authServerId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<AuthorizationServer>>();
        }

        [Fact]
        public void CreateAssociatedServers_ReturnsOktaCollectionClient()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new AuthorizationServerAssocApi(mockClient, new Configuration { BasePath = BaseUrl });

            var associatedServerMediated = new AssociatedServerMediated
            {
                Trusted = new List<string> { _associatedServerId }
            };

            // Act
            var result = api.CreateAssociatedServers(_authServerId, associatedServerMediated);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<AuthorizationServer>>();
        }

        #endregion
    }
}
