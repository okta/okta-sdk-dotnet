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
    /// LogSecurityContext
    /// </summary>
    [DataContract(Name = "LogSecurityContext")]
    public partial class LogSecurityContext : IEquatable<LogSecurityContext>
    {
        
        /// <summary>
        /// Gets or Sets AsNumber
        /// </summary>
        [DataMember(Name = "asNumber", EmitDefaultValue = false)]
        public int AsNumber { get; private set; }

        /// <summary>
        /// Returns false as AsNumber should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeAsNumber()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets AsOrg
        /// </summary>
        [DataMember(Name = "asOrg", EmitDefaultValue = false)]
        public string AsOrg { get; private set; }

        /// <summary>
        /// Returns false as AsOrg should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeAsOrg()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Domain
        /// </summary>
        [DataMember(Name = "domain", EmitDefaultValue = false)]
        public string Domain { get; private set; }

        /// <summary>
        /// Returns false as Domain should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDomain()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Isp
        /// </summary>
        [DataMember(Name = "isp", EmitDefaultValue = false)]
        public string Isp { get; private set; }

        /// <summary>
        /// Returns false as Isp should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeIsp()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets IsProxy
        /// </summary>
        [DataMember(Name = "isProxy", EmitDefaultValue = true)]
        public bool IsProxy { get; private set; }

        /// <summary>
        /// Returns false as IsProxy should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeIsProxy()
        {
            return false;
        }
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
            sb.Append("class LogSecurityContext {\n");
            sb.Append("  AsNumber: ").Append(AsNumber).Append("\n");
            sb.Append("  AsOrg: ").Append(AsOrg).Append("\n");
            sb.Append("  Domain: ").Append(Domain).Append("\n");
            sb.Append("  Isp: ").Append(Isp).Append("\n");
            sb.Append("  IsProxy: ").Append(IsProxy).Append("\n");
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
            return this.Equals(input as LogSecurityContext);
        }

        /// <summary>
        /// Returns true if LogSecurityContext instances are equal
        /// </summary>
        /// <param name="input">Instance of LogSecurityContext to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LogSecurityContext input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AsNumber == input.AsNumber ||
                    this.AsNumber.Equals(input.AsNumber)
                ) && 
                (
                    this.AsOrg == input.AsOrg ||
                    (this.AsOrg != null &&
                    this.AsOrg.Equals(input.AsOrg))
                ) && 
                (
                    this.Domain == input.Domain ||
                    (this.Domain != null &&
                    this.Domain.Equals(input.Domain))
                ) && 
                (
                    this.Isp == input.Isp ||
                    (this.Isp != null &&
                    this.Isp.Equals(input.Isp))
                ) && 
                (
                    this.IsProxy == input.IsProxy ||
                    this.IsProxy.Equals(input.IsProxy)
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
                hashCode = (hashCode * 59) + this.AsNumber.GetHashCode();
                if (this.AsOrg != null)
                {
                    hashCode = (hashCode * 59) + this.AsOrg.GetHashCode();
                }
                if (this.Domain != null)
                {
                    hashCode = (hashCode * 59) + this.Domain.GetHashCode();
                }
                if (this.Isp != null)
                {
                    hashCode = (hashCode * 59) + this.Isp.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IsProxy.GetHashCode();
                if (this.AdditionalProperties != null)
                {
                    hashCode = (hashCode * 59) + this.AdditionalProperties.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
