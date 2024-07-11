/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.06.1
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
    /// CsrMetadata
    /// </summary>
    [DataContract(Name = "CsrMetadata")]
    
    public partial class CsrMetadata : IEquatable<CsrMetadata>
    {
        
        /// <summary>
        /// Gets or Sets Subject
        /// </summary>
        [DataMember(Name = "subject", EmitDefaultValue = true)]
        public CsrMetadataSubject Subject { get; set; }

        /// <summary>
        /// Gets or Sets SubjectAltNames
        /// </summary>
        [DataMember(Name = "subjectAltNames", EmitDefaultValue = true)]
        public CsrMetadataSubjectAltNames SubjectAltNames { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CsrMetadata {\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  SubjectAltNames: ").Append(SubjectAltNames).Append("\n");
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
            return this.Equals(input as CsrMetadata);
        }

        /// <summary>
        /// Returns true if CsrMetadata instances are equal
        /// </summary>
        /// <param name="input">Instance of CsrMetadata to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CsrMetadata input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Subject == input.Subject ||
                    (this.Subject != null &&
                    this.Subject.Equals(input.Subject))
                ) && 
                (
                    this.SubjectAltNames == input.SubjectAltNames ||
                    (this.SubjectAltNames != null &&
                    this.SubjectAltNames.Equals(input.SubjectAltNames))
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
                
                if (this.Subject != null)
                {
                    hashCode = (hashCode * 59) + this.Subject.GetHashCode();
                }
                if (this.SubjectAltNames != null)
                {
                    hashCode = (hashCode * 59) + this.SubjectAltNames.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
