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
        private readonly IOAuthTokenProvider _customTokenProvider;
        private string _bearerToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalTokenProvider"/> class.
        /// </summary>
        /// <param name="bearerToken">The token.</param>
        /// <param name="tokenProvider">Optional custom token provider.</param>
        public ExternalTokenProvider(string bearerToken, IOAuthTokenProvider tokenProvider)
        {
            if (string.IsNullOrEmpty(bearerToken) && tokenProvider == default)
            {
                throw new ArgumentException("The token is not set.", nameof(bearerToken));
            }

            _bearerToken = bearerToken;
            _customTokenProvider = tokenProvider;
        }

        /// <inheritdoc/>
        public async Task<string> GetAccessTokenAsync(bool forceRenew = false)
        {
            if (forceRenew || string.IsNullOrEmpty(_bearerToken))
            {
                if (_customTokenProvider != null)
                {
                    _bearerToken = await _customTokenProvider.GetAccessTokenAsync(forceRenew).ConfigureAwait(false);
                }
                else
                {
                    _bearerToken = string.Empty;
                }
            }

            return _bearerToken;
        }
    }
}
