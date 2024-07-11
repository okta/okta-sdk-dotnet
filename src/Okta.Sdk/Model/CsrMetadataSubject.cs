/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.06.1
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
    /// CsrMetadataSubject
    /// </summary>
    [DataContract(Name = "CsrMetadataSubject")]
    
    public partial class CsrMetadataSubject : IEquatable<CsrMetadataSubject>
    {
        
        /// <summary>
        /// Gets or Sets CommonName
        /// </summary>
        [DataMember(Name = "commonName", EmitDefaultValue = true)]
        public string CommonName { get; set; }

        /// <summary>
        /// Gets or Sets CountryName
        /// </summary>
        [DataMember(Name = "countryName", EmitDefaultValue = true)]
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or Sets LocalityName
        /// </summary>
        [DataMember(Name = "localityName", EmitDefaultValue = true)]
        public string LocalityName { get; set; }

        /// <summary>
        /// Gets or Sets OrganizationalUnitName
        /// </summary>
        [DataMember(Name = "organizationalUnitName", EmitDefaultValue = true)]
        public string OrganizationalUnitName { get; set; }

        /// <summary>
        /// Gets or Sets OrganizationName
        /// </summary>
        [DataMember(Name = "organizationName", EmitDefaultValue = true)]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Gets or Sets StateOrProvinceName
        /// </summary>
        [DataMember(Name = "stateOrProvinceName", EmitDefaultValue = true)]
        public string StateOrProvinceName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CsrMetadataSubject {\n");
            sb.Append("  CommonName: ").Append(CommonName).Append("\n");
            sb.Append("  CountryName: ").Append(CountryName).Append("\n");
            sb.Append("  LocalityName: ").Append(LocalityName).Append("\n");
            sb.Append("  OrganizationalUnitName: ").Append(OrganizationalUnitName).Append("\n");
            sb.Append("  OrganizationName: ").Append(OrganizationName).Append("\n");
            sb.Append("  StateOrProvinceName: ").Append(StateOrProvinceName).Append("\n");
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
            return this.Equals(input as CsrMetadataSubject);
        }

        /// <summary>
        /// Returns true if CsrMetadataSubject instances are equal
        /// </summary>
        /// <param name="input">Instance of CsrMetadataSubject to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CsrMetadataSubject input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.CommonName == input.CommonName ||
                    (this.CommonName != null &&
                    this.CommonName.Equals(input.CommonName))
                ) && 
                (
                    this.CountryName == input.CountryName ||
                    (this.CountryName != null &&
                    this.CountryName.Equals(input.CountryName))
                ) && 
                (
                    this.LocalityName == input.LocalityName ||
                    (this.LocalityName != null &&
                    this.LocalityName.Equals(input.LocalityName))
                ) && 
                (
                    this.OrganizationalUnitName == input.OrganizationalUnitName ||
                    (this.OrganizationalUnitName != null &&
                    this.OrganizationalUnitName.Equals(input.OrganizationalUnitName))
                ) && 
                (
                    this.OrganizationName == input.OrganizationName ||
                    (this.OrganizationName != null &&
                    this.OrganizationName.Equals(input.OrganizationName))
                ) && 
                (
                    this.StateOrProvinceName == input.StateOrProvinceName ||
                    (this.StateOrProvinceName != null &&
                    this.StateOrProvinceName.Equals(input.StateOrProvinceName))
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
                
                if (this.CommonName != null)
                {
                    hashCode = (hashCode * 59) + this.CommonName.GetHashCode();
                }
                if (this.CountryName != null)
                {
                    hashCode = (hashCode * 59) + this.CountryName.GetHashCode();
                }
                if (this.LocalityName != null)
                {
                    hashCode = (hashCode * 59) + this.LocalityName.GetHashCode();
                }
                if (this.OrganizationalUnitName != null)
                {
                    hashCode = (hashCode * 59) + this.OrganizationalUnitName.GetHashCode();
                }
                if (this.OrganizationName != null)
                {
                    hashCode = (hashCode * 59) + this.OrganizationName.GetHashCode();
                }
                if (this.StateOrProvinceName != null)
                {
                    hashCode = (hashCode * 59) + this.StateOrProvinceName.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
