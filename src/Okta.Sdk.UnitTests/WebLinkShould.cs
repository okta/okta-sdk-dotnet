// <copyright file="WebLinkShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class WebLinkShould
    {
        [Fact]
        public void ReturnTargetForToString()
        {
            var link = new WebLink("target://foo", "self");

            link.ToString().Should().Be(link.Target);
        }
    }
}
