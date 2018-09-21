// <copyright file="IPolicyRule.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a PolicyRule resource in the Okta API.</summary>
    public partial interface IPolicyRule : IResource
    {
        DateTimeOffset? Created { get; }

        string Id { get; set; }

        DateTimeOffset? LastUpdated { get; }

        int? Priority { get; set; }

        string Status { get; set; }

        bool? System { get; set; }

        string Type { get; set; }

        Task ActivateAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken));

        Task DeactivateAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
