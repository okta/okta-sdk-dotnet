namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Determines the visibility of an <see cref="App"/> to a <see cref="User"/>
    /// </summary>
    public class Visibility : ApiObject
    {
        /// <summary>
        /// Automatically log in when user lands on login page
        /// </summary>
        [JsonProperty("autoSubmitToolbar")]
        public bool AutoSubmitToolbar { get; set; }

        /// <summary>
        /// Hides this app for specific end-user apps
        /// </summary>
        [JsonProperty("hide")]
        public Hide Hide { get; set; }

        /// <summary>
        /// Displays specific appLinks for the app
        /// </summary>
        [JsonProperty("appLinks")]
        public AppLinks AppLinks { get; set; }
    }
}