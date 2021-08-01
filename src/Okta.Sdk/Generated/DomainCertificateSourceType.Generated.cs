// <copyright file="DomainCertificateSourceType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of DomainCertificateSourceType values in the Okta API.
    /// </summary>
    public sealed class DomainCertificateSourceType : StringEnum
    {
        /// <summary>The MANUAL DomainCertificateSourceType.</summary>
        public static DomainCertificateSourceType Manual = new DomainCertificateSourceType("MANUAL");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="DomainCertificateSourceType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator DomainCertificateSourceType(string value) => new DomainCertificateSourceType(value);

        /// <summary>
        /// Creates a new <see cref="DomainCertificateSourceType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public DomainCertificateSourceType(string value)
            : base(value)
        {
        }

    }
}
