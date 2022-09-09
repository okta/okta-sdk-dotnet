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
    /// GroupSchemaDefinitions
    /// </summary>
    [DataContract(Name = "GroupSchemaDefinitions")]
    
    public partial class GroupSchemaDefinitions : IEquatable<GroupSchemaDefinitions>
    {
        
        /// <summary>
        /// Gets or Sets Base
        /// </summary>
        [DataMember(Name = "base", EmitDefaultValue = false)]
        public GroupSchemaBase Base { get; set; }

        /// <summary>
        /// Gets or Sets Custom
        /// </summary>
        [DataMember(Name = "custom", EmitDefaultValue = false)]
        public GroupSchemaCustom Custom { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GroupSchemaDefinitions {\n");
            sb.Append("  Base: ").Append(Base).Append("\n");
            sb.Append("  Custom: ").Append(Custom).Append("\n");
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
            return this.Equals(input as GroupSchemaDefinitions);
        }

        /// <summary>
        /// Returns true if GroupSchemaDefinitions instances are equal
        /// </summary>
        /// <param name="input">Instance of GroupSchemaDefinitions to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GroupSchemaDefinitions input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Base == input.Base ||
                    (this.Base != null &&
                    this.Base.Equals(input.Base))
                ) && 
                (
                    this.Custom == input.Custom ||
                    (this.Custom != null &&
                    this.Custom.Equals(input.Custom))
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
                
                if (this.Base != null)
                {
                    hashCode = (hashCode * 59) + this.Base.GetHashCode();
                }
                if (this.Custom != null)
                {
                    hashCode = (hashCode * 59) + this.Custom.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
