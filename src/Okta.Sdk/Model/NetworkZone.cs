/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 5.1.0
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
    /// NetworkZone
    /// </summary>
    [DataContract(Name = "NetworkZone")]
    
    public partial class NetworkZone : IEquatable<NetworkZone>
    {
        /// <summary>
        /// Dynamic network zone property: the proxy type used
        /// </summary>
        /// <value>Dynamic network zone property: the proxy type used</value>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class ProxyTypeEnum : StringEnum
        {
            /// <summary>
            /// StringEnum Null for value: null
            /// </summary>
            
            public static ProxyTypeEnum Null = new ProxyTypeEnum("null");

            /// <summary>
            /// StringEnum Any for value: Any
            /// </summary>
            
            public static ProxyTypeEnum Any = new ProxyTypeEnum("Any");

            /// <summary>
            /// StringEnum Tor for value: Tor
            /// </summary>
            
            public static ProxyTypeEnum Tor = new ProxyTypeEnum("Tor");

            /// <summary>
            /// StringEnum NotTorAnonymizer for value: NotTorAnonymizer
            /// </summary>
            
            public static ProxyTypeEnum NotTorAnonymizer = new ProxyTypeEnum("NotTorAnonymizer");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="ProxyTypeEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator ProxyTypeEnum(string value) => new ProxyTypeEnum(value);

            /// <summary>
            /// Creates a new <see cref="ProxyType"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public ProxyTypeEnum(string value)
                : base(value)
            {
            }
        }


        /// <summary>
        /// Dynamic network zone property: the proxy type used
        /// </summary>
        /// <value>Dynamic network zone property: the proxy type used</value>
        [DataMember(Name = "proxyType", EmitDefaultValue = true)]
        
        public ProxyTypeEnum ProxyType { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = true)]
        
        public NetworkZoneStatus Status { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = true)]
        
        public NetworkZoneType Type { get; set; }

        /// <summary>
        /// Gets or Sets Usage
        /// </summary>
        [DataMember(Name = "usage", EmitDefaultValue = true)]
        
        public NetworkZoneUsage Usage { get; set; }
        
        /// <summary>
        /// Dynamic network zone property. array of strings that represent an ASN numeric value
        /// </summary>
        /// <value>Dynamic network zone property. array of strings that represent an ASN numeric value</value>
        [DataMember(Name = "asns", EmitDefaultValue = true)]
        public List<string> Asns { get; set; }

        /// <summary>
        /// Timestamp when the network zone was created
        /// </summary>
        /// <value>Timestamp when the network zone was created</value>
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
        /// IP network zone property: the IP addresses (range or CIDR form) of this zone. The maximum array length is 150 entries for admin-created IP zones, 1000 entries for IP blocklist zones, and 5000 entries for the default system IP Zone.
        /// </summary>
        /// <value>IP network zone property: the IP addresses (range or CIDR form) of this zone. The maximum array length is 150 entries for admin-created IP zones, 1000 entries for IP blocklist zones, and 5000 entries for the default system IP Zone.</value>
        [DataMember(Name = "gateways", EmitDefaultValue = true)]
        public List<NetworkZoneAddress> Gateways { get; set; }

        /// <summary>
        /// Unique identifier for the network zone
        /// </summary>
        /// <value>Unique identifier for the network zone</value>
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
        /// Timestamp when the network zone was last modified
        /// </summary>
        /// <value>Timestamp when the network zone was last modified</value>
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
        /// Dynamic network zone property: an array of geolocations of this network zone
        /// </summary>
        /// <value>Dynamic network zone property: an array of geolocations of this network zone</value>
        [DataMember(Name = "locations", EmitDefaultValue = true)]
        public List<NetworkZoneLocation> Locations { get; set; }

        /// <summary>
        /// Unique name for this network zone. Maximum of 128 characters.
        /// </summary>
        /// <value>Unique name for this network zone. Maximum of 128 characters.</value>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// IP network zone property: the IP addresses (range or CIDR form) that are allowed to forward a request from gateway addresses These proxies are automatically trusted by Threat Insights, and used to identify the client IP of a request. The maximum array length is 150 entries for admin-created zones and 5000 entries for the default system IP Zone.
        /// </summary>
        /// <value>IP network zone property: the IP addresses (range or CIDR form) that are allowed to forward a request from gateway addresses These proxies are automatically trusted by Threat Insights, and used to identify the client IP of a request. The maximum array length is 150 entries for admin-created zones and 5000 entries for the default system IP Zone.</value>
        [DataMember(Name = "proxies", EmitDefaultValue = true)]
        public List<NetworkZoneAddress> Proxies { get; set; }

        /// <summary>
        /// Indicates if this is a system network zone. For admin-created zones, this is always &#x60;false&#x60;. The system IP Policy Network Zone (&#x60;LegacyIpZone&#x60;) is included by default in your Okta org. Notice that &#x60;system&#x3D;true&#x60; for the &#x60;LegacyIpZone&#x60; object. Admin users can modify the name of this default system Zone and can add up to 5000 gateway or proxy IP entries.
        /// </summary>
        /// <value>Indicates if this is a system network zone. For admin-created zones, this is always &#x60;false&#x60;. The system IP Policy Network Zone (&#x60;LegacyIpZone&#x60;) is included by default in your Okta org. Notice that &#x60;system&#x3D;true&#x60; for the &#x60;LegacyIpZone&#x60; object. Admin users can modify the name of this default system Zone and can add up to 5000 gateway or proxy IP entries.</value>
        [DataMember(Name = "system", EmitDefaultValue = true)]
        public bool System { get; set; }

        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = true)]
        public NetworkZoneLinks Links { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class NetworkZone {\n");
            sb.Append("  Asns: ").Append(Asns).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Gateways: ").Append(Gateways).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastUpdated: ").Append(LastUpdated).Append("\n");
            sb.Append("  Locations: ").Append(Locations).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Proxies: ").Append(Proxies).Append("\n");
            sb.Append("  ProxyType: ").Append(ProxyType).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  System: ").Append(System).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Usage: ").Append(Usage).Append("\n");
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
            return this.Equals(input as NetworkZone);
        }

        /// <summary>
        /// Returns true if NetworkZone instances are equal
        /// </summary>
        /// <param name="input">Instance of NetworkZone to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NetworkZone input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Asns == input.Asns ||
                    this.Asns != null &&
                    input.Asns != null &&
                    this.Asns.SequenceEqual(input.Asns)
                ) && 
                (
                    this.Created == input.Created ||
                    (this.Created != null &&
                    this.Created.Equals(input.Created))
                ) && 
                (
                    this.Gateways == input.Gateways ||
                    this.Gateways != null &&
                    input.Gateways != null &&
                    this.Gateways.SequenceEqual(input.Gateways)
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
                    this.Locations == input.Locations ||
                    this.Locations != null &&
                    input.Locations != null &&
                    this.Locations.SequenceEqual(input.Locations)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Proxies == input.Proxies ||
                    this.Proxies != null &&
                    input.Proxies != null &&
                    this.Proxies.SequenceEqual(input.Proxies)
                ) && 
                (
                    this.ProxyType == input.ProxyType ||
                    this.ProxyType.Equals(input.ProxyType)
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.System == input.System ||
                    this.System.Equals(input.System)
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.Usage == input.Usage ||
                    this.Usage.Equals(input.Usage)
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
                
                if (this.Asns != null)
                {
                    hashCode = (hashCode * 59) + this.Asns.GetHashCode();
                }
                if (this.Created != null)
                {
                    hashCode = (hashCode * 59) + this.Created.GetHashCode();
                }
                if (this.Gateways != null)
                {
                    hashCode = (hashCode * 59) + this.Gateways.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.LastUpdated != null)
                {
                    hashCode = (hashCode * 59) + this.LastUpdated.GetHashCode();
                }
                if (this.Locations != null)
                {
                    hashCode = (hashCode * 59) + this.Locations.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Proxies != null)
                {
                    hashCode = (hashCode * 59) + this.Proxies.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ProxyType.GetHashCode();
                hashCode = (hashCode * 59) + this.Status.GetHashCode();
                hashCode = (hashCode * 59) + this.System.GetHashCode();
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                hashCode = (hashCode * 59) + this.Usage.GetHashCode();
                if (this.Links != null)
                {
                    hashCode = (hashCode * 59) + this.Links.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
