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
    /// Domain
    /// </summary>
    [DataContract(Name = "Domain")]
    public partial class Domain : IEquatable<Domain>
    {
        
        /// <summary>
        /// Gets or Sets CertificateSourceType
        /// </summary>
        [DataMember(Name = "certificateSourceType", EmitDefaultValue = false)]
        public string CertificateSourceType { get; set; }

        /// <summary>
        /// Gets or Sets DnsRecords
        /// </summary>
        [DataMember(Name = "dnsRecords", EmitDefaultValue = false)]
        public List<DNSRecord> DnsRecords { get; set; }

        /// <summary>
        /// Gets or Sets _Domain
        /// </summary>
        [DataMember(Name = "domain", EmitDefaultValue = false)]
        public string _Domain { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets PublicCertificate
        /// </summary>
        [DataMember(Name = "publicCertificate", EmitDefaultValue = false)]
        public DomainCertificateMetadata PublicCertificate { get; set; }

        /// <summary>
        /// Gets or Sets ValidationStatus
        /// </summary>
        [DataMember(Name = "validationStatus", EmitDefaultValue = false)]
        public string ValidationStatus { get; set; }

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
            sb.Append("class Domain {\n");
            sb.Append("  CertificateSourceType: ").Append(CertificateSourceType).Append("\n");
            sb.Append("  DnsRecords: ").Append(DnsRecords).Append("\n");
            sb.Append("  _Domain: ").Append(_Domain).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  PublicCertificate: ").Append(PublicCertificate).Append("\n");
            sb.Append("  ValidationStatus: ").Append(ValidationStatus).Append("\n");
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
            return this.Equals(input as Domain);
        }

        /// <summary>
        /// Returns true if Domain instances are equal
        /// </summary>
        /// <param name="input">Instance of Domain to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Domain input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.CertificateSourceType == input.CertificateSourceType ||
                    (this.CertificateSourceType != null &&
                    this.CertificateSourceType.Equals(input.CertificateSourceType))
                ) && 
                (
                    this.DnsRecords == input.DnsRecords ||
                    this.DnsRecords != null &&
                    input.DnsRecords != null &&
                    this.DnsRecords.SequenceEqual(input.DnsRecords)
                ) && 
                (
                    this._Domain == input._Domain ||
                    (this._Domain != null &&
                    this._Domain.Equals(input._Domain))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.PublicCertificate == input.PublicCertificate ||
                    (this.PublicCertificate != null &&
                    this.PublicCertificate.Equals(input.PublicCertificate))
                ) && 
                (
                    this.ValidationStatus == input.ValidationStatus ||
                    (this.ValidationStatus != null &&
                    this.ValidationStatus.Equals(input.ValidationStatus))
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
                if (this.CertificateSourceType != null)
                {
                    hashCode = (hashCode * 59) + this.CertificateSourceType.GetHashCode();
                }
                if (this.DnsRecords != null)
                {
                    hashCode = (hashCode * 59) + this.DnsRecords.GetHashCode();
                }
                if (this._Domain != null)
                {
                    hashCode = (hashCode * 59) + this._Domain.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.PublicCertificate != null)
                {
                    hashCode = (hashCode * 59) + this.PublicCertificate.GetHashCode();
                }
                if (this.ValidationStatus != null)
                {
                    hashCode = (hashCode * 59) + this.ValidationStatus.GetHashCode();
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
