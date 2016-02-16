namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines how an <see cref="App"/> is accessible to a <see cref="User"/>
    /// </summary>
    public class Accessibility : ApiObject
    {
        /// <summary>
        /// Enable self service application assignment
        /// </summary>
        [JsonProperty("selfService")]
        public bool SelfService { get; set; }

        /// <summary>
        /// Custom error page for this application
        /// </summary>
        [JsonProperty("errorRedirectUrl")]
        public string ErrorRedirectUrl { get; set; }
    }
}