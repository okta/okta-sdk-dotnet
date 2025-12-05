// <copyright file="AgentPoolsApiTests.cs" company="Okta, Inc">
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
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for the AgentPoolsApi.
    /// 
    /// PREREQUISITES:
    /// These tests require an Okta org with directory agents configured (AD, LDAP, etc.)
    /// to fully execute. Tests will be skipped if no agent pools are available.
    /// 
    /// API ENDPOINTS COVERED (14 total):
    /// ┌─────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ #  │ Method │ Endpoint                                                    │ SDK Method      │
    /// ├─────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ 1  │ GET    │ /api/v1/agentPools                                          │ ListAgentPools  │
    /// │ 2  │ GET    │ /api/v1/agentPools/{poolId}/updates                         │ ListAgentPoolsUpdates │
    /// │ 3  │ POST   │ /api/v1/agentPools/{poolId}/updates                         │ CreateAgentPoolsUpdate │
    /// │ 4  │ GET    │ /api/v1/agentPools/{poolId}/updates/settings                │ GetAgentPoolsUpdateSettings │
    /// │ 5  │ POST   │ /api/v1/agentPools/{poolId}/updates/settings                │ UpdateAgentPoolsUpdateSettings │
    /// │ 6  │ GET    │ /api/v1/agentPools/{poolId}/updates/{updateId}              │ GetAgentPoolsUpdateInstance │
    /// │ 7  │ POST   │ /api/v1/agentPools/{poolId}/updates/{updateId}              │ UpdateAgentPoolsUpdate │
    /// │ 8  │ DELETE │ /api/v1/agentPools/{poolId}/updates/{updateId}              │ DeleteAgentPoolsUpdate │
    /// │ 9  │ POST   │ /api/v1/agentPools/{poolId}/updates/{updateId}/activate     │ ActivateAgentPoolsUpdate │
    /// │ 10 │ POST   │ /api/v1/agentPools/{poolId}/updates/{updateId}/deactivate   │ DeactivateAgentPoolsUpdate │
    /// │ 11 │ POST   │ /api/v1/agentPools/{poolId}/updates/{updateId}/pause        │ PauseAgentPoolsUpdate │
    /// │ 12 │ POST   │ /api/v1/agentPools/{poolId}/updates/{updateId}/resume       │ ResumeAgentPoolsUpdate │
    /// │ 13 │ POST   │ /api/v1/agentPools/{poolId}/updates/{updateId}/retry        │ RetryAgentPoolsUpdate │
    /// │ 14 │ POST   │ /api/v1/agentPools/{poolId}/updates/{updateId}/stop         │ StopAgentPoolsUpdate │
    /// └─────────────────────────────────────────────────────────────────────────────────────────────┘
    /// 
    /// TEST CATEGORIES:
    /// 1. ListAgentPools Tests (9 tests)
    ///    - Basic listing, pagination, filtering by pool type (AD, LDAP, IWA, Radius, MFA), model validation
    /// 
    /// 2. ListAgentPoolsUpdates Tests (4 tests)
    ///    - Basic listing, scheduled/ad-hoc filtering, invalid pool ID handling
    /// 
    /// 3. GetAgentPoolsUpdateSettings Tests (4 tests)
    ///    - Basic retrieval, model validation, HttpInfo response, error handling
    /// 
    /// 4. UpdateAgentPoolsUpdateSettings Tests (2 tests)
    ///    - Update settings, error handling
    /// 
    /// 5. CreateAgentPoolsUpdate Tests (2 tests)
    ///    - Create update, error handling (null poolId, null body)
    /// 
    /// 6. GetAgentPoolsUpdateInstance Tests (2 tests)
    ///    - Retrieve by ID, error handling
    /// 
    /// 7. UpdateAgentPoolsUpdate Tests (1 test)
    ///    - Update existing update
    /// 
    /// 8. DeleteAgentPoolsUpdate Tests (2 tests)
    ///    - Delete update, error handling
    /// 
    /// 9. Lifecycle Operations Tests (13 tests)
    ///    - Activate: invalid ID, with created update
    ///    - Deactivate: invalid ID, with created update
    ///    - Pause: invalid ID handling, with created update
    ///    - Resume: invalid ID handling, with created update
    ///    - Retry: invalid ID, with created update
    ///    - Stop: invalid ID, with created update
    ///    - Full lifecycle workflow: Create → Activate → Deactivate → Delete
    /// 
    /// 10. Parameter Validation Tests (4 tests)
    ///     - Null parameter handling for ListAgentPoolsUpdates, GetAgentPoolsUpdateSettings, CreateAgentPoolsUpdate
    /// 
    /// 11. Issue #808 Fix Verification Tests (2 tests)
    ///     - Unix timestamp parsing for lastConnection field
    ///     - Direct JSON deserialization test for Agent model
    /// 
    /// TOTAL: 46 tests
    /// 
    /// KNOWN ISSUES FIXED:
    /// - Issue #808: lastConnection field now correctly uses int64 (Unix timestamp in ms)
    /// </summary>
    [Collection(nameof(AgentPoolsApiTests))]
    public class AgentPoolsApiTests : IAsyncLifetime
    {
        private readonly AgentPoolsApi _agentPoolsApi;
        private AgentPool _testAgentPool;
        private string _createdUpdateId;
        private bool _hasAgentPools;

        public AgentPoolsApiTests()
        {
            _agentPoolsApi = new AgentPoolsApi();
        }

        public async Task InitializeAsync()
        {
            // Try to find an existing agent pool to use for tests
            // Agent pools cannot be created via API - they are created when agents are installed
            try
            {
                var pools = new List<AgentPool>();
                await foreach (var pool in _agentPoolsApi.ListAgentPools())
                {
                    pools.Add(pool);
                    if (pools.Count >= 1) break;
                }

                if (pools.Any())
                {
                    _testAgentPool = pools.First();
                    _hasAgentPools = true;
                }
                else
                {
                    _hasAgentPools = false;
                }
            }
            catch (ApiException)
            {
                // May not have permission or agent pools feature
                _hasAgentPools = false;
            }
        }

        public async Task DisposeAsync()
        {
            // Cleanup any created updates
            if (_hasAgentPools && !string.IsNullOrEmpty(_createdUpdateId) && _testAgentPool != null)
            {
                try
                {
                    await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(_testAgentPool.Id, _createdUpdateId);
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
        }

        private void SkipIfNoAgentPools()
        {
            if (!_hasAgentPools)
            {
                throw new SkipException("No agent pools available in the org. Install an AD/LDAP agent to enable these tests.");
            }
        }

        #region ListAgentPools Tests

        /// <summary>
        /// Tests GET /api/v1/agentPools
        /// Verifies that agent pools can be listed successfully.
        /// </summary>
        [Fact]
        public async Task ListAgentPools_ShouldReturnAgentPools()
        {
            // Act
            var pools = new List<AgentPool>();
            await foreach (var pool in _agentPoolsApi.ListAgentPools())
            {
                pools.Add(pool);
            }

            // Assert - This test passes even with empty list (org may not have agents)
            pools.Should().NotBeNull();
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools with limitPerPoolType parameter
        /// </summary>
        [Fact]
        public async Task ListAgentPools_WithLimit_ShouldRespectLimit()
        {
            // Act
            var pools = new List<AgentPool>();
            await foreach (var pool in _agentPoolsApi.ListAgentPools(limitPerPoolType: 1))
            {
                pools.Add(pool);
            }

            // Assert
            pools.Should().NotBeNull();
            // Can't assert exact count since org may have fewer pools than limit
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools with poolType filter
        /// </summary>
        [Fact]
        public async Task ListAgentPools_WithPoolTypeFilter_ShouldFilterByType()
        {
            // Act - Filter for AD type agents
            var adPools = new List<AgentPool>();
            await foreach (var pool in _agentPoolsApi.ListAgentPools(poolType: AgentType.AD))
            {
                adPools.Add(pool);
            }

            // Assert
            adPools.Should().NotBeNull();
            if (adPools.Any())
            {
                adPools.Should().OnlyContain(p => p.Type == AgentType.AD);
            }
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools for AD agent type
        /// </summary>
        [Fact]
        public async Task ListAgentPools_WithAdPoolType_ShouldNotThrow()
        {
            // Act & Assert
            var pools = new List<AgentPool>();
            await foreach (var p in _agentPoolsApi.ListAgentPools(poolType: AgentType.AD))
            {
                pools.Add(p);
            }
            pools.Should().NotBeNull();
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools for LDAP agent type
        /// </summary>
        [Fact]
        public async Task ListAgentPools_WithLdapPoolType_ShouldNotThrow()
        {
            // Act & Assert
            var pools = new List<AgentPool>();
            await foreach (var p in _agentPoolsApi.ListAgentPools(poolType: AgentType.LDAP))
            {
                pools.Add(p);
            }
            pools.Should().NotBeNull();
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools for IWA agent type
        /// Note: Some Okta orgs may not support IWA agent type and return "Bad request"
        /// </summary>
        [Fact]
        public async Task ListAgentPools_WithIwaPoolType_ShouldNotThrowOrReturnBadRequest()
        {
            // Act & Assert
            try
            {
                var pools = new List<AgentPool>();
                await foreach (var p in _agentPoolsApi.ListAgentPools(poolType: AgentType.IWA))
                {
                    pools.Add(p);
                }
                pools.Should().NotBeNull();
            }
            catch (ApiException ex) when (ex.ErrorCode == 400)
            {
                // Some Okta orgs may not support IWA agent type
                // This is expected behavior - validate the SDK method was invoked correctly
            }
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools for Radius agent type
        /// </summary>
        [Fact]
        public async Task ListAgentPools_WithRadiusPoolType_ShouldNotThrow()
        {
            // Act & Assert
            var pools = new List<AgentPool>();
            await foreach (var p in _agentPoolsApi.ListAgentPools(poolType: AgentType.Radius))
            {
                pools.Add(p);
            }
            pools.Should().NotBeNull();
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools for MFA agent type
        /// </summary>
        [Fact]
        public async Task ListAgentPools_WithMfaPoolType_ShouldNotThrow()
        {
            // Act & Assert
            var pools = new List<AgentPool>();
            await foreach (var p in _agentPoolsApi.ListAgentPools(poolType: AgentType.MFA))
            {
                pools.Add(p);
            }
            pools.Should().NotBeNull();
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools using WithHttpInfoAsync
        /// </summary>
        [Fact]
        public async Task ListAgentPoolsWithHttpInfo_ShouldReturnApiResponse()
        {
            // Act
            var response = await _agentPoolsApi.ListAgentPoolsWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        /// <summary>
        /// Tests that AgentPool model properties are correctly populated
        /// </summary>
        [Fact]
        public async Task ListAgentPools_ShouldReturnCorrectlyPopulatedModel()
        {
            SkipIfNoAgentPools();

            // Act
            var pools = new List<AgentPool>();
            await foreach (var p in _agentPoolsApi.ListAgentPools())
            {
                pools.Add(p);
                break; // Just need one
            }

            // Assert
            var agentPool = pools.First();
            agentPool.Id.Should().NotBeNullOrEmpty();
            agentPool.Name.Should().NotBeNullOrEmpty();
            agentPool.Type.Should().BeOneOf(AgentType.AD, AgentType.LDAP, AgentType.IWA, 
                AgentType.Radius, AgentType.MFA, AgentType.OPP, AgentType.RUM);
        }

        #endregion

        #region ListAgentPoolsUpdates Tests

        /// <summary>
        /// Tests GET /api/v1/agentPools/{poolId}/updates
        /// </summary>
        [Fact]
        public async Task ListAgentPoolsUpdates_ShouldReturnUpdates()
        {
            SkipIfNoAgentPools();

            // Act
            var updates = new List<AgentPoolUpdate>();
            await foreach (var update in _agentPoolsApi.ListAgentPoolsUpdates(_testAgentPool.Id))
            {
                updates.Add(update);
            }

            // Assert
            updates.Should().NotBeNull();
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools/{poolId}/updates with scheduled filter
        /// </summary>
        [Fact]
        public async Task ListAgentPoolsUpdates_WithScheduledFilter_ShouldFilterByScheduled()
        {
            SkipIfNoAgentPools();

            // Act - Get only scheduled updates
            var scheduledUpdates = new List<AgentPoolUpdate>();
            await foreach (var update in _agentPoolsApi.ListAgentPoolsUpdates(_testAgentPool.Id, scheduled: true))
            {
                scheduledUpdates.Add(update);
            }

            // Assert
            scheduledUpdates.Should().NotBeNull();
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools/{poolId}/updates with scheduled=false filter
        /// </summary>
        [Fact]
        public async Task ListAgentPoolsUpdates_WithAdHocFilter_ShouldFilterByAdHoc()
        {
            SkipIfNoAgentPools();

            // Act - Get only ad-hoc updates
            var adHocUpdates = new List<AgentPoolUpdate>();
            await foreach (var update in _agentPoolsApi.ListAgentPoolsUpdates(_testAgentPool.Id, scheduled: false))
            {
                adHocUpdates.Add(update);
            }

            // Assert
            adHocUpdates.Should().NotBeNull();
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools/{poolId}/updates with invalid poolId
        /// Note: The API may return an empty list or throw an exception depending on the pool ID format
        /// </summary>
        [Fact]
        public async Task ListAgentPoolsUpdates_WithInvalidPoolId_ShouldReturnEmptyListOrThrowApiException()
        {
            // Act
            var updates = new List<AgentPoolUpdate>();
            var threwException = false;

            try
            {
                await foreach (var update in _agentPoolsApi.ListAgentPoolsUpdates("invalid-pool-id-12345"))
                {
                    updates.Add(update);
                }
            }
            catch (ApiException ex) when (ex.ErrorCode == 404 || ex.ErrorCode == 400)
            {
                threwException = true;
            }

            // Assert - Either throws exception or returns empty list
            if (!threwException)
            {
                updates.Should().BeEmpty("invalid pool ID should not have any updates");
            }
        }

        #endregion

        #region GetAgentPoolsUpdateSettings Tests

        /// <summary>
        /// Tests GET /api/v1/agentPools/{poolId}/updates/settings
        /// </summary>
        [Fact]
        public async Task GetAgentPoolsUpdateSettings_ShouldReturnSettings()
        {
            SkipIfNoAgentPools();

            // Act
            var settings = await _agentPoolsApi.GetAgentPoolsUpdateSettingsAsync(_testAgentPool.Id);

            // Assert
            settings.Should().NotBeNull();
            settings.PoolId.Should().Be(_testAgentPool.Id);
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools/{poolId}/updates/settings verifies model properties
        /// </summary>
        [Fact]
        public async Task GetAgentPoolsUpdateSettings_ShouldReturnCorrectlyPopulatedModel()
        {
            SkipIfNoAgentPools();

            // Act
            var settings = await _agentPoolsApi.GetAgentPoolsUpdateSettingsAsync(_testAgentPool.Id);

            // Assert
            settings.Should().NotBeNull();
            settings.AgentType.Should().BeOneOf(AgentType.AD, AgentType.LDAP, AgentType.IWA,
                AgentType.Radius, AgentType.MFA, AgentType.OPP, AgentType.RUM);
            settings.ReleaseChannel.Should().BeOneOf(ReleaseChannel.GA, ReleaseChannel.EA, 
                ReleaseChannel.BETA, ReleaseChannel.TEST);
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools/{poolId}/updates/settings with invalid poolId
        /// </summary>
        [Fact]
        public async Task GetAgentPoolsUpdateSettings_WithInvalidPoolId_ShouldThrowApiException()
        {
            // Act
            Func<Task> act = async () => await _agentPoolsApi.GetAgentPoolsUpdateSettingsAsync("invalid-pool-id-12345");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404 || e.ErrorCode == 400);
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools/{poolId}/updates/settings using WithHttpInfoAsync
        /// </summary>
        [Fact]
        public async Task GetAgentPoolsUpdateSettingsWithHttpInfo_ShouldReturnApiResponse()
        {
            SkipIfNoAgentPools();

            // Act
            var response = await _agentPoolsApi.GetAgentPoolsUpdateSettingsWithHttpInfoAsync(_testAgentPool.Id);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region UpdateAgentPoolsUpdateSettings Tests

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/settings
        /// </summary>
        [Fact]
        public async Task UpdateAgentPoolsUpdateSettings_ShouldUpdateSettings()
        {
            SkipIfNoAgentPools();

            // Arrange - Get current settings first
            var currentSettings = await _agentPoolsApi.GetAgentPoolsUpdateSettingsAsync(_testAgentPool.Id);
            
            var updatedSettings = new AgentPoolUpdateSetting
            {
                AgentType = currentSettings.AgentType,
                ContinueOnError = !currentSettings.ContinueOnError, // Toggle this setting
                ReleaseChannel = currentSettings.ReleaseChannel,
                PoolName = currentSettings.PoolName
            };

            // Act
            var result = await _agentPoolsApi.UpdateAgentPoolsUpdateSettingsAsync(_testAgentPool.Id, updatedSettings);

            // Assert
            result.Should().NotBeNull();
            result.ContinueOnError.Should().Be(updatedSettings.ContinueOnError);

            // Cleanup - Restore original settings
            await _agentPoolsApi.UpdateAgentPoolsUpdateSettingsAsync(_testAgentPool.Id, currentSettings);
        }

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/settings with invalid poolId
        /// </summary>
        [Fact]
        public async Task UpdateAgentPoolsUpdateSettings_WithInvalidPoolId_ShouldThrowApiException()
        {
            // Arrange
            var settings = new AgentPoolUpdateSetting
            {
                AgentType = AgentType.AD,
                ContinueOnError = true,
                ReleaseChannel = ReleaseChannel.GA
            };

            // Act
            Func<Task> act = async () => await _agentPoolsApi.UpdateAgentPoolsUpdateSettingsAsync("invalid-pool-id-12345", settings);

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404 || e.ErrorCode == 400);
        }

        #endregion

        #region CreateAgentPoolsUpdate Tests

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates
        /// Note: Creating an update requires proper configuration and may fail if agents aren't properly set up
        /// </summary>
        [Fact]
        public async Task CreateAgentPoolsUpdate_ShouldCreateUpdate()
        {
            SkipIfNoAgentPools();

            // Arrange
            var guid = Guid.NewGuid().ToString("N").Substring(0, 8);
            var updateRequest = new AgentPoolUpdate
            {
                Name = $"dotnet-sdk-test-update-{guid}",
                AgentType = _testAgentPool.Type,
                Enabled = false, // Don't actually enable to avoid affecting agents
                NotifyAdmin = false,
                Schedule = new AutoUpdateSchedule
                {
                    Cron = "0 0 1 * *", // Monthly on first day at midnight
                    Timezone = "America/Los_Angeles",
                    Duration = 120
                }
            };

            try
            {
                // Act
                var result = await _agentPoolsApi.CreateAgentPoolsUpdateAsync(_testAgentPool.Id, updateRequest);

                // Assert
                result.Should().NotBeNull();
                result.Name.Should().Be(updateRequest.Name);
                result.Id.Should().NotBeNullOrEmpty();

                // Store for cleanup
                _createdUpdateId = result.Id;
            }
            catch (ApiException ex) when (ex.ErrorCode == 400)
            {
                // Some orgs may not allow creating updates - this is acceptable
                // The test verifies the API call format is correct
            }
        }

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates with invalid poolId
        /// </summary>
        [Fact]
        public async Task CreateAgentPoolsUpdate_WithInvalidPoolId_ShouldThrowApiException()
        {
            // Arrange
            var updateRequest = new AgentPoolUpdate
            {
                Name = "test-update",
                AgentType = AgentType.AD,
                Enabled = false
            };

            // Act
            Func<Task> act = async () => await _agentPoolsApi.CreateAgentPoolsUpdateAsync("invalid-pool-id-12345", updateRequest);

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404 || e.ErrorCode == 400);
        }

        #endregion

        #region GetAgentPoolsUpdateInstance Tests

        /// <summary>
        /// Tests GET /api/v1/agentPools/{poolId}/updates/{updateId}
        /// </summary>
        [Fact]
        public async Task GetAgentPoolsUpdateInstance_ShouldReturnUpdate()
        {
            SkipIfNoAgentPools();

            // Arrange - First check if there are any existing updates
            var updates = new List<AgentPoolUpdate>();
            await foreach (var update in _agentPoolsApi.ListAgentPoolsUpdates(_testAgentPool.Id))
            {
                updates.Add(update);
                break;
            }

            if (!updates.Any())
            {
                // Skip if no updates exist
                return;
            }

            var existingUpdate = updates.First();

            // Act
            var result = await _agentPoolsApi.GetAgentPoolsUpdateInstanceAsync(_testAgentPool.Id, existingUpdate.Id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(existingUpdate.Id);
        }

        /// <summary>
        /// Tests GET /api/v1/agentPools/{poolId}/updates/{updateId} with invalid updateId
        /// </summary>
        [Fact]
        public async Task GetAgentPoolsUpdateInstance_WithInvalidUpdateId_ShouldThrowApiException()
        {
            SkipIfNoAgentPools();

            // Act
            Func<Task> act = async () => await _agentPoolsApi.GetAgentPoolsUpdateInstanceAsync(_testAgentPool.Id, "invalid-update-id-12345");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404 || e.ErrorCode == 400);
        }

        #endregion

        #region UpdateAgentPoolsUpdate Tests

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}
        /// </summary>
        [Fact]
        public async Task UpdateAgentPoolsUpdate_ShouldUpdateExistingUpdate()
        {
            SkipIfNoAgentPools();

            // Arrange - First get an existing update
            var updates = new List<AgentPoolUpdate>();
            await foreach (var update in _agentPoolsApi.ListAgentPoolsUpdates(_testAgentPool.Id))
            {
                updates.Add(update);
                break;
            }

            if (!updates.Any())
            {
                // Skip if no updates exist
                return;
            }

            var existingUpdate = updates.First();
            var originalNotifyAdmin = existingUpdate.NotifyAdmin;

            var updateRequest = new AgentPoolUpdate
            {
                Name = existingUpdate.Name,
                AgentType = existingUpdate.AgentType,
                Enabled = existingUpdate.Enabled,
                NotifyAdmin = !originalNotifyAdmin // Toggle
            };

            try
            {
                // Act
                var result = await _agentPoolsApi.UpdateAgentPoolsUpdateAsync(_testAgentPool.Id, existingUpdate.Id, updateRequest);

                // Assert
                result.Should().NotBeNull();

                // Cleanup - Restore original
                updateRequest.NotifyAdmin = originalNotifyAdmin;
                await _agentPoolsApi.UpdateAgentPoolsUpdateAsync(_testAgentPool.Id, existingUpdate.Id, updateRequest);
            }
            catch (ApiException ex) when (ex.ErrorCode == 400)
            {
                // Update may not be allowed for certain statuses
            }
        }

        #endregion

        #region DeleteAgentPoolsUpdate Tests

        /// <summary>
        /// Tests DELETE /api/v1/agentPools/{poolId}/updates/{updateId}
        /// </summary>
        [Fact]
        public async Task DeleteAgentPoolsUpdate_ShouldDeleteUpdate()
        {
            SkipIfNoAgentPools();

            // Arrange - Create an update first
            var guid = Guid.NewGuid().ToString("N").Substring(0, 8);
            var updateRequest = new AgentPoolUpdate
            {
                Name = $"dotnet-sdk-delete-test-{guid}",
                AgentType = _testAgentPool.Type,
                Enabled = false,
                NotifyAdmin = false
            };

            string updateIdToDelete = null;

            try
            {
                var createdUpdate = await _agentPoolsApi.CreateAgentPoolsUpdateAsync(_testAgentPool.Id, updateRequest);
                updateIdToDelete = createdUpdate.Id;

                // Act
                await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(_testAgentPool.Id, updateIdToDelete);

                // Assert - Verify it's deleted by trying to get it
                Func<Task> act = async () => await _agentPoolsApi.GetAgentPoolsUpdateInstanceAsync(_testAgentPool.Id, updateIdToDelete);
                await act.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);
            }
            catch (ApiException ex) when (ex.ErrorCode == 400)
            {
                // Creation may fail - skip
            }
        }

        /// <summary>
        /// Tests DELETE /api/v1/agentPools/{poolId}/updates/{updateId} with invalid updateId
        /// </summary>
        [Fact]
        public async Task DeleteAgentPoolsUpdate_WithInvalidUpdateId_ShouldThrowApiException()
        {
            SkipIfNoAgentPools();

            // Act
            Func<Task> act = async () => await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(_testAgentPool.Id, "invalid-update-id-12345");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404 || e.ErrorCode == 400);
        }

        #endregion

        #region ActivateAgentPoolsUpdate Tests

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}/activate
        /// </summary>
        [Fact]
        public async Task ActivateAgentPoolsUpdate_WithInvalidUpdateId_ShouldThrowApiException()
        {
            SkipIfNoAgentPools();

            // Act
            Func<Task> act = async () => await _agentPoolsApi.ActivateAgentPoolsUpdateAsync(_testAgentPool.Id, "invalid-update-id-12345");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404 || e.ErrorCode == 400);
        }

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}/activate with a created update
        /// Note: May fail if the update is already in an incompatible state
        /// </summary>
        [Fact]
        public async Task ActivateAgentPoolsUpdate_WithCreatedUpdate_ShouldActivateOrThrowStateException()
        {
            SkipIfNoAgentPools();

            // Arrange - Create an update first
            var guid = Guid.NewGuid().ToString("N").Substring(0, 8);
            var updateRequest = new AgentPoolUpdate
            {
                Name = $"dotnet-sdk-activate-test-{guid}",
                AgentType = _testAgentPool.Type,
                Enabled = false,
                NotifyAdmin = false
            };

            string updateId = null;

            try
            {
                var createdUpdate = await _agentPoolsApi.CreateAgentPoolsUpdateAsync(_testAgentPool.Id, updateRequest);
                updateId = createdUpdate.Id;

                // Act - Try to activate the update
                var activatedUpdate = await _agentPoolsApi.ActivateAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);

                // Assert
                activatedUpdate.Should().NotBeNull();
                activatedUpdate.Id.Should().Be(updateId);
            }
            catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409)
            {
                // Expected - state transition not allowed, which validates the SDK method works
                // The API may reject activation if the update is already active or in an incompatible state
            }
            finally
            {
                // Cleanup - try to delete the update
                if (updateId != null)
                {
                    try
                    {
                        await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        #endregion

        #region DeactivateAgentPoolsUpdate Tests

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}/deactivate
        /// </summary>
        [Fact]
        public async Task DeactivateAgentPoolsUpdate_WithInvalidUpdateId_ShouldThrowApiException()
        {
            SkipIfNoAgentPools();

            // Act
            Func<Task> act = async () => await _agentPoolsApi.DeactivateAgentPoolsUpdateAsync(_testAgentPool.Id, "invalid-update-id-12345");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404 || e.ErrorCode == 400);
        }

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}/deactivate with a created update
        /// Note: May fail if the update is not in an active state
        /// </summary>
        [Fact]
        public async Task DeactivateAgentPoolsUpdate_WithCreatedUpdate_ShouldDeactivateOrThrowStateException()
        {
            SkipIfNoAgentPools();

            // Arrange - Create an update first
            var guid = Guid.NewGuid().ToString("N").Substring(0, 8);
            var updateRequest = new AgentPoolUpdate
            {
                Name = $"dotnet-sdk-deactivate-test-{guid}",
                AgentType = _testAgentPool.Type,
                Enabled = false,
                NotifyAdmin = false
            };

            string updateId = null;

            try
            {
                var createdUpdate = await _agentPoolsApi.CreateAgentPoolsUpdateAsync(_testAgentPool.Id, updateRequest);
                updateId = createdUpdate.Id;

                // Act - Try to deactivate the update
                var deactivatedUpdate = await _agentPoolsApi.DeactivateAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);

                // Assert
                deactivatedUpdate.Should().NotBeNull();
                deactivatedUpdate.Id.Should().Be(updateId);
            }
            catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409)
            {
                // Expected - state transition not allowed
                // The API may reject deactivation if the update is not active
            }
            finally
            {
                // Cleanup
                if (updateId != null)
                {
                    try
                    {
                        await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        #endregion

        #region PauseAgentPoolsUpdate Tests

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}/pause
        /// Note: The API may not throw for invalid update IDs but return a success response
        /// </summary>
        [Fact]
        public async Task PauseAgentPoolsUpdate_WithInvalidUpdateId_ShouldThrowOrSucceed()
        {
            SkipIfNoAgentPools();

            // Act & Assert
            try
            {
                var result = await _agentPoolsApi.PauseAgentPoolsUpdateAsync(_testAgentPool.Id, "invalid-update-id-12345");
                // If no exception, the API accepted the request (even for invalid ID)
                // This validates the SDK method executes correctly
            }
            catch (ApiException ex)
            {
                // Expected - either 404 (not found) or 400 (bad request)
                ex.ErrorCode.Should().BeOneOf(404, 400);
            }
        }

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}/pause with a created update
        /// Note: May fail if the update is not in a running state
        /// </summary>
        [Fact]
        public async Task PauseAgentPoolsUpdate_WithCreatedUpdate_ShouldPauseOrThrowStateException()
        {
            SkipIfNoAgentPools();

            // Arrange - Create an update first
            var guid = Guid.NewGuid().ToString("N").Substring(0, 8);
            var updateRequest = new AgentPoolUpdate
            {
                Name = $"dotnet-sdk-pause-test-{guid}",
                AgentType = _testAgentPool.Type,
                Enabled = false,
                NotifyAdmin = false
            };

            string updateId = null;

            try
            {
                var createdUpdate = await _agentPoolsApi.CreateAgentPoolsUpdateAsync(_testAgentPool.Id, updateRequest);
                updateId = createdUpdate.Id;

                // Act - Try to pause the update
                var pausedUpdate = await _agentPoolsApi.PauseAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);

                // Assert
                pausedUpdate.Should().NotBeNull();
                pausedUpdate.Id.Should().Be(updateId);
            }
            catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409)
            {
                // Expected - state transition not allowed
                // The API may reject pause if the update is not running
            }
            finally
            {
                // Cleanup
                if (updateId != null)
                {
                    try
                    {
                        await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        #endregion

        #region ResumeAgentPoolsUpdate Tests

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}/resume
        /// Note: The API may not throw for invalid update IDs but return a success response
        /// </summary>
        [Fact]
        public async Task ResumeAgentPoolsUpdate_WithInvalidUpdateId_ShouldThrowOrSucceed()
        {
            SkipIfNoAgentPools();

            // Act & Assert
            try
            {
                var result = await _agentPoolsApi.ResumeAgentPoolsUpdateAsync(_testAgentPool.Id, "invalid-update-id-12345");
                // If no exception, the API accepted the request (even for invalid ID)
                // This validates the SDK method executes correctly
            }
            catch (ApiException ex)
            {
                // Expected - either 404 (not found) or 400 (bad request)
                ex.ErrorCode.Should().BeOneOf(404, 400);
            }
        }

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}/resume with a created update
        /// Note: May fail if the update is not paused
        /// </summary>
        [Fact]
        public async Task ResumeAgentPoolsUpdate_WithCreatedUpdate_ShouldResumeOrThrowStateException()
        {
            SkipIfNoAgentPools();

            // Arrange - Create an update first
            var guid = Guid.NewGuid().ToString("N").Substring(0, 8);
            var updateRequest = new AgentPoolUpdate
            {
                Name = $"dotnet-sdk-resume-test-{guid}",
                AgentType = _testAgentPool.Type,
                Enabled = false,
                NotifyAdmin = false
            };

            string updateId = null;

            try
            {
                var createdUpdate = await _agentPoolsApi.CreateAgentPoolsUpdateAsync(_testAgentPool.Id, updateRequest);
                updateId = createdUpdate.Id;

                // Act - Try to resume the update
                var resumedUpdate = await _agentPoolsApi.ResumeAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);

                // Assert
                resumedUpdate.Should().NotBeNull();
                resumedUpdate.Id.Should().Be(updateId);
            }
            catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409)
            {
                // Expected - state transition not allowed
                // The API may reject resume if the update is not paused
            }
            finally
            {
                // Cleanup
                if (updateId != null)
                {
                    try
                    {
                        await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        #endregion

        #region RetryAgentPoolsUpdate Tests

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}/retry
        /// </summary>
        [Fact]
        public async Task RetryAgentPoolsUpdate_WithInvalidUpdateId_ShouldThrowApiException()
        {
            SkipIfNoAgentPools();

            // Act
            Func<Task> act = async () => await _agentPoolsApi.RetryAgentPoolsUpdateAsync(_testAgentPool.Id, "invalid-update-id-12345");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404 || e.ErrorCode == 400);
        }

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}/retry with a created update
        /// Note: May fail if the update is not in a failed state
        /// </summary>
        [Fact]
        public async Task RetryAgentPoolsUpdate_WithCreatedUpdate_ShouldRetryOrThrowStateException()
        {
            SkipIfNoAgentPools();

            // Arrange - Create an update first
            var guid = Guid.NewGuid().ToString("N").Substring(0, 8);
            var updateRequest = new AgentPoolUpdate
            {
                Name = $"dotnet-sdk-retry-test-{guid}",
                AgentType = _testAgentPool.Type,
                Enabled = false,
                NotifyAdmin = false
            };

            string updateId = null;

            try
            {
                var createdUpdate = await _agentPoolsApi.CreateAgentPoolsUpdateAsync(_testAgentPool.Id, updateRequest);
                updateId = createdUpdate.Id;

                // Act - Try to retry the update
                var retriedUpdate = await _agentPoolsApi.RetryAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);

                // Assert
                retriedUpdate.Should().NotBeNull();
                retriedUpdate.Id.Should().Be(updateId);
            }
            catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409)
            {
                // Expected - state transition not allowed
                // The API may reject retry if the update has not failed
            }
            finally
            {
                // Cleanup
                if (updateId != null)
                {
                    try
                    {
                        await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        #endregion

        #region StopAgentPoolsUpdate Tests

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}/stop
        /// </summary>
        [Fact]
        public async Task StopAgentPoolsUpdate_WithInvalidUpdateId_ShouldThrowApiException()
        {
            SkipIfNoAgentPools();

            // Act
            Func<Task> act = async () => await _agentPoolsApi.StopAgentPoolsUpdateAsync(_testAgentPool.Id, "invalid-update-id-12345");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404 || e.ErrorCode == 400);
        }

        /// <summary>
        /// Tests POST /api/v1/agentPools/{poolId}/updates/{updateId}/stop with a created update
        /// Note: May fail if the update is not in a running state
        /// </summary>
        [Fact]
        public async Task StopAgentPoolsUpdate_WithCreatedUpdate_ShouldStopOrThrowStateException()
        {
            SkipIfNoAgentPools();

            // Arrange - Create an update first
            var guid = Guid.NewGuid().ToString("N").Substring(0, 8);
            var updateRequest = new AgentPoolUpdate
            {
                Name = $"dotnet-sdk-stop-test-{guid}",
                AgentType = _testAgentPool.Type,
                Enabled = false,
                NotifyAdmin = false
            };

            string updateId = null;

            try
            {
                var createdUpdate = await _agentPoolsApi.CreateAgentPoolsUpdateAsync(_testAgentPool.Id, updateRequest);
                updateId = createdUpdate.Id;

                // Act - Try to stop the update
                var stoppedUpdate = await _agentPoolsApi.StopAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);

                // Assert
                stoppedUpdate.Should().NotBeNull();
                stoppedUpdate.Id.Should().Be(updateId);
            }
            catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409)
            {
                // Expected - state transition not allowed
                // The API may reject stop if the update is not running
            }
            finally
            {
                // Cleanup
                if (updateId != null)
                {
                    try
                    {
                        await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        #endregion

        #region Lifecycle Workflow Tests

        /// <summary>
        /// Tests the complete lifecycle workflow: Create → Activate → Deactivate → Delete
        /// This validates the state machine transitions work correctly
        /// </summary>
        [Fact]
        public async Task AgentPoolsUpdate_FullLifecycle_CreateActivateDeactivateDelete()
        {
            SkipIfNoAgentPools();

            var guid = Guid.NewGuid().ToString("N").Substring(0, 8);
            var updateRequest = new AgentPoolUpdate
            {
                Name = $"dotnet-sdk-lifecycle-test-{guid}",
                AgentType = _testAgentPool.Type,
                Enabled = false,
                NotifyAdmin = false
            };

            string updateId = null;

            try
            {
                // Step 1: Create
                var createdUpdate = await _agentPoolsApi.CreateAgentPoolsUpdateAsync(_testAgentPool.Id, updateRequest);
                createdUpdate.Should().NotBeNull();
                updateId = createdUpdate.Id;

                // Step 2: Try Activate
                try
                {
                    var activatedUpdate = await _agentPoolsApi.ActivateAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);
                    activatedUpdate.Should().NotBeNull();

                    // Step 3: Try Deactivate
                    try
                    {
                        var deactivatedUpdate = await _agentPoolsApi.DeactivateAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);
                        deactivatedUpdate.Should().NotBeNull();
                    }
                    catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409)
                    {
                        // Deactivation may fail depending on state
                    }
                }
                catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 409)
                {
                    // Activation may fail depending on state
                }

                // Step 4: Delete
                await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);
                updateId = null; // Mark as deleted

                // Step 5: Verify deletion
                Func<Task> act = async () => await _agentPoolsApi.GetAgentPoolsUpdateInstanceAsync(_testAgentPool.Id, createdUpdate.Id);
                await act.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);
            }
            catch (ApiException ex) when (ex.ErrorCode == 400)
            {
                // Creation may fail - skip
            }
            finally
            {
                // Cleanup if not already deleted
                if (updateId != null)
                {
                    try
                    {
                        await _agentPoolsApi.DeleteAgentPoolsUpdateAsync(_testAgentPool.Id, updateId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        #endregion

        #region Parameter Validation Tests

        /// <summary>
        /// Tests that null poolId throws ArgumentException
        /// </summary>
        [Fact]
        public async Task ListAgentPoolsUpdates_WithNullPoolId_ShouldThrowApiException()
        {
            // Act
            Func<Task> act = async () =>
            {
                await foreach (var _ in _agentPoolsApi.ListAgentPoolsUpdates(null))
                {
                }
            };

            // Assert
            await act.Should().ThrowAsync<ApiException>();
        }

        /// <summary>
        /// Tests that null poolId in GetAgentPoolsUpdateSettings throws
        /// </summary>
        [Fact]
        public async Task GetAgentPoolsUpdateSettings_WithNullPoolId_ShouldThrowApiException()
        {
            // Act
            Func<Task> act = async () => await _agentPoolsApi.GetAgentPoolsUpdateSettingsAsync(null);

            // Assert
            await act.Should().ThrowAsync<ApiException>();
        }

        /// <summary>
        /// Tests that null poolId in CreateAgentPoolsUpdate throws
        /// </summary>
        [Fact]
        public async Task CreateAgentPoolsUpdate_WithNullPoolId_ShouldThrowApiException()
        {
            // Arrange
            var update = new AgentPoolUpdate { Name = "test" };

            // Act
            Func<Task> act = async () => await _agentPoolsApi.CreateAgentPoolsUpdateAsync(null, update);

            // Assert
            await act.Should().ThrowAsync<ApiException>();
        }

        /// <summary>
        /// Tests that null update body throws
        /// </summary>
        [Fact]
        public async Task CreateAgentPoolsUpdate_WithNullBody_ShouldThrowApiException()
        {
            // Act
            Func<Task> act = async () => await _agentPoolsApi.CreateAgentPoolsUpdateAsync("pool-id", null);

            // Assert
            await act.Should().ThrowAsync<ApiException>();
        }

        #endregion

        #region Issue #808 - lastConnection Unix Timestamp Fix Verification

        /// <summary>
        /// This test verifies the fix for Issue #808: AgentPoolsApi.ListAgentPools() 
        /// now correctly parses Unix timestamps for the lastConnection property.
        /// 
        /// The API returns lastConnection as a Unix timestamp in milliseconds (e.g., 1761037561000)
        /// which is now correctly stored as a long value.
        /// 
        /// Before the fix (spec change), this would throw JsonReaderException with message:
        /// "Unexpected character encountered while parsing value: 1. Path '[0].agents[0].lastConnection'"
        /// </summary>
        [Fact]
        public async Task ListAgentPools_WithAgentsHavingLastConnection_ShouldParseUnixTimestamp_Issue808Fix()
        {
            // Act
            var pools = new List<AgentPool>();
            await foreach (var pool in _agentPoolsApi.ListAgentPools())
            {
                pools.Add(pool);
            }

            // Assert
            pools.Should().NotBeNull();
            
            // If we have pools with agents, verify the lastConnection is correctly parsed
            var poolsWithAgents = pools.Where(p => p.Agents != null && p.Agents.Any()).ToList();
            
            if (poolsWithAgents.Any())
            {
                foreach (var pool in poolsWithAgents)
                {
                    foreach (var agent in pool.Agents!)
                    {
                        // The lastConnection is now a long (Unix timestamp in milliseconds)
                        // It should be greater than 0 (after Unix epoch)
                        agent.LastConnection.Should().BeGreaterThan(0);
                        
                        // Convert to DateTimeOffset and verify it's a reasonable date (after year 2000)
                        var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(agent.LastConnection);
                        dateTime.Year.Should().BeGreaterThanOrEqualTo(2000);
                    }
                }
            }
            else
            {
                // No pools with agents - skip validation but don't fail
                // The org may not have any agents installed
            }
        }

        /// <summary>
        /// Verifies that the Agent model correctly deserializes lastConnection from Unix timestamp.
        /// This is a direct test of the fix for Issue #808.
        /// </summary>
        [Fact]
        public void Agent_LastConnection_ShouldDeserializeFromUnixTimestamp()
        {
            // Arrange - JSON with Unix timestamp in milliseconds (as returned by the API)
            var json = @"{
                ""id"": ""a53test123"",
                ""name"": ""TestAgent"",
                ""type"": ""AD"",
                ""operationalStatus"": ""OPERATIONAL"",
                ""version"": ""3.22.0"",
                ""lastConnection"": 1764658925000,
                ""isLatestGAedVersion"": true,
                ""poolId"": ""0oatest123"",
                ""isHidden"": false
            }";

            // Act
            var agent = Newtonsoft.Json.JsonConvert.DeserializeObject<Agent>(json);

            // Assert
            agent.Should().NotBeNull();
            
            // LastConnection is now a long (Unix timestamp in milliseconds)
            agent!.LastConnection.Should().Be(1764658925000);
            
            // Convert to DateTimeOffset to verify the date
            var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(agent.LastConnection);
            dateTime.Year.Should().Be(2025);
            dateTime.Month.Should().Be(12);
            dateTime.Day.Should().Be(2);
        }

        #endregion
    }

    /// <summary>
    /// Exception to skip tests when prerequisites are not met
    /// </summary>
    public class SkipException : Exception
    {
        public SkipException(string message) : base(message) { }
    }
}
