/*
 * Okta API
 *
 * Allows customers to easily access the Okta API
 *
 * The version of the OpenAPI document: 3.0.0
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
    /// SignInPageAllOf
    /// </summary>
    [DataContract(Name = "SignInPage_allOf")]
    public partial class SignInPageAllOf : IEquatable<SignInPageAllOf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignInPageAllOf" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public SignInPageAllOf() { }
        
        /// <summary>
        /// Gets or Sets DefaultApp
        /// </summary>
        [DataMember(Name = "defaultApp", EmitDefaultValue = false)]
        public SignInPageAllOfDefaultApp DefaultApp { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets WidgetCustomizations
        /// </summary>
        [DataMember(Name = "widgetCustomizations", EmitDefaultValue = false)]
        public SignInPageAllOfWidgetCustomizations WidgetCustomizations { get; set; }

        /// <summary>
        /// The version specified as a [Semantic Version](https://semver.org/).
        /// </summary>
        /// <value>The version specified as a [Semantic Version](https://semver.org/).</value>
        [DataMember(Name = "widgetVersion", EmitDefaultValue = false)]
        public string WidgetVersion { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SignInPageAllOf {\n");
            sb.Append("  DefaultApp: ").Append(DefaultApp).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  WidgetCustomizations: ").Append(WidgetCustomizations).Append("\n");
            sb.Append("  WidgetVersion: ").Append(WidgetVersion).Append("\n");
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
            return this.Equals(input as SignInPageAllOf);
        }

        /// <summary>
        /// Returns true if SignInPageAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of SignInPageAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SignInPageAllOf input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.DefaultApp == input.DefaultApp ||
                    (this.DefaultApp != null &&
                    this.DefaultApp.Equals(input.DefaultApp))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.WidgetCustomizations == input.WidgetCustomizations ||
                    (this.WidgetCustomizations != null &&
                    this.WidgetCustomizations.Equals(input.WidgetCustomizations))
                ) && 
                (
                    this.WidgetVersion == input.WidgetVersion ||
                    (this.WidgetVersion != null &&
                    this.WidgetVersion.Equals(input.WidgetVersion))
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
                if (this.DefaultApp != null)
                {
                    hashCode = (hashCode * 59) + this.DefaultApp.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                if (this.Url != null)
                {
                    hashCode = (hashCode * 59) + this.Url.GetHashCode();
                }
                if (this.WidgetCustomizations != null)
                {
                    hashCode = (hashCode * 59) + this.WidgetCustomizations.GetHashCode();
                }
                if (this.WidgetVersion != null)
                {
                    hashCode = (hashCode * 59) + this.WidgetVersion.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
