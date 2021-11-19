// <copyright file="FipsEnum.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of FipsEnum values in the Okta API.
    /// </summary>
    public sealed class FipsEnum : StringEnum
    {
        /// <summary>The REQUIRED FipsEnum.</summary>
        public static FipsEnum Required = new FipsEnum("REQUIRED");

        /// <summary>The OPTIONAL FipsEnum.</summary>
        public static FipsEnum Optional = new FipsEnum("OPTIONAL");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="FipsEnum"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator FipsEnum(string value) => new FipsEnum(value);

        /// <summary>
        /// Creates a new <see cref="FipsEnum"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public FipsEnum(string value)
            : base(value)
        {
        }

    }
}
