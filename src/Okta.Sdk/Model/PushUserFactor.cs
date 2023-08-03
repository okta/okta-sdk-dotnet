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
using JsonSubTypes;
using OpenAPIDateConverter = Okta.Sdk.Client.OpenAPIDateConverter;

namespace Okta.Sdk.Model
{
    /// <summary>
    /// Template: ModelGeneric
    /// PushUserFactor
    /// </summary>
    [DataContract(Name = "PushUserFactor")]
    [JsonConverter(typeof(JsonSubtypes), "FactorType")]
    [JsonSubtypes.KnownSubType(typeof(CallUserFactor), "call")]
    [JsonSubtypes.KnownSubType(typeof(EmailUserFactor), "email")]
    [JsonSubtypes.KnownSubType(typeof(CustomHotpUserFactor), "hotp")]
    [JsonSubtypes.KnownSubType(typeof(PushUserFactor), "push")]
    [JsonSubtypes.KnownSubType(typeof(SecurityQuestionUserFactor), "question")]
    [JsonSubtypes.KnownSubType(typeof(SmsUserFactor), "sms")]
    [JsonSubtypes.KnownSubType(typeof(TokenUserFactor), "token")]
    [JsonSubtypes.KnownSubType(typeof(HardwareUserFactor), "token:hardware")]
    [JsonSubtypes.KnownSubType(typeof(CustomHotpUserFactor), "token:hotp")]
    [JsonSubtypes.KnownSubType(typeof(TotpUserFactor), "token:software:totp")]
    [JsonSubtypes.KnownSubType(typeof(U2fUserFactor), "u2f")]
    [JsonSubtypes.KnownSubType(typeof(WebUserFactor), "web")]
    [JsonSubtypes.KnownSubType(typeof(WebAuthnUserFactor), "webauthn")]
    
    public partial class PushUserFactor : UserFactor, IEquatable<PushUserFactor>
    {

        /// <summary>
        /// Gets or Sets FactorResult
        /// </summary>
        [DataMember(Name = "factorResult", EmitDefaultValue = true)]
        
        public FactorResultType FactorResult { get; set; }
        
        /// <summary>
        /// Gets or Sets ExpiresAt
        /// </summary>
        [DataMember(Name = "expiresAt", EmitDefaultValue = true)]
        public DateTimeOffset ExpiresAt { get; set; }

        /// <summary>
        /// Gets or Sets Profile
        /// </summary>
        [DataMember(Name = "profile", EmitDefaultValue = true)]
        public PushUserFactorProfile Profile { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PushUserFactor {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
            sb.Append("  FactorResult: ").Append(FactorResult).Append("\n");
            sb.Append("  Profile: ").Append(Profile).Append("\n");
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
            return this.Equals(input as PushUserFactor);
        }

        /// <summary>
        /// Returns true if PushUserFactor instances are equal
        /// </summary>
        /// <param name="input">Instance of PushUserFactor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PushUserFactor input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.ExpiresAt == input.ExpiresAt ||
                    (this.ExpiresAt != null &&
                    this.ExpiresAt.Equals(input.ExpiresAt))
                ) && base.Equals(input) && 
                (
                    this.FactorResult == input.FactorResult ||
                    this.FactorResult.Equals(input.FactorResult)
                ) && base.Equals(input) && 
                (
                    this.Profile == input.Profile ||
                    (this.Profile != null &&
                    this.Profile.Equals(input.Profile))
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
                
                if (this.ExpiresAt != null)
                {
                    hashCode = (hashCode * 59) + this.ExpiresAt.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.FactorResult.GetHashCode();
                if (this.Profile != null)
                {
                    hashCode = (hashCode * 59) + this.Profile.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
