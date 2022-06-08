/*
 * Okta API
 *
 * Allows customers to easily access the Okta API
 *
 * The version of the OpenAPI document: 3.0.0
 * Contact: devex-public@okta.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = Okta.Sdk.Client.OpenAPIDateConverter;

namespace Okta.Sdk.Model
{
    /// <summary>
    /// Template: ModelGeneric
    /// CustomHotpUserFactorAllOf
    /// </summary>
    [DataContract(Name = "CustomHotpUserFactor_allOf")]
    public partial class CustomHotpUserFactorAllOf : IEquatable<CustomHotpUserFactorAllOf>
    {
        
        /// <summary>
        /// Gets or Sets FactorProfileId
        /// </summary>
        [DataMember(Name = "factorProfileId", EmitDefaultValue = false)]
        public string FactorProfileId { get; set; }

        /// <summary>
        /// Gets or Sets Profile
        /// </summary>
        [DataMember(Name = "profile", EmitDefaultValue = false)]
        public CustomHotpUserFactorProfile Profile { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CustomHotpUserFactorAllOf {\n");
            sb.Append("  FactorProfileId: ").Append(FactorProfileId).Append("\n");
            sb.Append("  Profile: ").Append(Profile).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as CustomHotpUserFactorAllOf);
        }

        /// <summary>
        /// Returns true if CustomHotpUserFactorAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of CustomHotpUserFactorAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CustomHotpUserFactorAllOf input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.FactorProfileId == input.FactorProfileId ||
                    (this.FactorProfileId != null &&
                    this.FactorProfileId.Equals(input.FactorProfileId))
                ) && 
                (
                    this.Profile == input.Profile ||
                    (this.Profile != null &&
                    this.Profile.Equals(input.Profile))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.FactorProfileId != null)
                {
                    hashCode = (hashCode * 59) + this.FactorProfileId.GetHashCode();
                }
                if (this.Profile != null)
                {
                    hashCode = (hashCode * 59) + this.Profile.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
