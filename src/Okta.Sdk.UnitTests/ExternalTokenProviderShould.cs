// <copyright file="ExternalTokenProviderShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
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
    public class ExternalTokenProviderShould
    {
        [Fact]
        public async Task ReturnAccessTokenWhenRequestSuccess()
        {
            var response = @"{""token_type"":""Bearer"",""expires_in"":3600,""access_token"":""foo"",""scope"":""okta.users.read okta.users.manage""}";
            var messageHandler = new MockHttpMessageHandler(response, HttpStatusCode.OK);
            var httpClient = new HttpClient(messageHandler);

            var configuration = new OktaClientConfiguration
            {
                OktaDomain = "https://myOktaDomain.oktapreview.com",
                AuthorizationMode = AuthorizationMode.OAuthAccessToken,
                ClientId = "foo",
                OAuthAccessToken = "Token",
                Scopes = new List<string> { "foo" },
            };

            var oktaClient = new OktaClient(configuration);
            var logger = Substitute.For<ILogger>();

            var resourceFactory = new ResourceFactory(oktaClient, logger);
            var tokenProvider = new ExternalTokenProvider("DefaultExternallyGeneratedToken", default);

            var token = await tokenProvider.GetAccessTokenAsync();

            token.Should().Be("DefaultExternallyGeneratedToken");
        }

        [Fact]
        public async Task ReturnNewAccessTokenWhenRefreshRequested()
        {
            var response = @"{""token_type"":""Bearer"",""expires_in"":3600,""access_token"":""foo"",""scope"":""okta.users.read okta.users.manage""}";
            var messageHandler = new MockHttpMessageHandler(response, HttpStatusCode.OK);
            var httpClient = new HttpClient(messageHandler);

            var configuration = new OktaClientConfiguration
            {
                OktaDomain = "https://myOktaDomain.oktapreview.com",
                AuthorizationMode = AuthorizationMode.OAuthAccessToken,
                ClientId = "foo",
                OAuthAccessToken = "token",
                Scopes = new List<string> { "foo" },
            };

            Func<Task<string>> tokenRenewer = () =>
            {
                return Task.FromResult("NewExternallyGeneratedToken");
            };

            var oktaClient = new OktaClient(configuration, oauthTokenRenewer: tokenRenewer);

            var logger = Substitute.For<ILogger>();

            var resourceFactory = new ResourceFactory(oktaClient, logger);
            var tokenProvider = new ExternalTokenProvider("DefaultExternalToken", tokenRenewer);

            var token = await tokenProvider.GetAccessTokenAsync(true);

            token.Should().Be("NewExternallyGeneratedToken");
        }

    }
}
