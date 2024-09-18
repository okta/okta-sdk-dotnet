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
    /// AuthenticatorKeyEmail
    /// </summary>
    [DataContract(Name = "AuthenticatorKeyEmail")]
    [JsonConverter(typeof(JsonSubtypes), "Key")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeyCustomApp), "custom_app")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeyDuo), "duo")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeyExternalIdp), "external_idp")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeyGoogleOtp), "google_otp")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeyEmail), "okta_email")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeyPassword), "okta_password")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeyOktaVerify), "okta_verify")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeyOnprem), "onprem_mfa")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeyPhone), "phone_number")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeySecurityKey), "security_key")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeySecurityQuestion), "security_question")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeySmartCard), "smart_card_idp")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeySymantecVip), "symantec_vip")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeyWebauthn), "webauthn")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatorKeyYubikey), "yubikey_token")]
    
    public partial class AuthenticatorKeyEmail : AuthenticatorSimple, IEquatable<AuthenticatorKeyEmail>
    {
        
        /// <summary>
        /// Gets or Sets Settings
        /// </summary>
        [DataMember(Name = "settings", EmitDefaultValue = true)]
        public AuthenticatorKeyEmailAllOfSettings Settings { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthenticatorKeyEmail {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Settings: ").Append(Settings).Append("\n");
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
            return this.Equals(input as AuthenticatorKeyEmail);
        }

        /// <summary>
        /// Returns true if AuthenticatorKeyEmail instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthenticatorKeyEmail to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthenticatorKeyEmail input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.Settings == input.Settings ||
                    (this.Settings != null &&
                    this.Settings.Equals(input.Settings))
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
                
                if (this.Settings != null)
                {
                    hashCode = (hashCode * 59) + this.Settings.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}