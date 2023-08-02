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
using OpenAPIDateConverter = Okta.Sdk.Client.OpenAPIDateConverter;

namespace Okta.Sdk.Model
{
    /// <summary>
    /// Template: ModelGeneric
    /// SwaApplicationSettingsApplication
    /// </summary>
    [DataContract(Name = "SwaApplicationSettingsApplication")]
    
    public partial class SwaApplicationSettingsApplication : IEquatable<SwaApplicationSettingsApplication>
    {
        
        /// <summary>
        /// Gets or Sets ButtonField
        /// </summary>
        [DataMember(Name = "buttonField", EmitDefaultValue = false)]
        public string ButtonField { get; set; }

        /// <summary>
        /// Gets or Sets ButtonSelector
        /// </summary>
        [DataMember(Name = "buttonSelector", EmitDefaultValue = false)]
        public string ButtonSelector { get; set; }

        /// <summary>
        /// Gets or Sets Checkbox
        /// </summary>
        [DataMember(Name = "checkbox", EmitDefaultValue = false)]
        public string Checkbox { get; set; }

        /// <summary>
        /// Gets or Sets ExtraFieldSelector
        /// </summary>
        [DataMember(Name = "extraFieldSelector", EmitDefaultValue = false)]
        public string ExtraFieldSelector { get; set; }

        /// <summary>
        /// Gets or Sets ExtraFieldValue
        /// </summary>
        [DataMember(Name = "extraFieldValue", EmitDefaultValue = false)]
        public string ExtraFieldValue { get; set; }

        /// <summary>
        /// Gets or Sets LoginUrlRegex
        /// </summary>
        [DataMember(Name = "loginUrlRegex", EmitDefaultValue = false)]
        public string LoginUrlRegex { get; set; }

        /// <summary>
        /// Gets or Sets PasswordField
        /// </summary>
        [DataMember(Name = "passwordField", EmitDefaultValue = false)]
        public string PasswordField { get; set; }

        /// <summary>
        /// Gets or Sets PasswordSelector
        /// </summary>
        [DataMember(Name = "passwordSelector", EmitDefaultValue = false)]
        public string PasswordSelector { get; set; }

