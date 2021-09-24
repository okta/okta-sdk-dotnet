// <copyright file="GroupsClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>
    /// Provides methods that manipulate Group resources, by communicating with the Okta Groups API.
    /// </summary>
    public sealed partial class GroupsClient : OktaClient, IGroupsClient, IAsyncEnumerable<IGroup>
    {
        /// <inheritdoc/>
        public Task<IGroup> CreateGroupAsync(CreateGroupOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            var newGroup = new Group
            {
                Profile = new GroupProfile
                {
                    Name = options.Name,
                    Description = options.Description,
                },
            };

            return CreateGroupAsync(newGroup, cancellationToken);
        }

        /// <inheritdoc />
        public Task DeleteGroupRuleAsync(string ruleId, CancellationToken cancellationToken)
            => DeleteGroupRuleAsync(ruleId, removeUsers: null, cancellationToken);

        /// <inheritdoc/>
        public IAsyncEnumerator<IGroup> GetAsyncEnumerator(CancellationToken cancellationToken = default) => ListGroups().GetAsyncEnumerator(cancellationToken);
    }
}
