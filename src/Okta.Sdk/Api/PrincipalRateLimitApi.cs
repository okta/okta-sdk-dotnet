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
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Okta.Sdk.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IPrincipalRateLimitApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Create a Principal Rate Limit
        /// </summary>
        /// <remarks>
        /// Adds a new Principal Rate Limit entity to your organization. In the current release, we only allow one Principal Rate Limit entity per org and principal.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="entity"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PrincipalRateLimitEntity</returns>
        System.Threading.Tasks.Task<PrincipalRateLimitEntity> CreatePrincipalRateLimitEntityAsync(PrincipalRateLimitEntity entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create a Principal Rate Limit
        /// </summary>
        /// <remarks>
        /// Adds a new Principal Rate Limit entity to your organization. In the current release, we only allow one Principal Rate Limit entity per org and principal.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="entity"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PrincipalRateLimitEntity)</returns>
        System.Threading.Tasks.Task<ApiResponse<PrincipalRateLimitEntity>> CreatePrincipalRateLimitEntityWithHttpInfoAsync(PrincipalRateLimitEntity entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve a Principal Rate Limit
        /// </summary>
        /// <remarks>
        /// Fetches a Principal Rate Limit entity by &#x60;principalRateLimitId&#x60;.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="principalRateLimitId">id of the Principal Rate Limit</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PrincipalRateLimitEntity</returns>
        System.Threading.Tasks.Task<PrincipalRateLimitEntity> GetPrincipalRateLimitEntityAsync(string principalRateLimitId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve a Principal Rate Limit
        /// </summary>
        /// <remarks>
        /// Fetches a Principal Rate Limit entity by &#x60;principalRateLimitId&#x60;.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="principalRateLimitId">id of the Principal Rate Limit</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PrincipalRateLimitEntity)</returns>
        System.Threading.Tasks.Task<ApiResponse<PrincipalRateLimitEntity>> GetPrincipalRateLimitEntityWithHttpInfoAsync(string principalRateLimitId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List all Principal Rate Limits
        /// </summary>
        /// <remarks>
        /// Lists all Principal Rate Limit entities considering the provided parameters.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filter"> (optional)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;PrincipalRateLimitEntity&gt;</returns>
        IOktaCollectionClient<PrincipalRateLimitEntity> ListPrincipalRateLimitEntities(string filter = default(string), string after = default(string), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List all Principal Rate Limits
        /// </summary>
        /// <remarks>
        /// Lists all Principal Rate Limit entities considering the provided parameters.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filter"> (optional)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;PrincipalRateLimitEntity&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<PrincipalRateLimitEntity>>> ListPrincipalRateLimitEntitiesWithHttpInfoAsync(string filter = default(string), string after = default(string), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Replace a Principal Rate Limit
        /// </summary>
        /// <remarks>
        /// Update a  Principal Rate Limit entity by &#x60;principalRateLimitId&#x60;.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="principalRateLimitId">id of the Principal Rate Limit</param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PrincipalRateLimitEntity</returns>
        System.Threading.Tasks.Task<PrincipalRateLimitEntity> UpdatePrincipalRateLimitEntityAsync(string principalRateLimitId, PrincipalRateLimitEntity entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Replace a Principal Rate Limit
        /// </summary>
        /// <remarks>
        /// Update a  Principal Rate Limit entity by &#x60;principalRateLimitId&#x60;.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="principalRateLimitId">id of the Principal Rate Limit</param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PrincipalRateLimitEntity)</returns>
        System.Threading.Tasks.Task<ApiResponse<PrincipalRateLimitEntity>> UpdatePrincipalRateLimitEntityWithHttpInfoAsync(string principalRateLimitId, PrincipalRateLimitEntity entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IPrincipalRateLimitApi :  IPrincipalRateLimitApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class PrincipalRateLimitApi : IPrincipalRateLimitApi
    {
        private Okta.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrincipalRateLimitApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public PrincipalRateLimitApi(Okta.Sdk.Client.Configuration configuration = null)
        {
            configuration = Sdk.Client.Configuration.GetConfigurationOrDefault(configuration);

            this.Configuration = Okta.Sdk.Client.Configuration.MergeConfigurations(
                Okta.Sdk.Client.GlobalConfiguration.Instance,
                configuration
            );
            
            Sdk.Client.Configuration.Validate((Configuration)this.Configuration);
            this.AsynchronousClient = new Okta.Sdk.Client.ApiClient(this.Configuration.OktaDomain);
            ExceptionFactory = Okta.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrincipalRateLimitApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public PrincipalRateLimitApi(Okta.Sdk.Client.IAsynchronousClient asyncClient, Okta.Sdk.Client.IReadableConfiguration configuration)
        {
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Okta.Sdk.Client.Configuration.DefaultExceptionFactory;
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
        /// Create a Principal Rate Limit Adds a new Principal Rate Limit entity to your organization. In the current release, we only allow one Principal Rate Limit entity per org and principal.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="entity"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PrincipalRateLimitEntity</returns>
        public async System.Threading.Tasks.Task<PrincipalRateLimitEntity> CreatePrincipalRateLimitEntityAsync(PrincipalRateLimitEntity entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<PrincipalRateLimitEntity> localVarResponse = await CreatePrincipalRateLimitEntityWithHttpInfoAsync(entity, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Create a Principal Rate Limit Adds a new Principal Rate Limit entity to your organization. In the current release, we only allow one Principal Rate Limit entity per org and principal.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="entity"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PrincipalRateLimitEntity)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<PrincipalRateLimitEntity>> CreatePrincipalRateLimitEntityWithHttpInfoAsync(PrincipalRateLimitEntity entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'entity' is set
            if (entity == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'entity' when calling PrincipalRateLimitApi->CreatePrincipalRateLimitEntity");
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

            localVarRequestOptions.Data = entity;

            // authentication (API_Token) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }
            // authentication (OAuth_2.0) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<PrincipalRateLimitEntity>("/api/v1/principal-rate-limits", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreatePrincipalRateLimitEntity", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve a Principal Rate Limit Fetches a Principal Rate Limit entity by &#x60;principalRateLimitId&#x60;.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="principalRateLimitId">id of the Principal Rate Limit</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PrincipalRateLimitEntity</returns>
        public async System.Threading.Tasks.Task<PrincipalRateLimitEntity> GetPrincipalRateLimitEntityAsync(string principalRateLimitId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<PrincipalRateLimitEntity> localVarResponse = await GetPrincipalRateLimitEntityWithHttpInfoAsync(principalRateLimitId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Retrieve a Principal Rate Limit Fetches a Principal Rate Limit entity by &#x60;principalRateLimitId&#x60;.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="principalRateLimitId">id of the Principal Rate Limit</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PrincipalRateLimitEntity)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<PrincipalRateLimitEntity>> GetPrincipalRateLimitEntityWithHttpInfoAsync(string principalRateLimitId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'principalRateLimitId' is set
            if (principalRateLimitId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'principalRateLimitId' when calling PrincipalRateLimitApi->GetPrincipalRateLimitEntity");
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

            localVarRequestOptions.PathParameters.Add("principalRateLimitId", Okta.Sdk.Client.ClientUtils.ParameterToString(principalRateLimitId)); // path parameter

            // authentication (API_Token) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }
            // authentication (OAuth_2.0) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<PrincipalRateLimitEntity>("/api/v1/principal-rate-limits/{principalRateLimitId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetPrincipalRateLimitEntity", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List all Principal Rate Limits Lists all Principal Rate Limit entities considering the provided parameters.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filter"> (optional)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;PrincipalRateLimitEntity&gt;</returns>
        public IOktaCollectionClient<PrincipalRateLimitEntity> ListPrincipalRateLimitEntities(string filter = default(string), string after = default(string), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (after != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "after", after));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            // authentication (API_Token) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }
            // authentication (OAuth_2.0) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            
            return new OktaCollectionClient<PrincipalRateLimitEntity>(localVarRequestOptions, "/api/v1/principal-rate-limits", this.AsynchronousClient);
        }
        /// <summary>
        /// List all Principal Rate Limits Lists all Principal Rate Limit entities considering the provided parameters.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filter"> (optional)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;PrincipalRateLimitEntity&gt;)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<List<PrincipalRateLimitEntity>>> ListPrincipalRateLimitEntitiesWithHttpInfoAsync(string filter = default(string), string after = default(string), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (after != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "after", after));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            // authentication (API_Token) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }
            // authentication (OAuth_2.0) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<PrincipalRateLimitEntity>>("/api/v1/principal-rate-limits", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListPrincipalRateLimitEntities", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Replace a Principal Rate Limit Update a  Principal Rate Limit entity by &#x60;principalRateLimitId&#x60;.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="principalRateLimitId">id of the Principal Rate Limit</param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PrincipalRateLimitEntity</returns>
        public async System.Threading.Tasks.Task<PrincipalRateLimitEntity> UpdatePrincipalRateLimitEntityAsync(string principalRateLimitId, PrincipalRateLimitEntity entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<PrincipalRateLimitEntity> localVarResponse = await UpdatePrincipalRateLimitEntityWithHttpInfoAsync(principalRateLimitId, entity, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Replace a Principal Rate Limit Update a  Principal Rate Limit entity by &#x60;principalRateLimitId&#x60;.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="principalRateLimitId">id of the Principal Rate Limit</param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PrincipalRateLimitEntity)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<PrincipalRateLimitEntity>> UpdatePrincipalRateLimitEntityWithHttpInfoAsync(string principalRateLimitId, PrincipalRateLimitEntity entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'principalRateLimitId' is set
            if (principalRateLimitId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'principalRateLimitId' when calling PrincipalRateLimitApi->UpdatePrincipalRateLimitEntity");
            }

            // verify the required parameter 'entity' is set
            if (entity == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'entity' when calling PrincipalRateLimitApi->UpdatePrincipalRateLimitEntity");
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

            localVarRequestOptions.PathParameters.Add("principalRateLimitId", Okta.Sdk.Client.ClientUtils.ParameterToString(principalRateLimitId)); // path parameter
            localVarRequestOptions.Data = entity;

            // authentication (API_Token) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }
            // authentication (OAuth_2.0) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<PrincipalRateLimitEntity>("/api/v1/principal-rate-limits/{principalRateLimitId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdatePrincipalRateLimitEntity", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
