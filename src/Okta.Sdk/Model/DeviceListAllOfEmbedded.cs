/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.06.1
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
    /// List of associated users for the device if the &#x60;expand&#x3D;user&#x60; query parameter is specified in the request. Use &#x60;expand&#x3D;userSummary&#x60; to get only a summary of each associated user for the device.
    /// </summary>
    [DataContract(Name = "DeviceList_allOf__embedded")]
    
    public partial class DeviceListAllOfEmbedded : IEquatable<DeviceListAllOfEmbedded>
    {
        
        /// <summary>
        /// Users for the device
        /// </summary>
        /// <value>Users for the device</value>
        [DataMember(Name = "users", EmitDefaultValue = true)]
        public List<DeviceUser> Users { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DeviceListAllOfEmbedded {\n");
            sb.Append("  Users: ").Append(Users).Append("\n");
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
            return this.Equals(input as DeviceListAllOfEmbedded);
        }

        /// <summary>
        /// Returns true if DeviceListAllOfEmbedded instances are equal
        /// </summary>
        /// <param name="input">Instance of DeviceListAllOfEmbedded to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeviceListAllOfEmbedded input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Users == input.Users ||
                    this.Users != null &&
                    input.Users != null &&
                    this.Users.SequenceEqual(input.Users)
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
                
                if (this.Users != null)
                {
                    hashCode = (hashCode * 59) + this.Users.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
