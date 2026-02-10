// <copyright file="DeviceAccessApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Model;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for DeviceAccessApi covering all 4 available endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /device-access/api/v1/desktop-mfa/enforce-number-matching-challenge-settings - GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync
    /// 2. PUT /device-access/api/v1/desktop-mfa/enforce-number-matching-challenge-settings - ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync
    /// 3. GET /device-access/api/v1/desktop-mfa/recovery-pin-settings - GetDesktopMFARecoveryPinOrgSettingAsync
    /// 4. PUT /device-access/api/v1/desktop-mfa/recovery-pin-settings - ReplaceDesktopMFARecoveryPinOrgSettingAsync
    /// 
    /// Note: These APIs manage org-level Desktop MFA settings. They are LIMITED_GA features
    /// requiring Okta Identity Engine. All tests restore original settings after modification.
    /// </summary>
    public class DeviceAccessApiTests
    {
        private readonly DeviceAccessApi _deviceAccessApi = new();

        /// <summary>
        /// Comprehensive test covering all DeviceAccessApi operations for Desktop MFA settings.
        /// This single test covers:
        /// - Retrieving Desktop MFA Enforce Number Matching Challenge setting
        /// - Modifying and restoring the setting
        /// - Retrieving Desktop MFA Recovery PIN setting  
        /// - Modifying and restoring the setting
        /// 
        /// Cleanup: All settings are restored to their original values
        /// </summary>
        [Fact]
        public async Task GivenDeviceAccessApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            bool? originalEnforceNumberMatchingSetting = null;
            bool? originalRecoveryPinSetting = null;

            try
            {
                // ========================================================================
                // SECTION 1: Desktop MFA Enforce Number Matching Challenge Settings
                // ========================================================================

                #region GetDesktopMFAEnforceNumberMatchingChallengeOrgSetting - GET

                // Test GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync()
                var enforceNumberMatchingSetting = await _deviceAccessApi.GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync();

                enforceNumberMatchingSetting.Should().NotBeNull();
                // Store original value for cleanup
                originalEnforceNumberMatchingSetting = enforceNumberMatchingSetting.DesktopMFAEnforceNumberMatchingChallengeEnabled;

                #endregion

                #region ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSetting - PUT

                // Toggle the setting to the opposite value
                var newEnforceNumberMatchingValue = !originalEnforceNumberMatchingSetting.Value;
                var updateEnforceNumberMatchingSetting = new DesktopMFAEnforceNumberMatchingChallengeOrgSetting
                {
                    DesktopMFAEnforceNumberMatchingChallengeEnabled = newEnforceNumberMatchingValue
                };

                var updatedEnforceNumberMatchingSetting = await _deviceAccessApi.ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync(updateEnforceNumberMatchingSetting);

                updatedEnforceNumberMatchingSetting.Should().NotBeNull();
                updatedEnforceNumberMatchingSetting.DesktopMFAEnforceNumberMatchingChallengeEnabled.Should().Be(newEnforceNumberMatchingValue);

                // Verify by retrieving again
                var verifyEnforceNumberMatchingSetting = await _deviceAccessApi.GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync();
                verifyEnforceNumberMatchingSetting.DesktopMFAEnforceNumberMatchingChallengeEnabled.Should().Be(newEnforceNumberMatchingValue);

                // Restore original value
                var restoreEnforceNumberMatchingSetting = new DesktopMFAEnforceNumberMatchingChallengeOrgSetting
                {
                    DesktopMFAEnforceNumberMatchingChallengeEnabled = originalEnforceNumberMatchingSetting.Value
                };
                await _deviceAccessApi.ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync(restoreEnforceNumberMatchingSetting);

                // Verify restoration
                var restoredEnforceNumberMatchingSetting = await _deviceAccessApi.GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync();
                restoredEnforceNumberMatchingSetting.DesktopMFAEnforceNumberMatchingChallengeEnabled.Should().Be(originalEnforceNumberMatchingSetting.Value);

                // Mark as restored
                originalEnforceNumberMatchingSetting = null;

                #endregion

                // ========================================================================
                // SECTION 2: Desktop MFA Recovery PIN Settings
                // ========================================================================

                #region GetDesktopMFARecoveryPinOrgSetting - GET

                // Test GetDesktopMFARecoveryPinOrgSettingAsync()
                var recoveryPinSetting = await _deviceAccessApi.GetDesktopMFARecoveryPinOrgSettingAsync();

                recoveryPinSetting.Should().NotBeNull();
                // Store original value for cleanup
                originalRecoveryPinSetting = recoveryPinSetting.DesktopMFARecoveryPinEnabled;

                #endregion

                #region ReplaceDesktopMFARecoveryPinOrgSetting - PUT

                // Toggle the setting to the opposite value
                var newRecoveryPinValue = !originalRecoveryPinSetting.Value;
                var updateRecoveryPinSetting = new DesktopMFARecoveryPinOrgSetting
                {
                    DesktopMFARecoveryPinEnabled = newRecoveryPinValue
                };

                var updatedRecoveryPinSetting = await _deviceAccessApi.ReplaceDesktopMFARecoveryPinOrgSettingAsync(updateRecoveryPinSetting);

                updatedRecoveryPinSetting.Should().NotBeNull();
                updatedRecoveryPinSetting.DesktopMFARecoveryPinEnabled.Should().Be(newRecoveryPinValue);

                // Verify by retrieving again
                var verifyRecoveryPinSetting = await _deviceAccessApi.GetDesktopMFARecoveryPinOrgSettingAsync();
                verifyRecoveryPinSetting.DesktopMFARecoveryPinEnabled.Should().Be(newRecoveryPinValue);

                // Restore original value
                var restoreRecoveryPinSetting = new DesktopMFARecoveryPinOrgSetting
                {
                    DesktopMFARecoveryPinEnabled = originalRecoveryPinSetting.Value
                };
                await _deviceAccessApi.ReplaceDesktopMFARecoveryPinOrgSettingAsync(restoreRecoveryPinSetting);

                // Verify restoration
                var restoredRecoveryPinSetting = await _deviceAccessApi.GetDesktopMFARecoveryPinOrgSettingAsync();
                restoredRecoveryPinSetting.DesktopMFARecoveryPinEnabled.Should().Be(originalRecoveryPinSetting.Value);

                // Mark as restored
                originalRecoveryPinSetting = null;

                #endregion
            }
            finally
            {
                // ========================================================================
                // CLEANUP: Restore original settings if they were modified and not restored
                // ========================================================================
                if (originalEnforceNumberMatchingSetting.HasValue)
                {
                    try
                    {
                        var restoreSetting = new DesktopMFAEnforceNumberMatchingChallengeOrgSetting
                        {
                            DesktopMFAEnforceNumberMatchingChallengeEnabled = originalEnforceNumberMatchingSetting.Value
                        };
                        await _deviceAccessApi.ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync(restoreSetting);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }

                if (originalRecoveryPinSetting.HasValue)
                {
                    try
                    {
                        var restoreSetting = new DesktopMFARecoveryPinOrgSetting
                        {
                            DesktopMFARecoveryPinEnabled = originalRecoveryPinSetting.Value
                        };
                        await _deviceAccessApi.ReplaceDesktopMFARecoveryPinOrgSettingAsync(restoreSetting);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        /// <summary>
        /// Test that settings can be set to explicit true value.
        /// </summary>
        [Fact]
        public async Task GivenDeviceAccessApi_WhenSettingEnforceNumberMatchingToTrue_ThenSettingIsUpdated()
        {
            bool? originalValue = null;

            try
            {
                // Get current value
                var currentSetting = await _deviceAccessApi.GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync();
                originalValue = currentSetting.DesktopMFAEnforceNumberMatchingChallengeEnabled;

                // Set to true
                var updateSetting = new DesktopMFAEnforceNumberMatchingChallengeOrgSetting
                {
                    DesktopMFAEnforceNumberMatchingChallengeEnabled = true
                };

                var result = await _deviceAccessApi.ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync(updateSetting);

                result.Should().NotBeNull();
                result.DesktopMFAEnforceNumberMatchingChallengeEnabled.Should().BeTrue();
            }
            finally
            {
                // Restore original value
                if (originalValue.HasValue)
                {
                    try
                    {
                        var restoreSetting = new DesktopMFAEnforceNumberMatchingChallengeOrgSetting
                        {
                            DesktopMFAEnforceNumberMatchingChallengeEnabled = originalValue.Value
                        };
                        await _deviceAccessApi.ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync(restoreSetting);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        /// <summary>
        /// Test that settings can be set to explicit false value.
        /// </summary>
        [Fact]
        public async Task GivenDeviceAccessApi_WhenSettingRecoveryPinToFalse_ThenSettingIsUpdated()
        {
            bool? originalValue = null;

            try
            {
                // Get current value
                var currentSetting = await _deviceAccessApi.GetDesktopMFARecoveryPinOrgSettingAsync();
                originalValue = currentSetting.DesktopMFARecoveryPinEnabled;

                // Set to false
                var updateSetting = new DesktopMFARecoveryPinOrgSetting
                {
                    DesktopMFARecoveryPinEnabled = false
                };

                var result = await _deviceAccessApi.ReplaceDesktopMFARecoveryPinOrgSettingAsync(updateSetting);

                result.Should().NotBeNull();
                result.DesktopMFARecoveryPinEnabled.Should().BeFalse();
            }
            finally
            {
                // Restore original value
                if (originalValue.HasValue)
                {
                    try
                    {
                        var restoreSetting = new DesktopMFARecoveryPinOrgSetting
                        {
                            DesktopMFARecoveryPinEnabled = originalValue.Value
                        };
                        await _deviceAccessApi.ReplaceDesktopMFARecoveryPinOrgSettingAsync(restoreSetting);
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
