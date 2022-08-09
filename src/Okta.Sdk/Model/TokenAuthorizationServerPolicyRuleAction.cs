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
    /// TokenAuthorizationServerPolicyRuleAction
    /// </summary>
    [DataContract(Name = "TokenAuthorizationServerPolicyRuleAction")]
    public partial class TokenAuthorizationServerPolicyRuleAction : IEquatable<TokenAuthorizationServerPolicyRuleAction>
    {
        
        /// <summary>
        /// Gets or Sets AccessTokenLifetimeMinutes
        /// </summary>
        [DataMember(Name = "accessTokenLifetimeMinutes", EmitDefaultValue = false)]
        public int AccessTokenLifetimeMinutes { get; set; }

        /// <summary>
        /// Gets or Sets InlineHook
        /// </summary>
        [DataMember(Name = "inlineHook", EmitDefaultValue = false)]
        public TokenAuthorizationServerPolicyRuleActionInlineHook InlineHook { get; set; }

        /// <summary>
        /// Gets or Sets RefreshTokenLifetimeMinutes
        /// </summary>
        [DataMember(Name = "refreshTokenLifetimeMinutes", EmitDefaultValue = false)]
        public int RefreshTokenLifetimeMinutes { get; set; }

        /// <summary>
        /// Gets or Sets RefreshTokenWindowMinutes
        /// </summary>
        [DataMember(Name = "refreshTokenWindowMinutes", EmitDefaultValue = false)]
        public int RefreshTokenWindowMinutes { get; set; }

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
            sb.Append("class TokenAuthorizationServerPolicyRuleAction {\n");
            sb.Append("  AccessTokenLifetimeMinutes: ").Append(AccessTokenLifetimeMinutes).Append("\n");
            sb.Append("  InlineHook: ").Append(InlineHook).Append("\n");
            sb.Append("  RefreshTokenLifetimeMinutes: ").Append(RefreshTokenLifetimeMinutes).Append("\n");
            sb.Append("  RefreshTokenWindowMinutes: ").Append(RefreshTokenWindowMinutes).Append("\n");
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
            return this.Equals(input as TokenAuthorizationServerPolicyRuleAction);
        }

        /// <summary>
        /// Returns true if TokenAuthorizationServerPolicyRuleAction instances are equal
        /// </summary>
        /// <param name="input">Instance of TokenAuthorizationServerPolicyRuleAction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TokenAuthorizationServerPolicyRuleAction input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AccessTokenLifetimeMinutes == input.AccessTokenLifetimeMinutes ||
                    this.AccessTokenLifetimeMinutes.Equals(input.AccessTokenLifetimeMinutes)
                ) && 
                (
                    this.InlineHook == input.InlineHook ||
                    (this.InlineHook != null &&
                    this.InlineHook.Equals(input.InlineHook))
                ) && 
                (
                    this.RefreshTokenLifetimeMinutes == input.RefreshTokenLifetimeMinutes ||
                    this.RefreshTokenLifetimeMinutes.Equals(input.RefreshTokenLifetimeMinutes)
                ) && 
                (
                    this.RefreshTokenWindowMinutes == input.RefreshTokenWindowMinutes ||
                    this.RefreshTokenWindowMinutes.Equals(input.RefreshTokenWindowMinutes)
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
                hashCode = (hashCode * 59) + this.AccessTokenLifetimeMinutes.GetHashCode();
                if (this.InlineHook != null)
                {
                    hashCode = (hashCode * 59) + this.InlineHook.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RefreshTokenLifetimeMinutes.GetHashCode();
                hashCode = (hashCode * 59) + this.RefreshTokenWindowMinutes.GetHashCode();
                if (this.AdditionalProperties != null)
                {
                    hashCode = (hashCode * 59) + this.AdditionalProperties.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
