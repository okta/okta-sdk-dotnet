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
    /// Base sign-in setting schema for an OIN app
    /// </summary>
    [DataContract(Name = "OINApplicationSettingsSignOn")]
    [JsonConverter(typeof(JsonSubtypes), "SignOnMode")]
    [JsonSubtypes.KnownSubType(typeof(OINAutoLoginApplicationSettingsSignOn), "AUTO_LOGIN")]
    [JsonSubtypes.KnownSubType(typeof(OINSaml11ApplicationSettingsSignOn), "SAML_1_1")]
    [JsonSubtypes.KnownSubType(typeof(OINSaml20ApplicationSettingsSignOn), "SAML_2_0")]
    
    public partial class OINApplicationSettingsSignOn : IEquatable<OINApplicationSettingsSignOn>
    {

        /// <summary>
        /// Gets or Sets SignOnMode
        /// </summary>
        [DataMember(Name = "signOnMode", EmitDefaultValue = true)]
        
        public ApplicationSignOnMode SignOnMode { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OINApplicationSettingsSignOn {\n");
            sb.Append("  SignOnMode: ").Append(SignOnMode).Append("\n");
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
            return this.Equals(input as OINApplicationSettingsSignOn);
        }

        /// <summary>
        /// Returns true if OINApplicationSettingsSignOn instances are equal
        /// </summary>
        /// <param name="input">Instance of OINApplicationSettingsSignOn to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OINApplicationSettingsSignOn input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.SignOnMode == input.SignOnMode ||
                    this.SignOnMode.Equals(input.SignOnMode)
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
                
                if (this.SignOnMode != null)
                {
                    hashCode = (hashCode * 59) + this.SignOnMode.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
