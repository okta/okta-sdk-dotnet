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
    /// ResourceSetBindingMembersLinks
    /// </summary>
    [DataContract(Name = "ResourceSetBindingMembers__links")]
    
    public partial class ResourceSetBindingMembersLinks : IEquatable<ResourceSetBindingMembersLinks>
    {
        
        /// <summary>
        /// Gets or Sets Next
        /// </summary>
        [DataMember(Name = "next", EmitDefaultValue = true)]
        public HrefObject Next { get; set; }

        /// <summary>
        /// Gets or Sets Binding
        /// </summary>
        [DataMember(Name = "binding", EmitDefaultValue = true)]
        public HrefObject Binding { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ResourceSetBindingMembersLinks {\n");
            sb.Append("  Next: ").Append(Next).Append("\n");
            sb.Append("  Binding: ").Append(Binding).Append("\n");
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
            return this.Equals(input as ResourceSetBindingMembersLinks);
        }

        /// <summary>
        /// Returns true if ResourceSetBindingMembersLinks instances are equal
        /// </summary>
        /// <param name="input">Instance of ResourceSetBindingMembersLinks to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ResourceSetBindingMembersLinks input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Next == input.Next ||
                    (this.Next != null &&
                    this.Next.Equals(input.Next))
                ) && 
                (
                    this.Binding == input.Binding ||
                    (this.Binding != null &&
                    this.Binding.Equals(input.Binding))
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
                
                if (this.Next != null)
                {
                    hashCode = (hashCode * 59) + this.Next.GetHashCode();
                }
                if (this.Binding != null)
                {
                    hashCode = (hashCode * 59) + this.Binding.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
