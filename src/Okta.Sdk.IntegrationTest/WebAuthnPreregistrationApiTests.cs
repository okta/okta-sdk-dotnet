// <copyright file="WebAuthnPreregistrationApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for WebAuthnPreregistrationApi.
    /// 
    /// These tests verify the WebAuthn Preregistration API endpoints
    /// against a real Okta environment, covering all 7 API endpoints:
    /// 1. ActivatePreregistrationEnrollmentAsync - POST /webauthn-registration/api/v1/activate
    /// 2. EnrollPreregistrationEnrollmentAsync - POST /webauthn-registration/api/v1/enroll
    /// 3. GenerateFulfillmentRequestAsync - POST /webauthn-registration/api/v1/initiate-fulfillment-request
    /// 4. SendPinAsync - POST /webauthn-registration/api/v1/send-pin
    /// 5. ListWebAuthnPreregistrationFactors - GET /webauthn-registration/api/v1/users/{userId}/enrollments
    /// 6. DeleteWebAuthnPreregistrationFactorAsync - DELETE /webauthn-registration/api/v1/users/{userId}/enrollments/{authenticatorEnrollmentId}
    /// 7. AssignFulfillmentErrorWebAuthnPreregistrationFactorAsync - POST /webauthn-registration/api/v1/users/{userId}/enrollments/{authenticatorEnrollmentId}/mark-error
    /// 
    /// Note: WebAuthn Preregistration requires specific Okta org configuration and 
    /// integration with a fulfillment provider (like Yubico). Some tests may require
    /// manual setup or may only validate API connectivity and error handling.
    /// </summary>
    public class WebAuthnPreregistrationApiTests
    {
        private readonly WebAuthnPreregistrationApi _preregistrationApi;
        private readonly UserApi _userApi;

        public WebAuthnPreregistrationApiTests()
        {
            _preregistrationApi = new WebAuthnPreregistrationApi();
            _userApi = new UserApi();
        }

        /// <summary>
        /// Helper method to create a test user for WebAuthn operations.
        /// </summary>
        private async Task<User> CreateTestUserAsync(string testName)
        {
            var uniqueId = Guid.NewGuid().ToString().Substring(0, 8);
            var userProfile = new UserProfile
            {
                FirstName = "WebAuthn",
                LastName = $"Test-{testName}",
                Email = $"webauthn-test-{uniqueId}@example.com",
                Login = $"webauthn-test-{uniqueId}@example.com"
            };

            var createUserRequest = new CreateUserRequest
            {
                Profile = userProfile
            };

            return await _userApi.CreateUserAsync(createUserRequest, activate: false);
        }

        /// <summary>
        /// Helper method to clean up a test user.
        /// First call deactivates the user, second call permanently deletes.
        /// </summary>
        private async Task CleanupUserAsync(string userId)
        {
            try
            {
                // First delete call deactivates the user
                await _userApi.DeleteUserAsync(userId);
                // Second delete call permanently deletes the user
                await _userApi.DeleteUserAsync(userId);
            }
            catch (ApiException)
            {
                // Ignore cleanup errors - user may already be deleted
            }
        }

        #region ListWebAuthnPreregistrationFactors Tests

        /// <summary>
        /// Tests listing WebAuthn preregistration factors for a user.
        /// This should work even when no factors are enrolled - returns empty list.
        /// </summary>
        [Fact]
        public async Task ListWebAuthnPreregistrationFactors_ForUserWithNoFactors_ReturnsEmptyList()
        {
            User testUser = null;

            try
            {
                // Setup - Create a test user
                testUser = await CreateTestUserAsync("ListEmpty");
                testUser.Should().NotBeNull("Test user should be created successfully");
                testUser.Id.Should().NotBeNullOrEmpty();

                // Act - List WebAuthn preregistration factors
                var factors = await _preregistrationApi.ListWebAuthnPreregistrationFactors(testUser.Id).ToListAsync();

                // Assert - Should return empty list for user with no factors
                factors.Should().NotBeNull("Factors list should not be null");
                factors.Should().BeEmpty("User should have no WebAuthn preregistration factors initially");
            }
            finally
            {
                // Cleanup
                if (testUser != null)
                {
                    await CleanupUserAsync(testUser.Id);
                }
            }
        }

        /// <summary>
        /// Tests that ListWebAuthnPreregistrationFactors returns a proper collection client.
        /// </summary>
        [Fact]
        public async Task ListWebAuthnPreregistrationFactors_ReturnsProperCollectionClient()
        {
            User testUser = null;

            try
            {
                // Setup - Create a test user
                testUser = await CreateTestUserAsync("CollectionClient");

                // Act
                var collectionClient = _preregistrationApi.ListWebAuthnPreregistrationFactors(testUser.Id);

                // Assert
                collectionClient.Should().NotBeNull("Collection client should not be null");
                collectionClient.Should().BeAssignableTo<IOktaCollectionClient<WebAuthnPreregistrationFactor>>();
            }
            finally
            {
                if (testUser != null)
                {
                    await CleanupUserAsync(testUser.Id);
                }
            }
        }

        /// <summary>
        /// Tests that ListWebAuthnPreregistrationFactors throws for invalid user ID.
        /// </summary>
        [Fact]
        public async Task ListWebAuthnPreregistrationFactors_WithInvalidUserId_ThrowsApiException()
        {
            // Act & Assert
            var action = async () =>
            {
                await _preregistrationApi.ListWebAuthnPreregistrationFactors("invalid-user-id-12345").ToListAsync();
            };

            await action.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404 || e.ErrorContent.ToString().Contains("Not found"));
        }

        /// <summary>
        /// Tests using WithHttpInfo variant for listing factors.
        /// </summary>
        [Fact]
        public async Task ListWebAuthnPreregistrationFactorsWithHttpInfo_ReturnsProperResponse()
        {
            User testUser = null;

            try
            {
                // Setup
                testUser = await CreateTestUserAsync("HttpInfo");

                // Act
                var response = await _preregistrationApi.ListWebAuthnPreregistrationFactorsWithHttpInfoAsync(testUser.Id);

                // Assert
                response.Should().NotBeNull("Response should not be null");
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, "Should return 200 OK");
                response.Data.Should().NotBeNull("Response data should not be null");
                response.Data.Should().BeEmpty("Should have no factors initially");
            }
            finally
            {
                if (testUser != null)
                {
                    await CleanupUserAsync(testUser.Id);
                }
            }
        }

        #endregion

        #region EnrollPreregistrationEnrollment Tests

        /// <summary>
        /// Tests enrollment initialization request validation.
        /// Without proper Yubico integration, this should return an error indicating
        /// the feature is not configured or the request is invalid.
        /// </summary>
        [Fact]
        public async Task EnrollPreregistrationEnrollmentAsync_WithoutYubicoIntegration_HandlesAppropriately()
        {
            User testUser = null;

            try
            {
                // Setup
                testUser = await CreateTestUserAsync("EnrollTest");

                var enrollRequest = new EnrollmentInitializationRequest
                {
                    UserId = testUser.Id,
                    FulfillmentProvider = EnrollmentInitializationRequest.FulfillmentProviderEnum.Yubico,
                    EnrollmentRpIds = new List<string> { "example.okta.com" }
                };

                // Act & Assert
                // Without Yubico integration configured, this should either:
                // 1. Return an error about missing configuration
                // 2. Return an error about invalid/missing parameters
                // 3. Work if Yubico integration is actually configured
                var action = async () => await _preregistrationApi.EnrollPreregistrationEnrollmentAsync(enrollRequest);

                // We expect this to throw an ApiException because Yubico integration
                // is not typically configured in test environments
                await action.Should().ThrowAsync<ApiException>(
                    "Should throw when WebAuthn preregistration is not properly configured");
            }
            catch (ApiException ex)
            {
                // Expected - the feature requires specific configuration
                var validErrorCodes = new[] { 400, 403, 404, 500 };
                validErrorCodes.Should().Contain(ex.ErrorCode,
                    "Should return appropriate error for unconfigured feature");
            }
            finally
            {
                if (testUser != null)
                {
                    await CleanupUserAsync(testUser.Id);
                }
            }
        }

        #endregion

        #region ActivatePreregistrationEnrollment Tests

        /// <summary>
        /// Tests that activation request without valid enrollment data returns appropriate error.
        /// </summary>
        [Fact]
        public async Task ActivatePreregistrationEnrollmentAsync_WithInvalidData_ThrowsApiException()
        {
            User testUser = null;

            try
            {
                // Setup
                testUser = await CreateTestUserAsync("ActivateTest");

                var activateRequest = new EnrollmentActivationRequest
                {
                    UserId = testUser.Id,
                    FulfillmentProvider = EnrollmentActivationRequest.FulfillmentProviderEnum.Yubico,
                    Serial = "invalid-serial",
                    PinResponseJwe = "invalid-jwe"
                };

                // Act & Assert
                var action = async () => await _preregistrationApi.ActivatePreregistrationEnrollmentAsync(activateRequest);

                // Should throw because there's no valid enrollment to activate
                await action.Should().ThrowAsync<ApiException>(
                    "Should throw when trying to activate with invalid data");
            }
            finally
            {
                if (testUser != null)
                {
                    await CleanupUserAsync(testUser.Id);
                }
            }
        }

        #endregion

        #region GenerateFulfillmentRequest Tests

        /// <summary>
        /// Tests that fulfillment request generation handles missing configuration appropriately.
        /// </summary>
        [Fact]
        public async Task GenerateFulfillmentRequestAsync_WithoutConfiguration_HandlesAppropriately()
        {
            User testUser = null;

            try
            {
                // Setup
                testUser = await CreateTestUserAsync("FulfillmentTest");

                var fulfillmentRequest = new FulfillmentRequest
                {
                    UserId = testUser.Id,
                    FulfillmentProvider = FulfillmentRequest.FulfillmentProviderEnum.Yubico
                };

                // Act & Assert
                var action = async () => await _preregistrationApi.GenerateFulfillmentRequestAsync(fulfillmentRequest);

                // Without proper configuration, this should throw
                await action.Should().ThrowAsync<ApiException>(
                    "Should throw when WebAuthn preregistration is not configured");
            }
            finally
            {
                if (testUser != null)
                {
                    await CleanupUserAsync(testUser.Id);
                }
            }
        }

        #endregion

        #region SendPin Tests

        /// <summary>
        /// Tests that SendPin with invalid enrollment returns appropriate error.
        /// </summary>
        [Fact]
        public async Task SendPinAsync_WithInvalidEnrollment_ThrowsApiException()
        {
            User testUser = null;

            try
            {
                // Setup
                testUser = await CreateTestUserAsync("SendPinTest");

                var pinRequest = new PinRequest
                {
                    UserId = testUser.Id,
                    AuthenticatorEnrollmentId = "fwe_invalid_enrollment_id",
                    FulfillmentProvider = PinRequest.FulfillmentProviderEnum.Yubico
                };

                // Act & Assert
                var action = async () => await _preregistrationApi.SendPinAsync(pinRequest);

                // Should throw because the enrollment doesn't exist
                await action.Should().ThrowAsync<ApiException>(
                    "Should throw when trying to send PIN for non-existent enrollment");
            }
            finally
            {
                if (testUser != null)
                {
                    await CleanupUserAsync(testUser.Id);
                }
            }
        }

        #endregion

        #region DeleteWebAuthnPreregistrationFactor Tests

        /// <summary>
        /// Tests that deleting a non-existent factor returns 404.
        /// </summary>
        [Fact]
        public async Task DeleteWebAuthnPreregistrationFactorAsync_WithInvalidFactorId_ThrowsApiException()
        {
            User testUser = null;

            try
            {
                // Setup
                testUser = await CreateTestUserAsync("DeleteTest");

                // Act & Assert
                var action = async () => await _preregistrationApi.DeleteWebAuthnPreregistrationFactorAsync(
                    testUser.Id,
                    "fwe_nonexistent_enrollment_id_12345");

                // Should throw 404 because the factor doesn't exist
                await action.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404 || e.ErrorContent.ToString().Contains("Not found"));
            }
            finally
            {
                if (testUser != null)
                {
                    await CleanupUserAsync(testUser.Id);
                }
            }
        }

        /// <summary>
        /// Tests delete with invalid user ID.
        /// </summary>
        [Fact]
        public async Task DeleteWebAuthnPreregistrationFactorAsync_WithInvalidUserId_ThrowsApiException()
        {
            // Act & Assert
            var action = async () => await _preregistrationApi.DeleteWebAuthnPreregistrationFactorAsync(
                "invalid_user_id_12345",
                "fwe_enrollment_id");

            await action.Should().ThrowAsync<ApiException>(
                "Should throw when user ID is invalid");
        }

        #endregion

        #region AssignFulfillmentErrorWebAuthnPreregistrationFactor Tests

        /// <summary>
        /// Tests that marking error on non-existent factor returns appropriate error.
        /// </summary>
        [Fact]
        public async Task AssignFulfillmentErrorWebAuthnPreregistrationFactorAsync_WithInvalidFactorId_ThrowsApiException()
        {
            User testUser = null;

            try
            {
                // Setup
                testUser = await CreateTestUserAsync("MarkErrorTest");

                // Act & Assert
                var action = async () => await _preregistrationApi.AssignFulfillmentErrorWebAuthnPreregistrationFactorAsync(
                    testUser.Id,
                    "fwe_nonexistent_enrollment_id");

                // Should throw because the factor doesn't exist
                await action.Should().ThrowAsync<ApiException>(
                    "Should throw when trying to mark error on non-existent factor");
            }
            finally
            {
                if (testUser != null)
                {
                    await CleanupUserAsync(testUser.Id);
                }
            }
        }

        /// <summary>
        /// Tests mark error with invalid user ID.
        /// </summary>
        [Fact]
        public async Task AssignFulfillmentErrorWebAuthnPreregistrationFactorAsync_WithInvalidUserId_ThrowsApiException()
        {
            // Act & Assert
            var action = async () => await _preregistrationApi.AssignFulfillmentErrorWebAuthnPreregistrationFactorAsync(
                "invalid_user_id_99999",
                "fwe_enrollment_id");

            await action.Should().ThrowAsync<ApiException>(
                "Should throw when user ID is invalid");
        }

        #endregion

        #region Request Model Tests

        /// <summary>
        /// Tests that EnrollmentInitializationRequest can be properly constructed with all properties.
        /// </summary>
        [Fact]
        public void EnrollmentInitializationRequest_CanBeConstructedWithAllProperties()
        {
            // Arrange & Act
            var ecKey = new ECKeyJWK
            {
                Kty = "EC",
                Crv = "P-256",
                X = "base64-x",
                Y = "base64-y"
            };

            var request = new EnrollmentInitializationRequest
            {
                UserId = "00u1234567890",
                FulfillmentProvider = EnrollmentInitializationRequest.FulfillmentProviderEnum.Yubico,
                EnrollmentRpIds = new List<string> { "rp1.example.com", "rp2.example.com" },
                YubicoTransportKeyJWK = ecKey
            };

            // Assert
            request.UserId.Should().Be("00u1234567890");
            request.FulfillmentProvider.Should().Be(EnrollmentInitializationRequest.FulfillmentProviderEnum.Yubico);
            request.EnrollmentRpIds.Should().HaveCount(2);
            request.EnrollmentRpIds.Should().Contain("rp1.example.com");
            request.YubicoTransportKeyJWK.Should().NotBeNull();
            request.YubicoTransportKeyJWK.Kty.Should().Be("EC");
        }

        /// <summary>
        /// Tests that EnrollmentActivationRequest can be properly constructed with all properties.
        /// </summary>
        [Fact]
        public void EnrollmentActivationRequest_CanBeConstructedWithAllProperties()
        {
            // Arrange & Act
            var credResponse = new WebAuthnCredResponse
            {
                AuthenticatorEnrollmentId = "fwe123",
                CredResponseJwe = "encrypted-jwe"
            };

            var ecKey = new ECKeyJWK
            {
                Kty = "EC",
                Crv = "P-256"
            };

            var request = new EnrollmentActivationRequest
            {
                UserId = "00u1234567890",
                FulfillmentProvider = EnrollmentActivationRequest.FulfillmentProviderEnum.Yubico,
                Serial = "YK-12345678",
                PinResponseJwe = "pin-jwe-encrypted",
                _Version = "1.0",
                CredResponses = new List<WebAuthnCredResponse> { credResponse },
                YubicoSigningJwks = new List<ECKeyJWK> { ecKey }
            };

            // Assert
            request.UserId.Should().Be("00u1234567890");
            request.FulfillmentProvider.Should().Be(EnrollmentActivationRequest.FulfillmentProviderEnum.Yubico);
            request.Serial.Should().Be("YK-12345678");
            request.PinResponseJwe.Should().Be("pin-jwe-encrypted");
            request._Version.Should().Be("1.0");
            request.CredResponses.Should().HaveCount(1);
            request.CredResponses[0].AuthenticatorEnrollmentId.Should().Be("fwe123");
            request.YubicoSigningJwks.Should().HaveCount(1);
        }

        /// <summary>
        /// Tests that FulfillmentRequest can be properly constructed.
        /// </summary>
        [Fact]
        public void FulfillmentRequest_CanBeConstructedWithAllProperties()
        {
            // Arrange & Act
            var request = new FulfillmentRequest
            {
                UserId = "00u1234567890",
                FulfillmentProvider = FulfillmentRequest.FulfillmentProviderEnum.Yubico,
                FulfillmentData = new List<FulfillmentDataOrderDetails>()
            };

            // Assert
            request.UserId.Should().Be("00u1234567890");
            request.FulfillmentProvider.Should().Be(FulfillmentRequest.FulfillmentProviderEnum.Yubico);
            request.FulfillmentData.Should().NotBeNull();
        }

        /// <summary>
        /// Tests that PinRequest can be properly constructed.
        /// </summary>
        [Fact]
        public void PinRequest_CanBeConstructedWithAllProperties()
        {
            // Arrange & Act
            var request = new PinRequest
            {
                UserId = "00u1234567890",
                AuthenticatorEnrollmentId = "fwe1234567890",
                FulfillmentProvider = PinRequest.FulfillmentProviderEnum.Yubico
            };

            // Assert
            request.UserId.Should().Be("00u1234567890");
            request.AuthenticatorEnrollmentId.Should().Be("fwe1234567890");
            request.FulfillmentProvider.Should().Be(PinRequest.FulfillmentProviderEnum.Yubico);
        }

        #endregion

        #region Response Model Tests

        /// <summary>
        /// Tests that WebAuthnCredRequest model has proper properties.
        /// </summary>
        [Fact]
        public void WebAuthnCredRequest_HasProperProperties()
        {
            // Arrange & Act
            var credRequest = new WebAuthnCredRequest
            {
                AuthenticatorEnrollmentId = "fwe123",
                CredRequestJwe = "encrypted-request-jwe",
                KeyId = "key-id-123"
            };

            // Assert
            credRequest.AuthenticatorEnrollmentId.Should().Be("fwe123");
            credRequest.CredRequestJwe.Should().Be("encrypted-request-jwe");
            credRequest.KeyId.Should().Be("key-id-123");
        }

        /// <summary>
        /// Tests that WebAuthnCredResponse model has proper properties.
        /// </summary>
        [Fact]
        public void WebAuthnCredResponse_HasProperProperties()
        {
            // Arrange & Act
            var credResponse = new WebAuthnCredResponse
            {
                AuthenticatorEnrollmentId = "fwe456",
                CredResponseJwe = "encrypted-response-jwe"
            };

            // Assert
            credResponse.AuthenticatorEnrollmentId.Should().Be("fwe456");
            credResponse.CredResponseJwe.Should().Be("encrypted-response-jwe");
        }

        #endregion

        #region API Initialization Tests

        /// <summary>
        /// Tests that API can be initialized with default configuration.
        /// </summary>
        [Fact]
        public void WebAuthnPreregistrationApi_CanBeInitialized()
        {
            // Act
            var api = new WebAuthnPreregistrationApi();

            // Assert
            api.Should().NotBeNull("API should be initialized");
        }

        /// <summary>
        /// Tests that API can be initialized with custom configuration.
        /// </summary>
        [Fact]
        public void WebAuthnPreregistrationApi_CanBeInitializedWithConfiguration()
        {
            // Arrange
            var config = new Configuration
            {
                OktaDomain = "https://custom.okta.com",
                Token = "test-token"
            };

            // Act
            var api = new WebAuthnPreregistrationApi(config);

            // Assert
            api.Should().NotBeNull("API should be initialized with custom config");
            api.GetBasePath().Should().Be("https://custom.okta.com");
        }

        #endregion
    }
}
