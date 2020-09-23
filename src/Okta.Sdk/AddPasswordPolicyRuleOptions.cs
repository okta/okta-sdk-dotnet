// <copyright file="AddPasswordPolicyRuleOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for password policy rule options
    /// </summary>
    public sealed class AddPasswordPolicyRuleOptions
    {
        /// <summary>
        /// Gets a type a policy
        /// </summary>
        public string Type => "PASSWORD";

        /// <summary>
        /// Gets or sets a name of the rule
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets an identifier of the policy
        /// </summary>
        public string PolicyId { get; set; }

        /// <summary>
        /// Gets or sets a list of users to be excluded
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#people-condition-object">the API documentation on policy objects.</a></remarks>
        public IList<string> PeopleConditionExcludeUsers { get; set; }

        /// <summary>
        /// Gets or sets a list of users to be included
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#people-condition-object">the API documentation on policy objects.</a></remarks>
        public IList<string> PeopleConditionIncludeUsers { get; set; }

        /// <summary>
        /// Gets or sets a list of groups whose users to be excluded
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#people-condition-object">the API documentation on policy objects.</a></remarks>
        public IList<string> PeopleConditionExcludeGroups { get; set; }

        /// <summary>
        /// Gets or sets a list of groups whose users to be included
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#people-condition-object">the API documentation on policy objects.</a></remarks>
        public IList<string> PeopleConditionIncludeGroups { get; set; }

        /// <summary>
        /// Gets or sets a network selection mode
        /// </summary>
        public string NetworkConditionConnection { get; set; }

        /// <summary>
        /// Gets or sets the zones to include
        /// </summary>
        public IList<string> NetworkConditionInclude { get; set; }

        /// <summary>
        /// Gets or sets the zones to exclude
        /// </summary>
        public IList<string> NetworkConditionExclude { get; set; }

        /// <summary>
        /// Gets or sets a rule for PasswordChange Access
        /// </summary>
        public string PasswordChangeAccess { get; set; }

        /// <summary>
        /// Gets or sets a rule for SelfServicePasswordReset Access
        /// </summary>
        public string SelfServicePasswordResetAccess { get; set; }

        /// <summary>
        /// Gets or sets a rule for SelfServiceUnlock Access
        /// </summary>
        public string SelfServiceUnlockAccess { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddPasswordPolicyRuleOptions"/> class.
        /// </summary>
        /// <param name="policyId">Password policy id</param>
        public AddPasswordPolicyRuleOptions(string policyId)
        {
            PolicyId = policyId;
        }
    }
}
