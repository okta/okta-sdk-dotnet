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
    /// Agent details
    /// </summary>
    [DataContract(Name = "Agent")]
    public partial class Agent : IEquatable<Agent>
    {
        
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
        /// Gets or Sets IsHidden
        /// </summary>
        [DataMember(Name = "isHidden", EmitDefaultValue = true)]
        public bool IsHidden { get; set; }

        /// <summary>
        /// Gets or Sets IsLatestGAedVersion
        /// </summary>
        [DataMember(Name = "isLatestGAedVersion", EmitDefaultValue = true)]
        public bool IsLatestGAedVersion { get; set; }

        /// <summary>
        /// Gets or Sets LastConnection
        /// </summary>
        [DataMember(Name = "lastConnection", EmitDefaultValue = false)]
        public DateTimeOffset LastConnection { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Operational status of a given agent
        /// </summary>
        /// <value>Operational status of a given agent</value>
        [DataMember(Name = "operationalStatus", EmitDefaultValue = false)]
        public string OperationalStatus { get; set; }

        /// <summary>
        /// Gets or Sets PoolId
        /// </summary>
        [DataMember(Name = "poolId", EmitDefaultValue = false)]
        public string PoolId { get; set; }

        /// <summary>
        /// Agent types that are being monitored
        /// </summary>
        /// <value>Agent types that are being monitored</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets UpdateMessage
        /// </summary>
        [DataMember(Name = "updateMessage", EmitDefaultValue = false)]
        public string UpdateMessage { get; set; }

        /// <summary>
        /// Status for one agent regarding the status to auto-update that agent
        /// </summary>
        /// <value>Status for one agent regarding the status to auto-update that agent</value>
        [DataMember(Name = "updateStatus", EmitDefaultValue = false)]
        public string UpdateStatus { get; set; }

        /// <summary>
        /// Gets or Sets _Version
        /// </summary>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public string _Version { get; set; }

        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public HrefObject Links { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Agent {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IsHidden: ").Append(IsHidden).Append("\n");
            sb.Append("  IsLatestGAedVersion: ").Append(IsLatestGAedVersion).Append("\n");
            sb.Append("  LastConnection: ").Append(LastConnection).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OperationalStatus: ").Append(OperationalStatus).Append("\n");
            sb.Append("  PoolId: ").Append(PoolId).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  UpdateMessage: ").Append(UpdateMessage).Append("\n");
            sb.Append("  UpdateStatus: ").Append(UpdateStatus).Append("\n");
            sb.Append("  _Version: ").Append(_Version).Append("\n");
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
            return this.Equals(input as Agent);
        }

        /// <summary>
        /// Returns true if Agent instances are equal
        /// </summary>
        /// <param name="input">Instance of Agent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Agent input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.IsHidden == input.IsHidden ||
                    this.IsHidden.Equals(input.IsHidden)
                ) && 
                (
                    this.IsLatestGAedVersion == input.IsLatestGAedVersion ||
                    this.IsLatestGAedVersion.Equals(input.IsLatestGAedVersion)
                ) && 
                (
                    this.LastConnection == input.LastConnection ||
                    (this.LastConnection != null &&
                    this.LastConnection.Equals(input.LastConnection))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.OperationalStatus == input.OperationalStatus ||
                    (this.OperationalStatus != null &&
                    this.OperationalStatus.Equals(input.OperationalStatus))
                ) && 
                (
                    this.PoolId == input.PoolId ||
                    (this.PoolId != null &&
                    this.PoolId.Equals(input.PoolId))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.UpdateMessage == input.UpdateMessage ||
                    (this.UpdateMessage != null &&
                    this.UpdateMessage.Equals(input.UpdateMessage))
                ) && 
                (
                    this.UpdateStatus == input.UpdateStatus ||
                    (this.UpdateStatus != null &&
                    this.UpdateStatus.Equals(input.UpdateStatus))
                ) && 
                (
                    this._Version == input._Version ||
                    (this._Version != null &&
                    this._Version.Equals(input._Version))
                ) && 
                (
                    this.Links == input.Links ||
                    (this.Links != null &&
                    this.Links.Equals(input.Links))
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
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IsHidden.GetHashCode();
                hashCode = (hashCode * 59) + this.IsLatestGAedVersion.GetHashCode();
                if (this.LastConnection != null)
                {
                    hashCode = (hashCode * 59) + this.LastConnection.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.OperationalStatus != null)
                {
                    hashCode = (hashCode * 59) + this.OperationalStatus.GetHashCode();
                }
                if (this.PoolId != null)
                {
                    hashCode = (hashCode * 59) + this.PoolId.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                if (this.UpdateMessage != null)
                {
                    hashCode = (hashCode * 59) + this.UpdateMessage.GetHashCode();
                }
                if (this.UpdateStatus != null)
                {
                    hashCode = (hashCode * 59) + this.UpdateStatus.GetHashCode();
                }
                if (this._Version != null)
                {
                    hashCode = (hashCode * 59) + this._Version.GetHashCode();
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
