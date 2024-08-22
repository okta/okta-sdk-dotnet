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
    /// PlatformConditionEvaluatorPlatform
    /// </summary>
    [DataContract(Name = "PlatformConditionEvaluatorPlatform")]
    
    public partial class PlatformConditionEvaluatorPlatform : IEquatable<PlatformConditionEvaluatorPlatform>
    {

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = true)]
        
        public PolicyPlatformType Type { get; set; }
        
        /// <summary>
        /// Gets or Sets Os
        /// </summary>
        [DataMember(Name = "os", EmitDefaultValue = true)]
        public PlatformConditionEvaluatorPlatformOperatingSystem Os { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PlatformConditionEvaluatorPlatform {\n");
            sb.Append("  Os: ").Append(Os).Append("\n");
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
            return this.Equals(input as PlatformConditionEvaluatorPlatform);
        }

        /// <summary>
        /// Returns true if PlatformConditionEvaluatorPlatform instances are equal
        /// </summary>
        /// <param name="input">Instance of PlatformConditionEvaluatorPlatform to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PlatformConditionEvaluatorPlatform input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Os == input.Os ||
                    (this.Os != null &&
                    this.Os.Equals(input.Os))
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
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
                
                if (this.Os != null)
                {
                    hashCode = (hashCode * 59) + this.Os.GetHashCode();
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
