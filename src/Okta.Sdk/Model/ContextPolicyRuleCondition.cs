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
    /// ContextPolicyRuleCondition
    /// </summary>
    [DataContract(Name = "ContextPolicyRuleCondition")]
    
    public partial class ContextPolicyRuleCondition : IEquatable<ContextPolicyRuleCondition>
    {

        /// <summary>
        /// Gets or Sets TrustLevel
        /// </summary>
        [DataMember(Name = "trustLevel", EmitDefaultValue = true)]
        
        public DevicePolicyTrustLevel TrustLevel { get; set; }
        
        /// <summary>
        /// Gets or Sets Migrated
        /// </summary>
        [DataMember(Name = "migrated", EmitDefaultValue = true)]
        public bool Migrated { get; set; }

        /// <summary>
        /// Gets or Sets Platform
        /// </summary>
        [DataMember(Name = "platform", EmitDefaultValue = true)]
        public DevicePolicyRuleConditionPlatform Platform { get; set; }

        /// <summary>
        /// Gets or Sets Rooted
        /// </summary>
        [DataMember(Name = "rooted", EmitDefaultValue = true)]
        public bool Rooted { get; set; }

        /// <summary>
        /// Gets or Sets Expression
        /// </summary>
        [DataMember(Name = "expression", EmitDefaultValue = true)]
        public string Expression { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ContextPolicyRuleCondition {\n");
            sb.Append("  Migrated: ").Append(Migrated).Append("\n");
            sb.Append("  Platform: ").Append(Platform).Append("\n");
            sb.Append("  Rooted: ").Append(Rooted).Append("\n");
            sb.Append("  TrustLevel: ").Append(TrustLevel).Append("\n");
            sb.Append("  Expression: ").Append(Expression).Append("\n");
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
            return this.Equals(input as ContextPolicyRuleCondition);
        }

        /// <summary>
        /// Returns true if ContextPolicyRuleCondition instances are equal
        /// </summary>
        /// <param name="input">Instance of ContextPolicyRuleCondition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ContextPolicyRuleCondition input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Migrated == input.Migrated ||
                    this.Migrated.Equals(input.Migrated)
                ) && 
                (
                    this.Platform == input.Platform ||
                    (this.Platform != null &&
                    this.Platform.Equals(input.Platform))
                ) && 
                (
                    this.Rooted == input.Rooted ||
                    this.Rooted.Equals(input.Rooted)
                ) && 
                (
                    this.TrustLevel == input.TrustLevel ||
                    this.TrustLevel.Equals(input.TrustLevel)
                ) && 
                (
                    this.Expression == input.Expression ||
                    (this.Expression != null &&
                    this.Expression.Equals(input.Expression))
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
                
                hashCode = (hashCode * 59) + this.Migrated.GetHashCode();
                if (this.Platform != null)
                {
                    hashCode = (hashCode * 59) + this.Platform.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Rooted.GetHashCode();
                if (this.TrustLevel != null)
                {
                    hashCode = (hashCode * 59) + this.TrustLevel.GetHashCode();
                }
                if (this.Expression != null)
                {
                    hashCode = (hashCode * 59) + this.Expression.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
