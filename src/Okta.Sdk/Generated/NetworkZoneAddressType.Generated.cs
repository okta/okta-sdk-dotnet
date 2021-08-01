// <copyright file="NetworkZoneAddressType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of NetworkZoneAddressType values in the Okta API.
    /// </summary>
    public sealed class NetworkZoneAddressType : StringEnum
    {
        /// <summary>The CIDR NetworkZoneAddressType.</summary>
        public static NetworkZoneAddressType Cidr = new NetworkZoneAddressType("CIDR");

        /// <summary>The RANGE NetworkZoneAddressType.</summary>
        public static NetworkZoneAddressType Range = new NetworkZoneAddressType("RANGE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="NetworkZoneAddressType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator NetworkZoneAddressType(string value) => new NetworkZoneAddressType(value);

        /// <summary>
        /// Creates a new <see cref="NetworkZoneAddressType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public NetworkZoneAddressType(string value)
            : base(value)
        {
        }

    }
}
