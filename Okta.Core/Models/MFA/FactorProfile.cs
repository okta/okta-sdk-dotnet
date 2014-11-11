using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
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
        /// Phone number of mobile device
        /// </summary>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Unique id for instance
        /// </summary>
        [JsonProperty("credentialId")]
        public string CredentialId { get; set; }
    }
}