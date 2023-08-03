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
    /// WsFederationApplicationSettingsApplication
    /// </summary>
    [DataContract(Name = "WsFederationApplicationSettingsApplication")]
    
    public partial class WsFederationApplicationSettingsApplication : IEquatable<WsFederationApplicationSettingsApplication>
    {
        
        /// <summary>
        /// Gets or Sets AttributeStatements
        /// </summary>
        [DataMember(Name = "attributeStatements", EmitDefaultValue = true)]
        public string AttributeStatements { get; set; }

        /// <summary>
        /// Gets or Sets AudienceRestriction
        /// </summary>
        [DataMember(Name = "audienceRestriction", EmitDefaultValue = true)]
        public string AudienceRestriction { get; set; }

        /// <summary>
        /// Gets or Sets AuthnContextClassRef
        /// </summary>
        [DataMember(Name = "authnContextClassRef", EmitDefaultValue = true)]
        public string AuthnContextClassRef { get; set; }

        /// <summary>
        /// Gets or Sets GroupFilter
        /// </summary>
        [DataMember(Name = "groupFilter", EmitDefaultValue = true)]
        public string GroupFilter { get; set; }

        /// <summary>
        /// Gets or Sets GroupName
        /// </summary>
        [DataMember(Name = "groupName", EmitDefaultValue = true)]
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or Sets GroupValueFormat
        /// </summary>
        [DataMember(Name = "groupValueFormat", EmitDefaultValue = true)]
        public string GroupValueFormat { get; set; }

        /// <summary>
        /// Gets or Sets NameIDFormat
        /// </summary>
        [DataMember(Name = "nameIDFormat", EmitDefaultValue = true)]
        public string NameIDFormat { get; set; }

        /// <summary>
        /// Gets or Sets Realm
        /// </summary>
        [DataMember(Name = "realm", EmitDefaultValue = true)]
        public string Realm { get; set; }

        /// <summary>
        /// Gets or Sets SiteURL
        /// </summary>
        [DataMember(Name = "siteURL", EmitDefaultValue = true)]
        public string SiteURL { get; set; }

        /// <summary>
        /// Gets or Sets UsernameAttribute
        /// </summary>
        [DataMember(Name = "usernameAttribute", EmitDefaultValue = true)]
        public string UsernameAttribute { get; set; }

        /// <summary>
        /// Gets or Sets WReplyOverride
        /// </summary>
        [DataMember(Name = "wReplyOverride", EmitDefaultValue = true)]
        public bool WReplyOverride { get; set; }

        /// <summary>
        /// Gets or Sets WReplyURL
        /// </summary>
        [DataMember(Name = "wReplyURL", EmitDefaultValue = true)]
        public string WReplyURL { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WsFederationApplicationSettingsApplication {\n");
            sb.Append("  AttributeStatements: ").Append(AttributeStatements).Append("\n");
            sb.Append("  AudienceRestriction: ").Append(AudienceRestriction).Append("\n");
            sb.Append("  AuthnContextClassRef: ").Append(AuthnContextClassRef).Append("\n");
            sb.Append("  GroupFilter: ").Append(GroupFilter).Append("\n");
            sb.Append("  GroupName: ").Append(GroupName).Append("\n");
            sb.Append("  GroupValueFormat: ").Append(GroupValueFormat).Append("\n");
            sb.Append("  NameIDFormat: ").Append(NameIDFormat).Append("\n");
            sb.Append("  Realm: ").Append(Realm).Append("\n");
            sb.Append("  SiteURL: ").Append(SiteURL).Append("\n");
            sb.Append("  UsernameAttribute: ").Append(UsernameAttribute).Append("\n");
            sb.Append("  WReplyOverride: ").Append(WReplyOverride).Append("\n");
            sb.Append("  WReplyURL: ").Append(WReplyURL).Append("\n");
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
            return this.Equals(input as WsFederationApplicationSettingsApplication);
        }

        /// <summary>
        /// Returns true if WsFederationApplicationSettingsApplication instances are equal
        /// </summary>
        /// <param name="input">Instance of WsFederationApplicationSettingsApplication to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WsFederationApplicationSettingsApplication input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AttributeStatements == input.AttributeStatements ||
                    (this.AttributeStatements != null &&
                    this.AttributeStatements.Equals(input.AttributeStatements))
                ) && 
                (
                    this.AudienceRestriction == input.AudienceRestriction ||
                    (this.AudienceRestriction != null &&
                    this.AudienceRestriction.Equals(input.AudienceRestriction))
                ) && 
                (
                    this.AuthnContextClassRef == input.AuthnContextClassRef ||
                    (this.AuthnContextClassRef != null &&
                    this.AuthnContextClassRef.Equals(input.AuthnContextClassRef))
                ) && 
                (
                    this.GroupFilter == input.GroupFilter ||
                    (this.GroupFilter != null &&
                    this.GroupFilter.Equals(input.GroupFilter))
                ) && 
                (
                    this.GroupName == input.GroupName ||
                    (this.GroupName != null &&
                    this.GroupName.Equals(input.GroupName))
                ) && 
                (
                    this.GroupValueFormat == input.GroupValueFormat ||
                    (this.GroupValueFormat != null &&
                    this.GroupValueFormat.Equals(input.GroupValueFormat))
                ) && 
                (
                    this.NameIDFormat == input.NameIDFormat ||
                    (this.NameIDFormat != null &&
                    this.NameIDFormat.Equals(input.NameIDFormat))
                ) && 
                (
                    this.Realm == input.Realm ||
                    (this.Realm != null &&
                    this.Realm.Equals(input.Realm))
                ) && 
                (
                    this.SiteURL == input.SiteURL ||
                    (this.SiteURL != null &&
                    this.SiteURL.Equals(input.SiteURL))
                ) && 
                (
                    this.UsernameAttribute == input.UsernameAttribute ||
                    (this.UsernameAttribute != null &&
                    this.UsernameAttribute.Equals(input.UsernameAttribute))
                ) && 
                (
                    this.WReplyOverride == input.WReplyOverride ||
                    this.WReplyOverride.Equals(input.WReplyOverride)
                ) && 
                (
                    this.WReplyURL == input.WReplyURL ||
                    (this.WReplyURL != null &&
                    this.WReplyURL.Equals(input.WReplyURL))
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
                
                if (this.AttributeStatements != null)
                {
                    hashCode = (hashCode * 59) + this.AttributeStatements.GetHashCode();
                }
                if (this.AudienceRestriction != null)
                {
                    hashCode = (hashCode * 59) + this.AudienceRestriction.GetHashCode();
                }
                if (this.AuthnContextClassRef != null)
                {
                    hashCode = (hashCode * 59) + this.AuthnContextClassRef.GetHashCode();
                }
                if (this.GroupFilter != null)
                {
                    hashCode = (hashCode * 59) + this.GroupFilter.GetHashCode();
                }
                if (this.GroupName != null)
                {
                    hashCode = (hashCode * 59) + this.GroupName.GetHashCode();
                }
                if (this.GroupValueFormat != null)
                {
                    hashCode = (hashCode * 59) + this.GroupValueFormat.GetHashCode();
                }
                if (this.NameIDFormat != null)
                {
                    hashCode = (hashCode * 59) + this.NameIDFormat.GetHashCode();
                }
                if (this.Realm != null)
                {
                    hashCode = (hashCode * 59) + this.Realm.GetHashCode();
                }
                if (this.SiteURL != null)
                {
                    hashCode = (hashCode * 59) + this.SiteURL.GetHashCode();
                }
                if (this.UsernameAttribute != null)
                {
                    hashCode = (hashCode * 59) + this.UsernameAttribute.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.WReplyOverride.GetHashCode();
                if (this.WReplyURL != null)
                {
                    hashCode = (hashCode * 59) + this.WReplyURL.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
