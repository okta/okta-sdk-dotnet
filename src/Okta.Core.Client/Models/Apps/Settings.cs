namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Wrapper for <see cref="AppSettings"/>
    /// </summary>
    public class Settings : ApiObject
    {
        public Settings()
        {
            App = new AppSettings();
        }

        [JsonProperty("app")]
        public AppSettings App { get; set; }
    }
}