// <copyright file="OktaClient.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FlexibleConfiguration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    public partial class OktaClient : IOktaClient
    {
        protected OktaClient(IDataStore dataStore)
        {
            DataStore = dataStore;
        }

        public OktaClient(OktaClientConfiguration apiClientConfiguration = null, ILogger logger = null)
        {
            var compiled = CompileFromConfigurationSources(apiClientConfiguration);
            var config = new OktaClientConfiguration();
            compiled.GetSection("okta").GetSection("client").Bind(config);

            ThrowIfInvalidConfiguration(config);

            var realLogger = logger ?? NullLogger.Instance;

            var requestExecutor = new DefaultRequestExecutor(config, realLogger);
            DataStore = new DefaultDataStore(requestExecutor, new DefaultSerializer(), realLogger);
        }

        private static FlexibleConfiguration.Abstractions.IConfigurationRoot CompileFromConfigurationSources(OktaClientConfiguration apiClientConfiguration = null)
        {
            string configurationFileRoot = Directory.GetCurrentDirectory();

            var homeOktaYamlLocation = HomePath.Resolve("~", ".okta", "okta.yaml");

            var applicationAppSettingsLocation = Path.Combine(configurationFileRoot ?? string.Empty, "appsettings.json");
            var applicationOktaYamlLocation = Path.Combine(configurationFileRoot ?? string.Empty, "okta.yaml");

            var configBuilder = new ConfigurationBuilder()
                .AddYamlFile(homeOktaYamlLocation, optional: true)
                .AddJsonFile(applicationAppSettingsLocation, optional: true)
                .AddYamlFile(applicationOktaYamlLocation, optional: true)
                .AddEnvironmentVariables("okta", "_", root: "okta")
                .AddObject(apiClientConfiguration, root: "okta:client");

            return configBuilder.Build();
        }

        private static void ThrowIfInvalidConfiguration(OktaClientConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration.OrgUrl))
            {
                throw new ArgumentNullException(nameof(configuration.OrgUrl), "You must supply an Okta Org URL, like https://dev-12345.oktapreview.com");
            }

            if (string.IsNullOrEmpty(configuration.Token))
            {
                throw new ArgumentNullException(nameof(configuration.Token), "You must supply an Okta API token. You can create one in the Okta developer dashboard.");
            }
        }

        public IDataStore DataStore { get; }

        /// <inheritdoc/>
        public UserClient Users => new UserClient(DataStore);

        /// <inheritdoc/>
        public GroupClient Groups => new GroupClient(DataStore);

        /// <inheritdoc/>
        public Task<T> GetAsync<T>(string href, CancellationToken cancellationToken = default(CancellationToken))
            where T : Resource, new()
            => GetAsync<T>(new HttpRequest { Uri = href }, cancellationToken);

        /// <inheritdoc/>
        public async Task<T> GetAsync<T>(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            where T : Resource, new()
        {
            var response = await DataStore.GetAsync<T>(request, cancellationToken).ConfigureAwait(false);
            return response?.Payload;
        }

        /// <inheritdoc/>
        public Task PostAsync(string href, object model, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest { Uri = href, Payload = model }, cancellationToken);

        /// <inheritdoc/>
        public Task<TResponse> PostAsync<TResponse>(string href, object model, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new()
            => PostAsync<TResponse>(new HttpRequest { Uri = href, Payload = model }, cancellationToken);

        /// <inheritdoc/>
        public Task PostAsync(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<Resource>(request, cancellationToken);

        /// <inheritdoc/>
        public async Task<TResponse> PostAsync<TResponse>(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new()
        {
            var response = await DataStore.PostAsync<TResponse>(request, cancellationToken).ConfigureAwait(false);
            return response?.Payload;
        }

        /// <inheritdoc/>
        public Task PutAsync(string href, object model, CancellationToken cancellationToken = default(CancellationToken))
            => PutAsync(new HttpRequest { Uri = href, Payload = model }, cancellationToken);

        /// <inheritdoc/>
        public Task<TResponse> PutAsync<TResponse>(string href, object model, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new()
            => PutAsync<TResponse>(new HttpRequest { Uri = href, Payload = model }, cancellationToken);

        /// <inheritdoc/>
        public Task PutAsync(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            => PutAsync<Resource>(request, cancellationToken);

        /// <inheritdoc/>
        public async Task<TResponse> PutAsync<TResponse>(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new()
        {
            var response = await DataStore.PostAsync<TResponse>(request, cancellationToken).ConfigureAwait(false);
            return response?.Payload;
        }

        /// <inheritdoc/>
        public Task DeleteAsync(string href, CancellationToken cancellationToken = default(CancellationToken))
            => DeleteAsync(new HttpRequest { Uri = href }, cancellationToken);

        /// <inheritdoc/>
        public Task DeleteAsync(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            => DataStore.DeleteAsync(request, cancellationToken);
    }
}
