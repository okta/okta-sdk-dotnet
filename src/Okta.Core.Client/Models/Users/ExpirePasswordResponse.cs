namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// A response received after making an expire password request if an email wasn't sent instead.
    /// </summary>
    public class ExpirePasswordResponse : ApiObject
    {
        /// <summary>
        /// Password generated after resetting an account
        /// </summary>
        [JsonProperty("tempPassword")]
        public string TempPassword { get; set; }
    }
}