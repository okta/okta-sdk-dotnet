using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// A request whose goal is to obtain a session token.
    /// </summary>
    public class AuthRequest : ApiObject
    {
        public AuthRequest()
        {
            Context = new AuthContext();
        }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("relayState")]
        public string RelayState { get; set; }

        [JsonProperty("context")]
        public AuthContext Context { get; set; }
    }
}
