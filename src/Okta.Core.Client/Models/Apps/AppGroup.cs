namespace Okta.Core.Models
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// A group defined for an <see cref="App"/>
    /// </summary>
    public class AppGroup : OktaObject
    {
        /// <summary>
        /// Timestamp when app group was last updated
        /// </summary>
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Priority of group assignment
        /// </summary>
        [JsonProperty("priority")]
        public int Priority { get; set; }
    }
}