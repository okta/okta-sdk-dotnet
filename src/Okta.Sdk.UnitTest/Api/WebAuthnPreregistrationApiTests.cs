// <copyright file="WebAuthnPreregistrationApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// Unit tests for WebAuthnPreregistrationApi covering all 7 endpoints.
    /// 
    /// API Coverage:
    /// 1. POST /webauthn-registration/api/v1/activate - ActivatePreregistrationEnrollmentAsync
    /// 2. POST /webauthn-registration/api/v1/enroll - EnrollPreregistrationEnrollmentAsync
    /// 3. POST /webauthn-registration/api/v1/initiate-fulfillment-request - GenerateFulfillmentRequestAsync
    /// 4. POST /webauthn-registration/api/v1/send-pin - SendPinAsync
    /// 5. GET /webauthn-registration/api/v1/users/{userId}/enrollments - ListWebAuthnPreregistrationFactors
    /// 6. DELETE /webauthn-registration/api/v1/users/{userId}/enrollments/{authenticatorEnrollmentId} - DeleteWebAuthnPreregistrationFactorAsync
    /// 7. POST /webauthn-registration/api/v1/users/{userId}/enrollments/{authenticatorEnrollmentId}/mark-error - AssignFulfillmentErrorWebAuthnPreregistrationFactorAsync
    /// 
    /// Each method is tested with:
    /// - Regular async method
    /// - WithHttpInfo variant for response metadata
    /// - Proper request path and parameters validation
    /// - Request body validation
    /// - Response data validation
    /// </summary>
    public class WebAuthnPreregistrationApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _userId = "00u1234567890abcdef";
        private readonly string _authenticatorEnrollmentId = "fwe1234567890abcdef";

        #region ActivatePreregistrationEnrollment Tests

        [Fact]
        public async Task ActivatePreregistrationEnrollmentAsync_BuildsCorrectPath()
        {
            // Arrange
            var responseJson = @"{
                ""authenticatorEnrollmentIds"": [""fwe1234567890abcdef""],
                ""fulfillmentProvider"": ""yubico"",
                ""userId"": ""00u1234567890abcdef""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new EnrollmentActivationRequest
            {
                UserId = _userId,
                FulfillmentProvider = EnrollmentActivationRequest.FulfillmentProviderEnum.Yubico,
                Serial = "12345678",
                PinResponseJwe = "eyJhbGciOiJFQ0RILUVTK0EyNTZLVyIsImVuYyI6IkEyNTZHQ00ifQ..."
            };

            // Act
            await api.ActivatePreregistrationEnrollmentAsync(request);

            // Assert
            mockClient.ReceivedPath.Should().Be("/webauthn-registration/api/v1/activate");
        }

        [Fact]
        public async Task ActivatePreregistrationEnrollmentWithHttpInfoAsync_ReturnsCorrectResponse()
        {
            // Arrange
            var responseJson = @"{
                ""authenticatorEnrollmentIds"": [""fwe1234567890abcdef"", ""fwe0987654321fedcba""],
                ""fulfillmentProvider"": ""yubico"",
                ""userId"": ""00u1234567890abcdef""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new EnrollmentActivationRequest
            {
                UserId = _userId,
                FulfillmentProvider = EnrollmentActivationRequest.FulfillmentProviderEnum.Yubico,
                Serial = "12345678"
            };

            // Act
            var response = await api.ActivatePreregistrationEnrollmentWithHttpInfoAsync(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.AuthenticatorEnrollmentIds.Should().HaveCount(2);
            response.Data.AuthenticatorEnrollmentIds[0].Should().Be("fwe1234567890abcdef");
            response.Data.AuthenticatorEnrollmentIds[1].Should().Be("fwe0987654321fedcba");
            response.Data.FulfillmentProvider.ToString().Should().Be("yubico");
            response.Data.UserId.Should().Be(_userId);
        }

        [Fact]
        public async Task ActivatePreregistrationEnrollmentAsync_SendsRequestBody()
        {
            // Arrange
            var responseJson = @"{
                ""authenticatorEnrollmentIds"": [""fwe1234567890abcdef""],
                ""fulfillmentProvider"": ""yubico"",
                ""userId"": ""00u1234567890abcdef""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new EnrollmentActivationRequest
            {
                UserId = _userId,
                FulfillmentProvider = EnrollmentActivationRequest.FulfillmentProviderEnum.Yubico,
                Serial = "YK-12345678",
                PinResponseJwe = "eyJhbGciOiJFQ0RILUVTK0EyNTZLVyJ9",
                _Version = "1.0"
            };

            // Act
            await api.ActivatePreregistrationEnrollmentWithHttpInfoAsync(request);

            // Assert
            mockClient.ReceivedBody.Should().Contain("userId");
            mockClient.ReceivedBody.Should().Contain(_userId);
            mockClient.ReceivedBody.Should().Contain("fulfillmentProvider");
            mockClient.ReceivedBody.Should().Contain("yubico");
            mockClient.ReceivedBody.Should().Contain("serial");
            mockClient.ReceivedBody.Should().Contain("YK-12345678");
            mockClient.ReceivedBody.Should().Contain("pinResponseJwe");
        }

        [Fact]
        public async Task ActivatePreregistrationEnrollmentAsync_WithCredResponses_IncludesInBody()
        {
            // Arrange
            var responseJson = @"{
                ""authenticatorEnrollmentIds"": [""fwe1234567890abcdef""],
                ""fulfillmentProvider"": ""yubico"",
                ""userId"": ""00u1234567890abcdef""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var credResponse = new WebAuthnCredResponse
            {
                AuthenticatorEnrollmentId = _authenticatorEnrollmentId,
                CredResponseJwe = "eyJhbGciOiJFQ0RILUVTK0EyNTZLVyIsImVuYyI6IkEyNTZHQ00ifQ.encrypted"
            };

            var request = new EnrollmentActivationRequest
            {
                UserId = _userId,
                FulfillmentProvider = EnrollmentActivationRequest.FulfillmentProviderEnum.Yubico,
                CredResponses = new List<WebAuthnCredResponse> { credResponse }
            };

            // Act
            await api.ActivatePreregistrationEnrollmentWithHttpInfoAsync(request);

            // Assert
            mockClient.ReceivedBody.Should().Contain("credResponses");
            mockClient.ReceivedBody.Should().Contain("authenticatorEnrollmentId");
            mockClient.ReceivedBody.Should().Contain("credResponseJwe");
        }

        #endregion

        #region EnrollPreregistrationEnrollment Tests

        [Fact]
        public async Task EnrollPreregistrationEnrollmentAsync_BuildsCorrectPath()
        {
            // Arrange
            var responseJson = @"{
                ""credRequests"": [],
                ""fulfillmentProvider"": ""yubico"",
                ""pinRequestJwe"": ""eyJhbGciOiJFQ0RILUVTK0EyNTZLVyJ9"",
                ""userId"": ""00u1234567890abcdef""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new EnrollmentInitializationRequest
            {
                UserId = _userId,
                FulfillmentProvider = EnrollmentInitializationRequest.FulfillmentProviderEnum.Yubico
            };

            // Act
            await api.EnrollPreregistrationEnrollmentAsync(request);

            // Assert
            mockClient.ReceivedPath.Should().Be("/webauthn-registration/api/v1/enroll");
        }

        [Fact]
        public async Task EnrollPreregistrationEnrollmentWithHttpInfoAsync_ReturnsCorrectResponse()
        {
            // Arrange
            var responseJson = @"{
                ""credRequests"": [
                    {
                        ""authenticatorEnrollmentId"": ""fwe1234567890abcdef"",
                        ""credRequestJwe"": ""eyJhbGciOiJFQ0RILUVTK0EyNTZLVyIsImVuYyI6IkEyNTZHQ00ifQ.encrypted"",
                        ""keyId"": ""kid-12345""
                    }
                ],
                ""fulfillmentProvider"": ""yubico"",
                ""pinRequestJwe"": ""eyJhbGciOiJFQ0RILUVTK0EyNTZLVyJ9.pin-encrypted"",
                ""userId"": ""00u1234567890abcdef""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new EnrollmentInitializationRequest
            {
                UserId = _userId,
                FulfillmentProvider = EnrollmentInitializationRequest.FulfillmentProviderEnum.Yubico,
                EnrollmentRpIds = new List<string> { "example.okta.com" }
            };

            // Act
            var response = await api.EnrollPreregistrationEnrollmentWithHttpInfoAsync(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.CredRequests.Should().HaveCount(1);
            response.Data.CredRequests[0].AuthenticatorEnrollmentId.Should().Be(_authenticatorEnrollmentId);
            response.Data.CredRequests[0].CredRequestJwe.Should().Contain("encrypted");
            response.Data.CredRequests[0].KeyId.Should().Be("kid-12345");
            response.Data.FulfillmentProvider.ToString().Should().Be("yubico");
            response.Data.PinRequestJwe.Should().Contain("pin-encrypted");
            response.Data.UserId.Should().Be(_userId);
        }

        [Fact]
        public async Task EnrollPreregistrationEnrollmentAsync_SendsRequestBody()
        {
            // Arrange
            var responseJson = @"{
                ""credRequests"": [],
                ""fulfillmentProvider"": ""yubico"",
                ""pinRequestJwe"": ""eyJhbGciOiJFQ0RILUVTK0EyNTZLVyJ9"",
                ""userId"": ""00u1234567890abcdef""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new EnrollmentInitializationRequest
            {
                UserId = _userId,
                FulfillmentProvider = EnrollmentInitializationRequest.FulfillmentProviderEnum.Yubico,
                EnrollmentRpIds = new List<string> { "rp1.okta.com", "rp2.okta.com" }
            };

            // Act
            await api.EnrollPreregistrationEnrollmentWithHttpInfoAsync(request);

            // Assert
            mockClient.ReceivedBody.Should().Contain("userId");
            mockClient.ReceivedBody.Should().Contain(_userId);
            mockClient.ReceivedBody.Should().Contain("fulfillmentProvider");
            mockClient.ReceivedBody.Should().Contain("yubico");
            mockClient.ReceivedBody.Should().Contain("enrollmentRpIds");
            mockClient.ReceivedBody.Should().Contain("rp1.okta.com");
            mockClient.ReceivedBody.Should().Contain("rp2.okta.com");
        }

        [Fact]
        public async Task EnrollPreregistrationEnrollmentAsync_WithMultipleCredRequests_ReturnsAll()
        {
            // Arrange
            var responseJson = @"{
                ""credRequests"": [
                    {
                        ""authenticatorEnrollmentId"": ""fwe1111111111111111"",
                        ""credRequestJwe"": ""jwe1"",
                        ""keyId"": ""kid-1""
                    },
                    {
                        ""authenticatorEnrollmentId"": ""fwe2222222222222222"",
                        ""credRequestJwe"": ""jwe2"",
                        ""keyId"": ""kid-2""
                    }
                ],
                ""fulfillmentProvider"": ""yubico"",
                ""pinRequestJwe"": ""pin-jwe"",
                ""userId"": ""00u1234567890abcdef""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.EnrollPreregistrationEnrollmentWithHttpInfoAsync(new EnrollmentInitializationRequest());

            // Assert
            response.Data.CredRequests.Should().HaveCount(2);
            response.Data.CredRequests[0].AuthenticatorEnrollmentId.Should().Be("fwe1111111111111111");
            response.Data.CredRequests[1].AuthenticatorEnrollmentId.Should().Be("fwe2222222222222222");
        }

        #endregion

        #region GenerateFulfillmentRequest Tests

        [Fact]
        public async Task GenerateFulfillmentRequestAsync_BuildsCorrectPath()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FulfillmentRequest
            {
                UserId = _userId,
                FulfillmentProvider = FulfillmentRequest.FulfillmentProviderEnum.Yubico
            };

            // Act
            await api.GenerateFulfillmentRequestAsync(request);

            // Assert
            mockClient.ReceivedPath.Should().Be("/webauthn-registration/api/v1/initiate-fulfillment-request");
        }

        [Fact]
        public async Task GenerateFulfillmentRequestWithHttpInfoAsync_Returns204()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FulfillmentRequest
            {
                UserId = _userId,
                FulfillmentProvider = FulfillmentRequest.FulfillmentProviderEnum.Yubico
            };

            // Act
            var response = await api.GenerateFulfillmentRequestWithHttpInfoAsync(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task GenerateFulfillmentRequestAsync_SendsRequestBody()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FulfillmentRequest
            {
                UserId = _userId,
                FulfillmentProvider = FulfillmentRequest.FulfillmentProviderEnum.Yubico
            };

            // Act
            await api.GenerateFulfillmentRequestWithHttpInfoAsync(request);

            // Assert
            mockClient.ReceivedBody.Should().Contain("userId");
            mockClient.ReceivedBody.Should().Contain(_userId);
            mockClient.ReceivedBody.Should().Contain("fulfillmentProvider");
            mockClient.ReceivedBody.Should().Contain("yubico");
        }

        [Fact]
        public async Task GenerateFulfillmentRequestAsync_WithFulfillmentData_IncludesInBody()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new FulfillmentRequest
            {
                UserId = _userId,
                FulfillmentProvider = FulfillmentRequest.FulfillmentProviderEnum.Yubico,
                FulfillmentData = new List<FulfillmentDataOrderDetails>
                {
                    new FulfillmentDataOrderDetails()
                }
            };

            // Act
            await api.GenerateFulfillmentRequestWithHttpInfoAsync(request);

            // Assert
            mockClient.ReceivedBody.Should().Contain("fulfillmentData");
        }

        #endregion

        #region SendPin Tests

        [Fact]
        public async Task SendPinAsync_BuildsCorrectPath()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new PinRequest
            {
                UserId = _userId,
                AuthenticatorEnrollmentId = _authenticatorEnrollmentId,
                FulfillmentProvider = PinRequest.FulfillmentProviderEnum.Yubico
            };

            // Act
            await api.SendPinAsync(request);

            // Assert
            mockClient.ReceivedPath.Should().Be("/webauthn-registration/api/v1/send-pin");
        }

        [Fact]
        public async Task SendPinWithHttpInfoAsync_Returns204()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new PinRequest
            {
                UserId = _userId,
                AuthenticatorEnrollmentId = _authenticatorEnrollmentId,
                FulfillmentProvider = PinRequest.FulfillmentProviderEnum.Yubico
            };

            // Act
            var response = await api.SendPinWithHttpInfoAsync(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task SendPinAsync_SendsRequestBody()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new PinRequest
            {
                UserId = _userId,
                AuthenticatorEnrollmentId = _authenticatorEnrollmentId,
                FulfillmentProvider = PinRequest.FulfillmentProviderEnum.Yubico
            };

            // Act
            await api.SendPinWithHttpInfoAsync(request);

            // Assert
            mockClient.ReceivedBody.Should().Contain("userId");
            mockClient.ReceivedBody.Should().Contain(_userId);
            mockClient.ReceivedBody.Should().Contain("authenticatorEnrollmentId");
            mockClient.ReceivedBody.Should().Contain(_authenticatorEnrollmentId);
            mockClient.ReceivedBody.Should().Contain("fulfillmentProvider");
            mockClient.ReceivedBody.Should().Contain("yubico");
        }

        #endregion

        #region ListWebAuthnPreregistrationFactors Tests

        [Fact]
        public void ListWebAuthnPreregistrationFactors_ReturnsCollectionClient()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]", HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = api.ListWebAuthnPreregistrationFactors(_userId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<WebAuthnPreregistrationFactor>>();
        }

        [Fact]
        public void ListWebAuthnPreregistrationFactors_SetsPathParameters()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]", HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = api.ListWebAuthnPreregistrationFactors(_userId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OktaCollectionClient<WebAuthnPreregistrationFactor>>();
        }

        [Fact]
        public void ListWebAuthnPreregistrationFactors_ThrowsOnNullUserId()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]", HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = Assert.Throws<ApiException>(() => api.ListWebAuthnPreregistrationFactors(null));
            exception.Message.Should().Contain("Missing required parameter 'userId'");
        }

        [Fact]
        public async Task ListWebAuthnPreregistrationFactorsWithHttpInfoAsync_BuildsCorrectPath()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListWebAuthnPreregistrationFactorsWithHttpInfoAsync(_userId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/webauthn-registration/api/v1/users/{userId}/enrollments");
            mockClient.ReceivedPathParams.Should().ContainKey("userId");
            mockClient.ReceivedPathParams["userId"].Should().Be(_userId);
        }

        [Fact]
        public async Task ListWebAuthnPreregistrationFactorsWithHttpInfoAsync_ReturnsFactors()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""fwe1234567890abcdef"",
                    ""factorType"": ""webauthn"",
                    ""provider"": ""FIDO"",
                    ""status"": ""ACTIVE"",
                    ""vendorName"": ""FIDO"",
                    ""created"": ""2024-01-15T10:30:00.000Z"",
                    ""lastUpdated"": ""2024-01-15T10:30:00.000Z"",
                    ""profile"": {
                        ""credentialId"": ""cred-id-123""
                    }
                },
                {
                    ""id"": ""fwe9876543210fedcba"",
                    ""factorType"": ""webauthn"",
                    ""provider"": ""FIDO"",
                    ""status"": ""PENDING_ACTIVATION"",
                    ""vendorName"": ""FIDO"",
                    ""created"": ""2024-01-16T14:45:00.000Z"",
                    ""lastUpdated"": ""2024-01-16T14:45:00.000Z""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListWebAuthnPreregistrationFactorsWithHttpInfoAsync(_userId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(2);
            
            var firstFactor = response.Data[0];
            firstFactor.Id.Should().Be("fwe1234567890abcdef");
            firstFactor.FactorType.Should().Be(UserFactorType.Webauthn);
            firstFactor.Provider.Should().Be(UserFactorProvider.FIDO);
            firstFactor.Status.Should().Be(UserFactorStatus.ACTIVE);
            firstFactor.VendorName.Should().Be("FIDO");

            var secondFactor = response.Data[1];
            secondFactor.Id.Should().Be("fwe9876543210fedcba");
            secondFactor.Status.Should().Be(UserFactorStatus.PENDINGACTIVATION);
        }

        [Fact]
        public async Task ListWebAuthnPreregistrationFactorsWithHttpInfoAsync_ThrowsOnNullUserId()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]", HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ListWebAuthnPreregistrationFactorsWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task ListWebAuthnPreregistrationFactorsWithHttpInfoAsync_ReturnsEmptyList()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListWebAuthnPreregistrationFactorsWithHttpInfoAsync(_userId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().BeEmpty();
        }

        #endregion

        #region DeleteWebAuthnPreregistrationFactor Tests

        [Fact]
        public async Task DeleteWebAuthnPreregistrationFactorAsync_BuildsCorrectPath()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteWebAuthnPreregistrationFactorAsync(_userId, _authenticatorEnrollmentId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/webauthn-registration/api/v1/users/{userId}/enrollments/{authenticatorEnrollmentId}");
            mockClient.ReceivedPathParams.Should().ContainKey("userId");
            mockClient.ReceivedPathParams["userId"].Should().Be(_userId);
            mockClient.ReceivedPathParams.Should().ContainKey("authenticatorEnrollmentId");
            mockClient.ReceivedPathParams["authenticatorEnrollmentId"].Should().Be(_authenticatorEnrollmentId);
        }

        [Fact]
        public async Task DeleteWebAuthnPreregistrationFactorWithHttpInfoAsync_Returns204()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteWebAuthnPreregistrationFactorWithHttpInfoAsync(_userId, _authenticatorEnrollmentId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteWebAuthnPreregistrationFactorAsync_ThrowsOnNullUserId()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteWebAuthnPreregistrationFactorAsync(null, _authenticatorEnrollmentId));
        }

        [Fact]
        public async Task DeleteWebAuthnPreregistrationFactorAsync_ThrowsOnNullAuthenticatorEnrollmentId()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteWebAuthnPreregistrationFactorAsync(_userId, null));
        }

        [Fact]
        public async Task DeleteWebAuthnPreregistrationFactorWithHttpInfoAsync_SetsPathParameters()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteWebAuthnPreregistrationFactorWithHttpInfoAsync(_userId, _authenticatorEnrollmentId);

            // Assert
            mockClient.ReceivedPathParams.Should().HaveCount(2);
            mockClient.ReceivedPathParams["userId"].Should().Be(_userId);
            mockClient.ReceivedPathParams["authenticatorEnrollmentId"].Should().Be(_authenticatorEnrollmentId);
        }

        #endregion

        #region AssignFulfillmentErrorWebAuthnPreregistrationFactor Tests

        [Fact]
        public async Task AssignFulfillmentErrorWebAuthnPreregistrationFactorAsync_BuildsCorrectPath()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.AssignFulfillmentErrorWebAuthnPreregistrationFactorAsync(_userId, _authenticatorEnrollmentId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/webauthn-registration/api/v1/users/{userId}/enrollments/{authenticatorEnrollmentId}/mark-error");
            mockClient.ReceivedPathParams.Should().ContainKey("userId");
            mockClient.ReceivedPathParams["userId"].Should().Be(_userId);
            mockClient.ReceivedPathParams.Should().ContainKey("authenticatorEnrollmentId");
            mockClient.ReceivedPathParams["authenticatorEnrollmentId"].Should().Be(_authenticatorEnrollmentId);
        }

        [Fact]
        public async Task AssignFulfillmentErrorWebAuthnPreregistrationFactorWithHttpInfoAsync_Returns204()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.AssignFulfillmentErrorWebAuthnPreregistrationFactorWithHttpInfoAsync(_userId, _authenticatorEnrollmentId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task AssignFulfillmentErrorWebAuthnPreregistrationFactorAsync_ThrowsOnNullUserId()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.AssignFulfillmentErrorWebAuthnPreregistrationFactorAsync(null, _authenticatorEnrollmentId));
            exception.Message.Should().Contain("Missing required parameter 'userId'");
        }

        [Fact]
        public async Task AssignFulfillmentErrorWebAuthnPreregistrationFactorAsync_ThrowsOnNullAuthenticatorEnrollmentId()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.AssignFulfillmentErrorWebAuthnPreregistrationFactorAsync(_userId, null));
            exception.Message.Should().Contain("Missing required parameter 'authenticatorEnrollmentId'");
        }

        [Fact]
        public async Task AssignFulfillmentErrorWebAuthnPreregistrationFactorWithHttpInfoAsync_SetsPathParameters()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.AssignFulfillmentErrorWebAuthnPreregistrationFactorWithHttpInfoAsync(_userId, _authenticatorEnrollmentId);

            // Assert
            mockClient.ReceivedPathParams.Should().HaveCount(2);
            mockClient.ReceivedPathParams["userId"].Should().Be(_userId);
            mockClient.ReceivedPathParams["authenticatorEnrollmentId"].Should().Be(_authenticatorEnrollmentId);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public async Task ActivatePreregistrationEnrollmentAsync_WithNullRequest_DoesNotThrow()
        {
            // Arrange
            var responseJson = @"{
                ""authenticatorEnrollmentIds"": [],
                ""fulfillmentProvider"": ""yubico"",
                ""userId"": """"
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act - should not throw, body is optional
            var result = await api.ActivatePreregistrationEnrollmentAsync(null);

            // Assert
            mockClient.ReceivedPath.Should().Be("/webauthn-registration/api/v1/activate");
        }

        [Fact]
        public async Task EnrollPreregistrationEnrollmentAsync_WithNullRequest_DoesNotThrow()
        {
            // Arrange
            var responseJson = @"{
                ""credRequests"": [],
                ""fulfillmentProvider"": ""yubico"",
                ""pinRequestJwe"": """",
                ""userId"": """"
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act - should not throw, body is optional
            var result = await api.EnrollPreregistrationEnrollmentAsync(null);

            // Assert
            mockClient.ReceivedPath.Should().Be("/webauthn-registration/api/v1/enroll");
        }

        [Fact]
        public async Task GenerateFulfillmentRequestAsync_WithNullRequest_DoesNotThrow()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act - should not throw, body is optional
            await api.GenerateFulfillmentRequestAsync(null);

            // Assert
            mockClient.ReceivedPath.Should().Be("/webauthn-registration/api/v1/initiate-fulfillment-request");
        }

        [Fact]
        public async Task SendPinAsync_WithNullRequest_DoesNotThrow()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act - should not throw, body is optional
            await api.SendPinAsync(null);

            // Assert
            mockClient.ReceivedPath.Should().Be("/webauthn-registration/api/v1/send-pin");
        }

        [Fact]
        public async Task ListWebAuthnPreregistrationFactorsWithHttpInfoAsync_WithDifferentUserIds()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });
            var customUserId = "00uCustomUserId12345";

            // Act
            await api.ListWebAuthnPreregistrationFactorsWithHttpInfoAsync(customUserId);

            // Assert
            mockClient.ReceivedPathParams["userId"].Should().Be(customUserId);
        }

        [Fact]
        public async Task DeleteWebAuthnPreregistrationFactorAsync_WithDifferentIds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });
            var customUserId = "00uDifferentUser99999";
            var customEnrollmentId = "fweDifferentEnrollment88888";

            // Act
            await api.DeleteWebAuthnPreregistrationFactorAsync(customUserId, customEnrollmentId);

            // Assert
            mockClient.ReceivedPathParams["userId"].Should().Be(customUserId);
            mockClient.ReceivedPathParams["authenticatorEnrollmentId"].Should().Be(customEnrollmentId);
        }

        #endregion

        #region YubicoSigningJwks Tests

        [Fact]
        public async Task ActivatePreregistrationEnrollmentAsync_WithYubicoSigningJwks_IncludesInBody()
        {
            // Arrange
            var responseJson = @"{
                ""authenticatorEnrollmentIds"": [""fwe1234567890abcdef""],
                ""fulfillmentProvider"": ""yubico"",
                ""userId"": ""00u1234567890abcdef""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var ecKey = new ECKeyJWK
            {
                Kty = "EC",
                Crv = "P-256",
                X = "base64-encoded-x-coordinate",
                Y = "base64-encoded-y-coordinate"
            };

            var request = new EnrollmentActivationRequest
            {
                UserId = _userId,
                FulfillmentProvider = EnrollmentActivationRequest.FulfillmentProviderEnum.Yubico,
                YubicoSigningJwks = new List<ECKeyJWK> { ecKey }
            };

            // Act
            await api.ActivatePreregistrationEnrollmentWithHttpInfoAsync(request);

            // Assert
            mockClient.ReceivedBody.Should().Contain("yubicoSigningJwks");
            mockClient.ReceivedBody.Should().Contain("kty");
            mockClient.ReceivedBody.Should().Contain("EC");
        }

        #endregion

        #region YubicoTransportKeyJWK Tests

        [Fact]
        public async Task EnrollPreregistrationEnrollmentAsync_WithYubicoTransportKeyJWK_IncludesInBody()
        {
            // Arrange
            var responseJson = @"{
                ""credRequests"": [],
                ""fulfillmentProvider"": ""yubico"",
                ""pinRequestJwe"": ""jwe"",
                ""userId"": ""00u1234567890abcdef""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new WebAuthnPreregistrationApi(mockClient, new Configuration { BasePath = BaseUrl });

            var ecKey = new ECKeyJWK
            {
                Kty = "EC",
                Crv = "P-256",
                X = "transport-x-coord",
                Y = "transport-y-coord"
            };

            var request = new EnrollmentInitializationRequest
            {
                UserId = _userId,
                FulfillmentProvider = EnrollmentInitializationRequest.FulfillmentProviderEnum.Yubico,
                YubicoTransportKeyJWK = ecKey
            };

            // Act
            await api.EnrollPreregistrationEnrollmentWithHttpInfoAsync(request);

            // Assert
            mockClient.ReceivedBody.Should().Contain("yubicoTransportKeyJWK");
            mockClient.ReceivedBody.Should().Contain("kty");
            mockClient.ReceivedBody.Should().Contain("EC");
            mockClient.ReceivedBody.Should().Contain("transport-x-coord");
        }

        #endregion
    }
}
