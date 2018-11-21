// <copyright file="IPolicy.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public partial interface IPolicy
    {
        /// <summary>
        /// Gets a policy rule
        /// </summary>
        /// <typeparam name="T">The type of policy rule</typeparam>
        /// <param name="ruleId">The policy rule Id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The policy rule</returns>
        Task<T> GetPolicyRuleAsync<T>(string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicyRule;

        /// <summary>
        /// Creates a policy rule
        /// </summary>
        /// <typeparam name="T">The type of policy rule</typeparam>
        /// <param name="policyRule">The policy rule</param>
        /// <param name="activate">The activate flag</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The created policy rule</returns>
        Task<T> CreateRuleAsync<T>(PolicyRule policyRule, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IPolicyRule;
    }
}
