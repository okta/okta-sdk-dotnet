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
    /// AuthorizationServerPolicyLinks
    /// </summary>
    [DataContract(Name = "AuthorizationServerPolicy__links")]
    
    public partial class AuthorizationServerPolicyLinks : IEquatable<AuthorizationServerPolicyLinks>
    {
        
        /// <summary>
        /// Gets or Sets Self
        /// </summary>
        [DataMember(Name = "self", EmitDefaultValue = true)]
        public HrefObjectSelfLink Self { get; set; }

        /// <summary>
        /// Gets or Sets Activate
        /// </summary>
        [DataMember(Name = "activate", EmitDefaultValue = true)]
        public HrefObjectActivateLink Activate { get; set; }

        /// <summary>
        /// Gets or Sets Deactivate
        /// </summary>
        [DataMember(Name = "deactivate", EmitDefaultValue = true)]
        public HrefObjectDeactivateLink Deactivate { get; set; }

        /// <summary>
        /// Gets or Sets Rules
        /// </summary>
        [DataMember(Name = "rules", EmitDefaultValue = true)]
        public AuthorizationServerPolicyLinksAllOfRules Rules { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthorizationServerPolicyLinks {\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  Activate: ").Append(Activate).Append("\n");
            sb.Append("  Deactivate: ").Append(Deactivate).Append("\n");
            sb.Append("  Rules: ").Append(Rules).Append("\n");
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
            return this.Equals(input as AuthorizationServerPolicyLinks);
        }

        /// <summary>
        /// Returns true if AuthorizationServerPolicyLinks instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthorizationServerPolicyLinks to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthorizationServerPolicyLinks input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Self == input.Self ||
                    (this.Self != null &&
                    this.Self.Equals(input.Self))
                ) && 
                (
                    this.Activate == input.Activate ||
                    (this.Activate != null &&
                    this.Activate.Equals(input.Activate))
                ) && 
                (
                    this.Deactivate == input.Deactivate ||
                    (this.Deactivate != null &&
                    this.Deactivate.Equals(input.Deactivate))
                ) && 
                (
                    this.Rules == input.Rules ||
                    (this.Rules != null &&
                    this.Rules.Equals(input.Rules))
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
                
                if (this.Self != null)
                {
                    hashCode = (hashCode * 59) + this.Self.GetHashCode();
                }
                if (this.Activate != null)
                {
                    hashCode = (hashCode * 59) + this.Activate.GetHashCode();
                }
                if (this.Deactivate != null)
                {
                    hashCode = (hashCode * 59) + this.Deactivate.GetHashCode();
                }
                if (this.Rules != null)
                {
                    hashCode = (hashCode * 59) + this.Rules.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
