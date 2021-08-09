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
    /// <summary>A client that works with Okta TrustedOrigin resources.</summary>
    public partial interface ITrustedOriginsClient
    {
        /// <summary>
        /// Success
        /// </summary>
        /// <param name="q"></param>
        /// <param name="filter"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="ITrustedOrigin"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<ITrustedOrigin> ListOrigins(string q = null, string filter = null, string after = null, int? limit = -1);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="trustedOrigin">The <see cref="ITrustedOrigin"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ITrustedOrigin"/> response.</returns>
        Task<ITrustedOrigin> CreateOriginAsync(ITrustedOrigin trustedOrigin, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="trustedOriginId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ITrustedOrigin"/> response.</returns>
        Task<ITrustedOrigin> GetOriginAsync(string trustedOriginId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="trustedOrigin">The <see cref="ITrustedOrigin"/> resource.</param>
        /// <param name="trustedOriginId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ITrustedOrigin"/> response.</returns>
        Task<ITrustedOrigin> UpdateOriginAsync(ITrustedOrigin trustedOrigin, string trustedOriginId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="trustedOriginId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteOriginAsync(string trustedOriginId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="trustedOriginId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ITrustedOrigin"/> response.</returns>
        Task<ITrustedOrigin> ActivateOriginAsync(string trustedOriginId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="trustedOriginId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ITrustedOrigin"/> response.</returns>
        Task<ITrustedOrigin> DeactivateOriginAsync(string trustedOriginId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
