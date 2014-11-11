using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// A response received after attempting to activate a <see cref="User"/>
    /// </summary>
    public class ActivationResponse : ApiObject
    {
        /// <summary>
        /// Url for user to activate their account
        /// </summary>
        [JsonProperty("activationUrl")]
        public Uri ActivationUrl { get; set; }
    }
}