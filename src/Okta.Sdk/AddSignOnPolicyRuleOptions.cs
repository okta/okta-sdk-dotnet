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
        /// Gets or sets an identifier of the policy
        /// </summary>
        public string PolicyId { get; set; }

        /// <summary>
        /// Gets or sets a name of the rule
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets an access property for Signon Action.
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#signon-action-object">the API documentation on Signon Action.</remarks>
        public string SignonActionAccess { get; set; }

        /// <summary>
        /// Gets or sets the requireFactor property for Signon Action
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#signon-action-object">the API documentation on Signon Action.</remarks>
        public bool? SignonActionRequireFactor { get; set; }

        /// <summary>
        /// Gets or sets the rememberDeviceByDefault property for Signon Action
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#signon-action-object">the API documentation on Signon Action.</remarks>
        public bool? SignonActionRememberDeviceByDefault { get; set; }

        /// <summary>
        /// Gets or sets the factorPromptMode property for Signon Action
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#signon-action-object">the API documentation on Signon Action.</remarks>
        public string SignonActionFactorPromptMode { get; set; }

        /// <summary>
        /// Gets or sets the  factorLifetime property for Signon Action
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#signon-action-object">the API documentation on Signon Action.</remarks>
        public int? SignonActionFactorLifetime { get; set; }

        /// <summary>
        /// Gets or sets the Signon Session usePersistentCookie value
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#signon-session-object">the API documentation on Signon Session.</remarks>
        public bool? SignonSessionUsePersistentCookie { get; set; }

        /// <summary>
        /// Gets or sets the Signon Session maxSessionIdleMinutes value
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#signon-session-object">the API documentation on Signon Session.</remarks>
        public int? SignonSessionMaxSessionIdleMinutes { get; set; }

        /// <summary>
        /// Gets or sets the Signon Session maxSessionLifetimeMinutes value
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#signon-session-object">the API documentation on Signon Session.</remarks>
        public int? SignonSessionMaxSessionLifetimeMinutes { get; set; }

        /// <summary>
        /// Gets or sets an AuthContext Condition object value
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#authcontext-condition-object">the API documentation on AuthContext Condition.</remarks>
        public string AuthContextConditionAuthType { get; set; }

        /// <summary>
        /// Gets or sets a network selection mode
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#network-condition-object">the API documentation on policy objects.</a></remarks>
        public string NetworkConditionConnection { get; set; }

        /// <summary>
        /// Gets or sets the zones to include
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#network-condition-object">the API documentation on policy objects.</a></remarks>
        public IList<string> NetworkConditionInclude { get; set; }

        /// <summary>
        /// Gets or sets the zones to exclude
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/reference/api/policy/#network-condition-object">the API documentation on policy objects.</a></remarks>
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
