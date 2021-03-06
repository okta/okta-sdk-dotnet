﻿// <copyright file="UserFactorsClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class UserFactorsClientShould
    {
        [Fact]
        public async Task EnrollEmailFactor()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            var factorsClient = client.UserFactors;
            var emailFactorOptions = new AddEmailFactorOptions
            {
                Email = "johndoe@mail.com",
                TokenLifetimeSeconds = 999,
            };
            await factorsClient.AddFactorAsync("UserId", emailFactorOptions);
            mockRequestExecutor.ReceivedHref.Should().Match("/api/v1/users/UserId/factors*tokenLifetimeSeconds=999*");
            mockRequestExecutor.ReceivedBody.Should().Be("{\"factorType\":\"email\",\"provider\":\"OKTA\",\"profile\":{\"email\":\"johndoe@mail.com\"}}");
        }

        [Fact]
        public async Task EnrollHotpFactor()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            var factorsClient = client.UserFactors;
            var hotpFactorOptions = new AddCustomHotpFactorOptions
            {
                FactorProfileId = "fpr20l2mDyaUGWGCa0g4",
                ProfileSharedSecret = "484f97be3213b117e3a20438e291540a",
            };
            await factorsClient.AddFactorAsync("UserId", hotpFactorOptions);
            mockRequestExecutor.ReceivedHref.Should().Match("/api/v1/users/UserId/factors*activate=true*");
            mockRequestExecutor.ReceivedBody.Should().Be("{\"factorType\":\"token:hotp\",\"provider\":\"CUSTOM\",\"factorProfileId\":\"fpr20l2mDyaUGWGCa0g4\",\"profile\":{\"sharedSecret\":\"484f97be3213b117e3a20438e291540a\"}}");
        }
    }
}
