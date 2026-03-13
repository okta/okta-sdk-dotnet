// <copyright file="UISchemaApiTests.cs" company="Okta, Inc">
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
    public class UISchemaApiTests
    {
        private const string BaseUrl = "https://test.okta.com";

        // ── Shared helpers ───────────────────────────────────────────────────

        private static UISchemaApi CreateApi(MockAsyncClient client)
            => new UISchemaApi(client, new Configuration { BasePath = BaseUrl });

        private static UISchemaApi CreateApiWithConfig(MockAsyncClient client, Configuration config)
            => new UISchemaApi(client, config);

        /// <summary>JSON for a single UISchemasResponseObject response.</summary>
        private static string SchemaResponseJson(string id = "uis-id-001", string label = "Test Label",
            string type = "xEnrollmentPageLayout", string buttonLabel = "Sign In")
            => $@"{{""id"":""{id}"",""uiSchema"":{{""label"":""{label}"",""type"":""{type}"",""buttonLabel"":""{buttonLabel}""}}}}";

        /// <summary>JSON for a list of UISchemasResponseObjects.</summary>
        private static string SchemaListJson(params (string id, string label)[] items)
        {
            var entries = new List<string>();
            foreach (var (id, label) in items)
                entries.Add($@"{{""id"":""{id}"",""uiSchema"":{{""label"":""{label}"",""type"":""xEnrollmentPageLayout"",""buttonLabel"":""Next""}}}}");
            return "[" + string.Join(",", entries) + "]";
        }

        /// <summary>JSON for an empty list response.</summary>
        private static string EmptyListJson() => "[]";

        /// <summary>Error-body JSON returned by the server for 4xx responses.</summary>
        private static string ErrorBodyJson(string code, string summary)
            => $@"{{""errorCode"":""{code}"",""errorSummary"":""{summary}""}}";

        /// <summary>Empty/null body used for void/no-content responses.</summary>
        private const string NoContentBody = "null";

        /// <summary>A valid CreateUISchema request body.</summary>
        private static CreateUISchema ValidCreateBody(string label = "Test Schema")
            => new CreateUISchema
            {
                UiSchema = new UISchemaObject
                {
                    Label = label,
                    Type = "xEnrollmentPageLayout",
                    ButtonLabel = "Sign In"
                }
            };

        /// <summary>A valid UpdateUISchema request body.</summary>
        private static UpdateUISchema ValidUpdateBody(string label = "Updated Schema")
            => new UpdateUISchema
            {
                UiSchema = new UISchemaObject
                {
                    Label = label,
                    Type = "xEnrollmentPageLayout",
                    ButtonLabel = "Submit"
                }
            };

        // ────────────────────────────────────────────────────────────────────
        #region Constructor and Property Tests

        [Fact]
        public void Constructor_WithNullAsyncClient_ThrowsArgumentNullException()
        {
            var act = () => new UISchemaApi(
                (IAsynchronousClient)null,
                new Configuration { BasePath = BaseUrl });

            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("asyncClient");
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new UISchemaApi(
                new MockAsyncClient(NoContentBody),
                (IReadableConfiguration)null);

            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("configuration");
        }

        [Fact]
        public void Constructor_SetsAsynchronousClientProperty()
        {
            var mockClient = new MockAsyncClient(NoContentBody);
            var api = CreateApi(mockClient);

            api.AsynchronousClient.Should().BeSameAs(mockClient,
                "the constructor must store the provided IAsynchronousClient");
        }

        [Fact]
        public void Constructor_SetsConfigurationProperty()
        {
            var config = new Configuration { BasePath = BaseUrl };
            var api = new UISchemaApi(new MockAsyncClient(NoContentBody), config);

            api.Configuration.Should().BeSameAs(config,
                "the constructor must store the provided IReadableConfiguration");
        }

        [Fact]
        public void GetBasePath_ReturnsBasePathFromConfiguration()
        {
            var api = CreateApi(new MockAsyncClient(NoContentBody));

            api.GetBasePath().Should().Be(BaseUrl);
        }

        [Fact]
        public void AsynchronousClient_CanBeReassigned()
        {
            var original = new MockAsyncClient(NoContentBody);
            var replacement = new MockAsyncClient(NoContentBody);
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
            var api = CreateApi(new MockAsyncClient(NoContentBody));

            api.ExceptionFactory.Should().NotBeNull(
                "the constructor assigns DefaultExceptionFactory as the initial value");
        }

        [Fact]
        public void ExceptionFactory_CanBeSetToNull()
        {
            var api = CreateApi(new MockAsyncClient(NoContentBody));

            api.ExceptionFactory = null;

            api.ExceptionFactory.Should().BeNull();
        }

        [Fact]
        public void ExceptionFactory_CanBeReplacedWithCustomFactory()
        {
            var api = CreateApi(new MockAsyncClient(NoContentBody));
            ExceptionFactory noOpFactory = (_, _) => null;

            api.ExceptionFactory = noOpFactory;

            api.ExceptionFactory.Should().BeSameAs(noOpFactory);
        }

        [Fact]
        public void ExceptionFactory_MulticastDelegate_ThrowsInvalidOperationExceptionOnGet()
        {
            var api = CreateApi(new MockAsyncClient(NoContentBody));
            api.ExceptionFactory += (_, _) => null;

            var act = () => { _ = api.ExceptionFactory; };

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("*Multicast*",
                    "the SDK explicitly forbids multicast ExceptionFactory delegates");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region CreateUISchemaAsync Tests

        [Fact]
        public async Task CreateUISchemaAsync_WithNullBody_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(NoContentBody);
            var api = CreateApi(mockClient);

            var act = async () => await api.CreateUISchemaAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400,
                    "the SDK guard throws ApiException(400) before any HTTP call when body is null");
        }

        [Fact]
        public async Task CreateUISchemaAsync_WithNullBody_ExceptionMessageContainsParameterName()
        {
            var mockClient = new MockAsyncClient(NoContentBody);
            var api = CreateApi(mockClient);

            var act = async () => await api.CreateUISchemaAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*uischemabody*");
        }

        [Fact]
        public async Task CreateUISchemaAsync_WithNullBody_DoesNotCallHttpClient()
        {
            var mockClient = new MockAsyncClient(NoContentBody);
            var api = CreateApi(mockClient);

            try { await api.CreateUISchemaAsync(null); } catch (ApiException) { }

            mockClient.ReceivedPath.Should().BeNull(
                "the null guard fires before the HTTP call, so the client must never be invoked");
        }

        [Fact]
        public async Task CreateUISchemaAsync_WithValidBody_ReturnsUISchemasResponseObject()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson("new-schema-id", "My Schema"));
            var api = CreateApi(mockClient);

            var result = await api.CreateUISchemaAsync(ValidCreateBody());

            result.Should().NotBeNull()
                .And.BeOfType<UISchemasResponseObject>(
                    "the plain variant must return UISchemasResponseObject, not the raw ApiResponse");
        }

        [Fact]
        public async Task CreateUISchemaAsync_ReturnsDataPropertyOfApiResponse()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson("create-equiv-id"));
            var api = CreateApi(mockClient);

            var result = await api.CreateUISchemaAsync(ValidCreateBody());

            result.Should().NotBeNull(
                "CreateUISchemaAsync must return exactly the .Data of the WithHttpInfo response");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region CreateUISchemaWithHttpInfoAsync – Request Construction

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_WithNullBody_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(NoContentBody);
            var api = CreateApi(mockClient);

            var act = async () => await api.CreateUISchemaWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400);
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_WithNullBody_MessageContainsParameterName()
        {
            var mockClient = new MockAsyncClient(NoContentBody);
            var api = CreateApi(mockClient);

            var act = async () => await api.CreateUISchemaWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*uischemabody*");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_CallsCorrectPostPath()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            mockClient.ReceivedPath.Should().Be("/api/v1/meta/uischemas");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_SetsContentTypeHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            mockClient.ReceivedHeaders.Should().ContainKey("Content-Type");
            mockClient.ReceivedHeaders["Content-Type"].Should().Contain("application/json");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_SetsAcceptHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_SerializesBodyIntoRequestData()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody("My Custom Label"));

            mockClient.ReceivedBody.Should().Contain("uiSchema",
                "the body must contain the uiSchema field serialized from the CreateUISchema object");
            mockClient.ReceivedBody.Should().Contain("My Custom Label");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_SendsNoPathParameters()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            mockClient.ReceivedPathParams.Should().BeEmpty(
                "POST /api/v1/meta/uischemas has no path variables");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_SendsNoQueryParameters()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            mockClient.ReceivedQueryParams.Should().BeEmpty(
                "Create UI Schema has no documented query parameters");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_Returns200WithDataPopulated()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson("created-id"), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            var response = await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_DeserializesId()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson("id-abc-123"));
            var api = CreateApi(mockClient);

            var response = await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            response.Data.Id.Should().Be("id-abc-123");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_DeserializesUiSchema()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson(label: "My Enrollment"));
            var api = CreateApi(mockClient);

            var response = await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            response.Data.UiSchema.Should().NotBeNull();
            response.Data.UiSchema.Label.Should().Be("My Enrollment");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_DefaultFactory_With401_ThrowsApiException401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token provided"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);

            var act = async () => await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 401);
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_DefaultFactory_With403_ThrowsApiException403()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000006", "You do not have permission"), HttpStatusCode.Forbidden);
            var api = CreateApi(mockClient);

            var act = async () => await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 403);
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_DefaultFactory_With429_ThrowsApiException429()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000047", "API call exceeded rate limit"), HttpStatusCode.TooManyRequests);
            var api = CreateApi(mockClient);

            var act = async () => await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 429);
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_NullExceptionFactory_DoesNotThrowFor401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            var response = await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized,
                "with a null ExceptionFactory the raw 4xx ApiResponse is returned without throwing");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_CustomFactory_IsCalledWithCorrectOperationName()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);
            string capturedName = null;
            api.ExceptionFactory = (name, _) =>
            {
                capturedName = name;
                return null;
            };

            await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            capturedName.Should().Be("CreateUISchema",
                "ExceptionFactory must be called with the SDK operation name");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_CustomFactory_ReturningNull_DoesNotThrow()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);
            api.ExceptionFactory = (_, _) => null;

            var act = async () => await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            await act.Should().NotThrowAsync(
                "when ExceptionFactory returns null no exception must be thrown");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_CustomFactory_CanReturnCustomExceptionType()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);
            var customEx = new InvalidOperationException("custom create error");
            api.ExceptionFactory = (_, _) => customEx;

            var act = async () => await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("custom create error");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_MulticastExceptionFactory_ThrowsInvalidOperationException()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);
            api.ExceptionFactory += (_, _) => null;

            var act = async () => await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*Multicast*");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region DeleteUISchemasAsync Tests

        [Fact]
        public async Task DeleteUISchemasAsync_WithNullId_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.DeleteUISchemasAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400,
                    "the SDK guard throws ApiException(400) before any HTTP call when id is null");
        }

        [Fact]
        public async Task DeleteUISchemasAsync_WithNullId_ExceptionMessageContainsParameterName()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.DeleteUISchemasAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*'id'*");
        }

        [Fact]
        public async Task DeleteUISchemasAsync_WithNullId_DoesNotCallHttpClient()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            try { await api.DeleteUISchemasAsync(null); } catch (ApiException) { }

            mockClient.ReceivedPath.Should().BeNull(
                "when the null guard throws the HTTP client must never be called");
        }

        [Fact]
        public async Task DeleteUISchemasAsync_WithValidId_CompletesWithoutThrowing()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.DeleteUISchemasAsync("schema-to-delete");

            await act.Should().NotThrowAsync();
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region DeleteUISchemasWithHttpInfoAsync – Request Construction

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_WithNullId_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.DeleteUISchemasWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400);
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_WithNullId_MessageContainsParameterName()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var act = async () => await api.DeleteUISchemasWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*'id'*");
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_CallsCorrectDeletePath()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteUISchemasWithHttpInfoAsync("my-schema-id");

            mockClient.ReceivedPath.Should().Be("/api/v1/meta/uischemas/{id}",
                "the path template must be passed verbatim to the HTTP client");
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_DoesNotSetContentTypeHeader()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteUISchemasWithHttpInfoAsync("some-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Content-Type",
                "a DELETE request with no body must not set Content-Type");
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_SetsAcceptHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteUISchemasWithHttpInfoAsync("some-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_SetsIdPathParameter()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteUISchemasWithHttpInfoAsync("target-schema-id");

            mockClient.ReceivedPathParams.Should().ContainKey("id");
            mockClient.ReceivedPathParams["id"].Should().Be("target-schema-id");
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_SendsNoQueryParameters()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            await api.DeleteUISchemasWithHttpInfoAsync("some-id");

            mockClient.ReceivedQueryParams.Should().BeEmpty(
                "DELETE /api/v1/meta/uischemas/{id} has no documented query parameters");
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_Returns204Response()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);

            var response = await api.DeleteUISchemasWithHttpInfoAsync("any-schema-id");

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_DefaultFactory_With401_ThrowsApiException401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);

            var act = async () => await api.DeleteUISchemasWithHttpInfoAsync("schema-id");

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 401);
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_DefaultFactory_With403_ThrowsApiException403()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000006", "Forbidden"), HttpStatusCode.Forbidden);
            var api = CreateApi(mockClient);

            var act = async () => await api.DeleteUISchemasWithHttpInfoAsync("schema-id");

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 403);
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_DefaultFactory_With429_ThrowsApiException429()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000047", "Rate limit"), HttpStatusCode.TooManyRequests);
            var api = CreateApi(mockClient);

            var act = async () => await api.DeleteUISchemasWithHttpInfoAsync("schema-id");

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 429);
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_NullExceptionFactory_DoesNotThrowFor401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            var response = await api.DeleteUISchemasWithHttpInfoAsync("schema-id");

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized,
                "with a null ExceptionFactory the raw 4xx ApiResponse is returned without throwing");
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_CustomFactory_IsCalledWithCorrectOperationName()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);
            string capturedName = null;
            api.ExceptionFactory = (name, _) =>
            {
                capturedName = name;
                return null;
            };

            await api.DeleteUISchemasWithHttpInfoAsync("schema-id");

            capturedName.Should().Be("DeleteUISchemas",
                "ExceptionFactory must be called with the SDK operation name");
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_MulticastExceptionFactory_ThrowsInvalidOperationException()
        {
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = CreateApi(mockClient);
            api.ExceptionFactory += (_, _) => null;

            var act = async () => await api.DeleteUISchemasWithHttpInfoAsync("schema-id");

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*Multicast*");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region GetUISchemaAsync Tests

        [Fact]
        public async Task GetUISchemaAsync_WithNullId_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(NoContentBody);
            var api = CreateApi(mockClient);

            var act = async () => await api.GetUISchemaAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400,
                    "the SDK guard throws ApiException(400) before any HTTP call when id is null");
        }

        [Fact]
        public async Task GetUISchemaAsync_WithNullId_ExceptionMessageContainsParameterName()
        {
            var mockClient = new MockAsyncClient(NoContentBody);
            var api = CreateApi(mockClient);

            var act = async () => await api.GetUISchemaAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*'id'*");
        }

        [Fact]
        public async Task GetUISchemaAsync_WithNullId_DoesNotCallHttpClient()
        {
            var mockClient = new MockAsyncClient(NoContentBody);
            var api = CreateApi(mockClient);

            try { await api.GetUISchemaAsync(null); } catch (ApiException) { }

            mockClient.ReceivedPath.Should().BeNull(
                "the null guard fires before the HTTP call, so the client must never be invoked");
        }

        [Fact]
        public async Task GetUISchemaAsync_WithValidId_ReturnsDataFromResponse()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson("get-id-123", "Get Schema"));
            var api = CreateApi(mockClient);

            var result = await api.GetUISchemaAsync("get-id-123");

            // The plain variant must return the .Data of the ApiResponse (may be null or a schema object)
            // We assert the call completes without exception and the path was hit.
            mockClient.ReceivedPath.Should().Be("/api/v1/meta/uischemas/{id}",
                "GetUISchemaAsync must delegate to GetUISchemaWithHttpInfoAsync which uses the id-parameterized path");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region GetUISchemaWithHttpInfoAsync – Request Construction

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_WithNullId_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(NoContentBody);
            var api = CreateApi(mockClient);

            var act = async () => await api.GetUISchemaWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400);
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_WithNullId_MessageContainsParameterName()
        {
            var mockClient = new MockAsyncClient(NoContentBody);
            var api = CreateApi(mockClient);

            var act = async () => await api.GetUISchemaWithHttpInfoAsync(null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*'id'*");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_CallsCorrectGetPath()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.GetUISchemaWithHttpInfoAsync("schema-xyz");

            mockClient.ReceivedPath.Should().Be("/api/v1/meta/uischemas/{id}");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_DoesNotSetContentTypeHeader()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.GetUISchemaWithHttpInfoAsync("some-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Content-Type",
                "a GET request with no body must not set Content-Type");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_SetsAcceptHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.GetUISchemaWithHttpInfoAsync("some-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_SetsIdPathParameter()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.GetUISchemaWithHttpInfoAsync("lookup-schema-id");

            mockClient.ReceivedPathParams.Should().ContainKey("id");
            mockClient.ReceivedPathParams["id"].Should().Be("lookup-schema-id");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_SendsNoQueryParameters()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.GetUISchemaWithHttpInfoAsync("some-id");

            mockClient.ReceivedQueryParams.Should().BeEmpty(
                "GET /api/v1/meta/uischemas/{id} has no documented query parameters");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_Returns200WithResponseNotNull()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson("get-200-id"), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            var response = await api.GetUISchemaWithHttpInfoAsync("get-200-id");

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_DeserializesUiSchema()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson(label: "Enrollment Form"));
            var api = CreateApi(mockClient);

            var response = await api.GetUISchemaWithHttpInfoAsync("any-id");

            response.Data.Should().NotBeNull();
            response.Data.UiSchema.Should().NotBeNull();
            response.Data.UiSchema.Label.Should().Be("Enrollment Form");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_DeserializesId()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson("readable-id"));
            var api = CreateApi(mockClient);

            var response = await api.GetUISchemaWithHttpInfoAsync("readable-id");

            response.Data.Id.Should().Be("readable-id");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_DefaultFactory_With401_ThrowsApiException401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);

            var act = async () => await api.GetUISchemaWithHttpInfoAsync("schema-id");

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 401);
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_DefaultFactory_With403_ThrowsApiException403()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000006", "Forbidden"), HttpStatusCode.Forbidden);
            var api = CreateApi(mockClient);

            var act = async () => await api.GetUISchemaWithHttpInfoAsync("schema-id");

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 403);
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_DefaultFactory_With429_ThrowsApiException429()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000047", "Rate limit"), HttpStatusCode.TooManyRequests);
            var api = CreateApi(mockClient);

            var act = async () => await api.GetUISchemaWithHttpInfoAsync("schema-id");

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 429);
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_NullExceptionFactory_DoesNotThrowFor401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            var response = await api.GetUISchemaWithHttpInfoAsync("schema-id");

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized,
                "with a null ExceptionFactory the raw 4xx ApiResponse is returned without throwing");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_CustomFactory_IsCalledWithCorrectOperationName()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);
            string capturedName = null;
            api.ExceptionFactory = (name, _) =>
            {
                capturedName = name;
                return null;
            };

            await api.GetUISchemaWithHttpInfoAsync("schema-id");

            capturedName.Should().Be("GetUISchema",
                "ExceptionFactory must be called with the SDK operation name");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_MulticastExceptionFactory_ThrowsInvalidOperationException()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);
            api.ExceptionFactory += (_, _) => null;

            var act = async () => await api.GetUISchemaWithHttpInfoAsync("schema-id");

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*Multicast*");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ListUISchemas Tests

        [Fact]
        public void ListUISchemas_ReturnsNonNullCollectionClient()
        {
            var mockClient = new MockAsyncClient(EmptyListJson());
            var api = CreateApi(mockClient);

            var result = api.ListUISchemas();

            result.Should().NotBeNull(
                "ListUISchemas must return an IOktaCollectionClient, never null");
        }

        [Fact]
        public void ListUISchemas_ReturnsIOktaCollectionClientOfCorrectType()
        {
            var mockClient = new MockAsyncClient(EmptyListJson());
            var api = CreateApi(mockClient);

            var result = api.ListUISchemas();

            result.Should().BeAssignableTo<IOktaCollectionClient<UISchemasResponseObject>>(
                "ListUISchemas must return IOktaCollectionClient<UISchemasResponseObject>");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ListUISchemasWithHttpInfoAsync – Request Construction

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_CallsCorrectGetPath()
        {
            var mockClient = new MockAsyncClient(EmptyListJson());
            var api = CreateApi(mockClient);

            await api.ListUISchemasWithHttpInfoAsync();

            mockClient.ReceivedPath.Should().Be("/api/v1/meta/uischemas");
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_DoesNotSetContentTypeHeader()
        {
            var mockClient = new MockAsyncClient(EmptyListJson());
            var api = CreateApi(mockClient);

            await api.ListUISchemasWithHttpInfoAsync();

            mockClient.ReceivedHeaders.Should().NotContainKey("Content-Type",
                "a GET request with no body must not set Content-Type");
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_SetsAcceptHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(EmptyListJson());
            var api = CreateApi(mockClient);

            await api.ListUISchemasWithHttpInfoAsync();

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_SendsNoPathParameters()
        {
            var mockClient = new MockAsyncClient(EmptyListJson());
            var api = CreateApi(mockClient);

            await api.ListUISchemasWithHttpInfoAsync();

            mockClient.ReceivedPathParams.Should().BeEmpty(
                "the /api/v1/meta/uischemas path has no {variables}");
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_SendsNoQueryParameters()
        {
            var mockClient = new MockAsyncClient(EmptyListJson());
            var api = CreateApi(mockClient);

            await api.ListUISchemasWithHttpInfoAsync();

            mockClient.ReceivedQueryParams.Should().BeEmpty(
                "List UI Schemas has no documented query parameters");
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_Returns200WithResponseNotNull()
        {
            var mockClient = new MockAsyncClient(EmptyListJson(), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            var response = await api.ListUISchemasWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_DeserializesEmptyListCorrectly()
        {
            var mockClient = new MockAsyncClient(EmptyListJson());
            var api = CreateApi(mockClient);

            var response = await api.ListUISchemasWithHttpInfoAsync();

            response.Data.Should().NotBeNull()
                .And.BeEmpty("an empty JSON array must deserialize to an empty List, not null");
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_DeserializesMultipleSchemas()
        {
            var mockClient = new MockAsyncClient(SchemaListJson(("id-1", "Schema One"), ("id-2", "Schema Two")));
            var api = CreateApi(mockClient);

            var response = await api.ListUISchemasWithHttpInfoAsync();

            response.Data.Should().HaveCount(2);
            response.Data[0].Id.Should().Be("id-1");
            response.Data[1].Id.Should().Be("id-2");
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_DeserializesUiSchemaForEachItem()
        {
            var mockClient = new MockAsyncClient(SchemaListJson(("s1", "First Form"), ("s2", "Second Form")));
            var api = CreateApi(mockClient);

            var response = await api.ListUISchemasWithHttpInfoAsync();

            response.Data[0].UiSchema.Label.Should().Be("First Form");
            response.Data[1].UiSchema.Label.Should().Be("Second Form");
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_DefaultFactory_With401_ThrowsApiException401()
        {
            var mockClient = new MockAsyncClient(
                EmptyListJson(), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);

            var act = async () => await api.ListUISchemasWithHttpInfoAsync();

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 401);
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_DefaultFactory_With403_ThrowsApiException403()
        {
            var mockClient = new MockAsyncClient(
                EmptyListJson(), HttpStatusCode.Forbidden);
            var api = CreateApi(mockClient);

            var act = async () => await api.ListUISchemasWithHttpInfoAsync();

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 403);
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_DefaultFactory_With429_ThrowsApiException429()
        {
            var mockClient = new MockAsyncClient(
                EmptyListJson(), HttpStatusCode.TooManyRequests);
            var api = CreateApi(mockClient);

            var act = async () => await api.ListUISchemasWithHttpInfoAsync();

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 429);
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_NullExceptionFactory_DoesNotThrowFor401()
        {
            var mockClient = new MockAsyncClient(
                EmptyListJson(), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            var response = await api.ListUISchemasWithHttpInfoAsync();

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized,
                "with a null ExceptionFactory the raw 4xx ApiResponse is returned without throwing");
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_CustomFactory_IsCalledWithCorrectOperationName()
        {
            var mockClient = new MockAsyncClient(EmptyListJson());
            var api = CreateApi(mockClient);
            string capturedName = null;
            api.ExceptionFactory = (name, _) =>
            {
                capturedName = name;
                return null;
            };

            await api.ListUISchemasWithHttpInfoAsync();

            capturedName.Should().Be("ListUISchemas",
                "ExceptionFactory must be called with the SDK operation name");
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_MulticastExceptionFactory_ThrowsInvalidOperationException()
        {
            var mockClient = new MockAsyncClient(EmptyListJson());
            var api = CreateApi(mockClient);
            api.ExceptionFactory += (_, _) => null;

            var act = async () => await api.ListUISchemasWithHttpInfoAsync();

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*Multicast*");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ReplaceUISchemasAsync Tests

        [Fact]
        public async Task ReplaceUISchemasAsync_WithNullId_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceUISchemasAsync(null, ValidUpdateBody());

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400,
                    "the SDK guard throws ApiException(400) before any HTTP call when id is null");
        }

        [Fact]
        public async Task ReplaceUISchemasAsync_WithNullId_ExceptionMessageContainsIdParameterName()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceUISchemasAsync(null, ValidUpdateBody());

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*'id'*");
        }

        [Fact]
        public async Task ReplaceUISchemasAsync_WithNullBody_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceUISchemasAsync("schema-id", null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400,
                    "the SDK guard throws ApiException(400) before any HTTP call when body is null");
        }

        [Fact]
        public async Task ReplaceUISchemasAsync_WithNullBody_ExceptionMessageContainsBodyParameterName()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceUISchemasAsync("schema-id", null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*updateUISchemaBody*");
        }

        [Fact]
        public async Task ReplaceUISchemasAsync_WithNullId_DoesNotCallHttpClient()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            try { await api.ReplaceUISchemasAsync(null, ValidUpdateBody()); } catch (ApiException) { }

            mockClient.ReceivedPath.Should().BeNull(
                "when the null guard throws the HTTP client must never be called");
        }

        [Fact]
        public async Task ReplaceUISchemasAsync_WithValidIdAndBody_ReturnsUISchemasResponseObject()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson("replaced-id", "Replaced Label"));
            var api = CreateApi(mockClient);

            var result = await api.ReplaceUISchemasAsync("replaced-id", ValidUpdateBody());

            result.Should().NotBeNull()
                .And.BeOfType<UISchemasResponseObject>();
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region ReplaceUISchemasWithHttpInfoAsync – Request Construction

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_WithNullId_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceUISchemasWithHttpInfoAsync(null, ValidUpdateBody());

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400);
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_WithNullId_MessageContainsIdParameterName()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceUISchemasWithHttpInfoAsync(null, ValidUpdateBody());

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*'id'*");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_WithNullBody_ThrowsApiException400()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceUISchemasWithHttpInfoAsync("schema-id", null);

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 400);
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_WithNullBody_MessageContainsBodyParameterName()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceUISchemasWithHttpInfoAsync("schema-id", null);

            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*updateUISchemaBody*");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_CallsCorrectPutPath()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.ReplaceUISchemasWithHttpInfoAsync("some-schema", ValidUpdateBody());

            mockClient.ReceivedPath.Should().Be("/api/v1/meta/uischemas/{id}");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_SetsContentTypeHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.ReplaceUISchemasWithHttpInfoAsync("some-schema", ValidUpdateBody());

            mockClient.ReceivedHeaders.Should().ContainKey("Content-Type");
            mockClient.ReceivedHeaders["Content-Type"].Should().Contain("application/json");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_SetsAcceptHeaderToApplicationJson()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.ReplaceUISchemasWithHttpInfoAsync("some-schema", ValidUpdateBody());

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
            mockClient.ReceivedHeaders["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_SetsIdPathParameter()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.ReplaceUISchemasWithHttpInfoAsync("replace-target-id", ValidUpdateBody());

            mockClient.ReceivedPathParams.Should().ContainKey("id");
            mockClient.ReceivedPathParams["id"].Should().Be("replace-target-id");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_SerializesBodyIntoRequestData()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.ReplaceUISchemasWithHttpInfoAsync("schema-id", ValidUpdateBody("Updated Label"));

            mockClient.ReceivedBody.Should().Contain("uiSchema");
            mockClient.ReceivedBody.Should().Contain("Updated Label");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_SendsNoQueryParameters()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);

            await api.ReplaceUISchemasWithHttpInfoAsync("schema-id", ValidUpdateBody());

            mockClient.ReceivedQueryParams.Should().BeEmpty(
                "PUT /api/v1/meta/uischemas/{id} has no documented query parameters");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_Returns200WithDataPopulated()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson("put-id", "Put Label"), HttpStatusCode.OK);
            var api = CreateApi(mockClient);

            var response = await api.ReplaceUISchemasWithHttpInfoAsync("put-id", ValidUpdateBody());

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_DeserializesResponseId()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson("deserialized-replace-id"));
            var api = CreateApi(mockClient);

            var response = await api.ReplaceUISchemasWithHttpInfoAsync("deserialized-replace-id", ValidUpdateBody());

            response.Data.Id.Should().Be("deserialized-replace-id");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_DefaultFactory_With401_ThrowsApiException401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceUISchemasWithHttpInfoAsync("schema-id", ValidUpdateBody());

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 401);
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_DefaultFactory_With403_ThrowsApiException403()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000006", "Forbidden"), HttpStatusCode.Forbidden);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceUISchemasWithHttpInfoAsync("schema-id", ValidUpdateBody());

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 403);
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_DefaultFactory_With429_ThrowsApiException429()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000047", "Rate limit"), HttpStatusCode.TooManyRequests);
            var api = CreateApi(mockClient);

            var act = async () => await api.ReplaceUISchemasWithHttpInfoAsync("schema-id", ValidUpdateBody());

            await act.Should().ThrowAsync<ApiException>()
                .Where(ex => ex.ErrorCode == 429);
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_NullExceptionFactory_DoesNotThrowFor401()
        {
            var mockClient = new MockAsyncClient(
                ErrorBodyJson("E0000011", "Invalid token"), HttpStatusCode.Unauthorized);
            var api = CreateApi(mockClient);
            api.ExceptionFactory = null;

            var response = await api.ReplaceUISchemasWithHttpInfoAsync("schema-id", ValidUpdateBody());

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized,
                "with a null ExceptionFactory the raw 4xx ApiResponse is returned without throwing");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_CustomFactory_IsCalledWithCorrectOperationName()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);
            string capturedName = null;
            api.ExceptionFactory = (name, _) =>
            {
                capturedName = name;
                return null;
            };

            await api.ReplaceUISchemasWithHttpInfoAsync("schema-id", ValidUpdateBody());

            capturedName.Should().Be("ReplaceUISchemas",
                "ExceptionFactory must be called with the SDK operation name");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_MulticastExceptionFactory_ThrowsInvalidOperationException()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = CreateApi(mockClient);
            api.ExceptionFactory += (_, _) => null;

            var act = async () => await api.ReplaceUISchemasWithHttpInfoAsync("schema-id", ValidUpdateBody());

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*Multicast*");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region Authentication Header Tests

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_NoAuthMode_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = new UISchemaApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization",
                "when no AuthorizationMode is configured no Authorization header must be added");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_SswsMode_AddsSswsAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.SSWS,
                ApiKey = new Dictionary<string, string> { { "Authorization", "my-api-token" } },
                ApiKeyPrefix = new Dictionary<string, string> { { "Authorization", "SSWS" } }
            };
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = new UISchemaApi(mockClient, config);

            await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should()
                .Contain("SSWS my-api-token",
                    "SSWS mode must produce 'SSWS {token}' in the Authorization header");
        }

        [Fact]
        public async Task CreateUISchemaWithHttpInfoAsync_BearerTokenMode_AddsBearerAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "my-bearer-token"
            };
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = new UISchemaApi(mockClient, config);

            await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should()
                .Contain("Bearer my-bearer-token",
                    "Bearer mode must produce 'Bearer {token}' in the Authorization header");
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_SswsMode_AddsSswsAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.SSWS,
                ApiKey = new Dictionary<string, string> { { "Authorization", "delete-token" } },
                ApiKeyPrefix = new Dictionary<string, string> { { "Authorization", "SSWS" } }
            };
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = new UISchemaApi(mockClient, config);

            await api.DeleteUISchemasWithHttpInfoAsync("schema-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS delete-token");
        }

        [Fact]
        public async Task DeleteUISchemasWithHttpInfoAsync_BearerTokenMode_AddsBearerAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "bearer-delete-token"
            };
            var mockClient = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var api = new UISchemaApi(mockClient, config);

            await api.DeleteUISchemasWithHttpInfoAsync("schema-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer bearer-delete-token");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_NoAuthMode_NoAuthorizationHeaderSent()
        {
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = new UISchemaApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.GetUISchemaWithHttpInfoAsync("schema-id");

            mockClient.ReceivedHeaders.Should().NotContainKey("Authorization",
                "when no AuthorizationMode is configured no Authorization header must be added");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_SswsMode_AddsSswsAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.SSWS,
                ApiKey = new Dictionary<string, string> { { "Authorization", "get-token" } },
                ApiKeyPrefix = new Dictionary<string, string> { { "Authorization", "SSWS" } }
            };
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = new UISchemaApi(mockClient, config);

            await api.GetUISchemaWithHttpInfoAsync("schema-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS get-token");
        }

        [Fact]
        public async Task GetUISchemaWithHttpInfoAsync_BearerTokenMode_AddsBearerAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "bearer-get-token"
            };
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = new UISchemaApi(mockClient, config);

            await api.GetUISchemaWithHttpInfoAsync("schema-id");

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer bearer-get-token");
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_SswsMode_AddsSswsAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.SSWS,
                ApiKey = new Dictionary<string, string> { { "Authorization", "list-token" } },
                ApiKeyPrefix = new Dictionary<string, string> { { "Authorization", "SSWS" } }
            };
            var mockClient = new MockAsyncClient(EmptyListJson());
            var api = new UISchemaApi(mockClient, config);

            await api.ListUISchemasWithHttpInfoAsync();

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS list-token");
        }

        [Fact]
        public async Task ListUISchemasWithHttpInfoAsync_BearerTokenMode_AddsBearerAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "bearer-list-token"
            };
            var mockClient = new MockAsyncClient(EmptyListJson());
            var api = new UISchemaApi(mockClient, config);

            await api.ListUISchemasWithHttpInfoAsync();

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer bearer-list-token");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_SswsMode_AddsSswsAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.SSWS,
                ApiKey = new Dictionary<string, string> { { "Authorization", "replace-token" } },
                ApiKeyPrefix = new Dictionary<string, string> { { "Authorization", "SSWS" } }
            };
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = new UISchemaApi(mockClient, config);

            await api.ReplaceUISchemasWithHttpInfoAsync("schema-id", ValidUpdateBody());

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("SSWS replace-token");
        }

        [Fact]
        public async Task ReplaceUISchemasWithHttpInfoAsync_BearerTokenMode_AddsBearerAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "bearer-replace-token"
            };
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = new UISchemaApi(mockClient, config);

            await api.ReplaceUISchemasWithHttpInfoAsync("schema-id", ValidUpdateBody());

            mockClient.ReceivedHeaders.Should().ContainKey("Authorization");
            mockClient.ReceivedHeaders["Authorization"].Should().Contain("Bearer bearer-replace-token");
        }

        [Fact]
        public async Task BearerTokenMode_AuthorizationHeaderSetExactlyOnce_ForGetEndpoint()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "unique-bearer-get"
            };
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = new UISchemaApi(mockClient, config);

            await api.GetUISchemaWithHttpInfoAsync("schema-id");

            mockClient.ReceivedHeaders["Authorization"].Should().HaveCount(1,
                "Authorization must be added at most once regardless of how many auth branches are active");
        }

        [Fact]
        public async Task BearerTokenMode_AuthorizationHeaderSetExactlyOnce_ForPostEndpoint()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "unique-bearer-post"
            };
            var mockClient = new MockAsyncClient(SchemaResponseJson());
            var api = new UISchemaApi(mockClient, config);

            await api.CreateUISchemaWithHttpInfoAsync(ValidCreateBody());

            mockClient.ReceivedHeaders["Authorization"].Should().HaveCount(1,
                "Authorization must be added at most once");
        }

        #endregion

        // ────────────────────────────────────────────────────────────────────
        #region Cross-Variant Equivalence Tests

        [Fact]
        public async Task CreateBothVariants_UseSamePathAndContentType()
        {
            var json = SchemaResponseJson("equiv-create");
            var config = new Configuration { BasePath = BaseUrl };
            var clientA = new MockAsyncClient(json);
            var clientB = new MockAsyncClient(json);
            var body = ValidCreateBody();

            await new UISchemaApi(clientA, config).CreateUISchemaAsync(body);
            await new UISchemaApi(clientB, config).CreateUISchemaWithHttpInfoAsync(body);

            clientA.ReceivedPath.Should().Be(clientB.ReceivedPath,
                "both Create variants must call the same endpoint path");
            clientA.ReceivedHeaders["Content-Type"].Should()
                .BeEquivalentTo(clientB.ReceivedHeaders["Content-Type"],
                    "both Create variants must set the same Content-Type header");
        }

        [Fact]
        public async Task CreateBothVariants_SendSameSerializedBody()
        {
            var json = SchemaResponseJson("equiv-create-body");
            var config = new Configuration { BasePath = BaseUrl };
            var clientA = new MockAsyncClient(json);
            var clientB = new MockAsyncClient(json);
            var body = ValidCreateBody("Same Label");

            await new UISchemaApi(clientA, config).CreateUISchemaAsync(body);
            await new UISchemaApi(clientB, config).CreateUISchemaWithHttpInfoAsync(body);

            clientA.ReceivedBody.Should().Be(clientB.ReceivedBody,
                "both Create variants must serialize the same request body");
        }

        [Fact]
        public async Task DeleteBothVariants_UseSamePath()
        {
            var config = new Configuration { BasePath = BaseUrl };
            var clientA = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var clientB = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);

            await new UISchemaApi(clientA, config).DeleteUISchemasAsync("equiv-delete-id");
            await new UISchemaApi(clientB, config).DeleteUISchemasWithHttpInfoAsync("equiv-delete-id");

            clientA.ReceivedPath.Should().Be(clientB.ReceivedPath,
                "both Delete variants must call the same endpoint path");
        }

        [Fact]
        public async Task DeleteBothVariants_SetSamePathParameter()
        {
            var config = new Configuration { BasePath = BaseUrl };
            var clientA = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var clientB = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);

            await new UISchemaApi(clientA, config).DeleteUISchemasAsync("del-param-id");
            await new UISchemaApi(clientB, config).DeleteUISchemasWithHttpInfoAsync("del-param-id");

            clientA.ReceivedPathParams["id"].Should().Be(clientB.ReceivedPathParams["id"],
                "both Delete variants must pass the same path parameter value");
        }

        [Fact]
        public async Task GetBothVariants_UseSamePathAndAcceptHeader()
        {
            var json = SchemaResponseJson("equiv-get");
            var config = new Configuration { BasePath = BaseUrl };
            var clientA = new MockAsyncClient(json);
            var clientB = new MockAsyncClient(json);

            await new UISchemaApi(clientA, config).GetUISchemaAsync("equiv-get");
            await new UISchemaApi(clientB, config).GetUISchemaWithHttpInfoAsync("equiv-get");

            clientA.ReceivedPath.Should().Be(clientB.ReceivedPath,
                "both Get variants must call the same endpoint path");
            clientA.ReceivedHeaders["Accept"].Should()
                .BeEquivalentTo(clientB.ReceivedHeaders["Accept"],
                    "both Get variants must set the same Accept header");
        }

        [Fact]
        public async Task ReplaceBothVariants_UseSamePathBodyAndContentType()
        {
            var json = SchemaResponseJson("equiv-replace");
            var config = new Configuration { BasePath = BaseUrl };
            var clientA = new MockAsyncClient(json);
            var clientB = new MockAsyncClient(json);
            var body = ValidUpdateBody("Equiv Replace Label");

            await new UISchemaApi(clientA, config).ReplaceUISchemasAsync("equiv-replace-id", body);
            await new UISchemaApi(clientB, config).ReplaceUISchemasWithHttpInfoAsync("equiv-replace-id", body);

            clientA.ReceivedPath.Should().Be(clientB.ReceivedPath,
                "both Replace variants must call the same endpoint path");
            clientA.ReceivedBody.Should().Be(clientB.ReceivedBody,
                "both Replace variants must send the same serialized request body");
            clientA.ReceivedHeaders["Content-Type"].Should()
                .BeEquivalentTo(clientB.ReceivedHeaders["Content-Type"],
                    "both Replace variants must set the same Content-Type header");
        }

        [Fact]
        public async Task AllOperations_UseDistinctPaths()
        {
            // Belt-and-suspenders: confirm each operation targets the correct unique path
            var config = new Configuration { BasePath = BaseUrl };
            var clientCreate = new MockAsyncClient(SchemaResponseJson("c"));
            var clientDelete = new MockAsyncClient(NoContentBody, HttpStatusCode.NoContent);
            var clientGet = new MockAsyncClient(SchemaResponseJson("g"));
            var clientList = new MockAsyncClient(EmptyListJson());
            var clientReplace = new MockAsyncClient(SchemaResponseJson("r"));

            await new UISchemaApi(clientCreate, config).CreateUISchemaWithHttpInfoAsync(ValidCreateBody());
            await new UISchemaApi(clientDelete, config).DeleteUISchemasWithHttpInfoAsync("schema-x");
            await new UISchemaApi(clientGet, config).GetUISchemaWithHttpInfoAsync("schema-x");
            await new UISchemaApi(clientList, config).ListUISchemasWithHttpInfoAsync();
            await new UISchemaApi(clientReplace, config).ReplaceUISchemasWithHttpInfoAsync("schema-x", ValidUpdateBody());

            clientCreate.ReceivedPath.Should().Be("/api/v1/meta/uischemas");
            clientDelete.ReceivedPath.Should().Be("/api/v1/meta/uischemas/{id}");
            clientGet.ReceivedPath.Should().Be("/api/v1/meta/uischemas/{id}");
            clientList.ReceivedPath.Should().Be("/api/v1/meta/uischemas");
            clientReplace.ReceivedPath.Should().Be("/api/v1/meta/uischemas/{id}");
        }

        #endregion
    }
}
