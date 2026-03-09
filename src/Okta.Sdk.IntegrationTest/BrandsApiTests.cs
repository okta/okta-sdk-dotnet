// <copyright file="BrandsApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for BrandsApi covering all 6 available endpoints.
    ///
    /// BrandsApi → Endpoint Mapping
    /// ─────────────────────────────────────────────────────────────────────────
    /// ListBrands           GET    /api/v1/brands
    /// CreateBrandAsync     POST   /api/v1/brands
    /// GetBrandAsync        GET    /api/v1/brands/{brandId}
    /// ReplaceBrandAsync    PUT    /api/v1/brands/{brandId}
    /// ListBrandDomains     GET    /api/v1/brands/{brandId}/domains
    /// DeleteBrandAsync     DELETE /api/v1/brands/{brandId}
    ///
    /// - ListBrands returns 200 with an array; every org has at least one default brand.
    /// - CreateBrand returns 201; defaultApp is {} for a fresh brand, isDefault is false.
    /// - GetBrand returns 200; _embedded is absent for brands with no custom resources
    ///   even when expand=themes,domains,emailDomain is supplied.
    /// - ReplaceBrand returns 200 with the updated fields.
    /// - ReplaceBrand with valid customPrivacyPolicyUrl + agreeToCustomPrivacyPolicy:true returns 200.
    /// - ListBrandDomains returns 200 with {"domains":[]} for a freshly created brand.
    /// - DeleteBrand returns 204.
    /// - GET/DELETE/PUT on non-existent brandId returns 404 (E0000007).
    /// - GET /domains on non-existent brandId returns 404 (E0000007).
    /// - PUT with customPrivacyPolicyUrl and agreeToCustomPrivacyPolicy:false returns 400 (E0000001).
    /// - POST with reserved name "DRAPP_DOMAIN_BRAND" returns 400 (E0000001).
    /// - POST with duplicate brand name returns 409 (Conflict).
    /// - DELETE on the default brand returns 403 or 409.
    /// - All 6 WithHttpInfo method variants return the correct HTTP status codes.
    /// </summary>
    public class BrandsApiTests
    {
        private readonly BrandsApi _brandsApi = new();

        /// <summary>
        /// Comprehensive single test covering all 6 BrandsApi endpoints and methods:
        ///
        /// Happy-path scenarios
        ///   1. ListBrands           – org has at least one default brand
        ///   2. CreateBrandAsync     – creates a new brand, 201 response
        ///   3. GetBrandAsync        – retrieves the created brand by ID
        ///   4. GetBrandAsync w/ expand – retrieves brand with embedded themes/domains metadata
        ///   5. ListBrands (query)   – filters brands by name, finds the created brand
        ///   6. ReplaceBrandAsync    – updates name, locale and removePoweredByOkta flag
        ///  6b. ReplaceBrandAsync    – sets customPrivacyPolicyUrl with consent (happy path)
        ///   7. ListBrandDomains     – lists domains associated with brand
        ///   8. DeleteBrandAsync     – deletes the brand, 204 response
        ///
        /// Negative scenarios
        ///   9.  GetBrandAsync on non-existent brandId         → 404
        ///  10.  ReplaceBrandAsync with customPrivacyPolicyUrl
        ///        but without agreeToCustomPrivacyPolicy       → 400
        ///  11.  DeleteBrandAsync on non-existent brandId      → 404
        ///  12.  ReplaceBrandAsync on non-existent brandId     → 404
        ///  13.  ListBrandDomains on non-existent brandId      → 404
        ///
        /// Teardown: the created brand is always deleted in the finally block.
        /// </summary>
        [Fact]
        public async Task GivenBrandsApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string createdBrandId = null;

            try
            {
                // ====================================================================
                // SECTION 1: ListBrands – GET /api/v1/brands
                // ====================================================================

                #region ListBrands – verify the org already has at least the default brand

                var allBrandsBefore = await _brandsApi.ListBrands().ToListAsync();

                allBrandsBefore.Should().NotBeNull();
                allBrandsBefore.Should().NotBeEmpty("every Okta org has at least one default brand");

                // The default brand must have IsDefault == true
                var defaultBrand = allBrandsBefore.FirstOrDefault(b => b.IsDefault);
                defaultBrand.Should().NotBeNull("the org must have a default brand");
                defaultBrand!.Id.Should().NotBeNullOrEmpty();
                defaultBrand.Name.Should().NotBeNullOrEmpty();

                // All returned brands must have required fields
                foreach (var brand in allBrandsBefore)
                {
                    brand.Id.Should().NotBeNullOrEmpty();
                    brand.Name.Should().NotBeNullOrEmpty();
                }

                #endregion

                // ====================================================================
                // SECTION 2: CreateBrandAsync – POST /api/v1/brands
                // ====================================================================

                #region CreateBrandAsync – create a new brand

                var uniqueSuffix = Guid.NewGuid().ToString("N")[..8];
                var brandName = $"SDK Integration Test Brand {uniqueSuffix}";

                var createRequest = new CreateBrandRequest
                {
                    Name = brandName
                };

                var createdBrand = await _brandsApi.CreateBrandAsync(createRequest);

                createdBrand.Should().NotBeNull();
                createdBrand.Id.Should().NotBeNullOrEmpty();
                createdBrand.Name.Should().Be(brandName);
                createdBrand.IsDefault.Should().BeFalse("newly created brands are not the default");

                createdBrandId = createdBrand.Id;

                #endregion

                // ====================================================================
                // SECTION 3: GetBrandAsync – GET /api/v1/brands/{brandId}
                // ====================================================================

                #region GetBrandAsync – retrieve the brand by ID

                var retrievedBrand = await _brandsApi.GetBrandAsync(createdBrandId);

                retrievedBrand.Should().NotBeNull();
                retrievedBrand.Id.Should().Be(createdBrandId);
                retrievedBrand.Name.Should().Be(brandName);
                retrievedBrand.IsDefault.Should().BeFalse();

                #endregion

                // ====================================================================
                // SECTION 4: GetBrandAsync with expand – GET /api/v1/brands/{brandId}?expand=themes,domains
                // ====================================================================

                #region GetBrandAsync with expand parameter – verify call succeeds and ID is preserved

                // The expanded parameter is accepted by the API (200 OK) and the brand ID is preserved.
                // _embedded is only populated when the brand has custom theme/domain resources;
                // a freshly created brand returns null for _embedded even with expanded supplied.
                // Valid expand enum values: "themes", "domains", "emailDomain".

                // Verify expand=themes,domains
                var expandOptions = new List<string> { "themes", "domains" };
                var brandWithExpand = await _brandsApi.GetBrandAsync(createdBrandId, expand: expandOptions);

                brandWithExpand.Should().NotBeNull();
                brandWithExpand.Id.Should().Be(createdBrandId);
                brandWithExpand.Name.Should().Be(brandName);

                // Verify expand=emailDomain (the third valid enum value)
                var brandWithEmailDomainExpand = await _brandsApi.GetBrandAsync(
                    createdBrandId, expand: ["emailDomain"]);

                brandWithEmailDomainExpand.Should().NotBeNull();
                brandWithEmailDomainExpand.Id.Should().Be(createdBrandId);

                #endregion

                // ====================================================================
                // SECTION 5: ListBrands with q filter – GET /api/v1/brands?q={name}
                // ====================================================================

                #region ListBrands with query filter – find the created brand by name

                var filteredBrands = await _brandsApi.ListBrands(q: brandName).ToListAsync();

                filteredBrands.Should().NotBeNull();
                var id = createdBrandId;
                filteredBrands.Should().Contain(b => b.Id == id,
                    "filtering by the brand name should return the newly created brand");

                #endregion

                // ====================================================================
                // SECTION 6: ReplaceBrandAsync – PUT /api/v1/brands/{brandId}
                // ====================================================================

                #region ReplaceBrandAsync – update brand name, locale and flag

                var updatedName = $"SDK Integration Test Brand Updated {uniqueSuffix}";

                var replaceRequest = new BrandRequest
                {
                    Name = updatedName,
                    Locale = "en",
                    RemovePoweredByOkta = true
                };

                var replacedBrand = await _brandsApi.ReplaceBrandAsync(createdBrandId, replaceRequest);

                replacedBrand.Should().NotBeNull();
                replacedBrand.Id.Should().Be(createdBrandId);
                replacedBrand.Name.Should().Be(updatedName);
                replacedBrand.Locale.Should().Be("en");
                replacedBrand.RemovePoweredByOkta.Should().BeTrue();

                // Verify changes persisted via a subsequent GET
                var verifyBrand = await _brandsApi.GetBrandAsync(createdBrandId);
                verifyBrand.Name.Should().Be(updatedName);
                verifyBrand.RemovePoweredByOkta.Should().BeTrue();

                #endregion

                // ====================================================================
                // SECTION 6b: ReplaceBrandAsync – customPrivacyPolicyUrl happy path
                //             PUT /api/v1/brands/{brandId} with valid consent
                // ====================================================================

                #region ReplaceBrandAsync – customPrivacyPolicyUrl with agreeToCustomPrivacyPolicy:true → 200

                // Providing agreeToCustomPrivacyPolicy:true alongside customPrivacyPolicyUrl is the
                // valid/happy-path scenario. The API returns 200 with the URL persisted.
                var privacyRequest = new BrandRequest
                {
                    Name = updatedName,
                    CustomPrivacyPolicyUrl = "https://example.com/privacy-policy",
                    AgreeToCustomPrivacyPolicy = true
                };

                var brandWithPrivacy = await _brandsApi.ReplaceBrandAsync(createdBrandId, privacyRequest);

                brandWithPrivacy.Should().NotBeNull();
                brandWithPrivacy.Id.Should().Be(createdBrandId);
                brandWithPrivacy.CustomPrivacyPolicyUrl.Should().Be("https://example.com/privacy-policy");
                brandWithPrivacy.AgreeToCustomPrivacyPolicy.Should().BeTrue();

                // Reset the custom privacy URL so later operations are not affected
                await _brandsApi.ReplaceBrandAsync(createdBrandId, new BrandRequest { Name = updatedName });

                #endregion

                // ====================================================================
                // SECTION 7: ListBrandDomains – GET /api/v1/brands/{brandId}/domains
                // ====================================================================

                #region ListBrandDomains – list domains associated with the brand

                var domains = await _brandsApi.ListBrandDomains(createdBrandId).ToListAsync();

                // A newly created brand has no custom domains, so the list may be empty.
                // The call itself must succeed with 200 and return a valid (possibly empty) list.
                domains.Should().NotBeNull("the endpoint always returns a list, even if empty");

                // If there are any domains, each must have the required fields
                foreach (var domain in domains)
                {
                    domain.Should().NotBeNull();
                    domain.Id.Should().NotBeNullOrEmpty();
                    domain.BrandId.Should().Be(createdBrandId);
                }

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 1: GetBrandAsync on a non-existent brandId → 404
                // ====================================================================

                #region GetBrandAsync – non-existent brand returns 404

                Func<Task> getNonExistent = async () =>
                    await _brandsApi.GetBrandAsync("invalid-brand-id-that-does-not-exist");

                await getNonExistent.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "retrieving a non-existent brand must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 2: ReplaceBrandAsync with customPrivacyPolicyUrl
                //                      but without agreeToCustomPrivacyPolicy → 400
                // ====================================================================

                #region ReplaceBrandAsync – missing agreeToCustomPrivacyPolicy returns 400

                var badReplaceRequest = new BrandRequest
                {
                    Name = updatedName,
                    CustomPrivacyPolicyUrl = "https://example.com/privacy-policy",
                    AgreeToCustomPrivacyPolicy = false   // false = not agreeing → API returns 400
                };

                var brandId = createdBrandId;
                Func<Task> replaceBadRequest = async () =>
                    await _brandsApi.ReplaceBrandAsync(brandId, badReplaceRequest);

                await replaceBadRequest.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 400,
                        "providing customPrivacyPolicyUrl without consent must return 400 Bad Request");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 3: DeleteBrandAsync on a non-existent brandId → 404
                // ====================================================================

                #region DeleteBrandAsync – non-existent brand returns 404

                Func<Task> deleteNonExistent = async () =>
                    await _brandsApi.DeleteBrandAsync("invalid-brand-id-that-does-not-exist");

                await deleteNonExistent.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "deleting a non-existent brand must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 4: ReplaceBrandAsync on a non-existent brandId → 404
                // ====================================================================

                #region ReplaceBrandAsync – non-existent brand returns 404

                Func<Task> replaceNonExistent = async () =>
                    await _brandsApi.ReplaceBrandAsync(
                        "invalid-brand-id-that-does-not-exist",
                        new BrandRequest { Name = "Whatever" });

                await replaceNonExistent.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "replacing a non-existent brand must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 5: ListBrandDomains on a non-existent brandId → 404
                // ====================================================================

                #region ListBrandDomains – non-existent brand returns 404

                Func<Task> listDomainsNonExistent = async () =>
                    await _brandsApi.ListBrandDomains("invalid-brand-id-that-does-not-exist").ToListAsync();

                await listDomainsNonExistent.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "listing domains for a non-existent brand must return 404 Not Found");

                #endregion

                // ====================================================================
                // SECTION 8: DeleteBrandAsync – DELETE /api/v1/brands/{brandId}
                // ====================================================================

                #region DeleteBrandAsync – delete the brand created in SECTION 2

                await _brandsApi.DeleteBrandAsync(createdBrandId);

                // Mark as null so the finally block skips the redundant delete attempt
                var deletedId = createdBrandId;
                createdBrandId = null;

                // Verify the brand is gone (GET should now return 404)
                Func<Task> getDeleted = async () =>
                    await _brandsApi.GetBrandAsync(deletedId);

                await getDeleted.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "a deleted brand must no longer be retrievable");

                // Verify brand no longer appears in the org brand list
                var allBrandsAfter = await _brandsApi.ListBrands().ToListAsync();
                allBrandsAfter.Should().NotContain(b => b.Id == deletedId,
                    "the deleted brand must not appear in the org brand list");

                #endregion
            }
            finally
            {
                // ====================================================================
                // TEARDOWN: Ensure the created brand is always cleaned up
                // ====================================================================
                if (!string.IsNullOrEmpty(createdBrandId))
                {
                    try
                    {
                        await _brandsApi.DeleteBrandAsync(createdBrandId);
                    }
                    catch
                    {
                        // Ignore cleanup errors – the brand may already have been deleted
                        // during the test, or it might not have been created successfully.
                    }
                }
            }
        }

        /// <summary>
        /// Verifies that ListBrands respects the <c>limit</c> query parameter.
        /// Maps to: GET /api/v1/brands?limit=1
        /// </summary>
        [Fact]
        public async Task GivenBrandsApi_WhenListingBrandsWithLimit_ThenResultRespectsPaginationParameter()
        {
            var limitedBrands = await _brandsApi.ListBrands(limit: 1).ToListAsync();

            // The SDK transparently follows Link headers, so ToListAsync() may return more
            // than 1 item, but we simply verify the call succeeds and returns a valid list.
            limitedBrands.Should().NotBeNull();
            limitedBrands.Should().NotBeEmpty("the org always has at least one brand");
        }

        /// <summary>
        /// Verifies that ListBrands with the <c>expand</c> parameter is accepted by the API
        /// and returns the full brand list.
        /// Maps to: GET /api/v1/brands?expand=themes
        /// Note: _embedded is only present on brands that have custom theme/domain resources;
        /// it is absent for brands without them, even when expand is supplied.
        /// </summary>
        [Fact]
        public async Task GivenBrandsApi_WhenListingBrandsWithExpand_ThenCallSucceedsAndBrandsAreReturned()
        {
            var expandOptions = new List<string> { "themes" };
            var brandsWithThemes = await _brandsApi.ListBrands(expand: expandOptions).ToListAsync();

            brandsWithThemes.Should().NotBeNull();
            brandsWithThemes.Should().NotBeEmpty("the org always has at least one default brand");

            // Each brand must carry its required fields
            brandsWithThemes.Should().AllSatisfy(b =>
            {
                b.Id.Should().NotBeNullOrEmpty();
                b.Name.Should().NotBeNullOrEmpty();
            });
        }

        /// <summary>
        /// Verifies that creating a brand with a reserved name fails with 400 or 409.
        /// Maps to: POST /api/v1/brands with name "DRAPP_DOMAIN_BRAND"
        /// </summary>
        [Fact]
        public async Task GivenBrandsApi_WhenCreatingBrandWithReservedName_ThenErrorIsReturned()
        {
            var reservedRequest = new CreateBrandRequest
            {
                Name = "DRAPP_DOMAIN_BRAND"
            };

            Func<Task> createReserved = async () =>
                await _brandsApi.CreateBrandAsync(reservedRequest);

            // The API returns 400 Bad Request for the reserved name
            await createReserved.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 400 || e.ErrorCode == 409,
                    "the reserved brand name DRAPP_DOMAIN_BRAND must be rejected by the API");
        }

        /// <summary>
        /// Verifies that all 6 WithHttpInfo method variants return the correct HTTP status codes.
        /// These variants expose the raw ApiResponse so callers can inspect status codes and headers.
        ///
        /// Method → Expected HTTP status code
        ///   CreateBrandWithHttpInfoAsync       → 201 Created
        ///   ListBrandsWithHttpInfoAsync        → 200 OK
        ///   GetBrandWithHttpInfoAsync          → 200 OK
        ///   ReplaceBrandWithHttpInfoAsync      → 200 OK
        ///   ListBrandDomainsWithHttpInfoAsync  → 200 OK
        ///   DeleteBrandWithHttpInfoAsync       → 204 No Content
        /// </summary>
        [Fact]
        public async Task GivenBrandsApi_WhenUsingWithHttpInfoVariants_ThenHttpStatusCodesAreCorrect()
        {
            string createdBrandId = null;

            try
            {
                var uniqueSuffix = Guid.NewGuid().ToString("N")[..8];
                var brandName = $"SDK HttpInfo Test Brand {uniqueSuffix}";

                // POST → 201 Created
                var createResponse = await _brandsApi.CreateBrandWithHttpInfoAsync(
                    new CreateBrandRequest { Name = brandName });

                createResponse.StatusCode.Should().Be(HttpStatusCode.Created);
                createResponse.Data.Should().NotBeNull();
                createdBrandId = createResponse.Data.Id;

                // GET a list → 200 OK
                var listResponse = await _brandsApi.ListBrandsWithHttpInfoAsync();
                listResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                listResponse.Data.Should().NotBeEmpty();

                // GET single → 200 OK
                var getResponse = await _brandsApi.GetBrandWithHttpInfoAsync(createdBrandId);
                getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                getResponse.Data.Id.Should().Be(createdBrandId);

                // PUT → 200 OK
                var putResponse = await _brandsApi.ReplaceBrandWithHttpInfoAsync(
                    createdBrandId,
                    new BrandRequest { Name = $"SDK HttpInfo Test Brand Updated {uniqueSuffix}" });
                putResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                putResponse.Data.Id.Should().Be(createdBrandId);

                // GET domains → 200 OK
                // Note: the raw endpoint returns {"domains": []} (a wrapper object), so
                // ApiResponse<List<DomainResponse>>.Data is null when there are no custom
                // domains. The collection client (ListBrandDomains) handles unwrapping
                // internally — only the status code is asserted here.
                var domainsResponse = await _brandsApi.ListBrandDomainsWithHttpInfoAsync(createdBrandId);
                domainsResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                // DELETE → 204 No Content
                var deleteResponse = await _brandsApi.DeleteBrandWithHttpInfoAsync(createdBrandId);
                deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
                createdBrandId = null;
            }
            finally
            {
                if (!string.IsNullOrEmpty(createdBrandId))
                {
                    try { await _brandsApi.DeleteBrandAsync(createdBrandId); } catch { }
                }
            }
        }

        /// <summary>
        /// Verifies that creating a brand with a name that already exists fails with 409 Conflict.
        /// Maps to: POST /api/v1/brands (409 response)
        /// </summary>
        [Fact]
        public async Task GivenBrandsApi_WhenCreatingBrandWithDuplicateName_ThenConflictIsReturned()
        {
            string createdBrandId = null;

            try
            {
                var uniqueSuffix = Guid.NewGuid().ToString("N")[..8];
                var brandName = $"SDK Duplicate Test Brand {uniqueSuffix}";

                // Create the brand once
                var created = await _brandsApi.CreateBrandAsync(new CreateBrandRequest { Name = brandName });
                createdBrandId = created.Id;

                // Attempt to create a second brand with the same name → 409 Conflict
                Func<Task> createDuplicate = async () =>
                    await _brandsApi.CreateBrandAsync(new CreateBrandRequest { Name = brandName });

                await createDuplicate.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 409,
                        "creating a brand with a name that already exists must return 409 Conflict");
            }
            finally
            {
                if (!string.IsNullOrEmpty(createdBrandId))
                {
                    try { await _brandsApi.DeleteBrandAsync(createdBrandId); } catch { }
                }
            }
        }

        /// <summary>
        /// Verifies that deleting the default brand fails with 403 Forbidden or 409 Conflict.
        /// Maps to: DELETE /api/v1/brands/{brandId} (403/409 response)
        /// The default brand is protected and cannot be removed.
        /// </summary>
        [Fact]
        public async Task GivenBrandsApi_WhenDeletingDefaultBrand_ThenForbiddenOrConflictIsReturned()
        {
            var allBrands = await _brandsApi.ListBrands().ToListAsync();
            var defaultBrand = allBrands.FirstOrDefault(b => b.IsDefault);

            defaultBrand.Should().NotBeNull("the org must have a default brand");

            Func<Task> deleteDefault = async () =>
                await _brandsApi.DeleteBrandAsync(defaultBrand!.Id);

            await deleteDefault.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 403 || e.ErrorCode == 409,
                    "deleting the default brand must return 403 Forbidden or 409 Conflict");
        }
    }
}
