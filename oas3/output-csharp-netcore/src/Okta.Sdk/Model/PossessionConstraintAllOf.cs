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
    /// PossessionConstraintAllOf
    /// </summary>
    [DataContract(Name = "PossessionConstraint_allOf")]
    public partial class PossessionConstraintAllOf : IEquatable<PossessionConstraintAllOf>
    {
        
        /// <summary>
        /// Gets or Sets DeviceBound
        /// </summary>
        [DataMember(Name = "deviceBound", EmitDefaultValue = false)]
        public string DeviceBound { get; set; }

        /// <summary>
        /// Gets or Sets HardwareProtection
        /// </summary>
        [DataMember(Name = "hardwareProtection", EmitDefaultValue = false)]
        public string HardwareProtection { get; set; }

        /// <summary>
        /// Gets or Sets PhishingResistant
        /// </summary>
        [DataMember(Name = "phishingResistant", EmitDefaultValue = false)]
        public string PhishingResistant { get; set; }

        /// <summary>
        /// Gets or Sets UserPresence
        /// </summary>
        [DataMember(Name = "userPresence", EmitDefaultValue = false)]
        public string UserPresence { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PossessionConstraintAllOf {\n");
            sb.Append("  DeviceBound: ").Append(DeviceBound).Append("\n");
            sb.Append("  HardwareProtection: ").Append(HardwareProtection).Append("\n");
            sb.Append("  PhishingResistant: ").Append(PhishingResistant).Append("\n");
            sb.Append("  UserPresence: ").Append(UserPresence).Append("\n");
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
            return this.Equals(input as PossessionConstraintAllOf);
        }

        /// <summary>
        /// Returns true if PossessionConstraintAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of PossessionConstraintAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PossessionConstraintAllOf input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.DeviceBound == input.DeviceBound ||
                    (this.DeviceBound != null &&
                    this.DeviceBound.Equals(input.DeviceBound))
                ) && 
                (
                    this.HardwareProtection == input.HardwareProtection ||
                    (this.HardwareProtection != null &&
                    this.HardwareProtection.Equals(input.HardwareProtection))
                ) && 
                (
                    this.PhishingResistant == input.PhishingResistant ||
                    (this.PhishingResistant != null &&
                    this.PhishingResistant.Equals(input.PhishingResistant))
                ) && 
                (
                    this.UserPresence == input.UserPresence ||
                    (this.UserPresence != null &&
                    this.UserPresence.Equals(input.UserPresence))
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
                if (this.DeviceBound != null)
                {
                    hashCode = (hashCode * 59) + this.DeviceBound.GetHashCode();
                }
                if (this.HardwareProtection != null)
                {
                    hashCode = (hashCode * 59) + this.HardwareProtection.GetHashCode();
                }
                if (this.PhishingResistant != null)
                {
                    hashCode = (hashCode * 59) + this.PhishingResistant.GetHashCode();
                }
                if (this.UserPresence != null)
                {
                    hashCode = (hashCode * 59) + this.UserPresence.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
