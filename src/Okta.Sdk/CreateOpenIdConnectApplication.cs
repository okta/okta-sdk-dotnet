// <copyright file="CreateOpenIdConnectApplication.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for OpenId Connect application settings
    /// </summary>
    public sealed class CreateOpenIdConnectApplication
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
        /// Gets or sets a client id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets a token endpoint authentication method
        /// </summary>
        public OAuthEndpointAuthenticationMethod TokenEndpointAuthMethod { get; set; }

        /// <summary>
        /// Gets or sets an auto key rotation flag value
        /// </summary>
        public bool AutoKeyRotation { get; set; } = true;

        /// <summary>
        /// Gets or sets a client uri
        /// </summary>
        public string ClientUri { get; set; }

        /// <summary>
        /// Gets or sets a logo uri
        /// </summary>
        public string LogoUri { get; set; }

        /// <summary>
        /// Gets or sets a response type list
        /// </summary>
        public IList<OAuthResponseType> ResponseTypes { get; set; }

        /// <summary>
        /// Gets or sets a redirect uri list
        /// </summary>
        public IList<string> RedirectUris { get; set; }

        /// <summary>
        /// Gets or sets a grant type list
        /// </summary>
        public IList<OAuthGrantType> GrantTypes { get; set; }

        /// <summary>
        /// Gets or sets an application type
        /// </summary>
        public OpenIdConnectApplicationType ApplicationType { get; set; }

        /// <summary>
        /// Gets or sets a term of service uri
        /// </summary>
        public string TermsOfServiceUri { get; set; }

        /// <summary>
        /// Gets or sets a policy uri
        /// </summary>
        public string PolicyUri { get; set; }
    }
}
