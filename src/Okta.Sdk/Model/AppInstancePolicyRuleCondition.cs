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
    /// AppInstancePolicyRuleCondition
    /// </summary>
    [DataContract(Name = "AppInstancePolicyRuleCondition")]
    
    public partial class AppInstancePolicyRuleCondition : IEquatable<AppInstancePolicyRuleCondition>
    {
        
        /// <summary>
        /// Gets or Sets Exclude
        /// </summary>
        [DataMember(Name = "exclude", EmitDefaultValue = false)]
        public List<string> Exclude { get; set; }

        /// <summary>
        /// Gets or Sets Include
        /// </summary>
        [DataMember(Name = "include", EmitDefaultValue = false)]
        public List<string> Include { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AppInstancePolicyRuleCondition {\n");
            sb.Append("  Exclude: ").Append(Exclude).Append("\n");
            sb.Append("  Include: ").Append(Include).Append("\n");
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
            return this.Equals(input as AppInstancePolicyRuleCondition);
        }

        /// <summary>
        /// Returns true if AppInstancePolicyRuleCondition instances are equal
        /// </summary>
        /// <param name="input">Instance of AppInstancePolicyRuleCondition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AppInstancePolicyRuleCondition input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Exclude == input.Exclude ||
                    this.Exclude != null &&
                    input.Exclude != null &&
                    this.Exclude.SequenceEqual(input.Exclude)
                ) && 
                (
                    this.Include == input.Include ||
                    this.Include != null &&
                    input.Include != null &&
                    this.Include.SequenceEqual(input.Include)
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
                
                if (this.Exclude != null)
                {
                    hashCode = (hashCode * 59) + this.Exclude.GetHashCode();
                }
                if (this.Include != null)
                {
                    hashCode = (hashCode * 59) + this.Include.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
