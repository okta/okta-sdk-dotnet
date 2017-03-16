namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// A request whose goal is to obtain a session token.
    /// </summary>
    public class AuthRequest : ApiObject
    {
        public AuthRequest()
        {
            Context = new AuthContext();
            Options = new AuthOptions();
        }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("relayState")]
        public string RelayState { get; set; }

        [JsonProperty("context")]
        public AuthContext Context { get; set; }

        [JsonProperty("options")]
        public AuthOptions Options { get; set; }

    }
}
