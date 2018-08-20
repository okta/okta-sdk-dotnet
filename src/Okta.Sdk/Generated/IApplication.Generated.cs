// <copyright file="IApplication.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a Application resource in the Okta API.</summary>
    public partial interface IApplication : IResource
    {
        IApplicationAccessibility Accessibility { get; set; }

        DateTimeOffset? Created { get; }

        IApplicationCredentials Credentials { get; set; }

        IList<string> Features { get; set; }

        string Id { get; }

        string Label { get; set; }

        DateTimeOffset? LastUpdated { get; }

        IApplicationLicensing Licensing { get; set; }

        string Name { get; }

        Resource Profile { get; set; }

        IApplicationSettings Settings { get; set; }

        ApplicationSignOnMode SignOnMode { get; set; }

        string Status { get; }

        IApplicationVisibility Visibility { get; set; }

        Task ActivateAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task DeactivateAsync(CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IAppUser> ListApplicationUsers(string q = null, string query_scope = null, string after = null, int? limit = -1, string filter = null, string expand = null);

        Task<IAppUser> AssignUserToApplicationAsync(AppUser appUser, CancellationToken cancellationToken = default(CancellationToken));

        Task<IAppUser> GetApplicationUserAsync(string userId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplicationGroupAssignment> CreateApplicationGroupAssignmentAsync(ApplicationGroupAssignment applicationGroupAssignment, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplicationGroupAssignment> GetApplicationGroupAssignmentAsync(string groupId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<IJsonWebKey> CloneApplicationKeyAsync(string keyId, string targetAid, CancellationToken cancellationToken = default(CancellationToken));

        Task<IJsonWebKey> GetApplicationKeyAsync(string keyId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IApplicationGroupAssignment> ListGroupAssignments(string q = null, string after = null, int? limit = -1, string expand = null);

        ICollectionClient<IJsonWebKey> ListKeys();

    }
}
