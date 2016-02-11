namespace Okta.Core.Models
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// An Okta user session
    /// </summary>
    public class Session : OktaObject
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("mfaActive")]
        public bool MfaActive { get; set; }

        [JsonProperty("cookieToken")]
        public string CookieToken { get; set; }

        [JsonProperty("cookieTokenUrl")]
        public Uri CookieTokenUrl { get; set; }
    }
}