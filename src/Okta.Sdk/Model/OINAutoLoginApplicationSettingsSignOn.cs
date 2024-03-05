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
    /// OINAutoLoginApplicationSettingsSignOn
    /// </summary>
    [DataContract(Name = "OINAutoLoginApplicationSettingsSignOn")]
    [JsonConverter(typeof(JsonSubtypes), "SignOnMode")]
    
    public partial class OINAutoLoginApplicationSettingsSignOn : OINApplicationSettingsSignOn, IEquatable<OINAutoLoginApplicationSettingsSignOn>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OINAutoLoginApplicationSettingsSignOn" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public OINAutoLoginApplicationSettingsSignOn() { }
        
        /// <summary>
        /// Gets or Sets SignOnMode
        /// </summary>
        [DataMember(Name = "signOnMode", EmitDefaultValue = true)]
        public Object SignOnMode { get; set; }

        /// <summary>
        /// Primary URL of the sign-in page for this app
        /// </summary>
        /// <value>Primary URL of the sign-in page for this app</value>
        [DataMember(Name = "loginUrl", EmitDefaultValue = true)]
        public string LoginUrl { get; set; }

        /// <summary>
        /// Secondary URL of the sign-in page for this app
        /// </summary>
        /// <value>Secondary URL of the sign-in page for this app</value>
        [DataMember(Name = "redirectUrl", EmitDefaultValue = true)]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OINAutoLoginApplicationSettingsSignOn {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  SignOnMode: ").Append(SignOnMode).Append("\n");
            sb.Append("  LoginUrl: ").Append(LoginUrl).Append("\n");
            sb.Append("  RedirectUrl: ").Append(RedirectUrl).Append("\n");
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
            return this.Equals(input as OINAutoLoginApplicationSettingsSignOn);
        }

        /// <summary>
        /// Returns true if OINAutoLoginApplicationSettingsSignOn instances are equal
        /// </summary>
        /// <param name="input">Instance of OINAutoLoginApplicationSettingsSignOn to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OINAutoLoginApplicationSettingsSignOn input)
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
                    this.LoginUrl == input.LoginUrl ||
                    (this.LoginUrl != null &&
                    this.LoginUrl.Equals(input.LoginUrl))
                ) && base.Equals(input) && 
                (
                    this.RedirectUrl == input.RedirectUrl ||
                    (this.RedirectUrl != null &&
                    this.RedirectUrl.Equals(input.RedirectUrl))
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
                if (this.LoginUrl != null)
                {
                    hashCode = (hashCode * 59) + this.LoginUrl.GetHashCode();
                }
                if (this.RedirectUrl != null)
                {
                    hashCode = (hashCode * 59) + this.RedirectUrl.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
