// <copyright file="DeviceIntegrationsApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

#nullable enable

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
    /// Custom exception for skipping DeviceIntegrations tests when the feature is not available.
    /// </summary>
    public class DeviceIntegrationsTestSkipException(string message) : Exception(message);
    /// <summary>
    /// Integration tests for DeviceIntegrationsApi covering all 4 available endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/device-integrations - ListDeviceIntegrations
    /// 2. GET /api/v1/device-integrations/{deviceIntegrationId} - GetDeviceIntegrationAsync
    /// 3. POST /api/v1/device-integrations/{deviceIntegrationId}/lifecycle/activate - ActivateDeviceIntegrationAsync
    /// 4. POST /api/v1/device-integrations/{deviceIntegrationId}/lifecycle/deactivate - DeactivateDeviceIntegrationAsync
    /// 
    /// Note: This API requires the Device Signal Collection Policy feature to be enabled.
    /// The API manages third-party device signal providers like CrowdStrike, Windows Security Center,
    /// Chrome OS Verified Access, OSQuery, and Android Zero Trust.
    /// 
    /// Test Strategy: Tests use existing device integrations that are pre-configured in the org.
    /// Lifecycle tests (activate/deactivate) restore the original state after testing.
    /// </summary>
    public class DeviceIntegrationsApiTests
    {
        private readonly DeviceIntegrationsApi _deviceIntegrationsApi = new();

        /// <summary>
        /// Tests listing all device integrations.
        /// Validates that the list endpoint returns device integrations with proper properties.
        /// 
        /// API: GET /api/v1/device-integrations
        /// </summary>
        [Fact]
        public async Task GivenDeviceIntegrationsApi_WhenListingDeviceIntegrations_ThenReturnsIntegrationsList()
        {
            try
            {
                // Act
                var deviceIntegrations = await _deviceIntegrationsApi
                    .ListDeviceIntegrations()
                    .ToListAsync();

                // Assert
                deviceIntegrations.Should().NotBeNull();
                deviceIntegrations.Should().NotBeEmpty("Expected at least one device integration to be available");

                // Validate first integration has required properties
                var firstIntegration = deviceIntegrations.First();
                firstIntegration.Id.Should().NotBeNullOrEmpty();
                firstIntegration.DisplayName.Should().NotBeNullOrEmpty();
                firstIntegration.Status.Should().NotBeNull();
                firstIntegration.Platform.Should().NotBeNull();

                // Validate we have various types of integrations (CrowdStrike, OSQuery, Chrome, etc.)
                var integrationNames = deviceIntegrations.Select(d => d.DisplayName).Distinct().ToList();
                integrationNames.Should().NotBeEmpty();

                // Validate platforms are valid enum values
                var validPlatforms = new[] 
                { 
                    DeviceIntegrationsPlatform.ANDROID, 
                    DeviceIntegrationsPlatform.CHROMEOS, 
                    DeviceIntegrationsPlatform.IOS, 
                    DeviceIntegrationsPlatform.MACOS, 
                    DeviceIntegrationsPlatform.WINDOWS 
                };
                foreach (var integration in deviceIntegrations)
                {
                    validPlatforms.Should().Contain(integration.Platform.Value);
                }
            }
            catch (ApiException ex) when (ex.ErrorCode == 403 || ex.Message.Contains("E0000015"))
            {
                // Device Signal Collection Policy feature may not be enabled
                throw new DeviceIntegrationsTestSkipException(
                    $"Device Integrations API is not available. Enable 'Device Signal Collection Policy' feature. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Tests retrieving a specific device integration by ID.
        /// 
        /// API: GET /api/v1/device-integrations/{deviceIntegrationId}
        /// </summary>
        [Fact]
        public async Task GivenDeviceIntegrationsApi_WhenGettingSpecificIntegration_ThenReturnsIntegrationDetails()
        {
            var deviceIntegrations = await _deviceIntegrationsApi
                .ListDeviceIntegrations()
                .ToListAsync();
            try
            {
                // Arrange - First get a list to find an integration ID
                if (deviceIntegrations == null) throw new ArgumentNullException(nameof(deviceIntegrations));

                if (!deviceIntegrations.Any())
                {
                    throw new DeviceIntegrationsTestSkipException("No device integrations available for testing");
                }

                var integrationToGet = deviceIntegrations.First();

                // Act
                var retrievedIntegration = await _deviceIntegrationsApi.GetDeviceIntegrationAsync(integrationToGet.Id);

                // Assert
                retrievedIntegration.Should().NotBeNull();
                retrievedIntegration.Id.Should().Be(integrationToGet.Id);
                retrievedIntegration.DisplayName.Should().Be(integrationToGet.DisplayName);
                retrievedIntegration.Status.Should().Be(integrationToGet.Status);
                retrievedIntegration.Platform.Should().Be(integrationToGet.Platform);
                retrievedIntegration.Links.Should().NotBeNull();
            }
            catch (ApiException ex) when (ex.ErrorCode == 403 || ex.Message.Contains("E0000015"))
            {
                throw new DeviceIntegrationsTestSkipException(
                    $"Device Integrations API is not available. Enable 'Device Signal Collection Policy' feature. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Tests the activate and deactivate lifecycle operations on a device integration.
        /// The test finds a DEACTIVATED integration, activates it, verifies the change,
        /// then deactivates it to restore the original state.
        /// 
        /// APIs:
        /// - POST /api/v1/device-integrations/{deviceIntegrationId}/lifecycle/activate
        /// - POST /api/v1/device-integrations/{deviceIntegrationId}/lifecycle/deactivate
        /// 
        /// Cleanup: The integration is returned to DEACTIVATED state after the test.
        /// </summary>
        [Fact]
        public async Task GivenDeviceIntegrationsApi_WhenActivatingAndDeactivating_ThenLifecycleOperationsWork()
        {
            DeviceIntegrations? testIntegration = null;
            DeviceIntegrationsStatus? originalStatus = null;

            try
            {
                // Arrange - Find a DEACTIVATED integration to test with
                var deviceIntegrations = await _deviceIntegrationsApi
                    .ListDeviceIntegrations()
                    .ToListAsync();

                if (!deviceIntegrations.Any())
                {
                    throw new DeviceIntegrationsTestSkipException("No device integrations available for testing");
                }

                // Find a deactivated integration (prefer CrowdStrike or Chrome Device Trust for testing)
                testIntegration = deviceIntegrations
                    .FirstOrDefault(d => d.Status == DeviceIntegrationsStatus.DEACTIVATED);

                if (testIntegration == null)
                {
                    // If all are active, find one to deactivate temporarily
                    testIntegration = deviceIntegrations
                        .FirstOrDefault(d => d.Status == DeviceIntegrationsStatus.ACTIVE);

                    if (testIntegration == null)
                    {
                        throw new DeviceIntegrationsTestSkipException("No suitable device integration found for lifecycle testing");
                    }

                    originalStatus = DeviceIntegrationsStatus.ACTIVE;

                    // Deactivate it first
                    var deactivatedIntegration = await _deviceIntegrationsApi.DeactivateDeviceIntegrationAsync(testIntegration.Id);
                    deactivatedIntegration.Status.Should().Be(DeviceIntegrationsStatus.DEACTIVATED);
                }
                else
                {
                    originalStatus = DeviceIntegrationsStatus.DEACTIVATED;
                }

                // Act - Activate the integration
                await Task.Delay(1000); // Brief delay for eventual consistency
                var activatedIntegration = await _deviceIntegrationsApi.ActivateDeviceIntegrationAsync(testIntegration.Id);

                // Assert activation
                activatedIntegration.Should().NotBeNull();
                activatedIntegration.Id.Should().Be(testIntegration.Id);
                activatedIntegration.Status.Should().Be(DeviceIntegrationsStatus.ACTIVE);

                // Verify by getting the integration
                var verifyActivated = await _deviceIntegrationsApi.GetDeviceIntegrationAsync(testIntegration.Id);
                verifyActivated.Status.Should().Be(DeviceIntegrationsStatus.ACTIVE);

                // Act - Deactivate the integration
                await Task.Delay(1000); // Brief delay for eventual consistency
                var deactivatedResult = await _deviceIntegrationsApi.DeactivateDeviceIntegrationAsync(testIntegration.Id);

                // Assert deactivation
                deactivatedResult.Should().NotBeNull();
                deactivatedResult.Id.Should().Be(testIntegration.Id);
                deactivatedResult.Status.Should().Be(DeviceIntegrationsStatus.DEACTIVATED);

                // Verify by getting the integration
                var verifyDeactivated = await _deviceIntegrationsApi.GetDeviceIntegrationAsync(testIntegration.Id);
                verifyDeactivated.Status.Should().Be(DeviceIntegrationsStatus.DEACTIVATED);
            }
            catch (ApiException ex) when (ex.ErrorCode == 403 || ex.Message.Contains("E0000015"))
            {
                throw new DeviceIntegrationsTestSkipException(
                    $"Device Integrations API is not available. Enable 'Device Signal Collection Policy' feature. Error: {ex.Message}");
            }
            finally
            {
                // Cleanup - Restore original state if needed
                if (testIntegration != null && originalStatus == DeviceIntegrationsStatus.ACTIVE)
                {
                    try
                    {
                        await Task.Delay(1000);
                        await _deviceIntegrationsApi.ActivateDeviceIntegrationAsync(testIntegration.Id);
                    }
                    catch
                    {
                        // Best effort cleanup
                    }
                }
            }
        }
    }
}
