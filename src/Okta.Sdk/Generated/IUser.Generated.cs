// <copyright file="IUser.Generated.cs" company="Okta, Inc">
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
    public partial interface IUser
    {


        DateTimeOffset? Activated { get; }

        DateTimeOffset? Created { get; }

        UserCredentials Credentials { get; set; }

        string Id { get; }

        DateTimeOffset? LastLogin { get; }

        DateTimeOffset? LastUpdated { get; }

        DateTimeOffset? PasswordChanged { get; }

        UserProfile Profile { get; set; }

        UserStatus Status { get; }

        DateTimeOffset? StatusChanged { get; }

        UserStatus TransitioningToStatus { get; }

        IAsyncEnumerable<AppLink> ListAppLinks(bool? showAll = false, CancellationToken cancellationToken = default(CancellationToken));

        IAsyncEnumerable<Role> ListRoles(string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        Task RemoveRoleAsync(string roleId, CancellationToken cancellationToken = default(CancellationToken));

        IAsyncEnumerable<Group> ListGroupTargetsForRole(string roleId, string after = null, int? limit = -1, CancellationToken cancellationToken = default(CancellationToken));

        Task RemoveGroupTargetFromRoleAsync(string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        Task AddGroupTargetToRoleAsync(string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        IAsyncEnumerable<Group> ListGroups(string after = null, int? limit = -1, CancellationToken cancellationToken = default(CancellationToken));

        Task<UserActivationToken> ActivateAsync(bool? sendEmail, CancellationToken cancellationToken = default(CancellationToken));

        Task DeactivateAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task SuspendAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task UnsuspendAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<ResetPasswordToken> ResetPasswordAsync(string provider = null, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<TempPassword> ExpirePasswordAsync(bool? tempPassword = false, CancellationToken cancellationToken = default(CancellationToken));

        Task UnlockAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task ResetFactorsAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task AddToGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
