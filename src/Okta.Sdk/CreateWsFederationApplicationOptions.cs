// <copyright file="CreateWsFederationApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for WS federation application settings
    /// </summary>
    public sealed class CreateWsFederationApplicationOptions
    {
        /// <summary>
        /// Gets or sets a label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets an activate flag value
        /// </summary>
        public bool Activate { get; set; } = true;

        /// <summary>
        /// Gets or sets an audience restriction
        /// </summary>
        public string AudienceRestriction { get; set; }

        /// <summary>
        /// Gets or sets a group name
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets a group value format
        /// </summary>
        public string GroupValueFormat { get; set; }

        /// <summary>
        /// Gets or sets a realm
        /// </summary>
        public string Realm { get; set; }

        /// <summary>
        /// Gets or sets a reply url
        /// </summary>
        public string WReplyUrl { get; set; }

        /// <summary>
        /// Gets or sets an attribute statement
        /// </summary>
        public string AttributeStatements { get; set; }

        /// <summary>
        /// Gets or sets a name id format
        /// </summary>
        public string NameIdFormat { get; set; }

        /// <summary>
        /// Gets or sets an authentication context class name
        /// </summary>
        public string AuthenticationContextClassName { get; set; }

        /// <summary>
        /// Gets or sets a site url
        /// </summary>
        public string SiteUrl { get; set; }

        /// <summary>
        /// Gets or sets a reply override flag value
        /// </summary>
        public bool WReplyOverride { get; set; }

        /// <summary>
        /// Gets or sets a group filter
        /// </summary>
        public string GroupFilter { get; set; }

        /// <summary>
        /// Gets or sets a username attribute
        /// </summary>
        public string UsernameAttribute { get; set; }
    }
}
