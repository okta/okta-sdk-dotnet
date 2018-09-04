// <copyright file="CreateSwaNoPluginApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for SWA no-plugin application settings
    /// </summary>
    public sealed class CreateSwaNoPluginApplicationOptions
    {
        /// <summary>
        /// Gets or sets a label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets a url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a password field
        /// </summary>
        public string PasswordField { get; set; }

        /// <summary>
        /// Gets or sets a username field
        /// </summary>
        public string UsernameField { get; set; }

        /// <summary>
        /// Gets or sets an OptionalField1
        /// </summary>
        public string OptionalField1 { get; set; }

        /// <summary>
        /// Gets or sets an OptionalField1 value
        /// </summary>
        public string OptionalField1Value { get; set; }

        /// <summary>
        /// Gets or sets an OptionalField2
        /// </summary>
        public string OptionalField2 { get; set; }

        /// <summary>
        /// Gets or sets an OptionalField2 value
        /// </summary>
        public string OptionalField2Value { get; set; }

        /// <summary>
        /// Gets or sets an OptionalField3
        /// </summary>
        public string OptionalField3 { get; set; }

        /// <summary>
        /// Gets or sets an OptionalField3 value
        /// </summary>
        public string OptionalField3Value { get; set; }

        /// <summary>
        /// Gets or sets an activate flag value
        /// </summary>
        public bool Activate { get; set; } = true;
    }
}
