// <copyright file="SessionStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of SessionStatus values in the Okta API.
    /// </summary>
    public sealed class SessionStatus : StringEnum
    {
        /// <summary>The ACTIVE SessionStatus.</summary>
        public static SessionStatus Active = new SessionStatus("ACTIVE");

        /// <summary>The MFA_ENROLL SessionStatus.</summary>
        public static SessionStatus MfaEnroll = new SessionStatus("MFA_ENROLL");

        /// <summary>The MFA_REQUIRED SessionStatus.</summary>
        public static SessionStatus MfaRequired = new SessionStatus("MFA_REQUIRED");

        /// <summary>
        /// Creates a new <see cref="SessionStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public SessionStatus(string value)
            : base(value)
        {
        }
    }
}
