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
    /// OINSaml11ApplicationSettingsSignOn
    /// </summary>
    [DataContract(Name = "OINSaml11ApplicationSettingsSignOn")]
    [JsonConverter(typeof(JsonSubtypes), "SignOnMode")]
    [JsonSubtypes.KnownSubType(typeof(OINAutoLoginApplicationSettingsSignOn), "AUTO_LOGIN")]
    [JsonSubtypes.KnownSubType(typeof(OINSaml11ApplicationSettingsSignOn), "SAML_1_1")]
    [JsonSubtypes.KnownSubType(typeof(OINSaml20ApplicationSettingsSignOn), "SAML_2_0")]
    
    public partial class OINSaml11ApplicationSettingsSignOn : OINApplicationSettingsSignOn, IEquatable<OINSaml11ApplicationSettingsSignOn>
    {
        
        /// <summary>
        /// Gets or Sets SignOnMode
        /// </summary>
        [DataMember(Name = "signOnMode", EmitDefaultValue = true)]
        public Object SignOnMode { get; set; }

        /// <summary>
        /// Identifies a specific application resource in an IDP-initiated SSO scenario
        /// </summary>
        /// <value>Identifies a specific application resource in an IDP-initiated SSO scenario</value>
        [DataMember(Name = "defaultRelayState", EmitDefaultValue = true)]
        public string DefaultRelayState { get; set; }

        /// <summary>
        /// Assertion Consumer Service URL override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm)
        /// </summary>
        /// <value>Assertion Consumer Service URL override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm)</value>
        [DataMember(Name = "ssoAcsUrlOverride", EmitDefaultValue = true)]
        public string SsoAcsUrlOverride { get; set; }

        /// <summary>
        /// Audience override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm)
        /// </summary>
        /// <value>Audience override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm)</value>
        [DataMember(Name = "audienceOverride", EmitDefaultValue = true)]
        public string AudienceOverride { get; set; }

        /// <summary>
        /// Recipient override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm)
        /// </summary>
        /// <value>Recipient override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm)</value>
        [DataMember(Name = "recipientOverride", EmitDefaultValue = true)]
        public string RecipientOverride { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OINSaml11ApplicationSettingsSignOn {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  SignOnMode: ").Append(SignOnMode).Append("\n");
            sb.Append("  DefaultRelayState: ").Append(DefaultRelayState).Append("\n");
            sb.Append("  SsoAcsUrlOverride: ").Append(SsoAcsUrlOverride).Append("\n");
            sb.Append("  AudienceOverride: ").Append(AudienceOverride).Append("\n");
            sb.Append("  RecipientOverride: ").Append(RecipientOverride).Append("\n");
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
            return this.Equals(input as OINSaml11ApplicationSettingsSignOn);
        }

        /// <summary>
        /// Returns true if OINSaml11ApplicationSettingsSignOn instances are equal
        /// </summary>
        /// <param name="input">Instance of OINSaml11ApplicationSettingsSignOn to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OINSaml11ApplicationSettingsSignOn input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.SignOnMode == input.SignOnMode ||
                    (this.SignOnMode != null &&
                    this.SignOnMode.Equals(input.SignOnMode))
                ) && base.Equals(input) && 
                (
                    this.DefaultRelayState == input.DefaultRelayState ||
                    (this.DefaultRelayState != null &&
                    this.DefaultRelayState.Equals(input.DefaultRelayState))
                ) && base.Equals(input) && 
                (
                    this.SsoAcsUrlOverride == input.SsoAcsUrlOverride ||
                    (this.SsoAcsUrlOverride != null &&
                    this.SsoAcsUrlOverride.Equals(input.SsoAcsUrlOverride))
                ) && base.Equals(input) && 
                (
                    this.AudienceOverride == input.AudienceOverride ||
                    (this.AudienceOverride != null &&
                    this.AudienceOverride.Equals(input.AudienceOverride))
                ) && base.Equals(input) && 
                (
                    this.RecipientOverride == input.RecipientOverride ||
                    (this.RecipientOverride != null &&
                    this.RecipientOverride.Equals(input.RecipientOverride))
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
                
                if (this.SignOnMode != null)
                {
                    hashCode = (hashCode * 59) + this.SignOnMode.GetHashCode();
                }
                if (this.DefaultRelayState != null)
                {
                    hashCode = (hashCode * 59) + this.DefaultRelayState.GetHashCode();
                }
                if (this.SsoAcsUrlOverride != null)
                {
                    hashCode = (hashCode * 59) + this.SsoAcsUrlOverride.GetHashCode();
                }
                if (this.AudienceOverride != null)
                {
                    hashCode = (hashCode * 59) + this.AudienceOverride.GetHashCode();
                }
                if (this.RecipientOverride != null)
                {
                    hashCode = (hashCode * 59) + this.RecipientOverride.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}