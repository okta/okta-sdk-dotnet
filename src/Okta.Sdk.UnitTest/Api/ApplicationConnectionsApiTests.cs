// <copyright file="ApplicationConnectionsApiTests.cs" company="Okta, Inc">
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
    /// Unit tests for ApplicationConnectionsApi
    /// Tests all provisioning connection operations, and their HTTP variants
    /// Covers all 6 endpoints and 12 methods (standard + WithHttpInfo)
    /// </summary>
    public class ApplicationConnectionsApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _appId = "0oa1gjh63g214q0Hq0g4";

        #region GetDefaultProvisioningConnectionForApplication Tests

        [Fact]
        public async Task GetDefaultProvisioningConnectionForApplication_ReturnsConnection()
        {
            // Arrange
            var responseJson = GetProvisioningConnectionResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var connection = await api.GetDefaultProvisioningConnectionForApplicationAsync(_appId);

            // Assert
            connection.Should().NotBeNull();
            connection.Status.Should().Be(ProvisioningConnectionStatus.ENABLED);
            connection.Profile.Should().NotBeNull();
            connection.Profile.AuthScheme.Should().Be(ProvisioningConnectionAuthScheme.TOKEN);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task GetDefaultProvisioningConnectionForApplicationWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = GetProvisioningConnectionResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetDefaultProvisioningConnectionForApplicationWithHttpInfoAsync(_appId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Status.Should().Be(ProvisioningConnectionStatus.ENABLED);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task GetDefaultProvisioningConnectionForApplication_WithSpecialCharacters_EncodesAppId()
        {
            // Arrange
            var appIdWithSpecialChars = "app+test@123";
            var responseJson = GetProvisioningConnectionResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var connection = await api.GetDefaultProvisioningConnectionForApplicationAsync(appIdWithSpecialChars);

            // Assert
            connection.Should().NotBeNull();
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(appIdWithSpecialChars);
        }

        #endregion

        #region UpdateDefaultProvisioningConnectionForApplication Tests

        [Fact]
        public async Task UpdateDefaultProvisioningConnectionForApplication_WithTokenAuth_ReturnsUpdatedConnection()
        {
            // Arrange
            var responseJson = GetProvisioningConnectionResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateDefaultProvisioningConnectionForApplicationRequest(
                new ProvisioningConnectionTokenRequest
                {
                    Profile = new ProvisioningConnectionTokenRequestProfile
                    {
                        AuthScheme = ProvisioningConnectionTokenAuthScheme.TOKEN,
                        Token = "test-token-123"
                    },
                    BaseUrl = "https://scim.example.com/v2"
                }
            );

            // Act
            var connection = await api.UpdateDefaultProvisioningConnectionForApplicationAsync(
                _appId,
                updateRequest,
                activate: false
            );

            // Assert
            connection.Should().NotBeNull();
            connection.Status.Should().Be(ProvisioningConnectionStatus.ENABLED);
            connection.Profile.AuthScheme.Should().Be(ProvisioningConnectionAuthScheme.TOKEN);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
            mockClient.ReceivedBody.Should().Contain("test-token-123");
            mockClient.ReceivedBody.Should().Contain("https://scim.example.com/v2");
            mockClient.ReceivedQueryParams.Should().ContainKey("activate");
            mockClient.ReceivedQueryParams["activate"].Should().Contain("false");
        }

        [Fact]
        public async Task UpdateDefaultProvisioningConnectionForApplication_WithActivateTrue_IncludesQueryParam()
        {
            // Arrange
            var responseJson = GetProvisioningConnectionResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateDefaultProvisioningConnectionForApplicationRequest(
                new ProvisioningConnectionTokenRequest
                {
                    Profile = new ProvisioningConnectionTokenRequestProfile
                    {
                        AuthScheme = ProvisioningConnectionTokenAuthScheme.TOKEN,
                        Token = "activate-token"
                    },
                    BaseUrl = "https://scim.activate.com/v2"
                }
            );

            // Act
            var connection = await api.UpdateDefaultProvisioningConnectionForApplicationAsync(
                _appId,
                updateRequest,
                activate: true
            );

            // Assert
            connection.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("activate");
            mockClient.ReceivedQueryParams["activate"].Should().Contain("true");
        }

        [Fact]
        public async Task UpdateDefaultProvisioningConnectionForApplication_WithNullActivate_DoesNotIncludeQueryParam()
        {
            // Arrange
            var responseJson = GetProvisioningConnectionResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateDefaultProvisioningConnectionForApplicationRequest(
                new ProvisioningConnectionTokenRequest
                {
                    Profile = new ProvisioningConnectionTokenRequestProfile
                    {
                        AuthScheme = ProvisioningConnectionTokenAuthScheme.TOKEN,
                        Token = "null-activate-token"
                    },
                    BaseUrl = "https://scim.null.com/v2"
                }
            );

            // Act
            var connection = await api.UpdateDefaultProvisioningConnectionForApplicationAsync(
                _appId,
                updateRequest,
                activate: null
            );

            // Assert
            connection.Should().NotBeNull();
            // Query params might be null or empty when no optional params are set
            if (mockClient.ReceivedQueryParams != null)
            {
                mockClient.ReceivedQueryParams.Should().NotContainKey("activate");
            }
        }

        [Fact]
        public async Task UpdateDefaultProvisioningConnectionForApplicationWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = GetProvisioningConnectionResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateDefaultProvisioningConnectionForApplicationRequest(
                new ProvisioningConnectionTokenRequest
                {
                    Profile = new ProvisioningConnectionTokenRequestProfile
                    {
                        AuthScheme = ProvisioningConnectionTokenAuthScheme.TOKEN,
                        Token = "http-info-token"
                    },
                    BaseUrl = "https://scim.httpinfo.com/v2"
                }
            );

            // Act
            var response = await api.UpdateDefaultProvisioningConnectionForApplicationWithHttpInfoAsync(
                _appId,
                updateRequest,
                activate: true
            );

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Status.Should().Be(ProvisioningConnectionStatus.ENABLED);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
            mockClient.ReceivedQueryParams["activate"].Should().Contain("true");
        }

        #endregion

        #region GetUserProvisioningConnectionJWKS Tests

        [Fact]
        public async Task GetUserProvisioningConnectionJWKS_ReturnsJWKSResponse()
        {
            // Arrange
            var responseJson = GetJwksResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var jwksResponse = await api.GetUserProvisioningConnectionJWKSAsync(_appId);

            // Assert
            jwksResponse.Should().NotBeNull();
            jwksResponse.Jwks.Should().NotBeNull();
            jwksResponse.Jwks.Keys.Should().NotBeNull();
            jwksResponse.Jwks.Keys.Should().HaveCount(1);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task GetUserProvisioningConnectionJWKSWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = GetJwksResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetUserProvisioningConnectionJWKSWithHttpInfoAsync(_appId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Jwks.Should().NotBeNull();
            response.Data.Jwks.Keys.Should().NotBeNull();

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task GetUserProvisioningConnectionJWKS_WithEmptyKeys_ReturnsEmptyList()
        {
            // Arrange
            var responseJson = GetEmptyJwksResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var jwksResponse = await api.GetUserProvisioningConnectionJWKSAsync(_appId);

            // Assert
            jwksResponse.Should().NotBeNull();
            jwksResponse.Jwks.Should().NotBeNull();
            jwksResponse.Jwks.Keys.Should().NotBeNull();
            jwksResponse.Jwks.Keys.Should().BeEmpty();
        }

        #endregion

        #region ActivateDefaultProvisioningConnectionForApplication Tests

        [Fact]
        public async Task ActivateDefaultProvisioningConnectionForApplication_CallsCorrectEndpoint()
        {
            // Arrange
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ActivateDefaultProvisioningConnectionForApplicationAsync(_appId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task ActivateDefaultProvisioningConnectionForApplicationWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ActivateDefaultProvisioningConnectionForApplicationWithHttpInfoAsync(_appId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task ActivateDefaultProvisioningConnectionForApplication_WithSpecialCharacters_EncodesAppId()
        {
            // Arrange
            var appIdWithSpecialChars = "app/activate+test";
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ActivateDefaultProvisioningConnectionForApplicationAsync(appIdWithSpecialChars);

            // Assert
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(appIdWithSpecialChars);
        }

        #endregion

        #region DeactivateDefaultProvisioningConnectionForApplication Tests

        [Fact]
        public async Task DeactivateDefaultProvisioningConnectionForApplication_CallsCorrectEndpoint()
        {
            // Arrange
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeactivateDefaultProvisioningConnectionForApplicationAsync(_appId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task DeactivateDefaultProvisioningConnectionForApplicationWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeactivateDefaultProvisioningConnectionForApplicationWithHttpInfoAsync(_appId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task DeactivateDefaultProvisioningConnectionForApplication_WithSpecialCharacters_EncodesAppId()
        {
            // Arrange
            var appIdWithSpecialChars = "app@deactivate#test";
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeactivateDefaultProvisioningConnectionForApplicationAsync(appIdWithSpecialChars);

            // Assert
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(appIdWithSpecialChars);
        }

        #endregion

        #region VerifyProvisioningConnectionForApplication Tests

        [Fact]
        public async Task VerifyProvisioningConnectionForApplication_WithGoogleApp_CallsCorrectEndpoint()
        {
            // Arrange
            var appName = OAuthProvisioningEnabledApp.Google;
            var code = "auth-code-xyz";
            var state = "state-token-abc";
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.VerifyProvisioningConnectionForApplicationAsync(appName, _appId, code, state);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appName}/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId); mockClient.ReceivedPathParams.Should().ContainKey("appName");
            mockClient.ReceivedPathParams.Should().ContainKey("appName");
            mockClient.ReceivedPathParams["appName"].Should().Be(appName.Value);
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(_appId);
            mockClient.ReceivedQueryParams.Should().ContainKey("code");
            mockClient.ReceivedQueryParams["code"].Should().Contain(code);
            mockClient.ReceivedQueryParams.Should().ContainKey("state");
            mockClient.ReceivedQueryParams["state"].Should().Contain(state);
        }

        [Fact]
        public async Task VerifyProvisioningConnectionForApplication_WithOffice365_CallsCorrectEndpoint()
        {
            // Arrange
            var appName = OAuthProvisioningEnabledApp.Office365;
            var code = "office-code-123";
            var state = "office-state-456";
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.VerifyProvisioningConnectionForApplicationAsync(appName, _appId, code, state);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appName}/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId); mockClient.ReceivedPathParams.Should().ContainKey("appName");
            mockClient.ReceivedPathParams["appName"].Should().Be(appName.Value);
            mockClient.ReceivedQueryParams["code"].Should().Contain(code);
            mockClient.ReceivedQueryParams["state"].Should().Contain(state);
        }

        [Fact]
        public async Task VerifyProvisioningConnectionForApplication_WithSlack_CallsCorrectEndpoint()
        {
            // Arrange
            var appName = OAuthProvisioningEnabledApp.Slack;
            var code = "slack-code-xyz";
            var state = "slack-state-abc";
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.VerifyProvisioningConnectionForApplicationAsync(appName, _appId, code, state);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appName}/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId); mockClient.ReceivedPathParams.Should().ContainKey("appName");
            mockClient.ReceivedPathParams["appName"].Should().Be(appName.Value);
        }

        [Fact]
        public async Task VerifyProvisioningConnectionForApplication_WithZoom_CallsCorrectEndpoint()
        {
            // Arrange
            var appName = OAuthProvisioningEnabledApp.Zoomus;
            var code = "zoom-code-123";
            var state = "zoom-state-456";
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.VerifyProvisioningConnectionForApplicationAsync(appName, _appId, code, state);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appName}/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId); mockClient.ReceivedPathParams.Should().ContainKey("appName");
            mockClient.ReceivedPathParams["appName"].Should().Be(appName.Value);
        }

        [Fact]
        public async Task VerifyProvisioningConnectionForApplication_WithNullCodeAndState_DoesNotIncludeQueryParams()
        {
            // Arrange
            var appName = OAuthProvisioningEnabledApp.Google;
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.VerifyProvisioningConnectionForApplicationAsync(appName, _appId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appName}/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId); mockClient.ReceivedPathParams.Should().ContainKey("appName");
            // Query params might be null or empty when no optional params are set
            if (mockClient.ReceivedQueryParams != null)
            {
                mockClient.ReceivedQueryParams.Should().NotContainKey("code");
                mockClient.ReceivedQueryParams.Should().NotContainKey("state");
            }
        }

        [Fact]
        public async Task VerifyProvisioningConnectionForApplicationWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var appName = OAuthProvisioningEnabledApp.Google;
            var code = "http-info-code";
            var state = "http-info-state";
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.VerifyProvisioningConnectionForApplicationWithHttpInfoAsync(
                appName,
                _appId,
                code,
                state
            );

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appName}/{appId}"); mockClient.ReceivedPathParams.Should().ContainKey("appId"); mockClient.ReceivedPathParams["appId"].Should().Contain(_appId); mockClient.ReceivedPathParams.Should().ContainKey("appName");
            mockClient.ReceivedQueryParams["code"].Should().Contain(code);
            mockClient.ReceivedQueryParams["state"].Should().Contain(state);
        }

        [Fact]
        public async Task VerifyProvisioningConnectionForApplication_WithSpecialCharactersInParams_EncodesCorrectly()
        {
            // Arrange
            var appName = OAuthProvisioningEnabledApp.Office365;
            var appIdWithSpecialChars = "app+test/123";
            var code = "code+with/special=chars";
            var state = "state@with#special$chars";
            var responseJson = "{}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApplicationConnectionsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.VerifyProvisioningConnectionForApplicationAsync(appName, appIdWithSpecialChars, code, state);

            // Assert
            mockClient.ReceivedPathParams["appId"].Should().Be(appIdWithSpecialChars);
            mockClient.ReceivedQueryParams["code"].Should().Contain(code);
            mockClient.ReceivedQueryParams["state"].Should().Contain(state);
        }

        #endregion

        #region Helper Methods for JSON Responses

        private string GetProvisioningConnectionResponseJson()
        {
            return @"{
                ""status"": ""ENABLED"",
                ""profile"": {
                    ""authScheme"": ""TOKEN""
                },
                ""_links"": {
                    ""self"": {
                        ""href"": """ + BaseUrl + @"/api/v1/apps/" + _appId + @"/connections/default""
                    }
                }
            }";
        }

        private static string GetJwksResponseJson()
        {
            return @"{
                ""jwks"": {
                    ""keys"": [
                        {
                            ""kty"": ""RSA"",
                            ""kid"": ""key-123"",
                            ""use"": ""sig"",
                            ""n"": ""0vx7agoebGcQSuuPiLJXZptN9nndrQmbXEps2aiAFbWhM78LhWx4cbbfAAtVT86zwu1RK7aPFFxuhDR1L6tSoc_BJECPebWKRXjBZCiFV4n3oknjhMstn64tZ_2W-5JsGY4Hc5n9yBXArwl93lqt7_RN5w6Cf0h4QyQ5v-65YGjQR0_FDW2QvzqY368QQMicAtaSqzs8KJZgnYb9c7d0zgdAZHzu6qMQvRL5hajrn1n91CbOpbISD08qNLyrdkt-bFTWhAI4vMQFh6WeZu0fM4lFd2NcRwr3XPksINHaQ-G_xBniIqbw0Ls1jF44-csFCur-kEgU8awapJzKnqDKgw"",
                            ""e"": ""AQAB""
                        }
                    ]
                }
            }";
        }

        private static string GetEmptyJwksResponseJson()
        {
            return @"{
                ""jwks"": {
                    ""keys"": []
                }
            }";
        }

        #endregion
    }
}
