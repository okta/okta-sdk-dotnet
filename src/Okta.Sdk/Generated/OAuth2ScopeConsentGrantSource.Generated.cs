// <copyright file="OAuth2ScopeConsentGrantSource.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of OAuth2ScopeConsentGrantSource values in the Okta API.
    /// </summary>
    public sealed class OAuth2ScopeConsentGrantSource : StringEnum
    {
        /// <summary>The END_USER OAuth2ScopeConsentGrantSource.</summary>
        public static OAuth2ScopeConsentGrantSource EndUser = new OAuth2ScopeConsentGrantSource("END_USER");

        /// <summary>The ADMIN OAuth2ScopeConsentGrantSource.</summary>
        public static OAuth2ScopeConsentGrantSource Admin = new OAuth2ScopeConsentGrantSource("ADMIN");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OAuth2ScopeConsentGrantSource"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OAuth2ScopeConsentGrantSource(string value) => new OAuth2ScopeConsentGrantSource(value);

        /// <summary>
        /// Creates a new <see cref="OAuth2ScopeConsentGrantSource"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OAuth2ScopeConsentGrantSource(string value)
            : base(value)
        {
        }

    }
}
