// <copyright file="Policy.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <inheritdoc cref="Policy"/>
    public partial class Policy
    {
        /// <inheritdoc/>
        public async Task<T> GetPolicyRuleAsync<T>(string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicyRule
            => await GetClient().Policies.GetPolicyRuleAsync(Id, ruleId, cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<T> CreateRuleAsync<T>(PolicyRule policyRule, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicyRule
            => await GetClient().Policies.CreatePolicyRuleAsync(policyRule, Id, cancellationToken).ConfigureAwait(false) as T;
    }
}
