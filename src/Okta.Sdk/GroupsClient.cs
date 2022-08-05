// <copyright file="GroupsClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
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

        /// <inheritdoc />
        [Obsolete("Use ListGroups(string q = null, string filter = null, string after = null, int? limit = 10000, string expand = null, string search = null) instead")]
        public ICollectionClient<IGroup> ListGroups(string q)
        {
            return ListGroups(q, null, null, null, null, null);
        }

        /// <inheritdoc />
        [Obsolete("Use ListGroups(string q = null, string filter = null, string after = null, int? limit = 10000, string expand = null, string search = null) instead")]
        public ICollectionClient<IGroup> ListGroups(string q, string search)
        {
            return ListGroups(q, null, null, null, null, search);
        }

        /// <inheritdoc />
        [Obsolete("Use ListGroups(string q = null, string filter = null, string after = null, int? limit = 10000, string expand = null, string search = null) instead")]
        public ICollectionClient<IGroup> ListGroups(string q, string search, string after)
        {
            return ListGroups(q, search, after, null, null, null);
        }

        /// <inheritdoc />
        [Obsolete("Use ListGroups(string q = null, string filter = null, string after = null, int? limit = 10000, string expand = null, string search = null) instead")]
        public ICollectionClient<IGroup> ListGroups(string q, string search, string after, int? limit)
        {
            return ListGroups(q, search, after, limit, null, null);
        }

        /// <inheritdoc />
        [Obsolete("Use ListGroups(string q = null, string filter = null, string after = null, int? limit = 10000, string expand = null, string search = null) instead")]
        public ICollectionClient<IGroup> ListGroups(string q, string search, string after, int? limit, string expand)
        {
            return ListGroups(q, search, after, limit, expand, null);
        }

        /// <inheritdoc />
        public ICollectionClient<IGroup> ListGroups(string q = null, string filter = null, string after = null, int? limit = 10000, string expand = null, string search = null)
            => GetCollectionClient<IGroup>(new HttpRequest
            {
                Uri = "/api/v1/groups",
                Verb = HttpVerb.Get,

                QueryParameters = new Dictionary<string, object>()
                {
                    ["q"] = q,
                    ["filter"] = filter,
                    ["after"] = after,
                    ["limit"] = limit,
                    ["expand"] = expand,
                    ["search"] = search,
                },
            });
    }
}
