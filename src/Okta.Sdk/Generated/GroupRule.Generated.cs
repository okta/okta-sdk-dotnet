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
    public sealed partial class GroupRule : Resource, IGroupRule
    {
        public GroupRuleAction Actions
        {
            get => GetResourceProperty<GroupRuleAction>("actions");
            set => this["actions"] = value;
        }

        public GroupRuleConditions Conditions
        {
            get => GetResourceProperty<GroupRuleConditions>("conditions");
            set => this["conditions"] = value;
        }

        public DateTimeOffset? Created => GetDateTimeProperty("created");

        public string Id => GetStringProperty("id");

        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");

        public string Name
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }

        public GroupRuleStatus Status => GetEnumProperty<GroupRuleStatus>("status");

        public string Type
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }


        /// <inheritdoc />
        public Task ActivateAsync(CancellationToken cancellationToken = default(CancellationToken))
            => new GroupClient(GetDataStore()).ActivateRuleAsync(Id, cancellationToken);

        /// <inheritdoc />
        public Task DeactivateAsync(CancellationToken cancellationToken = default(CancellationToken))
            => new GroupClient(GetDataStore()).DeactivateRuleAsync(Id, cancellationToken);
    }
}
