// <copyright file="GroupsClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Okta.Sdk.Internal;

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

        /// <inheritdoc/>
        public IAsyncEnumerator<IGroup> GetEnumerator() => ListGroups().GetEnumerator();

        /// <summary>
        /// Lists the groups asynchronous.
        /// </summary>
        /// <param name="q">The q.</param>
        /// <param name="after">The after.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="format">The format.</param>
        /// <param name="search">The search.</param>
        /// <param name="expand">The expand.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// page of groups.
        /// </returns>
        public async Task<PageOfResults<Group>> ListGroupsAsync(
            string q = null,
            string after = null,
            int? limit = -1,
            string filter = null,
            string format = null,
            string search = null,
            string expand = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetPageOfResultsAsync<Group>(
                new HttpRequest
                {
                    Uri = "/api/v1/groups",
                    QueryParameters = new Dictionary<string, object>()
                    {
                        ["q"] = q,
                        ["filter"] = filter,
                        ["after"] = after,
                        ["limit"] = limit,
                        ["expand"] = expand,
                    },
                },
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Lists the groups asynchronous.
        /// </summary>
        /// <param name="serializedNextRequest">The serialized next request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// page of groups.
        /// </returns>
        public async Task<PageOfResults<Group>> ListGroupsContinuationAsync(string serializedNextRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpRequest req = JsonConvert.DeserializeObject<HttpRequest>(serializedNextRequest);
            return await GetPageOfResultsAsync<Group>(req, cancellationToken).ConfigureAwait(false);
        }
    }
}
