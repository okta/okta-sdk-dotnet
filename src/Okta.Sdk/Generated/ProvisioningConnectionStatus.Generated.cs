// <copyright file="ProvisioningConnectionStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of ProvisioningConnectionStatus values in the Okta API.
    /// </summary>
    public sealed class ProvisioningConnectionStatus : StringEnum
    {
        /// <summary>The DISABLED ProvisioningConnectionStatus.</summary>
        public static ProvisioningConnectionStatus Disabled = new ProvisioningConnectionStatus("DISABLED");

        /// <summary>The ENABLED ProvisioningConnectionStatus.</summary>
        public static ProvisioningConnectionStatus Enabled = new ProvisioningConnectionStatus("ENABLED");

        /// <summary>The UNKNOWN ProvisioningConnectionStatus.</summary>
        public static ProvisioningConnectionStatus Unknown = new ProvisioningConnectionStatus("UNKNOWN");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ProvisioningConnectionStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ProvisioningConnectionStatus(string value) => new ProvisioningConnectionStatus(value);

        /// <summary>
        /// Creates a new <see cref="ProvisioningConnectionStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ProvisioningConnectionStatus(string value)
            : base(value)
        {
        }

    }
}
