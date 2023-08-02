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
    /// HrefObjectDeleteLink
    /// </summary>
    [DataContract(Name = "HrefObjectDeleteLink")]
    
    public partial class HrefObjectDeleteLink : IEquatable<HrefObjectDeleteLink>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HrefObjectDeleteLink" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public HrefObjectDeleteLink() { }
        
        /// <summary>
        /// Gets or Sets Hints
        /// </summary>
        [DataMember(Name = "hints", EmitDefaultValue = false)]
        public HrefObjectHints Hints { get; set; }

        /// <summary>
        /// Link URI
        /// </summary>
        /// <value>Link URI</value>
        [DataMember(Name = "href", IsRequired = true, EmitDefaultValue = false)]
        public string Href { get; set; }

        /// <summary>
        /// Link name
        /// </summary>
        /// <value>Link name</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// The media type of the link. If omitted, it is implicitly &#x60;application/json&#x60;.
        /// </summary>
        /// <value>The media type of the link. If omitted, it is implicitly &#x60;application/json&#x60;.</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class HrefObjectDeleteLink {\n");
            sb.Append("  Hints: ").Append(Hints).Append("\n");
            sb.Append("  Href: ").Append(Href).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return this.Equals(input as HrefObjectDeleteLink);
        }

        /// <summary>
        /// Returns true if HrefObjectDeleteLink instances are equal
        /// </summary>
        /// <param name="input">Instance of HrefObjectDeleteLink to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HrefObjectDeleteLink input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Hints == input.Hints ||
                    (this.Hints != null &&
                    this.Hints.Equals(input.Hints))
                ) && 
                (
                    this.Href == input.Href ||
                    (this.Href != null &&
                    this.Href.Equals(input.Href))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
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
                
                if (this.Hints != null)
                {
                    hashCode = (hashCode * 59) + this.Hints.GetHashCode();
                }
                if (this.Href != null)
                {
                    hashCode = (hashCode * 59) + this.Href.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
