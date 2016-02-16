namespace Okta.Core.Models
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// A log entry for a change within an Okta org
    /// </summary>
    public class Event : OktaObject
    {
        /// <summary>
        /// Unique key for event
        /// </summary>
        [JsonProperty("eventId")]
        public override string Id { get; set; }

        /// <summary>
        /// Timestamp when event was published  
        /// </summary>
        [JsonProperty("published")]
        public DateTime Published { get; set; }

        /// <summary>
        /// Identifies the request
        /// </summary>
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// Session in which the event occurred
        /// </summary>
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("action")]
        public Action Action { get; set; }

        [JsonProperty("actors")]
        public Actor[] Actors { get; set; }

        [JsonProperty("targets")]
        public Target[] Targets { get; set; }
    }
}