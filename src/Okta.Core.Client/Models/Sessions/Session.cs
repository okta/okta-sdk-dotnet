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

        [JsonProperty("login")]
        public string UserLogin { get; set; }

        [JsonProperty("mfaActive")]
        public bool MfaActive { get; set; }

        [JsonProperty("cookieToken")]
        public string CookieToken { get; set; }

        [JsonProperty("cookieTokenUrl")]
        public Uri CookieTokenUrl { get; set; }

        [JsonProperty("expiresAt")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("lastPasswordVerification")]
        public DateTime LastPasswordVerification { get; set; }

        [JsonProperty("lastFactorVerification")]
        public DateTime LastFactorVerification { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("amr")]
        public string[] AuthMethodReference { get; set; }

        [JsonProperty("idp")]
        public IdentityProvider IdP { get; set; }

    }

    public class IdentityProvider : OktaObject
    {
        [JsonProperty("type")]
        public string Type { get; set; }
       
    }
}