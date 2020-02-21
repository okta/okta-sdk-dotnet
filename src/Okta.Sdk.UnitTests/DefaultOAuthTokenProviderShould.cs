// <copyright file="DefaultOAuthTokenProviderShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
    public class DefaultOAuthTokenProviderShould
    {
        [Fact]
        public async Task FailIfResponseContentIsEmpty()
        {
            var messageHandler = new MockHttpMessageHandler(string.Empty, HttpStatusCode.BadRequest);
            var httpClient = new HttpClient(messageHandler);

            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = TestCryptoKeys.GetMockRSAPrivateKeyConfiguration();
            configuration.Scopes = new List<string> { "foo" };

            var oktaClient = new OktaClient(configuration);
            var logger = Substitute.For<ILogger>();

            var resourceFactory = new ResourceFactory(oktaClient, logger);
            var tokenProvider = new DefaultOAuthTokenProvider(configuration, resourceFactory, httpClient);

            Func<Task<string>> function = async () => await tokenProvider.GetAccessTokenAsync();

            function.Should().Throw<OktaOAuthException>();
        }

        [Fact]
        public async Task FailIfStatusCodeIs4xx()
        {
            var response = @"{""error"":""invalid_client"",""error_description"":""The audience claim for client_assertion must be the endpoint invoked for the request.""}";
            var messageHandler = new MockHttpMessageHandler(response, HttpStatusCode.Unauthorized);
            var httpClient = new HttpClient(messageHandler);

            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = TestCryptoKeys.GetMockRSAPrivateKeyConfiguration();
            configuration.Scopes = new List<string> { "foo" };

            var oktaClient = new OktaClient(configuration);
            var logger = Substitute.For<ILogger>();

            var resourceFactory = new ResourceFactory(oktaClient, logger);
            var tokenProvider = new DefaultOAuthTokenProvider(configuration, resourceFactory, httpClient);

            Func<Task<string>> function = async () => await tokenProvider.GetAccessTokenAsync();

            function.Should().Throw<OktaOAuthException>().Where(x => x.StatusCode == (int)HttpStatusCode.Unauthorized && x.Error == "invalid_client" && x.ErrorDescription == "The audience claim for client_assertion must be the endpoint invoked for the request.");
        }

        [Fact]
        public async Task FailIfAccessTokenNotFound()
        {
            var response = @"{""foo"":""bar""}";
            var messageHandler = new MockHttpMessageHandler(response, HttpStatusCode.OK);
            var httpClient = new HttpClient(messageHandler);

            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = TestCryptoKeys.GetMockRSAPrivateKeyConfiguration();
            configuration.Scopes = new List<string> { "foo" };

            var oktaClient = new OktaClient(configuration);
            var logger = Substitute.For<ILogger>();

            var resourceFactory = new ResourceFactory(oktaClient, logger);
            var tokenProvider = new DefaultOAuthTokenProvider(configuration, resourceFactory, httpClient);

            Func<Task<string>> function = async () => await tokenProvider.GetAccessTokenAsync();

            function.Should().Throw<MissingFieldException>();
        }

        [Fact]
        public async Task ReturnAccessTokenWhenRequestSuccess()
        {
            var response = @"{""token_type"":""Bearer"",""expires_in"":3600,""access_token"":""foo"",""scope"":""okta.users.read okta.users.manage""}";
            var messageHandler = new MockHttpMessageHandler(response, HttpStatusCode.OK);
            var httpClient = new HttpClient(messageHandler);

            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = TestCryptoKeys.GetMockRSAPrivateKeyConfiguration();
            configuration.Scopes = new List<string> { "foo" };

            var oktaClient = new OktaClient(configuration);
            var logger = Substitute.For<ILogger>();

            var resourceFactory = new ResourceFactory(oktaClient, logger);
            var tokenProvider = new DefaultOAuthTokenProvider(configuration, resourceFactory, httpClient);

            var token = await tokenProvider.GetAccessTokenAsync();

            token.Should().Be("foo");
        }
    }
}
