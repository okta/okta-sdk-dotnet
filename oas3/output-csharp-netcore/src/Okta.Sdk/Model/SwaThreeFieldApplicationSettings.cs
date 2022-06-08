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
    /// SwaThreeFieldApplicationSettings
    /// </summary>
    [DataContract(Name = "SwaThreeFieldApplicationSettings")]
    public partial class SwaThreeFieldApplicationSettings : IEquatable<SwaThreeFieldApplicationSettings>
    {
        
        /// <summary>
        /// Gets or Sets App
        /// </summary>
        [DataMember(Name = "app", EmitDefaultValue = false)]
        public SwaThreeFieldApplicationSettingsApplication App { get; set; }

        /// <summary>
        /// Gets or Sets ImplicitAssignment
        /// </summary>
        [DataMember(Name = "implicitAssignment", EmitDefaultValue = true)]
        public bool ImplicitAssignment { get; set; }

        /// <summary>
        /// Gets or Sets InlineHookId
        /// </summary>
        [DataMember(Name = "inlineHookId", EmitDefaultValue = false)]
        public string InlineHookId { get; set; }

        /// <summary>
        /// Gets or Sets IdentityStoreId
        /// </summary>
        [DataMember(Name = "identityStoreId", EmitDefaultValue = false)]
        public string IdentityStoreId { get; set; }

        /// <summary>
        /// Gets or Sets Notes
        /// </summary>
        [DataMember(Name = "notes", EmitDefaultValue = false)]
        public ApplicationSettingsNotes Notes { get; set; }

        /// <summary>
        /// Gets or Sets Notifications
        /// </summary>
        [DataMember(Name = "notifications", EmitDefaultValue = false)]
        public ApplicationSettingsNotifications Notifications { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SwaThreeFieldApplicationSettings {\n");
            sb.Append("  App: ").Append(App).Append("\n");
            sb.Append("  ImplicitAssignment: ").Append(ImplicitAssignment).Append("\n");
            sb.Append("  InlineHookId: ").Append(InlineHookId).Append("\n");
            sb.Append("  IdentityStoreId: ").Append(IdentityStoreId).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  Notifications: ").Append(Notifications).Append("\n");
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
            return this.Equals(input as SwaThreeFieldApplicationSettings);
        }

        /// <summary>
        /// Returns true if SwaThreeFieldApplicationSettings instances are equal
        /// </summary>
        /// <param name="input">Instance of SwaThreeFieldApplicationSettings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SwaThreeFieldApplicationSettings input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.App == input.App ||
                    (this.App != null &&
                    this.App.Equals(input.App))
                ) && 
                (
                    this.ImplicitAssignment == input.ImplicitAssignment ||
                    this.ImplicitAssignment.Equals(input.ImplicitAssignment)
                ) && 
                (
                    this.InlineHookId == input.InlineHookId ||
                    (this.InlineHookId != null &&
                    this.InlineHookId.Equals(input.InlineHookId))
                ) && 
                (
                    this.IdentityStoreId == input.IdentityStoreId ||
                    (this.IdentityStoreId != null &&
                    this.IdentityStoreId.Equals(input.IdentityStoreId))
                ) && 
                (
                    this.Notes == input.Notes ||
                    (this.Notes != null &&
                    this.Notes.Equals(input.Notes))
                ) && 
                (
                    this.Notifications == input.Notifications ||
                    (this.Notifications != null &&
                    this.Notifications.Equals(input.Notifications))
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
                if (this.App != null)
                {
                    hashCode = (hashCode * 59) + this.App.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ImplicitAssignment.GetHashCode();
                if (this.InlineHookId != null)
                {
                    hashCode = (hashCode * 59) + this.InlineHookId.GetHashCode();
                }
                if (this.IdentityStoreId != null)
                {
                    hashCode = (hashCode * 59) + this.IdentityStoreId.GetHashCode();
                }
                if (this.Notes != null)
                {
                    hashCode = (hashCode * 59) + this.Notes.GetHashCode();
                }
                if (this.Notifications != null)
                {
                    hashCode = (hashCode * 59) + this.Notifications.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
