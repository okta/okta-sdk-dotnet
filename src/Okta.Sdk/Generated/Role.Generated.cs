// <copyright file="Role.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class Role : Resource, IRole
    {
        /// <inheritdoc/>
        public RoleAssignmentType AssignmentType 
        {
            get => GetEnumProperty<RoleAssignmentType>("assignmentType");
            set => this["assignmentType"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string Description 
        {
            get => GetStringProperty("description");
            set => this["description"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public string Label => GetStringProperty("label");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public RoleStatus Status => GetEnumProperty<RoleStatus>("status");
        
        /// <inheritdoc/>
        public RoleType Type 
        {
            get => GetEnumProperty<RoleType>("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc />
        public Task AddAdminGroupTargetAsync(
            string groupId, string targetGroupId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.AddGroupTargetToGroupAdministratorRoleForGroupAsync(groupId, Id, targetGroupId, cancellationToken);
        
        /// <inheritdoc />
        public Task AddAppInstanceTargetToAdminRoleAsync(
            string groupId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.AddApplicationInstanceTargetToAppAdminRoleGivenToGroupAsync(groupId, Id, appName, applicationId, cancellationToken);
        
        /// <inheritdoc />
        public Task AddAppTargetToAdminRoleAsync(
            string groupId, string appName, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.AddApplicationTargetToAdminRoleGivenToGroupAsync(groupId, Id, appName, cancellationToken);
        
        /// <inheritdoc />
        public Task AddAllAppsAsTargetToRoleAsync(
            string userId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.AddAllAppsAsTargetToRoleAsync(userId, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task AddAppTargetToAppAdminRoleForUserAsync(
            string userId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.AddApplicationTargetToAppAdminRoleForUserAsync(userId, Id, appName, applicationId, cancellationToken);
        
        /// <inheritdoc />
        public Task AddAppTargetToAdminRoleForUserAsync(
            string userId, string appName, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.AddApplicationTargetToAdminRoleForUserAsync(userId, Id, appName, cancellationToken);
        
    }
}
