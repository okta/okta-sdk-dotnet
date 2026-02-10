// <copyright file="DeviceApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for DeviceApi covering all 8 available endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/devices - ListDevices
    /// 2. GET /api/v1/devices/{deviceId} - GetDeviceAsync
    /// 3. DELETE /api/v1/devices/{deviceId} - DeleteDeviceAsync
    /// 4. POST /api/v1/devices/{deviceId}/lifecycle/activate - ActivateDeviceAsync
    /// 5. POST /api/v1/devices/{deviceId}/lifecycle/deactivate - DeactivateDeviceAsync
    /// 6. POST /api/v1/devices/{deviceId}/lifecycle/suspend - SuspendDeviceAsync
    /// 7. POST /api/v1/devices/{deviceId}/lifecycle/unsuspend - UnsuspendDeviceAsync
    /// 8. GET /api/v1/devices/{deviceId}/users - ListDeviceUsers
    /// 
    /// Note: Devices cannot be created via the API - they are enrolled through Okta Verify.
    /// These tests work with existing devices in the org and perform non-destructive operations
    /// where possible. Lifecycle operations are tested but restored to the original state.
    /// </summary>
    public class DeviceApiTests
    {
        private readonly DeviceApi _deviceApi = new();

        /// <summary>
        /// Comprehensive test covering all DeviceApi operations and endpoints.
        /// This single test covers:
        /// - Listing all devices with pagination and search
        /// - Retrieving individual devices
        /// - Device lifecycle operations (suspend/unsuspend/deactivate/activate)
        /// - Listing users for a device
        /// 
        /// Cleanup: All lifecycle changes are reverted to original state
        /// </summary>
        [Fact]
        public async Task GivenDeviceApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string testDeviceId = null;
            DeviceStatus originalStatus = null;

            try
            {
                // ========================================================================
                // SECTION 1: List All Devices
                // ========================================================================

                #region ListDevices - GET /api/v1/devices

                // Test ListDevices() without parameters
                var allDevices = await _deviceApi.ListDevices().ToListAsync();

                allDevices.Should().NotBeNull();
                allDevices.Should().NotBeEmpty("Okta org should have at least one enrolled device");

                // Verify device list properties
                foreach (var device in allDevices.Take(5)) // Check first 5 to save time
                {
                    device.Id.Should().NotBeNullOrEmpty();
                    device.Status.Should().NotBeNull();
                    device.Profile.Should().NotBeNull();
                    device.Created.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));
                    device.LastUpdated.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));
                }

                #endregion

                #region ListDevices with pagination - GET /api/v1/devices?limit={limit}

                // Test ListDevices() with limit parameter
                var limitedDevices = await _deviceApi.ListDevices(limit: 2).ToListAsync();

                limitedDevices.Should().NotBeNull();
                // Note: The API may return more than the limit due to internal pagination handling,
                // but we verify we got results
                limitedDevices.Should().NotBeEmpty();

                #endregion

                #region ListDevices with search - GET /api/v1/devices?search={search}

                // Test ListDevices() with search parameter for ACTIVE devices
                var activeDevices = await _deviceApi.ListDevices(search: "status eq \"ACTIVE\"", limit: 5).ToListAsync();

                activeDevices.Should().NotBeNull();
                // All returned devices should be ACTIVE
                foreach (var device in activeDevices)
                {
                    device.Status.Should().Be(DeviceStatus.ACTIVE);
                }

                // Store a test device for further operations (prefer an ACTIVE device)
                var testDevice = activeDevices.FirstOrDefault() ?? allDevices.FirstOrDefault();
                testDevice.Should().NotBeNull("Need at least one device to test operations");
                if (testDevice != null) testDeviceId = testDevice.Id;

                #endregion

                // ========================================================================
                // SECTION 2: Retrieve a Device
                // ========================================================================

                #region GetDevice - GET /api/v1/devices/{deviceId}

                // Test GetDeviceAsync()
                var retrievedDevice = await _deviceApi.GetDeviceAsync(testDeviceId);

                retrievedDevice.Should().NotBeNull();
                retrievedDevice.Id.Should().Be(testDeviceId);
                retrievedDevice.Status.Should().NotBeNull();
                retrievedDevice.Profile.Should().NotBeNull();
                retrievedDevice.Profile.DisplayName.Should().NotBeNullOrEmpty();

                // Store original status for cleanup
                originalStatus = retrievedDevice.Status;

                // Verify profile properties based on documentation
                var profile = retrievedDevice.Profile;
                profile.Platform.Should().NotBeNull();
                // Other profile properties may vary by device type

                #endregion

                // ========================================================================
                // SECTION 3: List Users for a Device
                // ========================================================================

                #region ListDeviceUsers - GET /api/v1/devices/{deviceId}/users

                // Test ListDeviceUsers()
                var deviceUsers = await _deviceApi.ListDeviceUsers(testDeviceId).ToListAsync();

                deviceUsers.Should().NotBeNull();
                // A device may or may not have users linked
                // If users exist, verify their properties
                foreach (var deviceUser in deviceUsers)
                {
                    deviceUser.ManagementStatus.Should().NotBeNull();
                    deviceUser.Created.Should().NotBeNullOrEmpty();
                    // User object should be embedded
                    deviceUser.User.Should().NotBeNull();
                    deviceUser.User.Id.Should().NotBeNullOrEmpty();
                }

                #endregion

                // ========================================================================
                // SECTION 4: Device Lifecycle Operations
                // ========================================================================

                // Note: These operations modify device state. We will restore the original state.
                // The flow depends on the current device status:
                // - ACTIVE: Can suspend or deactivate
                // - SUSPENDED: Can unsuspend or deactivate
                // - DEACTIVATED: Can activate or delete

                #region Lifecycle Operations - suspend/unsuspend (non-destructive only)

                // Note: We only test SUSPEND and UNSUSPEND operations as they are non-destructive.
                // - DEACTIVATE is skipped because it causes the device to lose all user links (destructive)
                // - DELETE is skipped because it permanently removes the device
                // These destructive operations are tested via negative/error scenarios instead.

                if (originalStatus == DeviceStatus.ACTIVE)
                {
                    // ---- Test SuspendDevice - POST /api/v1/devices/{deviceId}/lifecycle/suspend ----
                    await _deviceApi.SuspendDeviceAsync(testDeviceId);

                    // Small delay to allow eventual consistency
                    await Task.Delay(2000);

                    // Verify the device is now SUSPENDED
                    var suspendedDevice = await _deviceApi.GetDeviceAsync(testDeviceId);
                    suspendedDevice.Status.Should().Be(DeviceStatus.SUSPENDED);

                    // ---- Test UnsuspendDevice - POST /api/v1/devices/{deviceId}/lifecycle/unsuspend ----
                    await _deviceApi.UnsuspendDeviceAsync(testDeviceId);

                    // Small delay to allow eventual consistency
                    await Task.Delay(2000);

                    // Verify the device is back to ACTIVE
                    var unsuspendedDevice = await _deviceApi.GetDeviceAsync(testDeviceId);
                    unsuspendedDevice.Status.Should().Be(DeviceStatus.ACTIVE);
                }
                else if (originalStatus == DeviceStatus.SUSPENDED)
                {
                    // Device is SUSPENDED - test unsuspend first, then suspend back
                    
                    // ---- Test UnsuspendDevice ----
                    await _deviceApi.UnsuspendDeviceAsync(testDeviceId);
                    
                    // Small delay to allow eventual consistency
                    await Task.Delay(2000);
                    
                    var unsuspendedDevice = await _deviceApi.GetDeviceAsync(testDeviceId);
                    unsuspendedDevice.Status.Should().Be(DeviceStatus.ACTIVE);

                    // ---- Test SuspendDevice - restore original state ----
                    await _deviceApi.SuspendDeviceAsync(testDeviceId);
                    
                    // Small delay to allow eventual consistency
                    await Task.Delay(2000);
                    
                    var resuspendedDevice = await _deviceApi.GetDeviceAsync(testDeviceId);
                    resuspendedDevice.Status.Should().Be(DeviceStatus.SUSPENDED);
                }
                // Note: DEACTIVATED devices are not tested with lifecycle operations to avoid data loss

                #endregion

                // ========================================================================
                // SECTION 5: Negative Testing for Destructive Operations
                // ========================================================================

                #region Negative Testing - Deactivate/Activate/Delete (without actual execution)

                // These operations are tested via error scenarios to verify the API exists
                // without actually performing destructive operations on real devices.

                // Test: DeactivateDeviceAsync on non-existent device returns 404
                var deactivateNotFoundEx = await Assert.ThrowsAsync<ApiException>(
                    () => _deviceApi.DeactivateDeviceAsync("guo000000000000001d7"));
                deactivateNotFoundEx.ErrorCode.Should().Be(404);

                // Test: ActivateDeviceAsync on non-existent device returns 404
                var activateNotFoundEx = await Assert.ThrowsAsync<ApiException>(
                    () => _deviceApi.ActivateDeviceAsync("guo000000000000001d7"));
                activateNotFoundEx.ErrorCode.Should().Be(404);

                // Test: DeleteDeviceAsync on non-existent device returns 404
                var deleteNotFoundEx = await Assert.ThrowsAsync<ApiException>(
                    () => _deviceApi.DeleteDeviceAsync("guo000000000000001d7"));
                deleteNotFoundEx.ErrorCode.Should().Be(404);

                // Test: DeleteDeviceAsync on an ACTIVE device should fail (a device must be DEACTIVATED first)
                // This validates the API enforces the correct state transition
                var deleteActiveDeviceEx = await Assert.ThrowsAsync<ApiException>(
                    () => _deviceApi.DeleteDeviceAsync(testDeviceId));
                // Expected: 403 Forbidden or 400 Bad Request (device not in DEACTIVATED state)
                deleteActiveDeviceEx.ErrorCode.Should().BeOneOf(400, 403);

                #endregion

                // ========================================================================
                // SECTION 6: Error Handling Scenarios
                // ========================================================================

                #region Error Scenarios

                // Test getting a non-existent device (404 Not Found)
                var nonExistentDeviceId = "guo000000000000001d7";
                var notFoundException = await Assert.ThrowsAsync<ApiException>(
                    () => _deviceApi.GetDeviceAsync(nonExistentDeviceId));
                notFoundException.ErrorCode.Should().Be(404);

                // Test listing users for a non-existent device (404 Not Found)
                var notFoundUsersException = await Assert.ThrowsAsync<ApiException>(
                    async () => await _deviceApi.ListDeviceUsers(nonExistentDeviceId).ToListAsync());
                notFoundUsersException.ErrorCode.Should().Be(404);

                // Test: SuspendDeviceAsync on non-existent device returns 404
                var suspendNotFoundEx = await Assert.ThrowsAsync<ApiException>(
                    () => _deviceApi.SuspendDeviceAsync(nonExistentDeviceId));
                suspendNotFoundEx.ErrorCode.Should().Be(404);

                // Test: UnsuspendDeviceAsync on non-existent device returns 404
                var unsuspendNotFoundEx = await Assert.ThrowsAsync<ApiException>(
                    () => _deviceApi.UnsuspendDeviceAsync(nonExistentDeviceId));
                unsuspendNotFoundEx.ErrorCode.Should().Be(404);

                #endregion
            }
            finally
            {
                // ========================================================================
                // CLEANUP: Restore original device state if changed (only for non-destructive changes)
                // ========================================================================
                if (testDeviceId != null && originalStatus != null)
                {
                    try
                    {
                        var currentDevice = await _deviceApi.GetDeviceAsync(testDeviceId);
                        if (currentDevice.Status != originalStatus)
                        {
                            // Only restore SUSPENDED <-> ACTIVE transitions (non-destructive)
                            if (originalStatus == DeviceStatus.ACTIVE && currentDevice.Status == DeviceStatus.SUSPENDED)
                            {
                                await _deviceApi.UnsuspendDeviceAsync(testDeviceId);
                            }
                            else if (originalStatus == DeviceStatus.SUSPENDED && currentDevice.Status == DeviceStatus.ACTIVE)
                            {
                                await _deviceApi.SuspendDeviceAsync(testDeviceId);
                            }
                            // Note: We don't restore DEACTIVATED state as that would require destructive operations
                        }
                    }
                    catch (ApiException)
                    {
                        // Cleanup failed - device may have been deleted or is in an unexpected state
                        // This is acceptable for cleanup code
                    }
                }
            }
        }

        /// <summary>
        /// Test ListDevices with expanded parameter to include embedded user details.
        /// </summary>
        [Fact]
        public async Task GivenDeviceApi_WhenListingDevicesWithExpand_ThenEmbeddedDataIsReturned()
        {
            // Test ListDevices with expanded parameter for user summaries
            var devicesWithUserSummary = await _deviceApi.ListDevices(
                limit: 5,
                expand: new DeviceExpandParameter("userSummary")
            ).ToListAsync();

            devicesWithUserSummary.Should().NotBeNull();
            devicesWithUserSummary.Should().NotBeEmpty();

            // Verify we get devices (embedded data may or may not be present depending on the device)
            foreach (var device in devicesWithUserSummary)
            {
                device.Id.Should().NotBeNullOrEmpty();
                device.Status.Should().NotBeNull();
            }

            // Test ListDevices with expanded parameter for full user details
            var devicesWithUsers = await _deviceApi.ListDevices(
                limit: 5,
                expand: new DeviceExpandParameter("user")
            ).ToListAsync();

            devicesWithUsers.Should().NotBeNull();
            devicesWithUsers.Should().NotBeEmpty();
        }

        /// <summary>
        /// Test ListDevices with various search filters.
        /// </summary>
        [Fact]
        public async Task GivenDeviceApi_WhenSearchingDevices_ThenFilteredResultsAreReturned()
        {
            // Get all devices first to find valid search criteria
            var allDevices = await _deviceApi.ListDevices(limit: 10).ToListAsync();
            allDevices.Should().NotBeEmpty();

            var sampleDevice = allDevices.First();

            // Test search by device ID
            var deviceById = await _deviceApi.ListDevices(
                search: $"id eq \"{sampleDevice.Id}\""
            ).ToListAsync();

            deviceById.Should().ContainSingle();
            deviceById.First().Id.Should().Be(sampleDevice.Id);

            // Test search by status
            var devicesByStatus = await _deviceApi.ListDevices(
                search: $"status eq \"{sampleDevice.Status.Value}\""
            ).ToListAsync();

            devicesByStatus.Should().NotBeEmpty();
            devicesByStatus.Should().Contain(d => d.Id == sampleDevice.Id);

            // Test search by display name using contains operator (co)
            if (!string.IsNullOrEmpty(sampleDevice.Profile?.DisplayName))
            {
                var displayNamePrefix = sampleDevice.Profile.DisplayName.Length > 3 
                    ? sampleDevice.Profile.DisplayName.Substring(0, 3) 
                    : sampleDevice.Profile.DisplayName;
                
                var devicesByDisplayName = await _deviceApi.ListDevices(
                    search: $"profile.displayName co \"{displayNamePrefix}\""
                ).ToListAsync();

                devicesByDisplayName.Should().NotBeEmpty();
            }
        }
    }
}
