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
    /// AuthenticatorSettings
    /// </summary>
    [DataContract(Name = "AuthenticatorSettings")]
    
    public partial class AuthenticatorSettings : IEquatable<AuthenticatorSettings>
    {

        /// <summary>
        /// Gets or Sets AllowedFor
        /// </summary>
        [DataMember(Name = "allowedFor", EmitDefaultValue = false)]
        
        public AllowedForEnum AllowedFor { get; set; }

        /// <summary>
        /// Gets or Sets UserVerification
        /// </summary>
        [DataMember(Name = "userVerification", EmitDefaultValue = false)]
        
        public UserVerificationEnum UserVerification { get; set; }
        
        /// <summary>
        /// Gets or Sets AppInstanceId
        /// </summary>
        [DataMember(Name = "appInstanceId", EmitDefaultValue = false)]
        public string AppInstanceId { get; set; }

        /// <summary>
        /// Gets or Sets ChannelBinding
        /// </summary>
        [DataMember(Name = "channelBinding", EmitDefaultValue = false)]
        public ChannelBinding ChannelBinding { get; set; }

        /// <summary>
        /// Gets or Sets Compliance
        /// </summary>
        [DataMember(Name = "compliance", EmitDefaultValue = false)]
        public Compliance Compliance { get; set; }

        /// <summary>
        /// Gets or Sets TokenLifetimeInMinutes
        /// </summary>
        [DataMember(Name = "tokenLifetimeInMinutes", EmitDefaultValue = false)]
        public int TokenLifetimeInMinutes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthenticatorSettings {\n");
            sb.Append("  AllowedFor: ").Append(AllowedFor).Append("\n");
            sb.Append("  AppInstanceId: ").Append(AppInstanceId).Append("\n");
            sb.Append("  ChannelBinding: ").Append(ChannelBinding).Append("\n");
            sb.Append("  Compliance: ").Append(Compliance).Append("\n");
            sb.Append("  TokenLifetimeInMinutes: ").Append(TokenLifetimeInMinutes).Append("\n");
            sb.Append("  UserVerification: ").Append(UserVerification).Append("\n");
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
            return this.Equals(input as AuthenticatorSettings);
        }

        /// <summary>
        /// Returns true if AuthenticatorSettings instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthenticatorSettings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthenticatorSettings input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AllowedFor == input.AllowedFor ||
                    this.AllowedFor.Equals(input.AllowedFor)
                ) && 
                (
                    this.AppInstanceId == input.AppInstanceId ||
                    (this.AppInstanceId != null &&
                    this.AppInstanceId.Equals(input.AppInstanceId))
                ) && 
                (
                    this.ChannelBinding == input.ChannelBinding ||
                    (this.ChannelBinding != null &&
                    this.ChannelBinding.Equals(input.ChannelBinding))
                ) && 
                (
                    this.Compliance == input.Compliance ||
                    (this.Compliance != null &&
                    this.Compliance.Equals(input.Compliance))
                ) && 
                (
                    this.TokenLifetimeInMinutes == input.TokenLifetimeInMinutes ||
                    this.TokenLifetimeInMinutes.Equals(input.TokenLifetimeInMinutes)
                ) && 
                (
                    this.UserVerification == input.UserVerification ||
                    this.UserVerification.Equals(input.UserVerification)
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
                
                hashCode = (hashCode * 59) + this.AllowedFor.GetHashCode();
                if (this.AppInstanceId != null)
                {
                    hashCode = (hashCode * 59) + this.AppInstanceId.GetHashCode();
                }
                if (this.ChannelBinding != null)
                {
                    hashCode = (hashCode * 59) + this.ChannelBinding.GetHashCode();
                }
                if (this.Compliance != null)
                {
                    hashCode = (hashCode * 59) + this.Compliance.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TokenLifetimeInMinutes.GetHashCode();
                hashCode = (hashCode * 59) + this.UserVerification.GetHashCode();
                return hashCode;
            }
        }

    }

}
