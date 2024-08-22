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
    /// IdentitySourceUserProfileForUpsert
    /// </summary>
    [DataContract(Name = "IdentitySourceUserProfileForUpsert")]
    
    public partial class IdentitySourceUserProfileForUpsert : Dictionary<String, Object>, IEquatable<IdentitySourceUserProfileForUpsert>
    {
        
        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = true)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [DataMember(Name = "firstName", EmitDefaultValue = true)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets HomeAddress
        /// </summary>
        [DataMember(Name = "homeAddress", EmitDefaultValue = true)]
        public string HomeAddress { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [DataMember(Name = "lastName", EmitDefaultValue = true)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets MobilePhone
        /// </summary>
        [DataMember(Name = "mobilePhone", EmitDefaultValue = true)]
        public string MobilePhone { get; set; }

        /// <summary>
        /// Gets or Sets SecondEmail
        /// </summary>
        [DataMember(Name = "secondEmail", EmitDefaultValue = true)]
        public string SecondEmail { get; set; }

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
            sb.Append("class IdentitySourceUserProfileForUpsert {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  HomeAddress: ").Append(HomeAddress).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  MobilePhone: ").Append(MobilePhone).Append("\n");
            sb.Append("  SecondEmail: ").Append(SecondEmail).Append("\n");
            sb.Append("  UserName: ").Append(UserName).Append("\n");
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
            return this.Equals(input as IdentitySourceUserProfileForUpsert);
        }

        /// <summary>
        /// Returns true if IdentitySourceUserProfileForUpsert instances are equal
        /// </summary>
        /// <param name="input">Instance of IdentitySourceUserProfileForUpsert to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IdentitySourceUserProfileForUpsert input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && base.Equals(input) && 
                (
                    this.FirstName == input.FirstName ||
                    (this.FirstName != null &&
                    this.FirstName.Equals(input.FirstName))
                ) && base.Equals(input) && 
                (
                    this.HomeAddress == input.HomeAddress ||
                    (this.HomeAddress != null &&
                    this.HomeAddress.Equals(input.HomeAddress))
                ) && base.Equals(input) && 
                (
                    this.LastName == input.LastName ||
                    (this.LastName != null &&
                    this.LastName.Equals(input.LastName))
                ) && base.Equals(input) && 
                (
                    this.MobilePhone == input.MobilePhone ||
                    (this.MobilePhone != null &&
                    this.MobilePhone.Equals(input.MobilePhone))
                ) && base.Equals(input) && 
                (
                    this.SecondEmail == input.SecondEmail ||
                    (this.SecondEmail != null &&
                    this.SecondEmail.Equals(input.SecondEmail))
                ) && base.Equals(input) && 
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
                int hashCode = base.GetHashCode();
                
                if (this.Email != null)
                {
                    hashCode = (hashCode * 59) + this.Email.GetHashCode();
                }
                if (this.FirstName != null)
                {
                    hashCode = (hashCode * 59) + this.FirstName.GetHashCode();
                }
                if (this.HomeAddress != null)
                {
                    hashCode = (hashCode * 59) + this.HomeAddress.GetHashCode();
                }
                if (this.LastName != null)
                {
                    hashCode = (hashCode * 59) + this.LastName.GetHashCode();
                }
                if (this.MobilePhone != null)
                {
                    hashCode = (hashCode * 59) + this.MobilePhone.GetHashCode();
                }
                if (this.SecondEmail != null)
                {
                    hashCode = (hashCode * 59) + this.SecondEmail.GetHashCode();
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
