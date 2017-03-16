namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// A question and answer that allow a user to make changes to their account.
    /// </summary>
    public class RecoveryQuestion : ApiObject
    {
        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("answer")]
        public string Answer { get; set; }
    }
}