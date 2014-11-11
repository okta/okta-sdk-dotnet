using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
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