using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Okta.Sdk.UnitTest.Internal;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    public class DeviceAccessApiTests
    {
        private const string BaseUrl = "https://test.okta.com";

        #region GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync Tests

        [Fact]
        public async Task GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync_ReturnsCurrentSetting()
        {
            var responseJson = @"{
                ""desktopMFAEnforceNumberMatchingChallengeEnabled"": true
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAccessApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync();

            result.Should().NotBeNull();
            result.DesktopMFAEnforceNumberMatchingChallengeEnabled.Should().BeTrue();
            mockClient.ReceivedPath.Should().Be("/device-access/api/v1/desktop-mfa/enforce-number-matching-challenge-settings");
        }

        [Fact]
        public async Task GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync_WhenDisabled_ReturnsFalse()
        {
            var responseJson = @"{
                ""desktopMFAEnforceNumberMatchingChallengeEnabled"": false
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAccessApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync();

            result.Should().NotBeNull();
            result.DesktopMFAEnforceNumberMatchingChallengeEnabled.Should().BeFalse();
        }

        [Fact]
        public async Task GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingWithHttpInfoAsync_ReturnsOkResponse()
        {
            var responseJson = @"{
                ""desktopMFAEnforceNumberMatchingChallengeEnabled"": true
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAccessApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.DesktopMFAEnforceNumberMatchingChallengeEnabled.Should().BeTrue();
        }

        #endregion

        #region ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync Tests

        [Fact]
        public async Task ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync_EnablesSetting()
        {
            var responseJson = @"{
                ""desktopMFAEnforceNumberMatchingChallengeEnabled"": true
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAccessApi(mockClient, new Configuration { BasePath = BaseUrl });

            var setting = new DesktopMFAEnforceNumberMatchingChallengeOrgSetting
            {
                DesktopMFAEnforceNumberMatchingChallengeEnabled = true
            };

            var result = await api.ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync(setting);

            result.Should().NotBeNull();
            result.DesktopMFAEnforceNumberMatchingChallengeEnabled.Should().BeTrue();
            mockClient.ReceivedPath.Should().Be("/device-access/api/v1/desktop-mfa/enforce-number-matching-challenge-settings");
            mockClient.ReceivedBody.Should().NotBeNull();
        }

        [Fact]
        public async Task ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync_DisablesSetting()
        {
            var responseJson = @"{
                ""desktopMFAEnforceNumberMatchingChallengeEnabled"": false
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAccessApi(mockClient, new Configuration { BasePath = BaseUrl });

            var setting = new DesktopMFAEnforceNumberMatchingChallengeOrgSetting
            {
                DesktopMFAEnforceNumberMatchingChallengeEnabled = false
            };

            var result = await api.ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingAsync(setting);

            result.Should().NotBeNull();
            result.DesktopMFAEnforceNumberMatchingChallengeEnabled.Should().BeFalse();
        }

        [Fact]
        public async Task ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingWithHttpInfoAsync_ReturnsOkResponse()
        {
            var responseJson = @"{
                ""desktopMFAEnforceNumberMatchingChallengeEnabled"": true
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAccessApi(mockClient, new Configuration { BasePath = BaseUrl });

            var setting = new DesktopMFAEnforceNumberMatchingChallengeOrgSetting
            {
                DesktopMFAEnforceNumberMatchingChallengeEnabled = true
            };

            var response = await api.ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingWithHttpInfoAsync(setting);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.DesktopMFAEnforceNumberMatchingChallengeEnabled.Should().BeTrue();
        }

        #endregion

        #region GetDesktopMFARecoveryPinOrgSettingAsync Tests

        [Fact]
        public async Task GetDesktopMFARecoveryPinOrgSettingAsync_ReturnsCurrentSetting()
        {
            var responseJson = @"{
                ""desktopMFARecoveryPinEnabled"": true
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAccessApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetDesktopMFARecoveryPinOrgSettingAsync();

            result.Should().NotBeNull();
            result.DesktopMFARecoveryPinEnabled.Should().BeTrue();
            mockClient.ReceivedPath.Should().Be("/device-access/api/v1/desktop-mfa/recovery-pin-settings");
        }

        [Fact]
        public async Task GetDesktopMFARecoveryPinOrgSettingAsync_WhenDisabled_ReturnsFalse()
        {
            var responseJson = @"{
                ""desktopMFARecoveryPinEnabled"": false
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAccessApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetDesktopMFARecoveryPinOrgSettingAsync();

            result.Should().NotBeNull();
            result.DesktopMFARecoveryPinEnabled.Should().BeFalse();
        }

        [Fact]
        public async Task GetDesktopMFARecoveryPinOrgSettingWithHttpInfoAsync_ReturnsOkResponse()
        {
            var responseJson = @"{
                ""desktopMFARecoveryPinEnabled"": true
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAccessApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetDesktopMFARecoveryPinOrgSettingWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.DesktopMFARecoveryPinEnabled.Should().BeTrue();
        }

        #endregion

        #region ReplaceDesktopMFARecoveryPinOrgSettingAsync Tests

        [Fact]
        public async Task ReplaceDesktopMFARecoveryPinOrgSettingAsync_EnablesSetting()
        {
            var responseJson = @"{
                ""desktopMFARecoveryPinEnabled"": true
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAccessApi(mockClient, new Configuration { BasePath = BaseUrl });

            var setting = new DesktopMFARecoveryPinOrgSetting
            {
                DesktopMFARecoveryPinEnabled = true
            };

            var result = await api.ReplaceDesktopMFARecoveryPinOrgSettingAsync(setting);

            result.Should().NotBeNull();
            result.DesktopMFARecoveryPinEnabled.Should().BeTrue();
            mockClient.ReceivedPath.Should().Be("/device-access/api/v1/desktop-mfa/recovery-pin-settings");
            mockClient.ReceivedBody.Should().NotBeNull();
        }

        [Fact]
        public async Task ReplaceDesktopMFARecoveryPinOrgSettingAsync_DisablesSetting()
        {
            var responseJson = @"{
                ""desktopMFARecoveryPinEnabled"": false
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAccessApi(mockClient, new Configuration { BasePath = BaseUrl });

            var setting = new DesktopMFARecoveryPinOrgSetting
            {
                DesktopMFARecoveryPinEnabled = false
            };

            var result = await api.ReplaceDesktopMFARecoveryPinOrgSettingAsync(setting);

            result.Should().NotBeNull();
            result.DesktopMFARecoveryPinEnabled.Should().BeFalse();
        }

        [Fact]
        public async Task ReplaceDesktopMFARecoveryPinOrgSettingWithHttpInfoAsync_ReturnsOkResponse()
        {
            var responseJson = @"{
                ""desktopMFARecoveryPinEnabled"": true
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new DeviceAccessApi(mockClient, new Configuration { BasePath = BaseUrl });

            var setting = new DesktopMFARecoveryPinOrgSetting
            {
                DesktopMFARecoveryPinEnabled = true
            };

            var response = await api.ReplaceDesktopMFARecoveryPinOrgSettingWithHttpInfoAsync(setting);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.DesktopMFARecoveryPinEnabled.Should().BeTrue();
        }

        #endregion
    }
}
