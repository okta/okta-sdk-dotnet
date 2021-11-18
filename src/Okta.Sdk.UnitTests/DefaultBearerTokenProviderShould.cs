// <copyright file="DefaultBearerTokenProviderShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
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
    public class DefaultBearerTokenProviderShould
    {
        [Fact]
        public async Task ReturnAccessTokenWhenRequestSuccess()
        {
            var tokenProvider = new DefaultBearerTokenProvider("DefaultExternallyGeneratedToken", default);
            var token = await tokenProvider.GetAccessTokenAsync();
            token.Should().Be("DefaultExternallyGeneratedToken");
        }

        [Fact]
        public async Task ReturnNewAccessTokenWhenOldIsNotAuthorized()
        {
            var configuration = new OktaClientConfiguration
            {
                OktaDomain = "https://myOktaDomain.oktapreview.com",
                AuthorizationMode = AuthorizationMode.BearerToken,
                ClientId = "foo",
                BearerToken = "token",
                Scopes = new List<string> { "foo" },
            };

            var requestMessageHandler = new MockHttpMessageHandler(string.Empty, HttpStatusCode.Unauthorized);
            var httpClientRequest = new HttpClient(requestMessageHandler);
            var testableCustomTokenProvider = new TestableCustomTokenProvider();
            var mockLogger = Substitute.For<ILogger>();
            var externalTokenProvider = new DefaultBearerTokenProvider("oldAccessToken", testableCustomTokenProvider);
            var requestExecutor = new DefaultRequestExecutor(configuration, httpClientRequest, mockLogger, oAuthTokenProvider: externalTokenProvider);

            testableCustomTokenProvider.TokenRefreshed.Should().BeFalse();
            await requestExecutor.GetAsync("https://myOktaDomain.oktapreview.com/v1/users", default, default).ConfigureAwait(false);
            testableCustomTokenProvider.TokenRefreshed.Should().BeTrue();
        }
    }
}
