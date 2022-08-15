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
    /// WebAuthnUserFactorProfile
    /// </summary>
    [DataContract(Name = "WebAuthnUserFactorProfile")]
    
    public partial class WebAuthnUserFactorProfile : IEquatable<WebAuthnUserFactorProfile>
    {
        
        /// <summary>
        /// Gets or Sets AuthenticatorName
        /// </summary>
        [DataMember(Name = "authenticatorName", EmitDefaultValue = false)]
        public string AuthenticatorName { get; set; }

        /// <summary>
        /// Gets or Sets CredentialId
        /// </summary>
        [DataMember(Name = "credentialId", EmitDefaultValue = false)]
        public string CredentialId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WebAuthnUserFactorProfile {\n");
            sb.Append("  AuthenticatorName: ").Append(AuthenticatorName).Append("\n");
            sb.Append("  CredentialId: ").Append(CredentialId).Append("\n");
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
            return this.Equals(input as WebAuthnUserFactorProfile);
        }

        /// <summary>
        /// Returns true if WebAuthnUserFactorProfile instances are equal
        /// </summary>
        /// <param name="input">Instance of WebAuthnUserFactorProfile to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WebAuthnUserFactorProfile input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AuthenticatorName == input.AuthenticatorName ||
                    (this.AuthenticatorName != null &&
                    this.AuthenticatorName.Equals(input.AuthenticatorName))
                ) && 
                (
                    this.CredentialId == input.CredentialId ||
                    (this.CredentialId != null &&
                    this.CredentialId.Equals(input.CredentialId))
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
                
                if (this.AuthenticatorName != null)
                {
                    hashCode = (hashCode * 59) + this.AuthenticatorName.GetHashCode();
                }
                if (this.CredentialId != null)
                {
                    hashCode = (hashCode * 59) + this.CredentialId.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
