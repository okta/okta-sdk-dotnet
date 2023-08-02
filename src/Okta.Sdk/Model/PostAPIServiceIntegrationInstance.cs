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
    /// PostAPIServiceIntegrationInstance
    /// </summary>
    [DataContract(Name = "postAPIServiceIntegrationInstance")]
    
    public partial class PostAPIServiceIntegrationInstance : IEquatable<PostAPIServiceIntegrationInstance>
    {
        
        /// <summary>
        /// The URL to the API service integration configuration guide
        /// </summary>
        /// <value>The URL to the API service integration configuration guide</value>
        [DataMember(Name = "configGuideUrl", EmitDefaultValue = false)]
        public string ConfigGuideUrl { get; private set; }

        /// <summary>
        /// Returns false as ConfigGuideUrl should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeConfigGuideUrl()
        {
            return false;
        }
        /// <summary>
        /// Timestamp when the API Service Integration instance was created
        /// </summary>
        /// <value>Timestamp when the API Service Integration instance was created</value>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public string CreatedAt { get; private set; }

        /// <summary>
        /// Returns false as CreatedAt should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCreatedAt()
        {
            return false;
        }
        /// <summary>
        /// The user ID of the API Service Integration instance creator
        /// </summary>
        /// <value>The user ID of the API Service Integration instance creator</value>
        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        public string CreatedBy { get; private set; }

        /// <summary>
        /// Returns false as CreatedBy should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCreatedBy()
        {
            return false;
        }
        /// <summary>
        /// The list of Okta management scopes granted to the API Service Integration instance. See [Okta management OAuth 2.0 scopes](/oauth2/#okta-admin-management).
        /// </summary>
        /// <value>The list of Okta management scopes granted to the API Service Integration instance. See [Okta management OAuth 2.0 scopes](/oauth2/#okta-admin-management).</value>
        [DataMember(Name = "grantedScopes", EmitDefaultValue = false)]
        public List<string> GrantedScopes { get; set; }

        /// <summary>
        /// The ID of the API Service Integration instance
        /// </summary>
        /// <value>The ID of the API Service Integration instance</value>
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
        /// The name of the API service integration that corresponds with the &#x60;type&#x60; property. This is the full name of the API service integration listed in the Okta Integration Network (OIN) catalog.
        /// </summary>
        /// <value>The name of the API service integration that corresponds with the &#x60;type&#x60; property. This is the full name of the API service integration listed in the Okta Integration Network (OIN) catalog.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; private set; }

        /// <summary>
        /// Returns false as Name should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeName()
        {
            return false;
        }
        /// <summary>
        /// The type of the API service integration. This string is an underscore-concatenated, lowercased API service integration name. For example, &#x60;my_api_log_integration&#x60;.
        /// </summary>
        /// <value>The type of the API service integration. This string is an underscore-concatenated, lowercased API service integration name. For example, &#x60;my_api_log_integration&#x60;.</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public APIServiceIntegrationLinks Links { get; set; }

        /// <summary>
        /// The client secret for the API Service Integration instance. This property is only returned in a POST response.
        /// </summary>
        /// <value>The client secret for the API Service Integration instance. This property is only returned in a POST response.</value>
        [DataMember(Name = "clientSecret", EmitDefaultValue = false)]
        public string ClientSecret { get; private set; }

        /// <summary>
        /// Returns false as ClientSecret should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeClientSecret()
        {
            return false;
        }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PostAPIServiceIntegrationInstance {\n");
            sb.Append("  ConfigGuideUrl: ").Append(ConfigGuideUrl).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  GrantedScopes: ").Append(GrantedScopes).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Links: ").Append(Links).Append("\n");
            sb.Append("  ClientSecret: ").Append(ClientSecret).Append("\n");
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
            return this.Equals(input as PostAPIServiceIntegrationInstance);
        }

        /// <summary>
        /// Returns true if PostAPIServiceIntegrationInstance instances are equal
        /// </summary>
        /// <param name="input">Instance of PostAPIServiceIntegrationInstance to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PostAPIServiceIntegrationInstance input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ConfigGuideUrl == input.ConfigGuideUrl ||
                    (this.ConfigGuideUrl != null &&
                    this.ConfigGuideUrl.Equals(input.ConfigGuideUrl))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.GrantedScopes == input.GrantedScopes ||
                    this.GrantedScopes != null &&
                    input.GrantedScopes != null &&
                    this.GrantedScopes.SequenceEqual(input.GrantedScopes)
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Links == input.Links ||
                    (this.Links != null &&
                    this.Links.Equals(input.Links))
                ) && 
                (
                    this.ClientSecret == input.ClientSecret ||
                    (this.ClientSecret != null &&
                    this.ClientSecret.Equals(input.ClientSecret))
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
                
                if (this.ConfigGuideUrl != null)
                {
                    hashCode = (hashCode * 59) + this.ConfigGuideUrl.GetHashCode();
                }
                if (this.CreatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                }
                if (this.CreatedBy != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedBy.GetHashCode();
                }
                if (this.GrantedScopes != null)
                {
                    hashCode = (hashCode * 59) + this.GrantedScopes.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                if (this.Links != null)
                {
                    hashCode = (hashCode * 59) + this.Links.GetHashCode();
                }
                if (this.ClientSecret != null)
                {
                    hashCode = (hashCode * 59) + this.ClientSecret.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
