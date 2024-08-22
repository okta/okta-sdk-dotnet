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
using JsonSubTypes;
using OpenAPIDateConverter = Okta.Sdk.Client.OpenAPIDateConverter;

namespace Okta.Sdk.Model
{
    /// <summary>
    /// Template: ModelGeneric
    /// IdpDiscoveryPolicy
    /// </summary>
    [DataContract(Name = "IdpDiscoveryPolicy")]
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(AccessPolicy), "ACCESS_POLICY")]
    [JsonSubtypes.KnownSubType(typeof(ContinuousAccessPolicy), "CONTINUOUS_ACCESS")]
    [JsonSubtypes.KnownSubType(typeof(EntityRiskPolicy), "ENTITY_RISK")]
    [JsonSubtypes.KnownSubType(typeof(IdpDiscoveryPolicy), "IDP_DISCOVERY")]
    [JsonSubtypes.KnownSubType(typeof(MultifactorEnrollmentPolicy), "MFA_ENROLL")]
    [JsonSubtypes.KnownSubType(typeof(OktaSignOnPolicy), "OKTA_SIGN_ON")]
    [JsonSubtypes.KnownSubType(typeof(PasswordPolicy), "PASSWORD")]
    [JsonSubtypes.KnownSubType(typeof(ProfileEnrollmentPolicy), "PROFILE_ENROLLMENT")]
    
    public partial class IdpDiscoveryPolicy : Policy, IEquatable<IdpDiscoveryPolicy>
    {
        
        /// <summary>
        /// Gets or Sets Conditions
        /// </summary>
        [DataMember(Name = "conditions", EmitDefaultValue = true)]
        public Object Conditions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class IdpDiscoveryPolicy {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Conditions: ").Append(Conditions).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return this.Equals(input as IdpDiscoveryPolicy);
        }

        /// <summary>
        /// Returns true if IdpDiscoveryPolicy instances are equal
        /// </summary>
        /// <param name="input">Instance of IdpDiscoveryPolicy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IdpDiscoveryPolicy input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.Conditions == input.Conditions ||
                    (this.Conditions != null &&
                    this.Conditions.Equals(input.Conditions))
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
                
                if (this.Conditions != null)
                {
                    hashCode = (hashCode * 59) + this.Conditions.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
