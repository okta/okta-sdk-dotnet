// <copyright file="IAppUser.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a AppUser resource in the Okta API.</summary>
    public partial interface IAppUser : IResource
    {
        DateTimeOffset? Created { get; }

        IAppUserCredentials Credentials { get; set; }

        string ExternalId { get; }

        string Id { get; set; }

        DateTimeOffset? LastSync { get; }

        DateTimeOffset? LastUpdated { get; }

        DateTimeOffset? PasswordChanged { get; }

        Resource Profile { get; set; }

        string Scope { get; set; }

        string Status { get; }

        DateTimeOffset? StatusChanged { get; }

        string SyncState { get; }

    }
}
