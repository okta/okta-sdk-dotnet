// <copyright file="OpenIdConnectApplicationType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of OpenIdConnectApplicationType values in the Okta API.
    /// </summary>
    public sealed class OpenIdConnectApplicationType : StringEnum
    {
        /// <summary>The web OpenIdConnectApplicationType.</summary>
        public static OpenIdConnectApplicationType Web = new OpenIdConnectApplicationType("web");

        /// <summary>The native OpenIdConnectApplicationType.</summary>
        public static OpenIdConnectApplicationType Native = new OpenIdConnectApplicationType("native");

        /// <summary>The browser OpenIdConnectApplicationType.</summary>
        public static OpenIdConnectApplicationType Browser = new OpenIdConnectApplicationType("browser");

        /// <summary>The service OpenIdConnectApplicationType.</summary>
        public static OpenIdConnectApplicationType Service = new OpenIdConnectApplicationType("service");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OpenIdConnectApplicationType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OpenIdConnectApplicationType(string value) => new OpenIdConnectApplicationType(value);

        /// <summary>
        /// Creates a new <see cref="OpenIdConnectApplicationType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OpenIdConnectApplicationType(string value)
            : base(value)
        {
        }

    }
}
