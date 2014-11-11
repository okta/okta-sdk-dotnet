using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// An object used to reset a password during an authentication flow.
    /// </summary>
    public class AuthNewPassword : ApiObject
    {
        [JsonProperty("oldPassword")]
        public string OldPassword { get; set; }

        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }
    }
}
