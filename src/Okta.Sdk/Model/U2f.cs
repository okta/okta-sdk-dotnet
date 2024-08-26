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
    /// Activates a &#x60;u2f&#x60; Factor with the specified client and registration information from the U2F token
    /// </summary>
    [DataContract(Name = "u2f")]
    
    public partial class U2f : IEquatable<U2f>
    {
        
        /// <summary>
        /// Base64-encoded client data from the U2F token
        /// </summary>
        /// <value>Base64-encoded client data from the U2F token</value>
        [DataMember(Name = "clientData", EmitDefaultValue = true)]
        public string ClientData { get; set; }

        /// <summary>
        /// Base64-encoded registration data from the U2F token
        /// </summary>
        /// <value>Base64-encoded registration data from the U2F token</value>
        [DataMember(Name = "registrationData", EmitDefaultValue = true)]
        public string RegistrationData { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class U2f {\n");
            sb.Append("  ClientData: ").Append(ClientData).Append("\n");
            sb.Append("  RegistrationData: ").Append(RegistrationData).Append("\n");
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
            return this.Equals(input as U2f);
        }

        /// <summary>
        /// Returns true if U2f instances are equal
        /// </summary>
        /// <param name="input">Instance of U2f to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(U2f input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ClientData == input.ClientData ||
                    (this.ClientData != null &&
                    this.ClientData.Equals(input.ClientData))
                ) && 
                (
                    this.RegistrationData == input.RegistrationData ||
                    (this.RegistrationData != null &&
                    this.RegistrationData.Equals(input.RegistrationData))
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
                
                if (this.ClientData != null)
                {
                    hashCode = (hashCode * 59) + this.ClientData.GetHashCode();
                }
                if (this.RegistrationData != null)
                {
                    hashCode = (hashCode * 59) + this.RegistrationData.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}