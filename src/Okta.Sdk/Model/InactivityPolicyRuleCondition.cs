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
    /// InactivityPolicyRuleCondition
    /// </summary>
    [DataContract(Name = "InactivityPolicyRuleCondition")]
    
    public partial class InactivityPolicyRuleCondition : IEquatable<InactivityPolicyRuleCondition>
    {
        
        /// <summary>
        /// Gets or Sets Number
        /// </summary>
        [DataMember(Name = "number", EmitDefaultValue = false)]
        public int Number { get; set; }

        /// <summary>
        /// Gets or Sets Unit
        /// </summary>
        [DataMember(Name = "unit", EmitDefaultValue = false)]
        public string Unit { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InactivityPolicyRuleCondition {\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  Unit: ").Append(Unit).Append("\n");
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
            return this.Equals(input as InactivityPolicyRuleCondition);
        }

        /// <summary>
        /// Returns true if InactivityPolicyRuleCondition instances are equal
        /// </summary>
        /// <param name="input">Instance of InactivityPolicyRuleCondition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InactivityPolicyRuleCondition input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Number == input.Number ||
                    this.Number.Equals(input.Number)
                ) && 
                (
                    this.Unit == input.Unit ||
                    (this.Unit != null &&
                    this.Unit.Equals(input.Unit))
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
                
                hashCode = (hashCode * 59) + this.Number.GetHashCode();
                if (this.Unit != null)
                {
                    hashCode = (hashCode * 59) + this.Unit.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
