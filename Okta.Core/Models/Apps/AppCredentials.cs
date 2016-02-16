namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Description of credentials for an <see cref="App"/>
    /// </summary>
    public class AppCredentials : ApiObject
    {
        /// <summary>
        /// Determines how credentials are managed for the signOnMode
        /// </summary>
        [JsonProperty("scheme")]
        public string Scheme { get; set; }

        /// <summary>
        /// Default username that is generated when an application is assigned to a user
        /// </summary>
        [JsonProperty("userNameTemplate")]
        public UserNameTemplate UserNameTemplate { get; set; }

        /// <summary>
        /// Shared username for app
        /// </summary>
        [JsonProperty("userName")]
        public string UserName { get; set; }

        /// <summary>
        /// Shared password for app
        /// </summary>
        [JsonProperty("password")]
        public Password Password { get; set; }
    }
}