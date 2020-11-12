// <copyright file="IPoliciesClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta Policy resources.</summary>
    public partial interface IPoliciesClient
    {
        /// <summary>
        /// Gets all policies with the specified type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="expand"></param>
        /// <returns>A collection of <see cref="IAuthorizationServerPolicy"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IAuthorizationServerPolicy> ListPolicies(string type, string status = null, string expand = "");

        /// <summary>
        /// Creates a policy.
        /// </summary>
        /// <param name="policy">The <see cref="IPolicy"/> resource.</param>
        /// <param name="activate"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IPolicy"/> response.</returns>
        Task<IPolicy> CreatePolicyAsync(IPolicy policy, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes a policy.
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeletePolicyAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a policy.
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IPolicy"/> response.</returns>
        Task<IPolicy> GetPolicyAsync(string policyId, string expand = "", CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a policy.
        /// </summary>
        /// <param name="policy">The <see cref="IPolicy"/> resource.</param>
        /// <param name="policyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IPolicy"/> response.</returns>
        Task<IPolicy> UpdatePolicyAsync(IPolicy policy, string policyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Activates a policy.
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task ActivatePolicyAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivates a policy.
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeactivatePolicyAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates all policy rules.
        /// </summary>
        /// <param name="policyId"></param>
        /// <returns>A collection of <see cref="IPolicyRule"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IPolicyRule> ListPolicyRules(string policyId);

        /// <summary>
        /// Creates a policy rule.
        /// </summary>
        /// <param name="policyRule">The <see cref="IPolicyRule"/> resource.</param>
        /// <param name="policyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IPolicyRule"/> response.</returns>
        Task<IPolicyRule> CreatePolicyRuleAsync(IPolicyRule policyRule, string policyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes a policy rule.
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeletePolicyRuleAsync(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a policy rule.
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IPolicyRule"/> response.</returns>
        Task<IPolicyRule> GetPolicyRuleAsync(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a policy rule.
        /// </summary>
        /// <param name="policyRule">The <see cref="IPolicyRule"/> resource.</param>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IPolicyRule"/> response.</returns>
        Task<IPolicyRule> UpdatePolicyRuleAsync(IPolicyRule policyRule, string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Activates a policy rule.
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task ActivatePolicyRuleAsync(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivates a policy rule.
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeactivatePolicyRuleAsync(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
