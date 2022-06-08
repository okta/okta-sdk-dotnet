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
    /// OktaSignOnPolicyAllOf
    /// </summary>
    [DataContract(Name = "OktaSignOnPolicy_allOf")]
    public partial class OktaSignOnPolicyAllOf : IEquatable<OktaSignOnPolicyAllOf>
    {
        
        /// <summary>
        /// Gets or Sets Conditions
        /// </summary>
        [DataMember(Name = "conditions", EmitDefaultValue = false)]
        public OktaSignOnPolicyConditions Conditions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OktaSignOnPolicyAllOf {\n");
            sb.Append("  Conditions: ").Append(Conditions).Append("\n");
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
            return this.Equals(input as OktaSignOnPolicyAllOf);
        }

        /// <summary>
        /// Returns true if OktaSignOnPolicyAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of OktaSignOnPolicyAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OktaSignOnPolicyAllOf input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Conditions == input.Conditions ||
                    (this.Conditions != null &&
                    this.Conditions.Equals(input.Conditions))
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
                if (this.Conditions != null)
                {
                    hashCode = (hashCode * 59) + this.Conditions.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
