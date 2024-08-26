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
    /// The configuration of the provider
    /// </summary>
    [DataContract(Name = "AuthenticatorKeyCustomApp_allOf_provider_configuration")]
    
    public partial class AuthenticatorKeyCustomAppAllOfProviderConfiguration : IEquatable<AuthenticatorKeyCustomAppAllOfProviderConfiguration>
    {
        
        /// <summary>
        /// Gets or Sets Apns
        /// </summary>
        [DataMember(Name = "apns", EmitDefaultValue = true)]
        public AuthenticatorKeyCustomAppAllOfProviderConfigurationApns Apns { get; set; }

        /// <summary>
        /// Gets or Sets Fcm
        /// </summary>
        [DataMember(Name = "fcm", EmitDefaultValue = true)]
        public AuthenticatorKeyCustomAppAllOfProviderConfigurationFcm Fcm { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthenticatorKeyCustomAppAllOfProviderConfiguration {\n");
            sb.Append("  Apns: ").Append(Apns).Append("\n");
            sb.Append("  Fcm: ").Append(Fcm).Append("\n");
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
            return this.Equals(input as AuthenticatorKeyCustomAppAllOfProviderConfiguration);
        }

        /// <summary>
        /// Returns true if AuthenticatorKeyCustomAppAllOfProviderConfiguration instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthenticatorKeyCustomAppAllOfProviderConfiguration to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthenticatorKeyCustomAppAllOfProviderConfiguration input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Apns == input.Apns ||
                    (this.Apns != null &&
                    this.Apns.Equals(input.Apns))
                ) && 
                (
                    this.Fcm == input.Fcm ||
                    (this.Fcm != null &&
                    this.Fcm.Equals(input.Fcm))
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
                
                if (this.Apns != null)
                {
                    hashCode = (hashCode * 59) + this.Apns.GetHashCode();
                }
                if (this.Fcm != null)
                {
                    hashCode = (hashCode * 59) + this.Fcm.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}