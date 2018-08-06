// <copyright file="EmailStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of EmailStatus values in the Okta API.
    /// </summary>
    public sealed class EmailStatus : StringEnum
    {
        /// <summary>The VERIFIED EmailStatus.</summary>
        public static EmailStatus Verified = new EmailStatus("VERIFIED");

        /// <summary>The UNVERIFIED EmailStatus.</summary>
        public static EmailStatus Unverified = new EmailStatus("UNVERIFIED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="EmailStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator EmailStatus(string value) => new EmailStatus(value);

        /// <summary>
        /// Creates a new <see cref="EmailStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public EmailStatus(string value)
            : base(value)
        {
        }

    }
}
