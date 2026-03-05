// <copyright file="IdentityProviderKeysApiTests.cs" company="Okta, Inc">
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
    /// Comprehensive unit tests for <see cref="IdentityProviderKeysApi"/>.
    /// Covers the global IdP key credential store endpoints at /api/v1/idps/credentials/keys.
    /// </summary>
    public class IdentityProviderKeysApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestKid = "mXtzOtml09Cg_v0JEDGkq";

        private static string BuildKeyJson(string kid = TestKid, string kty = "RSA", string use = "sig") =>
            $@"{{
                ""kid"": ""{kid}"",
                ""kty"": ""{kty}"",
                ""use"": ""{use}"",
                ""e"": ""AQAB"",
                ""n"": ""mkC6yAJVvFwhb2IQjXmX0O2N6kNyJL-Oqa6iehfGFMlY-AyxwFH55DImwpxMzx91-HHDgLWYKNWPp9Kr-uORBUA1Dl5N"",
                ""x5c"": [""MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA""],
                ""created"": ""2015-12-10T18:56:23.000Z"",
                ""expiresAt"": ""2017-12-10T18:56:22.000Z"",
                ""lastUpdated"": ""2015-12-10T18:56:23.000Z""
            }}";

        #region CreateIdentityProviderKey Tests

        [Fact]
        public async Task CreateIdentityProviderKey_WithValidBody_ReturnsCreatedKey()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            var jwk = new IdPCertificateCredential
            {
                X5c = new List<string> { "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA" }
            };

            // Act
            var result = await api.CreateIdentityProviderKeyAsync(jwk);

            // Assert
            result.Should().NotBeNull();
            result.Kid.Should().Be(TestKid);
            result.Kty.Should().Be("RSA");
            result.Use.Should().Be("sig");
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/credentials/keys");
            mockClient.ReceivedBody.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task CreateIdentityProviderKey_WithNullBody_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CreateIdentityProviderKeyAsync(null));
        }

        [Fact]
        public async Task CreateIdentityProviderKeyWithHttpInfo_WithValidBody_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created, headers);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            var jwk = new IdPCertificateCredential
            {
                X5c = new List<string> { "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA" }
            };

            // Act
            var result = await api.CreateIdentityProviderKeyWithHttpInfoAsync(jwk);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Kid.Should().Be(TestKid);
            result.Headers.Should().ContainKey("Content-Type");
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/credentials/keys");
        }

        [Fact]
        public async Task CreateIdentityProviderKeyWithHttpInfo_WithNullBody_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CreateIdentityProviderKeyWithHttpInfoAsync(null));
        }

        #endregion

        #region DeleteIdentityProviderKey Tests

        [Fact]
        public async Task DeleteIdentityProviderKey_WithValidKid_CompletesSuccessfully()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteIdentityProviderKeyAsync(TestKid);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/credentials/keys/{kid}");
            mockClient.ReceivedPathParams.Should().ContainKey("kid");
            mockClient.ReceivedPathParams["kid"].Should().Contain(TestKid);
        }

        [Fact]
        public async Task DeleteIdentityProviderKey_WithNullKid_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteIdentityProviderKeyAsync(null));
        }

        [Fact]
        public async Task DeleteIdentityProviderKeyWithHttpInfo_WithValidKid_ReturnsApiResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.DeleteIdentityProviderKeyWithHttpInfoAsync(TestKid);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/credentials/keys/{kid}");
            mockClient.ReceivedPathParams["kid"].Should().Contain(TestKid);
        }

        [Fact]
        public async Task DeleteIdentityProviderKeyWithHttpInfo_WithNullKid_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteIdentityProviderKeyWithHttpInfoAsync(null));
        }

        #endregion

        #region GetIdentityProviderKey Tests

        [Fact]
        public async Task GetIdentityProviderKey_WithValidKid_ReturnsKey()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetIdentityProviderKeyAsync(TestKid);

            // Assert
            result.Should().NotBeNull();
            result.Kid.Should().Be(TestKid);
            result.Kty.Should().Be("RSA");
            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/credentials/keys/{kid}");
            mockClient.ReceivedPathParams.Should().ContainKey("kid");
            mockClient.ReceivedPathParams["kid"].Should().Contain(TestKid);
        }

        [Fact]
        public async Task GetIdentityProviderKey_WithNullKid_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetIdentityProviderKeyAsync(null));
        }

        [Fact]
        public async Task GetIdentityProviderKeyWithHttpInfo_WithValidKid_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Rate-Limit-Remaining", "100" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetIdentityProviderKeyWithHttpInfoAsync(TestKid);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Kid.Should().Be(TestKid);
            result.Headers.Should().ContainKey("Content-Type");
            result.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
        }

        [Fact]
        public async Task GetIdentityProviderKeyWithHttpInfo_WithNullKid_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetIdentityProviderKeyWithHttpInfoAsync(null));
        }

        #endregion

        #region ListIdentityProviderKeys Tests

        [Fact]
        public async Task ListIdentityProviderKeys_WithNoParams_ReturnsCollection()
        {
            // Arrange
            var kid2 = "SIMcCQNY3uwXoW3y0vf6VxiBb5n9pf8L2fK8d-FIbm4";
            var responseJson = $"[{BuildKeyJson()}, {BuildKeyJson(kid2, "EC")}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProviderKeysWithHttpInfoAsync();

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Kid.Should().Be(TestKid);
            result.Data[1].Kid.Should().Be(kid2);
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/credentials/keys");
        }

        [Fact]
        public async Task ListIdentityProviderKeys_WithAfterCursor_SendsAfterParam()
        {
            // Arrange
            var afterCursor = "cursor-key-123";
            var responseJson = $"[{BuildKeyJson()}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProviderKeysWithHttpInfoAsync(after: afterCursor);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain(afterCursor);
        }

        [Fact]
        public async Task ListIdentityProviderKeys_WithLimit_SendsLimitParam()
        {
            // Arrange
            var responseJson = $"[{BuildKeyJson()}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProviderKeysWithHttpInfoAsync(limit: 10);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("10");
        }

        [Fact]
        public async Task ListIdentityProviderKeysWithHttpInfo_WithNoParams_ReturnsApiResponse()
        {
            // Arrange
            var kid2 = "SIMcCQNY3uwXoW3y0vf6VxiBb5n9pf8L2fK8d-FIbm4";
            var responseJson = $"[{BuildKeyJson()}, {BuildKeyJson(kid2)}]";
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProviderKeysWithHttpInfoAsync();

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().HaveCount(2);
            result.Headers.Should().ContainKey("Content-Type");
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/credentials/keys");
        }

        [Fact]
        public async Task ListIdentityProviderKeysWithHttpInfo_WithPaginationParams_SendsCorrectParams()
        {
            // Arrange
            var responseJson = $"[{BuildKeyJson()}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProviderKeysWithHttpInfoAsync(after: "cursor-abc", limit: 5);

            // Assert
            result.Data.Should().HaveCount(1);
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor-abc");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("5");
        }

        #endregion

        #region ReplaceIdentityProviderKey Tests

        [Fact]
        public async Task ReplaceIdentityProviderKey_WithValidParams_ReturnsUpdatedKey()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            var requestBody = new Dictionary<string, object>
            {
                { "kid", TestKid },
                { "kty", "RSA" },
                { "use", "sig" }
            };

            // Act
            var result = await api.ReplaceIdentityProviderKeyAsync(TestKid, requestBody);

            // Assert
            result.Should().NotBeNull();
            result.Kid.Should().Be(TestKid);
            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/credentials/keys/{kid}");
            mockClient.ReceivedPathParams.Should().ContainKey("kid");
            mockClient.ReceivedPathParams["kid"].Should().Contain(TestKid);
            mockClient.ReceivedBody.Should().Contain(TestKid);
        }

        [Fact]
        public async Task ReplaceIdentityProviderKey_WithNullKid_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });
            var requestBody = new Dictionary<string, object>();

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceIdentityProviderKeyAsync(null, requestBody));
        }

        [Fact]
        public async Task ReplaceIdentityProviderKey_WithNullBody_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceIdentityProviderKeyAsync(TestKid, null));
        }

        [Fact]
        public async Task ReplaceIdentityProviderKeyWithHttpInfo_WithValidParams_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            var requestBody = new Dictionary<string, object>
            {
                { "kid", TestKid },
                { "kty", "RSA" }
            };

            // Act
            var result = await api.ReplaceIdentityProviderKeyWithHttpInfoAsync(TestKid, requestBody);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Kid.Should().Be(TestKid);
            result.Headers.Should().ContainKey("Content-Type");
        }

        [Fact]
        public async Task ReplaceIdentityProviderKeyWithHttpInfo_WithNullKid_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceIdentityProviderKeyWithHttpInfoAsync(null, new Dictionary<string, object>()));
        }

        [Fact]
        public async Task ReplaceIdentityProviderKeyWithHttpInfo_WithNullBody_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceIdentityProviderKeyWithHttpInfoAsync(TestKid, null));
        }

        #endregion
    }
}
