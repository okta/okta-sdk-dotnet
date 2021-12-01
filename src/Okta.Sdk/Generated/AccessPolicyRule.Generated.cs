// <copyright file="AccessPolicyRule.Generated.cs" company="Okta, Inc">
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
    public sealed partial class AccessPolicyRule : PolicyRule, IAccessPolicyRule
    {
        /// <inheritdoc/>
        public IAccessPolicyRuleActions Actions 
        {
            get => GetResourceProperty<AccessPolicyRuleActions>("actions");
            set => this["actions"] = value;
        }
        
        /// <inheritdoc/>
        public IAccessPolicyRuleConditions Conditions 
        {
            get => GetResourceProperty<AccessPolicyRuleConditions>("conditions");
            set => this["conditions"] = value;
        }
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
    }
}
