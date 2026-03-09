// <copyright file="CustomDomainApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for CustomDomainApi covering all 7 unique operations (14 methods incl. WithHttpInfo variants).
    ///
    /// CustomDomainApi → Endpoint Mapping
    /// ─────────────────────────────────────────────────────────────────────────────────────────────
    /// CreateCustomDomainAsync     POST   /api/v1/domains
    /// ListCustomDomainsAsync      GET    /api/v1/domains
    /// GetCustomDomainAsync        GET    /api/v1/domains/{domainId}
    /// ReplaceCustomDomainAsync    PUT    /api/v1/domains/{domainId}
    /// VerifyDomainAsync           POST   /api/v1/domains/{domainId}/verify
    /// UpsertCertificateAsync      PUT    /api/v1/domains/{domainId}/certificate
    /// DeleteCustomDomainAsync     DELETE /api/v1/domains/{domainId}
    ///
    /// Key constraints discovered via curl validation:
    /// - Domain names must not be prohibited (e.g. oktapreview.com subdomains are blocked).
    ///   The pattern "sdk-test-{uuid8}.dotnet-sdk-dcp.com" is accepted by this test org.
    /// - CreateCustomDomain returns HTTP 201 (not 200).
    /// - Creating a domain auto-creates a brand associated with it; that brand is captured
    ///   from the response (BrandId) and deleted in teardown to avoid brand accumulation.
    ///   Deleting the domain does NOT automatically delete the auto-created brand.
    /// - CertificateSourceType=OKTA_MANAGED: DNS records are TXT (_acme-challenge.*), CAA, CNAME.
    /// - CertificateSourceType=MANUAL:       DNS records are TXT (_oktaverification.*) and CNAME only (no CAA).
    /// - ReplaceCustomDomainAsync requires a non-default brandId. Providing the default brandId
    ///   returns HTTP 409 E0000203. A pre-existing non-default brand is discovered at runtime via BrandsApi.
    /// - VerifyDomainAsync always returns HTTP 200; when DNS is not configured in the test
    ///   environment the ValidationStatus in the body reflects the failure (e.g. "FAILED_TO_VERIFY").
    /// - UpsertCertificateAsync (PUT /certificate) returns HTTP 403 E0000165 when the domain has
    ///   not been verified. Since DNS verification cannot be completed in automated tests,
    ///   UpsertCertificate is exercised as a negative scenario (403) only.
    /// - All operations with a non-existent domainId return HTTP 404 E0000163.
    /// - DeleteCustomDomainAsync returns HTTP 204 with an empty body.
    ///
    /// No hardcoded IDs — the default brand and non-default brand are discovered at runtime.
    ///
    /// Teardown:
    ///   - Both test domains are deleted in the finally block.
    ///   - The brands auto-created by CreateCustomDomain are also deleted to keep the org clean.
    /// </summary>
    public class CustomDomainApiTests
    {
        private readonly CustomDomainApi _customDomainApi = new();
        private readonly BrandsApi _brandsApi = new();

        /// <summary>
        /// Returns a unique domain name suitable for this test org.
        /// The ".dotnet-sdk-dcp.com" suffix is not restricted by the Okta preview org's domain policy.
        /// </summary>
        private static string TestDomainName(string suffix) =>
            $"sdk-test-{suffix}.dotnet-sdk-dcp.com";

        [Fact]
        public async Task GivenCustomDomainApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string domain1Id           = null;
            string autoCreatedBrand1Id = null;
            string domain2Id           = null;
            string autoCreatedBrand2Id = null;

            try
            {
                // ====================================================================
                // SETUP: discover default + non-default brands at runtime (no hardcoded IDs)
                // ====================================================================

                #region Setup – discover brands

                var allBrands = await _brandsApi.ListBrands().ToListAsync();
                allBrands.Should().NotBeEmpty("the org must have at least one brand");

                var defaultBrand    = allBrands.First(b => b.IsDefault == true);
                var nonDefaultBrand = allBrands.FirstOrDefault(b => b.IsDefault != true);
                nonDefaultBrand.Should().NotBeNull(
                    "the org must have at least one non-default brand for ReplaceCustomDomain");

                string defaultBrandId    = defaultBrand.Id;
                string nonDefaultBrandId = nonDefaultBrand!.Id;

                #endregion

                // ====================================================================
                // SECTION 1: CreateCustomDomainAsync – POST /api/v1/domains → 201
                // CertificateSourceType=OKTA_MANAGED: DNS shape is TXT(_acme-challenge) + CAA + CNAME
                // ====================================================================

                #region CreateCustomDomainAsync – OKTA_MANAGED, full response shape validated

                var suffix1     = Guid.NewGuid().ToString("N")[..8];
                var domainName1 = TestDomainName(suffix1);

                var createdDomain = await _customDomainApi.CreateCustomDomainAsync(new DomainRequest
                {
                    Domain                = domainName1,
                    CertificateSourceType = DomainCertificateSourceType.OKTAMANAGED
                });

                createdDomain.Should().NotBeNull();
                createdDomain.Id.Should().NotBeNullOrEmpty("created domain must have an ID");
                createdDomain.Domain.Should().Be(domainName1);
                createdDomain.CertificateSourceType.Should().Be(DomainCertificateSourceType.OKTAMANAGED);
                createdDomain.ValidationStatus.Should().Be(DomainValidationStatus.NOTSTARTED,
                    "a freshly created domain always starts with NOT_STARTED status");
                createdDomain.DnsRecords.Should().NotBeNullOrEmpty(
                    "OKTA_MANAGED domains require DNS records to be configured");
                createdDomain.BrandId.Should().NotBeNullOrEmpty(
                    "CreateCustomDomain auto-creates and associates a brand");
                createdDomain.Links.Should().NotBeNull();

                domain1Id           = createdDomain.Id;
                autoCreatedBrand1Id = createdDomain.BrandId;

                // OKTA_MANAGED DNS shape: TXT (_acme-challenge.*) + CAA + CNAME
                var recordTypes1 = createdDomain.DnsRecords.Select(r => r.RecordType.Value).ToList();
                recordTypes1.Should().Contain("TXT",  "OKTA_MANAGED needs a TXT record for the ACME challenge");
                recordTypes1.Should().Contain("CNAME","OKTA_MANAGED needs a CNAME record");
                recordTypes1.Should().Contain("CAA",  "OKTA_MANAGED needs a CAA record for Let's Encrypt");

                var acmeTxt = createdDomain.DnsRecords.FirstOrDefault(r => r.RecordType.Value == "TXT");
                acmeTxt.Should().NotBeNull();
                acmeTxt!.Fqdn.Should().Contain("_acme-challenge",
                    "OKTA_MANAGED TXT fqdn must use _acme-challenge prefix");
                acmeTxt.Values.Should().NotBeNullOrEmpty();

                #endregion

                // ====================================================================
                // SECTION 2: ListCustomDomainsAsync – GET /api/v1/domains → 200
                // ====================================================================

                #region ListCustomDomainsAsync – domain1 must appear in the list

                var domainList = await _customDomainApi.ListCustomDomainsAsync();

                domainList.Should().NotBeNull();
                domainList.Domains.Should().NotBeNull();
                domainList.Domains.Should().Contain(d => d.Id == domain1Id,
                    "the newly created domain must appear in the list");

                #endregion

                // ====================================================================
                // SECTION 3: GetCustomDomainAsync – GET /api/v1/domains/{domainId} → 200
                // ====================================================================

                #region GetCustomDomainAsync – retrieves domain1 by ID

                var retrievedDomain = await _customDomainApi.GetCustomDomainAsync(domain1Id);

                retrievedDomain.Should().NotBeNull();
                retrievedDomain.Id.Should().Be(domain1Id);
                retrievedDomain.Domain.Should().Be(domainName1);
                retrievedDomain.CertificateSourceType.Should().Be(DomainCertificateSourceType.OKTAMANAGED);
                retrievedDomain.DnsRecords.Should().NotBeNullOrEmpty();

                #endregion

                // ====================================================================
                // SECTION 4: ReplaceCustomDomainAsync – PUT /api/v1/domains/{domainId} → 200
                // ====================================================================

                #region ReplaceCustomDomainAsync – update brandId to a non-default brand

                // Supplying the default brandId is rejected with 409 (tested in negatives below).
                var replacedDomain = await _customDomainApi.ReplaceCustomDomainAsync(
                    domain1Id, new UpdateDomain { BrandId = nonDefaultBrandId });

                replacedDomain.Should().NotBeNull();
                replacedDomain.Id.Should().Be(domain1Id);
                replacedDomain.Domain.Should().Be(domainName1);
                replacedDomain.BrandId.Should().Be(nonDefaultBrandId,
                    "ReplaceCustomDomain must update the brandId to the requested value");

                #endregion

                // ====================================================================
                // SECTION 5: VerifyDomainAsync – POST /api/v1/domains/{domainId}/verify → 200
                // ====================================================================

                #region VerifyDomainAsync – always 200; ValidationStatus reflects DNS outcome

                // DNS is not configured in the test environment; the API still returns HTTP 200
                // but with a ValidationStatus indicating the DNS check result (e.g. "FAILED_TO_VERIFY").
                var verifiedDomain = await _customDomainApi.VerifyDomainAsync(domain1Id);

                verifiedDomain.Should().NotBeNull();
                verifiedDomain.Id.Should().Be(domain1Id);
                verifiedDomain.Domain.Should().Be(domainName1);
                verifiedDomain.ValidationStatus.Should().NotBeNull(
                    "VerifyDomain must always return a ValidationStatus in the response body");

                #endregion

                // ====================================================================
                // SECTION 6: UpsertCertificateAsync (negative) – PUT /certificate → 403
                // ====================================================================

                #region UpsertCertificateAsync – 403 when domain is not verified (E0000165)

                var exUpsert = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customDomainApi.UpsertCertificateAsync(domain1Id, new DomainCertificate
                    {
                        Type             = DomainCertificateType.PEM,
                        Certificate      = "-----BEGIN CERTIFICATE-----\nfake\n-----END CERTIFICATE-----",
                        CertificateChain = "-----BEGIN CERTIFICATE-----\nfake\n-----END CERTIFICATE-----",
                        PrivateKey       = "-----BEGIN PRIVATE KEY-----\nfake\n-----END PRIVATE KEY-----"
                    }));

                exUpsert.ErrorCode.Should().Be(403,
                    "UpsertCertificate returns 403 E0000165 when the domain has not been DNS-verified");

                #endregion

                // ====================================================================
                // SECTION 7: Negative scenarios – all operations with a non-existent domainId → 404
                // ====================================================================

                const string InvalidDomainId = "nonexistentdomainid00000";

                #region Negative: GetCustomDomainAsync → 404 E0000163

                var exGet = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customDomainApi.GetCustomDomainAsync(InvalidDomainId));
                exGet.ErrorCode.Should().Be(404,
                    "GET with a non-existent domainId must return 404 E0000163");

                #endregion

                #region Negative: DeleteCustomDomainAsync → 404 E0000163

                var exDelete = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customDomainApi.DeleteCustomDomainAsync(InvalidDomainId));
                exDelete.ErrorCode.Should().Be(404,
                    "DELETE with a non-existent domainId must return 404 E0000163");

                #endregion

                #region Negative: VerifyDomainAsync → 404 E0000163

                var exVerify = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customDomainApi.VerifyDomainAsync(InvalidDomainId));
                exVerify.ErrorCode.Should().Be(404,
                    "VerifyDomain with a non-existent domainId must return 404 E0000163");

                #endregion

                #region Negative: ReplaceCustomDomainAsync (invalid ID) → 404 E0000163

                var exReplaceInvalid = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customDomainApi.ReplaceCustomDomainAsync(
                        InvalidDomainId, new UpdateDomain { BrandId = nonDefaultBrandId }));
                exReplaceInvalid.ErrorCode.Should().Be(404,
                    "ReplaceCustomDomain with a non-existent domainId must return 404 E0000163");

                #endregion

                #region Negative: UpsertCertificateAsync (invalid ID) → 404 E0000163

                var exUpsertInvalid = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customDomainApi.UpsertCertificateAsync(InvalidDomainId, new DomainCertificate
                    {
                        Type             = DomainCertificateType.PEM,
                        Certificate      = "-----BEGIN CERTIFICATE-----\nfake\n-----END CERTIFICATE-----",
                        CertificateChain = "-----BEGIN CERTIFICATE-----\nfake\n-----END CERTIFICATE-----",
                        PrivateKey       = "-----BEGIN PRIVATE KEY-----\nfake\n-----END PRIVATE KEY-----"
                    }));
                exUpsertInvalid.ErrorCode.Should().Be(404,
                    "UpsertCertificate with a non-existent domainId must return 404 E0000163");

                #endregion

                #region Negative: ReplaceCustomDomainAsync (default brandId) → 409 E0000203

                var exDefaultBrand = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customDomainApi.ReplaceCustomDomainAsync(
                        domain1Id, new UpdateDomain { BrandId = defaultBrandId }));
                exDefaultBrand.ErrorCode.Should().Be(409,
                    "using the default brandId in ReplaceCustomDomain must return HTTP 409 (E0000203)");

                #endregion

                // ====================================================================
                // WithHttpInfo variants – all 7 operations via domain 2 (MANUAL cert type)
                //
                // Using MANUAL cert type here provides coverage of the alternative DNS shape:
                //   TXT (_oktaverification.*) + CNAME only — no CAA record.
                // ====================================================================

                #region CreateCustomDomainWithHttpInfoAsync – MANUAL, validates MANUAL DNS shape → 201

                var suffix2     = Guid.NewGuid().ToString("N")[..8];
                var domainName2 = TestDomainName(suffix2);

                var createInfo = await _customDomainApi.CreateCustomDomainWithHttpInfoAsync(
                    new DomainRequest
                    {
                        Domain                = domainName2,
                        CertificateSourceType = DomainCertificateSourceType.MANUAL
                    });

                createInfo.StatusCode.Should().Be(HttpStatusCode.Created,
                    "CreateCustomDomain returns HTTP 201 Created");
                createInfo.Data.Should().NotBeNull();
                createInfo.Data.Id.Should().NotBeNullOrEmpty();
                createInfo.Data.Domain.Should().Be(domainName2);
                createInfo.Data.CertificateSourceType.Should().Be(DomainCertificateSourceType.MANUAL);
                createInfo.Data.ValidationStatus.Should().Be(DomainValidationStatus.NOTSTARTED);
                createInfo.Data.DnsRecords.Should().NotBeNullOrEmpty("MANUAL domains also require DNS records");
                createInfo.Data.BrandId.Should().NotBeNullOrEmpty();
                createInfo.Data.Links.Should().NotBeNull();

                domain2Id           = createInfo.Data.Id;
                autoCreatedBrand2Id = createInfo.Data.BrandId;

                // MANUAL DNS shape: TXT (_oktaverification.*) + CNAME only; no CAA record
                var recordTypes2 = createInfo.Data.DnsRecords.Select(r => r.RecordType.Value).ToList();
                recordTypes2.Should().Contain("TXT",  "MANUAL requires a TXT record for domain ownership proof");
                recordTypes2.Should().Contain("CNAME","MANUAL requires a CNAME record");
                recordTypes2.Should().NotContain("CAA","MANUAL type does not use CAA (no Let's Encrypt)");

                var verificationTxt = createInfo.Data.DnsRecords.FirstOrDefault(r => r.RecordType.Value == "TXT");
                verificationTxt.Should().NotBeNull();
                verificationTxt!.Fqdn.Should().Contain("_oktaverification",
                    "MANUAL TXT fqdn must use _oktaverification prefix, not _acme-challenge");
                verificationTxt.Values.Should().NotBeNullOrEmpty();

                #endregion

                #region ListCustomDomainsWithHttpInfoAsync → 200, domain2 in list

                var listInfo = await _customDomainApi.ListCustomDomainsWithHttpInfoAsync();

                listInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                listInfo.Data.Should().NotBeNull();
                listInfo.Data.Domains.Should().NotBeNull();
                listInfo.Data.Domains.Should().Contain(d => d.Id == domain2Id,
                    "domain2 must appear in the list immediately after creation");

                #endregion

                #region GetCustomDomainWithHttpInfoAsync → 200

                var getInfo = await _customDomainApi.GetCustomDomainWithHttpInfoAsync(domain2Id);

                getInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                getInfo.Data.Should().NotBeNull();
                getInfo.Data.Id.Should().Be(domain2Id);
                getInfo.Data.Domain.Should().Be(domainName2);
                getInfo.Data.CertificateSourceType.Should().Be(DomainCertificateSourceType.MANUAL);

                #endregion

                #region ReplaceCustomDomainWithHttpInfoAsync → 200

                var replaceInfo = await _customDomainApi.ReplaceCustomDomainWithHttpInfoAsync(
                    domain2Id, new UpdateDomain { BrandId = nonDefaultBrandId });

                replaceInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                replaceInfo.Data.Should().NotBeNull();
                replaceInfo.Data.Id.Should().Be(domain2Id);
                replaceInfo.Data.BrandId.Should().Be(nonDefaultBrandId);

                #endregion

                #region VerifyDomainWithHttpInfoAsync → 200

                var verifyInfo = await _customDomainApi.VerifyDomainWithHttpInfoAsync(domain2Id);

                verifyInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                verifyInfo.Data.Should().NotBeNull();
                verifyInfo.Data.Id.Should().Be(domain2Id);
                verifyInfo.Data.ValidationStatus.Should().NotBeNull();

                #endregion

                #region UpsertCertificateWithHttpInfoAsync (negative) → 403

                var exUpsertInfo = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customDomainApi.UpsertCertificateWithHttpInfoAsync(domain2Id, new DomainCertificate
                    {
                        Type             = DomainCertificateType.PEM,
                        Certificate      = "-----BEGIN CERTIFICATE-----\nfake\n-----END CERTIFICATE-----",
                        CertificateChain = "-----BEGIN CERTIFICATE-----\nfake\n-----END CERTIFICATE-----",
                        PrivateKey       = "-----BEGIN PRIVATE KEY-----\nfake\n-----END PRIVATE KEY-----"
                    }));

                exUpsertInfo.ErrorCode.Should().Be(403,
                    "UpsertCertificate returns 403 E0000165 when the domain has not been DNS-verified");

                #endregion

                #region DeleteCustomDomainWithHttpInfoAsync → 204 NoContent

                var deleteInfo = await _customDomainApi.DeleteCustomDomainWithHttpInfoAsync(domain2Id);

                deleteInfo.StatusCode.Should().Be(HttpStatusCode.NoContent);
                domain2Id = null; // successfully deleted; skip teardown for domain2

                #endregion
            }
            finally
            {
                // ====================================================================
                // TEARDOWN: delete both test domains and their auto-created brands.
                //
                // Critical: domain deletion does NOT automatically delete the brand that
                // was auto-created by CreateCustomDomain. Each brand must be deleted
                // explicitly to prevent brand accumulation in the org (confirmed via curl).
                // ====================================================================

                // Domain 1 — deleted via the primary (non-WithHttpInfo) method
                if (domain1Id != null)
                    try { await _customDomainApi.DeleteCustomDomainAsync(domain1Id); } catch { }

                // Domain 2 — only non-null if DeleteCustomDomainWithHttpInfoAsync was not reached
                if (domain2Id != null)
                    try { await _customDomainApi.DeleteCustomDomainAsync(domain2Id); } catch { }

                // Auto-created brand for domain 1
                if (autoCreatedBrand1Id != null)
                    try { await _brandsApi.DeleteBrandAsync(autoCreatedBrand1Id); } catch { }

                // Auto-created brand for domain 2
                if (autoCreatedBrand2Id != null)
                    try { await _brandsApi.DeleteBrandAsync(autoCreatedBrand2Id); } catch { }
            }
        }
    }
}
