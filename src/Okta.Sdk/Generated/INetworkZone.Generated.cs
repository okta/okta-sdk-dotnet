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
        IList<string> Asns { get; set; }

        DateTimeOffset? Created { get; }

        IList<INetworkZoneAddress> Gateways { get; set; }

        string Id { get; }

        DateTimeOffset? LastUpdated { get; }

        IList<INetworkZoneLocation> Locations { get; set; }

        string Name { get; set; }

        IList<INetworkZoneAddress> Proxies { get; set; }

        string ProxyType { get; set; }

        NetworkZoneStatus Status { get; set; }

        bool? System { get; set; }

        NetworkZoneType Type { get; set; }

        NetworkZoneUsage Usage { get; set; }

        Task<INetworkZone> ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<INetworkZone> DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

    }
}
