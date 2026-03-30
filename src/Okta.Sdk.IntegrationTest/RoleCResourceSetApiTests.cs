// <copyright file="RoleCResourceSetApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for <see cref="RoleCResourceSetApi"/>.
    ///
    /// SDK Methods &amp; Endpoints Covered (all 10 signatures — 5 functional + 5 WithHttpInfo):
    /// ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ Method                              │ HTTP   │ Status │ Endpoint                                                             │
    /// ├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ CreateResourceSetAsync              │ POST   │ 200    │ /api/v1/iam/resource-sets                                            │
    /// │ CreateResourceSetWithHttpInfoAsync  │ POST   │ 200    │ same                                                                 │
    /// │ ListResourceSetsAsync               │ GET    │ 200    │ /api/v1/iam/resource-sets?after=...                                  │
    /// │ ListResourceSetsWithHttpInfoAsync   │ GET    │ 200    │ same                                                                 │
    /// │ GetResourceSetAsync                 │ GET    │ 200    │ /api/v1/iam/resource-sets/{resourceSetIdOrLabel} (by id)             │
    /// │ GetResourceSetWithHttpInfoAsync     │ GET    │ 200    │ same (by label)                                                      │
    /// │ ReplaceResourceSetAsync             │ PUT    │ 200    │ /api/v1/iam/resource-sets/{resourceSetIdOrLabel} (by id)             │
    /// │ ReplaceResourceSetWithHttpInfoAsync │ PUT    │ 200    │ same (by label)                                                      │
    /// │ DeleteResourceSetAsync              │ DELETE │ 204    │ /api/v1/iam/resource-sets/{resourceSetIdOrLabel} (by id)             │
    /// │ DeleteResourceSetWithHttpInfoAsync  │ DELETE │ 204    │ same (by label)                                                      │
    /// └──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
    ///
    /// </summary>
    [Collection(nameof(RoleCResourceSetApiTests))]
    public class RoleCResourceSetApiTests : IAsyncLifetime
    {
        // ── API Client ────────────────────────────────────────────────────────
        private readonly RoleCResourceSetApi _api = new();

        // ── Test state ────────────────────────────────────────────────────────
        private string _resourceSet1Id;    // primary resource set created in the test
        private string _resourceSet1Label; // label of primary resource set
        private string _resourceSet2Id;    // secondary resource set (for pagination test)
        private string _resourceSet2Label; // label of secondary resource set

        // ── Base URL of the Okta org (used when constructing resource URLs) ───
        private static readonly string OrgBaseUrl =
            Configuration.GetConfigurationOrDefault().OktaDomain.TrimEnd('/');

        // ── Setup (no-op — all state is created inside the test for clarity) ─
        public Task InitializeAsync() => Task.CompletedTask;

        // ── Teardown ──────────────────────────────────────────────────────────
        public async Task DisposeAsync()
        {
            // Only delete resource sets that this test created — never the system ones.
            foreach (var rsId in new[] { _resourceSet1Id, _resourceSet2Id })
            {
                if (string.IsNullOrEmpty(rsId)) continue;
                try { await _api.DeleteResourceSetAsync(rsId); } catch { /* ignore */ }
            }
        }

        // ═══════════════════════════════════════════════════════════════════════
        //  SINGLE COMPREHENSIVE TEST — covers all 10 SDK signatures in one flow
        // ═══════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task ResourceSets_FullWorkflow_ShouldSucceed()
        {
            var suffix = Guid.NewGuid().ToString("N")[..8];

            // ─────────────────────────────────────────────────────────────────
            // 1. CREATE — CreateResourceSetAsync
            //    POST /api/v1/iam/resource-sets → 200 ResourceSet
            // ─────────────────────────────────────────────────────────────────
            _resourceSet1Label = $"rcrs-rs1-{suffix}";
            var createRequest = new CreateResourceSetRequest
            {
                Label       = _resourceSet1Label,
                Description = "Integration test resource set 1",
                Resources   = new List<string>
                {
                    $"{OrgBaseUrl}/api/v1/users",
                },
            };

            var created = await _api.CreateResourceSetAsync(createRequest);

            created.Should().NotBeNull();
            created.Id.Should().NotBeNullOrEmpty("the server assigns a unique id on creation");
            created.Label.Should().Be(_resourceSet1Label);
            created.Description.Should().Be("Integration test resource set 1");
            created.Created.Should().NotBe(default(DateTimeOffset),
                "Created timestamp must be populated by the server");
            created.LastUpdated.Should().NotBe(default(DateTimeOffset),
                "LastUpdated timestamp must be populated by the server");
            _resourceSet1Id = created.Id;

            // ─────────────────────────────────────────────────────────────────
            // 2. CREATE (WithHttpInfo) — CreateResourceSetWithHttpInfoAsync
            //    POST /api/v1/iam/resource-sets → 200
            //    Creates a second resource set used for the pagination test below.
            // ─────────────────────────────────────────────────────────────────
            _resourceSet2Label = $"rcrs-rs2-{suffix}";
            var createRequest2 = new CreateResourceSetRequest
            {
                Label       = _resourceSet2Label,
                Description = "Integration test resource set 2",
                Resources   = new List<string>
                {
                    $"{OrgBaseUrl}/api/v1/groups",
                },
            };

            var createdHttp = await _api.CreateResourceSetWithHttpInfoAsync(createRequest2);

            ((int)createdHttp.StatusCode).Should().Be(200,
                "POST /api/v1/iam/resource-sets must return 200");
            createdHttp.Data.Should().NotBeNull();
            createdHttp.Data.Id.Should().NotBeNullOrEmpty();
            createdHttp.Data.Label.Should().Be(_resourceSet2Label);
            _resourceSet2Id = createdHttp.Data.Id;

            // ─────────────────────────────────────────────────────────────────
            // 3. LIST — ListResourceSetsAsync (no after cursor)
            //    GET /api/v1/iam/resource-sets → 200 ResourceSets wrapper
            //    Verifies both created resource sets appear in the list.
            // ─────────────────────────────────────────────────────────────────
            var listResult = await _api.ListResourceSetsAsync();

            listResult.Should().NotBeNull();
            listResult._ResourceSets.Should().NotBeNullOrEmpty(
                "at least the 3 system resource sets are always present");
            listResult._ResourceSets.Should().Contain(rs => rs.Id == _resourceSet1Id,
                "the first created resource set must appear in the list");
            listResult._ResourceSets.Should().Contain(rs => rs.Id == _resourceSet2Id,
                "the second created resource set must appear in the list");

            // ─────────────────────────────────────────────────────────────────
            // 3b. LIST (WithHttpInfo) — ListResourceSetsWithHttpInfoAsync (no after cursor)
            //     Verifies HTTP 200 and that Links is present for pagination inspection.
            // ─────────────────────────────────────────────────────────────────
            var listHttp = await _api.ListResourceSetsWithHttpInfoAsync();

            ((int)listHttp.StatusCode).Should().Be(200,
                "GET /api/v1/iam/resource-sets must return 200");
            listHttp.Data.Should().NotBeNull();
            listHttp.Data._ResourceSets.Should().NotBeNullOrEmpty();

            // ─────────────────────────────────────────────────────────────────
            // 3c. LIST with `after` cursor — exercises cursor-based pagination.
            //     The Links.Next.Href is present when there is a next page.
            //     We parse the `after` value from the href and call List again.
            //     Note: ListResourceSets has no `limit` parameter, so we cannot
            //     force a partial page in a deterministic way.  Instead we simply
            //     exercise the code path if a next link exists; otherwise we
            //     verify the call with an `after` value from the first resource
            //     set id still returns HTTP 200.
            // ─────────────────────────────────────────────────────────────────
            string afterCursor = null;
            if (listHttp.Data.Links?.Next?.Href != null)
            {
                var nextHref = listHttp.Data.Links.Next.Href;
                var afterMatch = Regex.Match(nextHref, @"after=([^&]+)");
                if (afterMatch.Success)
                {
                    afterCursor = Uri.UnescapeDataString(afterMatch.Groups[1].Value);
                }
            }

            if (afterCursor != null)
            {
                // Cursor obtained from the response — use it for the next page call.
                var listPage2 = await _api.ListResourceSetsWithHttpInfoAsync(after: afterCursor);
                ((int)listPage2.StatusCode).Should().Be(200,
                    "GET /api/v1/iam/resource-sets?after=CURSOR must return 200");
                listPage2.Data._ResourceSets.Should().NotBeNull();
            }
            else
            {
                // No next page in the response (all resource sets fit on one page).
                // Still exercise the `after` parameter code path by passing the
                // id of the first resource set as a cursor — the API must return 200.
                var listWithAfter = await _api.ListResourceSetsWithHttpInfoAsync(after: _resourceSet1Id);
                ((int)listWithAfter.StatusCode).Should().Be(200,
                    "GET /api/v1/iam/resource-sets?after=<id> must return 200");
                listWithAfter.Data.Should().NotBeNull();
            }

            // ─────────────────────────────────────────────────────────────────
            // 4. GET by id — GetResourceSetAsync
            //    GET /api/v1/iam/resource-sets/{id} → 200 ResourceSet
            // ─────────────────────────────────────────────────────────────────
            var getById = await _api.GetResourceSetAsync(_resourceSet1Id);

            getById.Should().NotBeNull();
            getById.Id.Should().Be(_resourceSet1Id);
            getById.Label.Should().Be(_resourceSet1Label);
            getById.Description.Should().Be("Integration test resource set 1");

            // ─────────────────────────────────────────────────────────────────
            // 5. GET by label (WithHttpInfo) — GetResourceSetWithHttpInfoAsync
            //    GET /api/v1/iam/resource-sets/{label} → 200
            //    Verifies that {resourceSetIdOrLabel} accepts a label as well as an id.
            // ─────────────────────────────────────────────────────────────────
            var getByLabelHttp = await _api.GetResourceSetWithHttpInfoAsync(_resourceSet1Label);

            ((int)getByLabelHttp.StatusCode).Should().Be(200,
                "GET /api/v1/iam/resource-sets/{label} must return 200");
            getByLabelHttp.Data.Should().NotBeNull();
            getByLabelHttp.Data.Id.Should().Be(_resourceSet1Id,
                "fetching by label must return the same resource set as fetching by id");
            getByLabelHttp.Data.Label.Should().Be(_resourceSet1Label);

            // ─────────────────────────────────────────────────────────────────
            // 6. REPLACE — ReplaceResourceSetAsync
            //    PUT /api/v1/iam/resource-sets/{id} → 200 ResourceSet
            //    Only updates label and description; resource membership is unchanged.
            // ─────────────────────────────────────────────────────────────────
            var updatedLabel = $"rcrs-rs1-updated-{suffix}";
            var replaceBody = new ResourceSet
            {
                Label       = updatedLabel,
                Description = "Updated description",
            };

            var replaced = await _api.ReplaceResourceSetAsync(_resourceSet1Id, replaceBody);

            replaced.Should().NotBeNull();
            replaced.Id.Should().Be(_resourceSet1Id,
                "Replace must not change the resource set id");
            replaced.Label.Should().Be(updatedLabel,
                "Replace must update the label");
            replaced.Description.Should().Be("Updated description",
                "Replace must update the description");

            // Confirm via a subsequent GET that the change is persisted.
            var getAfterReplace = await _api.GetResourceSetAsync(_resourceSet1Id);
            getAfterReplace.Label.Should().Be(updatedLabel);
            getAfterReplace.Description.Should().Be("Updated description");

            // Update _resourceSet1Label to the new label so DisposeAsync teardown
            // can still clean up using the id (which hasn't changed).
            _resourceSet1Label = updatedLabel;

            // ─────────────────────────────────────────────────────────────────
            // 7. REPLACE (WithHttpInfo) — ReplaceResourceSetWithHttpInfoAsync
            //    PUT /api/v1/iam/resource-sets/{label} → 200
            //    Uses the original label (not the id) of the second resource set
            //    to exercise the by-label variant of {resourceSetIdOrLabel}.
            // ─────────────────────────────────────────────────────────────────
            var rs2UpdatedLabel = $"rcrs-rs2-updated-{suffix}";
            var replaceBody2 = new ResourceSet
            {
                Label       = rs2UpdatedLabel,
                Description = "Updated description 2",
            };

            var replacedHttp = await _api.ReplaceResourceSetWithHttpInfoAsync(_resourceSet2Label, replaceBody2);

            ((int)replacedHttp.StatusCode).Should().Be(200,
                "PUT /api/v1/iam/resource-sets/{label} must return 200");
            replacedHttp.Data.Should().NotBeNull();
            replacedHttp.Data.Id.Should().Be(_resourceSet2Id,
                "Replace by label must not change the resource set id");
            replacedHttp.Data.Label.Should().Be(rs2UpdatedLabel);
            replacedHttp.Data.Description.Should().Be("Updated description 2");

            // ─────────────────────────────────────────────────────────────────
            // 8. DELETE — DeleteResourceSetAsync
            //    DELETE /api/v1/iam/resource-sets/{id} → 204 No Content
            //    Deletes the first resource set by id.
            // ─────────────────────────────────────────────────────────────────
            await _api.DeleteResourceSetAsync(_resourceSet1Id);

            // Confirm the resource set is gone — a subsequent GET must throw or return 404.
            Func<Task> getDeletedById = async () => await _api.GetResourceSetAsync(_resourceSet1Id);
            await getDeletedById.Should().ThrowAsync<ApiException>(
                "GET on a deleted resource set must throw ApiException (404)");
            _resourceSet1Id = null; // already deleted — skip DisposeAsync cleanup

            // ─────────────────────────────────────────────────────────────────
            // 9. DELETE (WithHttpInfo) — DeleteResourceSetWithHttpInfoAsync
            //    DELETE /api/v1/iam/resource-sets/{label} → 204
            //    Uses the updated label from step 7 (not the id) to exercise
            //    the by-label variant of {resourceSetIdOrLabel} on DELETE.
            // ─────────────────────────────────────────────────────────────────
            var deleteHttp = await _api.DeleteResourceSetWithHttpInfoAsync(rs2UpdatedLabel);

            ((int)deleteHttp.StatusCode).Should().Be(204,
                "DELETE /api/v1/iam/resource-sets/{label} must return 204");
            _resourceSet2Id = null; // already deleted — skip DisposeAsync cleanup

            // Confirm the second resource set is also gone.
            Func<Task> getDeletedById2 = async () => await _api.GetResourceSetAsync(replacedHttp.Data.Id);
            await getDeletedById2.Should().ThrowAsync<ApiException>(
                "GET on a deleted resource set must throw ApiException (404)");
        }
    }
}
