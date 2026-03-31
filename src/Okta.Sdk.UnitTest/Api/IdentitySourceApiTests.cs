// <copyright file="IdentitySourceApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Okta.Sdk.UnitTest.Internal;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    public class IdentitySourceApiTests
    {
        private const string BaseUrl = "https://test.okta.com";

        // -----------------------------------------------------------------------
        // Helpers
        // -----------------------------------------------------------------------

        private static Configuration CreateConfig(
            AuthorizationMode mode = AuthorizationMode.SSWS,
            string apiKey = null,
            string accessToken = null)
        {
            var config = new Configuration { OktaDomain = BaseUrl };

            if (mode == AuthorizationMode.SSWS && apiKey != null)
            {
                config.AuthorizationMode = AuthorizationMode.SSWS;
                config.ApiKey = new Dictionary<string, string> { { "Authorization", apiKey } };
                config.ApiKeyPrefix = new Dictionary<string, string> { { "Authorization", "SSWS" } };
            }
            else if (mode == AuthorizationMode.BearerToken && accessToken != null)
            {
                config.AuthorizationMode = AuthorizationMode.BearerToken;
                config.AccessToken = accessToken;
            }

            return config;
        }

        private static IdentitySourceApi CreateApi(IAsynchronousClient client, Configuration config = null)
            => new IdentitySourceApi(client, config ?? new Configuration { OktaDomain = BaseUrl });

        private static string BuildSessionJson(
            string id = "sess1a2b3c4d5e",
            string identitySourceId = "source-app-id",
            string status = "CREATED",
            string importType = "INCREMENTAL")
            => $@"{{
                ""id"": ""{id}"",
                ""identitySourceId"": ""{identitySourceId}"",
                ""status"": ""{status}"",
                ""importType"": ""{importType}"",
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-01-15T10:00:00.000Z""
            }}";

        private static string BuildSessionListJson(params string[] items)
            => $"[{string.Join(",", items)}]";

        private static BulkUpsertRequestBody BuildUpsertBody(string externalId = "ext-user-001")
            => new BulkUpsertRequestBody
            {
                EntityType = BulkUpsertRequestBody.EntityTypeEnum.USERS,
                Profiles =
                [
                    new BulkUpsertRequestBodyProfilesInner
                    {
                        ExternalId = externalId,
                        Profile = new IdentitySourceUserProfileForUpsert
                        {
                            Email = "test@example.com",
                            FirstName = "Test",
                            LastName = "User",
                            UserName = "test@example.com"
                        }
                    }
                ]
            };

        private static BulkDeleteRequestBody BuildDeleteBody(string externalId = "ext-user-001")
            => new BulkDeleteRequestBody
            {
                EntityType = BulkDeleteRequestBody.EntityTypeEnum.USERS,
                Profiles = [new IdentitySourceUserProfileForDelete { ExternalId = externalId }]
            };

        // -----------------------------------------------------------------------
        // Constructor
        // -----------------------------------------------------------------------

        #region Constructor Tests

        [Fact]
        public void Constructor_WithNullAsyncClient_ThrowsArgumentNullException()
        {
            Action act = () => new IdentitySourceApi(null, new Configuration { OktaDomain = BaseUrl });

            act.Should().Throw<ArgumentNullException>().WithParameterName("asyncClient");
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var mockClient = new Mock<IAsynchronousClient>();

            Action act = () => new IdentitySourceApi(mockClient.Object, null);

            act.Should().Throw<ArgumentNullException>().WithParameterName("configuration");
        }

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var mockClient = new Mock<IAsynchronousClient>();

            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });

            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithValidParameters_ImplementsIIdentitySourceApi()
        {
            var mockClient = new Mock<IAsynchronousClient>();

            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });

            api.Should().BeAssignableTo<IIdentitySourceApi>();
        }

        [Fact]
        public void Constructor_AssignsAsynchronousClient()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            var config = new Configuration { OktaDomain = BaseUrl };

            var api = new IdentitySourceApi(mockClient.Object, config);

            api.AsynchronousClient.Should().BeSameAs(mockClient.Object);
        }

        [Fact]
        public void Constructor_AssignsConfiguration()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            var config = new Configuration { OktaDomain = BaseUrl };

            var api = new IdentitySourceApi(mockClient.Object, config);

            api.Configuration.Should().BeSameAs(config);
        }

        [Fact]
        public void Constructor_SetsDefaultExceptionFactory()
        {
            var mockClient = new Mock<IAsynchronousClient>();

            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });

            api.ExceptionFactory.Should().NotBeNull();
        }

        [Fact]
        public void ExceptionFactory_WithMulticastDelegate_ThrowsInvalidOperationException()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });

            ExceptionFactory factoryA = (_, _) => new Exception("a");
            ExceptionFactory factoryB = (_, _) => new Exception("b");
            api.ExceptionFactory = factoryA + factoryB;

            Action act = () => { var _ = api.ExceptionFactory; };

            act.Should().Throw<InvalidOperationException>().WithMessage("*Multicast*");
        }

        [Fact]
        public void ExceptionFactory_CanBeSetToNull()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });

            api.ExceptionFactory = null;

            api.ExceptionFactory.Should().BeNull();
        }

        #endregion

        // -----------------------------------------------------------------------
        // GetBasePath
        // -----------------------------------------------------------------------

        #region GetBasePath Tests

        [Fact]
        public void GetBasePath_ReturnsOktaDomainFromConfiguration()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = "https://my-org.okta.com" });

            api.GetBasePath().Should().Be("https://my-org.okta.com");
        }

        [Fact]
        public void GetBasePath_WithTrailingSlash_ReturnsValueVerbatim()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = "https://my-org.okta.com/" });

            api.GetBasePath().Should().Be("https://my-org.okta.com/");
        }

        #endregion

        // -----------------------------------------------------------------------
        // CreateIdentitySourceSessionAsync / WithHttpInfo
        // -----------------------------------------------------------------------

        #region CreateIdentitySourceSession Tests

        [Fact]
        public async Task CreateIdentitySourceSessionAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.CreateIdentitySourceSessionAsync(null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task CreateIdentitySourceSessionWithHttpInfoAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.CreateIdentitySourceSessionWithHttpInfoAsync(null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task CreateIdentitySourceSessionAsync_WithNullIdentitySourceId_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.CreateIdentitySourceSessionAsync(null);

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");
        }

        [Fact]
        public async Task CreateIdentitySourceSessionAsync_CallsPostEndpoint()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            await api.CreateIdentitySourceSessionAsync("my-source-id");

            mockClient.ReceivedPath.Should().Be("/api/v1/identity-sources/{identitySourceId}/sessions");
        }

        [Fact]
        public async Task CreateIdentitySourceSessionAsync_SetsIdentitySourceIdPathParameter()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            await api.CreateIdentitySourceSessionAsync("my-source-id");

            mockClient.ReceivedPathParams.Should().ContainKey("identitySourceId");
            mockClient.ReceivedPathParams["identitySourceId"].Should().Contain("my-source-id");
        }

        [Fact]
        public async Task CreateIdentitySourceSessionWithHttpInfoAsync_ReturnsOkStatus()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            var response = await api.CreateIdentitySourceSessionWithHttpInfoAsync("my-source-id");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateIdentitySourceSessionAsync_ReturnsParsedSession()
        {
            var mockClient = new MockAsyncClient(
                BuildSessionJson("sess-abc", "src-123", "CREATED", "INCREMENTAL"),
                HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            var result = await api.CreateIdentitySourceSessionAsync("src-123");

            result.Should().NotBeNull();
            result.Id.Should().Be("sess-abc");
            result.IdentitySourceId.Should().Be("src-123");
            result.Status.Should().Be(IdentitySourceSessionStatus.CREATED);
            result.ImportType.Should().Be("INCREMENTAL");
        }

        [Fact]
        public async Task CreateIdentitySourceSessionWithHttpInfoAsync_ReturnsParsedSession()
        {
            var mockClient = new MockAsyncClient(
                BuildSessionJson("sess-xyz", "src-456"),
                HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            var response = await api.CreateIdentitySourceSessionWithHttpInfoAsync("src-456");

            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be("sess-xyz");
            response.Data.IdentitySourceId.Should().Be("src-456");
        }

        [Fact]
        public async Task CreateIdentitySourceSessionAsync_DelegatesDataFromWithHttpInfo()
        {
            var json = BuildSessionJson("sess-del", "src-del");
            var result = await CreateApi(new MockAsyncClient(json, HttpStatusCode.OK))
                .CreateIdentitySourceSessionAsync("src-del");
            var httpResult = await CreateApi(new MockAsyncClient(json, HttpStatusCode.OK))
                .CreateIdentitySourceSessionWithHttpInfoAsync("src-del");

            result.Id.Should().Be(httpResult.Data.Id);
            result.IdentitySourceId.Should().Be(httpResult.Data.IdentitySourceId);
        }

        [Fact]
        public async Task CreateIdentitySourceSessionAsync_DoesNotSetContentTypeHeader()
        {
            // POST /sessions has no request body
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            await api.CreateIdentitySourceSessionAsync("source-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Content-Type",
                "create session sends no body so Content-Type must not be set");
        }

        [Fact]
        public async Task CreateIdentitySourceSessionAsync_SetsAcceptHeader()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            await api.CreateIdentitySourceSessionAsync("source-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task CreateIdentitySourceSessionAsync_WithSswsAuth_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.SSWS, apiKey: "create-token"));

            await api.CreateIdentitySourceSessionAsync("source-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS create-token");
        }

        [Fact]
        public async Task CreateIdentitySourceSessionAsync_WithBearerToken_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.BearerToken, accessToken: "create-bearer"));

            await api.CreateIdentitySourceSessionAsync("source-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer create-bearer");
        }

        [Fact]
        public async Task CreateIdentitySourceSessionAsync_WithNoAuthConfigured_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient, new Configuration { OktaDomain = BaseUrl });

            await api.CreateIdentitySourceSessionAsync("source-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization");
        }

        [Fact]
        public async Task CreateIdentitySourceSessionWithHttpInfoAsync_WhenExceptionFactoryReturnsException_ThrowsIt()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            mockClient
                .Setup(c => c.PostAsync<IdentitySourceSession>(
                    It.IsAny<string>(), It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<IdentitySourceSession>(HttpStatusCode.Conflict, (Multimap<string, string>)null, (IdentitySourceSession)null));

            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });
            api.ExceptionFactory = (_, response) =>
                response.StatusCode == HttpStatusCode.Conflict ? new ApiException(409, "Conflict") : null;

            Func<Task> act = async () => await api.CreateIdentitySourceSessionWithHttpInfoAsync("src-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(409);
        }

        [Fact]
        public async Task CreateIdentitySourceSessionWithHttpInfoAsync_WhenExceptionFactoryIsNull_DoesNotThrow()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));
            api.ExceptionFactory = null;

            Func<Task> act = async () => await api.CreateIdentitySourceSessionWithHttpInfoAsync("src-id");

            await act.Should().NotThrowAsync();
        }

        #endregion

        // -----------------------------------------------------------------------
        // DeleteIdentitySourceSessionAsync / WithHttpInfo
        // -----------------------------------------------------------------------

        #region DeleteIdentitySourceSession Tests

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.NoContent));

            Func<Task> act = async () => await api.DeleteIdentitySourceSessionAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionWithHttpInfoAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.NoContent));

            Func<Task> act = async () => await api.DeleteIdentitySourceSessionWithHttpInfoAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_WithNullSessionId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.NoContent));

            Func<Task> act = async () => await api.DeleteIdentitySourceSessionAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionWithHttpInfoAsync_WithNullSessionId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.NoContent));

            Func<Task> act = async () => await api.DeleteIdentitySourceSessionWithHttpInfoAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_WithNullIdentitySourceId_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.NoContent));

            Func<Task> act = async () => await api.DeleteIdentitySourceSessionAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_WithNullSessionId_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.NoContent));

            Func<Task> act = async () => await api.DeleteIdentitySourceSessionAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("sessionId");
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_CallsDeleteEndpoint()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteIdentitySourceSessionAsync("src-id", "sess-id");

            mockClient.ReceivedPath.Should().Be("/api/v1/identity-sources/{identitySourceId}/sessions/{sessionId}");
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_SetsIdentitySourceIdPathParameter()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteIdentitySourceSessionAsync("my-source", "my-session");

            mockClient.ReceivedPathParams.Should().ContainKey("identitySourceId");
            mockClient.ReceivedPathParams["identitySourceId"].Should().Contain("my-source");
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_SetsSessionIdPathParameter()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteIdentitySourceSessionAsync("my-source", "my-session");

            mockClient.ReceivedPathParams.Should().ContainKey("sessionId");
            mockClient.ReceivedPathParams["sessionId"].Should().Contain("my-session");
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionWithHttpInfoAsync_ReturnsNoContentStatus()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var response = await api.DeleteIdentitySourceSessionWithHttpInfoAsync("src-id", "sess-id");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_DelegatesTo_WithHttpInfo()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            Func<Task> act = async () => await api.DeleteIdentitySourceSessionAsync("src-id", "sess-id");

            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_DoesNotSetContentTypeHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteIdentitySourceSessionAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Content-Type",
                "DELETE has no request body so Content-Type must not be added");
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_SetsAcceptHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteIdentitySourceSessionAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_WithSswsAuth_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.SSWS, apiKey: "del-token"));

            await api.DeleteIdentitySourceSessionAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS del-token");
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_WithBearerToken_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.BearerToken, accessToken: "del-bearer"));

            await api.DeleteIdentitySourceSessionAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer del-bearer");
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionAsync_WithNoAuthConfigured_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient, new Configuration { OktaDomain = BaseUrl });

            await api.DeleteIdentitySourceSessionAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization");
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionWithHttpInfoAsync_WhenExceptionFactoryReturnsException_ThrowsIt()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            mockClient
                .Setup(c => c.DeleteAsync<object>(
                    It.IsAny<string>(), It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<object>(HttpStatusCode.NotFound, (Multimap<string, string>)null, (object)null));

            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });
            api.ExceptionFactory = (_, response) =>
                response.StatusCode == HttpStatusCode.NotFound ? new ApiException(404, "Not Found") : null;

            Func<Task> act = async () => await api.DeleteIdentitySourceSessionWithHttpInfoAsync("src-id", "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task DeleteIdentitySourceSessionWithHttpInfoAsync_WhenExceptionFactoryIsNull_DoesNotThrow()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.NoContent));
            api.ExceptionFactory = null;

            Func<Task> act = async () => await api.DeleteIdentitySourceSessionWithHttpInfoAsync("src-id", "sess-id");

            await act.Should().NotThrowAsync();
        }

        #endregion

        // -----------------------------------------------------------------------
        // GetIdentitySourceSessionAsync / WithHttpInfo
        // -----------------------------------------------------------------------

        #region GetIdentitySourceSession Tests

        [Fact]
        public async Task GetIdentitySourceSessionAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.GetIdentitySourceSessionAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task GetIdentitySourceSessionWithHttpInfoAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.GetIdentitySourceSessionWithHttpInfoAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_WithNullSessionId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.GetIdentitySourceSessionAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task GetIdentitySourceSessionWithHttpInfoAsync_WithNullSessionId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.GetIdentitySourceSessionWithHttpInfoAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_WithNullIdentitySourceId_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.GetIdentitySourceSessionAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_WithNullSessionId_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.GetIdentitySourceSessionAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("sessionId");
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_CallsGetEndpoint()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson());
            var api = CreateApi(mockClient);

            await api.GetIdentitySourceSessionAsync("my-source", "my-session");

            mockClient.ReceivedPath.Should().Be("/api/v1/identity-sources/{identitySourceId}/sessions/{sessionId}");
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_SetsIdentitySourceIdPathParameter()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson());
            var api = CreateApi(mockClient);

            await api.GetIdentitySourceSessionAsync("my-source", "my-session");

            mockClient.ReceivedPathParams.Should().ContainKey("identitySourceId");
            mockClient.ReceivedPathParams["identitySourceId"].Should().Contain("my-source");
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_SetsSessionIdPathParameter()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson());
            var api = CreateApi(mockClient);

            await api.GetIdentitySourceSessionAsync("my-source", "my-session");

            mockClient.ReceivedPathParams.Should().ContainKey("sessionId");
            mockClient.ReceivedPathParams["sessionId"].Should().Contain("my-session");
        }

        [Fact]
        public async Task GetIdentitySourceSessionWithHttpInfoAsync_ReturnsOkStatus()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson());
            var api = CreateApi(mockClient);

            var response = await api.GetIdentitySourceSessionWithHttpInfoAsync("src-id", "sess-id");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_ReturnsFullResponseFields()
        {
            var json = BuildSessionJson("sess-full", "src-full", "TRIGGERED", "INCREMENTAL");
            var api = CreateApi(new MockAsyncClient(json));

            var result = await api.GetIdentitySourceSessionAsync("src-full", "sess-full");

            result.Should().NotBeNull();
            result.Id.Should().Be("sess-full");
            result.IdentitySourceId.Should().Be("src-full");
            result.Status.Should().Be(IdentitySourceSessionStatus.TRIGGERED);
            result.ImportType.Should().Be("INCREMENTAL");
        }

        [Fact]
        public async Task GetIdentitySourceSessionWithHttpInfoAsync_ReturnsFullResponseFields()
        {
            var json = BuildSessionJson("sess-http", "src-http", "COMPLETED", "INCREMENTAL");
            var api = CreateApi(new MockAsyncClient(json));

            var response = await api.GetIdentitySourceSessionWithHttpInfoAsync("src-http", "sess-http");

            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be("sess-http");
            response.Data.IdentitySourceId.Should().Be("src-http");
            response.Data.Status.Should().Be(IdentitySourceSessionStatus.COMPLETED);
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_DelegatesDataFromWithHttpInfo()
        {
            var json = BuildSessionJson("sess-cmp", "src-cmp");
            var result = await CreateApi(new MockAsyncClient(json)).GetIdentitySourceSessionAsync("src-cmp", "sess-cmp");
            var httpResult = await CreateApi(new MockAsyncClient(json)).GetIdentitySourceSessionWithHttpInfoAsync("src-cmp", "sess-cmp");

            result.Id.Should().Be(httpResult.Data.Id);
            result.IdentitySourceId.Should().Be(httpResult.Data.IdentitySourceId);
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_DoesNotSetContentTypeHeader()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson());
            var api = CreateApi(mockClient);

            await api.GetIdentitySourceSessionAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Content-Type",
                "GET has no request body so Content-Type must not be added");
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_SetsAcceptHeader()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson());
            var api = CreateApi(mockClient);

            await api.GetIdentitySourceSessionAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_WithSswsAuth_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson());
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.SSWS, apiKey: "get-token"));

            await api.GetIdentitySourceSessionAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS get-token");
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_WithBearerToken_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson());
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.BearerToken, accessToken: "get-bearer"));

            await api.GetIdentitySourceSessionAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer get-bearer");
        }

        [Fact]
        public async Task GetIdentitySourceSessionAsync_WithNoAuthConfigured_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson());
            var api = CreateApi(mockClient, new Configuration { OktaDomain = BaseUrl });

            await api.GetIdentitySourceSessionAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization");
        }

        [Fact]
        public async Task GetIdentitySourceSessionWithHttpInfoAsync_WhenExceptionFactoryReturnsException_ThrowsIt()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            mockClient
                .Setup(c => c.GetAsync<IdentitySourceSession>(
                    It.IsAny<string>(), It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<IdentitySourceSession>(HttpStatusCode.NotFound, (Multimap<string, string>)null, (IdentitySourceSession)null));

            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });
            api.ExceptionFactory = (_, response) =>
                response.StatusCode == HttpStatusCode.NotFound ? new ApiException(404, "Not Found") : null;

            Func<Task> act = async () => await api.GetIdentitySourceSessionWithHttpInfoAsync("src-id", "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GetIdentitySourceSessionWithHttpInfoAsync_WhenExceptionFactoryIsNull_DoesNotThrow()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson()));
            api.ExceptionFactory = null;

            Func<Task> act = async () => await api.GetIdentitySourceSessionWithHttpInfoAsync("src-id", "sess-id");

            await act.Should().NotThrowAsync();
        }

        #endregion

        // -----------------------------------------------------------------------
        // ListIdentitySourceSessions  (collection client)
        // -----------------------------------------------------------------------

        #region ListIdentitySourceSessions Tests

        [Fact]
        public void ListIdentitySourceSessions_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            Action act = () => api.ListIdentitySourceSessions(null);

            act.Should().Throw<ApiException>().Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public void ListIdentitySourceSessions_WithNullIdentitySourceId_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            Action act = () => api.ListIdentitySourceSessions(null);

            act.Should().Throw<ApiException>().Which.Message.Should().Contain("identitySourceId");
        }

        [Fact]
        public void ListIdentitySourceSessions_ReturnsNonNullCollectionClient()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            var result = api.ListIdentitySourceSessions("src-id");

            result.Should().NotBeNull();
        }

        [Fact]
        public void ListIdentitySourceSessions_ImplementsIOktaCollectionClient()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            var result = api.ListIdentitySourceSessions("src-id");

            result.Should().BeAssignableTo<IOktaCollectionClient<IdentitySourceSession>>();
        }

        [Fact]
        public void ListIdentitySourceSessions_WithSswsAuth_DoesNotThrowOnCreation()
        {
            var api = CreateApi(
                new MockAsyncClient("[]"),
                CreateConfig(AuthorizationMode.SSWS, apiKey: "list-token"));

            Action act = () => api.ListIdentitySourceSessions("src-id");

            act.Should().NotThrow();
        }

        [Fact]
        public void ListIdentitySourceSessions_WithBearerToken_DoesNotThrowOnCreation()
        {
            var api = CreateApi(
                new MockAsyncClient("[]"),
                CreateConfig(AuthorizationMode.BearerToken, accessToken: "list-bearer"));

            Action act = () => api.ListIdentitySourceSessions("src-id");

            act.Should().NotThrow();
        }

        [Fact]
        public void ListIdentitySourceSessions_CalledMultipleTimes_ReturnsNewCollectionClientEachTime()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            var result1 = api.ListIdentitySourceSessions("src-id");
            var result2 = api.ListIdentitySourceSessions("src-id");

            result1.Should().NotBeSameAs(result2);
        }

        #endregion

        // -----------------------------------------------------------------------
        // ListIdentitySourceSessionsWithHttpInfoAsync
        // -----------------------------------------------------------------------

        #region ListIdentitySourceSessionsWithHttpInfo Tests

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            Func<Task> act = async () => await api.ListIdentitySourceSessionsWithHttpInfoAsync(null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_CallsCorrectEndpoint()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient);

            await api.ListIdentitySourceSessionsWithHttpInfoAsync("my-source");

            mockClient.ReceivedPath.Should().Be("/api/v1/identity-sources/{identitySourceId}/sessions");
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_SetsIdentitySourceIdPathParameter()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient);

            await api.ListIdentitySourceSessionsWithHttpInfoAsync("my-source");

            mockClient.ReceivedPathParams.Should().ContainKey("identitySourceId");
            mockClient.ReceivedPathParams["identitySourceId"].Should().Contain("my-source");
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_ReturnsOkStatus()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            var response = await api.ListIdentitySourceSessionsWithHttpInfoAsync("src-id");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_EmptyListResponse_ReturnsEmptyCollection()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            var response = await api.ListIdentitySourceSessionsWithHttpInfoAsync("src-id");

            response.Data.Should().NotBeNull();
            response.Data.Should().BeEmpty();
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_SingleSession_ReturnsOneItem()
        {
            var json = BuildSessionListJson(BuildSessionJson("sess-one", "src-one"));
            var api = CreateApi(new MockAsyncClient(json));

            var response = await api.ListIdentitySourceSessionsWithHttpInfoAsync("src-one");

            response.Data.Should().HaveCount(1);
            response.Data[0].Id.Should().Be("sess-one");
            response.Data[0].IdentitySourceId.Should().Be("src-one");
            response.Data[0].Status.Should().Be(IdentitySourceSessionStatus.CREATED);
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_TwoSessions_ReturnsBoth()
        {
            var json = BuildSessionListJson(
                BuildSessionJson("sess-a", "src-multi"),
                BuildSessionJson("sess-b", "src-multi", "TRIGGERED"));
            var api = CreateApi(new MockAsyncClient(json));

            var response = await api.ListIdentitySourceSessionsWithHttpInfoAsync("src-multi");

            response.Data.Should().HaveCount(2);
            response.Data[0].Id.Should().Be("sess-a");
            response.Data[1].Id.Should().Be("sess-b");
            response.Data[1].Status.Should().Be(IdentitySourceSessionStatus.TRIGGERED);
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_SetsAcceptHeader()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient);

            await api.ListIdentitySourceSessionsWithHttpInfoAsync("src-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_DoesNotSetContentTypeHeader()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient);

            await api.ListIdentitySourceSessionsWithHttpInfoAsync("src-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Content-Type");
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_WithSswsAuth_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.SSWS, apiKey: "list-token"));

            await api.ListIdentitySourceSessionsWithHttpInfoAsync("src-id");

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS list-token");
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_WithBearerToken_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.BearerToken, accessToken: "list-bearer"));

            await api.ListIdentitySourceSessionsWithHttpInfoAsync("src-id");

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer list-bearer");
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_WithNoAuthConfigured_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient, new Configuration { OktaDomain = BaseUrl });

            await api.ListIdentitySourceSessionsWithHttpInfoAsync("src-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization",
                "when no auth mode is configured no Authorization header must be added");
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_WhenExceptionFactoryReturnsException_ThrowsIt()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            mockClient
                .Setup(c => c.GetAsync<List<IdentitySourceSession>>(
                    It.IsAny<string>(), It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<List<IdentitySourceSession>>(HttpStatusCode.Forbidden, (Multimap<string, string>)null, (List<IdentitySourceSession>)null));

            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });
            api.ExceptionFactory = (_, response) =>
                response.StatusCode == HttpStatusCode.Forbidden ? new ApiException(403, "Forbidden") : null;

            Func<Task> act = async () => await api.ListIdentitySourceSessionsWithHttpInfoAsync("src-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(403);
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_WhenExceptionFactoryIsNull_DoesNotThrow()
        {
            var api = CreateApi(new MockAsyncClient("[]"));
            api.ExceptionFactory = null;

            Func<Task> act = async () => await api.ListIdentitySourceSessionsWithHttpInfoAsync("src-id");

            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task ListIdentitySourceSessionsWithHttpInfoAsync_WhenExceptionFactoryReturnsNull_DoesNotThrow()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient);
            api.ExceptionFactory = (_, _) => null;

            Func<Task> act = async () => await api.ListIdentitySourceSessionsWithHttpInfoAsync("src-id");

            await act.Should().NotThrowAsync();
        }

        #endregion

        // -----------------------------------------------------------------------
        // StartImportFromIdentitySourceAsync / WithHttpInfo
        // -----------------------------------------------------------------------

        #region StartImportFromIdentitySource Tests

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.StartImportFromIdentitySourceAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task StartImportFromIdentitySourceWithHttpInfoAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.StartImportFromIdentitySourceWithHttpInfoAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_WithNullSessionId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.StartImportFromIdentitySourceAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task StartImportFromIdentitySourceWithHttpInfoAsync_WithNullSessionId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.StartImportFromIdentitySourceWithHttpInfoAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_WithNullIdentitySourceId_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.StartImportFromIdentitySourceAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_WithNullSessionId_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));

            Func<Task> act = async () => await api.StartImportFromIdentitySourceAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("sessionId");
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_CallsPostEndpoint()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            await api.StartImportFromIdentitySourceAsync("my-source", "my-session");

            mockClient.ReceivedPath.Should().Be("/api/v1/identity-sources/{identitySourceId}/sessions/{sessionId}/start-import");
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_SetsIdentitySourceIdPathParameter()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            await api.StartImportFromIdentitySourceAsync("my-source", "my-session");

            mockClient.ReceivedPathParams.Should().ContainKey("identitySourceId");
            mockClient.ReceivedPathParams["identitySourceId"].Should().Contain("my-source");
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_SetsSessionIdPathParameter()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            await api.StartImportFromIdentitySourceAsync("my-source", "my-session");

            mockClient.ReceivedPathParams.Should().ContainKey("sessionId");
            mockClient.ReceivedPathParams["sessionId"].Should().Contain("my-session");
        }

        [Fact]
        public async Task StartImportFromIdentitySourceWithHttpInfoAsync_ReturnsOkStatus()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(status: "TRIGGERED"), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            var response = await api.StartImportFromIdentitySourceWithHttpInfoAsync("src-id", "sess-id");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_ReturnsParsedSession()
        {
            var json = BuildSessionJson("sess-trig", "src-trig", "TRIGGERED");
            var api = CreateApi(new MockAsyncClient(json, HttpStatusCode.OK));

            var result = await api.StartImportFromIdentitySourceAsync("src-trig", "sess-trig");

            result.Should().NotBeNull();
            result.Id.Should().Be("sess-trig");
            result.Status.Should().Be(IdentitySourceSessionStatus.TRIGGERED);
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_DelegatesDataFromWithHttpInfo()
        {
            var json = BuildSessionJson("sess-start", "src-start", "TRIGGERED");
            var result = await CreateApi(new MockAsyncClient(json, HttpStatusCode.OK))
                .StartImportFromIdentitySourceAsync("src-start", "sess-start");
            var httpResult = await CreateApi(new MockAsyncClient(json, HttpStatusCode.OK))
                .StartImportFromIdentitySourceWithHttpInfoAsync("src-start", "sess-start");

            result.Id.Should().Be(httpResult.Data.Id);
            result.Status.Should().Be(httpResult.Data.Status);
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_DoesNotSetContentTypeHeader()
        {
            // POST /start-import has no request body
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            await api.StartImportFromIdentitySourceAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Content-Type",
                "start-import sends no body so Content-Type must not be set");
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_SetsAcceptHeader()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            await api.StartImportFromIdentitySourceAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_WithSswsAuth_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.SSWS, apiKey: "start-token"));

            await api.StartImportFromIdentitySourceAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS start-token");
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_WithBearerToken_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.BearerToken, accessToken: "start-bearer"));

            await api.StartImportFromIdentitySourceAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer start-bearer");
        }

        [Fact]
        public async Task StartImportFromIdentitySourceAsync_WithNoAuthConfigured_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient, new Configuration { OktaDomain = BaseUrl });

            await api.StartImportFromIdentitySourceAsync("src-id", "sess-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization");
        }

        [Fact]
        public async Task StartImportFromIdentitySourceWithHttpInfoAsync_WhenExceptionFactoryReturnsException_ThrowsIt()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            mockClient
                .Setup(c => c.PostAsync<IdentitySourceSession>(
                    It.IsAny<string>(), It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<IdentitySourceSession>(HttpStatusCode.BadRequest, (Multimap<string, string>)null, (IdentitySourceSession)null));

            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });
            api.ExceptionFactory = (_, response) =>
                response.StatusCode == HttpStatusCode.BadRequest ? new ApiException(400, "Bad Request") : null;

            Func<Task> act = async () => await api.StartImportFromIdentitySourceWithHttpInfoAsync("src-id", "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task StartImportFromIdentitySourceWithHttpInfoAsync_WhenExceptionFactoryIsNull_DoesNotThrow()
        {
            var api = CreateApi(new MockAsyncClient(BuildSessionJson(), HttpStatusCode.OK));
            api.ExceptionFactory = null;

            Func<Task> act = async () => await api.StartImportFromIdentitySourceWithHttpInfoAsync("src-id", "sess-id");

            await act.Should().NotThrowAsync();
        }

        #endregion

        // -----------------------------------------------------------------------
        // UploadIdentitySourceDataForDeleteAsync / WithHttpInfo
        // -----------------------------------------------------------------------

        #region UploadIdentitySourceDataForDelete Tests

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForDeleteAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteWithHttpInfoAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForDeleteWithHttpInfoAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_WithNullSessionId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForDeleteAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteWithHttpInfoAsync_WithNullSessionId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForDeleteWithHttpInfoAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_WithNullIdentitySourceId_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForDeleteAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_WithNullSessionId_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForDeleteAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("sessionId");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_WithNullBody_DoesNotThrow()
        {
            // The request body (BulkDeleteRequestBody) is optional
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForDeleteAsync("src-id", "sess-id");

            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_CallsPostEndpoint()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            await api.UploadIdentitySourceDataForDeleteAsync("my-source", "my-session", BuildDeleteBody());

            mockClient.ReceivedPath.Should().Be("/api/v1/identity-sources/{identitySourceId}/sessions/{sessionId}/bulk-delete");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_SetsIdentitySourceIdPathParameter()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            await api.UploadIdentitySourceDataForDeleteAsync("my-source", "my-session", BuildDeleteBody());

            mockClient.ReceivedPathParams.Should().ContainKey("identitySourceId");
            mockClient.ReceivedPathParams["identitySourceId"].Should().Contain("my-source");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_SetsSessionIdPathParameter()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            await api.UploadIdentitySourceDataForDeleteAsync("my-source", "my-session", BuildDeleteBody());

            mockClient.ReceivedPathParams.Should().ContainKey("sessionId");
            mockClient.ReceivedPathParams["sessionId"].Should().Contain("my-session");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteWithHttpInfoAsync_ReturnsAcceptedStatus()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            var response = await api.UploadIdentitySourceDataForDeleteWithHttpInfoAsync("src-id", "sess-id", BuildDeleteBody());

            response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_WithBody_SerializesBody()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            await api.UploadIdentitySourceDataForDeleteAsync("src-id", "sess-id", BuildDeleteBody("ext-del-user"));

            mockClient.ReceivedBody.Should().Contain("ext-del-user",
                "the external ID should be serialized in the request body");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_SetsContentTypeHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            await api.UploadIdentitySourceDataForDeleteAsync("src-id", "sess-id", BuildDeleteBody());

            mockClient.ReceivedHeaders.Should().ContainKey("Content-Type");
            mockClient.ReceivedHeaders["Content-Type"].Should().Contain("application/json");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_SetsAcceptHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            await api.UploadIdentitySourceDataForDeleteAsync("src-id", "sess-id", BuildDeleteBody());

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_WithSswsAuth_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.SSWS, apiKey: "upd-token"));

            await api.UploadIdentitySourceDataForDeleteAsync("src-id", "sess-id", BuildDeleteBody());

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS upd-token");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_WithBearerToken_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.BearerToken, accessToken: "upd-bearer"));

            await api.UploadIdentitySourceDataForDeleteAsync("src-id", "sess-id", BuildDeleteBody());

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer upd-bearer");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteAsync_WithNoAuthConfigured_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient, new Configuration { OktaDomain = BaseUrl });

            await api.UploadIdentitySourceDataForDeleteAsync("src-id", "sess-id", BuildDeleteBody());

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteWithHttpInfoAsync_WhenExceptionFactoryReturnsException_ThrowsIt()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            mockClient
                .Setup(c => c.PostAsync<object>(
                    It.IsAny<string>(), It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<object>(HttpStatusCode.BadRequest, (Multimap<string, string>)null, (object)null));

            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });
            api.ExceptionFactory = (_, response) =>
                response.StatusCode == HttpStatusCode.BadRequest ? new ApiException(400, "Bad Request") : null;

            Func<Task> act = async () => await api.UploadIdentitySourceDataForDeleteWithHttpInfoAsync("src-id", "sess-id", BuildDeleteBody());

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task UploadIdentitySourceDataForDeleteWithHttpInfoAsync_WhenExceptionFactoryIsNull_DoesNotThrow()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));
            api.ExceptionFactory = null;

            Func<Task> act = async () => await api.UploadIdentitySourceDataForDeleteWithHttpInfoAsync("src-id", "sess-id", BuildDeleteBody());

            await act.Should().NotThrowAsync();
        }

        #endregion

        // -----------------------------------------------------------------------
        // UploadIdentitySourceDataForUpsertAsync / WithHttpInfo
        // -----------------------------------------------------------------------

        #region UploadIdentitySourceDataForUpsert Tests

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForUpsertAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertWithHttpInfoAsync_WithNullIdentitySourceId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForUpsertWithHttpInfoAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_WithNullSessionId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForUpsertAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertWithHttpInfoAsync_WithNullSessionId_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForUpsertWithHttpInfoAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_WithNullIdentitySourceId_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForUpsertAsync(null, "sess-id");

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_WithNullSessionId_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForUpsertAsync("src-id", null);

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("sessionId");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_WithNullBody_DoesNotThrow()
        {
            // The request body (BulkUpsertRequestBody) is optional
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));

            Func<Task> act = async () => await api.UploadIdentitySourceDataForUpsertAsync("src-id", "sess-id");

            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_CallsPostEndpoint()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            await api.UploadIdentitySourceDataForUpsertAsync("my-source", "my-session", BuildUpsertBody());

            mockClient.ReceivedPath.Should().Be("/api/v1/identity-sources/{identitySourceId}/sessions/{sessionId}/bulk-upsert");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_SetsIdentitySourceIdPathParameter()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            await api.UploadIdentitySourceDataForUpsertAsync("my-source", "my-session", BuildUpsertBody());

            mockClient.ReceivedPathParams.Should().ContainKey("identitySourceId");
            mockClient.ReceivedPathParams["identitySourceId"].Should().Contain("my-source");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_SetsSessionIdPathParameter()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            await api.UploadIdentitySourceDataForUpsertAsync("my-source", "my-session", BuildUpsertBody());

            mockClient.ReceivedPathParams.Should().ContainKey("sessionId");
            mockClient.ReceivedPathParams["sessionId"].Should().Contain("my-session");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertWithHttpInfoAsync_ReturnsAcceptedStatus()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            var response = await api.UploadIdentitySourceDataForUpsertWithHttpInfoAsync("src-id", "sess-id", BuildUpsertBody());

            response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_WithBody_SerializesBody()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            await api.UploadIdentitySourceDataForUpsertAsync("src-id", "sess-id", BuildUpsertBody("ext-upsert-user"));

            mockClient.ReceivedBody.Should().Contain("ext-upsert-user",
                "the external ID should be serialized in the request body");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_SetsContentTypeHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            await api.UploadIdentitySourceDataForUpsertAsync("src-id", "sess-id", BuildUpsertBody());

            mockClient.ReceivedHeaders.Should().ContainKey("Content-Type");
            mockClient.ReceivedHeaders["Content-Type"].Should().Contain("application/json");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_SetsAcceptHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient);

            await api.UploadIdentitySourceDataForUpsertAsync("src-id", "sess-id", BuildUpsertBody());

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_WithSswsAuth_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.SSWS, apiKey: "ups-token"));

            await api.UploadIdentitySourceDataForUpsertAsync("src-id", "sess-id", BuildUpsertBody());

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS ups-token");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_WithBearerToken_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.BearerToken, accessToken: "ups-bearer"));

            await api.UploadIdentitySourceDataForUpsertAsync("src-id", "sess-id", BuildUpsertBody());

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer ups-bearer");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertAsync_WithNoAuthConfigured_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = CreateApi(mockClient, new Configuration { OktaDomain = BaseUrl });

            await api.UploadIdentitySourceDataForUpsertAsync("src-id", "sess-id", BuildUpsertBody());

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization");
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertWithHttpInfoAsync_WhenExceptionFactoryReturnsException_ThrowsIt()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            mockClient
                .Setup(c => c.PostAsync<object>(
                    It.IsAny<string>(), It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<object>(HttpStatusCode.BadRequest, (Multimap<string, string>)null, (object)null));

            var api = new IdentitySourceApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });
            api.ExceptionFactory = (_, response) =>
                response.StatusCode == HttpStatusCode.BadRequest ? new ApiException(400, "Bad Request") : null;

            Func<Task> act = async () => await api.UploadIdentitySourceDataForUpsertWithHttpInfoAsync("src-id", "sess-id", BuildUpsertBody());

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task UploadIdentitySourceDataForUpsertWithHttpInfoAsync_WhenExceptionFactoryIsNull_DoesNotThrow()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Accepted));
            api.ExceptionFactory = null;

            Func<Task> act = async () => await api.UploadIdentitySourceDataForUpsertWithHttpInfoAsync("src-id", "sess-id", BuildUpsertBody());

            await act.Should().NotThrowAsync();
        }

        #endregion
    }
}
