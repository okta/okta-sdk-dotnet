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
    /// DNSRecord
    /// </summary>
    [DataContract(Name = "DNSRecord")]
    public partial class DNSRecord : IEquatable<DNSRecord>
    {
        
        /// <summary>
        /// Gets or Sets Expiration
        /// </summary>
        [DataMember(Name = "expiration", EmitDefaultValue = false)]
        public string Expiration { get; set; }

        /// <summary>
        /// Gets or Sets Fqdn
        /// </summary>
        [DataMember(Name = "fqdn", EmitDefaultValue = false)]
        public string Fqdn { get; set; }

        /// <summary>
        /// Gets or Sets RecordType
        /// </summary>
        [DataMember(Name = "recordType", EmitDefaultValue = false)]
        public string RecordType { get; set; }

        /// <summary>
        /// Gets or Sets Values
        /// </summary>
        [DataMember(Name = "values", EmitDefaultValue = false)]
        public List<string> Values { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DNSRecord {\n");
            sb.Append("  Expiration: ").Append(Expiration).Append("\n");
            sb.Append("  Fqdn: ").Append(Fqdn).Append("\n");
            sb.Append("  RecordType: ").Append(RecordType).Append("\n");
            sb.Append("  Values: ").Append(Values).Append("\n");
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
            return this.Equals(input as DNSRecord);
        }

        /// <summary>
        /// Returns true if DNSRecord instances are equal
        /// </summary>
        /// <param name="input">Instance of DNSRecord to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DNSRecord input)
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
                    this.Fqdn == input.Fqdn ||
                    (this.Fqdn != null &&
                    this.Fqdn.Equals(input.Fqdn))
                ) && 
                (
                    this.RecordType == input.RecordType ||
                    (this.RecordType != null &&
                    this.RecordType.Equals(input.RecordType))
                ) && 
                (
                    this.Values == input.Values ||
                    this.Values != null &&
                    input.Values != null &&
                    this.Values.SequenceEqual(input.Values)
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
                if (this.Fqdn != null)
                {
                    hashCode = (hashCode * 59) + this.Fqdn.GetHashCode();
                }
                if (this.RecordType != null)
                {
                    hashCode = (hashCode * 59) + this.RecordType.GetHashCode();
                }
                if (this.Values != null)
                {
                    hashCode = (hashCode * 59) + this.Values.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
