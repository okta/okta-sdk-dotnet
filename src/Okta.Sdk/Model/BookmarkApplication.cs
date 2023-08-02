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
using JsonSubTypes;
using OpenAPIDateConverter = Okta.Sdk.Client.OpenAPIDateConverter;

namespace Okta.Sdk.Model
{
    /// <summary>
    /// Template: ModelGeneric
    /// BookmarkApplication
    /// </summary>
    [DataContract(Name = "BookmarkApplication")]
    [JsonConverter(typeof(JsonSubtypes), "SignOnMode")]
    [JsonSubtypes.KnownSubType(typeof(AutoLoginApplication), "AUTO_LOGIN")]
    [JsonSubtypes.KnownSubType(typeof(BasicAuthApplication), "BASIC_AUTH")]
    [JsonSubtypes.KnownSubType(typeof(BookmarkApplication), "BOOKMARK")]
    [JsonSubtypes.KnownSubType(typeof(BrowserPluginApplication), "BROWSER_PLUGIN")]
    [JsonSubtypes.KnownSubType(typeof(OpenIdConnectApplication), "OPENID_CONNECT")]
    [JsonSubtypes.KnownSubType(typeof(SamlApplication), "SAML_1_1")]
    [JsonSubtypes.KnownSubType(typeof(SamlApplication), "SAML_2_0")]
    [JsonSubtypes.KnownSubType(typeof(SecurePasswordStoreApplication), "SECURE_PASSWORD_STORE")]
    [JsonSubtypes.KnownSubType(typeof(WsFederationApplication), "WS_FEDERATION")]
    
    public partial class BookmarkApplication : Application, IEquatable<BookmarkApplication>
    {
        
        /// <summary>
        /// Gets or Sets Credentials
        /// </summary>
        [DataMember(Name = "credentials", EmitDefaultValue = false)]
        public ApplicationCredentials Credentials { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Settings
        /// </summary>
        [DataMember(Name = "settings", EmitDefaultValue = false)]
        public BookmarkApplicationSettings Settings { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BookmarkApplication {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Credentials: ").Append(Credentials).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Settings: ").Append(Settings).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return this.Equals(input as BookmarkApplication);
        }

        /// <summary>
        /// Returns true if BookmarkApplication instances are equal
        /// </summary>
        /// <param name="input">Instance of BookmarkApplication to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BookmarkApplication input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.Credentials == input.Credentials ||
                    (this.Credentials != null &&
                    this.Credentials.Equals(input.Credentials))
                ) && base.Equals(input) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && base.Equals(input) && 
                (
                    this.Settings == input.Settings ||
                    (this.Settings != null &&
                    this.Settings.Equals(input.Settings))
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
                int hashCode = base.GetHashCode();
                
                if (this.Credentials != null)
                {
                    hashCode = (hashCode * 59) + this.Credentials.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Settings != null)
                {
                    hashCode = (hashCode * 59) + this.Settings.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
