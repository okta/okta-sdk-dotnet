// <copyright file="PoliciesClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class PoliciesClient : OktaClient, IPoliciesClient
    {
        /// <inheritdoc/>
        public async Task<T> GetPolicyAsync<T>(string policyId, CancellationToken cancellationToken = default)
            where T : class, IPolicy
            => await GetPolicyAsync(policyId: policyId, cancellationToken: cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<T> CreatePolicyAsync<T>(IPolicy policy, bool? activate, CancellationToken cancellationToken = default)
            where T : class, IPolicy
            => await CreatePolicyAsync(policy, activate, cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<T> UpdatePolicyAsync<T>(IPolicy policy, string policyId, CancellationToken cancellationToken = default)
            where T : class, IPolicy
            => await UpdatePolicyAsync(policy, policyId, cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<T> UpdatePolicyAsync<T>(IPolicy policy, CancellationToken cancellationToken = default)
            where T : class, IPolicy
            => await UpdatePolicyAsync(policy, policy?.Id, cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<T> AddPolicyRuleAsync<T>(IPolicyRule policyRule, string policyId, CancellationToken cancellationToken = default)
            where T : class, IPolicyRule
            => await CreatePolicyRuleAsync(policyRule, policyId, cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<T> UpdatePolicyRuleAsync<T>(IPolicyRule policyRule, string policyId, string ruleId, CancellationToken cancellationToken = default)
            where T : class, IPolicyRule
            => await UpdatePolicyRuleAsync(policyRule, policyId, ruleId, cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<T> GetPolicyRuleAsync<T>(string policyId, string ruleId, CancellationToken cancellationToken = default)
            where T : class, IPolicyRule
            => await GetPolicyRuleAsync(policyId, ruleId, cancellationToken).ConfigureAwait(false) as T;

        /// <inheritdoc/>
        public async Task<IPasswordPolicyRule> AddPolicyRuleAsync(AddPasswordPolicyRuleOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var policyRule = new PasswordPolicyRule
            {
                Type = options.Type,
                Name = options.Name,
                Conditions = new PasswordPolicyRuleConditions
                {
                    People = new PolicyPeopleCondition
                    {
                        Users = new UserCondition
                        {
                            Exclude = options.PeopleConditionExcludeUsers,
                            Include = options.PeopleConditionIncludeUsers,
                        },
                        Groups = new GroupCondition
                        {
                            Exclude = options.PeopleConditionExcludeGroups,
                            Include = options.PeopleConditionIncludeGroups,
                        },
                    },
                    Network = new PolicyNetworkCondition
                    {
                        Connection = options.NetworkConditionConnection,
                        Exclude = options.NetworkConditionExclude,
                        Include = options.NetworkConditionInclude,
                    },
                },
                Actions = new PasswordPolicyRuleActions
                {
                    PasswordChange = new PasswordPolicyRuleAction
                    {
                        Access = options.ActionPasswordChangeAccess,
                    },
                    SelfServicePasswordReset = new PasswordPolicyRuleAction
                    {
                        Access = options.ActionSelfServicePasswordResetAccess,
                    },
                    SelfServiceUnlock = new PasswordPolicyRuleAction
                    {
                        Access = options.ActionSelfServiceUnlockAccess,
                    },
                },
            };

            return await AddPolicyRuleAsync<IPasswordPolicyRule>(policyRule, options.PolicyId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IOktaSignOnPolicyRule> AddPolicyRuleAsync(AddSignOnPolicyRuleOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var policyRule = new OktaSignOnPolicyRule
            {
                Type = options.Type,
                Name = options.Name,
                Actions = new OktaSignOnPolicyRuleActions
                {
                    Signon = new OktaSignOnPolicyRuleSignonActions
                    {
                        Access = options.SignonActionAccess,
                        FactorLifetime = options.SignonActionFactorLifetime,
                        FactorPromptMode = options.SignonActionFactorPromptMode,
                        RememberDeviceByDefault = options.SignonActionRememberDeviceByDefault,
                        RequireFactor = options.SignonActionRequireFactor,
                        Session = new OktaSignOnPolicyRuleSignonSessionActions
                        {
                            UsePersistentCookie = options.SignonSessionUsePersistentCookie,
                            MaxSessionIdleMinutes = options.SignonSessionMaxSessionIdleMinutes,
                            MaxSessionLifetimeMinutes = options.SignonSessionMaxSessionLifetimeMinutes,
                        },
                    },
                },
                Conditions = new OktaSignOnPolicyRuleConditions
                {
                    Network = new PolicyNetworkCondition
                    {
                        Connection = options.NetworkConditionConnection,
                        Exclude = options.NetworkConditionExclude,
                        Include = options.NetworkConditionInclude,
                    },
                    People = new PolicyPeopleCondition
                    {
                        Users = new UserCondition
                        {
                            Exclude = options.PeopleConditionExcludeUsers,
                            Include = options.PeopleConditionIncludeUsers,
                        },
                        Groups = new GroupCondition
                        {
                            Exclude = options.PeopleConditionExcludeGroups,
                            Include = options.PeopleConditionIncludeGroups,
                        },
                    },
                    AuthContext = new PolicyRuleAuthContextCondition
                    {
                        AuthType = options.AuthContextConditionAuthType,
                    },
                },
            };

            return await AddPolicyRuleAsync<IOktaSignOnPolicyRule>(policyRule, options.PolicyId, cancellationToken).ConfigureAwait(false);
        }
    }
}
