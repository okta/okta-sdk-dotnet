// <copyright file="StringEnumDerivedClassShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class StringEnumDerivedClassShould
    {
        [Fact]
        public void UseCaseInsensitiveComparison()
        {
            var userStatus1 = new UserStatus("Active");
            var userStatus2 = UserStatus.Active;

            (userStatus1 == userStatus2).Should().BeTrue();
        }

        [Fact]
        public void UseCaseInsensitveComparisonForGetHashCode()
        {
            var userStatus1 = new UserStatus("Active");
            var userStatus2 = UserStatus.Active;

            userStatus1.GetHashCode().Should().Be(userStatus2.GetHashCode());
        }
    }
}
