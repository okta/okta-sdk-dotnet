// <copyright file="CreateSwaCustomApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for SWA custom application settings
    /// </summary>
    public sealed class CreateSwaCustomApplicationOptions
    {
        /// <summary>
        /// Gets or sets a label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets an auto submit toolbar flag value
        /// </summary>
        public bool AutoSubmitToolbar { get; set; } = false;

        /// <summary>
        /// Gets or sets a hide IOs flag value
        /// </summary>
        public bool HideIOs { get; set; } = false;

        /// <summary>
        /// Gets or sets a hide web flag value
        /// </summary>
        public bool HideWeb { get; set; } = false;

        /// <summary>
        /// Gets or sets a redirect url
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Gets or sets a login url
        /// </summary>
        public string LoginUrl { get; set; }

        /// <summary>
        /// Gets or sets a features list
        /// </summary>
        public IList<string> Features { get; set; }

        /// <summary>
        /// Gets or sets an activate flag value
        /// </summary>
        public bool Activate { get; set; } = true;
    }
}
