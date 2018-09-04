// <copyright file="AssignUserToApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Settings helper class to assign users to application
    /// </summary>
    public sealed class AssignUserToApplicationOptions
    {
        /// <summary>
        /// Gets or sets the user id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the scope
        /// </summary>
        public string Scope { get; set; } = "USER";

        /// <summary>
        /// Gets or sets a password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets an application id
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets a profile
        /// </summary>
        public Resource Profile { get; set; }
    }
}
