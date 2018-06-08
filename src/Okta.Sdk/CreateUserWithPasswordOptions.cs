// <copyright file="CreateUserWithPasswordOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Contains the options for creating a new <see cref="IUser">User</see> with a password.
    /// Used with <see cref="IUsersClient.CreateUserAsync(CreateUserWithPasswordOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    /// <remarks>See <a href="https://developer.okta.com/docs/api/resources/users.html#create-user-with-password">Create User with Password</a> in the documentation.</remarks>
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
        /// Gets or sets a value indicating whether the new user should be activated immediately.
        /// </summary>
        /// <remarks>The default value is <c>true</c> (users will be activated immediately).</remarks>
        /// <value>
        /// Whether the new user should be activated immediately.
        /// </value>
        public bool Activate { get; set; } = true;

        /// <summary>
        /// Gets or sets the new user's password.
        /// </summary>
        /// <value>
        /// The new user's password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the new user's recovery question.
        /// </summary>
        /// <value>The new user's recovery question.</value>
        public string RecoveryQuestion { get; set; }

        /// <summary>
        /// Gets or sets the new user's recovery answer.
        /// </summary>
        /// <value>The new user's recovery answer.</value>
        public string RecoveryAnswer { get; set; }
    }
}
