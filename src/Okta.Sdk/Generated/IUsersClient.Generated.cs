// <copyright file="IUsersClient.Generated.cs" company="Okta, Inc">
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
        /// <param name="search">Searches for users with a supported filtering  expression for most properties</param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns>A collection of <see cref="IUser"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IUser> ListUsers(string q = null, string after = null, int? limit = 10, string filter = null, string search = null, string sortBy = null, string sortOrder = null);

        /// <summary>
        /// Creates a new user in your Okta organization with or without credentials.
        /// </summary>
        /// <param name="createUserRequest">The <see cref="ICreateUserRequest"/> resource.</param>
        /// <param name="activate">Executes activation lifecycle operation when creating the user</param>
        /// <param name="provider">Indicates whether to create a user with a specified authentication provider</param>
        /// <param name="nextLogin">With activate&#x3D;true, set nextLogin to &quot;changePassword&quot; to have the password be EXPIRED, so user must change it the next time they log in.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUser"/> response.</returns>
        Task<IUser> CreateUserAsync(ICreateUserRequest createUserRequest, bool? activate = true, bool? provider = false, UserNextLogin nextLogin = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets a linked object for a user.
        /// </summary>
        /// <param name="associatedUserId"></param>
        /// <param name="primaryRelationshipName"></param>
        /// <param name="primaryUserId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task SetLinkedObjectForUserAsync(string associatedUserId, string primaryRelationshipName, string primaryUserId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a user permanently.  This operation can only be performed on users that have a `DEPROVISIONED` status.  **This action cannot be recovered!**
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sendEmail"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeactivateOrDeleteUserAsync(string userId, bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches a user from your Okta organization.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUser"/> response.</returns>
        Task<IUser> GetUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch a user by `id`, `login`, or `login shortname` if the short name is unambiguous.
        /// </summary>
        /// <param name="user">The <see cref="IUser"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="strict"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUser"/> response.</returns>
        Task<IUser> PartialUpdateUserAsync(IUser user, string userId, bool? strict = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update a user's profile and/or credentials using strict-update semantics.
        /// </summary>
        /// <param name="user">The <see cref="IUser"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="strict"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUser"/> response.</returns>
        Task<IUser> UpdateUserAsync(IUser user, string userId, bool? strict = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches appLinks for all direct or indirect (via group membership) assigned applications.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A collection of <see cref="IAppLink"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IAppLink> ListAppLinks(string userId);

        /// <summary>
        /// Lists all client resources for which the specified user has grants or tokens.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A collection of <see cref="IOAuth2Client"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IOAuth2Client> ListUserClients(string userId);

        /// <summary>
        /// Revokes all grants for the specified user and client
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RevokeGrantsForUserAndClientAsync(string userId, string clientId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all grants for a specified user and client
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="expand"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="IOAuth2ScopeConsentGrant"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IOAuth2ScopeConsentGrant> ListGrantsForUserAndClient(string userId, string clientId, string expand = null, string after = null, int? limit = 20);

        /// <summary>
        /// Revokes all refresh tokens issued for the specified User and Client.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RevokeTokensForUserAndClientAsync(string userId, string clientId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all refresh tokens issued for the specified User and Client.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="expand"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="IOAuth2RefreshToken"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IOAuth2RefreshToken> ListRefreshTokensForUserAndClient(string userId, string clientId, string expand = null, string after = null, int? limit = 20);

        /// <summary>
        /// Revokes the specified refresh token.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="tokenId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RevokeTokenForUserAndClientAsync(string userId, string clientId, string tokenId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a refresh token issued for the specified User and Client.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="tokenId"></param>
        /// <param name="expand"></param>
        /// <param name="limit"></param>
        /// <param name="after"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOAuth2RefreshToken"/> response.</returns>
        Task<IOAuth2RefreshToken> GetRefreshTokenForUserAndClientAsync(string userId, string clientId, string tokenId, string expand = null, int? limit = 20, string after = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Changes a user's password by validating the user's current password. This operation can only be performed on users in `STAGED`, `ACTIVE`, `PASSWORD_EXPIRED`, or `RECOVERY` status that have a valid password credential
        /// </summary>
        /// <param name="changePasswordRequest">The <see cref="IChangePasswordRequest"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="strict"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserCredentials"/> response.</returns>
        Task<IUserCredentials> ChangePasswordAsync(IChangePasswordRequest changePasswordRequest, string userId, bool? strict = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Changes a user's recovery question & answer credential by validating the user's current password.  This operation can only be performed on users in **STAGED**, **ACTIVE** or **RECOVERY** `status` that have a valid password credential
        /// </summary>
        /// <param name="userCredentials">The <see cref="IUserCredentials"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserCredentials"/> response.</returns>
        Task<IUserCredentials> ChangeRecoveryQuestionAsync(IUserCredentials userCredentials, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Generates a one-time token (OTT) that can be used to reset a user's password
        /// </summary>
        /// <param name="userId">Determines whether an email is sent to the user. This only applies when &#x27;user&#x27; is not provided in the request body.</param>
        /// <param name="sendEmail"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IForgotPasswordResponse"/> response.</returns>
        Task<IForgotPasswordResponse> ForgotPasswordGenerateOneTimeTokenAsync(string userId, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets a new password for a user by validating the user's answer to their current recovery question
        /// </summary>
        /// <param name="userCredentials">The <see cref="IUserCredentials"/> resource.</param>
        /// <param name="userId">Determines whether an email is sent to the user. This only applies when &#x27;user&#x27; is not provided in the request body.</param>
        /// <param name="sendEmail"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IForgotPasswordResponse"/> response.</returns>
        Task<IForgotPasswordResponse> ForgotPasswordSetNewPasswordAsync(IUserCredentials userCredentials, string userId, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Revokes all grants for a specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RevokeUserGrantsAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all grants for the specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="scopeId"></param>
        /// <param name="expand"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="IOAuth2ScopeConsentGrant"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IOAuth2ScopeConsentGrant> ListUserGrants(string userId, string scopeId = null, string expand = null, string after = null, int? limit = 20);

        /// <summary>
        /// Revokes one grant for a specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="grantId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RevokeUserGrantAsync(string userId, string grantId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a grant for the specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="grantId"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOAuth2ScopeConsentGrant"/> response.</returns>
        Task<IOAuth2ScopeConsentGrant> GetUserGrantAsync(string userId, string grantId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches the groups of which the user is a member.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IGroup> ListUserGroups(string userId);

        /// <summary>
        /// Lists the IdPs associated with the user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A collection of <see cref="IIdentityProvider"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IIdentityProvider> ListUserIdentityProviders(string userId);

        /// <summary>
        /// Activates a user.  This operation can only be performed on users with a `STAGED` status.  Activation of a user is an asynchronous operation. The user will have the `transitioningToStatus` property with a value of `ACTIVE` during activation to indicate that the user hasn't completed the asynchronous operation.  The user will have a status of `ACTIVE` when the activation process is complete.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sendEmail">Sends an activation email to the user if true</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserActivationToken"/> response.</returns>
        Task<IUserActivationToken> ActivateUserAsync(string userId, bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivates a user.  This operation can only be performed on users that do not have a `DEPROVISIONED` status.  Deactivation of a user is an asynchronous operation.  The user will have the `transitioningToStatus` property with a value of `DEPROVISIONED` during deactivation to indicate that the user hasn't completed the asynchronous operation.  The user will have a status of `DEPROVISIONED` when the deactivation process is complete.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sendEmail"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeactivateUserAsync(string userId, bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// This operation transitions the user to the status of `PASSWORD_EXPIRED` so that the user is required to change their password at their next login.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUser"/> response.</returns>
        Task<IUser> ExpirePasswordAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// This operation transitions the user to the status of `PASSWORD_EXPIRED` so that the user is required to change their password at their next login.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ITempPassword"/> response.</returns>
        Task<ITempPassword> ExpirePasswordAndGetTemporaryPasswordAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Reactivates a user.  This operation can only be performed on users with a `PROVISIONED` status.  This operation restarts the activation workflow if for some reason the user activation was not completed when using the activationToken from [Activate User](#activate-user).
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sendEmail">Sends an activation email to the user if true</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserActivationToken"/> response.</returns>
        Task<IUserActivationToken> ReactivateUserAsync(string userId, bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// This operation resets all factors for the specified user. All MFA factor enrollments returned to the unenrolled state. The user's status remains ACTIVE. This link is present only if the user is currently enrolled in one or more MFA factors.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task ResetFactorsAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Generates a one-time token (OTT) that can be used to reset a user's password.  The OTT link can be automatically emailed to the user or returned to the API caller and distributed using a custom flow.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sendEmail"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IResetPasswordToken"/> response.</returns>
        Task<IResetPasswordToken> ResetPasswordAsync(string userId, bool? sendEmail, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Suspends a user.  This operation can only be performed on users with an `ACTIVE` status.  The user will have a status of `SUSPENDED` when the process is complete.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task SuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Unlocks a user with a `LOCKED_OUT` status and returns them to `ACTIVE` status.  Users will be able to login with their current password.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task UnlockUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Unsuspends a user and returns them to the `ACTIVE` state.  This operation can only be performed on users that have a `SUSPENDED` status.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task UnsuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete linked objects for a user, relationshipName can be ONLY a primary relationship name
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="relationshipName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RemoveLinkedObjectForUserAsync(string userId, string relationshipName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get linked objects for a user, relationshipName can be a primary or associated relationship name
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="relationshipName"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="IResponseLinks"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IResponseLinks> GetLinkedObjectsForUser(string userId, string relationshipName, string after = null, int? limit = -1);

        /// <summary>
        /// Lists all roles assigned to a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="expand"></param>
        /// <returns>A collection of <see cref="IRole"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IRole> ListAssignedRolesForUser(string userId, string expand = null);

        /// <summary>
        /// Assigns a role to a user.
        /// </summary>
        /// <param name="assignRoleRequest">The <see cref="IAssignRoleRequest"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="disableNotifications"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IRole"/> response.</returns>
        Task<IRole> AssignRoleToUserAsync(IAssignRoleRequest assignRoleRequest, string userId, string disableNotifications = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Unassigns a role from a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RemoveRoleFromUserAsync(string userId, string roleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all App targets for an `APP_ADMIN` Role assigned to a User. This methods return list may include full Applications or Instances. The response for an instance will have an `ID` value, while Application will not have an ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="ICatalogApplication"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<ICatalogApplication> ListApplicationTargetsForApplicationAdministratorRoleForUser(string userId, string roleId, string after = null, int? limit = 20);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task AddAllAppsAsTargetToRoleAsync(string userId, string roleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RemoveApplicationTargetFromApplicationAdministratorRoleForUserAsync(string userId, string roleId, string appName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task AddApplicationTargetToAdminRoleForUserAsync(string userId, string roleId, string appName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Remove App Instance Target to App Administrator Role given to a User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        /// <param name="applicationId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RemoveApplicationTargetFromAdministratorRoleForUserAsync(string userId, string roleId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Add App Instance Target to App Administrator Role given to a User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        /// <param name="applicationId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task AddApplicationTargetToAppAdminRoleForUserAsync(string userId, string roleId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List all group targets given a role id.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="IGroup"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IGroup> ListGroupTargetsForRole(string userId, string roleId, string after = null, int? limit = 20);

        /// <summary>
        /// Removes a group target from a role assigned to a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RemoveGroupTargetFromRoleAsync(string userId, string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a group target for a role assigned to a user.
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
        Task ClearUserSessionsAsync(string userId, bool? oauthTokens = false, CancellationToken cancellationToken = default(CancellationToken));

    }
}
