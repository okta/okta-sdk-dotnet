/*
 * Okta API
 *
 * Allows customers to easily access the Okta API
 *
 * The version of the OpenAPI document: 3.0.0
 * Contact: devex-public@okta.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Okta.Sdk.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISystemLogApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// List all System Log Events
        /// </summary>
        /// <remarks>
        /// The Okta System Log API provides read access to your organization’s system log. This API provides more functionality than the Events API
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="since"> (optional)</param>
        /// <param name="until"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="q"> (optional)</param>
        /// <param name="limit"> (optional, default to 100)</param>
        /// <param name="sortOrder"> (optional, default to &quot;ASCENDING&quot;)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;LogEvent&gt;</returns>
        IOktaCollectionClient<LogEvent> GetLogs(DateTimeOffset? since = default(DateTimeOffset?), DateTimeOffset? until = default(DateTimeOffset?), string filter = default(string), string q = default(string), int? limit = default(int?), string sortOrder = default(string), string after = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List all System Log Events
        /// </summary>
        /// <remarks>
        /// The Okta System Log API provides read access to your organization’s system log. This API provides more functionality than the Events API
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="since"> (optional)</param>
        /// <param name="until"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="q"> (optional)</param>
        /// <param name="limit"> (optional, default to 100)</param>
        /// <param name="sortOrder"> (optional, default to &quot;ASCENDING&quot;)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;LogEvent&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<LogEvent>>> GetLogsWithHttpInfoAsync(DateTimeOffset? since = default(DateTimeOffset?), DateTimeOffset? until = default(DateTimeOffset?), string filter = default(string), string q = default(string), int? limit = default(int?), string sortOrder = default(string), string after = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISystemLogApi :  ISystemLogApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class SystemLogApi : ISystemLogApi
    {
        private Okta.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        private IOAuthTokenProvider _oAuthTokenProvider;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemLogApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SystemLogApi(Okta.Sdk.Client.Configuration configuration = null, IOAuthTokenProvider oAuthTokenProvider = null)
        {
            configuration = Sdk.Client.Configuration.GetConfigurationOrDefault(configuration);

            this.Configuration = Okta.Sdk.Client.Configuration.MergeConfigurations(
                Okta.Sdk.Client.GlobalConfiguration.Instance,
                configuration
            );
            
            Sdk.Client.Configuration.Validate((Configuration)this.Configuration);
            
            _oAuthTokenProvider = NullOAuthTokenProvider.Instance;
            if (Sdk.Client.Configuration.IsPrivateKeyMode(this.Configuration))
            {
                _oAuthTokenProvider = oAuthTokenProvider ?? new DefaultOAuthTokenProvider(Configuration);
            }
            
            this.AsynchronousClient = new Okta.Sdk.Client.ApiClient(this.Configuration.OktaDomain);
            ExceptionFactory = Okta.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemLogApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public SystemLogApi(Okta.Sdk.Client.IAsynchronousClient asyncClient, Okta.Sdk.Client.IReadableConfiguration configuration)
        {
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Okta.Sdk.Client.Configuration.DefaultExceptionFactory;
             _oAuthTokenProvider = NullOAuthTokenProvider.Instance;
            if (Sdk.Client.Configuration.IsPrivateKeyMode(this.Configuration))
            {
                _oAuthTokenProvider = new DefaultOAuthTokenProvider(Configuration);
            }
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Okta.Sdk.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.OktaDomain;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Okta.Sdk.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Okta.Sdk.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }
         
        /// <summary>
        /// List all System Log Events The Okta System Log API provides read access to your organization’s system log. This API provides more functionality than the Events API
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="since"> (optional)</param>
        /// <param name="until"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="q"> (optional)</param>
        /// <param name="limit"> (optional, default to 100)</param>
        /// <param name="sortOrder"> (optional, default to &quot;ASCENDING&quot;)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;LogEvent&gt;</returns>
        public IOktaCollectionClient<LogEvent> GetLogs(DateTimeOffset? since = default(DateTimeOffset?), DateTimeOffset? until = default(DateTimeOffset?), string filter = default(string), string q = default(string), int? limit = default(int?), string sortOrder = default(string), string after = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Okta.Sdk.Client.RequestOptions localVarRequestOptions = new Okta.Sdk.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Okta.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Okta.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (since != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "since", since));
            }
            if (until != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "until", until));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (q != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "q", q));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (sortOrder != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "sortOrder", sortOrder));
            }
            if (after != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "after", after));
            }

            // authentication (API_Token) required
            if (Sdk.Client.Configuration.IsSswsMode(this.Configuration) && !string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }
            // authentication (OAuth_2.0) required
            // oauth required
            if (Sdk.Client.Configuration.IsBearerTokenMode(this.Configuration) && !string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            
            // If AuthorizationMode is equals to PrivateKey, the authorization header is set in the enumerator for collections.
            
            return new OktaCollectionClient<LogEvent>(localVarRequestOptions, "/api/v1/logs", this.AsynchronousClient, this.Configuration, this._oAuthTokenProvider);
        }
        /// <summary>
        /// List all System Log Events The Okta System Log API provides read access to your organization’s system log. This API provides more functionality than the Events API
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="since"> (optional)</param>
        /// <param name="until"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="q"> (optional)</param>
        /// <param name="limit"> (optional, default to 100)</param>
        /// <param name="sortOrder"> (optional, default to &quot;ASCENDING&quot;)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;LogEvent&gt;)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<List<LogEvent>>> GetLogsWithHttpInfoAsync(DateTimeOffset? since = default(DateTimeOffset?), DateTimeOffset? until = default(DateTimeOffset?), string filter = default(string), string q = default(string), int? limit = default(int?), string sortOrder = default(string), string after = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Okta.Sdk.Client.RequestOptions localVarRequestOptions = new Okta.Sdk.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Okta.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Okta.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (since != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "since", since));
            }
            if (until != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "until", until));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (q != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "q", q));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (sortOrder != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "sortOrder", sortOrder));
            }
            if (after != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "after", after));
            }

            // authentication (API_Token) required
            if (Sdk.Client.Configuration.IsSswsMode(this.Configuration) && !string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }
            // authentication (OAuth_2.0) required
            // oauth required
            if (Sdk.Client.Configuration.IsBearerTokenMode(this.Configuration) && !string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            
            // If AuthorizationMode is equals to PrivateKey, the authorization header is set in the enumerator for collections.

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<LogEvent>>("/api/v1/logs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLogs", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
