// <copyright file="SeedEnum.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of SeedEnum values in the Okta API.
    /// </summary>
    public sealed class SeedEnum : StringEnum
    {
        /// <summary>The OKTA SeedEnum.</summary>
        public static SeedEnum Okta = new SeedEnum("OKTA");

        /// <summary>The RANDOM SeedEnum.</summary>
        public static SeedEnum Random = new SeedEnum("RANDOM");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="SeedEnum"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator SeedEnum(string value) => new SeedEnum(value);

        /// <summary>
        /// Creates a new <see cref="SeedEnum"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public SeedEnum(string value)
            : base(value)
        {
        }

    }
}
