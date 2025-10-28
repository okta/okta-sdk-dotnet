using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    [Collection(nameof(UserRiskApiTests))]
    public class UserRiskApiTests : IDisposable
    {
        private readonly UserRiskApi _userRiskApi = new();
        private readonly UserApi _userApi = new();
        private readonly List<string> _createdUserIds = [];

        public void Dispose()
        {
            CleanupResources().GetAwaiter().GetResult();
        }

        private async Task CleanupResources()
        {
            foreach (var userId in _createdUserIds)
            {
                try
                {
                    await _userApi.DeleteUserAsync(userId);
                    await _userApi.DeleteUserAsync(userId);
                }
                catch (ApiException)
                {
                    // Ignore cleanup errors
                }
            }
            _createdUserIds.Clear();
        }

        [Fact]
        public async Task UserRiskApi_CompleteCrudLifecycle_ShouldCoverAllEndpointsAndMethods()
        {
            var guid = Guid.NewGuid();

            // Create test user
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "UserRisk",
                    LastName = $"Test{guid.ToString().Substring(0, 8)}",
                    Email = $"user-risk-test-{guid}@example.com",
                    Login = $"user-risk-test-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "ComplexP@ssw0rd!2024" }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);

            createdUser.Should().NotBeNull();
            createdUser.Id.Should().NotBeNullOrEmpty();

            await Task.Delay(2000);

            // Check if User Risk feature is enabled (Identity Engine with Identity Threat Protection)
            try
            {
                await _userRiskApi.GetUserRiskAsync(createdUser.Id);
            }
            catch (ApiException ex) when (ex.ErrorCode == 403 || ex.ErrorCode == 404 || ex.Message.Contains("E0000015"))
            {
                // User Risk API is an Identity Engine feature that requires Identity Threat Protection
                // If not available, skip the test
                return;
            }

            // GetUserRiskAsync - Retrieve initial user risk (should not exist or be default)
            try
            {
                var initialRisk = await _userRiskApi.GetUserRiskAsync(createdUser.Id);
                initialRisk.Should().NotBeNull();
            }
            catch (ApiException ex) when (ex.ErrorCode == 404)
            {
                // Risk not set yet is acceptable
            }

            // UpsertUserRiskAsync - Set user risk to HIGH
            var highRiskRequest = new UserRiskRequest
            {
                RiskLevel = "HIGH"
            };

            var highRiskResponse = await _userRiskApi.UpsertUserRiskAsync(createdUser.Id, highRiskRequest);

            highRiskResponse.Should().NotBeNull();
            highRiskResponse.RiskLevel.Should().Be(UserRiskLevelPut.HIGH);
            highRiskResponse.Reason.Should().NotBeNullOrEmpty();
            highRiskResponse.Links.Should().NotBeNull();
            highRiskResponse.Links.Self.Should().NotBeNull();
            highRiskResponse.Links.User.Should().NotBeNull();

            await Task.Delay(1000);

            // GetUserRiskAsync - Verify HIGH risk was set
            var verifyHighRisk = await _userRiskApi.GetUserRiskAsync(createdUser.Id);

            verifyHighRisk.Should().NotBeNull();
            verifyHighRisk.RiskLevel.Should().Be(UserRiskLevelAll.HIGH);

            // UpsertUserRiskAsync - Update risk to LOW
            var lowRiskRequest = new UserRiskRequest
            {
                RiskLevel = "LOW"
            };

            var lowRiskResponse = await _userRiskApi.UpsertUserRiskAsync(createdUser.Id, lowRiskRequest);

            lowRiskResponse.Should().NotBeNull();
            lowRiskResponse.RiskLevel.Should().Be(UserRiskLevelPut.LOW);

            await Task.Delay(1000);

            // GetUserRiskAsync - Verify LOW risk was set
            var verifyLowRisk = await _userRiskApi.GetUserRiskAsync(createdUser.Id);

            verifyLowRisk.Should().NotBeNull();
            verifyLowRisk.RiskLevel.Should().Be(UserRiskLevelAll.LOW);
        }

        [Fact]
        public async Task UserRiskApi_WithHttpInfo_ShouldReturnHttpMetadata()
        {
            var guid = Guid.NewGuid();

            // Create test user
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "UserRisk",
                    LastName = $"HttpInfo{guid.ToString().Substring(0, 8)}",
                    Email = $"user-risk-http-{guid}@example.com",
                    Login = $"user-risk-http-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "ComplexP@ssw0rd!2024" }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);

            await Task.Delay(2000);

            // Check if User Risk feature is enabled
            try
            {
                await _userRiskApi.GetUserRiskAsync(createdUser.Id);
            }
            catch (ApiException ex) when (ex.ErrorCode == 403 || ex.ErrorCode == 404 || ex.Message.Contains("E0000015"))
            {
                // Feature not available, skip test
                return;
            }

            // TEST 1: UpsertUserRiskWithHttpInfoAsync - Create risk with HTTP metadata
            var riskRequest = new UserRiskRequest
            {
                RiskLevel = "HIGH"
            };

            var createResponse = await _userRiskApi.UpsertUserRiskWithHttpInfoAsync(createdUser.Id, riskRequest);

            createResponse.Should().NotBeNull();
            createResponse.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.Created);
            createResponse.Data.Should().NotBeNull();
            createResponse.Data.RiskLevel.Should().Be(UserRiskLevelPut.HIGH);
            createResponse.Headers.Should().NotBeNull();

            await Task.Delay(1000);

            // TEST 2: GetUserRiskWithHttpInfoAsync - Retrieve risk with HTTP metadata
            var getResponse = await _userRiskApi.GetUserRiskWithHttpInfoAsync(createdUser.Id);

            getResponse.Should().NotBeNull();
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.Data.Should().NotBeNull();
            getResponse.Data.RiskLevel.Should().Be(UserRiskLevelAll.HIGH);
            getResponse.Headers.Should().NotBeNull();

            // TEST 3: UpsertUserRiskWithHttpInfoAsync - Update risk with HTTP metadata
            var updateRequest = new UserRiskRequest
            {
                RiskLevel = "LOW"
            };

            var updateResponse = await _userRiskApi.UpsertUserRiskWithHttpInfoAsync(createdUser.Id, updateRequest);

            updateResponse.Should().NotBeNull();
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            updateResponse.Data.Should().NotBeNull();
            updateResponse.Data.RiskLevel.Should().Be(UserRiskLevelPut.LOW);
            updateResponse.Headers.Should().NotBeNull();

            await Task.Delay(1000);

            // TEST 4: GetUserRiskWithHttpInfoAsync - Verify update with HTTP metadata
            var verifyResponse = await _userRiskApi.GetUserRiskWithHttpInfoAsync(createdUser.Id);

            verifyResponse.Should().NotBeNull();
            verifyResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            verifyResponse.Data.Should().NotBeNull();
            verifyResponse.Data.RiskLevel.Should().Be(UserRiskLevelAll.LOW);
            verifyResponse.Headers.Should().NotBeNull();
        }

        [Fact]
        public async Task UserRiskApi_ErrorScenarios_ShouldThrowApiException()
        {
            const string invalidUserId = "invalid_user_id_12345";

            // GetUserRiskAsync with invalid userId - should throw 401, 403 or 404
            var getException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userRiskApi.GetUserRiskAsync(invalidUserId);
            });
            getException.ErrorCode.Should().BeOneOf(401, 403, 404);

            // UpsertUserRiskAsync with invalid userId - should throw 401, 403 or 404
            var riskRequest = new UserRiskRequest
            {
                RiskLevel = "HIGH"
            };

            var upsertException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userRiskApi.UpsertUserRiskAsync(invalidUserId, riskRequest);
            });
            upsertException.ErrorCode.Should().BeOneOf(401, 403, 404);

            // GetUserRiskWithHttpInfoAsync with invalid userId - should throw 401, 403 or 404
            var getHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userRiskApi.GetUserRiskWithHttpInfoAsync(invalidUserId);
            });
            getHttpInfoException.ErrorCode.Should().BeOneOf(401, 403, 404);

            // UpsertUserRiskWithHttpInfoAsync with invalid userId - should throw 401, 403 or 404
            var upsertHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userRiskApi.UpsertUserRiskWithHttpInfoAsync(invalidUserId, riskRequest);
            });
            upsertHttpInfoException.ErrorCode.Should().BeOneOf(401, 403, 404);

            // UpsertUserRiskAsync with invalid risk level - should throw 400
            var guid = Guid.NewGuid();
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "UserRisk",
                    LastName = "ErrorTest",
                    Email = $"user-risk-error-{guid}@example.com",
                    Login = $"user-risk-error-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "ComplexP@ssw0rd!2024" }
                }
            };

            try
            {
                var user = await _userApi.CreateUserAsync(createUserRequest, activate: true);
                _createdUserIds.Add(user.Id);

                await Task.Delay(2000);

                // Try to set invalid risk level (not HIGH or LOW)
                var invalidRiskRequest = new UserRiskRequest
                {
                    RiskLevel = "INVALID_LEVEL"
                };

                var invalidException = await Assert.ThrowsAsync<ApiException>(async () =>
                {
                    await _userRiskApi.UpsertUserRiskAsync(user.Id, invalidRiskRequest);
                });
                invalidException.ErrorCode.Should().BeOneOf(400, 401, 403);
            }
            catch (ApiException ex) when (ex.ErrorCode == 401 || ex.ErrorCode == 403 || ex.Message.Contains("E0000015"))
            {
                // Feature not available - test cannot run
            }
        }
    }
}
