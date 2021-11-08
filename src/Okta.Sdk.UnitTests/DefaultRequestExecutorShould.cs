// <copyright file="DefaultRequestExecutorShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class DefaultRequestExecutorShould
    {
        [Fact]
        public async Task RetryRequestOnceWhenResponseIs401AndAuthorizationModeIsPrivateKeyAsync()
        {
            var requestMessageHandler = new MockHttpMessageHandler(string.Empty, HttpStatusCode.Unauthorized);
            var httpClientRequest = new HttpClient(requestMessageHandler);

            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = TestCryptoKeys.GetMockRSAPrivateKeyConfiguration();
            configuration.Scopes = new List<string> { "foo" };

            var oktaClient = new OktaClient(configuration);
            var logger = Substitute.For<ILogger>();

            var resourceFactory = new ResourceFactory(oktaClient, logger);

            var tokenResponse = @"{""token_type"":""Bearer"",""expires_in"":3600,""access_token"":""foo"",""scope"":""okta.users.read okta.users.manage""}";
            var tokenMessageHandler = new MockHttpMessageHandler(tokenResponse, HttpStatusCode.OK);
            var httpClientToken = new HttpClient(tokenMessageHandler);
            var tokenProvider = new DefaultOAuthTokenProvider(configuration, resourceFactory, httpClientToken);

            var requestExecutor = new DefaultRequestExecutor(configuration, httpClientRequest, logger, new NoRetryStrategy(), tokenProvider);

            var response = await requestExecutor.GetAsync("foo", null, default(CancellationToken));

            response.StatusCode.Should().Be(401);
            tokenMessageHandler.NumberOfCalls.Should().Be(2);
            requestMessageHandler.NumberOfCalls.Should().Be(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.OK)]
        [InlineData(HttpStatusCode.InternalServerError)]
        public async Task NotRetryRequestOnceWhenResponseIsNot401AndAuthorizationModeIsPrivateKeyAsync(HttpStatusCode statusCode)
        {
            var requestMessageHandler = new MockHttpMessageHandler(string.Empty, statusCode);
            var httpClientRequest = new HttpClient(requestMessageHandler);

            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = TestCryptoKeys.GetMockRSAPrivateKeyConfiguration();
            configuration.Scopes = new List<string> { "foo" };

            var oktaClient = new OktaClient(configuration);
            var logger = Substitute.For<ILogger>();

            var resourceFactory = new ResourceFactory(oktaClient, logger);

            var tokenResponse = @"{""token_type"":""Bearer"",""expires_in"":3600,""access_token"":""foo"",""scope"":""okta.users.read okta.users.manage""}";
            var tokenMessageHandler = new MockHttpMessageHandler(tokenResponse, HttpStatusCode.OK);
            var httpClientToken = new HttpClient(tokenMessageHandler);
            var tokenProvider = new DefaultOAuthTokenProvider(configuration, resourceFactory, httpClientToken);

            var requestExecutor = new DefaultRequestExecutor(configuration, httpClientRequest, logger, new NoRetryStrategy(), tokenProvider);

            var response = await requestExecutor.GetAsync("foo", null, default(CancellationToken));

            response.StatusCode.Should().Be((int)statusCode);
            tokenMessageHandler.NumberOfCalls.Should().Be(1);
            requestMessageHandler.NumberOfCalls.Should().Be(1);
        }

        [Theory]
        [InlineData(HttpVerb.Get)]
        [InlineData(HttpVerb.Post)]
        [InlineData(HttpVerb.Put)]
        [InlineData(HttpVerb.Delete)]
        public async Task ExecuteMethodBasedOnVerb(HttpVerb verb)
        {
            var httpClientRequest = new HttpClient();
            var configuration = new OktaClientConfiguration
            {
                OktaDomain = "https://myOktaDomain.oktapreview.com",
                Token = "foo",
            };
            var logger = Substitute.For<ILogger>();

            var testRequestExecutor = new TestDefaultRequestExecutor(configuration, httpClientRequest, logger, new NoRetryStrategy(), null);
            HttpRequest testRequest = new HttpRequest
            {
                Verb = verb,
            };
            await testRequestExecutor.ExecuteRequestAsync(testRequest, default(CancellationToken));
            testRequestExecutor.VerbExecutionCounts[verb].Should().Be(1);
        }

        [Fact]
        public async Task CallRequestMessageProviderOnPostAsync()
        {
            var httpClientRequest = new HttpClient();
            var configuration = new OktaClientConfiguration
            {
                OktaDomain = "https://okta.okta.com",
                Token = "foo",
            };
            var logger = Substitute.For<ILogger>();
            var mockHttpRequestMessageProvider = Substitute.For<IHttpRequestMessageProvider>();
            mockHttpRequestMessageProvider
                .CreateHttpRequestMessage(Arg.Any<HttpRequest>(), Arg.Any<string>())
                .Returns(new HttpRequestMessage());

            var testRequestExecutor = new DefaultRequestExecutor(configuration, httpClientRequest, logger, new NoRetryStrategy(), null, mockHttpRequestMessageProvider);
            var testHttpRequest = new HttpRequest { Uri = "/api/v1" };
            await testRequestExecutor.PostAsync(testHttpRequest, CancellationToken.None);
            mockHttpRequestMessageProvider
                .Received(1)
                .CreateHttpRequestMessage(Arg.Is(testHttpRequest), Arg.Is<string>("api/v1"));
        }
    }
}
