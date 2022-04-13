// <copyright file="IframeEmbedScopeAllowedApps.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of IframeEmbedScopeAllowedApps values in the Okta API.
    /// </summary>
    public sealed class IframeEmbedScopeAllowedApps : StringEnum
    {
        /// <summary>The OKTA_ENDUSER IframeEmbedScopeAllowedApps.</summary>
        public static IframeEmbedScopeAllowedApps OktaEnduser = new IframeEmbedScopeAllowedApps("OKTA_ENDUSER");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="IframeEmbedScopeAllowedApps"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator IframeEmbedScopeAllowedApps(string value) => new IframeEmbedScopeAllowedApps(value);

        /// <summary>
        /// Creates a new <see cref="IframeEmbedScopeAllowedApps"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public IframeEmbedScopeAllowedApps(string value)
            : base(value)
        {
        }

    }
}
