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
    /// Links to resources related to this email preview.
    /// </summary>
    [DataContract(Name = "EmailPreview__links")]
    public partial class EmailPreviewLinks : IEquatable<EmailPreviewLinks>
    {
        
        /// <summary>
        /// Gets or Sets Self
        /// </summary>
        [DataMember(Name = "self", EmitDefaultValue = false)]
        public HrefObject Self { get; set; }

        /// <summary>
        /// Gets or Sets ContentSource
        /// </summary>
        [DataMember(Name = "contentSource", EmitDefaultValue = false)]
        public HrefObject ContentSource { get; set; }

        /// <summary>
        /// Gets or Sets Template
        /// </summary>
        [DataMember(Name = "template", EmitDefaultValue = false)]
        public HrefObject Template { get; set; }

        /// <summary>
        /// Gets or Sets Test
        /// </summary>
        [DataMember(Name = "test", EmitDefaultValue = false)]
        public HrefObject Test { get; set; }

        /// <summary>
        /// Gets or Sets DefaultContent
        /// </summary>
        [DataMember(Name = "defaultContent", EmitDefaultValue = false)]
        public HrefObject DefaultContent { get; set; }

        /// <summary>
        /// Gets or Sets additional properties
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EmailPreviewLinks {\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  ContentSource: ").Append(ContentSource).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  Test: ").Append(Test).Append("\n");
            sb.Append("  DefaultContent: ").Append(DefaultContent).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
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
            return this.Equals(input as EmailPreviewLinks);
        }

        /// <summary>
        /// Returns true if EmailPreviewLinks instances are equal
        /// </summary>
        /// <param name="input">Instance of EmailPreviewLinks to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmailPreviewLinks input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Self == input.Self ||
                    (this.Self != null &&
                    this.Self.Equals(input.Self))
                ) && 
                (
                    this.ContentSource == input.ContentSource ||
                    (this.ContentSource != null &&
                    this.ContentSource.Equals(input.ContentSource))
                ) && 
                (
                    this.Template == input.Template ||
                    (this.Template != null &&
                    this.Template.Equals(input.Template))
                ) && 
                (
                    this.Test == input.Test ||
                    (this.Test != null &&
                    this.Test.Equals(input.Test))
                ) && 
                (
                    this.DefaultContent == input.DefaultContent ||
                    (this.DefaultContent != null &&
                    this.DefaultContent.Equals(input.DefaultContent))
                )
                && (this.AdditionalProperties.Count == input.AdditionalProperties.Count && !this.AdditionalProperties.Except(input.AdditionalProperties).Any());
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
                if (this.Self != null)
                {
                    hashCode = (hashCode * 59) + this.Self.GetHashCode();
                }
                if (this.ContentSource != null)
                {
                    hashCode = (hashCode * 59) + this.ContentSource.GetHashCode();
                }
                if (this.Template != null)
                {
                    hashCode = (hashCode * 59) + this.Template.GetHashCode();
                }
                if (this.Test != null)
                {
                    hashCode = (hashCode * 59) + this.Test.GetHashCode();
                }
                if (this.DefaultContent != null)
                {
                    hashCode = (hashCode * 59) + this.DefaultContent.GetHashCode();
                }
                if (this.AdditionalProperties != null)
                {
                    hashCode = (hashCode * 59) + this.AdditionalProperties.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
