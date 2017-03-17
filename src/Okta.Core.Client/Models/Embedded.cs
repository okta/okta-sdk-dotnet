namespace Okta.Core.Models
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

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

        [JsonProperty("policy")]
        public Policy policy { get; set; }

        [JsonProperty("phones")]
        public List<Phones> phones { get; set; }


    }



    public class Activation : LinkedObject
    {
        [JsonProperty("timeStep")]
        public int TimeStep { get; set; }

        [JsonProperty("sharedSecret")]
        public string SharedSecret { get; set; }

        [JsonProperty("keyLength")]
        public int KeyLength { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }
    }


    public class Phones
    {
        [JsonProperty("profile")]
        public PhoneProfile profile { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
    }

    public class PhoneProfile
    {
        [JsonProperty("phoneNumber")]
        public string phoneNumber { get; set; }
    }

    public class Policy
    {
        public Complexity complexity { get; set; }
    }

    public class Complexity
    {
        public int minLength { get; set; }
        public int minLowerCase { get; set; }
        public int minUpperCase { get; set; }
        public int minNumber { get; set; }
        public int minSymbol { get; set; }
    }
}
