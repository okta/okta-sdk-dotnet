// <copyright file="ApplicationSSOCredentialKeyApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

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
    /// Unit tests for ApplicationSSOCredentialKeyApi.
    /// Tests the SDK's behavior for Application SSO Credential Key operations without making actual HTTP requests.
    /// </summary>
    public class ApplicationSsoCredentialKeyApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestAppId = "0oa1gjh63g214q0Hq0g4";
        private const string TestKeyId = "mXtzOtml09Dg1ZCeKxTRBo3KrQuBWFkJ5oxhVagjTzo";
        private const string TestCsrId = "h9zkutaSe7fZX0SwN1GqDApofgD1OW8g2B5l2azha50";

        private const string SampleJsonWebKeyJson = @"{
            ""kid"": ""mXtzOtml09Dg1ZCeKxTRBo3KrQuBWFkJ5oxhVagjTzo"",
            ""kty"": ""RSA"",
            ""use"": ""sig"",
            ""x5c"": [""MIIDqDCCApCgAwIBAgIGAVGNO4qeMA0GCSqGSIb3DQEBBQUAMIGUMQswCQYDVQQGEwJVUzETMBEG""],
            ""n"": ""mkC6yAJVvFwUlmM9gKjb2d-YK5qHFt-mXSsbjWKKs4EfNm-BoQeeovBZtSACyaqLc8IYFTPEURFcbDQ9DkAL04uUIRD2gaHYY7uK0jsluEaXGq2RAIsmzAwNTzkiDw4q9pDL_q7n0f_SDt1TsMaMQayB6bU5jWsmqcWJ8MCRJ1aJMjZ16un5UVx51IIeCbe4QRDxEXGAvYNczsBoZxspDt28esSpq5W0dBFxcyGVudyl54Er3FzAguhgfMVjH-bUec9j2Tl40qDTktrYgYfxz9pfjm01Hl4WYP1YQxeETpSL7cQ5Ihz4jGDtHUEOcZ4GfJrPzrGpUrak8Qp5xcwCqQ"",
            ""e"": ""AQAB"",
            ""x5t#S256"": ""wzPVobIrveR1x-PCbjsFGNV-6zn7Rm9KuOWOG4Rk6jE""
        }";

        private const string SampleCsrJson = @"{
            ""id"": ""h9zkutaSe7fZX0SwN1GqDApofgD1OW8g2B5l2azha50"",
            ""created"": ""2017-03-28T01:11:10.000Z"",
            ""_csr"": ""-----BEGIN CERTIFICATE REQUEST-----\nMIICpTCCAY0CAQAwYDELMAkGA1UEBhMCVVMxEzARBgNVBAgMCkNhbGlmb3JuaWEx\n-----END CERTIFICATE REQUEST-----"",
            ""kty"": ""RSA""
        }";

        #region GenerateApplicationKey Tests

        [Fact]
        public async Task GenerateApplicationKey_WithValidParameters_ReturnsKey()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson, HttpStatusCode.Created);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GenerateApplicationKeyAsync(TestAppId, 2);

            result.Should().NotBeNull();
            result.Kid.Should().Be("mXtzOtml09Dg1ZCeKxTRBo3KrQuBWFkJ5oxhVagjTzo");
            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/keys/generate");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
            mockClient.ReceivedQueryParams.Should().ContainKey("validityYears");
        }

        [Fact]
        public async Task GenerateApplicationKey_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.GenerateApplicationKeyAsync(null, 2));
        }

        [Fact]
        public async Task GenerateApplicationKey_WithDefaultValidityYears_UsesCorrectValue()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson, HttpStatusCode.Created);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.GenerateApplicationKeyAsync(TestAppId, 5);

            mockClient.ReceivedQueryParams.Should().ContainKey("validityYears");
            mockClient.ReceivedQueryParams["validityYears"].Should().Contain("5");
        }

        [Fact]
        public async Task GenerateApplicationKey_ConstructsCorrectPath()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson, HttpStatusCode.Created);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.GenerateApplicationKeyAsync(TestAppId, 2);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/keys/generate");
        }

        #endregion

        #region GenerateApplicationKeyWithHttpInfo Tests

        [Fact]
        public async Task GenerateApplicationKeyWithHttpInfo_WithValidParameters_ReturnsApiResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Okta-Request-Id", "req123" }
            };

            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson, HttpStatusCode.Created, headers);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GenerateApplicationKeyWithHttpInfoAsync(TestAppId, 2);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Data.Should().NotBeNull();
            response.Data.Kid.Should().Be("mXtzOtml09Dg1ZCeKxTRBo3KrQuBWFkJ5oxhVagjTzo");
        }

        [Fact]
        public async Task GenerateApplicationKeyWithHttpInfo_ReturnsCorrectStatusCode()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson, HttpStatusCode.Created);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GenerateApplicationKeyWithHttpInfoAsync(TestAppId, 2);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task GenerateApplicationKeyWithHttpInfo_IncludesHeaders()
        {
            var expectedHeaders = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Rate-Limit-Remaining", "599" }
            };

            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson, HttpStatusCode.Created, expectedHeaders);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GenerateApplicationKeyWithHttpInfoAsync(TestAppId, 2);

            response.Headers.Should().ContainKey("Content-Type");
            response.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
        }

        #endregion

        #region CloneApplicationKey Tests

        [Fact]
        public async Task CloneApplicationKey_WithValidParameters_ReturnsKey()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson, HttpStatusCode.Created);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.CloneApplicationKeyAsync(TestAppId, TestKeyId, "0oa2target");

            result.Should().NotBeNull();
            result.Kid.Should().Be("mXtzOtml09Dg1ZCeKxTRBo3KrQuBWFkJ5oxhVagjTzo");
            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/keys/{keyId}/clone");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
            mockClient.ReceivedPathParams.Should().ContainKey("keyId");
            mockClient.ReceivedPathParams["keyId"].Should().Be(TestKeyId);
            mockClient.ReceivedQueryParams.Should().ContainKey("targetAid");
        }

        [Fact]
        public async Task CloneApplicationKey_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.CloneApplicationKeyAsync(null, TestKeyId, "0oa2target"));
        }

        [Fact]
        public async Task CloneApplicationKey_WithNullKeyId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.CloneApplicationKeyAsync(TestAppId, null, "0oa2target"));
        }

        [Fact]
        public async Task CloneApplicationKey_WithNullTargetAid_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.CloneApplicationKeyAsync(TestAppId, TestKeyId, null));
        }

        [Fact]
        public async Task CloneApplicationKey_ConstructsCorrectPath()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson, HttpStatusCode.Created);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.CloneApplicationKeyAsync(TestAppId, TestKeyId, "0oa2target");

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/keys/{keyId}/clone");
        }

        #endregion

        #region CloneApplicationKeyWithHttpInfo Tests

        [Fact]
        public async Task CloneApplicationKeyWithHttpInfo_WithValidParameters_ReturnsApiResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Okta-Request-Id", "req456" }
            };

            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson, HttpStatusCode.Created, headers);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.CloneApplicationKeyWithHttpInfoAsync(TestAppId, TestKeyId, "0oa2target");

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region ListApplicationKeys Tests

        [Fact]
        public async Task ListApplicationKeysWithHttpInfo_WithValidParameters_ReturnsApiResponse()
        {
            var mockJson = $@"[{SampleJsonWebKeyJson}]";
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" }
            };

            var mockClient = new MockAsyncClient(mockJson, HttpStatusCode.OK, headers);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListApplicationKeysWithHttpInfoAsync(TestAppId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(1);
            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/keys");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
        }

        [Fact]
        public void ListApplicationKeys_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            Assert.Throws<ApiException>(() =>
                api.ListApplicationKeys(null));
        }

        #endregion

        #region ListApplicationKeysWithHttpInfo Tests

        [Fact]
        public async Task ListApplicationKeysWithHttpInfo_ReturnsCorrectStatusCode()
        {
            var mockJson = $@"[{SampleJsonWebKeyJson}]";
            var mockClient = new MockAsyncClient(mockJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListApplicationKeysWithHttpInfoAsync(TestAppId);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region GetApplicationKey Tests

        [Fact]
        public async Task GetApplicationKey_WithValidParameters_ReturnsKey()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetApplicationKeyAsync(TestAppId, TestKeyId);

            result.Should().NotBeNull();
            result.Kid.Should().Be("mXtzOtml09Dg1ZCeKxTRBo3KrQuBWFkJ5oxhVagjTzo");
            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/keys/{keyId}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
            mockClient.ReceivedPathParams.Should().ContainKey("keyId");
            mockClient.ReceivedPathParams["keyId"].Should().Be(TestKeyId);
        }

        [Fact]
        public async Task GetApplicationKey_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetApplicationKeyAsync(null, TestKeyId));
        }

        [Fact]
        public async Task GetApplicationKey_WithNullKeyId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetApplicationKeyAsync(TestAppId, null));
        }

        [Fact]
        public async Task GetApplicationKey_ConstructsCorrectPath()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.GetApplicationKeyAsync(TestAppId, TestKeyId);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/keys/{keyId}");
        }

        #endregion

        #region GetApplicationKeyWithHttpInfo Tests

        [Fact]
        public async Task GetApplicationKeyWithHttpInfo_WithValidParameters_ReturnsApiResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Okta-Request-Id", "req789" }
            };

            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson, HttpStatusCode.OK, headers);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetApplicationKeyWithHttpInfoAsync(TestAppId, TestKeyId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Kid.Should().Be("mXtzOtml09Dg1ZCeKxTRBo3KrQuBWFkJ5oxhVagjTzo");
        }

        #endregion

        #region GenerateCsrForApplication Tests

        [Fact]
        public async Task GenerateCsrForApplication_WithValidParameters_ReturnsCsr()
        {
            var mockClient = new MockAsyncClient(SampleCsrJson, HttpStatusCode.Created);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var metadata = new CsrMetadata
            {
                Subject = new CsrMetadataSubject
                {
                    CountryName = "US",
                    StateOrProvinceName = "California",
                    LocalityName = "San Francisco",
                    OrganizationName = "Example Company",
                    OrganizationalUnitName = "IT",
                    CommonName = "SP Issuer"
                },
                SubjectAltNames = new CsrMetadataSubjectAltNames
                {
                    DnsNames = ["example.com"]
                }
            };

            var result = await api.GenerateCsrForApplicationAsync(TestAppId, metadata);

            result.Should().NotBeNullOrEmpty();
            result.Should().Contain("-----BEGIN CERTIFICATE REQUEST-----");
            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/csrs");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
        }

        [Fact]
        public async Task GenerateCsrForApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleCsrJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var metadata = new CsrMetadata
            {
                Subject = new CsrMetadataSubject { CommonName = "test" }
            };

            await Assert.ThrowsAsync<ApiException>(() =>
                api.GenerateCsrForApplicationAsync(null, metadata));
        }

        [Fact]
        public async Task GenerateCsrForApplication_WithNullMetadata_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleCsrJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.GenerateCsrForApplicationAsync(TestAppId, null));
        }

        [Fact]
        public async Task GenerateCsrForApplication_ConstructsCorrectPath()
        {
            var mockClient = new MockAsyncClient(SampleCsrJson, HttpStatusCode.Created);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var metadata = new CsrMetadata
            {
                Subject = new CsrMetadataSubject { CommonName = "test" }
            };

            await api.GenerateCsrForApplicationAsync(TestAppId, metadata);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/csrs");
        }

        #endregion

        #region GenerateCsrForApplicationWithHttpInfo Tests

        [Fact]
        public async Task GenerateCsrForApplicationWithHttpInfo_WithValidParameters_ReturnsApiResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Okta-Request-Id", "req101" }
            };

            var mockClient = new MockAsyncClient(SampleCsrJson, HttpStatusCode.Created, headers);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var metadata = new CsrMetadata
            {
                Subject = new CsrMetadataSubject { CommonName = "test" }
            };

            var response = await api.GenerateCsrForApplicationWithHttpInfoAsync(TestAppId, metadata);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Data.Should().NotBeNullOrEmpty();
            response.Data.Should().Contain("-----BEGIN CERTIFICATE REQUEST-----");
        }

        #endregion

        #region ListCsrsForApplication Tests

        [Fact]
        public async Task ListCsrsForApplicationWithHttpInfo_WithValidParameters_ReturnsApiResponse()
        {
            var mockJson = $@"[{SampleCsrJson}]";
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" }
            };

            var mockClient = new MockAsyncClient(mockJson, HttpStatusCode.OK, headers);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListCsrsForApplicationWithHttpInfoAsync(TestAppId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(1);
            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/csrs");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
        }

        [Fact]
        public void ListCsrsForApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            Assert.Throws<ApiException>(() =>
                api.ListCsrsForApplication(null));
        }

        #endregion

        #region ListCsrsForApplicationWithHttpInfo Tests

        [Fact]
        public async Task ListCsrsForApplicationWithHttpInfo_ReturnsCorrectStatusCode()
        {
            var mockJson = $@"[{SampleCsrJson}]";
            var mockClient = new MockAsyncClient(mockJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListCsrsForApplicationWithHttpInfoAsync(TestAppId);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region GetCsrForApplication Tests

        [Fact]
        public async Task GetCsrForApplication_WithValidParameters_ReturnsCsr()
        {
            var mockClient = new MockAsyncClient(SampleCsrJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetCsrForApplicationAsync(TestAppId, TestCsrId);

            result.Should().NotBeNull();
            result.Id.Should().Be("h9zkutaSe7fZX0SwN1GqDApofgD1OW8g2B5l2azha50");
            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/csrs/{csrId}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
            mockClient.ReceivedPathParams.Should().ContainKey("csrId");
            mockClient.ReceivedPathParams["csrId"].Should().Be(TestCsrId);
        }

        [Fact]
        public async Task GetCsrForApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleCsrJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetCsrForApplicationAsync(null, TestCsrId));
        }

        [Fact]
        public async Task GetCsrForApplication_WithNullCsrId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleCsrJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetCsrForApplicationAsync(TestAppId, null));
        }

        [Fact]
        public async Task GetCsrForApplication_ConstructsCorrectPath()
        {
            var mockClient = new MockAsyncClient(SampleCsrJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.GetCsrForApplicationAsync(TestAppId, TestCsrId);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/csrs/{csrId}");
        }

        #endregion

        #region GetCsrForApplicationWithHttpInfo Tests

        [Fact]
        public async Task GetCsrForApplicationWithHttpInfo_WithValidParameters_ReturnsApiResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Okta-Request-Id", "req202" }
            };

            var mockClient = new MockAsyncClient(SampleCsrJson, HttpStatusCode.OK, headers);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetCsrForApplicationWithHttpInfoAsync(TestAppId, TestCsrId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be("h9zkutaSe7fZX0SwN1GqDApofgD1OW8g2B5l2azha50");
        }

        #endregion

        #region RevokeCsrFromApplication Tests

        [Fact]
        public async Task RevokeCsrFromApplication_WithValidParameters_Succeeds()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.RevokeCsrFromApplicationAsync(TestAppId, TestCsrId);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/csrs/{csrId}");
            mockClient.ReceivedPathParams.Should().ContainKey("appId");
            mockClient.ReceivedPathParams["appId"].Should().Be(TestAppId);
            mockClient.ReceivedPathParams.Should().ContainKey("csrId");
            mockClient.ReceivedPathParams["csrId"].Should().Be(TestCsrId);
        }

        [Fact]
        public async Task RevokeCsrFromApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("");
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.RevokeCsrFromApplicationAsync(null, TestCsrId));
        }

        [Fact]
        public async Task RevokeCsrFromApplication_WithNullCsrId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("");
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.RevokeCsrFromApplicationAsync(TestAppId, null));
        }

        [Fact]
        public async Task RevokeCsrFromApplication_ConstructsCorrectPath()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.RevokeCsrFromApplicationAsync(TestAppId, TestCsrId);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/credentials/csrs/{csrId}");
        }

        #endregion

        #region RevokeCsrFromApplicationWithHttpInfo Tests

        [Fact]
        public async Task RevokeCsrFromApplicationWithHttpInfo_WithValidParameters_ReturnsApiResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "X-Okta-Request-Id", "req303" }
            };

            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent, headers);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.RevokeCsrFromApplicationWithHttpInfoAsync(TestAppId, TestCsrId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        #endregion

        #region PublishCsrFromApplication Tests

        // Note: PublishCsrFromApplication uses Stream parameters which are difficult to mock
        // in unit tests due to JSON serialization of Stream objects.
        // These methods are better tested in integration tests.

        [Fact]
        public async Task PublishCsrFromApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var certStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(
                "-----BEGIN CERTIFICATE-----\ncert\n-----END CERTIFICATE-----"));

            await Assert.ThrowsAsync<ApiException>(() =>
                api.PublishCsrFromApplicationAsync(null, TestCsrId, certStream));
        }

        [Fact]
        public async Task PublishCsrFromApplication_WithNullCsrId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var certStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(
                "-----BEGIN CERTIFICATE-----\ncert\n-----END CERTIFICATE-----"));

            await Assert.ThrowsAsync<ApiException>(() =>
                api.PublishCsrFromApplicationAsync(TestAppId, null, certStream));
        }

        [Fact]
        public async Task PublishCsrFromApplication_WithNullCertificate_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient(SampleJsonWebKeyJson);
            var api = new ApplicationSSOCredentialKeyApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.PublishCsrFromApplicationAsync(TestAppId, TestCsrId, null));
        }

        #endregion
    }
}
