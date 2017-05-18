// <copyright file="OktaClient.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Abstractions;

namespace Okta.Sdk
{
    public partial class OktaClient : IOktaClient
    {
        private readonly ILogger _logger;

        public OktaClient(ApiClientConfiguration apiClientConfiguration = null, ILogger logger = null)
        {
            // TODO: flexible configuration

            //string configurationFileRoot = null; // TODO find the application root directory at runtime?

            //var homeOktaJsonLocation = HomePath.Resolve("~", ".okta", "okta.json");
            //var homeOktaYamlLocation = HomePath.Resolve("~", ".okta", "okta.yaml");

            //var applicationAppSettingsLocation = Path.Combine(configurationFileRoot ?? string.Empty, "appsettings.json");
            //var applicationOktaJsonLocation = Path.Combine(configurationFileRoot ?? string.Empty, "okta.json");
            //var applicationOktaYamlLocation = Path.Combine(configurationFileRoot ?? string.Empty, "okta.yaml");

            //var configBuilder = new ConfigurationBuilder()
            //    .AddYamlFile(homeOktaYamlLocation, optional: true, root: "okta")
            //    .AddJsonFile(homeOktaJsonLocation, optional: true, root: "okta")
            //    .AddJsonFile(applicationAppSettingsLocation, optional: true)
            //    .AddYamlFile(applicationOktaYamlLocation, optional: true, root: "okta")
            //    .AddJsonFile(applicationOktaJsonLocation, optional: true, root: "okta")
            //    .AddEnvironmentVariables("okta", "_", root: "okta")
            //    .AddObject(apiClientConfiguration, root: "okta");

            //var config = configBuilder.Build();

            // TODO: for now, just doing dumb configuration

            _logger = logger ?? NullLogger.Instance;

            // TODO pass proxy, connectionTimeout, etc
            DataStore = new DefaultDataStore(
                new DefaultRequestExecutor(apiClientConfiguration.OrgUrl, apiClientConfiguration.Token, _logger),
                new DefaultSerializer());
        }

        public OktaClient(IDataStore dataStore)
        {
            DataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        public IDataStore DataStore { get; }

        public UsersClient GetUsersClient => new UsersClient(this);

        public async Task<T> GetAsync<T>(string href, CancellationToken cancellationToken = default(CancellationToken))
            where T : Resource, new()
        {
            var response = await DataStore.GetAsync<T>(href, cancellationToken).ConfigureAwait(false);
            return response.Payload;
        }

        public async Task<TResponse> PostAsync<TResponse>(
            string href,
            object model,
            CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new()
        {
            var response = await DataStore.PostAsync<TResponse>(href, model, cancellationToken).ConfigureAwait(false);
            return response.Payload;
        }
    }
}
