namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// A user's password
    /// </summary>
    public class Password : ApiObject
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}