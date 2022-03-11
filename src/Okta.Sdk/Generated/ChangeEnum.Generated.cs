// <copyright file="ChangeEnum.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of ChangeEnum values in the Okta API.
    /// </summary>
    public sealed class ChangeEnum : StringEnum
    {
        /// <summary>The KEEP_EXISTING ChangeEnum.</summary>
        public static ChangeEnum KeepExisting = new ChangeEnum("KEEP_EXISTING");

        /// <summary>The CHANGE ChangeEnum.</summary>
        public static ChangeEnum Change = new ChangeEnum("CHANGE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ChangeEnum"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ChangeEnum(string value) => new ChangeEnum(value);

        /// <summary>
        /// Creates a new <see cref="ChangeEnum"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ChangeEnum(string value)
            : base(value)
        {
        }

    }
}
