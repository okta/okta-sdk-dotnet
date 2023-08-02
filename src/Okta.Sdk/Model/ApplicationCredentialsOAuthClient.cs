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
    /// ApplicationCredentialsOAuthClient
    /// </summary>
    [DataContract(Name = "ApplicationCredentialsOAuthClient")]
    
    public partial class ApplicationCredentialsOAuthClient : IEquatable<ApplicationCredentialsOAuthClient>
    {

        /// <summary>
        /// Gets or Sets TokenEndpointAuthMethod
        /// </summary>
        [DataMember(Name = "token_endpoint_auth_method", EmitDefaultValue = false)]
        
        public OAuthEndpointAuthenticationMethod TokenEndpointAuthMethod { get; set; }
        
        /// <summary>
        /// Gets or Sets AutoKeyRotation
        /// </summary>
        [DataMember(Name = "autoKeyRotation", EmitDefaultValue = true)]
        public bool AutoKeyRotation { get; set; }

        /// <summary>
        /// Gets or Sets ClientId
        /// </summary>
        [DataMember(Name = "client_id", EmitDefaultValue = false)]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or Sets ClientSecret
        /// </summary>
        [DataMember(Name = "client_secret", EmitDefaultValue = false)]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ApplicationCredentialsOAuthClient {\n");
            sb.Append("  AutoKeyRotation: ").Append(AutoKeyRotation).Append("\n");
            sb.Append("  ClientId: ").Append(ClientId).Append("\n");
            sb.Append("  ClientSecret: ").Append(ClientSecret).Append("\n");
            sb.Append("  TokenEndpointAuthMethod: ").Append(TokenEndpointAuthMethod).Append("\n");
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
            return this.Equals(input as ApplicationCredentialsOAuthClient);
        }

        /// <summary>
        /// Returns true if ApplicationCredentialsOAuthClient instances are equal
        /// </summary>
        /// <param name="input">Instance of ApplicationCredentialsOAuthClient to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApplicationCredentialsOAuthClient input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AutoKeyRotation == input.AutoKeyRotation ||
                    this.AutoKeyRotation.Equals(input.AutoKeyRotation)
                ) && 
                (
                    this.ClientId == input.ClientId ||
                    (this.ClientId != null &&
                    this.ClientId.Equals(input.ClientId))
                ) && 
                (
                    this.ClientSecret == input.ClientSecret ||
                    (this.ClientSecret != null &&
                    this.ClientSecret.Equals(input.ClientSecret))
                ) && 
                (
                    this.TokenEndpointAuthMethod == input.TokenEndpointAuthMethod ||
                    this.TokenEndpointAuthMethod.Equals(input.TokenEndpointAuthMethod)
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
                
                hashCode = (hashCode * 59) + this.AutoKeyRotation.GetHashCode();
                if (this.ClientId != null)
                {
                    hashCode = (hashCode * 59) + this.ClientId.GetHashCode();
                }
                if (this.ClientSecret != null)
                {
                    hashCode = (hashCode * 59) + this.ClientSecret.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TokenEndpointAuthMethod.GetHashCode();
                return hashCode;
            }
        }

    }

}
