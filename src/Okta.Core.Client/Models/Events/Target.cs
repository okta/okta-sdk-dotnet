namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The target of an <see cref="Event"/>
    /// </summary>
    public class Target : ApiObject
    {
        /// <summary>
        /// Unique key for actor
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of actor used for display purposes
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// User, Client, or AppInstance
        /// </summary>
        [JsonProperty("objectType")]
        public string ObjectType { get; set; }
    }
}