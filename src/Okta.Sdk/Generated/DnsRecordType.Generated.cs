// <copyright file="DnsRecordType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of DnsRecordType values in the Okta API.
    /// </summary>
    public sealed class DnsRecordType : StringEnum
    {
        /// <summary>The TXT DnsRecordType.</summary>
        public static DnsRecordType Txt = new DnsRecordType("TXT");

        /// <summary>The CNAME DnsRecordType.</summary>
        public static DnsRecordType Cname = new DnsRecordType("CNAME");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="DnsRecordType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator DnsRecordType(string value) => new DnsRecordType(value);

        /// <summary>
        /// Creates a new <see cref="DnsRecordType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public DnsRecordType(string value)
            : base(value)
        {
        }

    }
}
