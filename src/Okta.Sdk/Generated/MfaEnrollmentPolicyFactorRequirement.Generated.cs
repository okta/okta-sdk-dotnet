// <copyright file="MfaEnrollmentPolicyFactorRequirement.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of MfaEnrollmentPolicyFactorRequirement values in the Okta API.
    /// </summary>
    public sealed class MfaEnrollmentPolicyFactorRequirement : StringEnum
    {
        /// <summary>The NOT_ALLOWED MfaEnrollmentPolicyFactorRequirement.</summary>
        public static MfaEnrollmentPolicyFactorRequirement NotAllowed = new MfaEnrollmentPolicyFactorRequirement("NOT_ALLOWED");

        /// <summary>The OPTIONAL MfaEnrollmentPolicyFactorRequirement.</summary>
        public static MfaEnrollmentPolicyFactorRequirement Optional = new MfaEnrollmentPolicyFactorRequirement("OPTIONAL");

        /// <summary>The REQUIRED MfaEnrollmentPolicyFactorRequirement.</summary>
        public static MfaEnrollmentPolicyFactorRequirement Required = new MfaEnrollmentPolicyFactorRequirement("REQUIRED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="MfaEnrollmentPolicyFactorRequirement"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator MfaEnrollmentPolicyFactorRequirement(string value) => new MfaEnrollmentPolicyFactorRequirement(value);

        /// <summary>
        /// Creates a new <see cref="MfaEnrollmentPolicyFactorRequirement"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public MfaEnrollmentPolicyFactorRequirement(string value)
            : base(value)
        {
        }

    }
}
