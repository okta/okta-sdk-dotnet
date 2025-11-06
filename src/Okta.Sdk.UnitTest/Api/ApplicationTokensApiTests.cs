// <copyright file="ApplicationTokensApiTests.cs" company="Okta, Inc">
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
    /// Unit tests for ApplicationTokensApi.
    /// Tests all 8 methods (4 operations with async and WithHttpInfo variants).
    /// </summary>
    public class ApplicationTokensApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestAppId = "0oa1gjh63g214q0Hq0g4";
        private const string TestTokenId = "oar2h3xbkPWJOIJRQ0g4";
        private const string TestUserId = "00u1gu2fJaO6T8V5Y0g4";

        #region GetOAuth2TokenForApplication Tests

        [Fact]
        public async Task GetOAuth2TokenForApplication_WithValidParameters_ReturnsToken()
        {
            var responseJson = @"{
                ""id"": ""oar2h3xbkPWJOIJRQ0g4"",
                ""status"": ""ACTIVE"",
                ""created"": ""2023-01-15T12:00:00.000Z"",
                ""lastUpdated"": ""2023-01-15T12:00:00.000Z"",
                ""expiresAt"": ""2024-01-15T12:00:00.000Z"",
                ""issuer"": ""https://test.okta.com/oauth2/default"",
                ""clientId"": ""0oa1gjh63g214q0Hq0g4"",
                ""userId"": ""00u1gu2fJaO6T8V5Y0g4"",
                ""scopes"": [""openid"", ""profile"", ""email""],
                ""_links"": {
                    ""app"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4"",
                        ""title"": ""Test Application""
                    },
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4/tokens/oar2h3xbkPWJOIJRQ0g4""
                    },
                    ""revoke"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4/tokens/oar2h3xbkPWJOIJRQ0g4""
                    },
                    ""client"": {
                        ""href"": ""https://test.okta.com/oauth2/v1/clients/0oa1gjh63g214q0Hq0g4"",
                        ""title"": ""Test Application""
                    },
                    ""user"": {
                        ""href"": ""https://test.okta.com/api/v1/users/00u1gu2fJaO6T8V5Y0g4"",
                        ""title"": ""Test User""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetOAuth2TokenForApplicationAsync(TestAppId, TestTokenId);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestTokenId);
            result.Status.Should().Be(GrantOrTokenStatus.ACTIVE);
            result.ClientId.Should().Be(TestAppId);
            result.UserId.Should().Be(TestUserId);
            result.Scopes.Should().Contain("openid");
            result.Scopes.Should().Contain("profile");
            result.Scopes.Should().Contain("email");
            result.Links.Should().NotBeNull();
            result.Links.App.Should().NotBeNull();
            result.Links.Self.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("tokens");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
            mockClient.ReceivedPathParams.Should().ContainKey("tokenId");
            mockClient.ReceivedPathParams["tokenId"].Should().Be(TestTokenId);
        }

        [Fact]
        public async Task GetOAuth2TokenForApplication_WithExpandParameter_AddsToQueryString()
        {
            var responseJson = @"{
                ""id"": ""oar2h3xbkPWJOIJRQ0g4"",
                ""status"": ""ACTIVE"",
                ""scopes"": [""openid""],
                ""_embedded"": {
                    ""scopes"": [
                        {
                            ""id"": ""openid""
                        }
                    ]
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetOAuth2TokenForApplicationAsync(TestAppId, TestTokenId, expand: "scope");

            result.Should().NotBeNull();
            result.Id.Should().Be(TestTokenId);
            mockClient.ReceivedQueryParams.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
        }

        [Fact]
        public async Task GetOAuth2TokenForApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetOAuth2TokenForApplicationAsync(null, TestTokenId));
        }

        [Fact]
        public async Task GetOAuth2TokenForApplication_WithNullTokenId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetOAuth2TokenForApplicationAsync(TestAppId, null));
        }

        [Fact]
        public async Task GetOAuth2TokenForApplicationWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"{
                ""id"": ""oar2h3xbkPWJOIJRQ0g4"",
                ""status"": ""ACTIVE"",
                ""clientId"": ""0oa1gjh63g214q0Hq0g4""
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Rate-Limit-Remaining", "100" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetOAuth2TokenForApplicationWithHttpInfoAsync(TestAppId, TestTokenId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestTokenId);
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("Content-Type");
            result.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
        }

        [Fact]
        public async Task GetOAuth2TokenForApplicationWithHttpInfo_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetOAuth2TokenForApplicationWithHttpInfoAsync(null, TestTokenId));
        }

        [Fact]
        public async Task GetOAuth2TokenForApplicationWithHttpInfo_WithNullTokenId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetOAuth2TokenForApplicationWithHttpInfoAsync(TestAppId, null));
        }

        #endregion

        #region ListOAuth2TokensForApplication Tests

        [Fact]
        public async Task ListOAuth2TokensForApplication_WithValidAppId_ReturnsCollection()
        {
            var responseJson = @"[
                {
                    ""id"": ""oar2h3xbkPWJOIJRQ0g4"",
                    ""status"": ""ACTIVE"",
                    ""clientId"": ""0oa1gjh63g214q0Hq0g4"",
                    ""userId"": ""00u1gu2fJaO6T8V5Y0g4"",
                    ""scopes"": [""openid"", ""profile""]
                },
                {
                    ""id"": ""oar3h3xbkPWJOIJRQ0g5"",
                    ""status"": ""ACTIVE"",
                    ""clientId"": ""0oa1gjh63g214q0Hq0g4"",
                    ""userId"": ""00u2gu2fJaO6T8V5Y0g5"",
                    ""scopes"": [""openid"", ""email""]
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListOAuth2TokensForApplicationWithHttpInfoAsync(TestAppId);

            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Id.Should().Be("oar2h3xbkPWJOIJRQ0g4");
            result.Data[1].Id.Should().Be("oar3h3xbkPWJOIJRQ0g5");
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("tokens");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
        }

        [Fact]
        public async Task ListOAuth2TokensForApplication_WithExpandParameter_AddsToQueryString()
        {
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListOAuth2TokensForApplicationWithHttpInfoAsync(TestAppId, expand: "scope");

            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
        }

        [Fact]
        public async Task ListOAuth2TokensForApplication_WithAfterParameter_AddsToQueryString()
        {
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListOAuth2TokensForApplicationWithHttpInfoAsync(TestAppId, after: "cursor123");

            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
        }

        [Fact]
        public async Task ListOAuth2TokensForApplication_WithLimitParameter_AddsToQueryString()
        {
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListOAuth2TokensForApplicationWithHttpInfoAsync(TestAppId, limit: 50);

            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
        }

        [Fact]
        public async Task ListOAuth2TokensForApplication_WithAllParameters_AddsToQueryString()
        {
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListOAuth2TokensForApplicationWithHttpInfoAsync(
                TestAppId, 
                expand: "scope", 
                after: "cursor123", 
                limit: 100);

            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
        }

        [Fact]
        public async Task ListOAuth2TokensForApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.ListOAuth2TokensForApplicationWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task ListOAuth2TokensForApplicationWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"[
                {
                    ""id"": ""oar2h3xbkPWJOIJRQ0g4"",
                    ""status"": ""ACTIVE""
                }
            ]";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "Link", "<https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4/tokens?after=cursor123>; rel=\"next\"" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListOAuth2TokensForApplicationWithHttpInfoAsync(TestAppId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(1);
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("Content-Type");
            result.Headers.Should().ContainKey("Link");
        }

        #endregion

        #region RevokeOAuth2TokenForApplication Tests

        [Fact]
        public async Task RevokeOAuth2TokenForApplication_WithValidParameters_CompletesSuccessfully()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.RevokeOAuth2TokenForApplicationAsync(TestAppId, TestTokenId);

            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("tokens");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
            mockClient.ReceivedPathParams.Should().ContainKey("tokenId");
            mockClient.ReceivedPathParams["tokenId"].Should().Be(TestTokenId);
        }

        [Fact]
        public async Task RevokeOAuth2TokenForApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.RevokeOAuth2TokenForApplicationAsync(null, TestTokenId));
        }

        [Fact]
        public async Task RevokeOAuth2TokenForApplication_WithNullTokenId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.RevokeOAuth2TokenForApplicationAsync(TestAppId, null));
        }

        [Fact]
        public async Task RevokeOAuth2TokenForApplicationWithHttpInfo_ReturnsHttpResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" }
            };
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent, headers);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.RevokeOAuth2TokenForApplicationWithHttpInfoAsync(TestAppId, TestTokenId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("Content-Type");
        }

        [Fact]
        public async Task RevokeOAuth2TokenForApplicationWithHttpInfo_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.RevokeOAuth2TokenForApplicationWithHttpInfoAsync(null, TestTokenId));
        }

        [Fact]
        public async Task RevokeOAuth2TokenForApplicationWithHttpInfo_WithNullTokenId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.RevokeOAuth2TokenForApplicationWithHttpInfoAsync(TestAppId, null));
        }

        #endregion

        #region RevokeOAuth2TokensForApplication Tests

        [Fact]
        public async Task RevokeOAuth2TokensForApplication_WithValidAppId_CompletesSuccessfully()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.RevokeOAuth2TokensForApplicationAsync(TestAppId);

            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("tokens");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
        }

        [Fact]
        public async Task RevokeOAuth2TokensForApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.RevokeOAuth2TokensForApplicationAsync(null));
        }

        [Fact]
        public async Task RevokeOAuth2TokensForApplicationWithHttpInfo_ReturnsHttpResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Rate-Limit-Remaining", "100" }
            };
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent, headers);
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.RevokeOAuth2TokensForApplicationWithHttpInfoAsync(TestAppId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("Content-Type");
            result.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
        }

        [Fact]
        public async Task RevokeOAuth2TokensForApplicationWithHttpInfo_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationTokensApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.RevokeOAuth2TokensForApplicationWithHttpInfoAsync(null));
        }

        #endregion
    }
}
