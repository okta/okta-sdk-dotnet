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
    /// ResourceSetBindingAddMembersRequest
    /// </summary>
    [DataContract(Name = "ResourceSetBindingAddMembersRequest")]
    
    public partial class ResourceSetBindingAddMembersRequest : IEquatable<ResourceSetBindingAddMembersRequest>
    {
        
        /// <summary>
        /// Gets or Sets Additions
        /// </summary>
        [DataMember(Name = "additions", EmitDefaultValue = false)]
        public List<string> Additions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ResourceSetBindingAddMembersRequest {\n");
            sb.Append("  Additions: ").Append(Additions).Append("\n");
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
            return this.Equals(input as ResourceSetBindingAddMembersRequest);
        }

        /// <summary>
        /// Returns true if ResourceSetBindingAddMembersRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of ResourceSetBindingAddMembersRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ResourceSetBindingAddMembersRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Additions == input.Additions ||
                    this.Additions != null &&
                    input.Additions != null &&
                    this.Additions.SequenceEqual(input.Additions)
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
                
                if (this.Additions != null)
                {
                    hashCode = (hashCode * 59) + this.Additions.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
