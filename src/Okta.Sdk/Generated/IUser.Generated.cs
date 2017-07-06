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
    /// <summary>Represents a User resource in the Okta API.</summary>
    public partial interface IUser : IResource
    {


        DateTimeOffset? Activated { get; }

        DateTimeOffset? Created { get; }

        IUserCredentials Credentials { get; set; }

        string Id { get; }

        DateTimeOffset? LastLogin { get; }

        DateTimeOffset? LastUpdated { get; }

        DateTimeOffset? PasswordChanged { get; }

        IUserProfile Profile { get; set; }

        UserStatus Status { get; }

        DateTimeOffset? StatusChanged { get; }

        UserStatus TransitioningToStatus { get; }

        Task RemoveRoleAsync(string roleId, CancellationToken cancellationToken = default(CancellationToken));

        Task RemoveGroupTargetFromRoleAsync(string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        Task AddGroupTargetToRoleAsync(string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IUserActivationToken> ActivateAsync(bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken));

        Task DeactivateAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task SuspendAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task UnsuspendAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<ITempPassword> ExpirePasswordAsync(bool? tempPassword = false, CancellationToken cancellationToken = default(CancellationToken));

        Task UnlockAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task ResetFactorsAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task AddToGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
