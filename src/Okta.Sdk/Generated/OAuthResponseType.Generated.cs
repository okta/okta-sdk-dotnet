// <copyright file="OAuthResponseType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of OAuthResponseType values in the Okta API.
    /// </summary>
    public sealed class OAuthResponseType : StringEnum
    {
        /// <summary>The code OAuthResponseType.</summary>
        public static OAuthResponseType Code = new OAuthResponseType("code");

        /// <summary>The token OAuthResponseType.</summary>
        public static OAuthResponseType Token = new OAuthResponseType("token");

        /// <summary>The id_token OAuthResponseType.</summary>
        public static OAuthResponseType IdToken = new OAuthResponseType("id_token");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OAuthResponseType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OAuthResponseType(string value) => new OAuthResponseType(value);

        /// <summary>
        /// Creates a new <see cref="OAuthResponseType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OAuthResponseType(string value)
            : base(value)
        {
        }

    }
}
