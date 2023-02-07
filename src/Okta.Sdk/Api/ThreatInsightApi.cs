/*
 * Okta Management
 *
 * Allows customers to easily access the Okta Management APIs
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
    public partial interface IThreatInsightApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Retrieve the ThreatInsight Configuration
        /// </summary>
        /// <remarks>
        /// Gets current ThreatInsight configuration
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ThreatInsightConfiguration</returns>
        System.Threading.Tasks.Task<ThreatInsightConfiguration> GetCurrentConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve the ThreatInsight Configuration
        /// </summary>
        /// <remarks>
        /// Gets current ThreatInsight configuration
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ThreatInsightConfiguration)</returns>
        System.Threading.Tasks.Task<ApiResponse<ThreatInsightConfiguration>> GetCurrentConfigurationWithHttpInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update the ThreatInsight Configuration
        /// </summary>
        /// <remarks>
        /// Updates ThreatInsight configuration
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="threatInsightConfiguration"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ThreatInsightConfiguration</returns>
        System.Threading.Tasks.Task<ThreatInsightConfiguration> UpdateConfigurationAsync(  ThreatInsightConfiguration threatInsightConfiguration , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update the ThreatInsight Configuration
        /// </summary>
        /// <remarks>
        /// Updates ThreatInsight configuration
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="threatInsightConfiguration"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ThreatInsightConfiguration)</returns>
        System.Threading.Tasks.Task<ApiResponse<ThreatInsightConfiguration>> UpdateConfigurationWithHttpInfoAsync(  ThreatInsightConfiguration threatInsightConfiguration , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial interface IThreatInsightApi :  IThreatInsightApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ThreatInsightApi : IThreatInsightApi
    {
        private Okta.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        private IOAuthTokenProvider _oAuthTokenProvider;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ThreatInsightApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <param name="oAuthTokenProvider">The access token provider to be used when the AuthorizationMode is equals to Private Key. Optional./param>
        /// <param name="webProxy">The web proxy to be used by the HTTP client. Optional./param>
        /// <returns></returns>
        public ThreatInsightApi(Okta.Sdk.Client.Configuration configuration = null, IOAuthTokenProvider oAuthTokenProvider = null, WebProxy webProxy = null)
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
            
            this.AsynchronousClient = new Okta.Sdk.Client.ApiClient(this.Configuration.OktaDomain, _oAuthTokenProvider, webProxy);
            ExceptionFactory = Okta.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreatInsightApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ThreatInsightApi(Okta.Sdk.Client.IAsynchronousClient asyncClient, Okta.Sdk.Client.IReadableConfiguration configuration)
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
        /// Retrieve the ThreatInsight Configuration Gets current ThreatInsight configuration
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ThreatInsightConfiguration</returns>
        public async System.Threading.Tasks.Task<ThreatInsightConfiguration> GetCurrentConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<ThreatInsightConfiguration> localVarResponse = await GetCurrentConfigurationWithHttpInfoAsync(cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Retrieve the ThreatInsight Configuration Gets current ThreatInsight configuration
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ThreatInsightConfiguration)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<ThreatInsightConfiguration>> GetCurrentConfigurationWithHttpInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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


            // authentication (apiToken) required
            if (Sdk.Client.Configuration.IsSswsMode(this.Configuration) && !string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }
            // authentication (oauth2) required
            // oauth required
            if (Sdk.Client.Configuration.IsBearerTokenMode(this.Configuration) && !string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            
            if (Sdk.Client.Configuration.IsPrivateKeyMode(this.Configuration) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                var token = await _oAuthTokenProvider.GetAccessTokenAsync(cancellationToken: cancellationToken);
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + token);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ThreatInsightConfiguration>("/api/v1/threats/configuration", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCurrentConfiguration", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update the ThreatInsight Configuration Updates ThreatInsight configuration
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="threatInsightConfiguration"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ThreatInsightConfiguration</returns>
        public async System.Threading.Tasks.Task<ThreatInsightConfiguration> UpdateConfigurationAsync(  ThreatInsightConfiguration threatInsightConfiguration , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<ThreatInsightConfiguration> localVarResponse = await UpdateConfigurationWithHttpInfoAsync(threatInsightConfiguration, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Update the ThreatInsight Configuration Updates ThreatInsight configuration
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="threatInsightConfiguration"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ThreatInsightConfiguration)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<ThreatInsightConfiguration>> UpdateConfigurationWithHttpInfoAsync(  ThreatInsightConfiguration threatInsightConfiguration , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'threatInsightConfiguration' is set
            if (threatInsightConfiguration == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'threatInsightConfiguration' when calling ThreatInsightApi->UpdateConfiguration");
            }


            Okta.Sdk.Client.RequestOptions localVarRequestOptions = new Okta.Sdk.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
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

            localVarRequestOptions.Data = threatInsightConfiguration;

            // authentication (apiToken) required
            if (Sdk.Client.Configuration.IsSswsMode(this.Configuration) && !string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }
            // authentication (oauth2) required
            // oauth required
            if (Sdk.Client.Configuration.IsBearerTokenMode(this.Configuration) && !string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            
            if (Sdk.Client.Configuration.IsPrivateKeyMode(this.Configuration) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                var token = await _oAuthTokenProvider.GetAccessTokenAsync(cancellationToken: cancellationToken);
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + token);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<ThreatInsightConfiguration>("/api/v1/threats/configuration", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateConfiguration", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
