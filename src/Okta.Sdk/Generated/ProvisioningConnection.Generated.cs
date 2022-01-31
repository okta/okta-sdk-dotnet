// <copyright file="ProvisioningConnection.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ProvisioningConnection : Resource, IProvisioningConnection
    {
        /// <inheritdoc/>
        public ProvisioningConnectionAuthScheme AuthScheme 
        {
            get => GetEnumProperty<ProvisioningConnectionAuthScheme>("authScheme");
            set => this["authScheme"] = value;
        }
        
        /// <inheritdoc/>
        public ProvisioningConnectionStatus Status 
        {
            get => GetEnumProperty<ProvisioningConnectionStatus>("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc />
        public Task<IProvisioningConnection> GetDefaultProvisioningConnectionForApplicationAsync(
            string appId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GetDefaultProvisioningConnectionForApplicationAsync(appId, cancellationToken);
        
        /// <inheritdoc />
        public Task ActivateDefaultProvisioningConnectionForApplicationAsync(
            string appId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.ActivateDefaultProvisioningConnectionForApplicationAsync(appId, cancellationToken);
        
        /// <inheritdoc />
        public Task DeactivateDefaultProvisioningConnectionForApplicationAsync(
            string appId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.DeactivateDefaultProvisioningConnectionForApplicationAsync(appId, cancellationToken);
        
    }
}
