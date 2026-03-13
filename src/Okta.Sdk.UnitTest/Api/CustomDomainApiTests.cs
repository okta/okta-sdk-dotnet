// <copyright file="CustomDomainApiTests.cs" company="Okta, Inc">
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
    /// Unit tests for CustomDomainApi.
    /// Covers all 14 methods (7 operations × 2 variants):
    ///   CreateCustomDomain, DeleteCustomDomain, GetCustomDomain,
    ///   ListCustomDomains, ReplaceCustomDomain, UpsertCertificate, VerifyDomain.
    ///
    /// Endpoint mapping
    /// ─────────────────────────────────────────────────────────────────────────
    /// CreateCustomDomain    POST   /api/v1/domains
    /// DeleteCustomDomain    DELETE /api/v1/domains/{domainId}
    /// GetCustomDomain       GET    /api/v1/domains/{domainId}
    /// ListCustomDomains     GET    /api/v1/domains
    /// ReplaceCustomDomain   PUT    /api/v1/domains/{domainId}
    /// UpsertCertificate     PUT    /api/v1/domains/{domainId}/certificate
    /// VerifyDomain          POST   /api/v1/domains/{domainId}/verify
    /// </summary>
    public class CustomDomainApiTests
    {
        private const string BaseUrl  = "https://test.okta.com";
        private const string DomainId = "OcDz6iRyjkaCTX7Wfb4h";
        private const string BrandId  = "bnd1ab2c3d4e5f6g7h8i";

        // ─────────────────────────────────────────────────────────────────────
        #region CreateCustomDomain

        [Fact]
        public async Task CreateCustomDomain_WithValidRequest_ReturnsDomainResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildDomainResponseJson(DomainId, "login.example.com"), HttpStatusCode.OK);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new DomainRequest { Domain = "login.example.com", CertificateSourceType = DomainCertificateSourceType.MANUAL };

            // Act
            var result = await api.CreateCustomDomainAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(DomainId);
            result.Domain.Should().Be("login.example.com");
            mockClient.ReceivedPath.Should().Be("/api/v1/domains");
            mockClient.ReceivedBody.Should().Contain("login.example.com");
        }

        [Fact]
        public async Task CreateCustomDomain_WithOktaManagedCertificate_SendsCorrectCertificateSourceType()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildDomainResponseJson(DomainId, "portal.example.com"));
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.CreateCustomDomainAsync(new DomainRequest
            {
                Domain = "portal.example.com",
                CertificateSourceType = DomainCertificateSourceType.OKTAMANAGED
            });

            // Assert
            mockClient.ReceivedBody.Should().Contain("OKTA_MANAGED");
        }

        [Fact]
        public async Task CreateCustomDomain_WithNullRequest_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CreateCustomDomainAsync(null));
        }

        [Fact]
        public async Task CreateCustomDomain_ResponseMapsAllFields()
        {
            // Arrange
            var json = $@"{{
                ""id"":""{DomainId}"",
                ""domain"":""login.example.com"",
                ""brandId"":""{BrandId}"",
                ""validationStatus"":""NOT_STARTED"",
                ""dnsRecords"":[],
                ""_links"":{{""self"":{{""href"":""https://test.okta.com/api/v1/domains/{DomainId}""}}}}
            }}";
            var mockClient = new MockAsyncClient(json);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.CreateCustomDomainAsync(new DomainRequest { Domain = "login.example.com" });

            // Assert
            result.Id.Should().Be(DomainId);
            result.BrandId.Should().Be(BrandId);
            result.ValidationStatus.Value.Should().Be("NOT_STARTED");
            result.DnsRecords.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateCustomDomainWithHttpInfo_ReturnsStatusCode200AndDomain()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildDomainResponseJson(DomainId, "login.example.com"), HttpStatusCode.OK);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.CreateCustomDomainWithHttpInfoAsync(new DomainRequest { Domain = "login.example.com" });

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(DomainId);
            mockClient.ReceivedPath.Should().Be("/api/v1/domains");
        }

        [Fact]
        public async Task CreateCustomDomainWithHttpInfo_WithNullRequest_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CreateCustomDomainWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region DeleteCustomDomain

        [Fact]
        public async Task DeleteCustomDomain_WithValidId_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.DeleteCustomDomainAsync(DomainId);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/domains/{domainId}");
            mockClient.ReceivedPathParams.Should().ContainKey("domainId");
            mockClient.ReceivedPathParams["domainId"].Should().Be(DomainId);
        }

        [Fact]
        public async Task DeleteCustomDomain_WithNullDomainId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteCustomDomainAsync(null));
        }

        [Fact]
        public async Task DeleteCustomDomainWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteCustomDomainWithHttpInfoAsync(DomainId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Be("/api/v1/domains/{domainId}");
            mockClient.ReceivedPathParams["domainId"].Should().Be(DomainId);
        }

        [Fact]
        public async Task DeleteCustomDomainWithHttpInfo_WithNullDomainId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteCustomDomainWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetCustomDomain

        [Fact]
        public async Task GetCustomDomain_WithValidId_ReturnsDomainResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildDomainResponseJson(DomainId, "login.example.com"));
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetCustomDomainAsync(DomainId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(DomainId);
            result.Domain.Should().Be("login.example.com");
            mockClient.ReceivedPath.Should().Be("/api/v1/domains/{domainId}");
            mockClient.ReceivedPathParams["domainId"].Should().Be(DomainId);
        }

        [Fact]
        public async Task GetCustomDomain_ResponseIncludesDnsRecords()
        {
            // Arrange
            var json = $@"{{
                ""id"":""{DomainId}"",
                ""domain"":""login.example.com"",
                ""validationStatus"":""NOT_STARTED"",
                ""dnsRecords"":[
                    {{""recordType"":""TXT"",""fqdn"":""_oktaverification.login.example.com"",""values"":[""abc123""]}}
                ]
            }}";
            var mockClient = new MockAsyncClient(json);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetCustomDomainAsync(DomainId);

            // Assert
            result.DnsRecords.Should().NotBeNull().And.HaveCount(1);
            result.DnsRecords[0].Fqdn.Should().Be("_oktaverification.login.example.com");
        }

        [Fact]
        public async Task GetCustomDomain_WithVerifiedStatus_ReturnsVerifiedStatus()
        {
            // Arrange
            var json = $@"{{""id"":""{DomainId}"",""domain"":""login.example.com"",""validationStatus"":""VERIFIED""}}";
            var mockClient = new MockAsyncClient(json);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetCustomDomainAsync(DomainId);

            // Assert
            result.ValidationStatus.Value.Should().Be("VERIFIED");
        }

        [Fact]
        public async Task GetCustomDomain_WithNullDomainId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetCustomDomainAsync(null));
        }

        [Fact]
        public async Task GetCustomDomainWithHttpInfo_ReturnsStatusCode200AndDomain()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildDomainResponseJson(DomainId, "login.example.com"), HttpStatusCode.OK);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetCustomDomainWithHttpInfoAsync(DomainId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(DomainId);
            mockClient.ReceivedPathParams["domainId"].Should().Be(DomainId);
        }

        [Fact]
        public async Task GetCustomDomainWithHttpInfo_WithNullDomainId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetCustomDomainWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ListCustomDomains

        [Fact]
        public async Task ListCustomDomains_ReturnsDomainsCollection()
        {
            // Arrange
            var domain1Json = BuildDomainResponseJson(DomainId, "login.example.com");
            var json = $@"{{""domains"":[{domain1Json},{{""id"":""dom2xxxxxxxx"",""domain"":""portal.example.com"",""validationStatus"":""VERIFIED""}}]}}";
            var mockClient = new MockAsyncClient(json);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListCustomDomainsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Domains.Should().HaveCount(2);
            result.Domains[0].Id.Should().Be(DomainId);
            result.Domains[1].Domain.Should().Be("portal.example.com");
            mockClient.ReceivedPath.Should().Be("/api/v1/domains");
        }

        [Fact]
        public async Task ListCustomDomains_WithEmptyList_ReturnsEmptyDomains()
        {
            // Arrange
            var mockClient = new MockAsyncClient(@"{""domains"":[]}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListCustomDomainsAsync();

            // Assert
            result.Domains.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task ListCustomDomainsWithHttpInfo_ReturnsStatusCode200AndDomainList()
        {
            // Arrange
            var domainJson = BuildDomainResponseJson(DomainId, "login.example.com");
            var json = $@"{{""domains"":[{domainJson}]}}";
            var mockClient = new MockAsyncClient(json, HttpStatusCode.OK);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListCustomDomainsWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Domains.Should().HaveCount(1);
            response.Data.Domains[0].Id.Should().Be(DomainId);
            mockClient.ReceivedPath.Should().Be("/api/v1/domains");
        }

        [Fact]
        public async Task ListCustomDomainsWithHttpInfo_WithMultipleDomains_ReturnsAllDomains()
        {
            // Arrange
            var json = @"{""domains"":[
                {""id"":""dom1"",""domain"":""d1.example.com"",""validationStatus"":""VERIFIED""},
                {""id"":""dom2"",""domain"":""d2.example.com"",""validationStatus"":""NOT_STARTED""},
                {""id"":""dom3"",""domain"":""d3.example.com"",""validationStatus"":""COMPLETED""}
            ]}";
            var mockClient = new MockAsyncClient(json);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListCustomDomainsWithHttpInfoAsync();

            // Assert
            response.Data.Domains.Should().HaveCount(3);
            response.Data.Domains[2].ValidationStatus.Value.Should().Be("COMPLETED");
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ReplaceCustomDomain

        [Fact]
        public async Task ReplaceCustomDomain_WithValidData_ReturnsDomainResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildDomainResponseJson(DomainId, "login.example.com"));
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ReplaceCustomDomainAsync(DomainId, new UpdateDomain { BrandId = BrandId });

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(DomainId);
            mockClient.ReceivedPath.Should().Be("/api/v1/domains/{domainId}");
            mockClient.ReceivedPathParams["domainId"].Should().Be(DomainId);
            mockClient.ReceivedBody.Should().Contain(BrandId);
        }

        [Fact]
        public async Task ReplaceCustomDomain_WithNullDomainId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceCustomDomainAsync(null, new UpdateDomain()));
        }

        [Fact]
        public async Task ReplaceCustomDomain_WithNullBody_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceCustomDomainAsync(DomainId, null));
        }

        [Fact]
        public async Task ReplaceCustomDomainWithHttpInfo_ReturnsStatusCode200AndDomain()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildDomainResponseJson(DomainId, "login.example.com"), HttpStatusCode.OK);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplaceCustomDomainWithHttpInfoAsync(DomainId, new UpdateDomain { BrandId = BrandId });

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Id.Should().Be(DomainId);
            mockClient.ReceivedPathParams["domainId"].Should().Be(DomainId);
        }

        [Fact]
        public async Task ReplaceCustomDomainWithHttpInfo_WithNullDomainId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceCustomDomainWithHttpInfoAsync(null, new UpdateDomain()));
        }

        [Fact]
        public async Task ReplaceCustomDomainWithHttpInfo_WithNullBody_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceCustomDomainWithHttpInfoAsync(DomainId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region UpsertCertificate

        [Fact]
        public async Task UpsertCertificate_WithValidData_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });
            var cert = new DomainCertificate
            {
                Type = DomainCertificateType.PEM,
                Certificate = "-----BEGIN CERTIFICATE-----\nMIIB...\n-----END CERTIFICATE-----",
                CertificateChain = "-----BEGIN CERTIFICATE-----\nchain...\n-----END CERTIFICATE-----",
                PrivateKey = "-----BEGIN RSA PRIVATE KEY-----\nkey...\n-----END RSA PRIVATE KEY-----"
            };

            // Act
            var act = async () => await api.UpsertCertificateAsync(DomainId, cert);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/domains/{domainId}/certificate");
            mockClient.ReceivedPathParams["domainId"].Should().Be(DomainId);
        }

        [Fact]
        public async Task UpsertCertificate_SendsCertificateTypeInBody()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.UpsertCertificateAsync(DomainId, new DomainCertificate { Type = DomainCertificateType.PEM });

            // Assert
            mockClient.ReceivedBody.Should().Contain("PEM");
        }

        [Fact]
        public async Task UpsertCertificate_WithNullDomainId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UpsertCertificateAsync(null, new DomainCertificate()));
        }

        [Fact]
        public async Task UpsertCertificate_WithNullCertificate_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UpsertCertificateAsync(DomainId, null));
        }

        [Fact]
        public async Task UpsertCertificateWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.UpsertCertificateWithHttpInfoAsync(DomainId, new DomainCertificate { Type = DomainCertificateType.PEM });

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Be("/api/v1/domains/{domainId}/certificate");
            mockClient.ReceivedPathParams["domainId"].Should().Be(DomainId);
        }

        [Fact]
        public async Task UpsertCertificateWithHttpInfo_WithNullDomainId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UpsertCertificateWithHttpInfoAsync(null, new DomainCertificate()));
        }

        [Fact]
        public async Task UpsertCertificateWithHttpInfo_WithNullCertificate_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UpsertCertificateWithHttpInfoAsync(DomainId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region VerifyDomain

        [Fact]
        public async Task VerifyDomain_WithValidId_ReturnsDomainResponseWithVerifiedStatus()
        {
            // Arrange
            var json = $@"{{""id"":""{DomainId}"",""domain"":""login.example.com"",""validationStatus"":""VERIFIED""}}";
            var mockClient = new MockAsyncClient(json);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.VerifyDomainAsync(DomainId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(DomainId);
            result.ValidationStatus.Value.Should().Be("VERIFIED");
            mockClient.ReceivedPath.Should().Be("/api/v1/domains/{domainId}/verify");
            mockClient.ReceivedPathParams["domainId"].Should().Be(DomainId);
        }

        [Fact]
        public async Task VerifyDomain_WithNotStartedStatus_ReturnsNotStartedStatus()
        {
            // Arrange
            var json = $@"{{""id"":""{DomainId}"",""domain"":""login.example.com"",""validationStatus"":""NOT_STARTED""}}";
            var mockClient = new MockAsyncClient(json);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.VerifyDomainAsync(DomainId);

            // Assert
            result.ValidationStatus.Value.Should().Be("NOT_STARTED");
        }

        [Fact]
        public async Task VerifyDomain_WithNullDomainId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.VerifyDomainAsync(null));
        }

        [Fact]
        public async Task VerifyDomainWithHttpInfo_ReturnsStatusCode200AndVerifiedDomain()
        {
            // Arrange
            var json = $@"{{""id"":""{DomainId}"",""domain"":""login.example.com"",""validationStatus"":""VERIFIED""}}";
            var mockClient = new MockAsyncClient(json, HttpStatusCode.OK);
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.VerifyDomainWithHttpInfoAsync(DomainId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(DomainId);
            response.Data.ValidationStatus.Value.Should().Be("VERIFIED");
            mockClient.ReceivedPath.Should().Be("/api/v1/domains/{domainId}/verify");
            mockClient.ReceivedPathParams["domainId"].Should().Be(DomainId);
        }

        [Fact]
        public async Task VerifyDomainWithHttpInfo_WithNullDomainId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomDomainApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.VerifyDomainWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region Helpers

        private static string BuildDomainResponseJson(string id, string domain) =>
            $@"{{
                ""id"":""{id}"",
                ""domain"":""{domain}"",
                ""brandId"":""{BrandId}"",
                ""validationStatus"":""NOT_STARTED"",
                ""certificateSourceType"":""MANUAL"",
                ""dnsRecords"":[],
                ""_links"":{{""self"":{{""href"":""https://test.okta.com/api/v1/domains/{id}""}}}}
            }}";

        #endregion
    }
}
