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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IAuthorizationServersClient
    {
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task ActivateAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Activate Authorization Server Policy
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task ActivateAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Activate Authorization Server Policy Rule
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task ActivateAuthorizationServerPolicyRuleAsync(string authServerId, string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of IAuthorizationServer</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IAuthorizationServer> CreateAuthorizationServerAsync(IAuthorizationServer body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authServerId"></param>
        ///  <returns>Task of IAuthorizationServerPolicy</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IAuthorizationServerPolicy> CreateAuthorizationServerPolicyAsync(IAuthorizationServerPolicy body, string authServerId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Creates a policy rule for the specified Custom Authorization Server and Policy.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="policyId"></param>
        /// <param name="authServerId"></param>
        ///  <returns>Task of IAuthorizationServerPolicyRule</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IAuthorizationServerPolicyRule> CreateAuthorizationServerPolicyRuleAsync(IAuthorizationServerPolicyRule body, string policyId, string authServerId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authServerId"></param>
        ///  <returns>Task of IOAuth2Claim</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IOAuth2Claim> CreateOAuth2ClaimAsync(IOAuth2Claim body, string authServerId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authServerId"></param>
        ///  <returns>Task of IOAuth2Scope</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IOAuth2Scope> CreateOAuth2ScopeAsync(IOAuth2Scope body, string authServerId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeactivateAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Deactivate Authorization Server Policy
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeactivateAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Deactivate Authorization Server Policy Rule
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeactivateAuthorizationServerPolicyRuleAsync(string authServerId, string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Deletes a Policy Rule defined in the specified Custom Authorization Server and Policy.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="policyId"></param>
        /// <param name="authServerId"></param>
        /// <param name="ruleId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteAuthorizationServerPolicyRuleAsync(string policyId, string authServerId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="claimId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteOAuth2ClaimAsync(string authServerId, string claimId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="scopeId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteOAuth2ScopeAsync(string authServerId, string scopeId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        ///  <returns>Task of IAuthorizationServer</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IAuthorizationServer> GetAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        ///  <returns>Task of IAuthorizationServerPolicy</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IAuthorizationServerPolicy> GetAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Returns a Policy Rule by ID that is defined in the specified Custom Authorization Server and Policy.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="policyId"></param>
        /// <param name="authServerId"></param>
        /// <param name="ruleId"></param>
        ///  <returns>Task of IAuthorizationServerPolicyRule</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IAuthorizationServerPolicyRule> GetAuthorizationServerPolicyRuleAsync(string policyId, string authServerId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="claimId"></param>
        ///  <returns>Task of IOAuth2Claim</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IOAuth2Claim> GetOAuth2ClaimAsync(string authServerId, string claimId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="scopeId"></param>
        ///  <returns>Task of IOAuth2Scope</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IOAuth2Scope> GetOAuth2ScopeAsync(string authServerId, string scopeId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="clientId"></param>
        /// <param name="tokenId"></param>
        /// <param name="expand"> (optional)</param>
        ///  <returns>Task of IOAuth2RefreshToken</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IOAuth2RefreshToken> GetRefreshTokenForAuthorizationServerAndClientAsync(string authServerId, string clientId, string tokenId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// A collection of <see cref="IAuthorizationServersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IJsonWebKey> ListAuthorizationServerKeys(string authServerId);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// A collection of <see cref="IAuthorizationServersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IAuthorizationServerPolicy> ListAuthorizationServerPolicies(string authServerId);
        /// <summary>
        ///  Enumerates all policy rules for the specified Custom Authorization Server and Policy.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="policyId"></param>
        /// <param name="authServerId"></param>
        /// A collection of <see cref="IAuthorizationServersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IAuthorizationServerPolicyRule> ListAuthorizationServerPolicyRules(string policyId, string authServerId);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="q"> (optional)</param>
        /// <param name="limit"> (optional)</param>
        /// <param name="after"> (optional)</param>
        /// A collection of <see cref="IAuthorizationServersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IAuthorizationServer> ListAuthorizationServers(string q = null, string limit = null, string after = null);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// A collection of <see cref="IAuthorizationServersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IOAuth2Claim> ListOAuth2Claims(string authServerId);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// A collection of <see cref="IAuthorizationServersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IOAuth2Client> ListOAuth2ClientsForAuthorizationServer(string authServerId);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="q"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="cursor"> (optional)</param>
        /// <param name="limit"> (optional, default to -1)</param>
        /// A collection of <see cref="IAuthorizationServersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IOAuth2Scope> ListOAuth2Scopes(string authServerId, string q = null, string filter = null, string cursor = null, int? limit = null);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="clientId"></param>
        /// <param name="expand"> (optional)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to -1)</param>
        /// A collection of <see cref="IAuthorizationServersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IOAuth2RefreshToken> ListRefreshTokensForAuthorizationServerAndClient(string authServerId, string clientId, string expand = null, string after = null, int? limit = null);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="clientId"></param>
        /// <param name="tokenId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RevokeRefreshTokenForAuthorizationServerAndClientAsync(string authServerId, string clientId, string tokenId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="authServerId"></param>
        /// <param name="clientId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RevokeRefreshTokensForAuthorizationServerAndClientAsync(string authServerId, string clientId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authServerId"></param>
        /// A collection of <see cref="IAuthorizationServersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IJsonWebKey> RotateAuthorizationServerKeys(IJwkUse body, string authServerId);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authServerId"></param>
        ///  <returns>Task of IAuthorizationServer</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IAuthorizationServer> UpdateAuthorizationServerAsync(IAuthorizationServer body, string authServerId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authServerId"></param>
        /// <param name="policyId"></param>
        ///  <returns>Task of IAuthorizationServerPolicy</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IAuthorizationServerPolicy> UpdateAuthorizationServerPolicyAsync(IAuthorizationServerPolicy body, string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Updates the configuration of the Policy Rule defined in the specified Custom Authorization Server and Policy.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="policyId"></param>
        /// <param name="authServerId"></param>
        /// <param name="ruleId"></param>
        ///  <returns>Task of IAuthorizationServerPolicyRule</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IAuthorizationServerPolicyRule> UpdateAuthorizationServerPolicyRuleAsync(IAuthorizationServerPolicyRule body, string policyId, string authServerId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authServerId"></param>
        /// <param name="claimId"></param>
        ///  <returns>Task of IOAuth2Claim</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IOAuth2Claim> UpdateOAuth2ClaimAsync(IOAuth2Claim body, string authServerId, string claimId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authServerId"></param>
        /// <param name="scopeId"></param>
        ///  <returns>Task of IOAuth2Scope</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IOAuth2Scope> UpdateOAuth2ScopeAsync(IOAuth2Scope body, string authServerId, string scopeId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

