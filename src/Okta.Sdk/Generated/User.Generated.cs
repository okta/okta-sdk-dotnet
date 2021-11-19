// <copyright file="User.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    [ResourceObject(NullValueHandling = ResourceNullValueHandling.Include)] 
    public sealed partial class User : Resource, IUser
    
    {
        /// <inheritdoc/>
        public DateTimeOffset? Activated => GetDateTimeProperty("activated");
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public IUserCredentials Credentials 
        {
            get => GetResourceProperty<UserCredentials>("credentials");
            set => this["credentials"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastLogin => GetDateTimeProperty("lastLogin");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public DateTimeOffset? PasswordChanged => GetDateTimeProperty("passwordChanged");
        
        /// <inheritdoc/>
        public IUserProfile Profile 
        {
            get => GetResourceProperty<UserProfile>("profile");
            set => this["profile"] = value;
        }
        
        /// <inheritdoc/>
        public UserStatus Status => GetEnumProperty<UserStatus>("status");
        
        /// <inheritdoc/>
        public DateTimeOffset? StatusChanged => GetDateTimeProperty("statusChanged");
        
        /// <inheritdoc/>
        public UserStatus TransitioningToStatus => GetEnumProperty<UserStatus>("transitioningToStatus");
        
        /// <inheritdoc/>
        public IUserType Type 
        {
            get => GetResourceProperty<UserType>("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc />
        public Task<IForgotPasswordResponse> ForgotPasswordSetNewPasswordAsync(IUserCredentials user, 
            bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ForgotPasswordSetNewPasswordAsync(user, Id, sendEmail, cancellationToken);
        
        /// <inheritdoc />
        public Task<IForgotPasswordResponse> ForgotPasswordGenerateOneTimeTokenAsync(
            bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ForgotPasswordGenerateOneTimeTokenAsync(Id, sendEmail, cancellationToken);
        
        /// <inheritdoc />
        public Task<IRole> AssignRoleAsync(IAssignRoleRequest assignRoleRequest, 
            bool? disableNotifications = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.AssignRoleToUserAsync(assignRoleRequest, Id, disableNotifications, cancellationToken);
        
        /// <inheritdoc />
        public Task<IRole> GetRoleAsync(
            string roleId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.GetUserRoleAsync(Id, roleId, cancellationToken);
        
        /// <inheritdoc />
        public Task RemoveRoleAsync(
            string roleId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.RemoveRoleFromUserAsync(Id, roleId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IGroup> ListGroupTargets(
            string roleId, string after = null, int? limit = 20)
            => GetClient().Users.ListGroupTargetsForRole(Id, roleId, after, limit);
        
        /// <inheritdoc />
        public Task RemoveGroupTargetAsync(
            string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.RemoveGroupTargetFromRoleAsync(Id, roleId, groupId, cancellationToken);
        
        /// <inheritdoc />
        public Task AddGroupTargetAsync(
            string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.AddGroupTargetToRoleAsync(Id, roleId, groupId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IRole> ListAssignedRoles(
            string expand = null)
            => GetClient().Users.ListAssignedRolesForUser(Id, expand);
        
        /// <inheritdoc />
        public Task AddAllAppsAsTargetAsync(
            string roleId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.AddAllAppsAsTargetToRoleAsync(Id, roleId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2ScopeConsentGrant> ListGrants(
            string scopeId = null, string expand = null, string after = null, int? limit = 20)
            => GetClient().Users.ListUserGrants(Id, scopeId, expand, after, limit);
        
        /// <inheritdoc />
        public Task RevokeGrantsAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.RevokeUserGrantsAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task RevokeGrantAsync(
            string grantId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.RevokeUserGrantAsync(Id, grantId, cancellationToken);
        
        /// <inheritdoc />
        public Task RevokeGrantsForUserAndClientAsync(
            string clientId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.RevokeGrantsForUserAndClientAsync(Id, clientId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2RefreshToken> ListRefreshTokensForUserAndClient(
            string clientId, string expand = null, string after = null, int? limit = 20)
            => GetClient().Users.ListRefreshTokensForUserAndClient(Id, clientId, expand, after, limit);
        
        /// <inheritdoc />
        public Task RevokeTokenForUserAndClientAsync(
            string clientId, string tokenId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.RevokeTokenForUserAndClientAsync(Id, clientId, tokenId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IOAuth2RefreshToken> GetRefreshTokenForUserAndClientAsync(
            string clientId, string tokenId, string expand = null, int? limit = 20, string after = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.GetRefreshTokenForUserAndClientAsync(Id, clientId, tokenId, expand, limit, after, cancellationToken);
        
        /// <inheritdoc />
        public Task RevokeTokensForUserAndClientAsync(
            string clientId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.RevokeTokensForUserAndClientAsync(Id, clientId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2Client> ListClients(
            )
            => GetClient().Users.ListUserClients(Id);
        
        /// <inheritdoc />
        public Task<IUserActivationToken> ActivateAsync(
            bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ActivateUserAsync(Id, sendEmail, cancellationToken);
        
        /// <inheritdoc />
        public Task<IUserActivationToken> ReactivateAsync(
            bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ReactivateUserAsync(Id, sendEmail, cancellationToken);
        
        /// <inheritdoc />
        public Task DeactivateAsync(
            bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.DeactivateUserAsync(Id, sendEmail, cancellationToken);
        
        /// <inheritdoc />
        public Task SuspendAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.SuspendUserAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task UnsuspendAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.UnsuspendUserAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<IUser> ExpirePasswordAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ExpirePasswordAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<ITempPassword> ExpirePasswordAndGetTemporaryPasswordAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ExpirePasswordAndGetTemporaryPasswordAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task UnlockAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.UnlockUserAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task ResetFactorsAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ResetFactorsAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task DeleteFactorAsync(
            string factorId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.DeleteFactorAsync(Id, factorId, cancellationToken);
        
        /// <inheritdoc />
        public Task AddToGroupAsync(
            string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.AddUserToGroupAsync(groupId, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<IUserFactor> EnrollFactorAsync(IUserFactor body, 
            bool? updatePhone = false, string templateId = null, int? tokenLifetimeSeconds = 300, bool? activate = false, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.EnrollFactorAsync(body, Id, updatePhone, templateId, tokenLifetimeSeconds, activate, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IUserFactor> ListSupportedFactors(
            )
            => GetClient().UserFactors.ListSupportedFactors(Id);
        
        /// <inheritdoc />
        public ICollectionClient<IUserFactor> ListFactors(
            )
            => GetClient().UserFactors.ListFactors(Id);
        
        /// <inheritdoc />
        public ICollectionClient<ISecurityQuestion> ListSupportedSecurityQuestions(
            )
            => GetClient().UserFactors.ListSupportedSecurityQuestions(Id);
        
        /// <inheritdoc />
        public Task<IUserFactor> GetFactorAsync(
            string factorId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.GetFactorAsync(Id, factorId, cancellationToken);
        
        /// <inheritdoc />
        public Task SetLinkedObjectAsync(
            string primaryRelationshipName, string primaryUserId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.SetLinkedObjectForUserAsync(Id, primaryRelationshipName, primaryUserId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IIdentityProvider> ListIdentityProviders(
            )
            => GetClient().Users.ListUserIdentityProviders(Id);
        
        /// <inheritdoc />
        public ICollectionClient<IResponseLinks> GetLinkedObjects(
            string relationshipName, string after = null, int? limit = -1)
            => GetClient().Users.GetLinkedObjectsForUser(Id, relationshipName, after, limit);
        
        /// <inheritdoc />
        public Task ClearSessionsAsync(
            bool? oauthTokens = false, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ClearUserSessionsAsync(Id, oauthTokens, cancellationToken);
        
        /// <inheritdoc />
        public Task RemoveLinkedObjectAsync(
            string relationshipName, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.RemoveLinkedObjectForUserAsync(Id, relationshipName, cancellationToken);
        
    }
}
