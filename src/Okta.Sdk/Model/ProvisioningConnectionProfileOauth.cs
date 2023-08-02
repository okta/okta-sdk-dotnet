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
    /// The app provisioning connection profile used to configure the method of authentication and the credentials. Currently, token-based and OAuth 2.0-based authentication are supported. 
    /// </summary>
    [DataContract(Name = "ProvisioningConnectionProfileOauth")]
    
    public partial class ProvisioningConnectionProfileOauth : IEquatable<ProvisioningConnectionProfileOauth>
    {

        /// <summary>
        /// Gets or Sets AuthScheme
        /// </summary>
        [DataMember(Name = "authScheme", IsRequired = true, EmitDefaultValue = false)]
        
        public ProvisioningConnectionAuthSchemeRequest AuthScheme { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisioningConnectionProfileOauth" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public ProvisioningConnectionProfileOauth() { }
        
        /// <summary>
        /// Unique client identifier for the OAuth 2.0 service app from the target org
        /// </summary>
        /// <value>Unique client identifier for the OAuth 2.0 service app from the target org</value>
        [DataMember(Name = "clientId", IsRequired = true, EmitDefaultValue = false)]
        public string ClientId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ProvisioningConnectionProfileOauth {\n");
            sb.Append("  AuthScheme: ").Append(AuthScheme).Append("\n");
            sb.Append("  ClientId: ").Append(ClientId).Append("\n");
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
            return this.Equals(input as ProvisioningConnectionProfileOauth);
        }

        /// <summary>
        /// Returns true if ProvisioningConnectionProfileOauth instances are equal
        /// </summary>
        /// <param name="input">Instance of ProvisioningConnectionProfileOauth to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProvisioningConnectionProfileOauth input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AuthScheme == input.AuthScheme ||
                    this.AuthScheme.Equals(input.AuthScheme)
                ) && 
                (
                    this.ClientId == input.ClientId ||
                    (this.ClientId != null &&
                    this.ClientId.Equals(input.ClientId))
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
                
                hashCode = (hashCode * 59) + this.AuthScheme.GetHashCode();
                if (this.ClientId != null)
                {
                    hashCode = (hashCode * 59) + this.ClientId.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
