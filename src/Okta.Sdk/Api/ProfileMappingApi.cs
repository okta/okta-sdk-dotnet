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
    public partial interface IProfileMappingApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Retrieve a Profile Mapping
        /// </summary>
        /// <remarks>
        /// Retrieves a single Profile Mapping referenced by its ID
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mappingId">&#x60;id&#x60; of the Mapping</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ProfileMapping</returns>
        System.Threading.Tasks.Task<ProfileMapping> GetProfileMappingAsync(  string mappingId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve a Profile Mapping
        /// </summary>
        /// <remarks>
        /// Retrieves a single Profile Mapping referenced by its ID
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mappingId">&#x60;id&#x60; of the Mapping</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ProfileMapping)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProfileMapping>> GetProfileMappingWithHttpInfoAsync(  string mappingId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List all Profile Mappings
        /// </summary>
        /// <remarks>
        /// Lists all profile mappings in your organization with [pagination](https://developer.okta.com/docs/api/#pagination). You can return a subset of profile mappings that match a supported &#x60;sourceId&#x60; and/or &#x60;targetId&#x60;. The results are [paginated](/#pagination) according to the limit parameter. If there are multiple pages of results, the Link header contains a &#x60;next&#x60; link that should be treated as an opaque value (follow it, don&#39;t parse it).  The response is a collection of profile mappings that include a subset of the profile mapping object&#39;s parameters. The profile mapping object describes the properties mapping between an Okta User and an App User Profile using [JSON Schema Draft 4](https://datatracker.ietf.org/doc/html/draft-zyp-json-schema-04).
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="after">Mapping &#x60;id&#x60; that specifies the pagination cursor for the next page of mappings (optional)</param>
        /// <param name="limit">Specifies the number of results per page (maximum 200) (optional, default to 20)</param>
        /// <param name="sourceId">The UserType or App Instance &#x60;id&#x60; that acts as the source of expressions in a mapping. If this parameter is included, all returned mappings have this as their &#x60;source.id&#x60;. (optional)</param>
        /// <param name="targetId">The UserType or App Instance &#x60;id&#x60; that acts as the target of expressions in a mapping. If this parameter is included, all returned mappings have this as their &#x60;target.id&#x60;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;ListProfileMappings&gt;</returns>
        IOktaCollectionClient<ListProfileMappings> ListProfileMappings(  string after = default(string) ,   int? limit = default(int?) ,   string sourceId = default(string) ,   string targetId = default(string) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List all Profile Mappings
        /// </summary>
        /// <remarks>
        /// Lists all profile mappings in your organization with [pagination](https://developer.okta.com/docs/api/#pagination). You can return a subset of profile mappings that match a supported &#x60;sourceId&#x60; and/or &#x60;targetId&#x60;. The results are [paginated](/#pagination) according to the limit parameter. If there are multiple pages of results, the Link header contains a &#x60;next&#x60; link that should be treated as an opaque value (follow it, don&#39;t parse it).  The response is a collection of profile mappings that include a subset of the profile mapping object&#39;s parameters. The profile mapping object describes the properties mapping between an Okta User and an App User Profile using [JSON Schema Draft 4](https://datatracker.ietf.org/doc/html/draft-zyp-json-schema-04).
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="after">Mapping &#x60;id&#x60; that specifies the pagination cursor for the next page of mappings (optional)</param>
        /// <param name="limit">Specifies the number of results per page (maximum 200) (optional, default to 20)</param>
        /// <param name="sourceId">The UserType or App Instance &#x60;id&#x60; that acts as the source of expressions in a mapping. If this parameter is included, all returned mappings have this as their &#x60;source.id&#x60;. (optional)</param>
        /// <param name="targetId">The UserType or App Instance &#x60;id&#x60; that acts as the target of expressions in a mapping. If this parameter is included, all returned mappings have this as their &#x60;target.id&#x60;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;ListProfileMappings&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<ListProfileMappings>>> ListProfileMappingsWithHttpInfoAsync(  string after = default(string) ,   int? limit = default(int?) ,   string sourceId = default(string) ,   string targetId = default(string) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a Profile Mapping
        /// </summary>
        /// <remarks>
        /// Updates an existing profile mapping by adding, updating, or removing one or many property mappings
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mappingId">&#x60;id&#x60; of the Mapping</param>
        /// <param name="profileMapping"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ProfileMapping</returns>
        System.Threading.Tasks.Task<ProfileMapping> UpdateProfileMappingAsync(  string mappingId ,   ProfileMappingRequest profileMapping , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a Profile Mapping
        /// </summary>
        /// <remarks>
        /// Updates an existing profile mapping by adding, updating, or removing one or many property mappings
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mappingId">&#x60;id&#x60; of the Mapping</param>
        /// <param name="profileMapping"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ProfileMapping)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProfileMapping>> UpdateProfileMappingWithHttpInfoAsync(  string mappingId ,   ProfileMappingRequest profileMapping , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial interface IProfileMappingApi :  IProfileMappingApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ProfileMappingApi : IProfileMappingApi
    {
        private Okta.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        private IOAuthTokenProvider _oAuthTokenProvider;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileMappingApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <param name="oAuthTokenProvider">The access token provider to be used when the AuthorizationMode is equals to Private Key. Optional./param>
        /// <param name="webProxy">The web proxy to be used by the HTTP client. Optional./param>
        /// <returns></returns>
        public ProfileMappingApi(Okta.Sdk.Client.Configuration configuration = null, IOAuthTokenProvider oAuthTokenProvider = null, WebProxy webProxy = null)
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
        /// Initializes a new instance of the <see cref="ProfileMappingApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ProfileMappingApi(Okta.Sdk.Client.IAsynchronousClient asyncClient, Okta.Sdk.Client.IReadableConfiguration configuration)
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
        /// Retrieve a Profile Mapping Retrieves a single Profile Mapping referenced by its ID
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mappingId">&#x60;id&#x60; of the Mapping</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ProfileMapping</returns>
        public async System.Threading.Tasks.Task<ProfileMapping> GetProfileMappingAsync(  string mappingId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<ProfileMapping> localVarResponse = await GetProfileMappingWithHttpInfoAsync(mappingId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Retrieve a Profile Mapping Retrieves a single Profile Mapping referenced by its ID
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mappingId">&#x60;id&#x60; of the Mapping</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ProfileMapping)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<ProfileMapping>> GetProfileMappingWithHttpInfoAsync(  string mappingId , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'mappingId' is set
            if (mappingId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'mappingId' when calling ProfileMappingApi->GetProfileMapping");
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

            localVarRequestOptions.PathParameters.Add("mappingId", Okta.Sdk.Client.ClientUtils.ParameterToString(mappingId)); // path parameter

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
                await _oAuthTokenProvider.AddOrUpdateAuthorizationHeader(localVarRequestOptions, $"/api/v1/mappings/{mappingId}", "GET", cancellationToken = default);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ProfileMapping>("/api/v1/mappings/{mappingId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetProfileMapping", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List all Profile Mappings Lists all profile mappings in your organization with [pagination](https://developer.okta.com/docs/api/#pagination). You can return a subset of profile mappings that match a supported &#x60;sourceId&#x60; and/or &#x60;targetId&#x60;. The results are [paginated](/#pagination) according to the limit parameter. If there are multiple pages of results, the Link header contains a &#x60;next&#x60; link that should be treated as an opaque value (follow it, don&#39;t parse it).  The response is a collection of profile mappings that include a subset of the profile mapping object&#39;s parameters. The profile mapping object describes the properties mapping between an Okta User and an App User Profile using [JSON Schema Draft 4](https://datatracker.ietf.org/doc/html/draft-zyp-json-schema-04).
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="after">Mapping &#x60;id&#x60; that specifies the pagination cursor for the next page of mappings (optional)</param>
        /// <param name="limit">Specifies the number of results per page (maximum 200) (optional, default to 20)</param>
        /// <param name="sourceId">The UserType or App Instance &#x60;id&#x60; that acts as the source of expressions in a mapping. If this parameter is included, all returned mappings have this as their &#x60;source.id&#x60;. (optional)</param>
        /// <param name="targetId">The UserType or App Instance &#x60;id&#x60; that acts as the target of expressions in a mapping. If this parameter is included, all returned mappings have this as their &#x60;target.id&#x60;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;ListProfileMappings&gt;</returns>
        //a
        public IOktaCollectionClient<ListProfileMappings> ListProfileMappings(  string after = default(string) ,   int? limit = default(int?) ,   string sourceId = default(string) ,   string targetId = default(string) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (after != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "after", after));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (sourceId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "sourceId", sourceId));
            }
            if (targetId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "targetId", targetId));
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
            
            return new OktaCollectionClient<ListProfileMappings>(localVarRequestOptions, "/api/v1/mappings", this.AsynchronousClient, this.Configuration, this._oAuthTokenProvider);
        }
        /// <summary>
        /// List all Profile Mappings Lists all profile mappings in your organization with [pagination](https://developer.okta.com/docs/api/#pagination). You can return a subset of profile mappings that match a supported &#x60;sourceId&#x60; and/or &#x60;targetId&#x60;. The results are [paginated](/#pagination) according to the limit parameter. If there are multiple pages of results, the Link header contains a &#x60;next&#x60; link that should be treated as an opaque value (follow it, don&#39;t parse it).  The response is a collection of profile mappings that include a subset of the profile mapping object&#39;s parameters. The profile mapping object describes the properties mapping between an Okta User and an App User Profile using [JSON Schema Draft 4](https://datatracker.ietf.org/doc/html/draft-zyp-json-schema-04).
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="after">Mapping &#x60;id&#x60; that specifies the pagination cursor for the next page of mappings (optional)</param>
        /// <param name="limit">Specifies the number of results per page (maximum 200) (optional, default to 20)</param>
        /// <param name="sourceId">The UserType or App Instance &#x60;id&#x60; that acts as the source of expressions in a mapping. If this parameter is included, all returned mappings have this as their &#x60;source.id&#x60;. (optional)</param>
        /// <param name="targetId">The UserType or App Instance &#x60;id&#x60; that acts as the target of expressions in a mapping. If this parameter is included, all returned mappings have this as their &#x60;target.id&#x60;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;ListProfileMappings&gt;)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<List<ListProfileMappings>>> ListProfileMappingsWithHttpInfoAsync(  string after = default(string) ,   int? limit = default(int?) ,   string sourceId = default(string) ,   string targetId = default(string) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (after != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "after", after));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (sourceId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "sourceId", sourceId));
            }
            if (targetId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "targetId", targetId));
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<ListProfileMappings>>("/api/v1/mappings", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListProfileMappings", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a Profile Mapping Updates an existing profile mapping by adding, updating, or removing one or many property mappings
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mappingId">&#x60;id&#x60; of the Mapping</param>
        /// <param name="profileMapping"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ProfileMapping</returns>
        public async System.Threading.Tasks.Task<ProfileMapping> UpdateProfileMappingAsync(  string mappingId ,   ProfileMappingRequest profileMapping , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<ProfileMapping> localVarResponse = await UpdateProfileMappingWithHttpInfoAsync(mappingId, profileMapping, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Update a Profile Mapping Updates an existing profile mapping by adding, updating, or removing one or many property mappings
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mappingId">&#x60;id&#x60; of the Mapping</param>
        /// <param name="profileMapping"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ProfileMapping)</returns>
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<ProfileMapping>> UpdateProfileMappingWithHttpInfoAsync(  string mappingId ,   ProfileMappingRequest profileMapping , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'mappingId' is set
            if (mappingId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'mappingId' when calling ProfileMappingApi->UpdateProfileMapping");
            }

            // verify the required parameter 'profileMapping' is set
            if (profileMapping == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'profileMapping' when calling ProfileMappingApi->UpdateProfileMapping");
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

            localVarRequestOptions.PathParameters.Add("mappingId", Okta.Sdk.Client.ClientUtils.ParameterToString(mappingId)); // path parameter
            localVarRequestOptions.Data = profileMapping;

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
                await _oAuthTokenProvider.AddOrUpdateAuthorizationHeader(localVarRequestOptions, $"/api/v1/mappings/{mappingId}", "POST", cancellationToken = default);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<ProfileMapping>("/api/v1/mappings/{mappingId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateProfileMapping", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
