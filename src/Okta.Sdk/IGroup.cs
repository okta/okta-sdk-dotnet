// <copyright file="IGroup.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public partial interface IGroup
    {
        /// <summary>
        /// Gets the collection of <see cref="IUser">Users</see> in this Group.
        /// </summary>
        /// <value>The colletion of Users in this Group.</value>
        IAsyncEnumerable<IUser> Users { get; }

        /// <summary>
        /// Saves changes and returns the updated resource.
        /// </summary>
        /// <remarks>Alias of <see cref="IGroupsClient.UpdateGroupAsync(IGroup, string, CancellationToken)"/>.</remarks>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated <see cref="IGroup">Group</see>.</returns>
        Task<IGroup> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
