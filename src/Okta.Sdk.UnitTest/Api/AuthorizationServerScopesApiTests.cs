// <copyright file="AuthorizationServerScopesApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
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
    /// Unit tests for AuthorizationServerScopesApi covering all 5 endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/scopes - ListOAuth2Scopes
    /// 2. POST /api/v1/authorizationServers/{authServerId}/scopes - CreateOAuth2ScopeAsync
    /// 3. GET /api/v1/authorizationServers/{authServerId}/scopes/{scopeId} - GetOAuth2ScopeAsync
    /// 4. PUT /api/v1/authorizationServers/{authServerId}/scopes/{scopeId} - ReplaceOAuth2ScopeAsync
    /// 5. DELETE /api/v1/authorizationServers/{authServerId}/scopes/{scopeId} - DeleteOAuth2ScopeAsync
    /// 
    /// Each method is tested with:
    /// - Regular async method
    /// - WithHttpInfo variant for response metadata
    /// - Proper request path and parameters validation
    /// - Response data validation including all OAuth2Scope properties
    /// </summary>
    public class AuthorizationServerScopesApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _authServerId = "aus1234567890abcdef";
        private readonly string _scopeId = "scp5yu8kLOnDzo7lh0g4";

        #region ListOAuth2Scopes Tests

        [Fact]
        public void ListOAuth2Scopes_ReturnsCollectionClient()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]", HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = api.ListOAuth2Scopes(_authServerId);

            // Assert - ListOAuth2Scopes returns IOktaCollectionClient, not a direct HTTP call
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<OAuth2Scope>>();
        }

        [Fact]
        public void ListOAuth2Scopes_SetsPathParameters()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]", HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = api.ListOAuth2Scopes(_authServerId);

            // Assert - Collection client is returned with correct configuration
            result.Should().NotBeNull();
            result.Should().BeOfType<OktaCollectionClient<OAuth2Scope>>();
        }

        [Fact]
        public async Task ListOAuth2ScopesWithHttpInfo_BuildsCorrectPath()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                    ""name"": ""car:drive"",
                    ""description"": ""Drive car"",
                    ""system"": false,
                    ""default"": false,
                    ""displayName"": ""Drive Car"",
                    ""consent"": ""REQUIRED"",
                    ""optional"": false,
                    ""metadataPublish"": ""NO_CLIENTS""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListOAuth2ScopesWithHttpInfoAsync(_authServerId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/scopes");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
        }

        [Fact]
        public async Task ListOAuth2ScopesWithHttpInfo_WithQueryParameters_IncludesAllParams()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                    ""name"": ""car:drive"",
                    ""description"": ""Drive car"",
                    ""system"": false,
                    ""default"": false,
                    ""displayName"": ""Drive Car"",
                    ""consent"": ""REQUIRED"",
                    ""optional"": false,
                    ""metadataPublish"": ""NO_CLIENTS""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListOAuth2ScopesWithHttpInfoAsync(
                _authServerId,
                q: "car",
                filter: "name eq \"car:drive\"",
                after: "cursor123",
                limit: 50);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/scopes");
            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams["q"].Should().Contain("car");
            mockClient.ReceivedQueryParams.Should().ContainKey("filter");
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor123");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("50");
        }

        [Fact]
        public async Task ListOAuth2ScopesWithHttpInfo_ReturnsAllScopeProperties()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                    ""name"": ""car:drive"",
                    ""description"": ""Drive car"",
                    ""system"": false,
                    ""default"": true,
                    ""displayName"": ""Drive Car"",
                    ""consent"": ""REQUIRED"",
                    ""optional"": true,
                    ""metadataPublish"": ""ALL_CLIENTS"",
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/scopes/scp5yu8kLOnDzo7lh0g4""
                        }
                    }
                },
                {
                    ""id"": ""scp9999999999999999"",
                    ""name"": ""api:read"",
                    ""description"": ""Read API"",
                    ""system"": true,
                    ""default"": false,
                    ""displayName"": ""API Read Access"",
                    ""consent"": ""IMPLICIT"",
                    ""optional"": false,
                    ""metadataPublish"": ""NO_CLIENTS""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListOAuth2ScopesWithHttpInfoAsync(_authServerId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(2);

            var firstScope = response.Data[0];
            firstScope.Id.Should().Be("scp5yu8kLOnDzo7lh0g4");
            firstScope.Name.Should().Be("car:drive");
            firstScope.Description.Should().Be("Drive car");
            firstScope.System.Should().BeFalse();
            firstScope.Default.Should().BeTrue();
            firstScope.DisplayName.Should().Be("Drive Car");
            firstScope.Consent.Should().Be(OAuth2ScopeConsentType.REQUIRED);
            firstScope.Optional.Should().BeTrue();
            firstScope.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.ALLCLIENTS);
            firstScope.Links.Should().NotBeNull();

            var secondScope = response.Data[1];
            secondScope.Id.Should().Be("scp9999999999999999");
            secondScope.Name.Should().Be("api:read");
            secondScope.System.Should().BeTrue();
            secondScope.Consent.Should().Be(OAuth2ScopeConsentType.IMPLICIT);
            secondScope.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.NOCLIENTS);
        }

        #endregion

        #region CreateOAuth2Scope Tests

        [Fact]
        public async Task CreateOAuth2ScopeAsync_BuildsCorrectPath()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:drive"",
                ""description"": ""Drive car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Drive Car"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""NO_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "car:drive",
                Description = "Drive car",
                DisplayName = "Drive Car",
                Consent = OAuth2ScopeConsentType.REQUIRED
            };

            // Act
            var result = await api.CreateOAuth2ScopeAsync(_authServerId, scopeRequest);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/scopes");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
        }

        [Fact]
        public async Task CreateOAuth2ScopeAsync_SendsRequestBody()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:drive"",
                ""description"": ""Drive car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Drive Car"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""NO_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "car:drive",
                Description = "Drive car",
                DisplayName = "Drive Car",
                Consent = OAuth2ScopeConsentType.REQUIRED
            };

            // Act
            await api.CreateOAuth2ScopeAsync(_authServerId, scopeRequest);

            // Assert
            mockClient.ReceivedBody.Should().NotBeNull();
            mockClient.ReceivedBody.Should().Contain("\"name\":\"car:drive\"");
            mockClient.ReceivedBody.Should().Contain("\"description\":\"Drive car\"");
            mockClient.ReceivedBody.Should().Contain("\"displayName\":\"Drive Car\"");
            mockClient.ReceivedBody.Should().Contain("\"consent\":\"REQUIRED\"");
        }

        [Fact]
        public async Task CreateOAuth2ScopeAsync_ReturnsCreatedScope()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:drive"",
                ""description"": ""Drive car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Drive Car"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""NO_CLIENTS"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/scopes/scp5yu8kLOnDzo7lh0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "car:drive",
                Description = "Drive car",
                DisplayName = "Drive Car",
                Consent = OAuth2ScopeConsentType.REQUIRED
            };

            // Act
            var result = await api.CreateOAuth2ScopeAsync(_authServerId, scopeRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("scp5yu8kLOnDzo7lh0g4");
            result.Name.Should().Be("car:drive");
            result.Description.Should().Be("Drive car");
            result.DisplayName.Should().Be("Drive Car");
            result.Consent.Should().Be(OAuth2ScopeConsentType.REQUIRED);
            result.System.Should().BeFalse();
            result.Default.Should().BeFalse();
            result.Optional.Should().BeFalse();
            result.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.NOCLIENTS);
            result.Links.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateOAuth2ScopeWithHttpInfo_ReturnsStatusCode201()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:drive"",
                ""description"": ""Drive car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Drive Car"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""NO_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "car:drive"
            };

            // Act
            var response = await api.CreateOAuth2ScopeWithHttpInfoAsync(_authServerId, scopeRequest);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be("scp5yu8kLOnDzo7lh0g4");
        }

        [Fact]
        public async Task CreateOAuth2ScopeAsync_WithAllProperties_SendsCompleteBody()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""api:full"",
                ""description"": ""Full API access"",
                ""system"": false,
                ""default"": true,
                ""displayName"": ""Full API Access"",
                ""consent"": ""FLEXIBLE"",
                ""optional"": true,
                ""metadataPublish"": ""ALL_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "api:full",
                Description = "Full API access",
                DisplayName = "Full API Access",
                Consent = OAuth2ScopeConsentType.FLEXIBLE,
                Default = true,
                Optional = true,
                MetadataPublish = OAuth2ScopeMetadataPublish.ALLCLIENTS
            };

            // Act
            var result = await api.CreateOAuth2ScopeAsync(_authServerId, scopeRequest);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"name\":\"api:full\"");
            mockClient.ReceivedBody.Should().Contain("\"description\":\"Full API access\"");
            mockClient.ReceivedBody.Should().Contain("\"displayName\":\"Full API Access\"");
            mockClient.ReceivedBody.Should().Contain("\"consent\":\"FLEXIBLE\"");
            mockClient.ReceivedBody.Should().Contain("\"default\":true");
            mockClient.ReceivedBody.Should().Contain("\"optional\":true");
            mockClient.ReceivedBody.Should().Contain("\"metadataPublish\":\"ALL_CLIENTS\"");

            result.Default.Should().BeTrue();
            result.Optional.Should().BeTrue();
            result.Consent.Should().Be(OAuth2ScopeConsentType.FLEXIBLE);
            result.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.ALLCLIENTS);
        }

        #endregion

        #region GetOAuth2Scope Tests

        [Fact]
        public async Task GetOAuth2ScopeAsync_BuildsCorrectPath()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:drive"",
                ""description"": ""Drive car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Drive Car"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""NO_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetOAuth2ScopeAsync(_authServerId, _scopeId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/scopes/{scopeId}");
        }

        [Fact]
        public async Task GetOAuth2ScopeAsync_SetsPathParameters()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:drive"",
                ""description"": ""Drive car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Drive Car"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""NO_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetOAuth2ScopeAsync(_authServerId, _scopeId);

            // Assert
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("scopeId");
            mockClient.ReceivedPathParams["scopeId"].Should().Be(_scopeId);
        }

        [Fact]
        public async Task GetOAuth2ScopeAsync_ReturnsScope()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:drive"",
                ""description"": ""Drive car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Drive Car"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""NO_CLIENTS"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/scopes/scp5yu8kLOnDzo7lh0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetOAuth2ScopeAsync(_authServerId, _scopeId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("scp5yu8kLOnDzo7lh0g4");
            result.Name.Should().Be("car:drive");
            result.Description.Should().Be("Drive car");
            result.DisplayName.Should().Be("Drive Car");
            result.System.Should().BeFalse();
            result.Default.Should().BeFalse();
            result.Optional.Should().BeFalse();
            result.Consent.Should().Be(OAuth2ScopeConsentType.REQUIRED);
            result.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.NOCLIENTS);
            result.Links.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOAuth2ScopeWithHttpInfo_ReturnsStatusCode200()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:drive"",
                ""description"": ""Drive car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Drive Car"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""NO_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetOAuth2ScopeWithHttpInfoAsync(_authServerId, _scopeId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Name.Should().Be("car:drive");
        }

        #endregion

        #region ReplaceOAuth2Scope Tests

        [Fact]
        public async Task ReplaceOAuth2ScopeAsync_BuildsCorrectPath()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:order"",
                ""description"": ""Order car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Order Car"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""ALL_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "car:order",
                Description = "Order car",
                MetadataPublish = OAuth2ScopeMetadataPublish.ALLCLIENTS
            };

            // Act
            var result = await api.ReplaceOAuth2ScopeAsync(_authServerId, _scopeId, scopeRequest);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/scopes/{scopeId}");
        }

        [Fact]
        public async Task ReplaceOAuth2ScopeAsync_SetsPathParameters()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:order"",
                ""description"": ""Order car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Order Car"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""ALL_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "car:order"
            };

            // Act
            await api.ReplaceOAuth2ScopeAsync(_authServerId, _scopeId, scopeRequest);

            // Assert
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("scopeId");
            mockClient.ReceivedPathParams["scopeId"].Should().Be(_scopeId);
        }

        [Fact]
        public async Task ReplaceOAuth2ScopeAsync_SendsRequestBody()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:order"",
                ""description"": ""Order car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Order Car"",
                ""consent"": ""IMPLICIT"",
                ""optional"": false,
                ""metadataPublish"": ""ALL_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "car:order",
                Description = "Order car",
                DisplayName = "Order Car",
                Consent = OAuth2ScopeConsentType.IMPLICIT,
                MetadataPublish = OAuth2ScopeMetadataPublish.ALLCLIENTS
            };

            // Act
            await api.ReplaceOAuth2ScopeAsync(_authServerId, _scopeId, scopeRequest);

            // Assert
            mockClient.ReceivedBody.Should().NotBeNull();
            mockClient.ReceivedBody.Should().Contain("\"name\":\"car:order\"");
            mockClient.ReceivedBody.Should().Contain("\"description\":\"Order car\"");
            mockClient.ReceivedBody.Should().Contain("\"displayName\":\"Order Car\"");
            mockClient.ReceivedBody.Should().Contain("\"consent\":\"IMPLICIT\"");
            mockClient.ReceivedBody.Should().Contain("\"metadataPublish\":\"ALL_CLIENTS\"");
        }

        [Fact]
        public async Task ReplaceOAuth2ScopeAsync_ReturnsUpdatedScope()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:order"",
                ""description"": ""Order car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Order Car"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""ALL_CLIENTS"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/scopes/scp5yu8kLOnDzo7lh0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "car:order",
                Description = "Order car",
                MetadataPublish = OAuth2ScopeMetadataPublish.ALLCLIENTS
            };

            // Act
            var result = await api.ReplaceOAuth2ScopeAsync(_authServerId, _scopeId, scopeRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("scp5yu8kLOnDzo7lh0g4");
            result.Name.Should().Be("car:order");
            result.Description.Should().Be("Order car");
            result.DisplayName.Should().Be("Order Car");
            result.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.ALLCLIENTS);
            result.Links.Should().NotBeNull();
        }

        [Fact]
        public async Task ReplaceOAuth2ScopeWithHttpInfo_ReturnsStatusCode200()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""car:order"",
                ""description"": ""Order car"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Order Car"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""ALL_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "car:order"
            };

            // Act
            var response = await api.ReplaceOAuth2ScopeWithHttpInfoAsync(_authServerId, _scopeId, scopeRequest);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Name.Should().Be("car:order");
        }

        #endregion

        #region DeleteOAuth2Scope Tests

        [Fact]
        public async Task DeleteOAuth2ScopeAsync_BuildsCorrectPath()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteOAuth2ScopeAsync(_authServerId, _scopeId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/scopes/{scopeId}");
        }

        [Fact]
        public async Task DeleteOAuth2ScopeAsync_SetsPathParameters()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteOAuth2ScopeAsync(_authServerId, _scopeId);

            // Assert
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("scopeId");
            mockClient.ReceivedPathParams["scopeId"].Should().Be(_scopeId);
        }

        [Fact]
        public async Task DeleteOAuth2ScopeAsync_CompletesSuccessfully()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert - delete should complete without throwing
            await api.DeleteOAuth2ScopeAsync(_authServerId, _scopeId);

            // Verify it called the correct endpoint
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/scopes/{scopeId}");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams["scopeId"].Should().Be(_scopeId);
        }

        [Fact]
        public async Task DeleteOAuth2ScopeWithHttpInfo_ReturnsStatusCode204()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteOAuth2ScopeWithHttpInfoAsync(_authServerId, _scopeId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        #endregion

        #region Input Validation Tests

        [Fact]
        public async Task CreateOAuth2ScopeAsync_WithNullAuthServerId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope { Name = "test:scope" };

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                () => api.CreateOAuth2ScopeAsync(null, scopeRequest));
        }

        [Fact]
        public async Task CreateOAuth2ScopeAsync_WithNullScope_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                () => api.CreateOAuth2ScopeAsync(_authServerId, null));
        }

        [Fact]
        public async Task GetOAuth2ScopeAsync_WithNullAuthServerId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                () => api.GetOAuth2ScopeAsync(null, _scopeId));
        }

        [Fact]
        public async Task GetOAuth2ScopeAsync_WithNullScopeId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                () => api.GetOAuth2ScopeAsync(_authServerId, null));
        }

        [Fact]
        public async Task ReplaceOAuth2ScopeAsync_WithNullAuthServerId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope { Name = "test:scope" };

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                () => api.ReplaceOAuth2ScopeAsync(null, _scopeId, scopeRequest));
        }

        [Fact]
        public async Task ReplaceOAuth2ScopeAsync_WithNullScopeId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope { Name = "test:scope" };

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                () => api.ReplaceOAuth2ScopeAsync(_authServerId, null, scopeRequest));
        }

        [Fact]
        public async Task ReplaceOAuth2ScopeAsync_WithNullScope_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                () => api.ReplaceOAuth2ScopeAsync(_authServerId, _scopeId, null));
        }

        [Fact]
        public async Task DeleteOAuth2ScopeAsync_WithNullAuthServerId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                () => api.DeleteOAuth2ScopeAsync(null, _scopeId));
        }

        [Fact]
        public async Task DeleteOAuth2ScopeAsync_WithNullScopeId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                () => api.DeleteOAuth2ScopeAsync(_authServerId, null));
        }

        [Fact]
        public void ListOAuth2Scopes_WithNullAuthServerId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            Assert.Throws<ApiException>(() => api.ListOAuth2Scopes(null));
        }

        #endregion

        #region Consent Type Tests

        [Fact]
        public async Task CreateOAuth2ScopeAsync_WithFlexibleConsent_SerializesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""flexible:scope"",
                ""description"": ""Flexible consent scope"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Flexible Scope"",
                ""consent"": ""FLEXIBLE"",
                ""optional"": false,
                ""metadataPublish"": ""NO_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "flexible:scope",
                Consent = OAuth2ScopeConsentType.FLEXIBLE
            };

            // Act
            var result = await api.CreateOAuth2ScopeAsync(_authServerId, scopeRequest);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"consent\":\"FLEXIBLE\"");
            result.Consent.Should().Be(OAuth2ScopeConsentType.FLEXIBLE);
        }

        [Fact]
        public async Task CreateOAuth2ScopeAsync_WithImplicitConsent_SerializesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""implicit:scope"",
                ""description"": ""Implicit consent scope"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Implicit Scope"",
                ""consent"": ""IMPLICIT"",
                ""optional"": false,
                ""metadataPublish"": ""NO_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "implicit:scope",
                Consent = OAuth2ScopeConsentType.IMPLICIT
            };

            // Act
            var result = await api.CreateOAuth2ScopeAsync(_authServerId, scopeRequest);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"consent\":\"IMPLICIT\"");
            result.Consent.Should().Be(OAuth2ScopeConsentType.IMPLICIT);
        }

        [Fact]
        public async Task CreateOAuth2ScopeAsync_WithRequiredConsent_SerializesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""required:scope"",
                ""description"": ""Required consent scope"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Required Scope"",
                ""consent"": ""REQUIRED"",
                ""optional"": false,
                ""metadataPublish"": ""NO_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "required:scope",
                Consent = OAuth2ScopeConsentType.REQUIRED
            };

            // Act
            var result = await api.CreateOAuth2ScopeAsync(_authServerId, scopeRequest);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"consent\":\"REQUIRED\"");
            result.Consent.Should().Be(OAuth2ScopeConsentType.REQUIRED);
        }

        #endregion

        #region MetadataPublish Tests

        [Fact]
        public async Task CreateOAuth2ScopeAsync_WithAllClientsMetadataPublish_SerializesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""public:scope"",
                ""description"": ""Public scope"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Public Scope"",
                ""consent"": ""IMPLICIT"",
                ""optional"": false,
                ""metadataPublish"": ""ALL_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "public:scope",
                MetadataPublish = OAuth2ScopeMetadataPublish.ALLCLIENTS
            };

            // Act
            var result = await api.CreateOAuth2ScopeAsync(_authServerId, scopeRequest);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"metadataPublish\":\"ALL_CLIENTS\"");
            result.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.ALLCLIENTS);
        }

        [Fact]
        public async Task CreateOAuth2ScopeAsync_WithNoClientsMetadataPublish_SerializesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""scp5yu8kLOnDzo7lh0g4"",
                ""name"": ""private:scope"",
                ""description"": ""Private scope"",
                ""system"": false,
                ""default"": false,
                ""displayName"": ""Private Scope"",
                ""consent"": ""IMPLICIT"",
                ""optional"": false,
                ""metadataPublish"": ""NO_CLIENTS""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerScopesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var scopeRequest = new OAuth2Scope
            {
                Name = "private:scope",
                MetadataPublish = OAuth2ScopeMetadataPublish.NOCLIENTS
            };

            // Act
            var result = await api.CreateOAuth2ScopeAsync(_authServerId, scopeRequest);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"metadataPublish\":\"NO_CLIENTS\"");
            result.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.NOCLIENTS);
        }

        #endregion
    }
}
