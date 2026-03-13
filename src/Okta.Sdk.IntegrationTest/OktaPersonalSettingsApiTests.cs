// <copyright file="OktaPersonalSettingsApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for OktaPersonalSettingsApi covering all 3 operations (6 method variants).
    ///
    /// OktaPersonalSettingsApi → Endpoint Mapping
    /// ─────────────────────────────────────────────────────────────────────────
    /// ListPersonalAppsExportBlockListAsync              GET  /okta-personal-settings/api/v1/export-blocklists
    /// ListPersonalAppsExportBlockListWithHttpInfoAsync  GET  /okta-personal-settings/api/v1/export-blocklists
    /// ReplaceBlockedEmailDomainsAsync                   PUT  /okta-personal-settings/api/v1/export-blocklists
    /// ReplaceBlockedEmailDomainsWithHttpInfoAsync        PUT  /okta-personal-settings/api/v1/export-blocklists
    /// ReplaceOktaPersonalAdminSettingsAsync             PUT  /okta-personal-settings/api/v1/edit-feature
    /// ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync PUT  /okta-personal-settings/api/v1/edit-feature
    ///
    /// Curl-validated responses: GET→200, both PUTs→204.
    /// Scenarios: 12 sections (8 happy-path + 4 negative null-body guards).
    /// Note: There is no GET endpoint for admin feature settings; teardown restores
    ///       the blocked-domains list to its pre-test state and resets admin settings
    ///       to a known safe state (both features disabled).
    /// </summary>
    public class OktaPersonalSettingsApiTests
    {
        private readonly OktaPersonalSettingsApi _api = new();

        [Fact]
        public async Task GivenOktaPersonalSettingsApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            List<string> originalDomains = null;

            try
            {
                // ====================================================================
                // SETUP: Capture pre-test state so teardown can restore it
                // ====================================================================

                #region SETUP – capture original blocked-domains list

                var initialBlockList = await _api.ListPersonalAppsExportBlockListAsync();
                initialBlockList.Should().NotBeNull("initial GET must succeed");
                originalDomains = initialBlockList.Domains ?? new List<string>();

                #endregion

                await Task.Delay(500);

                // ====================================================================
                // SECTION 1: ListPersonalAppsExportBlockListAsync
                //            GET /okta-personal-settings/api/v1/export-blocklists → 200
                // ====================================================================

                #region ListPersonalAppsExportBlockListAsync – returns PersonalAppsBlockList (200)

                var blockList = await _api.ListPersonalAppsExportBlockListAsync();

                blockList.Should().NotBeNull("GET export-blocklists must return a non-null body");
                blockList.Domains.Should().NotBeNull("Domains property must be present (may be empty)");

                #endregion

                await Task.Delay(500);

                // ====================================================================
                // SECTION 2: ListPersonalAppsExportBlockListWithHttpInfoAsync
                //            GET /okta-personal-settings/api/v1/export-blocklists → 200
                // ====================================================================

                #region ListPersonalAppsExportBlockListWithHttpInfoAsync – HttpStatusCode.OK + headers

                var blockListHttpInfo = await _api.ListPersonalAppsExportBlockListWithHttpInfoAsync();

                blockListHttpInfo.Should().NotBeNull();
                blockListHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK,
                    "GET export-blocklists should return 200 OK");
                blockListHttpInfo.Data.Should().NotBeNull(
                    "response body must deserialize to PersonalAppsBlockList");
                blockListHttpInfo.Data.Domains.Should().NotBeNull(
                    "Domains property must be present in WithHttpInfo response");
                blockListHttpInfo.Headers.Should().NotBeNull();
                blockListHttpInfo.Headers.Should().ContainKey("Content-Type",
                    "all JSON responses must carry Content-Type");

                #endregion

                await Task.Delay(500);

                // ====================================================================
                // SECTION 3: ReplaceBlockedEmailDomainsAsync
                //            PUT /okta-personal-settings/api/v1/export-blocklists → 204
                // ====================================================================

                #region ReplaceBlockedEmailDomainsAsync – sets test domains, no exception (204)

                var testDomains = new PersonalAppsBlockList
                {
                    Domains = new List<string> { "sdk-test-a.example.com", "sdk-test-b.example.com" }
                };

                // Should complete without throwing
                await _api.Invoking(a => a.ReplaceBlockedEmailDomainsAsync(testDomains))
                    .Should().NotThrowAsync("PUT export-blocklists with a valid body must succeed");

                await Task.Delay(500);

                // Verify the change was applied
                var afterFirstPut = await _api.ListPersonalAppsExportBlockListAsync();
                afterFirstPut.Should().NotBeNull();
                afterFirstPut.Domains.Should().NotBeNull();
                afterFirstPut.Domains.Should().Contain("sdk-test-a.example.com",
                    "first test domain should be present after PUT");
                afterFirstPut.Domains.Should().Contain("sdk-test-b.example.com",
                    "second test domain should be present after PUT");
                afterFirstPut.Domains.Should().HaveCount(2,
                    "PUT is a full replace; exactly the two submitted domains should be stored");

                #endregion

                await Task.Delay(500);

                // ====================================================================
                // SECTION 3b: ReplaceBlockedEmailDomainsAsync – empty list (clear all domains)
                //             PUT /okta-personal-settings/api/v1/export-blocklists → 204
                // ====================================================================

                #region ReplaceBlockedEmailDomainsAsync – empty domains list is accepted (204)

                var emptyDomains = new PersonalAppsBlockList
                {
                    Domains = new List<string>()
                };

                await _api.Invoking(a => a.ReplaceBlockedEmailDomainsAsync(emptyDomains))
                    .Should().NotThrowAsync("PUT with an empty Domains list must be accepted (clears the blocklist)");

                await Task.Delay(500);

                var afterClear = await _api.ListPersonalAppsExportBlockListAsync();
                afterClear.Domains.Should().NotBeNull();
                afterClear.Domains.Should().BeEmpty("after clearing all domains the blocklist should be empty");

                #endregion

                await Task.Delay(500);

                // ====================================================================
                // SECTION 4: ReplaceBlockedEmailDomainsWithHttpInfoAsync
                //            PUT /okta-personal-settings/api/v1/export-blocklists → 204
                // ====================================================================

                #region ReplaceBlockedEmailDomainsWithHttpInfoAsync – HttpStatusCode.NoContent (204)

                var replaceDomains = new PersonalAppsBlockList
                {
                    Domains = new List<string> { "sdk-test-c.example.com" }
                };

                var replaceHttpInfo = await _api.ReplaceBlockedEmailDomainsWithHttpInfoAsync(replaceDomains);

                replaceHttpInfo.Should().NotBeNull();
                replaceHttpInfo.StatusCode.Should().Be(HttpStatusCode.NoContent,
                    "PUT export-blocklists should return 204 No Content");

                await Task.Delay(500);

                // Verify the update was applied
                var afterSecondPut = await _api.ListPersonalAppsExportBlockListAsync();
                afterSecondPut.Domains.Should().ContainSingle("after the second PUT only one domain should remain")
                    .Which.Should().Be("sdk-test-c.example.com");

                #endregion

                await Task.Delay(500);

                // ====================================================================
                // SECTION 6: ReplaceOktaPersonalAdminSettingsAsync
                //            PUT /okta-personal-settings/api/v1/edit-feature → 204
                // ====================================================================

                #region ReplaceOktaPersonalAdminSettingsAsync – enables both features, no exception (204)

                var enableBothSettings = new OktaPersonalAdminFeatureSettings
                {
                    EnableExportApps = true,
                    EnableEnduserEntryPoints = true
                };

                await _api.Invoking(a => a.ReplaceOktaPersonalAdminSettingsAsync(enableBothSettings))
                    .Should().NotThrowAsync(
                        "PUT edit-feature with enableExportApps=true and enableEnduserEntryPoints=true must succeed");

                #endregion

                await Task.Delay(500);

                // ====================================================================
                // SECTION 7: ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync
                //            PUT /okta-personal-settings/api/v1/edit-feature → 204
                // ====================================================================

                #region ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync – HttpStatusCode.NoContent (204)

                var disableExportSettings = new OktaPersonalAdminFeatureSettings
                {
                    EnableExportApps = false,
                    EnableEnduserEntryPoints = true
                };

                var adminSettingsHttpInfo =
                    await _api.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(disableExportSettings);

                adminSettingsHttpInfo.Should().NotBeNull();
                adminSettingsHttpInfo.StatusCode.Should().Be(HttpStatusCode.NoContent,
                    "PUT edit-feature should return 204 No Content");

                #endregion

                await Task.Delay(500);

                // ====================================================================
                // SECTION 8: ReplaceOktaPersonalAdminSettingsAsync – all four boolean combinations
                //            Both fields are independently togglable; all four combos must return 204.
                // ====================================================================

                #region ReplaceOktaPersonalAdminSettingsAsync – all four boolean combinations accepted

                var boolCombinations = new[]
                {
                    (EnableExportApps: true,  EnableEnduserEntryPoints: false),
                    (EnableExportApps: false, EnableEnduserEntryPoints: false),
                    (EnableExportApps: false, EnableEnduserEntryPoints: true),
                    // (true, true) already exercised in Section 6
                };

                foreach (var combo in boolCombinations)
                {
                    var comboSettings = new OktaPersonalAdminFeatureSettings
                    {
                        EnableExportApps = combo.EnableExportApps,
                        EnableEnduserEntryPoints = combo.EnableEnduserEntryPoints
                    };
                    await _api.Invoking(a => a.ReplaceOktaPersonalAdminSettingsAsync(comboSettings))
                        .Should().NotThrowAsync(
                            $"PUT edit-feature with enableExportApps={combo.EnableExportApps} " +
                            $"and enableEnduserEntryPoints={combo.EnableEnduserEntryPoints} must be accepted");
                    await Task.Delay(300);
                }

                #endregion

                await Task.Delay(500);

                // ====================================================================
                // SECTION 9: Negative – ReplaceBlockedEmailDomainsAsync(null)
                //            SDK throws ApiException(400) before making an HTTP call
                // ====================================================================

                #region ReplaceBlockedEmailDomainsAsync(null) – ApiException ErrorCode 400

                var nullBlockListEx = await _api
                    .Invoking(a => a.ReplaceBlockedEmailDomainsAsync(null!))
                    .Should().ThrowAsync<ApiException>(
                        "passing null for the required personalAppsBlockList parameter must throw ApiException");
                nullBlockListEx.WithMessage("*Missing required parameter*");
                nullBlockListEx.Which.ErrorCode.Should().Be(400,
                    "the SDK sets ErrorCode=400 for missing required parameters");

                #endregion

                // ====================================================================
                // SECTION 10: Negative – ReplaceBlockedEmailDomainsWithHttpInfoAsync(null)
                //             Same guard, WithHttpInfo variant
                // ====================================================================

                #region ReplaceBlockedEmailDomainsWithHttpInfoAsync(null) – ApiException ErrorCode 400

                var nullBlockListHttpInfoEx = await _api
                    .Invoking(a => a.ReplaceBlockedEmailDomainsWithHttpInfoAsync(null!))
                    .Should().ThrowAsync<ApiException>(
                        "passing null to the WithHttpInfo variant must also throw ApiException");
                nullBlockListHttpInfoEx.WithMessage("*Missing required parameter*");
                nullBlockListHttpInfoEx.Which.ErrorCode.Should().Be(400);

                #endregion

                // ====================================================================
                // SECTION 11: Negative – ReplaceOktaPersonalAdminSettingsAsync(null)
                //             SDK throws ApiException(400) before making an HTTP call
                // ====================================================================

                #region ReplaceOktaPersonalAdminSettingsAsync(null) – ApiException ErrorCode 400

                var nullAdminEx = await _api
                    .Invoking(a => a.ReplaceOktaPersonalAdminSettingsAsync(null!))
                    .Should().ThrowAsync<ApiException>(
                        "passing null for the required oktaPersonalAdminFeatureSettings parameter must throw ApiException");
                nullAdminEx.WithMessage("*Missing required parameter*");
                nullAdminEx.Which.ErrorCode.Should().Be(400);

                #endregion

                // ====================================================================
                // SECTION 12: Negative – ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(null)
                //             Same guard, WithHttpInfo variant
                // ====================================================================

                #region ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(null) – ApiException ErrorCode 400

                var nullAdminHttpInfoEx = await _api
                    .Invoking(a => a.ReplaceOktaPersonalAdminSettingsWithHttpInfoAsync(null!))
                    .Should().ThrowAsync<ApiException>(
                        "passing null to the WithHttpInfo variant must also throw ApiException");
                nullAdminHttpInfoEx.WithMessage("*Missing required parameter*");
                nullAdminHttpInfoEx.Which.ErrorCode.Should().Be(400);

                #endregion
            }
            finally
            {
                // ====================================================================
                // TEARDOWN
                // Restore the blocked-domains list to its pre-test state.
                // Reset admin feature settings to a known safe state (both disabled).
                // ====================================================================

                #region TEARDOWN – restore blocked-domains list and admin settings

                try
                {
                    // Restore blocked-domains list
                    var restoreDomains = new PersonalAppsBlockList
                    {
                        Domains = originalDomains ?? new List<string>()
                    };
                    await _api.ReplaceBlockedEmailDomainsAsync(restoreDomains);
                }
                catch (Exception ex)
                {
                    // Log but do not fail the test on teardown errors
                    Console.WriteLine($"[TEARDOWN] Failed to restore blocked-domains list: {ex.Message}");
                }

                try
                {
                    // Reset admin settings to a known safe state.
                    // There is no GET for admin settings, so we cannot restore the exact
                    // original values; we default to both features disabled.
                    var safeSettings = new OktaPersonalAdminFeatureSettings
                    {
                        EnableExportApps = false,
                        EnableEnduserEntryPoints = false
                    };
                    await _api.ReplaceOktaPersonalAdminSettingsAsync(safeSettings);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[TEARDOWN] Failed to restore admin settings: {ex.Message}");
                }

                #endregion
            }
        }
    }
}
