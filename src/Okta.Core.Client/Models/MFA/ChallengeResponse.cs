namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// A result after submitting an MFA request
    /// </summary>
    public class ChallengeResponse : LinkedObject
    {
        [JsonProperty("factorResult")]
        public string FactorResult { get; set; }

        [JsonProperty("factorResultMessage")]
        public string FactorResultMessage { get; set; }
    }
}