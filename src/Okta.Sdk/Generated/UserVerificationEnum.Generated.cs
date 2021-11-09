// <copyright file="UserVerificationEnum.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of UserVerificationEnum values in the Okta API.
    /// </summary>
    public sealed class UserVerificationEnum : StringEnum
    {
        /// <summary>The REQUIRED UserVerificationEnum.</summary>
        public static UserVerificationEnum Required = new UserVerificationEnum("REQUIRED");

        /// <summary>The PREFERRED UserVerificationEnum.</summary>
        public static UserVerificationEnum Preferred = new UserVerificationEnum("PREFERRED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="UserVerificationEnum"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator UserVerificationEnum(string value) => new UserVerificationEnum(value);

        /// <summary>
        /// Creates a new <see cref="UserVerificationEnum"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public UserVerificationEnum(string value)
            : base(value)
        {
        }

    }
}
