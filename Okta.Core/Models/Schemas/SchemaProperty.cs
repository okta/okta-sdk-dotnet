using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Okta.Core.Models.Schemas
{
    /// <summary>
    /// The definition of a Schema property
    /// </summary>
    public class SchemaProperty
    {
        /// <summary>
        /// User-defined display name for the property
        /// </summary>
        [JsonProperty("title")]
        public String Title { get; set; }
        /// <summary>
        /// Type of property
        /// </summary>
        [JsonProperty("type")]
        public String Type { get; set; }
        /// <summary>
        /// The format
        /// </summary>
        [JsonProperty("format")]
        public String Format { get; set; }
        /// <summary>
        /// The optional maximum length for any String property
        /// </summary>
        [JsonProperty("maxLength")]
        public int? MaxLength { get; set; }
        /// <summary>
        /// The optional minimum length for any String property
        /// </summary>
        [JsonProperty("minLength")]
        public int? MinLength { get; set; }
        /// <summary>
        /// Determines whether the property is required
        /// </summary>
        [JsonProperty("required")]
        public bool Required { get; set; }
        /// <summary>
        /// The permissions for the property
        /// </summary>
        [JsonProperty("permissions")]
        public SchemaPropertyPermission[] Permissions { get; set; }
    }
}
