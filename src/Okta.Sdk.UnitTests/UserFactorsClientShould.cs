// <copyright file="UserFactorsClientShould.cs" company="Okta, Inc">
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
            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/UserId/factors?updatePhone=false&tokenLifetimeSeconds=999&activate=false");
            mockRequestExecutor.ReceivedBody.Should().Be("{\"factorType\":\"email\",\"provider\":\"OKTA\",\"profile\":{\"email\":\"johndoe@mail.com\"}}");
        }
    }
}
