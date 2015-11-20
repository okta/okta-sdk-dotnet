using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okta.Core.Models.Schemas
{
    public class SchemaPropertyPermission
    {
        /// <summary>
        /// The security principal
        /// </summary>
        [JsonProperty("principal")]
        public String Principal { get; set; }
        /// <summary>
        /// Determines whether the principal can view or modify the property
        /// </summary>
        [JsonProperty("action")]
        public String Action { get; set; }
    }
}
