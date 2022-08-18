using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Okta.Sdk.Client
{
    public class OAuthResponse
    {
        [DataMember(Name = "token_type", EmitDefaultValue = false)]
        public string TokenType { get; set; }

        [DataMember(Name = "access_token", EmitDefaultValue = false)]
        public string AccessToken { get; set; }

        [DataMember(Name = "expires_in", EmitDefaultValue = false)]
        public int ExpiresIn { get; set; }

        [DataMember(Name = "scope", EmitDefaultValue = false)]
        public string Scope { get; set; }
    }
}
