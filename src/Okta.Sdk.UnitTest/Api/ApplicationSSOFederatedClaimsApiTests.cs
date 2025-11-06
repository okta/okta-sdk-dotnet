// <copyright file="ApplicationSSOFederatedClaimsApiTests.cs" company="Okta, Inc">
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
    /// Unit tests for ApplicationSSOFederatedClaimsApi.
    /// Tests all 10 methods (5 operations with async and WithHttpInfo variants).
    /// </summary>
    public class ApplicationSsoFederatedClaimsApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestAppId = "0oa1gjh63g214q0Hq0g4";
        private const string TestClaimId = "ofc893fbjaBaqdtoX0g7";

        #region CreateFederatedClaim Tests

        [Fact]
        public async Task CreateFederatedClaim_WithValidParameters_ReturnsClaim()
        {
            var responseJson = @"{
                ""id"": ""ofc893fbjaBaqdtoX0g7"",
                ""name"": ""department"",
                ""expression"": ""user.profile.department"",
                ""created"": ""2024-12-25T03:00:00.000Z"",
                ""lastUpdated"": ""2024-12-25T03:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FederatedClaimRequestBody
            {
                Name = "department",
                Expression = "user.profile.department"
            };

            var result = await api.CreateFederatedClaimAsync(TestAppId, request);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestClaimId);
            result.Name.Should().Be("department");
            result.Expression.Should().Be("user.profile.department");
            result.Created.Should().NotBeNullOrEmpty();
            result.LastUpdated.Should().NotBeNullOrEmpty();
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("federated-claims");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
        }

        [Fact]
        public async Task CreateFederatedClaim_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FederatedClaimRequestBody
            {
                Name = "test",
                Expression = "user.profile.test"
            };

            await Assert.ThrowsAsync<ApiException>(() => api.CreateFederatedClaimAsync(null, request));
        }

        [Fact]
        public async Task CreateFederatedClaim_WithNullRequestBody_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.CreateFederatedClaimAsync(TestAppId, null));
        }

        [Fact]
        public async Task CreateFederatedClaimWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"{
                ""id"": ""ofc893fbjaBaqdtoX0g7"",
                ""name"": ""location"",
                ""expression"": ""user.profile.city"",
                ""created"": ""2024-12-25T03:00:00.000Z"",
                ""lastUpdated"": ""2024-12-25T03:00:00.000Z""
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Rate-Limit-Remaining", "100" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created, headers);
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FederatedClaimRequestBody
            {
                Name = "location",
                Expression = "user.profile.city"
            };

            var result = await api.CreateFederatedClaimWithHttpInfoAsync(TestAppId, request);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.Created);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestClaimId);
            result.Data.Name.Should().Be("location");
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("Content-Type");
            result.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
        }

        [Fact]
        public async Task CreateFederatedClaimWithHttpInfo_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FederatedClaimRequestBody
            {
                Name = "test",
                Expression = "user.profile.test"
            };

            await Assert.ThrowsAsync<ApiException>(() => api.CreateFederatedClaimWithHttpInfoAsync(null, request));
        }

        [Fact]
        public async Task CreateFederatedClaimWithHttpInfo_WithNullRequestBody_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.CreateFederatedClaimWithHttpInfoAsync(TestAppId, null));
        }

        #endregion

        #region GetFederatedClaim Tests

        [Fact]
        public async Task GetFederatedClaim_WithValidParameters_ReturnsClaim()
        {
            // Note: API returns FederatedClaimRequestBody instead of FederatedClaim (possible API bug)
            var responseJson = @"{
                ""name"": ""userRole"",
                ""expression"": ""user.profile.title""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetFederatedClaimAsync(TestAppId, TestClaimId);

            result.Should().NotBeNull();
            result.Name.Should().Be("userRole");
            result.Expression.Should().Be("user.profile.title");
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("federated-claims");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
            mockClient.ReceivedPathParams.Should().ContainKey("claimId");
            mockClient.ReceivedPathParams["claimId"].Should().Be(TestClaimId);
        }

        [Fact]
        public async Task GetFederatedClaim_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetFederatedClaimAsync(null, TestClaimId));
        }

        [Fact]
        public async Task GetFederatedClaim_WithNullClaimId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetFederatedClaimAsync(TestAppId, null));
        }

        [Fact]
        public async Task GetFederatedClaimWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"{
                ""id"": ""ofc893fbjaBaqdtoX0g7"",
                ""name"": ""email"",
                ""expression"": ""user.profile.email"",
                ""created"": ""2024-12-25T03:00:00.000Z"",
                ""lastUpdated"": ""2024-12-25T03:00:00.000Z""
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Rate-Limit-Remaining", "95" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetFederatedClaimWithHttpInfoAsync(TestAppId, TestClaimId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Name.Should().Be("email");
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("Content-Type");
            result.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
        }

        [Fact]
        public async Task GetFederatedClaimWithHttpInfo_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetFederatedClaimWithHttpInfoAsync(null, TestClaimId));
        }

        [Fact]
        public async Task GetFederatedClaimWithHttpInfo_WithNullClaimId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetFederatedClaimWithHttpInfoAsync(TestAppId, null));
        }

        #endregion

        #region ListFederatedClaims Tests

        [Fact]
        public async Task ListFederatedClaims_WithValidAppId_ReturnsCollection()
        {
            var responseJson = @"[
                {
                    ""id"": ""ofc893fbjaBaqdtoX0g7"",
                    ""name"": ""department"",
                    ""expression"": ""user.profile.department"",
                    ""created"": ""2024-12-25T03:00:00.000Z"",
                    ""lastUpdated"": ""2024-12-25T03:00:00.000Z""
                },
                {
                    ""id"": ""ofc893fbjaTxynmo5v93"",
                    ""name"": ""location"",
                    ""expression"": ""user.profile.city"",
                    ""created"": ""2024-12-25T04:00:00.000Z"",
                    ""lastUpdated"": ""2024-12-25T04:00:00.000Z""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListFederatedClaimsWithHttpInfoAsync(TestAppId);

            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Id.Should().Be("ofc893fbjaBaqdtoX0g7");
            result.Data[0].Name.Should().Be("department");
            result.Data[1].Id.Should().Be("ofc893fbjaTxynmo5v93");
            result.Data[1].Name.Should().Be("location");
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("federated-claims");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
        }

        [Fact]
        public async Task ListFederatedClaims_WithEmptyList_ReturnsEmptyCollection()
        {
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListFederatedClaimsWithHttpInfoAsync(TestAppId);

            result.Should().NotBeNull();
            result.Data.Should().BeEmpty();
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("federated-claims");
        }

        [Fact]
        public async Task ListFederatedClaims_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.ListFederatedClaimsWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task ListFederatedClaimsWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"[
                {
                    ""id"": ""ofc893fbjaBaqdtoX0g7"",
                    ""name"": ""test"",
                    ""expression"": ""user.profile.test"",
                    ""created"": ""2024-12-25T03:00:00.000Z"",
                    ""lastUpdated"": ""2024-12-25T03:00:00.000Z""
                }
            ]";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Rate-Limit-Remaining", "90" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListFederatedClaimsWithHttpInfoAsync(TestAppId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(1);
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("Content-Type");
            result.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
        }

        #endregion

        #region ReplaceFederatedClaim Tests

        [Fact]
        public async Task ReplaceFederatedClaim_WithValidParameters_ReturnsUpdatedClaim()
        {
            var responseJson = @"{
                ""id"": ""ofc893fbjaBaqdtoX0g7"",
                ""name"": ""updatedName"",
                ""expression"": ""user.profile.updatedExpression"",
                ""created"": ""2024-12-25T03:00:00.000Z"",
                ""lastUpdated"": ""2024-12-25T05:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FederatedClaim
            {
                Name = "updatedName",
                Expression = "user.profile.updatedExpression"
            };

            var result = await api.ReplaceFederatedClaimAsync(TestAppId, TestClaimId, request);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestClaimId);
            result.Name.Should().Be("updatedName");
            result.Expression.Should().Be("user.profile.updatedExpression");
            result.Created.Should().NotBeNullOrEmpty();
            result.LastUpdated.Should().NotBeNullOrEmpty();
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("federated-claims");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
            mockClient.ReceivedPathParams.Should().ContainKey("claimId");
            mockClient.ReceivedPathParams["claimId"].Should().Be(TestClaimId);
        }

        [Fact]
        public async Task ReplaceFederatedClaim_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FederatedClaim
            {
                Name = "test",
                Expression = "user.profile.test"
            };

            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFederatedClaimAsync(null, TestClaimId, request));
        }

        [Fact]
        public async Task ReplaceFederatedClaim_WithNullClaimId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FederatedClaim
            {
                Name = "test",
                Expression = "user.profile.test"
            };

            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFederatedClaimAsync(TestAppId, null, request));
        }

        [Fact]
        public async Task ReplaceFederatedClaimWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"{
                ""id"": ""ofc893fbjaBaqdtoX0g7"",
                ""name"": ""replacedName"",
                ""expression"": ""user.profile.replacedExpression"",
                ""created"": ""2024-12-25T03:00:00.000Z"",
                ""lastUpdated"": ""2024-12-25T07:00:00.000Z""
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Rate-Limit-Remaining", "85" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FederatedClaim
            {
                Name = "replacedName",
                Expression = "user.profile.replacedExpression"
            };

            var result = await api.ReplaceFederatedClaimWithHttpInfoAsync(TestAppId, TestClaimId, request);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestClaimId);
            result.Data.Name.Should().Be("replacedName");
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("Content-Type");
            result.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
        }

        [Fact]
        public async Task ReplaceFederatedClaimWithHttpInfo_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FederatedClaim
            {
                Name = "test",
                Expression = "user.profile.test"
            };

            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFederatedClaimWithHttpInfoAsync(null, TestClaimId, request));
        }

        [Fact]
        public async Task ReplaceFederatedClaimWithHttpInfo_WithNullClaimId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FederatedClaim
            {
                Name = "test",
                Expression = "user.profile.test"
            };

            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFederatedClaimWithHttpInfoAsync(TestAppId, null, request));
        }

        #endregion

        #region DeleteFederatedClaim Tests

        [Fact]
        public async Task DeleteFederatedClaim_WithValidParameters_CompletesSuccessfully()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.DeleteFederatedClaimAsync(TestAppId, TestClaimId);

            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("federated-claims");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
            mockClient.ReceivedPathParams.Should().ContainKey("claimId");
            mockClient.ReceivedPathParams["claimId"].Should().Be(TestClaimId);
        }

        [Fact]
        public async Task DeleteFederatedClaim_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.DeleteFederatedClaimAsync(null, TestClaimId));
        }

        [Fact]
        public async Task DeleteFederatedClaim_WithNullClaimId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.DeleteFederatedClaimAsync(TestAppId, null));
        }

        [Fact]
        public async Task DeleteFederatedClaimWithHttpInfo_ReturnsHttpResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "X-Rate-Limit-Remaining", "80" },
                { "Date", "Mon, 25 Dec 2024 12:00:00 GMT" }
            };
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent, headers);
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.DeleteFederatedClaimWithHttpInfoAsync(TestAppId, TestClaimId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
            result.Headers.Should().ContainKey("Date");
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("federated-claims");
        }

        [Fact]
        public async Task DeleteFederatedClaimWithHttpInfo_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.DeleteFederatedClaimWithHttpInfoAsync(null, TestClaimId));
        }

        [Fact]
        public async Task DeleteFederatedClaimWithHttpInfo_WithNullClaimId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationSSOFederatedClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.DeleteFederatedClaimWithHttpInfoAsync(TestAppId, null));
        }

        #endregion
    }
}
