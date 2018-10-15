// <copyright file="IPolicy.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a Policy resource in the Okta API.</summary>
    public partial interface IPolicy : IResource
    {
        DateTimeOffset? Created { get; }

        string Description { get; set; }

        string Id { get; }

        DateTimeOffset? LastUpdated { get; }

        string Name { get; set; }

        int? Priority { get; set; }

        string Status { get; set; }

        bool? System { get; set; }

        PolicyType Type { get; set; }

        Task ActivateAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task DeactivateAsync(CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IPolicyRule> ListPolicyRules();

        Task<IPolicyRule> CreateRuleAsync(PolicyRule policyRule, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken));

        Task<IPolicyRule> GetPolicyRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
