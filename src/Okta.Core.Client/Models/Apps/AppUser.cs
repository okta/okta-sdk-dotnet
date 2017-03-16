namespace Okta.Core.Models
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// A <see cref="User"/> assigned to an <see cref="App"/>.
    /// </summary>
    public class AppUser : OktaObject
    {

        /// <summary>
        /// App-specific profile for the user
        /// </summary>
        [JsonProperty("profile")]
        public UserProfile Profile { get; set; }

        /// <summary>
        /// Timestamp when user was created
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Timestamp when user was last updated
        /// </summary>
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Toggles the assignment between user or group scope
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Status of app user
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Timestamp when status last changed
        /// </summary>
        [JsonProperty("statusChanged")]
        public DateTime StatusChanged { get; set; }

        /// <summary>
        /// Timestamp when app password last changed
        /// </summary>
        [JsonProperty("passwordChanged")]
        public DateTime PasswordChanged { get; set; }

        /// <summary>
        /// Synchronization state for app user
        /// </summary>
        [JsonProperty("syncState")]
        public string SyncState { get; set; }

        /// <summary>
        /// Timestamp when last sync operation was executed
        /// </summary>
        [JsonProperty("lastSynced")]
        public DateTime LastSynced { get; set; }

        /// <summary>
        /// Credentials for assigned app
        /// </summary>
        [JsonProperty("credentials")]
        public AppUserCredentials Credentials { get; set; }

        /// <summary>
        /// Id of user in target app (must be imported or provisioned)
        /// </summary>
        [JsonProperty("externalId")]
        public string ExternalId { get; set; }
    }
}