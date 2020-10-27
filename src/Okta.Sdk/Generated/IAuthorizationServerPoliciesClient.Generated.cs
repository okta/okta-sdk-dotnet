// <copyright file="IAuthorizationServerPoliciesClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta AuthorizationServerPolicy resources.</summary>
    public partial interface IAuthorizationServerPoliciesClient
    {
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
        /// <param name="policyRule">The <see cref="IAuthorizationServerPolicyRule"/> resource.</param>
        /// <param name="policyId"></param>
        /// <param name="authServerId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAuthorizationServerPolicyRule"/> response.</returns>
        Task<IAuthorizationServerPolicyRule> CreateAuthorizationServerPolicyRuleAsync(IAuthorizationServerPolicyRule policyRule, string policyId, string authServerId, CancellationToken cancellationToken = default(CancellationToken));

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
        /// <param name="policyId"></param>
        /// <param name="authServerId"></param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAuthorizationServerPolicyRule"/> response.</returns>
        Task<IAuthorizationServerPolicyRule> UpdateAuthorizationServerPolicyRuleAsync(string policyId, string authServerId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
