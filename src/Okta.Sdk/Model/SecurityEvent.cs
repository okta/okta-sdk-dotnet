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
    /// SecurityEvent
    /// </summary>
    [DataContract(Name = "SecurityEvent")]
    
    public partial class SecurityEvent : IEquatable<SecurityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityEvent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public SecurityEvent() { }
        
        /// <summary>
        /// The time of the event (UNIX timestamp)
        /// </summary>
        /// <value>The time of the event (UNIX timestamp)</value>
        [DataMember(Name = "event_timestamp", EmitDefaultValue = true)]
        public long EventTimestamp { get; set; }

        /// <summary>
        /// Gets or Sets Subjects
        /// </summary>
        [DataMember(Name = "subjects", EmitDefaultValue = true)]
        public SecurityEventSubject Subjects { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SecurityEvent {\n");
            sb.Append("  EventTimestamp: ").Append(EventTimestamp).Append("\n");
            sb.Append("  Subjects: ").Append(Subjects).Append("\n");
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
            return this.Equals(input as SecurityEvent);
        }

        /// <summary>
        /// Returns true if SecurityEvent instances are equal
        /// </summary>
        /// <param name="input">Instance of SecurityEvent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SecurityEvent input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.EventTimestamp == input.EventTimestamp ||
                    this.EventTimestamp.Equals(input.EventTimestamp)
                ) && 
                (
                    this.Subjects == input.Subjects ||
                    (this.Subjects != null &&
                    this.Subjects.Equals(input.Subjects))
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
                
                hashCode = (hashCode * 59) + this.EventTimestamp.GetHashCode();
                if (this.Subjects != null)
                {
                    hashCode = (hashCode * 59) + this.Subjects.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}