// <copyright file="PossessionConstraint.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PossessionConstraint : AccessPolicyConstraint, IPossessionConstraint
    {
        /// <inheritdoc/>
        public string DeviceBound 
        {
            get => GetStringProperty("deviceBound");
            set => this["deviceBound"] = value;
        }
        
        /// <inheritdoc/>
        public string HardwareProtection 
        {
            get => GetStringProperty("hardwareProtection");
            set => this["hardwareProtection"] = value;
        }
        
        /// <inheritdoc/>
        public string PhishingResistant 
        {
            get => GetStringProperty("phishingResistant");
            set => this["phishingResistant"] = value;
        }
        
        /// <inheritdoc/>
        public string UserPresence 
        {
            get => GetStringProperty("userPresence");
            set => this["userPresence"] = value;
        }
        
    }
}
