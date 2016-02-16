namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Link to an <see cref="App"/>
    /// </summary>
    public class AppLinks : ApiObject
    {
        [JsonProperty("login")]
        public bool Login { get; set; }
    }
}