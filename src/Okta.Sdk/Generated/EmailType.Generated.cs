// <copyright file="EmailType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of EmailType values in the Okta API.
    /// </summary>
    public sealed class EmailType : StringEnum
    {
        /// <summary>The PRIMARY EmailType.</summary>
        public static EmailType Primary = new EmailType("PRIMARY");

        /// <summary>The SECONDARY EmailType.</summary>
        public static EmailType Secondary = new EmailType("SECONDARY");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="EmailType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator EmailType(string value) => new EmailType(value);

        /// <summary>
        /// Creates a new <see cref="EmailType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public EmailType(string value)
            : base(value)
        {
        }

    }
}
