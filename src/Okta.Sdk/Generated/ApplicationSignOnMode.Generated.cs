// <copyright file="ApplicationSignOnMode.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of ApplicationSignOnMode values in the Okta API.
    /// </summary>
    public sealed class ApplicationSignOnMode : StringEnum
    {
        /// <summary>The BOOKMARK ApplicationSignOnMode.</summary>
        public static ApplicationSignOnMode Bookmark = new ApplicationSignOnMode("BOOKMARK");

        /// <summary>The BASIC_AUTH ApplicationSignOnMode.</summary>
        public static ApplicationSignOnMode BasicAuth = new ApplicationSignOnMode("BASIC_AUTH");

        /// <summary>The BROWSER_PLUGIN ApplicationSignOnMode.</summary>
        public static ApplicationSignOnMode BrowserPlugin = new ApplicationSignOnMode("BROWSER_PLUGIN");

        /// <summary>The SECURE_PASSWORD_STORE ApplicationSignOnMode.</summary>
        public static ApplicationSignOnMode SecurePasswordStore = new ApplicationSignOnMode("SECURE_PASSWORD_STORE");

        /// <summary>The AUTO_LOGIN ApplicationSignOnMode.</summary>
        public static ApplicationSignOnMode AutoLogin = new ApplicationSignOnMode("AUTO_LOGIN");

        /// <summary>The WS_FEDERATION ApplicationSignOnMode.</summary>
        public static ApplicationSignOnMode WsFederation = new ApplicationSignOnMode("WS_FEDERATION");

        /// <summary>The SAML_2_0 ApplicationSignOnMode.</summary>
        public static ApplicationSignOnMode Saml2 = new ApplicationSignOnMode("SAML_2_0");

        /// <summary>The OPENID_CONNECT ApplicationSignOnMode.</summary>
        public static ApplicationSignOnMode OpenIdConnect = new ApplicationSignOnMode("OPENID_CONNECT");

        /// <summary>The SAML_1_1 ApplicationSignOnMode.</summary>
        public static ApplicationSignOnMode Saml11 = new ApplicationSignOnMode("SAML_1_1");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ApplicationSignOnMode"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ApplicationSignOnMode(string value) => new ApplicationSignOnMode(value);

        /// <summary>
        /// Creates a new <see cref="ApplicationSignOnMode"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ApplicationSignOnMode(string value)
            : base(value)
        {
        }

    }
}
