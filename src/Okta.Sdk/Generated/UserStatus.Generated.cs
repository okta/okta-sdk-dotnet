// <copyright file="UserStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed class UserStatus : StringEnum
    {
        public static UserStatus Staged = new UserStatus("STAGED");

        public static UserStatus Provisioned = new UserStatus("PROVISIONED");

        public static UserStatus Active = new UserStatus("ACTIVE");

        public static UserStatus Recovery = new UserStatus("RECOVERY");

        public static UserStatus PasswordExpired = new UserStatus("PASSWORD_EXPIRED");

        public static UserStatus LockedOut = new UserStatus("LOCKED_OUT");

        public static UserStatus Deprovisioned = new UserStatus("DEPROVISIONED");

        public static UserStatus Suspended = new UserStatus("SUSPENDED");

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
