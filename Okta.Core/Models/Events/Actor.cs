namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The source of an <see cref="Event"/>
    /// </summary>
    public class Actor : ApiObject
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
        /// User or Client
        /// </summary>
        [JsonProperty("objectType")]
        public string ObjectType { get; set; }
    }
}