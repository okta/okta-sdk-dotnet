// <copyright file="IAuthenticatorsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta Authenticator resources.</summary>
    public partial interface IAuthenticatorsClient
    {
        /// <summary>
        /// Success
        /// </summary>
        /// <returns>A collection of <see cref="IAuthenticator"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IAuthenticator> ListAuthenticators();

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authenticatorId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAuthenticator"/> response.</returns>
        Task<IAuthenticator> GetAuthenticatorAsync(string authenticatorId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authenticatorId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task ActivateAuthenticatorAsync(string authenticatorId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authenticatorId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeactivateAuthenticatorAsync(string authenticatorId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
