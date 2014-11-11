using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// Link to an <see cref="App"/>
    /// </summary>
    public class AppLinks : ApiObject
    {
        [JsonProperty("login")]
        public bool Login { get; set; }
    }
}