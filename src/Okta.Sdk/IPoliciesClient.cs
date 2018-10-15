// <copyright file="IPoliciesClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta Policies resources.</summary>
    public partial interface IPoliciesClient
    {
        /// <summary>
        /// Gets a policy by id
        /// </summary>
        /// <typeparam name="T">The policy type</typeparam>
        /// <param name="policyId">The policy id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IPolicy"/> response.</returns>
        Task<T> GetPolicyAsync<T>(string policyId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicy;

        /// <summary>
        /// Creates a policy
        /// </summary>
        /// <typeparam name="T">The policy type</typeparam>
        /// <param name="policy">The <see cref="IPolicy"/> resource.</param>
        /// <param name="activate">The activate flag</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IPolicy"/> response.</returns>
        Task<T> CreatePolicyAsync<T>(IPolicy policy, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicy;

        /// <summary>
        /// Updates a policy
        /// </summary>
        /// <typeparam name="T">The policy type</typeparam>
        /// <param name="policy">The <see cref="IPolicy"/> resource.</param>
        /// <param name="policyId">The policy ID</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IPolicy"/> response.</returns>
        Task<T> UpdatePolicyAsync<T>(IPolicy policy, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicy;

        /// <summary>
        /// Creates a policy rule
        /// </summary>
        /// <typeparam name="T">The policy Rule type</typeparam>
        /// <param name="policyRule">The <see cref="IPolicyRule"/> resource.</param>
        /// <param name="policyId">The policy ID</param>
        /// <param name="activate">The activate flag</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IPolicyRule"/> response.</returns>
        Task<T> AddPolicyRuleAsync<T>(IPolicyRule policyRule, string policyId, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicyRule;

        /// <summary>
        /// Updates a policy rule
        /// </summary>
        /// <typeparam name="T">The policy Rule type</typeparam>
        /// <param name="policyRule">The <see cref="IPolicyRule"/> resource.</param>
        /// <param name="policyId">The policy ID</param>
        /// <param name="ruleId">The rule ID</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IPolicyRule"/> response.</returns>
        Task<T> UpdatePolicyRuleAsync<T>(IPolicyRule policyRule, string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicyRule;

        /// <summary>
        /// Gets a Policy Rule
        /// </summary>
        /// <typeparam name="T">The policy Rule type</typeparam>
        /// <param name="policyId">The policy ID</param>
        /// <param name="ruleId">The rule ID</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IPolicyRule"/> response.</returns>
        Task<T> GetPolicyRuleAsync<T>(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicyRule;
    }
}
