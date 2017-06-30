// <copyright file="IGroupRule.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Interface for <see cref="GroupRule"/> resources.</summary>
    public partial interface IGroupRule
    {
        GroupRuleAction Actions { get; set; }

        GroupRuleConditions Conditions { get; set; }

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
