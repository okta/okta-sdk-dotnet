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
    /// TokenUserFactorProfile
    /// </summary>
    [DataContract(Name = "TokenUserFactorProfile")]
    
    public partial class TokenUserFactorProfile : IEquatable<TokenUserFactorProfile>
    {
        
        /// <summary>
        /// Gets or Sets CredentialId
        /// </summary>
        [DataMember(Name = "credentialId", EmitDefaultValue = false)]
        public string CredentialId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TokenUserFactorProfile {\n");
            sb.Append("  CredentialId: ").Append(CredentialId).Append("\n");
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
            return this.Equals(input as TokenUserFactorProfile);
        }

        /// <summary>
        /// Returns true if TokenUserFactorProfile instances are equal
        /// </summary>
        /// <param name="input">Instance of TokenUserFactorProfile to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TokenUserFactorProfile input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.CredentialId == input.CredentialId ||
                    (this.CredentialId != null &&
                    this.CredentialId.Equals(input.CredentialId))
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
                
                if (this.CredentialId != null)
                {
                    hashCode = (hashCode * 59) + this.CredentialId.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
