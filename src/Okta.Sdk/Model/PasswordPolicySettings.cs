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
    /// PasswordPolicySettings
    /// </summary>
    [DataContract(Name = "PasswordPolicySettings")]
    
    public partial class PasswordPolicySettings : IEquatable<PasswordPolicySettings>
    {
        
        /// <summary>
        /// Gets or Sets Delegation
        /// </summary>
        [DataMember(Name = "delegation", EmitDefaultValue = false)]
        public PasswordPolicyDelegationSettings Delegation { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name = "password", EmitDefaultValue = false)]
        public PasswordPolicyPasswordSettings Password { get; set; }

        /// <summary>
        /// Gets or Sets Recovery
        /// </summary>
        [DataMember(Name = "recovery", EmitDefaultValue = false)]
        public PasswordPolicyRecoverySettings Recovery { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PasswordPolicySettings {\n");
            sb.Append("  Delegation: ").Append(Delegation).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Recovery: ").Append(Recovery).Append("\n");
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
            return this.Equals(input as PasswordPolicySettings);
        }

        /// <summary>
        /// Returns true if PasswordPolicySettings instances are equal
        /// </summary>
        /// <param name="input">Instance of PasswordPolicySettings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PasswordPolicySettings input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Delegation == input.Delegation ||
                    (this.Delegation != null &&
                    this.Delegation.Equals(input.Delegation))
                ) && 
                (
                    this.Password == input.Password ||
                    (this.Password != null &&
                    this.Password.Equals(input.Password))
                ) && 
                (
                    this.Recovery == input.Recovery ||
                    (this.Recovery != null &&
                    this.Recovery.Equals(input.Recovery))
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
                
                if (this.Delegation != null)
                {
                    hashCode = (hashCode * 59) + this.Delegation.GetHashCode();
                }
                if (this.Password != null)
                {
                    hashCode = (hashCode * 59) + this.Password.GetHashCode();
                }
                if (this.Recovery != null)
                {
                    hashCode = (hashCode * 59) + this.Recovery.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
