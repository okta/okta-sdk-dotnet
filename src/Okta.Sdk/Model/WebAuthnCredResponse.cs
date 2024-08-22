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
    /// Credential response object for enrolled credential details, along with enrollment and key identifiers to associate the credential
    /// </summary>
    [DataContract(Name = "WebAuthnCredResponse")]
    
    public partial class WebAuthnCredResponse : IEquatable<WebAuthnCredResponse>
    {
        
        /// <summary>
        /// ID for a WebAuthn Preregistration Factor in Okta
        /// </summary>
        /// <value>ID for a WebAuthn Preregistration Factor in Okta</value>
        [DataMember(Name = "authenticatorEnrollmentId", EmitDefaultValue = true)]
        public string AuthenticatorEnrollmentId { get; set; }

        /// <summary>
        /// Encrypted JWE of credential response from the fulfillment provider
        /// </summary>
        /// <value>Encrypted JWE of credential response from the fulfillment provider</value>
        [DataMember(Name = "credResponseJWE", EmitDefaultValue = true)]
        public string CredResponseJWE { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WebAuthnCredResponse {\n");
            sb.Append("  AuthenticatorEnrollmentId: ").Append(AuthenticatorEnrollmentId).Append("\n");
            sb.Append("  CredResponseJWE: ").Append(CredResponseJWE).Append("\n");
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
            return this.Equals(input as WebAuthnCredResponse);
        }

        /// <summary>
        /// Returns true if WebAuthnCredResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of WebAuthnCredResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WebAuthnCredResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AuthenticatorEnrollmentId == input.AuthenticatorEnrollmentId ||
                    (this.AuthenticatorEnrollmentId != null &&
                    this.AuthenticatorEnrollmentId.Equals(input.AuthenticatorEnrollmentId))
                ) && 
                (
                    this.CredResponseJWE == input.CredResponseJWE ||
                    (this.CredResponseJWE != null &&
                    this.CredResponseJWE.Equals(input.CredResponseJWE))
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
                
                if (this.AuthenticatorEnrollmentId != null)
                {
                    hashCode = (hashCode * 59) + this.AuthenticatorEnrollmentId.GetHashCode();
                }
                if (this.CredResponseJWE != null)
                {
                    hashCode = (hashCode * 59) + this.CredResponseJWE.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
