// <copyright file="EmailCustomizationApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for EmailCustomizationApi covering all 2 methods (1 operation × 2 variants).
    ///
    /// EmailCustomizationApi → Endpoint Mapping
    /// ─────────────────────────────────────────────────────────────────────────
    /// BulkRemoveEmailAddressBounces     POST   /api/v1/org/email/bounces/remove-list
    /// BulkRemoveEmailAddressBouncesWithHttpInfo  (same endpoint, raw ApiResponse variant)
    ///
    /// Key behaviors discovered via curl validation:
    /// - The endpoint ALWAYS returns HTTP 200 for syntactically well-formed requests, even when
    ///   all submitted emails are not on the bounce list or belong to another org.
    /// - Invalid email format (RFC 3696 check fails) → 200 with errors[].reason =
    ///   "Invalid email address. The provided email address failed validation against RFC 3696."
    /// - Valid-format email that does not belong to any org user → 200 with errors[].reason =
    ///   "This email address does not belong to any user in your organization."
    /// - Mixed batch (invalid + valid-format-not-in-org) → 200 with an errors entry for each address.
    /// - Empty emailAddresses list → 400 E0000001
    ///   "emailAddresses: The field cannot be left blank"
    /// - Null body (bouncesRemoveListObj = null) → 400 E0000003
    ///   "The request body was not well-formed." (distinct error code from empty-list case)
    ///
    /// Teardown:
    ///   The bounce-removal endpoint is stateless with respect to the org's data model —
    ///   it only removes addresses from an external email-service bounce list.
    ///   No org resources are created, so no teardown is required beyond standard assertion cleanup.
    /// </summary>
    public class EmailCustomizationApiTests
    {
        private readonly EmailCustomizationApi _emailCustomizationApi = new();

        /// <summary>
        /// Comprehensive single test covering all EmailCustomizationApi scenarios:
        ///
        /// Happy-path scenarios
        ///   1. Single invalid-format email        → 200 OK, errors array with RFC 3696 reason
        ///   2. Single valid-format email (not in org) → 200 OK, errors array with "not in org" reason
        ///   3. Mixed batch (invalid + valid-format) → 200 OK, errors for every address
        ///   4. Multiple valid-format emails        → 200 OK, errors for each (none on bounce list)
        ///
        /// Negative scenarios
        ///   5a. Empty emailAddresses list          → 400 E0000001 (cannot be blank)
        ///   5b. Null request body (null arg)       → 400 E0000003 (request body not well-formed)
        ///
        /// WithHttpInfo variant
        ///   6. BulkRemoveEmailAddressBouncesWithHttpInfoAsync → 200 OK, status code confirmed
        ///
        /// Teardown: none required (endpoint is fully stateless for the org data model).
        /// </summary>
        [Fact]
        public async Task GivenEmailCustomizationApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            // ====================================================================
            // SECTION 1: Single invalid-format email → 200 OK with RFC 3696 error
            // POST /api/v1/org/email/bounces/remove-list
            // ====================================================================

            #region BulkRemoveEmailAddressBounces – invalid email format (RFC 3696 check)

            // Curl-confirmed: "bad-email" fails RFC 3696 and is reported in the errors array.
            // The HTTP status is still 200 — the endpoint is designed to be permissive.
            var resultInvalid = await _emailCustomizationApi.BulkRemoveEmailAddressBouncesAsync(
                new BouncesRemoveListObj
                {
                    EmailAddresses = new List<string> { "not-an-email" }
                });

            resultInvalid.Should().NotBeNull();
            resultInvalid.Errors.Should().NotBeNull(
                "the response must include an errors list when addresses fail validation");
            resultInvalid.Errors.Should().ContainSingle(
                "exactly one error entry must be returned for one invalid email");

            var rfcError = resultInvalid.Errors[0];
            rfcError.EmailAddress.Should().Be("not-an-email",
                "the error entry must echo back the submitted address");
            rfcError.Reason.Should().NotBeNullOrEmpty(
                "every error entry must carry a human-readable reason");
            rfcError.Reason.Should().Contain("RFC",
                "the reason for an RFC-invalid address must mention RFC 3696");

            #endregion

            // ====================================================================
            // SECTION 2: Valid-format email that does not belong to any org user → 200
            // POST /api/v1/org/email/bounces/remove-list
            // ====================================================================

            #region BulkRemoveEmailAddressBounces – RFC-valid email not in the org

            // Curl-confirmed: "valid.format@example.com" passes RFC 3696 but is not a user
            // in the org, so it appears in the errors array with a different reason message.
            var resultNotInOrg = await _emailCustomizationApi.BulkRemoveEmailAddressBouncesAsync(
                new BouncesRemoveListObj
                {
                    EmailAddresses = new List<string> { "sdk-integration-test-bounce@example.com" }
                });

            resultNotInOrg.Should().NotBeNull();
            resultNotInOrg.Errors.Should().NotBeNull();
            resultNotInOrg.Errors.Should().ContainSingle(
                "one error entry must be returned for one address that is not an org user");

            var notInOrgError = resultNotInOrg.Errors[0];
            notInOrgError.EmailAddress.Should().Be("sdk-integration-test-bounce@example.com");
            notInOrgError.Reason.Should().NotBeNullOrEmpty();
            notInOrgError.Reason.Should().Contain("organization",
                "the reason for a valid-but-not-org address must reference the organization");

            #endregion

            // ====================================================================
            // SECTION 3: Mixed batch (invalid-format + valid-format-not-in-org) → 200
            // POST /api/v1/org/email/bounces/remove-list
            // ====================================================================

            #region BulkRemoveEmailAddressBounces – mixed batch with two distinct error reasons

            // Curl-confirmed: both addresses appear in the errors array; the batch is accepted
            // even though all entries fail either validation or org-membership check.
            var resultMixed = await _emailCustomizationApi.BulkRemoveEmailAddressBouncesAsync(
                new BouncesRemoveListObj
                {
                    EmailAddresses = new List<string>
                    {
                        "bad-email-no-at-sign",
                        "sdk-integration-bounce-two@example.com"
                    }
                });

            resultMixed.Should().NotBeNull();
            resultMixed.Errors.Should().NotBeNull();
            resultMixed.Errors.Should().HaveCount(2,
                "each submitted address must have a corresponding errors entry");

            // Order is not guaranteed by the API — find entries by address.
            var invalidEntry = resultMixed.Errors
                .Find(e => e.EmailAddress == "bad-email-no-at-sign");
            var notOrgEntry = resultMixed.Errors
                .Find(e => e.EmailAddress == "sdk-integration-bounce-two@example.com");

            invalidEntry.Should().NotBeNull("the invalid-format address must be in the errors list");
            invalidEntry!.Reason.Should().Contain("RFC",
                "the RFC-invalid address must reference RFC 3696 in its reason");

            notOrgEntry.Should().NotBeNull("the valid-format address must be in the errors list");
            notOrgEntry!.Reason.Should().NotBeNullOrEmpty();

            #endregion

            // ====================================================================
            // SECTION 4: Multiple valid-format emails → 200, one error per address
            // POST /api/v1/org/email/bounces/remove-list
            // ====================================================================

            #region BulkRemoveEmailAddressBounces – multiple valid-format addresses not in org

            var resultMultiple = await _emailCustomizationApi.BulkRemoveEmailAddressBouncesAsync(
                new BouncesRemoveListObj
                {
                    EmailAddresses = new List<string>
                    {
                        "sdk-bounce-a@example.com",
                        "sdk-bounce-b@example.com",
                        "sdk-bounce-c@example.com"
                    }
                });

            resultMultiple.Should().NotBeNull();
            resultMultiple.Errors.Should().NotBeNull();
            resultMultiple.Errors.Should().HaveCount(3,
                "each submitted address must produce an error entry when none belong to the org");

            foreach (var error in resultMultiple.Errors)
            {
                error.EmailAddress.Should().NotBeNullOrEmpty("every error entry must carry the email address");
                error.Reason.Should().NotBeNullOrEmpty("every error entry must carry a reason");
            }

            #endregion

            // ====================================================================
            // SECTION 5a: Empty emailAddresses list → 400 E0000001 (field cannot be blank)
            // POST /api/v1/org/email/bounces/remove-list
            // ====================================================================

            #region BulkRemoveEmailAddressBounces – empty list returns 400 E0000001

            // Curl-confirmed: emailAddresses=[] → 400 E0000001 "The field cannot be left blank"
            var exEmpty = await Assert.ThrowsAsync<ApiException>(async () =>
                await _emailCustomizationApi.BulkRemoveEmailAddressBouncesAsync(
                    new BouncesRemoveListObj
                    {
                        EmailAddresses = new List<string>() // empty — not null
                    }));

            exEmpty.ErrorCode.Should().Be(400,
                "an empty emailAddresses list must return 400 E0000001 (field cannot be blank)");
            // The ApiException.Message contains the raw JSON error body, not the HTTP status code.
            // ErrorCode is the authoritative place for the HTTP status; no Message assertion needed.

            #endregion

            // ====================================================================
            // SECTION 5b: Null request body → 400 E0000003 (request body not well-formed)
            // POST /api/v1/org/email/bounces/remove-list
            // ====================================================================

            #region BulkRemoveEmailAddressBounces – null body returns 400 E0000003

            // Curl-confirmed: POST with no body → 400 E0000003
            //   "The request body was not well-formed."
            // This is distinct from the empty-list case (E0000001).
            // The SDK method accepts bouncesRemoveListObj as optional (= default = null);
            // passing null is a valid call-site pattern that must be rejected by the API.
            var exNull = await Assert.ThrowsAsync<ApiException>(async () =>
                await _emailCustomizationApi.BulkRemoveEmailAddressBouncesAsync(null));

            exNull.ErrorCode.Should().Be(400,
                "a null request body must return 400 E0000003 (request body not well-formed)");

            #endregion

            // ====================================================================
            // SECTION 6: BulkRemoveEmailAddressBouncesWithHttpInfoAsync → 200 OK
            // WithHttpInfo variant — exposes raw ApiResponse for status-code inspection
            // ====================================================================

            #region BulkRemoveEmailAddressBouncesWithHttpInfoAsync – HTTP 200 status confirmed

            var infoResponse = await _emailCustomizationApi.BulkRemoveEmailAddressBouncesWithHttpInfoAsync(
                new BouncesRemoveListObj
                {
                    EmailAddresses = new List<string> { "sdk-integration-httpinfo@example.com" }
                });

            infoResponse.Should().NotBeNull();
            infoResponse.StatusCode.Should().Be(HttpStatusCode.OK,
                "BulkRemoveEmailAddressBounces must return HTTP 200 OK");
            infoResponse.Data.Should().NotBeNull(
                "the WithHttpInfo variant must deserialise the response body into Data");
            infoResponse.Data.Errors.Should().NotBeNull();

            // The submitted address is valid-format but not an org user → one error entry.
            infoResponse.Data.Errors.Should().ContainSingle(
                "one error entry is expected for one valid-format address not in the org");
            infoResponse.Data.Errors[0].EmailAddress.Should().Be("sdk-integration-httpinfo@example.com");
            infoResponse.Data.Errors[0].Reason.Should().NotBeNullOrEmpty();

            #endregion

            // ====================================================================
            // TEARDOWN
            // ====================================================================
            // BulkRemoveEmailAddressBounces is fully stateless with respect to the Okta org's
            // data model — it only removes addresses from an external email-service bounce list.
            // No Okta resources (brands, templates, users, etc.) are created or modified by
            // this test, so no teardown steps are required.
        }
    }
}
