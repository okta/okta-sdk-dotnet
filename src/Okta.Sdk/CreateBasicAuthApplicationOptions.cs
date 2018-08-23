// <copyright file="CreateBasicAuthApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for basic authentication application settings
    /// </summary>
    public sealed class CreateBasicAuthApplicationOptions
    {
        /// <summary>
        /// Gets or sets a label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets an url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets an Auth url
        /// </summary>
        public string AuthUrl { get; set; }

        /// <summary>
        /// Gets or sets an Activate flag value
        /// </summary>
        public bool Activate { get; set; } = true;
    }
}
