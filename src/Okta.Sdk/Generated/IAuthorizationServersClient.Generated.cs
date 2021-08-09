// <copyright file="IAuthorizationServersClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta AuthorizationServer resources.</summary>
    public partial interface IAuthorizationServersClient
    {
        /// <summary>
        /// Success
        /// </summary>
        /// <param name="q"></param>
        /// <param name="limit"></param>
        /// <param name="after"></param>
        /// <returns>A collection of <see cref="IAuthorizationServer"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IAuthorizationServer> ListAuthorizationServers(string q = null, string limit = null, string after = null);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authorizationServer">The <see cref="IAuthorizationServer"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAuthorizationServer"/> response.</returns>
        Task<IAuthorizationServer> CreateAuthorizationServerAsync(IAuthorizationServer authorizationServer, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAuthorizationServer"/> response.</returns>
        Task<IAuthorizationServer> GetAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authorizationServer">The <see cref="IAuthorizationServer"/> resource.</param>
        /// <param name="authServerId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAuthorizationServer"/> response.</returns>
        Task<IAuthorizationServer> UpdateAuthorizationServerAsync(IAuthorizationServer authorizationServer, string authServerId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <returns>A collection of <see cref="IOAuth2Claim"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IOAuth2Claim> ListOAuth2Claims(string authServerId);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="oAuth2Claim">The <see cref="IOAuth2Claim"/> resource.</param>
        /// <param name="authServerId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOAuth2Claim"/> response.</returns>
        Task<IOAuth2Claim> CreateOAuth2ClaimAsync(IOAuth2Claim oAuth2Claim, string authServerId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="claimId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOAuth2Claim"/> response.</returns>
        Task<IOAuth2Claim> GetOAuth2ClaimAsync(string authServerId, string claimId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="oAuth2Claim">The <see cref="IOAuth2Claim"/> resource.</param>
        /// <param name="authServerId"></param>
        /// <param name="claimId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOAuth2Claim"/> response.</returns>
        Task<IOAuth2Claim> UpdateOAuth2ClaimAsync(IOAuth2Claim oAuth2Claim, string authServerId, string claimId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="claimId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteOAuth2ClaimAsync(string authServerId, string claimId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <returns>A collection of <see cref="IOAuth2Client"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IOAuth2Client> ListOAuth2ClientsForAuthorizationServer(string authServerId);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="clientId"></param>
        /// <param name="expand"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="IOAuth2RefreshToken"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IOAuth2RefreshToken> ListRefreshTokensForAuthorizationServerAndClient(string authServerId, string clientId, string expand = null, string after = null, int? limit = -1);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="clientId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RevokeRefreshTokensForAuthorizationServerAndClientAsync(string authServerId, string clientId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="clientId"></param>
        /// <param name="tokenId"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOAuth2RefreshToken"/> response.</returns>
        Task<IOAuth2RefreshToken> GetRefreshTokenForAuthorizationServerAndClientAsync(string authServerId, string clientId, string tokenId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="clientId"></param>
        /// <param name="tokenId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RevokeRefreshTokenForAuthorizationServerAndClientAsync(string authServerId, string clientId, string tokenId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <returns>A collection of <see cref="IJsonWebKey"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IJsonWebKey> ListAuthorizationServerKeys(string authServerId);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="jwkUse">The <see cref="IJwkUse"/> resource.</param>
        /// <param name="authServerId"></param>
        /// <returns>A collection of <see cref="IJsonWebKey"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IJsonWebKey> RotateAuthorizationServerKeys(IJwkUse jwkUse, string authServerId);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task ActivateAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeactivateAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <returns>A collection of <see cref="IAuthorizationServerPolicy"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IAuthorizationServerPolicy> ListAuthorizationServerPolicies(string authServerId);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authorizationServerPolicy">The <see cref="IAuthorizationServerPolicy"/> resource.</param>
        /// <param name="authServerId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAuthorizationServerPolicy"/> response.</returns>
        Task<IAuthorizationServerPolicy> CreateAuthorizationServerPolicyAsync(IAuthorizationServerPolicy authorizationServerPolicy, string authServerId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAuthorizationServerPolicy"/> response.</returns>
        Task<IAuthorizationServerPolicy> GetAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authorizationServerPolicy">The <see cref="IAuthorizationServerPolicy"/> resource.</param>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAuthorizationServerPolicy"/> response.</returns>
        Task<IAuthorizationServerPolicy> UpdateAuthorizationServerPolicyAsync(IAuthorizationServerPolicy authorizationServerPolicy, string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Activate Authorization Server Policy
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task ActivateAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivate Authorization Server Policy
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeactivateAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates all policy rules for the specified Custom Authorization Server and Policy.
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="authServerId"></param>
        /// <returns>A collection of <see cref="IAuthorizationServerPolicyRule"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IAuthorizationServerPolicyRule> ListAuthorizationServerPolicyRules(string policyId, string authServerId);

        /// <summary>
        /// Creates a policy rule for the specified Custom Authorization Server and Policy.
        /// </summary>
        /// <param name="authorizationServerPolicyRule">The <see cref="IAuthorizationServerPolicyRule"/> resource.</param>
        /// <param name="policyId"></param>
        /// <param name="authServerId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAuthorizationServerPolicyRule"/> response.</returns>
        Task<IAuthorizationServerPolicyRule> CreateAuthorizationServerPolicyRuleAsync(IAuthorizationServerPolicyRule authorizationServerPolicyRule, string policyId, string authServerId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns a Policy Rule by ID that is defined in the specified Custom Authorization Server and Policy.
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="authServerId"></param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAuthorizationServerPolicyRule"/> response.</returns>
        Task<IAuthorizationServerPolicyRule> GetAuthorizationServerPolicyRuleAsync(string policyId, string authServerId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the configuration of the Policy Rule defined in the specified Custom Authorization Server and Policy.
        /// </summary>
        /// <param name="authorizationServerPolicyRule">The <see cref="IAuthorizationServerPolicyRule"/> resource.</param>
        /// <param name="policyId"></param>
        /// <param name="authServerId"></param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAuthorizationServerPolicyRule"/> response.</returns>
        Task<IAuthorizationServerPolicyRule> UpdateAuthorizationServerPolicyRuleAsync(IAuthorizationServerPolicyRule authorizationServerPolicyRule, string policyId, string authServerId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a Policy Rule defined in the specified Custom Authorization Server and Policy.
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="authServerId"></param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteAuthorizationServerPolicyRuleAsync(string policyId, string authServerId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Activate Authorization Server Policy Rule
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task ActivateAuthorizationServerPolicyRuleAsync(string authServerId, string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivate Authorization Server Policy Rule
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeactivateAuthorizationServerPolicyRuleAsync(string authServerId, string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="q"></param>
        /// <param name="filter"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="IOAuth2Scope"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IOAuth2Scope> ListOAuth2Scopes(string authServerId, string q = null, string filter = null, string cursor = null, int? limit = -1);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="oAuth2Scope">The <see cref="IOAuth2Scope"/> resource.</param>
        /// <param name="authServerId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOAuth2Scope"/> response.</returns>
        Task<IOAuth2Scope> CreateOAuth2ScopeAsync(IOAuth2Scope oAuth2Scope, string authServerId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="scopeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOAuth2Scope"/> response.</returns>
        Task<IOAuth2Scope> GetOAuth2ScopeAsync(string authServerId, string scopeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="oAuth2Scope">The <see cref="IOAuth2Scope"/> resource.</param>
        /// <param name="authServerId"></param>
        /// <param name="scopeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOAuth2Scope"/> response.</returns>
        Task<IOAuth2Scope> UpdateOAuth2ScopeAsync(IOAuth2Scope oAuth2Scope, string authServerId, string scopeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="authServerId"></param>
        /// <param name="scopeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteOAuth2ScopeAsync(string authServerId, string scopeId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
