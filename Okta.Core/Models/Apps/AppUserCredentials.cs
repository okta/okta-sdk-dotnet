using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// Credentials of an <see cref="AppUser"/>
    /// </summary>
    public class AppUserCredentials : ApiObject
    {
        /// <summary>
        /// Username for app
        /// </summary>
        [JsonProperty("userName")]
        public string UserName { get; set; }

        /// <summary>
        /// Password for app
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}