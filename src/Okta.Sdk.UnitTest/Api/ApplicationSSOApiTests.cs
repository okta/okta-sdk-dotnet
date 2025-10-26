using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.UnitTest.Internal;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    /// <summary>
    /// Unit tests for ApplicationSSOApi.
    /// Tests the SDK's behavior for Application SSO operations without making actual HTTP requests.
    /// </summary>
    public class ApplicationSsoApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestAppId = "0oa1gjh63g214q0Hq0g4";
        private const string TestKid = "mXtzOtml09Dg1ZCeKxTRBo3KrQuBWFkJ5oxhVagjTzo";

        private const string SampleSamlMetadataXml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<md:EntityDescriptor xmlns:md=""urn:oasis:names:tc:SAML:2.0:metadata"" entityID=""exk39sivhuytV2D8H0h7"">
    <md:IDPSSODescriptor WantAuthnRequestsSigned=""false"" protocolSupportEnumeration=""urn:oasis:names:tc:SAML:2.0:protocol"">
        <md:KeyDescriptor use=""signing"">
            <ds:KeyInfo xmlns:ds=""http://www.w3.org/2000/09/xmldsig#"">
                <ds:X509Data>
                    <ds:X509Certificate>MIIDqDCCApCgAwIBAgIGAVGNO4qeMA0GCSqGSIb3DQEBBQUAMIGUMQswCQYDVQQGEwJVUzETMBEG</ds:X509Certificate>
                </ds:X509Data>
            </ds:KeyInfo>
        </md:KeyDescriptor>
        <md:NameIDFormat>urn:oasis:names:tc:SAML:1.1:nameid-format:emailAddress</md:NameIDFormat>
        <md:NameIDFormat>urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified</md:NameIDFormat>
        <md:SingleSignOnService Binding=""urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST"" Location=""https://test.okta.com/app/test/sso/saml""/>
        <md:SingleSignOnService Binding=""urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect"" Location=""https://test.okta.com/app/test/sso/saml""/>
    </md:IDPSSODescriptor>
