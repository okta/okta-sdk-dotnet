// <copyright file="OktaClient.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
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
    /// <summary>
    /// A client that communicates with the Okta management API.
    /// </summary>
    /// <example>
    /// Initialize an OktaClient by passing configuration via code
    /// <code>
    /// var oktaClient = new OktaClient(new OktaClientConfiguration
    /// {
    ///   OrgUrl = "https://dev-12345.oktapreview.com/",
    ///   Token = "my_api_token"
    /// });
    /// </code>
    /// </example>
    public partial class OktaClient : IOktaClient
    {
        private readonly IDataStore _dataStore;
        private readonly RequestContext _requestContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="OktaClient"/> class.
        /// </summary>
        /// <param name="apiClientConfiguration">The client configuration.</param>
        /// <param name="logger">The logging interface.</param>
        /// <remarks>
        /// Configuration can also be specified with a YAML file, or by environment variables.
        /// </remarks>
        public OktaClient(OktaClientConfiguration apiClientConfiguration = null, ILogger logger = null)
        {
            var compiled = CompileFromConfigurationSources(apiClientConfiguration);
            var config = new OktaClientConfiguration();
            compiled.GetSection("okta").GetSection("client").Bind(config);

            ThrowIfInvalidConfiguration(config);
            Configuration = config.DeepClone();

            logger = logger ?? NullLogger.Instance;

            var requestExecutor = new DefaultRequestExecutor(config, logger);
            var resourceFactory = new ResourceFactory(this, logger);
            _dataStore = new DefaultDataStore(requestExecutor, new DefaultSerializer(), resourceFactory, logger);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OktaClient"/> class.
        /// </summary>
        /// <param name="dataStore">The <see cref="IDataStore">DataStore</see> to use.</param>
        /// <param name="configuration">The client configuration.</param>
        /// <param name="requestContext">The request context, if any.</param>
        protected OktaClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            Configuration = configuration;
            _requestContext = requestContext;
        }

        /// <inheritdoc/>
        public OktaClientConfiguration Configuration { get; }

        /// <inheritdoc/>
        public IOktaClient CreatedScoped(RequestContext requestContext)
            => new OktaClient(_dataStore, Configuration, requestContext);

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

        /// <inheritdoc/>
        public IUsersClient Users => new UsersClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IUserFactorsClient UserFactors => new UserFactorsClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IGroupsClient Groups => new GroupsClient(_dataStore, Configuration, _requestContext);

        /// <summary>
        /// Creates a new <see cref="CollectionClient{T}"/> given an initial HTTP request.
        /// </summary>
        /// <typeparam name="T">The collection client item type.</typeparam>
        /// <param name="initialRequest">The initial HTTP request.</param>
        /// <returns>The collection client.</returns>
        protected CollectionClient<T> GetCollectionClient<T>(HttpRequest initialRequest)
            where T : Resource, new()
            => new CollectionClient<T>(_dataStore, initialRequest, _requestContext);

        /// <inheritdoc/>
        public Task<T> GetAsync<T>(string href, CancellationToken cancellationToken = default(CancellationToken))
            where T : Resource, new()
            => GetAsync<T>(new HttpRequest { Uri = href }, cancellationToken);

        /// <inheritdoc/>
        public async Task<T> GetAsync<T>(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            where T : Resource, new()
        {
            var response = await _dataStore.GetAsync<T>(request, _requestContext, cancellationToken).ConfigureAwait(false);
            return response?.Payload;
        }

        /// <inheritdoc/>
        public IAsyncEnumerable<T> GetCollection<T>(string href)
            where T : Resource, new()
            => GetCollection<T>(new HttpRequest
            {
                Uri = href,
            });

        /// <inheritdoc/>
        public IAsyncEnumerable<T> GetCollection<T>(HttpRequest request)
            where T : Resource, new()
            => GetCollectionClient<T>(request);

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
            var response = await _dataStore.PostAsync<TResponse>(request, _requestContext, cancellationToken).ConfigureAwait(false);
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
            var response = await _dataStore.PutAsync<TResponse>(request, _requestContext, cancellationToken).ConfigureAwait(false);
            return response?.Payload;
        }

        /// <inheritdoc/>
        public Task DeleteAsync(string href, CancellationToken cancellationToken = default(CancellationToken))
            => DeleteAsync(new HttpRequest { Uri = href }, cancellationToken);

        /// <inheritdoc/>
        public Task DeleteAsync(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            => _dataStore.DeleteAsync(request, _requestContext, cancellationToken);
    }
}
