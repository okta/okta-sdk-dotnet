// <copyright file="AuthorizationServerClientsApiTests.cs" company="Okta, Inc">
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
    /// Unit tests for AuthorizationServerClientsApi covering all 5 endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/clients - ListOAuth2ClientsForAuthorizationServer
    /// 2. GET /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens - ListRefreshTokensForAuthorizationServerAndClient
    /// 3. DELETE /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens - RevokeRefreshTokensForAuthorizationServerAndClient
    /// 4. GET /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId} - GetRefreshTokenForAuthorizationServerAndClient
    /// 5. DELETE /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId} - RevokeRefreshTokenForAuthorizationServerAndClient
    /// 
    /// Each method is tested with:
    /// - Regular async method
    /// - WithHttpInfo variant for response metadata
    /// - Proper request path and parameters validation
    /// - Response data validation
    /// </summary>
    public class AuthorizationServerClientsApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _authServerId = "aus1234567890abcdef";
        private readonly string _clientId = "0oa1234567890abcdef";
        private readonly string _tokenId = "tok1234567890abcdef";

        #region ListOAuth2ClientsForAuthorizationServer Tests

        [Fact]
        public async Task ListOAuth2ClientsForAuthorizationServer_ReturnsClientsList()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""client_id"": ""0oaClient111111111111"",
                    ""client_name"": ""My Web App"",
                    ""client_uri"": ""https://example.com"",
                    ""logo_uri"": ""https://example.com/logo.png"",
                    ""_links"": {
                        ""client"": {
                            ""href"": ""https://test.okta.com/oauth2/v1/clients/0oaClient111111111111""
                        },
                        ""tokens"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/clients/0oaClient111111111111/tokens""
                        }
                    }
                },
                {
                    ""client_id"": ""0oaClient222222222222"",
                    ""client_name"": ""My Mobile App"",
                    ""client_uri"": null,
                    ""logo_uri"": null,
                    ""_links"": {
                        ""client"": {
                            ""href"": ""https://test.okta.com/oauth2/v1/clients/0oaClient222222222222""
                        },
                        ""tokens"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/clients/0oaClient222222222222/tokens""
                        }
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListOAuth2ClientsForAuthorizationServerWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            
            // Verify first client
            result.Data[0].ClientId.Should().Be("0oaClient111111111111");
            result.Data[0].ClientName.Should().Be("My Web App");
            result.Data[0].ClientUri.Should().Be("https://example.com");
            result.Data[0].LogoUri.Should().Be("https://example.com/logo.png");
            result.Data[0].Links.Should().NotBeNull();

            // Verify second client
            result.Data[1].ClientId.Should().Be("0oaClient222222222222");
            result.Data[1].ClientName.Should().Be("My Mobile App");
            result.Data[1].ClientUri.Should().BeNull();
            result.Data[1].LogoUri.Should().BeNull();

            // Verify request path
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/clients");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
        }

        [Fact]
        public async Task ListOAuth2ClientsForAuthorizationServer_WithEmptyList_ReturnsEmptyCollection()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListOAuth2ClientsForAuthorizationServerWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().NotBeNull();
            result.Data.Should().BeEmpty();
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/clients");
        }

        [Fact]
        public async Task ListOAuth2ClientsForAuthorizationServer_CollectionMethod_ReturnsCollection()
        {
            // Arrange - Using collection method which is synchronous and returns IOktaCollectionClient
            var responseJson = @"[
                {
                    ""client_id"": ""0oaClient333333333333"",
                    ""client_name"": ""Test App""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act - Collection method
            var collection = api.ListOAuth2ClientsForAuthorizationServer(_authServerId);

            // Assert
            collection.Should().NotBeNull();
            // Note: IOktaCollectionClient doesn't immediately call the API, it's lazy loaded
        }

        #endregion

        #region ListRefreshTokensForAuthorizationServerAndClient Tests

        [Fact]
        public async Task ListRefreshTokensForAuthorizationServerAndClient_ReturnsTokensList()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""oar1111111111111111"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2024-01-15T10:30:00.000Z"",
                    ""lastUpdated"": ""2024-01-15T10:30:00.000Z"",
                    ""expiresAt"": ""2024-01-22T10:30:00.000Z"",
                    ""issuer"": ""https://test.okta.com/oauth2/aus1234567890abcdef"",
                    ""clientId"": ""0oaClient111111111111"",
                    ""userId"": ""00u1234567890abcdef"",
                    ""scopes"": [""offline_access"", ""openid"", ""profile""],
                    ""_links"": {
                        ""app"": {
                            ""href"": ""https://test.okta.com/api/v1/apps/0oaClient111111111111""
                        },
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/clients/0oaClient111111111111/tokens/oar1111111111111111""
                        },
                        ""revoke"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/clients/0oaClient111111111111/tokens/oar1111111111111111""
                        }
                    }
                },
                {
                    ""id"": ""oar2222222222222222"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2024-01-14T08:00:00.000Z"",
                    ""lastUpdated"": ""2024-01-14T08:00:00.000Z"",
                    ""expiresAt"": ""2024-01-21T08:00:00.000Z"",
                    ""issuer"": ""https://test.okta.com/oauth2/aus1234567890abcdef"",
                    ""clientId"": ""0oaClient111111111111"",
                    ""userId"": ""00u9876543210fedcba"",
                    ""scopes"": [""offline_access""]
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListRefreshTokensForAuthorizationServerAndClientWithHttpInfoAsync(_authServerId, _clientId);

            // Assert
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            
            // Verify first token
            result.Data[0].Id.Should().Be("oar1111111111111111");
            result.Data[0].Status.Should().Be(GrantOrTokenStatus.ACTIVE);
            result.Data[0].ClientId.Should().Be("0oaClient111111111111");
            result.Data[0].UserId.Should().Be("00u1234567890abcdef");
            result.Data[0].Scopes.Should().Contain("offline_access");
            result.Data[0].Scopes.Should().Contain("openid");
            result.Data[0].Scopes.Should().Contain("profile");
            result.Data[0].Issuer.Should().Contain("aus1234567890abcdef");
            result.Data[0].Links.Should().NotBeNull();

            // Verify second token
            result.Data[1].Id.Should().Be("oar2222222222222222");
            result.Data[1].UserId.Should().Be("00u9876543210fedcba");
            result.Data[1].Scopes.Should().HaveCount(1);

            // Verify request path and parameters
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("clientId");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
        }

        [Fact]
        public async Task ListRefreshTokensForAuthorizationServerAndClient_WithExpandScope_IncludesScopeDetails()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""oar1111111111111111"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2024-01-15T10:30:00.000Z"",
                    ""lastUpdated"": ""2024-01-15T10:30:00.000Z"",
                    ""expiresAt"": ""2024-01-22T10:30:00.000Z"",
                    ""issuer"": ""https://test.okta.com/oauth2/aus1234567890abcdef"",
                    ""clientId"": ""0oaClient111111111111"",
                    ""userId"": ""00u1234567890abcdef"",
                    ""scopes"": [""offline_access"", ""openid""],
                    ""_embedded"": {
                        ""scopes"": [
                            {
                                ""id"": ""scpOfflineAccess"",
                                ""name"": ""offline_access"",
                                ""description"": ""Requests a refresh token""
                            },
                            {
                                ""id"": ""scpOpenid"",
                                ""name"": ""openid"",
                                ""description"": ""OpenID Connect""
                            }
                        ]
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListRefreshTokensForAuthorizationServerAndClientWithHttpInfoAsync(
                _authServerId, _clientId, expand: "scope");

            // Assert
            result.Data.Should().HaveCount(1);
            result.Data[0].Embedded.Should().NotBeNull();
            
            // Verify query parameter was sent
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("scope");
        }

        [Fact]
        public async Task ListRefreshTokensForAuthorizationServerAndClient_WithPagination_SendsPaginationParams()
        {
            // Arrange
            var responseJson = @"[]";
            var afterCursor = "cursorToken123";
            var limit = 50;

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListRefreshTokensForAuthorizationServerAndClientWithHttpInfoAsync(
                _authServerId, _clientId, after: afterCursor, limit: limit);

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain(afterCursor);
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("50");
        }

        [Fact]
        public async Task ListRefreshTokensForAuthorizationServerAndClient_WithAllQueryParams_SendsAllParams()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListRefreshTokensForAuthorizationServerAndClientWithHttpInfoAsync(
                _authServerId, _clientId, expand: "scope", after: "cursor123", limit: 100);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens");
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
        }

        [Fact]
        public async Task ListRefreshTokensForAuthorizationServerAndClient_CollectionMethod_ReturnsCollection()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""oar3333333333333333"",
                    ""status"": ""ACTIVE"",
                    ""clientId"": ""0oaClient111111111111""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act - Collection method
            var collection = api.ListRefreshTokensForAuthorizationServerAndClient(_authServerId, _clientId);

            // Assert
            collection.Should().NotBeNull();
        }

        #endregion

        #region GetRefreshTokenForAuthorizationServerAndClient Tests

        [Fact]
        public async Task GetRefreshTokenForAuthorizationServerAndClient_ReturnsToken()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oar1111111111111111"",
                ""status"": ""ACTIVE"",
                ""created"": ""2024-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2024-01-15T10:30:00.000Z"",
                ""expiresAt"": ""2024-01-22T10:30:00.000Z"",
                ""issuer"": ""https://test.okta.com/oauth2/aus1234567890abcdef"",
                ""clientId"": ""0oaClient111111111111"",
                ""userId"": ""00u1234567890abcdef"",
                ""scopes"": [""offline_access"", ""openid"", ""profile"", ""email""],
                ""_links"": {
                    ""app"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oaClient111111111111""
                    },
                    ""authorizationServer"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef""
                    },
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/clients/0oaClient111111111111/tokens/oar1111111111111111""
                    },
                    ""revoke"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/clients/0oaClient111111111111/tokens/oar1111111111111111"",
                        ""hints"": {
                            ""allow"": [""DELETE""]
                        }
                    },
                    ""client"": {
                        ""href"": ""https://test.okta.com/oauth2/v1/clients/0oaClient111111111111""
                    },
                    ""user"": {
                        ""href"": ""https://test.okta.com/api/v1/users/00u1234567890abcdef""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetRefreshTokenForAuthorizationServerAndClientAsync(_authServerId, _clientId, _tokenId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("oar1111111111111111");
            result.Status.Should().Be(GrantOrTokenStatus.ACTIVE);
            result.ClientId.Should().Be("0oaClient111111111111");
            result.UserId.Should().Be("00u1234567890abcdef");
            result.Issuer.Should().Be("https://test.okta.com/oauth2/aus1234567890abcdef");
            result.Scopes.Should().HaveCount(4);
            result.Scopes.Should().Contain("offline_access");
            result.Scopes.Should().Contain("openid");
            result.Scopes.Should().Contain("profile");
            result.Scopes.Should().Contain("email");
            result.Links.Should().NotBeNull();

            // Verify request path and parameters
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("clientId");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
            mockClient.ReceivedPathParams.Should().ContainKey("tokenId");
            mockClient.ReceivedPathParams["tokenId"].Should().Contain(_tokenId);
        }

        [Fact]
        public async Task GetRefreshTokenForAuthorizationServerAndClient_WithHttpInfo_ReturnsResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oar1111111111111111"",
                ""status"": ""ACTIVE"",
                ""created"": ""2024-01-15T10:30:00.000Z"",
                ""expiresAt"": ""2024-01-22T10:30:00.000Z"",
                ""clientId"": ""0oaClient111111111111"",
                ""scopes"": [""offline_access""]
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetRefreshTokenForAuthorizationServerAndClientWithHttpInfoAsync(
                _authServerId, _clientId, _tokenId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be("oar1111111111111111");
            result.Data.Status.Should().Be(GrantOrTokenStatus.ACTIVE);
        }

        [Fact]
        public async Task GetRefreshTokenForAuthorizationServerAndClient_WithExpandScope_IncludesEmbeddedScopes()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oar1111111111111111"",
                ""status"": ""ACTIVE"",
                ""clientId"": ""0oaClient111111111111"",
                ""scopes"": [""offline_access"", ""openid""],
                ""_embedded"": {
                    ""scopes"": [
                        {
                            ""id"": ""scpOfflineAccess"",
                            ""name"": ""offline_access"",
                            ""description"": ""Requests a refresh token by returning a refresh token from the authorization server""
                        },
                        {
                            ""id"": ""scpOpenid"",
                            ""name"": ""openid"",
                            ""description"": ""Signals that a request is an OpenID Connect request""
                        }
                    ]
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetRefreshTokenForAuthorizationServerAndClientAsync(
                _authServerId, _clientId, _tokenId, expand: "scope");

            // Assert
            result.Should().NotBeNull();
            result.Embedded.Should().NotBeNull();
            
            // Verify expand query parameter was sent
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("scope");
        }

        [Fact]
        public async Task GetRefreshTokenForAuthorizationServerAndClient_WithCreatedAndExpires_ParsesDatesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oarDates123"",
                ""status"": ""ACTIVE"",
                ""created"": ""2024-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2024-01-16T14:45:30.000Z"",
                ""expiresAt"": ""2024-01-22T10:30:00.000Z"",
                ""clientId"": ""0oaClient111111111111"",
                ""scopes"": [""offline_access""]
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetRefreshTokenForAuthorizationServerAndClientAsync(
                _authServerId, _clientId, _tokenId);

            // Assert
            result.Should().NotBeNull();
            result.Created.Year.Should().Be(2024);
            result.Created.Month.Should().Be(1);
            result.Created.Day.Should().Be(15);
            result.LastUpdated.Year.Should().Be(2024);
            result.LastUpdated.Month.Should().Be(1);
            result.LastUpdated.Day.Should().Be(16);
            result.ExpiresAt.Year.Should().Be(2024);
            result.ExpiresAt.Month.Should().Be(1);
            result.ExpiresAt.Day.Should().Be(22);
        }

        #endregion

        #region RevokeRefreshTokenForAuthorizationServerAndClient Tests

        [Fact]
        public async Task RevokeRefreshTokenForAuthorizationServerAndClient_SendsDeleteRequest()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.RevokeRefreshTokenForAuthorizationServerAndClientAsync(_authServerId, _clientId, _tokenId);

            // Assert - Verify request path and parameters
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("clientId");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
            mockClient.ReceivedPathParams.Should().ContainKey("tokenId");
            mockClient.ReceivedPathParams["tokenId"].Should().Contain(_tokenId);
        }

        [Fact]
        public async Task RevokeRefreshTokenForAuthorizationServerAndClient_WithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.RevokeRefreshTokenForAuthorizationServerAndClientWithHttpInfoAsync(
                _authServerId, _clientId, _tokenId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId}");
        }

        [Fact]
        public async Task RevokeRefreshTokenForAuthorizationServerAndClient_ValidatesAllPathParameters()
        {
            // Arrange
            var testAuthServerId = "ausTestServer123";
            var testClientId = "0oaTestClient456";
            var testTokenId = "tokTestToken789";
            
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.RevokeRefreshTokenForAuthorizationServerAndClientAsync(testAuthServerId, testClientId, testTokenId);

            // Assert
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(testAuthServerId);
            mockClient.ReceivedPathParams["clientId"].Should().Contain(testClientId);
            mockClient.ReceivedPathParams["tokenId"].Should().Contain(testTokenId);
        }

        #endregion

        #region RevokeRefreshTokensForAuthorizationServerAndClient Tests

        [Fact]
        public async Task RevokeRefreshTokensForAuthorizationServerAndClient_SendsDeleteRequest()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.RevokeRefreshTokensForAuthorizationServerAndClientAsync(_authServerId, _clientId);

            // Assert - Verify request path and parameters
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("clientId");
            mockClient.ReceivedPathParams["clientId"].Should().Contain(_clientId);
        }

        [Fact]
        public async Task RevokeRefreshTokensForAuthorizationServerAndClient_WithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.RevokeRefreshTokensForAuthorizationServerAndClientWithHttpInfoAsync(
                _authServerId, _clientId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens");
        }

        [Fact]
        public async Task RevokeRefreshTokensForAuthorizationServerAndClient_DoesNotIncludeTokenId()
        {
            // Arrange - Revoke ALL tokens for a client does not include tokenId
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.RevokeRefreshTokensForAuthorizationServerAndClientAsync(_authServerId, _clientId);

            // Assert - Should NOT have tokenId in path parameters
            mockClient.ReceivedPathParams.Should().NotContainKey("tokenId");
            mockClient.ReceivedPath.Should().NotContain("{tokenId}");
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task GetRefreshTokenForAuthorizationServerAndClient_WhenNotFound_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: tok_nonexistent (OAuth2RefreshToken)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaeInvalidToken123"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.GetRefreshTokenForAuthorizationServerAndClientAsync(
                    _authServerId, _clientId, "tok_nonexistent"));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task RevokeRefreshTokenForAuthorizationServerAndClient_WhenForbidden_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000006"",
                ""errorSummary"": ""You do not have permission to perform the requested action"",
                ""errorLink"": ""E0000006"",
                ""errorId"": ""oaeUnauthorized123"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.Forbidden);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.RevokeRefreshTokenForAuthorizationServerAndClientAsync(
                    _authServerId, _clientId, _tokenId));

            exception.ErrorCode.Should().Be(403);
        }

        [Fact]
        public async Task GetRefreshTokenForAuthorizationServerAndClient_WhenAuthServerNotFound_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: aus_nonexistent (AuthorizationServer)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaeNotFound123"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.GetRefreshTokenForAuthorizationServerAndClientAsync("aus_nonexistent", _clientId, _tokenId));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task RevokeRefreshTokenForAuthorizationServerAndClient_WhenRateLimited_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000047"",
                ""errorSummary"": ""API call exceeded rate limit due to too many requests."",
                ""errorLink"": ""E0000047"",
                ""errorId"": ""oaeRateLimit123"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.TooManyRequests);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.RevokeRefreshTokenForAuthorizationServerAndClientAsync(_authServerId, _clientId, _tokenId));

            exception.ErrorCode.Should().Be(429);
        }

        #endregion

        #region Edge Cases Tests

        [Fact]
        public async Task ListRefreshTokensForAuthorizationServerAndClient_WithEmptyList_ReturnsEmptyCollection()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListRefreshTokensForAuthorizationServerAndClientWithHttpInfoAsync(_authServerId, _clientId);

            // Assert
            result.Data.Should().NotBeNull();
            result.Data.Should().BeEmpty();
        }

        [Fact]
        public async Task GetRefreshTokenForAuthorizationServerAndClient_WithMinimalData_ParsesCorrectly()
        {
            // Arrange - Token with minimal required fields
            var responseJson = @"{
                ""id"": ""oarMinimal123"",
                ""status"": ""ACTIVE"",
                ""clientId"": ""0oaClient111111111111"",
                ""scopes"": []
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetRefreshTokenForAuthorizationServerAndClientAsync(
                _authServerId, _clientId, _tokenId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("oarMinimal123");
            result.Status.Should().Be(GrantOrTokenStatus.ACTIVE);
            result.Scopes.Should().BeEmpty();
        }

        [Fact]
        public async Task ListOAuth2ClientsForAuthorizationServer_WithClientWithNullValues_ParsesCorrectly()
        {
            // Arrange - Client with null optional fields
            var responseJson = @"[
                {
                    ""client_id"": ""0oaNullClient"",
                    ""client_name"": ""App with nulls"",
                    ""client_uri"": null,
                    ""logo_uri"": null,
                    ""_links"": null
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListOAuth2ClientsForAuthorizationServerWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().HaveCount(1);
            result.Data[0].ClientId.Should().Be("0oaNullClient");
            result.Data[0].ClientName.Should().Be("App with nulls");
            result.Data[0].ClientUri.Should().BeNull();
            result.Data[0].LogoUri.Should().BeNull();
        }

        [Fact]
        public async Task GetRefreshTokenForAuthorizationServerAndClient_WithRevokedStatus_ParsesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oarRevoked123"",
                ""status"": ""REVOKED"",
                ""clientId"": ""0oaClient111111111111"",
                ""scopes"": [""offline_access""]
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClientsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetRefreshTokenForAuthorizationServerAndClientAsync(
                _authServerId, _clientId, _tokenId);

            // Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(GrantOrTokenStatus.REVOKED);
        }

        #endregion
    }
}
