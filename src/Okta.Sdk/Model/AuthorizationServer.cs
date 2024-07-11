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
    /// AuthorizationServer
    /// </summary>
    [DataContract(Name = "AuthorizationServer")]
    
    public partial class AuthorizationServer : IEquatable<AuthorizationServer>
    {

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = true)]
        
        public LifecycleStatus Status { get; set; }
        
        /// <summary>
        /// The recipients that the tokens are intended for. This becomes the &#x60;aud&#x60; claim in an access token. Okta currently supports only one audience.
        /// </summary>
        /// <value>The recipients that the tokens are intended for. This becomes the &#x60;aud&#x60; claim in an access token. Okta currently supports only one audience.</value>
        [DataMember(Name = "audiences", EmitDefaultValue = true)]
        public List<string> Audiences { get; set; }

        /// <summary>
        /// Gets or Sets Created
        /// </summary>
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
        /// Gets or Sets Credentials
        /// </summary>
        [DataMember(Name = "credentials", EmitDefaultValue = true)]
        public AuthorizationServerCredentials Credentials { get; set; }

        /// <summary>
        /// The description of the custom authorization server
        /// </summary>
        /// <value>The description of the custom authorization server</value>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// The ID of the custom authorization server
        /// </summary>
        /// <value>The ID of the custom authorization server</value>
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
        /// The complete URL for the custom authorization server. This becomes the &#x60;iss&#x60; claim in an access token.
        /// </summary>
        /// <value>The complete URL for the custom authorization server. This becomes the &#x60;iss&#x60; claim in an access token.</value>
        [DataMember(Name = "issuer", EmitDefaultValue = true)]
        public string Issuer { get; set; }

        /// <summary>
        /// Indicates which value is specified in the issuer of the tokens that a custom authorization server returns: the Okta org domain URL or a custom domain URL.  &#x60;issuerMode&#x60; is visible if you have a custom URL domain configured or the Dynamic Issuer Mode feature enabled. If you have a custom URL domain configured, you can set a custom domain URL in a custom authorization server, and this property is returned in the appropriate responses.  When set to &#x60;ORG_URL&#x60;, then in responses, &#x60;issuer&#x60; is the Okta org domain URL: &#x60;https://${yourOktaDomain}&#x60;.  When set to &#x60;CUSTOM_URL&#x60;, then in responses, &#x60;issuer&#x60; is the custom domain URL configured in the administration user interface.  When set to &#x60;DYNAMIC&#x60;, then in responses, &#x60;issuer&#x60; is the custom domain URL if the OAuth 2.0 request was sent to the custom domain, or is the Okta org&#39;s domain URL if the OAuth 2.0 request was sent to the original Okta org domain.  After you configure a custom URL domain, all new custom authorization servers use &#x60;CUSTOM_URL&#x60; by default. If the Dynamic Issuer Mode feature is enabled, then all new custom authorization servers use &#x60;DYNAMIC&#x60; by default. All existing custom authorization servers continue to use the original value until they&#39;re changed using the Admin Console or the API. This way, existing integrations with the client and resource server continue to work after the feature is enabled.
        /// </summary>
        /// <value>Indicates which value is specified in the issuer of the tokens that a custom authorization server returns: the Okta org domain URL or a custom domain URL.  &#x60;issuerMode&#x60; is visible if you have a custom URL domain configured or the Dynamic Issuer Mode feature enabled. If you have a custom URL domain configured, you can set a custom domain URL in a custom authorization server, and this property is returned in the appropriate responses.  When set to &#x60;ORG_URL&#x60;, then in responses, &#x60;issuer&#x60; is the Okta org domain URL: &#x60;https://${yourOktaDomain}&#x60;.  When set to &#x60;CUSTOM_URL&#x60;, then in responses, &#x60;issuer&#x60; is the custom domain URL configured in the administration user interface.  When set to &#x60;DYNAMIC&#x60;, then in responses, &#x60;issuer&#x60; is the custom domain URL if the OAuth 2.0 request was sent to the custom domain, or is the Okta org&#39;s domain URL if the OAuth 2.0 request was sent to the original Okta org domain.  After you configure a custom URL domain, all new custom authorization servers use &#x60;CUSTOM_URL&#x60; by default. If the Dynamic Issuer Mode feature is enabled, then all new custom authorization servers use &#x60;DYNAMIC&#x60; by default. All existing custom authorization servers continue to use the original value until they&#39;re changed using the Admin Console or the API. This way, existing integrations with the client and resource server continue to work after the feature is enabled.</value>
        [DataMember(Name = "issuerMode", EmitDefaultValue = true)]
        public string IssuerMode { get; set; }

        /// <summary>
        /// Gets or Sets LastUpdated
        /// </summary>
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
        /// The name of the custom authorization server
        /// </summary>
        /// <value>The name of the custom authorization server</value>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = true)]
        public AuthServerLinks Links { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthorizationServer {\n");
            sb.Append("  Audiences: ").Append(Audiences).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Credentials: ").Append(Credentials).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Issuer: ").Append(Issuer).Append("\n");
            sb.Append("  IssuerMode: ").Append(IssuerMode).Append("\n");
            sb.Append("  LastUpdated: ").Append(LastUpdated).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
            return this.Equals(input as AuthorizationServer);
        }

        /// <summary>
        /// Returns true if AuthorizationServer instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthorizationServer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthorizationServer input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Audiences == input.Audiences ||
                    this.Audiences != null &&
                    input.Audiences != null &&
                    this.Audiences.SequenceEqual(input.Audiences)
                ) && 
                (
                    this.Created == input.Created ||
                    (this.Created != null &&
                    this.Created.Equals(input.Created))
                ) && 
                (
                    this.Credentials == input.Credentials ||
                    (this.Credentials != null &&
                    this.Credentials.Equals(input.Credentials))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Issuer == input.Issuer ||
                    (this.Issuer != null &&
                    this.Issuer.Equals(input.Issuer))
                ) && 
                (
                    this.IssuerMode == input.IssuerMode ||
                    (this.IssuerMode != null &&
                    this.IssuerMode.Equals(input.IssuerMode))
                ) && 
                (
                    this.LastUpdated == input.LastUpdated ||
                    (this.LastUpdated != null &&
                    this.LastUpdated.Equals(input.LastUpdated))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
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
                
                if (this.Audiences != null)
                {
                    hashCode = (hashCode * 59) + this.Audiences.GetHashCode();
                }
                if (this.Created != null)
                {
                    hashCode = (hashCode * 59) + this.Created.GetHashCode();
                }
                if (this.Credentials != null)
                {
                    hashCode = (hashCode * 59) + this.Credentials.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.Issuer != null)
                {
                    hashCode = (hashCode * 59) + this.Issuer.GetHashCode();
                }
                if (this.IssuerMode != null)
                {
                    hashCode = (hashCode * 59) + this.IssuerMode.GetHashCode();
                }
                if (this.LastUpdated != null)
                {
                    hashCode = (hashCode * 59) + this.LastUpdated.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Status != null)
                {
                    hashCode = (hashCode * 59) + this.Status.GetHashCode();
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
