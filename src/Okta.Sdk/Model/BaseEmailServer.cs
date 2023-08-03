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
    /// BaseEmailServer
    /// </summary>
    [DataContract(Name = "BaseEmailServer")]
    
    public partial class BaseEmailServer : IEquatable<BaseEmailServer>
    {
        
        /// <summary>
        /// A name to identify this configuration
        /// </summary>
        /// <value>A name to identify this configuration</value>
        [DataMember(Name = "alias", EmitDefaultValue = true)]
        public string Alias { get; set; }

        /// <summary>
        /// True if and only if all email traffic should be routed through this SMTP Server
        /// </summary>
        /// <value>True if and only if all email traffic should be routed through this SMTP Server</value>
        [DataMember(Name = "enabled", EmitDefaultValue = true)]
        public bool Enabled { get; set; }

        /// <summary>
        /// The address of the SMTP Server
        /// </summary>
        /// <value>The address of the SMTP Server</value>
        [DataMember(Name = "host", EmitDefaultValue = true)]
        public string Host { get; set; }

        /// <summary>
        /// The port number of the SMTP Server
        /// </summary>
        /// <value>The port number of the SMTP Server</value>
        [DataMember(Name = "port", EmitDefaultValue = true)]
        public int Port { get; set; }

        /// <summary>
        /// The username to use with your SMTP Server
        /// </summary>
        /// <value>The username to use with your SMTP Server</value>
        [DataMember(Name = "username", EmitDefaultValue = true)]
        public string Username { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BaseEmailServer {\n");
            sb.Append("  Alias: ").Append(Alias).Append("\n");
            sb.Append("  Enabled: ").Append(Enabled).Append("\n");
            sb.Append("  Host: ").Append(Host).Append("\n");
            sb.Append("  Port: ").Append(Port).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
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
            return this.Equals(input as BaseEmailServer);
        }

        /// <summary>
        /// Returns true if BaseEmailServer instances are equal
        /// </summary>
        /// <param name="input">Instance of BaseEmailServer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BaseEmailServer input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Alias == input.Alias ||
                    (this.Alias != null &&
                    this.Alias.Equals(input.Alias))
                ) && 
                (
                    this.Enabled == input.Enabled ||
                    this.Enabled.Equals(input.Enabled)
                ) && 
                (
                    this.Host == input.Host ||
                    (this.Host != null &&
                    this.Host.Equals(input.Host))
                ) && 
                (
                    this.Port == input.Port ||
                    this.Port.Equals(input.Port)
                ) && 
                (
                    this.Username == input.Username ||
                    (this.Username != null &&
                    this.Username.Equals(input.Username))
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
                
                if (this.Alias != null)
                {
                    hashCode = (hashCode * 59) + this.Alias.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Enabled.GetHashCode();
                if (this.Host != null)
                {
                    hashCode = (hashCode * 59) + this.Host.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Port.GetHashCode();
                if (this.Username != null)
                {
                    hashCode = (hashCode * 59) + this.Username.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
