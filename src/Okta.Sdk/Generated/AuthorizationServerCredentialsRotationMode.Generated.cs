// <copyright file="AuthorizationServerCredentialsRotationMode.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of AuthorizationServerCredentialsRotationMode values in the Okta API.
    /// </summary>
    public sealed class AuthorizationServerCredentialsRotationMode : StringEnum
    {
        /// <summary>The AUTO AuthorizationServerCredentialsRotationMode.</summary>
        public static AuthorizationServerCredentialsRotationMode Auto = new AuthorizationServerCredentialsRotationMode("AUTO");

        /// <summary>The MANUAL AuthorizationServerCredentialsRotationMode.</summary>
        public static AuthorizationServerCredentialsRotationMode Manual = new AuthorizationServerCredentialsRotationMode("MANUAL");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="AuthorizationServerCredentialsRotationMode"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator AuthorizationServerCredentialsRotationMode(string value) => new AuthorizationServerCredentialsRotationMode(value);

        /// <summary>
        /// Creates a new <see cref="AuthorizationServerCredentialsRotationMode"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public AuthorizationServerCredentialsRotationMode(string value)
            : base(value)
        {
        }

    }
}