        /// <summary>
        /// Gets or Sets RedirectUrl
        /// </summary>
        [DataMember(Name = "redirectUrl", EmitDefaultValue = false)]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Gets or Sets TargetURL
        /// </summary>
        [DataMember(Name = "targetURL", EmitDefaultValue = false)]
        public string TargetURL { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets UsernameField
        /// </summary>
        [DataMember(Name = "usernameField", EmitDefaultValue = false)]
        public string UsernameField { get; set; }

        /// <summary>
        /// Gets or Sets UserNameSelector
        /// </summary>
        [DataMember(Name = "userNameSelector", EmitDefaultValue = false)]
        public string UserNameSelector { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SwaApplicationSettingsApplication {\n");
            sb.Append("  ButtonField: ").Append(ButtonField).Append("\n");
            sb.Append("  ButtonSelector: ").Append(ButtonSelector).Append("\n");
            sb.Append("  Checkbox: ").Append(Checkbox).Append("\n");
            sb.Append("  ExtraFieldSelector: ").Append(ExtraFieldSelector).Append("\n");
            sb.Append("  ExtraFieldValue: ").Append(ExtraFieldValue).Append("\n");
            sb.Append("  LoginUrlRegex: ").Append(LoginUrlRegex).Append("\n");
            sb.Append("  PasswordField: ").Append(PasswordField).Append("\n");
            sb.Append("  PasswordSelector: ").Append(PasswordSelector).Append("\n");
            sb.Append("  RedirectUrl: ").Append(RedirectUrl).Append("\n");
            sb.Append("  TargetURL: ").Append(TargetURL).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  UsernameField: ").Append(UsernameField).Append("\n");
            sb.Append("  UserNameSelector: ").Append(UserNameSelector).Append("\n");
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
            return this.Equals(input as SwaApplicationSettingsApplication);
        }

        /// <summary>
        /// Returns true if SwaApplicationSettingsApplication instances are equal
        /// </summary>
        /// <param name="input">Instance of SwaApplicationSettingsApplication to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SwaApplicationSettingsApplication input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ButtonField == input.ButtonField ||
                    (this.ButtonField != null &&
                    this.ButtonField.Equals(input.ButtonField))
                ) && 
                (
                    this.ButtonSelector == input.ButtonSelector ||
                    (this.ButtonSelector != null &&
                    this.ButtonSelector.Equals(input.ButtonSelector))
                ) && 
                (
                    this.Checkbox == input.Checkbox ||
                    (this.Checkbox != null &&
                    this.Checkbox.Equals(input.Checkbox))
                ) && 
                (
                    this.ExtraFieldSelector == input.ExtraFieldSelector ||
                    (this.ExtraFieldSelector != null &&
                    this.ExtraFieldSelector.Equals(input.ExtraFieldSelector))
                ) && 
                (
                    this.ExtraFieldValue == input.ExtraFieldValue ||
                    (this.ExtraFieldValue != null &&
                    this.ExtraFieldValue.Equals(input.ExtraFieldValue))
                ) && 
                (
                    this.LoginUrlRegex == input.LoginUrlRegex ||
                    (this.LoginUrlRegex != null &&
                    this.LoginUrlRegex.Equals(input.LoginUrlRegex))
                ) && 
                (
                    this.PasswordField == input.PasswordField ||
                    (this.PasswordField != null &&
                    this.PasswordField.Equals(input.PasswordField))
                ) && 
                (
                    this.PasswordSelector == input.PasswordSelector ||
                    (this.PasswordSelector != null &&
                    this.PasswordSelector.Equals(input.PasswordSelector))
                ) && 
                (
                    this.RedirectUrl == input.RedirectUrl ||
                    (this.RedirectUrl != null &&
                    this.RedirectUrl.Equals(input.RedirectUrl))
                ) && 
                (
                    this.TargetURL == input.TargetURL ||
                    (this.TargetURL != null &&
                    this.TargetURL.Equals(input.TargetURL))
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.UsernameField == input.UsernameField ||
                    (this.UsernameField != null &&
                    this.UsernameField.Equals(input.UsernameField))
                ) && 
                (
                    this.UserNameSelector == input.UserNameSelector ||
                    (this.UserNameSelector != null &&
                    this.UserNameSelector.Equals(input.UserNameSelector))
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
                
                if (this.ButtonField != null)
                {
                    hashCode = (hashCode * 59) + this.ButtonField.GetHashCode();
                }
                if (this.ButtonSelector != null)
                {
                    hashCode = (hashCode * 59) + this.ButtonSelector.GetHashCode();
                }
                if (this.Checkbox != null)
                {
                    hashCode = (hashCode * 59) + this.Checkbox.GetHashCode();
                }
                if (this.ExtraFieldSelector != null)
                {
                    hashCode = (hashCode * 59) + this.ExtraFieldSelector.GetHashCode();
                }
                if (this.ExtraFieldValue != null)
                {
                    hashCode = (hashCode * 59) + this.ExtraFieldValue.GetHashCode();
                }
                if (this.LoginUrlRegex != null)
                {
                    hashCode = (hashCode * 59) + this.LoginUrlRegex.GetHashCode();
                }
                if (this.PasswordField != null)
                {
                    hashCode = (hashCode * 59) + this.PasswordField.GetHashCode();
                }
                if (this.PasswordSelector != null)
                {
                    hashCode = (hashCode * 59) + this.PasswordSelector.GetHashCode();
                }
                if (this.RedirectUrl != null)
                {
                    hashCode = (hashCode * 59) + this.RedirectUrl.GetHashCode();
                }
                if (this.TargetURL != null)
                {
                    hashCode = (hashCode * 59) + this.TargetURL.GetHashCode();
                }
                if (this.Url != null)
                {
                    hashCode = (hashCode * 59) + this.Url.GetHashCode();
                }
                if (this.UsernameField != null)
                {
                    hashCode = (hashCode * 59) + this.UsernameField.GetHashCode();
                }
                if (this.UserNameSelector != null)
                {
                    hashCode = (hashCode * 59) + this.UserNameSelector.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
