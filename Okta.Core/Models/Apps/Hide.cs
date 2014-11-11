using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// Where an <see cref="App"/> is visible
    /// </summary>
    public class Hide : ApiObject
    {
        /// <summary>
        /// Okta Mobile for iOS or Android (pre-dates Android)
        /// </summary>
        [JsonProperty("iOS")]
        public bool IOS { get; set; }

        /// <summary>
        /// Okta Web Browser Home Page
        /// </summary>
        [JsonProperty("web")]
        public bool Web { get; set; }
    }
}