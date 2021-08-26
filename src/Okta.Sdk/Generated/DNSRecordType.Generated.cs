// <copyright file="DNSRecordType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of DNSRecordType values in the Okta API.
    /// </summary>
    public sealed class DNSRecordType : StringEnum
    {
        /// <summary>The TXT DNSRecordType.</summary>
        public static DNSRecordType Txt = new DNSRecordType("TXT");

        /// <summary>The CNAME DNSRecordType.</summary>
        public static DNSRecordType Cname = new DNSRecordType("CNAME");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="DNSRecordType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator DNSRecordType(string value) => new DNSRecordType(value);

        /// <summary>
        /// Creates a new <see cref="DNSRecordType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public DNSRecordType(string value)
            : base(value)
        {
        }

    }
}
