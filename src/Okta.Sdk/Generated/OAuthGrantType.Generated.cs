// <copyright file="OAuthGrantType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of OAuthGrantType values in the Okta API.
    /// </summary>
    public sealed class OAuthGrantType : StringEnum
    {
        /// <summary>The authorization_code OAuthGrantType.</summary>
        public static OAuthGrantType AuthorizationCode = new OAuthGrantType("authorization_code");

        /// <summary>The implicit OAuthGrantType.</summary>
        public static OAuthGrantType Implicit = new OAuthGrantType("implicit");

        /// <summary>The password OAuthGrantType.</summary>
        public static OAuthGrantType Password = new OAuthGrantType("password");

        /// <summary>The refresh_token OAuthGrantType.</summary>
        public static OAuthGrantType RefreshToken = new OAuthGrantType("refresh_token");

        /// <summary>The client_credentials OAuthGrantType.</summary>
        public static OAuthGrantType ClientCredentials = new OAuthGrantType("client_credentials");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OAuthGrantType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OAuthGrantType(string value) => new OAuthGrantType(value);

        /// <summary>
        /// Creates a new <see cref="OAuthGrantType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OAuthGrantType(string value)
            : base(value)
        {
        }

    }
}
