// <copyright file="IdentityProviderApplicationUser.Generated.cs" company="Okta, Inc">
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
    public sealed partial class IdentityProviderApplicationUser : Resource, IIdentityProviderApplicationUser
    {
        /// <inheritdoc/>
        public string Created 
        {
            get => GetStringProperty("created");
            set => this["created"] = value;
        }
        
        /// <inheritdoc/>
        public string ExternalId 
        {
            get => GetStringProperty("externalId");
            set => this["externalId"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public string LastUpdated 
        {
            get => GetStringProperty("lastUpdated");
            set => this["lastUpdated"] = value;
        }
        
        /// <inheritdoc/>
        public Resource Profile 
        {
            get => GetResourceProperty<Resource>("profile");
            set => this["profile"] = value;
        }
        
    }
}
