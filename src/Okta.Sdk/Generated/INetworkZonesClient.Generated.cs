// <copyright file="INetworkZonesClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta NetworkZone resources.</summary>
    public partial interface INetworkZonesClient
    {
        /// <summary>
        /// Enumerates network zones added to your organization with pagination. A subset of zones can be returned that match a supported filter expression or query.
        /// </summary>
        /// <param name="after">Specifies the pagination cursor for the next page of network zones</param>
        /// <param name="limit">Specifies the number of results for a page</param>
        /// <param name="filter">Filters zones by usage or id expression</param>
        /// <returns>A collection of <see cref="INetworkZone"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<INetworkZone> ListNetworkZones(string after = null, int? limit = -1, string filter = null);

        /// <summary>
        /// Adds a new network zone to your Okta organization.
        /// </summary>
        /// <param name="networkZone">The <see cref="INetworkZone"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="INetworkZone"/> response.</returns>
        Task<INetworkZone> CreateNetworkZoneAsync(INetworkZone networkZone, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes network zone.
        /// </summary>
        /// <param name="zoneId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteNetworkZoneAsync(string zoneId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches a network zone from your Okta organization by `id`.
        /// </summary>
        /// <param name="zoneId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="INetworkZone"/> response.</returns>
        Task<INetworkZone> GetNetworkZoneAsync(string zoneId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a network zone in your organization.
        /// </summary>
        /// <param name="networkZone">The <see cref="INetworkZone"/> resource.</param>
        /// <param name="zoneId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="INetworkZone"/> response.</returns>
        Task<INetworkZone> UpdateNetworkZoneAsync(INetworkZone networkZone, string zoneId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Activate Network Zone
        /// </summary>
        /// <param name="zoneId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="INetworkZone"/> response.</returns>
        Task<INetworkZone> ActivateNetworkZoneAsync(string zoneId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivates a network zone.
        /// </summary>
        /// <param name="zoneId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="INetworkZone"/> response.</returns>
        Task<INetworkZone> DeactivateNetworkZoneAsync(string zoneId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
