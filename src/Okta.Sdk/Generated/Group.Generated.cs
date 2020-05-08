// <copyright file="Group.Generated.cs" company="Okta, Inc">
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
    public sealed partial class Group : Resource, IGroup
    {
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastMembershipUpdated => GetDateTimeProperty("lastMembershipUpdated");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public IList<string> ObjectClass => GetArrayProperty<string>("objectClass");
        
        /// <inheritdoc/>
        public IGroupProfile Profile 
        {
            get => GetResourceProperty<GroupProfile>("profile");
            set => this["profile"] = value;
        }
        
        /// <inheritdoc/>
        public GroupType Type => GetEnumProperty<GroupType>("type");
        
        /// <inheritdoc />
        public Task RemoveUserAsync(
            string userId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.RemoveUserFromGroupAsync(Id, userId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IApplication> ListApplications(
            string after = null, int? limit = 20)
            => GetClient().Groups.ListAssignedApplicationsForGroup(Id, after, limit);
        
        /// <inheritdoc />
        public Task<IRole> AssignRoleAsync(IAssignRoleRequest type, 
            string disableNotifications = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.AssignRoleToGroupAsync(type, Id, disableNotifications, cancellationToken);
        
    }
}
