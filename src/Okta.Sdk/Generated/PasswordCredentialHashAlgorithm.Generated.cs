// <copyright file="PasswordCredentialHashAlgorithm.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of PasswordCredentialHashAlgorithm values in the Okta API.
    /// </summary>
    public sealed class PasswordCredentialHashAlgorithm : StringEnum
    {
        /// <summary>The BCRYPT PasswordCredentialHashAlgorithm.</summary>
        public static PasswordCredentialHashAlgorithm Bcrypt = new PasswordCredentialHashAlgorithm("BCRYPT");

        /// <summary>The SHA-512 PasswordCredentialHashAlgorithm.</summary>
        public static PasswordCredentialHashAlgorithm Sha512 = new PasswordCredentialHashAlgorithm("SHA-512");

        /// <summary>The SHA-256 PasswordCredentialHashAlgorithm.</summary>
        public static PasswordCredentialHashAlgorithm Sha256 = new PasswordCredentialHashAlgorithm("SHA-256");

        /// <summary>The SHA-1 PasswordCredentialHashAlgorithm.</summary>
        public static PasswordCredentialHashAlgorithm Sha1 = new PasswordCredentialHashAlgorithm("SHA-1");

        /// <summary>The MD5 PasswordCredentialHashAlgorithm.</summary>
        public static PasswordCredentialHashAlgorithm Md5 = new PasswordCredentialHashAlgorithm("MD5");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="PasswordCredentialHashAlgorithm"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator PasswordCredentialHashAlgorithm(string value) => new PasswordCredentialHashAlgorithm(value);

        /// <summary>
        /// Creates a new <see cref="PasswordCredentialHashAlgorithm"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public PasswordCredentialHashAlgorithm(string value)
            : base(value)
        {
        }

    }
}
