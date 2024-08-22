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
    /// AutoLoginApplicationSettingsSignOn
    /// </summary>
    [DataContract(Name = "AutoLoginApplicationSettingsSignOn")]
    
    public partial class AutoLoginApplicationSettingsSignOn : IEquatable<AutoLoginApplicationSettingsSignOn>
    {
        
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
            sb.Append("class AutoLoginApplicationSettingsSignOn {\n");
            sb.Append("  LoginUrl: ").Append(LoginUrl).Append("\n");
            sb.Append("  RedirectUrl: ").Append(RedirectUrl).Append("\n");
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
            return this.Equals(input as AutoLoginApplicationSettingsSignOn);
        }

        /// <summary>
        /// Returns true if AutoLoginApplicationSettingsSignOn instances are equal
        /// </summary>
        /// <param name="input">Instance of AutoLoginApplicationSettingsSignOn to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AutoLoginApplicationSettingsSignOn input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.LoginUrl == input.LoginUrl ||
                    (this.LoginUrl != null &&
                    this.LoginUrl.Equals(input.LoginUrl))
                ) && 
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
                int hashCode = 41;
                
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
