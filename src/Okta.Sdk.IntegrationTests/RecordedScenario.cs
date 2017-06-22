// <copyright file="RecordedScenario.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Okta.Sdk.Configuration;

namespace Okta.Sdk.IntegrationTests
{
    public abstract class RecordedScenario
    {
        private readonly string _scenarioName;
        private readonly bool _useLocalServer;

        public RecordedScenario(string scenarioName)
        {
            _scenarioName = scenarioName;

            _useLocalServer = TestConfiguration.UseLocalServer;
        }

        protected IOktaClient GetClient()
        {
            if (!_useLocalServer)
            {
                return new OktaClient();
            }

            var defaultClient = new OktaClient();
            var orgUrlWithScenarioName = $"{defaultClient.DataStore.RequestExecutor.OrgUrl}/{_scenarioName}";

            return new OktaClient(new OktaClientConfiguration
            {
                OrgUrl = orgUrlWithScenarioName,
            });
        }
    }
}
