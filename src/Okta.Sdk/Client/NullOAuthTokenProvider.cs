// <copyright file="NullOAuthTokenProvider.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Polly;
using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;
using Polly.NoOp;

namespace Okta.Sdk.Client
{
    /// <summary>
    /// Null OAuth Token Provider.
    /// </summary>
    public class NullOAuthTokenProvider : IOAuthTokenProvider
    {
        private static NullOAuthTokenProvider _instance = null;

        private NullOAuthTokenProvider()
        {
        }

        /// <summary>
        /// Gets a new <c>NullOAuthTokenProvider</c> instance.
        /// </summary>
        public static IOAuthTokenProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NullOAuthTokenProvider();
                }

                return _instance;
            }
        }

        /// <inheritdoc/>
        public Task<string> GetAccessTokenAsync(bool forceRenew = false, CancellationToken cancellationToken = default)
        {
            return Task.FromResult<string>(null);
        }

        /// <inheritdoc/>
        public AsyncPolicy<IRestResponse> GetOAuthRetryPolicy(Func<DelegateResult<IRestResponse>, int, Context, Task> onRetryAsyncFunc = null)
        {
            return Policy.NoOpAsync<IRestResponse>();
        }
    }
}
