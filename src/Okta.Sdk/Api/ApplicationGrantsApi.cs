/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.07.0
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
    public partial interface IApplicationGrantsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Retrieve an app Grant
        /// </summary>
        /// <remarks>
        /// Retrieves a single scope consent Grant object for the app
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="grantId">Grant ID</param>
        /// <param name="expand">An optional parameter to return scope details in the &#x60;_embedded&#x60; property. Valid value: &#x60;scope&#x60; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OAuth2ScopeConsentGrant</returns>
        System.Threading.Tasks.Task<OAuth2ScopeConsentGrant> GetScopeConsentGrantAsync(  string appId ,   string grantId ,   string expand = default(string) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve an app Grant
        /// </summary>
        /// <remarks>
        /// Retrieves a single scope consent Grant object for the app
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="grantId">Grant ID</param>
        /// <param name="expand">An optional parameter to return scope details in the &#x60;_embedded&#x60; property. Valid value: &#x60;scope&#x60; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OAuth2ScopeConsentGrant)</returns>
        System.Threading.Tasks.Task<ApiResponse<OAuth2ScopeConsentGrant>> GetScopeConsentGrantWithHttpInfoAsync(  string appId ,   string grantId ,   string expand = default(string) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Grant consent to scope
        /// </summary>
        /// <remarks>
        /// Grants consent for the app to request an OAuth 2.0 Okta scope
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="oAuth2ScopeConsentGrant"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OAuth2ScopeConsentGrant</returns>
        System.Threading.Tasks.Task<OAuth2ScopeConsentGrant> GrantConsentToScopeAsync(  string appId ,   OAuth2ScopeConsentGrant oAuth2ScopeConsentGrant , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Grant consent to scope
        /// </summary>
        /// <remarks>
        /// Grants consent for the app to request an OAuth 2.0 Okta scope
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="oAuth2ScopeConsentGrant"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OAuth2ScopeConsentGrant)</returns>
        System.Threading.Tasks.Task<ApiResponse<OAuth2ScopeConsentGrant>> GrantConsentToScopeWithHttpInfoAsync(  string appId ,   OAuth2ScopeConsentGrant oAuth2ScopeConsentGrant , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List all app Grants
        /// </summary>
        /// <remarks>
        /// Lists all scope consent Grants for the app
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="expand">An optional parameter to return scope details in the &#x60;_embedded&#x60; property. Valid value: &#x60;scope&#x60; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;OAuth2ScopeConsentGrant&gt;</returns>
        IOktaCollectionClient<OAuth2ScopeConsentGrant> ListScopeConsentGrants(  string appId ,   string expand = default(string) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List all app Grants
        /// </summary>
        /// <remarks>
        /// Lists all scope consent Grants for the app
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="expand">An optional parameter to return scope details in the &#x60;_embedded&#x60; property. Valid value: &#x60;scope&#x60; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;OAuth2ScopeConsentGrant&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<OAuth2ScopeConsentGrant>>> ListScopeConsentGrantsWithHttpInfoAsync(  string appId ,   string expand = default(string) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Revoke an app Grant
        /// </summary>
        /// <remarks>
        /// Revokes permission for the app to grant the given scope
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="grantId">Grant ID</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task RevokeScopeConsentGrantAsync(  string appId ,   string grantId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Revoke an app Grant
        /// </summary>
        /// <remarks>
        /// Revokes permission for the app to grant the given scope
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="grantId">Grant ID</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> RevokeScopeConsentGrantWithHttpInfoAsync(  string appId ,   string grantId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial interface IApplicationGrantsApi :  IApplicationGrantsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ApplicationGrantsApi : IApplicationGrantsApi
    {
        private Okta.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        private IOAuthTokenProvider _oAuthTokenProvider;
        
        public ApplicationGrantsApi(Okta.Sdk.Client.OktaApiClientOptions options) : this(options.Configuration, options.OAuthTokenProvider, options.WebProxy)
        {
            this.AsynchronousClient = new Okta.Sdk.Client.ApiClient(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationGrantsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <param name="oAuthTokenProvider">The access token provider to be used when the AuthorizationMode is equals to Private Key. Optional./param>
        /// <param name="webProxy">The web proxy to be used by the HTTP client. Optional./param>
        /// <returns></returns>
        public ApplicationGrantsApi(Okta.Sdk.Client.Configuration configuration = null, IOAuthTokenProvider oAuthTokenProvider = null, WebProxy webProxy = null)
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
        /// Initializes a new instance of the <see cref="ApplicationGrantsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ApplicationGrantsApi(Okta.Sdk.Client.IAsynchronousClient asyncClient, Okta.Sdk.Client.IReadableConfiguration configuration)
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
        /// Retrieve an app Grant Retrieves a single scope consent Grant object for the app
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="grantId">Grant ID</param>
        /// <param name="expand">An optional parameter to return scope details in the &#x60;_embedded&#x60; property. Valid value: &#x60;scope&#x60; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OAuth2ScopeConsentGrant</returns>
        public async System.Threading.Tasks.Task<OAuth2ScopeConsentGrant> GetScopeConsentGrantAsync(  string appId ,   string grantId ,   string expand = default(string) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<OAuth2ScopeConsentGrant> localVarResponse = await GetScopeConsentGrantWithHttpInfoAsync(appId, grantId, expand, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Retrieve an app Grant Retrieves a single scope consent Grant object for the app
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="grantId">Grant ID</param>
        /// <param name="expand">An optional parameter to return scope details in the &#x60;_embedded&#x60; property. Valid value: &#x60;scope&#x60; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OAuth2ScopeConsentGrant)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<OAuth2ScopeConsentGrant>> GetScopeConsentGrantWithHttpInfoAsync(  string appId ,   string grantId ,   string expand = default(string) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'appId' is set
            if (appId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'appId' when calling ApplicationGrantsApi->GetScopeConsentGrant");
            }

            // verify the required parameter 'grantId' is set
            if (grantId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'grantId' when calling ApplicationGrantsApi->GetScopeConsentGrant");
            }


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

            localVarRequestOptions.PathParameters.Add("appId", Okta.Sdk.Client.ClientUtils.ParameterToString(appId)); // path parameter
            localVarRequestOptions.PathParameters.Add("grantId", Okta.Sdk.Client.ClientUtils.ParameterToString(grantId)); // path parameter
            if (expand != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "expand", expand));
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
                await _oAuthTokenProvider.AddOrUpdateAuthorizationHeader(localVarRequestOptions, $"/api/v1/apps/{appId}/grants/{grantId}", "GET", cancellationToken = default);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<OAuth2ScopeConsentGrant>("/api/v1/apps/{appId}/grants/{grantId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetScopeConsentGrant", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Grant consent to scope Grants consent for the app to request an OAuth 2.0 Okta scope
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="oAuth2ScopeConsentGrant"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OAuth2ScopeConsentGrant</returns>
        public async System.Threading.Tasks.Task<OAuth2ScopeConsentGrant> GrantConsentToScopeAsync(  string appId ,   OAuth2ScopeConsentGrant oAuth2ScopeConsentGrant , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<OAuth2ScopeConsentGrant> localVarResponse = await GrantConsentToScopeWithHttpInfoAsync(appId, oAuth2ScopeConsentGrant, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Grant consent to scope Grants consent for the app to request an OAuth 2.0 Okta scope
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="oAuth2ScopeConsentGrant"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OAuth2ScopeConsentGrant)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<OAuth2ScopeConsentGrant>> GrantConsentToScopeWithHttpInfoAsync(  string appId ,   OAuth2ScopeConsentGrant oAuth2ScopeConsentGrant , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'appId' is set
            if (appId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'appId' when calling ApplicationGrantsApi->GrantConsentToScope");
            }

            // verify the required parameter 'oAuth2ScopeConsentGrant' is set
            if (oAuth2ScopeConsentGrant == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'oAuth2ScopeConsentGrant' when calling ApplicationGrantsApi->GrantConsentToScope");
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

            localVarRequestOptions.PathParameters.Add("appId", Okta.Sdk.Client.ClientUtils.ParameterToString(appId)); // path parameter
            localVarRequestOptions.Data = oAuth2ScopeConsentGrant;

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
                await _oAuthTokenProvider.AddOrUpdateAuthorizationHeader(localVarRequestOptions, $"/api/v1/apps/{appId}/grants", "POST", cancellationToken = default);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<OAuth2ScopeConsentGrant>("/api/v1/apps/{appId}/grants", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GrantConsentToScope", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List all app Grants Lists all scope consent Grants for the app
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="expand">An optional parameter to return scope details in the &#x60;_embedded&#x60; property. Valid value: &#x60;scope&#x60; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;OAuth2ScopeConsentGrant&gt;</returns>
        //a
        public IOktaCollectionClient<OAuth2ScopeConsentGrant> ListScopeConsentGrants(  string appId ,   string expand = default(string) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'appId' is set
            if (appId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'appId' when calling ApplicationGrantsApi->ListScopeConsentGrants");
            }


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

            localVarRequestOptions.PathParameters.Add("appId", Okta.Sdk.Client.ClientUtils.ParameterToString(appId)); // path parameter
            if (expand != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "expand", expand));
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
            
            // If AuthorizationMode is equals to PrivateKey, the authorization header is set in the enumerator for collections.
            
            return new OktaCollectionClient<OAuth2ScopeConsentGrant>(localVarRequestOptions, "/api/v1/apps/{appId}/grants", this.AsynchronousClient, this.Configuration, this._oAuthTokenProvider);
        }
        /// <summary>
        /// List all app Grants Lists all scope consent Grants for the app
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="expand">An optional parameter to return scope details in the &#x60;_embedded&#x60; property. Valid value: &#x60;scope&#x60; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;OAuth2ScopeConsentGrant&gt;)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<List<OAuth2ScopeConsentGrant>>> ListScopeConsentGrantsWithHttpInfoAsync(  string appId ,   string expand = default(string) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'appId' is set
            if (appId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'appId' when calling ApplicationGrantsApi->ListScopeConsentGrants");
            }


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

            localVarRequestOptions.PathParameters.Add("appId", Okta.Sdk.Client.ClientUtils.ParameterToString(appId)); // path parameter
            if (expand != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "expand", expand));
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
            
            // If AuthorizationMode is equals to PrivateKey, the authorization header is set in the enumerator for collections.

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<OAuth2ScopeConsentGrant>>("/api/v1/apps/{appId}/grants", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListScopeConsentGrants", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Revoke an app Grant Revokes permission for the app to grant the given scope
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="grantId">Grant ID</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task RevokeScopeConsentGrantAsync(  string appId ,   string grantId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await RevokeScopeConsentGrantWithHttpInfoAsync(appId, grantId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Revoke an app Grant Revokes permission for the app to grant the given scope
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">Application ID</param>
        /// <param name="grantId">Grant ID</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<Object>> RevokeScopeConsentGrantWithHttpInfoAsync(  string appId ,   string grantId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'appId' is set
            if (appId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'appId' when calling ApplicationGrantsApi->RevokeScopeConsentGrant");
            }

            // verify the required parameter 'grantId' is set
            if (grantId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'grantId' when calling ApplicationGrantsApi->RevokeScopeConsentGrant");
            }


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

            localVarRequestOptions.PathParameters.Add("appId", Okta.Sdk.Client.ClientUtils.ParameterToString(appId)); // path parameter
            localVarRequestOptions.PathParameters.Add("grantId", Okta.Sdk.Client.ClientUtils.ParameterToString(grantId)); // path parameter

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
                await _oAuthTokenProvider.AddOrUpdateAuthorizationHeader(localVarRequestOptions, $"/api/v1/apps/{appId}/grants/{grantId}", "DELETE", cancellationToken = default);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/apps/{appId}/grants/{grantId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RevokeScopeConsentGrant", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
