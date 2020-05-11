// <copyright file="OpenIdConnectApplicationIssuerMode.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of OpenIdConnectApplicationIssuerMode values in the Okta API.
    /// </summary>
    public sealed class OpenIdConnectApplicationIssuerMode : StringEnum
    {
        /// <summary>The CUSTOM_URL OpenIdConnectApplicationIssuerMode.</summary>
        public static OpenIdConnectApplicationIssuerMode CustomUrl = new OpenIdConnectApplicationIssuerMode("CUSTOM_URL");

        /// <summary>The ORG_URL OpenIdConnectApplicationIssuerMode.</summary>
        public static OpenIdConnectApplicationIssuerMode OrgUrl = new OpenIdConnectApplicationIssuerMode("ORG_URL");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OpenIdConnectApplicationIssuerMode"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OpenIdConnectApplicationIssuerMode(string value) => new OpenIdConnectApplicationIssuerMode(value);

        /// <summary>
        /// Creates a new <see cref="OpenIdConnectApplicationIssuerMode"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OpenIdConnectApplicationIssuerMode(string value)
            : base(value)
        {
        }

    }
}
