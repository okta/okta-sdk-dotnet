// <copyright file="AuthorizationServerApiTests.cs" company="Okta, Inc">
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
    /// <summary>
    /// Unit tests for AuthorizationServerApi covering all 7 endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers - ListAuthorizationServers
    /// 2. POST /api/v1/authorizationServers - CreateAuthorizationServerAsync
    /// 3. GET /api/v1/authorizationServers/{authServerId} - GetAuthorizationServerAsync
    /// 4. PUT /api/v1/authorizationServers/{authServerId} - ReplaceAuthorizationServerAsync
    /// 5. DELETE /api/v1/authorizationServers/{authServerId} - DeleteAuthorizationServerAsync
    /// 6. POST /api/v1/authorizationServers/{authServerId}/lifecycle/activate - ActivateAuthorizationServerAsync
    /// 7. POST /api/v1/authorizationServers/{authServerId}/lifecycle/deactivate - DeactivateAuthorizationServerAsync
    /// 
    /// Each method is tested with:
    /// - Regular async method
    /// - WithHttpInfo variant for response metadata
    /// </summary>
    public class AuthorizationServerApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _authServerId = "aus1234567890abcdef";

        #region ListAuthorizationServers Tests

        [Fact]
        public async Task ListAuthorizationServers_ReturnsAuthorizationServersList()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""aus1111111111111111"",
                    ""name"": ""Test Server 1"",
                    ""description"": ""First test server"",
                    ""audiences"": [""https://api1.example.com""],
                    ""status"": ""ACTIVE"",
                    ""issuer"": ""https://test.okta.com/oauth2/aus1111111111111111"",
                    ""issuerMode"": ""ORG_URL"",
                    ""created"": ""2025-01-01T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
                },
                {
                    ""id"": ""aus2222222222222222"",
                    ""name"": ""Test Server 2"",
                    ""description"": ""Second test server"",
                    ""audiences"": [""https://api2.example.com""],
                    ""status"": ""INACTIVE"",
                    ""issuer"": ""https://test.okta.com/oauth2/aus2222222222222222"",
                    ""issuerMode"": ""ORG_URL"",
                    ""created"": ""2025-01-01T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListAuthorizationServersWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(2);
            response.Data[0].Id.Should().Be("aus1111111111111111");
            response.Data[0].Name.Should().Be("Test Server 1");
            response.Data[0].Status.Should().Be(LifecycleStatus.ACTIVE);
            response.Data[1].Id.Should().Be("aus2222222222222222");
            response.Data[1].Status.Should().Be(LifecycleStatus.INACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers");
        }

        [Fact]
        public async Task ListAuthorizationServersWithHttpInfo_WithQueryParameter_IncludesQueryInRequest()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""aus1111111111111111"",
                    ""name"": ""MyCustomServer"",
                    ""audiences"": [""https://custom.example.com""],
                    ""status"": ""ACTIVE""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListAuthorizationServersWithHttpInfoAsync(q: "MyCustom");

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(1);
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers");
            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams["q"].Should().Contain("MyCustom");
        }

        [Fact]
        public async Task ListAuthorizationServersWithHttpInfo_WithLimitParameter_IncludesLimitInRequest()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListAuthorizationServersWithHttpInfoAsync(limit: 50);

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("50");
        }

        [Fact]
        public async Task ListAuthorizationServersWithHttpInfo_WithAfterParameter_IncludesAfterInRequest()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListAuthorizationServersWithHttpInfoAsync(after: "cursorValue123");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursorValue123");
        }

        [Fact]
        public async Task ListAuthorizationServersWithHttpInfo_WithAllParameters_IncludesAllParametersInRequest()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListAuthorizationServersWithHttpInfoAsync(q: "test", limit: 25, after: "cursor");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams["q"].Should().Contain("test");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("25");
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor");
        }

        [Fact]
        public async Task ListAuthorizationServersWithHttpInfo_EmptyList_ReturnsEmptyArray()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListAuthorizationServersWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().BeEmpty();
        }

        [Fact]
        public async Task ListAuthorizationServersWithHttpInfo_WithMaxLimit_UsesCorrectLimit()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act - Maximum limit is 200
            var response = await api.ListAuthorizationServersWithHttpInfoAsync(limit: 200);

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("200");
        }

        #endregion

        #region CreateAuthorizationServer Tests

        [Fact]
        public async Task CreateAuthorizationServerAsync_WithValidServer_ReturnsCreatedServer()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authServerId + @""",
                ""name"": ""New Test Server"",
                ""description"": ""A new authorization server"",
                ""audiences"": [""https://api.example.com""],
                ""status"": ""ACTIVE"",
                ""issuer"": ""https://test.okta.com/oauth2/" + _authServerId + @""",
                ""issuerMode"": ""ORG_URL"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newAuthServer = new AuthorizationServer
            {
                Name = "New Test Server",
                Description = "A new authorization server",
                Audiences = new System.Collections.Generic.List<string> { "https://api.example.com" }
            };

            // Act
            var result = await api.CreateAuthorizationServerAsync(newAuthServer);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_authServerId);
            result.Name.Should().Be("New Test Server");
            result.Status.Should().Be(LifecycleStatus.ACTIVE);
            result.Issuer.Should().Contain(_authServerId);

            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers");
            mockClient.ReceivedBody.Should().Contain("New Test Server");
            mockClient.ReceivedBody.Should().Contain("https://api.example.com");
        }

        [Fact]
        public async Task CreateAuthorizationServerWithHttpInfoAsync_ReturnsCreatedStatusCode()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""ausHttpInfo"",
                ""name"": ""HttpInfo Server"",
                ""audiences"": [""https://httpinfo.example.com""],
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newAuthServer = new AuthorizationServer
            {
                Name = "HttpInfo Server",
                Audiences = new System.Collections.Generic.List<string> { "https://httpinfo.example.com" }
            };

            // Act
            var response = await api.CreateAuthorizationServerWithHttpInfoAsync(newAuthServer);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be("ausHttpInfo");
        }

        [Fact]
        public async Task CreateAuthorizationServerAsync_WithMinimalFields_RequestHasRequiredFieldsOnly()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""ausMinimal"",
                ""name"": ""Minimal Server"",
                ""audiences"": [""https://minimal.example.com""],
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newAuthServer = new AuthorizationServer
            {
                Name = "Minimal Server",
                Audiences = new System.Collections.Generic.List<string> { "https://minimal.example.com" }
            };

            // Act
            var result = await api.CreateAuthorizationServerAsync(newAuthServer);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("Minimal Server");
            mockClient.ReceivedBody.Should().Contain("Minimal Server");
        }

        [Fact]
        public async Task CreateAuthorizationServerAsync_WithMultipleAudiences_AllAudiencesAreIncluded()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""ausMulti"",
                ""name"": ""Multi Audience Server"",
                ""audiences"": [""https://api1.example.com"", ""https://api2.example.com"", ""https://api3.example.com""],
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newAuthServer = new AuthorizationServer
            {
                Name = "Multi Audience Server",
                Audiences = new System.Collections.Generic.List<string>
                {
                    "https://api1.example.com",
                    "https://api2.example.com",
                    "https://api3.example.com"
                }
            };

            // Act
            var result = await api.CreateAuthorizationServerAsync(newAuthServer);

            // Assert
            result.Audiences.Should().HaveCount(3);
            mockClient.ReceivedBody.Should().Contain("api1.example.com");
            mockClient.ReceivedBody.Should().Contain("api2.example.com");
            mockClient.ReceivedBody.Should().Contain("api3.example.com");
        }

        #endregion

        #region GetAuthorizationServer Tests

        [Fact]
        public async Task GetAuthorizationServerAsync_WithValidId_ReturnsServer()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authServerId + @""",
                ""name"": ""Retrieved Server"",
                ""description"": ""A retrieved authorization server"",
                ""audiences"": [""https://api.example.com""],
                ""status"": ""ACTIVE"",
                ""issuer"": ""https://test.okta.com/oauth2/" + _authServerId + @""",
                ""issuerMode"": ""ORG_URL"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerAsync(_authServerId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_authServerId);
            result.Name.Should().Be("Retrieved Server");
            result.Status.Should().Be(LifecycleStatus.ACTIVE);
            result.IssuerMode.Should().Be("ORG_URL");

            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
        }

        [Fact]
        public async Task GetAuthorizationServerAsync_WhenServerIsInactive_ReturnsInactiveStatus()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""ausInactive"",
                ""name"": ""Inactive Server"",
                ""audiences"": [""https://api.example.com""],
                ""status"": ""INACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerAsync("ausInactive");

            // Assert
            result.Status.Should().Be(LifecycleStatus.INACTIVE);
        }

        [Fact]
        public async Task GetAuthorizationServerWithHttpInfoAsync_ReturnsFullResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authServerId + @""",
                ""name"": ""HttpInfo Server"",
                ""audiences"": [""https://api.example.com""],
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetAuthorizationServerWithHttpInfoAsync(_authServerId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_authServerId);
        }

        [Fact]
        public async Task GetAuthorizationServerAsync_WhenServerHasCredentials_CredentialsAreReturned()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authServerId + @""",
                ""name"": ""Server With Credentials"",
                ""audiences"": [""https://api.example.com""],
                ""status"": ""ACTIVE"",
                ""credentials"": {
                    ""signing"": {
                        ""kid"": ""kid123"",
                        ""rotationMode"": ""AUTO""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerAsync(_authServerId);

            // Assert
            result.Credentials.Should().NotBeNull();
            result.Credentials.Signing.Should().NotBeNull();
            result.Credentials.Signing.Kid.Should().Be("kid123");
        }

        [Fact]
        public async Task GetAuthorizationServerAsync_WhenServerHasAllFields_AllFieldsArePopulated()
        {
            // Arrange - Full server response
            var responseJson = @"{
                ""id"": """ + _authServerId + @""",
                ""name"": ""Full Server"",
                ""description"": ""A complete authorization server"",
                ""audiences"": [""https://api.example.com""],
                ""status"": ""ACTIVE"",
                ""issuer"": ""https://test.okta.com/oauth2/" + _authServerId + @""",
                ""issuerMode"": ""ORG_URL"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z"",
                ""credentials"": {
                    ""signing"": {
                        ""kid"": ""kidValue"",
                        ""rotationMode"": ""AUTO""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerAsync(_authServerId);

            // Assert
            result.Id.Should().NotBeNullOrEmpty();
            result.Name.Should().NotBeNullOrEmpty();
            result.Description.Should().NotBeNullOrEmpty();
            result.Audiences.Should().NotBeNull();
            result.Status.Should().NotBeNull();
            result.Issuer.Should().NotBeNullOrEmpty();
            result.IssuerMode.Should().NotBeNullOrEmpty();
            result.Credentials.Should().NotBeNull();
        }

        #endregion

        #region ReplaceAuthorizationServer Tests

        [Fact]
        public async Task ReplaceAuthorizationServerAsync_WithValidData_ReturnsUpdatedServer()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authServerId + @""",
                ""name"": ""Updated Server Name"",
                ""description"": ""Updated description"",
                ""audiences"": [""https://updated-api.example.com""],
                ""issuerMode"": ""ORG_URL"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedAuthServer = new AuthorizationServer
            {
                Name = "Updated Server Name",
                Description = "Updated description",
                Audiences = new System.Collections.Generic.List<string> { "https://updated-api.example.com" },
                IssuerMode = "ORG_URL"
            };

            // Act
            var result = await api.ReplaceAuthorizationServerAsync(_authServerId, updatedAuthServer);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_authServerId);
            result.Name.Should().Be("Updated Server Name");
            result.Description.Should().Be("Updated description");

            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
            mockClient.ReceivedBody.Should().Contain("Updated Server Name");
            mockClient.ReceivedBody.Should().Contain("ORG_URL");
        }

        [Fact]
        public async Task ReplaceAuthorizationServerAsync_WhenChangingAudiences_NewAudiencesAreIncluded()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authServerId + @""",
                ""name"": ""Server"",
                ""audiences"": [""https://new-audience.example.com""],
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedAuthServer = new AuthorizationServer
            {
                Name = "Server",
                Audiences = new System.Collections.Generic.List<string> { "https://new-audience.example.com" },
                IssuerMode = "ORG_URL"
            };

            // Act
            var result = await api.ReplaceAuthorizationServerAsync(_authServerId, updatedAuthServer);

            // Assert
            result.Audiences.Should().Contain("https://new-audience.example.com");
            mockClient.ReceivedBody.Should().Contain("new-audience.example.com");
        }

        [Fact]
        public async Task ReplaceAuthorizationServerWithHttpInfoAsync_ReturnsFullResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authServerId + @""",
                ""name"": ""HttpInfo Update"",
                ""audiences"": [""https://httpinfo.example.com""],
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedAuthServer = new AuthorizationServer
            {
                Name = "HttpInfo Update",
                Audiences = new System.Collections.Generic.List<string> { "https://httpinfo.example.com" },
                IssuerMode = "ORG_URL"
            };

            // Act
            var response = await api.ReplaceAuthorizationServerWithHttpInfoAsync(_authServerId, updatedAuthServer);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Name.Should().Be("HttpInfo Update");
        }

        [Fact]
        public async Task ReplaceAuthorizationServerAsync_WhenChangingIssuerMode_NewModeIsIncluded()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authServerId + @""",
                ""name"": ""Server"",
                ""audiences"": [""https://api.example.com""],
                ""issuerMode"": ""CUSTOM_URL"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedAuthServer = new AuthorizationServer
            {
                Name = "Server",
                Audiences = new System.Collections.Generic.List<string> { "https://api.example.com" },
                IssuerMode = "CUSTOM_URL"
            };

            // Act
            var result = await api.ReplaceAuthorizationServerAsync(_authServerId, updatedAuthServer);

            // Assert
            result.IssuerMode.Should().Be("CUSTOM_URL");
            mockClient.ReceivedBody.Should().Contain("CUSTOM_URL");
        }

        [Fact]
        public async Task ReplaceAuthorizationServerAsync_WithDynamicIssuerMode_ModeIsCorrect()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authServerId + @""",
                ""name"": ""Dynamic Issuer Server"",
                ""audiences"": [""https://api.example.com""],
                ""issuerMode"": ""DYNAMIC"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedAuthServer = new AuthorizationServer
            {
                Name = "Dynamic Issuer Server",
                Audiences = new System.Collections.Generic.List<string> { "https://api.example.com" },
                IssuerMode = "DYNAMIC"
            };

            // Act
            var result = await api.ReplaceAuthorizationServerAsync(_authServerId, updatedAuthServer);

            // Assert
            result.IssuerMode.Should().Be("DYNAMIC");
            mockClient.ReceivedBody.Should().Contain("DYNAMIC");
        }

        #endregion

        #region DeleteAuthorizationServer Tests

        [Fact]
        public async Task DeleteAuthorizationServerAsync_WithValidId_RequestIsCorrectlyFormed()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteAuthorizationServerAsync(_authServerId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
        }

        [Fact]
        public async Task DeleteAuthorizationServerWithHttpInfoAsync_ReturnsNoContentStatus()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteAuthorizationServerWithHttpInfoAsync(_authServerId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteAuthorizationServerAsync_WithDifferentIds_PathContainsCorrectId()
        {
            // Arrange
            var customServerId = "ausCustomId456";
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteAuthorizationServerAsync(customServerId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(customServerId);
        }

        #endregion

        #region ActivateAuthorizationServer Tests

        [Fact]
        public async Task ActivateAuthorizationServerAsync_WithValidId_RequestIsCorrectlyFormed()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ActivateAuthorizationServerAsync(_authServerId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/lifecycle/activate");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
        }

        [Fact]
        public async Task ActivateAuthorizationServerWithHttpInfoAsync_ReturnsNoContentStatus()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ActivateAuthorizationServerWithHttpInfoAsync(_authServerId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task ActivateAuthorizationServerAsync_WithDifferentIds_PathContainsCorrectId()
        {
            // Arrange
            var customServerId = "ausToActivate789";
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ActivateAuthorizationServerAsync(customServerId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/lifecycle/activate");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(customServerId);
        }

        #endregion

        #region DeactivateAuthorizationServer Tests

        [Fact]
        public async Task DeactivateAuthorizationServerAsync_WithValidId_RequestIsCorrectlyFormed()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeactivateAuthorizationServerAsync(_authServerId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
        }

        [Fact]
        public async Task DeactivateAuthorizationServerWithHttpInfoAsync_ReturnsNoContentStatus()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeactivateAuthorizationServerWithHttpInfoAsync(_authServerId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeactivateAuthorizationServerAsync_WithDifferentIds_PathContainsCorrectId()
        {
            // Arrange
            var customServerId = "ausToDeactivate101";
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeactivateAuthorizationServerAsync(customServerId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(customServerId);
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task GetAuthorizationServerAsync_WhenServerNotFound_ThrowsApiException()
        {
            // Arrange - Return 404 response
            var errorResponse = @"{""errorCode"": ""E0000007"", ""errorSummary"": ""Not found: Resource not found: aus_invalid""}";
            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.NotFound);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                async () => await api.GetAuthorizationServerAsync("aus_invalid"));
        }

        [Fact]
        public async Task CreateAuthorizationServerAsync_WhenValidationFails_ThrowsApiException()
        {
            // Arrange - Return 400 response
            var errorResponse = @"{""errorCode"": ""E0000001"", ""errorSummary"": ""Api validation failed""}";
            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.BadRequest);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            var invalidAuthServer = new AuthorizationServer(); // Missing required fields

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                async () => await api.CreateAuthorizationServerAsync(invalidAuthServer));
        }

        [Fact]
        public async Task DeleteAuthorizationServerAsync_WhenServerIsActive_ThrowsApiException()
        {
            // Arrange - Return 400 response for trying to delete active server
            var errorResponse = @"{""errorCode"": ""E0000145"", ""errorSummary"": ""Cannot delete active authorization server""}";
            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.BadRequest);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                async () => await api.DeleteAuthorizationServerAsync(_authServerId));
        }

        [Fact]
        public async Task ActivateAuthorizationServerAsync_WhenUnauthorized_ThrowsApiException()
        {
            // Arrange - Return 401 response
            var errorResponse = @"{""errorCode"": ""E0000011"", ""errorSummary"": ""Invalid token provided""}";
            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.Unauthorized);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                async () => await api.ActivateAuthorizationServerAsync(_authServerId));
        }

        [Fact]
        public async Task ReplaceAuthorizationServerAsync_WhenIssuerModeInvalid_ThrowsApiException()
        {
            // Arrange - Return 400 response for invalid issuerMode
            var errorResponse = @"{""errorCode"": ""E0000001"", ""errorSummary"": ""Api validation failed: issuerMode"", ""errorCauses"": [{""errorSummary"": ""issuerMode: 'issuerMode' is required.""}]}";
            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.BadRequest);
            var api = new AuthorizationServerApi(mockClient, new Configuration { BasePath = BaseUrl });

            var authServer = new AuthorizationServer
            {
                Name = "Test",
                Audiences = new System.Collections.Generic.List<string> { "https://api.example.com" }
                // Missing issuerMode
            };

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                async () => await api.ReplaceAuthorizationServerAsync(_authServerId, authServer));
        }

        #endregion
    }
}
