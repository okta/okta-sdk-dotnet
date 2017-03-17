namespace Okta.Core.Models.Schemas
{
    using Newtonsoft.Json;

    /// <summary>
    /// Definition of schema array items
    /// </summary>
    public class SchemaItems
    {
        /// <summary>
        /// The type of the array items
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
