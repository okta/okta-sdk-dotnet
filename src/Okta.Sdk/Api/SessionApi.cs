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
    public partial interface ISessionApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Create a Session with session token
        /// </summary>
        /// <remarks>
        /// Creates a new Session for a user with a valid session token. Use this API if, for example, you want to set the session cookie yourself instead of allowing Okta to set it, or want to hold the session ID to delete a session through the API instead of visiting the logout URL.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createSessionRequest"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Session</returns>
        System.Threading.Tasks.Task<Session> CreateSessionAsync(  CreateSessionRequest createSessionRequest , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create a Session with session token
        /// </summary>
        /// <remarks>
        /// Creates a new Session for a user with a valid session token. Use this API if, for example, you want to set the session cookie yourself instead of allowing Okta to set it, or want to hold the session ID to delete a session through the API instead of visiting the logout URL.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createSessionRequest"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Session)</returns>
        System.Threading.Tasks.Task<ApiResponse<Session>> CreateSessionWithHttpInfoAsync(  CreateSessionRequest createSessionRequest , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve a Session
        /// </summary>
        /// <remarks>
        /// Retrieves information about the Session specified by the given session ID
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">&#x60;id&#x60; of the Session</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Session</returns>
        System.Threading.Tasks.Task<Session> GetSessionAsync(  string sessionId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve a Session
        /// </summary>
        /// <remarks>
        /// Retrieves information about the Session specified by the given session ID
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">&#x60;id&#x60; of the Session</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Session)</returns>
        System.Threading.Tasks.Task<ApiResponse<Session>> GetSessionWithHttpInfoAsync(  string sessionId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Refresh a Session
        /// </summary>
        /// <remarks>
        /// Refreshes an existing Session using the &#x60;id&#x60; for that Session. A successful response contains the refreshed Session with an updated &#x60;expiresAt&#x60; timestamp.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">&#x60;id&#x60; of the Session</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Session</returns>
        System.Threading.Tasks.Task<Session> RefreshSessionAsync(  string sessionId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Refresh a Session
        /// </summary>
        /// <remarks>
        /// Refreshes an existing Session using the &#x60;id&#x60; for that Session. A successful response contains the refreshed Session with an updated &#x60;expiresAt&#x60; timestamp.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">&#x60;id&#x60; of the Session</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Session)</returns>
        System.Threading.Tasks.Task<ApiResponse<Session>> RefreshSessionWithHttpInfoAsync(  string sessionId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Revoke a Session
        /// </summary>
        /// <remarks>
        /// Revokes the specified Session
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">&#x60;id&#x60; of the Session</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task RevokeSessionAsync(  string sessionId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Revoke a Session
        /// </summary>
        /// <remarks>
        /// Revokes the specified Session
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">&#x60;id&#x60; of the Session</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> RevokeSessionWithHttpInfoAsync(  string sessionId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial interface ISessionApi :  ISessionApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class SessionApi : ISessionApi
    {
        private Okta.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        private IOAuthTokenProvider _oAuthTokenProvider;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <param name="oAuthTokenProvider">The access token provider to be used when the AuthorizationMode is equals to Private Key. Optional./param>
        /// <param name="webProxy">The web proxy to be used by the HTTP client. Optional./param>
        /// <returns></returns>
        public SessionApi(Okta.Sdk.Client.Configuration configuration = null, IOAuthTokenProvider oAuthTokenProvider = null, WebProxy webProxy = null)
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
        /// Initializes a new instance of the <see cref="SessionApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public SessionApi(Okta.Sdk.Client.IAsynchronousClient asyncClient, Okta.Sdk.Client.IReadableConfiguration configuration)
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
        /// Create a Session with session token Creates a new Session for a user with a valid session token. Use this API if, for example, you want to set the session cookie yourself instead of allowing Okta to set it, or want to hold the session ID to delete a session through the API instead of visiting the logout URL.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createSessionRequest"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Session</returns>
        public async System.Threading.Tasks.Task<Session> CreateSessionAsync(  CreateSessionRequest createSessionRequest , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<Session> localVarResponse = await CreateSessionWithHttpInfoAsync(createSessionRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Create a Session with session token Creates a new Session for a user with a valid session token. Use this API if, for example, you want to set the session cookie yourself instead of allowing Okta to set it, or want to hold the session ID to delete a session through the API instead of visiting the logout URL.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createSessionRequest"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Session)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<Session>> CreateSessionWithHttpInfoAsync(  CreateSessionRequest createSessionRequest , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'createSessionRequest' is set
            if (createSessionRequest == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'createSessionRequest' when calling SessionApi->CreateSession");
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

            localVarRequestOptions.Data = createSessionRequest;

            // authentication (apiToken) required
            if (Sdk.Client.Configuration.IsSswsMode(this.Configuration) && !string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Session>("/api/v1/sessions", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateSession", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve a Session Retrieves information about the Session specified by the given session ID
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">&#x60;id&#x60; of the Session</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Session</returns>
        public async System.Threading.Tasks.Task<Session> GetSessionAsync(  string sessionId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<Session> localVarResponse = await GetSessionWithHttpInfoAsync(sessionId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Retrieve a Session Retrieves information about the Session specified by the given session ID
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">&#x60;id&#x60; of the Session</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Session)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<Session>> GetSessionWithHttpInfoAsync(  string sessionId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'sessionId' is set
            if (sessionId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'sessionId' when calling SessionApi->GetSession");
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

            localVarRequestOptions.PathParameters.Add("sessionId", Okta.Sdk.Client.ClientUtils.ParameterToString(sessionId)); // path parameter

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
                await _oAuthTokenProvider.AddOrUpdateAuthorizationHeader(localVarRequestOptions, $"/api/v1/sessions/{sessionId}", "GET", cancellationToken = default);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Session>("/api/v1/sessions/{sessionId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSession", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Refresh a Session Refreshes an existing Session using the &#x60;id&#x60; for that Session. A successful response contains the refreshed Session with an updated &#x60;expiresAt&#x60; timestamp.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">&#x60;id&#x60; of the Session</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Session</returns>
        public async System.Threading.Tasks.Task<Session> RefreshSessionAsync(  string sessionId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<Session> localVarResponse = await RefreshSessionWithHttpInfoAsync(sessionId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Refresh a Session Refreshes an existing Session using the &#x60;id&#x60; for that Session. A successful response contains the refreshed Session with an updated &#x60;expiresAt&#x60; timestamp.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">&#x60;id&#x60; of the Session</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Session)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<Session>> RefreshSessionWithHttpInfoAsync(  string sessionId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'sessionId' is set
            if (sessionId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'sessionId' when calling SessionApi->RefreshSession");
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

            localVarRequestOptions.PathParameters.Add("sessionId", Okta.Sdk.Client.ClientUtils.ParameterToString(sessionId)); // path parameter

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
                await _oAuthTokenProvider.AddOrUpdateAuthorizationHeader(localVarRequestOptions, $"/api/v1/sessions/{sessionId}/lifecycle/refresh", "POST", cancellationToken = default);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Session>("/api/v1/sessions/{sessionId}/lifecycle/refresh", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RefreshSession", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Revoke a Session Revokes the specified Session
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">&#x60;id&#x60; of the Session</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task RevokeSessionAsync(  string sessionId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await RevokeSessionWithHttpInfoAsync(sessionId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Revoke a Session Revokes the specified Session
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId">&#x60;id&#x60; of the Session</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<Object>> RevokeSessionWithHttpInfoAsync(  string sessionId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'sessionId' is set
            if (sessionId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'sessionId' when calling SessionApi->RevokeSession");
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

            localVarRequestOptions.PathParameters.Add("sessionId", Okta.Sdk.Client.ClientUtils.ParameterToString(sessionId)); // path parameter

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
                await _oAuthTokenProvider.AddOrUpdateAuthorizationHeader(localVarRequestOptions, $"/api/v1/sessions/{sessionId}", "DELETE", cancellationToken = default);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/sessions/{sessionId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RevokeSession", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
