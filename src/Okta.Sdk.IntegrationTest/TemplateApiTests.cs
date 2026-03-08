// <copyright file="TemplateApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Newtonsoft.Json;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for TemplateApi covering all 6 SMS Template endpoints and their
    /// 12 SDK methods (6 primary + 6 WithHttpInfo variants).
    ///
    /// TemplateApi → Endpoint Mapping
    /// ─────────────────────────────────────────────────────────────────────────────────────
    /// ListSmsTemplates                    GET    /api/v1/templates/sms
    /// ListSmsTemplatesWithHttpInfoAsync   GET    /api/v1/templates/sms
    /// CreateSmsTemplateAsync              POST   /api/v1/templates/sms
    /// CreateSmsTemplateWithHttpInfoAsync  POST   /api/v1/templates/sms
    /// GetSmsTemplateAsync                 GET    /api/v1/templates/sms/{templateId}
    /// GetSmsTemplateWithHttpInfoAsync     GET    /api/v1/templates/sms/{templateId}
    /// UpdateSmsTemplateAsync              POST   /api/v1/templates/sms/{templateId}  (partial/merge)
    /// UpdateSmsTemplateWithHttpInfoAsync  POST   /api/v1/templates/sms/{templateId}
    /// ReplaceSmsTemplateAsync             PUT    /api/v1/templates/sms/{templateId}  (full replace)
    /// ReplaceSmsTemplateWithHttpInfoAsync PUT    /api/v1/templates/sms/{templateId}
    /// DeleteSmsTemplateAsync              DELETE /api/v1/templates/sms/{templateId}
    /// DeleteSmsTemplateWithHttpInfoAsync  DELETE /api/v1/templates/sms/{templateId}
    ///
    /// ─────────────────────────────────────────────────────────────────────────────────────
    /// - Only ONE custom template per type (SMS_VERIFY_CODE) is supported per org.
    /// - A built-in "default" template (id = "default") always exists and cannot be deleted
    ///   or modified by the "replace/update" APIs (those are for custom templates only).
    /// - List → 200 OK    (includes both default + any custom template)
    /// - Create → 200 OK  (not 201! confirmed via live API)
    /// - Get    → 200 OK
    /// - Update → 200 OK  (partial merge: adds/updates/removes translations; POST to /{id})
    /// - Replace→ 200 OK  (full replace: PUT to /{id})
    /// - Delete → 204 No Content
    /// - Get / Update / Replace / Delete with invalid templateId → 404
    /// - Teardown: the custom template created by the test is deleted in the finally block.
    /// </summary>
    public class TemplateApiTests
    {
        private readonly TemplateApi _templateApi = new();

        // ─────────────────────────────────────────────────────────────────────────────
        // Helpers
        // ─────────────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Builds a fully populated custom SMS template request body.
        /// </summary>
        private static SmsTemplate BuildCustomTemplate(string name = "Integration Test Template") =>
            new SmsTemplate
            {
                Name     = name,
                Type     = SmsTemplateType.SMSVERIFYCODE,
                Template = "${org.name}: your verification code is ${code}",
                Translations = new
                {
                    es = "${org.name}: su código de verificación es ${code}",
                    fr = "${org.name}: votre code de vérification est ${code}",
                },
            };

        /// <summary>
        /// Deletes the given template, swallowing any errors (best-effort teardown).
        /// </summary>
        private async Task TryDeleteTemplateAsync(string templateId)
        {
            try { await _templateApi.DeleteSmsTemplateAsync(templateId); }
            catch { /* best effort */ }
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // Test 1: Full happy-path + negative scenarios
        // ─────────────────────────────────────────────────────────────────────────────

        [Fact]
        public async Task GivenTemplateApi_WhenPerformingAllOperations_ThenAllEndpointsWork()
        {
            string createdId = null;

            try
            {
                // ── Section 1: ListSmsTemplates (GET /api/v1/templates/sms) ───────────
                // The default "built-in" template is always present.
                var allTemplates = await _templateApi.ListSmsTemplates().ToListAsync();
                allTemplates.Should().NotBeNull();
                allTemplates.Should().NotBeEmpty("the default SMS template is always present");

                var defaultEntry = allTemplates.FirstOrDefault(t => t.Id == "default");
                defaultEntry.Should().NotBeNull("default template must exist");
                defaultEntry?.Name.Should().NotBeNullOrEmpty();
                defaultEntry?.Type.Should().Be(SmsTemplateType.SMSVERIFYCODE);
                defaultEntry?.Template.Should().NotBeNullOrEmpty();
                defaultEntry?.Created.Should().NotBe(default);
                defaultEntry?.LastUpdated.Should().NotBe(default);

                // ── List with templateType filter ──────────────────────────────────────
                var filtered = await _templateApi
                    .ListSmsTemplates(SmsTemplateType.SMSVERIFYCODE)
                    .ToListAsync();
                filtered.Should().NotBeNull();
                filtered.All(t => t.Type == SmsTemplateType.SMSVERIFYCODE).Should().BeTrue();

                // ── Get the built-in default template by its well-known id ──────────
                // The default template is always retrievable even though it cannot be
                // meaningfully deleted (the API is idempotent; it auto-recreates it).
                var defaultTemplate = await _templateApi.GetSmsTemplateAsync("default");
                defaultTemplate.Should().NotBeNull();
                defaultTemplate.Id.Should().Be("default");
                defaultTemplate.Type.Should().Be(SmsTemplateType.SMSVERIFYCODE);
                defaultTemplate.Template.Should().Contain("${code}");
                defaultTemplate.Translations.Should().BeNull(
                    "the built-in default template has no translations");

                // ── Section 2: CreateSmsTemplateAsync (POST /api/v1/templates/sms) ──
                var created = await _templateApi.CreateSmsTemplateAsync(BuildCustomTemplate());
                created.Should().NotBeNull();
                created.Id.Should().NotBeNullOrEmpty();
                created.Id.Should().NotBe("default");
                created.Name.Should().Be("Integration Test Template");
                created.Type.Should().Be(SmsTemplateType.SMSVERIFYCODE);
                created.Template.Should().Contain("${code}");
                created.Created.Should().NotBe(default);
                created.LastUpdated.Should().NotBe(default);
                // Translations round-trip — Okta returns them as a JObject; verify non-null
                created.Translations.Should().NotBeNull();
                // Verify the two language keys we sent (es, fr) are present in the payload
                var createdTranslationsJson = JsonConvert.SerializeObject(created.Translations);
                createdTranslationsJson.Should().Contain("\"es\"");
                createdTranslationsJson.Should().Contain("\"fr\"");
                createdId = created.Id;

                // ── Section 3: GetSmsTemplateAsync (GET /api/v1/templates/sms/{id}) ──
                var fetched = await _templateApi.GetSmsTemplateAsync(createdId);
                fetched.Should().NotBeNull();
                fetched.Id.Should().Be(createdId);
                fetched.Name.Should().Be("Integration Test Template");
                fetched.Type.Should().Be(SmsTemplateType.SMSVERIFYCODE);
                fetched.Template.Should().Be("${org.name}: your verification code is ${code}");
                fetched.Translations.Should().NotBeNull();

                // ── Section 4: UpdateSmsTemplateAsync (POST /api/v1/templates/sms/{id}) ─
                // Partial / merge update: adds a new translation for "de", preserves others.
                var updateBody = new SmsTemplate
                {
                    Name     = "Integration Test Template",
                    Type     = SmsTemplateType.SMSVERIFYCODE,
                    Template = "${org.name}: your verification code is ${code}",
                    Translations = new
                    {
                        de = "${org.name}: ihr Bestätigungscode ist ${code}",
                    },
                };
                var updated = await _templateApi.UpdateSmsTemplateAsync(createdId, updateBody);
                updated.Should().NotBeNull();
                updated.Id.Should().Be(createdId);
                // After partial update, the template text should be unchanged
                updated.Template.Should().Be("${org.name}: your verification code is ${code}");
                // LastUpdated should be present
                updated.LastUpdated.Should().NotBe(default);

                // ── Section 5: ReplaceSmsTemplateAsync (PUT /api/v1/templates/sms/{id}) ─
                // Full replace: removes all translations, sets a new template body.
                var replaceBody = new SmsTemplate
                {
                    Name     = "Integration Test Template Replaced",
                    Type     = SmsTemplateType.SMSVERIFYCODE,
                    Template = "${org.name}: replaced code ${code}",
                };
                var replaced = await _templateApi.ReplaceSmsTemplateAsync(createdId, replaceBody);
                replaced.Should().NotBeNull();
                replaced.Id.Should().Be(createdId);
                replaced.Name.Should().Be("Integration Test Template Replaced");
                replaced.Template.Should().Be("${org.name}: replaced code ${code}");

                // GET after Replace to confirm persisted state
                var afterReplace = await _templateApi.GetSmsTemplateAsync(createdId);
                afterReplace.Name.Should().Be("Integration Test Template Replaced");
                afterReplace.Template.Should().Be("${org.name}: replaced code ${code}");
                // Replace without translations body should clear all previous translations
                afterReplace.Translations.Should().BeNull(
                    "a full Replace with no translations field should clear existing translations");

                // ── Section 6: List again — should now contain our custom template ───
                var afterCreateList = await _templateApi.ListSmsTemplates().ToListAsync();
                afterCreateList.Any(t => t.Id == createdId).Should().BeTrue();

                // ── Section 7: Negative — GetSmsTemplate with invalid templateId → 404 ─
                var exGet = await Assert.ThrowsAsync<ApiException>(
                    () => _templateApi.GetSmsTemplateAsync("invalid-template-id-99999"));
                exGet.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

                // ── Negative — UpdateSmsTemplate with invalid templateId → 404 ────────
                var exUpdate = await Assert.ThrowsAsync<ApiException>(
                    () => _templateApi.UpdateSmsTemplateAsync("invalid-template-id-99999", updateBody));
                exUpdate.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

                // ── Negative — ReplaceSmsTemplate with invalid templateId → 404 ───────
                var exReplace = await Assert.ThrowsAsync<ApiException>(
                    () => _templateApi.ReplaceSmsTemplateAsync("invalid-template-id-99999", replaceBody));
                exReplace.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

                // ── Negative — CreateSmsTemplate with missing ${code} macro → 400 ────
                // The template body MUST contain ${code}; Okta rejects it otherwise.
                var badTemplate = new SmsTemplate
                {
                    Name     = "Bad Template",
                    Type     = SmsTemplateType.SMSVERIFYCODE,
                    Template = "no verification code placeholder here",
                };
                var exBadCreate = await Assert.ThrowsAsync<ApiException>(
                    () => _templateApi.CreateSmsTemplateAsync(badTemplate));
                exBadCreate.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

                // ── Negative — Create duplicate (one custom template already exists) → 400
                // Only one custom template per type is allowed per org.
                var exDuplicate = await Assert.ThrowsAsync<ApiException>(
                    () => _templateApi.CreateSmsTemplateAsync(BuildCustomTemplate("Duplicate")));
                exDuplicate.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

                // Note: DeleteSmsTemplateAsync with an invalid/non-existent templateId does NOT throw.
                // The live API responds with 204 No Content regardless (idempotent DELETE).
                // We therefore do not assert a 404 for delete-with-invalid-id.

                // ── Section 8: DeleteSmsTemplateAsync (DELETE /api/v1/templates/sms/{id}) ─
                await _templateApi.DeleteSmsTemplateAsync(createdId);
                createdId = null; // nullify so finally block doesn't double-delete

                // After delete: GET should throw 404
                var exAfterDelete = await Assert.ThrowsAsync<ApiException>(
                    () => _templateApi.GetSmsTemplateAsync(created.Id));
                exAfterDelete.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

                // The List should no longer contain our template
                var afterDeleteList = await _templateApi.ListSmsTemplates().ToListAsync();
                afterDeleteList.Any(t => t.Id == created.Id).Should().BeFalse();
            }
            finally
            {
                if (createdId != null)
                    await TryDeleteTemplateAsync(createdId);
            }
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // Test 2: WithHttpInfo variants — verify HTTP status codes and response data
        // ─────────────────────────────────────────────────────────────────────────────

        [Fact]
        public async Task GivenTemplateApi_WhenUsingWithHttpInfoVariants_ThenHttpStatusCodesAreCorrect()
        {
            string createdId = null;

            try
            {
                // ── ListSmsTemplatesWithHttpInfoAsync → 200, Data populated ───────────
                var listResp = await _templateApi.ListSmsTemplatesWithHttpInfoAsync();
                listResp.StatusCode.Should().Be(HttpStatusCode.OK);
                listResp.Data.Should().NotBeNull();
                listResp.Data.Should().NotBeEmpty();

                // ── ListSmsTemplatesWithHttpInfoAsync with filter → 200 ───────────────
                var listFiltered = await _templateApi.ListSmsTemplatesWithHttpInfoAsync(SmsTemplateType.SMSVERIFYCODE);
                listFiltered.StatusCode.Should().Be(HttpStatusCode.OK);
                listFiltered.Data.Should().NotBeNull();
                listFiltered.Data.All(t => t.Type == SmsTemplateType.SMSVERIFYCODE).Should().BeTrue();

                // ── CreateSmsTemplateWithHttpInfoAsync → 200 OK ───────────────────────
                // (The live API returns 200, not 201, for template creation.)
                var createResp = await _templateApi.CreateSmsTemplateWithHttpInfoAsync(BuildCustomTemplate());
                createResp.StatusCode.Should().Be(HttpStatusCode.OK);
                createResp.Data.Should().NotBeNull();
                createResp.Data.Id.Should().NotBeNullOrEmpty();
                createResp.Data.Type.Should().Be(SmsTemplateType.SMSVERIFYCODE);
                createdId = createResp.Data.Id;

                // ── GetSmsTemplateWithHttpInfoAsync → 200, Data.Id matches ───────────
                var getResp = await _templateApi.GetSmsTemplateWithHttpInfoAsync(createdId);
                getResp.StatusCode.Should().Be(HttpStatusCode.OK);
                getResp.Data.Should().NotBeNull();
                getResp.Data.Id.Should().Be(createdId);

                // ── UpdateSmsTemplateWithHttpInfoAsync → 200 OK ──────────────────────
                var updateBody = new SmsTemplate
                {
                    Name     = "Integration Test Template",
                    Type     = SmsTemplateType.SMSVERIFYCODE,
                    Template = "${org.name}: your verification code is ${code}",
                    Translations = new { it = "${org.name}: il tuo codice è ${code}" },
                };
                var updateResp = await _templateApi.UpdateSmsTemplateWithHttpInfoAsync(createdId, updateBody);
                updateResp.StatusCode.Should().Be(HttpStatusCode.OK);
                updateResp.Data.Should().NotBeNull();
                updateResp.Data.Id.Should().Be(createdId);

                // ── ReplaceSmsTemplateWithHttpInfoAsync → 200 OK ─────────────────────
                var replaceBody = new SmsTemplate
                {
                    Name     = "Integration Test Template Final",
                    Type     = SmsTemplateType.SMSVERIFYCODE,
                    Template = "${org.name}: final code ${code}",
                };
                var replaceResp = await _templateApi.ReplaceSmsTemplateWithHttpInfoAsync(createdId, replaceBody);
                replaceResp.StatusCode.Should().Be(HttpStatusCode.OK);
                replaceResp.Data.Should().NotBeNull();
                replaceResp.Data.Id.Should().Be(createdId);
                replaceResp.Data.Name.Should().Be("Integration Test Template Final");

                // ── DeleteSmsTemplateWithHttpInfoAsync → 204 No Content ──────────────
                var deleteResp = await _templateApi.DeleteSmsTemplateWithHttpInfoAsync(createdId);
                deleteResp.StatusCode.Should().Be(HttpStatusCode.NoContent);
                createdId = null; // prevent double-delete in finally

                // ── Idempotent delete: non-existent templateId still returns 204 ──────
                // The DELETE endpoint is unconditionally idempotent — it does not throw
                // a 404 for missing IDs. This is confirmed via live curl.
                var idempotentDelete = await _templateApi.DeleteSmsTemplateWithHttpInfoAsync("non-existent-id-99999");
                idempotentDelete.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
            finally
            {
                if (createdId != null)
                    await TryDeleteTemplateAsync(createdId);
            }
        }
    }
}
