// <copyright file="CreateOpenIdConnectApplication.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class CreateOpenIdConnectApplication
    {
        public string Label { get; set; }

        public bool Activate { get; set; } = true;

        public string ClientId { get; set; }

        public OAuthEndpointAuthenticationMethod TokenEndpointAuthMethod { get; set; }

        public bool AutoKeyRotation { get; set; } = true;

        public string ClientUri { get; set; }

        public string LogoUri { get; set; }

        public IList<OAuthResponseType> ResponseTypes { get; set; }

        public IList<string> RedirectUris { get; set; }

        public IList<OAuthGrantType> GrantTypes { get; set; }

        public OpenIdConnectApplicationType ApplicationType { get; set; }

        public string TermsOfServiceUri { get; set; }

        public string PolicyUri { get; set; }
    }
}
