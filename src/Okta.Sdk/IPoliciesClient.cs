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
    }
}
