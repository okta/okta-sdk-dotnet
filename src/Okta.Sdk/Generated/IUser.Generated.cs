// <copyright file="IUser.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a User resource in the Okta API.</summary>
    public partial interface IUser : IResource
    {
        DateTimeOffset? Activated { get; }

        DateTimeOffset? Created { get; }

        IUserCredentials Credentials { get; set; }

        string Id { get; }

        DateTimeOffset? LastLogin { get; }

        DateTimeOffset? LastUpdated { get; }

        DateTimeOffset? PasswordChanged { get; }

        IUserProfile Profile { get; set; }

        UserStatus Status { get; set; }

        DateTimeOffset? StatusChanged { get; }

        UserStatus TransitioningToStatus { get; set; }

        IUserType Type { get; set; }

        Task<IRole> AssignRoleAsync(IAssignRoleRequest assignRoleRequest, 
            string disableNotifications = null, CancellationToken cancellationToken = default(CancellationToken));

        Task RemoveRoleAsync(
            string roleId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IGroup> ListGroupTargets(
            string roleId, string after = null, int? limit = 20);

        Task RemoveGroupTargetAsync(
            string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        Task AddGroupTargetAsync(
            string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IRole> ListAssignedRoles(
            string expand = null);

        Task AddAllAppsAsTargetAsync(
            string roleId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IOAuth2ScopeConsentGrant> ListGrants(
            string scopeId = null, string expand = null, string after = null, int? limit = 20);

        Task RevokeGrantsAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task RevokeGrantAsync(
            string grantId, CancellationToken cancellationToken = default(CancellationToken));

        Task RevokeGrantsForUserAndClientAsync(
            string clientId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IOAuth2RefreshToken> ListRefreshTokensForUserAndClient(
            string clientId, string expand = null, string after = null, int? limit = 20);

        Task RevokeTokenForUserAndClientAsync(
            string clientId, string tokenId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IOAuth2RefreshToken> GetRefreshTokenForUserAndClientAsync(
            string clientId, string tokenId, string expand = null, int? limit = 20, string after = null, CancellationToken cancellationToken = default(CancellationToken));

        Task RevokeTokensForUserAndClientAsync(
            string clientId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IOAuth2Client> ListClients(
            );

        Task<IUserActivationToken> ActivateAsync(
            bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken));

        Task<IUserActivationToken> ReactivateAsync(
            bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken));

        Task DeactivateAsync(
            bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken));

        Task SuspendAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task UnsuspendAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IUser> ExpirePasswordAsync(
            bool? tempPassword = false, CancellationToken cancellationToken = default(CancellationToken));

        Task UnlockAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task ResetFactorsAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteFactorAsync(
            string factorId, CancellationToken cancellationToken = default(CancellationToken));

        Task AddToGroupAsync(
            string groupId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IUserFactor> EnrollFactorAsync(IUserFactor userFactor, 
            bool? updatePhone = false, string templateId = null, int? tokenLifetimeSeconds = 300, bool? activate = false, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IUserFactor> ListSupportedFactors(
            );

        ICollectionClient<IUserFactor> ListFactors(
            );

        ICollectionClient<ISecurityQuestion> ListSupportedSecurityQuestions(
            );

        Task<IUserFactor> GetFactorAsync(
            string factorId, CancellationToken cancellationToken = default(CancellationToken));

        Task SetLinkedObjectAsync(
            string primaryRelationshipName, string primaryUserId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IIdentityProvider> ListIdentityProviders(
            );

        ICollectionClient<IResponseLinks> GetLinkedObjects(
            string relationshipName, string after = null, int? limit = -1);

        Task ClearSessionsAsync(
            bool? oauthTokens = false, CancellationToken cancellationToken = default(CancellationToken));

        Task RemoveLinkedObjectAsync(
            string relationshipName, CancellationToken cancellationToken = default(CancellationToken));

    }
}
