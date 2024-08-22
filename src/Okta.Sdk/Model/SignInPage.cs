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
    /// SignInPage
    /// </summary>
    [DataContract(Name = "SignInPage")]
    
    public partial class SignInPage : IEquatable<SignInPage>
    {
        
        /// <summary>
        /// The HTML for the page
        /// </summary>
        /// <value>The HTML for the page</value>
        [DataMember(Name = "pageContent", EmitDefaultValue = true)]
        public string PageContent { get; set; }

        /// <summary>
        /// Gets or Sets ContentSecurityPolicySetting
        /// </summary>
        [DataMember(Name = "contentSecurityPolicySetting", EmitDefaultValue = true)]
        public ContentSecurityPolicySetting ContentSecurityPolicySetting { get; set; }

        /// <summary>
        /// Gets or Sets WidgetCustomizations
        /// </summary>
        [DataMember(Name = "widgetCustomizations", EmitDefaultValue = true)]
        public SignInPageAllOfWidgetCustomizations WidgetCustomizations { get; set; }

        /// <summary>
        /// The version specified as a [Semantic Version](https://semver.org/).
        /// </summary>
        /// <value>The version specified as a [Semantic Version](https://semver.org/).</value>
        [DataMember(Name = "widgetVersion", EmitDefaultValue = true)]
        public string WidgetVersion { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SignInPage {\n");
            sb.Append("  PageContent: ").Append(PageContent).Append("\n");
            sb.Append("  ContentSecurityPolicySetting: ").Append(ContentSecurityPolicySetting).Append("\n");
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
            return this.Equals(input as SignInPage);
        }

        /// <summary>
        /// Returns true if SignInPage instances are equal
        /// </summary>
        /// <param name="input">Instance of SignInPage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SignInPage input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.PageContent == input.PageContent ||
                    (this.PageContent != null &&
                    this.PageContent.Equals(input.PageContent))
                ) && 
                (
                    this.ContentSecurityPolicySetting == input.ContentSecurityPolicySetting ||
                    (this.ContentSecurityPolicySetting != null &&
                    this.ContentSecurityPolicySetting.Equals(input.ContentSecurityPolicySetting))
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
                
                if (this.PageContent != null)
                {
                    hashCode = (hashCode * 59) + this.PageContent.GetHashCode();
                }
                if (this.ContentSecurityPolicySetting != null)
                {
                    hashCode = (hashCode * 59) + this.ContentSecurityPolicySetting.GetHashCode();
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
