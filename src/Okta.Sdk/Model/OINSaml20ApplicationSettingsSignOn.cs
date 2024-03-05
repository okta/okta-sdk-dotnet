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
    /// Contains the sign-in attributes available when configuring an app with &#x60;SAML_2_0&#x60; as the &#x60;signOnMode&#x60;
    /// </summary>
    [DataContract(Name = "OINSaml20ApplicationSettingsSignOn")]
    [JsonConverter(typeof(JsonSubtypes), "SignOnMode")]
    
    public partial class OINSaml20ApplicationSettingsSignOn : OINSaml11ApplicationSettingsSignOn, IEquatable<OINSaml20ApplicationSettingsSignOn>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OINSaml20ApplicationSettingsSignOn" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public OINSaml20ApplicationSettingsSignOn() { }
        
        /// <summary>
        /// Gets or Sets SignOnMode
        /// </summary>
        [DataMember(Name = "signOnMode", EmitDefaultValue = true)]
        public Object SignOnMode { get; set; }

        /// <summary>
        /// Destination override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm)
        /// </summary>
        /// <value>Destination override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm)</value>
        [DataMember(Name = "destinationOverride", EmitDefaultValue = true)]
        public string DestinationOverride { get; set; }

        /// <summary>
        /// Set to &#x60;true&#x60; to prompt users for their credentials when a SAML request has the &#x60;ForceAuthn&#x60; attribute set to &#x60;true&#x60;
        /// </summary>
        /// <value>Set to &#x60;true&#x60; to prompt users for their credentials when a SAML request has the &#x60;ForceAuthn&#x60; attribute set to &#x60;true&#x60;</value>
        [DataMember(Name = "honorForceAuthn", EmitDefaultValue = true)]
        public bool HonorForceAuthn { get; set; }

        /// <summary>
        /// Gets or Sets ConfiguredAttributeStatements
        /// </summary>
        [DataMember(Name = "configuredAttributeStatements", EmitDefaultValue = true)]
        public List<SamlAttributeStatement> ConfiguredAttributeStatements { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OINSaml20ApplicationSettingsSignOn {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  SignOnMode: ").Append(SignOnMode).Append("\n");
            sb.Append("  DestinationOverride: ").Append(DestinationOverride).Append("\n");
            sb.Append("  HonorForceAuthn: ").Append(HonorForceAuthn).Append("\n");
            sb.Append("  ConfiguredAttributeStatements: ").Append(ConfiguredAttributeStatements).Append("\n");
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
            return this.Equals(input as OINSaml20ApplicationSettingsSignOn);
        }

        /// <summary>
        /// Returns true if OINSaml20ApplicationSettingsSignOn instances are equal
        /// </summary>
        /// <param name="input">Instance of OINSaml20ApplicationSettingsSignOn to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OINSaml20ApplicationSettingsSignOn input)
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
                    this.DestinationOverride == input.DestinationOverride ||
                    (this.DestinationOverride != null &&
                    this.DestinationOverride.Equals(input.DestinationOverride))
                ) && base.Equals(input) && 
                (
                    this.HonorForceAuthn == input.HonorForceAuthn ||
                    this.HonorForceAuthn.Equals(input.HonorForceAuthn)
                ) && base.Equals(input) && 
                (
                    this.ConfiguredAttributeStatements == input.ConfiguredAttributeStatements ||
                    this.ConfiguredAttributeStatements != null &&
                    input.ConfiguredAttributeStatements != null &&
                    this.ConfiguredAttributeStatements.SequenceEqual(input.ConfiguredAttributeStatements)
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
                if (this.DestinationOverride != null)
                {
                    hashCode = (hashCode * 59) + this.DestinationOverride.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.HonorForceAuthn.GetHashCode();
                if (this.ConfiguredAttributeStatements != null)
                {
                    hashCode = (hashCode * 59) + this.ConfiguredAttributeStatements.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
