// <copyright file="GroupRule.Generated.cs" company="Okta, Inc">
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
    public sealed partial class GroupRule : Resource, IGroupRule
    {
        /// <inheritdoc/>
        public IGroupRuleAction Actions 
        {
            get => GetResourceProperty<GroupRuleAction>("actions");
            set => this["actions"] = value;
        }
        
        /// <inheritdoc/>
        public bool? AllGroupsValid 
        {
            get => GetBooleanProperty("allGroupsValid");
            set => this["allGroupsValid"] = value;
        }
        
        /// <inheritdoc/>
        public IGroupRuleConditions Conditions 
        {
            get => GetResourceProperty<GroupRuleConditions>("conditions");
            set => this["conditions"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public GroupRuleStatus Status => GetEnumProperty<GroupRuleStatus>("status");
        
        /// <inheritdoc/>
        public string Type 
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc />
        public Task ActivateAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.ActivateRuleAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task DeactivateAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.DeactivateRuleAsync(Id, cancellationToken);
        
    }
}
