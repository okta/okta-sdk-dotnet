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
    /// UserActivationToken
    /// </summary>
    [DataContract(Name = "UserActivationToken")]
    
    public partial class UserActivationToken : IEquatable<UserActivationToken>
    {
        
        /// <summary>
        /// Gets or Sets ActivationToken
        /// </summary>
        [DataMember(Name = "activationToken", EmitDefaultValue = false)]
        public string ActivationToken { get; private set; }

        /// <summary>
        /// Returns false as ActivationToken should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeActivationToken()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets ActivationUrl
        /// </summary>
        [DataMember(Name = "activationUrl", EmitDefaultValue = false)]
        public string ActivationUrl { get; private set; }

        /// <summary>
        /// Returns false as ActivationUrl should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeActivationUrl()
        {
            return false;
        }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserActivationToken {\n");
            sb.Append("  ActivationToken: ").Append(ActivationToken).Append("\n");
            sb.Append("  ActivationUrl: ").Append(ActivationUrl).Append("\n");
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
            return this.Equals(input as UserActivationToken);
        }

        /// <summary>
        /// Returns true if UserActivationToken instances are equal
        /// </summary>
        /// <param name="input">Instance of UserActivationToken to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserActivationToken input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ActivationToken == input.ActivationToken ||
                    (this.ActivationToken != null &&
                    this.ActivationToken.Equals(input.ActivationToken))
                ) && 
                (
                    this.ActivationUrl == input.ActivationUrl ||
                    (this.ActivationUrl != null &&
                    this.ActivationUrl.Equals(input.ActivationUrl))
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
                
                if (this.ActivationToken != null)
                {
                    hashCode = (hashCode * 59) + this.ActivationToken.GetHashCode();
                }
                if (this.ActivationUrl != null)
                {
                    hashCode = (hashCode * 59) + this.ActivationUrl.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
