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
    /// ProfileEnrollmentPolicyRuleAction
    /// </summary>
    [DataContract(Name = "ProfileEnrollmentPolicyRuleAction")]
    public partial class ProfileEnrollmentPolicyRuleAction : IEquatable<ProfileEnrollmentPolicyRuleAction>
    {
        
        /// <summary>
        /// Gets or Sets Access
        /// </summary>
        [DataMember(Name = "access", EmitDefaultValue = false)]
        public string Access { get; set; }

        /// <summary>
        /// Gets or Sets ActivationRequirements
        /// </summary>
        [DataMember(Name = "activationRequirements", EmitDefaultValue = false)]
        public ProfileEnrollmentPolicyRuleActivationRequirement ActivationRequirements { get; set; }

        /// <summary>
        /// Gets or Sets PreRegistrationInlineHooks
        /// </summary>
        [DataMember(Name = "preRegistrationInlineHooks", EmitDefaultValue = false)]
        public List<PreRegistrationInlineHook> PreRegistrationInlineHooks { get; set; }

        /// <summary>
        /// Gets or Sets ProfileAttributes
        /// </summary>
        [DataMember(Name = "profileAttributes", EmitDefaultValue = false)]
        public List<ProfileEnrollmentPolicyRuleProfileAttribute> ProfileAttributes { get; set; }

        /// <summary>
        /// Gets or Sets TargetGroupIds
        /// </summary>
        [DataMember(Name = "targetGroupIds", EmitDefaultValue = false)]
        public List<string> TargetGroupIds { get; set; }

        /// <summary>
        /// Gets or Sets UnknownUserAction
        /// </summary>
        [DataMember(Name = "unknownUserAction", EmitDefaultValue = false)]
        public string UnknownUserAction { get; set; }

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
            sb.Append("class ProfileEnrollmentPolicyRuleAction {\n");
            sb.Append("  Access: ").Append(Access).Append("\n");
            sb.Append("  ActivationRequirements: ").Append(ActivationRequirements).Append("\n");
            sb.Append("  PreRegistrationInlineHooks: ").Append(PreRegistrationInlineHooks).Append("\n");
            sb.Append("  ProfileAttributes: ").Append(ProfileAttributes).Append("\n");
            sb.Append("  TargetGroupIds: ").Append(TargetGroupIds).Append("\n");
            sb.Append("  UnknownUserAction: ").Append(UnknownUserAction).Append("\n");
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
            return this.Equals(input as ProfileEnrollmentPolicyRuleAction);
        }

        /// <summary>
        /// Returns true if ProfileEnrollmentPolicyRuleAction instances are equal
        /// </summary>
        /// <param name="input">Instance of ProfileEnrollmentPolicyRuleAction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProfileEnrollmentPolicyRuleAction input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Access == input.Access ||
                    (this.Access != null &&
                    this.Access.Equals(input.Access))
                ) && 
                (
                    this.ActivationRequirements == input.ActivationRequirements ||
                    (this.ActivationRequirements != null &&
                    this.ActivationRequirements.Equals(input.ActivationRequirements))
                ) && 
                (
                    this.PreRegistrationInlineHooks == input.PreRegistrationInlineHooks ||
                    this.PreRegistrationInlineHooks != null &&
                    input.PreRegistrationInlineHooks != null &&
                    this.PreRegistrationInlineHooks.SequenceEqual(input.PreRegistrationInlineHooks)
                ) && 
                (
                    this.ProfileAttributes == input.ProfileAttributes ||
                    this.ProfileAttributes != null &&
                    input.ProfileAttributes != null &&
                    this.ProfileAttributes.SequenceEqual(input.ProfileAttributes)
                ) && 
                (
                    this.TargetGroupIds == input.TargetGroupIds ||
                    this.TargetGroupIds != null &&
                    input.TargetGroupIds != null &&
                    this.TargetGroupIds.SequenceEqual(input.TargetGroupIds)
                ) && 
                (
                    this.UnknownUserAction == input.UnknownUserAction ||
                    (this.UnknownUserAction != null &&
                    this.UnknownUserAction.Equals(input.UnknownUserAction))
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
                if (this.Access != null)
                {
                    hashCode = (hashCode * 59) + this.Access.GetHashCode();
                }
                if (this.ActivationRequirements != null)
                {
                    hashCode = (hashCode * 59) + this.ActivationRequirements.GetHashCode();
                }
                if (this.PreRegistrationInlineHooks != null)
                {
                    hashCode = (hashCode * 59) + this.PreRegistrationInlineHooks.GetHashCode();
                }
                if (this.ProfileAttributes != null)
                {
                    hashCode = (hashCode * 59) + this.ProfileAttributes.GetHashCode();
                }
                if (this.TargetGroupIds != null)
                {
                    hashCode = (hashCode * 59) + this.TargetGroupIds.GetHashCode();
                }
                if (this.UnknownUserAction != null)
                {
                    hashCode = (hashCode * 59) + this.UnknownUserAction.GetHashCode();
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
