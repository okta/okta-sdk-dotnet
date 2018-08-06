// <copyright file="OAuthEndpointAuthenticationMethod.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of OAuthEndpointAuthenticationMethod values in the Okta API.
    /// </summary>
    public sealed class OAuthEndpointAuthenticationMethod : StringEnum
    {
        /// <summary>The none OAuthEndpointAuthenticationMethod.</summary>
        public static OAuthEndpointAuthenticationMethod None = new OAuthEndpointAuthenticationMethod("none");

        /// <summary>The client_secret_post OAuthEndpointAuthenticationMethod.</summary>
        public static OAuthEndpointAuthenticationMethod ClientSecretPost = new OAuthEndpointAuthenticationMethod("client_secret_post");

        /// <summary>The client_secret_basic OAuthEndpointAuthenticationMethod.</summary>
        public static OAuthEndpointAuthenticationMethod ClientSecretBasic = new OAuthEndpointAuthenticationMethod("client_secret_basic");

        /// <summary>The client_secret_jwt OAuthEndpointAuthenticationMethod.</summary>
        public static OAuthEndpointAuthenticationMethod ClientSecretJwt = new OAuthEndpointAuthenticationMethod("client_secret_jwt");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OAuthEndpointAuthenticationMethod"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OAuthEndpointAuthenticationMethod(string value) => new OAuthEndpointAuthenticationMethod(value);

        /// <summary>
        /// Creates a new <see cref="OAuthEndpointAuthenticationMethod"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OAuthEndpointAuthenticationMethod(string value)
            : base(value)
        {
        }

    }
}
