// <copyright file="NullOAuthTokenProvider.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;

namespace Okta.Sdk.Internal
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
        public Task<string> GetAccessTokenAsync(bool forceRenew = false)
        {
            return new Task<string>(null);
        }
    }
}
