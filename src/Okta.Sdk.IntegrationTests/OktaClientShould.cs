// <copyright file="OktaClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Configuration;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class OktaClientShould
    {
        [Fact]
        public void ThrowForNullOktaDomain()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var client = new OktaClient(new OktaClientConfiguration
                {
                    OktaDomain = string.Empty,
                    Token = "foobar",
                });
            });
        }

        [Fact]
        public void ThrowForInvalidOktaDomain()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var client = new OktaClient(new OktaClientConfiguration
                {
                    // Must start with https://
                    OktaDomain = "http://insecure.dev",
                    Token = "foobar",
                    DisableHttpsCheck = false,
                });
            });
        }

        [Fact]
        public void ThrowForNullToken()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var client = new OktaClient(new OktaClientConfiguration
                {
                    OktaDomain = "https://dev-12345.oktapreview.com",
                    Token = string.Empty,
                });
            });
        }

        [Fact]
        public async Task ThrowForArbitraryRequestUrl()
        {
            var client = TestClient.Create();

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            {
                // Request URI must start with Org URI
                return client.GetAsync<User>("https://evil.com/api/v1/users/foobar");
            });
        }

        [Fact]
        public async Task ThrowApiExceptionForInvalidToken()
        {
            var client = TestClient.Create(new OktaClientConfiguration
            {
                OktaDomain = "https://dev-12345.oktapreview.com",
                Token = "abcd1234",
            });

            try
            {
                await client.Users.GetUserAsync("12345");
            }
            catch (OktaApiException apiException)
            {
                apiException.Message.Should().StartWith("Invalid token provided");

                apiException.Error.Should().NotBeNull();
                apiException.Error.ErrorCode.Should().Be("E0000011");
            }
        }
    }
}
