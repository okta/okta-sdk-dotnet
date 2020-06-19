// <copyright file="IGroupsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta Group resources.</summary>
    public partial interface IGroupsClient
    {
        /// <summary>
        /// Enumerates groups in your organization with pagination. A subset of groups can be returned that match a supported filter expression or query.
        /// </summary>
        /// <param name="q">Searches the name property of groups for matching value</param>
        /// <param name="filter">Filter expression for groups</param>
        /// <param name="after">Specifies the pagination cursor for the next page of groups</param>
        /// <param name="limit">Specifies the number of group results in a page</param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IGroup> ListGroups(string q = null, string filter = null, string after = null, int? limit = 10000);

        /// <summary>
        /// Adds a new group with `OKTA_GROUP` type to your organization.
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
        /// <param name="search">Specifies the keyword to search fules for</param>
        /// <param name="expand">If specified as &#x60;groupIdToGroupNameMap&#x60;, then show group names</param>
        /// <returns>A collection of <see cref="IGroupRule"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IGroupRule> ListGroupRules(int? limit = 50, string after = null, string search = null, string expand = null);

        /// <summary>
        /// Creates a group rule to dynamically add users to the specified group if they match the condition
        /// </summary>
        /// <param name="groupRule">The <see cref="IGroupRule"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroupRule"/> response.</returns>
        Task<IGroupRule> CreateGroupRuleAsync(IGroupRule groupRule, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes a specific group rule by id from your organization
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteGroupRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches a specific group rule by id from your organization
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroupRule"/> response.</returns>
        Task<IGroupRule> GetGroupRuleAsync(string ruleId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a group rule. Only `INACTIVE` rules can be updated.
        /// </summary>
        /// <param name="groupRule">The <see cref="IGroupRule"/> resource.</param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroupRule"/> response.</returns>
        Task<IGroupRule> UpdateGroupRuleAsync(IGroupRule groupRule, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Activates a specific group rule by id from your organization
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task ActivateGroupRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivates a specific group rule by id from your organization
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeactivateGroupRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes a group with `OKTA_GROUP` type from your organization.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all group rules for your organization.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroup"/> response.</returns>
        Task<IGroup> GetGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the profile for a group with `OKTA_GROUP` type from your organization.
        /// </summary>
        /// <param name="group">The <see cref="IGroup"/> resource.</param>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroup"/> response.</returns>
        Task<IGroup> UpdateGroupAsync(IGroup group, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates all applications that are assigned to a group.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="after">Specifies the pagination cursor for the next page of apps</param>
        /// <param name="limit">Specifies the number of app results for a page</param>
        /// <returns>A collection of <see cref="IApplication"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IApplication> ListAssignedApplicationsForGroup(string groupId, string after = null, int? limit = 20);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="expand"></param>
        /// <returns>A collection of <see cref="IRole"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IRole> ListGroupAssignedRoles(string groupId, string expand = null);

        /// <summary>
        /// Assigns a Role to a Group
        /// </summary>
        /// <param name="assignRoleRequest">The <see cref="IAssignRoleRequest"/> resource.</param>
        /// <param name="groupId"></param>
        /// <param name="disableNotifications"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IRole"/> response.</returns>
        Task<IRole> AssignRoleToGroupAsync(IAssignRoleRequest assignRoleRequest, string groupId, string disableNotifications = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Unassigns a Role from a Group
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RemoveRoleFromGroupAsync(string groupId, string roleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IRole"/> response.</returns>
        Task<IRole> GetRoleAsync(string groupId, string roleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all App targets for an `APP_ADMIN` Role assigned to a Group. This methods return list may include full Applications or Instances. The response for an instance will have an `ID` value, while Application will not have an ID.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="ICatalogApplication"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<ICatalogApplication> ListApplicationTargetsForApplicationAdministratorRoleForGroup(string groupId, string roleId, string after = null, int? limit = 20);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroupAsync(string groupId, string roleId, string appName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task AddApplicationTargetToAdminRoleGivenToGroupAsync(string groupId, string roleId, string appName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Remove App Instance Target to App Administrator Role given to a Group
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        /// <param name="applicationId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RemoveApplicationTargetFromAdministratorRoleGivenToGroupAsync(string groupId, string roleId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Add App Instance Target to App Administrator Role given to a Group
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        /// <param name="applicationId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task AddApplicationInstanceTargetToAppAdminRoleGivenToGroupAsync(string groupId, string roleId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IGroup> ListGroupTargetsForGroupRole(string groupId, string roleId, string after = null, int? limit = 20);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="targetGroupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RemoveGroupTargetFromGroupAdministratorRoleGivenToGroupAsync(string groupId, string roleId, string targetGroupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="targetGroupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task AddGroupTargetToGroupAdministratorRoleForGroupAsync(string groupId, string roleId, string targetGroupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates all users that are a member of a group.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="after">Specifies the pagination cursor for the next page of users</param>
        /// <param name="limit">Specifies the number of user results in a page</param>
        /// <returns>A collection of <see cref="IUser"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IUser> ListGroupUsers(string groupId, string after = null, int? limit = 1000);

        /// <summary>
        /// Removes a user from a group with 'OKTA_GROUP' type.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RemoveUserFromGroupAsync(string groupId, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a user to a group with 'OKTA_GROUP' type.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task AddUserToGroupAsync(string groupId, string userId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
