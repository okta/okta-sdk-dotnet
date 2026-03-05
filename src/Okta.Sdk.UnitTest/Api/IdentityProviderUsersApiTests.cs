// <copyright file="IdentityProviderUsersApiTests.cs" company="Okta, Inc">
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
    /// Comprehensive unit tests for <see cref="IdentityProviderUsersApi"/>.
    /// Covers user-IdP linking, listing federated users, and social auth tokens.
    /// </summary>
    public class IdentityProviderUsersApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestIdpId = "0oa1k5d68qR2954hb0g4";
        private const string TestUserId = "00u1f96ECLNVOKVMUSEA";

        private static string BuildIdpUserJson(string id = TestUserId, string externalId = "ext-123") =>
            $@"{{
                ""id"": ""{id}"",
                ""externalId"": ""{externalId}"",
                ""created"": ""2017-03-30T02:19:51.000Z"",
                ""lastUpdated"": ""2017-03-30T02:19:51.000Z"",
                ""profile"": {{
                    ""firstName"": ""John"",
                    ""lastName"": ""Doe""
                }}
            }}";

        private static string BuildSocialAuthTokenJson(string id = "sat001") =>
            $@"{{
                ""id"": ""{id}"",
                ""token"": ""eyJhbGciOiJSUzI1NiJ9"",
                ""tokenType"": ""urn:ietf:params:oauth:token-type:access_token"",
                ""tokenAuthScheme"": ""Bearer"",
                ""expiresAt"": ""2017-04-01T00:00:00.000Z"",
                ""scopes"": [""openid"", ""profile""]
            }}";

        private static string BuildIdpJson(string id = "0oa1k5d68qR2954hb0g4") =>
            $@"{{
                ""id"": ""{id}"",
                ""name"": ""Test IdP"",
                ""status"": ""ACTIVE"",
                ""type"": ""GOOGLE"",
                ""created"": ""2024-01-01T00:00:00.000Z"",
                ""lastUpdated"": ""2024-01-01T00:00:00.000Z""
            }}";

        #region GetIdentityProviderApplicationUser Tests

        [Fact]
        public async Task GetIdentityProviderApplicationUser_WithValidParams_ReturnsUser()
        {
            // Arrange
            var responseJson = BuildIdpUserJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetIdentityProviderApplicationUserAsync(TestIdpId, TestUserId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestUserId);
            result.ExternalId.Should().Be("ext-123");
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/users/{userId}");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
            mockClient.ReceivedPathParams.Should().ContainKey("userId");
            mockClient.ReceivedPathParams["userId"].Should().Contain(TestUserId);
        }

        [Fact]
        public async Task GetIdentityProviderApplicationUser_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetIdentityProviderApplicationUserAsync(null, TestUserId));
        }

        [Fact]
        public async Task GetIdentityProviderApplicationUser_WithNullUserId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetIdentityProviderApplicationUserAsync(TestIdpId, null));
        }

        [Fact]
        public async Task GetIdentityProviderApplicationUserWithHttpInfo_WithValidParams_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildIdpUserJson();
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetIdentityProviderApplicationUserWithHttpInfoAsync(TestIdpId, TestUserId);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestUserId);
            result.Headers.Should().ContainKey("Content-Type");
        }

        #endregion

        #region LinkUserToIdentityProvider Tests

        [Fact]
        public async Task LinkUserToIdentityProvider_WithValidParams_ReturnsLinkedUser()
        {
            // Arrange
            var responseJson = BuildIdpUserJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var linkRequest = new UserIdentityProviderLinkRequest { ExternalId = "ext-123" };

            // Act
            var result = await api.LinkUserToIdentityProviderAsync(TestIdpId, TestUserId, linkRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestUserId);
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/users/{userId}");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
            mockClient.ReceivedPathParams.Should().ContainKey("userId");
            mockClient.ReceivedPathParams["userId"].Should().Contain(TestUserId);
        }

        [Fact]
        public async Task LinkUserToIdentityProvider_SendsExternalIdInBody()
        {
            // Arrange
            var responseJson = BuildIdpUserJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var linkRequest = new UserIdentityProviderLinkRequest { ExternalId = "ext-body-456" };

            // Act
            await api.LinkUserToIdentityProviderAsync(TestIdpId, TestUserId, linkRequest);

            // Assert
            mockClient.ReceivedBody.Should().Contain("ext-body-456");
        }

        [Fact]
        public async Task LinkUserToIdentityProvider_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            var linkRequest = new UserIdentityProviderLinkRequest { ExternalId = "ext-123" };

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.LinkUserToIdentityProviderAsync(null, TestUserId, linkRequest));
        }

        [Fact]
        public async Task LinkUserToIdentityProvider_WithNullUserId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            var linkRequest = new UserIdentityProviderLinkRequest { ExternalId = "ext-123" };

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.LinkUserToIdentityProviderAsync(TestIdpId, null, linkRequest));
        }

        [Fact]
        public async Task LinkUserToIdentityProvider_WithNullLinkRequest_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.LinkUserToIdentityProviderAsync(TestIdpId, TestUserId, null));
        }

        [Fact]
        public async Task LinkUserToIdentityProviderWithHttpInfo_WithValidParams_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildIdpUserJson();
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var linkRequest = new UserIdentityProviderLinkRequest { ExternalId = "ext-123" };

            // Act
            var result = await api.LinkUserToIdentityProviderWithHttpInfoAsync(TestIdpId, TestUserId, linkRequest);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestUserId);
        }

        #endregion

        #region ListIdentityProviderApplicationUsers Tests

        [Fact]
        public async Task ListIdentityProviderApplicationUsers_WithValidIdpId_ReturnsUsers()
        {
            // Arrange
            var userId2 = "00u2f96ECLNVOKVMUSEA";
            var idpUser1 = BuildIdpUserJson();
            var idpUser2 = BuildIdpUserJson(userId2, "ext-456");
            var responseJson = $"[{idpUser1}, {idpUser2}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProviderApplicationUsersWithHttpInfoAsync(TestIdpId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Id.Should().Be(TestUserId);
            result.Data[1].Id.Should().Be(userId2);
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/users");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
        }

        [Fact]
        public async Task ListIdentityProviderApplicationUsers_WithQueryParam_SendsCorrectParams()
        {
            // Arrange
            var responseJson = $"[{BuildIdpUserJson()}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProviderApplicationUsersWithHttpInfoAsync(
                TestIdpId, q: "John", after: "cursor-abc", limit: 10, expand: "user");

            // Assert
            result.Data.Should().HaveCount(1);
            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams["q"].Should().Contain("John");
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor-abc");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("10");
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("user");
        }

        [Fact]
        public async Task ListIdentityProviderApplicationUsers_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ListIdentityProviderApplicationUsersWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task ListIdentityProviderApplicationUsersWithHttpInfo_WithPaginationLink_ReturnsHeaders()
        {
            // Arrange
            var responseJson = $"[{BuildIdpUserJson()}]";
            var headers = new Multimap<string, string>
            {
                { "Link", "<https://test.okta.com/api/v1/idps/001/users?after=next>; rel=\"next\"" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProviderApplicationUsersWithHttpInfoAsync(TestIdpId);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().HaveCount(1);
            result.Headers.Should().ContainKey("Link");
        }

        #endregion

        #region ListSocialAuthTokens Tests

        [Fact]
        public async Task ListSocialAuthTokens_WithValidParams_ReturnsTokens()
        {
            // Arrange
            var tokenId2 = "sat002";
            var responseJson = $"[{BuildSocialAuthTokenJson()}, {BuildSocialAuthTokenJson(tokenId2)}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListSocialAuthTokensWithHttpInfoAsync(TestIdpId, TestUserId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Id.Should().Be("sat001");
            result.Data[1].Id.Should().Be(tokenId2);
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/users/{userId}/credentials/tokens");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
            mockClient.ReceivedPathParams.Should().ContainKey("userId");
            mockClient.ReceivedPathParams["userId"].Should().Contain(TestUserId);
        }

        [Fact]
        public async Task ListSocialAuthTokens_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ListSocialAuthTokensWithHttpInfoAsync(null, TestUserId));
        }

        [Fact]
        public async Task ListSocialAuthTokens_WithNullUserId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ListSocialAuthTokensWithHttpInfoAsync(TestIdpId, null));
        }

        [Fact]
        public async Task ListSocialAuthTokensWithHttpInfo_ReturnsTokenFields()
        {
            // Arrange
            var responseJson = $"[{BuildSocialAuthTokenJson()}]";
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListSocialAuthTokensWithHttpInfoAsync(TestIdpId, TestUserId);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().HaveCount(1);
            result.Data[0].Token.Should().Be("eyJhbGciOiJSUzI1NiJ9");
            result.Data[0].TokenType.Should().Be("urn:ietf:params:oauth:token-type:access_token");
        }

        #endregion

        #region ListUserIdentityProviders Tests

        [Fact]
        public async Task ListUserIdentityProviders_WithValidUserId_ReturnsIdps()
        {
            // Arrange
            var idpId2 = "0oa2k5d68qR2954hb0g5";
            var responseJson = $"[{BuildIdpJson()}, {BuildIdpJson(idpId2)}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListUserIdentityProvidersWithHttpInfoAsync(TestUserId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Id.Should().Be(TestIdpId);
            result.Data[1].Id.Should().Be(idpId2);
            mockClient.ReceivedPath.Should().Be("/api/v1/users/{id}/idps");
            mockClient.ReceivedPathParams.Should().ContainKey("id");
            mockClient.ReceivedPathParams["id"].Should().Contain(TestUserId);
        }

        [Fact]
        public async Task ListUserIdentityProviders_WithNullId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ListUserIdentityProvidersWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task ListUserIdentityProvidersWithHttpInfo_WithHeaders_ReturnsStatusCode200()
        {
            // Arrange
            var responseJson = $"[{BuildIdpJson()}]";
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListUserIdentityProvidersWithHttpInfoAsync(TestUserId);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().HaveCount(1);
            result.Headers.Should().ContainKey("Content-Type");
        }

        #endregion

        #region UnlinkUserFromIdentityProvider Tests

        [Fact]
        public async Task UnlinkUserFromIdentityProvider_WithValidParams_CompletesSuccessfully()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.UnlinkUserFromIdentityProviderAsync(TestIdpId, TestUserId);

            // Assert — no exception means success
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/users/{userId}");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
            mockClient.ReceivedPathParams.Should().ContainKey("userId");
            mockClient.ReceivedPathParams["userId"].Should().Contain(TestUserId);
        }

        [Fact]
        public async Task UnlinkUserFromIdentityProvider_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UnlinkUserFromIdentityProviderAsync(null, TestUserId));
        }

        [Fact]
        public async Task UnlinkUserFromIdentityProvider_WithNullUserId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UnlinkUserFromIdentityProviderAsync(TestIdpId, null));
        }

        [Fact]
        public async Task UnlinkUserFromIdentityProviderWithHttpInfo_WithValidParams_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new IdentityProviderUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.UnlinkUserFromIdentityProviderWithHttpInfoAsync(TestIdpId, TestUserId);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        #endregion
    }
}
