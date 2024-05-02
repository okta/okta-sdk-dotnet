﻿/*
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
    public interface IOAuthApiAsync : IApiAccessor
    {
        #region Asynchronous Operations

        /// <summary>
        /// Retrieve the UI Layout for an Application
        /// </summary>
        /// <remarks>
        /// Takes an Application name as an input parameter and retrieves the App Instance page Layout for that Application.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appName"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApplicationLayout</returns>
        System.Threading.Tasks.Task<OAuthTokenResponse> GetBearerTokenAsync(
            System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Retrieve the UI Layout for an Application
        /// </summary>
        /// <remarks>
        /// Takes an Application name as an input parameter and retrieves the App Instance page Layout for that Application.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="appName"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApplicationLayout)</returns>
        System.Threading.Tasks.Task<ApiResponse<OAuthTokenResponse>> GetBearerTokenWithHttpInfoAsync(
            System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        #endregion
    }


    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IOAuthApi : IOAuthApiAsync
{

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class OAuthApi : IOAuthApi
    {
        private Okta.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        private IJwtGenerator _jwtGenerator;
        private IDpopProofJwtGenerator _dpopProofJwtGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public OAuthApi(Okta.Sdk.Client.Configuration configuration = null, IJwtGenerator jwtGenerator = null, IDpopProofJwtGenerator dpopProofJwtGenerator = null)
        {
            configuration = Sdk.Client.Configuration.GetConfigurationOrDefault(configuration);

            this.Configuration = Okta.Sdk.Client.Configuration.MergeConfigurations(
                Okta.Sdk.Client.GlobalConfiguration.Instance,
                configuration
            );
            
            Sdk.Client.Configuration.Validate((Configuration)this.Configuration);
            this.AsynchronousClient = new Okta.Sdk.Client.ApiClient(this.Configuration.OktaDomain, NullOAuthTokenProvider.Instance);
            ExceptionFactory = Okta.Sdk.Client.Configuration.DefaultExceptionFactory;
            _jwtGenerator = jwtGenerator ?? new DefaultJwtGenerator(Configuration);
            _dpopProofJwtGenerator = dpopProofJwtGenerator ?? new DefaultDpopProofJwtGenerator(this.Configuration);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public OAuthApi(Okta.Sdk.Client.IAsynchronousClient asyncClient, Okta.Sdk.Client.IReadableConfiguration configuration, IJwtGenerator jwtGenerator)
        {
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Okta.Sdk.Client.Configuration.DefaultExceptionFactory;
            _jwtGenerator = jwtGenerator;
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

        public async Task<OAuthTokenResponse> GetBearerTokenAsync(CancellationToken cancellationToken = default)
        {
            Okta.Sdk.Client.ApiResponse<OAuthTokenResponse> localVarResponse = await GetBearerTokenWithHttpInfoAsync(cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
    

        public async Task<ApiResponse<OAuthTokenResponse>> GetBearerTokenWithHttpInfoAsync(CancellationToken cancellationToken = default)
        {
            Okta.Sdk.Client.RequestOptions localVarRequestOptions = new Okta.Sdk.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/x-www-form-urlencoded"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            _dpopProofJwtGenerator.RotateKeys();
            var jwtSecurityToken = _jwtGenerator.GenerateSignedJWT();
            var scopes = string.Join("+", Configuration.Scopes);
            var accessTokenUri = "/oauth2/v1/token";
            //?grant_type=client_credentials
            //&scope={scopes}
            //&client_assertion_type=urn:ietf:params:oauth:client-assertion-type:jwt-bearer
            //&client_assertion={jwtSecurityToken.ToString()}";
            localVarRequestOptions.FormParameters.Add("grant_type", "client_credentials");
            localVarRequestOptions.FormParameters.Add("scope", scopes);
            localVarRequestOptions.FormParameters.Add("client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer");
            localVarRequestOptions.FormParameters.Add("client_assertion", jwtSecurityToken.ToString());

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
            
            var dpopJwt = _dpopProofJwtGenerator.GenerateJWT();
            localVarRequestOptions.HeaderParameters.Add("DPoP", dpopJwt);
            
            var localVarResponse = await this.AsynchronousClient.PostAsync<OAuthTokenResponse>(accessTokenUri.Trim(), localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (localVarResponse.StatusCode == HttpStatusCode.BadRequest 
                && localVarResponse.Data.Error == "use_dpop_nonce"
                && localVarResponse.Headers.TryGetValue("dpop-nonce", out var header))
            {
                var nonce = header.FirstOrDefault();
                dpopJwt = _dpopProofJwtGenerator.GenerateJWT(nonce);
                jwtSecurityToken = _jwtGenerator.GenerateSignedJWT();
                
                localVarRequestOptions.FormParameters.Remove("client_assertion");
                localVarRequestOptions.FormParameters.Add("client_assertion", jwtSecurityToken.ToString());

                localVarRequestOptions.HeaderParameters["DPoP"].Clear();
                localVarRequestOptions.HeaderParameters["DPoP"].Add(dpopJwt);

                localVarResponse = await this.AsynchronousClient.PostAsync<OAuthTokenResponse>(accessTokenUri.Trim(), localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            }

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetBearerToken", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }
    }
}
