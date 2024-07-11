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
    /// The Network Condition of the API Token
    /// </summary>
    [DataContract(Name = "ApiToken_network")]
    
    public partial class ApiTokenNetwork : IEquatable<ApiTokenNetwork>
    {
        
        /// <summary>
        /// The connection type of the Network Condition
        /// </summary>
        /// <value>The connection type of the Network Condition</value>
        [DataMember(Name = "connection", EmitDefaultValue = true)]
        public string Connection { get; set; }

        /// <summary>
        /// List of included IP network zones
        /// </summary>
        /// <value>List of included IP network zones</value>
        [DataMember(Name = "include", EmitDefaultValue = true)]
        public List<string> Include { get; set; }

        /// <summary>
        /// List of excluded IP network zones
        /// </summary>
        /// <value>List of excluded IP network zones</value>
        [DataMember(Name = "exclude", EmitDefaultValue = true)]
        public List<string> Exclude { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ApiTokenNetwork {\n");
            sb.Append("  Connection: ").Append(Connection).Append("\n");
            sb.Append("  Include: ").Append(Include).Append("\n");
            sb.Append("  Exclude: ").Append(Exclude).Append("\n");
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
            return this.Equals(input as ApiTokenNetwork);
        }

        /// <summary>
        /// Returns true if ApiTokenNetwork instances are equal
        /// </summary>
        /// <param name="input">Instance of ApiTokenNetwork to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiTokenNetwork input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Connection == input.Connection ||
                    (this.Connection != null &&
                    this.Connection.Equals(input.Connection))
                ) && 
                (
                    this.Include == input.Include ||
                    this.Include != null &&
                    input.Include != null &&
                    this.Include.SequenceEqual(input.Include)
                ) && 
                (
                    this.Exclude == input.Exclude ||
                    this.Exclude != null &&
                    input.Exclude != null &&
                    this.Exclude.SequenceEqual(input.Exclude)
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
                
                if (this.Connection != null)
                {
                    hashCode = (hashCode * 59) + this.Connection.GetHashCode();
                }
                if (this.Include != null)
                {
                    hashCode = (hashCode * 59) + this.Include.GetHashCode();
                }
                if (this.Exclude != null)
                {
                    hashCode = (hashCode * 59) + this.Exclude.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
