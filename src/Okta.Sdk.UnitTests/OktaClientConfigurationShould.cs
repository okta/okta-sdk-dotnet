// <copyright file="OktaClientConfigurationShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Configuration;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class OktaClientConfigurationShould
    {
        [Fact]
        public void DefaultDisableHttpsCheckToFalse()
        {
            var clientConfiguration = new OktaClientConfiguration();

            clientConfiguration.DisableHttpsCheck.Should().BeFalse();
        }
    }
}
