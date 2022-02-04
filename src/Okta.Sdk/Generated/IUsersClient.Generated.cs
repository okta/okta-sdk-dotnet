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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IUsersClient
    {
        /// <summary>
        /// Activate User Activates a user.  This operation can only be performed on users with a &#x60;STAGED&#x60; status.  Activation of a user is an asynchronous operation. The user will have the &#x60;transitioningToStatus&#x60; property with a value of &#x60;ACTIVE&#x60; during activation to indicate that the user hasn&#x27;t completed the asynchronous operation.  The user will have a status of &#x60;ACTIVE&#x60; when the activation process is complete.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="sendEmail">Sends an activation email to the user if true</param>
        ///  <returns>Task of IUserActivationToken</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserActivationToken> ActivateUserAsync(string userId, bool? sendEmail, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task AddAllAppsAsTargetToRoleAsync(string userId, string roleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task AddApplicationTargetToAdminRoleForUserAsync(string userId, string roleId, string appName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add App Instance Target to App Administrator Role given to a User Add App Instance Target to App Administrator Role given to a User
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        /// <param name="applicationId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task AddApplicationTargetToAppAdminRoleForUserAsync(string userId, string roleId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="groupId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task AddGroupTargetToRoleAsync(string userId, string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Assigns a role to a user.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="userId"></param>
        /// <param name="disableNotifications"> (optional)</param>
        ///  <returns>Task of IRole</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IRole> AssignRoleToUserAsync(IAssignRoleRequest body, string userId, string disableNotifications = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Change Password Changes a user&#x27;s password by validating the user&#x27;s current password. This operation can only be performed on users in &#x60;STAGED&#x60;, &#x60;ACTIVE&#x60;, &#x60;PASSWORD_EXPIRED&#x60;, or &#x60;RECOVERY&#x60; status that have a valid password credential
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="userId"></param>
        /// <param name="strict"> (optional)</param>
        ///  <returns>Task of IUserCredentials</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserCredentials> ChangePasswordAsync(IChangePasswordRequest body, string userId, bool? strict = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Change Recovery Question Changes a user&#x27;s recovery question &amp; answer credential by validating the user&#x27;s current password.  This operation can only be performed on users in **STAGED**, **ACTIVE** or **RECOVERY** &#x60;status&#x60; that have a valid password credential
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="userId"></param>
        ///  <returns>Task of IUserCredentials</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserCredentials> ChangeRecoveryQuestionAsync(IUserCredentials body, string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Removes all active identity provider sessions. This forces the user to authenticate on the next operation. Optionally revokes OpenID Connect and OAuth refresh and access tokens issued to the user.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="oauthTokens">Revoke issued OpenID Connect and OAuth refresh and access tokens (optional, default to false)</param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task ClearUserSessionsAsync(string userId, bool? oauthTokens = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create User Creates a new user in your Okta organization with or without credentials.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="activate">Executes activation lifecycle operation when creating the user (optional, default to true)</param>
        /// <param name="provider">Indicates whether to create a user with a specified authentication provider (optional, default to false)</param>
        /// <param name="nextLogin">With activate&#x3D;true, set nextLogin to \&quot;changePassword\&quot; to have the password be EXPIRED, so user must change it the next time they log in. (optional)</param>
        ///  <returns>Task of IUser</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUser> CreateUserAsync(ICreateUserRequest body, bool? activate = null, bool? provider = null, string nextLogin = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete User Deletes a user permanently.  This operation can only be performed on users that have a &#x60;DEPROVISIONED&#x60; status.  **This action cannot be recovered!**
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="sendEmail"> (optional, default to false)</param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeactivateOrDeleteUserAsync(string userId, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deactivate User Deactivates a user.  This operation can only be performed on users that do not have a &#x60;DEPROVISIONED&#x60; status.  Deactivation of a user is an asynchronous operation.  The user will have the &#x60;transitioningToStatus&#x60; property with a value of &#x60;DEPROVISIONED&#x60; during deactivation to indicate that the user hasn&#x27;t completed the asynchronous operation.  The user will have a status of &#x60;DEPROVISIONED&#x60; when the deactivation process is complete.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="sendEmail"> (optional, default to false)</param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeactivateUserAsync(string userId, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Expire Password This operation transitions the user to the status of &#x60;PASSWORD_EXPIRED&#x60; so that the user is required to change their password at their next login.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        ///  <returns>Task of IUser</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUser> ExpirePasswordAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Expire Password This operation transitions the user to the status of &#x60;PASSWORD_EXPIRED&#x60; so that the user is required to change their password at their next login.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        ///  <returns>Task of ITempPassword</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ITempPassword> ExpirePasswordAndGetTemporaryPasswordAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Forgot Password Initiate forgot password flow, see desciptions for parameters.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        ///  <returns>Task of IForgotPasswordResponse</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IForgotPasswordResponse> ForgotPasswordAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Get linked objects for a user, relationshipName can be a primary or associated relationship name
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="relationshipName"></param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to -1)</param>
        /// A collection of <see cref="IUsersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IResponseLinks> GetLinkedObjectsForUser(string userId, string relationshipName, string after = null, int? limit = null);
        /// <summary>
        ///  Gets a refresh token issued for the specified User and Client.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="tokenId"></param>
        /// <param name="expand"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// <param name="after"> (optional)</param>
        ///  <returns>Task of IOAuth2RefreshToken</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IOAuth2RefreshToken> GetRefreshTokenForUserAndClientAsync(string userId, string clientId, string tokenId, string expand = null, int? limit = null, string after = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get User Fetches a user from your Okta organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        ///  <returns>Task of IUser</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUser> GetUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Gets a grant for the specified user
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="grantId"></param>
        /// <param name="expand"> (optional)</param>
        ///  <returns>Task of IOAuth2ScopeConsentGrant</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IOAuth2ScopeConsentGrant> GetUserGrantAsync(string userId, string grantId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Assigned App Links Fetches appLinks for all direct or indirect (via group membership) assigned applications.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// A collection of <see cref="IUsersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IAppLink> ListAppLinks(string userId);
        /// <summary>
        ///  Lists all App targets for an &#x60;APP_ADMIN&#x60; Role assigned to a User. This methods return list may include full Applications or Instances. The response for an instance will have an &#x60;ID&#x60; value, while Application will not have an ID.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// A collection of <see cref="IUsersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<ICatalogApplication> ListApplicationTargetsForApplicationAdministratorRoleForUser(string userId, string roleId, string after = null, int? limit = null);
        /// <summary>
        ///  Lists all roles assigned to a user.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="expand"> (optional)</param>
        /// A collection of <see cref="IUsersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IRole> ListAssignedRolesForUser(string userId, string expand = null);
        /// <summary>
        ///  Lists all grants for a specified user and client
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="expand"> (optional)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// A collection of <see cref="IUsersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IOAuth2ScopeConsentGrant> ListGrantsForUserAndClient(string userId, string clientId, string expand = null, string after = null, int? limit = null);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// A collection of <see cref="IUsersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IGroup> ListGroupTargetsForRole(string userId, string roleId, string after = null, int? limit = null);
        /// <summary>
        ///  Lists all refresh tokens issued for the specified User and Client.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="expand"> (optional)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// A collection of <see cref="IUsersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IOAuth2RefreshToken> ListRefreshTokensForUserAndClient(string userId, string clientId, string expand = null, string after = null, int? limit = null);
        /// <summary>
        ///  Lists all client resources for which the specified user has grants or tokens.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// A collection of <see cref="IUsersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IOAuth2Client> ListUserClients(string userId);
        /// <summary>
        ///  Lists all grants for the specified user
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="scopeId"> (optional)</param>
        /// <param name="expand"> (optional)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// A collection of <see cref="IUsersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IOAuth2ScopeConsentGrant> ListUserGrants(string userId, string scopeId = null, string expand = null, string after = null, int? limit = null);
        /// <summary>
        /// Get Member Groups Fetches the groups of which the user is a member.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// A collection of <see cref="IUsersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IGroup> ListUserGroups(string userId);
        /// <summary>
        /// Listing IdPs associated with a user Lists the IdPs associated with the user.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// A collection of <see cref="IUsersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IIdentityProvider> ListUserIdentityProviders(string userId);
        /// <summary>
        /// List Users Lists users in your organization with pagination in most cases.  A subset of users can be returned that match a supported filter expression or search criteria.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="q">Finds a user that matches firstName, lastName, and email properties (optional)</param>
        /// <param name="after">Specifies the pagination cursor for the next page of users (optional)</param>
        /// <param name="limit">Specifies the number of results returned (optional, default to 10)</param>
        /// <param name="filter">Filters users with a supported expression for a subset of properties (optional)</param>
        /// <param name="search">Searches for users with a supported filtering  expression for most properties (optional)</param>
        /// <param name="sortBy"> (optional)</param>
        /// <param name="sortOrder"> (optional)</param>
        /// A collection of <see cref="IUsersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IUser> ListUsers(string q = null, string after = null, int? limit = null, string filter = null, string search = null, string sortBy = null, string sortOrder = null);
        /// <summary>
        ///  Fetch a user by &#x60;id&#x60;, &#x60;login&#x60;, or &#x60;login shortname&#x60; if the short name is unambiguous.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="userId"></param>
        /// <param name="strict"> (optional)</param>
        ///  <returns>Task of IUser</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUser> PartialUpdateUserAsync(IUser body, string userId, bool? strict = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Reactivate User Reactivates a user.  This operation can only be performed on users with a &#x60;PROVISIONED&#x60; status.  This operation restarts the activation workflow if for some reason the user activation was not completed when using the activationToken from [Activate User](#activate-user).
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="sendEmail">Sends an activation email to the user if true (optional, default to false)</param>
        ///  <returns>Task of IUserActivationToken</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserActivationToken> ReactivateUserAsync(string userId, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Remove App Instance Target to App Administrator Role given to a User Remove App Instance Target to App Administrator Role given to a User
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        /// <param name="applicationId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RemoveApplicationTargetFromAdministratorRoleForUserAsync(string userId, string roleId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="appName"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RemoveApplicationTargetFromApplicationAdministratorRoleForUserAsync(string userId, string roleId, string appName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="groupId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RemoveGroupTargetFromRoleAsync(string userId, string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Delete linked objects for a user, relationshipName can be ONLY a primary relationship name
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="relationshipName"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RemoveLinkedObjectForUserAsync(string userId, string relationshipName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Unassigns a role from a user.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RemoveRoleFromUserAsync(string userId, string roleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Reset Factors This operation resets all factors for the specified user. All MFA factor enrollments returned to the unenrolled state. The user&#x27;s status remains ACTIVE. This link is present only if the user is currently enrolled in one or more MFA factors.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task ResetFactorsAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Reset Password Generates a one-time token (OTT) that can be used to reset a user&#x27;s password.  The OTT link can be automatically emailed to the user or returned to the API caller and distributed using a custom flow.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="sendEmail"></param>
        ///  <returns>Task of IResetPasswordToken</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IResetPasswordToken> ResetPasswordAsync(string userId, bool? sendEmail, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Revokes all grants for the specified user and client
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RevokeGrantsForUserAndClientAsync(string userId, string clientId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Revokes the specified refresh token.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="tokenId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RevokeTokenForUserAndClientAsync(string userId, string clientId, string tokenId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Revokes all refresh tokens issued for the specified User and Client.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RevokeTokensForUserAndClientAsync(string userId, string clientId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Revokes one grant for a specified user
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="grantId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RevokeUserGrantAsync(string userId, string grantId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Revokes all grants for a specified user
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RevokeUserGrantsAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Set Linked Object for User Sets a linked object for a user.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="associatedUserId"></param>
        /// <param name="primaryRelationshipName"></param>
        /// <param name="primaryUserId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task SetLinkedObjectForUserAsync(string associatedUserId, string primaryRelationshipName, string primaryUserId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Suspend User Suspends a user.  This operation can only be performed on users with an &#x60;ACTIVE&#x60; status.  The user will have a status of &#x60;SUSPENDED&#x60; when the process is complete.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task SuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Unlock User Unlocks a user with a &#x60;LOCKED_OUT&#x60; status and returns them to &#x60;ACTIVE&#x60; status.  Users will be able to login with their current password.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task UnlockUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Unsuspend User Unsuspends a user and returns them to the &#x60;ACTIVE&#x60; state.  This operation can only be performed on users that have a &#x60;SUSPENDED&#x60; status.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task UnsuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update User Update a user&#x27;s profile and/or credentials using strict-update semantics.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="userId"></param>
        /// <param name="strict"> (optional)</param>
        ///  <returns>Task of IUser</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUser> UpdateUserAsync(IUser body, string userId, bool? strict = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

