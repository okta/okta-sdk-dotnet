using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
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