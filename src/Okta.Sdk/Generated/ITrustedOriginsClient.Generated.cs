// <copyright file="ITrustedOriginsClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface ITrustedOriginsClient
    {
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="trustedOriginId"></param>
        ///  <returns>Task of ITrustedOrigin</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ITrustedOrigin> ActivateOriginAsync(string trustedOriginId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of ITrustedOrigin</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ITrustedOrigin> CreateOriginAsync(ITrustedOrigin body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="trustedOriginId"></param>
        ///  <returns>Task of ITrustedOrigin</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ITrustedOrigin> DeactivateOriginAsync(string trustedOriginId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="trustedOriginId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteOriginAsync(string trustedOriginId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="trustedOriginId"></param>
        ///  <returns>Task of ITrustedOrigin</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ITrustedOrigin> GetOriginAsync(string trustedOriginId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="q"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to -1)</param>
        /// A collection of <see cref="ITrustedOriginsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<ITrustedOrigin> ListOrigins(string q = null, string filter = null, string after = null, int? limit = null);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="trustedOriginId"></param>
        ///  <returns>Task of ITrustedOrigin</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ITrustedOrigin> UpdateOriginAsync(ITrustedOrigin body, string trustedOriginId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

