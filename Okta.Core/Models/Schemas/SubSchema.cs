using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okta.Core.Models.Schemas
{
    public class SubSchema
    {
        /// <summary>
        /// Sub Schema Id
        /// </summary>
        [JsonProperty("id")]
        public String Id { get; private set; }
        /// <summary>
        /// Sub Schema type
        /// </summary>
        [JsonProperty("type")]
        public String Type { get; private set; }
        /// <summary>
        /// The properties of the Sub Schema
        /// </summary>
        [JsonProperty("properties")]
        public Dictionary<String, SchemaProperty> Properties { get; private set; }
        /// <summary>
        /// List of required property names
        /// </summary>
        [JsonProperty("required")]
        public List<String> RequiredProperties { get; private set; }
    }
}
