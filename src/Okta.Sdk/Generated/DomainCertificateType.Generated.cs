// <copyright file="DomainCertificateType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of DomainCertificateType values in the Okta API.
    /// </summary>
    public sealed class DomainCertificateType : StringEnum
    {
        /// <summary>The PEM DomainCertificateType.</summary>
        public static DomainCertificateType Pem = new DomainCertificateType("PEM");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="DomainCertificateType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator DomainCertificateType(string value) => new DomainCertificateType(value);

        /// <summary>
        /// Creates a new <see cref="DomainCertificateType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public DomainCertificateType(string value)
            : base(value)
        {
        }

    }
}
