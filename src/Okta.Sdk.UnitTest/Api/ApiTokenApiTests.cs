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
    /// Unit tests for ApiTokenApi covering all 10 methods (5 operations with async and WithHttpInfo variants).
    /// Tests cover: GetApiToken, ListApiTokens, RevokeApiToken, RevokeCurrentApiToken, UpsertApiToken
    /// </summary>
    public class ApiTokenApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestTokenId = "00Tck1l40BgsBbRf40g7";
        private const string TestUserId = "00u1gjh63g214q0Hq0g4";

        #region GetApiTokenAsync Tests

        [Fact]
        public async Task GetApiTokenAsync_WithValidId_ReturnsToken()
        {
            var responseJson = @"{
                ""id"": ""00Tck1l40BgsBbRf40g7"",
                ""name"": ""Test API Token"",
                ""tokenWindow"": ""P30D"",
                ""userId"": ""00u1gjh63g214q0Hq0g4"",
                ""clientName"": ""GitHub Copilot"",
                ""created"": ""2025-01-15T10:00:00.000Z"",
                ""expiresAt"": ""2025-02-14T10:00:00.000Z"",
                ""lastUpdated"": ""2025-01-15T10:00:00.000Z"",
                ""link"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/api-tokens/00Tck1l40BgsBbRf40g7""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetApiTokenAsync(TestTokenId);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestTokenId);
            result.Name.Should().Be("Test API Token");
            result.TokenWindow.Should().Be("P30D");
            result.UserId.Should().Be(TestUserId);
            result.ClientName.Should().Be("GitHub Copilot");
            mockClient.ReceivedPath.Should().Contain("/api/v1/api-tokens/");
            mockClient.ReceivedPathParams.Should().ContainKey("apiTokenId");
            mockClient.ReceivedPathParams["apiTokenId"].Should().Be(TestTokenId);
        }

        [Fact]
        public async Task GetApiTokenWithHttpInfoAsync_WithValidId_ReturnsApiResponse()
        {
            var responseJson = @"{
                ""id"": ""00Tck1l40BgsBbRf40g7"",
                ""name"": ""Test API Token"",
                ""tokenWindow"": ""P30D"",
                ""userId"": ""00u1gjh63g214q0Hq0g4"",
                ""clientName"": ""VS Code"",
                ""created"": ""2025-01-15T10:00:00.000Z"",
                ""link"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/api-tokens/00Tck1l40BgsBbRf40g7""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetApiTokenWithHttpInfoAsync(TestTokenId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestTokenId);
            response.Data.Name.Should().Be("Test API Token");
            response.Data.ClientName.Should().Be("VS Code");
            mockClient.ReceivedPath.Should().Contain("/api/v1/api-tokens/");
            mockClient.ReceivedPathParams.Should().ContainKey("apiTokenId");
            mockClient.ReceivedPathParams["apiTokenId"].Should().Be(TestTokenId);
        }

        #endregion

        #region ListApiTokensAsync Tests

        [Fact]
        public async Task ListApiTokensWithHttpInfoAsync_ReturnsTokenList()
        {
            var responseJson = @"[
                {
                    ""id"": ""00Tck1l40BgsBbRf40g7"",
                    ""name"": ""API Token 1"",
                    ""tokenWindow"": ""P30D"",
                    ""userId"": ""00u1gjh63g214q0Hq0g4"",
                    ""clientName"": ""GitHub Copilot"",
                    ""created"": ""2025-01-15T10:00:00.000Z"",
                    ""link"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/api-tokens/00Tck1l40BgsBbRf40g7""
                        }
                    }
                },
                {
                    ""id"": ""00Tck1l40BgsBbRf40g8"",
                    ""name"": ""API Token 2"",
                    ""tokenWindow"": ""P60D"",
                    ""userId"": ""00u1gjh63g214q0Hq0g4"",
                    ""clientName"": ""Postman"",
                    ""created"": ""2025-01-10T10:00:00.000Z"",
                    ""link"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/api-tokens/00Tck1l40BgsBbRf40g8""
                        }
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListApiTokensWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);
            
            var firstToken = response.Data[0];
            firstToken.Id.Should().Be("00Tck1l40BgsBbRf40g7");
            firstToken.Name.Should().Be("API Token 1");
            firstToken.TokenWindow.Should().Be("P30D");
            firstToken.ClientName.Should().Be("GitHub Copilot");

            var secondToken = response.Data[1];
            secondToken.Id.Should().Be("00Tck1l40BgsBbRf40g8");
            secondToken.Name.Should().Be("API Token 2");
            secondToken.TokenWindow.Should().Be("P60D");
            secondToken.ClientName.Should().Be("Postman");

            mockClient.ReceivedPath.Should().Contain("/api/v1/api-tokens");
        }

        #endregion

        #region RevokeApiTokenAsync Tests

        [Fact]
        public async Task RevokeApiTokenAsync_WithValidId_CompletesSuccessfully()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.RevokeApiTokenAsync(TestTokenId);

            mockClient.ReceivedPath.Should().Contain("/api/v1/api-tokens/");
            mockClient.ReceivedPathParams.Should().ContainKey("apiTokenId");
            mockClient.ReceivedPathParams["apiTokenId"].Should().Be(TestTokenId);
        }

        [Fact]
        public async Task RevokeApiTokenWithHttpInfoAsync_WithValidId_ReturnsNoContentResponse()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.RevokeApiTokenWithHttpInfoAsync(TestTokenId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Contain("/api/v1/api-tokens/");
            mockClient.ReceivedPathParams.Should().ContainKey("apiTokenId");
            mockClient.ReceivedPathParams["apiTokenId"].Should().Be(TestTokenId);
        }

        #endregion

        #region RevokeCurrentApiTokenAsync Tests

        [Fact]
        public async Task RevokeCurrentApiTokenAsync_CompletesSuccessfully()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.RevokeCurrentApiTokenAsync();

            mockClient.ReceivedPath.Should().Contain("/api/v1/api-tokens/current");
        }

        [Fact]
        public async Task RevokeCurrentApiTokenWithHttpInfoAsync_ReturnsNoContentResponse()
        {
            var responseJson = @"";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.RevokeCurrentApiTokenWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Contain("/api/v1/api-tokens/current");
        }

        #endregion

        #region UpsertApiTokenAsync Tests

        [Fact]
        public async Task UpsertApiTokenAsync_WithValidUpdate_ReturnsUpdatedToken()
        {
            var updateRequest = new ApiTokenUpdate
            {
                Network = new ApiTokenNetwork
                {
                    Connection = "ANYWHERE"
                }
            };

            var responseJson = @"{
                ""id"": ""00Tck1l40BgsBbRf40g7"",
                ""name"": ""Updated API Token"",
                ""tokenWindow"": ""P30D"",
                ""userId"": ""00u1gjh63g214q0Hq0g4"",
                ""clientName"": ""GitHub Copilot"",
                ""created"": ""2025-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2025-01-20T10:00:00.000Z"",
                ""link"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/api-tokens/00Tck1l40BgsBbRf40g7""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.UpsertApiTokenAsync(TestTokenId, updateRequest);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestTokenId);
            result.Name.Should().Be("Updated API Token");
            mockClient.ReceivedPath.Should().Contain("/api/v1/api-tokens/");
            mockClient.ReceivedPathParams.Should().ContainKey("apiTokenId");
            mockClient.ReceivedPathParams["apiTokenId"].Should().Be(TestTokenId);
            mockClient.ReceivedBody.Should().Contain("network");
            mockClient.ReceivedBody.Should().Contain("ANYWHERE");
        }

        [Fact]
        public async Task UpsertApiTokenWithHttpInfoAsync_WithValidUpdate_ReturnsApiResponse()
        {
            var updateRequest = new ApiTokenUpdate
            {
                Network = new ApiTokenNetwork
                {
                    Connection = "ZONE",
                    Include = ["nzp1qo9hLKJ4nXFhi0g4"]
                }
            };

            var responseJson = @"{
                ""id"": ""00Tck1l40BgsBbRf40g7"",
                ""name"": ""Zone-restricted Token"",
                ""tokenWindow"": ""P30D"",
                ""userId"": ""00u1gjh63g214q0Hq0g4"",
                ""clientName"": ""GitHub Copilot"",
                ""created"": ""2025-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2025-01-20T10:00:00.000Z"",
                ""link"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/api-tokens/00Tck1l40BgsBbRf40g7""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.UpsertApiTokenWithHttpInfoAsync(TestTokenId, updateRequest);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestTokenId);
            response.Data.Name.Should().Be("Zone-restricted Token");
            mockClient.ReceivedPath.Should().Contain("/api/v1/api-tokens/");
            mockClient.ReceivedPathParams.Should().ContainKey("apiTokenId");
            mockClient.ReceivedPathParams["apiTokenId"].Should().Be(TestTokenId);
            mockClient.ReceivedBody.Should().Contain("network");
            mockClient.ReceivedBody.Should().Contain("ZONE");
        }

        [Fact]
        public async Task UpsertApiTokenAsync_WithNetworkRestrictions_IncludesProperStructure()
        {
            var updateRequest = new ApiTokenUpdate
            {
                Network = new ApiTokenNetwork
                {
                    Connection = "ZONE",
                    Include =
                    [
                        "10.0.0.0/8",
                        "192.168.1.0/24"
                    ],
                    Exclude = ["192.168.1.100/32"]
                }
            };

            var responseJson = @"{
                ""id"": ""00Tck1l40BgsBbRf40g7"",
                ""name"": ""CIDR-restricted Token"",
                ""tokenWindow"": ""P30D"",
                ""userId"": ""00u1gjh63g214q0Hq0g4"",
                ""clientName"": ""GitHub Copilot"",
                ""created"": ""2025-01-15T10:00:00.000Z"",
                ""link"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/api-tokens/00Tck1l40BgsBbRf40g7""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.UpsertApiTokenAsync(TestTokenId, updateRequest);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestTokenId);
            mockClient.ReceivedBody.Should().Contain("include");
            mockClient.ReceivedBody.Should().Contain("exclude");
            mockClient.ReceivedBody.Should().Contain("10.0.0.0/8");
            mockClient.ReceivedBody.Should().Contain("192.168.1.0/24");
            mockClient.ReceivedBody.Should().Contain("192.168.1.100/32");
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task GetApiTokenAsync_WithNotFound_ThrowsApiException()
        {
            var responseJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: 00Tin-valid (ApiToken)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaeXyz123""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NotFound);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await api.GetApiTokenAsync("00Tin-valid");
            });

            exception.Should().NotBeNull();
            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task UpsertApiTokenAsync_WithInvalidData_ThrowsApiException()
        {
            var updateRequest = new ApiTokenUpdate
            {
                Network = new ApiTokenNetwork
                {
                    Connection = "INVALID_VALUE"
                }
            };

            var responseJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed"",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""oaeXyz456""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.BadRequest);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await api.UpsertApiTokenAsync(TestTokenId, updateRequest);
            });

            exception.Should().NotBeNull();
            exception.ErrorCode.Should().Be(400);
        }

        #endregion

        #region Edge Cases

        [Fact]
        public async Task ListApiTokensWithHttpInfoAsync_WithNoTokens_ReturnsEmptyList()
        {
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListApiTokensWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().BeEmpty();
        }

        [Fact]
        public async Task GetApiTokenAsync_WithMinimalData_ReturnsToken()
        {
            var responseJson = @"{
                ""id"": ""00Tck1l40BgsBbRf40g7"",
                ""name"": ""Minimal Token"",
                ""userId"": ""00u1gjh63g214q0Hq0g4"",
                ""clientName"": ""Test Client"",
                ""created"": ""2025-01-15T10:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApiTokenApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetApiTokenAsync(TestTokenId);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestTokenId);
            result.Name.Should().Be("Minimal Token");
            result.UserId.Should().Be(TestUserId);
            result.ClientName.Should().Be("Test Client");
        }

        #endregion
    }
}
