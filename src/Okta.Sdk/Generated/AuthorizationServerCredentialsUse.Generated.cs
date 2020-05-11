// <copyright file="AuthorizationServerCredentialsUse.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of AuthorizationServerCredentialsUse values in the Okta API.
    /// </summary>
    public sealed class AuthorizationServerCredentialsUse : StringEnum
    {
        /// <summary>The sig AuthorizationServerCredentialsUse.</summary>
        public static AuthorizationServerCredentialsUse Sig = new AuthorizationServerCredentialsUse("sig");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="AuthorizationServerCredentialsUse"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator AuthorizationServerCredentialsUse(string value) => new AuthorizationServerCredentialsUse(value);

        /// <summary>
        /// Creates a new <see cref="AuthorizationServerCredentialsUse"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public AuthorizationServerCredentialsUse(string value)
            : base(value)
        {
        }

    }
}
