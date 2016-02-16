namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The master of a user's profile
    /// </summary>
    public class Provider : ApiObject
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}