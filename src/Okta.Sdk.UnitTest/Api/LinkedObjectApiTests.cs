// <copyright file="LinkedObjectApiTests.cs" company="Okta, Inc">
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
    public class LinkedObjectApiTests
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
            // else: no-auth (default SSWS mode but no key supplied -> no header added)

            return config;
        }

        private static LinkedObjectApi CreateApi(IAsynchronousClient client, Configuration config = null)
            => new LinkedObjectApi(client, config ?? new Configuration { OktaDomain = BaseUrl });

        /// <summary>Builds a minimal LinkedObject model.</summary>
        private static LinkedObject BuildLinkedObject(
            string primaryName = "manager",
            string associatedName = "subordinate",
            string primaryTitle = "Manager",
            string associatedTitle = "Subordinate",
            string primaryDesc = "Manager relationship",
            string associatedDesc = "Subordinate relationship")
            => new LinkedObject
            {
                Primary = new LinkedObjectDetails
                {
                    Name = primaryName,
                    Title = primaryTitle,
                    Description = primaryDesc,
                    Type = LinkedObjectDetailsType.USER
                },
                Associated = new LinkedObjectDetails
                {
                    Name = associatedName,
                    Title = associatedTitle,
                    Description = associatedDesc,
                    Type = LinkedObjectDetailsType.USER
                }
            };

        /// <summary>Builds a JSON representation of a single LinkedObject.</summary>
        private static string BuildLinkedObjectJson(
            string primaryName = "manager",
            string associatedName = "subordinate",
            string primaryTitle = null,
            string associatedTitle = null,
            string primaryDesc = null,
            string associatedDesc = null)
            => $@"{{
                ""primary"": {{
                    ""name"": ""{primaryName}"",
                    ""title"": ""{primaryTitle ?? primaryName}"",
                    ""description"": ""{primaryDesc ?? $"{primaryName} relationship"}"",
                    ""type"": ""USER""
                }},
                ""associated"": {{
                    ""name"": ""{associatedName}"",
                    ""title"": ""{associatedTitle ?? associatedName}"",
                    ""description"": ""{associatedDesc ?? $"{associatedName} relationship"}"",
                    ""type"": ""USER""
                }}
            }}";

        /// <summary>Builds a JSON array containing one or more LinkedObject JSON strings.</summary>
        private static string BuildLinkedObjectListJson(params string[] items)
            => $"[{string.Join(",", items)}]";

        // -----------------------------------------------------------------------
        // Constructor
        // -----------------------------------------------------------------------

        #region Constructor Tests

        [Fact]
        public void Constructor_WithNullAsyncClient_ThrowsArgumentNullException()
        {
            Action act = () => new LinkedObjectApi(null, new Configuration { OktaDomain = BaseUrl });

            act.Should().Throw<ArgumentNullException>().WithParameterName("asyncClient");
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var mockClient = new Mock<IAsynchronousClient>();

            Action act = () => new LinkedObjectApi(mockClient.Object, null);

            act.Should().Throw<ArgumentNullException>().WithParameterName("configuration");
        }

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var mockClient = new Mock<IAsynchronousClient>();

            var api = new LinkedObjectApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });

            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithValidParameters_ImplementsILinkedObjectApi()
        {
            var mockClient = new Mock<IAsynchronousClient>();

            var api = new LinkedObjectApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });

            api.Should().BeAssignableTo<ILinkedObjectApi>();
        }

        [Fact]
        public void Constructor_AssignsAsynchronousClient()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            var config = new Configuration { OktaDomain = BaseUrl };

            var api = new LinkedObjectApi(mockClient.Object, config);

            api.AsynchronousClient.Should().BeSameAs(mockClient.Object);
        }

        [Fact]
        public void Constructor_AssignsConfiguration()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            var config = new Configuration { OktaDomain = BaseUrl };

            var api = new LinkedObjectApi(mockClient.Object, config);

            api.Configuration.Should().BeSameAs(config);
        }

        [Fact]
        public void Constructor_SetsDefaultExceptionFactory()
        {
            var mockClient = new Mock<IAsynchronousClient>();

            var api = new LinkedObjectApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });

            api.ExceptionFactory.Should().NotBeNull();
        }

        [Fact]
        public void ExceptionFactory_WithMulticastDelegate_ThrowsInvalidOperationException()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            var api = new LinkedObjectApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });

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
            var api = new LinkedObjectApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });

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
            var api = new LinkedObjectApi(mockClient.Object, new Configuration { OktaDomain = "https://my-org.okta.com" });

            api.GetBasePath().Should().Be("https://my-org.okta.com");
        }

        [Fact]
        public void GetBasePath_WithTrailingSlash_ReturnsValueVerbatim()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            var api = new LinkedObjectApi(mockClient.Object, new Configuration { OktaDomain = "https://my-org.okta.com/" });

            api.GetBasePath().Should().Be("https://my-org.okta.com/");
        }

        #endregion

        // -----------------------------------------------------------------------
        // CreateLinkedObjectDefinitionAsync / WithHttpInfo
        // -----------------------------------------------------------------------

        #region Create Tests

        [Fact]
        public async Task CreateLinkedObjectDefinitionAsync_WithNullBody_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Created));

            Func<Task> act = async () => await api.CreateLinkedObjectDefinitionAsync(null);

            (await act.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionWithHttpInfoAsync_WithNullBody_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Created));

            Func<Task> act = async () => await api.CreateLinkedObjectDefinitionWithHttpInfoAsync(null);

            (await act.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionAsync_WithNullBody_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.Created));

            Func<Task> act = async () => await api.CreateLinkedObjectDefinitionAsync(null);

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("linkedObject");
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionAsync_CallsPostEndpoint()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson(), HttpStatusCode.Created);
            var api = CreateApi(mockClient);

            await api.CreateLinkedObjectDefinitionAsync(BuildLinkedObject());

            mockClient.ReceivedPath.Should().Be("/api/v1/meta/schemas/user/linkedObjects");
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionWithHttpInfoAsync_ReturnsCreatedStatus()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson(), HttpStatusCode.Created);
            var api = CreateApi(mockClient);

            var response = await api.CreateLinkedObjectDefinitionWithHttpInfoAsync(BuildLinkedObject());

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionAsync_ReturnsPrimaryAndAssociatedData()
        {
            var mockClient = new MockAsyncClient(
                BuildLinkedObjectJson("manager", "subordinate", "Manager Title", "Sub Title", "Mgr Desc", "Sub Desc"),
                HttpStatusCode.Created);
            var api = CreateApi(mockClient);

            var result = await api.CreateLinkedObjectDefinitionAsync(BuildLinkedObject("manager", "subordinate"));

            result.Should().NotBeNull();
            result.Primary.Name.Should().Be("manager");
            result.Primary.Title.Should().Be("Manager Title");
            result.Primary.Description.Should().Be("Mgr Desc");
            result.Primary.Type.Should().Be(LinkedObjectDetailsType.USER);
            result.Associated.Name.Should().Be("subordinate");
            result.Associated.Title.Should().Be("Sub Title");
            result.Associated.Description.Should().Be("Sub Desc");
            result.Associated.Type.Should().Be(LinkedObjectDetailsType.USER);
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionWithHttpInfoAsync_ReturnsBothPrimaryAndAssociated()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson("lead", "contributor"), HttpStatusCode.Created);
            var api = CreateApi(mockClient);

            var response = await api.CreateLinkedObjectDefinitionWithHttpInfoAsync(BuildLinkedObject("lead", "contributor"));

            response.Data.Primary.Name.Should().Be("lead");
            response.Data.Associated.Name.Should().Be("contributor");
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionAsync_DelegatesDataFromWithHttpInfo()
        {
            // CreateLinkedObjectDefinitionAsync must return WithHttpInfo.Data
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson("mgr", "sub"), HttpStatusCode.Created);
            var api = CreateApi(mockClient);

            var result = await api.CreateLinkedObjectDefinitionAsync(BuildLinkedObject("mgr", "sub"));
            var httpResult = await CreateApi(new MockAsyncClient(BuildLinkedObjectJson("mgr", "sub"), HttpStatusCode.Created))
                .CreateLinkedObjectDefinitionWithHttpInfoAsync(BuildLinkedObject("mgr", "sub"));

            result.Primary.Name.Should().Be(httpResult.Data.Primary.Name);
            result.Associated.Name.Should().Be(httpResult.Data.Associated.Name);
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionAsync_SerializesBodyInRequest()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson("mgr", "sub"), HttpStatusCode.Created);
            var api = CreateApi(mockClient);

            await api.CreateLinkedObjectDefinitionAsync(BuildLinkedObject("mgr", "sub"));

            mockClient.ReceivedBody.Should().Contain("mgr");
            mockClient.ReceivedBody.Should().Contain("sub");
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionAsync_SetsContentTypeHeader()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson(), HttpStatusCode.Created);
            var api = CreateApi(mockClient);

            await api.CreateLinkedObjectDefinitionAsync(BuildLinkedObject());

            mockClient.ReceivedHeaders.Should().ContainKey("Content-Type");
            mockClient.ReceivedHeaders["Content-Type"].Should().Contain("application/json");
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionAsync_SetsAcceptHeader()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson(), HttpStatusCode.Created);
            var api = CreateApi(mockClient);

            await api.CreateLinkedObjectDefinitionAsync(BuildLinkedObject());

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionAsync_WithSswsAuth_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson(), HttpStatusCode.Created);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.SSWS, apiKey: "create-token"));

            await api.CreateLinkedObjectDefinitionAsync(BuildLinkedObject());

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS create-token");
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionAsync_WithBearerToken_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson(), HttpStatusCode.Created);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.BearerToken, accessToken: "create-bearer"));

            await api.CreateLinkedObjectDefinitionAsync(BuildLinkedObject());

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer create-bearer");
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionAsync_WithNoAuthConfigured_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson(), HttpStatusCode.Created);
            var api = CreateApi(mockClient, new Configuration { OktaDomain = BaseUrl });

            await api.CreateLinkedObjectDefinitionAsync(BuildLinkedObject());

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization",
                "when no auth mode is configured no Authorization header must be added");
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionWithHttpInfoAsync_WhenExceptionFactoryReturnsException_ThrowsIt()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            mockClient
                .Setup(c => c.PostAsync<LinkedObject>(
                    It.IsAny<string>(), It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<LinkedObject>(HttpStatusCode.Conflict, (Multimap<string, string>)null, (LinkedObject)null));

            var api = new LinkedObjectApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });
            api.ExceptionFactory = (_, response) =>
                response.StatusCode == HttpStatusCode.Conflict ? new ApiException(409, "Conflict") : null;

            Func<Task> act = async () => await api.CreateLinkedObjectDefinitionWithHttpInfoAsync(BuildLinkedObject());

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(409);
        }

        [Fact]
        public async Task CreateLinkedObjectDefinitionWithHttpInfoAsync_WhenExceptionFactoryIsNull_DoesNotThrow()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson(), HttpStatusCode.Created);
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            Func<Task> act = async () => await api.CreateLinkedObjectDefinitionWithHttpInfoAsync(BuildLinkedObject());

            await act.Should().NotThrowAsync();
        }

        #endregion

        // -----------------------------------------------------------------------
        // DeleteLinkedObjectDefinitionAsync / WithHttpInfo
        // -----------------------------------------------------------------------

        #region Delete Tests

        [Fact]
        public async Task DeleteLinkedObjectDefinitionAsync_WithNullName_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.NoContent));

            Func<Task> act = async () => await api.DeleteLinkedObjectDefinitionAsync(null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionWithHttpInfoAsync_WithNullName_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.NoContent));

            Func<Task> act = async () => await api.DeleteLinkedObjectDefinitionWithHttpInfoAsync(null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionAsync_WithNullName_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.NoContent));

            Func<Task> act = async () => await api.DeleteLinkedObjectDefinitionAsync(null);

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("linkedObjectName");
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionAsync_ByPrimaryName_CallsCorrectEndpoint()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedPath.Should().Be("/api/v1/meta/schemas/user/linkedObjects/{linkedObjectName}");
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionAsync_ByPrimaryName_SetsPathParameter()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedPathParams.Should().ContainKey("linkedObjectName");
            mockClient.ReceivedPathParams["linkedObjectName"].Should().Contain("manager");
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionAsync_ByAssociatedName_SetsPathParameter()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteLinkedObjectDefinitionAsync("subordinate");

            mockClient.ReceivedPathParams.Should().ContainKey("linkedObjectName");
            mockClient.ReceivedPathParams["linkedObjectName"].Should().Contain("subordinate");
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionWithHttpInfoAsync_ReturnsNoContentStatus()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var response = await api.DeleteLinkedObjectDefinitionWithHttpInfoAsync("manager");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionAsync_DelegatesTo_WithHttpInfo()
        {
            // DeleteLinkedObjectDefinitionAsync must not throw when the underlying call succeeds
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            Func<Task> act = async () => await api.DeleteLinkedObjectDefinitionAsync("manager");

            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionAsync_SetsAcceptHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionAsync_DoesNotSetContentTypeHeader()
        {
            // DELETE carries no request body
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedHeaders.Should().NotContainKey("Content-Type",
                "DELETE has no request body so Content-Type must not be added");
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionAsync_WithSswsAuth_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.SSWS, apiKey: "del-token"));

            await api.DeleteLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS del-token");
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionAsync_WithBearerToken_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.BearerToken, accessToken: "del-bearer"));

            await api.DeleteLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer del-bearer");
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionAsync_WithNoAuthConfigured_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient, new Configuration { OktaDomain = BaseUrl });

            await api.DeleteLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization");
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionWithHttpInfoAsync_WhenExceptionFactoryReturnsException_ThrowsIt()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            mockClient
                .Setup(c => c.DeleteAsync<object>(
                    It.IsAny<string>(), It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<object>(HttpStatusCode.NotFound, (Multimap<string, string>)null, (object)null));

            var api = new LinkedObjectApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });
            api.ExceptionFactory = (_, response) =>
                response.StatusCode == HttpStatusCode.NotFound ? new ApiException(404, "Not Found") : null;

            Func<Task> act = async () => await api.DeleteLinkedObjectDefinitionWithHttpInfoAsync("manager");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task DeleteLinkedObjectDefinitionWithHttpInfoAsync_WhenExceptionFactoryIsNull_DoesNotThrow()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            Func<Task> act = async () => await api.DeleteLinkedObjectDefinitionWithHttpInfoAsync("manager");

            await act.Should().NotThrowAsync();
        }

        #endregion

        // -----------------------------------------------------------------------
        // GetLinkedObjectDefinitionAsync / WithHttpInfo
        // -----------------------------------------------------------------------

        #region Get Tests

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_WithNullName_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.OK));

            Func<Task> act = async () => await api.GetLinkedObjectDefinitionAsync(null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionWithHttpInfoAsync_WithNullName_ThrowsApiException400()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.OK));

            Func<Task> act = async () => await api.GetLinkedObjectDefinitionWithHttpInfoAsync(null);

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_WithNullName_ExceptionMessageMentionsParameter()
        {
            var api = CreateApi(new MockAsyncClient("", HttpStatusCode.OK));

            Func<Task> act = async () => await api.GetLinkedObjectDefinitionAsync(null);

            (await act.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("linkedObjectName");
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_ByPrimaryName_CallsCorrectEndpoint()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson());
            var api = CreateApi(mockClient);

            await api.GetLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedPath.Should().Be("/api/v1/meta/schemas/user/linkedObjects/{linkedObjectName}");
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_ByPrimaryName_SetsPathParameter()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson());
            var api = CreateApi(mockClient);

            await api.GetLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedPathParams.Should().ContainKey("linkedObjectName");
            mockClient.ReceivedPathParams["linkedObjectName"].Should().Contain("manager");
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_ByAssociatedName_CallsCorrectEndpoint()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson());
            var api = CreateApi(mockClient);

            await api.GetLinkedObjectDefinitionAsync("subordinate");

            mockClient.ReceivedPath.Should().Be("/api/v1/meta/schemas/user/linkedObjects/{linkedObjectName}");
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_ByAssociatedName_SetsPathParameter()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson());
            var api = CreateApi(mockClient);

            await api.GetLinkedObjectDefinitionAsync("subordinate");

            mockClient.ReceivedPathParams.Should().ContainKey("linkedObjectName");
            mockClient.ReceivedPathParams["linkedObjectName"].Should().Contain("subordinate");
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionWithHttpInfoAsync_ByPrimaryName_ReturnsOkStatus()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson());
            var api = CreateApi(mockClient);

            var response = await api.GetLinkedObjectDefinitionWithHttpInfoAsync("manager");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionWithHttpInfoAsync_ByAssociatedName_ReturnsOkStatus()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson());
            var api = CreateApi(mockClient);

            var response = await api.GetLinkedObjectDefinitionWithHttpInfoAsync("subordinate");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_ReturnsPrimaryAndAssociatedData()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson("caseworker", "client"));
            var api = CreateApi(mockClient);

            var result = await api.GetLinkedObjectDefinitionAsync("caseworker");

            result.Should().NotBeNull();
            result.Primary.Name.Should().Be("caseworker");
            result.Associated.Name.Should().Be("client");
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionWithHttpInfoAsync_ReturnsFullResponseFields()
        {
            var mockClient = new MockAsyncClient(
                BuildLinkedObjectJson("lead", "contributor", "Team Lead", "Contributor", "Lead desc", "Contrib desc"));
            var api = CreateApi(mockClient);

            var response = await api.GetLinkedObjectDefinitionWithHttpInfoAsync("lead");

            response.Data.Primary.Name.Should().Be("lead");
            response.Data.Primary.Title.Should().Be("Team Lead");
            response.Data.Primary.Description.Should().Be("Lead desc");
            response.Data.Primary.Type.Should().Be(LinkedObjectDetailsType.USER);
            response.Data.Associated.Name.Should().Be("contributor");
            response.Data.Associated.Title.Should().Be("Contributor");
            response.Data.Associated.Description.Should().Be("Contrib desc");
            response.Data.Associated.Type.Should().Be(LinkedObjectDetailsType.USER);
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_DelegatesDataFromWithHttpInfo()
        {
            var json = BuildLinkedObjectJson("rep", "customer");
            var mockClient1 = new MockAsyncClient(json);
            var mockClient2 = new MockAsyncClient(json);

            var result = await CreateApi(mockClient1).GetLinkedObjectDefinitionAsync("rep");
            var httpResult = await CreateApi(mockClient2).GetLinkedObjectDefinitionWithHttpInfoAsync("rep");

            result.Primary.Name.Should().Be(httpResult.Data.Primary.Name);
            result.Associated.Name.Should().Be(httpResult.Data.Associated.Name);
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_SetsAcceptHeader()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson());
            var api = CreateApi(mockClient);

            await api.GetLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_DoesNotSetContentTypeHeader()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson());
            var api = CreateApi(mockClient);

            await api.GetLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedHeaders.Should().NotContainKey("Content-Type",
                "GET has no request body so Content-Type must not be added");
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_WithSswsAuth_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson());
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.SSWS, apiKey: "get-token"));

            await api.GetLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS get-token");
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_WithBearerToken_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson());
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.BearerToken, accessToken: "get-bearer"));

            await api.GetLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer get-bearer");
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionAsync_WithNoAuthConfigured_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson());
            var api = CreateApi(mockClient, new Configuration { OktaDomain = BaseUrl });

            await api.GetLinkedObjectDefinitionAsync("manager");

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization");
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionWithHttpInfoAsync_WhenExceptionFactoryReturnsException_ThrowsIt()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            mockClient
                .Setup(c => c.GetAsync<LinkedObject>(
                    It.IsAny<string>(), It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<LinkedObject>(HttpStatusCode.NotFound, (Multimap<string, string>)null, (LinkedObject)null));

            var api = new LinkedObjectApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });
            api.ExceptionFactory = (_, response) =>
                response.StatusCode == HttpStatusCode.NotFound ? new ApiException(404, "Not Found") : null;

            Func<Task> act = async () => await api.GetLinkedObjectDefinitionWithHttpInfoAsync("manager");

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionWithHttpInfoAsync_WhenExceptionFactoryIsNull_DoesNotThrow()
        {
            var mockClient = new MockAsyncClient(BuildLinkedObjectJson());
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            Func<Task> act = async () => await api.GetLinkedObjectDefinitionWithHttpInfoAsync("manager");

            await act.Should().NotThrowAsync();
        }

        #endregion

        // -----------------------------------------------------------------------
        // ListLinkedObjectDefinitions  (collection client)
        // -----------------------------------------------------------------------

        #region ListLinkedObjectDefinitions Tests

        [Fact]
        public void ListLinkedObjectDefinitions_ReturnsNonNullCollectionClient()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            var result = api.ListLinkedObjectDefinitions();

            result.Should().NotBeNull();
        }

        [Fact]
        public void ListLinkedObjectDefinitions_ImplementsIOktaCollectionClient()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            var result = api.ListLinkedObjectDefinitions();

            result.Should().BeAssignableTo<IOktaCollectionClient<LinkedObject>>();
        }

        [Fact]
        public void ListLinkedObjectDefinitions_WithSswsAuth_DoesNotThrowOnCreation()
        {
            // The collection client defers HTTP calls to enumeration; creation must always succeed.
            var api = CreateApi(
                new MockAsyncClient("[]"),
                CreateConfig(AuthorizationMode.SSWS, apiKey: "list-token"));

            Action act = () => api.ListLinkedObjectDefinitions();

            act.Should().NotThrow();
        }

        [Fact]
        public void ListLinkedObjectDefinitions_WithBearerToken_DoesNotThrowOnCreation()
        {
            var api = CreateApi(
                new MockAsyncClient("[]"),
                CreateConfig(AuthorizationMode.BearerToken, accessToken: "list-bearer"));

            Action act = () => api.ListLinkedObjectDefinitions();

            act.Should().NotThrow();
        }

        [Fact]
        public void ListLinkedObjectDefinitions_CalledMultipleTimes_ReturnsNewCollectionClientEachTime()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            var result1 = api.ListLinkedObjectDefinitions();
            var result2 = api.ListLinkedObjectDefinitions();

            result1.Should().NotBeSameAs(result2);
        }

        #endregion

        // -----------------------------------------------------------------------
        // ListLinkedObjectDefinitionsWithHttpInfoAsync
        // -----------------------------------------------------------------------

        #region ListWithHttpInfo Tests

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_CallsCorrectEndpoint()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient);

            await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            mockClient.ReceivedPath.Should().Be("/api/v1/meta/schemas/user/linkedObjects");
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_ReturnsOkStatus()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            var response = await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_EmptyListResponse_ReturnsEmptyCollection()
        {
            var api = CreateApi(new MockAsyncClient("[]"));

            var response = await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            response.Data.Should().NotBeNull();
            response.Data.Should().BeEmpty();
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_SingleDefinition_ReturnsOneItem()
        {
            var api = CreateApi(new MockAsyncClient(BuildLinkedObjectListJson(BuildLinkedObjectJson("rep", "customer"))));

            var response = await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            response.Data.Should().HaveCount(1);
            response.Data[0].Primary.Name.Should().Be("rep");
            response.Data[0].Associated.Name.Should().Be("customer");
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_TwoDefinitions_ReturnsBoth()
        {
            var json = BuildLinkedObjectListJson(
                BuildLinkedObjectJson("manager", "subordinate"),
                BuildLinkedObjectJson("lead", "contributor"));
            var api = CreateApi(new MockAsyncClient(json));

            var response = await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            response.Data.Should().HaveCount(2);
            response.Data[0].Primary.Name.Should().Be("manager");
            response.Data[1].Primary.Name.Should().Be("lead");
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_EachDefinitionHasCorrectType()
        {
            var json = BuildLinkedObjectListJson(BuildLinkedObjectJson("mgr", "sub"));
            var api = CreateApi(new MockAsyncClient(json));

            var response = await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            response.Data[0].Primary.Type.Should().Be(LinkedObjectDetailsType.USER);
            response.Data[0].Associated.Type.Should().Be(LinkedObjectDetailsType.USER);
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_SetsAcceptHeader()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient);

            await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_DoesNotSetContentTypeHeader()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient);

            await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            mockClient.ReceivedHeaders.Should().NotContainKey("Content-Type");
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_WithSswsAuth_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.SSWS, apiKey: "list-token"));

            await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS list-token");
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_WithBearerToken_SetsAuthorizationHeader()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient, CreateConfig(AuthorizationMode.BearerToken, accessToken: "list-bearer"));

            await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer list-bearer");
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_WithNoAuthConfigured_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient, new Configuration { OktaDomain = BaseUrl });

            await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization",
                "when no auth mode is configured no Authorization header must be added");
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_WhenExceptionFactoryReturnsException_ThrowsIt()
        {
            var mockClient = new Mock<IAsynchronousClient>();
            mockClient
                .Setup(c => c.GetAsync<List<LinkedObject>>(
                    It.IsAny<string>(), It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<List<LinkedObject>>(HttpStatusCode.Forbidden, (Multimap<string, string>)null, (List<LinkedObject>)null));

            var api = new LinkedObjectApi(mockClient.Object, new Configuration { OktaDomain = BaseUrl });
            api.ExceptionFactory = (_, response) =>
                response.StatusCode == HttpStatusCode.Forbidden ? new ApiException(403, "Forbidden") : null;

            Func<Task> act = async () => await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            (await act.Should().ThrowAsync<ApiException>()).Which.ErrorCode.Should().Be(403);
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_WhenExceptionFactoryIsNull_DoesNotThrow()
        {
            var api = CreateApi(new MockAsyncClient("[]"));
            api.ExceptionFactory = null;

            Func<Task> act = async () => await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task ListLinkedObjectDefinitionsWithHttpInfoAsync_WhenExceptionFactoryReturnsNull_DoesNotThrow()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = CreateApi(mockClient);
            // factory that always returns null = no exception
            api.ExceptionFactory = (_, _) => null;

            Func<Task> act = async () => await api.ListLinkedObjectDefinitionsWithHttpInfoAsync();

            await act.Should().NotThrowAsync();
        }

        #endregion
    }
}
