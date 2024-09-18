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
    /// DeviceList
    /// </summary>
    [DataContract(Name = "DeviceList")]
    
    public partial class DeviceList : IEquatable<DeviceList>
    {

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = true)]
        
        public DeviceStatus Status { get; set; }
        
        /// <summary>
        /// Timestamp when the device was created
        /// </summary>
        /// <value>Timestamp when the device was created</value>
        [DataMember(Name = "created", EmitDefaultValue = true)]
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
        /// Unique key for the device
        /// </summary>
        /// <value>Unique key for the device</value>
        [DataMember(Name = "id", EmitDefaultValue = true)]
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
        /// Timestamp when the device record was last updated. Updates occur when Okta collects and saves device signals during authentication, and when the lifecycle state of the device changes.
        /// </summary>
        /// <value>Timestamp when the device record was last updated. Updates occur when Okta collects and saves device signals during authentication, and when the lifecycle state of the device changes.</value>
        [DataMember(Name = "lastUpdated", EmitDefaultValue = true)]
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
        /// Gets or Sets Profile
        /// </summary>
        [DataMember(Name = "profile", EmitDefaultValue = true)]
        public DeviceProfile Profile { get; set; }

        /// <summary>
        /// Gets or Sets ResourceAlternateId
        /// </summary>
        [DataMember(Name = "resourceAlternateId", EmitDefaultValue = true)]
        public string ResourceAlternateId { get; private set; }

        /// <summary>
        /// Returns false as ResourceAlternateId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeResourceAlternateId()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets ResourceDisplayName
        /// </summary>
        [DataMember(Name = "resourceDisplayName", EmitDefaultValue = true)]
        public DeviceDisplayName ResourceDisplayName { get; set; }

        /// <summary>
        /// Alternate key for the &#x60;id&#x60;
        /// </summary>
        /// <value>Alternate key for the &#x60;id&#x60;</value>
        [DataMember(Name = "resourceId", EmitDefaultValue = true)]
        public string ResourceId { get; private set; }

        /// <summary>
        /// Returns false as ResourceId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeResourceId()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets ResourceType
        /// </summary>
        [DataMember(Name = "resourceType", EmitDefaultValue = true)]
        public string ResourceType { get; private set; }

        /// <summary>
        /// Returns false as ResourceType should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeResourceType()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = true)]
        public LinksSelfAndFullUsersLifecycle Links { get; set; }

        /// <summary>
        /// Gets or Sets Embedded
        /// </summary>
        [DataMember(Name = "_embedded", EmitDefaultValue = true)]
        public DeviceListAllOfEmbedded Embedded { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DeviceList {\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastUpdated: ").Append(LastUpdated).Append("\n");
            sb.Append("  Profile: ").Append(Profile).Append("\n");
            sb.Append("  ResourceAlternateId: ").Append(ResourceAlternateId).Append("\n");
            sb.Append("  ResourceDisplayName: ").Append(ResourceDisplayName).Append("\n");
            sb.Append("  ResourceId: ").Append(ResourceId).Append("\n");
            sb.Append("  ResourceType: ").Append(ResourceType).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Links: ").Append(Links).Append("\n");
            sb.Append("  Embedded: ").Append(Embedded).Append("\n");
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
            return this.Equals(input as DeviceList);
        }

        /// <summary>
        /// Returns true if DeviceList instances are equal
        /// </summary>
        /// <param name="input">Instance of DeviceList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeviceList input)
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
                    this.Profile == input.Profile ||
                    (this.Profile != null &&
                    this.Profile.Equals(input.Profile))
                ) && 
                (
                    this.ResourceAlternateId == input.ResourceAlternateId ||
                    (this.ResourceAlternateId != null &&
                    this.ResourceAlternateId.Equals(input.ResourceAlternateId))
                ) && 
                (
                    this.ResourceDisplayName == input.ResourceDisplayName ||
                    (this.ResourceDisplayName != null &&
                    this.ResourceDisplayName.Equals(input.ResourceDisplayName))
                ) && 
                (
                    this.ResourceId == input.ResourceId ||
                    (this.ResourceId != null &&
                    this.ResourceId.Equals(input.ResourceId))
                ) && 
                (
                    this.ResourceType == input.ResourceType ||
                    (this.ResourceType != null &&
                    this.ResourceType.Equals(input.ResourceType))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Links == input.Links ||
                    (this.Links != null &&
                    this.Links.Equals(input.Links))
                ) && 
                (
                    this.Embedded == input.Embedded ||
                    (this.Embedded != null &&
                    this.Embedded.Equals(input.Embedded))
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
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.LastUpdated != null)
                {
                    hashCode = (hashCode * 59) + this.LastUpdated.GetHashCode();
                }
                if (this.Profile != null)
                {
                    hashCode = (hashCode * 59) + this.Profile.GetHashCode();
                }
                if (this.ResourceAlternateId != null)
                {
                    hashCode = (hashCode * 59) + this.ResourceAlternateId.GetHashCode();
                }
                if (this.ResourceDisplayName != null)
                {
                    hashCode = (hashCode * 59) + this.ResourceDisplayName.GetHashCode();
                }
                if (this.ResourceId != null)
                {
                    hashCode = (hashCode * 59) + this.ResourceId.GetHashCode();
                }
                if (this.ResourceType != null)
                {
                    hashCode = (hashCode * 59) + this.ResourceType.GetHashCode();
                }
                if (this.Status != null)
                {
                    hashCode = (hashCode * 59) + this.Status.GetHashCode();
                }
                if (this.Links != null)
                {
                    hashCode = (hashCode * 59) + this.Links.GetHashCode();
                }
                if (this.Embedded != null)
                {
                    hashCode = (hashCode * 59) + this.Embedded.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}