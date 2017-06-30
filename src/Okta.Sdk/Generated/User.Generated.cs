// <copyright file="User.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <summary>Represents a User resource in the Okta API.</summary>
    public sealed partial class User : Resource, IUser
    {
        public User()
            : base(ResourceBehavior.ChangeTracking)
        {
        }


        public DateTimeOffset? Activated => GetDateTimeProperty("activated");

        public DateTimeOffset? Created => GetDateTimeProperty("created");

        public UserCredentials Credentials
        {
            get => GetResourceProperty<UserCredentials>("credentials");
            set => this["credentials"] = value;
        }

        public string Id => GetStringProperty("id");

        public DateTimeOffset? LastLogin => GetDateTimeProperty("lastLogin");

        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");

        public DateTimeOffset? PasswordChanged => GetDateTimeProperty("passwordChanged");

        public UserProfile Profile
        {
            get => GetResourceProperty<UserProfile>("profile");
            set => this["profile"] = value;
        }

        public UserStatus Status => GetEnumProperty<UserStatus>("status");

        public DateTimeOffset? StatusChanged => GetDateTimeProperty("statusChanged");

        public UserStatus TransitioningToStatus => GetEnumProperty<UserStatus>("transitioningToStatus");


        /// <inheritdoc />
        public IAsyncEnumerable<AppLink> ListAppLinks(bool? showAll = false, CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).ListAppLinks(Id, showAll);

        /// <inheritdoc />
        public IAsyncEnumerable<Role> ListRoles(string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).ListAssignedRoles(Id, expand);

        /// <inheritdoc />
        public Task RemoveRoleAsync(string roleId, CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).RemoveRoleFromUserAsync(Id, roleId, cancellationToken);

        /// <inheritdoc />
        public IAsyncEnumerable<Group> ListGroupTargetsForRole(string roleId, string after = null, int? limit = -1, CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).ListGroupTargetsForRole(Id, roleId, after, limit);

        /// <inheritdoc />
        public Task RemoveGroupTargetFromRoleAsync(string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).RemoveGroupTargetFromRoleAsync(Id, roleId, groupId, cancellationToken);

        /// <inheritdoc />
        public Task AddGroupTargetToRoleAsync(string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).AddGroupTargetToRoleAsync(Id, roleId, groupId, cancellationToken);

        /// <inheritdoc />
        public IAsyncEnumerable<Group> ListGroups(string after = null, int? limit = -1, CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).ListUserGroups(Id, after, limit);

        /// <inheritdoc />
        public Task<UserActivationToken> ActivateAsync(bool? sendEmail, CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).ActivateUserAsync(Id, sendEmail, cancellationToken);

        /// <inheritdoc />
        public Task DeactivateAsync(CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).DeactivateUserAsync(Id, cancellationToken);

        /// <inheritdoc />
        public Task SuspendAsync(CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).SuspendUserAsync(Id, cancellationToken);

        /// <inheritdoc />
        public Task UnsuspendAsync(CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).UnsuspendUserAsync(Id, cancellationToken);

        /// <inheritdoc />
        public Task<ResetPasswordToken> ResetPasswordAsync(string provider = null, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).ResetPasswordAsync(Id, provider, sendEmail, cancellationToken);

        /// <inheritdoc />
        public Task<TempPassword> ExpirePasswordAsync(bool? tempPassword = false, CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).ExpirePasswordAsync(Id, tempPassword, cancellationToken);

        /// <inheritdoc />
        public Task UnlockAsync(CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).UnlockUserAsync(Id, cancellationToken);

        /// <inheritdoc />
        public Task ResetFactorsAsync(CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).ResetAllFactorsAsync(Id, cancellationToken);

        /// <inheritdoc />
        public Task AddToGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => new GroupClient(GetDataStore()).AddUserToGroupAsync(groupId, Id, cancellationToken);
    }
}