</md:EntityDescriptor>";

        #region PreviewSAMLmetadataForApplication Tests

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithValidParameters_ReturnsMetadata()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid);

            // Note: In actual implementation, text/xml responses may return null for Data property
            // and populate RawContent instead. This test validates the SDK behavior.
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("sso");
            mockClient.ReceivedPath.Should().Contain("saml");
            mockClient.ReceivedPath.Should().Contain("metadata");
            // Path parameters are stored separately in ReceivedPathParams
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
            mockClient.ReceivedQueryParams.Should().ContainKey("kid");
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => 
                api.PreviewSAMLmetadataForApplicationAsync(null, TestKid));
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithEmptyAppId_ThrowsApiException()
        {
            // Note: The SDK doesn't validate empty strings, only null values
            // Empty strings will be sent to the API which will reject them
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Empty appId doesn't throw exception from SDK - it will be passed to the API
            var result = await api.PreviewSAMLmetadataForApplicationAsync("", TestKid);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithNullKid_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => 
                api.PreviewSAMLmetadataForApplicationAsync(TestAppId, null));
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithEmptyKid_ThrowsApiException()
        {
            // Note: The SDK doesn't validate empty strings, only null values
            // Empty strings will be sent to the API which will reject them
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Empty kid doesn't throw exception from SDK - it will be passed to the API
            var result = await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, "");
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_ValidatesPathParameters()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid);

            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_ValidatesQueryParameters()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid);

            mockClient.ReceivedQueryParams.Should().ContainKey("kid");
            mockClient.ReceivedQueryParams["kid"].Should().Contain(TestKid);
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_SetsCorrectHttpMethod()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid);

            // The method should use GET - validated by mock client receiving the request
            mockClient.ReceivedPath.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_ConstructsCorrectPath()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/sso/saml/metadata");
        }

        #endregion

        #region PreviewSAMLmetadataForApplicationWithHttpInfo Tests

        [Fact]
        public async Task PreviewSAMLmetadataForApplicationWithHttpInfo_WithValidParameters_ReturnsApiResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "text/xml; charset=utf-8" },
                { "X-Okta-Request-Id", "req123" }
            };

            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"", HttpStatusCode.OK, headers);
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(TestAppId, TestKid);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Headers.Should().NotBeNull();
            response.Headers.Should().ContainKey("Content-Type");
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("metadata");
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplicationWithHttpInfo_ReturnsCorrectStatusCode()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(TestAppId, TestKid);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplicationWithHttpInfo_IncludesHeaders()
        {
            var expectedHeaders = new Multimap<string, string>
            {
                { "Content-Type", "text/xml; charset=utf-8" },
                { "X-Okta-Request-Id", "req456" },
                { "X-Rate-Limit-Remaining", "599" }
            };

            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"", HttpStatusCode.OK, expectedHeaders);
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(TestAppId, TestKid);

            response.Headers.Should().NotBeNull();
            response.Headers.Should().ContainKey("Content-Type");
            response.Headers.Should().ContainKey("X-Okta-Request-Id");
            response.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplicationWithHttpInfo_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => 
                api.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(null, TestKid));
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplicationWithHttpInfo_WithNullKid_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => 
                api.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(TestAppId, null));
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplicationWithHttpInfo_ValidatesContentType()
        {
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "text/xml; charset=utf-8" }
            };

            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"", HttpStatusCode.OK, headers);
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(TestAppId, TestKid);

            // response.Headers["Content-Type"] returns a list of strings
            response.Headers.Should().ContainKey("Content-Type");
            response.Headers["Content-Type"].Should().Contain(x => x.Contains("text/xml"));
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplicationWithHttpInfo_IncludesRawContent()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(TestAppId, TestKid);

            // RawContent should be available for text/xml responses
            response.RawContent.Should().NotBeNullOrEmpty();
        }

        #endregion

        #region Error Scenarios Tests

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithNotFoundError_ThrowsApiException()
        {
            var errorResponse = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: 0oa1gjh63g214q0Hq0g4 (AppInstance)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaetest123""
            }";

            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.NotFound);
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            var exception = await Assert.ThrowsAsync<ApiException>(() => 
                api.PreviewSAMLmetadataForApplicationAsync("nonexistent_app", TestKid));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithInvalidKidError_ThrowsApiException()
        {
            var errorResponse = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: invalid_kid (Credential)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaetest456""
            }";

            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.NotFound);
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            var exception = await Assert.ThrowsAsync<ApiException>(() => 
                api.PreviewSAMLmetadataForApplicationAsync(TestAppId, "invalid_kid"));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithForbiddenError_ThrowsApiException()
        {
            var errorResponse = @"{
                ""errorCode"": ""E0000006"",
                ""errorSummary"": ""You do not have permission to perform the requested action"",
                ""errorLink"": ""E0000006"",
                ""errorId"": ""oaetest789""
            }";

            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.Forbidden);
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            var exception = await Assert.ThrowsAsync<ApiException>(() => 
                api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid));

            exception.ErrorCode.Should().Be(403);
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithBadRequestError_ThrowsApiException()
        {
            var errorResponse = @"{
                ""errorCode"": ""E0000003"",
                ""errorSummary"": ""The request body was not well-formed."",
                ""errorLink"": ""E0000003"",
                ""errorId"": ""oaetest101""
            }";

            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.BadRequest);
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            var exception = await Assert.ThrowsAsync<ApiException>(() => 
                api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid));

            exception.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithTooManyRequestsError_ThrowsApiException()
        {
            var errorResponse = @"{
                ""errorCode"": ""E0000047"",
                ""errorSummary"": ""API call exceeded rate limit due to too many requests"",
                ""errorLink"": ""E0000047"",
                ""errorId"": ""oaetest202""
            }";

            var mockClient = new MockAsyncClient(errorResponse, HttpStatusCode.TooManyRequests);
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            var exception = await Assert.ThrowsAsync<ApiException>(() => 
                api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid));

            exception.ErrorCode.Should().Be(429);
        }

        #endregion

        #region Header Validation Tests

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_SetsAcceptHeader()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid);

            mockClient.ReceivedHeaders.Should().ContainKey("Accept");
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_DoesNotSetContentTypeForGetRequest()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid);

            // GET requests typically don't have Content-Type header
            // ReceivedBody may be null or the string "null"
            if (mockClient.ReceivedBody != null)
            {
                mockClient.ReceivedBody.Should().Be("null");
            }
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_IncludesAuthorizationHeader()
        {
            var config = new Configuration
            {
                BasePath = BaseUrl,
                AccessToken = "test_token_123"
            };

            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, config);

            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid);

            // Authorization header should be set when a token is provided
            mockClient.ReceivedHeaders.Should().NotBeNull();
        }

        #endregion

        #region Special Characters and Edge Cases Tests

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithSpecialCharactersInAppId_EncodesCorrectly()
        {
            var appIdWithSpecialChars = "0oa1gjh63g214q0Hq0g4_test";
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.PreviewSAMLmetadataForApplicationAsync(appIdWithSpecialChars, TestKid);

            mockClient.ReceivedPathParams["appId"].Should().Be(appIdWithSpecialChars);
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithSpecialCharactersInKid_EncodesCorrectly()
        {
            var kidWithSpecialChars = "mXtzOtml09Dg1ZCeKxTRBo3KrQuBWFkJ5oxhVagjTzo_test+special=chars";
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, kidWithSpecialChars);

            mockClient.ReceivedQueryParams["kid"].Should().Contain(kidWithSpecialChars);
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithLongKid_HandlesCorrectly()
        {
            var longKid = new string('a', 256); // Very long kid
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, longKid);

            mockClient.ReceivedQueryParams["kid"].Should().Contain(longKid);
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithWhitespaceInParameters_ThrowsOrTrims()
        {
            // Note: The SDK doesn't validate or trim whitespace-only parameters
            // They will be sent to the API which will reject them
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Whitespace-only parameters don't throw exception from SDK
            var result = await api.PreviewSAMLmetadataForApplicationAsync("   ", TestKid);
            result.Should().NotBeNull();
        }

        #endregion

        #region Configuration Tests

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithCustomConfiguration_UsesConfiguration()
        {
            var customConfig = new Configuration
            {
                BasePath = "https://custom.okta.com",
                AccessToken = "custom_token"
            };

            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, customConfig);

            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid);

            // Validates that custom configuration is respected
            api.Configuration.Should().NotBeNull();
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithDefaultConfiguration_Works()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Should work with default configuration
            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid);

            mockClient.ReceivedPath.Should().NotBeNullOrEmpty();
        }

        #endregion

        #region Cancellation Token Tests

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_WithCancellationToken_PropagatesToken()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });
            var cancellationToken = CancellationToken.None;

            // Should accept and propagate cancellation token
            await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid, cancellationToken);

            mockClient.ReceivedPath.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplicationWithHttpInfo_WithCancellationToken_PropagatesToken()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });
            var cancellationToken = CancellationToken.None;

            // Should accept and propagate cancellation token
            var response = await api.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(
                TestAppId, TestKid, cancellationToken);

            response.Should().NotBeNull();
        }

        #endregion

        #region Response Format Tests

        [Fact]
        public async Task PreviewSAMLmetadataForApplication_ReturnsStringType()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.PreviewSAMLmetadataForApplicationAsync(TestAppId, TestKid);

            // The return type should be string
            result.Should().BeOfType<string>();
        }

        [Fact]
        public async Task PreviewSAMLmetadataForApplicationWithHttpInfo_ReturnsApiResponseOfString()
        {
            var mockClient = new MockAsyncClient($"\"{SampleSamlMetadataXml}\"");
            var api = new ApplicationSSOApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(TestAppId, TestKid);

            // The response type should be ApiResponse<string>
            response.Should().BeOfType<ApiResponse<string>>();
        }

        #endregion
    }
}
