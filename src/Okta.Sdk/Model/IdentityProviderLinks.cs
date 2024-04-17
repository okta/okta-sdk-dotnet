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
    /// IdentityProviderLinks
    /// </summary>
    [DataContract(Name = "IdentityProvider__links")]
    public partial class IdentityProviderLinks : IEquatable<IdentityProviderLinks>
    
    {
        
        /// <summary>
        /// Gets or Sets Self
        /// </summary>
        [DataMember(Name = "self", EmitDefaultValue = true)]
        public HrefObjectSelfLink Self { get; set; }

        /// <summary>
        /// Gets or Sets Acs
        /// </summary>
        [DataMember(Name = "acs", EmitDefaultValue = true)]
        public IdentityProviderLinksAllOfAcs Acs { get; set; }

        /// <summary>
        /// Gets or Sets Authorize
        /// </summary>
        [DataMember(Name = "authorize", EmitDefaultValue = true)]
        public IdentityProviderLinksAllOfAuthorize Authorize { get; set; }

        /// <summary>
        /// Gets or Sets ClientRedirectUri
        /// </summary>
        [DataMember(Name = "clientRedirectUri", EmitDefaultValue = true)]
        public IdentityProviderLinksAllOfClientRedirectUri ClientRedirectUri { get; set; }

        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name = "metadata", EmitDefaultValue = true)]
        public IdentityProviderLinksAllOfMetadata Metadata { get; set; }

        /// <summary>
        /// Gets or Sets Users
        /// </summary>
        [DataMember(Name = "users", EmitDefaultValue = true)]
        public IdentityProviderLinksAllOfUsers Users { get; set; }

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
            sb.Append("class IdentityProviderLinks {\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  Acs: ").Append(Acs).Append("\n");
            sb.Append("  Authorize: ").Append(Authorize).Append("\n");
            sb.Append("  ClientRedirectUri: ").Append(ClientRedirectUri).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Users: ").Append(Users).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
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
            return this.Equals(input as IdentityProviderLinks);
        }

        /// <summary>
        /// Returns true if IdentityProviderLinks instances are equal
        /// </summary>
        /// <param name="input">Instance of IdentityProviderLinks to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IdentityProviderLinks input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Self == input.Self ||
                    (this.Self != null &&
                    this.Self.Equals(input.Self))
                ) && 
                (
                    this.Acs == input.Acs ||
                    (this.Acs != null &&
                    this.Acs.Equals(input.Acs))
                ) && 
                (
                    this.Authorize == input.Authorize ||
                    (this.Authorize != null &&
                    this.Authorize.Equals(input.Authorize))
                ) && 
                (
                    this.ClientRedirectUri == input.ClientRedirectUri ||
                    (this.ClientRedirectUri != null &&
                    this.ClientRedirectUri.Equals(input.ClientRedirectUri))
                ) && 
                (
                    this.Metadata == input.Metadata ||
                    (this.Metadata != null &&
                    this.Metadata.Equals(input.Metadata))
                ) && 
                (
                    this.Users == input.Users ||
                    (this.Users != null &&
                    this.Users.Equals(input.Users))
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
                
                if (this.Self != null)
                {
                    hashCode = (hashCode * 59) + this.Self.GetHashCode();
                }
                if (this.Acs != null)
                {
                    hashCode = (hashCode * 59) + this.Acs.GetHashCode();
                }
                if (this.Authorize != null)
                {
                    hashCode = (hashCode * 59) + this.Authorize.GetHashCode();
                }
                if (this.ClientRedirectUri != null)
                {
                    hashCode = (hashCode * 59) + this.ClientRedirectUri.GetHashCode();
                }
                if (this.Metadata != null)
                {
                    hashCode = (hashCode * 59) + this.Metadata.GetHashCode();
                }
                if (this.Users != null)
                {
                    hashCode = (hashCode * 59) + this.Users.GetHashCode();
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
