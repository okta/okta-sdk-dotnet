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
    /// APNSConfiguration
    /// </summary>
    [DataContract(Name = "APNSConfiguration")]
    
    public partial class APNSConfiguration : IEquatable<APNSConfiguration>
    {
        
        /// <summary>
        /// (Optional) File name for Admin Console display
        /// </summary>
        /// <value>(Optional) File name for Admin Console display</value>
        [DataMember(Name = "fileName", EmitDefaultValue = false)]
        public string FileName { get; set; }

        /// <summary>
        /// 10-character Key ID obtained from the Apple developer account
        /// </summary>
        /// <value>10-character Key ID obtained from the Apple developer account</value>
        [DataMember(Name = "keyId", EmitDefaultValue = false)]
        public string KeyId { get; set; }

        /// <summary>
        /// 10-character Team ID used to develop the iOS app
        /// </summary>
        /// <value>10-character Team ID used to develop the iOS app</value>
        [DataMember(Name = "teamId", EmitDefaultValue = false)]
        public string TeamId { get; set; }

        /// <summary>
        /// APNs private authentication token signing key
        /// </summary>
        /// <value>APNs private authentication token signing key</value>
        [DataMember(Name = "tokenSigningKey", EmitDefaultValue = false)]
        public string TokenSigningKey { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class APNSConfiguration {\n");
            sb.Append("  FileName: ").Append(FileName).Append("\n");
            sb.Append("  KeyId: ").Append(KeyId).Append("\n");
            sb.Append("  TeamId: ").Append(TeamId).Append("\n");
            sb.Append("  TokenSigningKey: ").Append(TokenSigningKey).Append("\n");
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
            return this.Equals(input as APNSConfiguration);
        }

        /// <summary>
        /// Returns true if APNSConfiguration instances are equal
        /// </summary>
        /// <param name="input">Instance of APNSConfiguration to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(APNSConfiguration input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.FileName == input.FileName ||
                    (this.FileName != null &&
                    this.FileName.Equals(input.FileName))
                ) && 
                (
                    this.KeyId == input.KeyId ||
                    (this.KeyId != null &&
                    this.KeyId.Equals(input.KeyId))
                ) && 
                (
                    this.TeamId == input.TeamId ||
                    (this.TeamId != null &&
                    this.TeamId.Equals(input.TeamId))
                ) && 
                (
                    this.TokenSigningKey == input.TokenSigningKey ||
                    (this.TokenSigningKey != null &&
                    this.TokenSigningKey.Equals(input.TokenSigningKey))
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
                
                if (this.FileName != null)
                {
                    hashCode = (hashCode * 59) + this.FileName.GetHashCode();
                }
                if (this.KeyId != null)
                {
                    hashCode = (hashCode * 59) + this.KeyId.GetHashCode();
                }
                if (this.TeamId != null)
                {
                    hashCode = (hashCode * 59) + this.TeamId.GetHashCode();
                }
                if (this.TokenSigningKey != null)
                {
                    hashCode = (hashCode * 59) + this.TokenSigningKey.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
