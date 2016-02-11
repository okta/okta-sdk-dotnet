namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// A user's login credentials.
    /// </summary>
    public class LoginCredentials : ApiObject
    {
        public LoginCredentials()
        {
            Password = new Password();
            RecoveryQuestion = new RecoveryQuestion();
            Provider = new Provider();
        }

        [JsonProperty("password")]
        public Password Password { get; set; }

        [JsonProperty("recovery_question")]
        public RecoveryQuestion RecoveryQuestion { get; set; }

        [JsonProperty("provider")]
        public Provider Provider { get; set; }
    }
}