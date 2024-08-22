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
    /// RiskEventSubject
    /// </summary>
    [DataContract(Name = "RiskEventSubject")]
    
    public partial class RiskEventSubject : IEquatable<RiskEventSubject>
    {

        /// <summary>
        /// Gets or Sets RiskLevel
        /// </summary>
        [DataMember(Name = "riskLevel", EmitDefaultValue = true)]
        
        public RiskEventSubjectRiskLevel RiskLevel { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="RiskEventSubject" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public RiskEventSubject() { }
        
        /// <summary>
        /// The risk event subject IP address (either an IPv4 or IPv6 address)
        /// </summary>
        /// <value>The risk event subject IP address (either an IPv4 or IPv6 address)</value>
        [DataMember(Name = "ip", EmitDefaultValue = true)]
        public string Ip { get; set; }

        /// <summary>
        /// Additional reasons for the risk level of the IP
        /// </summary>
        /// <value>Additional reasons for the risk level of the IP</value>
        [DataMember(Name = "message", EmitDefaultValue = true)]
        public string Message { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RiskEventSubject {\n");
            sb.Append("  Ip: ").Append(Ip).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  RiskLevel: ").Append(RiskLevel).Append("\n");
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
            return this.Equals(input as RiskEventSubject);
        }

        /// <summary>
        /// Returns true if RiskEventSubject instances are equal
        /// </summary>
        /// <param name="input">Instance of RiskEventSubject to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RiskEventSubject input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Ip == input.Ip ||
                    (this.Ip != null &&
                    this.Ip.Equals(input.Ip))
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.RiskLevel == input.RiskLevel ||
                    this.RiskLevel.Equals(input.RiskLevel)
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
                
                if (this.Ip != null)
                {
                    hashCode = (hashCode * 59) + this.Ip.GetHashCode();
                }
                if (this.Message != null)
                {
                    hashCode = (hashCode * 59) + this.Message.GetHashCode();
                }
                if (this.RiskLevel != null)
                {
                    hashCode = (hashCode * 59) + this.RiskLevel.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
