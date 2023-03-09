using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Okta.Sdk.Api
{
    public partial interface IResourceSetApiAsync : IApiAccessor
    {
        /// <summary>
        /// Create a Resource Set
        /// </summary>
        /// <remarks>
        /// Creates a new resource set
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="instance"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceSet</returns>
        [Obsolete("This method is obsolete and will be removed in the next major release. Use CreateResourceSetAsync(CreateResourceSetRequest instance...)")]
        System.Threading.Tasks.Task<ResourceSet> CreateResourceSetAsync(ResourceSet instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create a Resource Set
        /// </summary>
        /// <remarks>
        /// Creates a new resource set
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="instance"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceSet)</returns>
        [Obsolete("This method is obsolete and will be removed in the next major release. Use CreateResourceSetWithHttpInfoAsync(CreateResourceSetRequest instance...)")]
        System.Threading.Tasks.Task<ApiResponse<ResourceSet>> CreateResourceSetWithHttpInfoAsync(ResourceSet instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }

    public partial class ResourceSetApi : IResourceSetApi
    {
        /// <summary>
        /// Create a Resource Set Creates a new resource set
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="instance"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceSet</returns>
        [Obsolete("This method is obsolete and will be removed in the next major release. Use CreateResourceSetAsync(CreateResourceSetRequest instance...)")]
        public async System.Threading.Tasks.Task<ResourceSet> CreateResourceSetAsync(ResourceSet instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<ResourceSet> localVarResponse = await CreateResourceSetWithHttpInfoAsync(instance, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Create a Resource Set Creates a new resource set
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="instance"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceSet)</returns>
        [Obsolete("This method is obsolete and will be removed in the next major release. Use CreateResourceSetWithHttpInfoAsync(CreateResourceSetRequest instance...)")]
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<ResourceSet>> CreateResourceSetWithHttpInfoAsync(ResourceSet instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'instance' is set
            if (instance == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'instance' when calling ResourceSetApi->CreateResourceSet");
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

            localVarRequestOptions.Data = instance;

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
            var localVarResponse = await this.AsynchronousClient.PostAsync<ResourceSet>("/api/v1/iam/resource-sets", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateResourceSet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }
    }
}
