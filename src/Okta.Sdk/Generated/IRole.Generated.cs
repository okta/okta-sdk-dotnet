// <copyright file="IRole.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a Role resource in the Okta API.</summary>
    public partial interface IRole : IResource
    {
        DateTimeOffset? Created { get; }

        string Description { get; set; }

        string Id { get; }

        string Label { get; }

        DateTimeOffset? LastUpdated { get; }

        RoleStatus Status { get; }

        string Type { get; set; }

    }
}
