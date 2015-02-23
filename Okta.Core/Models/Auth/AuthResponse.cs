using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// A response during any authentication request.
    /// </summary>
    public class AuthResponse : LinkedObject
    {
        public AuthResponse()
        {
            Embedded = new Embedded();
        }

        [JsonProperty("stateToken")]
        public string StateToken { get; set; }

        [JsonProperty("sessionToken")]
        public string SessionToken { get; set; }

        [JsonProperty("recoveryToken")]
        public string RecoveryToken { get; set; }

        [JsonProperty("expiresAt")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("relayState")]
        public string RelayState { get; set; }

        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }

        [JsonProperty("_links")]
        new public Dictionary<string, FactorLink> Links { get; set; }
    }
}
