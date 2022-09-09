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
    /// KnowledgeConstraint
    /// </summary>
    [DataContract(Name = "KnowledgeConstraint")]
    
    public partial class KnowledgeConstraint : IEquatable<KnowledgeConstraint>
    {
        
        /// <summary>
        /// Gets or Sets Methods
        /// </summary>
        [DataMember(Name = "methods", EmitDefaultValue = false)]
        public List<string> Methods { get; set; }

        /// <summary>
        /// Gets or Sets ReauthenticateIn
        /// </summary>
        [DataMember(Name = "reauthenticateIn", EmitDefaultValue = false)]
        public string ReauthenticateIn { get; set; }

        /// <summary>
        /// Gets or Sets Types
        /// </summary>
        [DataMember(Name = "types", EmitDefaultValue = false)]
        public List<string> Types { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class KnowledgeConstraint {\n");
            sb.Append("  Methods: ").Append(Methods).Append("\n");
            sb.Append("  ReauthenticateIn: ").Append(ReauthenticateIn).Append("\n");
            sb.Append("  Types: ").Append(Types).Append("\n");
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
            return this.Equals(input as KnowledgeConstraint);
        }

        /// <summary>
        /// Returns true if KnowledgeConstraint instances are equal
        /// </summary>
        /// <param name="input">Instance of KnowledgeConstraint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(KnowledgeConstraint input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Methods == input.Methods ||
                    this.Methods != null &&
                    input.Methods != null &&
                    this.Methods.SequenceEqual(input.Methods)
                ) && 
                (
                    this.ReauthenticateIn == input.ReauthenticateIn ||
                    (this.ReauthenticateIn != null &&
                    this.ReauthenticateIn.Equals(input.ReauthenticateIn))
                ) && 
                (
                    this.Types == input.Types ||
                    this.Types != null &&
                    input.Types != null &&
                    this.Types.SequenceEqual(input.Types)
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
                
                if (this.Methods != null)
                {
                    hashCode = (hashCode * 59) + this.Methods.GetHashCode();
                }
                if (this.ReauthenticateIn != null)
                {
                    hashCode = (hashCode * 59) + this.ReauthenticateIn.GetHashCode();
                }
                if (this.Types != null)
                {
                    hashCode = (hashCode * 59) + this.Types.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
