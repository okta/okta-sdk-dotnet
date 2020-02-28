// <copyright file="IOAuthTokenProvider.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;

namespace Okta.Sdk.Internal
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
        Task<string> GetAccessTokenAsync(bool forceRenew = false);
    }
}
