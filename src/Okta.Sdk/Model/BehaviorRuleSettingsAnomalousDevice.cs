/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 5.1.0
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
    /// BehaviorRuleSettingsAnomalousDevice
    /// </summary>
    [DataContract(Name = "BehaviorRuleSettingsAnomalousDevice")]
    
    public partial class BehaviorRuleSettingsAnomalousDevice : IEquatable<BehaviorRuleSettingsAnomalousDevice>
    {
        
        /// <summary>
        /// Gets or Sets MaxEventsUsedForEvaluation
        /// </summary>
        [DataMember(Name = "maxEventsUsedForEvaluation", EmitDefaultValue = false)]
        public int MaxEventsUsedForEvaluation { get; set; }

        /// <summary>
        /// Gets or Sets MinEventsNeededForEvaluation
        /// </summary>
        [DataMember(Name = "minEventsNeededForEvaluation", EmitDefaultValue = false)]
        public int MinEventsNeededForEvaluation { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BehaviorRuleSettingsAnomalousDevice {\n");
            sb.Append("  MaxEventsUsedForEvaluation: ").Append(MaxEventsUsedForEvaluation).Append("\n");
            sb.Append("  MinEventsNeededForEvaluation: ").Append(MinEventsNeededForEvaluation).Append("\n");
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
            return this.Equals(input as BehaviorRuleSettingsAnomalousDevice);
        }

        /// <summary>
        /// Returns true if BehaviorRuleSettingsAnomalousDevice instances are equal
        /// </summary>
        /// <param name="input">Instance of BehaviorRuleSettingsAnomalousDevice to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BehaviorRuleSettingsAnomalousDevice input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.MaxEventsUsedForEvaluation == input.MaxEventsUsedForEvaluation ||
                    this.MaxEventsUsedForEvaluation.Equals(input.MaxEventsUsedForEvaluation)
                ) && 
                (
                    this.MinEventsNeededForEvaluation == input.MinEventsNeededForEvaluation ||
                    this.MinEventsNeededForEvaluation.Equals(input.MinEventsNeededForEvaluation)
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
                
                hashCode = (hashCode * 59) + this.MaxEventsUsedForEvaluation.GetHashCode();
                hashCode = (hashCode * 59) + this.MinEventsNeededForEvaluation.GetHashCode();
                return hashCode;
            }
        }

    }

}
