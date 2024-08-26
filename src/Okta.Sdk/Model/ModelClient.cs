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
    /// ModelClient
    /// </summary>
    [DataContract(Name = "_Client")]
    
    public partial class ModelClient : IEquatable<ModelClient>
    {

        /// <summary>
        /// Gets or Sets ApplicationType
        /// </summary>
        [DataMember(Name = "application_type", EmitDefaultValue = true)]
        
        public ApplicationType ApplicationType { get; set; }

        /// <summary>
        /// Gets or Sets TokenEndpointAuthMethod
        /// </summary>
        [DataMember(Name = "token_endpoint_auth_method", EmitDefaultValue = true)]
        
        public EndpointAuthMethod TokenEndpointAuthMethod { get; set; }
        
        /// <summary>
        /// Unique key for the client application. The &#x60;client_id&#x60; is immutable. When you create a client Application, you can&#39;t specify the &#x60;client_id&#x60; because Okta uses the application ID for the &#x60;client_id&#x60;.
        /// </summary>
        /// <value>Unique key for the client application. The &#x60;client_id&#x60; is immutable. When you create a client Application, you can&#39;t specify the &#x60;client_id&#x60; because Okta uses the application ID for the &#x60;client_id&#x60;.</value>
        [DataMember(Name = "client_id", EmitDefaultValue = true)]
        public string ClientId { get; private set; }

        /// <summary>
        /// Returns false as ClientId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeClientId()
        {
            return false;
        }
        /// <summary>
        /// Time at which the &#x60;client_id&#x60; was issued (measured in unix seconds)
        /// </summary>
        /// <value>Time at which the &#x60;client_id&#x60; was issued (measured in unix seconds)</value>
        [DataMember(Name = "client_id_issued_at", EmitDefaultValue = true)]
        public int ClientIdIssuedAt { get; private set; }

        /// <summary>
        /// Returns false as ClientIdIssuedAt should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeClientIdIssuedAt()
        {
            return false;
        }
        /// <summary>
        /// Human-readable string name of the client application
        /// </summary>
        /// <value>Human-readable string name of the client application</value>
        [DataMember(Name = "client_name", EmitDefaultValue = true)]
        public string ClientName { get; set; }

        /// <summary>
        /// OAuth 2.0 client secret string (used for confidential clients). The &#x60;client_secret&#x60; is shown only on the response of the creation or update of a client Application (and only if the &#x60;token_endpoint_auth_method&#x60; is one that requires a client secret). You can&#39;t specify the &#x60;client_secret&#x60;. If the &#x60;token_endpoint_auth_method&#x60; requires one, Okta generates a random &#x60;client_secret&#x60; for the client Application.
        /// </summary>
        /// <value>OAuth 2.0 client secret string (used for confidential clients). The &#x60;client_secret&#x60; is shown only on the response of the creation or update of a client Application (and only if the &#x60;token_endpoint_auth_method&#x60; is one that requires a client secret). You can&#39;t specify the &#x60;client_secret&#x60;. If the &#x60;token_endpoint_auth_method&#x60; requires one, Okta generates a random &#x60;client_secret&#x60; for the client Application.</value>
        [DataMember(Name = "client_secret", EmitDefaultValue = true)]
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
        /// Time at which the &#x60;client_secret&#x60; expires or 0 if it doesn&#39;t expire (measured in unix seconds)
        /// </summary>
        /// <value>Time at which the &#x60;client_secret&#x60; expires or 0 if it doesn&#39;t expire (measured in unix seconds)</value>
        [DataMember(Name = "client_secret_expires_at", EmitDefaultValue = true)]
        public int? ClientSecretExpiresAt { get; private set; }

        /// <summary>
        /// Returns false as ClientSecretExpiresAt should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeClientSecretExpiresAt()
        {
            return false;
        }
        /// <summary>
        /// Include user session details
        /// </summary>
        /// <value>Include user session details</value>
        [DataMember(Name = "frontchannel_logout_session_required", EmitDefaultValue = true)]
        public bool FrontchannelLogoutSessionRequired { get; set; }

        /// <summary>
        /// URL where Okta sends the logout request
        /// </summary>
        /// <value>URL where Okta sends the logout request</value>
        [DataMember(Name = "frontchannel_logout_uri", EmitDefaultValue = true)]
        public string FrontchannelLogoutUri { get; set; }

        /// <summary>
        /// Array of OAuth 2.0 grant type strings. Default value: &#x60;[authorization_code]&#x60;
        /// </summary>
        /// <value>Array of OAuth 2.0 grant type strings. Default value: &#x60;[authorization_code]&#x60;</value>
        [DataMember(Name = "grant_types", EmitDefaultValue = true)]
        public List<GrantType> GrantTypes { get; set; }

        /// <summary>
        /// URL that a third party can use to initiate a login by the client
        /// </summary>
        /// <value>URL that a third party can use to initiate a login by the client</value>
        [DataMember(Name = "initiate_login_uri", EmitDefaultValue = true)]
        public string InitiateLoginUri { get; set; }

        /// <summary>
        /// URL string that references a [JSON Web Key Set](https://tools.ietf.org/html/rfc7517#section-5) for validating JWTs presented to Okta
        /// </summary>
        /// <value>URL string that references a [JSON Web Key Set](https://tools.ietf.org/html/rfc7517#section-5) for validating JWTs presented to Okta</value>
        [DataMember(Name = "jwks_uri", EmitDefaultValue = true)]
        public string JwksUri { get; set; }

        /// <summary>
        /// URL string that references a logo for the client consent dialog (not the sign-in dialog)
        /// </summary>
        /// <value>URL string that references a logo for the client consent dialog (not the sign-in dialog)</value>
        [DataMember(Name = "logo_uri", EmitDefaultValue = true)]
        public string LogoUri { get; set; }

        /// <summary>
        /// URL string of a web page providing the client&#39;s policy document
        /// </summary>
        /// <value>URL string of a web page providing the client&#39;s policy document</value>
        [DataMember(Name = "policy_uri", EmitDefaultValue = true)]
        public string PolicyUri { get; set; }

        /// <summary>
        /// Array of redirection URI strings for use for relying party initiated logouts
        /// </summary>
        /// <value>Array of redirection URI strings for use for relying party initiated logouts</value>
        [DataMember(Name = "post_logout_redirect_uris", EmitDefaultValue = true)]
        public List<string> PostLogoutRedirectUris { get; set; }

        /// <summary>
        /// Array of redirection URI strings for use in redirect-based flows. All redirect URIs must be absolute URIs and must not include a fragment component. At least one redirect URI and response type is required for all client types, with the following exceptions: If the client uses the Resource Owner Password flow (if &#x60;grant_type&#x60; contains the value password) or the Client Credentials flow (if &#x60;grant_type&#x60; contains the value &#x60;client_credentials&#x60;), then no redirect URI or response type is necessary. In these cases, you can pass either null or an empty array for these attributes.
        /// </summary>
        /// <value>Array of redirection URI strings for use in redirect-based flows. All redirect URIs must be absolute URIs and must not include a fragment component. At least one redirect URI and response type is required for all client types, with the following exceptions: If the client uses the Resource Owner Password flow (if &#x60;grant_type&#x60; contains the value password) or the Client Credentials flow (if &#x60;grant_type&#x60; contains the value &#x60;client_credentials&#x60;), then no redirect URI or response type is necessary. In these cases, you can pass either null or an empty array for these attributes.</value>
        [DataMember(Name = "redirect_uris", EmitDefaultValue = true)]
        public List<string> RedirectUris { get; set; }

        /// <summary>
        /// The type of [JSON Web Key Set](https://tools.ietf.org/html/rfc7517#section-5) algorithm that must be used for signing request objects
        /// </summary>
        /// <value>The type of [JSON Web Key Set](https://tools.ietf.org/html/rfc7517#section-5) algorithm that must be used for signing request objects</value>
        [DataMember(Name = "request_object_signing_alg", EmitDefaultValue = true)]
        public List<SigningAlgorithm> RequestObjectSigningAlg { get; set; }

        /// <summary>
        /// Array of OAuth 2.0 response type strings. Default value: &#x60;[code]&#x60;
        /// </summary>
        /// <value>Array of OAuth 2.0 response type strings. Default value: &#x60;[code]&#x60;</value>
        [DataMember(Name = "response_types", EmitDefaultValue = true)]
        public List<ResponseType> ResponseTypes { get; set; }

        /// <summary>
        /// URL string of a web page providing the client&#39;s terms of service document
        /// </summary>
        /// <value>URL string of a web page providing the client&#39;s terms of service document</value>
        [DataMember(Name = "tos_uri", EmitDefaultValue = true)]
        public string TosUri { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ModelClient {\n");
            sb.Append("  ApplicationType: ").Append(ApplicationType).Append("\n");
            sb.Append("  ClientId: ").Append(ClientId).Append("\n");
            sb.Append("  ClientIdIssuedAt: ").Append(ClientIdIssuedAt).Append("\n");
            sb.Append("  ClientName: ").Append(ClientName).Append("\n");
            sb.Append("  ClientSecret: ").Append(ClientSecret).Append("\n");
            sb.Append("  ClientSecretExpiresAt: ").Append(ClientSecretExpiresAt).Append("\n");
            sb.Append("  FrontchannelLogoutSessionRequired: ").Append(FrontchannelLogoutSessionRequired).Append("\n");
            sb.Append("  FrontchannelLogoutUri: ").Append(FrontchannelLogoutUri).Append("\n");
            sb.Append("  GrantTypes: ").Append(GrantTypes).Append("\n");
            sb.Append("  InitiateLoginUri: ").Append(InitiateLoginUri).Append("\n");
            sb.Append("  JwksUri: ").Append(JwksUri).Append("\n");
            sb.Append("  LogoUri: ").Append(LogoUri).Append("\n");
            sb.Append("  PolicyUri: ").Append(PolicyUri).Append("\n");
            sb.Append("  PostLogoutRedirectUris: ").Append(PostLogoutRedirectUris).Append("\n");
            sb.Append("  RedirectUris: ").Append(RedirectUris).Append("\n");
            sb.Append("  RequestObjectSigningAlg: ").Append(RequestObjectSigningAlg).Append("\n");
            sb.Append("  ResponseTypes: ").Append(ResponseTypes).Append("\n");
            sb.Append("  TokenEndpointAuthMethod: ").Append(TokenEndpointAuthMethod).Append("\n");
            sb.Append("  TosUri: ").Append(TosUri).Append("\n");
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
            return this.Equals(input as ModelClient);
        }

        /// <summary>
        /// Returns true if ModelClient instances are equal
        /// </summary>
        /// <param name="input">Instance of ModelClient to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ModelClient input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ApplicationType == input.ApplicationType ||
                    this.ApplicationType.Equals(input.ApplicationType)
                ) && 
                (
                    this.ClientId == input.ClientId ||
                    (this.ClientId != null &&
                    this.ClientId.Equals(input.ClientId))
                ) && 
                (
                    this.ClientIdIssuedAt == input.ClientIdIssuedAt ||
                    this.ClientIdIssuedAt.Equals(input.ClientIdIssuedAt)
                ) && 
                (
                    this.ClientName == input.ClientName ||
                    (this.ClientName != null &&
                    this.ClientName.Equals(input.ClientName))
                ) && 
                (
                    this.ClientSecret == input.ClientSecret ||
                    (this.ClientSecret != null &&
                    this.ClientSecret.Equals(input.ClientSecret))
                ) && 
                (
                    this.ClientSecretExpiresAt == input.ClientSecretExpiresAt ||
                    (this.ClientSecretExpiresAt != null &&
                    this.ClientSecretExpiresAt.Equals(input.ClientSecretExpiresAt))
                ) && 
                (
                    this.FrontchannelLogoutSessionRequired == input.FrontchannelLogoutSessionRequired ||
                    this.FrontchannelLogoutSessionRequired.Equals(input.FrontchannelLogoutSessionRequired)
                ) && 
                (
                    this.FrontchannelLogoutUri == input.FrontchannelLogoutUri ||
                    (this.FrontchannelLogoutUri != null &&
                    this.FrontchannelLogoutUri.Equals(input.FrontchannelLogoutUri))
                ) && 
                (
                    this.GrantTypes == input.GrantTypes ||
                    this.GrantTypes != null &&
                    input.GrantTypes != null &&
                    this.GrantTypes.SequenceEqual(input.GrantTypes)
                ) && 
                (
                    this.InitiateLoginUri == input.InitiateLoginUri ||
                    (this.InitiateLoginUri != null &&
                    this.InitiateLoginUri.Equals(input.InitiateLoginUri))
                ) && 
                (
                    this.JwksUri == input.JwksUri ||
                    (this.JwksUri != null &&
                    this.JwksUri.Equals(input.JwksUri))
                ) && 
                (
                    this.LogoUri == input.LogoUri ||
                    (this.LogoUri != null &&
                    this.LogoUri.Equals(input.LogoUri))
                ) && 
                (
                    this.PolicyUri == input.PolicyUri ||
                    (this.PolicyUri != null &&
                    this.PolicyUri.Equals(input.PolicyUri))
                ) && 
                (
                    this.PostLogoutRedirectUris == input.PostLogoutRedirectUris ||
                    this.PostLogoutRedirectUris != null &&
                    input.PostLogoutRedirectUris != null &&
                    this.PostLogoutRedirectUris.SequenceEqual(input.PostLogoutRedirectUris)
                ) && 
                (
                    this.RedirectUris == input.RedirectUris ||
                    this.RedirectUris != null &&
                    input.RedirectUris != null &&
                    this.RedirectUris.SequenceEqual(input.RedirectUris)
                ) && 
                (
                    this.RequestObjectSigningAlg == input.RequestObjectSigningAlg ||
                    this.RequestObjectSigningAlg != null &&
                    input.RequestObjectSigningAlg != null &&
                    this.RequestObjectSigningAlg.SequenceEqual(input.RequestObjectSigningAlg)
                ) && 
                (
                    this.ResponseTypes == input.ResponseTypes ||
                    this.ResponseTypes != null &&
                    input.ResponseTypes != null &&
                    this.ResponseTypes.SequenceEqual(input.ResponseTypes)
                ) && 
                (
                    this.TokenEndpointAuthMethod == input.TokenEndpointAuthMethod ||
                    this.TokenEndpointAuthMethod.Equals(input.TokenEndpointAuthMethod)
                ) && 
                (
                    this.TosUri == input.TosUri ||
                    (this.TosUri != null &&
                    this.TosUri.Equals(input.TosUri))
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
                
                if (this.ApplicationType != null)
                {
                    hashCode = (hashCode * 59) + this.ApplicationType.GetHashCode();
                }
                if (this.ClientId != null)
                {
                    hashCode = (hashCode * 59) + this.ClientId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ClientIdIssuedAt.GetHashCode();
                if (this.ClientName != null)
                {
                    hashCode = (hashCode * 59) + this.ClientName.GetHashCode();
                }
                if (this.ClientSecret != null)
                {
                    hashCode = (hashCode * 59) + this.ClientSecret.GetHashCode();
                }
                if (this.ClientSecretExpiresAt != null)
                {
                    hashCode = (hashCode * 59) + this.ClientSecretExpiresAt.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.FrontchannelLogoutSessionRequired.GetHashCode();
                if (this.FrontchannelLogoutUri != null)
                {
                    hashCode = (hashCode * 59) + this.FrontchannelLogoutUri.GetHashCode();
                }
                if (this.GrantTypes != null)
                {
                    hashCode = (hashCode * 59) + this.GrantTypes.GetHashCode();
                }
                if (this.InitiateLoginUri != null)
                {
                    hashCode = (hashCode * 59) + this.InitiateLoginUri.GetHashCode();
                }
                if (this.JwksUri != null)
                {
                    hashCode = (hashCode * 59) + this.JwksUri.GetHashCode();
                }
                if (this.LogoUri != null)
                {
                    hashCode = (hashCode * 59) + this.LogoUri.GetHashCode();
                }
                if (this.PolicyUri != null)
                {
                    hashCode = (hashCode * 59) + this.PolicyUri.GetHashCode();
                }
                if (this.PostLogoutRedirectUris != null)
                {
                    hashCode = (hashCode * 59) + this.PostLogoutRedirectUris.GetHashCode();
                }
                if (this.RedirectUris != null)
                {
                    hashCode = (hashCode * 59) + this.RedirectUris.GetHashCode();
                }
                if (this.RequestObjectSigningAlg != null)
                {
                    hashCode = (hashCode * 59) + this.RequestObjectSigningAlg.GetHashCode();
                }
                if (this.ResponseTypes != null)
                {
                    hashCode = (hashCode * 59) + this.ResponseTypes.GetHashCode();
                }
                if (this.TokenEndpointAuthMethod != null)
                {
                    hashCode = (hashCode * 59) + this.TokenEndpointAuthMethod.GetHashCode();
                }
                if (this.TosUri != null)
                {
                    hashCode = (hashCode * 59) + this.TosUri.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}