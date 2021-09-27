// <copyright file="AllowedForEnum.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of AllowedForEnum values in the Okta API.
    /// </summary>
    public sealed class AllowedForEnum : StringEnum
    {
        /// <summary>The recovery AllowedForEnum.</summary>
        public static AllowedForEnum Recovery = new AllowedForEnum("recovery");

        /// <summary>The sso AllowedForEnum.</summary>
        public static AllowedForEnum Sso = new AllowedForEnum("sso");

        /// <summary>The any AllowedForEnum.</summary>
        public static AllowedForEnum Any = new AllowedForEnum("any");

        /// <summary>The none AllowedForEnum.</summary>
        public static AllowedForEnum None = new AllowedForEnum("none");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="AllowedForEnum"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator AllowedForEnum(string value) => new AllowedForEnum(value);

        /// <summary>
        /// Creates a new <see cref="AllowedForEnum"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public AllowedForEnum(string value)
            : base(value)
        {
        }

    }
}
