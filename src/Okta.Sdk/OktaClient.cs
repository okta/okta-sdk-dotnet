// <copyright file="OktaClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
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
        /// <param name="apiClientConfiguration">
        /// The client configuration. If <c>null</c>, the library will attempt to load
        /// configuration from an <c>okta.yaml</c> file or environment variables.
        /// </param>
        /// <param name="logger">The logging interface to use, if any.</param>
        /// <param name="serializer">The JSON serializer to use, if any. Using the <c>DefaultSerializer</c> is still strongly recommended since it has all the behavior this SDK needs to work properly.
        /// If a custom serializer is used, the developer is responsible to add the required logic for this SDK to continue working properly. See <see cref="DefaultSerializer"/> to check out what can be configured.
        /// </param>
        public OktaClient(OktaClientConfiguration apiClientConfiguration = null, ILogger logger = null, ISerializer serializer = null)
        {
            Configuration = GetConfigurationOrDefault(apiClientConfiguration);
            OktaClientConfigurationValidator.Validate(Configuration);

            logger = logger ?? NullLogger.Instance;
            serializer = serializer ?? new DefaultSerializer();

            var defaultClient = DefaultHttpClient.Create(
                Configuration.ConnectionTimeout,
                Configuration.Proxy,
                logger);

            var resourceFactory = new ResourceFactory(this, logger);
            IOAuthTokenProvider oAuthTokenProvider = (Configuration.AuthorizationMode == AuthorizationMode.PrivateKey) ? new DefaultOAuthTokenProvider(Configuration, resourceFactory, logger: logger) : NullOAuthTokenProvider.Instance;
            var requestExecutor = new DefaultRequestExecutor(Configuration, defaultClient, logger, oAuthTokenProvider: oAuthTokenProvider);

            _dataStore = new DefaultDataStore(
                requestExecutor,
                serializer,
                resourceFactory,
                logger);

            PayloadHandler.TryRegister<PkixCertPayloadHandler>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OktaClient"/> class using the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="apiClientConfiguration">
        /// The client configuration. If <c>null</c>, the library will attempt to load
        /// configuration from an <c>okta.yaml</c> file or environment variables.
        /// </param>
        /// <param name="httpClient">The HTTP client to use for requests to the Okta API.</param>
        /// <param name="logger">The logging interface to use, if any.</param>
        /// <param name="retryStrategy">The retry strategy interface to use, if any.</param>
        /// <param name="serializer">The JSON serializer to use, if any. Using the <c>DefaultSerializer</c> is still strongly recommended since it has all the behavior this SDK needs to work properly.
        /// If a custom serializer is used, the developer is responsible to add the required logic for this SDK to continue working properly. See <see cref="DefaultSerializer"/> to check out what settings can be configured.
        /// </param>
        public OktaClient(OktaClientConfiguration apiClientConfiguration, HttpClient httpClient, ILogger logger = null, IRetryStrategy retryStrategy = null, ISerializer serializer = null)
        {
            Configuration = GetConfigurationOrDefault(apiClientConfiguration);
            OktaClientConfigurationValidator.Validate(Configuration);

            logger = logger ?? NullLogger.Instance;
            serializer = serializer ?? new DefaultSerializer();

            var resourceFactory = new ResourceFactory(this, logger);
            IOAuthTokenProvider oAuthTokenProvider = (Configuration.AuthorizationMode == AuthorizationMode.PrivateKey) ? new DefaultOAuthTokenProvider(Configuration, resourceFactory, logger: logger) : NullOAuthTokenProvider.Instance;
            var requestExecutor = new DefaultRequestExecutor(Configuration, httpClient, logger, retryStrategy, oAuthTokenProvider);

            _dataStore = new DefaultDataStore(
                requestExecutor,
                serializer,
                resourceFactory,
                logger);

            PayloadHandler.TryRegister<PkixCertPayloadHandler>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OktaClient"/> class.
        /// </summary>
        /// <param name="dataStore">The <see cref="IDataStore">DataStore</see> to use.</param>
        /// <param name="configuration">The client configuration.</param>
        /// <param name="requestContext">The request context, if any.</param>
        /// <remarks>This overload is used internally to create cheap copies of an existing client.</remarks>
        protected OktaClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            Configuration = configuration;
            _requestContext = requestContext;
        }

        private static OktaClientConfiguration GetConfigurationOrDefault(OktaClientConfiguration apiClientConfiguration = null)
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
                .AddEnvironmentVariables("okta_testing", "_", root: "okta")
                .AddObject(apiClientConfiguration, root: "okta:client")
                .AddObject(apiClientConfiguration, root: "okta:testing")
                .AddObject(apiClientConfiguration);

            var compiledConfig = new OktaClientConfiguration();
            configBuilder.Build().GetSection("okta").GetSection("client").Bind(compiledConfig);
            configBuilder.Build().GetSection("okta").GetSection("testing").Bind(compiledConfig);
            configBuilder.Build().Bind(compiledConfig);

            return compiledConfig;
        }

        /// <inheritdoc/>
        public OktaClientConfiguration Configuration { get; }

        /// <inheritdoc/>
        public IOktaClient CreatedScoped(RequestContext requestContext)
            => new OktaClient(_dataStore, Configuration, requestContext);

        /// <inheritdoc/>
        public IUserTypesClient UserTypes => new UserTypesClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IUsersClient Users => new UsersClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IUserFactorsClient UserFactors => new UserFactorsClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IGroupsClient Groups => new GroupsClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IApplicationsClient Applications => new ApplicationsClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public ISessionsClient Sessions => new SessionsClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IAuthorizationServersClient AuthorizationServers => new AuthorizationServersClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public ILogsClient Logs => new LogsClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IPoliciesClient Policies => new PoliciesClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IEventHooksClient EventHooks => new EventHooksClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IInlineHooksClient InlineHooks => new InlineHooksClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public ILinkedObjectsClient LinkedObjects => new LinkedObjectsClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IFeaturesClient Features => new FeaturesClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public ITemplatesClient Templates => new TemplatesClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IIdentityProvidersClient IdentityProviders => new IdentityProvidersClient(_dataStore, Configuration, _requestContext);

        /// <summary>
        /// Creates a new <see cref="CollectionClient{T}"/> given an initial HTTP request.
        /// </summary>
        /// <typeparam name="T">The collection client item type.</typeparam>
        /// <param name="initialRequest">The initial HTTP request.</param>
        /// <returns>The collection client.</returns>
        protected CollectionClient<T> GetCollectionClient<T>(HttpRequest initialRequest)
            where T : IResource
            => new CollectionClient<T>(_dataStore, initialRequest, _requestContext);

        /// <inheritdoc/>
        public Task<T> GetAsync<T>(string href, CancellationToken cancellationToken = default(CancellationToken))
            where T : Resource, new()
            => GetAsync<T>(new HttpRequest { Uri = href, Verb = HttpVerb.Get }, cancellationToken);

        /// <inheritdoc/>
        public async Task<T> GetAsync<T>(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            where T : Resource, new()
        {
            request.Verb = HttpVerb.Get;
            var response = await _dataStore.GetAsync<T>(request, _requestContext, cancellationToken).ConfigureAwait(false);
            return response?.Payload;
        }

        /// <inheritdoc/>
        public CollectionClient<T> GetCollection<T>(string href)
            where T : IResource
            => GetCollection<T>(new HttpRequest
            {
                Uri = href,
            });

        /// <inheritdoc/>
        public CollectionClient<T> GetCollection<T>(HttpRequest request)
            where T : IResource
            => GetCollectionClient<T>(request);

        /// <inheritdoc/>
        public Task PostAsync(string href, object model, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest { Uri = href, Payload = model, Verb = HttpVerb.Post }, cancellationToken);

        /// <inheritdoc/>
        public Task<TResponse> PostAsync<TResponse>(string href, object model, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new()
            => PostAsync<TResponse>(new HttpRequest { Uri = href, Payload = model, Verb = HttpVerb.Post }, cancellationToken);

        /// <inheritdoc/>
        public Task PostAsync(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<Resource>(request, cancellationToken);

        /// <inheritdoc/>
        public async Task<TResponse> PostAsync<TResponse>(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new()
        {
            request.Verb = HttpVerb.Post;
            var response = await _dataStore.PostAsync<TResponse>(request, _requestContext, cancellationToken).ConfigureAwait(false);
            return response?.Payload;
        }

        /// <inheritdoc/>
        public Task PutAsync(string href, object model, CancellationToken cancellationToken = default(CancellationToken))
            => PutAsync(new HttpRequest { Uri = href, Payload = model, Verb = HttpVerb.Put }, cancellationToken);

        /// <inheritdoc/>
        public Task<TResponse> PutAsync<TResponse>(string href, object model, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new()
            => PutAsync<TResponse>(new HttpRequest { Uri = href, Payload = model, Verb = HttpVerb.Put }, cancellationToken);

        /// <inheritdoc/>
        public Task PutAsync(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            => PutAsync<Resource>(request, cancellationToken);

        /// <inheritdoc/>
        public async Task<TResponse> PutAsync<TResponse>(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new()
        {
            request.Verb = HttpVerb.Put;
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
