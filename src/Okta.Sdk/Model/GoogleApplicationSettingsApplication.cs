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
    /// Google app instance properties
    /// </summary>
    [DataContract(Name = "GoogleApplicationSettingsApplication")]
    
    public partial class GoogleApplicationSettingsApplication : IEquatable<GoogleApplicationSettingsApplication>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleApplicationSettingsApplication" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public GoogleApplicationSettingsApplication() { }
        
        /// <summary>
        /// Your Google Apps company domain
        /// </summary>
        /// <value>Your Google Apps company domain</value>
        [DataMember(Name = "domain", EmitDefaultValue = true)]
        public string Domain { get; set; }

        /// <summary>
        /// RPID
        /// </summary>
        /// <value>RPID</value>
        [DataMember(Name = "rpId", EmitDefaultValue = true)]
        public string RpId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GoogleApplicationSettingsApplication {\n");
            sb.Append("  Domain: ").Append(Domain).Append("\n");
            sb.Append("  RpId: ").Append(RpId).Append("\n");
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
            return this.Equals(input as GoogleApplicationSettingsApplication);
        }

        /// <summary>
        /// Returns true if GoogleApplicationSettingsApplication instances are equal
        /// </summary>
        /// <param name="input">Instance of GoogleApplicationSettingsApplication to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GoogleApplicationSettingsApplication input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Domain == input.Domain ||
                    (this.Domain != null &&
                    this.Domain.Equals(input.Domain))
                ) && 
                (
                    this.RpId == input.RpId ||
                    (this.RpId != null &&
                    this.RpId.Equals(input.RpId))
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
                
                if (this.Domain != null)
                {
                    hashCode = (hashCode * 59) + this.Domain.GetHashCode();
                }
                if (this.RpId != null)
                {
                    hashCode = (hashCode * 59) + this.RpId.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
