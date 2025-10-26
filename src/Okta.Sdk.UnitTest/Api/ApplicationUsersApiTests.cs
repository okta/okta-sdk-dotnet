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
    public class ApplicationUsersApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestAppId = "0oa1gjh63g214q0Hq0g4";
        private const string TestUserId = "00u1gu2fJaO6T8V5Y0g4";

        #region AssignUserToApplication Tests

        [Fact]
        public async Task AssignUserToApplication_WithValidRequest_ReturnsAppUser()
        {
            var responseJson = @"{
                ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                ""externalId"": null,
                ""created"": ""2023-01-15T12:00:00.000Z"",
                ""lastUpdated"": ""2023-01-15T12:00:00.000Z"",
                ""scope"": ""USER"",
                ""status"": ""PROVISIONED"",
                ""statusChanged"": ""2023-01-15T12:00:00.000Z"",
                ""passwordChanged"": null,
                ""syncState"": ""DISABLED"",
                ""credentials"": {
                    ""userName"": ""test@example.com""
                },
                ""profile"": {
                    ""email"": ""test@example.com""
                },
                ""_links"": {
                    ""app"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4""
                    },
                    ""user"": {
                        ""href"": ""https://test.okta.com/api/v1/users/00u1gu2fJaO6T8V5Y0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AppUserAssignRequest { Id = TestUserId };

            var result = await api.AssignUserToApplicationAsync(TestAppId, request);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestUserId);
            result.Scope.Should().Be(AppUser.ScopeEnum.USER);
            result.Status.Should().Be(AppUserStatus.PROVISIONED);
            result.Credentials.Should().NotBeNull();
            result.Credentials.UserName.Should().Be("test@example.com");
            result.Links.Should().NotBeNull();
            result.Links.App.Should().NotBeNull();
            result.Links.User.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("users");
            mockClient.ReceivedBody.Should().Contain(TestUserId);
        }

        [Fact]
        public async Task AssignUserToApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AppUserAssignRequest { Id = TestUserId };

            await Assert.ThrowsAsync<ApiException>(() => api.AssignUserToApplicationAsync(null, request));
        }

        [Fact]
        public async Task AssignUserToApplication_WithNullRequest_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.AssignUserToApplicationAsync(TestAppId, null));
        }

        [Fact]
        public async Task AssignUserToApplicationWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"{
                ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                ""scope"": ""USER"",
                ""credentials"": { ""userName"": ""test@example.com"" }
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AppUserAssignRequest { Id = TestUserId };

            var result = await api.AssignUserToApplicationWithHttpInfoAsync(TestAppId, request);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestUserId);
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("Content-Type");
        }

        #endregion

        #region GetApplicationUser Tests

        [Fact]
        public async Task GetApplicationUser_WithValidIds_ReturnsAppUser()
        {
            var responseJson = @"{
                ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                ""externalId"": ""ext123"",
                ""created"": ""2023-01-15T12:00:00.000Z"",
                ""lastUpdated"": ""2023-01-15T13:30:00.000Z"",
                ""scope"": ""USER"",
                ""status"": ""ACTIVE"",
                ""statusChanged"": ""2023-01-15T12:00:00.000Z"",
                ""passwordChanged"": ""2023-01-15T12:00:00.000Z"",
                ""syncState"": ""DISABLED"",
                ""credentials"": {
                    ""userName"": ""test@example.com"",
                    ""password"": {}
                },
                ""profile"": {
                    ""email"": ""test@example.com"",
                    ""firstName"": ""Test"",
                    ""lastName"": ""User""
                },
                ""_links"": {
                    ""app"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4""
                    },
                    ""user"": {
                        ""href"": ""https://test.okta.com/api/v1/users/00u1gu2fJaO6T8V5Y0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetApplicationUserAsync(TestAppId, TestUserId);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestUserId);
            result.ExternalId.Should().Be("ext123");
            result.Scope.Should().Be(AppUser.ScopeEnum.USER);
            result.Status.Should().Be(AppUserStatus.ACTIVE);
            result.SyncState.Should().Be(AppUserSyncState.DISABLED);
            result.Credentials.Should().NotBeNull();
            result.Profile.Should().NotBeNull();
            result.Links.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("users");
        }

        [Fact]
        public async Task GetApplicationUser_WithExpandParameter_IncludesEmbeddedUser()
        {
            var responseJson = @"{
                ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                ""scope"": ""USER"",
                ""_embedded"": {
                    ""user"": {
                        ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                        ""status"": ""ACTIVE"",
                        ""profile"": {
                            ""email"": ""test@example.com"",
                            ""firstName"": ""Test"",
                            ""lastName"": ""User""
                        }
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetApplicationUserAsync(TestAppId, TestUserId, "user");

            result.Should().NotBeNull();
            result.Embedded.Should().NotBeNull();
            result.Embedded.Should().ContainKey("user");
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("user");
        }

        [Fact]
        public async Task GetApplicationUser_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetApplicationUserAsync(null, TestUserId));
        }

        [Fact]
        public async Task GetApplicationUser_WithNullUserId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetApplicationUserAsync(TestAppId, null));
        }

        [Fact]
        public async Task GetApplicationUserWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"{
                ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                ""scope"": ""USER""
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Rate-Limit-Remaining", "100" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetApplicationUserWithHttpInfoAsync(TestAppId, TestUserId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestUserId);
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("Content-Type");
            result.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
        }

        #endregion

        #region ListApplicationUsers Tests

        [Fact]
        public async Task ListApplicationUsers_WithValidAppId_ReturnsCollection()
        {
            var responseJson = @"[
                {
                    ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                    ""scope"": ""USER"",
                    ""credentials"": { ""userName"": ""user1@example.com"" }
                },
                {
                    ""id"": ""00u2gu2fJaO6T8V5Y0g5"",
                    ""scope"": ""GROUP"",
                    ""credentials"": { ""userName"": ""user2@example.com"" }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListApplicationUsersWithHttpInfoAsync(TestAppId);

            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            mockClient.ReceivedPath.Should().Contain("users");
        }

        [Fact]
        public async Task ListApplicationUsers_WithQueryParameter_AddsToQueryString()
        {
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListApplicationUsersWithHttpInfoAsync(TestAppId, q: "test@example");

            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().NotBeNull();
        }

        [Fact]
        public async Task ListApplicationUsers_WithLimitParameter_AddsToQueryString()
        {
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListApplicationUsersWithHttpInfoAsync(TestAppId, limit: 10);

            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().NotBeNull();
        }

        [Fact]
        public async Task ListApplicationUsers_WithAfterParameter_AddsToQueryString()
        {
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListApplicationUsersWithHttpInfoAsync(TestAppId, after: "cursor123");

            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().NotBeNull();
        }

        [Fact]
        public async Task ListApplicationUsers_WithExpandParameter_AddsToQueryString()
        {
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListApplicationUsersWithHttpInfoAsync(TestAppId, expand: "user");

            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().NotBeNull();
        }

        [Fact]
        public async Task ListApplicationUsers_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.ListApplicationUsersWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task ListApplicationUsersWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"[
                { ""id"": ""00u1gu2fJaO6T8V5Y0g4"", ""scope"": ""USER"" }
            ]";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "link", "<https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4/users?after=cursor>; rel=\"next\"" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListApplicationUsersWithHttpInfoAsync(TestAppId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(1);
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("link");
        }

        #endregion

        #region UpdateApplicationUser Tests

        [Fact]
        public async Task UpdateApplicationUser_WithProfileUpdate_ReturnsUpdatedUser()
        {
            var responseJson = @"{
                ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                ""scope"": ""USER"",
                ""lastUpdated"": ""2023-01-15T14:00:00.000Z"",
                ""profile"": {
                    ""email"": ""updated@example.com""
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            
            var profilePayload = new AppUserProfileRequestPayload
            {
                Profile = new Dictionary<string, object> { { "email", "updated@example.com" } }
            };
            var request = new AppUserUpdateRequest(profilePayload);

            var result = await api.UpdateApplicationUserAsync(TestAppId, TestUserId, request);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestUserId);
            result.Profile.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("users");
            mockClient.ReceivedBody.Should().Contain("updated@example.com");
        }

        [Fact]
        public async Task UpdateApplicationUser_WithCredentialsUpdate_ReturnsUpdatedUser()
        {
            var responseJson = @"{
                ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                ""scope"": ""USER"",
                ""credentials"": {
                    ""userName"": ""newusername@example.com""
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            
            var credentialsPayload = new AppUserCredentialsRequestPayload
            {
                Credentials = new AppUserCredentials
                {
                    UserName = "newusername@example.com"
                }
            };
            var request = new AppUserUpdateRequest(credentialsPayload);

            var result = await api.UpdateApplicationUserAsync(TestAppId, TestUserId, request);

            result.Should().NotBeNull();
            result.Credentials.Should().NotBeNull();
            result.Credentials.UserName.Should().Be("newusername@example.com");
            mockClient.ReceivedBody.Should().Contain("newusername@example.com");
        }

        [Fact]
        public async Task UpdateApplicationUser_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AppUserUpdateRequest(new AppUserProfileRequestPayload());

            await Assert.ThrowsAsync<ApiException>(() => api.UpdateApplicationUserAsync(null, TestUserId, request));
        }

        [Fact]
        public async Task UpdateApplicationUser_WithNullUserId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AppUserUpdateRequest(new AppUserProfileRequestPayload());

            await Assert.ThrowsAsync<ApiException>(() => api.UpdateApplicationUserAsync(TestAppId, null, request));
        }

        [Fact]
        public async Task UpdateApplicationUser_WithNullRequest_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.UpdateApplicationUserAsync(TestAppId, TestUserId, null));
        }

        [Fact]
        public async Task UpdateApplicationUserWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"{
                ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                ""scope"": ""USER""
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AppUserUpdateRequest(new AppUserProfileRequestPayload());

            var result = await api.UpdateApplicationUserWithHttpInfoAsync(TestAppId, TestUserId, request);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Headers.Should().NotBeNull();
        }

        #endregion

        #region UnassignUserFromApplication Tests

        [Fact]
        public async Task UnassignUserFromApplication_WithValidIds_Succeeds()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.UnassignUserFromApplicationAsync(TestAppId, TestUserId);

            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("users");
        }

        [Fact]
        public async Task UnassignUserFromApplication_WithSendEmailParameter_AddsToQueryString()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.UnassignUserFromApplicationAsync(TestAppId, TestUserId, sendEmail: false);

            mockClient.ReceivedQueryParams.Should().ContainKey("sendEmail");
            mockClient.ReceivedQueryParams["sendEmail"].Should().Contain("false");
        }

        [Fact]
        public async Task UnassignUserFromApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.UnassignUserFromApplicationAsync(null, TestUserId));
        }

        [Fact]
        public async Task UnassignUserFromApplication_WithNullUserId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.UnassignUserFromApplicationAsync(TestAppId, null));
        }

        [Fact]
        public async Task UnassignUserFromApplicationWithHttpInfo_ReturnsHttpResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "X-Rate-Limit-Remaining", "100" }
            };
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent, headers);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.UnassignUserFromApplicationWithHttpInfoAsync(TestAppId, TestUserId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
            result.Headers.Should().NotBeNull();
            result.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task AssignUserToApplication_With404Response_ThrowsApiException()
        {
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: 0oa1gjh63g214q0Hq0g4 (Application)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaepBauDp10wHbi76zjZkLhCw""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AppUserAssignRequest { Id = TestUserId };

            var exception = await Assert.ThrowsAsync<ApiException>(() => 
                api.AssignUserToApplicationAsync("invalid-app-id", request));
            
            exception.Should().NotBeNull();
            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GetApplicationUser_With404Response_ThrowsApiException()
        {
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaepBauDp10wHbi76zjZkLhCw""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var exception = await Assert.ThrowsAsync<ApiException>(() => 
                api.GetApplicationUserAsync(TestAppId, "invalid-user-id"));
            
            exception.Should().NotBeNull();
            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task UpdateApplicationUser_With400Response_ThrowsApiException()
        {
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: request"",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""oaepBauDp10wHbi76zjZkLhCw""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AppUserUpdateRequest(new AppUserProfileRequestPayload());

            var exception = await Assert.ThrowsAsync<ApiException>(() => 
                api.UpdateApplicationUserAsync(TestAppId, TestUserId, request));
            
            exception.Should().NotBeNull();
            exception.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task UnassignUserFromApplication_With404Response_ThrowsApiException()
        {
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: User is not assigned to application"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaepBauDp10wHbi76zjZkLhCw""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var exception = await Assert.ThrowsAsync<ApiException>(() => 
                api.UnassignUserFromApplicationAsync(TestAppId, TestUserId));
            
            exception.Should().NotBeNull();
            exception.ErrorCode.Should().Be(404);
        }

        #endregion

        #region Edge Cases Tests

        [Fact]
        public async Task AssignUserToApplication_WithGroupScope_ReturnsGroupScopedUser()
        {
            var responseJson = @"{
                ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                ""scope"": ""GROUP"",
                ""status"": ""PROVISIONED"",
                ""credentials"": { ""userName"": ""test@example.com"" }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new AppUserAssignRequest { Id = TestUserId };

            var result = await api.AssignUserToApplicationAsync(TestAppId, request);

            result.Should().NotBeNull();
            result.Scope.Should().Be(AppUser.ScopeEnum.GROUP);
        }

        [Fact]
        public async Task GetApplicationUser_WithAllStatusValues_ParsesCorrectly()
        {
            var statusValues = new[] { "PROVISIONED", "STAGED", "ACTIVE", "INACTIVE", "DEPROVISIONED" };

            foreach (var status in statusValues)
            {
                var responseJson = $@"{{
                    ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                    ""scope"": ""USER"",
                    ""status"": ""{status}""
                }}";

                var mockClient = new MockAsyncClient(responseJson);
                var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

                var result = await api.GetApplicationUserAsync(TestAppId, TestUserId);

                result.Should().NotBeNull();
                result.Status.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task GetApplicationUser_WithSyncStateValues_ParsesCorrectly()
        {
            var syncStates = new[] { "DISABLED", "SYNCHRONIZED", "PENDING", "OUT_OF_SYNC", "ERROR" };

            foreach (var syncState in syncStates)
            {
                var responseJson = $@"{{
                    ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                    ""scope"": ""USER"",
                    ""syncState"": ""{syncState}""
                }}";

                var mockClient = new MockAsyncClient(responseJson);
                var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

                var result = await api.GetApplicationUserAsync(TestAppId, TestUserId);

                result.Should().NotBeNull();
                result.SyncState.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task ListApplicationUsers_WithAllParameters_AddsAllToQueryString()
        {
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.ListApplicationUsersWithHttpInfoAsync(
                TestAppId, 
                q: "search", 
                after: "cursor", 
                limit: 20, 
                expand: "user");

            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateApplicationUser_WithPasswordCredentials_IncludesPassword()
        {
            var responseJson = @"{
                ""id"": ""00u1gu2fJaO6T8V5Y0g4"",
                ""scope"": ""USER"",
                ""credentials"": {
                    ""userName"": ""test@example.com"",
                    ""password"": {}
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationUsersApi(mockClient, new Configuration { BasePath = BaseUrl });
            
            var credentialsPayload = new AppUserCredentialsRequestPayload
            {
                Credentials = new AppUserCredentials
                {
                    UserName = "test@example.com",
                    Password = new AppUserPasswordCredential
                    {
                        Value = "NewP@ssw0rd123!"
                    }
                }
            };
            var request = new AppUserUpdateRequest(credentialsPayload);

            var result = await api.UpdateApplicationUserAsync(TestAppId, TestUserId, request);

            result.Should().NotBeNull();
            result.Credentials.Should().NotBeNull();
            mockClient.ReceivedBody.Should().Contain("test@example.com");
        }

        #endregion
    }
}
