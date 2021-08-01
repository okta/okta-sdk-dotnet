// <copyright file="NetworkZoneStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of NetworkZoneStatus values in the Okta API.
    /// </summary>
    public sealed class NetworkZoneStatus : StringEnum
    {
        /// <summary>The ACTIVE NetworkZoneStatus.</summary>
        public static NetworkZoneStatus Active = new NetworkZoneStatus("ACTIVE");

        /// <summary>The INACTIVE NetworkZoneStatus.</summary>
        public static NetworkZoneStatus Inactive = new NetworkZoneStatus("INACTIVE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="NetworkZoneStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator NetworkZoneStatus(string value) => new NetworkZoneStatus(value);

        /// <summary>
        /// Creates a new <see cref="NetworkZoneStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public NetworkZoneStatus(string value)
            : base(value)
        {
        }

    }
}
