// <copyright file="IGroupsClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
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

        /// <summary>
        /// Enumerates groups in your organization with pagination. A subset of groups can be returned that match a supported filter expression or query.
        /// </summary>
        /// <param name="q">Searches the name property of groups for matching value</param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IGroup> ListGroups(string q);

        /// <summary>
        /// Enumerates groups in your organization with pagination. A subset of groups can be returned that match a supported filter expression or query.
        /// </summary>
        /// <param name="q">Searches the name property of groups for matching value</param>
        /// <param name="search">Searches for groups with a supported filtering expression for all attributes except for _embedded, _links, and objectClass</param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>
        [Obsolete("Use ListGroups(string q = null, string filter = null, string after = null, int? limit = 10000, string expand = null, string search = null) instead")]
        ICollectionClient<IGroup> ListGroups(string q, string search);

        /// <summary>
        /// Enumerates groups in your organization with pagination. A subset of groups can be returned that match a supported filter expression or query.
        /// </summary>
        /// <param name="q">Searches the name property of groups for matching value</param>
        /// <param name="search">Searches for groups with a supported filtering expression for all attributes except for _embedded, _links, and objectClass</param>
        /// <param name="after">Specifies the pagination cursor for the next page of groups</param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>
        [Obsolete("Use ListGroups(string q = null, string filter = null, string after = null, int? limit = 10000, string expand = null, string search = null) instead")]
        ICollectionClient<IGroup> ListGroups(string q, string search, string after);

        /// <summary>
        /// Enumerates groups in your organization with pagination. A subset of groups can be returned that match a supported filter expression or query.
        /// </summary>
        /// <param name="q">Searches the name property of groups for matching value</param>
        /// <param name="search">Searches for groups with a supported filtering expression for all attributes except for _embedded, _links, and objectClass</param>
        /// <param name="after">Specifies the pagination cursor for the next page of groups</param>
        /// <param name="limit">Specifies the number of group results in a page</param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>
        [Obsolete("Use ListGroups(string q = null, string filter = null, string after = null, int? limit = 10000, string expand = null, string search = null) instead")]
        ICollectionClient<IGroup> ListGroups(string q, string search, string after, int? limit);

        /// <summary>
        /// Enumerates groups in your organization with pagination. A subset of groups can be returned that match a supported filter expression or query.
        /// </summary>
        /// <param name="q">Searches the name property of groups for matching value</param>
        /// <param name="search">Searches for groups with a supported filtering expression for all attributes except for _embedded, _links, and objectClass</param>
        /// <param name="after">Specifies the pagination cursor for the next page of groups</param>
        /// <param name="limit">Specifies the number of group results in a page</param>
        /// <param name="expand">If specified, it causes additional metadata to be included in the response.</param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>
        [Obsolete("Use ListGroups(string q = null, string filter = null, string after = null, int? limit = 10000, string expand = null, string search = null) instead")]
        ICollectionClient<IGroup> ListGroups(string q, string search, string after, int? limit, string expand);

        /// <summary>
        /// Enumerates groups in your organization with pagination. A subset of groups can be returned that match a supported filter expression or query.
        /// </summary>
        /// <param name="q">Searches the name property of groups for matching value</param>
        /// <param name="filter">Filter expression for groups</param>
        /// <param name="after">Specifies the pagination cursor for the next page of groups</param>
        /// <param name="limit">Specifies the number of group results in a page</param>
        /// <param name="expand">If specified, it causes additional metadata to be included in the response.</param>
        /// <param name="search">Searches for groups with a supported filtering expression for all attributes except for _embedded, _links, and objectClass</param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IGroup> ListGroups(string q = null, string filter = null, string after = null, int? limit = 10000, string expand = null, string search = null);
    }
}
