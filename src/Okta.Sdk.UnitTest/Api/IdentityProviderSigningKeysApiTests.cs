// <copyright file="IdentityProviderSigningKeysApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

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
    /// <summary>
    /// Comprehensive unit tests for <see cref="IdentityProviderSigningKeysApi"/>.
    /// Covers signing key credentials, CSR lifecycle, and key management for a specific IdP.
    /// </summary>
    public class IdentityProviderSigningKeysApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestIdpId = "0oa1k5d68qR2954hb0g4";
        private const string TestKid = "mXtzOtml09Cg_v0JEDGkq";
        private const string TestCsrId = "h9zkutaSe7fZX0SwN1GqDApofgD1OW8g2B5l2azha50";

        private static string BuildKeyJson(string kid = TestKid, string kty = "RSA", string use = "sig") =>
            $@"{{
                ""kid"": ""{kid}"",
                ""kty"": ""{kty}"",
                ""use"": ""{use}"",
                ""e"": ""AQAB"",
                ""n"": ""mkC6yAJVvFwhb2IQjXmX0O2N6kNyJL-Oqa6iehfGFMlY"",
                ""x5c"": [""MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA""],
                ""created"": ""2015-12-10T18:56:23.000Z"",
                ""expiresAt"": ""2017-12-10T18:56:22.000Z"",
                ""lastUpdated"": ""2015-12-10T18:56:23.000Z""
            }}";

        private static string BuildCsrJson(string id = TestCsrId, string kty = "RSA") =>
            $@"{{
                ""id"": ""{id}"",
                ""kty"": ""{kty}"",
                ""created"": ""2017-04-19T12:50:58.000Z"",
                ""csr"": ""MIIC4DCCAcgCAQAwcTELMAkGA1UEBhMCVVMx""
            }}";

        #region CloneIdentityProviderKey Tests

        [Fact]
        public async Task CloneIdentityProviderKey_WithValidParams_ReturnsClonedKey()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.CloneIdentityProviderKeyAsync(TestIdpId, TestKid, "0oa2k5d68qR2954hb0g5");

            // Assert
            result.Should().NotBeNull();
            result.Kid.Should().Be(TestKid);
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/credentials/keys/{kid}/clone");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
            mockClient.ReceivedPathParams.Should().ContainKey("kid");
            mockClient.ReceivedPathParams["kid"].Should().Contain(TestKid);
        }

        [Fact]
        public async Task CloneIdentityProviderKey_SendsTargetIdpIdAsQueryParam()
        {
            // Arrange
            var targetIdpId = "0oa2k5d68qR2954hb0g5";
            var responseJson = BuildKeyJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.CloneIdentityProviderKeyAsync(TestIdpId, TestKid, targetIdpId);

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("targetIdpId");
            mockClient.ReceivedQueryParams["targetIdpId"].Should().Contain(targetIdpId);
        }

        [Fact]
        public async Task CloneIdentityProviderKey_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CloneIdentityProviderKeyAsync(null, TestKid, "targetId"));
        }

        [Fact]
        public async Task CloneIdentityProviderKey_WithNullKid_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CloneIdentityProviderKeyAsync(TestIdpId, null, "targetId"));
        }

        [Fact]
        public async Task CloneIdentityProviderKey_WithNullTargetIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CloneIdentityProviderKeyAsync(TestIdpId, TestKid, null));
        }

        [Fact]
        public async Task CloneIdentityProviderKeyWithHttpInfo_WithValidParams_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.CloneIdentityProviderKeyWithHttpInfoAsync(TestIdpId, TestKid, "targetId");

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Kid.Should().Be(TestKid);
        }

        #endregion

        #region GenerateCsrForIdentityProvider Tests

        [Fact]
        public async Task GenerateCsrForIdentityProvider_WithValidParams_ReturnsCsr()
        {
            // Arrange
            var responseJson = BuildCsrJson();
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            var metadata = new CsrMetadata();

            // Act
            var result = await api.GenerateCsrForIdentityProviderAsync(TestIdpId, metadata);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestCsrId);
            result.Kty.Should().Be("RSA");
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/credentials/csrs");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
        }

        [Fact]
        public async Task GenerateCsrForIdentityProvider_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GenerateCsrForIdentityProviderAsync(null, new CsrMetadata()));
        }

        [Fact]
        public async Task GenerateCsrForIdentityProvider_WithNullMetadata_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GenerateCsrForIdentityProviderAsync(TestIdpId, null));
        }

        [Fact]
        public async Task GenerateCsrForIdentityProviderWithHttpInfo_WithValidParams_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildCsrJson();
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created, headers);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GenerateCsrForIdentityProviderWithHttpInfoAsync(TestIdpId, new CsrMetadata());

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.Created);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestCsrId);
        }

        #endregion

        #region GenerateIdentityProviderSigningKey Tests

        [Fact]
        public async Task GenerateIdentityProviderSigningKey_WithValidParams_ReturnsKey()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GenerateIdentityProviderSigningKeyAsync(TestIdpId, 2);

            // Assert
            result.Should().NotBeNull();
            result.Kid.Should().Be(TestKid);
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/credentials/keys/generate");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
        }

        [Fact]
        public async Task GenerateIdentityProviderSigningKey_SendsValidityYearsAsQueryParam()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GenerateIdentityProviderSigningKeyAsync(TestIdpId, 5);

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("validityYears");
            mockClient.ReceivedQueryParams["validityYears"].Should().Contain("5");
        }

        [Fact]
        public async Task GenerateIdentityProviderSigningKey_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GenerateIdentityProviderSigningKeyAsync(null, 2));
        }

        [Fact]
        public async Task GenerateIdentityProviderSigningKeyWithHttpInfo_WithValidParams_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GenerateIdentityProviderSigningKeyWithHttpInfoAsync(TestIdpId, 2);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Kid.Should().Be(TestKid);
        }

        #endregion

        #region GetCsrForIdentityProvider Tests

        [Fact]
        public async Task GetCsrForIdentityProvider_WithValidParams_ReturnsCsr()
        {
            // Arrange
            var responseJson = BuildCsrJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetCsrForIdentityProviderAsync(TestIdpId, TestCsrId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestCsrId);
            result.Kty.Should().Be("RSA");
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/credentials/csrs/{idpCsrId}");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
            mockClient.ReceivedPathParams.Should().ContainKey("idpCsrId");
            mockClient.ReceivedPathParams["idpCsrId"].Should().Contain(TestCsrId);
        }

        [Fact]
        public async Task GetCsrForIdentityProvider_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetCsrForIdentityProviderAsync(null, TestCsrId));
        }

        [Fact]
        public async Task GetCsrForIdentityProvider_WithNullCsrId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetCsrForIdentityProviderAsync(TestIdpId, null));
        }

        [Fact]
        public async Task GetCsrForIdentityProviderWithHttpInfo_WithValidParams_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildCsrJson();
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetCsrForIdentityProviderWithHttpInfoAsync(TestIdpId, TestCsrId);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestCsrId);
            result.Headers.Should().ContainKey("Content-Type");
        }

        #endregion

        #region GetIdentityProviderSigningKey Tests

        [Fact]
        public async Task GetIdentityProviderSigningKey_WithValidParams_ReturnsKey()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetIdentityProviderSigningKeyAsync(TestIdpId, TestKid);

            // Assert
            result.Should().NotBeNull();
            result.Kid.Should().Be(TestKid);
            result.Kty.Should().Be("RSA");
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/credentials/keys/{kid}");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
            mockClient.ReceivedPathParams.Should().ContainKey("kid");
            mockClient.ReceivedPathParams["kid"].Should().Contain(TestKid);
        }

        [Fact]
        public async Task GetIdentityProviderSigningKey_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetIdentityProviderSigningKeyAsync(null, TestKid));
        }

        [Fact]
        public async Task GetIdentityProviderSigningKey_WithNullKid_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetIdentityProviderSigningKeyAsync(TestIdpId, null));
        }

        [Fact]
        public async Task GetIdentityProviderSigningKeyWithHttpInfo_WithValidParams_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetIdentityProviderSigningKeyWithHttpInfoAsync(TestIdpId, TestKid);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Kid.Should().Be(TestKid);
        }

        #endregion

        #region ListActiveIdentityProviderSigningKey Tests

        [Fact]
        public async Task ListActiveIdentityProviderSigningKey_WithValidIdpId_ReturnsKeys()
        {
            // Arrange
            var kid2 = "SIMcCQNY3uwXoW3y0vf6VxiBb5n9pf8L2fK8d-FIbm4";
            var responseJson = $"[{BuildKeyJson()}, {BuildKeyJson(kid2)}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListActiveIdentityProviderSigningKeyWithHttpInfoAsync(TestIdpId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Kid.Should().Be(TestKid);
            result.Data[1].Kid.Should().Be(kid2);
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/credentials/keys/active");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
        }

        [Fact]
        public async Task ListActiveIdentityProviderSigningKey_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ListActiveIdentityProviderSigningKeyWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task ListActiveIdentityProviderSigningKeyWithHttpInfo_ReturnsStatusCode200()
        {
            // Arrange
            var responseJson = $"[{BuildKeyJson()}]";
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListActiveIdentityProviderSigningKeyWithHttpInfoAsync(TestIdpId);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().HaveCount(1);
            result.Headers.Should().ContainKey("Content-Type");
        }

        #endregion

        #region ListCsrsForIdentityProvider Tests

        [Fact]
        public async Task ListCsrsForIdentityProvider_WithValidIdpId_ReturnsCsrs()
        {
            // Arrange
            var csrId2 = "abcdefg1234567890";
            var responseJson = $"[{BuildCsrJson()}, {BuildCsrJson(csrId2)}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListCsrsForIdentityProviderWithHttpInfoAsync(TestIdpId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Id.Should().Be(TestCsrId);
            result.Data[1].Id.Should().Be(csrId2);
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/credentials/csrs");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
        }

        [Fact]
        public async Task ListCsrsForIdentityProvider_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ListCsrsForIdentityProviderWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task ListCsrsForIdentityProviderWithHttpInfo_WithHeaders_ReturnsHeaders()
        {
            // Arrange
            var responseJson = $"[{BuildCsrJson()}]";
            var headers = new Multimap<string, string> { { "Link", "<https://test.okta.com/api/v1/idps/001/credentials/csrs?after=next>; rel=\"next\"" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListCsrsForIdentityProviderWithHttpInfoAsync(TestIdpId);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().HaveCount(1);
            result.Headers.Should().ContainKey("Link");
        }

        #endregion

        #region ListIdentityProviderSigningKeys Tests

        [Fact]
        public async Task ListIdentityProviderSigningKeys_WithValidIdpId_ReturnsKeys()
        {
            // Arrange
            var kid2 = "SIMcCQNY3uwXoW3y0vf6VxiBb5n9pf8L2fK8d-FIbm4";
            var responseJson = $"[{BuildKeyJson()}, {BuildKeyJson(kid2)}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProviderSigningKeysWithHttpInfoAsync(TestIdpId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Kid.Should().Be(TestKid);
            result.Data[1].Kid.Should().Be(kid2);
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/credentials/keys");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
        }

        [Fact]
        public async Task ListIdentityProviderSigningKeys_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ListIdentityProviderSigningKeysWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task ListIdentityProviderSigningKeysWithHttpInfo_ReturnsStatusCode200()
        {
            // Arrange
            var responseJson = $"[{BuildKeyJson()}]";
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProviderSigningKeysWithHttpInfoAsync(TestIdpId);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().HaveCount(1);
        }

        #endregion

        #region PublishCsrForIdentityProvider Tests

        [Fact(Skip = "MockAsyncClient cannot serialize System.IO.Stream as a request body — covered by integration tests")]
        public async Task PublishCsrForIdentityProvider_WithValidParams_ReturnsKey()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            var certData = System.Text.Encoding.UTF8.GetBytes("fake-certificate-data");
            using var body = new System.IO.MemoryStream(certData);

            // Act
            var result = await api.PublishCsrForIdentityProviderAsync(TestIdpId, TestCsrId, body);

            // Assert
            result.Should().NotBeNull();
            result.Kid.Should().Be(TestKid);
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/credentials/csrs/{idpCsrId}/lifecycle/publish");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
            mockClient.ReceivedPathParams.Should().ContainKey("idpCsrId");
            mockClient.ReceivedPathParams["idpCsrId"].Should().Contain(TestCsrId);
        }

        [Fact]
        public async Task PublishCsrForIdentityProvider_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });
            using var body = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("data"));

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.PublishCsrForIdentityProviderAsync(null, TestCsrId, body));
        }

        [Fact]
        public async Task PublishCsrForIdentityProvider_WithNullCsrId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });
            using var body = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("data"));

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.PublishCsrForIdentityProviderAsync(TestIdpId, null, body));
        }

        [Fact]
        public async Task PublishCsrForIdentityProvider_WithNullBody_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.PublishCsrForIdentityProviderAsync(TestIdpId, TestCsrId, null));
        }

        [Fact(Skip = "MockAsyncClient cannot serialize System.IO.Stream as a request body — covered by integration tests")]
        public async Task PublishCsrForIdentityProviderWithHttpInfo_WithValidParams_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildKeyJson();
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            var certData = System.Text.Encoding.UTF8.GetBytes("fake-certificate-data");
            using var body = new System.IO.MemoryStream(certData);

            // Act
            var result = await api.PublishCsrForIdentityProviderWithHttpInfoAsync(TestIdpId, TestCsrId, body);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Kid.Should().Be(TestKid);
        }

        #endregion

        #region RevokeCsrForIdentityProvider Tests

        [Fact]
        public async Task RevokeCsrForIdentityProvider_WithValidParams_CompletesSuccessfully()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.RevokeCsrForIdentityProviderAsync(TestIdpId, TestCsrId);

            // Assert — no exception means success
            mockClient.ReceivedPath.Should().Be("/api/v1/idps/{idpId}/credentials/csrs/{idpCsrId}");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
            mockClient.ReceivedPathParams.Should().ContainKey("idpCsrId");
            mockClient.ReceivedPathParams["idpCsrId"].Should().Contain(TestCsrId);
        }

        [Fact]
        public async Task RevokeCsrForIdentityProvider_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.RevokeCsrForIdentityProviderAsync(null, TestCsrId));
        }

        [Fact]
        public async Task RevokeCsrForIdentityProvider_WithNullCsrId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.RevokeCsrForIdentityProviderAsync(TestIdpId, null));
        }

        [Fact]
        public async Task RevokeCsrForIdentityProviderWithHttpInfo_WithValidParams_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new IdentityProviderSigningKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.RevokeCsrForIdentityProviderWithHttpInfoAsync(TestIdpId, TestCsrId);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        #endregion
    }
}
