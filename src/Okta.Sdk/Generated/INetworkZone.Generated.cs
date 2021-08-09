// <copyright file="INetworkZone.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a NetworkZone resource in the Okta API.</summary>
    public partial interface INetworkZone : IResource
    {
        NetworkZoneType Type { get; set; }

        string Id { get; }

        string Name { get; set; }

        bool? System { get; set; }

        NetworkZoneUsage Usage { get; set; }

        NetworkZoneStatus Status { get; set; }

        string ProxyType { get; set; }

        IList<INetworkZoneLocation> Locations { get; set; }

        IList<INetworkZoneAddress> Gateways { get; set; }

        IList<INetworkZoneAddress> Proxies { get; set; }

        IList<string> Asns { get; set; }

        DateTimeOffset? Created { get; }

        DateTimeOffset? LastUpdated { get; }

        Task<INetworkZone> ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<INetworkZone> DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

    }
}
