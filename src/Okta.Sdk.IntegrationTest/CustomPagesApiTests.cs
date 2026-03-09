// <copyright file="CustomPagesApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for CustomPagesApi covering all 19 unique operations (38 methods incl. WithHttpInfo variants).
    ///
    /// CustomPagesApi → Endpoint Mapping
    /// ─────────────────────────────────────────────────────────────────────────────────────────────
    /// GetErrorPageAsync                  GET    /api/v1/brands/{brandId}/pages/error
    /// GetCustomizedErrorPageAsync        GET    /api/v1/brands/{brandId}/pages/error/customized
    /// ReplaceCustomizedErrorPageAsync    PUT    /api/v1/brands/{brandId}/pages/error/customized
    /// DeleteCustomizedErrorPageAsync     DELETE /api/v1/brands/{brandId}/pages/error/customized
    /// GetDefaultErrorPageAsync           GET    /api/v1/brands/{brandId}/pages/error/default
    /// GetPreviewErrorPageAsync           GET    /api/v1/brands/{brandId}/pages/error/preview
    /// ReplacePreviewErrorPageAsync       PUT    /api/v1/brands/{brandId}/pages/error/preview
    /// DeletePreviewErrorPageAsync        DELETE /api/v1/brands/{brandId}/pages/error/preview
    /// GetSignInPageAsync                 GET    /api/v1/brands/{brandId}/pages/sign-in
    /// GetCustomizedSignInPageAsync       GET    /api/v1/brands/{brandId}/pages/sign-in/customized
    /// ReplaceCustomizedSignInPageAsync   PUT    /api/v1/brands/{brandId}/pages/sign-in/customized
    /// DeleteCustomizedSignInPageAsync    DELETE /api/v1/brands/{brandId}/pages/sign-in/customized
    /// GetDefaultSignInPageAsync          GET    /api/v1/brands/{brandId}/pages/sign-in/default
    /// GetPreviewSignInPageAsync          GET    /api/v1/brands/{brandId}/pages/sign-in/preview
    /// ReplacePreviewSignInPageAsync      PUT    /api/v1/brands/{brandId}/pages/sign-in/preview
    /// DeletePreviewSignInPageAsync       DELETE /api/v1/brands/{brandId}/pages/sign-in/preview
    /// ListAllSignInWidgetVersions        GET    /api/v1/brands/{brandId}/pages/sign-in/widget-versions
    /// GetSignOutPageSettingsAsync        GET    /api/v1/brands/{brandId}/pages/sign-out/customized
    /// ReplaceSignOutPageSettingsAsync    PUT    /api/v1/brands/{brandId}/pages/sign-out/customized
    ///
    /// Key constraints discovered via curl validation:
    /// - Brand IDs are discovered dynamically at runtime (ListBrands + CreateBrand) — no hardcoded IDs.
    /// - A temporary brand is created for all write operations and deleted in teardown.
    /// - Write operations (PUT/DELETE) on the DEFAULT brand return 403 E0000213.
    /// - ReplaceCustomizedSignInPageAsync requires widgetCustomizations.WidgetGeneration to be set.
    /// - GetCustomizedErrorPage / GetCustomizedSignInPage return 404 when no customization exists.
    /// - GetPreviewErrorPage / GetPreviewSignInPage return 404 when no preview exists.
    /// - GetErrorPageAsync / GetSignInPageAsync support an optional expand parameter:
    ///     expand="default"       → _embedded.Default is populated with the default page content
    ///     expand="customized"    → _embedded.Customized is populated (null if no customization exists)
    ///     expand="customizedUrl" → _embedded.CustomizedUrl string is populated
    ///     expand="preview"       → _embedded.Preview is populated (null if no preview exists)
    ///     expand="previewUrl"    → _embedded.PreviewUrl string is populated
    /// - ListAllSignInWidgetVersions returns a plain List&lt;string&gt; of semver ranges.
    /// - GetSignOutPageSettings always returns 200 (type="OKTA_DEFAULT" when no redirect configured).
    /// - ReplaceSignOutPageSettings with OKTA_DEFAULT restores the default state (no url required).
    /// - Deleting the write brand in teardown automatically cleans up all its custom pages.
    /// </summary>
    public class CustomPagesApiTests
    {
        private readonly CustomPagesApi _customPagesApi = new();
        private readonly BrandsApi _brandsApi = new();

        private const string CustomErrorPageContent   = "<html><body>SDK Integration Test Error Page</body></html>";
        private const string CustomSignInPageContent  = "<html><body>SDK Integration Test Sign-In Page</body></html>";
        private const string ExternalSignOutUrl       = "https://example.com/sdk-integration-test-signout";

        [Fact]
        public async Task GivenCustomPagesApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string defaultBrandId = null;
            string writeBrandId   = null;

            try
            {
                // ====================================================================
                // SETUP: Discover default brand; create a temporary brand for writes
                // ====================================================================

                #region Setup – discover default brand and create write brand

                var uniqueSuffix = Guid.NewGuid().ToString("N")[..8];

                var allBrands = await _brandsApi.ListBrands().ToListAsync();
                allBrands.Should().NotBeEmpty("the org must have at least one brand");

                var defaultBrand = allBrands.FirstOrDefault(b => b.IsDefault == true);
                defaultBrand.Should().NotBeNull("the org must have a default brand");
                defaultBrandId = defaultBrand!.Id;

                var createdBrand = await _brandsApi.CreateBrandAsync(new CreateBrandRequest
                {
                    Name = $"SDK-CustomPages-Test-{uniqueSuffix}"
                });
                createdBrand.Should().NotBeNull();
                createdBrand.IsDefault.Should().BeFalse("newly created brands are never the default");
                writeBrandId = createdBrand.Id;

                #endregion

                // ====================================================================
                // SECTION 1: GetErrorPageAsync – GET /pages/error (no expand)
                // ====================================================================

                #region GetErrorPageAsync – returns PageRoot with _links, no _embedded

                var errorPageRoot = await _customPagesApi.GetErrorPageAsync(defaultBrandId);

                errorPageRoot.Should().NotBeNull();
                errorPageRoot.Links.Should().NotBeNull("PageRoot must always have _links");
                errorPageRoot.Embedded.Should().BeNull("_embedded is absent when no expand parameter is supplied");

                #endregion

                // ====================================================================
                // SECTION 1b: GetErrorPageAsync with expand=default
                // ====================================================================

                #region GetErrorPageAsync with expand=default – _embedded.Default is populated

                var errorPageRootExpanded = await _customPagesApi.GetErrorPageAsync(
                    defaultBrandId, new List<string> { "default" });

                errorPageRootExpanded.Should().NotBeNull();
                errorPageRootExpanded.Embedded.Should().NotBeNull("expand=default must populate _embedded");
                errorPageRootExpanded.Embedded.Default.Should().NotBeNull("_embedded.default must be present when expand=default");
                errorPageRootExpanded.Embedded.Default.PageContent.Should().NotBeNullOrEmpty();

                #endregion

                // ====================================================================
                // SECTION 2: GetDefaultErrorPageAsync – GET /pages/error/default
                // ====================================================================

                #region GetDefaultErrorPageAsync – returns full HTML content

                var defaultErrorPage = await _customPagesApi.GetDefaultErrorPageAsync(defaultBrandId);

                defaultErrorPage.Should().NotBeNull();
                defaultErrorPage.PageContent.Should().NotBeNullOrEmpty("default error page must have content");

                #endregion

                // ====================================================================
                // SECTION 3: GetCustomizedErrorPageAsync (before write) – expect 404
                // ====================================================================

                #region GetCustomizedErrorPageAsync – 404 before any customization

                var exGetCustomizedErrorBefore = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customPagesApi.GetCustomizedErrorPageAsync(writeBrandId));
                exGetCustomizedErrorBefore.ErrorCode.Should().Be(404,
                    "no customization exists on a freshly created brand before any PUT");

                #endregion

                // ====================================================================
                // SECTION 4: ReplaceCustomizedErrorPageAsync – PUT /pages/error/customized
                // ====================================================================

                #region ReplaceCustomizedErrorPageAsync – create customization on write brand

                var customErrorPage = new ErrorPage { PageContent = CustomErrorPageContent };

                var replacedCustomErrorPage = await _customPagesApi.ReplaceCustomizedErrorPageAsync(writeBrandId, customErrorPage);

                replacedCustomErrorPage.Should().NotBeNull();
                replacedCustomErrorPage.PageContent.Should().Be(CustomErrorPageContent);

                #endregion

                // ====================================================================
                // SECTION 5: GetCustomizedErrorPageAsync (after write) – expect 200
                // ====================================================================

                #region GetCustomizedErrorPageAsync – 200 after PUT

                var retrievedCustomErrorPage = await _customPagesApi.GetCustomizedErrorPageAsync(writeBrandId);

                retrievedCustomErrorPage.Should().NotBeNull();
                retrievedCustomErrorPage.PageContent.Should().Be(CustomErrorPageContent);

                #endregion

                // ====================================================================
                // SECTION 5b: GetErrorPageAsync with expand=customized after write
                // ====================================================================

                #region GetErrorPageAsync with expand=customized – _embedded.Customized populated after PUT

                var errorPageRootWithCustomized = await _customPagesApi.GetErrorPageAsync(
                    writeBrandId, new List<string> { "customized" });

                errorPageRootWithCustomized.Should().NotBeNull();
                errorPageRootWithCustomized.Embedded.Should().NotBeNull("expand=customized must populate _embedded");
                errorPageRootWithCustomized.Embedded.Customized.Should().NotBeNull("_embedded.customized must be present after a PUT");
                errorPageRootWithCustomized.Embedded.Customized.PageContent.Should().Be(CustomErrorPageContent);

                #endregion

                // ====================================================================
                // SECTION 6: DeleteCustomizedErrorPageAsync – DELETE /pages/error/customized
                // ====================================================================

                #region DeleteCustomizedErrorPageAsync – 204

                await _customPagesApi.DeleteCustomizedErrorPageAsync(writeBrandId);

                #endregion

                // ====================================================================
                // SECTION 7: GetPreviewErrorPageAsync (before write) – expect 404
                // ====================================================================

                #region GetPreviewErrorPageAsync – 404 before any preview write

                var exGetPreviewErrorBefore = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customPagesApi.GetPreviewErrorPageAsync(writeBrandId));
                exGetPreviewErrorBefore.ErrorCode.Should().Be(404,
                    "no preview exists on a freshly created brand before any PUT");

                #endregion

                // ====================================================================
                // SECTION 8: ReplacePreviewErrorPageAsync – PUT /pages/error/preview
                // ====================================================================

                #region ReplacePreviewErrorPageAsync – set a preview error page

                var previewErrorPageContent = "<html><body>SDK Integration Test Preview Error Page</body></html>";
                var previewErrorPage = new ErrorPage { PageContent = previewErrorPageContent };

                var replacedPreviewErrorPage = await _customPagesApi.ReplacePreviewErrorPageAsync(writeBrandId, previewErrorPage);

                replacedPreviewErrorPage.Should().NotBeNull();
                replacedPreviewErrorPage.PageContent.Should().Be(previewErrorPageContent);

                #endregion

                // ====================================================================
                // SECTION 9: GetPreviewErrorPageAsync (after write) – expect 200
                // ====================================================================

                #region GetPreviewErrorPageAsync – 200 after PUT

                var retrievedPreviewErrorPage = await _customPagesApi.GetPreviewErrorPageAsync(writeBrandId);

                retrievedPreviewErrorPage.Should().NotBeNull();
                retrievedPreviewErrorPage.PageContent.Should().Be(previewErrorPageContent);

                #endregion

                // ====================================================================
                // SECTION 9b: GetErrorPageAsync with expand=preview after write
                // ====================================================================

                #region GetErrorPageAsync with expand=preview – _embedded.Preview populated after PUT

                var errorPageRootWithPreview = await _customPagesApi.GetErrorPageAsync(
                    writeBrandId, new List<string> { "preview" });

                errorPageRootWithPreview.Should().NotBeNull();
                errorPageRootWithPreview.Embedded.Should().NotBeNull("expand=preview must populate _embedded");
                errorPageRootWithPreview.Embedded.Preview.Should().NotBeNull("_embedded.preview must be present after a preview PUT");
                errorPageRootWithPreview.Embedded.Preview.PageContent.Should().Be(previewErrorPageContent);

                #endregion

                // ====================================================================
                // SECTION 10: DeletePreviewErrorPageAsync – DELETE /pages/error/preview
                // ====================================================================

                #region DeletePreviewErrorPageAsync – 204

                await _customPagesApi.DeletePreviewErrorPageAsync(writeBrandId);

                #endregion

                // ====================================================================
                // SECTION 11: GetSignInPageAsync – GET /pages/sign-in (no expand)
                // ====================================================================

                #region GetSignInPageAsync – returns PageRoot with _links, no _embedded

                var signInPageRoot = await _customPagesApi.GetSignInPageAsync(defaultBrandId);

                signInPageRoot.Should().NotBeNull();
                signInPageRoot.Links.Should().NotBeNull("PageRoot must always have _links");
                signInPageRoot.Embedded.Should().BeNull("_embedded is absent when no expand parameter is supplied");

                #endregion

                // ====================================================================
                // SECTION 11b: GetSignInPageAsync with expand=default
                // ====================================================================

                #region GetSignInPageAsync with expand=default – _embedded.Default is populated

                var signInPageRootExpanded = await _customPagesApi.GetSignInPageAsync(
                    defaultBrandId, new List<string> { "default" });

                signInPageRootExpanded.Should().NotBeNull();
                signInPageRootExpanded.Embedded.Should().NotBeNull("expand=default must populate _embedded");
                signInPageRootExpanded.Embedded.Default.Should().NotBeNull("_embedded.default must be present when expand=default");
                signInPageRootExpanded.Embedded.Default.PageContent.Should().NotBeNullOrEmpty();

                #endregion

                // ====================================================================
                // SECTION 12: GetDefaultSignInPageAsync – GET /pages/sign-in/default
                // ====================================================================

                #region GetDefaultSignInPageAsync – returns full page content and widget config

                var defaultSignInPage = await _customPagesApi.GetDefaultSignInPageAsync(defaultBrandId);

                defaultSignInPage.Should().NotBeNull();
                defaultSignInPage.PageContent.Should().NotBeNullOrEmpty("default sign-in page must have content");
                defaultSignInPage.WidgetVersion.Should().NotBeNullOrEmpty("default sign-in page must have a widget version");
                defaultSignInPage.WidgetCustomizations.Should().NotBeNull("default sign-in page must have widget customizations");

                #endregion

                // ====================================================================
                // SECTION 13: GetCustomizedSignInPageAsync (before write) – expect 404
                // ====================================================================

                #region GetCustomizedSignInPageAsync – 404 before any customization

                var exGetCustomizedSignInBefore = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customPagesApi.GetCustomizedSignInPageAsync(writeBrandId));
                exGetCustomizedSignInBefore.ErrorCode.Should().Be(404,
                    "no sign-in customization exists on a freshly created brand before any PUT");

                #endregion

                // ====================================================================
                // SECTION 14: ReplaceCustomizedSignInPageAsync – PUT /pages/sign-in/customized
                // ====================================================================

                #region ReplaceCustomizedSignInPageAsync – create sign-in customization

                // widgetCustomizations is required and must include WidgetGeneration
                var customSignInPage = new SignInPage
                {
                    PageContent = CustomSignInPageContent,
                    WidgetVersion = "^7",
                    WidgetCustomizations = new SignInPageAllOfWidgetCustomizations
                    {
                        WidgetGeneration = WidgetGeneration.G2
                    }
                };

                var replacedCustomSignInPage = await _customPagesApi.ReplaceCustomizedSignInPageAsync(writeBrandId, customSignInPage);

                replacedCustomSignInPage.Should().NotBeNull();
                replacedCustomSignInPage.PageContent.Should().Be(CustomSignInPageContent);
                replacedCustomSignInPage.WidgetVersion.Should().Be("^7");
                replacedCustomSignInPage.WidgetCustomizations.Should().NotBeNull();

                #endregion

                // ====================================================================
                // SECTION 15: GetCustomizedSignInPageAsync (after write) – expect 200
                // ====================================================================

                #region GetCustomizedSignInPageAsync – 200 after PUT

                var retrievedCustomSignInPage = await _customPagesApi.GetCustomizedSignInPageAsync(writeBrandId);

                retrievedCustomSignInPage.Should().NotBeNull();
                retrievedCustomSignInPage.PageContent.Should().Be(CustomSignInPageContent);
                retrievedCustomSignInPage.WidgetCustomizations.Should().NotBeNull();

                #endregion

                // ====================================================================
                // SECTION 15b: GetSignInPageAsync with expand=customized after write
                // ====================================================================

                #region GetSignInPageAsync with expand=customized – _embedded.Customized populated after PUT

                var signInPageRootWithCustomized = await _customPagesApi.GetSignInPageAsync(
                    writeBrandId, new List<string> { "customized" });

                signInPageRootWithCustomized.Should().NotBeNull();
                signInPageRootWithCustomized.Embedded.Should().NotBeNull("expand=customized must populate _embedded");
                signInPageRootWithCustomized.Embedded.Customized.Should().NotBeNull("_embedded.customized must be present after a PUT");
                signInPageRootWithCustomized.Embedded.Customized.PageContent.Should().Be(CustomSignInPageContent);

                #endregion

                // ====================================================================
                // SECTION 16: DeleteCustomizedSignInPageAsync – DELETE /pages/sign-in/customized
                // ====================================================================

                #region DeleteCustomizedSignInPageAsync – 204

                await _customPagesApi.DeleteCustomizedSignInPageAsync(writeBrandId);

                #endregion

                // ====================================================================
                // SECTION 17a: GetPreviewSignInPageAsync (before write) – expect 404
                // ====================================================================

                #region GetPreviewSignInPageAsync – 404 before any preview write

                var exGetPreviewSignInBefore = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customPagesApi.GetPreviewSignInPageAsync(writeBrandId));
                exGetPreviewSignInBefore.ErrorCode.Should().Be(404,
                    "no sign-in preview exists on a freshly created brand before any PUT");

                #endregion

                // ====================================================================
                // SECTION 17: ReplacePreviewSignInPageAsync – PUT /pages/sign-in/preview
                // ====================================================================

                #region ReplacePreviewSignInPageAsync – set a preview sign-in page

                var previewSignInPageContent = "<html><body>SDK Integration Test Preview Sign-In Page</body></html>";
                var previewSignInPage = new SignInPage
                {
                    PageContent = previewSignInPageContent,
                    WidgetVersion = "^7",
                    WidgetCustomizations = new SignInPageAllOfWidgetCustomizations
                    {
                        WidgetGeneration = WidgetGeneration.G2
                    }
                };

                var replacedPreviewSignInPage = await _customPagesApi.ReplacePreviewSignInPageAsync(writeBrandId, previewSignInPage);

                replacedPreviewSignInPage.Should().NotBeNull();
                replacedPreviewSignInPage.PageContent.Should().Be(previewSignInPageContent);
                replacedPreviewSignInPage.WidgetCustomizations.Should().NotBeNull();

                #endregion

                // ====================================================================
                // SECTION 18: GetPreviewSignInPageAsync (after write) – expect 200
                // ====================================================================

                #region GetPreviewSignInPageAsync – 200 after PUT

                var retrievedPreviewSignInPage = await _customPagesApi.GetPreviewSignInPageAsync(writeBrandId);

                retrievedPreviewSignInPage.Should().NotBeNull();
                retrievedPreviewSignInPage.PageContent.Should().Be(previewSignInPageContent);

                #endregion

                // ====================================================================
                // SECTION 18b: GetSignInPageAsync with expand=preview after write
                // ====================================================================

                #region GetSignInPageAsync with expand=preview – _embedded.Preview populated after PUT

                var signInPageRootWithPreview = await _customPagesApi.GetSignInPageAsync(
                    writeBrandId, new List<string> { "preview" });

                signInPageRootWithPreview.Should().NotBeNull();
                signInPageRootWithPreview.Embedded.Should().NotBeNull("expand=preview must populate _embedded");
                signInPageRootWithPreview.Embedded.Preview.Should().NotBeNull("_embedded.preview must be present after a preview PUT");
                signInPageRootWithPreview.Embedded.Preview.PageContent.Should().Be(previewSignInPageContent);

                #endregion

                // ====================================================================
                // SECTION 19: DeletePreviewSignInPageAsync – DELETE /pages/sign-in/preview
                // ====================================================================

                #region DeletePreviewSignInPageAsync – 204

                await _customPagesApi.DeletePreviewSignInPageAsync(writeBrandId);

                #endregion

                // ====================================================================
                // SECTION 20: ListAllSignInWidgetVersions – GET /pages/sign-in/widget-versions
                // ====================================================================

                #region ListAllSignInWidgetVersions – returns non-empty list of version strings

                var widgetVersions = await _customPagesApi.ListAllSignInWidgetVersions(defaultBrandId).ToListAsync();

                widgetVersions.Should().NotBeNull();
                widgetVersions.Should().NotBeEmpty("the org must support at least one widget version");
                widgetVersions.Should().Contain("^7", "the current major widget version must be available");

                #endregion

                // ====================================================================
                // SECTION 21: GetSignOutPageSettingsAsync – GET /pages/sign-out/customized
                // ====================================================================

                #region GetSignOutPageSettingsAsync – returns HostedPage (OKTA_DEFAULT on a fresh brand)

                var signOutSettings = await _customPagesApi.GetSignOutPageSettingsAsync(writeBrandId);

                signOutSettings.Should().NotBeNull();
                signOutSettings.Type.Should().Be(HostedPageType.OKTADEFAULT,
                    "a freshly created brand has the sign-out page set to OKTA_DEFAULT");

                #endregion

                // ====================================================================
                // SECTION 22: ReplaceSignOutPageSettingsAsync – PUT /pages/sign-out/customized
                // ====================================================================

                #region ReplaceSignOutPageSettingsAsync – set externally-hosted sign-out page

                var externalSignOutPage = new HostedPage
                {
                    Type = HostedPageType.EXTERNALLYHOSTED,
                    Url  = ExternalSignOutUrl
                };

                var replacedSignOutSettings = await _customPagesApi.ReplaceSignOutPageSettingsAsync(writeBrandId, externalSignOutPage);

                replacedSignOutSettings.Should().NotBeNull();
                replacedSignOutSettings.Type.Should().Be(HostedPageType.EXTERNALLYHOSTED);
                replacedSignOutSettings.Url.Should().Be(ExternalSignOutUrl);

                #endregion

                // ====================================================================
                // SECTION 23: GetSignOutPageSettingsAsync (after write) – verify URL
                // ====================================================================

                #region GetSignOutPageSettingsAsync – verify EXTERNALLY_HOSTED state and URL

                var verifiedSignOutSettings = await _customPagesApi.GetSignOutPageSettingsAsync(writeBrandId);

                verifiedSignOutSettings.Should().NotBeNull();
                verifiedSignOutSettings.Type.Should().Be(HostedPageType.EXTERNALLYHOSTED);
                verifiedSignOutSettings.Url.Should().Be(ExternalSignOutUrl);

                #endregion

                // ====================================================================
                // SECTION 24: Negative scenarios – writes on default brand return 403
                // ====================================================================

                #region Negative: ReplaceCustomizedErrorPage on default brand → 403 E0000213

                var exErrorOnDefault = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customPagesApi.ReplaceCustomizedErrorPageAsync(defaultBrandId, new ErrorPage
                    {
                        PageContent = "<html><body>Should Fail</body></html>"
                    }));

                exErrorOnDefault.ErrorCode.Should().Be(403,
                    "writing to the default brand must return HTTP 403 (E0000213)");

                #endregion

                #region Negative: ReplaceCustomizedSignInPage on default brand → 403 E0000213

                var exSignInOnDefault = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _customPagesApi.ReplaceCustomizedSignInPageAsync(defaultBrandId, new SignInPage
                    {
                        PageContent = "<html><body>Should Fail</body></html>",
                        WidgetVersion = "^7",
                        WidgetCustomizations = new SignInPageAllOfWidgetCustomizations
                        {
                            WidgetGeneration = WidgetGeneration.G2
                        }
                    }));

                exSignInOnDefault.ErrorCode.Should().Be(403,
                    "writing to the default brand must return HTTP 403 (E0000213)");

                #endregion

                // ====================================================================
                // SECTION 25+: WithHttpInfo variants – verify all 19 HTTP status codes
                // ====================================================================

                #region WithHttpInfo – GetErrorPageWithHttpInfoAsync → 200

                var errorPageRootInfo = await _customPagesApi.GetErrorPageWithHttpInfoAsync(defaultBrandId);
                errorPageRootInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                errorPageRootInfo.Data.Should().NotBeNull();
                errorPageRootInfo.Data.Links.Should().NotBeNull();

                #endregion

                #region WithHttpInfo – GetErrorPageWithHttpInfoAsync with expand=default → 200, _embedded populated

                var errorPageRootInfoExpanded = await _customPagesApi.GetErrorPageWithHttpInfoAsync(
                    defaultBrandId, new List<string> { "default" });
                errorPageRootInfoExpanded.StatusCode.Should().Be(HttpStatusCode.OK);
                errorPageRootInfoExpanded.Data.Embedded.Should().NotBeNull();
                errorPageRootInfoExpanded.Data.Embedded.Default.Should().NotBeNull();

                #endregion

                #region WithHttpInfo – GetDefaultErrorPageWithHttpInfoAsync → 200

                var defaultErrorPageInfo = await _customPagesApi.GetDefaultErrorPageWithHttpInfoAsync(defaultBrandId);
                defaultErrorPageInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                defaultErrorPageInfo.Data.Should().NotBeNull();
                defaultErrorPageInfo.Data.PageContent.Should().NotBeNullOrEmpty();

                #endregion

                #region WithHttpInfo – ReplaceCustomizedErrorPageWithHttpInfoAsync → 200

                var replaceCustomErrorInfo = await _customPagesApi.ReplaceCustomizedErrorPageWithHttpInfoAsync(
                    writeBrandId, new ErrorPage { PageContent = CustomErrorPageContent });

                replaceCustomErrorInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                replaceCustomErrorInfo.Data.PageContent.Should().Be(CustomErrorPageContent);

                #endregion

                #region WithHttpInfo – GetCustomizedErrorPageWithHttpInfoAsync → 200

                var getCustomErrorInfo = await _customPagesApi.GetCustomizedErrorPageWithHttpInfoAsync(writeBrandId);
                getCustomErrorInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                getCustomErrorInfo.Data.PageContent.Should().Be(CustomErrorPageContent);

                #endregion

                #region WithHttpInfo – DeleteCustomizedErrorPageWithHttpInfoAsync → 204

                var deleteCustomErrorInfo = await _customPagesApi.DeleteCustomizedErrorPageWithHttpInfoAsync(writeBrandId);
                deleteCustomErrorInfo.StatusCode.Should().Be(HttpStatusCode.NoContent);

                #endregion

                #region WithHttpInfo – ReplacePreviewErrorPageWithHttpInfoAsync → 200

                var replacePreviewErrorInfo = await _customPagesApi.ReplacePreviewErrorPageWithHttpInfoAsync(
                    writeBrandId, new ErrorPage { PageContent = "<html><body>WithHttpInfo Preview Error</body></html>" });

                replacePreviewErrorInfo.StatusCode.Should().Be(HttpStatusCode.OK);

                #endregion

                #region WithHttpInfo – GetPreviewErrorPageWithHttpInfoAsync → 200

                var getPreviewErrorInfo = await _customPagesApi.GetPreviewErrorPageWithHttpInfoAsync(writeBrandId);
                getPreviewErrorInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                getPreviewErrorInfo.Data.Should().NotBeNull();

                #endregion

                #region WithHttpInfo – DeletePreviewErrorPageWithHttpInfoAsync → 204

                var deletePreviewErrorInfo = await _customPagesApi.DeletePreviewErrorPageWithHttpInfoAsync(writeBrandId);
                deletePreviewErrorInfo.StatusCode.Should().Be(HttpStatusCode.NoContent);

                #endregion

                #region WithHttpInfo – GetSignInPageWithHttpInfoAsync → 200

                var signInPageRootInfo = await _customPagesApi.GetSignInPageWithHttpInfoAsync(defaultBrandId);
                signInPageRootInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                signInPageRootInfo.Data.Should().NotBeNull();
                signInPageRootInfo.Data.Links.Should().NotBeNull();

                #endregion

                #region WithHttpInfo – GetSignInPageWithHttpInfoAsync with expand=default → 200, _embedded populated

                var signInPageRootInfoExpanded = await _customPagesApi.GetSignInPageWithHttpInfoAsync(
                    defaultBrandId, new List<string> { "default" });
                signInPageRootInfoExpanded.StatusCode.Should().Be(HttpStatusCode.OK);
                signInPageRootInfoExpanded.Data.Embedded.Should().NotBeNull();
                signInPageRootInfoExpanded.Data.Embedded.Default.Should().NotBeNull();

                #endregion

                #region WithHttpInfo – GetDefaultSignInPageWithHttpInfoAsync → 200

                var defaultSignInPageInfo = await _customPagesApi.GetDefaultSignInPageWithHttpInfoAsync(defaultBrandId);
                defaultSignInPageInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                defaultSignInPageInfo.Data.Should().NotBeNull();
                defaultSignInPageInfo.Data.PageContent.Should().NotBeNullOrEmpty();

                #endregion

                #region WithHttpInfo – ReplaceCustomizedSignInPageWithHttpInfoAsync → 200

                var replaceCustomSignInInfo = await _customPagesApi.ReplaceCustomizedSignInPageWithHttpInfoAsync(
                    writeBrandId, new SignInPage
                    {
                        PageContent = CustomSignInPageContent,
                        WidgetVersion = "^7",
                        WidgetCustomizations = new SignInPageAllOfWidgetCustomizations
                        {
                            WidgetGeneration = WidgetGeneration.G2
                        }
                    });

                replaceCustomSignInInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                replaceCustomSignInInfo.Data.PageContent.Should().Be(CustomSignInPageContent);

                #endregion

                #region WithHttpInfo – GetCustomizedSignInPageWithHttpInfoAsync → 200

                var getCustomSignInInfo = await _customPagesApi.GetCustomizedSignInPageWithHttpInfoAsync(writeBrandId);
                getCustomSignInInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                getCustomSignInInfo.Data.PageContent.Should().Be(CustomSignInPageContent);

                #endregion

                #region WithHttpInfo – DeleteCustomizedSignInPageWithHttpInfoAsync → 204

                var deleteCustomSignInInfo = await _customPagesApi.DeleteCustomizedSignInPageWithHttpInfoAsync(writeBrandId);
                deleteCustomSignInInfo.StatusCode.Should().Be(HttpStatusCode.NoContent);

                #endregion

                #region WithHttpInfo – ReplacePreviewSignInPageWithHttpInfoAsync → 200

                var replacePreviewSignInInfo = await _customPagesApi.ReplacePreviewSignInPageWithHttpInfoAsync(
                    writeBrandId, new SignInPage
                    {
                        PageContent = "<html><body>WithHttpInfo Preview SignIn</body></html>",
                        WidgetVersion = "^7",
                        WidgetCustomizations = new SignInPageAllOfWidgetCustomizations
                        {
                            WidgetGeneration = WidgetGeneration.G2
                        }
                    });

                replacePreviewSignInInfo.StatusCode.Should().Be(HttpStatusCode.OK);

                #endregion

                #region WithHttpInfo – GetPreviewSignInPageWithHttpInfoAsync → 200

                var getPreviewSignInInfo = await _customPagesApi.GetPreviewSignInPageWithHttpInfoAsync(writeBrandId);
                getPreviewSignInInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                getPreviewSignInInfo.Data.Should().NotBeNull();

                #endregion

                #region WithHttpInfo – DeletePreviewSignInPageWithHttpInfoAsync → 204

                var deletePreviewSignInInfo = await _customPagesApi.DeletePreviewSignInPageWithHttpInfoAsync(writeBrandId);
                deletePreviewSignInInfo.StatusCode.Should().Be(HttpStatusCode.NoContent);

                #endregion

                #region WithHttpInfo – ListAllSignInWidgetVersionsWithHttpInfoAsync → 200

                var widgetVersionsInfo = await _customPagesApi.ListAllSignInWidgetVersionsWithHttpInfoAsync(defaultBrandId);
                widgetVersionsInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                widgetVersionsInfo.Data.Should().NotBeNullOrEmpty();

                #endregion

                #region WithHttpInfo – GetSignOutPageSettingsWithHttpInfoAsync → 200

                var signOutSettingsInfo = await _customPagesApi.GetSignOutPageSettingsWithHttpInfoAsync(defaultBrandId);
                signOutSettingsInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                signOutSettingsInfo.Data.Should().NotBeNull();
                signOutSettingsInfo.Data.Type.Should().NotBeNull();

                #endregion

                #region WithHttpInfo – ReplaceSignOutPageSettingsWithHttpInfoAsync → 200 (EXTERNALLY_HOSTED)

                var replaceSignOutInfo = await _customPagesApi.ReplaceSignOutPageSettingsWithHttpInfoAsync(
                    writeBrandId, new HostedPage
                    {
                        Type = HostedPageType.EXTERNALLYHOSTED,
                        Url  = ExternalSignOutUrl
                    });

                replaceSignOutInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                replaceSignOutInfo.Data.Type.Should().Be(HostedPageType.EXTERNALLYHOSTED);
                replaceSignOutInfo.Data.Url.Should().Be(ExternalSignOutUrl);

                #endregion
            }
            finally
            {
                // ====================================================================
                // TEARDOWN: delete the created write brand — removes all its custom pages automatically
                // ====================================================================

                if (writeBrandId != null)
                {
                    try { await _brandsApi.DeleteBrandAsync(writeBrandId); } catch { }
                }
            }
        }
    }
}
