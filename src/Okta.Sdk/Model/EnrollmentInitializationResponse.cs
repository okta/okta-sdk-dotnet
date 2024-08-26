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
    /// Yubico Transport Key in the form of a JWK, used to encrypt our fulfillment request to Yubico. The currently agreed protocol uses P-384.
    /// </summary>
    [DataContract(Name = "EnrollmentInitializationResponse")]
    
    public partial class EnrollmentInitializationResponse : IEquatable<EnrollmentInitializationResponse>
    {
        /// <summary>
        /// Name of the fulfillment provider for the WebAuthn Preregistration Factor
        /// </summary>
        /// <value>Name of the fulfillment provider for the WebAuthn Preregistration Factor</value>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class FulfillmentProviderEnum : StringEnum
        {
            /// <summary>
            /// StringEnum Yubico for value: yubico
            /// </summary>
            
            public static FulfillmentProviderEnum Yubico = new FulfillmentProviderEnum("yubico");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="FulfillmentProviderEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator FulfillmentProviderEnum(string value) => new FulfillmentProviderEnum(value);

            /// <summary>
            /// Creates a new <see cref="FulfillmentProvider"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public FulfillmentProviderEnum(string value)
                : base(value)
            {
            }
        }


        /// <summary>
        /// Name of the fulfillment provider for the WebAuthn Preregistration Factor
        /// </summary>
        /// <value>Name of the fulfillment provider for the WebAuthn Preregistration Factor</value>
        [DataMember(Name = "fulfillmentProvider", EmitDefaultValue = true)]
        
        public FulfillmentProviderEnum FulfillmentProvider { get; set; }
        
        /// <summary>
        /// List of credential requests for the fulfillment provider
        /// </summary>
        /// <value>List of credential requests for the fulfillment provider</value>
        [DataMember(Name = "credRequests", EmitDefaultValue = true)]
        public List<WebAuthnCredRequest> CredRequests { get; set; }

        /// <summary>
        /// Encrypted JWE of PIN request for the fulfillment provider
        /// </summary>
        /// <value>Encrypted JWE of PIN request for the fulfillment provider</value>
        [DataMember(Name = "pinRequestJwe", EmitDefaultValue = true)]
        public string PinRequestJwe { get; set; }

        /// <summary>
        /// ID of an existing Okta user
        /// </summary>
        /// <value>ID of an existing Okta user</value>
        [DataMember(Name = "userId", EmitDefaultValue = true)]
        public string UserId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EnrollmentInitializationResponse {\n");
            sb.Append("  CredRequests: ").Append(CredRequests).Append("\n");
            sb.Append("  FulfillmentProvider: ").Append(FulfillmentProvider).Append("\n");
            sb.Append("  PinRequestJwe: ").Append(PinRequestJwe).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
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
            return this.Equals(input as EnrollmentInitializationResponse);
        }

        /// <summary>
        /// Returns true if EnrollmentInitializationResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of EnrollmentInitializationResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnrollmentInitializationResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.CredRequests == input.CredRequests ||
                    this.CredRequests != null &&
                    input.CredRequests != null &&
                    this.CredRequests.SequenceEqual(input.CredRequests)
                ) && 
                (
                    this.FulfillmentProvider == input.FulfillmentProvider ||
                    this.FulfillmentProvider.Equals(input.FulfillmentProvider)
                ) && 
                (
                    this.PinRequestJwe == input.PinRequestJwe ||
                    (this.PinRequestJwe != null &&
                    this.PinRequestJwe.Equals(input.PinRequestJwe))
                ) && 
                (
                    this.UserId == input.UserId ||
                    (this.UserId != null &&
                    this.UserId.Equals(input.UserId))
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
                
                if (this.CredRequests != null)
                {
                    hashCode = (hashCode * 59) + this.CredRequests.GetHashCode();
                }
                if (this.FulfillmentProvider != null)
                {
                    hashCode = (hashCode * 59) + this.FulfillmentProvider.GetHashCode();
                }
                if (this.PinRequestJwe != null)
                {
                    hashCode = (hashCode * 59) + this.PinRequestJwe.GetHashCode();
                }
                if (this.UserId != null)
                {
                    hashCode = (hashCode * 59) + this.UserId.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}