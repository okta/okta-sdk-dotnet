// <copyright file="Group.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class Group : IGroup
    {
        /// <inheritdoc/>
        public IAsyncEnumerable<IUser> Users
            => GetClient().Groups.ListGroupUsers(Id);

        /// <inheritdoc/>
        public Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.DeleteGroupAsync(Id, cancellationToken);

        /// <inheritdoc/>
        public Task<IGroup> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.UpdateGroupAsync(this, Id, cancellationToken);

        /// <inheritdoc/>
        public Task<IRole> AssignRoleAsync(IAssignRoleRequest assignRoleRequest, string disableNotifications, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.AssignRoleToGroupAsync(assignRoleRequest, Id, (bool?)null, cancellationToken);
    }
}
