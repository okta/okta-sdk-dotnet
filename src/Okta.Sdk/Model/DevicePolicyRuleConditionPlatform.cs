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
    /// DevicePolicyRuleConditionPlatform
    /// </summary>
    [DataContract(Name = "DevicePolicyRuleConditionPlatform")]
    public partial class DevicePolicyRuleConditionPlatform : IEquatable<DevicePolicyRuleConditionPlatform>
    {
        
        /// <summary>
        /// Gets or Sets SupportedMDMFrameworks
        /// </summary>
        [DataMember(Name = "supportedMDMFrameworks", EmitDefaultValue = false)]
        public List<string> SupportedMDMFrameworks { get; set; }

        /// <summary>
        /// Gets or Sets Types
        /// </summary>
        [DataMember(Name = "types", EmitDefaultValue = false)]
        public List<string> Types { get; set; }

        /// <summary>
        /// Gets or Sets additional properties
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DevicePolicyRuleConditionPlatform {\n");
            sb.Append("  SupportedMDMFrameworks: ").Append(SupportedMDMFrameworks).Append("\n");
            sb.Append("  Types: ").Append(Types).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
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
            return this.Equals(input as DevicePolicyRuleConditionPlatform);
        }

        /// <summary>
        /// Returns true if DevicePolicyRuleConditionPlatform instances are equal
        /// </summary>
        /// <param name="input">Instance of DevicePolicyRuleConditionPlatform to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DevicePolicyRuleConditionPlatform input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.SupportedMDMFrameworks == input.SupportedMDMFrameworks ||
                    this.SupportedMDMFrameworks != null &&
                    input.SupportedMDMFrameworks != null &&
                    this.SupportedMDMFrameworks.SequenceEqual(input.SupportedMDMFrameworks)
                ) && 
                (
                    this.Types == input.Types ||
                    this.Types != null &&
                    input.Types != null &&
                    this.Types.SequenceEqual(input.Types)
                )
                && (this.AdditionalProperties.Count == input.AdditionalProperties.Count && !this.AdditionalProperties.Except(input.AdditionalProperties).Any());
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
                if (this.SupportedMDMFrameworks != null)
                {
                    hashCode = (hashCode * 59) + this.SupportedMDMFrameworks.GetHashCode();
                }
                if (this.Types != null)
                {
                    hashCode = (hashCode * 59) + this.Types.GetHashCode();
                }
                if (this.AdditionalProperties != null)
                {
                    hashCode = (hashCode * 59) + this.AdditionalProperties.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
