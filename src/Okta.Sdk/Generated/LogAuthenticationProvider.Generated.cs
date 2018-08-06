// <copyright file="LogAuthenticationProvider.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of LogAuthenticationProvider values in the Okta API.
    /// </summary>
    public sealed class LogAuthenticationProvider : StringEnum
    {
        /// <summary>The OKTA_AUTHENTICATION_PROVIDER LogAuthenticationProvider.</summary>
        public static LogAuthenticationProvider OktaAuthenticationProvider = new LogAuthenticationProvider("OKTA_AUTHENTICATION_PROVIDER");

        /// <summary>The ACTIVE_DIRECTORY LogAuthenticationProvider.</summary>
        public static LogAuthenticationProvider ActiveDirectory = new LogAuthenticationProvider("ACTIVE_DIRECTORY");

        /// <summary>The LDAP LogAuthenticationProvider.</summary>
        public static LogAuthenticationProvider Ldap = new LogAuthenticationProvider("LDAP");

        /// <summary>The FEDERATION LogAuthenticationProvider.</summary>
        public static LogAuthenticationProvider Federation = new LogAuthenticationProvider("FEDERATION");

        /// <summary>The SOCIAL LogAuthenticationProvider.</summary>
        public static LogAuthenticationProvider Social = new LogAuthenticationProvider("SOCIAL");

        /// <summary>The FACTOR_PROVIDER LogAuthenticationProvider.</summary>
        public static LogAuthenticationProvider FactorProvider = new LogAuthenticationProvider("FACTOR_PROVIDER");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="LogAuthenticationProvider"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator LogAuthenticationProvider(string value) => new LogAuthenticationProvider(value);

        /// <summary>
        /// Creates a new <see cref="LogAuthenticationProvider"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public LogAuthenticationProvider(string value)
            : base(value)
        {
        }

    }
}
