// <copyright file="ProvisioningConnectionAuthScheme.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of ProvisioningConnectionAuthScheme values in the Okta API.
    /// </summary>
    public sealed class ProvisioningConnectionAuthScheme : StringEnum
    {
        /// <summary>The TOKEN ProvisioningConnectionAuthScheme.</summary>
        public static ProvisioningConnectionAuthScheme Token = new ProvisioningConnectionAuthScheme("TOKEN");

        /// <summary>The UNKNOWN ProvisioningConnectionAuthScheme.</summary>
        public static ProvisioningConnectionAuthScheme Unknown = new ProvisioningConnectionAuthScheme("UNKNOWN");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ProvisioningConnectionAuthScheme"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ProvisioningConnectionAuthScheme(string value) => new ProvisioningConnectionAuthScheme(value);

        /// <summary>
        /// Creates a new <see cref="ProvisioningConnectionAuthScheme"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ProvisioningConnectionAuthScheme(string value)
            : base(value)
        {
        }

    }
}
