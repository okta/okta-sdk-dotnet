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
    }
}
