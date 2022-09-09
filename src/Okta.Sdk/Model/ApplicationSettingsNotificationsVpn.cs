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
    /// ApplicationSettingsNotificationsVpn
    /// </summary>
    [DataContract(Name = "ApplicationSettingsNotificationsVpn")]
    
    public partial class ApplicationSettingsNotificationsVpn : IEquatable<ApplicationSettingsNotificationsVpn>
    {
        
        /// <summary>
        /// Gets or Sets HelpUrl
        /// </summary>
        [DataMember(Name = "helpUrl", EmitDefaultValue = false)]
        public string HelpUrl { get; set; }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets Network
        /// </summary>
        [DataMember(Name = "network", EmitDefaultValue = false)]
        public ApplicationSettingsNotificationsVpnNetwork Network { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ApplicationSettingsNotificationsVpn {\n");
            sb.Append("  HelpUrl: ").Append(HelpUrl).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Network: ").Append(Network).Append("\n");
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
            return this.Equals(input as ApplicationSettingsNotificationsVpn);
        }

        /// <summary>
        /// Returns true if ApplicationSettingsNotificationsVpn instances are equal
        /// </summary>
        /// <param name="input">Instance of ApplicationSettingsNotificationsVpn to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApplicationSettingsNotificationsVpn input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.HelpUrl == input.HelpUrl ||
                    (this.HelpUrl != null &&
                    this.HelpUrl.Equals(input.HelpUrl))
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.Network == input.Network ||
                    (this.Network != null &&
                    this.Network.Equals(input.Network))
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
                
                if (this.HelpUrl != null)
                {
                    hashCode = (hashCode * 59) + this.HelpUrl.GetHashCode();
                }
                if (this.Message != null)
                {
                    hashCode = (hashCode * 59) + this.Message.GetHashCode();
                }
                if (this.Network != null)
                {
                    hashCode = (hashCode * 59) + this.Network.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
