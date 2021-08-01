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
        RoleAssignmentType AssignmentType { get; set; }

        DateTimeOffset? Created { get; }

        string Description { get; set; }

        string Id { get; }

        string Label { get; }

        DateTimeOffset? LastUpdated { get; }

        RoleStatus Status { get; set; }

        RoleType Type { get; set; }

        Task AddAdminGroupTargetAsync(
            string groupId, string targetGroupId, CancellationToken cancellationToken = default(CancellationToken));

        Task AddAppInstanceTargetToAdminRoleAsync(
            string groupId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken));

        Task AddAppTargetToAdminRoleAsync(
            string groupId, string appName, CancellationToken cancellationToken = default(CancellationToken));

        Task AddAllAppsAsTargetToRoleAsync(
            string userId, CancellationToken cancellationToken = default(CancellationToken));

        Task AddAppTargetToAppAdminRoleForUserAsync(
            string userId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken));

        Task AddAppTargetToAdminRoleForUserAsync(
            string userId, string appName, CancellationToken cancellationToken = default(CancellationToken));

    }
}
