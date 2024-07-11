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
    /// AuthenticatorKeyDuoAllOfProviderConfiguration
    /// </summary>
    [DataContract(Name = "AuthenticatorKeyDuo_allOf_provider_configuration")]
    
    public partial class AuthenticatorKeyDuoAllOfProviderConfiguration : IEquatable<AuthenticatorKeyDuoAllOfProviderConfiguration>
    {
        
        /// <summary>
        /// The Duo Security API hostname
        /// </summary>
        /// <value>The Duo Security API hostname</value>
        [DataMember(Name = "host", EmitDefaultValue = true)]
        public string Host { get; set; }

        /// <summary>
        /// The Duo Security integration key
        /// </summary>
        /// <value>The Duo Security integration key</value>
        [DataMember(Name = "integrationKey", EmitDefaultValue = true)]
        public string IntegrationKey { get; set; }

        /// <summary>
        /// The Duo Security secret key
        /// </summary>
        /// <value>The Duo Security secret key</value>
        [DataMember(Name = "secretKey", EmitDefaultValue = true)]
        public string SecretKey { get; set; }

        /// <summary>
        /// Gets or Sets UserNameTemplate
        /// </summary>
        [DataMember(Name = "userNameTemplate", EmitDefaultValue = true)]
        public AuthenticatorKeyDuoAllOfProviderConfigurationUserNameTemplate UserNameTemplate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthenticatorKeyDuoAllOfProviderConfiguration {\n");
            sb.Append("  Host: ").Append(Host).Append("\n");
            sb.Append("  IntegrationKey: ").Append(IntegrationKey).Append("\n");
            sb.Append("  SecretKey: ").Append(SecretKey).Append("\n");
            sb.Append("  UserNameTemplate: ").Append(UserNameTemplate).Append("\n");
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
            return this.Equals(input as AuthenticatorKeyDuoAllOfProviderConfiguration);
        }

        /// <summary>
        /// Returns true if AuthenticatorKeyDuoAllOfProviderConfiguration instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthenticatorKeyDuoAllOfProviderConfiguration to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthenticatorKeyDuoAllOfProviderConfiguration input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Host == input.Host ||
                    (this.Host != null &&
                    this.Host.Equals(input.Host))
                ) && 
                (
                    this.IntegrationKey == input.IntegrationKey ||
                    (this.IntegrationKey != null &&
                    this.IntegrationKey.Equals(input.IntegrationKey))
                ) && 
                (
                    this.SecretKey == input.SecretKey ||
                    (this.SecretKey != null &&
                    this.SecretKey.Equals(input.SecretKey))
                ) && 
                (
                    this.UserNameTemplate == input.UserNameTemplate ||
                    (this.UserNameTemplate != null &&
                    this.UserNameTemplate.Equals(input.UserNameTemplate))
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
                
                if (this.Host != null)
                {
                    hashCode = (hashCode * 59) + this.Host.GetHashCode();
                }
                if (this.IntegrationKey != null)
                {
                    hashCode = (hashCode * 59) + this.IntegrationKey.GetHashCode();
                }
                if (this.SecretKey != null)
                {
                    hashCode = (hashCode * 59) + this.SecretKey.GetHashCode();
                }
                if (this.UserNameTemplate != null)
                {
                    hashCode = (hashCode * 59) + this.UserNameTemplate.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
