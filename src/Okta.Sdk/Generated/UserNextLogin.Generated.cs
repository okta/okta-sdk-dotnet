// <copyright file="UserNextLogin.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of UserNextLogin values in the Okta API.
    /// </summary>
    public sealed class UserNextLogin : StringEnum
    {
        /// <summary>The changePassword UserNextLogin.</summary>
        public static UserNextLogin ChangePassword = new UserNextLogin("changePassword");

        /// <summary>
        /// Creates a new <see cref="UserNextLogin"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public UserNextLogin(string value)
            : base(value)
        {
        }
    }
}
