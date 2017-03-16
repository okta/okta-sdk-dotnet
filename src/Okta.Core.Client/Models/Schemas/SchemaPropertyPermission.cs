namespace Okta.Core.Models.Schemas
{
    using System;

    using Newtonsoft.Json;

    public class SchemaPropertyPermission
    {
        /// <summary>
        /// The security principal
        /// </summary>
        [JsonProperty("principal")]
        public string Principal { get; set; }

        /// <summary>
        /// Determines whether the principal can view or modify the property
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
