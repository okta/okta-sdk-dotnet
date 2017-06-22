// <copyright file="ListUsersShould.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(RecordedScenarioCollection))]
    public class ListUsersShould : RecordedScenario
    {
        public ListUsersShould()
            : base(scenarioName: "list-users")
        {
        }

        [Fact]
        public void DoStuff()
        {
            Assert.True(true);
        }
    }
}
