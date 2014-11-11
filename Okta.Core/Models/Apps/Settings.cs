using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// Wrapper for <see cref="AppSettings"/>
    /// </summary>
    public class Settings : ApiObject
    {
        public Settings()
        {
            App = new AppSettings();
        }

        [JsonProperty("app")]
        public AppSettings App { get; set; }
    }
}