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
    /// Setting for auto-update
    /// </summary>
    [DataContract(Name = "AgentPoolUpdateSetting")]
    
    public partial class AgentPoolUpdateSetting : IEquatable<AgentPoolUpdateSetting>
    {

        /// <summary>
        /// Gets or Sets AgentType
        /// </summary>
        [DataMember(Name = "agentType", EmitDefaultValue = true)]
        
        public AgentType AgentType { get; set; }

        /// <summary>
        /// Gets or Sets ReleaseChannel
        /// </summary>
        [DataMember(Name = "releaseChannel", EmitDefaultValue = true)]
        
        public ReleaseChannel ReleaseChannel { get; set; }
        
        /// <summary>
        /// Gets or Sets ContinueOnError
        /// </summary>
        [DataMember(Name = "continueOnError", EmitDefaultValue = true)]
        public bool ContinueOnError { get; set; }

        /// <summary>
        /// Gets or Sets LatestVersion
        /// </summary>
        [DataMember(Name = "latestVersion", EmitDefaultValue = true)]
        public string LatestVersion { get; set; }

        /// <summary>
        /// Gets or Sets MinimalSupportedVersion
        /// </summary>
        [DataMember(Name = "minimalSupportedVersion", EmitDefaultValue = true)]
        public string MinimalSupportedVersion { get; set; }

        /// <summary>
        /// Gets or Sets PoolId
        /// </summary>
        [DataMember(Name = "poolId", EmitDefaultValue = true)]
        public string PoolId { get; private set; }

        /// <summary>
        /// Returns false as PoolId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePoolId()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets PoolName
        /// </summary>
        [DataMember(Name = "poolName", EmitDefaultValue = true)]
        public string PoolName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AgentPoolUpdateSetting {\n");
            sb.Append("  AgentType: ").Append(AgentType).Append("\n");
            sb.Append("  ContinueOnError: ").Append(ContinueOnError).Append("\n");
            sb.Append("  LatestVersion: ").Append(LatestVersion).Append("\n");
            sb.Append("  MinimalSupportedVersion: ").Append(MinimalSupportedVersion).Append("\n");
            sb.Append("  PoolId: ").Append(PoolId).Append("\n");
            sb.Append("  PoolName: ").Append(PoolName).Append("\n");
            sb.Append("  ReleaseChannel: ").Append(ReleaseChannel).Append("\n");
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
            return this.Equals(input as AgentPoolUpdateSetting);
        }

        /// <summary>
        /// Returns true if AgentPoolUpdateSetting instances are equal
        /// </summary>
        /// <param name="input">Instance of AgentPoolUpdateSetting to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AgentPoolUpdateSetting input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AgentType == input.AgentType ||
                    this.AgentType.Equals(input.AgentType)
                ) && 
                (
                    this.ContinueOnError == input.ContinueOnError ||
                    this.ContinueOnError.Equals(input.ContinueOnError)
                ) && 
                (
                    this.LatestVersion == input.LatestVersion ||
                    (this.LatestVersion != null &&
                    this.LatestVersion.Equals(input.LatestVersion))
                ) && 
                (
                    this.MinimalSupportedVersion == input.MinimalSupportedVersion ||
                    (this.MinimalSupportedVersion != null &&
                    this.MinimalSupportedVersion.Equals(input.MinimalSupportedVersion))
                ) && 
                (
                    this.PoolId == input.PoolId ||
                    (this.PoolId != null &&
                    this.PoolId.Equals(input.PoolId))
                ) && 
                (
                    this.PoolName == input.PoolName ||
                    (this.PoolName != null &&
                    this.PoolName.Equals(input.PoolName))
                ) && 
                (
                    this.ReleaseChannel == input.ReleaseChannel ||
                    this.ReleaseChannel.Equals(input.ReleaseChannel)
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
                
                if (this.AgentType != null)
                {
                    hashCode = (hashCode * 59) + this.AgentType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ContinueOnError.GetHashCode();
                if (this.LatestVersion != null)
                {
                    hashCode = (hashCode * 59) + this.LatestVersion.GetHashCode();
                }
                if (this.MinimalSupportedVersion != null)
                {
                    hashCode = (hashCode * 59) + this.MinimalSupportedVersion.GetHashCode();
                }
                if (this.PoolId != null)
                {
                    hashCode = (hashCode * 59) + this.PoolId.GetHashCode();
                }
                if (this.PoolName != null)
                {
                    hashCode = (hashCode * 59) + this.PoolName.GetHashCode();
                }
                if (this.ReleaseChannel != null)
                {
                    hashCode = (hashCode * 59) + this.ReleaseChannel.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
