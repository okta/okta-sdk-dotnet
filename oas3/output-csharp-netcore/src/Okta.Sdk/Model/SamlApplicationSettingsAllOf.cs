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
    /// SamlApplicationSettingsAllOf
    /// </summary>
    [DataContract(Name = "SamlApplicationSettings_allOf")]
    public partial class SamlApplicationSettingsAllOf : IEquatable<SamlApplicationSettingsAllOf>
    {
        
        /// <summary>
        /// Gets or Sets App
        /// </summary>
        [DataMember(Name = "app", EmitDefaultValue = false)]
        public SamlApplicationSettingsApplication App { get; set; }

        /// <summary>
        /// Gets or Sets SignOn
        /// </summary>
        [DataMember(Name = "signOn", EmitDefaultValue = false)]
        public SamlApplicationSettingsSignOn SignOn { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SamlApplicationSettingsAllOf {\n");
            sb.Append("  App: ").Append(App).Append("\n");
            sb.Append("  SignOn: ").Append(SignOn).Append("\n");
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
            return this.Equals(input as SamlApplicationSettingsAllOf);
        }

        /// <summary>
        /// Returns true if SamlApplicationSettingsAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of SamlApplicationSettingsAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SamlApplicationSettingsAllOf input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.App == input.App ||
                    (this.App != null &&
                    this.App.Equals(input.App))
                ) && 
                (
                    this.SignOn == input.SignOn ||
                    (this.SignOn != null &&
                    this.SignOn.Equals(input.SignOn))
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
                if (this.App != null)
                {
                    hashCode = (hashCode * 59) + this.App.GetHashCode();
                }
                if (this.SignOn != null)
                {
                    hashCode = (hashCode * 59) + this.SignOn.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
