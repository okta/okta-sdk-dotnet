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
    /// AccessPolicyRuleConditionsAllOf
    /// </summary>
    [DataContract(Name = "AccessPolicyRuleConditions_allOf")]
    public partial class AccessPolicyRuleConditionsAllOf : IEquatable<AccessPolicyRuleConditionsAllOf>
    {
        
        /// <summary>
        /// Gets or Sets Device
        /// </summary>
        [DataMember(Name = "device", EmitDefaultValue = false)]
        public DeviceAccessPolicyRuleCondition Device { get; set; }

        /// <summary>
        /// Gets or Sets ElCondition
        /// </summary>
        [DataMember(Name = "elCondition", EmitDefaultValue = false)]
        public AccessPolicyRuleCustomCondition ElCondition { get; set; }

        /// <summary>
        /// Gets or Sets UserType
        /// </summary>
        [DataMember(Name = "userType", EmitDefaultValue = false)]
        public UserTypeCondition UserType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AccessPolicyRuleConditionsAllOf {\n");
            sb.Append("  Device: ").Append(Device).Append("\n");
            sb.Append("  ElCondition: ").Append(ElCondition).Append("\n");
            sb.Append("  UserType: ").Append(UserType).Append("\n");
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
            return this.Equals(input as AccessPolicyRuleConditionsAllOf);
        }

        /// <summary>
        /// Returns true if AccessPolicyRuleConditionsAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of AccessPolicyRuleConditionsAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccessPolicyRuleConditionsAllOf input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Device == input.Device ||
                    (this.Device != null &&
                    this.Device.Equals(input.Device))
                ) && 
                (
                    this.ElCondition == input.ElCondition ||
                    (this.ElCondition != null &&
                    this.ElCondition.Equals(input.ElCondition))
                ) && 
                (
                    this.UserType == input.UserType ||
                    (this.UserType != null &&
                    this.UserType.Equals(input.UserType))
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
                if (this.Device != null)
                {
                    hashCode = (hashCode * 59) + this.Device.GetHashCode();
                }
                if (this.ElCondition != null)
                {
                    hashCode = (hashCode * 59) + this.ElCondition.GetHashCode();
                }
                if (this.UserType != null)
                {
                    hashCode = (hashCode * 59) + this.UserType.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
