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
    /// AuthenticatorKeyPhoneAllOfSettings
    /// </summary>
    [DataContract(Name = "AuthenticatorKeyPhone_allOf_settings")]
    
    public partial class AuthenticatorKeyPhoneAllOfSettings : IEquatable<AuthenticatorKeyPhoneAllOfSettings>
    {

        /// <summary>
        /// Gets or Sets AllowedFor
        /// </summary>
        [DataMember(Name = "allowedFor", EmitDefaultValue = true)]
        
        public AllowedForEnum AllowedFor { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthenticatorKeyPhoneAllOfSettings {\n");
            sb.Append("  AllowedFor: ").Append(AllowedFor).Append("\n");
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
            return this.Equals(input as AuthenticatorKeyPhoneAllOfSettings);
        }

        /// <summary>
        /// Returns true if AuthenticatorKeyPhoneAllOfSettings instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthenticatorKeyPhoneAllOfSettings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthenticatorKeyPhoneAllOfSettings input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AllowedFor == input.AllowedFor ||
                    this.AllowedFor.Equals(input.AllowedFor)
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
                
                if (this.AllowedFor != null)
                {
                    hashCode = (hashCode * 59) + this.AllowedFor.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
