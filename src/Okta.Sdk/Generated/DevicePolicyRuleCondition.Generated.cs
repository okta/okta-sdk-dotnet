// <copyright file="DevicePolicyRuleCondition.Generated.cs" company="Okta, Inc">
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
    public sealed partial class DevicePolicyRuleCondition : Resource, IDevicePolicyRuleCondition
    {
        /// <inheritdoc/>
        public bool? Migrated 
        {
            get => GetBooleanProperty("migrated");
            set => this["migrated"] = value;
        }
        
        /// <inheritdoc/>
        public IDevicePolicyRuleConditionPlatform Platform 
        {
            get => GetResourceProperty<DevicePolicyRuleConditionPlatform>("platform");
            set => this["platform"] = value;
        }
        
        /// <inheritdoc/>
        public bool? Rooted 
        {
            get => GetBooleanProperty("rooted");
            set => this["rooted"] = value;
        }
        
        /// <inheritdoc/>
        public string TrustLevel 
        {
            get => GetStringProperty("trustLevel");
            set => this["trustLevel"] = value;
        }
        
    }
}
