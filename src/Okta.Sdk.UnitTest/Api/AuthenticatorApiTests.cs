// <copyright file="AuthenticatorApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

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
    public class AuthenticatorApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _authenticatorId = "aut1234567890abcdef";
        private readonly string _aaguid = "12345678-1234-1234-1234-123456789abc";

        #region ListAuthenticators Tests

        [Fact]
        public async Task ListAuthenticators_ReturnsAuthenticatorsList()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""aut1111111111111111"",
                    ""key"": ""okta_password"",
                    ""name"": ""Password"",
                    ""type"": ""password"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2025-01-01T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
                },
                {
                    ""id"": ""aut2222222222222222"",
                    ""key"": ""okta_email"",
                    ""name"": ""Email"",
                    ""type"": ""email"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2025-01-01T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.ListAuthenticatorsWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(2);
            response.Data[0].Key.Should().Be(AuthenticatorKeyEnum.OktaPassword);
            response.Data[1].Key.Should().Be(AuthenticatorKeyEnum.OktaEmail);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators");
        }

        [Fact]
        public async Task ListAuthenticatorsWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": """ + _authenticatorId + @""",
                    ""key"": ""phone_number"",
                    ""name"": ""Phone"",
                    ""type"": ""phone"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2025-01-01T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.ListAuthenticatorsWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(1);
            response.Data[0].Id.Should().Be(_authenticatorId);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators");
        }

        [Fact]
        public async Task ListAuthenticators_EmptyList_ReturnsEmptyArray()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.ListAuthenticatorsWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().BeEmpty();
        }

        #endregion

        #region GetAuthenticator Tests

        [Fact]
        public async Task GetAuthenticator_WithValidId_ReturnsAuthenticator()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""okta_email"",
                ""name"": ""Email"",
                ""type"": ""email"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var authenticator = await authenticatorApi.GetAuthenticatorAsync(_authenticatorId);

            // Assert
            authenticator.Should().NotBeNull();
            authenticator.Id.Should().Be(_authenticatorId);
            authenticator.Key.Should().Be(AuthenticatorKeyEnum.OktaEmail);
            authenticator.Name.Should().Be("Email");
            authenticator.Type.Should().Be(AuthenticatorType.Email);
            authenticator.Status.Should().Be(LifecycleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authenticatorId");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
        }

        [Fact]
        public async Task GetAuthenticatorWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""okta_password"",
                ""name"": ""Password"",
                ""type"": ""password"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.GetAuthenticatorWithHttpInfoAsync(_authenticatorId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_authenticatorId);
            response.Data.Key.Should().Be(AuthenticatorKeyEnum.OktaPassword);

            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
        }

        [Fact]
        public async Task GetAuthenticator_PhoneAuthenticator_ReturnsCorrectType()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""phone_number"",
                ""name"": ""Phone"",
                ""type"": ""phone"",
                ""status"": ""INACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var authenticator = await authenticatorApi.GetAuthenticatorAsync(_authenticatorId);

            // Assert
            authenticator.Should().NotBeNull();
            authenticator.Key.Should().Be(AuthenticatorKeyEnum.PhoneNumber);
            authenticator.Type.Should().Be(AuthenticatorType.Phone);
            authenticator.Status.Should().Be(LifecycleStatus.INACTIVE);
        }

        [Fact]
        public async Task GetAuthenticator_WebAuthnAuthenticator_ReturnsCorrectType()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""webauthn"",
                ""name"": ""Security Key or Biometric"",
                ""type"": ""security_key"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var authenticator = await authenticatorApi.GetAuthenticatorAsync(_authenticatorId);

            // Assert
            authenticator.Should().NotBeNull();
            authenticator.Key.Should().Be(AuthenticatorKeyEnum.Webauthn);
            authenticator.Type.Should().Be(AuthenticatorType.SecurityKey);
        }

        #endregion

        #region CreateAuthenticator Tests

        [Fact]
        public async Task CreateAuthenticator_WithValidData_ReturnsCreatedAuthenticator()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""duo"",
                ""name"": ""Duo Security"",
                ""type"": ""app"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new AuthenticatorKeyDuo
            {
                Key = AuthenticatorKeyEnum.Duo,
                Name = "Duo Security",
                Type = AuthenticatorType.App
            };

            // Act
            var authenticator = await authenticatorApi.CreateAuthenticatorAsync(request, activate: true);

            // Assert
            authenticator.Should().NotBeNull();
            authenticator.Id.Should().Be(_authenticatorId);
            authenticator.Key.Should().Be(AuthenticatorKeyEnum.Duo);
            authenticator.Name.Should().Be("Duo Security");

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators");
            mockClient.ReceivedQueryParams.Should().ContainKey("activate");
            mockClient.ReceivedQueryParams["activate"].Should().Contain("true");
        }

        [Fact]
        public async Task CreateAuthenticator_WithActivateFalse_SetsQueryParameter()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""duo"",
                ""name"": ""Duo Security"",
                ""type"": ""app"",
                ""status"": ""INACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new AuthenticatorBase
            {
                Key = AuthenticatorKeyEnum.Duo,
                Name = "Duo Security"
            };

            // Act
            var authenticator = await authenticatorApi.CreateAuthenticatorAsync(request, activate: false);

            // Assert
            authenticator.Should().NotBeNull();
            authenticator.Status.Should().Be(LifecycleStatus.INACTIVE);

            mockClient.ReceivedQueryParams.Should().ContainKey("activate");
            mockClient.ReceivedQueryParams["activate"].Should().Contain("false");
        }

        [Fact]
        public async Task CreateAuthenticatorWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""duo"",
                ""name"": ""Duo Security"",
                ""type"": ""app"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new AuthenticatorBase
            {
                Key = AuthenticatorKeyEnum.Duo,
                Name = "Duo Security"
            };

            // Act
            var response = await authenticatorApi.CreateAuthenticatorWithHttpInfoAsync(request);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_authenticatorId);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators");
        }

        #endregion

        #region ReplaceAuthenticator Tests

        [Fact]
        public async Task ReplaceAuthenticator_WithValidData_ReturnsUpdatedAuthenticator()
        {
            // Arrange
            var updatedName = "Updated Email Authenticator";

            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""okta_email"",
                ""name"": """ + updatedName + @""",
                ""type"": ""email"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-02T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new AuthenticatorKeyEmail
            {
                Key = AuthenticatorKeyEnum.OktaEmail,
                Name = updatedName,
                Type = AuthenticatorType.Email,
                Status = LifecycleStatus.ACTIVE
            };

            // Act
            var authenticator = await authenticatorApi.ReplaceAuthenticatorAsync(_authenticatorId, request);

            // Assert
            authenticator.Should().NotBeNull();
            authenticator.Id.Should().Be(_authenticatorId);
            authenticator.Name.Should().Be(updatedName);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
            mockClient.ReceivedBody.Should().Contain(updatedName);
        }

        [Fact]
        public async Task ReplaceAuthenticatorWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""okta_email"",
                ""name"": ""Email"",
                ""type"": ""email"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new AuthenticatorBase
            {
                Key = AuthenticatorKeyEnum.OktaEmail,
                Name = "Email"
            };

            // Act
            var response = await authenticatorApi.ReplaceAuthenticatorWithHttpInfoAsync(_authenticatorId, request);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_authenticatorId);

            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
        }

        #endregion

        #region ActivateAuthenticator Tests

        [Fact]
        public async Task ActivateAuthenticator_WithValidId_ReturnsActivatedAuthenticator()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""phone_number"",
                ""name"": ""Phone"",
                ""type"": ""phone"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-02T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var authenticator = await authenticatorApi.ActivateAuthenticatorAsync(_authenticatorId);

            // Assert
            authenticator.Should().NotBeNull();
            authenticator.Id.Should().Be(_authenticatorId);
            authenticator.Status.Should().Be(LifecycleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/lifecycle/activate");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
        }

        [Fact]
        public async Task ActivateAuthenticatorWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""phone_number"",
                ""name"": ""Phone"",
                ""type"": ""phone"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-02T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.ActivateAuthenticatorWithHttpInfoAsync(_authenticatorId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Status.Should().Be(LifecycleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/lifecycle/activate");
        }

        #endregion

        #region DeactivateAuthenticator Tests

        [Fact]
        public async Task DeactivateAuthenticator_WithValidId_ReturnsDeactivatedAuthenticator()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""phone_number"",
                ""name"": ""Phone"",
                ""type"": ""phone"",
                ""status"": ""INACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-02T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var authenticator = await authenticatorApi.DeactivateAuthenticatorAsync(_authenticatorId);

            // Assert
            authenticator.Should().NotBeNull();
            authenticator.Id.Should().Be(_authenticatorId);
            authenticator.Status.Should().Be(LifecycleStatus.INACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
        }

        [Fact]
        public async Task DeactivateAuthenticatorWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""phone_number"",
                ""name"": ""Phone"",
                ""type"": ""phone"",
                ""status"": ""INACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-02T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.DeactivateAuthenticatorWithHttpInfoAsync(_authenticatorId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Status.Should().Be(LifecycleStatus.INACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/lifecycle/deactivate");
        }

        #endregion

        #region ListAuthenticatorMethods Tests

        [Fact]
        public async Task ListAuthenticatorMethods_WithValidAuthenticatorId_ReturnsMethods()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""type"": ""sms"",
                    ""status"": ""ACTIVE""
                },
                {
                    ""type"": ""voice"",
                    ""status"": ""INACTIVE""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.ListAuthenticatorMethodsWithHttpInfoAsync(_authenticatorId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(2);
            response.Data[0].Type.Should().Be(AuthenticatorMethodType.Sms);
            response.Data[1].Type.Should().Be(AuthenticatorMethodType.Voice);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/methods");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
        }

        [Fact]
        public async Task ListAuthenticatorMethods_EmptyList_ReturnsEmptyArray()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.ListAuthenticatorMethodsWithHttpInfoAsync(_authenticatorId);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().BeEmpty();
        }

        #endregion

        #region GetAuthenticatorMethod Tests

        [Fact]
        public async Task GetAuthenticatorMethod_WithValidParameters_ReturnsMethod()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""sms"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var method = await authenticatorApi.GetAuthenticatorMethodAsync(_authenticatorId, AuthenticatorMethodType.Sms);

            // Assert
            method.Should().NotBeNull();
            method.Type.Should().Be(AuthenticatorMethodType.Sms);
            method.Status.Should().Be(LifecycleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/methods/{methodType}");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
            mockClient.ReceivedPathParams["methodType"].Should().Contain("sms");
        }

        [Fact]
        public async Task GetAuthenticatorMethodWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""voice"",
                ""status"": ""INACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.GetAuthenticatorMethodWithHttpInfoAsync(
                _authenticatorId, 
                AuthenticatorMethodType.Voice);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Type.Should().Be(AuthenticatorMethodType.Voice);
            response.Data.Status.Should().Be(LifecycleStatus.INACTIVE);
        }

        [Fact]
        public async Task GetAuthenticatorMethod_EmailMethod_ReturnsCorrectType()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""email"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var method = await authenticatorApi.GetAuthenticatorMethodAsync(_authenticatorId, AuthenticatorMethodType.Email);

            // Assert
            method.Type.Should().Be(AuthenticatorMethodType.Email);
            mockClient.ReceivedPathParams["methodType"].Should().Contain("email");
        }

        #endregion

        #region ReplaceAuthenticatorMethod Tests

        [Fact]
        public async Task ReplaceAuthenticatorMethod_WithValidData_ReturnsUpdatedMethod()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""sms"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var methodRequest = new AuthenticatorMethodBase
            {
                Type = AuthenticatorMethodType.Sms,
                Status = LifecycleStatus.ACTIVE
            };

            // Act
            var method = await authenticatorApi.ReplaceAuthenticatorMethodAsync(
                _authenticatorId, 
                AuthenticatorMethodType.Sms,
                methodRequest);

            // Assert
            method.Should().NotBeNull();
            method.Type.Should().Be(AuthenticatorMethodType.Sms);
            method.Status.Should().Be(LifecycleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/methods/{methodType}");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
            mockClient.ReceivedPathParams["methodType"].Should().Contain("sms");
        }

        [Fact]
        public async Task ReplaceAuthenticatorMethodWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""voice"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var methodRequest = new AuthenticatorMethodBase
            {
                Type = AuthenticatorMethodType.Voice,
                Status = LifecycleStatus.ACTIVE
            };

            // Act
            var response = await authenticatorApi.ReplaceAuthenticatorMethodWithHttpInfoAsync(
                _authenticatorId, 
                AuthenticatorMethodType.Voice,
                methodRequest);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Type.Should().Be(AuthenticatorMethodType.Voice);
        }

        #endregion

        #region ActivateAuthenticatorMethod Tests

        [Fact]
        public async Task ActivateAuthenticatorMethod_WithValidParameters_ReturnsActivatedMethod()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""sms"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var method = await authenticatorApi.ActivateAuthenticatorMethodAsync(
                _authenticatorId, 
                AuthenticatorMethodType.Sms);

            // Assert
            method.Should().NotBeNull();
            method.Type.Should().Be(AuthenticatorMethodType.Sms);
            method.Status.Should().Be(LifecycleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/methods/{methodType}/lifecycle/activate");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
            mockClient.ReceivedPathParams["methodType"].Should().Contain("sms");
        }

        [Fact]
        public async Task ActivateAuthenticatorMethodWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""voice"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.ActivateAuthenticatorMethodWithHttpInfoAsync(
                _authenticatorId, 
                AuthenticatorMethodType.Voice);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Status.Should().Be(LifecycleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/methods/{methodType}/lifecycle/activate");
        }

        #endregion

        #region DeactivateAuthenticatorMethod Tests

        [Fact]
        public async Task DeactivateAuthenticatorMethod_WithValidParameters_ReturnsDeactivatedMethod()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""sms"",
                ""status"": ""INACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var method = await authenticatorApi.DeactivateAuthenticatorMethodAsync(
                _authenticatorId, 
                AuthenticatorMethodType.Sms);

            // Assert
            method.Should().NotBeNull();
            method.Type.Should().Be(AuthenticatorMethodType.Sms);
            method.Status.Should().Be(LifecycleStatus.INACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/methods/{methodType}/lifecycle/deactivate");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
            mockClient.ReceivedPathParams["methodType"].Should().Contain("sms");
        }

        [Fact]
        public async Task DeactivateAuthenticatorMethodWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""voice"",
                ""status"": ""INACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.DeactivateAuthenticatorMethodWithHttpInfoAsync(
                _authenticatorId, 
                AuthenticatorMethodType.Voice);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Status.Should().Be(LifecycleStatus.INACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/methods/{methodType}/lifecycle/deactivate");
        }

        #endregion

        #region ListAllCustomAAGUIDs Tests

        [Fact]
        public async Task ListAllCustomAAGUIDs_WithValidAuthenticatorId_ReturnsAAGUIDs()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""aaguid"": ""12345678-1234-1234-1234-123456789abc"",
                    ""name"": ""Custom Security Key 1"",
                    ""authenticatorCharacteristics"": {
                        ""platformAttached"": false,
                        ""fipsCompliant"": true,
                        ""hardwareProtected"": true
                    }
                },
                {
                    ""aaguid"": ""87654321-4321-4321-4321-cba987654321"",
                    ""name"": ""Custom Security Key 2"",
                    ""authenticatorCharacteristics"": {
                        ""platformAttached"": true,
                        ""fipsCompliant"": false,
                        ""hardwareProtected"": false
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.ListAllCustomAAGUIDsWithHttpInfoAsync(_authenticatorId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(2);
            response.Data[0].Aaguid.Should().Be("12345678-1234-1234-1234-123456789abc");
            response.Data[0].Name.Should().Be("Custom Security Key 1");
            response.Data[1].Aaguid.Should().Be("87654321-4321-4321-4321-cba987654321");

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/aaguids");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
        }

        [Fact]
        public async Task ListAllCustomAAGUIDs_EmptyList_ReturnsEmptyArray()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.ListAllCustomAAGUIDsWithHttpInfoAsync(_authenticatorId);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().BeEmpty();
        }

        #endregion

        #region CreateCustomAAGUID Tests

        [Fact]
        public async Task CreateCustomAAGUID_WithValidData_ReturnsCreatedAAGUID()
        {
            // Arrange
            var responseJson = @"{
                ""aaguid"": """ + _aaguid + @""",
                ""name"": ""New Custom AAGUID"",
                ""authenticatorCharacteristics"": {
                    ""platformAttached"": false,
                    ""fipsCompliant"": true,
                    ""hardwareProtected"": true
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new CustomAAGUIDCreateRequestObject
            {
                Aaguid = _aaguid,
                AuthenticatorCharacteristics = new AAGUIDAuthenticatorCharacteristics
                {
                    PlatformAttached = false,
                    FipsCompliant = true,
                    HardwareProtected = true
                }
            };

            // Act
            var aaguid = await authenticatorApi.CreateCustomAAGUIDAsync(_authenticatorId, request);

            // Assert
            aaguid.Should().NotBeNull();
            aaguid.Aaguid.Should().Be(_aaguid);
            aaguid.AuthenticatorCharacteristics.FipsCompliant.Should().BeTrue();
            aaguid.AuthenticatorCharacteristics.HardwareProtected.Should().BeTrue();

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/aaguids");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
            mockClient.ReceivedBody.Should().Contain(_aaguid);
        }

        [Fact]
        public async Task CreateCustomAAGUIDWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""aaguid"": """ + _aaguid + @""",
                ""name"": ""Test AAGUID"",
                ""authenticatorCharacteristics"": {
                    ""platformAttached"": true,
                    ""fipsCompliant"": false,
                    ""hardwareProtected"": false
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new CustomAAGUIDCreateRequestObject
            {
                Aaguid = _aaguid,
                AuthenticatorCharacteristics = new AAGUIDAuthenticatorCharacteristics
                {
                    PlatformAttached = true,
                    FipsCompliant = false,
                    HardwareProtected = false
                }
            };

            // Act
            var response = await authenticatorApi.CreateCustomAAGUIDWithHttpInfoAsync(_authenticatorId, request);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Aaguid.Should().Be(_aaguid);
        }

        #endregion

        #region GetCustomAAGUID Tests

        [Fact]
        public async Task GetCustomAAGUID_WithValidParameters_ReturnsAAGUID()
        {
            // Arrange
            var responseJson = @"{
                ""aaguid"": """ + _aaguid + @""",
                ""name"": ""My Security Key"",
                ""authenticatorCharacteristics"": {
                    ""platformAttached"": false,
                    ""fipsCompliant"": true,
                    ""hardwareProtected"": true
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var aaguid = await authenticatorApi.GetCustomAAGUIDAsync(_authenticatorId, _aaguid);

            // Assert
            aaguid.Should().NotBeNull();
            aaguid.Aaguid.Should().Be(_aaguid);
            aaguid.Name.Should().Be("My Security Key");
            aaguid.AuthenticatorCharacteristics.FipsCompliant.Should().BeTrue();

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/aaguids/{aaguid}");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
            mockClient.ReceivedPathParams["aaguid"].Should().Contain(_aaguid);
        }

        [Fact]
        public async Task GetCustomAAGUIDWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""aaguid"": """ + _aaguid + @""",
                ""name"": ""Retrieved AAGUID"",
                ""authenticatorCharacteristics"": {
                    ""platformAttached"": true,
                    ""fipsCompliant"": false,
                    ""hardwareProtected"": true
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.GetCustomAAGUIDWithHttpInfoAsync(_authenticatorId, _aaguid);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Aaguid.Should().Be(_aaguid);
            response.Data.Name.Should().Be("Retrieved AAGUID");
        }

        #endregion

        #region UpdateCustomAAGUID Tests

        [Fact]
        public async Task UpdateCustomAAGUID_WithValidData_ReturnsUpdatedAAGUID()
        {
            // Arrange
            var updatedName = "Updated Security Key Name";

            var responseJson = @"{
                ""aaguid"": """ + _aaguid + @""",
                ""name"": """ + updatedName + @""",
                ""authenticatorCharacteristics"": {
                    ""platformAttached"": false,
                    ""fipsCompliant"": true,
                    ""hardwareProtected"": true
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new CustomAAGUIDUpdateRequestObject
            {
                Name = updatedName,
                AuthenticatorCharacteristics = new AAGUIDAuthenticatorCharacteristics
                {
                    PlatformAttached = false,
                    FipsCompliant = true,
                    HardwareProtected = true
                }
            };

            // Act
            var aaguid = await authenticatorApi.UpdateCustomAAGUIDAsync(_authenticatorId, _aaguid, request);

            // Assert
            aaguid.Should().NotBeNull();
            aaguid.Aaguid.Should().Be(_aaguid);
            aaguid.Name.Should().Be(updatedName);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/aaguids/{aaguid}");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
            mockClient.ReceivedPathParams["aaguid"].Should().Contain(_aaguid);
            mockClient.ReceivedBody.Should().Contain(updatedName);
        }

        [Fact]
        public async Task UpdateCustomAAGUIDWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""aaguid"": """ + _aaguid + @""",
                ""name"": ""Patched AAGUID"",
                ""authenticatorCharacteristics"": {
                    ""platformAttached"": true,
                    ""fipsCompliant"": true,
                    ""hardwareProtected"": false
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new CustomAAGUIDUpdateRequestObject
            {
                Name = "Patched AAGUID"
            };

            // Act
            var response = await authenticatorApi.UpdateCustomAAGUIDWithHttpInfoAsync(_authenticatorId, _aaguid, request);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Name.Should().Be("Patched AAGUID");
        }

        #endregion

        #region ReplaceCustomAAGUID Tests

        [Fact]
        public async Task ReplaceCustomAAGUID_WithValidData_ReturnsReplacedAAGUID()
        {
            // Arrange
            var newName = "Replaced Security Key";

            var responseJson = @"{
                ""aaguid"": """ + _aaguid + @""",
                ""name"": """ + newName + @""",
                ""authenticatorCharacteristics"": {
                    ""platformAttached"": true,
                    ""fipsCompliant"": false,
                    ""hardwareProtected"": true
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new CustomAAGUIDUpdateRequestObject
            {
                Name = newName,
                AuthenticatorCharacteristics = new AAGUIDAuthenticatorCharacteristics
                {
                    PlatformAttached = true,
                    FipsCompliant = false,
                    HardwareProtected = true
                }
            };

            // Act
            var aaguid = await authenticatorApi.ReplaceCustomAAGUIDAsync(_authenticatorId, _aaguid, request);

            // Assert
            aaguid.Should().NotBeNull();
            aaguid.Aaguid.Should().Be(_aaguid);
            aaguid.Name.Should().Be(newName);
            aaguid.AuthenticatorCharacteristics.PlatformAttached.Should().BeTrue();
            aaguid.AuthenticatorCharacteristics.HardwareProtected.Should().BeTrue();

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/aaguids/{aaguid}");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
            mockClient.ReceivedPathParams["aaguid"].Should().Contain(_aaguid);
        }

        [Fact]
        public async Task ReplaceCustomAAGUIDWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""aaguid"": """ + _aaguid + @""",
                ""name"": ""Full Replace AAGUID"",
                ""authenticatorCharacteristics"": {
                    ""platformAttached"": false,
                    ""fipsCompliant"": false,
                    ""hardwareProtected"": false
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new CustomAAGUIDUpdateRequestObject
            {
                Name = "Full Replace AAGUID",
                AuthenticatorCharacteristics = new AAGUIDAuthenticatorCharacteristics
                {
                    PlatformAttached = false,
                    FipsCompliant = false,
                    HardwareProtected = false
                }
            };

            // Act
            var response = await authenticatorApi.ReplaceCustomAAGUIDWithHttpInfoAsync(_authenticatorId, _aaguid, request);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Name.Should().Be("Full Replace AAGUID");
        }

        #endregion

        #region DeleteCustomAAGUID Tests

        [Fact]
        public async Task DeleteCustomAAGUID_WithValidParameters_CallsDeleteEndpoint()
        {
            // Arrange
            var responseJson = @"{}";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await authenticatorApi.DeleteCustomAAGUIDAsync(_authenticatorId, _aaguid);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/aaguids/{aaguid}");
            mockClient.ReceivedPathParams["authenticatorId"].Should().Contain(_authenticatorId);
            mockClient.ReceivedPathParams["aaguid"].Should().Contain(_aaguid);
        }

        [Fact]
        public async Task DeleteCustomAAGUIDWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{}";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.DeleteCustomAAGUIDWithHttpInfoAsync(_authenticatorId, _aaguid);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            mockClient.ReceivedPath.Should().Be("/api/v1/authenticators/{authenticatorId}/aaguids/{aaguid}");
        }

        #endregion

        #region GetWellKnownAppAuthenticatorConfiguration Tests

        [Fact]
        public async Task GetWellKnownAppAuthenticatorConfiguration_WithValidClientId_ReturnsConfiguration()
        {
            // Arrange
            var oauthClientId = "0oa1234567890abcdef";

            var responseJson = @"[
                {
                    ""id"": ""app123"",
                    ""name"": ""My Custom App Authenticator"",
                    ""supportedMethods"": [
                        {
                            ""type"": ""push""
                        },
                        {
                            ""type"": ""totp""
                        }
                    ]
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.GetWellKnownAppAuthenticatorConfigurationWithHttpInfoAsync(oauthClientId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(1);

            mockClient.ReceivedPath.Should().Be("/.well-known/app-authenticator-configuration");
            mockClient.ReceivedQueryParams.Should().ContainKey("oauthClientId");
            mockClient.ReceivedQueryParams["oauthClientId"].Should().Contain(oauthClientId);
        }

        [Fact]
        public async Task GetWellKnownAppAuthenticatorConfiguration_EmptyResult_ReturnsEmptyList()
        {
            // Arrange
            var oauthClientId = "0oa1234567890abcdef";
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.GetWellKnownAppAuthenticatorConfigurationWithHttpInfoAsync(oauthClientId);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().BeEmpty();
        }

        #endregion

        #region Authenticator Types Tests

        [Fact]
        public async Task GetAuthenticator_DuoAuthenticator_ReturnsCorrectType()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""duo"",
                ""name"": ""Duo Security"",
                ""type"": ""app"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var authenticator = await authenticatorApi.GetAuthenticatorAsync(_authenticatorId);

            // Assert
            authenticator.Should().NotBeNull();
            authenticator.Key.Should().Be(AuthenticatorKeyEnum.Duo);
            authenticator.Type.Should().Be(AuthenticatorType.App);
        }

        [Fact]
        public async Task GetAuthenticator_OktaVerifyAuthenticator_ReturnsCorrectType()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""okta_verify"",
                ""name"": ""Okta Verify"",
                ""type"": ""app"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var authenticator = await authenticatorApi.GetAuthenticatorAsync(_authenticatorId);

            // Assert
            authenticator.Should().NotBeNull();
            authenticator.Key.Should().Be(AuthenticatorKeyEnum.OktaVerify);
            authenticator.Type.Should().Be(AuthenticatorType.App);
        }

        [Fact]
        public async Task GetAuthenticator_GoogleOtpAuthenticator_ReturnsCorrectType()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""google_otp"",
                ""name"": ""Google Authenticator"",
                ""type"": ""app"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var authenticator = await authenticatorApi.GetAuthenticatorAsync(_authenticatorId);

            // Assert
            authenticator.Should().NotBeNull();
            authenticator.Key.Should().Be(AuthenticatorKeyEnum.GoogleOtp);
            authenticator.Type.Should().Be(AuthenticatorType.App);
        }

        [Fact]
        public async Task GetAuthenticator_SecurityQuestionAuthenticator_ReturnsCorrectType()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _authenticatorId + @""",
                ""key"": ""security_question"",
                ""name"": ""Security Question"",
                ""type"": ""security_question"",
                ""status"": ""ACTIVE"",
                ""created"": ""2025-01-01T12:00:00.000Z"",
                ""lastUpdated"": ""2025-01-01T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var authenticator = await authenticatorApi.GetAuthenticatorAsync(_authenticatorId);

            // Assert
            authenticator.Should().NotBeNull();
            authenticator.Key.Should().Be(AuthenticatorKeyEnum.SecurityQuestion);
            authenticator.Type.Should().Be(AuthenticatorType.SecurityQuestion);
        }

        #endregion

        #region Authenticator Method Types Tests

        [Fact]
        public async Task GetAuthenticatorMethod_PushMethod_ReturnsCorrectType()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""push"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var method = await authenticatorApi.GetAuthenticatorMethodAsync(_authenticatorId, AuthenticatorMethodType.Push);

            // Assert
            method.Type.Should().Be(AuthenticatorMethodType.Push);
            mockClient.ReceivedPathParams["methodType"].Should().Contain("push");
        }

        [Fact]
        public async Task GetAuthenticatorMethod_TotpMethod_ReturnsCorrectType()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""totp"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var method = await authenticatorApi.GetAuthenticatorMethodAsync(_authenticatorId, AuthenticatorMethodType.Totp);

            // Assert
            method.Type.Should().Be(AuthenticatorMethodType.Totp);
            mockClient.ReceivedPathParams["methodType"].Should().Contain("totp");
        }

        [Fact]
        public async Task GetAuthenticatorMethod_PasswordMethod_ReturnsCorrectType()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""password"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var method = await authenticatorApi.GetAuthenticatorMethodAsync(_authenticatorId, AuthenticatorMethodType.Password);

            // Assert
            method.Type.Should().Be(AuthenticatorMethodType.Password);
            mockClient.ReceivedPathParams["methodType"].Should().Contain("password");
        }

        [Fact]
        public async Task GetAuthenticatorMethod_SignedNonceMethod_ReturnsCorrectType()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""signed_nonce"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var method = await authenticatorApi.GetAuthenticatorMethodAsync(_authenticatorId, AuthenticatorMethodType.SignedNonce);

            // Assert
            method.Type.Should().Be(AuthenticatorMethodType.SignedNonce);
            mockClient.ReceivedPathParams["methodType"].Should().Contain("signed_nonce");
        }

        [Fact]
        public async Task GetAuthenticatorMethod_WebauthnMethod_ReturnsCorrectType()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""webauthn"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var method = await authenticatorApi.GetAuthenticatorMethodAsync(_authenticatorId, AuthenticatorMethodType.Webauthn);

            // Assert
            method.Type.Should().Be(AuthenticatorMethodType.Webauthn);
            mockClient.ReceivedPathParams["methodType"].Should().Contain("webauthn");
        }

        #endregion

        #region AAGUID Characteristics Tests

        [Fact]
        public async Task GetCustomAAGUID_WithAllCharacteristics_ParsesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""aaguid"": """ + _aaguid + @""",
                ""name"": ""FIPS Compliant Security Key"",
                ""authenticatorCharacteristics"": {
                    ""platformAttached"": true,
                    ""fipsCompliant"": true,
                    ""hardwareProtected"": true
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var aaguid = await authenticatorApi.GetCustomAAGUIDAsync(_authenticatorId, _aaguid);

            // Assert
            aaguid.AuthenticatorCharacteristics.Should().NotBeNull();
            aaguid.AuthenticatorCharacteristics.PlatformAttached.Should().BeTrue();
            aaguid.AuthenticatorCharacteristics.FipsCompliant.Should().BeTrue();
            aaguid.AuthenticatorCharacteristics.HardwareProtected.Should().BeTrue();
        }

        [Fact]
        public async Task GetCustomAAGUID_WithNoCharacteristics_HandlesNullCharacteristics()
        {
            // Arrange
            var responseJson = @"{
                ""aaguid"": """ + _aaguid + @""",
                ""name"": ""Basic Security Key""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var aaguid = await authenticatorApi.GetCustomAAGUIDAsync(_authenticatorId, _aaguid);

            // Assert
            aaguid.Should().NotBeNull();
            aaguid.Aaguid.Should().Be(_aaguid);
            aaguid.Name.Should().Be("Basic Security Key");
        }

        #endregion

        #region Edge Cases Tests

        [Fact]
        public async Task ListAuthenticators_WithMultipleTypes_ReturnsAllTypes()
        {
            // Arrange
            var responseJson = @"[
                {""id"": ""aut1"", ""key"": ""okta_password"", ""name"": ""Password"", ""type"": ""password"", ""status"": ""ACTIVE"", ""created"": ""2025-01-01T12:00:00.000Z"", ""lastUpdated"": ""2025-01-01T12:00:00.000Z""},
                {""id"": ""aut2"", ""key"": ""okta_email"", ""name"": ""Email"", ""type"": ""email"", ""status"": ""ACTIVE"", ""created"": ""2025-01-01T12:00:00.000Z"", ""lastUpdated"": ""2025-01-01T12:00:00.000Z""},
                {""id"": ""aut3"", ""key"": ""phone_number"", ""name"": ""Phone"", ""type"": ""phone"", ""status"": ""INACTIVE"", ""created"": ""2025-01-01T12:00:00.000Z"", ""lastUpdated"": ""2025-01-01T12:00:00.000Z""},
                {""id"": ""aut4"", ""key"": ""webauthn"", ""name"": ""Security Key"", ""type"": ""security_key"", ""status"": ""ACTIVE"", ""created"": ""2025-01-01T12:00:00.000Z"", ""lastUpdated"": ""2025-01-01T12:00:00.000Z""},
                {""id"": ""aut5"", ""key"": ""okta_verify"", ""name"": ""Okta Verify"", ""type"": ""app"", ""status"": ""ACTIVE"", ""created"": ""2025-01-01T12:00:00.000Z"", ""lastUpdated"": ""2025-01-01T12:00:00.000Z""},
                {""id"": ""aut6"", ""key"": ""security_question"", ""name"": ""Security Question"", ""type"": ""security_question"", ""status"": ""ACTIVE"", ""created"": ""2025-01-01T12:00:00.000Z"", ""lastUpdated"": ""2025-01-01T12:00:00.000Z""}
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.ListAuthenticatorsWithHttpInfoAsync();

            // Assert
            response.Data.Should().HaveCount(6);
            response.Data.Should().Contain(a => a.Key == AuthenticatorKeyEnum.OktaPassword);
            response.Data.Should().Contain(a => a.Key == AuthenticatorKeyEnum.OktaEmail);
            response.Data.Should().Contain(a => a.Key == AuthenticatorKeyEnum.PhoneNumber);
            response.Data.Should().Contain(a => a.Key == AuthenticatorKeyEnum.Webauthn);
            response.Data.Should().Contain(a => a.Key == AuthenticatorKeyEnum.OktaVerify);
            response.Data.Should().Contain(a => a.Key == AuthenticatorKeyEnum.SecurityQuestion);
        }

        [Fact]
        public async Task ListAuthenticatorMethods_WithMultipleTypes_ReturnsAllMethods()
        {
            // Arrange
            var responseJson = @"[
                {""type"": ""sms"", ""status"": ""ACTIVE""},
                {""type"": ""voice"", ""status"": ""ACTIVE""},
                {""type"": ""email"", ""status"": ""INACTIVE""},
                {""type"": ""push"", ""status"": ""ACTIVE""},
                {""type"": ""totp"", ""status"": ""ACTIVE""}
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var authenticatorApi = new AuthenticatorApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await authenticatorApi.ListAuthenticatorMethodsWithHttpInfoAsync(_authenticatorId);

            // Assert
            response.Data.Should().HaveCount(5);
            response.Data.Should().Contain(m => m.Type == AuthenticatorMethodType.Sms);
            response.Data.Should().Contain(m => m.Type == AuthenticatorMethodType.Voice);
            response.Data.Should().Contain(m => m.Type == AuthenticatorMethodType.Email);
            response.Data.Should().Contain(m => m.Type == AuthenticatorMethodType.Push);
            response.Data.Should().Contain(m => m.Type == AuthenticatorMethodType.Totp);
        }

        #endregion
    }
}
