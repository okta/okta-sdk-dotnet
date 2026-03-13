// <copyright file="AssociatedDomainCustomizationsApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for AssociatedDomainCustomizationsApi covering all 7 unique operations
    /// (14 methods including WithHttpInfo variants).
    ///
    /// AssociatedDomainCustomizationsApi → Endpoint Mapping
    /// ─────────────────────────────────────────────────────────────────────────────────────────────
    /// GetAllWellKnownURIsAsync               GET  /api/v1/brands/{brandId}/well-known-uris
    /// GetRootBrandWellKnownURIAsync          GET  /api/v1/brands/{brandId}/well-known-uris/{path}
    /// GetBrandWellKnownURIAsync              GET  /api/v1/brands/{brandId}/well-known-uris/{path}/customized
    /// ReplaceBrandWellKnownURIAsync          PUT  /api/v1/brands/{brandId}/well-known-uris/{path}/customized
    /// GetAppleAppSiteAssociationWellKnownURIAsync   GET  /.well-known/apple-app-site-association
    /// GetAssetLinksWellKnownURIAsync                GET  /.well-known/assetlinks.json
    /// GetWebAuthnWellKnownURIAsync                  GET  /.well-known/webauthn
    ///
    /// Key constraints discovered via curl validation:
    /// - brandId is discovered at runtime via BrandsApi.ListBrands() — no hardcoded IDs.
    /// - ALL branded API endpoints (/api/v1/brands/{brandId}/well-known-uris/...) require a
    ///   NON-DEFAULT brand. Calling with the default brand returns HTTP 405 E0000022.
    /// - ReplaceBrandWellKnownURIAsync on the DEFAULT brand returns HTTP 405 E0000257
    ///   "Cannot update the content for the default brand."
    /// - ReplaceBrandWellKnownURIAsync returns HTTP 200 (not 201).
    /// - WellKnownUriPath enum values: AppleAppSiteAssociation, AssetlinksJson, Webauthn.
    /// - GetBrandWellKnownURIAsync returns representation=null when no customization is set.
    ///   Setting representation=null via Replace effectively clears/resets the customization.
    /// - GetAllWellKnownURIsAsync expand values: "all", "apple-app-site-association",
    ///   "assetlinks.json", "webauthn". When expanded, Embedded.{path} is populated.
    ///   - Embedded.AppleAppSiteAssociation.Customized → WellKnownURIObjectResponse (Object Representation)
    ///   - Embedded.AssetlinksJson.Customized          → WellKnownURIArrayResponse (List&lt;Object&gt; Representation)
    ///   - Embedded.Webauthn.Customized                → WellKnownURIObjectResponse (Object Representation)
    /// - GetRootBrandWellKnownURIAsync expand value: "customized". When expanded, the API adds
    ///   _embedded to the response, but WellKnownURIObjectResponse does not model _embedded —
    ///   only Links is reliably asserted.
    /// - Public endpoints (no auth, no brandId):
    ///   - GetAppleAppSiteAssociationWellKnownURIAsync → always 200 (authsrv block always present)
    ///   - GetAssetLinksWellKnownURIAsync              → 404 E0000007 if not configured on the org
    ///   - GetWebAuthnWellKnownURIAsync                → 404 E0000007 if not configured on the org
    ///   These read from the ORG-LEVEL default brand, not from the non-default brand used in tests.
    /// - Body format for each path (Object Representation passed as anonymous C# type):
    ///   apple-app-site-association: { webcredentials: { apps: ["TEAMID.bundle"] } }
    ///   assetlinks.json:            [ { relation: [...], target: { namespace, package_name, sha256_cert_fingerprints } } ]
    ///   webauthn:                   { origins: ["https://example.com"] }
    ///
    /// Teardown:
    ///   - The pre-test representation for each of the three paths is captured before any write
    ///     (in the GetBrandWellKnownURIAsync region). Modified paths are restored to their captured
    ///     initial value (null if no customization existed), so the org is returned to exactly the
    ///     state it was in before the test ran — no data leakage, no silent destruction of real data.
    /// </summary>
    public class AssociatedDomainCustomizationsApiTests
    {
        private readonly AssociatedDomainCustomizationsApi _api = new();
        private readonly BrandsApi _brandsApi = new();

        [Fact]
        public async Task GivenAssociatedDomainCustomizationsApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string nonDefaultBrandId     = null;
            string defaultBrandId        = null;
            bool   appleModified         = false;
            bool   assetlinksModified    = false;
            bool   webauthnModified      = false;
            object initialAppleRepr      = null;   // captures pre-test state; restored in teardown
            object initialAssetlinksRepr = null;
            object initialWebauthnRepr   = null;

            try
            {
                // ================================================================
                // SETUP: discover default and non-default brands at runtime
                // ================================================================
                var brands = await _brandsApi.ListBrands().ToListAsync();
                var nonDefaultBrand = brands.FirstOrDefault(b => b.IsDefault != true);
                nonDefaultBrand.Should().NotBeNull(
                    "A non-default brand must exist; branded well-known URI endpoints do not support the default brand.");
                nonDefaultBrandId = nonDefaultBrand.Id;
                defaultBrandId    = brands.First(b => b.IsDefault == true).Id;

                // ================================================================
                // PRIMARY SECTION
                // ================================================================

                #region GetAllWellKnownURIsAsync – no expand; verify links shape
                var root = await _api.GetAllWellKnownURIsAsync(nonDefaultBrandId);
                root.Should().NotBeNull();
                root.Links.Should().NotBeNull();
                root.Links.Self.Should().NotBeNull();
                root.Links.AppleAppSiteAssociation.Should().NotBeNull();
                root.Links.AssetlinksJson.Should().NotBeNull();
                root.Links.Webauthn.Should().NotBeNull();
                root.Embedded.Should().BeNull("no expand was requested");
                #endregion

                #region GetAllWellKnownURIsAsync – with expand=apple-app-site-association; verify embedded
                var rootWithApple = await _api.GetAllWellKnownURIsAsync(
                    nonDefaultBrandId,
                    expand: new List<string> { "apple-app-site-association" });
                rootWithApple.Embedded.Should().NotBeNull();
                rootWithApple.Embedded.AppleAppSiteAssociation.Should().NotBeNull();
                rootWithApple.Embedded.AppleAppSiteAssociation.Customized.Should().NotBeNull();
                #endregion

                #region GetAllWellKnownURIsAsync – with expand=assetlinks.json; verify AssetlinksJson embedded
                var rootWithAssetlinks = await _api.GetAllWellKnownURIsAsync(
                    nonDefaultBrandId,
                    expand: new List<string> { "assetlinks.json" });
                rootWithAssetlinks.Embedded.Should().NotBeNull();
                rootWithAssetlinks.Embedded.AssetlinksJson.Should().NotBeNull();
                rootWithAssetlinks.Embedded.AssetlinksJson.Customized.Should().NotBeNull();
                #endregion

                #region GetAllWellKnownURIsAsync – with expand=webauthn; verify Webauthn embedded
                var rootWithWebauthn = await _api.GetAllWellKnownURIsAsync(
                    nonDefaultBrandId,
                    expand: new List<string> { "webauthn" });
                rootWithWebauthn.Embedded.Should().NotBeNull();
                rootWithWebauthn.Embedded.Webauthn.Should().NotBeNull();
                rootWithWebauthn.Embedded.Webauthn.Customized.Should().NotBeNull();
                #endregion

                #region GetAllWellKnownURIsAsync – with expand=all; verify all three embedded sections present
                var rootWithAll = await _api.GetAllWellKnownURIsAsync(
                    nonDefaultBrandId,
                    expand: new List<string> { "all" });
                rootWithAll.Embedded.Should().NotBeNull();
                rootWithAll.Embedded.AppleAppSiteAssociation.Should().NotBeNull();
                rootWithAll.Embedded.AppleAppSiteAssociation.Customized.Should().NotBeNull();
                rootWithAll.Embedded.AssetlinksJson.Should().NotBeNull();
                rootWithAll.Embedded.AssetlinksJson.Customized.Should().NotBeNull();
                rootWithAll.Embedded.Webauthn.Should().NotBeNull();
                rootWithAll.Embedded.Webauthn.Customized.Should().NotBeNull();
                #endregion

                #region GetRootBrandWellKnownURIAsync – apple-app-site-association, no expand
                var appleRoot = await _api.GetRootBrandWellKnownURIAsync(
                    nonDefaultBrandId, WellKnownUriPath.AppleAppSiteAssociation);
                appleRoot.Should().NotBeNull();
                appleRoot.Links.Should().NotBeNull();
                appleRoot.Links.Self.Should().NotBeNull();
                #endregion

                #region GetRootBrandWellKnownURIAsync – apple-app-site-association, expand=customized
                // API returns _embedded with customized content, but WellKnownURIObjectResponse model
                // does not expose _embedded — we verify the 200 response and links.
                var appleRootExpanded = await _api.GetRootBrandWellKnownURIAsync(
                    nonDefaultBrandId,
                    WellKnownUriPath.AppleAppSiteAssociation,
                    expand: new List<string> { "customized" });
                appleRootExpanded.Links.Should().NotBeNull();
                appleRootExpanded.Links.Self.Should().NotBeNull();
                #endregion

                #region GetRootBrandWellKnownURIAsync – assetlinks.json and webauthn paths
                var assetlinksRoot = await _api.GetRootBrandWellKnownURIAsync(
                    nonDefaultBrandId, WellKnownUriPath.AssetlinksJson);
                assetlinksRoot.Links.Should().NotBeNull();
                assetlinksRoot.Links.Self.Should().NotBeNull();

                var webauthnRoot = await _api.GetRootBrandWellKnownURIAsync(
                    nonDefaultBrandId, WellKnownUriPath.Webauthn);
                webauthnRoot.Links.Should().NotBeNull();
                webauthnRoot.Links.Self.Should().NotBeNull();
                #endregion

                #region GetBrandWellKnownURIAsync – all 3 paths; verify initial state (representation may be null)
                var appleCustomized = await _api.GetBrandWellKnownURIAsync(
                    nonDefaultBrandId, WellKnownUriPath.AppleAppSiteAssociation);
                appleCustomized.Should().NotBeNull();
                appleCustomized.Links.Should().NotBeNull();
                appleCustomized.Links.Self.Should().NotBeNull();
                initialAppleRepr = appleCustomized.Representation;             // save pre-test state for teardown restore

                var assetlinksCustomized = await _api.GetBrandWellKnownURIAsync(
                    nonDefaultBrandId, WellKnownUriPath.AssetlinksJson);
                assetlinksCustomized.Should().NotBeNull();
                assetlinksCustomized.Links.Should().NotBeNull();
                initialAssetlinksRepr = assetlinksCustomized.Representation;   // save pre-test state for teardown restore

                var webauthnCustomized = await _api.GetBrandWellKnownURIAsync(
                    nonDefaultBrandId, WellKnownUriPath.Webauthn);
                webauthnCustomized.Should().NotBeNull();
                webauthnCustomized.Links.Should().NotBeNull();
                initialWebauthnRepr = webauthnCustomized.Representation;       // save pre-test state for teardown restore
                #endregion

                #region ReplaceBrandWellKnownURIAsync – set apple-app-site-association, verify 200 + representation
                var appleBody = new WellKnownURIRequest
                {
                    Representation = new
                    {
                        webcredentials = new { apps = new[] { "TEAMID.com.okta.sdktest" } }
                    }
                };
                var appleReplaced = await _api.ReplaceBrandWellKnownURIAsync(
                    nonDefaultBrandId, WellKnownUriPath.AppleAppSiteAssociation, appleBody);
                appleModified = true;
                appleReplaced.Should().NotBeNull();
                appleReplaced.Representation.Should().NotBeNull();
                appleReplaced.Links.Should().NotBeNull();
                appleReplaced.Links.Self.Should().NotBeNull();
                #endregion

                #region GetBrandWellKnownURIAsync – apple, verify representation is now set
                var appleAfterSet = await _api.GetBrandWellKnownURIAsync(
                    nonDefaultBrandId, WellKnownUriPath.AppleAppSiteAssociation);
                appleAfterSet.Representation.Should().NotBeNull(
                    "Representation should be set after ReplaceBrandWellKnownURI");
                #endregion

                #region GetAppleAppSiteAssociationWellKnownURIAsync – public endpoint, always 200
                // Reads from the org-level default brand; always returns 200 because Okta's
                // built-in authsrv content is always present.
                var publicApple = await _api.GetAppleAppSiteAssociationWellKnownURIAsync();
                publicApple.Should().NotBeNull();
                // The response is a JSON object; serialized ToString contains at least the authsrv key.
                var publicAppleStr = publicApple.ToString() ?? string.Empty;
                publicAppleStr.Should().NotBeEmpty();
                #endregion

                #region GetAssetLinksWellKnownURIAsync – public endpoint, 404 when not configured on org default brand
                // The test org default brand has no assetlinks.json configured → E0000007.
                var assetlinksEx = await Assert.ThrowsAsync<ApiException>(
                    async () => await _api.GetAssetLinksWellKnownURIAsync());
                assetlinksEx.ErrorCode.Should().Be(404);
                #endregion

                #region GetWebAuthnWellKnownURIAsync – public endpoint, 404 when not configured on org default brand
                var webauthnEx = await Assert.ThrowsAsync<ApiException>(
                    async () => await _api.GetWebAuthnWellKnownURIAsync());
                webauthnEx.ErrorCode.Should().Be(404);
                #endregion

                #region Negative: ReplaceBrandWellKnownURIAsync on DEFAULT brand → 405 E0000257
                // The API prohibits mutating well-known URI files for the default brand.
                var ex405 = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _api.ReplaceBrandWellKnownURIAsync(
                        defaultBrandId,
                        WellKnownUriPath.AppleAppSiteAssociation,
                        new WellKnownURIRequest { Representation = new { key = "val" } }));
                ex405.ErrorCode.Should().Be(405);
                #endregion

                // ================================================================
                // WithHttpInfo VARIANTS
                // ================================================================

                #region GetAllWellKnownURIsWithHttpInfoAsync – no expand
                var rootHttp = await _api.GetAllWellKnownURIsWithHttpInfoAsync(nonDefaultBrandId);
                rootHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                rootHttp.Data.Should().NotBeNull();
                rootHttp.Data.Links.Should().NotBeNull();
                rootHttp.Data.Links.Self.Should().NotBeNull();
                rootHttp.Data.Embedded.Should().BeNull("no expand was requested");
                #endregion

                #region GetAllWellKnownURIsWithHttpInfoAsync – with expand=webauthn
                var rootHttpExpanded = await _api.GetAllWellKnownURIsWithHttpInfoAsync(
                    nonDefaultBrandId,
                    expand: new List<string> { "webauthn" });
                rootHttpExpanded.StatusCode.Should().Be(HttpStatusCode.OK);
                rootHttpExpanded.Data.Embedded.Should().NotBeNull();
                rootHttpExpanded.Data.Embedded.Webauthn.Should().NotBeNull();
                rootHttpExpanded.Data.Embedded.Webauthn.Customized.Should().NotBeNull();
                #endregion

                #region GetRootBrandWellKnownURIWithHttpInfoAsync – assetlinks.json, no expand
                var assetlinksRootHttp = await _api.GetRootBrandWellKnownURIWithHttpInfoAsync(
                    nonDefaultBrandId, WellKnownUriPath.AssetlinksJson);
                assetlinksRootHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                assetlinksRootHttp.Data.Links.Should().NotBeNull();
                assetlinksRootHttp.Data.Links.Self.Should().NotBeNull();
                #endregion

                #region GetRootBrandWellKnownURIWithHttpInfoAsync – webauthn, expand=customized
                var webauthnRootHttp = await _api.GetRootBrandWellKnownURIWithHttpInfoAsync(
                    nonDefaultBrandId,
                    WellKnownUriPath.Webauthn,
                    expand: new List<string> { "customized" });
                webauthnRootHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                webauthnRootHttp.Data.Links.Should().NotBeNull();
                #endregion

                #region GetRootBrandWellKnownURIWithHttpInfoAsync – apple-app-site-association, no expand
                var appleRootHttp = await _api.GetRootBrandWellKnownURIWithHttpInfoAsync(
                    nonDefaultBrandId, WellKnownUriPath.AppleAppSiteAssociation);
                appleRootHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                appleRootHttp.Data.Links.Should().NotBeNull();
                appleRootHttp.Data.Links.Self.Should().NotBeNull();
                #endregion

                #region GetBrandWellKnownURIWithHttpInfoAsync – all 3 paths (apple, assetlinks.json, webauthn)
                // apple was set via ReplaceBrandWellKnownURIAsync in the primary section; assert Representation is now set.
                var appleCustomizedHttp = await _api.GetBrandWellKnownURIWithHttpInfoAsync(
                    nonDefaultBrandId, WellKnownUriPath.AppleAppSiteAssociation);
                appleCustomizedHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                appleCustomizedHttp.Data.Links.Should().NotBeNull();
                appleCustomizedHttp.Data.Representation.Should().NotBeNull(
                    "apple representation was set via ReplaceBrandWellKnownURIAsync in the primary section");

                var assetlinksCustomizedHttp = await _api.GetBrandWellKnownURIWithHttpInfoAsync(
                    nonDefaultBrandId, WellKnownUriPath.AssetlinksJson);
                assetlinksCustomizedHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                assetlinksCustomizedHttp.Data.Links.Should().NotBeNull();

                var webauthnCustomizedHttp = await _api.GetBrandWellKnownURIWithHttpInfoAsync(
                    nonDefaultBrandId, WellKnownUriPath.Webauthn);
                webauthnCustomizedHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                webauthnCustomizedHttp.Data.Links.Should().NotBeNull();
                #endregion

                #region ReplaceBrandWellKnownURIWithHttpInfoAsync – assetlinks.json, verify 200 + representation
                // assetlinks.json representation must be a JSON array of Digital Asset Link statements.
                var assetlinksBody = new WellKnownURIRequest
                {
                    Representation = new[]
                    {
                        new
                        {
                            relation = new[] { "delegate_permission/common.handle_all_urls" },
                            target   = new
                            {
                                @namespace                = "android_app",
                                package_name              = "com.sdk.integrationtest",
                                sha256_cert_fingerprints  = new[] { "AA:BB:CC:DD:EE" }
                            }
                        }
                    }
                };
                var assetlinksReplacedHttp = await _api.ReplaceBrandWellKnownURIWithHttpInfoAsync(
                    nonDefaultBrandId, WellKnownUriPath.AssetlinksJson, assetlinksBody);
                assetlinksModified = true;
                assetlinksReplacedHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                assetlinksReplacedHttp.Data.Representation.Should().NotBeNull();
                assetlinksReplacedHttp.Data.Links.Should().NotBeNull();
                #endregion

                #region ReplaceBrandWellKnownURIWithHttpInfoAsync – webauthn, verify 200 + representation
                // webauthn representation must be a JSON object with an "origins" array.
                var webauthnBody = new WellKnownURIRequest
                {
                    Representation = new
                    {
                        origins = new[] { "https://sdk-integration-test.example.com" }
                    }
                };
                var webauthnReplacedHttp = await _api.ReplaceBrandWellKnownURIWithHttpInfoAsync(
                    nonDefaultBrandId, WellKnownUriPath.Webauthn, webauthnBody);
                webauthnModified = true;
                webauthnReplacedHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                webauthnReplacedHttp.Data.Representation.Should().NotBeNull();
                webauthnReplacedHttp.Data.Links.Should().NotBeNull();
                #endregion

                #region GetAppleAppSiteAssociationWellKnownURIWithHttpInfoAsync – public endpoint, always 200
                var publicAppleHttp = await _api.GetAppleAppSiteAssociationWellKnownURIWithHttpInfoAsync();
                publicAppleHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                publicAppleHttp.Data.Should().NotBeNull();
                #endregion

                #region GetAssetLinksWellKnownURIWithHttpInfoAsync – public endpoint, 404 (reads default brand)
                // Even though we just set assetlinks.json on the NON-default brand above, this
                // public endpoint reads from the org's DEFAULT brand, which is not configured.
                var assetlinksPublicEx = await Assert.ThrowsAsync<ApiException>(
                    async () => await _api.GetAssetLinksWellKnownURIWithHttpInfoAsync());
                assetlinksPublicEx.ErrorCode.Should().Be(404);
                #endregion

                #region GetWebAuthnWellKnownURIWithHttpInfoAsync – public endpoint, 404 (reads default brand)
                var webauthnPublicEx = await Assert.ThrowsAsync<ApiException>(
                    async () => await _api.GetWebAuthnWellKnownURIWithHttpInfoAsync());
                webauthnPublicEx.ErrorCode.Should().Be(404);
                #endregion

                #region Negative: GetAllWellKnownURIsAsync on DEFAULT brand → 405
                // The /api/v1/brands/{brandId}/well-known-uris endpoint returns 405 for the default
                // brand, consistent with the prohibition on modifying the default brand.
                var ex405Get = await Assert.ThrowsAsync<ApiException>(
                    async () => await _api.GetAllWellKnownURIsAsync(defaultBrandId));
                ex405Get.ErrorCode.Should().Be(405);
                #endregion
            }
            finally
            {
                // ================================================================
                // TEARDOWN: restore each path to its captured pre-test representation.
                // Using the initial values (null if unconfigured) ensures no data leakage —
                // the org is returned to exactly the state it was in before the test ran.
                // ================================================================
                if (nonDefaultBrandId != null)
                {
                    if (appleModified)
                        try { await _api.ReplaceBrandWellKnownURIAsync(nonDefaultBrandId, WellKnownUriPath.AppleAppSiteAssociation, new WellKnownURIRequest { Representation = initialAppleRepr }); } catch { }

                    if (assetlinksModified)
                        try { await _api.ReplaceBrandWellKnownURIAsync(nonDefaultBrandId, WellKnownUriPath.AssetlinksJson, new WellKnownURIRequest { Representation = initialAssetlinksRepr }); } catch { }

                    if (webauthnModified)
                        try { await _api.ReplaceBrandWellKnownURIAsync(nonDefaultBrandId, WellKnownUriPath.Webauthn, new WellKnownURIRequest { Representation = initialWebauthnRepr }); } catch { }
                }
            }
        }
    }
}
