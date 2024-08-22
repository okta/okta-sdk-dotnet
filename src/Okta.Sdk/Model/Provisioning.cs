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
    /// Provisioning
    /// </summary>
    [DataContract(Name = "Provisioning")]
    
    public partial class Provisioning : IEquatable<Provisioning>
    {

        /// <summary>
        /// Gets or Sets Action
        /// </summary>
        [DataMember(Name = "action", EmitDefaultValue = true)]
        
        public ProvisioningAction Action { get; set; }
        
        /// <summary>
        /// Gets or Sets Conditions
        /// </summary>
        [DataMember(Name = "conditions", EmitDefaultValue = true)]
        public ProvisioningConditions Conditions { get; set; }

        /// <summary>
        /// Gets or Sets Groups
        /// </summary>
        [DataMember(Name = "groups", EmitDefaultValue = true)]
        public ProvisioningGroups Groups { get; set; }

        /// <summary>
        /// Gets or Sets ProfileMaster
        /// </summary>
        [DataMember(Name = "profileMaster", EmitDefaultValue = true)]
        public bool ProfileMaster { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Provisioning {\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("  Conditions: ").Append(Conditions).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("  ProfileMaster: ").Append(ProfileMaster).Append("\n");
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
            return this.Equals(input as Provisioning);
        }

        /// <summary>
        /// Returns true if Provisioning instances are equal
        /// </summary>
        /// <param name="input">Instance of Provisioning to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Provisioning input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Action == input.Action ||
                    this.Action.Equals(input.Action)
                ) && 
                (
                    this.Conditions == input.Conditions ||
                    (this.Conditions != null &&
                    this.Conditions.Equals(input.Conditions))
                ) && 
                (
                    this.Groups == input.Groups ||
                    (this.Groups != null &&
                    this.Groups.Equals(input.Groups))
                ) && 
                (
                    this.ProfileMaster == input.ProfileMaster ||
                    this.ProfileMaster.Equals(input.ProfileMaster)
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
                
                if (this.Action != null)
                {
                    hashCode = (hashCode * 59) + this.Action.GetHashCode();
                }
                if (this.Conditions != null)
                {
                    hashCode = (hashCode * 59) + this.Conditions.GetHashCode();
                }
                if (this.Groups != null)
                {
                    hashCode = (hashCode * 59) + this.Groups.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ProfileMaster.GetHashCode();
                return hashCode;
            }
        }

    }

}
