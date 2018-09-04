// <copyright file="CreateSwaApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for a SWA application settings
    /// </summary>
    public sealed class CreateSwaApplicationOptions
    {
        /// <summary>
        /// Gets or sets a label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets a button field
        /// </summary>
        public string ButtonField { get; set; }

        /// <summary>
        /// Gets or sets a password field
        /// </summary>
        public string PasswordField { get; set; }

        /// <summary>
        /// Gets or sets a username field
        /// </summary>
        public string UsernameField { get; set; }

        /// <summary>
        /// Gets or sets an url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a login url regex
        /// </summary>
        public string LoginUrlRegex { get; set; }

        /// <summary>
        /// Gets or sets an activate flag value
        /// </summary>
        public bool Activate { get; set; } = true;
    }
}
