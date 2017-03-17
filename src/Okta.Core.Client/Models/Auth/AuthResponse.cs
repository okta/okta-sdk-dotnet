namespace Okta.Core.Models
{
    using System;

    using Newtonsoft.Json;
    using System.Collections.Generic;

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

        [JsonProperty("recoveryType")]
        public string RecoveryType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("factorResult")]
        public string FactorResult { get; set; }

        [JsonProperty("relayState")]
        public string RelayState { get; set; }

        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }

    }
}
