// <copyright file="Provisioning.Generated.cs" company="Okta, Inc">
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
    public sealed partial class Provisioning : Resource, IProvisioning
    {
        /// <inheritdoc/>
        public string Action 
        {
            get => GetStringProperty("action");
            set => this["action"] = value;
        }
        
        /// <inheritdoc/>
        public IProvisioningConditions Conditions 
        {
            get => GetResourceProperty<ProvisioningConditions>("conditions");
            set => this["conditions"] = value;
        }
        
        /// <inheritdoc/>
        public IProvisioningGroups Groups 
        {
            get => GetResourceProperty<ProvisioningGroups>("groups");
            set => this["groups"] = value;
        }
        
        /// <inheritdoc/>
        public bool? ProfileMaster 
        {
            get => GetBooleanProperty("profileMaster");
            set => this["profileMaster"] = value;
        }
        
    }
}
