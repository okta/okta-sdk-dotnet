/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 5.1.0
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
    public partial interface IApplicationSSOApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Preview the application SAML metadata
        /// </summary>
        /// <remarks>
        /// Previews the SSO SAML metadata for an application
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">ID of the Application</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> PreviewSAMLmetadataForApplicationAsync(  string appId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Preview the application SAML metadata
        /// </summary>
        /// <remarks>
        /// Previews the SSO SAML metadata for an application
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">ID of the Application</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> PreviewSAMLmetadataForApplicationWithHttpInfoAsync(  string appId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Preview the application SAML metadata
        /// </summary>
        /// <remarks>
        /// Previews the SSO SAML metadata for an application
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">ID of the Application</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> PreviewSAMLmetadataForApplication_0Async(  string appId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Preview the application SAML metadata
        /// </summary>
        /// <remarks>
        /// Previews the SSO SAML metadata for an application
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">ID of the Application</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> PreviewSAMLmetadataForApplication_0WithHttpInfoAsync(  string appId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial interface IApplicationSSOApi :  IApplicationSSOApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ApplicationSSOApi : IApplicationSSOApi
    {
        private Okta.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        private IOAuthTokenProvider _oAuthTokenProvider;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationSSOApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <param name="oAuthTokenProvider">The access token provider to be used when the AuthorizationMode is equals to Private Key. Optional./param>
        /// <param name="webProxy">The web proxy to be used by the HTTP client. Optional./param>
        /// <returns></returns>
        public ApplicationSSOApi(Okta.Sdk.Client.Configuration configuration = null, IOAuthTokenProvider oAuthTokenProvider = null, WebProxy webProxy = null)
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
        /// Initializes a new instance of the <see cref="ApplicationSSOApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ApplicationSSOApi(Okta.Sdk.Client.IAsynchronousClient asyncClient, Okta.Sdk.Client.IReadableConfiguration configuration)
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
        /// Preview the application SAML metadata Previews the SSO SAML metadata for an application
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">ID of the Application</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of string</returns>
        public async System.Threading.Tasks.Task<string> PreviewSAMLmetadataForApplicationAsync(  string appId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<string> localVarResponse = await PreviewSAMLmetadataForApplicationWithHttpInfoAsync(appId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Preview the application SAML metadata Previews the SSO SAML metadata for an application
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">ID of the Application</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (string)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<string>> PreviewSAMLmetadataForApplicationWithHttpInfoAsync(  string appId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'appId' is set
            if (appId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'appId' when calling ApplicationSSOApi->PreviewSAMLmetadataForApplication");
            }


            Okta.Sdk.Client.RequestOptions localVarRequestOptions = new Okta.Sdk.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "text/xml",
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<string>("/api/v1/apps/${appId}/sso/saml/metadata", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PreviewSAMLmetadataForApplication", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Preview the application SAML metadata Previews the SSO SAML metadata for an application
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">ID of the Application</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of string</returns>
        public async System.Threading.Tasks.Task<string> PreviewSAMLmetadataForApplication_0Async(  string appId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<string> localVarResponse = await PreviewSAMLmetadataForApplication_0WithHttpInfoAsync(appId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Preview the application SAML metadata Previews the SSO SAML metadata for an application
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appId">ID of the Application</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (string)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<string>> PreviewSAMLmetadataForApplication_0WithHttpInfoAsync(  string appId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'appId' is set
            if (appId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'appId' when calling ApplicationSSOApi->PreviewSAMLmetadataForApplication_0");
            }


            Okta.Sdk.Client.RequestOptions localVarRequestOptions = new Okta.Sdk.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "text/xml"
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<string>("/api/v1/apps/{appId}/sso/saml/metadata", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PreviewSAMLmetadataForApplication_0", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
