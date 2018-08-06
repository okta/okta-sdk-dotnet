// <copyright file="UserStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of UserStatus values in the Okta API.
    /// </summary>
    public sealed class UserStatus : StringEnum
    {
        /// <summary>The STAGED UserStatus.</summary>
        public static UserStatus Staged = new UserStatus("STAGED");

        /// <summary>The PROVISIONED UserStatus.</summary>
        public static UserStatus Provisioned = new UserStatus("PROVISIONED");

        /// <summary>The ACTIVE UserStatus.</summary>
        public static UserStatus Active = new UserStatus("ACTIVE");

        /// <summary>The RECOVERY UserStatus.</summary>
        public static UserStatus Recovery = new UserStatus("RECOVERY");

        /// <summary>The PASSWORD_EXPIRED UserStatus.</summary>
        public static UserStatus PasswordExpired = new UserStatus("PASSWORD_EXPIRED");

        /// <summary>The LOCKED_OUT UserStatus.</summary>
        public static UserStatus LockedOut = new UserStatus("LOCKED_OUT");

        /// <summary>The DEPROVISIONED UserStatus.</summary>
        public static UserStatus Deprovisioned = new UserStatus("DEPROVISIONED");

        /// <summary>The SUSPENDED UserStatus.</summary>
        public static UserStatus Suspended = new UserStatus("SUSPENDED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="UserStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator UserStatus(string value) => new UserStatus(value);

        /// <summary>
        /// Creates a new <see cref="UserStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public UserStatus(string value)
            : base(value)
        {
        }

    }
}
