// <copyright file="OktaClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
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
        private static IOktaClient CreateClient(string token = null)
        {
            // TODO get these values from configuration
            return new OktaClient(new ApiClientConfiguration
            {
                OrgUrl = "https://dev-341607.oktapreview.com",
                Token = token ?? "00w6Z6oZSqdPX243H5XUPj0svMGbJonU20-Rjnatqe",
            });
        }

        [Fact]
        public void ThrowForNullOrgUrl()
        {
            IOktaClient client;

            Assert.Throws<ArgumentNullException>(() =>
            {
                client = new OktaClient(new ApiClientConfiguration
                {
                    OrgUrl = null,
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
                client = new OktaClient(new ApiClientConfiguration
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
                client = new OktaClient(new ApiClientConfiguration
                {
                    OrgUrl = "https://dev-12345.oktapreview.com",
                    Token = null,
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
                return client.GetAsync<User>("https://dev-999.oktapreview.com/api/v1/users/foobar");
            });
        }

        [Fact]
        public async Task ThrowApiExceptionForInvalidToken()
        {
            var client = CreateClient(token: "foobar123");

            try
            {
                await client.GetAsync<User>("https://dev-341607.oktapreview.com/api/v1/users/00u9o1nikjvOBg5Zo0h7");
            }
            catch (OktaApiException apiException)
            {
                apiException.Message.Should().Be("Invalid token provided");
                apiException.ErrorCode.Should().Be("E0000011");
                apiException.ErrorSummary.Should().Be("Invalid token provided");
                apiException.ErrorLink.Should().Be("E0000011");
                apiException.ErrorId.Should().NotBeNullOrEmpty();
                // TODO errorCauses
            }
        }

        [Fact]
        public async Task GetUserByHref()
        {
            var client = CreateClient();
            var user = await client.GetAsync<User>("https://dev-341607.oktapreview.com/api/v1/users/00u9o1nikjvOBg5Zo0h7");

            user.Id.Should().Be("00u9o1nikjvOBg5Zo0h7");
            user.Created.Value.Year.Should().Be(2017);
            user.Profile.LastName.Should().Be("Barbettini");
            user.Profile.FirstName.Should().Be("Nathanael");
        }
    }
}
