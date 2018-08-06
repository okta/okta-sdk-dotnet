// <copyright file="FactorProvider.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of FactorProvider values in the Okta API.
    /// </summary>
    public sealed class FactorProvider : StringEnum
    {
        /// <summary>The OKTA FactorProvider.</summary>
        public static FactorProvider Okta = new FactorProvider("OKTA");

        /// <summary>The RSA FactorProvider.</summary>
        public static FactorProvider Rsa = new FactorProvider("RSA");

        /// <summary>The GOOGLE FactorProvider.</summary>
        public static FactorProvider Google = new FactorProvider("GOOGLE");

        /// <summary>The SYMANTEC FactorProvider.</summary>
        public static FactorProvider Symantec = new FactorProvider("SYMANTEC");

        /// <summary>The DUO FactorProvider.</summary>
        public static FactorProvider Duo = new FactorProvider("DUO");

        /// <summary>The YUBICO FactorProvider.</summary>
        public static FactorProvider Yubico = new FactorProvider("YUBICO");

        /// <summary>The FIDO FactorProvider.</summary>
        public static FactorProvider Fido = new FactorProvider("FIDO");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="FactorProvider"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator FactorProvider(string value) => new FactorProvider(value);

        /// <summary>
        /// Creates a new <see cref="FactorProvider"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public FactorProvider(string value)
            : base(value)
        {
        }

    }
}
