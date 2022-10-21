/*
 * Okta Management
 *
 * Allows customers to easily access the Okta Management APIs
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
    /// UserSchemaPropertiesProfile
    /// </summary>
    [DataContract(Name = "UserSchemaPropertiesProfile")]
    
    public partial class UserSchemaPropertiesProfile : IEquatable<UserSchemaPropertiesProfile>
    {
        
        /// <summary>
        /// Gets or Sets AllOf
        /// </summary>
        [DataMember(Name = "allOf", EmitDefaultValue = false)]
        public List<UserSchemaPropertiesProfileItem> AllOf { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserSchemaPropertiesProfile {\n");
            sb.Append("  AllOf: ").Append(AllOf).Append("\n");
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
            return this.Equals(input as UserSchemaPropertiesProfile);
        }

        /// <summary>
        /// Returns true if UserSchemaPropertiesProfile instances are equal
        /// </summary>
        /// <param name="input">Instance of UserSchemaPropertiesProfile to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserSchemaPropertiesProfile input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AllOf == input.AllOf ||
                    this.AllOf != null &&
                    input.AllOf != null &&
                    this.AllOf.SequenceEqual(input.AllOf)
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
                
                if (this.AllOf != null)
                {
                    hashCode = (hashCode * 59) + this.AllOf.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
