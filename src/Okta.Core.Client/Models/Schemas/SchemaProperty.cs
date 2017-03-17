namespace Okta.Core.Models.Schemas
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The definition of a Schema property
    /// </summary>
    public class SchemaProperty
    {
        /// <summary>
        /// User-defined display name for the property
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Type of property
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The format
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

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
        
        /// <summary>
        /// The type of the items.
        /// </summary>
        [JsonProperty("items")]
        public SchemaItems Items { get; set; }
    }
}
