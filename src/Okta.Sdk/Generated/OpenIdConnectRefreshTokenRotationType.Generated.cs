// <copyright file="OpenIdConnectRefreshTokenRotationType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of OpenIdConnectRefreshTokenRotationType values in the Okta API.
    /// </summary>
    public sealed class OpenIdConnectRefreshTokenRotationType : StringEnum
    {
        /// <summary>The rotate OpenIdConnectRefreshTokenRotationType.</summary>
        public static OpenIdConnectRefreshTokenRotationType Rotate = new OpenIdConnectRefreshTokenRotationType("rotate");

        /// <summary>The static OpenIdConnectRefreshTokenRotationType.</summary>
        public static OpenIdConnectRefreshTokenRotationType Static = new OpenIdConnectRefreshTokenRotationType("static");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OpenIdConnectRefreshTokenRotationType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OpenIdConnectRefreshTokenRotationType(string value) => new OpenIdConnectRefreshTokenRotationType(value);

        /// <summary>
        /// Creates a new <see cref="OpenIdConnectRefreshTokenRotationType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OpenIdConnectRefreshTokenRotationType(string value)
            : base(value)
        {
        }

    }
}
