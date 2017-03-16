namespace Okta.Core.Models
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// An Okta user.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class User : OktaObject
    {
        public User()
        {
            Profile = new UserProfile();
            Credentials= new LoginCredentials();
        }

        /// <summary>
        /// Instantiate a user with a predefined profile
        /// </summary>
        /// <param name="Login">User's unique login name</param>
        /// <param name="Email">User's email address</param>
        /// <param name="FirstName">User's first name</param>
        /// <param name="LastName">User's last name</param>
        /// <param name="MobilePhone">User's phone number</param>
        /// <param name="SecondaryEmail">User's secondary email</param>
        public User(string Login, string Email, string FirstName, string LastName, string MobilePhone = null, string SecondaryEmail = null)
        {
            Profile = new UserProfile {
                Login = Login, 
                Email = Email, 
                FirstName = FirstName, 
                LastName = LastName, 
                MobilePhone = MobilePhone, 
                SecondaryEmail = SecondaryEmail
            };
        }

       /// <summary>
        /// Current status of user
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Timestamp when user was created
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Timestamp when transition to ACTIVE status completed
        /// </summary>
        [JsonProperty("activated")]
        public DateTime Activated { get; set; }

        /// <summary>
        /// Timestamp when status last changed
        /// </summary>
        [JsonProperty("statusChanged")]
        public DateTime StatusChanged { get; set; }

        /// <summary>
        /// Timestamp of last login
        /// </summary>
        [JsonProperty("lastLogin")]
        public DateTime LastLogin { get; set; }

        /// <summary>
        /// Timestamp when user was last updated
        /// </summary>
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Timestamp when password last changed
        /// </summary>
        [JsonProperty("passwordChanged")]
        public DateTime PasswordChanged { get; set; }

        /// <summary>
        /// Target status of an inprogress asynchronous status transition
        /// </summary>
        [JsonProperty("transitioningToStatus")]
        public string TransitioningToStatus { get; set; }

        [JsonProperty("profile")]
        public UserProfile Profile { get; set; }

        [JsonProperty("credentials")]
        public LoginCredentials Credentials { get; set; }

        /// <summary>
        /// Current recovery question of user
        /// </summary>
        [JsonProperty("recovery_question")]
        public RecoveryQuestion recoveryQuestion { get; set; }

    }
}
