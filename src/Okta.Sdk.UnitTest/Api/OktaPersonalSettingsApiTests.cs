// <copyright file="OktaPersonalSettingsApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
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
    public class OktaPersonalSettingsApiTests
    {
        private const string BaseUrl = "https://test.okta.com";

        // ── Shared helpers ───────────────────────────────────────────────────

        private static OktaPersonalSettingsApi CreateApi(MockAsyncClient client)
            => new OktaPersonalSettingsApi(client, new Configuration { BasePath = BaseUrl });

        private static OktaPersonalSettingsApi CreateApiWithConfig(MockAsyncClient client, Configuration config)
            => new OktaPersonalSettingsApi(client, config);

        /// <summary>JSON representing a PersonalAppsBlockList with <paramref name="domains"/>.</summary>
        private static string BlockListJson(params string[] domains)
        {
            var quoted = string.Join(",", System.Array.ConvertAll(domains, d => $@"""{d}"""));
            return $@"{{""domains"":[{quoted}]}}";
        }

        /// <summary>JSON representing a PersonalAppsBlockList with an empty domains array.</summary>
        private static string EmptyBlockListJson() => @"{""domains"":[]}";

        /// <summary>Error-body JSON returned by the server for 4xx responses.</summary>
        private static string ErrorBodyJson(string code, string summary)
            => $@"{{""errorCode"":""{code}"",""errorSummary"":""{summary}""}}";

        /// <summary>Empty body string returned for 204 No Content responses.</summary>
        private const string NoContentBody = "null";

        // ────────────────────────────────────────────────────────────────────
        #region Constructor and Property Tests

        [Fact]
        public void Constructor_WithNullAsyncClient_ThrowsArgumentNullException()
        {
            var act = () => new OktaPersonalSettingsApi(
                (IAsynchronousClient)null,
                new Configuration { BasePath = BaseUrl });

            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("asyncClient");
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new OktaPersonalSettingsApi(
                new MockAsyncClient(EmptyBlockListJson()),
                (IReadableConfiguration)null);

            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("configuration");
        }

        [Fact]
        public void Constructor_SetsAsynchronousClientProperty()
        {
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(mockClient);

            api.AsynchronousClient.Should().BeSameAs(mockClient,
                "the constructor must store the provided IAsynchronousClient");
        }

        [Fact]
        public void Constructor_SetsConfigurationProperty()
        {
            var config = new Configuration { BasePath = BaseUrl };
            var api = new OktaPersonalSettingsApi(new MockAsyncClient(EmptyBlockListJson()), config);

            api.Configuration.Should().BeSameAs(config,
                "the constructor must store the provided IReadableConfiguration");
        }

        [Fact]
        public void GetBasePath_ReturnsOktaDomainFromConfiguration()
        {
            var api = CreateApi(new MockAsyncClient(EmptyBlockListJson()));

            api.GetBasePath().Should().Be(BaseUrl);
        }

        [Fact]
        public void AsynchronousClient_CanBeReassigned()
        {
            var original = new MockAsyncClient(EmptyBlockListJson());
            var replacement = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(original);

            api.AsynchronousClient = replacement;

            api.AsynchronousClient.Should().BeSameAs(replacement);
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ExceptionFactory Property Tests

        [Fact]
        public void ExceptionFactory_DefaultIsNotNull()
        {
            var api = CreateApi(new MockAsyncClient(EmptyBlockListJson()));

            api.ExceptionFactory.Should().NotBeNull(
                "the constructor assigns DefaultExceptionFactory as the initial value");
        }

        [Fact]
        public void ExceptionFactory_CanBeSetToNull()
        {
            var api = CreateApi(new MockAsyncClient(EmptyBlockListJson()));

            api.ExceptionFactory = null;

            api.ExceptionFactory.Should().BeNull();
        }

        [Fact]
        public void ExceptionFactory_CanBeReplacedWithCustomFactory()
        {
            var api = CreateApi(new MockAsyncClient(EmptyBlockListJson()));
            ExceptionFactory noOpFactory = (_, _) => null;

            api.ExceptionFactory = noOpFactory;

            api.ExceptionFactory.Should().BeSameAs(noOpFactory);
        }

        [Fact]
        public void ExceptionFactory_MulticastDelegate_ThrowsInvalidOperationExceptionOnGet()
        {
            var api = CreateApi(new MockAsyncClient(EmptyBlockListJson()));
            api.ExceptionFactory += (_, _) => null;

            var act = () => { _ = api.ExceptionFactory; };

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("*Multicast*",
                    "the SDK explicitly forbids multicast ExceptionFactory delegates");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ListPersonalAppsExportBlockListAsync Tests

        [Fact]
        public async Task ListPersonalAppsExportBlockListAsync_ReturnsPersonalAppsBlockList_NotApiResponseWrapper()
        {
            var mockClient = new MockAsyncClient(BlockListJson("yahoo.com", "google.com"));
            var api = CreateApi(mockClient);

            var result = await api.ListPersonalAppsExportBlockListAsync();

            result.Should().NotBeNull()
                .And.BeOfType<PersonalAppsBlockList>(
                    "the plain variant must return PersonalAppsBlockList, not the raw ApiResponse");
        }

        [Fact]
        public async Task ListPersonalAppsExportBlockListAsync_WithNonEmptyDomains_DeserializesAllDomains()
        {
            var mockClient = new MockAsyncClient(BlockListJson("yahoo.com", "google.com", "hotmail.com"));
            var api = CreateApi(mockClient);

            var result = await api.ListPersonalAppsExportBlockListAsync();

            result.Domains.Should().HaveCount(3);
            result.Domains.Should().Contain("yahoo.com");
            result.Domains.Should().Contain("google.com");
            result.Domains.Should().Contain("hotmail.com");
        }

        [Fact]
        public async Task ListPersonalAppsExportBlockListAsync_WithEmptyDomains_ReturnsEmptyList()
        {
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(mockClient);

            var result = await api.ListPersonalAppsExportBlockListAsync();

            result.Should().NotBeNull();
            result.Domains.Should().NotBeNull()
                .And.BeEmpty("an empty JSON array must deserialize as an empty List, not null");
        }

        [Fact]
        public async Task ListPersonalAppsExportBlockListAsync_ReturnsSingleDomain_Correctly()
        {
            var mockClient = new MockAsyncClient(BlockListJson("only.example.com"));
            var api = CreateApi(mockClient);

            var result = await api.ListPersonalAppsExportBlockListAsync();

            result.Domains.Should().ContainSingle()
                .Which.Should().Be("only.example.com");
        }

        [Fact]
        public async Task ListPersonalAppsExportBlockListAsync_ReturnsDataPropertyOfApiResponse()
        {
            // Verifies the plain variant unwraps .Data rather than returning the ApiResponse wrapper
            var mockClient = new MockAsyncClient(BlockListJson("unwrap.example.com"));
            var api = CreateApi(mockClient);

            var result = await api.ListPersonalAppsExportBlockListAsync();

            result.Domains.Should().Contain("unwrap.example.com",
                "ListPersonalAppsExportBlockListAsync must return exactly the .Data of the response");
        }

        [Fact]
        public async Task ListPersonalAppsExportBlockListAsync_With401Response_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token provided"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);

            var act = async () => await api.ListPersonalAppsExportBlockListAsync();

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 401,
                    "DefaultExceptionFactory must throw ApiException(401) for HTTP 401");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ListPersonalAppsExportBlockListWithHttpInfoAsync – Request Construction

        [Fact]
        public async Task ListWithHttpInfoAsync_CallsCorrectGetPath()
        {
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(mockClient);

            await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            mockClient.ReceivedPath.Should().Be("/okta-personal-settings/api/v1/export-blocklists");
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_SetsAcceptHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(mockClient);

            await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_DoesNotSetContentTypeHeader()
        {
            // GET with no body must not send Content-Type
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(mockClient);

            await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            mockClient.ReceivedHeaders.Should().NotContainKey("Content-Type",
                "a GET request with no body must not set Content-Type");
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_SendsNoQueryParameters()
        {
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(mockClient);

            await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            mockClient.ReceivedQueryParams.Should().BeEmpty(
                "GET export-blocklists has no documented query parameters");
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_SendsNoPathParameters()
        {
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(mockClient);

            await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            mockClient.ReceivedPathParams.Should().BeEmpty(
                "the export-blocklists path has no {variables} requiring substitution");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ListPersonalAppsExportBlockListWithHttpInfoAsync – Response Deserialization

        [Fact]
        public async Task ListWithHttpInfoAsync_Returns200WithDataPopulated()
        {
            var mockClient = new MockAsyncClient(BlockListJson("a.com"), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            var response = await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_DataIsPersonalAppsBlockList()
        {
            var mockClient = new MockAsyncClient(BlockListJson("type.example.com"));
            var api = CreateApi(mockClient);

            var response = await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            response.Data.Should().BeOfType<PersonalAppsBlockList>();
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_DeserializesDomainsArray_WithMultipleEntries()
        {
            var json = BlockListJson("yahoo.com", "gmail.com", "outlook.com");
            var mockClient = new MockAsyncClient(json);
            var api = CreateApi(mockClient);

            var response = await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            response.Data.Domains.Should().HaveCount(3);
            response.Data.Domains.Should().Contain("yahoo.com");
            response.Data.Domains.Should().Contain("gmail.com");
            response.Data.Domains.Should().Contain("outlook.com");
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_DeserializesEmptyDomainsArray()
        {
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(mockClient);

            var response = await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            response.Data.Domains.Should().NotBeNull()
                .And.BeEmpty();
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_DefaultFactory_With401_ThrowsApiException401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token provided"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);

            var act = async () => await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 401,
                    "DefaultExceptionFactory maps HTTP 401 → ApiException.ErrorCode 401");
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_DefaultFactory_With403_ThrowsApiException403()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000006", "You do not have permission"), HttpStatusCode.Forbidden);
            var api = CreateApi(mockClient);

            var act = async () => await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 403);
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_DefaultFactory_With429_ThrowsApiException429()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000047", "API call exceeded rate limit"), HttpStatusCode.TooManyRequests);
            var api = CreateApi(mockClient);

            var act = async () => await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 429);
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_NullExceptionFactory_DoesNotThrowFor401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            var response = await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized,
                "with a null ExceptionFactory the raw ApiResponse is returned even for 4xx");
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_CustomFactory_IsCalledWithCorrectOperationName()
        {
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(mockClient);
            string capturedName = null;
            api.ExceptionFactory = (name, _) =>
            {
                capturedName = name;
                return null;
            };

            await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            capturedName.Should().Be("ListPersonalAppsExportBlockList",
                "ExceptionFactory must be called with the SDK operation name, not the C# method name");
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_CustomFactory_ReturningNull_DoesNotThrow()
        {
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(mockClient);
            api.ExceptionFactory = (_, _) => null;

            var act = async () => await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            await act.Should().NotThrowAsync(
                "when ExceptionFactory returns null no exception must be thrown");
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_CustomFactory_CanReturnCustomExceptionType()
        {
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(mockClient);
            var customEx = new InvalidOperationException("custom error");
            api.ExceptionFactory = (_, _) => customEx;

            var act = async () => await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("custom error",
                    "the exception returned by ExceptionFactory must be propagated as-is");
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_MulticastExceptionFactory_ThrowsInvalidOperationException()
        {
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = CreateApi(mockClient);
            api.ExceptionFactory += (_, _) => null;

            var act = async () => await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*Multicast*");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ReplaceBlockedEmailDomainsAsync Tests

        [Fact]
        public async Task ReplaceBlockedEmailDomainsAsync_WithNullBody_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceBlockedEmailDomainsAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400,
                    "the SDK guard throws ApiException(400) before any HTTP call when body is null");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsAsync_WithNullBody_ExceptionMessageContainsParameterName()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceBlockedEmailDomainsAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*personalAppsBlockList*");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsAsync_WithNullBody_DoesNotCallHttpClient()
        {
            // Verify the guard fires before the HTTP call — ReceivedPath will be null if not called
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            try { await api.ReplaceBlockedEmailDomainsAsync(null); } catch (ApiException) { }

            mockClient.ReceivedPath.Should().BeNull(
                "when the null guard throws the HTTP client must never be called");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsAsync_WithValidBody_CompletesWithoutThrowing()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceBlockedEmailDomainsAsync(
                new PersonalAppsBlockList { Domains = new List<string> { "test.example.com" } });

            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsAsync_WithEmptyDomains_CompletesWithoutThrowing()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceBlockedEmailDomainsAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            await act.Should().NotThrowAsync("an empty Domains list is valid; it clears the blocklist");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ReplaceBlockedEmailDomainsWithHttpInfoAsync – Request Construction

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_WithNullBody_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400,
                    "the guard lives in the WithHttpInfo variant and must throw ApiException(400)");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_WithNullBody_MessageContainsParameterName()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*personalAppsBlockList*");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_CallsCorrectPutPath()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            mockClient.ReceivedPath.Should().Be("/okta-personal-settings/api/v1/export-blocklists");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_SetsContentTypeHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            mockClient.ReceivedHeaders.Should().ContainKey("Content-Type");
            mockClient.ReceivedHeaders["Content-Type"].Should().Contain("application/json");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_SetsAcceptHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_SerializesDomainsListInBody()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList
                {
                    Domains = new List<string> { "alpha.example.com", "beta.example.com" }
                });

            mockClient.ReceivedBody.Should().Contain("domains");
            mockClient.ReceivedBody.Should().Contain("alpha.example.com");
            mockClient.ReceivedBody.Should().Contain("beta.example.com");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_WithEmptyDomains_SerializesEmptyArray()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            mockClient.ReceivedBody.Should().Contain("domains",
                "the domains field must still appear even when the list is empty");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_SendsNoQueryParameters()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            mockClient.ReceivedQueryParams.Should().BeEmpty(
                "PUT export-blocklists has no documented query parameters");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_SendsNoPathParameters()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            mockClient.ReceivedPathParams.Should().BeEmpty(
                "the export-blocklists path has no {variables} requiring substitution");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_Returns204NoContent()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var response = await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string> { "sdk.example.com" } });

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent,
                "a successful PUT to export-blocklists returns 204 No Content");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_DefaultFactory_With401_ThrowsApiException401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 401);
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_DefaultFactory_With403_ThrowsApiException403()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000006", "Forbidden"), HttpStatusCode.Forbidden);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 403);
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_DefaultFactory_With429_ThrowsApiException429()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000047", "Rate limit"), HttpStatusCode.TooManyRequests);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 429);
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_NullExceptionFactory_DoesNotThrowFor401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            var response = await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized,
                "with a null ExceptionFactory the raw 4xx ApiResponse is returned without throwing");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_CustomFactory_IsCalledWithCorrectOperationName()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);
            string capturedName = null;
            api.ExceptionFactory = (name, _) =>
            {
                capturedName = name;
                return null;
            };

            await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            capturedName.Should().Be("ReplaceBlockedEmailDomains",
                "ExceptionFactory must be called with the SDK operation name");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_MulticastExceptionFactory_ThrowsInvalidOperationException()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);
            api.ExceptionFactory += (_, _) => null;

            var act = async () => await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*Multicast*");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ReplaceOktaPersonalAdminSettingsAsync Tests

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsAsync_WithNullBody_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceOktaPersonalAdminSettingsAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400,
                    "the SDK guard throws ApiException(400) before any HTTP call when body is null");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsAsync_WithNullBody_ExceptionMessageContainsParameterName()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceOktaPersonalAdminSettingsAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*oktaPersonalAdminFeatureSettings*");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsAsync_WithNullBody_DoesNotCallHttpClient()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            try { await api.ReplaceOktaPersonalAdminSettingsAsync(null); } catch (ApiException) { }

            mockClient.ReceivedPath.Should().BeNull(
                "when the null guard throws the HTTP client must never be called");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsAsync_WithBothFeaturesEnabled_CompletesWithoutThrowing()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceOktaPersonalAdminSettingsAsync(
                new OktaPersonalAdminFeatureSettings
                {
                    EnableExportApps = true,
                    EnableEnduserEntryPoints = true
                });

            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsAsync_WithBothFeaturesDisabled_CompletesWithoutThrowing()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceOktaPersonalAdminSettingsAsync(
                new OktaPersonalAdminFeatureSettings
                {
                    EnableExportApps = false,
                    EnableEnduserEntryPoints = false
                });

            await act.Should().NotThrowAsync("disabling both features is a valid request");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync – Request Construction

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_WithNullBody_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400);
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_WithNullBody_MessageContainsParameterName()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*oktaPersonalAdminFeatureSettings*");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_CallsCorrectPutPath()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            mockClient.ReceivedPath.Should().Be("/okta-personal-settings/api/v1/edit-feature");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_SetsContentTypeHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            mockClient.ReceivedHeaders.Should().ContainKey("Content-Type");
            mockClient.ReceivedHeaders["Content-Type"].Should().Contain("application/json");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_SetsAcceptHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_SerializesEnableExportAppsInBody()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings
                {
                    EnableExportApps = true,
                    EnableEnduserEntryPoints = false
                });

            mockClient.ReceivedBody.Should().Contain("enableExportApps");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_SerializesEnableEnduserEntryPointsInBody()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings
                {
                    EnableExportApps = false,
                    EnableEnduserEntryPoints = true
                });

            mockClient.ReceivedBody.Should().Contain("enableEnduserEntryPoints");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_BothFieldsTrueSerializedInBody()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings
                {
                    EnableExportApps = true,
                    EnableEnduserEntryPoints = true
                });

            mockClient.ReceivedBody.Should().Contain("enableExportApps");
            mockClient.ReceivedBody.Should().Contain("enableEnduserEntryPoints");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_SendsNoQueryParameters()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            mockClient.ReceivedQueryParams.Should().BeEmpty(
                "PUT edit-feature has no documented query parameters");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_SendsNoPathParameters()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            mockClient.ReceivedPathParams.Should().BeEmpty(
                "the edit-feature path has no {variables} requiring substitution");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_Returns204NoContent()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var response = await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings
                {
                    EnableExportApps = true,
                    EnableEnduserEntryPoints = true
                });

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent,
                "a successful PUT to edit-feature returns 204 No Content");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_DefaultFactory_With401_ThrowsApiException401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 401);
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_DefaultFactory_With403_ThrowsApiException403()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000006", "Forbidden"), HttpStatusCode.Forbidden);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 403);
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_DefaultFactory_With429_ThrowsApiException429()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000047", "Rate limit"), HttpStatusCode.TooManyRequests);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 429);
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_NullExceptionFactory_DoesNotThrowFor403()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000006", "Forbidden"), HttpStatusCode.Forbidden);
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            var response = await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden,
                "with a null ExceptionFactory the raw 4xx ApiResponse is returned without throwing");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_CustomFactory_IsCalledWithCorrectOperationName()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);
            string capturedName = null;
            api.ExceptionFactory = (name, _) =>
            {
                capturedName = name;
                return null;
            };

            await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            capturedName.Should().Be("ReplaceOktaPersonalAdminSettings",
                "ExceptionFactory must be called with the SDK operation name");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_MulticastExceptionFactory_ThrowsInvalidOperationException()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);
            api.ExceptionFactory += (_, _) => null;

            var act = async () => await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*Multicast*");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region Authentication Header Tests

        [Fact]
        public async Task ListWithHttpInfoAsync_NoAuthMode_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = new OktaPersonalSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization",
                "when no AuthorizationMode is configured no Authorization header must be added");
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_SswsMode_AddsSswsAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.SSWS,
                ApiKey = new Dictionary<string, string> { { "Authorization", "my-okta-token" } },
                ApiKeyPrefix = new Dictionary<string, string> { { "Authorization", "SSWS" } }
            };
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = new OktaPersonalSettingsApi(mockClient, config);

            await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should()
                .Contain("SSWS my-okta-token",
                    "SSWS mode must produce 'SSWS {token}' in the Authorization header");
        }

        [Fact]
        public async Task ListWithHttpInfoAsync_BearerTokenMode_AddsBearerAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "my-bearer-token"
            };
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = new OktaPersonalSettingsApi(mockClient, config);

            await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should()
                .Contain("Bearer my-bearer-token",
                    "Bearer mode must produce 'Bearer {token}' in the Authorization header");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_SswsMode_AddsSswsAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.SSWS,
                ApiKey = new Dictionary<string, string> { { "Authorization", "put-token" } },
                ApiKeyPrefix = new Dictionary<string, string> { { "Authorization", "SSWS" } }
            };
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = new OktaPersonalSettingsApi(mockClient, config);

            await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS put-token");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsWithHttpInfoAsync_BearerTokenMode_AddsBearerAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "bearer-put-token"
            };
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = new OktaPersonalSettingsApi(mockClient, config);

            await api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(
                new PersonalAppsBlockList { Domains = new List<string>() });

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer bearer-put-token");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_NoAuthMode_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = new OktaPersonalSettingsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization",
                "when no AuthorizationMode is configured no Authorization header must be added");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_SswsMode_AddsSswsAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.SSWS,
                ApiKey = new Dictionary<string, string> { { "Authorization", "admin-token" } },
                ApiKeyPrefix = new Dictionary<string, string> { { "Authorization", "SSWS" } }
            };
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = new OktaPersonalSettingsApi(mockClient, config);

            await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS admin-token");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync_BearerTokenMode_AddsBearerAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "bearer-admin-token"
            };
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = new OktaPersonalSettingsApi(mockClient, config);

            await api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer bearer-admin-token");
        }

        [Fact]
        public async Task BearerTokenMode_AuthorizationHeaderSetExactlyOnce_ForListEndpoint()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "unique-bearer"
            };
            var mockClient = new MockAsyncClient(EmptyBlockListJson());
            var api = new OktaPersonalSettingsApi(mockClient, config);

            await api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

            mockClient.ReceivedHeaders["Authorization"].Should().HaveCount(1,
                "Authorization must be added at most once regardless of how many auth branches are active");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region Cross-Variant Equivalence Tests

        [Fact]
        public async Task ListPlainVariant_AndWithHttpInfoVariant_ReturnEquivalentData()
        {
            var json = BlockListJson("equiv1.example.com", "equiv2.example.com");
            var config = new Configuration { BasePath = BaseUrl };

            var plainResult = await new OktaPersonalSettingsApi(new MockAsyncClient(json), config)
                .ListPersonalAppsExportBlockListAsync();

            var httpInfoResult = (await new OktaPersonalSettingsApi(new MockAsyncClient(json), config)
                .ListPersonalAppsExportBlockListWithHttpInfoAsync()).Data;

            plainResult.Should().BeEquivalentTo(httpInfoResult,
                "ListPersonalAppsExportBlockListAsync must return exactly WithHttpInfoAsync(...).Data");
        }

        [Fact]
        public async Task ListBothVariants_UseSamePathAndAcceptHeader()
        {
            var json = EmptyBlockListJson();
            var config = new Configuration { BasePath = BaseUrl };
            var clientA = new MockAsyncClient(json);
            var clientB = new MockAsyncClient(json);

            await new OktaPersonalSettingsApi(clientA, config).ListPersonalAppsExportBlockListAsync();
            await new OktaPersonalSettingsApi(clientB, config).ListPersonalAppsExportBlockListWithHttpInfoAsync();

            clientA.ReceivedPath.Should().Be(clientB.ReceivedPath,
                "both List variants must call the same endpoint path");
            clientA.ReceivedHeaders["Accept"].Should()
                .BeEquivalentTo(clientB.ReceivedHeaders["Accept"],
                    "both List variants must set the same Accept header");
        }

        [Fact]
        public async Task ReplaceBlockedEmailDomainsBothVariants_UseSamePathAndBodyAndContentType()
        {
            var config = new Configuration { BasePath = BaseUrl };
            var clientA = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var clientB = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var body = new PersonalAppsBlockList { Domains = new List<string> { "same.example.com" } };

            await new OktaPersonalSettingsApi(clientA, config).ReplaceBlockedEmailDomainsAsync(body);
            await new OktaPersonalSettingsApi(clientB, config).ReplaceBlockedEmailDomainsWithHttpInfoAsync(body);

            clientA.ReceivedPath.Should().Be(clientB.ReceivedPath,
                "both ReplaceBlockedEmailDomains variants must call the same endpoint path");
            clientA.ReceivedBody.Should().Be(clientB.ReceivedBody,
                "both variants must send the same serialized request body");
            clientA.ReceivedHeaders["Content-Type"].Should()
                .BeEquivalentTo(clientB.ReceivedHeaders["Content-Type"],
                    "both variants must set the same Content-Type header");
        }

        [Fact]
        public async Task ReplaceOktaPersonalAdminSettingsBothVariants_UseSamePathAndBodyAndContentType()
        {
            var config = new Configuration { BasePath = BaseUrl };
            var clientA = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var clientB = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var body = new OktaPersonalAdminFeatureSettings
            {
                EnableExportApps = true,
                EnableEnduserEntryPoints = false
            };

            await new OktaPersonalSettingsApi(clientA, config).ReplaceOktaPersonalAdminSettingsAsync(body);
            await new OktaPersonalSettingsApi(clientB, config).ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(body);

            clientA.ReceivedPath.Should().Be(clientB.ReceivedPath,
                "both ReplaceOktaPersonalAdminSettings variants must call the same endpoint path");
            clientA.ReceivedBody.Should().Be(clientB.ReceivedBody,
                "both variants must send the same serialized request body");
            clientA.ReceivedHeaders["Content-Type"].Should()
                .BeEquivalentTo(clientB.ReceivedHeaders["Content-Type"],
                    "both variants must set the same Content-Type header");
        }

        [Fact]
        public async Task GetAndPutEndpoints_UseDistinctPaths()
        {
            // Belt-and-suspenders: confirm the two unique base paths are never mixed up
            var config = new Configuration { BasePath = BaseUrl };
            var clientGet = new MockAsyncClient(EmptyBlockListJson());
            var clientPut = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);

            await new OktaPersonalSettingsApi(clientGet, config).ListPersonalAppsExportBlockListWithHttpInfoAsync();
            await new OktaPersonalSettingsApi(clientPut, config).ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(
                new OktaPersonalAdminFeatureSettings());

            clientGet.ReceivedPath.Should().Be("/okta-personal-settings/api/v1/export-blocklists");
            clientPut.ReceivedPath.Should().Be("/okta-personal-settings/api/v1/edit-feature");
            clientGet.ReceivedPath.Should().NotBe(clientPut.ReceivedPath,
                "the List and edit-feature operations target different endpoint paths");
        }

        #endregion
    }
}
