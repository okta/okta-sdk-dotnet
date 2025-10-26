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
    /// Unit tests for ApplicationApi
    /// Tests all CRUD operations, lifecycle management, and HTTP variants
    /// </summary>
    public class ApplicationApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _appId = "0oa1gjh63g214q0Hq0g4";
        private readonly string _userId = "00u5t60iloOHN9pBi0h7";

        #region CreateApplication Tests

        [Fact]
        public async Task CreateApplication_WithBookmarkApp_ReturnsApplication()
        {
            // Arrange
            var responseJson = GetBookmarkAppResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var app = new BookmarkApplication
            {
                Name = "bookmark",
                Label = "Test Bookmark App",
                SignOnMode = "BOOKMARK",
                Settings = new BookmarkApplicationSettings
                {
                    App = new BookmarkApplicationSettingsApplication
                    {
                        Url = "https://example.com/bookmark.html",
                        RequestIntegration = false
                    }
                }
            };

            // Act
            var createdApp = await appApi.CreateApplicationAsync(app);

            // Assert
            createdApp.Should().NotBeNull();
            createdApp.Id.Should().Be(_appId);
            createdApp.Label.Should().Be("Test Bookmark App");
            createdApp.Status.Should().Be(ApplicationLifecycleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps");
            mockClient.ReceivedBody.Should().Contain("bookmark");
            mockClient.ReceivedBody.Should().Contain("Test Bookmark App");
        }

        [Fact]
        public async Task CreateApplicationWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = GetBookmarkAppResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var app = new BookmarkApplication
            {
                Name = "bookmark",
                Label = "Test Bookmark App",
                SignOnMode = "BOOKMARK"
            };

            // Act
            var response = await appApi.CreateApplicationWithHttpInfoAsync(app);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_appId);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps");
        }

        [Fact]
        public async Task CreateApplication_WithActivateFalse_CreatesInactiveApp()
        {
            // Arrange
            var responseJson = GetInactiveAppResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var app = new BookmarkApplication
            {
                Name = "bookmark",
                Label = "Inactive App",
                SignOnMode = "BOOKMARK"
            };

            // Act
            var createdApp = await appApi.CreateApplicationAsync(app, activate: false);

            // Assert
            createdApp.Should().NotBeNull();
            createdApp.Status.Should().Be(ApplicationLifecycleStatus.INACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps");
            mockClient.ReceivedQueryParams.Should().ContainKey("activate");
            mockClient.ReceivedQueryParams["activate"].Should().Contain("false");
        }

        [Fact]
        public async Task CreateApplication_WithOIDCApp_ReturnsOIDCApplication()
        {
            // Arrange
            var responseJson = GetOidcAppResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = "Test OIDC App",
                SignOnMode = "OPENID_CONNECT",
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        ClientUri = "https://example.com/client",
                        RedirectUris = ["https://example.com/callback"],
                        ResponseTypes = [OAuthResponseType.Code],
                        GrantTypes = [GrantType.AuthorizationCode],
                        ApplicationType = OpenIdConnectApplicationType.Web
                    }
                }
            };

            // Act
            var createdApp = await appApi.CreateApplicationAsync(app);

            // Assert
            createdApp.Should().NotBeNull();
            createdApp.SignOnMode.Should().Be(ApplicationSignOnMode.OPENIDCONNECT);

            mockClient.ReceivedBody.Should().Contain("oidc_client");
        }

        #endregion

        #region GetApplication Tests

        [Fact]
        public async Task GetApplication_WithValidId_ReturnsApplication()
        {
            // Arrange
            var responseJson = GetBookmarkAppResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var app = await appApi.GetApplicationAsync(_appId);

            // Assert
            app.Should().NotBeNull();
            app.Id.Should().Be(_appId);
            app.Label.Should().Be("Test Bookmark App");

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task GetApplicationWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = GetBookmarkAppResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await appApi.GetApplicationWithHttpInfoAsync(_appId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_appId);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task GetApplication_WithExpandParameter_IncludesExpandInQuery()
        {
            // Arrange
            var responseJson = GetBookmarkAppResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var app = await appApi.GetApplicationAsync(_appId, expand: $"user/{_userId}");

            // Assert
            app.Should().NotBeNull();

            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain($"user/{_userId}");
        }

        #endregion

        #region ReplaceApplication Tests

        [Fact]
        public async Task ReplaceApplication_WithUpdatedApp_ReturnsUpdatedApplication()
        {
            // Arrange
            var responseJson = GetUpdatedBookmarkAppResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var app = new BookmarkApplication
            {
                Name = "bookmark",
                Label = "Updated Bookmark App",
                SignOnMode = "BOOKMARK",
                Settings = new BookmarkApplicationSettings
                {
                    App = new BookmarkApplicationSettingsApplication
                    {
                        Url = "https://example.com/updated.html",
                        RequestIntegration = true
                    }
                }
            };

            // Act
            var updatedApp = await appApi.ReplaceApplicationAsync(_appId, app);

            // Assert
            updatedApp.Should().NotBeNull();
            updatedApp.Id.Should().Be(_appId);
            updatedApp.Label.Should().Be("Updated Bookmark App");

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
            mockClient.ReceivedBody.Should().Contain("Updated Bookmark App");
        }

        [Fact]
        public async Task ReplaceApplicationWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = GetUpdatedBookmarkAppResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var app = new BookmarkApplication
            {
                Name = "bookmark",
                Label = "Updated App",
                SignOnMode = "BOOKMARK"
            };

            // Act
            var response = await appApi.ReplaceApplicationWithHttpInfoAsync(_appId, app);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Label.Should().Be("Updated Bookmark App");

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        #endregion

        #region DeleteApplication Tests

        [Fact]
        public async Task DeleteApplication_WithValidId_DeletesSuccessfully()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await appApi.DeleteApplicationAsync(_appId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task DeleteApplicationWithHttpInfo_ReturnsNoContentResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await appApi.DeleteApplicationWithHttpInfoAsync(_appId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        #endregion

        #region ActivateApplication Tests

        [Fact]
        public async Task ActivateApplication_WithValidId_ActivatesSuccessfully()
        {
            // Arrange
            var mockClient = new MockAsyncClient("");
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await appApi.ActivateApplicationAsync(_appId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/lifecycle/activate");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task ActivateApplicationWithHttpInfo_ReturnsOkResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient("");
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await appApi.ActivateApplicationWithHttpInfoAsync(_appId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/lifecycle/activate");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        #endregion

        #region DeactivateApplication Tests

        [Fact]
        public async Task DeactivateApplication_WithValidId_DeactivatesSuccessfully()
        {
            // Arrange
            var mockClient = new MockAsyncClient("");
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await appApi.DeactivateApplicationAsync(_appId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        [Fact]
        public async Task DeactivateApplicationWithHttpInfo_ReturnsOkResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient("");
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await appApi.DeactivateApplicationWithHttpInfoAsync(_appId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/apps/{appId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Contain(_appId);
        }

        #endregion

        #region ListApplications Tests

        [Fact]
        public async Task ListApplicationsWithHttpInfo_ReturnsApplicationList()
        {
            // Arrange
            var responseJson = GetApplicationListResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await appApi.ListApplicationsWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);
            response.Data.First().Id.Should().Be(_appId);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps");
        }

        [Fact]
        public async Task ListApplicationsWithHttpInfo_WithQueryParameter_IncludesQueryInRequest()
        {
            // Arrange
            var responseJson = GetApplicationListResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await appApi.ListApplicationsWithHttpInfoAsync(q: "Test");

            // Assert
            response.Should().NotBeNull();

            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams["q"].Should().Contain("Test");
        }

        [Fact]
        public async Task ListApplicationsWithHttpInfo_WithFilter_IncludesFilterInRequest()
        {
            // Arrange
            var responseJson = GetApplicationListResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await appApi.ListApplicationsWithHttpInfoAsync(filter: "status eq \"ACTIVE\"");

            // Assert
            response.Should().NotBeNull();

            mockClient.ReceivedQueryParams.Should().ContainKey("filter");
            mockClient.ReceivedQueryParams["filter"].Should().Contain("status eq \"ACTIVE\"");
        }

        [Fact]
        public async Task ListApplicationsWithHttpInfo_WithLimit_IncludesLimitInRequest()
        {
            // Arrange
            var responseJson = GetApplicationListResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await appApi.ListApplicationsWithHttpInfoAsync(limit: 10);

            // Assert
            response.Should().NotBeNull();

            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("10");
        }

        [Fact]
        public async Task ListApplicationsWithHttpInfo_WithAfter_IncludesAfterInRequest()
        {
            // Arrange
            var responseJson = GetApplicationListResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await appApi.ListApplicationsWithHttpInfoAsync(after: "cursor123");

            // Assert
            response.Should().NotBeNull();

            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor123");
        }

        [Fact]
        public async Task ListApplicationsWithHttpInfo_WithUseOptimization_IncludesOptimizationInRequest()
        {
            // Arrange
            var responseJson = GetApplicationListResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await appApi.ListApplicationsWithHttpInfoAsync(useOptimization: true);

            // Assert
            response.Should().NotBeNull();

            mockClient.ReceivedQueryParams.Should().ContainKey("useOptimization");
            mockClient.ReceivedQueryParams["useOptimization"].Should().Contain("true");
        }

        [Fact]
        public async Task ListApplicationsWithHttpInfo_WithIncludeNonDeleted_IncludesParameterInRequest()
        {
            // Arrange
            var responseJson = GetApplicationListResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await appApi.ListApplicationsWithHttpInfoAsync(includeNonDeleted: true);

            // Assert
            response.Should().NotBeNull();

            mockClient.ReceivedQueryParams.Should().ContainKey("includeNonDeleted");
            mockClient.ReceivedQueryParams["includeNonDeleted"].Should().Contain("true");
        }

        [Fact]
        public async Task ListApplicationsWithHttpInfo_WithExpandParameter_IncludesExpandInRequest()
        {
            // Arrange
            var responseJson = GetApplicationListResponseJson();
            var mockClient = new MockAsyncClient(responseJson);
            var appApi = new ApplicationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await appApi.ListApplicationsWithHttpInfoAsync(expand: $"user/{_userId}");

            // Assert
            response.Should().NotBeNull();

            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain($"user/{_userId}");
        }

        #endregion

        #region Helper Methods - Response JSON

        private string GetBookmarkAppResponseJson()
        {
            return $@"{{
                ""id"": ""{_appId}"",
                ""name"": ""bookmark"",
                ""label"": ""Test Bookmark App"",
                ""status"": ""ACTIVE"",
                ""lastUpdated"": ""2025-10-26T10:00:00.000Z"",
                ""created"": ""2025-10-26T10:00:00.000Z"",
                ""accessibility"": {{
                    ""selfService"": false,
                    ""errorRedirectUrl"": null,
                    ""loginRedirectUrl"": null
                }},
                ""visibility"": {{
                    ""autoSubmitToolbar"": false,
                    ""hide"": {{
                        ""iOS"": false,
                        ""web"": false
                    }},
                    ""appLinks"": {{
                        ""login"": true
                    }}
                }},
                ""features"": [],
                ""signOnMode"": ""BOOKMARK"",
                ""credentials"": {{
                    ""userNameTemplate"": {{
                        ""template"": ""${{source.email}}"",
                        ""type"": ""BUILT_IN""
                    }},
                    ""signing"": {{}}
                }},
                ""settings"": {{
                    ""app"": {{
                        ""requestIntegration"": false,
                        ""url"": ""https://example.com/bookmark.html""
                    }},
                    ""notifications"": {{
                        ""vpn"": {{
                            ""network"": {{
                                ""connection"": ""DISABLED""
                            }},
                            ""message"": null,
                            ""helpUrl"": null
                        }}
                    }}
                }},
                ""_links"": {{
                    ""self"": {{
                        ""href"": ""{BaseUrl}/api/v1/apps/{_appId}""
                    }}
                }}
            }}";
        }

        private string GetInactiveAppResponseJson()
        {
            return $@"{{
                ""id"": ""{_appId}"",
                ""name"": ""bookmark"",
                ""label"": ""Inactive App"",
                ""status"": ""INACTIVE"",
                ""lastUpdated"": ""2025-10-26T10:00:00.000Z"",
                ""created"": ""2025-10-26T10:00:00.000Z"",
                ""signOnMode"": ""BOOKMARK"",
                ""settings"": {{
                    ""app"": {{}}
                }}
            }}";
        }

        private string GetUpdatedBookmarkAppResponseJson()
        {
            return $@"{{
                ""id"": ""{_appId}"",
                ""name"": ""bookmark"",
                ""label"": ""Updated Bookmark App"",
                ""status"": ""ACTIVE"",
                ""lastUpdated"": ""2025-10-26T11:00:00.000Z"",
                ""created"": ""2025-10-26T10:00:00.000Z"",
                ""signOnMode"": ""BOOKMARK"",
                ""settings"": {{
                    ""app"": {{
                        ""requestIntegration"": true,
                        ""url"": ""https://example.com/updated.html""
                    }}
                }}
            }}";
        }

        private string GetOidcAppResponseJson()
        {
            return $@"{{
                ""id"": ""{_appId}"",
                ""name"": ""oidc_client"",
                ""label"": ""Test OIDC App"",
                ""status"": ""ACTIVE"",
                ""lastUpdated"": ""2025-10-26T10:00:00.000Z"",
                ""created"": ""2025-10-26T10:00:00.000Z"",
                ""signOnMode"": ""OPENID_CONNECT"",
                ""credentials"": {{
                    ""oauthClient"": {{
                        ""client_id"": ""0odbc123"",
                        ""token_endpoint_auth_method"": ""client_secret_post"",
                        ""autoKeyRotation"": true
                    }}
                }},
                ""settings"": {{
                    ""oauthClient"": {{
                        ""client_uri"": ""https://example.com/client"",
                        ""redirect_uris"": [""https://example.com/callback""],
                        ""response_types"": [""code""],
                        ""grant_types"": [""authorization_code""],
                        ""application_type"": ""web""
                    }}
                }}
            }}";
        }

        private string GetApplicationListResponseJson()
        {
            return $@"[
                {{
                    ""id"": ""{_appId}"",
                    ""name"": ""bookmark"",
                    ""label"": ""Test Bookmark App"",
                    ""status"": ""ACTIVE"",
                    ""signOnMode"": ""BOOKMARK""
                }},
                {{
                    ""id"": ""0oa2abc456"",
                    ""name"": ""template_basic_auth"",
                    ""label"": ""Test Basic Auth App"",
                    ""status"": ""ACTIVE"",
                    ""signOnMode"": ""BASIC_AUTH""
                }}
            ]";
        }

        #endregion
    }
}
