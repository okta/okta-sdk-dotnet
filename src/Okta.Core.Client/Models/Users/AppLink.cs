namespace Okta.Core.Models
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// A link between a <see cref="User"/> and an <see cref="App"/>
    /// </summary>
    public class AppLink : OktaObject
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("linkUrl")]
        public Uri LinkUrl { get; set; }

        [JsonProperty("logoUrl")]
        public Uri LogoUrl { get; set; }

        [JsonProperty("appName")]
        public string AppName { get; set; }

        [JsonProperty("appInstanceId")]
        public string AppInstanceId { get; set; }

        [JsonProperty("appAssignmentId")]
        public string AppAssignmentId { get; set; }

        [JsonProperty("credentialsSetup")]
        public bool CredentialsSetup { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The index of the <see cref="AppLink"/> relative to the other links
        /// </value>
        [JsonProperty("sortOrder")]
        public int SortOrder { get; set; }
    }
}