// <copyright file="ProtocolRelayStateFormat.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of ProtocolRelayStateFormat values in the Okta API.
    /// </summary>
    public sealed class ProtocolRelayStateFormat : StringEnum
    {
        /// <summary>The OPAQUE ProtocolRelayStateFormat.</summary>
        public static ProtocolRelayStateFormat Opaque = new ProtocolRelayStateFormat("OPAQUE");

        /// <summary>The FROM_URL ProtocolRelayStateFormat.</summary>
        public static ProtocolRelayStateFormat FromUrl = new ProtocolRelayStateFormat("FROM_URL");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ProtocolRelayStateFormat"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ProtocolRelayStateFormat(string value) => new ProtocolRelayStateFormat(value);

        /// <summary>
        /// Creates a new <see cref="ProtocolRelayStateFormat"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ProtocolRelayStateFormat(string value)
            : base(value)
        {
        }

    }
}
