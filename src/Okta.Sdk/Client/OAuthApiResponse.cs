using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk.Client
{
    public abstract class OAuthApiResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
