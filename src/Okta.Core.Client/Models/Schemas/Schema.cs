namespace Okta.Core.Models.Schemas
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// The Schema is defined using JSON Schema Draft 4.
    /// </summary>
    public class Schema : OktaObject
    {
        /// <summary>
        /// JSON Schema version identifier
        /// </summary>
        [JsonProperty("$schema")]
        public string JsonSchemaVersion { get; private set; }

        /// <summary>
        /// The name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// The title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// Timestamp when schema was last updated
        /// </summary>
        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; private set; }

        /// <summary>
        /// Timestamp when schema was created
        /// </summary>
        [JsonProperty("created")]
        public string Created { get; private set; }

        /// <summary>
        /// The Sub Schemas
        /// </summary>
        [JsonProperty("definitions")]
        public Dictionary<string, SubSchema> SubSchemas { get; private set; }
    }
}
