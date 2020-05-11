// <copyright file="OAuth2ScopeConsentGrantStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of OAuth2ScopeConsentGrantStatus values in the Okta API.
    /// </summary>
    public sealed class OAuth2ScopeConsentGrantStatus : StringEnum
    {
        /// <summary>The ACTIVE OAuth2ScopeConsentGrantStatus.</summary>
        public static OAuth2ScopeConsentGrantStatus Active = new OAuth2ScopeConsentGrantStatus("ACTIVE");

        /// <summary>The REVOKED OAuth2ScopeConsentGrantStatus.</summary>
        public static OAuth2ScopeConsentGrantStatus Revoked = new OAuth2ScopeConsentGrantStatus("REVOKED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OAuth2ScopeConsentGrantStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OAuth2ScopeConsentGrantStatus(string value) => new OAuth2ScopeConsentGrantStatus(value);

        /// <summary>
        /// Creates a new <see cref="OAuth2ScopeConsentGrantStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OAuth2ScopeConsentGrantStatus(string value)
            : base(value)
        {
        }

    }
}
