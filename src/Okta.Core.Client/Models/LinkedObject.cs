namespace Okta.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    /// <summary>
    /// An entity that has HAL links
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class LinkedObject : ApiObject
    {
        internal LinkedObject()
        {
            Links = new Dictionary<string, List<Link>>();
        }

        /// <summary>
        /// Gets the self URI.
        /// </summary>
        /// <value>
        /// The self URI.
        /// </value>
        public Uri SelfUri { get { return Links.ContainsKey("self") ? this.Links["self"].First().Href : null; } }

        /// <summary>
        /// Gets the refresh URI.
        /// </summary>
        /// <value>
        /// The Refresh URI.
        /// </value>
        public Uri RefreshUri { get { return Links.ContainsKey("refresh") ? this.Links["refresh"].First().Href : null; } }


        /// <summary>
        /// Gets or sets the HAL links of an object.
        /// </summary>
        /// <value>
        /// The HAL links.
        /// </value>
        [JsonProperty("_links")]
        public Dictionary<string, List<Link>> Links { get; set; }
    }
}
