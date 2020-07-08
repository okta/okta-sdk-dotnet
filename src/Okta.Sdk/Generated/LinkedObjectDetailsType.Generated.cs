// <copyright file="LinkedObjectDetailsType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of LinkedObjectDetailsType values in the Okta API.
    /// </summary>
    public sealed class LinkedObjectDetailsType : StringEnum
    {
        /// <summary>The USER LinkedObjectDetailsType.</summary>
        public static LinkedObjectDetailsType User = new LinkedObjectDetailsType("USER");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="LinkedObjectDetailsType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator LinkedObjectDetailsType(string value) => new LinkedObjectDetailsType(value);

        /// <summary>
        /// Creates a new <see cref="LinkedObjectDetailsType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public LinkedObjectDetailsType(string value)
            : base(value)
        {
        }

    }
}
