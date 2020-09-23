// <copyright file="AddPasswordPolicyRuleOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for sign on rule options
    /// </summary>
    public sealed class AddSignOnPolicyRuleOptions
    {
        /// <summary>
        /// Gets a type of a policy
        /// </summary>
        public string Type => "SIGN_ON";

        /// <summary>
        /// Gets or sets a name of the rule
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets an identifier of the policy
        /// </summary>
        public string PolicyId { get; set; }

        /// <summary>
        /// Gets or sets an access
        /// </summary>
        public string Access { get; set; }

        /// <summary>
        /// Gets or sets the requireFactor parameter
        /// </summary>
        public bool? RequireFactor { get; set; }

        /// <summary>
        /// Gets or sets the rememberDeviceByDefault parameter
        /// </summary>
        public bool? RememberDeviceByDefault { get; set; }

        /// <summary>
        /// Gets or sets the factorPromptMode parameter
        /// </summary>
        public string FactorPromptMode { get; set; }

        /// <summary>
        /// Gets or sets the factorLifetime parameter
        /// </summary>
        public int? FactorLifetime { get; set; }

        /// <summary>
        /// Gets or sets the usePersistentCookie parameter
        /// </summary>
        public bool? UsePersistentCookie { get; set; }

        /// <summary>
        /// Gets or sets the maxSessionIdleMinutes parameter
        /// </summary>
        public int? MaxSessionIdleMinutes { get; set; }

        /// <summary>
        /// Gets or sets the maxSessionLifetimeMinutes parameter
        /// </summary>
        public int? MaxSessionLifetimeMinutes { get; set; }

        /// <summary>
        /// Gets or sets an authentication entry point
        /// </summary>
        public string AuthType { get; set; }

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
        /// Initializes a new instance of the <see cref="AddSignOnPolicyRuleOptions"/> class.
        /// </summary>
        /// <param name="policyId">SignOn policy id</param>
        public AddSignOnPolicyRuleOptions(string policyId)
        {
            PolicyId = policyId;
        }
    }
}
