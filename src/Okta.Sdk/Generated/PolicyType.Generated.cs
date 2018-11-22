// <copyright file="PolicyType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of PolicyType values in the Okta API.
    /// </summary>
    public sealed class PolicyType : StringEnum
    {
        /// <summary>The OAUTH_AUTHORIZATION_POLICY PolicyType.</summary>
        public static PolicyType OauthAuthorizationPolicy = new PolicyType("OAUTH_AUTHORIZATION_POLICY");

        /// <summary>The OKTA_SIGN_ON PolicyType.</summary>
        public static PolicyType OktaSignOn = new PolicyType("OKTA_SIGN_ON");

        /// <summary>The PASSWORD PolicyType.</summary>
        public static PolicyType Password = new PolicyType("PASSWORD");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="PolicyType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator PolicyType(string value) => new PolicyType(value);

        /// <summary>
        /// Creates a new <see cref="PolicyType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public PolicyType(string value)
            : base(value)
        {
        }

    }
}
