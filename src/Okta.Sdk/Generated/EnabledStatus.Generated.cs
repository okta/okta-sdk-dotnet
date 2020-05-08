// <copyright file="EnabledStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of EnabledStatus values in the Okta API.
    /// </summary>
    public sealed class EnabledStatus : StringEnum
    {
        /// <summary>The ENABLED EnabledStatus.</summary>
        public static EnabledStatus Enabled = new EnabledStatus("ENABLED");

        /// <summary>The DISABLED EnabledStatus.</summary>
        public static EnabledStatus Disabled = new EnabledStatus("DISABLED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="EnabledStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator EnabledStatus(string value) => new EnabledStatus(value);

        /// <summary>
        /// Creates a new <see cref="EnabledStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public EnabledStatus(string value)
            : base(value)
        {
        }

    }
}
