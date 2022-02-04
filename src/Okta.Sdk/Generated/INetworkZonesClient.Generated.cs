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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface INetworkZonesClient
    {
        /// <summary>
        /// Activate Network Zone Activate Network Zone
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="zoneId"></param>
        ///  <returns>Task of INetworkZone</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<INetworkZone> ActivateNetworkZoneAsync(string zoneId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add Network Zone Adds a new network zone to your Okta organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of INetworkZone</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<INetworkZone> CreateNetworkZoneAsync(INetworkZone body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deactivate Network Zone Deactivates a network zone.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="zoneId"></param>
        ///  <returns>Task of INetworkZone</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<INetworkZone> DeactivateNetworkZoneAsync(string zoneId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete Network Zone Removes network zone.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="zoneId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteNetworkZoneAsync(string zoneId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Network Zone Fetches a network zone from your Okta organization by &#x60;id&#x60;.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="zoneId"></param>
        ///  <returns>Task of INetworkZone</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<INetworkZone> GetNetworkZoneAsync(string zoneId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List Network Zones Enumerates network zones added to your organization with pagination. A subset of zones can be returned that match a supported filter expression or query.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="after">Specifies the pagination cursor for the next page of network zones (optional)</param>
        /// <param name="limit">Specifies the number of results for a page (optional, default to -1)</param>
        /// <param name="filter">Filters zones by usage or id expression (optional)</param>
        /// A collection of <see cref="INetworkZonesClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<INetworkZone> ListNetworkZones(string after = null, int? limit = null, string filter = null);
        /// <summary>
        /// Update Network Zone Updates a network zone in your organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="zoneId"></param>
        ///  <returns>Task of INetworkZone</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<INetworkZone> UpdateNetworkZoneAsync(INetworkZone body, string zoneId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

