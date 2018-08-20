// <copyright file="IUsersClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta User resources.</summary>
    public partial interface IUsersClient
    {
        /// <summary>
        /// Lists users in your organization with pagination in most cases.  A subset of users can be returned that match a supported filter expression or search criteria.
        /// </summary>
        /// <param name="q">Finds a user that matches firstName, lastName, and email properties</param>
        /// <param name="after">Specifies the pagination cursor for the next page of users</param>
        /// <param name="limit">Specifies the number of results returned</param>
        /// <param name="filter">Filters users with a supported expression for a subset of properties</param>
        /// <param name="format"></param>
        /// <param name="search">Searches for users with a supported filtering  expression for most properties</param>
        /// <param name="expand"></param>
        /// <returns>A collection of <see cref="IUser"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IUser> ListUsers(string q = null, string after = null, int? limit = -1, string filter = null, string format = null, string search = null, string expand = null);

        /// <summary>
        /// Creates a new user in your Okta organization with or without credentials.
        /// </summary>
        /// <param name="user">The <see cref="IUser"/> resource.</param>
        /// <param name="activate">Executes activation lifecycle operation when creating the user</param>
        /// <param name="provider">Indicates whether to create a user with a specified authentication provider</param>
        /// <param name="nextLogin">With activate&#x3D;true, set nextLogin to &quot;changePassword&quot; to have the password be EXPIRED, so user must change it the next time they log in.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUser"/> response.</returns>
        Task<IUser> CreateUserAsync(IUser user, bool? activate = true, bool? provider = false, UserNextLogin nextLogin = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a user permanently.  This operation can only be performed on users that have a &#x60;DEPROVISIONED&#x60; status.  **This action cannot be recovered!**
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeactivateOrDeleteUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches a user from your Okta organization.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUser"/> response.</returns>
        Task<IUser> GetUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update a user&#x27;s profile and/or credentials using strict-update semantics.
        /// </summary>
        /// <param name="user">The <see cref="IUser"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUser"/> response.</returns>
        Task<IUser> UpdateUserAsync(IUser user, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches appLinks for all direct or indirect (via group membership) assigned applications.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="showAll"></param>
        /// <returns>A collection of <see cref="IAppLink"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IAppLink> ListAppLinks(string userId, bool? showAll = false);

        /// <summary>
        /// Changes a user&#x27;s password by validating the user&#x27;s current password.  This operation can only be performed on users in &#x60;STAGED&#x60;, &#x60;ACTIVE&#x60;, &#x60;PASSWORD_EXPIRED&#x60;, or &#x60;RECOVERY&#x60; status that have a valid [password credential](#password-object)
        /// </summary>
        /// <param name="changePasswordRequest">The <see cref="IChangePasswordRequest"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserCredentials"/> response.</returns>
        Task<IUserCredentials> ChangePasswordAsync(IChangePasswordRequest changePasswordRequest, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Changes a user&#x27;s recovery question &amp; answer credential by validating the user&#x27;s current password.  This operation can only be performed on users in **STAGED**, **ACTIVE** or **RECOVERY** &#x60;status&#x60; that have a valid [password credential](#password-object)
        /// </summary>
        /// <param name="userCredentials">The <see cref="IUserCredentials"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserCredentials"/> response.</returns>
        Task<IUserCredentials> ChangeRecoveryQuestionAsync(IUserCredentials userCredentials, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches the groups of which the user is a member.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IGroup> ListUserGroups(string userId, string after = null, int? limit = -1);

        /// <summary>
        /// Activates a user.  This operation can only be performed on users with a &#x60;STAGED&#x60; status.  Activation of a user is an asynchronous operation.  The user will have the &#x60;transitioningToStatus&#x60; property with a value of &#x60;ACTIVE&#x60; during activation to indicate that the user hasn&#x27;t completed the asynchronous operation.  The user will have a status of &#x60;ACTIVE&#x60; when the activation process is complete.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sendEmail">Sends an activation email to the user if true</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserActivationToken"/> response.</returns>
        Task<IUserActivationToken> ActivateUserAsync(string userId, bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivates a user.  This operation can only be performed on users that do not have a &#x60;DEPROVISIONED&#x60; status.  Deactivation of a user is an asynchronous operation.  The user will have the &#x60;transitioningToStatus&#x60; property with a value of &#x60;DEPROVISIONED&#x60; during deactivation to indicate that the user hasn&#x27;t completed the asynchronous operation.  The user will have a status of &#x60;DEPROVISIONED&#x60; when the deactivation process is complete.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeactivateUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// This operation transitions the user to the status of &#x60;PASSWORD_EXPIRED&#x60; so that the user is required to change their password at their next login.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tempPassword">Sets the user&#x27;s password to a temporary password,  if true</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ITempPassword"/> response.</returns>
        Task<ITempPassword> ExpirePasswordAsync(string userId, bool? tempPassword = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// This operation resets all factors for the specified user. All MFA factor enrollments returned to the unenrolled state. The user&#x27;s status remains ACTIVE. This link is present only if the user is currently enrolled in one or more MFA factors.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task ResetAllFactorsAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Generates a one-time token (OTT) that can be used to reset a user&#x27;s password.  The OTT link can be automatically emailed to the user or returned to the API caller and distributed using a custom flow.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="provider"></param>
        /// <param name="sendEmail"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IResetPasswordToken"/> response.</returns>
        Task<IResetPasswordToken> ResetPasswordAsync(string userId, AuthenticationProviderType provider = null, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Suspends a user.  This operation can only be performed on users with an &#x60;ACTIVE&#x60; status.  The user will have a status of &#x60;SUSPENDED&#x60; when the process is complete.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task SuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Unlocks a user with a &#x60;LOCKED_OUT&#x60; status and returns them to &#x60;ACTIVE&#x60; status.  Users will be able to login with their current password.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task UnlockUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Unsuspends a user and returns them to the &#x60;ACTIVE&#x60; state.  This operation can only be performed on users that have a &#x60;SUSPENDED&#x60; status.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task UnsuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all roles assigned to a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="expand"></param>
        /// <returns>A collection of <see cref="IRole"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IRole> ListAssignedRoles(string userId, string expand = null);

        /// <summary>
        /// Unassigns a role from a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RemoveRoleFromUserAsync(string userId, string roleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IGroup> ListGroupTargetsForRole(string userId, string roleId, string after = null, int? limit = -1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RemoveGroupTargetFromRoleAsync(string userId, string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task AddGroupTargetToRoleAsync(string userId, string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes all active identity provider sessions. This forces the user to authenticate on the next operation. Optionally revokes OpenID Connect and OAuth refresh and access tokens issued to the user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="oauthTokens">Revoke issued OpenID Connect and OAuth refresh and access tokens</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task EndAllUserSessionsAsync(string userId, bool? oauthTokens = false, CancellationToken cancellationToken = default(CancellationToken));

    }
}
