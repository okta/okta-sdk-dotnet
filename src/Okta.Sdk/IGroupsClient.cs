// <copyright file="IGroupsClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta Group resources.</summary>
    public partial interface IGroupsClient : IAsyncEnumerable<IGroup>
    {
        /// <summary>
        /// Adds a new group with &#x60;OKTA_GROUP&#x60; type to your organization.
        /// </summary>
        /// <param name="options">The options for this Create Group request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroup"/> response.</returns>
        Task<IGroup> CreateGroupAsync(CreateGroupOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes a specific group rule by id from your organization
        /// </summary>
        /// <param name="ruleId">Id of the group rule</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteGroupRuleAsync(string ruleId, CancellationToken cancellationToken);
    }
}
