// <copyright file="OpenIdConnectApplicationConsentMethod.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of OpenIdConnectApplicationConsentMethod values in the Okta API.
    /// </summary>
    public sealed class OpenIdConnectApplicationConsentMethod : StringEnum
    {
        /// <summary>The REQUIRED OpenIdConnectApplicationConsentMethod.</summary>
        public static OpenIdConnectApplicationConsentMethod Required = new OpenIdConnectApplicationConsentMethod("REQUIRED");

        /// <summary>The TRUSTED OpenIdConnectApplicationConsentMethod.</summary>
        public static OpenIdConnectApplicationConsentMethod Trusted = new OpenIdConnectApplicationConsentMethod("TRUSTED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OpenIdConnectApplicationConsentMethod"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OpenIdConnectApplicationConsentMethod(string value) => new OpenIdConnectApplicationConsentMethod(value);

        /// <summary>
        /// Creates a new <see cref="OpenIdConnectApplicationConsentMethod"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OpenIdConnectApplicationConsentMethod(string value)
            : base(value)
        {
        }

    }
}
