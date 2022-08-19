// <copyright file="DefaultOAuthTokenProvider.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Api;
using Polly;
using RestSharp;


namespace Okta.Sdk.Client
{
    /// <summary>
    /// Default OAuth token provider.
    /// </summary>
    public class DefaultOAuthTokenProvider : IOAuthTokenProvider
    {
        private Configuration Configuration { get; }

        private OAuthTokenResponse _oAuthTokenResponse;

        private OAuthApi _oauthApi;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultOAuthTokenProvider"/> class.
        /// </summary>
        /// <param name="configuration">The Okta configuration.</param>
        public DefaultOAuthTokenProvider(Configuration configuration)
        {
            Configuration = configuration;
            _oauthApi = new OAuthApi(configuration);
        }

        /// <inheritdoc/>
        public async Task<string> GetAccessTokenAsync(bool forceRenew = false, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(_oAuthTokenResponse?.AccessToken) || forceRenew)
            {
                _oAuthTokenResponse = await RequestAccessTokenAsync(cancellationToken).ConfigureAwait(false);
            }

            return _oAuthTokenResponse.AccessToken;
        }

        /// <summary>
        /// Gets the policy for retrying requests when the OAuth token has expired.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="onRetryAsyncFunc">The method to call before retrying a request</param>
        /// <returns></returns>
        public static Polly.AsyncPolicy<IRestResponse> GetOAuthRetryPolicy(IReadableConfiguration configuration,
            Func<DelegateResult<IRestResponse>, int, Context, Task> onRetryAsyncFunc = null)
        {
            AsyncPolicy<IRestResponse> retryAsyncPolicy = Policy
                .Handle<ApiException>(ex => ex.ErrorCode == 401)
                .OrResult<IRestResponse>(r => (int)r.StatusCode == 401)
                .RetryAsync(1, onRetry: (response, retryCount, context) => OnOAuthRetryAsync(response, retryCount, context, onRetryAsyncFunc));

            return retryAsyncPolicy;
        }

        private static void AddToContext(Context context, string key, object value)
        {
            if (context.Any(x =>
                    String.Equals(x.Key, key, StringComparison.InvariantCultureIgnoreCase)))
            {
                context.Remove(key);
            }

            context.Add(key, value);
        }

        private static Task OnOAuthRetryAsync(DelegateResult<IRestResponse> response, int retryCount, Context context, Func<DelegateResult<IRestResponse>, int, Context, Task> onRetryAsyncFunc = null)
        {
            // TODO: Get a new token and add it to the header
            //var token =  

            if (onRetryAsyncFunc != null)
            {
                onRetryAsyncFunc(response, retryCount, context);
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Requests an access token
        /// </summary>
        /// <returns>The access token.</returns>
        private async Task<OAuthTokenResponse> RequestAccessTokenAsync(CancellationToken cancellationToken = default) =>
            await _oauthApi.GetBearerTokenAsync(cancellationToken);
    }
}
