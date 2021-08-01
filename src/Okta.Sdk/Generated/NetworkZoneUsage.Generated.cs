// <copyright file="NetworkZoneUsage.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of NetworkZoneUsage values in the Okta API.
    /// </summary>
    public sealed class NetworkZoneUsage : StringEnum
    {
        /// <summary>The POLICY NetworkZoneUsage.</summary>
        public static NetworkZoneUsage Policy = new NetworkZoneUsage("POLICY");

        /// <summary>The BLOCKLIST NetworkZoneUsage.</summary>
        public static NetworkZoneUsage Blocklist = new NetworkZoneUsage("BLOCKLIST");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="NetworkZoneUsage"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator NetworkZoneUsage(string value) => new NetworkZoneUsage(value);

        /// <summary>
        /// Creates a new <see cref="NetworkZoneUsage"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public NetworkZoneUsage(string value)
            : base(value)
        {
        }

    }
}
