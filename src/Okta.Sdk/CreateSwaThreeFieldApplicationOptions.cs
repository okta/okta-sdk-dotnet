// <copyright file="CreateSwaThreeFieldApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for SWA 3 field application settings
    /// </summary>
    public sealed class CreateSwaThreeFieldApplicationOptions
    {
        /// <summary>
        /// Gets or sets a label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets a button selector
        /// </summary>
        public string ButtonSelector { get; set; }

        /// <summary>
        /// Gets or sets a password selector
        /// </summary>
        public string PasswordSelector { get; set; }

        /// <summary>
        /// Gets or sets a username selector
        /// </summary>
        public string UserNameSelector { get; set; }

        /// <summary>
        /// Gets or sets a target url
        /// </summary>
        public string TargetUrl { get; set; }

        /// <summary>
        /// Gets or sets an extra field selector
        /// </summary>
        public string ExtraFieldSelector { get; set; }

        /// <summary>
        /// Gets or sets an extra field value
        /// </summary>
        public string ExtraFieldValue { get; set; }

        /// <summary>
        /// Gets or sets a login url regex
        /// </summary>
        public string LoginUrlRegex { get; set; }

        /// <summary>
        /// Gets or sets an activate flag value
        /// </summary>
        public bool? Activate { get; set; } = true;
    }
}
