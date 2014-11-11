using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// A response received after making an expire password request if an email wasn't sent instead.
    /// </summary>
    public class ExpirePasswordResponse : ApiObject
    {
        /// <summary>
        /// Password generated after resetting an account
        /// </summary>
        [JsonProperty("tempPassword")]
        public string TempPassword { get; set; }
    }
}