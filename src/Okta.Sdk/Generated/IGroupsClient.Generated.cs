// <copyright file="IGroupsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with <see cref="IGroup"/> resources.</summary>
    public partial interface IGroupsClient
    {
        /// <summary>
        /// Enumerates groups in your organization with pagination. A subset of groups can be returned that match a supported filter expression or query.
        /// </summary>
        /// <param name="q">Searches the name property of groups for matching value</param>
        /// <param name="filter">Filter expression for groups</param>
        /// <param name="after">Specifies the pagination cursor for the next page of groups</param>
        /// <param name="limit">Specifies the number of group results in a page</param>
        /// <param name="expand"></param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>        
        IAsyncEnumerable<IGroup> ListGroups(string q = null, string filter = null, string after = null, int? limit = -1, string expand = null);

        /// <summary>
        /// Adds a new group with &#x60;OKTA_GROUP&#x60; type to your organization.
        /// </summary>
        /// <param name="group">The <see cref="IGroup"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroup"/> response.</returns>        
        Task<IGroup> CreateGroupAsync(IGroup group, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all group rules for your organization.
        /// </summary>
        /// <param name="limit">Specifies the number of rule results in a page</param>
        /// <param name="after">Specifies the pagination cursor for the next page of rules</param>
        /// <returns>A collection of <see cref="IGroupRule"/> that can be enumerated asynchronously.</returns>        
        IAsyncEnumerable<IGroupRule> ListRules(int? limit = -1, string after = null);

        /// <summary>
        /// Creates a group rule to dynamically add users to the specified group if they match the condition
        /// </summary>
        /// <param name="groupRule">The <see cref="IGroupRule"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroupRule"/> response.</returns>        
        Task<IGroupRule> CreateRuleAsync(IGroupRule groupRule, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="removeUsers"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>        
        Task DeleteRuleAsync(string ruleId, bool? removeUsers = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroupRule"/> response.</returns>        
        Task<IGroupRule> GetRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupRule">The <see cref="IGroupRule"/> resource.</param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroupRule"/> response.</returns>        
        Task<IGroupRule> UpdateRuleAsync(IGroupRule groupRule, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>        
        Task ActivateRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>        
        Task DeactivateRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>        
        Task DeleteGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroup"/> response.</returns>        
        Task<IGroup> GetGroupAsync(string groupId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="group">The <see cref="IGroup"/> resource.</param>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroup"/> response.</returns>        
        Task<IGroup> UpdateGroupAsync(IGroup group, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="IUser"/> that can be enumerated asynchronously.</returns>        
        IAsyncEnumerable<IUser> ListGroupUsers(string groupId, string after = null, int? limit = -1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>        
        Task RemoveGroupUserAsync(string groupId, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>        
        Task AddUserToGroupAsync(string groupId, string userId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
