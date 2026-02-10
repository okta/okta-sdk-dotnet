// <copyright file="DeviceAssuranceApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for DeviceAssuranceApi covering all 5 available endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/device-assurances - ListDeviceAssurancePolicies
    /// 2. POST /api/v1/device-assurances - CreateDeviceAssurancePolicyAsync
    /// 3. GET /api/v1/device-assurances/{deviceAssuranceId} - GetDeviceAssurancePolicyAsync
    /// 4. PUT /api/v1/device-assurances/{deviceAssuranceId} - ReplaceDeviceAssurancePolicyAsync
    /// 5. DELETE /api/v1/device-assurances/{deviceAssuranceId} - DeleteDeviceAssurancePolicyAsync
    /// 
    /// Note: Unlike Device API, Device Assurance policies can be fully managed (CRUD) via the API.
    /// All tests create policies for testing and clean up by deleting them at the end.
    /// ScreenLockType Valid Combinations (per API validation):
    /// - [BIOMETRIC] - Valid
    /// - [PASSCODE, BIOMETRIC] - Valid
    /// - [PASSCODE] alone - Invalid
    /// - [NONE] - Invalid
    /// </summary>
    public class DeviceAssuranceApiTests
    {
        private readonly DeviceAssuranceApi _deviceAssuranceApi = new();

        /// <summary>
        /// Comprehensive test covering all DeviceAssuranceApi operations and endpoints.
        /// This single test covers:
        /// - Creating a device assurance policy (macOS platform)
        /// - Retrieving the created policy
        /// - Listing all policies and verifying the new one exists
        /// - Replacing/updating the policy
        /// - Deleting the policy
        /// - Negative testing for non-existent policy operations
        /// 
        /// Cleanup: Policy is deleted at the end of the test
        /// </summary>
        [Fact]
        public async Task GivenDeviceAssuranceApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string createdPolicyId = null;

            try
            {
                // ========================================================================
                // SECTION 1: Create a Device Assurance Policy
                // ========================================================================

                #region CreateDeviceAssurancePolicy - POST /api/v1/device-assurances

                // Create a macOS device assurance policy with specific requirements
                // Note: SecureHardwarePresent must be explicitly set to true as the SDK
                // serializes bool fields with their default values
                var macOsPolicy = new DeviceAssuranceMacOSPlatform()
                {
                    Name = $"Test macOS Policy {Guid.NewGuid():N}".Substring(0, 50),
                    Platform = Platform.MACOS,
                    SecureHardwarePresent = true, // Required - API doesn't accept false
                    OsVersion = new OSVersion
                    {
                        Minimum = "12.0"
                    },
                    ScreenLockType = new DeviceAssuranceAndroidPlatformAllOfScreenLockType
                    {
                        Include = [ScreenLockType.BIOMETRIC]
                    }
                };

                var createdPolicy = await _deviceAssuranceApi.CreateDeviceAssurancePolicyAsync(macOsPolicy);

                createdPolicy.Should().NotBeNull();
                createdPolicy.Id.Should().NotBeNullOrEmpty();
                createdPolicy.Name.Should().Be(macOsPolicy.Name);
                createdPolicy.Platform.Should().Be(Platform.MACOS);
                createdPolicy.CreatedDate.Should().NotBeNullOrEmpty();
                createdPolicy.LastUpdate.Should().NotBeNullOrEmpty();

                createdPolicyId = createdPolicy.Id;

                // Verify the returned policy is of the correct type
                createdPolicy.Should().BeOfType<DeviceAssuranceMacOSPlatform>();

                // Verify the macOS-specific properties
                var createdMacOsPolicy = createdPolicy as DeviceAssuranceMacOSPlatform;
                createdMacOsPolicy.Should().NotBeNull();
                if (createdMacOsPolicy != null)
                {
                    createdMacOsPolicy.OsVersion.Should().NotBeNull();
                    createdMacOsPolicy.OsVersion.Minimum.Should().Be("12.0");
                    createdMacOsPolicy.SecureHardwarePresent.Should().BeTrue();
                }

                #endregion

                // ========================================================================
                // SECTION 2: Retrieve the Device Assurance Policy
                // ========================================================================

                #region GetDeviceAssurancePolicy - GET /api/v1/device-assurances/{deviceAssuranceId}

                var retrievedPolicy = await _deviceAssuranceApi.GetDeviceAssurancePolicyAsync(createdPolicyId);

                retrievedPolicy.Should().NotBeNull();
                retrievedPolicy.Id.Should().Be(createdPolicyId);
                retrievedPolicy.Name.Should().Be(macOsPolicy.Name);
                retrievedPolicy.Platform.Should().Be(Platform.MACOS);

                // Verify it's the correct type
                retrievedPolicy.Should().BeOfType<DeviceAssuranceMacOSPlatform>();

                #endregion

                // ========================================================================
                // SECTION 3: List All Device Assurance Policies
                // ========================================================================

                #region ListDeviceAssurancePolicies - GET /api/v1/device-assurances

                var allPolicies = await _deviceAssuranceApi.ListDeviceAssurancePolicies().ToListAsync();

                allPolicies.Should().NotBeNull();
                allPolicies.Should().NotBeEmpty("We just created a policy, so there should be at least one");

                // Verify our created policy is in the list
                var foundPolicy = allPolicies.FirstOrDefault(p => p.Id == createdPolicyId);
                foundPolicy.Should().NotBeNull("The created policy should be in the list");
                foundPolicy?.Name.Should().Be(macOsPolicy.Name);
                foundPolicy?.Platform.Should().Be(Platform.MACOS);

                // Verify all policies have required properties
                foreach (var policy in allPolicies)
                {
                    policy.Id.Should().NotBeNullOrEmpty();
                    policy.Name.Should().NotBeNullOrEmpty();
                    policy.Platform.Should().NotBeNull();
                    policy.CreatedDate.Should().NotBeNullOrEmpty();
                }

                #endregion

                // ========================================================================
                // SECTION 4: Replace/Update the Device Assurance Policy
                // ========================================================================

                #region ReplaceDeviceAssurancePolicy - PUT /api/v1/device-assurances/{deviceAssuranceId}

                // Update the policy with new name and OS version
                var updatedMacOsPolicy = new DeviceAssuranceMacOSPlatform()
                {
                    Name = $"Updated macOS Policy {Guid.NewGuid():N}".Substring(0, 50),
                    Platform = Platform.MACOS,
                    SecureHardwarePresent = true, // Required
                    OsVersion = new OSVersion
                    {
                        Minimum = "13.0" // Updated from 12.0 to 13.0
                    },
                    ScreenLockType = new DeviceAssuranceAndroidPlatformAllOfScreenLockType
                    {
                        // Valid values: [PASSCODE, BIOMETRIC] or [BIOMETRIC] only
                        Include =
                        [
                            ScreenLockType.PASSCODE,
                            ScreenLockType.BIOMETRIC
                        ]
                    }
                };

                var replacedPolicy = await _deviceAssuranceApi.ReplaceDeviceAssurancePolicyAsync(createdPolicyId, updatedMacOsPolicy);

                replacedPolicy.Should().NotBeNull();
                replacedPolicy.Id.Should().Be(createdPolicyId); // ID should remain the same
                replacedPolicy.Name.Should().Be(updatedMacOsPolicy.Name);
                replacedPolicy.Platform.Should().Be(Platform.MACOS);

                // Verify the updates were applied
                {
                    replacedPolicy.Should().BeOfType<DeviceAssuranceMacOSPlatform>();
                    var replacedMacOsPolicy = replacedPolicy as DeviceAssuranceMacOSPlatform;
                    replacedMacOsPolicy.Should().NotBeNull();
                    replacedMacOsPolicy?.OsVersion.Minimum.Should().Be("13.0");
                }

                // Verify by retrieving again
                var verifyUpdatedPolicy = await _deviceAssuranceApi.GetDeviceAssurancePolicyAsync(createdPolicyId);
                verifyUpdatedPolicy.Name.Should().Be(updatedMacOsPolicy.Name);

                #endregion

                // ========================================================================
                // SECTION 5: Delete the Device Assurance Policy
                // ========================================================================

                #region DeleteDeviceAssurancePolicy - DELETE /api/v1/device-assurances/{deviceAssuranceId}

                // Delete the policy
                await _deviceAssuranceApi.DeleteDeviceAssurancePolicyAsync(createdPolicyId);

                // Verify deletion by trying to retrieve - should throw 404
                var id = createdPolicyId;
                Func<Task> getDeletedPolicy = async () => await _deviceAssuranceApi.GetDeviceAssurancePolicyAsync(id);
                await getDeletedPolicy.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                // Mark as cleaned up
                createdPolicyId = null;

                #endregion

                // ========================================================================
                // SECTION 6: Negative Testing - Operations on Non-Existent Policies
                // ========================================================================

                #region Negative Testing

                var nonExistentPolicyId = "nonexistent12345";

                // GET non-existent policy - should return 404
                Func<Task> getNonExistent = async () => await _deviceAssuranceApi.GetDeviceAssurancePolicyAsync(nonExistentPolicyId);
                await getNonExistent.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                // PUT non-existent policy - should return 404
                Func<Task> replaceNonExistent = async () => await _deviceAssuranceApi.ReplaceDeviceAssurancePolicyAsync(
                    nonExistentPolicyId, 
                    new DeviceAssuranceMacOSPlatform 
                    { 
                        Name = "Test",
                        Platform = Platform.MACOS,
                        SecureHardwarePresent = true,
                        OsVersion = new OSVersion { Minimum = "12.0" }
                    });
                await replaceNonExistent.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                // DELETE non-existent policy - should return 404
                Func<Task> deleteNonExistent = async () => await _deviceAssuranceApi.DeleteDeviceAssurancePolicyAsync(nonExistentPolicyId);
                await deleteNonExistent.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                #endregion
            }
            finally
            {
                // ========================================================================
                // CLEANUP: Ensure the test policy is deleted
                // ========================================================================
                if (!string.IsNullOrEmpty(createdPolicyId))
                {
                    try
                    {
                        await _deviceAssuranceApi.DeleteDeviceAssurancePolicyAsync(createdPolicyId);
                    }
                    catch
                    {
                        // Ignore cleanup errors - policy might already be deleted
                    }
                }
            }
        }

        /// <summary>
        /// Tests validation errors when creating invalid device assurance policies.
        /// </summary>
        [Fact]
        public async Task GivenDeviceAssuranceApi_WhenCreatingInvalidPolicy_ThenValidationErrorIsReturned()
        {
            // Create a policy without required name - should fail
            var invalidPolicy = new DeviceAssuranceMacOSPlatform()
            {
                // Name is missing
                Platform = Platform.MACOS,
                SecureHardwarePresent = true,
                OsVersion = new OSVersion
                {
                    Minimum = "12.0"
                }
            };

            Func<Task> createInvalidPolicy = async () => await _deviceAssuranceApi.CreateDeviceAssurancePolicyAsync(invalidPolicy);
            
            // Should throw an API exception (400 Bad Request for validation error)
            await createInvalidPolicy.Should().ThrowAsync<ApiException>();
        }

        /// <summary>
        /// Tests that SecureHardwarePresent (nullable bool?) is not serialized when not set.
        /// This verifies the OpenAPI spec fix that changed the property from bool to bool?.
        /// Previously, the SDK would serialize false (default value) which the API rejects.
        /// After the fix, when SecureHardwarePresent is not explicitly set (null), it won't be serialized.
        /// </summary>
        [Fact]
        public async Task GivenDeviceAssuranceApi_WhenCreatingPolicyWithoutSecureHardwarePresent_ThenPolicyIsCreatedSuccessfully()
        {
            string createdPolicyId = null;

            try
            {
                // Create a policy WITHOUT setting SecureHardwarePresent
                // Before the fix: SDK serialized "secureHardwarePresent": false which API rejects
                // After the fix: SecureHardwarePresent is null (bool?) and won't be serialized
                var macOsPolicy = new DeviceAssuranceMacOSPlatform()
                {
                    Name = $"Test Policy No SHP {Guid.NewGuid():N}".Substring(0, 50),
                    Platform = Platform.MACOS,
                    // NOT setting SecureHardwarePresent - it will be null
                    OsVersion = new OSVersion
                    {
                        Minimum = "12.0"
                    }
                };

                // This should succeed now that SecureHardwarePresent is nullable
                var createdPolicy = await _deviceAssuranceApi.CreateDeviceAssurancePolicyAsync(macOsPolicy);

                createdPolicy.Should().NotBeNull();
                createdPolicy.Id.Should().NotBeNullOrEmpty();
                createdPolicy.Name.Should().Be(macOsPolicy.Name);
                createdPolicy.Platform.Should().Be(Platform.MACOS);
                
                createdPolicyId = createdPolicy.Id;

                // The response should not have SecureHardwarePresent set
                var createdMacOsPolicy = createdPolicy as DeviceAssuranceMacOSPlatform;
                createdMacOsPolicy.Should().NotBeNull();
                createdMacOsPolicy?.SecureHardwarePresent.Should().BeNull();
            }
            finally
            {
                // Cleanup
                if (!string.IsNullOrEmpty(createdPolicyId))
                {
                    try
                    {
                        await _deviceAssuranceApi.DeleteDeviceAssurancePolicyAsync(createdPolicyId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }
    }
}
