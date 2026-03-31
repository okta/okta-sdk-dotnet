// <copyright file="IdentitySourceApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for the IdentitySourceApi.
    ///
    /// IMPORTANT: The session lifecycle tests require a <c>custom_identity_source</c> app with
    /// <b>profile sourcing</b> enabled.  This feature cannot be activated through the management API
    /// and must be turned on manually in the Okta Admin Console:
    ///
    ///   Admin Console → Applications → &lt;app&gt; → Provisioning → Enable "Profile Sourcing"
    ///
    /// The pre-configured identity source app used by these tests has ID:
    ///   <c>0oawy3z24vqxn04J61d7</c>  (label: "Test Identity Source for SDK")
    ///
    /// Once the feature is enabled for that app, remove the <c>Skip</c> attribute from
    /// <see cref="GivenIdentitySourceSessions_WhenPerformingLifecycleOperations_ThenAllEndpointsAndMethodsWork"/>.
    /// </summary>
    [Collection(nameof(IdentitySourceApiTests))]
    public class IdentitySourceApiTests : IDisposable
    {
        // Pre-existing custom_identity_source app in the integration test org.
        // Profile sourcing must be enabled on this app before the lifecycle test can run.
        private const string KnownIdentitySourceId = "0oawy3z24vqxn04J61d7";

        private readonly IdentitySourceApi _identitySourceApi = new();
        private readonly List<string> _createdSessionIds = [];

        public void Dispose()
        {
            CleanupResources().GetAwaiter().GetResult();
        }

        private async Task CleanupResources()
        {
            foreach (var sessionId in _createdSessionIds)
            {
                try
                {
                    await _identitySourceApi.DeleteIdentitySourceSessionAsync(KnownIdentitySourceId, sessionId);
                }
                catch (ApiException)
                {
                    // best-effort cleanup
                }
            }

            _createdSessionIds.Clear();
        }

        // -----------------------------------------------------------------------
        // CLIENT-SIDE NULL-PARAMETER VALIDATION
        // These checks are performed before any HTTP call is made; they run regardless
        // of whether the profile sourcing feature is enabled.
        // -----------------------------------------------------------------------

        [Fact]
        public async Task GivenIdentitySourceApi_WhenCalledWithNullRequiredParameters_ThenThrowsApiException400()
        {
            // --- CreateIdentitySourceSessionAsync ---

            var nullCreateSource = async () =>
                await _identitySourceApi.CreateIdentitySourceSessionAsync(null);
            (await nullCreateSource.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullCreateSourceHttp = async () =>
                await _identitySourceApi.CreateIdentitySourceSessionWithHttpInfoAsync(null);
            (await nullCreateSourceHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            (await nullCreateSource.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");

            // --- DeleteIdentitySourceSessionAsync ---

            var nullDeleteSource = async () =>
                await _identitySourceApi.DeleteIdentitySourceSessionAsync(null, "some-session");
            (await nullDeleteSource.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullDeleteSession = async () =>
                await _identitySourceApi.DeleteIdentitySourceSessionAsync(KnownIdentitySourceId, null);
            (await nullDeleteSession.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullDeleteSourceHttp = async () =>
                await _identitySourceApi.DeleteIdentitySourceSessionWithHttpInfoAsync(null, "some-session");
            (await nullDeleteSourceHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullDeleteSessionHttp = async () =>
                await _identitySourceApi.DeleteIdentitySourceSessionWithHttpInfoAsync(KnownIdentitySourceId, null);
            (await nullDeleteSessionHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            (await nullDeleteSource.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");
            (await nullDeleteSession.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("sessionId");

            // --- GetIdentitySourceSessionAsync ---

            var nullGetSource = async () =>
                await _identitySourceApi.GetIdentitySourceSessionAsync(null, "some-session");
            (await nullGetSource.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullGetSession = async () =>
                await _identitySourceApi.GetIdentitySourceSessionAsync(KnownIdentitySourceId, null);
            (await nullGetSession.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullGetSourceHttp = async () =>
                await _identitySourceApi.GetIdentitySourceSessionWithHttpInfoAsync(null, "some-session");
            (await nullGetSourceHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullGetSessionHttp = async () =>
                await _identitySourceApi.GetIdentitySourceSessionWithHttpInfoAsync(KnownIdentitySourceId, null);
            (await nullGetSessionHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            (await nullGetSource.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");
            (await nullGetSession.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("sessionId");

            // --- ListIdentitySourceSessions ---

            var nullListSource = async () =>
                await _identitySourceApi.ListIdentitySourceSessions(null).ToListAsync();
            (await nullListSource.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullListSourceHttp = async () =>
                await _identitySourceApi.ListIdentitySourceSessionsWithHttpInfoAsync(null);
            (await nullListSourceHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            (await nullListSource.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");

            // --- StartImportFromIdentitySourceAsync ---

            var nullStartSource = async () =>
                await _identitySourceApi.StartImportFromIdentitySourceAsync(null, "some-session");
            (await nullStartSource.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullStartSession = async () =>
                await _identitySourceApi.StartImportFromIdentitySourceAsync(KnownIdentitySourceId, null);
            (await nullStartSession.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullStartSourceHttp = async () =>
                await _identitySourceApi.StartImportFromIdentitySourceWithHttpInfoAsync(null, "some-session");
            (await nullStartSourceHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullStartSessionHttp = async () =>
                await _identitySourceApi.StartImportFromIdentitySourceWithHttpInfoAsync(KnownIdentitySourceId, null);
            (await nullStartSessionHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            (await nullStartSource.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");
            (await nullStartSession.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("sessionId");

            // --- UploadIdentitySourceDataForDeleteAsync ---

            var nullUploadDelSource = async () =>
                await _identitySourceApi.UploadIdentitySourceDataForDeleteAsync(null, "some-session");
            (await nullUploadDelSource.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullUploadDelSession = async () =>
                await _identitySourceApi.UploadIdentitySourceDataForDeleteAsync(KnownIdentitySourceId, null);
            (await nullUploadDelSession.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullUploadDelSourceHttp = async () =>
                await _identitySourceApi.UploadIdentitySourceDataForDeleteWithHttpInfoAsync(null, "some-session");
            (await nullUploadDelSourceHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullUploadDelSessionHttp = async () =>
                await _identitySourceApi.UploadIdentitySourceDataForDeleteWithHttpInfoAsync(KnownIdentitySourceId, null);
            (await nullUploadDelSessionHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            (await nullUploadDelSource.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");
            (await nullUploadDelSession.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("sessionId");

            // --- UploadIdentitySourceDataForUpsertAsync ---

            var nullUploadUpsertSource = async () =>
                await _identitySourceApi.UploadIdentitySourceDataForUpsertAsync(null, "some-session");
            (await nullUploadUpsertSource.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullUploadUpsertSession = async () =>
                await _identitySourceApi.UploadIdentitySourceDataForUpsertAsync(KnownIdentitySourceId, null);
            (await nullUploadUpsertSession.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullUploadUpsertSourceHttp = async () =>
                await _identitySourceApi.UploadIdentitySourceDataForUpsertWithHttpInfoAsync(null, "some-session");
            (await nullUploadUpsertSourceHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            var nullUploadUpsertSessionHttp = async () =>
                await _identitySourceApi.UploadIdentitySourceDataForUpsertWithHttpInfoAsync(KnownIdentitySourceId, null);
            (await nullUploadUpsertSessionHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            (await nullUploadUpsertSource.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("identitySourceId");
            (await nullUploadUpsertSession.Should().ThrowAsync<ApiException>())
                .Which.Message.Should().Contain("sessionId");
        }

        // -----------------------------------------------------------------------
        // FULL SESSION LIFECYCLE
        // Requires: profile sourcing enabled on the identity source app.
        // To enable: Admin Console → Applications → "Test Identity Source for SDK"
        //            → Provisioning tab → enable "Profile Sourcing".
        // -----------------------------------------------------------------------

        [Fact]
        public async Task GivenIdentitySourceSessions_WhenPerformingLifecycleOperations_ThenAllEndpointsAndMethodsWork()
        {
            // API constraints discovered via live investigation:
            //  1. Session creation returns HTTP 201 Created (not 200).
            //  2. Only one CREATED/IN_PROGRESS session is allowed per identity source at a time.
            //  3. After start-import (TRIGGERED), there is a ~60-second rate-limit window before
            //     the next session can be created.  We wait 70 s to be safe.
            //  4. start-import returns 400 on an empty session; data must be uploaded first.
            //  5. Only CREATED/IN_PROGRESS sessions can be deleted; TRIGGERED/COMPLETED cannot.
            //     CleanupResources handles deletion failures gracefully (best-effort).

            // Shared upsert payload reused across phases.
            var upsertBody = new BulkUpsertRequestBody
            {
                EntityType = BulkUpsertRequestBody.EntityTypeEnum.USERS,
                Profiles =
                [
                    new BulkUpsertRequestBodyProfilesInner
                    {
                        ExternalId = "ext-user-001",
                        Profile = new IdentitySourceUserProfileForUpsert
                        {
                            Email    = "sdk-test-user-001@example.com",
                            FirstName = "SdkTest",
                            LastName  = "UserOne",
                            UserName  = "sdk-test-user-001@example.com"
                        }
                    }
                ]
            };

            var deleteDataBody = new BulkDeleteRequestBody
            {
                EntityType = BulkDeleteRequestBody.EntityTypeEnum.USERS,
                Profiles   = [new IdentitySourceUserProfileForDelete { ExternalId = "ext-user-stale-001" }]
            };

            string sessionIdA = null;
            string sessionIdB = null;
            string sessionIdC = null;
            string sessionIdD = null;

            try
            {
                // ===============================================================
                // PHASE 1 — Session A
                // Tests: CreateAsync (plain), GetAsync (plain + WithHttpInfo),
                //        ListSessions (plain + WithHttpInfo),
                //        UploadUpsert (plain + WithHttpInfo + null body),
                //        UploadDelete (plain + WithHttpInfo + null body),
                //        StartImportAsync (plain)
                // ===============================================================

                // CREATE (A) via CreateIdentitySourceSessionAsync (plain)
                //   POST /api/v1/identity-sources/{id}/sessions → 201
                var sessionA = await _identitySourceApi.CreateIdentitySourceSessionAsync(KnownIdentitySourceId);

                sessionA.Should().NotBeNull("a session should be returned on creation");
                sessionA.Id.Should().NotBeNullOrEmpty("session should have an ID");
                sessionA.IdentitySourceId.Should().Be(KnownIdentitySourceId,
                    "session should reference the correct identity source");
                sessionA.Status.Should().Be(IdentitySourceSessionStatus.CREATED,
                    "a newly created session must have status CREATED");
                sessionA.ImportType.Should().Be("INCREMENTAL",
                    "all sessions are incremental imports");
                sessionA.Created.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromMinutes(5),
                    "created timestamp should be recent");
                sessionA.LastUpdated.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromMinutes(5),
                    "lastUpdated timestamp should be recent");

                sessionIdA = sessionA.Id;
                _createdSessionIds.Add(sessionIdA);

                // GET (A) plain
                var fetchedA = await _identitySourceApi.GetIdentitySourceSessionAsync(KnownIdentitySourceId, sessionIdA);

                fetchedA.Should().NotBeNull();
                fetchedA.Id.Should().Be(sessionIdA);
                fetchedA.IdentitySourceId.Should().Be(KnownIdentitySourceId);
                fetchedA.Status.Should().Be(IdentitySourceSessionStatus.CREATED);
                fetchedA.ImportType.Should().Be("INCREMENTAL");

                // GET (A) WithHttpInfo → HTTP 200
                var fetchedAHttp = await _identitySourceApi.GetIdentitySourceSessionWithHttpInfoAsync(KnownIdentitySourceId, sessionIdA);

                fetchedAHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                fetchedAHttp.Data.Should().NotBeNull();
                fetchedAHttp.Data.Id.Should().Be(sessionIdA);
                fetchedAHttp.Data.IdentitySourceId.Should().Be(KnownIdentitySourceId);
                fetchedAHttp.Data.Status.Should().Be(IdentitySourceSessionStatus.CREATED);
                fetchedAHttp.Data.ImportType.Should().Be("INCREMENTAL");

                // LIST (plain collection) → contains A
                var sessionList = await _identitySourceApi.ListIdentitySourceSessions(KnownIdentitySourceId).ToListAsync();

                sessionList.Should().NotBeNull();
                sessionList.Should().Contain(s => s.Id == sessionIdA, "list should contain session A");
                foreach (var s in sessionList)
                {
                    s.IdentitySourceId.Should().Be(KnownIdentitySourceId);
                    s.Status.Should().NotBeNull();
                }

                // LIST WithHttpInfo → HTTP 200, contains A
                var listHttp = await _identitySourceApi.ListIdentitySourceSessionsWithHttpInfoAsync(KnownIdentitySourceId);

                listHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                listHttp.Data.Should().NotBeNull();
                listHttp.Data.Should().Contain(s => s.Id == sessionIdA);

                // UPLOAD UPSERT (plain) to A
                await _identitySourceApi.UploadIdentitySourceDataForUpsertAsync(KnownIdentitySourceId, sessionIdA, upsertBody);

                // UPLOAD UPSERT WithHttpInfo → HTTP 202
                var upsertHttpResponse = await _identitySourceApi.UploadIdentitySourceDataForUpsertWithHttpInfoAsync(
                    KnownIdentitySourceId, sessionIdA, upsertBody);

                upsertHttpResponse.StatusCode.Should().Be(HttpStatusCode.Accepted,
                    "bulk-upsert upload should return HTTP 202 Accepted");

                // UPLOAD DELETE (plain) to A
                await _identitySourceApi.UploadIdentitySourceDataForDeleteAsync(KnownIdentitySourceId, sessionIdA, deleteDataBody);

                // UPLOAD DELETE WithHttpInfo → HTTP 202
                var deleteDataHttpResponse = await _identitySourceApi.UploadIdentitySourceDataForDeleteWithHttpInfoAsync(
                    KnownIdentitySourceId, sessionIdA, deleteDataBody);

                deleteDataHttpResponse.StatusCode.Should().Be(HttpStatusCode.Accepted,
                    "bulk-delete upload should return HTTP 202 Accepted");

                // START IMPORT (plain) — session A has data uploaded; must not be empty
                //   POST /api/v1/identity-sources/{id}/sessions/{sessionId}/start-import → 200
                var triggeredA = await _identitySourceApi.StartImportFromIdentitySourceAsync(KnownIdentitySourceId, sessionIdA);

                triggeredA.Should().NotBeNull("start-import should return the updated session");
                triggeredA.Id.Should().Be(sessionIdA);
                triggeredA.IdentitySourceId.Should().Be(KnownIdentitySourceId);
                triggeredA.Status.Should().BeOneOf(
                    IdentitySourceSessionStatus.TRIGGERED,
                    IdentitySourceSessionStatus.INPROGRESS,
                    IdentitySourceSessionStatus.COMPLETED,
                    "session should transition away from CREATED after import is triggered");

                // Session A is now TRIGGERED — cannot be explicitly deleted.
                // CleanupResources will swallow the resulting ApiException (best-effort).

                // ---------------------------------------------------------------
                // COOLDOWN between phases
                // Triggering a session activates a ~60 s rate-limit on new session
                // creation.  Wait 70 s to ensure the window has fully elapsed.
                // ---------------------------------------------------------------
                await Task.Delay(TimeSpan.FromSeconds(70));

                // ===============================================================
                // PHASE 2 — Session B
                // Tests: CreateWithHttpInfoAsync (→ HTTP 201), StartImportWithHttpInfoAsync
                // ===============================================================

                // CREATE (B) via CreateIdentitySourceSessionWithHttpInfoAsync → HTTP 201 Created
                var createResponseB = await _identitySourceApi.CreateIdentitySourceSessionWithHttpInfoAsync(KnownIdentitySourceId);

                createResponseB.StatusCode.Should().Be(HttpStatusCode.Created,
                    "create session should return HTTP 201 Created");
                var sessionB = createResponseB.Data;
                sessionB.Should().NotBeNull();
                sessionB.Id.Should().NotBeNullOrEmpty();
                sessionB.IdentitySourceId.Should().Be(KnownIdentitySourceId);
                sessionB.Status.Should().Be(IdentitySourceSessionStatus.CREATED);
                sessionB.ImportType.Should().Be("INCREMENTAL");

                sessionIdB = sessionB.Id;
                _createdSessionIds.Add(sessionIdB);

                // Upload data to B (required before start-import)
                await _identitySourceApi.UploadIdentitySourceDataForUpsertAsync(KnownIdentitySourceId, sessionIdB, upsertBody);

                // START IMPORT WithHttpInfo — session B has data uploaded
                //   POST /api/v1/identity-sources/{id}/sessions/{sessionId}/start-import → 200
                var triggeredBHttp = await _identitySourceApi.StartImportFromIdentitySourceWithHttpInfoAsync(
                    KnownIdentitySourceId, sessionIdB);

                triggeredBHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                triggeredBHttp.Data.Should().NotBeNull();
                triggeredBHttp.Data.Id.Should().Be(sessionIdB);
                triggeredBHttp.Data.IdentitySourceId.Should().Be(KnownIdentitySourceId);
                triggeredBHttp.Data.Status.Should().BeOneOf(
                    IdentitySourceSessionStatus.TRIGGERED,
                    IdentitySourceSessionStatus.INPROGRESS,
                    IdentitySourceSessionStatus.COMPLETED,
                    "session B should transition away from CREATED after import is triggered");

                // Session B is now TRIGGERED — cleanup handles gracefully.

                // ---------------------------------------------------------------
                // Second cooldown before creating sessions C and D
                // ---------------------------------------------------------------
                await Task.Delay(TimeSpan.FromSeconds(70));

                // ===============================================================
                // PHASE 3 — Sessions C and D
                // Tests: DeleteWithHttpInfoAsync (→ 204), DeleteAsync (plain, void),
                //        404 scenarios for GET and DELETE
                // Sessions C and D are created in CREATED state and deleted immediately
                // (never triggered), so no additional cooldown is required between them.
                // ===============================================================

                // CREATE (C) — for DeleteWithHttpInfoAsync test
                var sessionC = await _identitySourceApi.CreateIdentitySourceSessionAsync(KnownIdentitySourceId);

                sessionC.Should().NotBeNull();
                sessionC.Id.Should().NotBeNullOrEmpty();
                sessionC.Status.Should().Be(IdentitySourceSessionStatus.CREATED);

                sessionIdC = sessionC.Id;
                _createdSessionIds.Add(sessionIdC);

                // DELETE (C) via DeleteIdentitySourceSessionWithHttpInfoAsync → HTTP 204
                var deleteCHttp = await _identitySourceApi.DeleteIdentitySourceSessionWithHttpInfoAsync(
                    KnownIdentitySourceId, sessionIdC);

                deleteCHttp.StatusCode.Should().Be(HttpStatusCode.NoContent,
                    "delete session should return HTTP 204 No Content");
                _createdSessionIds.Remove(sessionIdC);

                // GET C after delete → 200 with status CLOSED
                // (The API does not remove the session record; it transitions it to CLOSED.)
                var fetchedCAfterDelete = await _identitySourceApi.GetIdentitySourceSessionAsync(KnownIdentitySourceId, sessionIdC);
                fetchedCAfterDelete.Should().NotBeNull();
                fetchedCAfterDelete.Id.Should().Be(sessionIdC);
                fetchedCAfterDelete.IdentitySourceId.Should().Be(KnownIdentitySourceId);
                fetchedCAfterDelete.Status.Should().Be(IdentitySourceSessionStatus.CLOSED,
                    "a deleted session transitions to CLOSED status");

                // DELETE C again (plain) → 400 ApiException (session is CLOSED, not deletable)
                Func<Task> deleteCAgainPlain = async () =>
                    await _identitySourceApi.DeleteIdentitySourceSessionAsync(KnownIdentitySourceId, sessionIdC);
                (await deleteCAgainPlain.Should().ThrowAsync<ApiException>())
                    .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest,
                        "re-deleting a CLOSED session should return HTTP 400");

                // DELETE C again (WithHttpInfo) → 400 ApiException
                Func<Task> deleteCAgainHttp = async () =>
                    await _identitySourceApi.DeleteIdentitySourceSessionWithHttpInfoAsync(KnownIdentitySourceId, sessionIdC);
                (await deleteCAgainHttp.Should().ThrowAsync<ApiException>())
                    .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest,
                        "re-deleting a CLOSED session should return HTTP 400");

                // GET completely unknown session → 404
                Func<Task> unknownGet = async () =>
                    await _identitySourceApi.GetIdentitySourceSessionAsync(KnownIdentitySourceId, "no-such-session-id");
                (await unknownGet.Should().ThrowAsync<ApiException>())
                    .Which.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

                // CREATE (D) — for DeleteAsync (plain, void) test
                // C was deleted in CREATED state (never triggered) so no cooldown is needed.
                var sessionD = await _identitySourceApi.CreateIdentitySourceSessionAsync(KnownIdentitySourceId);

                sessionD.Should().NotBeNull();
                sessionD.Id.Should().NotBeNullOrEmpty();
                sessionD.Status.Should().Be(IdentitySourceSessionStatus.CREATED);

                sessionIdD = sessionD.Id;
                _createdSessionIds.Add(sessionIdD);

                // DELETE (D) via DeleteIdentitySourceSessionAsync (plain, void) — should not throw
                await _identitySourceApi.DeleteIdentitySourceSessionAsync(KnownIdentitySourceId, sessionIdD);
                _createdSessionIds.Remove(sessionIdD);

                // GET D after delete → 200 CLOSED (WithHttpInfo path)
                // Same behaviour as C: the record persists with status CLOSED.
                var fetchedDAfterDelete = await _identitySourceApi.GetIdentitySourceSessionWithHttpInfoAsync(KnownIdentitySourceId, sessionIdD);
                fetchedDAfterDelete.StatusCode.Should().Be(HttpStatusCode.OK);
                fetchedDAfterDelete.Data.Should().NotBeNull();
                fetchedDAfterDelete.Data.Id.Should().Be(sessionIdD);
                fetchedDAfterDelete.Data.IdentitySourceId.Should().Be(KnownIdentitySourceId);
                fetchedDAfterDelete.Data.Status.Should().Be(IdentitySourceSessionStatus.CLOSED,
                    "a deleted session transitions to CLOSED status");

                // DELETE D again (WithHttpInfo) → 400 (CLOSED session not deletable)
                Func<Task> deleteDAgainHttp = async () =>
                    await _identitySourceApi.DeleteIdentitySourceSessionWithHttpInfoAsync(KnownIdentitySourceId, sessionIdD);
                (await deleteDAgainHttp.Should().ThrowAsync<ApiException>())
                    .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest,
                        "re-deleting a CLOSED session should return HTTP 400");
            }
            finally
            {
                // best-effort cleanup of any remaining sessions
                await CleanupResources();
            }
        }
    }
}
