// <copyright file="IGroup.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a Group resource in the Okta API.</summary>
    public partial interface IGroup : IResource
    {
        DateTimeOffset? Created { get; }

        string Id { get; }

        DateTimeOffset? LastMembershipUpdated { get; }

        DateTimeOffset? LastUpdated { get; }

        IList<string> ObjectClass { get; }

        IGroupProfile Profile { get; set; }

        string Type { get; }

        Task RemoveUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
