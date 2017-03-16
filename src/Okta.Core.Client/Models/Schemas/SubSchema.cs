namespace Okta.Core.Models.Schemas
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class SubSchema
    {
        /// <summary>
        /// Sub Schema Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>
        /// Sub Schema type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; private set; }

        /// <summary>
        /// The properties of the Sub Schema
        /// </summary>
        [JsonProperty("properties")]
        public Dictionary<string, SchemaProperty> Properties { get; private set; }

        /// <summary>
        /// List of required property names
        /// </summary>
        [JsonProperty("required")]
        public List<string> RequiredProperties { get; private set; }
    }
}
