// <copyright file="CreateUserWithPasswordOptions.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Contains the options for creating a new <see cref="User"/> with a password.
    /// </summary>
    public sealed class CreateUserWithPasswordOptions
    {
        /// <summary>
        /// Gets or sets the new user's profile.
        /// </summary>
        /// <value>
        /// The user's profile.
        /// </value>
        public UserProfile Profile { get; set; }

        /// <summary>
        /// Gets or sets whether to activate the new user immediately.
        /// </summary>
        /// <remarks>Unless otherwise specified, users will be activated immediately.</remarks>
        /// <value>
        /// Whether to activate the new user immediately.
        /// </value>
        public bool Activate { get; set; } = true;

        /// <summary>
        /// Gets or sets the new user's password.
        /// </summary>
        /// <value>
        /// The new user's password.
        /// </value>
        public string Password { get; set; }
    }
}
