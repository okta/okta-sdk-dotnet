namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Where an <see cref="App"/> is visible
    /// </summary>
    public class Hide : ApiObject
    {
        /// <summary>
        /// Okta Mobile for iOS or Android (pre-dates Android)
        /// </summary>
        [JsonProperty("iOS")]
        public bool IOS { get; set; }

        /// <summary>
        /// Okta Web Browser Home Page
        /// </summary>
        [JsonProperty("web")]
        public bool Web { get; set; }
    }
}