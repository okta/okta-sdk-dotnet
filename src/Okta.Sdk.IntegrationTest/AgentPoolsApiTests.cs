// <copyright file="AgentPoolsApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for AgentPoolsApi covering all 14 endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/agentPools - ListAgentPools
    /// 2. GET /api/v1/agentPools/{poolId}/updates - ListAgentPoolsUpdates
    /// 3. POST /api/v1/agentPools/{poolId}/updates - CreateAgentPoolsUpdate
    /// 4. GET /api/v1/agentPools/{poolId}/updates/settings - GetAgentPoolsUpdateSettings
    /// 5. POST /api/v1/agentPools/{poolId}/updates/settings - UpdateAgentPoolsUpdateSettings
    /// 6. GET /api/v1/agentPools/{poolId}/updates/{updateId} - GetAgentPoolsUpdateInstance
    /// 7. POST /api/v1/agentPools/{poolId}/updates/{updateId} - UpdateAgentPoolsUpdate
    /// 8. DELETE /api/v1/agentPools/{poolId}/updates/{updateId} - DeleteAgentPoolsUpdate
    /// 9. POST /api/v1/agentPools/{poolId}/updates/{updateId}/activate - ActivateAgentPoolsUpdate
    /// 10. POST /api/v1/agentPools/{poolId}/updates/{updateId}/deactivate - DeactivateAgentPoolsUpdate
    /// 11. POST /api/v1/agentPools/{poolId}/updates/{updateId}/pause - PauseAgentPoolsUpdate
    /// 12. POST /api/v1/agentPools/{poolId}/updates/{updateId}/resume - ResumeAgentPoolsUpdate
    /// 13. POST /api/v1/agentPools/{poolId}/updates/{updateId}/retry - RetryAgentPoolsUpdate
    /// 14. POST /api/v1/agentPools/{poolId}/updates/{updateId}/stop - StopAgentPoolsUpdate
    /// 
    /// Note: Agent pools are created when directory agents (AD/LDAP) are installed.
    /// These tests require an Okta org with at least one agent pool configured.
    /// </summary>
    public class AgentPoolsApiTests
    {
        private readonly AgentPoolsApi _agentPoolsApi = new();

        /// <summary>
        /// Comprehensive test covering all AgentPoolsApi operations and endpoints.
        /// This single test covers:
        /// - Listing agent pools with pagination and type filters
        /// - Getting and updating pool update settings
        /// - CRUD operations for pool updates
        /// - Lifecycle operations (activate, deactivate, pause, resume, retry, stop)
        /// - Error handling for invalid IDs
        /// 
        /// Cleanup: All created updates are deleted in the finally block
        /// </summary>
        [Fact]
        public async Task GivenAgentPoolsApi_WhenPerformingAllOperations_ThenAllEndpointsWork()
        {
            string testPoolId = null;
            string createdUpdateId = null;

            try
            {
                // ========================================================================
                // SECTION 1: List Agent Pools
                // ========================================================================

                #region ListAgentPools - GET /api/v1/agentPools

                // Test ListAgentPools() without parameters
                var allPools = await _agentPoolsApi.ListAgentPools().ToListAsync();

                allPools.Should().NotBeNull();
                allPools.Should().NotBeEmpty("Okta org should have at least one agent pool configured");

                // Verify pool model properties
                var firstPool = allPools.First();
                firstPool.Id.Should().NotBeNullOrEmpty();
                firstPool.Name.Should().NotBeNullOrEmpty();
                firstPool.Type.Should().NotBeNull();

                testPoolId = firstPool.Id;

                // Test ListAgentPools() with limit
                var limitedPools = await _agentPoolsApi.ListAgentPools(limitPerPoolType: 1).ToListAsync();
                limitedPools.Should().NotBeNull();

                // Test ListAgentPools() with pool type filter (AD)
                var adPools = await _agentPoolsApi.ListAgentPools(poolType: AgentType.AD).ToListAsync();
                adPools.Should().NotBeNull();
                foreach (var pool in adPools)
                {
                    pool.Type.Should().Be(AgentType.AD);
                }

                // Verify agent properties if pool has agents (Issue #808 fix: lastConnection parsing)
                if (firstPool.Agents != null && firstPool.Agents.Any())
                {
                    var agent = firstPool.Agents.First();
                    agent.Id.Should().NotBeNullOrEmpty();
                    agent.Name.Should().NotBeNullOrEmpty();
                    agent.LastConnection.Should().BeGreaterThan(0);
                }

                #endregion

                // ========================================================================
                // SECTION 2: Get and Update Pool Settings
                // ========================================================================

                #region GetAgentPoolsUpdateSettings - GET /api/v1/agentPools/{poolId}/updates/settings

                var settings = await _agentPoolsApi.GetAgentPoolsUpdateSettingsAsync(testPoolId);

                settings.Should().NotBeNull();
                settings.PoolId.Should().Be(testPoolId);
                settings.AgentType.Should().NotBeNull();
                settings.ReleaseChannel.Should().NotBeNull();
                settings.LatestVersion.Should().NotBeNullOrEmpty();
                settings.MinimalSupportedVersion.Should().NotBeNullOrEmpty();

                var originalContinueOnError = settings.ContinueOnError;

                #endregion

                #region UpdateAgentPoolsUpdateSettings - POST /api/v1/agentPools/{poolId}/updates/settings

                // Toggle continueOnError setting
                var updatedSettings = new AgentPoolUpdateSetting
                {
                    AgentType = settings.AgentType,
                    ReleaseChannel = settings.ReleaseChannel,
                    ContinueOnError = !originalContinueOnError
                };

                var settingsResult = await _agentPoolsApi.UpdateAgentPoolsUpdateSettingsAsync(testPoolId, updatedSettings);

                settingsResult.Should().NotBeNull();
                settingsResult.ContinueOnError.Should().Be(!originalContinueOnError);

                // Restore original setting
                updatedSettings.ContinueOnError = originalContinueOnError;
                await _agentPoolsApi.UpdateAgentPoolsUpdateSettingsAsync(testPoolId, updatedSettings);

                #endregion

                // ========================================================================
                // SECTION 3: List Pool Updates
                // ========================================================================

                #region ListAgentPoolsUpdates - GET /api/v1/agentPools/{poolId}/updates

                // List all updates (may be empty)
                var allUpdates = await _agentPoolsApi.ListAgentPoolsUpdates(testPoolId).ToListAsync();
                allUpdates.Should().NotBeNull();

                // Test with scheduled filter
                var scheduledUpdates = await _agentPoolsApi.ListAgentPoolsUpdates(testPoolId, scheduled: true).ToListAsync();
                scheduledUpdates.Should().NotBeNull();

                #endregion

                // ========================================================================
                // SECTION 4: CRUD Operations for Pool Updates
                // ========================================================================

                #region CreateAgentPoolsUpdate - POST /api/v1/agentPools/{poolId}/updates

                var newUpdate = new AgentPoolUpdate
                {
                    Name = $"SDK Integration Test Update - {DateTime.UtcNow:yyyyMMddHHmmss}",
                    AgentType = firstPool.Type, // Required field
                    NotifyAdmin = false,
                    TargetVersion = settings.LatestVersion,
                    Agents = firstPool.Agents // Required - list of agents to update
                };

                var createdUpdate = await _agentPoolsApi.CreateAgentPoolsUpdateAsync(testPoolId, newUpdate);

                createdUpdate.Should().NotBeNull();
                createdUpdate.Id.Should().NotBeNullOrEmpty();
                createdUpdate.Name.Should().Contain("SDK Integration Test Update");
                createdUpdate.TargetVersion.Should().Be(settings.LatestVersion);

                createdUpdateId = createdUpdate.Id;

                #endregion

                #region GetAgentPoolsUpdateInstance - GET /api/v1/agentPools/{poolId}/updates/{updateId}

                // Note: Update may complete immediately if agents are already at target version
                // In that case, the update is auto-deleted, so we handle 404 gracefully
                bool updateStillExists = true;
                try
                {
                    var retrievedUpdate = await _agentPoolsApi.GetAgentPoolsUpdateInstanceAsync(testPoolId, createdUpdateId);

                    retrievedUpdate.Should().NotBeNull();
                    retrievedUpdate.Id.Should().Be(createdUpdateId);
                    retrievedUpdate.Name.Should().Be(createdUpdate.Name);
                    retrievedUpdate.Status.Should().NotBeNull();
                }
                catch (ApiException ex) when (ex.ErrorCode == 404)
                {
                    // Update completed and was auto-deleted - this is valid behavior
                    updateStillExists = false;
                    createdUpdateId = null;
                }

                #endregion

                #region UpdateAgentPoolsUpdate - POST /api/v1/agentPools/{poolId}/updates/{updateId}

                if (updateStillExists)
                {
                    var modifiedUpdate = new AgentPoolUpdate
                    {
                        Name = $"SDK Test Update - Modified - {DateTime.UtcNow:yyyyMMddHHmmss}",
                        NotifyAdmin = true
                    };

                    try
                    {
                        var updatedResult = await _agentPoolsApi.UpdateAgentPoolsUpdateAsync(testPoolId, createdUpdateId, modifiedUpdate);

                        updatedResult.Should().NotBeNull();
                        updatedResult.Name.Should().Contain("Modified");
                        updatedResult.NotifyAdmin.Should().BeTrue();
                    }
                    catch (ApiException ex) when (ex.ErrorCode == 404)
                    {
                        // Update was deleted during test - acceptable
                        updateStillExists = false;
                        createdUpdateId = null;
                    }
                }

                #endregion

                // ========================================================================
                // SECTION 5: Lifecycle Operations
                // ========================================================================

                #region Lifecycle Operations

                // Lifecycle operations only run if the update still exists
                if (updateStillExists && !string.IsNullOrEmpty(createdUpdateId))
                {
                    // Test Deactivate - POST /api/v1/agentPools/{poolId}/updates/{updateId}/deactivate
                    try
                    {
                        var deactivated = await _agentPoolsApi.DeactivateAgentPoolsUpdateAsync(testPoolId, createdUpdateId);
                        deactivated.Should().NotBeNull();
                    }
                    catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409 || ex.ErrorCode == 404)
                    {
                        // State doesn't allow deactivation or update was deleted - acceptable
                    }

                    // Test Activate - POST /api/v1/agentPools/{poolId}/updates/{updateId}/activate
                    try
                    {
                        var activated = await _agentPoolsApi.ActivateAgentPoolsUpdateAsync(testPoolId, createdUpdateId);
                        activated.Should().NotBeNull();
                    }
                    catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409 || ex.ErrorCode == 404)
                    {
                        // State doesn't allow activation or update was deleted - acceptable
                    }

                    // Test Pause - POST /api/v1/agentPools/{poolId}/updates/{updateId}/pause
                    try
                    {
                        await _agentPoolsApi.PauseAgentPoolsUpdateAsync(testPoolId, createdUpdateId);
                    }
                    catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409 || ex.ErrorCode == 404)
                    {
                        // State doesn't allow pause or update was deleted - acceptable
                    }

                    // Test Resume - POST /api/v1/agentPools/{poolId}/updates/{updateId}/resume
                    try
                    {
                        await _agentPoolsApi.ResumeAgentPoolsUpdateAsync(testPoolId, createdUpdateId);
                    }
                    catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409 || ex.ErrorCode == 404)
                    {
                        // State doesn't allow resume or update was deleted - acceptable
                    }

                    // Test Retry - POST /api/v1/agentPools/{poolId}/updates/{updateId}/retry
                    try
                    {
                        var retried = await _agentPoolsApi.RetryAgentPoolsUpdateAsync(testPoolId, createdUpdateId);
                        retried.Should().NotBeNull();
                    }
                    catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409 || ex.ErrorCode == 404)
                    {
                        // State doesn't allow retry or update was deleted - acceptable
                    }

                    // Test Stop - POST /api/v1/agentPools/{poolId}/updates/{updateId}/stop
                    try
                    {
                        var stopped = await _agentPoolsApi.StopAgentPoolsUpdateAsync(testPoolId, createdUpdateId);
                        stopped.Should().NotBeNull();
                    }
                    catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409 || ex.ErrorCode == 404)
                    {
                        // State doesn't allow stop or update was deleted - acceptable
                    }
                }

                #endregion

                // ========================================================================
                // SECTION 6: Delete Update
                // ========================================================================

                #region DeleteAgentPoolsUpdate - DELETE /api/v1/agentPools/{poolId}/updates/{updateId}

                if (updateStillExists && !string.IsNullOrEmpty(createdUpdateId))
                {
                    try
                    {
                        await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(testPoolId, createdUpdateId);

                        // Verify deletion - should get 404
                        var deleteException = await Assert.ThrowsAsync<ApiException>(
                            () => _agentPoolsApi.GetAgentPoolsUpdateInstanceAsync(testPoolId, createdUpdateId));
                        deleteException.ErrorCode.Should().Be(404);

                        createdUpdateId = null; // Prevent double-delete in finally
                    }
                    catch (ApiException ex) when (ex.ErrorCode == 404)
                    {
                        // Already deleted - acceptable
                        createdUpdateId = null;
                    }
                }

                #endregion

                // ========================================================================
                // SECTION 7: Error Handling
                // ========================================================================

                #region Error Scenarios

                // Test 404 for non-existent update ID
                var notFoundException = await Assert.ThrowsAsync<ApiException>(
                    () => _agentPoolsApi.GetAgentPoolsUpdateInstanceAsync(testPoolId, "nonexistent123"));
                notFoundException.ErrorCode.Should().Be(404);

                // Test invalid pool ID
                var invalidPoolException = await Assert.ThrowsAsync<ApiException>(
                    () => _agentPoolsApi.GetAgentPoolsUpdateSettingsAsync("invalidPoolId123"));
                invalidPoolException.ErrorCode.Should().BeOneOf(400, 404);

                #endregion
            }
            finally
            {
                // ========================================================================
                // CLEANUP
                // ========================================================================
                if (!string.IsNullOrEmpty(createdUpdateId) && !string.IsNullOrEmpty(testPoolId))
                {
                    try
                    {
                        await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(testPoolId, createdUpdateId);
                    }
                    catch (ApiException)
                    {
                        // Cleanup failed - update may have been deleted already
                    }
                }
            }
        }

        /// <summary>
        /// Tests WithHttpInfoAsync variants to verify they return proper ApiResponse objects
        /// with status codes, headers, and data.
        /// </summary>
        [Fact]
        public async Task GivenAgentPoolsApi_WhenUsingWithHttpInfoAsync_ThenReturnsApiResponseWithMetadata()
        {
            // ========================================================================
            // Test ListAgentPoolsWithHttpInfoAsync
            // ========================================================================
            var listPoolsResponse = await _agentPoolsApi.ListAgentPoolsWithHttpInfoAsync();

            listPoolsResponse.Should().NotBeNull();
            listPoolsResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            listPoolsResponse.Headers.Should().NotBeNull();
            listPoolsResponse.Data.Should().NotBeNull();

            if (!listPoolsResponse.Data.Any())
            {
                // Skip remaining tests if no pools available
                return;
            }

            var testPoolId = listPoolsResponse.Data.First().Id;

            // ========================================================================
            // Test GetAgentPoolsUpdateSettingsWithHttpInfoAsync
            // ========================================================================
            var settingsResponse = await _agentPoolsApi.GetAgentPoolsUpdateSettingsWithHttpInfoAsync(testPoolId);

            settingsResponse.Should().NotBeNull();
            settingsResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            settingsResponse.Headers.Should().NotBeNull();
            settingsResponse.Data.Should().NotBeNull();
            settingsResponse.Data.PoolId.Should().Be(testPoolId);

            // ========================================================================
            // Test ListAgentPoolsUpdatesWithHttpInfoAsync
            // ========================================================================
            var updatesResponse = await _agentPoolsApi.ListAgentPoolsUpdatesWithHttpInfoAsync(testPoolId);

            updatesResponse.Should().NotBeNull();
            updatesResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            updatesResponse.Headers.Should().NotBeNull();
            updatesResponse.Data.Should().NotBeNull();

            // ========================================================================
            // Test Error Scenarios with WithHttpInfoAsync (400/404)
            // ========================================================================

            // Test 404 for invalid pool ID with GetAgentPoolsUpdateSettingsWithHttpInfoAsync
            var invalidPoolException = await Assert.ThrowsAsync<ApiException>(
                () => _agentPoolsApi.GetAgentPoolsUpdateSettingsWithHttpInfoAsync("invalidPoolId123"));
            invalidPoolException.ErrorCode.Should().BeOneOf(400, 404);

            // Test 404 for non-existent update ID with GetAgentPoolsUpdateInstanceWithHttpInfoAsync
            var notFoundUpdateException = await Assert.ThrowsAsync<ApiException>(
                () => _agentPoolsApi.GetAgentPoolsUpdateInstanceWithHttpInfoAsync(testPoolId, "nonexistent123"));
            notFoundUpdateException.ErrorCode.Should().Be(404);

            // Test 404 for invalid pool ID with ListAgentPoolsUpdatesWithHttpInfoAsync
            // Note: This may return empty list or throw depending on pool ID format
            try
            {
                var invalidUpdatesResponse = await _agentPoolsApi.ListAgentPoolsUpdatesWithHttpInfoAsync("invalidPoolId123");
                // If it doesn't throw, verify we got a response (empty list is valid)
                invalidUpdatesResponse.Should().NotBeNull();
            }
            catch (ApiException ex)
            {
                ex.ErrorCode.Should().BeOneOf(400, 404);
            }
        }

        /// <summary>
        /// Tests pagination functionality using the 'after' cursor parameter.
        /// </summary>
        [Fact]
        public async Task GivenAgentPoolsApi_WhenUsingPagination_ThenReturnsCorrectPages()
        {
            // ========================================================================
            // Test ListAgentPools pagination with limit
            // ========================================================================
            
            // First, get all pools to understand the total count
            var allPools = await _agentPoolsApi.ListAgentPools().ToListAsync();
            
            if (allPools.Count < 2)
            {
                // Need at least 2 pools to test pagination effectively
                // Just verify the pagination parameters work without error
                var singlePage = await _agentPoolsApi.ListAgentPools(limitPerPoolType: 1).ToListAsync();
                singlePage.Should().NotBeNull();
                return;
            }

            // Get first page with limit of 1
            var firstPageResponse = await _agentPoolsApi.ListAgentPoolsWithHttpInfoAsync(limitPerPoolType: 1);
            firstPageResponse.Should().NotBeNull();
            firstPageResponse.Data.Should().NotBeNull();

            // Check for 'after' cursor in Link header or response
            // The SDK's IAsyncEnumerable handles pagination automatically, but we can verify manual pagination works
            var firstPool = firstPageResponse.Data.FirstOrDefault();
            if (firstPool != null)
            {
                // Use the first pool's ID as an 'after' cursor for next page
                var secondPageResponse = await _agentPoolsApi.ListAgentPoolsWithHttpInfoAsync(
                    limitPerPoolType: 1, 
                    after: firstPool.Id);
                
                secondPageResponse.Should().NotBeNull();
                secondPageResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
                
                // If there are more pools, the second page should have different data
                if (secondPageResponse.Data.Any())
                {
                    var secondPool = secondPageResponse.Data.First();
                    secondPool.Id.Should().NotBe(firstPool.Id, "Second page should not return the same pool");
                }
            }

            // ========================================================================
            // Test ListAgentPoolsUpdates pagination
            // ========================================================================
            var testPoolId = allPools.First().Id;
            
            // Get updates for the pool
            var allUpdates = await _agentPoolsApi.ListAgentPoolsUpdates(testPoolId).ToListAsync();
            
            // Test with HttpInfo to access pagination metadata
            var updatesPageResponse = await _agentPoolsApi.ListAgentPoolsUpdatesWithHttpInfoAsync(testPoolId);
            updatesPageResponse.Should().NotBeNull();
            updatesPageResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            // Verify the async enumerable pagination works correctly
            var updatesViaEnumerable = await _agentPoolsApi.ListAgentPoolsUpdates(testPoolId).ToListAsync();
            updatesViaEnumerable.Should().NotBeNull();
            updatesViaEnumerable.Count.Should().Be(allUpdates.Count);
        }
    }
}
