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
    /// ApplicationAccessibility
    /// </summary>
    [DataContract(Name = "ApplicationAccessibility")]
    public partial class ApplicationAccessibility : IEquatable<ApplicationAccessibility>
    {
        
        /// <summary>
        /// Gets or Sets ErrorRedirectUrl
        /// </summary>
        [DataMember(Name = "errorRedirectUrl", EmitDefaultValue = false)]
        public string ErrorRedirectUrl { get; set; }

        /// <summary>
        /// Gets or Sets LoginRedirectUrl
        /// </summary>
        [DataMember(Name = "loginRedirectUrl", EmitDefaultValue = false)]
        public string LoginRedirectUrl { get; set; }

        /// <summary>
        /// Gets or Sets SelfService
        /// </summary>
        [DataMember(Name = "selfService", EmitDefaultValue = true)]
        public bool SelfService { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ApplicationAccessibility {\n");
            sb.Append("  ErrorRedirectUrl: ").Append(ErrorRedirectUrl).Append("\n");
            sb.Append("  LoginRedirectUrl: ").Append(LoginRedirectUrl).Append("\n");
            sb.Append("  SelfService: ").Append(SelfService).Append("\n");
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
            return this.Equals(input as ApplicationAccessibility);
        }

        /// <summary>
        /// Returns true if ApplicationAccessibility instances are equal
        /// </summary>
        /// <param name="input">Instance of ApplicationAccessibility to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApplicationAccessibility input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ErrorRedirectUrl == input.ErrorRedirectUrl ||
                    (this.ErrorRedirectUrl != null &&
                    this.ErrorRedirectUrl.Equals(input.ErrorRedirectUrl))
                ) && 
                (
                    this.LoginRedirectUrl == input.LoginRedirectUrl ||
                    (this.LoginRedirectUrl != null &&
                    this.LoginRedirectUrl.Equals(input.LoginRedirectUrl))
                ) && 
                (
                    this.SelfService == input.SelfService ||
                    this.SelfService.Equals(input.SelfService)
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
                if (this.ErrorRedirectUrl != null)
                {
                    hashCode = (hashCode * 59) + this.ErrorRedirectUrl.GetHashCode();
                }
                if (this.LoginRedirectUrl != null)
                {
                    hashCode = (hashCode * 59) + this.LoginRedirectUrl.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.SelfService.GetHashCode();
                return hashCode;
            }
        }

    }

}
