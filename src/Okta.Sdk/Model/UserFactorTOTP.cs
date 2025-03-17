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
using JsonSubTypes;
using OpenAPIDateConverter = Okta.Sdk.Client.OpenAPIDateConverter;

namespace Okta.Sdk.Model
{
    /// <summary>
    /// Template: ModelGeneric
    /// UserFactorTOTP
    /// </summary>
    [DataContract(Name = "UserFactorTOTP")]
    [JsonConverter(typeof(JsonSubtypes), "FactorType")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorCall), "call")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorEmail), "email")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorCustomHOTP), "hotp")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorPush), "push")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorSecurityQuestion), "question")]
    [JsonSubtypes.KnownSubType(typeof(UserFactor), "signed_nonce")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorSMS), "sms")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorToken), "token")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorHardware), "token:hardware")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorCustomHOTP), "token:hotp")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorTOTP), "token:software:totp")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorU2F), "u2f")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorWeb), "web")]
    [JsonSubtypes.KnownSubType(typeof(UserFactorWebAuthn), "webauthn")]
    
    public partial class UserFactorTOTP : UserFactor, IEquatable<UserFactorTOTP>
    {
        /// <summary>
        /// Defines Provider
        /// </summary>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class ProviderEnum : StringEnum
        {
            /// <summary>
            /// StringEnum OKTA for value: OKTA
            /// </summary>
            
            public static ProviderEnum OKTA = new ProviderEnum("OKTA");

            /// <summary>
            /// StringEnum GOOGLE for value: GOOGLE
            /// </summary>
            
            public static ProviderEnum GOOGLE = new ProviderEnum("GOOGLE");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="ProviderEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator ProviderEnum(string value) => new ProviderEnum(value);

            /// <summary>
            /// Creates a new <see cref="Provider"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public ProviderEnum(string value)
                : base(value)
            {
            }
        }


        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        [DataMember(Name = "provider", EmitDefaultValue = true)]
        
        public ProviderEnum Provider { get; set; }

        /// <summary>
        /// Gets or Sets Profile
        /// </summary>
        [DataMember(Name = "profile", EmitDefaultValue = true)]
        public UserFactorTOTPProfile Profile { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserFactorTOTP {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  FactorType: ").Append(FactorType).Append("\n");
            sb.Append("  Profile: ").Append(Profile).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
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
            return this.Equals(input as UserFactorTOTP);
        }

        /// <summary>
        /// Returns true if UserFactorTOTP instances are equal
        /// </summary>
        /// <param name="input">Instance of UserFactorTOTP to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserFactorTOTP input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.FactorType == input.FactorType ||
                    (this.FactorType != null &&
                    this.FactorType.Equals(input.FactorType))
                ) && base.Equals(input) && 
                (
                    this.Profile == input.Profile ||
                    (this.Profile != null &&
                    this.Profile.Equals(input.Profile))
                ) && base.Equals(input) && 
                (
                    this.Provider == input.Provider ||
                    this.Provider.Equals(input.Provider)
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
                
                if (this.FactorType != null)
                {
                    hashCode = (hashCode * 59) + this.FactorType.GetHashCode();
                }
                if (this.Profile != null)
                {
                    hashCode = (hashCode * 59) + this.Profile.GetHashCode();
                }
                if (this.Provider != null)
                {
                    hashCode = (hashCode * 59) + this.Provider.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
