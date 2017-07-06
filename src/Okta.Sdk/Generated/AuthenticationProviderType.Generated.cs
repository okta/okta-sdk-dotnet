// <copyright file="AuthenticationProviderType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of AuthenticationProviderType values in the Okta API.
    /// </summary>
    public sealed class AuthenticationProviderType : StringEnum
    {
        /// <summary>The ACTIVE_DIRECTORY AuthenticationProviderType.</summary>
        public static AuthenticationProviderType ActiveDirectory = new AuthenticationProviderType("ACTIVE_DIRECTORY");

        /// <summary>The FEDERATION AuthenticationProviderType.</summary>
        public static AuthenticationProviderType Federation = new AuthenticationProviderType("FEDERATION");

        /// <summary>The LDAP AuthenticationProviderType.</summary>
        public static AuthenticationProviderType Ldap = new AuthenticationProviderType("LDAP");

        /// <summary>The OKTA AuthenticationProviderType.</summary>
        public static AuthenticationProviderType Okta = new AuthenticationProviderType("OKTA");

        /// <summary>The SOCIAL AuthenticationProviderType.</summary>
        public static AuthenticationProviderType Social = new AuthenticationProviderType("SOCIAL");

        /// <summary>The IMPORT AuthenticationProviderType.</summary>
        public static AuthenticationProviderType Import = new AuthenticationProviderType("IMPORT");

        /// <summary>
        /// Creates a new <see cref="AuthenticationProviderType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public AuthenticationProviderType(string value)
            : base(value)
        {
        }
    }
}
