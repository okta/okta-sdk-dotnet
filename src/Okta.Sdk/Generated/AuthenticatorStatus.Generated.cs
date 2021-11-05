// <copyright file="AuthenticatorStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of AuthenticatorStatus values in the Okta API.
    /// </summary>
    public sealed class AuthenticatorStatus : StringEnum
    {
        /// <summary>The ACTIVE AuthenticatorStatus.</summary>
        public static AuthenticatorStatus Active = new AuthenticatorStatus("ACTIVE");

        /// <summary>The INACTIVE AuthenticatorStatus.</summary>
        public static AuthenticatorStatus Inactive = new AuthenticatorStatus("INACTIVE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="AuthenticatorStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator AuthenticatorStatus(string value) => new AuthenticatorStatus(value);

        /// <summary>
        /// Creates a new <see cref="AuthenticatorStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public AuthenticatorStatus(string value)
            : base(value)
        {
        }

    }
}
