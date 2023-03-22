using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk.Api
{
    public partial interface IUserApiAsync : IApiAccessor
    {
        /// <summary>
        /// Replace a User
        /// </summary>
        /// <remarks>
        /// Update a user&#39;s profile and/or credentials using strict-update semantics.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <param name="strict"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of User</returns>
        [Obsolete("This method is obsolete. Use UpdateUserAsync(string userId, User user,...) instead.")]
        System.Threading.Tasks.Task<User> UpdateUserAsync(string userId, UpdateUserRequest user, bool? strict = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Replace a User
        /// </summary>
        /// <remarks>
        /// Update a user&#39;s profile and/or credentials using strict-update semantics.
        /// </remarks>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <param name="strict"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (User)</returns>
        [Obsolete("This method is obsolete. Use UpdateUserWithHttpInfoAsync(string userId, User user,...) instead.")]
        System.Threading.Tasks.Task<ApiResponse<User>> UpdateUserWithHttpInfoAsync(string userId, UpdateUserRequest user, bool? strict = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }


    public partial class UserApi : IUserApi 
    {
        /// <summary>
        /// Replace a User Update a user&#39;s profile and/or credentials using strict-update semantics.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <param name="strict"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of User</returns>
        [Obsolete("This method is obsolete. Use UpdateUserAsync(string userId, User user,...) instead.")]
        public async System.Threading.Tasks.Task<User> UpdateUserAsync(string userId, UpdateUserRequest user, bool? strict = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Okta.Sdk.Client.ApiResponse<User> localVarResponse = await UpdateUserWithHttpInfoAsync(userId, user, strict, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Replace a User Update a user&#39;s profile and/or credentials using strict-update semantics.
        /// </summary>
        /// <exception cref="Okta.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <param name="strict"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (User)</returns>
        [Obsolete("This method is obsolete. Use UpdateUserWithHttpInfoAsync(string userId, User user,...) instead.")]
        public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<User>> UpdateUserWithHttpInfoAsync(string userId, UpdateUserRequest user, bool? strict = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'userId' when calling UserApi->UpdateUser");
            }

            // verify the required parameter 'user' is set
            if (user == null)
            {
                throw new Okta.Sdk.Client.ApiException(400, "Missing required parameter 'user' when calling UserApi->UpdateUser");
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

            localVarRequestOptions.PathParameters.Add("userId", Okta.Sdk.Client.ClientUtils.ParameterToString(userId)); // path parameter
            if (strict != null)
            {
                localVarRequestOptions.QueryParameters.Add(Okta.Sdk.Client.ClientUtils.ParameterToMultiMap("", "strict", strict));
            }
            localVarRequestOptions.Data = user;

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
            var localVarResponse = await this.AsynchronousClient.PutAsync<User>("/api/v1/users/{userId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateUser", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }
    }
}
