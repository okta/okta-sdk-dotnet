// <copyright file="CustomTemplatesApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for CustomTemplatesApi covering all 14 unique operations (28 methods incl. WithHttpInfo variants).
    ///
    /// CustomTemplatesApi → Endpoint Mapping
    /// ─────────────────────────────────────────────────────────────────────────────────────────────
    /// ListEmailTemplates                  GET    /api/v1/brands/{brandId}/templates/email
    /// GetEmailTemplateAsync               GET    /api/v1/brands/{brandId}/templates/email/{templateName}
    /// GetEmailDefaultContentAsync         GET    /api/v1/brands/{brandId}/templates/email/{templateName}/default-content
    /// GetEmailDefaultPreviewAsync         GET    /api/v1/brands/{brandId}/templates/email/{templateName}/default-content/preview
    /// GetEmailSettingsAsync               GET    /api/v1/brands/{brandId}/templates/email/{templateName}/settings
    /// ReplaceEmailSettingsAsync           PUT    /api/v1/brands/{brandId}/templates/email/{templateName}/settings
    /// SendTestEmailAsync                  POST   /api/v1/brands/{brandId}/templates/email/{templateName}/test
    /// CreateEmailCustomizationAsync       POST   /api/v1/brands/{brandId}/templates/email/{templateName}/customizations
    /// ListEmailCustomizations             GET    /api/v1/brands/{brandId}/templates/email/{templateName}/customizations
    /// GetEmailCustomizationAsync          GET    /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{id}
    /// GetCustomizationPreviewAsync        GET    /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{id}/preview
    /// ReplaceEmailCustomizationAsync      PUT    /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{id}
    /// DeleteEmailCustomizationAsync       DELETE /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{id}
    /// DeleteAllCustomizationsAsync        DELETE /api/v1/brands/{brandId}/templates/email/{templateName}/customizations
    ///
    /// Key constraints discovered via curl validation:
    /// - brandId is discovered at runtime via BrandsApi.ListBrands() — no hardcoded IDs.
    /// - The "UserActivation" template is well-known and always present. All customization tests use it.
    /// - CreateEmailCustomization returns HTTP 201 (not 200).
    /// - The body of a UserActivation customization MUST contain ${activationLink} or ${activationToken};
    ///   otherwise the API returns 400 E0000001 "Invalid email text".
    /// - SendTestEmail returns HTTP 204 (empty body).
    /// - DeleteEmailCustomization with a non-existent ID returns HTTP 204 (idempotent — not 404).
    /// - DeleteAllCustomizations when there are no customizations returns HTTP 204 (idempotent).
    /// - GetEmailCustomization, ReplaceEmailCustomization, and GetCustomizationPreview with an invalid
    ///   customizationId return HTTP 404 E0000007.
    /// - GetEmailTemplate with an invalid templateName returns HTTP 404 E0000007.
    /// - Creating a customization for a language that already exists returns HTTP 409 E0000183.
    /// - The FIRST customization created for a brand+template is auto-promoted to isDefault=true
    ///   regardless of the isDefault value in the request body.
    /// - The DEFAULT customization cannot be deleted individually (E0000184); use DeleteAllCustomizations.
    /// - The DEFAULT customization cannot be replaced with isDefault=false (E0000185).
    /// - ListEmailTemplates and ListEmailCustomizations return IOktaCollectionClient&lt;T&gt;
    ///   (enumerable via ToListAsync()); their WithHttpInfo variants return ApiResponse&lt;List&lt;T&gt;&gt;.
    /// - GetEmailTemplate and ListEmailTemplates accept expand=["settings","customizationCount"] which
    ///   populates Embedded.Settings and Embedded.CustomizationCount.
    /// - GetEmailDefaultContent and GetEmailDefaultPreview accept an optional language param (e.g. "de")
    ///   which returns the translated version of the default content/preview.
    /// - ReplaceEmailSettings returns EmailSettings (not EmailSettingsResponse).
    ///   Recipients enum values: ALLUSERS ("ALL_USERS"), ADMINSONLY ("ADMINS_ONLY"), NOUSERS ("NO_USERS").
    ///
    /// Teardown:
    ///   - Non-default customizations (cust2, cust4) are deleted individually.
    ///   - DeleteAllCustomizationsAsync is called as a catch-all to clean up default customizations
    ///     (cust1, cust3) and any other leftovers regardless of where the test fails.
    ///   - Email settings are restored to ALL_USERS if they were changed.
    /// </summary>
    public class CustomTemplatesApiTests
    {
        private readonly CustomTemplatesApi _templatesApi = new();
        private readonly BrandsApi _brandsApi = new();

        // Well-known template present in every Okta org; body requires ${activationLink}.
        private const string TemplateName = "UserActivation";

        // Minimal valid body for UserActivation customizations (must include ${activationLink}).
        private static string CustomizationBody(string lang) =>
            $"<!DOCTYPE html><html><body><p>${{user.profile.firstName}}, " +
            $"<a href=\"${{activationLink}}\">Activate ({lang})</a></p></body></html>";

        [Fact]
        public async Task GivenCustomTemplatesApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            // EmailSettingsResponse.RecipientsEnum (from GET) and EmailSettings.RecipientsEnum (for PUT)
            // are distinct generated types with the same underlying string values.  This local helper
            // converts between them so we can restore the original recipients setting after the test.
            static EmailSettings.RecipientsEnum ToSettingsEnum(EmailSettingsResponse.RecipientsEnum r) =>
                r == EmailSettingsResponse.RecipientsEnum.ADMINSONLY ? EmailSettings.RecipientsEnum.ADMINSONLY :
                r == EmailSettingsResponse.RecipientsEnum.NOUSERS    ? EmailSettings.RecipientsEnum.NOUSERS    :
                                                                        EmailSettings.RecipientsEnum.ALLUSERS;

            // ── Customization lifecycle constraints discovered via curl validation ───────────
            // • The FIRST customization created for a brand+template is ALWAYS auto-promoted to
            //   isDefault=true regardless of the isDefault value in the request body.
            // • The DEFAULT customization cannot be deleted individually (E0000184).
            //   Use DeleteAllCustomizations to remove it.
            // • The DEFAULT customization cannot be replaced with isDefault=false (E0000185).
            //   Pass isDefault=true in the replace body when targeting the default customization.
            // • Non-default customizations can be deleted individually (returns 204).
            //
            // Test strategy:
            //   Primary section  : cust1 (es, auto-default) + cust2 (de, non-default)
            //                      → Delete cust2 individually; DeleteAll cleans cust1.
            //   WithHttpInfo sect: cust3 (fr, auto-default) + cust4 (it, non-default)
            //                      → Delete cust4 individually; DeleteAll cleans cust3.
            // ─────────────────────────────────────────────────────────────────────────────────

            string brandId = null;
            string cust1Id = null; // es – primary default   (cleaned by DeleteAllCustomizations)
            string cust2Id = null; // de – primary non-default (cleaned by DeleteEmailCustomization)
            string cust3Id = null; // fr – WithHttpInfo default (cleaned by DeleteAllWithHttpInfo)
            string cust4Id = null; // it – WithHttpInfo non-default (cleaned by DeleteEmailCustomizationWithHttpInfo)
            bool settingsAltered = false;

            try
            {
                // ====================================================================
                // SETUP: discover the default brand ID at runtime (no hardcoded IDs)
                // ====================================================================

                #region Setup – discover default brand

                var allBrands = await _brandsApi.ListBrands().ToListAsync();
                allBrands.Should().NotBeEmpty("the org must have at least one brand");

                var defaultBrand = allBrands.First(b => b.IsDefault == true);
                brandId = defaultBrand.Id;
                brandId.Should().NotBeNullOrEmpty();

                #endregion

                // ====================================================================
                // SECTION 1: ListEmailTemplates – GET /api/v1/brands/{brandId}/templates/email → 200
                // ====================================================================

                #region ListEmailTemplates – IOktaCollectionClient, UserActivation must be present

                var templates = await _templatesApi.ListEmailTemplates(brandId).ToListAsync();

                templates.Should().NotBeNull();
                templates.Should().NotBeEmpty("every Okta org must have at least one email template");
                templates.Should().Contain(t => t.Name == TemplateName,
                    $"the '{TemplateName}' template must exist in every org");

                var userActivationTemplate = templates.First(t => t.Name == TemplateName);
                userActivationTemplate.Links.Should().NotBeNull();

                // Also exercise the optional expand parameter on the collection endpoint.
                var templatesWithExpand = await _templatesApi
                    .ListEmailTemplates(brandId, expand: new List<string> { "settings", "customizationCount" })
                    .ToListAsync();

                var uaExpanded = templatesWithExpand.First(t => t.Name == TemplateName);
                uaExpanded.Embedded.Should().NotBeNull(
                    "expand was requested on ListEmailTemplates; Embedded must be populated");
                uaExpanded.Embedded.Settings.Should().NotBeNull(
                    "expand=settings must populate Embedded.Settings on each listed template");

                #endregion

                // ====================================================================
                // SECTION 2: GetEmailTemplateAsync – GET /templates/email/{templateName} → 200
                // ====================================================================

                #region GetEmailTemplateAsync – basic (no expand)

                var template = await _templatesApi.GetEmailTemplateAsync(brandId, TemplateName);

                template.Should().NotBeNull();
                template.Name.Should().Be(TemplateName);
                template.Links.Should().NotBeNull();
                template.Embedded.Should().BeNull("Embedded is only populated when expand is requested");

                #endregion

                #region GetEmailTemplateAsync – with expand=settings,customizationCount

                var expandedTemplate = await _templatesApi.GetEmailTemplateAsync(
                    brandId, TemplateName,
                    new List<string> { "settings", "customizationCount" });

                expandedTemplate.Should().NotBeNull();
                expandedTemplate.Name.Should().Be(TemplateName);
                expandedTemplate.Embedded.Should().NotBeNull(
                    "expand was requested; Embedded must be populated");
                expandedTemplate.Embedded.Settings.Should().NotBeNull(
                    "expand=settings must populate Embedded.Settings");
                expandedTemplate.Embedded.Settings.Recipients.Should().NotBeNull(
                    "Settings.Recipients must be present");

                #endregion

                // ====================================================================
                // SECTION 3: GetEmailDefaultContentAsync – GET /{templateName}/default-content → 200
                // ====================================================================

                #region GetEmailDefaultContentAsync – validates default template content shape

                var defaultContent = await _templatesApi.GetEmailDefaultContentAsync(brandId, TemplateName);

                defaultContent.Should().NotBeNull();
                defaultContent.Subject.Should().NotBeNullOrEmpty(
                    "every email template must have a default subject");
                defaultContent.Body.Should().NotBeNullOrEmpty(
                    "every email template must have a default body");
                defaultContent.Links.Should().NotBeNull();

                #endregion

                #region GetEmailDefaultContentAsync – with language param (German)

                var defaultContentDe = await _templatesApi.GetEmailDefaultContentAsync(
                    brandId, TemplateName, "de");

                defaultContentDe.Should().NotBeNull();
                defaultContentDe.Subject.Should().NotBeNullOrEmpty();
                defaultContentDe.Body.Should().NotBeNullOrEmpty();

                #endregion

                // ====================================================================
                // SECTION 4: GetEmailDefaultPreviewAsync – GET /{templateName}/default-content/preview → 200
                // ====================================================================

                #region GetEmailDefaultPreviewAsync – rendered preview with user context

                var defaultPreview = await _templatesApi.GetEmailDefaultPreviewAsync(brandId, TemplateName);

                defaultPreview.Should().NotBeNull();
                defaultPreview.Subject.Should().NotBeNullOrEmpty(
                    "the default preview must always render a subject");
                defaultPreview.Body.Should().NotBeNullOrEmpty(
                    "the default preview must always render a body");
                defaultPreview.Links.Should().NotBeNull();

                #endregion

                #region GetEmailDefaultPreviewAsync – with language param (German)

                // Exercise the optional language parameter (mirrors the GetEmailDefaultContent language test).
                var defaultPreviewDe = await _templatesApi.GetEmailDefaultPreviewAsync(
                    brandId, TemplateName, "de");

                defaultPreviewDe.Should().NotBeNull();
                defaultPreviewDe.Subject.Should().NotBeNullOrEmpty(
                    "language=de preview must return a non-empty subject");
                defaultPreviewDe.Body.Should().NotBeNullOrEmpty(
                    "language=de preview must return a non-empty body");

                #endregion

                // ====================================================================
                // SECTION 5: GetEmailSettingsAsync – GET /{templateName}/settings → 200
                // ====================================================================

                #region GetEmailSettingsAsync – validates settings response shape

                var settings = await _templatesApi.GetEmailSettingsAsync(brandId, TemplateName);

                settings.Should().NotBeNull();
                settings.Recipients.Should().NotBeNull(
                    "every email template must have a recipients setting");
                settings.Links.Should().NotBeNull();

                // Capture original value to restore in teardown
                var originalRecipients = settings.Recipients;

                #endregion

                // ====================================================================
                // SECTION 6: ReplaceEmailSettingsAsync – PUT /{templateName}/settings → 200
                // ====================================================================

                #region ReplaceEmailSettingsAsync – change recipients to ADMINS_ONLY then restore

                settingsAltered = true;

                var updatedSettings = await _templatesApi.ReplaceEmailSettingsAsync(
                    brandId, TemplateName,
                    new EmailSettings { Recipients = EmailSettings.RecipientsEnum.ADMINSONLY });

                updatedSettings.Should().NotBeNull();
                updatedSettings.Recipients.Should().Be(EmailSettings.RecipientsEnum.ADMINSONLY,
                    "ReplaceEmailSettings must persist the updated recipients value");

                // Restore to original value (convert between the two distinct generated enum types)
                var restoredSettings = await _templatesApi.ReplaceEmailSettingsAsync(
                    brandId, TemplateName,
                    new EmailSettings { Recipients = ToSettingsEnum(originalRecipients) });

                // Both enum types encode the same underlying string value; compare via ToString()
                // to avoid a FluentAssertions type-mismatch failure.
                restoredSettings.Recipients.ToString().Should().Be(originalRecipients.ToString(),
                    "recipients must be restored to the original value");

                settingsAltered = false;

                #endregion

                // ====================================================================
                // SECTION 7: SendTestEmailAsync – POST /{templateName}/test → 204
                // ====================================================================

                #region SendTestEmailAsync – no exception means 204 (void return)

                // SendTestEmail has no return value; a successful call returns HTTP 204.
                // An ApiException would be thrown for any non-2xx response.
                await _templatesApi.SendTestEmailAsync(brandId, TemplateName, "en");
                // No assertion needed — reaching here confirms HTTP 204 was returned.

                #endregion

                // ====================================================================
                // SECTION 8: CreateEmailCustomizationAsync – POST /{templateName}/customizations → 201
                // ====================================================================

                #region CreateEmailCustomizationAsync – Spanish (es) → cust1, auto-promoted default

                var createdCust1 = await _templatesApi.CreateEmailCustomizationAsync(
                    brandId, TemplateName,
                    new EmailCustomization
                    {
                        Language  = "es",
                        IsDefault = false,    // API auto-promotes first customization to default
                        Subject   = "Bienvenido a ${org.name}!",
                        Body      = CustomizationBody("es")
                    });

                createdCust1.Should().NotBeNull();
                createdCust1.Id.Should().NotBeNullOrEmpty("created customization must have an ID");
                createdCust1.Language.Should().Be("es");
                // isDefault will be true even though we passed false — first customization is always
                // auto-promoted to default. Do not assert a specific boolean value.
                createdCust1.Subject.Should().Be("Bienvenido a ${org.name}!");
                createdCust1.Body.Should().Contain("${activationLink}");
                createdCust1.Created.Should().NotBe(default);
                createdCust1.LastUpdated.Should().NotBe(default);
                createdCust1.Links.Should().NotBeNull();

                cust1Id = createdCust1.Id;

                #endregion

                #region CreateEmailCustomizationAsync – German (de) → cust2, non-default

                var createdCust2 = await _templatesApi.CreateEmailCustomizationAsync(
                    brandId, TemplateName,
                    new EmailCustomization
                    {
                        Language  = "de",
                        IsDefault = false,    // cust1 (es) is already the default; cust2 stays false
                        Subject   = "Willkommen bei ${org.name}!",
                        Body      = CustomizationBody("de")
                    });

                createdCust2.Should().NotBeNull();
                createdCust2.Id.Should().NotBeNullOrEmpty();
                createdCust2.Language.Should().Be("de");
                createdCust2.IsDefault.Should().BeFalse(
                    "cust2 (de) is the second customization; cust1 (es) is already the default");
                createdCust2.Subject.Should().Be("Willkommen bei ${org.name}!");

                cust2Id = createdCust2.Id;

                #endregion

                #region Negative (inline): CreateEmailCustomizationAsync – duplicate language → 409 E0000183

                // cust1 (es) is already live; creating a second customization for "es" must fail.
                // Curl-verified: returns 409 E0000183 "An email template customization for that
                // language already exists."  No new object is persisted, so no teardown needed.
                var exDuplicate = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _templatesApi.CreateEmailCustomizationAsync(
                        brandId, TemplateName,
                        new EmailCustomization
                        {
                            Language  = "es",
                            IsDefault = false,
                            Subject   = "Duplicate es",
                            Body      = CustomizationBody("es")
                        }));
                exDuplicate.ErrorCode.Should().Be(409,
                    "creating a second customization for the same language must return 409 E0000183");

                #endregion

                // ====================================================================
                // SECTION 9: ListEmailCustomizations – GET /{templateName}/customizations → 200
                // ====================================================================

                #region ListEmailCustomizations – both cust1 and cust2 must appear

                var customizations = await _templatesApi
                    .ListEmailCustomizations(brandId, TemplateName)
                    .ToListAsync();

                customizations.Should().NotBeNull();
                customizations.Should().Contain(c => c.Id == cust1Id,
                    "the Spanish (default) customization must appear in the list");
                customizations.Should().Contain(c => c.Id == cust2Id,
                    "the German (non-default) customization must appear in the list");

                #endregion

                // ====================================================================
                // SECTION 10: GetEmailCustomizationAsync – GET /{templateName}/customizations/{id} → 200
                // ====================================================================

                #region GetEmailCustomizationAsync – retrieves cust1 by ID

                var retrievedCust1 = await _templatesApi.GetEmailCustomizationAsync(
                    brandId, TemplateName, cust1Id);

                retrievedCust1.Should().NotBeNull();
                retrievedCust1.Id.Should().Be(cust1Id);
                retrievedCust1.Language.Should().Be("es");
                retrievedCust1.Subject.Should().Be("Bienvenido a ${org.name}!");

                #endregion

                // ====================================================================
                // SECTION 11: GetCustomizationPreviewAsync – GET /customizations/{id}/preview → 200
                // ====================================================================

                #region GetCustomizationPreviewAsync – rendered preview for cust1

                var custPreview = await _templatesApi.GetCustomizationPreviewAsync(
                    brandId, TemplateName, cust1Id);

                custPreview.Should().NotBeNull();
                custPreview.Subject.Should().NotBeNullOrEmpty(
                    "preview must render the subject with variables expanded");
                custPreview.Body.Should().NotBeNullOrEmpty(
                    "preview must render the body with variables expanded");
                custPreview.Links.Should().NotBeNull();

                #endregion

                // ====================================================================
                // SECTION 12: ReplaceEmailCustomizationAsync – PUT /customizations/{id} → 200
                // ====================================================================

                #region ReplaceEmailCustomizationAsync – update subject of cust2 (non-default)

                // cust2 is non-default (IsDefault=false) → no E0000185 risk; straightforward replace.
                var replacedCust2 = await _templatesApi.ReplaceEmailCustomizationAsync(
                    brandId, TemplateName, cust2Id,
                    new EmailCustomization
                    {
                        Language  = "de",
                        IsDefault = false,
                        Subject   = "Willkommen bei ${org.name} - Aktualisiert!",
                        Body      = CustomizationBody("de")
                    });

                replacedCust2.Should().NotBeNull();
                replacedCust2.Id.Should().Be(cust2Id);
                replacedCust2.Language.Should().Be("de");
                replacedCust2.Subject.Should().Be("Willkommen bei ${org.name} - Aktualisiert!",
                    "ReplaceEmailCustomization must persist the updated subject");

                #endregion

                // ====================================================================
                // SECTION 13: DeleteEmailCustomizationAsync – DELETE /customizations/{id} → 204
                // ====================================================================

                #region DeleteEmailCustomizationAsync – deletes cust2 (non-default; API constraint:
                // the DEFAULT customization cannot be deleted individually → E0000184)

                await _templatesApi.DeleteEmailCustomizationAsync(brandId, TemplateName, cust2Id);
                cust2Id = null; // successfully deleted

                #endregion

                // ====================================================================
                // SECTION 14: DeleteAllCustomizationsAsync – DELETE /customizations → 204 (primary)
                // ====================================================================

                #region DeleteAllCustomizationsAsync – cleans up cust1 (the default) and any leftovers

                // cust1 (es, default) is still alive. DeleteAll removes all customizations including
                // the default, which cannot be removed individually.
                await _templatesApi.DeleteAllCustomizationsAsync(brandId, TemplateName);

                // Verify list is now empty
                var afterDeleteAll = await _templatesApi
                    .ListEmailCustomizations(brandId, TemplateName)
                    .ToListAsync();
                afterDeleteAll.Should().BeEmpty(
                    "DeleteAllCustomizations must remove all customizations including the default");
                cust1Id = null; // cleaned by DeleteAll

                #endregion

                // ====================================================================
                // SECTION 15: Negative scenarios (all curl-confirmed)
                // ====================================================================

                const string InvalidCustomizationId = "nonexistentcustomizationid";

                #region Negative: GetEmailCustomizationAsync("nonexistent") → 404 E0000007

                var exGet = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _templatesApi.GetEmailCustomizationAsync(
                        brandId, TemplateName, InvalidCustomizationId));
                exGet.ErrorCode.Should().Be(404,
                    "GET with a non-existent customizationId must return 404 E0000007");

                #endregion

                #region Negative: ReplaceEmailCustomizationAsync("nonexistent") → 404 E0000007

                var exReplace = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _templatesApi.ReplaceEmailCustomizationAsync(
                        brandId, TemplateName, InvalidCustomizationId,
                        new EmailCustomization
                        {
                            Language  = "es",
                            IsDefault = false,
                            Subject   = "test",
                            Body      = CustomizationBody("es")
                        }));
                exReplace.ErrorCode.Should().Be(404,
                    "PUT with a non-existent customizationId must return 404 E0000007");

                #endregion

                #region Negative: GetCustomizationPreviewAsync("nonexistent") → 404 E0000007

                var exPreview = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _templatesApi.GetCustomizationPreviewAsync(
                        brandId, TemplateName, InvalidCustomizationId));
                exPreview.ErrorCode.Should().Be(404,
                    "preview GET with a non-existent customizationId must return 404 E0000007");

                #endregion

                #region Negative: GetEmailTemplateAsync("NonExistentTemplate") → 404 E0000007

                var exTemplate = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _templatesApi.GetEmailTemplateAsync(brandId, "NonExistentTemplateName"));
                exTemplate.ErrorCode.Should().Be(404,
                    "GET with a non-existent templateName must return 404 E0000007");

                #endregion

                #region Negative: DeleteEmailCustomizationAsync("nonexistent") → 204 (idempotent!)

                // Confirmed via curl: DELETE with a non-existent customizationId returns 204 (not 404).
                // The API treats DELETE as idempotent — no exception should be thrown.
                await _templatesApi.DeleteEmailCustomizationAsync(
                    brandId, TemplateName, InvalidCustomizationId);
                // Reaching here confirms HTTP 204 was returned (no exception thrown).

                #endregion

                // ====================================================================
                // WithHttpInfo variants – all 14 operations via WithHttpInfo counterparts
                // ====================================================================

                #region ListEmailTemplatesWithHttpInfoAsync → 200 (with expand)

                // Exercise expand on the list endpoint via the WithHttpInfo variant.
                var listTemplatesInfo = await _templatesApi.ListEmailTemplatesWithHttpInfoAsync(
                    brandId, expand: new List<string> { "settings", "customizationCount" });

                listTemplatesInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                listTemplatesInfo.Data.Should().NotBeNull();
                listTemplatesInfo.Data.Should().NotBeEmpty();
                listTemplatesInfo.Data.Should().Contain(t => t.Name == TemplateName,
                    $"'{TemplateName}' must appear in the WithHttpInfo list result");
                listTemplatesInfo.Data.First(t => t.Name == TemplateName).Embedded.Should().NotBeNull(
                    "expand was requested; Embedded must be populated via WithHttpInfo list");
                listTemplatesInfo.Data.First(t => t.Name == TemplateName).Embedded.Settings.Should().NotBeNull(
                    "expand=settings must populate Embedded.Settings via WithHttpInfo list");

                #endregion

                #region GetEmailTemplateWithHttpInfoAsync → 200

                var getTemplateInfo = await _templatesApi.GetEmailTemplateWithHttpInfoAsync(
                    brandId, TemplateName,
                    new List<string> { "settings", "customizationCount" });

                getTemplateInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                getTemplateInfo.Data.Should().NotBeNull();
                getTemplateInfo.Data.Name.Should().Be(TemplateName);
                getTemplateInfo.Data.Embedded.Should().NotBeNull();
                getTemplateInfo.Data.Embedded.Settings.Should().NotBeNull();

                #endregion

                #region GetEmailDefaultContentWithHttpInfoAsync → 200

                var defaultContentInfo = await _templatesApi.GetEmailDefaultContentWithHttpInfoAsync(
                    brandId, TemplateName);

                defaultContentInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                defaultContentInfo.Data.Should().NotBeNull();
                defaultContentInfo.Data.Subject.Should().NotBeNullOrEmpty();
                defaultContentInfo.Data.Body.Should().NotBeNullOrEmpty();

                #endregion

                #region GetEmailDefaultPreviewWithHttpInfoAsync → 200 (with language param)

                // Exercise the optional language parameter on the WithHttpInfo variant.
                var defaultPreviewInfo = await _templatesApi.GetEmailDefaultPreviewWithHttpInfoAsync(
                    brandId, TemplateName, "de");

                defaultPreviewInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                defaultPreviewInfo.Data.Should().NotBeNull();
                defaultPreviewInfo.Data.Subject.Should().NotBeNullOrEmpty(
                    "language=de preview (WithHttpInfo) must return a non-empty subject");
                defaultPreviewInfo.Data.Body.Should().NotBeNullOrEmpty(
                    "language=de preview (WithHttpInfo) must return a non-empty body");

                #endregion

                #region GetEmailSettingsWithHttpInfoAsync → 200

                var getSettingsInfo = await _templatesApi.GetEmailSettingsWithHttpInfoAsync(
                    brandId, TemplateName);

                getSettingsInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                getSettingsInfo.Data.Should().NotBeNull();
                getSettingsInfo.Data.Recipients.Should().NotBeNull();
                getSettingsInfo.Data.Links.Should().NotBeNull();

                #endregion

                #region ReplaceEmailSettingsWithHttpInfoAsync → 200 (ADMINS_ONLY → restore to ALL_USERS)

                settingsAltered = true;

                var replaceSettingsInfo = await _templatesApi.ReplaceEmailSettingsWithHttpInfoAsync(
                    brandId, TemplateName,
                    new EmailSettings { Recipients = EmailSettings.RecipientsEnum.ADMINSONLY });

                replaceSettingsInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                replaceSettingsInfo.Data.Should().NotBeNull();
                replaceSettingsInfo.Data.Recipients.Should().Be(EmailSettings.RecipientsEnum.ADMINSONLY);

                // Restore settings
                var restoreSettingsInfo = await _templatesApi.ReplaceEmailSettingsWithHttpInfoAsync(
                    brandId, TemplateName,
                    new EmailSettings { Recipients = EmailSettings.RecipientsEnum.ALLUSERS });

                restoreSettingsInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                restoreSettingsInfo.Data.Recipients.Should().Be(EmailSettings.RecipientsEnum.ALLUSERS);

                settingsAltered = false;

                #endregion

                #region SendTestEmailWithHttpInfoAsync → 204 NoContent

                var sendTestInfo = await _templatesApi.SendTestEmailWithHttpInfoAsync(
                    brandId, TemplateName, "en");

                sendTestInfo.StatusCode.Should().Be(HttpStatusCode.NoContent,
                    "SendTestEmail must return HTTP 204 No Content");

                #endregion

                #region CreateEmailCustomizationWithHttpInfoAsync → 201 (French, auto-default + Italian, non-default)

                // At this point the list is empty (cleared by DeleteAllCustomizationsAsync above).
                // The first customization created (fr) will auto-promote to isDefault=true.
                var createCust3Info = await _templatesApi.CreateEmailCustomizationWithHttpInfoAsync(
                    brandId, TemplateName,
                    new EmailCustomization
                    {
                        Language  = "fr",
                        IsDefault = false,    // API auto-promotes first customization to default
                        Subject   = "Bienvenue dans ${org.name}!",
                        Body      = CustomizationBody("fr")
                    });

                createCust3Info.StatusCode.Should().Be(HttpStatusCode.Created,
                    "CreateEmailCustomization returns HTTP 201 Created");
                createCust3Info.Data.Should().NotBeNull();
                createCust3Info.Data.Id.Should().NotBeNullOrEmpty();
                createCust3Info.Data.Language.Should().Be("fr");
                // isDefault will be true (auto-promoted); intentionally not asserting false here.
                createCust3Info.Data.Subject.Should().Be("Bienvenue dans ${org.name}!");
                createCust3Info.Data.Created.Should().NotBe(default);
                createCust3Info.Data.Links.Should().NotBeNull();

                cust3Id = createCust3Info.Data.Id;

                // Second customization (it) — cust3 (fr) is already default; cust4 (it) stays false.
                var createCust4Info = await _templatesApi.CreateEmailCustomizationWithHttpInfoAsync(
                    brandId, TemplateName,
                    new EmailCustomization
                    {
                        Language  = "it",
                        IsDefault = false,
                        Subject   = "Benvenuto in ${org.name}!",
                        Body      = CustomizationBody("it")
                    });

                createCust4Info.StatusCode.Should().Be(HttpStatusCode.Created);
                createCust4Info.Data.Should().NotBeNull();
                createCust4Info.Data.Id.Should().NotBeNullOrEmpty();
                createCust4Info.Data.Language.Should().Be("it");
                createCust4Info.Data.IsDefault.Should().BeFalse(
                    "cust4 (it) is the second customization; cust3 (fr) is already the default");

                cust4Id = createCust4Info.Data.Id;

                #endregion

                #region ListEmailCustomizationsWithHttpInfoAsync → 200, both cust3 and cust4 in list

                var listCustInfo = await _templatesApi.ListEmailCustomizationsWithHttpInfoAsync(
                    brandId, TemplateName);

                listCustInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                listCustInfo.Data.Should().NotBeNull();
                listCustInfo.Data.Should().Contain(c => c.Id == cust3Id,
                    "the French (default) customization must appear in the WithHttpInfo list result");
                listCustInfo.Data.Should().Contain(c => c.Id == cust4Id,
                    "the Italian (non-default) customization must appear in the WithHttpInfo list result");

                #endregion

                #region GetEmailCustomizationWithHttpInfoAsync → 200

                var getCustInfo = await _templatesApi.GetEmailCustomizationWithHttpInfoAsync(
                    brandId, TemplateName, cust4Id);

                getCustInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                getCustInfo.Data.Should().NotBeNull();
                getCustInfo.Data.Id.Should().Be(cust4Id);
                getCustInfo.Data.Language.Should().Be("it");

                #endregion

                #region GetCustomizationPreviewWithHttpInfoAsync → 200

                var getCustPreviewInfo = await _templatesApi.GetCustomizationPreviewWithHttpInfoAsync(
                    brandId, TemplateName, cust4Id);

                getCustPreviewInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                getCustPreviewInfo.Data.Should().NotBeNull();
                getCustPreviewInfo.Data.Subject.Should().NotBeNullOrEmpty();
                getCustPreviewInfo.Data.Body.Should().NotBeNullOrEmpty();

                #endregion

                #region ReplaceEmailCustomizationWithHttpInfoAsync → 200

                // cust4 (it) is non-default → IsDefault=false is valid; no E0000185 risk.
                var replaceCustInfo = await _templatesApi.ReplaceEmailCustomizationWithHttpInfoAsync(
                    brandId, TemplateName, cust4Id,
                    new EmailCustomization
                    {
                        Language  = "it",
                        IsDefault = false,
                        Subject   = "Benvenuto in ${org.name} - Aggiornato!",
                        Body      = CustomizationBody("it")
                    });

                replaceCustInfo.StatusCode.Should().Be(HttpStatusCode.OK);
                replaceCustInfo.Data.Should().NotBeNull();
                replaceCustInfo.Data.Id.Should().Be(cust4Id);
                replaceCustInfo.Data.Subject.Should().Be("Benvenuto in ${org.name} - Aggiornato!",
                    "ReplaceEmailCustomization must persist the updated subject via WithHttpInfo");

                #endregion

                #region DeleteEmailCustomizationWithHttpInfoAsync → 204

                // cust4 (it) is non-default → individual delete is allowed (E0000184 does not apply).
                var deleteCustInfo = await _templatesApi.DeleteEmailCustomizationWithHttpInfoAsync(
                    brandId, TemplateName, cust4Id);

                deleteCustInfo.StatusCode.Should().Be(HttpStatusCode.NoContent);
                cust4Id = null; // successfully deleted

                #endregion

                #region DeleteAllCustomizationsWithHttpInfoAsync → 204

                // cust3 (fr, default) is still alive. DeleteAll removes all including the default.
                var deleteAllInfo = await _templatesApi.DeleteAllCustomizationsWithHttpInfoAsync(
                    brandId, TemplateName);

                deleteAllInfo.StatusCode.Should().Be(HttpStatusCode.NoContent,
                    "DeleteAllCustomizations must return HTTP 204 No Content");
                cust3Id = null; // cleaned by DeleteAll

                // Verify list is now empty
                var afterDeleteAllInfo = await _templatesApi
                    .ListEmailCustomizations(brandId, TemplateName)
                    .ToListAsync();
                afterDeleteAllInfo.Should().BeEmpty(
                    "all customizations must be gone after DeleteAllCustomizationsWithHttpInfo");

                #endregion
            }
            finally
            {
                // ====================================================================
                // TEARDOWN: delete any remaining customizations and restore settings
                // ====================================================================

                // cust2 (de, non-default) — attempt individual delete if not already cleaned
                if (cust2Id != null && brandId != null)
                    try { await _templatesApi.DeleteEmailCustomizationAsync(brandId, TemplateName, cust2Id); } catch { }

                // cust4 (it, non-default) — attempt individual delete if not already cleaned
                if (cust4Id != null && brandId != null)
                    try { await _templatesApi.DeleteEmailCustomizationAsync(brandId, TemplateName, cust4Id); } catch { }

                // Catch-all: removes cust1 (es, default), cust3 (fr, default), or any other leftovers.
                // DeleteAll is idempotent (204 when list is already empty).
                if (brandId != null)
                    try { await _templatesApi.DeleteAllCustomizationsAsync(brandId, TemplateName); } catch { }

                // Restore email settings to ALL_USERS if they were changed
                if (settingsAltered && brandId != null)
                    try
                    {
                        await _templatesApi.ReplaceEmailSettingsAsync(
                            brandId, TemplateName,
                            new EmailSettings { Recipients = EmailSettings.RecipientsEnum.ALLUSERS });
                    }
                    catch { }
            }
        }
    }
}
