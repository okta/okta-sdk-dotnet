// <copyright file="OAuthApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    public class OAuthApiTests
    {
        private Mock<IAsynchronousClient> CreateMockAsyncClient()
        {
            return new Mock<IAsynchronousClient>();
        }

        private Mock<IClientAssertionJwtGenerator> CreateMockClientAssertionGenerator()
        {
            var mock = new Mock<IClientAssertionJwtGenerator>();
            mock.Setup(x => x.GenerateJwt()).Returns("mock-client-assertion-jwt");
            return mock;
        }

        private Mock<IDpopProofJwtGenerator> CreateMockDpopGenerator()
        {
            var mock = new Mock<IDpopProofJwtGenerator>();
            mock.Setup(x => x.GenerateJwt(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns("mock-dpop-jwt");
            return mock;
        }

        private Configuration CreateTestConfiguration()
        {
            return new Configuration
            {
                OktaDomain = "https://test.okta.com",
                ClientId = "test-client-id",
                Scopes = ["okta.users.read", "okta.apps.read"],
                AuthorizationMode = AuthorizationMode.PrivateKey
            };
        }

        [Fact]
        public void ThrowArgumentNullExceptionWhenAsyncClientIsNull()
        {
            // Arrange
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            // Act
            Action act = () => new OAuthApi(null, config, clientAssertionGen.Object, dpopGen.Object);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("asyncClient");
        }

        [Fact]
        public void ThrowArgumentNullExceptionWhenConfigurationIsNull()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            // Act
            Action act = () => new OAuthApi(asyncClient.Object, null, clientAssertionGen.Object, dpopGen.Object);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("configuration");
        }

        [Fact]
        public void InitializeWithValidParameters()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            // Act
            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Assert
            api.Should().NotBeNull();
            api.Configuration.Should().Be(config);
            api.AsynchronousClient.Should().Be(asyncClient.Object);
        }

        [Fact]
        public void GetBasePathReturnsOktaDomain()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();
            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            var basePath = api.GetBasePath();

            // Assert
            basePath.Should().Be("https://test.okta.com");
        }

        [Fact]
        public async Task GetBearerTokenAsyncCallsRotateKeysOnDpopGenerator()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var tokenResponse = new OAuthTokenResponse
            {
                AccessToken = "test-access-token",
                TokenType = "Bearer"
            };

            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<OAuthTokenResponse>(HttpStatusCode.OK, null, tokenResponse));

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            await api.GetBearerTokenAsync();

            // Assert
            dpopGen.Verify(x => x.RotateKeys(), Times.Once);
        }

        [Fact]
        public async Task GetBearerTokenAsyncGeneratesClientAssertionJwt()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var tokenResponse = new OAuthTokenResponse
            {
                AccessToken = "test-access-token",
                TokenType = "Bearer"
            };

            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<OAuthTokenResponse>(HttpStatusCode.OK, null, tokenResponse));

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            await api.GetBearerTokenAsync();

            // Assert
            clientAssertionGen.Verify(x => x.GenerateJwt(), Times.Once);
        }

        [Fact]
        public async Task GetBearerTokenAsyncGeneratesDpopProofJwt()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var tokenResponse = new OAuthTokenResponse
            {
                AccessToken = "test-access-token",
                TokenType = "Bearer"
            };

            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<OAuthTokenResponse>(HttpStatusCode.OK, null, tokenResponse));

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            await api.GetBearerTokenAsync();

            // Assert
            dpopGen.Verify(x => x.GenerateJwt(null, null, null, null), Times.Once);
        }

        [Fact]
        public async Task GetBearerTokenAsyncSendsCorrectFormParameters()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var tokenResponse = new OAuthTokenResponse
            {
                AccessToken = "test-access-token",
                TokenType = "Bearer"
            };

            RequestOptions capturedOptions = null;
            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, RequestOptions, IReadableConfiguration, CancellationToken>((_, opts, _, _) =>
                {
                    capturedOptions = opts;
                })
                .ReturnsAsync(new ApiResponse<OAuthTokenResponse>(HttpStatusCode.OK, null, tokenResponse));

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            await api.GetBearerTokenAsync();

            // Assert
            capturedOptions.Should().NotBeNull();
            capturedOptions.FormParameters.Should().ContainKey("grant_type");
            capturedOptions.FormParameters["grant_type"].Should().Be("client_credentials");
            capturedOptions.FormParameters.Should().ContainKey("scope");
            capturedOptions.FormParameters["scope"].Should().Be("okta.users.read okta.apps.read");
            capturedOptions.FormParameters.Should().ContainKey("client_assertion_type");
            capturedOptions.FormParameters["client_assertion_type"].Should().Be("urn:ietf:params:oauth:client-assertion-type:jwt-bearer");
            capturedOptions.FormParameters.Should().ContainKey("client_assertion");
            capturedOptions.FormParameters["client_assertion"].Should().Be("mock-client-assertion-jwt");
        }

        [Fact]
        public async Task GetBearerTokenAsyncSendsDpopHeader()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var tokenResponse = new OAuthTokenResponse
            {
                AccessToken = "test-access-token",
                TokenType = "Bearer"
            };

            RequestOptions capturedOptions = null;
            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, RequestOptions, IReadableConfiguration, CancellationToken>((_, opts, _, _) =>
                {
                    capturedOptions = opts;
                })
                .ReturnsAsync(new ApiResponse<OAuthTokenResponse>(HttpStatusCode.OK, null, tokenResponse));

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            await api.GetBearerTokenAsync();

            // Assert
            capturedOptions.Should().NotBeNull();
            capturedOptions.HeaderParameters.Should().ContainKey("DPoP");
            capturedOptions.HeaderParameters["DPoP"].Should().Contain("mock-dpop-jwt");
        }

        [Fact]
        public async Task GetBearerTokenAsyncPostsToCorrectEndpoint()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var tokenResponse = new OAuthTokenResponse
            {
                AccessToken = "test-access-token",
                TokenType = "Bearer"
            };

            string capturedUri = null;
            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, RequestOptions, IReadableConfiguration, CancellationToken>((uri, _, _, _) =>
                {
                    capturedUri = uri;
                })
                .ReturnsAsync(new ApiResponse<OAuthTokenResponse>(HttpStatusCode.OK, null, tokenResponse));

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            await api.GetBearerTokenAsync();

            // Assert
            capturedUri.Should().Be("/oauth2/v1/token");
        }

        [Fact]
        public async Task GetBearerTokenAsyncReturnsTokenResponse()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var expectedTokenResponse = new OAuthTokenResponse
            {
                AccessToken = "test-access-token",
                TokenType = "Bearer",
                ExpiresIn = 3600
            };

            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<OAuthTokenResponse>(HttpStatusCode.OK, null, expectedTokenResponse));

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            var result = await api.GetBearerTokenAsync();

            // Assert
            result.Should().NotBeNull();
            result.AccessToken.Should().Be("test-access-token");
            result.TokenType.Should().Be("Bearer");
            result.ExpiresIn.Should().Be(3600);
        }

        [Fact]
        public async Task GetBearerTokenAsyncHandlesUseDpopNonceError()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var errorResponse = new OAuthTokenResponse
            {
                Error = "use_dpop_nonce",
                ErrorDescription = "Authorization server requires nonce in DPoP proof."
            };

            var successResponse = new OAuthTokenResponse
            {
                AccessToken = "test-access-token",
                TokenType = "DPoP"
            };

            var headers = new Multimap<string, string>
            {
                { "dpop-nonce", new List<string> { "test-nonce-value" } }
            };

            var callCount = 0;
            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return new ApiResponse<OAuthTokenResponse>(HttpStatusCode.BadRequest, headers, errorResponse);
                    }
                    return new ApiResponse<OAuthTokenResponse>(HttpStatusCode.OK, null, successResponse);
                });

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            var result = await api.GetBearerTokenAsync();

            // Assert
            result.Should().NotBeNull();
            result.AccessToken.Should().Be("test-access-token");
            result.TokenType.Should().Be("DPoP");

            // Verify retry behavior
            asyncClient.Verify(x => x.PostAsync<OAuthTokenResponse>(
                It.IsAny<string>(),
                It.IsAny<RequestOptions>(),
                It.IsAny<IReadableConfiguration>(),
                It.IsAny<CancellationToken>()), Times.Exactly(2));

            // Verify nonce was used in retry
            dpopGen.Verify(x => x.GenerateJwt("test-nonce-value", null, null, null), Times.Once);
        }

        [Fact]
        public async Task GetBearerTokenAsyncRegeneratesClientAssertionOnNonceRetry()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var errorResponse = new OAuthTokenResponse
            {
                Error = "use_dpop_nonce",
                ErrorDescription = "Authorization server requires nonce in DPoP proof."
            };

            var successResponse = new OAuthTokenResponse
            {
                AccessToken = "test-access-token",
                TokenType = "DPoP"
            };

            var headers = new Multimap<string, string>
            {
                { "dpop-nonce", new List<string> { "test-nonce-value" } }
            };

            var callCount = 0;
            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return new ApiResponse<OAuthTokenResponse>(HttpStatusCode.BadRequest, headers, errorResponse);
                    }
                    return new ApiResponse<OAuthTokenResponse>(HttpStatusCode.OK, null, successResponse);
                });

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            await api.GetBearerTokenAsync();

            // Assert
            // Verify client assertion is generated twice (once for the first attempt, once for retry)
            clientAssertionGen.Verify(x => x.GenerateJwt(), Times.Exactly(2));
        }

        [Fact]
        public async Task GetBearerTokenAsyncDoesNotRetryWhenNonceHeaderIsMissing()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var errorResponse = new OAuthTokenResponse
            {
                Error = "use_dpop_nonce",
                ErrorDescription = "Authorization server requires nonce in DPoP proof."
            };

            // No dpop-nonce header - empty Multimap
            var headers = new Multimap<string, string>();

            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<OAuthTokenResponse>(HttpStatusCode.BadRequest, headers, errorResponse));

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object)
                {
                    // Set exception factory to null to avoid throwing
                    ExceptionFactory = (_, _) => null
                };

            // Act
            var result = await api.GetBearerTokenAsync();

            // Assert
            result.Error.Should().Be("use_dpop_nonce");

            // Verify no retry
            asyncClient.Verify(x => x.PostAsync<OAuthTokenResponse>(
                It.IsAny<string>(),
                It.IsAny<RequestOptions>(),
                It.IsAny<IReadableConfiguration>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetBearerTokenAsyncDoesNotRetryForNonDpopErrors()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var errorResponse = new OAuthTokenResponse
            {
                Error = "invalid_client",
                ErrorDescription = "Invalid client credentials."
            };

            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<OAuthTokenResponse>(HttpStatusCode.BadRequest, null, errorResponse));

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Set exception factory to null to avoid throwing
            api.ExceptionFactory = (name, response) => null;

            // Act
            var result = await api.GetBearerTokenAsync();

            // Assert
            result.Error.Should().Be("invalid_client");

            // Verify no retry
            asyncClient.Verify(x => x.PostAsync<OAuthTokenResponse>(
                It.IsAny<string>(),
                It.IsAny<RequestOptions>(),
                It.IsAny<IReadableConfiguration>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetBearerTokenAsyncSetsContentTypeHeader()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var tokenResponse = new OAuthTokenResponse
            {
                AccessToken = "test-access-token",
                TokenType = "Bearer"
            };

            RequestOptions capturedOptions = null;
            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, RequestOptions, IReadableConfiguration, CancellationToken>((_, opts, _, _) =>
                {
                    capturedOptions = opts;
                })
                .ReturnsAsync(new ApiResponse<OAuthTokenResponse>(HttpStatusCode.OK, null, tokenResponse));

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            await api.GetBearerTokenAsync();

            // Assert
            capturedOptions.Should().NotBeNull();
            capturedOptions.HeaderParameters.Should().ContainKey("Content-Type");
            capturedOptions.HeaderParameters["Content-Type"].Should().Contain("application/x-www-form-urlencoded");
        }

        [Fact]
        public async Task GetBearerTokenAsyncSetsAcceptHeader()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var tokenResponse = new OAuthTokenResponse
            {
                AccessToken = "test-access-token",
                TokenType = "Bearer"
            };

            RequestOptions capturedOptions = null;
            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, RequestOptions, IReadableConfiguration, CancellationToken>((_, opts, _, _) =>
                {
                    capturedOptions = opts;
                })
                .ReturnsAsync(new ApiResponse<OAuthTokenResponse>(HttpStatusCode.OK, null, tokenResponse));

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            await api.GetBearerTokenAsync();

            // Assert
            capturedOptions.Should().NotBeNull();
            capturedOptions.HeaderParameters.Should().ContainKey("Accept");
            capturedOptions.HeaderParameters["Accept"].Should().Contain("application/json");
        }

        [Fact]
        public async Task GetBearerTokenWithHttpInfoAsyncReturnsApiResponse()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var tokenResponse = new OAuthTokenResponse
            {
                AccessToken = "test-access-token",
                TokenType = "Bearer"
            };

            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<OAuthTokenResponse>(HttpStatusCode.OK, null, tokenResponse));

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act
            var result = await api.GetBearerTokenWithHttpInfoAsync();

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.AccessToken.Should().Be("test-access-token");
        }

        [Fact]
        public async Task GetBearerTokenAsyncRespectsCancellationToken()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();

            var cts = new CancellationTokenSource();
            await cts.CancelAsync();

            asyncClient.Setup(x => x.PostAsync<OAuthTokenResponse>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new TaskCanceledException());

            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            // Act & Assert
            await Assert.ThrowsAsync<TaskCanceledException>(() => api.GetBearerTokenAsync(cts.Token));
        }

        [Fact]
        public void ExceptionFactoryCanBeSet()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();
            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            ExceptionFactory customFactory = (_, _) => new Exception("Custom exception");

            // Act
            api.ExceptionFactory = customFactory;

            // Assert
            api.ExceptionFactory.Should().NotBeNull();
            api.ExceptionFactory.Should().Be(customFactory);
        }

        [Fact]
        public void ExceptionFactoryThrowsWhenSettingMulticastDelegate()
        {
            // Arrange
            var asyncClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            var clientAssertionGen = CreateMockClientAssertionGenerator();
            var dpopGen = CreateMockDpopGenerator();
            var api = new OAuthApi(asyncClient.Object, config, clientAssertionGen.Object, dpopGen.Object);

            Exception Factory1(string s, IApiResponse apiResponse) => new Exception("Exception 1");
            Exception Factory2(string s, IApiResponse apiResponse) => new Exception("Exception 2");
            api.ExceptionFactory = Factory1;
            api.ExceptionFactory += Factory2;

            // Act & Assert
            Action act = () => { var _ = api.ExceptionFactory; };
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Multicast delegate for ExceptionFactory is unsupported.");
        }
    }
}
