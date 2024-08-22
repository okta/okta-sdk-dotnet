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
    /// SchemeApplicationCredentials
    /// </summary>
    [DataContract(Name = "SchemeApplicationCredentials")]
    
    public partial class SchemeApplicationCredentials : IEquatable<SchemeApplicationCredentials>
    {

        /// <summary>
        /// Gets or Sets Scheme
        /// </summary>
        [DataMember(Name = "scheme", EmitDefaultValue = true)]
        
        public ApplicationCredentialsScheme Scheme { get; set; }
        
        /// <summary>
        /// Gets or Sets Signing
        /// </summary>
        [DataMember(Name = "signing", EmitDefaultValue = true)]
        public ApplicationCredentialsSigning Signing { get; set; }

        /// <summary>
        /// Gets or Sets UserNameTemplate
        /// </summary>
        [DataMember(Name = "userNameTemplate", EmitDefaultValue = true)]
        public ApplicationCredentialsUsernameTemplate UserNameTemplate { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name = "password", EmitDefaultValue = true)]
        public PasswordCredential Password { get; set; }

        /// <summary>
        /// Allow users to securely see their password
        /// </summary>
        /// <value>Allow users to securely see their password</value>
        [DataMember(Name = "revealPassword", EmitDefaultValue = true)]
        public bool RevealPassword { get; set; }

        /// <summary>
        /// Gets or Sets UserName
        /// </summary>
        [DataMember(Name = "userName", EmitDefaultValue = true)]
        public string UserName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SchemeApplicationCredentials {\n");
            sb.Append("  Signing: ").Append(Signing).Append("\n");
            sb.Append("  UserNameTemplate: ").Append(UserNameTemplate).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  RevealPassword: ").Append(RevealPassword).Append("\n");
            sb.Append("  Scheme: ").Append(Scheme).Append("\n");
            sb.Append("  UserName: ").Append(UserName).Append("\n");
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
            return this.Equals(input as SchemeApplicationCredentials);
        }

        /// <summary>
        /// Returns true if SchemeApplicationCredentials instances are equal
        /// </summary>
        /// <param name="input">Instance of SchemeApplicationCredentials to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchemeApplicationCredentials input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Signing == input.Signing ||
                    (this.Signing != null &&
                    this.Signing.Equals(input.Signing))
                ) && 
                (
                    this.UserNameTemplate == input.UserNameTemplate ||
                    (this.UserNameTemplate != null &&
                    this.UserNameTemplate.Equals(input.UserNameTemplate))
                ) && 
                (
                    this.Password == input.Password ||
                    (this.Password != null &&
                    this.Password.Equals(input.Password))
                ) && 
                (
                    this.RevealPassword == input.RevealPassword ||
                    this.RevealPassword.Equals(input.RevealPassword)
                ) && 
                (
                    this.Scheme == input.Scheme ||
                    this.Scheme.Equals(input.Scheme)
                ) && 
                (
                    this.UserName == input.UserName ||
                    (this.UserName != null &&
                    this.UserName.Equals(input.UserName))
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
                
                if (this.Signing != null)
                {
                    hashCode = (hashCode * 59) + this.Signing.GetHashCode();
                }
                if (this.UserNameTemplate != null)
                {
                    hashCode = (hashCode * 59) + this.UserNameTemplate.GetHashCode();
                }
                if (this.Password != null)
                {
                    hashCode = (hashCode * 59) + this.Password.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RevealPassword.GetHashCode();
                if (this.Scheme != null)
                {
                    hashCode = (hashCode * 59) + this.Scheme.GetHashCode();
                }
                if (this.UserName != null)
                {
                    hashCode = (hashCode * 59) + this.UserName.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
