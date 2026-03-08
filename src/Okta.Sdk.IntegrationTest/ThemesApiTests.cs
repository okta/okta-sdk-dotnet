// <copyright file="ThemesApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for ThemesApi covering all 9 endpoints and their 18 SDK methods
    /// (9 primary + 9 WithHttpInfo variants).
    ///
    /// ThemesApi → Endpoint Mapping
    /// ─────────────────────────────────────────────────────────────────────────────────────
    /// ListBrandThemes                      GET    /api/v1/brands/{brandId}/themes
    /// GetBrandThemeAsync                   GET    /api/v1/brands/{brandId}/themes/{themeId}
    /// ReplaceBrandThemeAsync               PUT    /api/v1/brands/{brandId}/themes/{themeId}
    /// UploadBrandThemeLogoAsync            POST   /api/v1/brands/{brandId}/themes/{themeId}/logo
    /// DeleteBrandThemeLogoAsync            DELETE /api/v1/brands/{brandId}/themes/{themeId}/logo
    /// UploadBrandThemeFaviconAsync         POST   /api/v1/brands/{brandId}/themes/{themeId}/favicon
    /// DeleteBrandThemeFaviconAsync         DELETE /api/v1/brands/{brandId}/themes/{themeId}/favicon
    /// UploadBrandThemeBackgroundImageAsync POST   /api/v1/brands/{brandId}/themes/{themeId}/background-image
    /// DeleteBrandThemeBackgroundImageAsync DELETE /api/v1/brands/{brandId}/themes/{themeId}/background-image
    ///
    /// Key behavioral notes
    /// ─────────────────────────────────────────────────────────────────────────────────────
    /// - Each org/brand has exactly one theme (no create or delete for the theme itself).
    /// - Tests operate on the org's default brand and its theme, discovered dynamically.
    /// - The original theme state (colors + variants) is snapshotted at the start and
    ///   restored unconditionally in the finally block.
    /// - Logo upload → 201 Created  (confirmed via live API)
    /// - Favicon upload → 201 Created
    /// - Background image upload → 201 Created
    /// - All deletes (logo, favicon, background-image) → 204 No Content
    /// - GET / PUT with an invalid themeId → 404 (E0000007)
    /// - GET / DELETE with an invalid brandId → 404 (E0000007)
    /// - The themes list endpoint returns a bare JSON array, so
    ///   ListBrandThemesWithHttpInfoAsync(..).Data IS populated (unlike the BrandsApi
    ///   domains endpoint which wraps in an envelope object).
    /// </summary>
    public class ThemesApiTests
    {
        private readonly ThemesApi _themesApi = new();
        private readonly BrandsApi _brandsApi = new();

        // ──────────────────────────────────────────────────────────────────────────────
        // Helpers
        // ──────────────────────────────────────────────────────────────────────────────

        /// <summary>
        /// A minimal 1×1 transparent PNG (67 bytes). Valid for logo, favicon, and
        /// background-image uploads; satisfy the PNG/JPG/GIF format requirement.
        /// </summary>
        private static readonly byte[] MinimalPngBytes = Convert.FromBase64String(
            "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg==");

        /// <summary>
        /// Returns a FileStream backed by a temp .png file.
        /// The SDK's ApiClient only extracts a filename (with extension) from FileStream;
        /// MemoryStream gets renamed to "no_file_name_provided" (no extension) which Okta rejects.
        /// FileOptions.DeleteOnClose ensures the temp file is removed when the stream is disposed.
        /// </summary>
        private static Stream PngStream()
        {
            var tmpPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.png");
            File.WriteAllBytes(tmpPath, MinimalPngBytes);
            return new FileStream(tmpPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.DeleteOnClose);
        }

        /// <summary>
        /// Builds an <see cref="UpdateThemeRequest"/> that resets all touchpoint variants
        /// to their defaults and keeps the standard Okta brand colors.
        /// Used for the WithHttpInfo test where we just need a valid body for PUT.
        /// </summary>
        private static UpdateThemeRequest DefaultThemeRequest() => new UpdateThemeRequest
        {
            PrimaryColorHex = "#1662dd",
            SecondaryColorHex = "#ebebed",
            SignInPageTouchPointVariant = SignInPageTouchPointVariant.OKTADEFAULT,
            EndUserDashboardTouchPointVariant = EndUserDashboardTouchPointVariant.OKTADEFAULT,
            ErrorPageTouchPointVariant = ErrorPageTouchPointVariant.OKTADEFAULT,
            EmailTemplateTouchPointVariant = EmailTemplateTouchPointVariant.OKTADEFAULT,
            LoadingPageTouchPointVariant = LoadingPageTouchPointVariant.OKTADEFAULT,
        };

        /// <summary>
        /// Builds a restore request from a live <see cref="ThemeResponse"/> snapshot.
        /// Falls back to Okta defaults when a field is null so PUT never fails validation.
        /// </summary>
        private static UpdateThemeRequest RestoreRequestFrom(ThemeResponse snapshot) => new UpdateThemeRequest
        {
            PrimaryColorHex = snapshot.PrimaryColorHex ?? "#1662dd",
            PrimaryColorContrastHex = snapshot.PrimaryColorContrastHex,
            SecondaryColorHex = snapshot.SecondaryColorHex ?? "#ebebed",
            SecondaryColorContrastHex = snapshot.SecondaryColorContrastHex,
            SignInPageTouchPointVariant = snapshot.SignInPageTouchPointVariant ?? SignInPageTouchPointVariant.OKTADEFAULT,
            EndUserDashboardTouchPointVariant = snapshot.EndUserDashboardTouchPointVariant ?? EndUserDashboardTouchPointVariant.OKTADEFAULT,
            ErrorPageTouchPointVariant = snapshot.ErrorPageTouchPointVariant ?? ErrorPageTouchPointVariant.OKTADEFAULT,
            EmailTemplateTouchPointVariant = snapshot.EmailTemplateTouchPointVariant ?? EmailTemplateTouchPointVariant.OKTADEFAULT,
            LoadingPageTouchPointVariant = snapshot.LoadingPageTouchPointVariant ?? LoadingPageTouchPointVariant.OKTADEFAULT,
        };

        // ──────────────────────────────────────────────────────────────────────────────
        // Tests
        // ──────────────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Comprehensive single test covering all 9 ThemesApi endpoints and their primary
        /// (non-WithHttpInfo) methods:
        ///
        /// Happy-path scenarios
        ///   1. ListBrandThemes        – discovers the brand's single theme
        ///   2. GetBrandThemeAsync     – retrieves the theme by ID, verifies fields
        ///   3. ReplaceBrandThemeAsync – updates touchpoint variants and colors, verifies persistence
        ///   4. UploadBrandThemeLogoAsync      – uploads a minimal PNG → 201 + CDN URL, verifies ThemeResponse.Logo
        ///   5. DeleteBrandThemeLogoAsync      – deletes the logo → 204, theme still accessible
        ///   6. UploadBrandThemeFaviconAsync   – uploads a minimal PNG → 201 + CDN URL, verifies ThemeResponse.Favicon
        ///   7. DeleteBrandThemeFaviconAsync   – deletes the favicon → 204
        ///   8. UploadBrandThemeBackgroundImageAsync – uploads a minimal PNG → 201 + CDN URL, verifies ThemeResponse.BackgroundImage
        ///  8a. BACKGROUND_IMAGE variants for SignInPage and ErrorPage (while background image is present)
        ///   9. DeleteBrandThemeBackgroundImageAsync – deletes the background image → 204
        ///
        /// Negative scenarios (invalid themeId or brandId → 404)
        ///  10. GetBrandThemeAsync           – invalid themeId
        ///  11. ReplaceBrandThemeAsync       – invalid themeId
        ///  12. DeleteBrandThemeLogoAsync    – invalid brandId
        ///  13. UploadBrandThemeLogoAsync    – invalid themeId
        ///  14. DeleteBrandThemeFaviconAsync – invalid themeId
        ///  15. DeleteBrandThemeBackgroundImageAsync – invalid themeId
        ///  16. ListBrandThemes              – invalid brandId
        ///  17. GetBrandThemeAsync           – invalid brandId
        ///  18. ReplaceBrandThemeAsync       – invalid brandId
        ///  19. UploadBrandThemeLogoAsync    – invalid brandId
        ///  20. UploadBrandThemeFaviconAsync – invalid brandId
        ///  21. UploadBrandThemeBackgroundImageAsync – invalid brandId
        ///  22. DeleteBrandThemeFaviconAsync – invalid brandId
        ///  23. DeleteBrandThemeBackgroundImageAsync – invalid brandId
        ///
        /// Teardown: theme colors/variants are always restored to their original state.
        /// Logo/favicon/background-image are deleted in the test body; the finally block
        /// makes a best-effort cleanup of any remaining assets.
        /// </summary>
        [Fact]
        public async Task GivenThemesApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            // ── Setup: discover the default brand and its theme ───────────────────────
            var brands = await _brandsApi.ListBrands().ToListAsync();
            var defaultBrand = brands.FirstOrDefault(b => b.IsDefault);
            defaultBrand.Should().NotBeNull("the org must have a default brand");
            var brandId = defaultBrand!.Id;

            var themes = await _themesApi.ListBrandThemes(brandId).ToListAsync();
            themes.Should().NotBeNullOrEmpty("every brand has at least one theme");
            var themeId = themes[0].Id;

            // Snapshot original state for restoration in finally block
            var originalTheme = await _themesApi.GetBrandThemeAsync(brandId, themeId);
            var restoreRequest = RestoreRequestFrom(originalTheme);

            try
            {
                // ====================================================================
                // SECTION 1: ListBrandThemes – GET /api/v1/brands/{brandId}/themes
                // ====================================================================

                #region ListBrandThemes – org's brand has exactly one theme

                // Org currently supports exactly one theme per brand; the list always has one entry.
                themes.Should().HaveCountGreaterThanOrEqualTo(1,
                    "each brand always has at least one theme");

                foreach (var t in themes)
                {
                    t.Id.Should().NotBeNullOrEmpty();
                    t.SignInPageTouchPointVariant.Should().NotBeNull();
                    t.PrimaryColorHex.Should().NotBeNullOrEmpty();
                }

                #endregion

                // ====================================================================
                // SECTION 2: GetBrandThemeAsync – GET /api/v1/brands/{brandId}/themes/{themeId}
                // ====================================================================

                #region GetBrandThemeAsync – retrieve theme by ID, verify required fields

                var retrieved = await _themesApi.GetBrandThemeAsync(brandId, themeId);

                retrieved.Should().NotBeNull();
                retrieved.Id.Should().Be(themeId);
                retrieved.PrimaryColorHex.Should().NotBeNullOrEmpty();
                retrieved.SecondaryColorHex.Should().NotBeNullOrEmpty();
                retrieved.SignInPageTouchPointVariant.Should().NotBeNull();
                retrieved.EndUserDashboardTouchPointVariant.Should().NotBeNull();
                retrieved.ErrorPageTouchPointVariant.Should().NotBeNull();
                retrieved.EmailTemplateTouchPointVariant.Should().NotBeNull();
                retrieved.LoadingPageTouchPointVariant.Should().NotBeNull();

                // HAL links – every ThemeResponse must include _links.self
                retrieved.Links.Should().NotBeNull("every theme response includes HAL _links");
                retrieved.Links.Self.Should().NotBeNull("self link must point to the theme URL");

                // Logo, Favicon, and BackgroundImage are read-only CDN URLs; may be null if no asset is uploaded.

                #endregion

                // ====================================================================
                // SECTION 3: ReplaceBrandThemeAsync – PUT /api/v1/brands/{brandId}/themes/{themeId}
                //
                // Exercises BACKGROUND_SECONDARY_COLOR (signIn), FULL_THEME (email/endUser),
                // BACKGROUND_SECONDARY_COLOR (error) and NONE (loading) variants – all non-default
                // values to confirm every enum path is reachable.
                // ====================================================================

                #region ReplaceBrandThemeAsync – update colors and all touchpoint variant fields

                var updateRequest = new UpdateThemeRequest
                {
                    PrimaryColorHex = "#e00000",
                    PrimaryColorContrastHex = "#ffffff",
                    SecondaryColorHex = "#ff6600",
                    SecondaryColorContrastHex = "#000000",
                    SignInPageTouchPointVariant = SignInPageTouchPointVariant.BACKGROUNDSECONDARYCOLOR,
                    EndUserDashboardTouchPointVariant = EndUserDashboardTouchPointVariant.FULLTHEME,
                    ErrorPageTouchPointVariant = ErrorPageTouchPointVariant.BACKGROUNDSECONDARYCOLOR,
                    EmailTemplateTouchPointVariant = EmailTemplateTouchPointVariant.FULLTHEME,
                    LoadingPageTouchPointVariant = LoadingPageTouchPointVariant.NONE,
                };

                var replaced = await _themesApi.ReplaceBrandThemeAsync(brandId, themeId, updateRequest);

                replaced.Should().NotBeNull();
                replaced.Id.Should().Be(themeId);
                replaced.PrimaryColorHex.Should().Be("#e00000");
                replaced.SecondaryColorHex.Should().Be("#ff6600");
                replaced.SignInPageTouchPointVariant.Should().Be(SignInPageTouchPointVariant.BACKGROUNDSECONDARYCOLOR);
                replaced.EndUserDashboardTouchPointVariant.Should().Be(EndUserDashboardTouchPointVariant.FULLTHEME);
                replaced.ErrorPageTouchPointVariant.Should().Be(ErrorPageTouchPointVariant.BACKGROUNDSECONDARYCOLOR);
                replaced.EmailTemplateTouchPointVariant.Should().Be(EmailTemplateTouchPointVariant.FULLTHEME);
                replaced.LoadingPageTouchPointVariant.Should().Be(LoadingPageTouchPointVariant.NONE);

                // Verify all color and variant fields are persisted via a subsequent GET
                var verifyReplace = await _themesApi.GetBrandThemeAsync(brandId, themeId);
                verifyReplace.PrimaryColorHex.Should().Be("#e00000");
                verifyReplace.PrimaryColorContrastHex.Should().Be("#ffffff");
                verifyReplace.SecondaryColorHex.Should().Be("#ff6600");
                verifyReplace.SecondaryColorContrastHex.Should().Be("#000000");
                verifyReplace.SignInPageTouchPointVariant.Should().Be(SignInPageTouchPointVariant.BACKGROUNDSECONDARYCOLOR);
                verifyReplace.EndUserDashboardTouchPointVariant.Should().Be(EndUserDashboardTouchPointVariant.FULLTHEME);
                verifyReplace.ErrorPageTouchPointVariant.Should().Be(ErrorPageTouchPointVariant.BACKGROUNDSECONDARYCOLOR);
                verifyReplace.EmailTemplateTouchPointVariant.Should().Be(EmailTemplateTouchPointVariant.FULLTHEME);
                verifyReplace.LoadingPageTouchPointVariant.Should().Be(LoadingPageTouchPointVariant.NONE);

                // Test LOGO_ON_FULL_WHITE_BACKGROUND variant for EndUserDashboard
                var logoOnWhiteReplace = await _themesApi.ReplaceBrandThemeAsync(brandId, themeId,
                    new UpdateThemeRequest
                    {
                        PrimaryColorHex = "#1662dd",
                        SecondaryColorHex = "#ebebed",
                        SignInPageTouchPointVariant = SignInPageTouchPointVariant.OKTADEFAULT,
                        EndUserDashboardTouchPointVariant = EndUserDashboardTouchPointVariant.LOGOONFULLWHITEBACKGROUND,
                        ErrorPageTouchPointVariant = ErrorPageTouchPointVariant.OKTADEFAULT,
                        EmailTemplateTouchPointVariant = EmailTemplateTouchPointVariant.OKTADEFAULT,
                        LoadingPageTouchPointVariant = LoadingPageTouchPointVariant.OKTADEFAULT,
                    });
                logoOnWhiteReplace.EndUserDashboardTouchPointVariant.Should().Be(EndUserDashboardTouchPointVariant.LOGOONFULLWHITEBACKGROUND);

                // Test WHITE_LOGO_BACKGROUND variant for EndUserDashboard
                var whiteLogoBgReplace = await _themesApi.ReplaceBrandThemeAsync(brandId, themeId,
                    new UpdateThemeRequest
                    {
                        PrimaryColorHex = "#1662dd",
                        SecondaryColorHex = "#ebebed",
                        SignInPageTouchPointVariant = SignInPageTouchPointVariant.OKTADEFAULT,
                        EndUserDashboardTouchPointVariant = EndUserDashboardTouchPointVariant.WHITELOGOBACKGROUND,
                        ErrorPageTouchPointVariant = ErrorPageTouchPointVariant.OKTADEFAULT,
                        EmailTemplateTouchPointVariant = EmailTemplateTouchPointVariant.OKTADEFAULT,
                        LoadingPageTouchPointVariant = LoadingPageTouchPointVariant.OKTADEFAULT,
                    });
                whiteLogoBgReplace.EndUserDashboardTouchPointVariant.Should().Be(EndUserDashboardTouchPointVariant.WHITELOGOBACKGROUND);

                // Restore to OKTA_DEFAULT before proceeding to upload tests
                var defaultUpdate = await _themesApi.ReplaceBrandThemeAsync(brandId, themeId, DefaultThemeRequest());
                defaultUpdate.SignInPageTouchPointVariant.Should().Be(SignInPageTouchPointVariant.OKTADEFAULT);
                defaultUpdate.EndUserDashboardTouchPointVariant.Should().Be(EndUserDashboardTouchPointVariant.OKTADEFAULT);

                #endregion

                // ====================================================================
                // SECTION 4: UploadBrandThemeLogoAsync – POST .../logo → 200 OK
                // ====================================================================

                #region UploadBrandThemeLogoAsync – upload a PNG logo, verify CDN URL returned

                await using var logoStream = PngStream();
                var logoUpload = await _themesApi.UploadBrandThemeLogoAsync(brandId, themeId, logoStream);

                logoUpload.Should().NotBeNull();
                logoUpload.Url.Should().NotBeNullOrEmpty(
                    "a successful logo upload must return a CDN URL for the new logo");

                // The read-only ThemeResponse.Logo field must reflect the CDN URL after upload
                var afterLogoUpload = await _themesApi.GetBrandThemeAsync(brandId, themeId);
                afterLogoUpload.Logo.Should().NotBeNullOrEmpty(
                    "ThemeResponse.Logo must be populated after a successful logo upload");

                #endregion

                // ====================================================================
                // SECTION 5: DeleteBrandThemeLogoAsync – DELETE .../logo → 204 No Content
                // ====================================================================

                #region DeleteBrandThemeLogoAsync – delete the uploaded logo

                // Should succeed silently (204 – no response body)
                await _themesApi.DeleteBrandThemeLogoAsync(brandId, themeId);

                // The theme still exists and remains accessible after the logo is deleted
                var afterLogoDelete = await _themesApi.GetBrandThemeAsync(brandId, themeId);
                afterLogoDelete.Should().NotBeNull("theme must still be accessible after logo deletion");
                afterLogoDelete.Id.Should().Be(themeId);

                #endregion

                // ====================================================================
                // SECTION 6: UploadBrandThemeFaviconAsync – POST .../favicon → 201 Created
                // ====================================================================

                #region UploadBrandThemeFaviconAsync – upload a PNG favicon, verify CDN URL returned

                await using var faviconStream = PngStream();
                var faviconUpload = await _themesApi.UploadBrandThemeFaviconAsync(brandId, themeId, faviconStream);

                faviconUpload.Should().NotBeNull();
                faviconUpload.Url.Should().NotBeNullOrEmpty(
                    "a successful favicon upload must return a CDN URL for the new favicon");

                // The read-only ThemeResponse.Favicon field must reflect the CDN URL after upload
                var afterFaviconUpload = await _themesApi.GetBrandThemeAsync(brandId, themeId);
                afterFaviconUpload.Favicon.Should().NotBeNullOrEmpty(
                    "ThemeResponse.Favicon must be populated after a successful favicon upload");

                #endregion

                // ====================================================================
                // SECTION 7: DeleteBrandThemeFaviconAsync – DELETE .../favicon → 204 No Content
                // ====================================================================

                #region DeleteBrandThemeFaviconAsync – delete the uploaded favicon

                await _themesApi.DeleteBrandThemeFaviconAsync(brandId, themeId);

                // Theme still accessible after favicon is deleted
                var afterFaviconDelete = await _themesApi.GetBrandThemeAsync(brandId, themeId);
                afterFaviconDelete.Id.Should().Be(themeId);

                #endregion

                // ====================================================================
                // SECTION 8: UploadBrandThemeBackgroundImageAsync – POST .../background-image → 201 Created
                // ====================================================================

                #region UploadBrandThemeBackgroundImageAsync – upload a PNG background image

                await using var bgStream = PngStream();
                var bgUpload = await _themesApi.UploadBrandThemeBackgroundImageAsync(brandId, themeId, bgStream);

                bgUpload.Should().NotBeNull();
                bgUpload.Url.Should().NotBeNullOrEmpty(
                    "a successful background-image upload must return a CDN URL");

                // The read-only ThemeResponse.BackgroundImage field must reflect the CDN URL after upload
                var afterBgUpload = await _themesApi.GetBrandThemeAsync(brandId, themeId);
                afterBgUpload.BackgroundImage.Should().NotBeNullOrEmpty(
                    "ThemeResponse.BackgroundImage must be populated after a successful background-image upload");

                #endregion

                // ====================================================================
                // SECTION 8a: BACKGROUND_IMAGE touchpoint variants
                // SignInPageTouchPointVariant.BACKGROUNDIMAGE and ErrorPageTouchPointVariant.BACKGROUNDIMAGE
                // require an uploaded background image and are tested here before deletion.
                // ====================================================================

                #region BACKGROUNDIMAGE variants – tested while background image is available

                var bgImageVariants = await _themesApi.ReplaceBrandThemeAsync(brandId, themeId,
                    new UpdateThemeRequest
                    {
                        PrimaryColorHex = "#1662dd",
                        SecondaryColorHex = "#ebebed",
                        SignInPageTouchPointVariant = SignInPageTouchPointVariant.BACKGROUNDIMAGE,
                        EndUserDashboardTouchPointVariant = EndUserDashboardTouchPointVariant.OKTADEFAULT,
                        ErrorPageTouchPointVariant = ErrorPageTouchPointVariant.BACKGROUNDIMAGE,
                        EmailTemplateTouchPointVariant = EmailTemplateTouchPointVariant.OKTADEFAULT,
                        LoadingPageTouchPointVariant = LoadingPageTouchPointVariant.OKTADEFAULT,
                    });
                bgImageVariants.SignInPageTouchPointVariant.Should().Be(SignInPageTouchPointVariant.BACKGROUNDIMAGE);
                bgImageVariants.ErrorPageTouchPointVariant.Should().Be(ErrorPageTouchPointVariant.BACKGROUNDIMAGE);

                // Verify persistence via GET
                var verifyBgImageVariants = await _themesApi.GetBrandThemeAsync(brandId, themeId);
                verifyBgImageVariants.SignInPageTouchPointVariant.Should().Be(SignInPageTouchPointVariant.BACKGROUNDIMAGE);
                verifyBgImageVariants.ErrorPageTouchPointVariant.Should().Be(ErrorPageTouchPointVariant.BACKGROUNDIMAGE);

                // Restore to OKTA_DEFAULT before background image deletion
                await _themesApi.ReplaceBrandThemeAsync(brandId, themeId, DefaultThemeRequest());

                #endregion

                // ====================================================================
                // SECTION 9: DeleteBrandThemeBackgroundImageAsync – DELETE .../background-image → 204 No Content
                // ====================================================================

                #region DeleteBrandThemeBackgroundImageAsync – delete the background image

                await _themesApi.DeleteBrandThemeBackgroundImageAsync(brandId, themeId);

                // BackgroundImage field should be null again after deletion
                var afterBgDelete = await _themesApi.GetBrandThemeAsync(brandId, themeId);
                afterBgDelete.BackgroundImage.Should().BeNull(
                    "the backgroundImage field must be null after the background image is deleted");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 1: GetBrandThemeAsync with invalid themeId → 404
                // ====================================================================

                #region GetBrandThemeAsync – invalid themeId returns 404

                Func<Task> getNonExistentTheme = async () =>
                    await _themesApi.GetBrandThemeAsync(brandId, "invalid-theme-id-does-not-exist");

                await getNonExistentTheme.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "retrieving a theme with an invalid ID must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 2: ReplaceBrandThemeAsync with invalid themeId → 404
                // ====================================================================

                #region ReplaceBrandThemeAsync – invalid themeId returns 404

                Func<Task> replaceNonExistentTheme = async () =>
                    await _themesApi.ReplaceBrandThemeAsync(
                        brandId, "invalid-theme-id-does-not-exist", DefaultThemeRequest());

                await replaceNonExistentTheme.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "replacing a theme with an invalid ID must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 3: DeleteBrandThemeLogoAsync with invalid brandId → 404
                // ====================================================================

                #region DeleteBrandThemeLogoAsync – invalid brandId returns 404

                Func<Task> deleteLogoInvalidBrand = async () =>
                    await _themesApi.DeleteBrandThemeLogoAsync("invalid-brand-id-does-not-exist", themeId);

                await deleteLogoInvalidBrand.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "deleting a logo for a non-existent brand must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 4: UploadBrandThemeLogoAsync with invalid themeId → 404
                // ====================================================================

                #region UploadBrandThemeLogoAsync – invalid themeId returns 404

                Func<Task> uploadLogoInvalidTheme = async () =>
                    await _themesApi.UploadBrandThemeLogoAsync(
                        brandId, "invalid-theme-id-does-not-exist", PngStream());

                await uploadLogoInvalidTheme.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "uploading a logo to a non-existent theme must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 5: DeleteBrandThemeFaviconAsync with invalid themeId → 404
                // ====================================================================

                #region DeleteBrandThemeFaviconAsync – invalid themeId returns 404

                Func<Task> deleteFaviconInvalidTheme = async () =>
                    await _themesApi.DeleteBrandThemeFaviconAsync(brandId, "invalid-theme-id-does-not-exist");

                await deleteFaviconInvalidTheme.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "deleting a favicon for a non-existent theme must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 6: DeleteBrandThemeBackgroundImageAsync with invalid themeId → 404
                // ====================================================================

                #region DeleteBrandThemeBackgroundImageAsync – invalid themeId returns 404

                Func<Task> deleteBgInvalidTheme = async () =>
                    await _themesApi.DeleteBrandThemeBackgroundImageAsync(brandId, "invalid-theme-id-does-not-exist");

                await deleteBgInvalidTheme.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "deleting a background image for a non-existent theme must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 7: ListBrandThemes with invalid brandId → 404
                // ====================================================================

                #region ListBrandThemes – invalid brandId returns 404

                Func<Task> listInvalidBrand = async () =>
                    await _themesApi.ListBrandThemes("invalid-brand-id-does-not-exist").ToListAsync();

                await listInvalidBrand.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "listing themes for a non-existent brand must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 8: GetBrandThemeAsync with invalid brandId → 404
                // ====================================================================

                #region GetBrandThemeAsync – invalid brandId returns 404

                Func<Task> getInvalidBrand = async () =>
                    await _themesApi.GetBrandThemeAsync("invalid-brand-id-does-not-exist", themeId);

                await getInvalidBrand.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "retrieving a theme for a non-existent brand must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 9: ReplaceBrandThemeAsync with invalid brandId → 404
                // ====================================================================

                #region ReplaceBrandThemeAsync – invalid brandId returns 404

                Func<Task> replaceInvalidBrand = async () =>
                    await _themesApi.ReplaceBrandThemeAsync(
                        "invalid-brand-id-does-not-exist", themeId, DefaultThemeRequest());

                await replaceInvalidBrand.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "replacing a theme for a non-existent brand must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 10: UploadBrandThemeLogoAsync with invalid brandId → 404
                // ====================================================================

                #region UploadBrandThemeLogoAsync – invalid brandId returns 404

                Func<Task> uploadLogoInvalidBrand = async () =>
                    await _themesApi.UploadBrandThemeLogoAsync(
                        "invalid-brand-id-does-not-exist", themeId, PngStream());

                await uploadLogoInvalidBrand.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "uploading a logo to a non-existent brand must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 11: UploadBrandThemeFaviconAsync with invalid brandId → 404
                // ====================================================================

                #region UploadBrandThemeFaviconAsync – invalid brandId returns 404

                Func<Task> uploadFaviconInvalidBrand = async () =>
                    await _themesApi.UploadBrandThemeFaviconAsync(
                        "invalid-brand-id-does-not-exist", themeId, PngStream());

                await uploadFaviconInvalidBrand.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "uploading a favicon to a non-existent brand must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 12: UploadBrandThemeBackgroundImageAsync with invalid brandId → 404
                // ====================================================================

                #region UploadBrandThemeBackgroundImageAsync – invalid brandId returns 404

                Func<Task> uploadBgInvalidBrand = async () =>
                    await _themesApi.UploadBrandThemeBackgroundImageAsync(
                        "invalid-brand-id-does-not-exist", themeId, PngStream());

                await uploadBgInvalidBrand.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "uploading a background image to a non-existent brand must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 13: DeleteBrandThemeFaviconAsync with invalid brandId → 404
                // ====================================================================

                #region DeleteBrandThemeFaviconAsync – invalid brandId returns 404

                Func<Task> deleteFaviconInvalidBrand = async () =>
                    await _themesApi.DeleteBrandThemeFaviconAsync("invalid-brand-id-does-not-exist", themeId);

                await deleteFaviconInvalidBrand.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "deleting a favicon for a non-existent brand must return 404 Not Found");

                #endregion

                // ====================================================================
                // NEGATIVE SCENARIO 14: DeleteBrandThemeBackgroundImageAsync with invalid brandId → 404
                // ====================================================================

                #region DeleteBrandThemeBackgroundImageAsync – invalid brandId returns 404

                Func<Task> deleteBgInvalidBrand = async () =>
                    await _themesApi.DeleteBrandThemeBackgroundImageAsync("invalid-brand-id-does-not-exist", themeId);

                await deleteBgInvalidBrand.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404,
                        "deleting a background image for a non-existent brand must return 404 Not Found");

                #endregion
            }
            finally
            {
                // ====================================================================
                // TEARDOWN: Restore the theme to its original state unconditionally.
                // Each asset deletion is best-effort (no-op if already deleted in the test body).
                // ====================================================================
                try { await _themesApi.ReplaceBrandThemeAsync(brandId, themeId, restoreRequest); } catch { }
                try { await _themesApi.DeleteBrandThemeLogoAsync(brandId, themeId); } catch { }
                try { await _themesApi.DeleteBrandThemeFaviconAsync(brandId, themeId); } catch { }
                try { await _themesApi.DeleteBrandThemeBackgroundImageAsync(brandId, themeId); } catch { }
            }
        }

        /// <summary>
        /// Verifies that all 9 WithHttpInfo method variants return the correct HTTP status codes.
        /// These variants expose the raw <see cref="ApiResponse{T}"/> so callers can inspect
        /// HTTP status codes and response headers directly.
        ///
        /// Method → Expected HTTP status code
        ///   ListBrandThemesWithHttpInfoAsync                   → 200 OK  (Data is populated – bare JSON array)
        ///   GetBrandThemeWithHttpInfoAsync                     → 200 OK
        ///   ReplaceBrandThemeWithHttpInfoAsync                 → 200 OK
        ///   UploadBrandThemeLogoWithHttpInfoAsync              → 201 Created
        ///   DeleteBrandThemeLogoWithHttpInfoAsync              → 204 No Content
        ///   UploadBrandThemeFaviconWithHttpInfoAsync           → 201 Created
        ///   DeleteBrandThemeFaviconWithHttpInfoAsync           → 204 No Content
        ///   UploadBrandThemeBackgroundImageWithHttpInfoAsync   → 201 Created
        ///   DeleteBrandThemeBackgroundImageWithHttpInfoAsync   → 204 No Content
        /// </summary>
        [Fact]
        public async Task GivenThemesApi_WhenUsingWithHttpInfoVariants_ThenHttpStatusCodesAreCorrect()
        {
            var brands = await _brandsApi.ListBrands().ToListAsync();
            var defaultBrand = brands.FirstOrDefault(b => b.IsDefault);
            defaultBrand.Should().NotBeNull("the org must have a default brand");
            var brandId = defaultBrand!.Id;

            var themes = await _themesApi.ListBrandThemes(brandId).ToListAsync();
            themes.Should().NotBeNullOrEmpty();
            var themeId = themes[0].Id;

            // Snapshot original theme for restoration
            var originalTheme = await _themesApi.GetBrandThemeAsync(brandId, themeId);
            var restoreRequest = RestoreRequestFrom(originalTheme);

            try
            {
                // ── ListBrandThemesWithHttpInfoAsync → 200 OK ────────────────────────────
                // The themes endpoint returns a bare JSON array (unlike the domains endpoint
                // which wraps in {"domains":[...]}), so ApiResponse<List<ThemeResponse>>.Data
                // IS correctly populated here.
                var listResponse = await _themesApi.ListBrandThemesWithHttpInfoAsync(brandId);
                listResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                listResponse.Data.Should().NotBeNullOrEmpty(
                    "the themes list endpoint returns a bare JSON array, so Data must be populated");

                // ── GetBrandThemeWithHttpInfoAsync → 200 OK ──────────────────────────────
                var getResponse = await _themesApi.GetBrandThemeWithHttpInfoAsync(brandId, themeId);
                getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                getResponse.Data.Should().NotBeNull();
                getResponse.Data.Id.Should().Be(themeId);

                // ── ReplaceBrandThemeWithHttpInfoAsync → 200 OK ──────────────────────────
                var putResponse = await _themesApi.ReplaceBrandThemeWithHttpInfoAsync(
                    brandId, themeId, DefaultThemeRequest());
                putResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                putResponse.Data.Should().NotBeNull();
                putResponse.Data.Id.Should().Be(themeId);

                // ── UploadBrandThemeLogoWithHttpInfoAsync → 201 Created ──────────────────
                // Note: the logo upload returns 201 (confirmed via live API).
                await using var logoStream = PngStream();
                var logoResponse = await _themesApi.UploadBrandThemeLogoWithHttpInfoAsync(
                    brandId, themeId, logoStream);
                logoResponse.StatusCode.Should().Be(HttpStatusCode.Created);
                logoResponse.Data.Should().NotBeNull();
                logoResponse.Data.Url.Should().NotBeNullOrEmpty();

                // ── DeleteBrandThemeLogoWithHttpInfoAsync → 204 No Content ───────────────
                var deleteLogoResponse = await _themesApi.DeleteBrandThemeLogoWithHttpInfoAsync(brandId, themeId);
                deleteLogoResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

                // ── UploadBrandThemeFaviconWithHttpInfoAsync → 201 Created ───────────────
                await using var faviconStream = PngStream();
                var faviconResponse = await _themesApi.UploadBrandThemeFaviconWithHttpInfoAsync(
                    brandId, themeId, faviconStream);
                faviconResponse.StatusCode.Should().Be(HttpStatusCode.Created);
                faviconResponse.Data.Should().NotBeNull();
                faviconResponse.Data.Url.Should().NotBeNullOrEmpty();

                // ── DeleteBrandThemeFaviconWithHttpInfoAsync → 204 No Content ─────────────
                var deleteFaviconResponse = await _themesApi.DeleteBrandThemeFaviconWithHttpInfoAsync(
                    brandId, themeId);
                deleteFaviconResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

                // ── UploadBrandThemeBackgroundImageWithHttpInfoAsync → 201 Created ────────
                await using var bgStream = PngStream();
                var bgResponse = await _themesApi.UploadBrandThemeBackgroundImageWithHttpInfoAsync(
                    brandId, themeId, bgStream);
                bgResponse.StatusCode.Should().Be(HttpStatusCode.Created);
                bgResponse.Data.Should().NotBeNull();
                bgResponse.Data.Url.Should().NotBeNullOrEmpty();

                // ── DeleteBrandThemeBackgroundImageWithHttpInfoAsync → 204 No Content ─────
                var deleteBgResponse = await _themesApi.DeleteBrandThemeBackgroundImageWithHttpInfoAsync(
                    brandId, themeId);
                deleteBgResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
            finally
            {
                try { await _themesApi.ReplaceBrandThemeAsync(brandId, themeId, restoreRequest); } catch { }
                try { await _themesApi.DeleteBrandThemeLogoAsync(brandId, themeId); } catch { }
                try { await _themesApi.DeleteBrandThemeFaviconAsync(brandId, themeId); } catch { }
                try { await _themesApi.DeleteBrandThemeBackgroundImageAsync(brandId, themeId); } catch { }
            }
        }
    }
}
