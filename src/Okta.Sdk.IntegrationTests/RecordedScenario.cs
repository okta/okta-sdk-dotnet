// <copyright file="RecordedScenario.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using Okta.Sdk.Configuration;

namespace Okta.Sdk.IntegrationTests
{
    public abstract class RecordedScenario
    {
        private readonly Lazy<IOktaClient> _client;

        public RecordedScenario(string scenarioName)
        {
            _client = new Lazy<IOktaClient>(() =>
            {
                if (!TestConfiguration.UseLocalServer)
                {
                    return new OktaClient();
                }

                var defaultClient = new OktaClient();
                var orgUrlWithScenarioName = $"{defaultClient.DataStore.RequestExecutor.OrgUrl}/{scenarioName}";

                return new OktaClient(new OktaClientConfiguration
                {
                    OrgUrl = orgUrlWithScenarioName,
                });
            });
        }

        protected IOktaClient GetClient() => _client.Value;
    }
}
