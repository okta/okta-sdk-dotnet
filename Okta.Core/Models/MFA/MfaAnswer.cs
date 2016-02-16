namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Sent to confirm receipt of an MFA request
    /// </summary>
    public class MfaAnswer : ApiObject
    {
        /// <summary>
        /// Answer to question
        /// </summary>
        [JsonProperty("answer")]
        public string Answer { get; set; }

        /// <summary>
        /// Code sent via Mfa
        /// </summary>
        [JsonProperty("passCode")]
        public string Passcode { get; set; }
    }
}