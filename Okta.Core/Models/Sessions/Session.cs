using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// An Okta user session
    /// </summary>
    public class Session : OktaObject
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("mfaActive")]
        public bool MfaActive { get; set; }

        [JsonProperty("cookieToken")]
        public string CookieToken { get; set; }

        [JsonProperty("cookieTokenUrl")]
        public Uri CookieTokenUrl { get; set; }
    }
}