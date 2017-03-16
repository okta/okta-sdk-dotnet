namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// An Options object that allows advanced authentication scenarios
    /// </summary>
    public class AuthOptions : ApiObject
    {
        public AuthOptions()
        {
        }

        [JsonProperty("warnBeforePasswordExpired")]
        public bool WarnBeforePasswordExpiration { get; set; }

        [JsonProperty("multiOptionalFactorEnroll")]
        public bool MultiOptionalFactorEnroll { get; set; }

    }
}
