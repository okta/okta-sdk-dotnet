
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
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Okta.Sdk.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial interface IPolicyApiAsync : IApiAccessor
    {
        /// <summary>
        /// Create a Policy
        /// </summary>
        /// <remarks>
        /// Creates a policy
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="policy"></param>
        /// <param name="activate"> (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Policy</returns>
        System.Threading.Tasks.Task<Policy> CreatePolicyAsync(Policy policy, bool? activate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create a Policy
        /// </summary>
        /// <remarks>
        /// Creates a policy
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="policy"></param>
        /// <param name="activate"> (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Policy)</returns>
        System.Threading.Tasks.Task<ApiResponse<Policy>> CreatePolicyWithHttpInfoAsync(Policy policy, bool? activate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Replace a Policy
        /// </summary>
        /// <remarks>
        /// Replaces the properties of a Policy identified by &#x60;policyId&#x60;
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="policyId">&#x60;id&#x60; of the Policy</param>
        /// <param name="policy"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Policy</returns>
        System.Threading.Tasks.Task<Policy> ReplacePolicyAsync(string policyId, Policy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Replace a Policy
        /// </summary>
        /// <remarks>
        /// Replaces the properties of a Policy identified by &#x60;policyId&#x60;
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="policyId">&#x60;id&#x60; of the Policy</param>
        /// <param name="policy"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Policy)</returns>
        System.Threading.Tasks.Task<ApiResponse<Policy>> ReplacePolicyWithHttpInfoAsync(string policyId, Policy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial interface IPolicyApi :  IPolicyApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class PolicyApi : IPolicyApi
    {
        /// <summary>
        /// Replace a Policy Replaces the properties of a Policy identified by &#x60;policyId&#x60;
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="policyId">&#x60;id&#x60; of the Policy</param>
        /// <param name="policy"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Policy</returns>
        [Obsolete("This method is deprecated and will be removed in the next major version.Use ReplacePolicyAsync(string policyId, PolicyCanBeCreatedOrReplaced policy ..)")]
        public async System.Threading.Tasks.Task<Policy> ReplacePolicyAsync(string policyId, Policy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<Policy> localVarResponse = await ReplacePolicyWithHttpInfoAsync(policyId, policy, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Replace a Policy Replaces the properties of a Policy identified by &#x60;policyId&#x60;
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="policyId">&#x60;id&#x60; of the Policy</param>
        /// <param name="policy"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Policy)</returns>
        [Obsolete("This method is deprecated and will be removed in the next major version.Use ReplacePolicyWithHttpInfoAsync(string policyId, PolicyCanBeCreatedOrReplaced policy ..)")]
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<Policy>> ReplacePolicyWithHttpInfoAsync(string policyId, Policy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'policyId' is set
            if (policyId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'policyId' when calling PolicyApi->ReplacePolicy");
            }

            // verify the required parameter 'policy' is set
            if (policy == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'policy' when calling PolicyApi->ReplacePolicy");
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

            localVarRequestOptions.PathParameters.Add("policyId", Okta.Sdk.Client.ClientUtils.ParameterToString(policyId)); // path parameter
            localVarRequestOptions.Data = policy;

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
                await _oAuthTokenProvider.AddOrUpdateAuthorizationHeader(localVarRequestOptions, $"/api/v1/policies/{policyId}", "PUT", cancellationToken = default);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<Policy>("/api/v1/policies/{policyId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReplacePolicy", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a Policy Creates a policy
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="policy"></param>
        /// <param name="activate"> (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Policy</returns>
        [Obsolete("This method is deprecated and will be removed in the next major version.Use PolicyAsync(PolicyCanBeCreatedOrReplaced policy ..)")]
        public async System.Threading.Tasks.Task<Policy> CreatePolicyAsync(Policy policy, bool? activate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<Policy> localVarResponse = await CreatePolicyWithHttpInfoAsync(policy, activate, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }
        /// <summary>
        /// Create a Policy Creates a policy
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="policy"></param>
        /// <param name="activate"> (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Policy)</returns>
        [Obsolete("This method is deprecated and will be removed in the next major version.Use CreatePolicyWithHttpInfoAsync(PolicyCanBeCreatedOrReplaced policy ..)")]
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<Policy>> CreatePolicyWithHttpInfoAsync(Policy policy, bool? activate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'policy' is set
            if (policy == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'policy' when calling PolicyApi->CreatePolicy");
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

            if (activate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "activate", activate));
            }
            localVarRequestOptions.Data = policy;

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
                await _oAuthTokenProvider.AddOrUpdateAuthorizationHeader(localVarRequestOptions, $"/api/v1/policies", "POST", cancellationToken = default);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Policy>("/api/v1/policies", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreatePolicy", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }


    }
}
