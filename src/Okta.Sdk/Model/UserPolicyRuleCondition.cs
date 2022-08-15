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
    /// UserPolicyRuleCondition
    /// </summary>
    [DataContract(Name = "UserPolicyRuleCondition")]
    
    public partial class UserPolicyRuleCondition : IEquatable<UserPolicyRuleCondition>
    {
        
        /// <summary>
        /// Gets or Sets Exclude
        /// </summary>
        [DataMember(Name = "exclude", EmitDefaultValue = false)]
        public List<string> Exclude { get; set; }

        /// <summary>
        /// Gets or Sets Inactivity
        /// </summary>
        [DataMember(Name = "inactivity", EmitDefaultValue = false)]
        public InactivityPolicyRuleCondition Inactivity { get; set; }

        /// <summary>
        /// Gets or Sets Include
        /// </summary>
        [DataMember(Name = "include", EmitDefaultValue = false)]
        public List<string> Include { get; set; }

        /// <summary>
        /// Gets or Sets LifecycleExpiration
        /// </summary>
        [DataMember(Name = "lifecycleExpiration", EmitDefaultValue = false)]
        public LifecycleExpirationPolicyRuleCondition LifecycleExpiration { get; set; }

        /// <summary>
        /// Gets or Sets PasswordExpiration
        /// </summary>
        [DataMember(Name = "passwordExpiration", EmitDefaultValue = false)]
        public PasswordExpirationPolicyRuleCondition PasswordExpiration { get; set; }

        /// <summary>
        /// Gets or Sets UserLifecycleAttribute
        /// </summary>
        [DataMember(Name = "userLifecycleAttribute", EmitDefaultValue = false)]
        public UserLifecycleAttributePolicyRuleCondition UserLifecycleAttribute { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserPolicyRuleCondition {\n");
            sb.Append("  Exclude: ").Append(Exclude).Append("\n");
            sb.Append("  Inactivity: ").Append(Inactivity).Append("\n");
            sb.Append("  Include: ").Append(Include).Append("\n");
            sb.Append("  LifecycleExpiration: ").Append(LifecycleExpiration).Append("\n");
            sb.Append("  PasswordExpiration: ").Append(PasswordExpiration).Append("\n");
            sb.Append("  UserLifecycleAttribute: ").Append(UserLifecycleAttribute).Append("\n");
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
            return this.Equals(input as UserPolicyRuleCondition);
        }

        /// <summary>
        /// Returns true if UserPolicyRuleCondition instances are equal
        /// </summary>
        /// <param name="input">Instance of UserPolicyRuleCondition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserPolicyRuleCondition input)
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
                    this.Inactivity == input.Inactivity ||
                    (this.Inactivity != null &&
                    this.Inactivity.Equals(input.Inactivity))
                ) && 
                (
                    this.Include == input.Include ||
                    this.Include != null &&
                    input.Include != null &&
                    this.Include.SequenceEqual(input.Include)
                ) && 
                (
                    this.LifecycleExpiration == input.LifecycleExpiration ||
                    (this.LifecycleExpiration != null &&
                    this.LifecycleExpiration.Equals(input.LifecycleExpiration))
                ) && 
                (
                    this.PasswordExpiration == input.PasswordExpiration ||
                    (this.PasswordExpiration != null &&
                    this.PasswordExpiration.Equals(input.PasswordExpiration))
                ) && 
                (
                    this.UserLifecycleAttribute == input.UserLifecycleAttribute ||
                    (this.UserLifecycleAttribute != null &&
                    this.UserLifecycleAttribute.Equals(input.UserLifecycleAttribute))
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
                if (this.Inactivity != null)
                {
                    hashCode = (hashCode * 59) + this.Inactivity.GetHashCode();
                }
                if (this.Include != null)
                {
                    hashCode = (hashCode * 59) + this.Include.GetHashCode();
                }
                if (this.LifecycleExpiration != null)
                {
                    hashCode = (hashCode * 59) + this.LifecycleExpiration.GetHashCode();
                }
                if (this.PasswordExpiration != null)
                {
                    hashCode = (hashCode * 59) + this.PasswordExpiration.GetHashCode();
                }
                if (this.UserLifecycleAttribute != null)
                {
                    hashCode = (hashCode * 59) + this.UserLifecycleAttribute.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
