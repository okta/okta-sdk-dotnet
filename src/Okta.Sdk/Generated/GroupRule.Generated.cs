// <copyright file="GroupRule.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

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
        public GroupRuleAction Actions
        {
            get => GetResourceProperty<GroupRuleAction>("actions");
            set => this["actions"] = value;
        }

        /// <inheritdoc/>
        public GroupRuleConditions Conditions
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
