namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Format of an <see cref="AppCredentials.UserName"/>
    /// </summary>
    public class UserNameTemplate : ApiObject
    {
        /// <summary>
        /// Mapping expression for username
        /// </summary>
        [JsonProperty("template")]
        public string Template { get; set; }

        /// <summary>
        /// Type of mapping expression
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Suffix for built-in mapping expressions
        /// </summary>
        [JsonProperty("userSuffix")]
        public string UserSuffix { get; set; }
    }
}