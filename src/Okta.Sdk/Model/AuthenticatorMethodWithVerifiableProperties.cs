/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.06.1
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
using JsonSubTypes;
using OpenAPIDateConverter = Okta.Sdk.Client.OpenAPIDateConverter;

namespace Okta.Sdk.Model
{
    /// <summary>
    /// Template: ModelGeneric
    /// AuthenticatorMethodWithVerifiableProperties
    /// </summary>
    [DataContract(Name = "AuthenticatorMethodWithVerifiableProperties")]
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodOtp), "AuthenticatorMethodOtp")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodWithVerifiableProperties), "cert")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodWithVerifiableProperties), "duo")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodSimple), "email")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodWithVerifiableProperties), "idp")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodOtp), "otp")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodSimple), "password")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodPush), "push")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodSimple), "security_question")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodSignedNonce), "signed_nonce")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodSimple), "sms")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodTotp), "totp")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodSimple), "voice")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorMethodWebAuthn), "webauthn")]
    
    public partial class AuthenticatorMethodWithVerifiableProperties : AuthenticatorMethodBase, IEquatable<AuthenticatorMethodWithVerifiableProperties>
    {
        
        /// <summary>
        /// Gets or Sets VerifiableProperties
        /// </summary>
        [DataMember(Name = "verifiableProperties", EmitDefaultValue = true)]
        public List<AuthenticatorMethodProperty> VerifiableProperties { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthenticatorMethodWithVerifiableProperties {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  VerifiableProperties: ").Append(VerifiableProperties).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return this.Equals(input as AuthenticatorMethodWithVerifiableProperties);
        }

        /// <summary>
        /// Returns true if AuthenticatorMethodWithVerifiableProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthenticatorMethodWithVerifiableProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthenticatorMethodWithVerifiableProperties input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.VerifiableProperties == input.VerifiableProperties ||
                    this.VerifiableProperties != null &&
                    input.VerifiableProperties != null &&
                    this.VerifiableProperties.SequenceEqual(input.VerifiableProperties)
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
                int hashCode = base.GetHashCode();
                
                if (this.VerifiableProperties != null)
                {
                    hashCode = (hashCode * 59) + this.VerifiableProperties.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
