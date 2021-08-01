// <copyright file="IdentityProviderPolicy.Generated.cs" company="Okta, Inc">
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
    public sealed partial class IdentityProviderPolicy : Policy, IIdentityProviderPolicy
    {
        /// <inheritdoc/>
        public IPolicyAccountLink AccountLink 
        {
            get => GetResourceProperty<PolicyAccountLink>("accountLink");
            set => this["accountLink"] = value;
        }
        
        /// <inheritdoc/>
        public int? MaxClockSkew 
        {
            get => GetIntegerProperty("maxClockSkew");
            set => this["maxClockSkew"] = value;
        }
        
        /// <inheritdoc/>
        public IProvisioning Provisioning 
        {
            get => GetResourceProperty<Provisioning>("provisioning");
            set => this["provisioning"] = value;
        }
        
        /// <inheritdoc/>
        public IPolicySubject Subject 
        {
            get => GetResourceProperty<PolicySubject>("subject");
            set => this["subject"] = value;
        }
        
    }
}
