// <copyright file="RequiredEnum.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of RequiredEnum values in the Okta API.
    /// </summary>
    public sealed class RequiredEnum : StringEnum
    {
        /// <summary>The ALWAYS RequiredEnum.</summary>
        public static RequiredEnum Always = new RequiredEnum("ALWAYS");

        /// <summary>The HIGH_RISK_ONLY RequiredEnum.</summary>
        public static RequiredEnum HighRiskOnly = new RequiredEnum("HIGH_RISK_ONLY");

        /// <summary>The NEVER RequiredEnum.</summary>
        public static RequiredEnum Never = new RequiredEnum("NEVER");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="RequiredEnum"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator RequiredEnum(string value) => new RequiredEnum(value);

        /// <summary>
        /// Creates a new <see cref="RequiredEnum"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public RequiredEnum(string value)
            : base(value)
        {
        }

    }
}
