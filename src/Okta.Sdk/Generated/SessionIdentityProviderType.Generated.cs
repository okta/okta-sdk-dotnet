// <copyright file="SessionIdentityProviderType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of SessionIdentityProviderType values in the Okta API.
    /// </summary>
    public sealed class SessionIdentityProviderType : StringEnum
    {
        /// <summary>The ACTIVE_DIRECTORY SessionIdentityProviderType.</summary>
        public static SessionIdentityProviderType ActiveDirectory = new SessionIdentityProviderType("ACTIVE_DIRECTORY");

        /// <summary>The LDAP SessionIdentityProviderType.</summary>
        public static SessionIdentityProviderType Ldap = new SessionIdentityProviderType("LDAP");

        /// <summary>The OKTA SessionIdentityProviderType.</summary>
        public static SessionIdentityProviderType Okta = new SessionIdentityProviderType("OKTA");

        /// <summary>The FEDERATION SessionIdentityProviderType.</summary>
        public static SessionIdentityProviderType Federation = new SessionIdentityProviderType("FEDERATION");

        /// <summary>The SOCIAL SessionIdentityProviderType.</summary>
        public static SessionIdentityProviderType Social = new SessionIdentityProviderType("SOCIAL");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="SessionIdentityProviderType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator SessionIdentityProviderType(string value) => new SessionIdentityProviderType(value);

        /// <summary>
        /// Creates a new <see cref="SessionIdentityProviderType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public SessionIdentityProviderType(string value)
            : base(value)
        {
        }

    }
}
