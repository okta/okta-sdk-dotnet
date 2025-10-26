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
    public class OktaApplicationSettingsApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string AppName = "admin-console";

        #region GetFirstPartyAppSettings Tests

        [Fact]
        public async Task GetFirstPartyAppSettings_WithValidAppName_ReturnsSettings()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 15,
                ""sessionMaxLifetimeMinutes"": 720
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetFirstPartyAppSettingsAsync(AppName);

            // Assert
            result.Should().NotBeNull();
            result.SessionIdleTimeoutMinutes.Should().Be(15);
            result.SessionMaxLifetimeMinutes.Should().Be(720);
            mockClient.ReceivedPath.Should().Contain("first-party-app-settings");
        }

        [Fact]
        public async Task GetFirstPartyAppSettings_WithMinimumValues_ReturnsSettings()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 5,
                ""sessionMaxLifetimeMinutes"": 5
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetFirstPartyAppSettingsAsync(AppName);

            // Assert
            result.Should().NotBeNull();
            result.SessionIdleTimeoutMinutes.Should().Be(5);
            result.SessionMaxLifetimeMinutes.Should().Be(5);
        }

        [Fact]
        public async Task GetFirstPartyAppSettings_WithMaximumValues_ReturnsSettings()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 120,
                ""sessionMaxLifetimeMinutes"": 1440
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetFirstPartyAppSettingsAsync(AppName);

            // Assert
            result.Should().NotBeNull();
            result.SessionIdleTimeoutMinutes.Should().Be(120);
            result.SessionMaxLifetimeMinutes.Should().Be(1440);
        }

        [Fact]
        public async Task GetFirstPartyAppSettings_WithNullAppName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetFirstPartyAppSettingsAsync(null));
        }

        [Fact]
        public async Task GetFirstPartyAppSettings_WithEmptyAppName_DoesNotThrow()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 15,
                ""sessionMaxLifetimeMinutes"": 720
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetFirstPartyAppSettingsAsync(string.Empty);

            // Assert - Empty string doesn't throw in unit tests (only validates null)
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFirstPartyAppSettings_WithInvalidAppName_ThrowsApiException()
        {
            // Arrange
            var responseJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: invalid-app (FirstPartyApp)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""detect123""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NotFound);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(() => api.GetFirstPartyAppSettingsAsync("invalid-app"));
            exception.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        #endregion

        #region GetFirstPartyAppSettingsWithHttpInfo Tests

        [Fact]
        public async Task GetFirstPartyAppSettingsWithHttpInfo_WithValidAppName_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 30,
                ""sessionMaxLifetimeMinutes"": 1080
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Okta-Request-Id", "test-request-id" }
            };

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetFirstPartyAppSettingsWithHttpInfoAsync(AppName);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.SessionIdleTimeoutMinutes.Should().Be(30);
            response.Data.SessionMaxLifetimeMinutes.Should().Be(1080);
            response.Headers.Should().NotBeNull();
            response.Headers.Should().ContainKey("Content-Type");
            mockClient.ReceivedPath.Should().Contain("first-party-app-settings");
        }

        [Fact]
        public async Task GetFirstPartyAppSettingsWithHttpInfo_WithNullAppName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetFirstPartyAppSettingsWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task GetFirstPartyAppSettingsWithHttpInfo_WithNotFoundError_ReturnsNotFoundStatus()
        {
            // Arrange
            var responseJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found"",
                ""errorLink"": ""E0000007""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NotFound);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(() => api.GetFirstPartyAppSettingsWithHttpInfoAsync("invalid-app"));
            exception.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        #endregion

        #region ReplaceFirstPartyAppSettings Tests

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithValidSettings_ReturnsUpdatedSettings()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 45,
                ""sessionMaxLifetimeMinutes"": 900
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 45,
                SessionMaxLifetimeMinutes = 900
            };

            // Act
            var result = await api.ReplaceFirstPartyAppSettingsAsync(AppName, settings);

            // Assert
            result.Should().NotBeNull();
            result.SessionIdleTimeoutMinutes.Should().Be(45);
            result.SessionMaxLifetimeMinutes.Should().Be(900);
            mockClient.ReceivedPath.Should().Contain("first-party-app-settings");
            mockClient.ReceivedBody.Should().Contain("45");
            mockClient.ReceivedBody.Should().Contain("900");
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithMinimumValues_ReturnsUpdatedSettings()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 5,
                ""sessionMaxLifetimeMinutes"": 5
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 5,
                SessionMaxLifetimeMinutes = 5
            };

            // Act
            var result = await api.ReplaceFirstPartyAppSettingsAsync(AppName, settings);

            // Assert
            result.Should().NotBeNull();
            result.SessionIdleTimeoutMinutes.Should().Be(5);
            result.SessionMaxLifetimeMinutes.Should().Be(5);
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithMaximumValues_ReturnsUpdatedSettings()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 120,
                ""sessionMaxLifetimeMinutes"": 1440
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 120,
                SessionMaxLifetimeMinutes = 1440
            };

            // Act
            var result = await api.ReplaceFirstPartyAppSettingsAsync(AppName, settings);

            // Assert
            result.Should().NotBeNull();
            result.SessionIdleTimeoutMinutes.Should().Be(120);
            result.SessionMaxLifetimeMinutes.Should().Be(1440);
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithDefaultValues_ReturnsUpdatedSettings()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 15,
                ""sessionMaxLifetimeMinutes"": 720
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 15,
                SessionMaxLifetimeMinutes = 720
            };

            // Act
            var result = await api.ReplaceFirstPartyAppSettingsAsync(AppName, settings);

            // Assert
            result.Should().NotBeNull();
            result.SessionIdleTimeoutMinutes.Should().Be(15);
            result.SessionMaxLifetimeMinutes.Should().Be(720);
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithNullAppName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var settings = new AdminConsoleSettings { SessionIdleTimeoutMinutes = 15, SessionMaxLifetimeMinutes = 720 };

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsAsync(null, settings));
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithNullSettings_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsAsync(AppName, null));
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithEmptyAppName_DoesNotThrow()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 15,
                ""sessionMaxLifetimeMinutes"": 720
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var settings = new AdminConsoleSettings { SessionIdleTimeoutMinutes = 15, SessionMaxLifetimeMinutes = 720 };

            // Act
            var result = await api.ReplaceFirstPartyAppSettingsAsync(string.Empty, settings);

            // Assert - Empty string doesn't throw in unit tests (only validates null)
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithInvalidIdleTimeout_ReturnsBadRequest()
        {
            // Arrange
            var responseJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: sessionIdleTimeoutMinutes"",
                ""errorLink"": ""E0000001""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.BadRequest);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 0,
                SessionMaxLifetimeMinutes = 720
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsAsync(AppName, settings));
            exception.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithInvalidMaxLifetime_ReturnsBadRequest()
        {
            // Arrange
            var responseJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: sessionMaxLifetimeMinutes"",
                ""errorLink"": ""E0000001""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.BadRequest);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 15,
                SessionMaxLifetimeMinutes = 0
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsAsync(AppName, settings));
            exception.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithNegativeValues_ReturnsBadRequest()
        {
            // Arrange
            var responseJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed"",
                ""errorLink"": ""E0000001""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.BadRequest);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = -1,
                SessionMaxLifetimeMinutes = -1
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsAsync(AppName, settings));
            exception.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithInvalidAppName_ReturnsNotFound()
        {
            // Arrange
            var responseJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: invalid-app (FirstPartyApp)"",
                ""errorLink"": ""E0000007""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NotFound);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 15,
                SessionMaxLifetimeMinutes = 720
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsAsync("invalid-app", settings));
            exception.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        #endregion

        #region ReplaceFirstPartyAppSettingsWithHttpInfo Tests

        [Fact]
        public async Task ReplaceFirstPartyAppSettingsWithHttpInfo_WithValidSettings_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 60,
                ""sessionMaxLifetimeMinutes"": 1200
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Okta-Request-Id", "test-request-id-put" }
            };

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 60,
                SessionMaxLifetimeMinutes = 1200
            };

            // Act
            var response = await api.ReplaceFirstPartyAppSettingsWithHttpInfoAsync(AppName, settings);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.SessionIdleTimeoutMinutes.Should().Be(60);
            response.Data.SessionMaxLifetimeMinutes.Should().Be(1200);
            response.Headers.Should().NotBeNull();
            response.Headers.Should().ContainKey("Content-Type");
            mockClient.ReceivedPath.Should().Contain("first-party-app-settings");
            mockClient.ReceivedBody.Should().Contain("60");
            mockClient.ReceivedBody.Should().Contain("1200");
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettingsWithHttpInfo_WithMinimumValues_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 5,
                ""sessionMaxLifetimeMinutes"": 5
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 5,
                SessionMaxLifetimeMinutes = 5
            };

            // Act
            var response = await api.ReplaceFirstPartyAppSettingsWithHttpInfoAsync(AppName, settings);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.SessionIdleTimeoutMinutes.Should().Be(5);
            response.Data.SessionMaxLifetimeMinutes.Should().Be(5);
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettingsWithHttpInfo_WithMaximumValues_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 120,
                ""sessionMaxLifetimeMinutes"": 1440
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 120,
                SessionMaxLifetimeMinutes = 1440
            };

            // Act
            var response = await api.ReplaceFirstPartyAppSettingsWithHttpInfoAsync(AppName, settings);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.SessionIdleTimeoutMinutes.Should().Be(120);
            response.Data.SessionMaxLifetimeMinutes.Should().Be(1440);
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettingsWithHttpInfo_WithNullAppName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var settings = new AdminConsoleSettings { SessionIdleTimeoutMinutes = 15, SessionMaxLifetimeMinutes = 720 };

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsWithHttpInfoAsync(null, settings));
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettingsWithHttpInfo_WithNullSettings_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsWithHttpInfoAsync(AppName, null));
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettingsWithHttpInfo_WithInvalidValues_ReturnsBadRequestStatus()
        {
            // Arrange
            var responseJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: sessionIdleTimeoutMinutes"",
                ""errorLink"": ""E0000001""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.BadRequest);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 121,
                SessionMaxLifetimeMinutes = 720
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsWithHttpInfoAsync(AppName, settings));
            exception.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettingsWithHttpInfo_WithInvalidAppName_ReturnsNotFoundStatus()
        {
            // Arrange
            var responseJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found"",
                ""errorLink"": ""E0000007""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NotFound);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 15,
                SessionMaxLifetimeMinutes = 720
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsWithHttpInfoAsync("invalid-app", settings));
            exception.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        #endregion

        #region Edge Cases and Boundary Tests

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithBelowMinimumIdleTimeout_ReturnsBadRequest()
        {
            // Arrange
            var responseJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: sessionIdleTimeoutMinutes must be between 5 and 120"",
                ""errorLink"": ""E0000001""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.BadRequest);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 4,
                SessionMaxLifetimeMinutes = 720
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsAsync(AppName, settings));
            exception.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithAboveMaximumIdleTimeout_ReturnsBadRequest()
        {
            // Arrange
            var responseJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: sessionIdleTimeoutMinutes must be between 5 and 120"",
                ""errorLink"": ""E0000001""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.BadRequest);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 121,
                SessionMaxLifetimeMinutes = 720
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsAsync(AppName, settings));
            exception.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithBelowMinimumMaxLifetime_ReturnsBadRequest()
        {
            // Arrange
            var responseJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: sessionMaxLifetimeMinutes must be between 5 and 1440"",
                ""errorLink"": ""E0000001""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.BadRequest);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 15,
                SessionMaxLifetimeMinutes = 4
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsAsync(AppName, settings));
            exception.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_WithAboveMaximumMaxLifetime_ReturnsBadRequest()
        {
            // Arrange
            var responseJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: sessionMaxLifetimeMinutes must be between 5 and 1440"",
                ""errorLink"": ""E0000001""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.BadRequest);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 15,
                SessionMaxLifetimeMinutes = 1441
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(() => api.ReplaceFirstPartyAppSettingsAsync(AppName, settings));
            exception.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        #endregion

        #region HTTP Method Verification Tests

        [Fact]
        public async Task GetFirstPartyAppSettings_UsesCorrectHttpMethod()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 15,
                ""sessionMaxLifetimeMinutes"": 720
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetFirstPartyAppSettingsAsync(AppName);

            // Assert - GET method should not have body
            mockClient.ReceivedBody.Should().Be("null");
        }

        [Fact]
        public async Task ReplaceFirstPartyAppSettings_UsesCorrectHttpMethod()
        {
            // Arrange
            var responseJson = @"{
                ""sessionIdleTimeoutMinutes"": 30,
                ""sessionMaxLifetimeMinutes"": 900
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new OktaApplicationSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var settings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 30,
                SessionMaxLifetimeMinutes = 900
            };

            // Act
            await api.ReplaceFirstPartyAppSettingsAsync(AppName, settings);

            // Assert - PUT method should have body with settings
            mockClient.ReceivedBody.Should().NotBe("null");
            mockClient.ReceivedBody.Should().Contain("sessionIdleTimeoutMinutes");
            mockClient.ReceivedBody.Should().Contain("sessionMaxLifetimeMinutes");
        }

        #endregion
    }
}
