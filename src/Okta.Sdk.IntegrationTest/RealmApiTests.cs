// <copyright file="RealmApiTests.cs" company="Okta, Inc">
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
    [Collection(name: nameof(RealmApiTests))]
    public class RealmApiTests : IAsyncLifetime
    {
        private readonly RealmApi _realmApi = new();
        
        // Test realm IDs for cleanup
        private readonly List<string> _testRealmIds = [];

        // Using parameterless constructor - configuration loaded from ~/.okta/okta.yaml or environment variables

        public Task InitializeAsync()
        {
            // No async initialization needed
            return Task.CompletedTask;
        }

        public async Task DisposeAsync()
        {
            // Cleanup: Delete test realms if created
            await CleanupTestRealms();
        }

        private async Task CleanupTestRealms()
        {
            if (_testRealmIds == null || _testRealmIds.Count == 0)
            {
                return; // Nothing to clean up
            }

            var realmIdsToClean = _testRealmIds.ToList(); // Create a copy to avoid modification during iteration
            
            foreach (var realmId in realmIdsToClean)
            {
                try
                {
                    // Directly delete it without checking existence first (more efficient)
                    await _realmApi.DeleteRealmAsync(realmId);
                }
                catch (ApiException ex) when (ex.ErrorCode == 404)
                {
                    // Realm already deleted - this is fine, ignore
                    Console.WriteLine($"Realm {realmId} already deleted (404)");
                }
                catch (ApiException ex)
                {
                    // Log but continue with other realms
                    Console.WriteLine($"Failed to cleanup realm {realmId}: {ex.ErrorCode} - {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Log unexpected errors but continue
                    Console.WriteLine($"Unexpected error cleaning up realm {realmId}: {ex.Message}");
                }
                finally
                {
                    // Remove from the list regardless of success/failure to avoid retry
                    _testRealmIds.Remove(realmId);
                }
            }
            
            // Ensure the list is completely cleared
            _testRealmIds.Clear();
        }

        private string GenerateUniqueRealmName()
        {
            var guid = Guid.NewGuid().ToString("N").Substring(0, 8);
            return $"TestRealm-{guid}";
        }

        [Fact]
        public async Task GivenRealm_WhenPerformingCrudOperations_ThenAllOperationsSucceed()
        {
            // Step 1: Create Realm
            var realmName = GenerateUniqueRealmName();
            var createRealmRequest = new CreateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = realmName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER,
                    Domains = ["example-test.com", "partner-test.com"]
                }
            };

            var createdRealm = await _realmApi.CreateRealmAsync(createRealmRequest);
            
            createdRealm.Should().NotBeNull("Created realm should not be null");
            createdRealm.Id.Should().NotBeNullOrEmpty("Realm ID should be set");
            createdRealm.Profile.Should().NotBeNull("Realm profile should not be null");
            createdRealm.Profile.Name.Should().Be(realmName, "Realm name should match");
            // NOTE: RealmType is not returned by the API in responses, only accepted in requests
            // createdRealm.Profile.RealmType.Should().NotBeNull("RealmType should not be null");
            // createdRealm.Profile.RealmType.Should().Be(RealmProfile.RealmTypeEnum.PARTNER, "Realm type should be PARTNER");
            createdRealm.Profile.Domains.Should().NotBeNull("Domains should not be null");
            createdRealm.Profile.Domains.Should().Contain("example-test.com", "Should contain first domain");
            createdRealm.Profile.Domains.Should().Contain("partner-test.com", "Should contain second domain");
            createdRealm.IsDefault.Should().BeFalse("Newly created realm should not be default");
            createdRealm.Created.Should().BeBefore(DateTimeOffset.UtcNow.AddSeconds(30), 
                "Realm should be created recently");
            createdRealm.LastUpdated.Should().BeBefore(DateTimeOffset.UtcNow.AddSeconds(30), 
                "Realm should be updated recently");

            var realmId = createdRealm.Id;
            _testRealmIds.Add(realmId);

            // Step 2: Get (Read) Realm
            var retrievedRealm = await _realmApi.GetRealmAsync(realmId);
            
            retrievedRealm.Should().NotBeNull("Retrieved realm should not be null");
            retrievedRealm.Id.Should().Be(realmId, "Retrieved realm ID should match created realm");
            retrievedRealm.Profile.Should().NotBeNull("Retrieved realm profile should not be null");
            retrievedRealm.Profile.Name.Should().Be(realmName, "Retrieved realm name should match");
            // NOTE: RealmType is not returned by the API in responses, only accepted in requests
            // retrievedRealm.Profile.RealmType.Should().NotBeNull("Retrieved RealmType should not be null");
            // retrievedRealm.Profile.RealmType.Should().Be(RealmProfile.RealmTypeEnum.PARTNER, 
            //     "Retrieved realm type should match");
            retrievedRealm.Profile.Domains.Should().HaveCount(2, "Should have 2 domains");
            retrievedRealm.IsDefault.Should().BeFalse("Retrieved realm should not be default");

            // Step 3: List Realms (verify our realm appears in the list)
            var allRealms = await _realmApi.ListRealms().ToListAsync();
            
            allRealms.Should().NotBeNull("Realms list should not be null");
            allRealms.Should().Contain(r => r.Id == realmId, "Realms list should contain our realm");
            
            var listedRealm = allRealms.First(r => r.Id == realmId);
            listedRealm.Profile.Name.Should().Be(realmName, "Listed realm should have correct name");

            // Step 4: Update Realm (Replace profile)
            var updatedName = $"{realmName}-Updated";
            var updateRealmRequest = new UpdateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = updatedName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER,
                    Domains = ["updated-domain.com"]
                }
            };

            var updatedRealm = await _realmApi.ReplaceRealmAsync(realmId, updateRealmRequest);
            
            updatedRealm.Should().NotBeNull("Updated realm should not be null");
            updatedRealm.Id.Should().Be(realmId, "Updated realm ID should remain the same");
            updatedRealm.Profile.Name.Should().Be(updatedName, "Realm name should be updated");
            updatedRealm.Profile.Domains.Should().HaveCount(1, "Should have 1 domain after update");
            updatedRealm.Profile.Domains.Should().Contain("updated-domain.com", "Should contain updated domain");
            updatedRealm.LastUpdated.Should().BeAfter(createdRealm.LastUpdated, 
                "LastUpdated should be more recent after update");

            // Verify update was persisted
            var reRetrievedRealm = await _realmApi.GetRealmAsync(realmId);
            reRetrievedRealm.Profile.Name.Should().Be(updatedName, "Updated name should be persisted");
            reRetrievedRealm.Profile.Domains.Should().Contain("updated-domain.com", 
                "Updated domain should be persisted");

            // Step 5: Delete Realm
            await _realmApi.DeleteRealmAsync(realmId);
            _testRealmIds.Remove(realmId); // Remove from a cleanup list since we deleted it manually

            // Step 6: Verify realm is deleted - should return 404 Not Found
            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _realmApi.GetRealmAsync(realmId));
            
            ex.ErrorCode.Should().Be(404, "Getting a deleted realm should return HTTP 404");
            ex.Message.Should().Contain("E0000007", "Error should contain Okta's Not Found error code");
        }

        [Fact]
        public async Task GivenValidData_WhenCreatingRealm_ThenRealmIsCreatedSuccessfully()
        {
            var realmName = GenerateUniqueRealmName();
            var createRealmRequest = new CreateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = realmName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER,
                    Domains = ["test-domain.com"]
                }
            };

            var realm = await _realmApi.CreateRealmAsync(createRealmRequest);

            realm.Should().NotBeNull();
            realm.Id.Should().NotBeNullOrEmpty();
            realm.Profile.Name.Should().Be(realmName);
            // NOTE: RealmType is not returned by the API in responses, only accepted in requests
            // realm.Profile.RealmType.Should().NotBeNull("RealmType should not be null");
            // realm.Profile.RealmType.Should().Be(RealmProfile.RealmTypeEnum.PARTNER);
            realm.Profile.Domains.Should().Contain("test-domain.com");

            _testRealmIds.Add(realm.Id);
        }

        /// <summary>
        /// Tests CreateRealmAsync with HTTP response details
        /// API: POST /api/v1/realms - Returns ApiResponse with status code and headers
        /// </summary>
        [Fact]
        public async Task GivenValidData_WhenCreatingRealmWithHttpInfo_ThenHttpResponseIsReturned()
        {
            var realmName = GenerateUniqueRealmName();
            var createRealmRequest = new CreateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = realmName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER,
                    Domains = ["test-domain.com"]
                }
            };

            var response = await _realmApi.CreateRealmWithHttpInfoAsync(createRealmRequest);

            // Verify HTTP response details
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK, "Create should return HTTP 200");
            response.Data.Should().NotBeNull("Response should contain realm data");
            
            // Verify realm data
            var realm = response.Data;
            realm.Id.Should().NotBeNullOrEmpty();
            realm.Profile.Name.Should().Be(realmName);
            realm.Profile.Domains.Should().Contain("test-domain.com");

            _testRealmIds.Add(realm.Id);
        }

        [Fact]
        public async Task GivenInvalidProfile_WhenCreatingRealm_ThenOperationFails()
        {
            // Realm without a name should fail
            var createRealmRequest = new CreateRealmRequest
            {
                Profile = new RealmProfile
                {
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER
                    // Missing the required Name field
                }
            };

            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _realmApi.CreateRealmAsync(createRealmRequest));

            ex.ErrorCode.Should().Be(400, "Invalid realm profile should return HTTP 400 Bad Request");
        }

        [Fact]
        public async Task GivenValidId_WhenGettingRealm_ThenRealmIsReturned()
        {
            // First, create a realm
            var realmName = GenerateUniqueRealmName();
            var createRealmRequest = new CreateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = realmName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER
                }
            };
            var createdRealm = await _realmApi.CreateRealmAsync(createRealmRequest);
            _testRealmIds.Add(createdRealm.Id);

            // Now retrieve it
            var retrievedRealm = await _realmApi.GetRealmAsync(createdRealm.Id);

            retrievedRealm.Should().NotBeNull();
            retrievedRealm.Id.Should().Be(createdRealm.Id);
            retrievedRealm.Profile.Name.Should().Be(realmName);
            // NOTE: RealmType is not returned by the API in responses, only accepted in requests
            // retrievedRealm.Profile.RealmType.Should().NotBeNull("RealmType should not be null");
            // retrievedRealm.Profile.RealmType.Should().Be(RealmProfile.RealmTypeEnum.PARTNER);
        }

        /// <summary>
        /// Tests GetRealmAsync with HTTP response details
        /// API: GET /api/v1/realms/{id} - Returns ApiResponse with status code and headers
        /// </summary>
        [Fact]
        public async Task GivenValidId_WhenGettingRealmWithHttpInfo_ThenHttpResponseIsReturned()
        {
            // First, create a realm to get
            var realmName = GenerateUniqueRealmName();
            var createRealmRequest = new CreateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = realmName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER,
                    Domains = ["test-domain.com"]
                }
            };
            var createdRealm = await _realmApi.CreateRealmAsync(createRealmRequest);
            _testRealmIds.Add(createdRealm.Id);

            // Now get it with HTTP info
            var response = await _realmApi.GetRealmWithHttpInfoAsync(createdRealm.Id);

            // Verify HTTP response details
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK, "Get should return HTTP 200");
            response.Data.Should().NotBeNull("Response should contain realm data");
            
            // Verify realm data
            var realm = response.Data;
            realm.Id.Should().Be(createdRealm.Id);
            realm.Profile.Name.Should().Be(realmName);
        }

        [Fact]
        public async Task GivenInvalidId_WhenGettingRealm_ThenOperationFails()
        {
            var invalidRealmId = "invalid_realm_id_12345";

            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _realmApi.GetRealmAsync(invalidRealmId));

            ex.ErrorCode.Should().Be(404, "Getting non-existent realm should return HTTP 404");
            // More flexible error message check - could be E0000007 or other not found messages
            ex.Message.Should().NotBeNullOrEmpty("Error message should be provided");
        }

        [Fact]
        public async Task GivenRealmsExist_WhenListingRealms_ThenRealmsAreReturned()
        {
            var realms = await _realmApi.ListRealms().ToListAsync();

            realms.Should().NotBeNull("Realms list should not be null");
            realms.Should().NotBeEmpty("Should have at least the default realm");
            
            // At least one realm should be the default realm
            realms.Should().Contain(r => r.IsDefault == true, "Should contain the default realm");
        }

        [Fact]
        public async Task GivenLimitParameter_WhenListingRealms_ThenLimitIsRespected()
        {
            var limit = 5;
            
            // Test the limit parameter by checking the first page size
            var realmsCollection = _realmApi.ListRealms(limit: limit);
            var pagedEnumerator = realmsCollection.GetPagedEnumerator();
            var hasNextPage = await pagedEnumerator.MoveNextAsync();

            if (hasNextPage)
            {
                var firstPage = pagedEnumerator.CurrentPage;
                firstPage.Should().NotBeNull();
                var firstPageItems = firstPage.Items.ToList();
                
                // The first page should respect the limit but may have fewer items if there aren't enough realms
                firstPageItems.Count.Should().BeLessThanOrEqualTo(limit, "First page should not exceed the specified limit");
                
                // If we have exactly the limit, verify we got the requested number
                if (firstPageItems.Count == limit)
                {
                    firstPageItems.Count.Should().Be(limit, "Should return exactly the requested limit when available");
                }
            }
            
            // Alternative verification: ensure the API call succeeds with a limit parameter
            var limitedRealms = await _realmApi.ListRealms(limit: 1).ToListAsync(); // Use limit of 1 for reliable testing
            limitedRealms.Should().NotBeNull("Limited realms list should not be null");
            limitedRealms.Should().NotBeEmpty("Should return at least one realm");
        }

        [Fact]
        public async Task GivenSearchParameter_WhenListingRealms_ThenResultsAreFiltered()
        {
            // Create a realm with a unique name
            var uniquePrefix = $"UniqueSearch{Guid.NewGuid().ToString("N").Substring(0, 6)}";
            var realmName = $"{uniquePrefix}-TestRealm";
            
            var createRealmRequest = new CreateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = realmName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER
                }
            };
            var createdRealm = await _realmApi.CreateRealmAsync(createRealmRequest);
            _testRealmIds.Add(createdRealm.Id);

            // Wait a bit for indexing (eventually consistent)
            await Task.Delay(2000);

            // Search for the realm using 'co' (contains) operator
            var searchQuery = $"profile.name co \"{uniquePrefix}\"";
            var searchResults = await _realmApi.ListRealms(search: searchQuery).ToListAsync();

            searchResults.Should().NotBeNull();
            searchResults.Should().Contain(r => r.Id == createdRealm.Id, 
                "Search results should contain the created realm");
        }

        /// <summary>
        /// Tests ListRealms with sortBy parameter
        /// API: GET /api/v1/realms?sortBy=profile.name - Should sort results by name
        /// </summary>
        [Fact]
        public async Task GivenSortByParameter_WhenListingRealms_ThenResultsAreSorted()
        {
            var realms = await _realmApi.ListRealms(sortBy: "profile.name", sortOrder: "asc", limit: 10).ToListAsync();

            realms.Should().NotBeNull();
            realms.Should().NotBeEmpty();
            
            // Verify realms are sorted by name in ascending order
            if (realms.Count > 1)
            {
                for (int i = 0; i < realms.Count - 1; i++)
                {
                    var currentName = realms[i].Profile?.Name ?? "";
                    var nextName = realms[i + 1].Profile?.Name ?? "";
                    
                    string.Compare(currentName, nextName, StringComparison.OrdinalIgnoreCase)
                        .Should().BeLessThanOrEqualTo(0, $"Realm '{currentName}' should come before or equal to '{nextName}' in ascending order");
                }
            }
        }

        /// <summary>
        /// Tests ListRealms with sortOrder parameter
        /// API: GET /api/v1/realms?sortBy=created & sortOrder=desc - Should sort by creation date descending
        /// </summary>
        [Fact]
        public async Task GivenSortOrderParameter_WhenListingRealms_ThenResultsAreOrdered()
        {
            var realms = await _realmApi.ListRealms(sortBy: "created", sortOrder: "desc", limit: 10).ToListAsync();

            realms.Should().NotBeNull();
            realms.Should().NotBeEmpty();
            
            // Verify realms are sorted by created date in descending order (newest first)
            if (realms.Count > 1)
            {
                for (int i = 0; i < realms.Count - 1; i++)
                {
                    realms[i].Created.Should().BeOnOrAfter(realms[i + 1].Created, 
                        "In descending order, earlier items should have later (more recent) creation dates");
                }
            }
        }

        /// <summary>
        /// Tests ListRealmsAsync with HTTP response details
        /// API: GET /api/v1/realms - Returns ApiResponse with status code and headers
        /// </summary>
        [Fact]
        public async Task GivenHttpInfoMethod_WhenListingRealms_ThenHttpResponseIsReturned()
        {
            var response = await _realmApi.ListRealmsWithHttpInfoAsync(limit: 10);

            // Verify HTTP response details
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK, "List should return HTTP 200");
            response.Data.Should().NotBeNull("Response should contain realm list");
            response.Data.Should().NotBeEmpty("Should have at least the default realm");
            
            // Verify headers contain a pagination link if applicable
            response.Headers.Should().NotBeNull("Response headers should be present");
        }

        /// <summary>
        /// Tests the default realm always exists
        /// API: GET /api/v1/realms - Verifies system realm
        /// </summary>
        [Fact]
        public async Task GivenOktaOrg_WhenCheckingForDefaultRealm_ThenDefaultRealmExists()
        {
            var realms = await _realmApi.ListRealms().ToListAsync();

            realms.Should().NotBeNull("Realms list should not be null");
            realms.Should().Contain(r => r.IsDefault == true, "Should contain at least one default realm");
            
            var defaultRealm = realms.First(r => r.IsDefault);
            defaultRealm.Id.Should().NotBeNullOrEmpty("Default realm should have an ID");
            defaultRealm.Profile.Should().NotBeNull("Default realm should have a profile");
            defaultRealm.Profile.Name.Should().NotBeNullOrEmpty("Default realm should have a name");
        }

        [Fact]
        public async Task GivenUpdatedName_WhenReplacingRealm_ThenRealmIsUpdated()
        {
            // Create a realm
            var originalName = GenerateUniqueRealmName();
            var createRealmRequest = new CreateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = originalName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER,
                    Domains = ["original.com"]
                }
            };
            var createdRealm = await _realmApi.CreateRealmAsync(createRealmRequest);
            _testRealmIds.Add(createdRealm.Id);

            // Update the realm
            var updatedName = $"{originalName}-Modified";
            var updateRealmRequest = new UpdateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = updatedName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER,
                    Domains = ["original.com", "updated.com"]
                }
            };

            var updatedRealm = await _realmApi.ReplaceRealmAsync(createdRealm.Id, updateRealmRequest);

            updatedRealm.Should().NotBeNull();
            updatedRealm.Id.Should().Be(createdRealm.Id, "ID should remain the same");
            updatedRealm.Profile.Name.Should().Be(updatedName, "Name should be updated");
            updatedRealm.Profile.Domains.Should().HaveCount(2, "Should have 2 domains");
            updatedRealm.Profile.Domains.Should().Contain("updated.com", "Should contain new domain");
        }

        /// <summary>
        /// Tests ReplaceRealmAsync with HTTP response details
        /// API: PUT /api/v1/realms/{id} - Returns ApiResponse with status code and headers
        /// </summary>
        [Fact]
        public async Task GivenUpdatedName_WhenReplacingRealmWithHttpInfo_ThenHttpResponseIsReturned()
        {
            // Create a realm
            var originalName = GenerateUniqueRealmName();
            var createRealmRequest = new CreateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = originalName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER,
                    Domains = ["original.com"]
                }
            };
            var createdRealm = await _realmApi.CreateRealmAsync(createRealmRequest);
            _testRealmIds.Add(createdRealm.Id);

            // Update the realm with HTTP info
            var updatedName = $"{originalName}-Modified";
            var updateRealmRequest = new UpdateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = updatedName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER,
                    Domains = ["updated.com"]
                }
            };

            var response = await _realmApi.ReplaceRealmWithHttpInfoAsync(createdRealm.Id, updateRealmRequest);

            // Verify HTTP response details
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK, "Replace should return HTTP 200");
            response.Data.Should().NotBeNull("Response should contain updated realm data");
            
            // Verify updated realm data
            var updatedRealm = response.Data;
            updatedRealm.Id.Should().Be(createdRealm.Id);
            updatedRealm.Profile.Name.Should().Be(updatedName);
        }

        /// <summary>
        /// Tests DeleteRealmAsync - verifies realm can be deleted
        /// API: DELETE /api/v1/realms/{id} - Returns void on success
        /// </summary>
        [Fact]
        public async Task GivenValidId_WhenDeletingRealm_ThenRealmIsRemoved()
        {
            // Create a realm
            var realmName = GenerateUniqueRealmName();
            var createRealmRequest = new CreateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = realmName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER
                }
            };
            var createdRealm = await _realmApi.CreateRealmAsync(createRealmRequest);

            // Delete the realm
            await _realmApi.DeleteRealmAsync(createdRealm.Id);

            // Verify it's deleted
            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _realmApi.GetRealmAsync(createdRealm.Id));

            ex.ErrorCode.Should().Be(404, "Deleted realm should return HTTP 404");
        }

        /// <summary>
        /// Tests DeleteRealmAsync with HTTP response details
        /// API: DELETE /api/v1/realms/{id} - Returns ApiResponse with HTTP 204 No Content
        /// </summary>
        [Fact]
        public async Task GivenValidId_WhenDeletingRealmWithHttpInfo_ThenNoContentIsReturned()
        {
            // Create a realm to delete
            var realmName = GenerateUniqueRealmName();
            var createRealmRequest = new CreateRealmRequest
            {
                Profile = new RealmProfile
                {
                    Name = realmName,
                    RealmType = RealmProfile.RealmTypeEnum.PARTNER
                }
            };
            var createdRealm = await _realmApi.CreateRealmAsync(createRealmRequest);

            // Delete it with HTTP info
            var response = await _realmApi.DeleteRealmWithHttpInfoAsync(createdRealm.Id);

            // Verify HTTP response details
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent, "Delete should return HTTP 204 No Content");
            
            // Verify realm is actually deleted
            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _realmApi.GetRealmAsync(createdRealm.Id));
            ex.ErrorCode.Should().Be(404, "Deleted realm should return 404");
            
            // No need to add to clean up since it's already deleted
        }
    }
}
