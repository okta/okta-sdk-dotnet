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
    /// RiskPolicyRuleCondition
    /// </summary>
    [DataContract(Name = "RiskPolicyRuleCondition")]
    public partial class RiskPolicyRuleCondition : IEquatable<RiskPolicyRuleCondition>
    {
        
        /// <summary>
        /// Gets or Sets Behaviors
        /// </summary>
        [DataMember(Name = "behaviors", EmitDefaultValue = false)]
        public List<string> Behaviors { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RiskPolicyRuleCondition {\n");
            sb.Append("  Behaviors: ").Append(Behaviors).Append("\n");
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
            return this.Equals(input as RiskPolicyRuleCondition);
        }

        /// <summary>
        /// Returns true if RiskPolicyRuleCondition instances are equal
        /// </summary>
        /// <param name="input">Instance of RiskPolicyRuleCondition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RiskPolicyRuleCondition input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Behaviors == input.Behaviors ||
                    this.Behaviors != null &&
                    input.Behaviors != null &&
                    this.Behaviors.SequenceEqual(input.Behaviors)
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
                if (this.Behaviors != null)
                {
                    hashCode = (hashCode * 59) + this.Behaviors.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
