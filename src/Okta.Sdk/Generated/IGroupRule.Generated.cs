// <copyright file="IGroupRule.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Represents a GroupRule resource in the Okta API.</summary>
    public partial interface IGroupRule : IResource
    {
        IGroupRuleAction Actions { get; set; }

        bool? AllGroupsValid { get; set; }

        IGroupRuleConditions Conditions { get; set; }

        DateTimeOffset? Created { get; }

        string Id { get; }

        DateTimeOffset? LastUpdated { get; }

        string Name { get; set; }

        GroupRuleStatus Status { get; }

        string Type { get; set; }

        Task ActivateAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task DeactivateAsync(CancellationToken cancellationToken = default(CancellationToken));

    }
}
