namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// MFA profile.
    /// </summary>
    public class FactorProfile : ApiObject
    {
        /// <summary>
        /// Unique key for question
        /// </summary>
        [JsonProperty("question")]
        public string QuestionType { get; set; }

        /// <summary>
        /// Display text for question
        /// </summary>
        [JsonProperty("questionText")]
        public string QuestionText { get; set; }

        /// <summary>
        /// Answer to question
        /// </summary>
        [JsonProperty("answer")]
        public string Answer { get; set; }

        /// <summary>
        /// Phone number of mobile device (for SMS factor) or phone device (for voice call factor)
        /// </summary>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Phone number of voice call factor device
        /// </summary>
        [JsonProperty("phoneExtension")]
        public string PhoneExtension { get; set; }

        /// <summary>
        /// Unique id for instance
        /// </summary>
        [JsonProperty("credentialId")]
        public string CredentialId { get; set; }
    }
}