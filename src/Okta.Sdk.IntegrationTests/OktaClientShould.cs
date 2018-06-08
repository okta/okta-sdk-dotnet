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
        private static IOktaClient CreateClient()
        {
            // Client settings are expected to be in environment variables on the test machine.
            return new OktaClient();
        }

        [Fact]
        public void ThrowForNullOrgUrl()
        {
            IOktaClient client;

            Assert.Throws<ArgumentNullException>(() =>
            {
                client = new OktaClient(new OktaClientConfiguration
                {
                    OrgUrl = string.Empty,
                    Token = "foobar",
                });
            });
        }

        [Fact]
        public void ThrowForInvalidOrgUrl()
        {
            IOktaClient client;

            Assert.Throws<ArgumentException>(() =>
            {
                client = new OktaClient(new OktaClientConfiguration
                {
                    // Must start with https://
                    OrgUrl = "http://insecure.dev",
                    Token = "foobar",
                });
            });
        }

        [Fact]
        public void ThrowForNullToken()
        {
            IOktaClient client;

            Assert.Throws<ArgumentNullException>(() =>
            {
                client = new OktaClient(new OktaClientConfiguration
                {
                    OrgUrl = "https://dev-12345.oktapreview.com",
                    Token = string.Empty,
                });
            });
        }

        [Fact]
        public async Task ThrowForArbitraryRequestUrl()
        {
            var client = CreateClient();

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            {
                // Request URI must start with Org URI
                return client.GetAsync<User>("https://evil.com/api/v1/users/foobar");
            });
        }

        [Fact]
        public async Task ThrowApiExceptionForInvalidToken()
        {
            var client = new OktaClient(new OktaClientConfiguration
            {
                Token = "abcd1234",
            });

            try
            {
                await client.Users.GetUserAsync("12345");
            }
            catch (OktaApiException apiException)
            {
                apiException.Message.Should().Be("Invalid token provided (400, E0000011)");

                apiException.Error.Should().NotBeNull();
                apiException.Error.ErrorCode.Should().Be("E0000011");
            }
        }
    }
}
