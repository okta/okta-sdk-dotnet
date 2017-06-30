// <copyright file="ScenarioGroup.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using Okta.Sdk.Configuration;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    /// <summary>
    /// Base class for groups of integration tests that optionally are run against a local test server.
    /// </summary>
    public abstract class ScenarioGroup
    {
        private readonly Lazy<OktaClient> _defaultClient;

        public ScenarioGroup()
        {
            _defaultClient = new Lazy<OktaClient>(() => new OktaClient());
        }

        protected IOktaClient GetClient(string scenarioName)
        {
            if (!TestConfiguration.UseLocalServer)
            {
                return _defaultClient.Value;
            }

            var configuredOrgUrl = _defaultClient.Value.Configuration.OrgUrl;
            var orgUrlWithScenarioName = $"{configuredOrgUrl}/{scenarioName}";

            return new OktaClient(new OktaClientConfiguration
            {
                OrgUrl = orgUrlWithScenarioName,
            });
        }
    }
}
