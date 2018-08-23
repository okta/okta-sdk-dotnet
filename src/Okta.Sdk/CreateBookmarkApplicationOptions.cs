// <copyright file="CreateBookmarkApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for bookmark application settings
    /// </summary>
    public sealed class CreateBookmarkApplicationOptions
    {
        /// <summary>
        /// Gets or sets the label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the request integration flag value
        /// </summary>
        public bool RequestIntegration { get; set; } = false;

        /// <summary>
        /// Gets or sets the url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Activate flag value
        /// </summary>
        public bool Activate { get; set; } = true;
    }
}
