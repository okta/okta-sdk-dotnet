namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// A user's profile.
    /// </summary>
    /// <remarks>
    /// This includes all of a user's attributes regardless of source.
    /// </remarks>
    public class UserProfile : ApiObject
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("mobilePhone")]
        public string MobilePhone { get; set; }

        [JsonProperty("secondEmail")]
        public string SecondaryEmail { get; set; }
    }
}