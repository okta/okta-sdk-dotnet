// <copyright file="ExternalTokenProvider.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading.Tasks;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// External Token Provider.
    /// </summary>
    public class ExternalTokenProvider : IOAuthTokenProvider
    {
        private readonly Func<Task<string>> _tokenProviderFunc;
        private string _accessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalTokenProvider"/> class.
        /// </summary>
        /// <param name="accessToken">The token.</param>
        /// <param name="tokenProviderFunc">Optional token provider function.</param>
        public ExternalTokenProvider(string accessToken, Func<Task<string>> tokenProviderFunc)
        {
            if (string.IsNullOrEmpty(accessToken) && tokenProviderFunc == null)
            {
                throw new ArgumentException("The token is not set.", nameof(accessToken));
            }

            _accessToken = accessToken;
            _tokenProviderFunc = tokenProviderFunc;
        }

        /// <inheritdoc/>
        public async Task<string> GetAccessTokenAsync(bool forceRenew = false)
        {
            if (forceRenew || string.IsNullOrEmpty(_accessToken))
            {
                if (_tokenProviderFunc != null)
                {
                    _accessToken = await _tokenProviderFunc.Invoke().ConfigureAwait(false);
                }
                else
                {
                    _accessToken = string.Empty;
                }
            }

            return _accessToken;
        }
    }
}
