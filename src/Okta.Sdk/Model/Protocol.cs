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
    /// Protocol
    /// </summary>
    [DataContract(Name = "Protocol")]
    
    public partial class Protocol : IEquatable<Protocol>
    {
        
        /// <summary>
        /// Gets or Sets Algorithms
        /// </summary>
        [DataMember(Name = "algorithms", EmitDefaultValue = false)]
        public ProtocolAlgorithms Algorithms { get; set; }

        /// <summary>
        /// Gets or Sets Credentials
        /// </summary>
        [DataMember(Name = "credentials", EmitDefaultValue = false)]
        public IdentityProviderCredentials Credentials { get; set; }

        /// <summary>
        /// Gets or Sets Endpoints
        /// </summary>
        [DataMember(Name = "endpoints", EmitDefaultValue = false)]
        public ProtocolEndpoints Endpoints { get; set; }

        /// <summary>
        /// Gets or Sets Issuer
        /// </summary>
        [DataMember(Name = "issuer", EmitDefaultValue = false)]
        public ProtocolEndpoint Issuer { get; set; }

        /// <summary>
        /// Gets or Sets RelayState
        /// </summary>
        [DataMember(Name = "relayState", EmitDefaultValue = false)]
        public ProtocolRelayState RelayState { get; set; }

        /// <summary>
        /// Gets or Sets Scopes
        /// </summary>
        [DataMember(Name = "scopes", EmitDefaultValue = false)]
        public List<string> Scopes { get; set; }

        /// <summary>
        /// Gets or Sets Settings
        /// </summary>
        [DataMember(Name = "settings", EmitDefaultValue = false)]
        public ProtocolSettings Settings { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Protocol {\n");
            sb.Append("  Algorithms: ").Append(Algorithms).Append("\n");
            sb.Append("  Credentials: ").Append(Credentials).Append("\n");
            sb.Append("  Endpoints: ").Append(Endpoints).Append("\n");
            sb.Append("  Issuer: ").Append(Issuer).Append("\n");
            sb.Append("  RelayState: ").Append(RelayState).Append("\n");
            sb.Append("  Scopes: ").Append(Scopes).Append("\n");
            sb.Append("  Settings: ").Append(Settings).Append("\n");
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
            return this.Equals(input as Protocol);
        }

        /// <summary>
        /// Returns true if Protocol instances are equal
        /// </summary>
        /// <param name="input">Instance of Protocol to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Protocol input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Algorithms == input.Algorithms ||
                    (this.Algorithms != null &&
                    this.Algorithms.Equals(input.Algorithms))
                ) && 
                (
                    this.Credentials == input.Credentials ||
                    (this.Credentials != null &&
                    this.Credentials.Equals(input.Credentials))
                ) && 
                (
                    this.Endpoints == input.Endpoints ||
                    (this.Endpoints != null &&
                    this.Endpoints.Equals(input.Endpoints))
                ) && 
                (
                    this.Issuer == input.Issuer ||
                    (this.Issuer != null &&
                    this.Issuer.Equals(input.Issuer))
                ) && 
                (
                    this.RelayState == input.RelayState ||
                    (this.RelayState != null &&
                    this.RelayState.Equals(input.RelayState))
                ) && 
                (
                    this.Scopes == input.Scopes ||
                    this.Scopes != null &&
                    input.Scopes != null &&
                    this.Scopes.SequenceEqual(input.Scopes)
                ) && 
                (
                    this.Settings == input.Settings ||
                    (this.Settings != null &&
                    this.Settings.Equals(input.Settings))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
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
                
                if (this.Algorithms != null)
                {
                    hashCode = (hashCode * 59) + this.Algorithms.GetHashCode();
                }
                if (this.Credentials != null)
                {
                    hashCode = (hashCode * 59) + this.Credentials.GetHashCode();
                }
                if (this.Endpoints != null)
                {
                    hashCode = (hashCode * 59) + this.Endpoints.GetHashCode();
                }
                if (this.Issuer != null)
                {
                    hashCode = (hashCode * 59) + this.Issuer.GetHashCode();
                }
                if (this.RelayState != null)
                {
                    hashCode = (hashCode * 59) + this.RelayState.GetHashCode();
                }
                if (this.Scopes != null)
                {
                    hashCode = (hashCode * 59) + this.Scopes.GetHashCode();
                }
                if (this.Settings != null)
                {
                    hashCode = (hashCode * 59) + this.Settings.GetHashCode();
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
