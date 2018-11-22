// <copyright file="PoliciesClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class PoliciesClient : OktaClient, IPoliciesClient
    {
        /// <inheritdoc/>
        public async Task<T> GetPolicyAsync<T>(string policyId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicy
            => await GetPolicyAsync(policyId: policyId, cancellationToken: cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<T> CreatePolicyAsync<T>(IPolicy policy, bool? activate, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicy
            => await CreatePolicyAsync(policy, activate, cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<T> UpdatePolicyAsync<T>(IPolicy policy, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicy
            => await UpdatePolicyAsync(policy, policyId, cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<T> AddPolicyRuleAsync<T>(IPolicyRule policyRule, string policyId, bool? activate, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicyRule
            => await AddPolicyRuleAsync(policyRule, policyId, activate, cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<T> UpdatePolicyRuleAsync<T>(IPolicyRule policyRule, string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicyRule
            => await UpdatePolicyRuleAsync(policyRule, policyId, ruleId, cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<T> GetPolicyRuleAsync<T>(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicyRule
            => await GetPolicyRuleAsync(policyId, ruleId, cancellationToken).ConfigureAwait(false) as T;
    }
}
