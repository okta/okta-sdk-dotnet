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
    /// ResetPasswordToken
    /// </summary>
    [DataContract(Name = "ResetPasswordToken")]
    public partial class ResetPasswordToken : IEquatable<ResetPasswordToken>
    {
        
        /// <summary>
        /// Gets or Sets ResetPasswordUrl
        /// </summary>
        [DataMember(Name = "resetPasswordUrl", EmitDefaultValue = false)]
        public string ResetPasswordUrl { get; private set; }

        /// <summary>
        /// Returns false as ResetPasswordUrl should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeResetPasswordUrl()
        {
            return false;
        }
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
            sb.Append("class ResetPasswordToken {\n");
            sb.Append("  ResetPasswordUrl: ").Append(ResetPasswordUrl).Append("\n");
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
            return this.Equals(input as ResetPasswordToken);
        }

        /// <summary>
        /// Returns true if ResetPasswordToken instances are equal
        /// </summary>
        /// <param name="input">Instance of ResetPasswordToken to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ResetPasswordToken input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ResetPasswordUrl == input.ResetPasswordUrl ||
                    (this.ResetPasswordUrl != null &&
                    this.ResetPasswordUrl.Equals(input.ResetPasswordUrl))
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
                if (this.ResetPasswordUrl != null)
                {
                    hashCode = (hashCode * 59) + this.ResetPasswordUrl.GetHashCode();
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
