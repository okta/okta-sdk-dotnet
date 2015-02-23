using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// Read only objects that are related to another <see cref="ApiObject"/>.
    /// </summary>
    /// <remarks>
    /// These are typically used to save a roundtrip HTTP call
    /// </remarks>
    public class Embedded : ApiObject
    {
        public Embedded()
        {
            Factors = new List<Factor>();
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the factors.
        /// </summary>
        /// <value>
        /// The factors.
        /// </value>
        [JsonProperty("factors")]
        public List<Factor> Factors { get; set; }

        /// <summary>
        /// Gets or sets the factor.
        /// </summary>
        /// <value>
        /// The factor.
        /// </value>
        [JsonProperty("factor")]
        public Factor Factor { get; set; }

        [JsonProperty("activation")]
        public Activation Activation { get; set; }
    }

    public class Activation : ApiObject
    {
        [JsonProperty("timeStep")]
        public int TimeStep { get; set; }

        [JsonProperty("sharedSecret")]
        public string SharedSecret { get; set; }

        [JsonProperty("keyLength")]
        public int KeyLength { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        // Note: This is a "Factor Links Object" [0] and not a "Links Object" [1] as used elsewhere.
        // Footnotes:
        //   0: http://developer.okta.com/docs/api/rest/authn.html#factor-links-object
        //   1: http://developer.okta.com/docs/api/rest/authn.html#links-object
        [JsonProperty("_links")]
        public Dictionary<string, FactorLink> Links { get; set; }
    }

    /// <summary>
    /// A HAL link, with additional hints.
    /// </summary>
    public class FactorLink : Link
    {
        [JsonProperty("hints")]
        public Dictionary<string, List<string>> Hints { get; set; }
    }
}
