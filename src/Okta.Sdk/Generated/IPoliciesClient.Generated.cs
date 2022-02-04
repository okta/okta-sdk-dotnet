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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IPoliciesClient
    {
        /// <summary>
        ///  Activates a policy.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="policyId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task ActivatePolicyAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Activates a policy rule.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task ActivatePolicyRuleAsync(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Creates a policy.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="activate"> (optional, default to true)</param>
        ///  <returns>Task of IPolicy</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IPolicy> CreatePolicyAsync(IPolicy body, bool? activate = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Creates a policy rule.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="policyId"></param>
        ///  <returns>Task of IPolicyRule</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IPolicyRule> CreatePolicyRuleAsync(IPolicyRule body, string policyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Deactivates a policy.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="policyId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeactivatePolicyAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Deactivates a policy rule.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeactivatePolicyRuleAsync(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Removes a policy.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="policyId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeletePolicyAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Removes a policy rule.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeletePolicyRuleAsync(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Gets a policy.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="policyId"></param>
        /// <param name="expand"> (optional)</param>
        ///  <returns>Task of IPolicy</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IPolicy> GetPolicyAsync(string policyId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Gets a policy rule.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        ///  <returns>Task of IPolicyRule</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IPolicyRule> GetPolicyRuleAsync(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Gets all policies with the specified type.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="type"></param>
        /// <param name="status"> (optional)</param>
        /// <param name="expand"> (optional)</param>
        /// A collection of <see cref="IPoliciesClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IAuthorizationServerPolicy> ListPolicies(string type, string status = null, string expand = null);
        /// <summary>
        ///  Enumerates all policy rules.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="policyId"></param>
        /// A collection of <see cref="IPoliciesClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IPolicyRule> ListPolicyRules(string policyId);
        /// <summary>
        ///  Updates a policy.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="policyId"></param>
        ///  <returns>Task of IPolicy</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IPolicy> UpdatePolicyAsync(IPolicy body, string policyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Updates a policy rule.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="policyId"></param>
        /// <param name="ruleId"></param>
        ///  <returns>Task of IPolicyRule</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IPolicyRule> UpdatePolicyRuleAsync(IPolicyRule body, string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

