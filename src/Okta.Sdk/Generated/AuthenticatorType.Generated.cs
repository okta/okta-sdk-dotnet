// <copyright file="AuthenticatorType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of AuthenticatorType values in the Okta API.
    /// </summary>
    public sealed class AuthenticatorType : StringEnum
    {
        /// <summary>The app AuthenticatorType.</summary>
        public static AuthenticatorType App = new AuthenticatorType("app");

        /// <summary>The password AuthenticatorType.</summary>
        public static AuthenticatorType Password = new AuthenticatorType("password");

        /// <summary>The security_question AuthenticatorType.</summary>
        public static AuthenticatorType SecurityQuestion = new AuthenticatorType("security_question");

        /// <summary>The phone AuthenticatorType.</summary>
        public static AuthenticatorType Phone = new AuthenticatorType("phone");

        /// <summary>The email AuthenticatorType.</summary>
        public static AuthenticatorType Email = new AuthenticatorType("email");

        /// <summary>The security_key AuthenticatorType.</summary>
        public static AuthenticatorType SecurityKey = new AuthenticatorType("security_key");

        /// <summary>The federated AuthenticatorType.</summary>
        public static AuthenticatorType Federated = new AuthenticatorType("federated");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="AuthenticatorType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator AuthenticatorType(string value) => new AuthenticatorType(value);

        /// <summary>
        /// Creates a new <see cref="AuthenticatorType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public AuthenticatorType(string value)
            : base(value)
        {
        }

    }
}
