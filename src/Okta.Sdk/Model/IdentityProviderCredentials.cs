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
    /// IdentityProviderCredentials
    /// </summary>
    [DataContract(Name = "IdentityProviderCredentials")]
    
    public partial class IdentityProviderCredentials : IEquatable<IdentityProviderCredentials>
    {
        
        /// <summary>
        /// Gets or Sets _Client
        /// </summary>
        [DataMember(Name = "client", EmitDefaultValue = false)]
        public IdentityProviderCredentialsClient _Client { get; set; }

        /// <summary>
        /// Gets or Sets Signing
        /// </summary>
        [DataMember(Name = "signing", EmitDefaultValue = false)]
        public IdentityProviderCredentialsSigning Signing { get; set; }

        /// <summary>
        /// Gets or Sets Trust
        /// </summary>
        [DataMember(Name = "trust", EmitDefaultValue = false)]
        public IdentityProviderCredentialsTrust Trust { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class IdentityProviderCredentials {\n");
            sb.Append("  _Client: ").Append(_Client).Append("\n");
            sb.Append("  Signing: ").Append(Signing).Append("\n");
            sb.Append("  Trust: ").Append(Trust).Append("\n");
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
            return this.Equals(input as IdentityProviderCredentials);
        }

        /// <summary>
        /// Returns true if IdentityProviderCredentials instances are equal
        /// </summary>
        /// <param name="input">Instance of IdentityProviderCredentials to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IdentityProviderCredentials input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this._Client == input._Client ||
                    (this._Client != null &&
                    this._Client.Equals(input._Client))
                ) && 
                (
                    this.Signing == input.Signing ||
                    (this.Signing != null &&
                    this.Signing.Equals(input.Signing))
                ) && 
                (
                    this.Trust == input.Trust ||
                    (this.Trust != null &&
                    this.Trust.Equals(input.Trust))
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
                
                if (this._Client != null)
                {
                    hashCode = (hashCode * 59) + this._Client.GetHashCode();
                }
                if (this.Signing != null)
                {
                    hashCode = (hashCode * 59) + this.Signing.GetHashCode();
                }
                if (this.Trust != null)
                {
                    hashCode = (hashCode * 59) + this.Trust.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
