// <copyright file="PolicyRule.Generated.cs" company="Okta, Inc">
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
    public partial class PolicyRule : Resource, IPolicyRule
    {
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string Id 
        {
            get => GetStringProperty("id");
            set => this["id"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public int? Priority 
        {
            get => GetIntegerProperty("priority");
            set => this["priority"] = value;
        }
        
        /// <inheritdoc/>
        public string Status 
        {
            get => GetStringProperty("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc/>
        public bool? System 
        {
            get => GetBooleanProperty("system");
            set => this["system"] = value;
        }
        
        /// <inheritdoc/>
        public string Type 
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc />
        public Task ActivateAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Policies.ActivatePolicyRuleAsync(policyId, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task DeactivateAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Policies.DeactivatePolicyRuleAsync(policyId, Id, cancellationToken);
        
    }
}
