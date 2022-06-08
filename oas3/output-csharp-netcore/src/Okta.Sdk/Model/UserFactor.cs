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
using JsonSubTypes;
using OpenAPIDateConverter = Okta.Sdk.Client.OpenAPIDateConverter;

namespace Okta.Sdk.Model
{
    /// <summary>
    /// Template: ModelGeneric
    /// UserFactor
    /// </summary>
    [DataContract(Name = "UserFactor")]
    [JsonConverter(typeof(JsonSubtypes), "FactorType")]
    [JsonSubtypes.KnownSubType(typeof(CallUserFactor), "CallUserFactor")]
    [JsonSubtypes.KnownSubType(typeof(CustomHotpUserFactor), "CustomHotpUserFactor")]
    [JsonSubtypes.KnownSubType(typeof(EmailUserFactor), "EmailUserFactor")]
    [JsonSubtypes.KnownSubType(typeof(HardwareUserFactor), "HardwareUserFactor")]
    [JsonSubtypes.KnownSubType(typeof(PushUserFactor), "PushUserFactor")]
    [JsonSubtypes.KnownSubType(typeof(SecurityQuestionUserFactor), "SecurityQuestionUserFactor")]
    [JsonSubtypes.KnownSubType(typeof(SmsUserFactor), "SmsUserFactor")]
    [JsonSubtypes.KnownSubType(typeof(TokenUserFactor), "TokenUserFactor")]
    [JsonSubtypes.KnownSubType(typeof(TotpUserFactor), "TotpUserFactor")]
    [JsonSubtypes.KnownSubType(typeof(U2fUserFactor), "U2fUserFactor")]
    [JsonSubtypes.KnownSubType(typeof(WebAuthnUserFactor), "WebAuthnUserFactor")]
    [JsonSubtypes.KnownSubType(typeof(WebUserFactor), "WebUserFactor")]
    [JsonSubtypes.KnownSubType(typeof(CallUserFactor), "call")]
    [JsonSubtypes.KnownSubType(typeof(EmailUserFactor), "email")]
    [JsonSubtypes.KnownSubType(typeof(CustomHotpUserFactor), "hotp")]
    [JsonSubtypes.KnownSubType(typeof(PushUserFactor), "push")]
    [JsonSubtypes.KnownSubType(typeof(SecurityQuestionUserFactor), "question")]
    [JsonSubtypes.KnownSubType(typeof(SmsUserFactor), "sms")]
    [JsonSubtypes.KnownSubType(typeof(TokenUserFactor), "token")]
    [JsonSubtypes.KnownSubType(typeof(HardwareUserFactor), "token:hardware")]
    [JsonSubtypes.KnownSubType(typeof(CustomHotpUserFactor), "token:hotp")]
    [JsonSubtypes.KnownSubType(typeof(TotpUserFactor), "token:software:totp")]
    [JsonSubtypes.KnownSubType(typeof(U2fUserFactor), "u2f")]
    [JsonSubtypes.KnownSubType(typeof(WebUserFactor), "web")]
    [JsonSubtypes.KnownSubType(typeof(WebAuthnUserFactor), "webauthn")]
    public partial class UserFactor : IEquatable<UserFactor>
    {

        /// <summary>
        /// Gets or Sets FactorType
        /// </summary>
        [DataMember(Name = "factorType", EmitDefaultValue = false)]
        public FactorType? FactorType { get; set; }

        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        [DataMember(Name = "provider", EmitDefaultValue = false)]
        public FactorProvider? Provider { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public FactorStatus? Status { get; set; }
        
        /// <summary>
        /// Gets or Sets Created
        /// </summary>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public DateTimeOffset Created { get; private set; }

        /// <summary>
        /// Returns false as Created should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCreated()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; private set; }

        /// <summary>
        /// Returns false as Id should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeId()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets LastUpdated
        /// </summary>
        [DataMember(Name = "lastUpdated", EmitDefaultValue = false)]
        public DateTimeOffset LastUpdated { get; private set; }

        /// <summary>
        /// Returns false as LastUpdated should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeLastUpdated()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Verify
        /// </summary>
        [DataMember(Name = "verify", EmitDefaultValue = false)]
        public VerifyFactorRequest Verify { get; set; }

        /// <summary>
        /// Gets or Sets Embedded
        /// </summary>
        [DataMember(Name = "_embedded", EmitDefaultValue = false)]
        public Dictionary<string, Object> Embedded { get; private set; }

        /// <summary>
        /// Returns false as Embedded should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeEmbedded()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public Dictionary<string, Object> Links { get; private set; }

        /// <summary>
        /// Returns false as Links should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeLinks()
        {
            return false;
        }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserFactor {\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  FactorType: ").Append(FactorType).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastUpdated: ").Append(LastUpdated).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Verify: ").Append(Verify).Append("\n");
            sb.Append("  Embedded: ").Append(Embedded).Append("\n");
            sb.Append("  Links: ").Append(Links).Append("\n");
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
            return this.Equals(input as UserFactor);
        }

        /// <summary>
        /// Returns true if UserFactor instances are equal
        /// </summary>
        /// <param name="input">Instance of UserFactor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserFactor input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Created == input.Created ||
                    (this.Created != null &&
                    this.Created.Equals(input.Created))
                ) && 
                (
                    this.FactorType == input.FactorType ||
                    this.FactorType.Equals(input.FactorType)
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.LastUpdated == input.LastUpdated ||
                    (this.LastUpdated != null &&
                    this.LastUpdated.Equals(input.LastUpdated))
                ) && 
                (
                    this.Provider == input.Provider ||
                    this.Provider.Equals(input.Provider)
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Verify == input.Verify ||
                    (this.Verify != null &&
                    this.Verify.Equals(input.Verify))
                ) && 
                (
                    this.Embedded == input.Embedded ||
                    this.Embedded != null &&
                    input.Embedded != null &&
                    this.Embedded.SequenceEqual(input.Embedded)
                ) && 
                (
                    this.Links == input.Links ||
                    this.Links != null &&
                    input.Links != null &&
                    this.Links.SequenceEqual(input.Links)
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
                if (this.Created != null)
                {
                    hashCode = (hashCode * 59) + this.Created.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.FactorType.GetHashCode();
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.LastUpdated != null)
                {
                    hashCode = (hashCode * 59) + this.LastUpdated.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Provider.GetHashCode();
                hashCode = (hashCode * 59) + this.Status.GetHashCode();
                if (this.Verify != null)
                {
                    hashCode = (hashCode * 59) + this.Verify.GetHashCode();
                }
                if (this.Embedded != null)
                {
                    hashCode = (hashCode * 59) + this.Embedded.GetHashCode();
                }
                if (this.Links != null)
                {
                    hashCode = (hashCode * 59) + this.Links.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
