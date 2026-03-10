// <copyright file="EmailCustomizationApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
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
    public class EmailCustomizationApiTests
    {
        private const string BaseUrl = "https://test.okta.com";

        // ── Shared helpers ───────────────────────────────────────────────────

        /// <summary>Creates an API instance backed by <paramref name="client"/> with no auth mode set.</summary>
        private static EmailCustomizationApi CreateApi(MockAsyncClient client)
            => new EmailCustomizationApi(client, new Configuration { BasePath = BaseUrl });

        /// <summary>200-response JSON with one error entry.</summary>
        private static string OneErrorJson(
            string email = "test@example.com",
            string reason = "Not in organization")
            => $@"{{""errors"":[{{""emailAddress"":""{email}"",""reason"":""{reason}""}}]}}";

        /// <summary>200-response JSON with an empty errors array.</summary>
        private static string EmptyErrorsJson() => @"{""errors"":[]}";

        /// <summary>200-response JSON with <paramref name="count"/> error entries (addr1@example.com … addrN@example.com).</summary>
        private static string MultiErrorJson(int count)
        {
            var entries = Enumerable.Range(1, count)
                .Select(i => $@"{{""emailAddress"":""addr{i}@example.com"",""reason"":""Not in org""}}");
            return $@"{{""errors"":[{string.Join(",", entries)}]}}";
        }

        /// <summary>Error-body JSON returned by the server for 4xx responses.</summary>
        private static string ErrorBodyJson(string code, string summary)
            => $@"{{""errorCode"":""{code}"",""errorSummary"":""{summary}""}}";

        // ────────────────────────────────────────────────────────────────────
        #region Constructor and Property Tests

        [Fact]
        public void Constructor_WithNullAsyncClient_ThrowsArgumentNullException()
        {
            var act = () => new EmailCustomizationApi(
                (IAsynchronousClient)null,
                new Configuration { BasePath = BaseUrl });

            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("asyncClient");
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new EmailCustomizationApi(
                new MockAsyncClient("{}"),
                (IReadableConfiguration)null);

            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("configuration");
        }

        [Fact]
        public void Constructor_SetsAsynchronousClientProperty()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = CreateApi(mockClient);

            api.AsynchronousClient.Should().BeSameAs(mockClient,
                "the constructor must store the provided IAsynchronousClient");
        }

        [Fact]
        public void Constructor_SetsConfigurationProperty()
        {
            var config = new Configuration { BasePath = BaseUrl };
            var api = new EmailCustomizationApi(new MockAsyncClient("{}"), config);

            api.Configuration.Should().BeSameAs(config,
                "the constructor must store the provided IReadableConfiguration");
        }

        [Fact]
        public void GetBasePath_ReturnsOktaDomainFromConfiguration()
        {
            var api = CreateApi(new MockAsyncClient("{}"));

            api.GetBasePath().Should().Be(BaseUrl);
        }

        [Fact]
        public void AsynchronousClient_CanBeReassigned()
        {
            var original = new MockAsyncClient("{}");
            var replacement = new MockAsyncClient("{}");
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
            var api = CreateApi(new MockAsyncClient("{}"));

            api.ExceptionFactory.Should().NotBeNull(
                "the constructor assigns DefaultExceptionFactory as the initial value");
        }

        [Fact]
        public void ExceptionFactory_CanBeSetToNull()
        {
            var api = CreateApi(new MockAsyncClient("{}"));

            api.ExceptionFactory = null;

            api.ExceptionFactory.Should().BeNull();
        }

        [Fact]
        public void ExceptionFactory_CanBeReplacedWithCustomFactory()
        {
            var api = CreateApi(new MockAsyncClient("{}"));
            ExceptionFactory noOpFactory = (_, _) => null;

            api.ExceptionFactory = noOpFactory;

            api.ExceptionFactory.Should().BeSameAs(noOpFactory);
        }

        [Fact]
        public void ExceptionFactory_MulticastDelegate_ThrowsInvalidOperationExceptionOnGet()
        {
            // Arrange: add a second delegate to create a multicast
            var api = CreateApi(new MockAsyncClient("{}"));
            api.ExceptionFactory += (_, _) => null;

            // Act & Assert: the getter must detect the multicast and throw
            var act = () => { _ = api.ExceptionFactory; };

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("*Multicast*",
                    "the SDK explicitly forbids multicast ExceptionFactory delegates");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region BulkRemoveEmailAddressBouncesAsync Tests

        [Fact]
        public async Task BulkRemoveEmailAddressBouncesAsync_WithSingleEmail_ReturnsBouncesRemoveListResult()
        {
            var mockClient = new MockAsyncClient(OneErrorJson("a@example.com", "Not in organization"));
            var api = CreateApi(mockClient);

            var result = await api.BulkRemoveEmailAddressBouncesAsync(
                new BouncesRemoveListObj { EmailAddresses = new List<string> { "a@example.com" } });

            result.Should().NotBeNull()
                .And.BeOfType<BouncesRemoveListResult>(
                    "the plain variant must return BouncesRemoveListResult, not the raw ApiResponse");
            result.Errors.Should().ContainSingle();
            result.Errors[0].EmailAddress.Should().Be("a@example.com");
            result.Errors[0].Reason.Should().Be("Not in organization");
        }

        [Fact]
        public async Task BulkRemoveEmailAddressBouncesAsync_WithMultipleEmails_ReturnsAllErrorEntries()
        {
            var mockClient = new MockAsyncClient(MultiErrorJson(3));
            var api = CreateApi(mockClient);

            var result = await api.BulkRemoveEmailAddressBouncesAsync(
                new BouncesRemoveListObj
                {
                    EmailAddresses = new List<string>
                    {
                        "addr1@example.com",
                        "addr2@example.com",
                        "addr3@example.com"
                    }
                });

            result.Errors.Should().HaveCount(3);
            result.Errors.Select(e => e.EmailAddress)
                .Should().BeEquivalentTo(
                    "addr1@example.com", "addr2@example.com", "addr3@example.com");
        }

        [Fact]
        public async Task BulkRemoveEmailAddressBouncesAsync_WithEmptyErrorsInResponse_ReturnsEmptyList()
        {
            // The API returns 200 with errors:[] when all addresses are valid and on no bounce list
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            var result = await api.BulkRemoveEmailAddressBouncesAsync(
                new BouncesRemoveListObj { EmailAddresses = new List<string> { "ok@example.com" } });

            result.Should().NotBeNull();
            result.Errors.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task BulkRemoveEmailAddressBouncesAsync_WithNullRequest_SendsNullBodyAndReturnsResult()
        {
            // Passing null as the parameter is a valid call site (it's optional in the SDK)
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            var result = await api.BulkRemoveEmailAddressBouncesAsync(null);

            result.Should().NotBeNull();
            mockClient.ReceivedBody.Should().Be("null",
                "a null argument must be serialized as JSON null in the request body");
        }

        [Fact]
        public async Task BulkRemoveEmailAddressBouncesAsync_WithEmptyEmailList_SerializesEmailAddressesField()
        {
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            await api.BulkRemoveEmailAddressBouncesAsync(
                new BouncesRemoveListObj { EmailAddresses = new List<string>() });

            mockClient.ReceivedBody.Should().Contain("emailAddresses",
                "an empty list must still produce the emailAddresses field in the request body");
        }

        [Fact]
        public async Task BulkRemoveEmailAddressBouncesAsync_ReturnsDataPropertyOfApiResponse()
        {
            // Verifies the plain variant unwraps .Data rather than returning the ApiResponse wrapper
            var mockClient = new MockAsyncClient(OneErrorJson("unwrap@example.com", "unwrap reason"));
            var api = CreateApi(mockClient);

            var result = await api.BulkRemoveEmailAddressBouncesAsync(
                new BouncesRemoveListObj { EmailAddresses = new List<string> { "unwrap@example.com" } });

            // If the method had mistakenly returned the ApiResponse the cast would throw
            result.Errors[0].EmailAddress.Should().Be("unwrap@example.com");
            result.Errors[0].Reason.Should().Be("unwrap reason");
        }

        [Fact]
        public async Task BulkRemoveEmailAddressBouncesAsync_With400Response_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000001", "Api validation failed"), HttpStatusCode.BadRequest);
            var api = CreateApi(mockClient);

            var act = async () => await api.BulkRemoveEmailAddressBouncesAsync(
                new BouncesRemoveListObj { EmailAddresses = new List<string>() });

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400,
                    "DefaultExceptionFactory must throw ApiException(400) for HTTP 400");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region BulkRemoveEmailAddressBouncesWithHttpInfoAsync – Request Construction

        [Fact]
        public async Task WithHttpInfoAsync_CallsCorrectEndpointPath()
        {
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            mockClient.ReceivedPath.Should().Be("/api/v1/org/email/bounces/remove-list");
        }

        [Fact]
        public async Task WithHttpInfoAsync_SetsContentTypeHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            mockClient.ReceivedHeaders.Should().ContainKey("Content-Type");
            mockClient.ReceivedHeaders["Content-Type"].Should().Contain("application/json");
        }

        [Fact]
        public async Task WithHttpInfoAsync_SetsAcceptHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task WithHttpInfoAsync_WithRequestObject_SerializesEmailAddressesInBody()
        {
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(
                new BouncesRemoveListObj
                {
                    EmailAddresses = new List<string> { "alpha@example.com", "beta@example.com" }
                });

            mockClient.ReceivedBody.Should().Contain("emailAddresses");
            mockClient.ReceivedBody.Should().Contain("alpha@example.com");
            mockClient.ReceivedBody.Should().Contain("beta@example.com");
        }

        [Fact]
        public async Task WithHttpInfoAsync_WithNullRequest_SetsNullBodyInRequest()
        {
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            mockClient.ReceivedBody.Should().Be("null",
                "null bouncesRemoveListObj must produce JSON null as the request body");
        }

        [Fact]
        public async Task WithHttpInfoAsync_WithSpecialCharacterEmails_PreservesAllEmailsVerbatim()
        {
            var emails = new List<string>
            {
                "user+tag@example.com",
                "user.name@sub.domain.co.uk",
                "user_name@example.com",
                "user-name@example.com"
            };
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(
                new BouncesRemoveListObj { EmailAddresses = emails });

            foreach (var email in emails)
            {
                mockClient.ReceivedBody.Should().Contain(email,
                    $"email '{email}' must appear verbatim in the serialised request body");
            }
        }

        [Fact]
        public async Task WithHttpInfoAsync_WithLargeEmailBatch_SerializesAllEntries()
        {
            const int count = 500;
            var emails = Enumerable.Range(1, count)
                .Select(i => $"test{i:D4}@example.com")
                .ToList();
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            var response = await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(
                new BouncesRemoveListObj { EmailAddresses = emails });

            response.Should().NotBeNull("500-email batch must succeed");
            // Verify first and last entries survive serialisation
            mockClient.ReceivedBody.Should().Contain("test0001@example.com");
            mockClient.ReceivedBody.Should().Contain("test0500@example.com");
        }

        [Fact]
        public async Task WithHttpInfoAsync_SendsNoQueryParameters()
        {
            // The endpoint has no documented query params — verify none are sent
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(
                new BouncesRemoveListObj { EmailAddresses = new List<string> { "q@example.com" } });

            mockClient.ReceivedQueryParams.Should().BeEmpty(
                "POST /api/v1/org/email/bounces/remove-list takes no query parameters");
        }

        [Fact]
        public async Task WithHttpInfoAsync_SendsNoPathParameters()
        {
            // The endpoint URL is fixed — no path substitution variables
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            mockClient.ReceivedPathParams.Should().BeEmpty(
                "the endpoint path has no {variables} requiring substitution");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region BulkRemoveEmailAddressBouncesWithHttpInfoAsync – Response Deserialization

        [Fact]
        public async Task WithHttpInfoAsync_WithValidRequest_ReturnsApiResponse200()
        {
            var mockClient = new MockAsyncClient(OneErrorJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            var response = await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(
                new BouncesRemoveListObj { EmailAddresses = new List<string> { "x@example.com" } });

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task WithHttpInfoAsync_DataPropertyIsBouncesRemoveListResult()
        {
            var mockClient = new MockAsyncClient(OneErrorJson("type@example.com", "type check"));
            var api = CreateApi(mockClient);

            var response = await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            response.Data.Should().BeOfType<BouncesRemoveListResult>();
        }

        [Fact]
        public async Task WithHttpInfoAsync_DeserializesErrorsArray_WithTwoEntries()
        {
            var json = @"{""errors"":[
                {""emailAddress"":""a@x.com"",""reason"":""RFC 3696 error""},
                {""emailAddress"":""b@x.com"",""reason"":""Not in organization""}
            ]}";
            var mockClient = new MockAsyncClient(json);
            var api = CreateApi(mockClient);

            var response = await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            response.Data.Errors.Should().HaveCount(2);
            response.Data.Errors[0].EmailAddress.Should().Be("a@x.com");
            response.Data.Errors[0].Reason.Should().Be("RFC 3696 error");
            response.Data.Errors[1].EmailAddress.Should().Be("b@x.com");
            response.Data.Errors[1].Reason.Should().Be("Not in organization");
        }

        [Fact]
        public async Task WithHttpInfoAsync_DeserializesEmptyErrorsArray()
        {
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);

            var response = await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            response.Data.Errors.Should().NotBeNull()
                .And.BeEmpty();
        }

        [Fact]
        public async Task WithHttpInfoAsync_MapsEmailAddressFieldOnBouncesRemoveListError()
        {
            var mockClient = new MockAsyncClient(OneErrorJson("field@example.com", "Any reason"));
            var api = CreateApi(mockClient);

            var response = await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            response.Data.Errors.Single().EmailAddress.Should().Be("field@example.com");
        }

        [Fact]
        public async Task WithHttpInfoAsync_MapsReasonFieldOnBouncesRemoveListError()
        {
            var mockClient = new MockAsyncClient(OneErrorJson("r@example.com", "Invalid email address. RFC 3696."));
            var api = CreateApi(mockClient);

            var response = await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            response.Data.Errors.Single().Reason
                .Should().Be("Invalid email address. RFC 3696.");
        }

        [Fact]
        public async Task WithHttpInfoAsync_WithManyErrorEntries_AllEntriesDeserialized()
        {
            const int count = 50;
            var mockClient = new MockAsyncClient(MultiErrorJson(count));
            var api = CreateApi(mockClient);

            var response = await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(
                new BouncesRemoveListObj
                {
                    EmailAddresses = Enumerable.Range(1, count)
                        .Select(i => $"addr{i}@example.com")
                        .ToList()
                });

            response.Data.Errors.Should().HaveCount(count);
            // Spot-check first and last entries
            response.Data.Errors.First().EmailAddress.Should().Be("addr1@example.com");
            response.Data.Errors.Last().EmailAddress.Should().Be($"addr{count}@example.com");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ExceptionFactory / Error-Status-Code Tests

        [Fact]
        public async Task WithHttpInfoAsync_DefaultFactory_With400_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000001", "Api validation failed"), HttpStatusCode.BadRequest);
            var api = CreateApi(mockClient);

            var act = async () => await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400,
                    "DefaultExceptionFactory maps HTTP 400 → ApiException.ErrorCode 400");
        }

        [Fact]
        public async Task WithHttpInfoAsync_DefaultFactory_With403_ThrowsApiException403()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000006", "You do not have permission to perform the requested action"),
                HttpStatusCode.Forbidden);
            var api = CreateApi(mockClient);

            var act = async () => await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 403);
        }

        [Fact]
        public async Task WithHttpInfoAsync_DefaultFactory_With429_ThrowsApiException429()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000047", "API call exceeded rate limit due to too many requests"),
                HttpStatusCode.TooManyRequests);
            var api = CreateApi(mockClient);

            var act = async () => await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 429);
        }

        [Fact]
        public async Task WithHttpInfoAsync_NullExceptionFactory_DoesNotThrowFor400()
        {
            // Setting ExceptionFactory = null disables the throw-on-error behaviour,
            // which lets callers inspect the raw error response directly.
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000001", "Api validation failed"), HttpStatusCode.BadRequest);
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            var response = await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest,
                "with a null ExceptionFactory the raw ApiResponse is returned even for 4xx");
        }

        [Fact]
        public async Task WithHttpInfoAsync_NullExceptionFactory_DoesNotThrowFor403()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000006", "Forbidden"), HttpStatusCode.Forbidden);
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            var response = await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }

        [Fact]
        public async Task WithHttpInfoAsync_CustomFactory_IsCalledWithCorrectOperationName()
        {
            var mockClient = new MockAsyncClient(EmptyErrorsJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            string capturedOperationName = null;
            api.ExceptionFactory = (operationName, _) =>
            {
                capturedOperationName = operationName;
                return null;
            };

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            capturedOperationName.Should().Be("BulkRemoveEmailAddressBounces",
                "ExceptionFactory must be called with the operation name, not the method name");
        }

        [Fact]
        public async Task WithHttpInfoAsync_CustomFactory_CanReturnCustomExceptionType()
        {
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);
            var customEx = new InvalidOperationException("custom domain validation failed");
            api.ExceptionFactory = (_, _) => customEx;

            var act = async () => await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("custom domain validation failed",
                    "the exception returned by ExceptionFactory must be propagated as-is");
        }

        [Fact]
        public async Task WithHttpInfoAsync_CustomFactory_ReturningNull_DoesNotThrow()
        {
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);
            api.ExceptionFactory = (_, _) => null;

            var act = async () => await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            await act.Should().NotThrowAsync(
                "when ExceptionFactory returns null no exception must be thrown");
        }

        [Fact]
        public async Task WithHttpInfoAsync_MulticastExceptionFactory_ThrowsInvalidOperationException()
        {
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = CreateApi(mockClient);
            api.ExceptionFactory += (_, _) => null;  // promotes _exceptionFactory to multicast

            var act = async () => await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*Multicast*");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region Authentication Header Tests

        [Fact]
        public async Task WithHttpInfoAsync_NoAuthMode_NoAuthorizationHeaderSent()
        {
            // Default Configuration with no AuthorizationMode → all mode checks return false
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = new EmailCustomizationApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization",
                "when no AuthorizationMode is configured no Authorization header must be added");
        }

        [Fact]
        public async Task WithHttpInfoAsync_SswsMode_AddsSswsAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.SSWS,
                ApiKey = new Dictionary<string, string> { { "Authorization", "my-okta-token" } },
                ApiKeyPrefix = new Dictionary<string, string> { { "Authorization", "SSWS" } }
            };
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = new EmailCustomizationApi(mockClient, config);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should()
                .Contain("SSWS my-okta-token",
                    "SSWS mode must produce 'SSWS {token}' in the Authorization header");
        }

        [Fact]
        public async Task WithHttpInfoAsync_SswsMode_EmptyApiKeyInDictionary_StillAddsHeader()
        {
            // GetApiKeyWithPrefix("Authorization") returns "SSWS " when the key is "" —
            // !string.IsNullOrEmpty("SSWS ") is true so the header IS added.  Document this.
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.SSWS,
                ApiKey = new Dictionary<string, string> { { "Authorization", string.Empty } },
                ApiKeyPrefix = new Dictionary<string, string> { { "Authorization", "SSWS" } }
            };
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = new EmailCustomizationApi(mockClient, config);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            // "SSWS " (with trailing space) is not null/empty → header is present
            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
        }

        [Fact]
        public async Task WithHttpInfoAsync_SswsMode_NoApiKeyConfigured_NoAuthorizationHeader()
        {
            // When ApiKey has no "Authorization" entry AND ApiKeyPrefix has no "Authorization" entry,
            // GetApiKeyWithPrefix("Authorization") returns null → !IsNullOrEmpty(null) → false → no header.
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.SSWS,
                ApiKey = new Dictionary<string, string>(),         // empty — no "Authorization" key
                ApiKeyPrefix = new Dictionary<string, string>()    // empty — no prefix either
            };
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = new EmailCustomizationApi(mockClient, config);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization",
                "GetApiKeyWithPrefix returns null when no key is registered → no header sent");
        }

        [Fact]
        public async Task WithHttpInfoAsync_BearerTokenMode_AddsBearerAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "my-bearer-token"
            };
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = new EmailCustomizationApi(mockClient, config);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should()
                .Contain("Bearer my-bearer-token",
                    "Bearer mode must produce 'Bearer {token}' in the Authorization header");
        }

        [Fact]
        public async Task WithHttpInfoAsync_BearerTokenMode_AuthorizationHeaderSetExactlyOnce()
        {
            // Both SSWS and Bearer branches check ContainsKey("Authorization") before adding
            // to prevent double-setting.  Verify exactly one value is present.
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "unique-bearer"
            };
            var mockClient = new MockAsyncClient(EmptyErrorsJson());
            var api = new EmailCustomizationApi(mockClient, config);

            await api.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(null);

            mockClient.ReceivedHeaders["Authorization"].Should().HaveCount(1,
                "Authorization must be added at most once regardless of how many auth branches are active");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region Cross-Variant Equivalence Tests

        [Fact]
        public async Task PlainVariant_AndWithHttpInfoVariant_ReturnEquivalentData()
        {
            // The plain variant is documented to return WithHttpInfo(...).Data.
            // Confirm both variants produce the same deserialized object graph.
            const string email = "equiv@example.com";
            const string reason = "equivalence check";
            var json = OneErrorJson(email, reason);
            var config = new Configuration { BasePath = BaseUrl };

            var plainResult = await new EmailCustomizationApi(new MockAsyncClient(json), config)
                .BulkRemoveEmailAddressBouncesAsync(
                    new BouncesRemoveListObj { EmailAddresses = new List<string> { email } });

            var httpInfoResult = (await new EmailCustomizationApi(new MockAsyncClient(json), config)
                .BulkRemoveEmailAddressBouncesWithHttpInfoAsync(
                    new BouncesRemoveListObj { EmailAddresses = new List<string> { email } })).Data;

            plainResult.Should().BeEquivalentTo(httpInfoResult,
                "BulkRemoveEmailAddressBouncesAsync must return exactly WithHttpInfoAsync(...).Data");
        }

        [Fact]
        public async Task PlainVariant_WithSameConfiguration_UsesIdenticalEndpointAndHeaders()
        {
            var jsonA = EmptyErrorsJson();
            var jsonB = EmptyErrorsJson();
            var clientA = new MockAsyncClient(jsonA);
            var clientB = new MockAsyncClient(jsonB);
            var config = new Configuration { BasePath = BaseUrl };
            var request = new BouncesRemoveListObj { EmailAddresses = new List<string> { "same@example.com" } };

            await new EmailCustomizationApi(clientA, config).BulkRemoveEmailAddressBouncesAsync(request);
            await new EmailCustomizationApi(clientB, config).BulkRemoveEmailAddressBouncesWithHttpInfoAsync(request);

            clientA.ReceivedPath.Should().Be(clientB.ReceivedPath,
                "both variants must call the same endpoint path");
            clientA.ReceivedBody.Should().Be(clientB.ReceivedBody,
                "both variants must send the same request body");
            clientA.ReceivedHeaders["Content-Type"].Should()
                .BeEquivalentTo(clientB.ReceivedHeaders["Content-Type"],
                    "both variants must set the same Content-Type header");
        }

        #endregion
    }
}
