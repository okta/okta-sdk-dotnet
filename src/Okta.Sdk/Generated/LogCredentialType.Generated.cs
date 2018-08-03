// <copyright file="LogCredentialType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of LogCredentialType values in the Okta API.
    /// </summary>
    public sealed class LogCredentialType : StringEnum
    {
        /// <summary>The OTP LogCredentialType.</summary>
        public static LogCredentialType Otp = new LogCredentialType("OTP");

        /// <summary>The SMS LogCredentialType.</summary>
        public static LogCredentialType Sms = new LogCredentialType("SMS");

        /// <summary>The PASSWORD LogCredentialType.</summary>
        public static LogCredentialType Password = new LogCredentialType("PASSWORD");

        /// <summary>The ASSERTION LogCredentialType.</summary>
        public static LogCredentialType Assertion = new LogCredentialType("ASSERTION");

        /// <summary>The IWA LogCredentialType.</summary>
        public static LogCredentialType Iwa = new LogCredentialType("IWA");

        /// <summary>The EMAIL LogCredentialType.</summary>
        public static LogCredentialType Email = new LogCredentialType("EMAIL");

        /// <summary>The OAUTH2 LogCredentialType.</summary>
        public static LogCredentialType Oauth2 = new LogCredentialType("OAUTH2");

        /// <summary>The JWT LogCredentialType.</summary>
        public static LogCredentialType Jwt = new LogCredentialType("JWT");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="LogCredentialType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator LogCredentialType(string value) => new LogCredentialType(value);

        /// <summary>
        /// Creates a new <see cref="LogCredentialType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public LogCredentialType(string value)
            : base(value)
        {
        }

    }
}
