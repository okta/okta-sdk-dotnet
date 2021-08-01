// <copyright file="NetworkZoneType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of NetworkZoneType values in the Okta API.
    /// </summary>
    public sealed class NetworkZoneType : StringEnum
    {
        /// <summary>The IP NetworkZoneType.</summary>
        public static NetworkZoneType Ip = new NetworkZoneType("IP");

        /// <summary>The DYNAMIC NetworkZoneType.</summary>
        public static NetworkZoneType Dynamic = new NetworkZoneType("DYNAMIC");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="NetworkZoneType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator NetworkZoneType(string value) => new NetworkZoneType(value);

        /// <summary>
        /// Creates a new <see cref="NetworkZoneType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public NetworkZoneType(string value)
            : base(value)
        {
        }

    }
}
