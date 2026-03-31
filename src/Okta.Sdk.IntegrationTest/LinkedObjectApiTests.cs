// <copyright file="LinkedObjectApiTests.cs" company="Okta, Inc">
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
    [Collection(nameof(LinkedObjectApiTests))]
    public class LinkedObjectApiTests : IDisposable
    {
        private readonly LinkedObjectApi _linkedObjectApi = new();
        private readonly List<string> _createdLinkedObjectNames = [];

        public void Dispose()
        {
            CleanupResources().GetAwaiter().GetResult();
        }

        private async Task CleanupResources()
        {
            foreach (var linkedObjectName in _createdLinkedObjectNames)
            {
                try
                {
                    await _linkedObjectApi.DeleteLinkedObjectDefinitionAsync(linkedObjectName);
                }
                catch (ApiException)
                {
                    // best-effort cleanup
                }
            }

            _createdLinkedObjectNames.Clear();
        }

        [Fact]
        public async Task GivenLinkedObjectDefinitions_WhenPerformingCrudOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guidA = Guid.NewGuid().ToString("N");
            var guidB = Guid.NewGuid().ToString("N");

            // Definition A  – primary/associated names for the first pair
            var primaryNameA   = $"mgra{guidA}";
            var associatedNameA = $"suba{guidA}";

            // Definition B  – second independent pair
            var primaryNameB   = $"mgrb{guidB}";
            var associatedNameB = $"subb{guidB}";

            // ---------------------------------------------------------------
            // CLIENT-SIDE NULL-PARAMETER VALIDATION (400 thrown before any HTTP call)
            // ---------------------------------------------------------------

            // CreateLinkedObjectDefinitionAsync – null body
            var nullCreate = async () => await _linkedObjectApi.CreateLinkedObjectDefinitionAsync(null);
            (await nullCreate.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            // CreateLinkedObjectDefinitionWithHttpInfoAsync – null body
            var nullCreateHttp = async () => await _linkedObjectApi.CreateLinkedObjectDefinitionWithHttpInfoAsync(null);
            (await nullCreateHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            // GetLinkedObjectDefinitionAsync – null name
            var nullGet = async () => await _linkedObjectApi.GetLinkedObjectDefinitionAsync(null);
            (await nullGet.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            // GetLinkedObjectDefinitionWithHttpInfoAsync – null name
            var nullGetHttp = async () => await _linkedObjectApi.GetLinkedObjectDefinitionWithHttpInfoAsync(null);
            (await nullGetHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            // DeleteLinkedObjectDefinitionAsync – null name
            var nullDelete = async () => await _linkedObjectApi.DeleteLinkedObjectDefinitionAsync(null);
            (await nullDelete.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            // DeleteLinkedObjectDefinitionWithHttpInfoAsync – null name
            var nullDeleteHttp = async () => await _linkedObjectApi.DeleteLinkedObjectDefinitionWithHttpInfoAsync(null);
            (await nullDeleteHttp.Should().ThrowAsync<ApiException>())
                .Which.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);

            try
            {
                // ---------------------------------------------------------------
                // CREATE  (definition A) via CreateLinkedObjectDefinitionAsync
                //   POST /api/v1/meta/schemas/user/linkedObjects  → 201
                // ---------------------------------------------------------------
                var defA = await _linkedObjectApi.CreateLinkedObjectDefinitionAsync(
                    new LinkedObject
                    {
                        Primary = new LinkedObjectDetails
                        {
                            Name = primaryNameA,
                            Title = "Manager A",
                            Description = "Manager relationship A",
                            Type = LinkedObjectDetailsType.USER
                        },
                        Associated = new LinkedObjectDetails
                        {
                            Name = associatedNameA,
                            Title = "Subordinate A",
                            Description = "Subordinate relationship A",
                            Type = LinkedObjectDetailsType.USER
                        }
                    });
                defA.Should().NotBeNull();
                defA.Primary.Name.Should().Be(primaryNameA);
                defA.Primary.Title.Should().Be("Manager A");
                defA.Primary.Description.Should().Be("Manager relationship A");
                defA.Primary.Type.Should().Be(LinkedObjectDetailsType.USER);
                defA.Associated.Name.Should().Be(associatedNameA);
                defA.Associated.Title.Should().Be("Subordinate A");
                defA.Associated.Description.Should().Be("Subordinate relationship A");
                defA.Associated.Type.Should().Be(LinkedObjectDetailsType.USER);
                _createdLinkedObjectNames.Add(defA.Primary.Name);

                // ---------------------------------------------------------------
                // CREATE  (definition B) via CreateLinkedObjectDefinitionWithHttpInfoAsync
                //   POST /api/v1/meta/schemas/user/linkedObjects  → 201
                // ---------------------------------------------------------------
                var createResponseB = await _linkedObjectApi.CreateLinkedObjectDefinitionWithHttpInfoAsync(
                    new LinkedObject
                    {
                        Primary = new LinkedObjectDetails
                        {
                            Name = primaryNameB,
                            Title = "Manager B",
                            Description = "Manager relationship B",
                            Type = LinkedObjectDetailsType.USER
                        },
                        Associated = new LinkedObjectDetails
                        {
                            Name = associatedNameB,
                            Title = "Subordinate B",
                            Description = "Subordinate relationship B",
                            Type = LinkedObjectDetailsType.USER
                        }
                    });
                createResponseB.StatusCode.Should().Be(HttpStatusCode.Created);
                var defB = createResponseB.Data;
                defB.Should().NotBeNull();
                defB.Primary.Name.Should().Be(primaryNameB);
                defB.Associated.Name.Should().Be(associatedNameB);
                _createdLinkedObjectNames.Add(defB.Primary.Name);

                await Task.Delay(2000);

                // ---------------------------------------------------------------
                // READ – GetLinkedObjectDefinitionAsync
                //   GET /api/v1/meta/schemas/user/linkedObjects/{linkedObjectName} → 200
                //   linkedObjectName can be *either* primary or associated name
                // ---------------------------------------------------------------

                // by primary name
                var fetchedAByPrimary = await _linkedObjectApi.GetLinkedObjectDefinitionAsync(primaryNameA);
                fetchedAByPrimary.Should().NotBeNull();
                fetchedAByPrimary.Primary.Name.Should().Be(primaryNameA);
                fetchedAByPrimary.Associated.Name.Should().Be(associatedNameA);

                // by associated name
                var fetchedAByAssociated = await _linkedObjectApi.GetLinkedObjectDefinitionAsync(associatedNameA);
                fetchedAByAssociated.Should().NotBeNull();
                fetchedAByAssociated.Primary.Name.Should().Be(primaryNameA);
                fetchedAByAssociated.Associated.Name.Should().Be(associatedNameA);

                // ---------------------------------------------------------------
                // READ – GetLinkedObjectDefinitionWithHttpInfoAsync
                //   GET /api/v1/meta/schemas/user/linkedObjects/{linkedObjectName} → 200
                // ---------------------------------------------------------------

                // by primary name
                var fetchedBByPrimaryHttp = await _linkedObjectApi.GetLinkedObjectDefinitionWithHttpInfoAsync(primaryNameB);
                fetchedBByPrimaryHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                fetchedBByPrimaryHttp.Data.Primary.Name.Should().Be(primaryNameB);
                fetchedBByPrimaryHttp.Data.Associated.Name.Should().Be(associatedNameB);

                // by associated name
                var fetchedBByAssociatedHttp = await _linkedObjectApi.GetLinkedObjectDefinitionWithHttpInfoAsync(associatedNameB);
                fetchedBByAssociatedHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                fetchedBByAssociatedHttp.Data.Primary.Name.Should().Be(primaryNameB);
                fetchedBByAssociatedHttp.Data.Associated.Name.Should().Be(associatedNameB);

                // ---------------------------------------------------------------
                // LIST – ListLinkedObjectDefinitions  (collection client)
                //   GET /api/v1/meta/schemas/user/linkedObjects → 200
                // ---------------------------------------------------------------
                var list = await _linkedObjectApi.ListLinkedObjectDefinitions().ToListAsync();
                list.Should().NotBeNull();
                list.Should().Contain(lo => lo.Primary.Name == primaryNameA);
                list.Should().Contain(lo => lo.Primary.Name == primaryNameB);

                // ---------------------------------------------------------------
                // LIST – ListLinkedObjectDefinitionsWithHttpInfoAsync
                //   GET /api/v1/meta/schemas/user/linkedObjects → 200
                // ---------------------------------------------------------------
                var listHttp = await _linkedObjectApi.ListLinkedObjectDefinitionsWithHttpInfoAsync();
                listHttp.StatusCode.Should().Be(HttpStatusCode.OK);
                listHttp.Data.Should().NotBeNull();
                listHttp.Data.Should().Contain(lo => lo.Primary.Name == primaryNameA);
                listHttp.Data.Should().Contain(lo => lo.Primary.Name == primaryNameB);

                // ---------------------------------------------------------------
                // CREATE conflict (duplicate) – 409
                // ---------------------------------------------------------------
                var duplicateCreate = async () => await _linkedObjectApi.CreateLinkedObjectDefinitionAsync(
                    new LinkedObject
                    {
                        Primary    = defA.Primary,
                        Associated = defA.Associated
                    });
                (await duplicateCreate.Should().ThrowAsync<ApiException>())
                    .Which.ErrorCode.Should().Be((int)HttpStatusCode.Conflict);

                // ---------------------------------------------------------------
                // DELETE – DeleteLinkedObjectDefinitionWithHttpInfoAsync  by associated name
                //   DELETE /api/v1/meta/schemas/user/linkedObjects/{linkedObjectName} → 204
                // ---------------------------------------------------------------
                var deleteAResponse = await _linkedObjectApi.DeleteLinkedObjectDefinitionWithHttpInfoAsync(associatedNameA);
                deleteAResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
                _createdLinkedObjectNames.Remove(primaryNameA); // already deleted – no teardown needed

                await Task.Delay(2000);

                // GET after delete → 404  (by primary name)
                var getAAfterDelete = async () => await _linkedObjectApi.GetLinkedObjectDefinitionAsync(primaryNameA);
                (await getAAfterDelete.Should().ThrowAsync<ApiException>())
                    .Which.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

                // GET after delete → 404  (by associated name)
                var getAAfterDeleteByAssoc = async () => await _linkedObjectApi.GetLinkedObjectDefinitionAsync(associatedNameA);
                (await getAAfterDeleteByAssoc.Should().ThrowAsync<ApiException>())
                    .Which.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

                // ---------------------------------------------------------------
                // DELETE – DeleteLinkedObjectDefinitionAsync  by primary name
                //   DELETE /api/v1/meta/schemas/user/linkedObjects/{linkedObjectName} → 204 (void)
                // ---------------------------------------------------------------
                await _linkedObjectApi.DeleteLinkedObjectDefinitionAsync(primaryNameB);
                _createdLinkedObjectNames.Remove(primaryNameB); // already deleted

                await Task.Delay(2000);

                // GET after delete → 404  (WithHttpInfo path)
                var getBAfterDeleteHttp = async () => await _linkedObjectApi.GetLinkedObjectDefinitionWithHttpInfoAsync(primaryNameB);
                (await getBAfterDeleteHttp.Should().ThrowAsync<ApiException>())
                    .Which.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

                // DELETE already deleted → 404  (plain)
                var deleteAgainA = async () => await _linkedObjectApi.DeleteLinkedObjectDefinitionAsync(primaryNameA);
                (await deleteAgainA.Should().ThrowAsync<ApiException>())
                    .Which.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

                // DELETE already deleted → 404  (WithHttpInfo)
                var deleteAgainBHttp = async () => await _linkedObjectApi.DeleteLinkedObjectDefinitionWithHttpInfoAsync(associatedNameB);
                (await deleteAgainBHttp.Should().ThrowAsync<ApiException>())
                    .Which.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

                // GET completely unknown name → 404
                var unknownGet = async () => await _linkedObjectApi.GetLinkedObjectDefinitionAsync($"no-such-object-{guidA}");
                (await unknownGet.Should().ThrowAsync<ApiException>())
                    .Which.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

                // DELETE completely unknown name → 404
                var unknownDelete = async () => await _linkedObjectApi.DeleteLinkedObjectDefinitionAsync($"no-such-object-{guidB}");
                (await unknownDelete.Should().ThrowAsync<ApiException>())
                    .Which.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);
            }
            finally
            {
                // best-effort cleanup of anything that may remain
                await CleanupResources();
            }
        }
    }
}
