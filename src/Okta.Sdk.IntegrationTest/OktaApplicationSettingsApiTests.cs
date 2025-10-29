// <copyright file="OktaApplicationSettingsApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    public class OktaApplicationSettingsApiTests : IDisposable
    {
        private readonly OktaApplicationSettingsApi _oktaAppSettingsApi = new();
        private AdminConsoleSettings _originalSettings;

        public void Dispose()
        {
            RestoreOriginalSettings().GetAwaiter().GetResult();
        }

        private async Task RestoreOriginalSettings()
        {
            if (_originalSettings != null)
            {
                try
                {
                    await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync("admin-console", _originalSettings);
                }
                catch (ApiException)
                {
                    // Best effort cleanup
                }
            }
        }

        [Fact]
        public async Task GivenOktaApplicationSettings_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            const string appName = "admin-console";

            // Test GetFirstPartyAppSettingsAsync - validates GET endpoint and response structure
            var currentSettings = await _oktaAppSettingsApi.GetFirstPartyAppSettingsAsync(appName);

            currentSettings.Should().NotBeNull();
            currentSettings.SessionIdleTimeoutMinutes.Should().BeInRange(5, 120);
            currentSettings.SessionMaxLifetimeMinutes.Should().BeInRange(5, 1440);

            _originalSettings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = currentSettings.SessionIdleTimeoutMinutes,
                SessionMaxLifetimeMinutes = currentSettings.SessionMaxLifetimeMinutes
            };

            // Test GetFirstPartyAppSettingsWithHttpInfoAsync - validates GET endpoint with full HTTP response
            var settingsWithHttpInfo = await _oktaAppSettingsApi.GetFirstPartyAppSettingsWithHttpInfoAsync(appName);

            settingsWithHttpInfo.Should().NotBeNull();
            settingsWithHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK);
            settingsWithHttpInfo.Headers.Should().NotBeNull();
            settingsWithHttpInfo.Headers.Should().ContainKey("Content-Type");
            settingsWithHttpInfo.Data.Should().NotBeNull();
            settingsWithHttpInfo.Data.SessionIdleTimeoutMinutes.Should().Be(currentSettings.SessionIdleTimeoutMinutes);
            settingsWithHttpInfo.Data.SessionMaxLifetimeMinutes.Should().Be(currentSettings.SessionMaxLifetimeMinutes);

            var newIdleTimeout = currentSettings.SessionIdleTimeoutMinutes == 15 ? 30 : 15;
            var newMaxLifetime = currentSettings.SessionMaxLifetimeMinutes == 720 ? 1440 : 720;

            var updatedSettings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = newIdleTimeout,
                SessionMaxLifetimeMinutes = newMaxLifetime
            };

            // Test ReplaceFirstPartyAppSettingsAsync - validates PUT endpoint and response data
            var replaceResult = await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync(appName, updatedSettings);

            replaceResult.Should().NotBeNull();
            replaceResult.SessionIdleTimeoutMinutes.Should().Be(newIdleTimeout);
            replaceResult.SessionMaxLifetimeMinutes.Should().Be(newMaxLifetime);

            // Verify the change persisted with GET
            var verifySettings = await _oktaAppSettingsApi.GetFirstPartyAppSettingsAsync(appName);

            verifySettings.Should().NotBeNull();
            verifySettings.SessionIdleTimeoutMinutes.Should().Be(newIdleTimeout);
            verifySettings.SessionMaxLifetimeMinutes.Should().Be(newMaxLifetime);

            var anotherIdleTimeout = newIdleTimeout == 15 ? 45 : 20;
            var anotherMaxLifetime = newMaxLifetime == 720 ? 1080 : 900;

            var anotherUpdate = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = anotherIdleTimeout,
                SessionMaxLifetimeMinutes = anotherMaxLifetime
            };

            // Test ReplaceFirstPartyAppSettingsWithHttpInfoAsync - validates PUT endpoint with full HTTP response
            var replaceWithHttpInfo = await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsWithHttpInfoAsync(appName, anotherUpdate);

            replaceWithHttpInfo.Should().NotBeNull();
            replaceWithHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK);
            replaceWithHttpInfo.Headers.Should().NotBeNull();
            replaceWithHttpInfo.Headers.Should().ContainKey("Content-Type");
            replaceWithHttpInfo.Data.Should().NotBeNull();
            replaceWithHttpInfo.Data.SessionIdleTimeoutMinutes.Should().Be(anotherIdleTimeout);
            replaceWithHttpInfo.Data.SessionMaxLifetimeMinutes.Should().Be(anotherMaxLifetime);

            // Verify the second change persisted
            var finalVerify = await _oktaAppSettingsApi.GetFirstPartyAppSettingsAsync(appName);

            finalVerify.Should().NotBeNull();
            finalVerify.SessionIdleTimeoutMinutes.Should().Be(anotherIdleTimeout);
            finalVerify.SessionMaxLifetimeMinutes.Should().Be(anotherMaxLifetime);

            // Test boundary values - minimum allowed values
            var minSettings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 5,
                SessionMaxLifetimeMinutes = 5
            };

            var minResult = await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync(appName, minSettings);

            minResult.Should().NotBeNull();
            minResult.SessionIdleTimeoutMinutes.Should().Be(5);
            minResult.SessionMaxLifetimeMinutes.Should().Be(5);

            var minVerify = await _oktaAppSettingsApi.GetFirstPartyAppSettingsAsync(appName);
            minVerify.SessionIdleTimeoutMinutes.Should().Be(5);
            minVerify.SessionMaxLifetimeMinutes.Should().Be(5);

            // Test boundary values - maximum allowed values
            var maxSettings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = 120,
                SessionMaxLifetimeMinutes = 1440
            };

            var maxResult = await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync(appName, maxSettings);

            maxResult.Should().NotBeNull();
            maxResult.SessionIdleTimeoutMinutes.Should().Be(120);
            maxResult.SessionMaxLifetimeMinutes.Should().Be(1440);

            var maxVerify = await _oktaAppSettingsApi.GetFirstPartyAppSettingsAsync(appName);
            maxVerify.SessionIdleTimeoutMinutes.Should().Be(120);
            maxVerify.SessionMaxLifetimeMinutes.Should().Be(1440);

            // Restore original settings
            var restoreResult = await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync(appName, _originalSettings);

            restoreResult.Should().NotBeNull();
            restoreResult.SessionIdleTimeoutMinutes.Should().Be(_originalSettings.SessionIdleTimeoutMinutes);
            restoreResult.SessionMaxLifetimeMinutes.Should().Be(_originalSettings.SessionMaxLifetimeMinutes);

            // Final verification that restore was successful
            var restoredSettings = await _oktaAppSettingsApi.GetFirstPartyAppSettingsAsync(appName);

            restoredSettings.Should().NotBeNull();
            restoredSettings.SessionIdleTimeoutMinutes.Should().Be(_originalSettings.SessionIdleTimeoutMinutes);
            restoredSettings.SessionMaxLifetimeMinutes.Should().Be(_originalSettings.SessionMaxLifetimeMinutes);

            _originalSettings = null;
        }

        [Fact]
        public async Task GivenInvalidScenarios_WhenCallingApi_ThenAllInvalidScenariosAreCovered()
        {
            const string appName = "admin-console";

            // Test 1: Invalid app name with GetFirstPartyAppSettingsAsync
            var getInvalidAppException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _oktaAppSettingsApi.GetFirstPartyAppSettingsAsync("invalid-app-name");
            });
            getInvalidAppException.Should().NotBeNull();
            getInvalidAppException.ErrorCode.Should().BeOneOf(400, 404);
            getInvalidAppException.Message.Should().NotBeNullOrEmpty();
            getInvalidAppException.ErrorContent.Should().NotBeNull();

            // Test 2: Invalid app name with GetFirstPartyAppSettingsWithHttpInfoAsync
            var getWithHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _oktaAppSettingsApi.GetFirstPartyAppSettingsWithHttpInfoAsync("invalid-app-name");
            });
            getWithHttpInfoException.Should().NotBeNull();
            getWithHttpInfoException.ErrorCode.Should().BeOneOf(400, 404);
            getWithHttpInfoException.Message.Should().NotBeNullOrEmpty();
            getWithHttpInfoException.ErrorContent.Should().NotBeNull();
            getWithHttpInfoException.Headers.Should().NotBeNull();

            // Test 3: Null settings with ReplaceFirstPartyAppSettingsAsync (client-side validation)
            var nullException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync(appName, null);
            });
            nullException.Should().NotBeNull();
            nullException.ErrorCode.Should().Be(400);
            nullException.Message.Should().Contain("adminConsoleSettings");

            // Test 4: Null settings with ReplaceFirstPartyAppSettingsWithHttpInfoAsync (client-side validation)
            var nullWithHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsWithHttpInfoAsync(appName, null);
            });
            nullWithHttpInfoException.Should().NotBeNull();
            nullWithHttpInfoException.ErrorCode.Should().Be(400);
            nullWithHttpInfoException.Message.Should().Contain("adminConsoleSettings");

            // Test 5: Idle timeout below a minimum with ReplaceFirstPartyAppSettingsAsync
            var belowMinIdleException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync(appName, new AdminConsoleSettings
                {
                    SessionIdleTimeoutMinutes = 0,
                    SessionMaxLifetimeMinutes = 720
                });
            });
            belowMinIdleException.Should().NotBeNull();
            belowMinIdleException.ErrorCode.Should().Be(400);
            belowMinIdleException.Message.Should().NotBeNullOrEmpty();
            belowMinIdleException.ErrorContent.Should().NotBeNull();

            // Test 6: Idle timeout above maximum with ReplaceFirstPartyAppSettingsWithHttpInfoAsync
            var aboveMaxIdleException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsWithHttpInfoAsync(appName, new AdminConsoleSettings
                {
                    SessionIdleTimeoutMinutes = 121,
                    SessionMaxLifetimeMinutes = 720
                });
            });
            aboveMaxIdleException.Should().NotBeNull();
            aboveMaxIdleException.ErrorCode.Should().Be(400);
            aboveMaxIdleException.Message.Should().NotBeNullOrEmpty();
            aboveMaxIdleException.ErrorContent.Should().NotBeNull();
            aboveMaxIdleException.Headers.Should().NotBeNull();

            // Test 7: Max lifetime below a minimum
            var belowMinLifetimeException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync(appName, new AdminConsoleSettings
                {
                    SessionIdleTimeoutMinutes = 15,
                    SessionMaxLifetimeMinutes = 0
                });
            });
            belowMinLifetimeException.Should().NotBeNull();
            belowMinLifetimeException.ErrorCode.Should().Be(400);
            belowMinLifetimeException.Message.Should().NotBeNullOrEmpty();
            belowMinLifetimeException.ErrorContent.Should().NotBeNull();

            // Test 8: Max lifetime above maximum
            var aboveMaxLifetimeException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync(appName, new AdminConsoleSettings
                {
                    SessionIdleTimeoutMinutes = 15,
                    SessionMaxLifetimeMinutes = 1441
                });
            });
            aboveMaxLifetimeException.Should().NotBeNull();
            aboveMaxLifetimeException.ErrorCode.Should().Be(400);
            aboveMaxLifetimeException.Message.Should().NotBeNullOrEmpty();
            aboveMaxLifetimeException.ErrorContent.Should().NotBeNull();

            // Test 9: Negative idle timeout
            var negativeIdleException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync(appName, new AdminConsoleSettings
                {
                    SessionIdleTimeoutMinutes = -1,
                    SessionMaxLifetimeMinutes = 720
                });
            });
            negativeIdleException.Should().NotBeNull();
            negativeIdleException.ErrorCode.Should().Be(400);
            negativeIdleException.Message.Should().NotBeNullOrEmpty();
            negativeIdleException.ErrorContent.Should().NotBeNull();

            // Test 10: Negative max lifetime
            var negativeLifetimeException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync(appName, new AdminConsoleSettings
                {
                    SessionIdleTimeoutMinutes = 15,
                    SessionMaxLifetimeMinutes = -1
                });
            });
            negativeLifetimeException.Should().NotBeNull();
            negativeLifetimeException.ErrorCode.Should().Be(400);
            negativeLifetimeException.Message.Should().NotBeNullOrEmpty();
            negativeLifetimeException.ErrorContent.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenDefaultValues_WhenReplacingSettings_ThenSettingsAreUpdatedSuccessfully()
        {
            const string appName = "admin-console";
            
            var originalSettings = await _oktaAppSettingsApi.GetFirstPartyAppSettingsAsync(appName);
            _originalSettings = new AdminConsoleSettings
            {
                SessionIdleTimeoutMinutes = originalSettings.SessionIdleTimeoutMinutes,
                SessionMaxLifetimeMinutes = originalSettings.SessionMaxLifetimeMinutes
            };

            try
            {
                var defaultSettings = new AdminConsoleSettings
                {
                    SessionIdleTimeoutMinutes = 15,
                    SessionMaxLifetimeMinutes = 720
                };

                var result = await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync(appName, defaultSettings);

                result.Should().NotBeNull();
                result.SessionIdleTimeoutMinutes.Should().Be(15);
                result.SessionMaxLifetimeMinutes.Should().Be(720);

                var verifySettings = await _oktaAppSettingsApi.GetFirstPartyAppSettingsAsync(appName);
                verifySettings.SessionIdleTimeoutMinutes.Should().Be(15);
                verifySettings.SessionMaxLifetimeMinutes.Should().Be(720);
            }
            finally
            {
                if (_originalSettings != null)
                {
                    await _oktaAppSettingsApi.ReplaceFirstPartyAppSettingsAsync(appName, _originalSettings);
                }
            }
        }
    }
}
