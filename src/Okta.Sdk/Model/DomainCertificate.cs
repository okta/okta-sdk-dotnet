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
    /// Defines the properties of the certificate
    /// </summary>
    [DataContract(Name = "DomainCertificate")]
    
    public partial class DomainCertificate : IEquatable<DomainCertificate>
    {

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        
        public DomainCertificateType Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainCertificate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public DomainCertificate() { }
        
        /// <summary>
        /// Certificate content
        /// </summary>
        /// <value>Certificate content</value>
        [DataMember(Name = "certificate", IsRequired = true, EmitDefaultValue = false)]
        public string Certificate { get; set; }

        /// <summary>
        /// Certificate chain
        /// </summary>
        /// <value>Certificate chain</value>
        [DataMember(Name = "certificateChain", IsRequired = true, EmitDefaultValue = false)]
        public string CertificateChain { get; set; }

        /// <summary>
        /// Certificate private key
        /// </summary>
        /// <value>Certificate private key</value>
        [DataMember(Name = "privateKey", IsRequired = true, EmitDefaultValue = false)]
        public string PrivateKey { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DomainCertificate {\n");
            sb.Append("  Certificate: ").Append(Certificate).Append("\n");
            sb.Append("  CertificateChain: ").Append(CertificateChain).Append("\n");
            sb.Append("  PrivateKey: ").Append(PrivateKey).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return this.Equals(input as DomainCertificate);
        }

        /// <summary>
        /// Returns true if DomainCertificate instances are equal
        /// </summary>
        /// <param name="input">Instance of DomainCertificate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DomainCertificate input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Certificate == input.Certificate ||
                    (this.Certificate != null &&
                    this.Certificate.Equals(input.Certificate))
                ) && 
                (
                    this.CertificateChain == input.CertificateChain ||
                    (this.CertificateChain != null &&
                    this.CertificateChain.Equals(input.CertificateChain))
                ) && 
                (
                    this.PrivateKey == input.PrivateKey ||
                    (this.PrivateKey != null &&
                    this.PrivateKey.Equals(input.PrivateKey))
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
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
                
                if (this.Certificate != null)
                {
                    hashCode = (hashCode * 59) + this.Certificate.GetHashCode();
                }
                if (this.CertificateChain != null)
                {
                    hashCode = (hashCode * 59) + this.CertificateChain.GetHashCode();
                }
                if (this.PrivateKey != null)
                {
                    hashCode = (hashCode * 59) + this.PrivateKey.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                return hashCode;
            }
        }

    }

}
