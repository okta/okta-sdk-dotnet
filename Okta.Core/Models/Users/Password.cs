using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// A user's password
    /// </summary>
    public class Password : ApiObject
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}