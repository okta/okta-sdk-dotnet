using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// Defines how an <see cref="App"/> is accessible to a <see cref="User"/>
    /// </summary>
    public class Accessibility : ApiObject
    {
        /// <summary>
        /// Enable self service application assignment
        /// </summary>
        [JsonProperty("selfService")]
        public bool SelfService { get; set; }

        /// <summary>
        /// Custom error page for this application
        /// </summary>
        [JsonProperty("errorRedirectUrl")]
        public string ErrorRedirectUrl { get; set; }
    }
}