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
    /// PasswordPolicyRecoveryFactors
    /// </summary>
    [DataContract(Name = "PasswordPolicyRecoveryFactors")]
    
    public partial class PasswordPolicyRecoveryFactors : IEquatable<PasswordPolicyRecoveryFactors>
    {
        
        /// <summary>
        /// Gets or Sets OktaCall
        /// </summary>
        [DataMember(Name = "okta_call", EmitDefaultValue = false)]
        public PasswordPolicyRecoveryFactorSettings OktaCall { get; set; }

        /// <summary>
        /// Gets or Sets OktaEmail
        /// </summary>
        [DataMember(Name = "okta_email", EmitDefaultValue = false)]
        public PasswordPolicyRecoveryEmail OktaEmail { get; set; }

        /// <summary>
        /// Gets or Sets OktaSms
        /// </summary>
        [DataMember(Name = "okta_sms", EmitDefaultValue = false)]
        public PasswordPolicyRecoveryFactorSettings OktaSms { get; set; }

        /// <summary>
        /// Gets or Sets RecoveryQuestion
        /// </summary>
        [DataMember(Name = "recovery_question", EmitDefaultValue = false)]
        public PasswordPolicyRecoveryQuestion RecoveryQuestion { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PasswordPolicyRecoveryFactors {\n");
            sb.Append("  OktaCall: ").Append(OktaCall).Append("\n");
            sb.Append("  OktaEmail: ").Append(OktaEmail).Append("\n");
            sb.Append("  OktaSms: ").Append(OktaSms).Append("\n");
            sb.Append("  RecoveryQuestion: ").Append(RecoveryQuestion).Append("\n");
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
            return this.Equals(input as PasswordPolicyRecoveryFactors);
        }

        /// <summary>
        /// Returns true if PasswordPolicyRecoveryFactors instances are equal
        /// </summary>
        /// <param name="input">Instance of PasswordPolicyRecoveryFactors to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PasswordPolicyRecoveryFactors input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.OktaCall == input.OktaCall ||
                    (this.OktaCall != null &&
                    this.OktaCall.Equals(input.OktaCall))
                ) && 
                (
                    this.OktaEmail == input.OktaEmail ||
                    (this.OktaEmail != null &&
                    this.OktaEmail.Equals(input.OktaEmail))
                ) && 
                (
                    this.OktaSms == input.OktaSms ||
                    (this.OktaSms != null &&
                    this.OktaSms.Equals(input.OktaSms))
                ) && 
                (
                    this.RecoveryQuestion == input.RecoveryQuestion ||
                    (this.RecoveryQuestion != null &&
                    this.RecoveryQuestion.Equals(input.RecoveryQuestion))
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
                
                if (this.OktaCall != null)
                {
                    hashCode = (hashCode * 59) + this.OktaCall.GetHashCode();
                }
                if (this.OktaEmail != null)
                {
                    hashCode = (hashCode * 59) + this.OktaEmail.GetHashCode();
                }
                if (this.OktaSms != null)
                {
                    hashCode = (hashCode * 59) + this.OktaSms.GetHashCode();
                }
                if (this.RecoveryQuestion != null)
                {
                    hashCode = (hashCode * 59) + this.RecoveryQuestion.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
