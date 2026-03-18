// <copyright file="RoleCResourceSetResourceApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for <see cref="RoleCResourceSetResourceApi"/>.
    ///
    /// SDK Methods &amp; Endpoints Covered (all 12 signatures — 6 functional + 6 WithHttpInfo):
    /// ┌────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ Method                                       │ HTTP   │ Status │ Endpoint                                                              │
    /// ├────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ ListResourceSetResourcesAsync                │ GET    │ 200    │ /api/v1/iam/resource-sets/{rsId}/resources (by id)                    │
    /// │ ListResourceSetResourcesWithHttpInfoAsync    │ GET    │ 200    │ same (by label — label routing confirmed working)                     │
    /// │ AddResourceSetResourcesAsync                 │ PATCH  │ 200    │ /api/v1/iam/resource-sets/{rsId}/resources                            │
    /// │ AddResourceSetResourcesWithHttpInfoAsync     │ PATCH  │ 200    │ same (by label, idempotent re-add)                                    │
    /// │ AddResourceSetResourceAsync                  │ POST   │ 200    │ /api/v1/iam/resource-sets/{rsId}/resources                            │
    /// │ AddResourceSetResourceWithHttpInfoAsync      │ POST   │ 200    │ same (by label, after prior DELETE freed the slot)                    │
    /// │ GetResourceSetResourceAsync                  │ GET    │ 200    │ /api/v1/iam/resource-sets/{rsId}/resources/{resourceId}               │
    /// │ GetResourceSetResourceWithHttpInfoAsync      │ GET    │ 200    │ same                                                                  │
    /// │ ReplaceResourceSetResourceAsync              │ PUT    │ 200    │ /api/v1/iam/resource-sets/{rsId}/resources/{resourceId}               │
    /// │ ReplaceResourceSetResourceWithHttpInfoAsync  │ PUT    │ 200    │ same (by id — label routing not supported for PUT)                    │
    /// │ DeleteResourceSetResourceAsync               │ DELETE │ 204    │ /api/v1/iam/resource-sets/{rsId}/resources/{resourceId}               │
    /// │ DeleteResourceSetResourceWithHttpInfoAsync   │ DELETE │ 204    │ same (by label)                                                       │
    /// └────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
    ///
    /// </summary>
    [Collection(nameof(RoleCResourceSetResourceApiTests))]
    public class RoleCResourceSetResourceApiTests : IAsyncLifetime
    {
        // ── API clients ───────────────────────────────────────────────────────
        private readonly RoleCResourceSetResourceApi _api = new();
        private readonly RoleCResourceSetApi _rsApi = new();

        // ── Fixture state (parent resource set) ───────────────────────────────
        private string _resourceSetId;
        private string _resourceSetLabel;

        // ── Org base URL ──────────────────────────────────────────────────────
        private static readonly string OrgBaseUrl =
            Configuration.GetConfigurationOrDefault().OktaDomain.TrimEnd('/');

        // ── Setup ─────────────────────────────────────────────────────────────
        public async Task InitializeAsync()
        {
            var suffix = new Random().Next(100_000_000, 999_999_999).ToString();
            _resourceSetLabel = $"rcrsr-rs-{suffix}";

            var created = await _rsApi.CreateResourceSetAsync(new CreateResourceSetRequest
            {
                Label       = _resourceSetLabel,
                Description = "Integration test — RoleCResourceSetResourceApi",
                Resources   = new List<string> { $"{OrgBaseUrl}/api/v1/users" },
            });

            _resourceSetId = created.Id;
        }

        // ── Teardown ──────────────────────────────────────────────────────────
        public async Task DisposeAsync()
        {
            if (!string.IsNullOrEmpty(_resourceSetId))
            {
                try { await _rsApi.DeleteResourceSetAsync(_resourceSetId); } catch { /* ignore */ }
            }
        }

        // ═════════════════════════════════════════════════════════════════════
        //  SINGLE COMPREHENSIVE TEST — covers all 12 SDK signatures in one flow
        // ═════════════════════════════════════════════════════════════════════

        [Fact]
        public async Task ResourceSetResources_FullWorkflow_ShouldSucceed()
        {
            // ─────────────────────────────────────────────────────────────────
            // Step 1 — ListResourceSetResourcesAsync (GET /resources by id)
            //   The resource set was created with /api/v1/users, so exactly
            //   one resource entry should be present.
            // ─────────────────────────────────────────────────────────────────
            var list1 = await _api.ListResourceSetResourcesAsync(_resourceSetId);

            list1.Should().NotBeNull();
            list1.Resources.Should().HaveCount(1,
                "the resource set was seeded with exactly one resource (/api/v1/users)");
            list1.Resources[0].Id.Should().NotBeNullOrEmpty(
                "the server assigns a unique id to every resource entry");
            list1.Resources[0].Orn.Should().NotBeNullOrEmpty(
                "every resource entry carries an Okta Resource Name");
            list1.Resources[0].Created.Should().NotBe(default(DateTimeOffset),
                "Created timestamp must be set by the server");

            // ─────────────────────────────────────────────────────────────────
            // Step 2 — AddResourceSetResourcesAsync (PATCH /resources by id)
            //   Bulk-add /api/v1/groups (no conditions).
            //   Response is the PARENT ResourceSet (not the resources list).
            // ─────────────────────────────────────────────────────────────────
            var patchResult = await _api.AddResourceSetResourcesAsync(
                _resourceSetId,
                new ResourceSetResourcePatchRequest
                {
                    Additions = new List<string> { $"{OrgBaseUrl}/api/v1/groups" },
                });

            patchResult.Should().NotBeNull();
            patchResult.Id.Should().Be(_resourceSetId,
                "PATCH returns the parent ResourceSet — id must match the fixture");
            patchResult.Label.Should().Be(_resourceSetLabel);

            // ─────────────────────────────────────────────────────────────────
            // Step 3 — ListResourceSetResourcesWithHttpInfoAsync (GET by LABEL)
            //   Use the resource set label instead of id to verify label routing
            //   works for the list endpoint.  After adding groups (Step 2) there
            //   should be two resources.  Also assert _links in the response:
            //     • Links.ResourceSet.Href — the parent RS self link
            //     • Links.Next             — null when the page is complete
            //   Save the server-assigned id of the groups entry for later.
            // ─────────────────────────────────────────────────────────────────
            var list2Http = await _api.ListResourceSetResourcesWithHttpInfoAsync(_resourceSetLabel);

            ((int)list2Http.StatusCode).Should().Be(200,
                "GET /resources (by label) must return HTTP 200");
            list2Http.Data.Should().NotBeNull();
            list2Http.Data.Resources.Should().HaveCount(2,
                "users (seeded at creation) + groups (added via PATCH) = 2 resources");

            // Verify _links: resource-set href points back to the parent RS
            list2Http.Data.Links.Should().NotBeNull("_links must be present in the list response");
            list2Http.Data.Links.ResourceSet.Should().NotBeNull(
                "_links.resource-set must be present (link back to the parent resource set)");
            list2Http.Data.Links.ResourceSet.Href.Should().Contain(_resourceSetId,
                "_links.resource-set href must reference the parent resource set id");
            list2Http.Data.Links.Next.Should().BeNull(
                "_links.next must be absent when all resources fit on one page");

            var groupsEntry = list2Http.Data.Resources
                .FirstOrDefault(r => r.Orn != null &&
                                     r.Orn.EndsWith(":groups", StringComparison.OrdinalIgnoreCase));
            groupsEntry.Should().NotBeNull("the groups resource must appear in the list");
            var groupsResourceId = groupsEntry!.Id;

            // ─────────────────────────────────────────────────────────────────
            // Step 4 — AddResourceSetResourcesWithHttpInfoAsync (PATCH by label)
            //   Re-adding an already-present resource is idempotent; the API
            //   must return HTTP 200 with the parent ResourceSet.
            // ─────────────────────────────────────────────────────────────────
            var patchHttpResult = await _api.AddResourceSetResourcesWithHttpInfoAsync(
                _resourceSetLabel,
                new ResourceSetResourcePatchRequest
                {
                    Additions = new List<string> { $"{OrgBaseUrl}/api/v1/groups" },
                });

            ((int)patchHttpResult.StatusCode).Should().Be(200,
                "PATCH /resources (idempotent re-add by label) must return HTTP 200");
            patchHttpResult.Data.Should().NotBeNull();
            patchHttpResult.Data.Id.Should().Be(_resourceSetId,
                "PATCH by label must return the same parent ResourceSet");

            // ─────────────────────────────────────────────────────────────────
            // Step 5 — AddResourceSetResourceAsync (POST /resources by id)
            //   Add /api/v1/apps as a conditioned resource (Exclude = empty set).
            //   Response is the newly created ResourceSetResource with a
            //   server-assigned id.
            // ─────────────────────────────────────────────────────────────────
            var postResult = await _api.AddResourceSetResourceAsync(
                _resourceSetId,
                new ResourceSetResourcePostRequest
                {
                    ResourceOrnOrUrl = $"{OrgBaseUrl}/api/v1/apps",
                    Conditions       = new ResourceConditions
                    {
                        Exclude = new ResourceConditionsExclude(),
                    },
                });

            postResult.Should().NotBeNull();
            postResult.Id.Should().NotBeNullOrEmpty(
                "POST returns a ResourceSetResource with a server-assigned id");
            postResult.Orn.Should().Contain("apps",
                "the ORN must reflect the /api/v1/apps resource");
            postResult.Created.Should().NotBe(default(DateTimeOffset),
                "Created timestamp must be populated by the server");
            postResult.LastUpdated.Should().NotBe(default(DateTimeOffset),
                "LastUpdated timestamp must be populated by the server");
            var appsResourceId = postResult.Id;

            // ─────────────────────────────────────────────────────────────────
            // Step 6 — GetResourceSetResourceAsync (GET /resources/{id} by RS id)
            //   Retrieve the apps resource entry and verify its fields.
            // ─────────────────────────────────────────────────────────────────
            var getResult = await _api.GetResourceSetResourceAsync(_resourceSetId, appsResourceId);

            getResult.Should().NotBeNull();
            getResult.Id.Should().Be(appsResourceId,
                "GET must return the correct resource entry");
            getResult.Orn.Should().Contain("apps");
            getResult.Created.Should().NotBe(default(DateTimeOffset));

            // ─────────────────────────────────────────────────────────────────
            // Step 7 — GetResourceSetResourceWithHttpInfoAsync (GET by id)
            //   Same resource, WithHttpInfo variant — verify status code.
            // ─────────────────────────────────────────────────────────────────
            var getHttpResult = await _api.GetResourceSetResourceWithHttpInfoAsync(
                _resourceSetId, appsResourceId);

            ((int)getHttpResult.StatusCode).Should().Be(200,
                "GET /resources/{id} must return HTTP 200");
            getHttpResult.Data.Id.Should().Be(appsResourceId);

            // ─────────────────────────────────────────────────────────────────
            // Step 8 — ReplaceResourceSetResourceAsync (PUT /resources/{id} by RS id)
            //   Replace the conditions on the apps resource.
            //   The id and ORN are immutable; only conditions can change.
            // ─────────────────────────────────────────────────────────────────
            var putResult = await _api.ReplaceResourceSetResourceAsync(
                _resourceSetId,
                appsResourceId,
                new ResourceSetResourcePutRequest
                {
                    Conditions = new ResourceConditions
                    {
                        Exclude = new ResourceConditionsExclude(),
                    },
                });

            putResult.Should().NotBeNull();
            putResult.Id.Should().Be(appsResourceId,
                "PUT must not change the resource entry id");
            putResult.Orn.Should().Contain("apps",
                "PUT must not change the ORN");

            // ─────────────────────────────────────────────────────────────────
            // Step 9 — ReplaceResourceSetResourceWithHttpInfoAsync (PUT by id, WithHttpInfo)
            //   Label routing is NOT supported for PUT /resources/{resourceId} (returns 404).
            //   Use the RS id — this exercises the WithHttpInfo code path.
            // ─────────────────────────────────────────────────────────────────
            var putHttpResult = await _api.ReplaceResourceSetResourceWithHttpInfoAsync(
                _resourceSetId,
                appsResourceId,
                new ResourceSetResourcePutRequest
                {
                    Conditions = new ResourceConditions
                    {
                        Exclude = new ResourceConditionsExclude(),
                    },
                });

            ((int)putHttpResult.StatusCode).Should().Be(200,
                "PUT /resources/{id} (WithHttpInfo) must return HTTP 200");
            putHttpResult.Data.Id.Should().Be(appsResourceId,
                "PUT must not change the resource entry id");

            // ─────────────────────────────────────────────────────────────────
            // Step 10 — DeleteResourceSetResourceAsync (DELETE by RS id)
            //   Remove the groups resource entry; a subsequent GET must throw.
            // ─────────────────────────────────────────────────────────────────
            await _api.DeleteResourceSetResourceAsync(_resourceSetId, groupsResourceId);

            Func<Task> getDeletedGroups = async () =>
                await _api.GetResourceSetResourceAsync(_resourceSetId, groupsResourceId);
            await getDeletedGroups.Should().ThrowAsync<ApiException>(
                "GET on a deleted resource entry must throw ApiException (404)");

            // ─────────────────────────────────────────────────────────────────
            // Step 11 — AddResourceSetResourceWithHttpInfoAsync (POST by label)
            //   Re-add groups with conditions now that the bare entry was
            //   deleted in Step 10, so there is no conflict.
            //   Save the new server-assigned id for the DELETE test below.
            // ─────────────────────────────────────────────────────────────────
            var postHttpResult = await _api.AddResourceSetResourceWithHttpInfoAsync(
                _resourceSetLabel,
                new ResourceSetResourcePostRequest
                {
                    ResourceOrnOrUrl = $"{OrgBaseUrl}/api/v1/groups",
                    Conditions       = new ResourceConditions
                    {
                        Exclude = new ResourceConditionsExclude(),
                    },
                });

            ((int)postHttpResult.StatusCode).Should().Be(200,
                "POST /resources (by label) must return HTTP 200");
            postHttpResult.Data.Should().NotBeNull();
            postHttpResult.Data.Id.Should().NotBeNullOrEmpty(
                "POST must return a ResourceSetResource with a server-assigned id");
            postHttpResult.Data.Orn.Should().Contain("groups",
                "the ORN must reflect the /api/v1/groups resource");
            var groups2ResourceId = postHttpResult.Data.Id;

            // ─────────────────────────────────────────────────────────────────
            // Step 12 — DeleteResourceSetResourceWithHttpInfoAsync (DELETE by label)
            //   Remove the re-added groups entry; response must be HTTP 204.
            // ─────────────────────────────────────────────────────────────────
            var deleteHttpResult = await _api.DeleteResourceSetResourceWithHttpInfoAsync(
                _resourceSetLabel, groups2ResourceId);

            ((int)deleteHttpResult.StatusCode).Should().Be(204,
                "DELETE /resources/{id} must return HTTP 204 No Content");
        }
    }
}
