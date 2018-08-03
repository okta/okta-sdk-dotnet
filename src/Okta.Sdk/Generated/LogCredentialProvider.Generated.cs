// <copyright file="LogCredentialProvider.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of LogCredentialProvider values in the Okta API.
    /// </summary>
    public sealed class LogCredentialProvider : StringEnum
    {
        /// <summary>The OKTA_AUTHENTICATION_PROVIDER LogCredentialProvider.</summary>
        public static LogCredentialProvider Okta = new LogCredentialProvider("OKTA_AUTHENTICATION_PROVIDER");

        /// <summary>The RSA LogCredentialProvider.</summary>
        public static LogCredentialProvider Rsa = new LogCredentialProvider("RSA");

        /// <summary>The SYMANTEC LogCredentialProvider.</summary>
        public static LogCredentialProvider Symantec = new LogCredentialProvider("SYMANTEC");

        /// <summary>The GOOGLE LogCredentialProvider.</summary>
        public static LogCredentialProvider Google = new LogCredentialProvider("GOOGLE");

        /// <summary>The DUO LogCredentialProvider.</summary>
        public static LogCredentialProvider Duo = new LogCredentialProvider("DUO");

        /// <summary>The YUBIKEY LogCredentialProvider.</summary>
        public static LogCredentialProvider Yubikey = new LogCredentialProvider("YUBIKEY");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="LogCredentialProvider"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator LogCredentialProvider(string value) => new LogCredentialProvider(value);

        /// <summary>
        /// Creates a new <see cref="LogCredentialProvider"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public LogCredentialProvider(string value)
            : base(value)
        {
        }

    }
}
