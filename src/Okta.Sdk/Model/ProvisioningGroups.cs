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
    /// ProvisioningGroups
    /// </summary>
    [DataContract(Name = "ProvisioningGroups")]
    public partial class ProvisioningGroups : IEquatable<ProvisioningGroups>
    {
        
        /// <summary>
        /// Gets or Sets Action
        /// </summary>
        [DataMember(Name = "action", EmitDefaultValue = false)]
        public string Action { get; set; }

        /// <summary>
        /// Gets or Sets Assignments
        /// </summary>
        [DataMember(Name = "assignments", EmitDefaultValue = false)]
        public List<string> Assignments { get; set; }

        /// <summary>
        /// Gets or Sets Filter
        /// </summary>
        [DataMember(Name = "filter", EmitDefaultValue = false)]
        public List<string> Filter { get; set; }

        /// <summary>
        /// Gets or Sets SourceAttributeName
        /// </summary>
        [DataMember(Name = "sourceAttributeName", EmitDefaultValue = false)]
        public string SourceAttributeName { get; set; }

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
            sb.Append("class ProvisioningGroups {\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("  Assignments: ").Append(Assignments).Append("\n");
            sb.Append("  Filter: ").Append(Filter).Append("\n");
            sb.Append("  SourceAttributeName: ").Append(SourceAttributeName).Append("\n");
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
            return this.Equals(input as ProvisioningGroups);
        }

        /// <summary>
        /// Returns true if ProvisioningGroups instances are equal
        /// </summary>
        /// <param name="input">Instance of ProvisioningGroups to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProvisioningGroups input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Action == input.Action ||
                    (this.Action != null &&
                    this.Action.Equals(input.Action))
                ) && 
                (
                    this.Assignments == input.Assignments ||
                    this.Assignments != null &&
                    input.Assignments != null &&
                    this.Assignments.SequenceEqual(input.Assignments)
                ) && 
                (
                    this.Filter == input.Filter ||
                    this.Filter != null &&
                    input.Filter != null &&
                    this.Filter.SequenceEqual(input.Filter)
                ) && 
                (
                    this.SourceAttributeName == input.SourceAttributeName ||
                    (this.SourceAttributeName != null &&
                    this.SourceAttributeName.Equals(input.SourceAttributeName))
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
                if (this.Action != null)
                {
                    hashCode = (hashCode * 59) + this.Action.GetHashCode();
                }
                if (this.Assignments != null)
                {
                    hashCode = (hashCode * 59) + this.Assignments.GetHashCode();
                }
                if (this.Filter != null)
                {
                    hashCode = (hashCode * 59) + this.Filter.GetHashCode();
                }
                if (this.SourceAttributeName != null)
                {
                    hashCode = (hashCode * 59) + this.SourceAttributeName.GetHashCode();
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
