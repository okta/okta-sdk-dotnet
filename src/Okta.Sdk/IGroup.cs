// <copyright file="IGroup.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Represents a Group resource in the Okta API.</summary>
    public partial interface IGroup
    {
        /// <summary>
        /// Gets the collection of <see cref="IUser">Users</see> in this Group.
        /// </summary>
        /// <value>The collection of Users in this Group.</value>
        IAsyncEnumerable<IUser> Users { get; }

        /// <summary>
        /// Deletes the group.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Saves changes and returns the updated resource.
        /// </summary>
        /// <remarks>Alias of <see cref="IGroupsClient.UpdateGroupAsync(IGroup, string, CancellationToken)"/>.</remarks>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated <see cref="IGroup">Group</see>.</returns>
        Task<IGroup> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Assigns a role to a group.
        /// </summary>
        /// <param name="assignRoleRequest">The request.</param>
        /// <param name="disableNotifications">The flag to disable notifications.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The role.</returns>
        //[Obsolete("This method is deprecated and will be removed in the next major release. Use <c>AssignRoleAsync</c> but passing a bool? param for <c>disableNotifications</c> instead.")]
        //Task<IRole> AssignRoleAsync(IAssignRoleRequest assignRoleRequest, string disableNotifications, CancellationToken cancellationToken = default(CancellationToken));
    }
}
