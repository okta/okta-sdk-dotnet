// <copyright file="DevicePostureCheckApiTests.cs" company="Okta, Inc">
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
    /// Custom exception for skipping DevicePostureCheck tests when the feature is not available.
    /// </summary>
    public class DevicePostureCheckTestSkipException(string message) : Exception(message);

    /// <summary>
    /// Integration tests for DevicePostureCheckApi covering all 6 available endpoints.
    /// 
    /// API Coverage:
    /// 1. POST /api/v1/device-posture-checks - CreateDevicePostureCheckAsync
    /// 2. GET /api/v1/device-posture-checks - ListDevicePostureChecks
    /// 3. GET /api/v1/device-posture-checks/default - ListDefaultDevicePostureChecks
    /// 4. GET /api/v1/device-posture-checks/{postureCheckId} - GetDevicePostureCheckAsync
    /// 5. PUT /api/v1/device-posture-checks/{postureCheckId} - ReplaceDevicePostureCheckAsync
    /// 6. DELETE /api/v1/device-posture-checks/{postureCheckId} - DeleteDevicePostureCheckAsync
    /// 
    /// Note: This API requires the Advanced Posture Checks feature to be enabled.
    /// The API manages custom device posture checks using OSQuery for device assurance policies.
    /// 
    /// Test Strategy: Tests create custom posture checks for MACOS platform, perform CRUD operations,
    /// and clean up after testing. BUILTIN posture checks (Okta-defined) are also tested for listing.
    /// </summary>
    public class DevicePostureCheckApiTests
    {
        private readonly DevicePostureCheckApi _devicePostureCheckApi = new();

        /// <summary>
        /// Tests listing all default (BUILTIN) device posture checks.
        /// These are predefined by Okta and cannot be modified.
        /// 
        /// API: GET /api/v1/device-posture-checks/default
        /// </summary>
        [Fact]
        public async Task GivenDevicePostureCheckApi_WhenListingDefaultChecks_ThenReturnsBuiltinChecks()
        {
            try
            {
                // Act
                var defaultChecks = await _devicePostureCheckApi
                    .ListDefaultDevicePostureChecks()
                    .ToListAsync();

                // Assert
                defaultChecks.Should().NotBeNull();
                defaultChecks.Should().NotBeEmpty("Expected at least one default device posture check to be available");

                // All default checks should be BUILTIN type
                foreach (var check in defaultChecks)
                {
                    check.Type.Should().Be(DevicePostureChecksType.BUILTIN);
                    check.Name.Should().NotBeNullOrEmpty();
                    check.VariableName.Should().NotBeNullOrEmpty();
                    check.Platform.Should().NotBeNull();
                }

                // Validate we have checks for different platforms
                var platforms = defaultChecks.Select(c => c.Platform).Distinct().ToList();
                platforms.Should().NotBeEmpty();

                // Validate valid platforms (DevicePostureChecksPlatform only supports MACOS and WINDOWS)
                // Note: The API returns ANDROID, CHROMEOS, IOS, MACOS, WINDOWS but the SDK enum only has MACOS and WINDOWS
                foreach (var check in defaultChecks)
                {
                    // Platform should be set
                    check.Platform.Should().NotBeNull();
                }
            }
            catch (ApiException ex) when (ex.ErrorCode == 403 || ex.Message.Contains("E0000015"))
            {
                throw new DevicePostureCheckTestSkipException(
                    $"Device Posture Check API is not available. Enable 'Advanced Posture Checks' feature. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Tests listing all device posture checks (both BUILTIN and CUSTOM).
        /// 
        /// API: GET /api/v1/device-posture-checks
        /// </summary>
        [Fact]
        public async Task GivenDevicePostureCheckApi_WhenListingAllChecks_ThenReturnsChecksList()
        {
            try
            {
                // Act
                var allChecks = await _devicePostureCheckApi
                    .ListDevicePostureChecks()
                    .ToListAsync();

                // Assert - List can be empty if no custom checks exist
                allChecks.Should().NotBeNull();

                // If there are checks, validate their properties
                foreach (var check in allChecks)
                {
                    check.Name.Should().NotBeNullOrEmpty();
                    check.VariableName.Should().NotBeNullOrEmpty();
                    check.Platform.Should().NotBeNull();
                    check.Type.Should().NotBeNull();
                    check.MappingType.Should().NotBeNull();
                }
            }
            catch (ApiException ex) when (ex.ErrorCode == 403 || ex.Message.Contains("E0000015"))
            {
                throw new DevicePostureCheckTestSkipException(
                    $"Device Posture Check API is not available. Enable 'Advanced Posture Checks' feature. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Comprehensive test covering full CRUD lifecycle for custom device posture checks.
        /// This test covers:
        /// - Create a custom device posture check
        /// - Retrieve the created check by ID
        /// - Update (replace) the check
        /// - Delete the check
        /// 
        /// APIs:
        /// - POST /api/v1/device-posture-checks (Create)
        /// - GET /api/v1/device-posture-checks/{postureCheckId} (Get)
        /// - PUT /api/v1/device-posture-checks/{postureCheckId} (Replace)
        /// - DELETE /api/v1/device-posture-checks/{postureCheckId} (Delete)
        /// 
        /// Cleanup: The created posture check is deleted in the finally block.
        /// </summary>
        [Fact]
        public async Task GivenDevicePostureCheckApi_WhenPerformingCrudOperations_ThenAllOperationsSucceed()
        {
            string? createdPostureCheckId = null;
            var testId = Guid.NewGuid().ToString("N").Substring(0, 8);

            try
            {
                // ========================================================================
                // SECTION 1: CREATE Device Posture Check
                // ========================================================================

                #region CreateDevicePostureCheck - POST

                var newPostureCheck = new DevicePostureCheck
                {
                    Name = $"SDK Integration Test Check {testId}",
                    Description = "Integration test posture check - created by SDK tests",
                    Platform = DevicePostureChecksPlatform.MACOS,
                    MappingType = DevicePostureChecksMappingType.CHECKBOX,
                    Type = DevicePostureChecksType.CUSTOM,
                    Query = "SELECT * FROM system_info;",
                    VariableName = $"TestSDKCheck{testId}",
                    RemediationSettings = new DevicePostureChecksRemediationSettings
                    {
                        Message = new DevicePostureChecksRemediationSettingsMessage
                        {
                            CustomText = "Please ensure your system meets the requirements"
                        },
                        Link = new DevicePostureChecksRemediationSettingsLink
                        {
                            CustomUrl = "https://example.com/help"
                        }
                    }
                };

                var createdCheck = await _devicePostureCheckApi.CreateDevicePostureCheckAsync(newPostureCheck);

                // Assert creation
                createdCheck.Should().NotBeNull();
                createdCheck.Id.Should().NotBeNullOrEmpty();
                createdPostureCheckId = createdCheck.Id;
                createdCheck.Name.Should().Be(newPostureCheck.Name);
                createdCheck.Description.Should().Be(newPostureCheck.Description);
                createdCheck.Platform.Should().Be(DevicePostureChecksPlatform.MACOS);
                createdCheck.Type.Should().Be(DevicePostureChecksType.CUSTOM);
                createdCheck.MappingType.Should().Be(DevicePostureChecksMappingType.CHECKBOX);
                createdCheck.Query.Should().Be(newPostureCheck.Query);
                createdCheck.VariableName.Should().Be(newPostureCheck.VariableName);
                createdCheck.CreatedDate.Should().NotBeNullOrEmpty();
                createdCheck.CreatedBy.Should().NotBeNullOrEmpty();
                createdCheck.Links.Should().NotBeNull();

                #endregion

                // ========================================================================
                // SECTION 2: GET Device Posture Check by ID
                // ========================================================================

                #region GetDevicePostureCheck - GET

                await Task.Delay(1000); // Brief delay for eventual consistency

                var retrievedCheck = await _devicePostureCheckApi.GetDevicePostureCheckAsync(createdPostureCheckId);

                // Assert retrieval
                retrievedCheck.Should().NotBeNull();
                retrievedCheck.Id.Should().Be(createdPostureCheckId);
                retrievedCheck.Name.Should().Be(createdCheck.Name);
                retrievedCheck.Description.Should().Be(createdCheck.Description);
                retrievedCheck.Platform.Should().Be(createdCheck.Platform);
                retrievedCheck.Type.Should().Be(DevicePostureChecksType.CUSTOM);

                #endregion

                // ========================================================================
                // SECTION 3: REPLACE (Update) Device Posture Check
                // ========================================================================

                #region ReplaceDevicePostureCheck - PUT

                var updatedPostureCheck = new DevicePostureCheck
                {
                    Name = $"SDK Integration Test Check {testId} - Updated",
                    Description = "Integration test posture check - updated by SDK tests",
                    Platform = DevicePostureChecksPlatform.MACOS,
                    MappingType = DevicePostureChecksMappingType.CHECKBOX,
                    Type = DevicePostureChecksType.CUSTOM,
                    Query = "SELECT hostname FROM system_info;",
                    VariableName = $"TestSDKCheck{testId}",
                    RemediationSettings = new DevicePostureChecksRemediationSettings
                    {
                        Message = new DevicePostureChecksRemediationSettingsMessage
                        {
                            CustomText = "Updated remediation message"
                        },
                        Link = new DevicePostureChecksRemediationSettingsLink
                        {
                            CustomUrl = "https://example.com/updated-help"
                        }
                    }
                };

                var replacedCheck = await _devicePostureCheckApi.ReplaceDevicePostureCheckAsync(
                    createdPostureCheckId,
                    updatedPostureCheck);

                // Assert replacement
                replacedCheck.Should().NotBeNull();
                replacedCheck.Id.Should().Be(createdPostureCheckId);
                replacedCheck.Name.Should().Be(updatedPostureCheck.Name);
                replacedCheck.Description.Should().Be(updatedPostureCheck.Description);
                replacedCheck.Query.Should().Be(updatedPostureCheck.Query);
                replacedCheck.RemediationSettings.Should().NotBeNull();
                replacedCheck.RemediationSettings.Message.CustomText.Should().Be("Updated remediation message");
                replacedCheck.RemediationSettings.Link.CustomUrl.Should().Be("https://example.com/updated-help");

                // Verify by getting again
                var verifyUpdated = await _devicePostureCheckApi.GetDevicePostureCheckAsync(createdPostureCheckId);
                verifyUpdated.Name.Should().Be(updatedPostureCheck.Name);

                #endregion

                // ========================================================================
                // SECTION 4: DELETE Device Posture Check
                // ========================================================================

                #region DeleteDevicePostureCheck - DELETE

                await Task.Delay(1000); // Brief delay for eventual consistency

                // Delete should not throw
                await _devicePostureCheckApi.DeleteDevicePostureCheckAsync(createdPostureCheckId);

                // Mark as deleted, so cleanup doesn't try to delete it again
                createdPostureCheckId = null;

                // Verify deletion by trying to get - should throw 404
                await Task.Delay(1000);
                Func<Task> getDeletedAction = async () => 
                    await _devicePostureCheckApi.GetDevicePostureCheckAsync(replacedCheck.Id);
                
                await getDeletedAction.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404 || e.Message.Contains("E0000007"));

                #endregion
            }
            catch (ApiException ex) when (ex.ErrorCode == 403 || ex.Message.Contains("E0000015"))
            {
                throw new DevicePostureCheckTestSkipException(
                    $"Device Posture Check API is not available. Enable 'Advanced Posture Checks' feature. Error: {ex.Message}");
            }
            finally
            {
                // Cleanup - Delete the posture check if it was created but test failed before deletion
                if (!string.IsNullOrEmpty(createdPostureCheckId))
                {
                    try
                    {
                        await Task.Delay(1000);
                        await _devicePostureCheckApi.DeleteDevicePostureCheckAsync(createdPostureCheckId);
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
