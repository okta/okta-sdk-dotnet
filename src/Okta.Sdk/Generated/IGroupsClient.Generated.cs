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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IGroupsClient
    {
        /// <summary>
        /// Activate a group Rule Activates a specific group rule by id from your organization
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="ruleId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task ActivateGroupRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add App Instance Target to App Administrator Role given to a Group Add App Instance Target to App Administrator Role given to a Group
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        /// <param name="applicationId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task AddApplicationInstanceTargetToAppAdminRoleGivenToGroupAsync(string groupId, string roleId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task AddApplicationTargetToAdminRoleGivenToGroupAsync(string groupId, string roleId, string appName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add Group Target for Group Role Enumerates group targets for a group role.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="targetGroupId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task AddGroupTargetToGroupAdministratorRoleForGroupAsync(string groupId, string roleId, string targetGroupId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add User to Group Adds a user to a group with &#x27;OKTA_GROUP&#x27; type.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task AddUserToGroupAsync(string groupId, string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Assigns a Role to a Group
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="groupId"></param>
        /// <param name="disableNotifications"> (optional)</param>
        ///  <returns>Task of IRole</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IRole> AssignRoleToGroupAsync(IAssignRoleRequest body, string groupId, string disableNotifications = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add Group Adds a new group with &#x60;OKTA_GROUP&#x60; type to your organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of IGroup</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IGroup> CreateGroupAsync(IGroup body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create Group Rule Creates a group rule to dynamically add users to the specified group if they match the condition
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of IGroupRule</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IGroupRule> CreateGroupRuleAsync(IGroupRule body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deactivate a group Rule Deactivates a specific group rule by id from your organization
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="ruleId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeactivateGroupRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Remove Group Removes a group with &#x60;OKTA_GROUP&#x60; type from your organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete a group Rule Removes a specific group rule by id from your organization
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="ruleId"></param>
        /// <param name="removeUsers">Indicates whether to keep or remove users from groups assigned by this rule. (optional)</param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteGroupRuleAsync(string ruleId, bool? removeUsers = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List Group Rules Lists all group rules for your organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        ///  <returns>Task of IGroup</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IGroup> GetGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Group Rule Fetches a specific group rule by id from your organization
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="ruleId"></param>
        /// <param name="expand"> (optional)</param>
        ///  <returns>Task of IGroupRule</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IGroupRule> GetGroupRuleAsync(string ruleId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        ///  <returns>Task of IRole</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IRole> GetRoleAsync(string groupId, string roleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Lists all App targets for an &#x60;APP_ADMIN&#x60; Role assigned to a Group. This methods return list may include full Applications or Instances. The response for an instance will have an &#x60;ID&#x60; value, while Application will not have an ID.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// A collection of <see cref="IGroupsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<ICatalogApplication> ListApplicationTargetsForApplicationAdministratorRoleForGroup(string groupId, string roleId, string after = null, int? limit = null);
        /// <summary>
        /// List Assigned Applications Enumerates all applications that are assigned to a group.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="after">Specifies the pagination cursor for the next page of apps (optional)</param>
        /// <param name="limit">Specifies the number of app results for a page (optional, default to 20)</param>
        /// A collection of <see cref="IGroupsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IApplication> ListAssignedApplicationsForGroup(string groupId, string after = null, int? limit = null);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="expand"> (optional)</param>
        /// A collection of <see cref="IGroupsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IRole> ListGroupAssignedRoles(string groupId, string expand = null);
        /// <summary>
        /// List Group Rules Lists all group rules for your organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="limit">Specifies the number of rule results in a page (optional, default to 50)</param>
        /// <param name="after">Specifies the pagination cursor for the next page of rules (optional)</param>
        /// <param name="search">Specifies the keyword to search fules for (optional)</param>
        /// <param name="expand">If specified as &#x60;groupIdToGroupNameMap&#x60;, then show group names (optional)</param>
        /// A collection of <see cref="IGroupsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IGroupRule> ListGroupRules(int? limit = null, string after = null, string search = null, string expand = null);
        /// <summary>
        /// List Group Targets for Group Role Enumerates group targets for a group role.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// A collection of <see cref="IGroupsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IGroup> ListGroupTargetsForGroupRole(string groupId, string roleId, string after = null, int? limit = null);
        /// <summary>
        /// List Group Members Enumerates all users that are a member of a group.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="after">Specifies the pagination cursor for the next page of users (optional)</param>
        /// <param name="limit">Specifies the number of user results in a page (optional, default to 1000)</param>
        /// A collection of <see cref="IGroupsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IUser> ListGroupUsers(string groupId, string after = null, int? limit = null);
        /// <summary>
        /// List Groups Enumerates groups in your organization with pagination. A subset of groups can be returned that match a supported filter expression or query.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="q">Searches the name property of groups for matching value (optional)</param>
        /// <param name="search">Filter expression for groups (optional)</param>
        /// <param name="after">Specifies the pagination cursor for the next page of groups (optional)</param>
        /// <param name="limit">Specifies the number of group results in a page (optional, default to 10000)</param>
        /// <param name="expand">If specified, it causes additional metadata to be included in the response. (optional)</param>
        /// A collection of <see cref="IGroupsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IGroup> ListGroups(string q = null, string search = null, string after = null, int? limit = null, string expand = null);
        /// <summary>
        /// Remove App Instance Target to App Administrator Role given to a Group Remove App Instance Target to App Administrator Role given to a Group
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        /// <param name="applicationId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RemoveApplicationTargetFromAdministratorRoleGivenToGroupAsync(string groupId, string roleId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroupAsync(string groupId, string roleId, string appName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete Group Target for Group Role remove group target for a group role.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        /// <param name="targetGroupId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RemoveGroupTargetFromGroupAdministratorRoleGivenToGroupAsync(string groupId, string roleId, string targetGroupId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Unassigns a Role from a Group
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="roleId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RemoveRoleFromGroupAsync(string groupId, string roleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Remove User from Group Removes a user from a group with &#x27;OKTA_GROUP&#x27; type.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RemoveUserFromGroupAsync(string groupId, string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update Group Updates the profile for a group with &#x60;OKTA_GROUP&#x60; type from your organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="groupId"></param>
        ///  <returns>Task of IGroup</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IGroup> UpdateGroupAsync(IGroup body, string groupId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Updates a group rule. Only &#x60;INACTIVE&#x60; rules can be updated.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="ruleId"></param>
        ///  <returns>Task of IGroupRule</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IGroupRule> UpdateGroupRuleAsync(IGroupRule body, string ruleId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

