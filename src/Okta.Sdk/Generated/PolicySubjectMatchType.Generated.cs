// <copyright file="PolicySubjectMatchType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of PolicySubjectMatchType values in the Okta API.
    /// </summary>
    public sealed class PolicySubjectMatchType : StringEnum
    {
        /// <summary>The USERNAME PolicySubjectMatchType.</summary>
        public static PolicySubjectMatchType Username = new PolicySubjectMatchType("USERNAME");

        /// <summary>The EMAIL PolicySubjectMatchType.</summary>
        public static PolicySubjectMatchType Email = new PolicySubjectMatchType("EMAIL");

        /// <summary>The USERNAME_OR_EMAIL PolicySubjectMatchType.</summary>
        public static PolicySubjectMatchType UsernameOrEmail = new PolicySubjectMatchType("USERNAME_OR_EMAIL");

        /// <summary>The CUSTOM_ATTRIBUTE PolicySubjectMatchType.</summary>
        public static PolicySubjectMatchType CustomAttribute = new PolicySubjectMatchType("CUSTOM_ATTRIBUTE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="PolicySubjectMatchType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator PolicySubjectMatchType(string value) => new PolicySubjectMatchType(value);

        /// <summary>
        /// Creates a new <see cref="PolicySubjectMatchType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public PolicySubjectMatchType(string value)
            : base(value)
        {
        }

    }
}
