using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okta.Core.Models.Schemas
{
    /// <summary>
    /// The Schema is defined using JSON Schema Draft 4.
    /// </summary>
    public class Schema : OktaObject
    {
        /// <summary>
        /// JSON Schema version identifier
        /// </summary>
        [JsonProperty("$schema")]
        public String JsonSchemaVersion { get; private set; }
        /// <summary>
        /// The name
        /// </summary>
        [JsonProperty("name")]
        public String Name { get; private set; }
        /// <summary>
        /// The title
        /// </summary>
        [JsonProperty("title")]
        public String Title { get; private set; }
        /// <summary>
        /// Timestamp when schema was last updated
        /// </summary>
        [JsonProperty("lastUpdated")]
        public String LastUpdated { get; private set; }
        /// <summary>
        /// Timestamp when schema was created
        /// </summary>
        [JsonProperty("created")]
        public String Created { get; private set; }
        /// <summary>
        /// The Sub Schemas
        /// </summary>
        [JsonProperty("definitions")]
        public Dictionary<String, SubSchema> SubSchemas { get; private set; }
    }
}
