namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The action performed by an <see cref="Actor"/> on a <see cref="Target"/> in an <see cref="Event"/>
    /// </summary>
    public class Action : ApiObject
    {
        /// <summary>
        /// Description of an action
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Categories for an action
        /// </summary>
        [JsonProperty("categories")]
        public string[] Categories { get; set; }

        /// <summary>
        /// Identifies the unique type of an action
        /// </summary>
        [JsonProperty("objectType")]
        public string ObjectType { get; set; }

        /// <summary>
        /// Relative uri of the request that generated the event.
        /// </summary>
        [JsonProperty("requestUri")]
        public string RequestUri { get; set; }
    }
}