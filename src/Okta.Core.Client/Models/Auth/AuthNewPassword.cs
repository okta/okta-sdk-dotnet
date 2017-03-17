namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// An object used to reset a password during an authentication flow.
    /// </summary>
    public class AuthNewPassword : ApiObject
    {
        [JsonProperty("oldPassword")]
        public string OldPassword { get; set; }

        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }

        [JsonProperty("stateToken")]
        public string StateToken { get; set; }

    }
}
