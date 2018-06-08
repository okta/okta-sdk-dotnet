// <copyright file="CreateUserWithProviderOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Contains the options for creating a new <see cref="IUser">User</see> with a specified authentication provider.
    /// Used with <see cref="IUsersClient.CreateUserAsync(CreateUserWithProviderOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    /// <remarks>See <a href="https://developer.okta.com/docs/api/resources/users.html#create-user-with-authentication-provider">Create User with Authentication Provider</a> in the documentation.</remarks>
    public sealed class CreateUserWithProviderOptions
    {
        /// <summary>
        /// Gets or sets the new user's profile.
        /// </summary>
        /// <value>
        /// The user's profile.
        /// </value>
        public UserProfile Profile { get; set; }

        /// <summary>
        /// Gets or sets the authentication provider type.
        /// </summary>
        /// <value>The authentication provider type.</value>
        public AuthenticationProviderType ProviderType { get; set; }

        /// <summary>
        /// Gets or sets the optional authentication provider name.
        /// </summary>
        /// <value>The authentication provider name.</value>
        public string ProviderName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the new user should be activated immediately.
        /// </summary>
        /// <remarks>The default value is <c>true</c> (users will be activated immediately).</remarks>
        /// <value>
        /// Whether the new user should be activated immediately.
        /// </value>
        public bool Activate { get; set; } = true;
    }
}
