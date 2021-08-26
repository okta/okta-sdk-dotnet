// <copyright file="NetworkZone.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class NetworkZone : Resource, INetworkZone
    {
        /// <inheritdoc/>
        public IList<string> Asns 
        {
            get => GetArrayProperty<string>("asns");
            set => this["asns"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public IList<INetworkZoneAddress> Gateways 
        {
            get => GetArrayProperty<INetworkZoneAddress>("gateways");
            set => this["gateways"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public IList<INetworkZoneLocation> Locations 
        {
            get => GetArrayProperty<INetworkZoneLocation>("locations");
            set => this["locations"] = value;
        }
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public IList<INetworkZoneAddress> Proxies 
        {
            get => GetArrayProperty<INetworkZoneAddress>("proxies");
            set => this["proxies"] = value;
        }
        
        /// <inheritdoc/>
        public string ProxyType 
        {
            get => GetStringProperty("proxyType");
            set => this["proxyType"] = value;
        }
        
        /// <inheritdoc/>
        public NetworkZoneStatus Status 
        {
            get => GetEnumProperty<NetworkZoneStatus>("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc/>
        public bool? System 
        {
            get => GetBooleanProperty("system");
            set => this["system"] = value;
        }
        
        /// <inheritdoc/>
        public NetworkZoneType Type 
        {
            get => GetEnumProperty<NetworkZoneType>("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc/>
        public NetworkZoneUsage Usage 
        {
            get => GetEnumProperty<NetworkZoneUsage>("usage");
            set => this["usage"] = value;
        }
        
        /// <inheritdoc />
        public Task<INetworkZone> ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().NetworkZones.ActivateNetworkZoneAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<INetworkZone> DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().NetworkZones.DeactivateNetworkZoneAsync(Id, cancellationToken);
        
    }
}
