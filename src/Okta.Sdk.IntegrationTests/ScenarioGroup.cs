// <copyright file="ScenarioGroup.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.IntegrationTests
{
    /// <summary>
    /// Base class for groups of integration tests.
    /// </summary>
    public abstract class ScenarioGroup
    {
        protected IOktaClient GetClient(string scenarioName)
        {
            // scenarioName is reserved for future use, if we add
            // mocked server responses to our testing strategy.

            return TestClient.Create();
        }
    }
}
