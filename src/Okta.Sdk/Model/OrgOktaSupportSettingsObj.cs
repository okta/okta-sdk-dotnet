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
    /// OrgOktaSupportSettingsObj
    /// </summary>
    [DataContract(Name = "OrgOktaSupportSettingsObj")]
    
    public partial class OrgOktaSupportSettingsObj : IEquatable<OrgOktaSupportSettingsObj>
    {

        /// <summary>
        /// Gets or Sets Support
        /// </summary>
        [DataMember(Name = "support", EmitDefaultValue = false)]
        
        public OrgOktaSupportSetting Support { get; set; }
        
        /// <summary>
        /// Gets or Sets Expiration
        /// </summary>
        [DataMember(Name = "expiration", EmitDefaultValue = false)]
        public DateTimeOffset Expiration { get; private set; }

        /// <summary>
        /// Returns false as Expiration should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeExpiration()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public LinksSelf Links { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OrgOktaSupportSettingsObj {\n");
            sb.Append("  Expiration: ").Append(Expiration).Append("\n");
            sb.Append("  Support: ").Append(Support).Append("\n");
            sb.Append("  Links: ").Append(Links).Append("\n");
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
            return this.Equals(input as OrgOktaSupportSettingsObj);
        }

        /// <summary>
        /// Returns true if OrgOktaSupportSettingsObj instances are equal
        /// </summary>
        /// <param name="input">Instance of OrgOktaSupportSettingsObj to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrgOktaSupportSettingsObj input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Expiration == input.Expiration ||
                    (this.Expiration != null &&
                    this.Expiration.Equals(input.Expiration))
                ) && 
                (
                    this.Support == input.Support ||
                    this.Support.Equals(input.Support)
                ) && 
                (
                    this.Links == input.Links ||
                    (this.Links != null &&
                    this.Links.Equals(input.Links))
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
                
                if (this.Expiration != null)
                {
                    hashCode = (hashCode * 59) + this.Expiration.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Support.GetHashCode();
                if (this.Links != null)
                {
                    hashCode = (hashCode * 59) + this.Links.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
