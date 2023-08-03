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
    /// LogDebugContext
    /// </summary>
    [DataContract(Name = "LogDebugContext")]
    
    public partial class LogDebugContext : IEquatable<LogDebugContext>
    {
        
        /// <summary>
        /// Gets or Sets DebugData
        /// </summary>
        [DataMember(Name = "debugData", EmitDefaultValue = true)]
        public Dictionary<string, Object> DebugData { get; private set; }

        /// <summary>
        /// Returns false as DebugData should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDebugData()
        {
            return false;
        }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LogDebugContext {\n");
            sb.Append("  DebugData: ").Append(DebugData).Append("\n");
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
            return this.Equals(input as LogDebugContext);
        }

        /// <summary>
        /// Returns true if LogDebugContext instances are equal
        /// </summary>
        /// <param name="input">Instance of LogDebugContext to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LogDebugContext input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.DebugData == input.DebugData ||
                    this.DebugData != null &&
                    input.DebugData != null &&
                    this.DebugData.SequenceEqual(input.DebugData)
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
                
                if (this.DebugData != null)
                {
                    hashCode = (hashCode * 59) + this.DebugData.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
