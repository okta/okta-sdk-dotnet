// <copyright file="IOAuthTokenProvider.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using Polly;
using RestSharp;

namespace Okta.Sdk.Client
{
    /// <summary>
    /// Interface for OAuth token providers.
    /// </summary>
    public interface IOAuthTokenProvider
    {
        /// <summary>
        /// Gets an access token.
        /// </summary>
        /// <returns>The access token.</returns>
        /// <param name="forceRenew">The flag to indicate if the access token should be renewed.</param>
        Task<string> GetAccessTokenAsync(bool forceRenew = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the OAuth policy to get a new access token after expiration.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="onRetryAsyncFunc"></param>
        /// <returns></returns>
        Polly.AsyncPolicy<IRestResponse> GetOAuthRetryPolicy(Func<DelegateResult<IRestResponse>, int, Context, Task> onRetryAsyncFunc = null);
    }
}
