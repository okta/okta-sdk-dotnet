// <copyright file="ProvisioningConnectionProfile.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ProvisioningConnectionProfile : Resource, IProvisioningConnectionProfile
    {
        /// <inheritdoc/>
        public ProvisioningConnectionAuthScheme AuthScheme 
        {
            get => GetEnumProperty<ProvisioningConnectionAuthScheme>("authScheme");
            set => this["authScheme"] = value;
        }
        
        /// <inheritdoc/>
        public string Token 
        {
            get => GetStringProperty("token");
            set => this["token"] = value;
        }
        
        /// <inheritdoc />
        public Task<IProvisioningConnection> SetDefaultProvisioningConnectionForApplicationAsync(IProvisioningConnectionRequest profile, 
            string appId, bool? activate = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.SetDefaultProvisioningConnectionForApplicationAsync(profile, appId, activate, cancellationToken);
        
    }
}
