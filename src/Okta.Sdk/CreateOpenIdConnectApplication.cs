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

        public OpenIdConnectApplicationType ApplicationType { get; set; } = OpenIdConnectApplicationType.Native;

        public string TermsOfServiceUri { get; set; }

        public string PolicyUri { get; set; }
    }
}
