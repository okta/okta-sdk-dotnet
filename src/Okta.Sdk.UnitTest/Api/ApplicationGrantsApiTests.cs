// <copyright file="ApplicationGrantsApiTests.cs" company="Okta, Inc">
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
    public class ApplicationGrantsApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestAppId = "0oa1gjh63g214q0Hq0g4";
        private const string TestGrantId = "oag1gjh63g214q0Hq0g5";

        #region GrantConsentToScope Tests

        [Fact]
        public async Task GrantConsentToScope_WithValidRequest_ReturnsGrant()
        {
            var responseJson = @"{
                ""id"": ""oag1gjh63g214q0Hq0g5"",
                ""status"": ""ACTIVE"",
                ""created"": ""2023-01-15T12:00:00.000Z"",
                ""createdBy"": {
                    ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                    ""type"": ""User""
                },
                ""lastUpdated"": ""2023-01-15T12:00:00.000Z"",
                ""issuer"": ""https://test.okta.com"",
                ""scopeId"": ""okta.users.read"",
                ""source"": ""ADMIN"",
                ""_links"": {
                    ""app"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4""
                    },
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4/grants/oag1gjh63g214q0Hq0g5""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new OAuth2ScopeConsentGrant
            {
                ScopeId = "okta.users.read",
                Issuer = "https://test.okta.com"
            };

            var result = await api.GrantConsentToScopeAsync(TestAppId, request);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestGrantId);
            result.ScopeId.Should().Be("okta.users.read");
            result.Status.Should().Be(GrantOrTokenStatus.ACTIVE);
            result.Source.Should().Be(OAuth2ScopeConsentGrantSource.ADMIN);
            result.Issuer.Should().Be("https://test.okta.com");
            result.Links.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("grants");
            mockClient.ReceivedBody.Should().Contain("okta.users.read");
        }

        [Fact]
        public async Task GrantConsentToScope_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new OAuth2ScopeConsentGrant { ScopeId = "okta.users.read" };

            await Assert.ThrowsAsync<ApiException>(() => api.GrantConsentToScopeAsync(null, request));
        }

        [Fact]
        public async Task GrantConsentToScope_WithNullRequest_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GrantConsentToScopeAsync(TestAppId, null));
        }

        [Fact]
        public async Task GrantConsentToScopeWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"{
                ""id"": ""oag1gjh63g214q0Hq0g5"",
                ""scopeId"": ""okta.users.read"",
                ""status"": ""ACTIVE""
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" }
            };

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new OAuth2ScopeConsentGrant { ScopeId = "okta.users.read" };

            var response = await api.GrantConsentToScopeWithHttpInfoAsync(TestAppId, request);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestGrantId);
            response.Headers.Should().ContainKey("Content-Type");
        }

        #endregion

        #region GetScopeConsentGrant Tests

        [Fact]
        public async Task GetScopeConsentGrant_WithValidIds_ReturnsGrant()
        {
            var responseJson = @"{
                ""id"": ""oag1gjh63g214q0Hq0g5"",
                ""status"": ""ACTIVE"",
                ""scopeId"": ""okta.users.read"",
                ""issuer"": ""https://test.okta.com"",
                ""source"": ""ADMIN"",
                ""_links"": {
                    ""app"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetScopeConsentGrantAsync(TestAppId, TestGrantId);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestGrantId);
            result.ScopeId.Should().Be("okta.users.read");
            result.Status.Should().Be(GrantOrTokenStatus.ACTIVE);
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("grants");
        }

        [Fact]
        public async Task GetScopeConsentGrant_WithExpandParameter_IncludesExpandInPath()
        {
            var responseJson = @"{
                ""id"": ""oag1gjh63g214q0Hq0g5"",
                ""scopeId"": ""okta.users.read"",
                ""_embedded"": {
                    ""scope"": {
                        ""id"": ""okta.users.read"",
                        ""name"": ""Users Read""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetScopeConsentGrantAsync(TestAppId, TestGrantId, expand: "scope");

            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("scope");
        }

        [Fact]
        public async Task GetScopeConsentGrant_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetScopeConsentGrantAsync(null, TestGrantId));
        }

        [Fact]
        public async Task GetScopeConsentGrant_WithNullGrantId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetScopeConsentGrantAsync(TestAppId, null));
        }

        [Fact]
        public async Task GetScopeConsentGrantWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"{
                ""id"": ""oag1gjh63g214q0Hq0g5"",
                ""scopeId"": ""okta.users.read""
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" }
            };

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetScopeConsentGrantWithHttpInfoAsync(TestAppId, TestGrantId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestGrantId);
        }

        #endregion

        #region ListScopeConsentGrants Tests

        [Fact]
        public async Task ListScopeConsentGrantsWithHttpInfo_ReturnsGrantList()
        {
            var responseJson = @"[
                {
                    ""id"": ""oag1gjh63g214q0Hq0g5"",
                    ""scopeId"": ""okta.users.read"",
                    ""status"": ""ACTIVE""
                },
                {
                    ""id"": ""oag2gjh63g214q0Hq0g6"",
                    ""scopeId"": ""okta.groups.read"",
                    ""status"": ""ACTIVE""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListScopeConsentGrantsWithHttpInfoAsync(TestAppId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);
            response.Data[0].Id.Should().Be("oag1gjh63g214q0Hq0g5");
            response.Data[1].Id.Should().Be("oag2gjh63g214q0Hq0g6");
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("grants");
        }

        [Fact]
        public async Task ListScopeConsentGrantsWithHttpInfo_WithExpandParameter_IncludesExpandInQuery()
        {
            var responseJson = @"[{""id"": ""oag1gjh63g214q0Hq0g5""}]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.ListScopeConsentGrantsWithHttpInfoAsync(TestAppId, expand: "scope");

            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("scope");
        }

        [Fact]
        public async Task ListScopeConsentGrantsWithHttpInfo_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.ListScopeConsentGrantsWithHttpInfoAsync(null));
        }

        #endregion

        #region RevokeScopeConsentGrant Tests

        [Fact]
        public async Task RevokeScopeConsentGrant_WithValidIds_CompletesSuccessfully()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.RevokeScopeConsentGrantAsync(TestAppId, TestGrantId);

            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("grants");
        }

        [Fact]
        public async Task RevokeScopeConsentGrant_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("");
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.RevokeScopeConsentGrantAsync(null, TestGrantId));
        }

        [Fact]
        public async Task RevokeScopeConsentGrant_WithNullGrantId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("");
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.RevokeScopeConsentGrantAsync(TestAppId, null));
        }

        [Fact]
        public async Task RevokeScopeConsentGrantWithHttpInfo_ReturnsNoContentResponse()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationGrantsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.RevokeScopeConsentGrantWithHttpInfoAsync(TestAppId, TestGrantId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("grants");
        }

        #endregion
    }
}
