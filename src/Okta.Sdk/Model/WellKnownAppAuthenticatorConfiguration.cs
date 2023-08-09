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
    /// WellKnownAppAuthenticatorConfiguration
    /// </summary>
    [DataContract(Name = "WellKnownAppAuthenticatorConfiguration")]
    
    public partial class WellKnownAppAuthenticatorConfiguration : IEquatable<WellKnownAppAuthenticatorConfiguration>
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class TypeEnum : StringEnum
        {
            /// <summary>
            /// StringEnum App for value: app
            /// </summary>
            
            public static TypeEnum App = new TypeEnum("app");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="TypeEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator TypeEnum(string value) => new TypeEnum(value);

            /// <summary>
            /// Creates a new <see cref="Type"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public TypeEnum(string value)
                : base(value)
            {
            }
        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = true)]
        
        public TypeEnum Type { get; set; }
        
        /// <summary>
        /// Gets or Sets AppAuthenticatorEnrollEndpoint
        /// </summary>
        [DataMember(Name = "appAuthenticatorEnrollEndpoint", EmitDefaultValue = true)]
        public string AppAuthenticatorEnrollEndpoint { get; set; }

        /// <summary>
        /// The unique identifier of the app authenticator
        /// </summary>
        /// <value>The unique identifier of the app authenticator</value>
        [DataMember(Name = "authenticatorId", EmitDefaultValue = true)]
        public string AuthenticatorId { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        [DataMember(Name = "createdDate", EmitDefaultValue = true)]
        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets Key
        /// </summary>
        [DataMember(Name = "key", EmitDefaultValue = true)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or Sets LastUpdated
        /// </summary>
        [DataMember(Name = "lastUpdated", EmitDefaultValue = true)]
        public DateTimeOffset LastUpdated { get; set; }

        /// <summary>
        /// The authenticator display name
        /// </summary>
        /// <value>The authenticator display name</value>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets OrgId
        /// </summary>
        [DataMember(Name = "orgId", EmitDefaultValue = true)]
        public string OrgId { get; set; }

        /// <summary>
        /// Gets or Sets Settings
        /// </summary>
        [DataMember(Name = "settings", EmitDefaultValue = true)]
        public WellKnownAppAuthenticatorConfigurationSettings Settings { get; set; }

        /// <summary>
        /// Gets or Sets SupportedMethods
        /// </summary>
        [DataMember(Name = "supportedMethods", EmitDefaultValue = true)]
        public List<SupportedMethods> SupportedMethods { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WellKnownAppAuthenticatorConfiguration {\n");
            sb.Append("  AppAuthenticatorEnrollEndpoint: ").Append(AppAuthenticatorEnrollEndpoint).Append("\n");
            sb.Append("  AuthenticatorId: ").Append(AuthenticatorId).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  LastUpdated: ").Append(LastUpdated).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OrgId: ").Append(OrgId).Append("\n");
            sb.Append("  Settings: ").Append(Settings).Append("\n");
            sb.Append("  SupportedMethods: ").Append(SupportedMethods).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return this.Equals(input as WellKnownAppAuthenticatorConfiguration);
        }

        /// <summary>
        /// Returns true if WellKnownAppAuthenticatorConfiguration instances are equal
        /// </summary>
        /// <param name="input">Instance of WellKnownAppAuthenticatorConfiguration to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WellKnownAppAuthenticatorConfiguration input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AppAuthenticatorEnrollEndpoint == input.AppAuthenticatorEnrollEndpoint ||
                    (this.AppAuthenticatorEnrollEndpoint != null &&
                    this.AppAuthenticatorEnrollEndpoint.Equals(input.AppAuthenticatorEnrollEndpoint))
                ) && 
                (
                    this.AuthenticatorId == input.AuthenticatorId ||
                    (this.AuthenticatorId != null &&
                    this.AuthenticatorId.Equals(input.AuthenticatorId))
                ) && 
                (
                    this.CreatedDate == input.CreatedDate ||
                    (this.CreatedDate != null &&
                    this.CreatedDate.Equals(input.CreatedDate))
                ) && 
                (
                    this.Key == input.Key ||
                    (this.Key != null &&
                    this.Key.Equals(input.Key))
                ) && 
                (
                    this.LastUpdated == input.LastUpdated ||
                    (this.LastUpdated != null &&
                    this.LastUpdated.Equals(input.LastUpdated))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.OrgId == input.OrgId ||
                    (this.OrgId != null &&
                    this.OrgId.Equals(input.OrgId))
                ) && 
                (
                    this.Settings == input.Settings ||
                    (this.Settings != null &&
                    this.Settings.Equals(input.Settings))
                ) && 
                (
                    this.SupportedMethods == input.SupportedMethods ||
                    this.SupportedMethods != null &&
                    input.SupportedMethods != null &&
                    this.SupportedMethods.SequenceEqual(input.SupportedMethods)
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
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
                
                if (this.AppAuthenticatorEnrollEndpoint != null)
                {
                    hashCode = (hashCode * 59) + this.AppAuthenticatorEnrollEndpoint.GetHashCode();
                }
                if (this.AuthenticatorId != null)
                {
                    hashCode = (hashCode * 59) + this.AuthenticatorId.GetHashCode();
                }
                if (this.CreatedDate != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedDate.GetHashCode();
                }
                if (this.Key != null)
                {
                    hashCode = (hashCode * 59) + this.Key.GetHashCode();
                }
                if (this.LastUpdated != null)
                {
                    hashCode = (hashCode * 59) + this.LastUpdated.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.OrgId != null)
                {
                    hashCode = (hashCode * 59) + this.OrgId.GetHashCode();
                }
                if (this.Settings != null)
                {
                    hashCode = (hashCode * 59) + this.Settings.GetHashCode();
                }
                if (this.SupportedMethods != null)
                {
                    hashCode = (hashCode * 59) + this.SupportedMethods.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
