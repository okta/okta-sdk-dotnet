namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Credentials of an <see cref="AppUser"/>
    /// </summary>
    public class AppUserCredentials : ApiObject
    {
        /// <summary>
        /// Username for app
        /// </summary>
        [JsonProperty("userName")]
        public string UserName { get; set; }

        /// <summary>
        /// Password for app
        /// </summary>
        [JsonProperty("password")]
        public Password Password { get; set; }
    }
}