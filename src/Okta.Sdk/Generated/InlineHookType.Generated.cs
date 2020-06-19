// <copyright file="InlineHookType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of InlineHookType values in the Okta API.
    /// </summary>
    public sealed class InlineHookType : StringEnum
    {
        /// <summary>The com.okta.oauth2.tokens.transform InlineHookType.</summary>
        public static InlineHookType ComOktaOauth2TokensTransform = new InlineHookType("com.okta.oauth2.tokens.transform");

        /// <summary>The com.okta.import.transform InlineHookType.</summary>
        public static InlineHookType ComOktaImportTransform = new InlineHookType("com.okta.import.transform");

        /// <summary>The com.okta.saml.tokens.transform InlineHookType.</summary>
        public static InlineHookType ComOktaSamlTokensTransform = new InlineHookType("com.okta.saml.tokens.transform");

        /// <summary>The com.okta.user.pre-registration InlineHookType.</summary>
        public static InlineHookType ComOktaUserPreRegistration = new InlineHookType("com.okta.user.pre-registration");

        /// <summary>The com.okta.user.credential.password.import InlineHookType.</summary>
        public static InlineHookType ComOktaUserCredentialPasswordImport = new InlineHookType("com.okta.user.credential.password.import");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="InlineHookType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator InlineHookType(string value) => new InlineHookType(value);

        /// <summary>
        /// Creates a new <see cref="InlineHookType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public InlineHookType(string value)
            : base(value)
        {
        }

    }
}
