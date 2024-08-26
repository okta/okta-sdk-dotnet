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
    /// Security Events Provider with issuer and JWKS settings for signal ingestion
    /// </summary>
    [DataContract(Name = "SecurityEventsProviderSettingsNonSSFCompliant")]
    
    public partial class SecurityEventsProviderSettingsNonSSFCompliant : IEquatable<SecurityEventsProviderSettingsNonSSFCompliant>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityEventsProviderSettingsNonSSFCompliant" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public SecurityEventsProviderSettingsNonSSFCompliant() { }
        
        /// <summary>
        /// Issuer URL
        /// </summary>
        /// <value>Issuer URL</value>
        [DataMember(Name = "issuer", EmitDefaultValue = true)]
        public string Issuer { get; set; }

        /// <summary>
        /// The public URL where the JWKS public key is uploaded
        /// </summary>
        /// <value>The public URL where the JWKS public key is uploaded</value>
        [DataMember(Name = "jwks_url", EmitDefaultValue = true)]
        public string JwksUrl { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SecurityEventsProviderSettingsNonSSFCompliant {\n");
            sb.Append("  Issuer: ").Append(Issuer).Append("\n");
            sb.Append("  JwksUrl: ").Append(JwksUrl).Append("\n");
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
            return this.Equals(input as SecurityEventsProviderSettingsNonSSFCompliant);
        }

        /// <summary>
        /// Returns true if SecurityEventsProviderSettingsNonSSFCompliant instances are equal
        /// </summary>
        /// <param name="input">Instance of SecurityEventsProviderSettingsNonSSFCompliant to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SecurityEventsProviderSettingsNonSSFCompliant input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Issuer == input.Issuer ||
                    (this.Issuer != null &&
                    this.Issuer.Equals(input.Issuer))
                ) && 
                (
                    this.JwksUrl == input.JwksUrl ||
                    (this.JwksUrl != null &&
                    this.JwksUrl.Equals(input.JwksUrl))
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
                
                if (this.Issuer != null)
                {
                    hashCode = (hashCode * 59) + this.Issuer.GetHashCode();
                }
                if (this.JwksUrl != null)
                {
                    hashCode = (hashCode * 59) + this.JwksUrl.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}