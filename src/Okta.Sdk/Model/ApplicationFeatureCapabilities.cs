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
    /// ApplicationFeatureCapabilities
    /// </summary>
    [DataContract(Name = "ApplicationFeature_capabilities")]
    
    public partial class ApplicationFeatureCapabilities : IEquatable<ApplicationFeatureCapabilities>
    {
        
        /// <summary>
        /// Gets or Sets Create
        /// </summary>
        [DataMember(Name = "create", EmitDefaultValue = false)]
        public CapabilitiesCreateObject Create { get; set; }

        /// <summary>
        /// Gets or Sets Update
        /// </summary>
        [DataMember(Name = "update", EmitDefaultValue = false)]
        public CapabilitiesUpdateObject Update { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ApplicationFeatureCapabilities {\n");
            sb.Append("  Create: ").Append(Create).Append("\n");
            sb.Append("  Update: ").Append(Update).Append("\n");
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
            return this.Equals(input as ApplicationFeatureCapabilities);
        }

        /// <summary>
        /// Returns true if ApplicationFeatureCapabilities instances are equal
        /// </summary>
        /// <param name="input">Instance of ApplicationFeatureCapabilities to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApplicationFeatureCapabilities input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Create == input.Create ||
                    (this.Create != null &&
                    this.Create.Equals(input.Create))
                ) && 
                (
                    this.Update == input.Update ||
                    (this.Update != null &&
                    this.Update.Equals(input.Update))
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
                
                if (this.Create != null)
                {
                    hashCode = (hashCode * 59) + this.Create.GetHashCode();
                }
                if (this.Update != null)
                {
                    hashCode = (hashCode * 59) + this.Update.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
