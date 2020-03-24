// <copyright file="UserAgentHelperShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class UserAgentHelperShould
    {
        [Theory]
        [InlineData("foo")]
        [InlineData("foo .NET")]
        [InlineData(".NET")]
        [InlineData(".NET foo")]
        [InlineData(".NET Framework 4.8")]
        public void ReturnPassedFrameworkDescriptionIfItDoesNotStartWithKeyword(string runtimeDescription)
        {
            // Keyword for runtimeDescription = ".NET Core"
            var frameworkInfo = UserAgentHelper.GetFrameworkDescription(runtimeDescription);

            frameworkInfo.Should().Be(runtimeDescription);
        }

        [Theory]
        [InlineData("file:///C:/Program Files/dotnet/shared/Microsoft.NETCore.App/2.0.9/System.Private.CoreLib.dll", "2.0.9")]
        [InlineData("Microsoft.NETCore.App/2.0.9/System.Private.CoreLib.dll", "2.0.9")]
        [InlineData("foo/Microsoft.NETCore.App/2.0.9/System.Private.CoreLib.dll", "2.0.9")]
        [InlineData("foo/Microsoft.NETCore.App/3.1.1/System.Private.CoreLib.dll", "3.1.1")]
        public void ReturnNormalizedFrameworkDescriptionWhenItStartsWithKeywordAndCodeBaseHasKeyword(string runtimeAssemblyCodeBase, string expectedVersion)
        {
            // Keyword for runtimeDescription = ".NET Core"
            // Keyword for codeBase = "Microsoft.NETCore.App"
            var frameworkInfo = UserAgentHelper.GetFrameworkDescription(".NET Core", runtimeAssemblyCodeBase);

            frameworkInfo.Should().Be($".NET Core {expectedVersion}");
        }

        [Theory]
        [InlineData("Microsoft.App/2.0.9/System.Private.CoreLib.dll")]
        [InlineData("foo/Microsoft.NETCore.foo/2.0.9/System.Private.CoreLib.dll")]
        [InlineData("foo/Microsoft.NETCore.Apps/3.1.1/System.Private.CoreLib.dll")]
        public void ReturnPassedFrameworkDescriptionWhenAssemblyCodeBaseDoesNotContainKeyword(string runtimeAssemblyCodeBase)
        {
            // Keyword for runtimeDescription = ".NET Core"
            // Keyword for codeBase = "Microsoft.NETCore.App"
            var frameworkInfo = UserAgentHelper.GetFrameworkDescription(".NET Core foo", runtimeAssemblyCodeBase);

            frameworkInfo.Should().Be(".NET Core foo");
        }
    }
}
