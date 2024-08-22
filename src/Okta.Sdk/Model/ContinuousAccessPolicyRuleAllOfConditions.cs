/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.07.0
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
    /// ContinuousAccessPolicyRuleAllOfConditions
    /// </summary>
    [DataContract(Name = "ContinuousAccessPolicyRule_allOf_conditions")]
    
    public partial class ContinuousAccessPolicyRuleAllOfConditions : IEquatable<ContinuousAccessPolicyRuleAllOfConditions>
    {
        
        /// <summary>
        /// Gets or Sets People
        /// </summary>
        [DataMember(Name = "people", EmitDefaultValue = true)]
        public PolicyPeopleCondition People { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ContinuousAccessPolicyRuleAllOfConditions {\n");
            sb.Append("  People: ").Append(People).Append("\n");
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
            return this.Equals(input as ContinuousAccessPolicyRuleAllOfConditions);
        }

        /// <summary>
        /// Returns true if ContinuousAccessPolicyRuleAllOfConditions instances are equal
        /// </summary>
        /// <param name="input">Instance of ContinuousAccessPolicyRuleAllOfConditions to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ContinuousAccessPolicyRuleAllOfConditions input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.People == input.People ||
                    (this.People != null &&
                    this.People.Equals(input.People))
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
                
                if (this.People != null)
                {
                    hashCode = (hashCode * 59) + this.People.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
