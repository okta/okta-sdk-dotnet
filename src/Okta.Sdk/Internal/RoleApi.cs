/*
 * Okta Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 3.0.0
 * Contact: devex-public@okta.com
 */


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
    public partial interface IRoleApiAsync : IApiAccessor
    {
        /// <summary>
        /// Create a Role
        /// </summary>
        /// <remarks>
        /// Creates a new role
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="instance"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of IamRole</returns>
        [Obsolete("This method is obsolete. Use CreateRoleAsync(CreateIamRoleRequest,...) instead.")]
        System.Threading.Tasks.Task<IamRole> CreateRoleAsync(IamRole instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a Role
        /// </summary>
        /// <remarks>
        /// Creates a new role
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="instance"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (IamRole)</returns>
        [Obsolete("This method is obsolete. Use CreateRoleWithHttpInfoAsync(CreateIamRoleRequest,...) instead.")]
        System.Threading.Tasks.Task<ApiResponse<IamRole>> CreateRoleWithHttpInfoAsync(IamRole instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Replace a Role
        /// </summary>
        /// <remarks>
        /// Replaces a role by &#x60;roleIdOrLabel&#x60;
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="roleIdOrLabel">&#x60;id&#x60; or &#x60;label&#x60; of the role</param>
        /// <param name="instance"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of IamRole</returns>
        [Obsolete("This method is obsolete. Use ReplaceRoleAsync(string roleIdOrLabel, UpdateIamRoleRequest,...) instead.")]
        System.Threading.Tasks.Task<IamRole> ReplaceRoleAsync(string roleIdOrLabel, IamRole instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Replace a Role
        /// </summary>
        /// <remarks>
        /// Replaces a role by &#x60;roleIdOrLabel&#x60;
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="roleIdOrLabel">&#x60;id&#x60; or &#x60;label&#x60; of the role</param>
        /// <param name="instance"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (IamRole)</returns>
        [Obsolete("This method is obsolete. Use ReplaceRoleWithHttpInfoAsync(string roleIdOrLabel, UpdateIamRoleRequest,...) instead.")]
        System.Threading.Tasks.Task<ApiResponse<IamRole>> ReplaceRoleWithHttpInfoAsync(string roleIdOrLabel, IamRole instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }

    public partial class RoleApi : IRoleApi
    {
        /// <summary>
        /// Create a Role Creates a new role
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="instance"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of IamRole</returns>
        [Obsolete("This method is obsolete. Use CreateRoleAsync(CreateIamRoleRequest,...) instead.")]
        public async System.Threading.Tasks.Task<IamRole> CreateRoleAsync(IamRole instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<IamRole> localVarResponse = await CreateRoleWithHttpInfoAsync(instance, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a Role Creates a new role
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="instance"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (IamRole)</returns>
        [Obsolete("This method is obsolete. Use CreateRoleWithHttpInfoAsync(CreateIamRoleRequest,...) instead.")]
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<IamRole>> CreateRoleWithHttpInfoAsync(IamRole instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'instance' is set
            if (instance == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'instance' when calling RoleApi->CreateRole");
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<IamRole>("/api/v1/iam/roles", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateRole", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }


        /// <summary>
        /// Replace a Role Replaces a role by &#x60;roleIdOrLabel&#x60;
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="roleIdOrLabel">&#x60;id&#x60; or &#x60;label&#x60; of the role</param>
        /// <param name="instance"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of IamRole</returns>
        [Obsolete("This method is obsolete. Use ReplaceRoleAsync(string roleIdOrLabel, UpdateIamRoleRequest,...) instead.")]
        public async System.Threading.Tasks.Task<IamRole> ReplaceRoleAsync(string roleIdOrLabel, IamRole instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<IamRole> localVarResponse = await ReplaceRoleWithHttpInfoAsync(roleIdOrLabel, instance, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Replace a Role Replaces a role by &#x60;roleIdOrLabel&#x60;
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="roleIdOrLabel">&#x60;id&#x60; or &#x60;label&#x60; of the role</param>
        /// <param name="instance"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (IamRole)</returns>
        [Obsolete("This method is obsolete. Use ReplaceRoleWithHttpInfoAsync(string roleIdOrLabel, UpdateIamRoleRequest,...) instead.")]
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<IamRole>> ReplaceRoleWithHttpInfoAsync(string roleIdOrLabel, IamRole instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'roleIdOrLabel' is set
            if (roleIdOrLabel == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'roleIdOrLabel' when calling RoleApi->ReplaceRole");
            }
            // verify the required parameter 'instance' is set
            if (instance == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'instance' when calling RoleApi->ReplaceRole");
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
            localVarRequestOptions.PathParameters.Add("roleIdOrLabel", Okta.Sdk.Client.ClientUtils.ParameterToString(roleIdOrLabel)); // path parameter
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
            var localVarResponse = await this.AsynchronousClient.PutAsync<IamRole>("/api/v1/iam/roles/{roleIdOrLabel}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReplaceRole", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
    }
}
