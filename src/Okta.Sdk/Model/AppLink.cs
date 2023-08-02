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
    /// AppLink
    /// </summary>
    [DataContract(Name = "AppLink")]
    
    public partial class AppLink : IEquatable<AppLink>
    {
        
        /// <summary>
        /// Gets or Sets AppAssignmentId
        /// </summary>
        [DataMember(Name = "appAssignmentId", EmitDefaultValue = false)]
        public string AppAssignmentId { get; private set; }

        /// <summary>
        /// Returns false as AppAssignmentId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeAppAssignmentId()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets AppInstanceId
        /// </summary>
        [DataMember(Name = "appInstanceId", EmitDefaultValue = false)]
        public string AppInstanceId { get; private set; }

        /// <summary>
        /// Returns false as AppInstanceId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeAppInstanceId()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets AppName
        /// </summary>
        [DataMember(Name = "appName", EmitDefaultValue = false)]
        public string AppName { get; private set; }

        /// <summary>
        /// Returns false as AppName should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeAppName()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets CredentialsSetup
        /// </summary>
        [DataMember(Name = "credentialsSetup", EmitDefaultValue = true)]
        public bool CredentialsSetup { get; private set; }

        /// <summary>
        /// Returns false as CredentialsSetup should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCredentialsSetup()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Hidden
        /// </summary>
        [DataMember(Name = "hidden", EmitDefaultValue = true)]
        public bool Hidden { get; private set; }

        /// <summary>
        /// Returns false as Hidden should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeHidden()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
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
        /// Gets or Sets Label
        /// </summary>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; private set; }

        /// <summary>
        /// Returns false as Label should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeLabel()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets LinkUrl
        /// </summary>
        [DataMember(Name = "linkUrl", EmitDefaultValue = false)]
        public string LinkUrl { get; private set; }

        /// <summary>
        /// Returns false as LinkUrl should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeLinkUrl()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets LogoUrl
        /// </summary>
        [DataMember(Name = "logoUrl", EmitDefaultValue = false)]
        public string LogoUrl { get; private set; }

        /// <summary>
        /// Returns false as LogoUrl should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeLogoUrl()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets SortOrder
        /// </summary>
        [DataMember(Name = "sortOrder", EmitDefaultValue = false)]
        public int SortOrder { get; private set; }

        /// <summary>
        /// Returns false as SortOrder should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeSortOrder()
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
            sb.Append("class AppLink {\n");
            sb.Append("  AppAssignmentId: ").Append(AppAssignmentId).Append("\n");
            sb.Append("  AppInstanceId: ").Append(AppInstanceId).Append("\n");
            sb.Append("  AppName: ").Append(AppName).Append("\n");
            sb.Append("  CredentialsSetup: ").Append(CredentialsSetup).Append("\n");
            sb.Append("  Hidden: ").Append(Hidden).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  LinkUrl: ").Append(LinkUrl).Append("\n");
            sb.Append("  LogoUrl: ").Append(LogoUrl).Append("\n");
            sb.Append("  SortOrder: ").Append(SortOrder).Append("\n");
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
            return this.Equals(input as AppLink);
        }

        /// <summary>
        /// Returns true if AppLink instances are equal
        /// </summary>
        /// <param name="input">Instance of AppLink to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AppLink input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AppAssignmentId == input.AppAssignmentId ||
                    (this.AppAssignmentId != null &&
                    this.AppAssignmentId.Equals(input.AppAssignmentId))
                ) && 
                (
                    this.AppInstanceId == input.AppInstanceId ||
                    (this.AppInstanceId != null &&
                    this.AppInstanceId.Equals(input.AppInstanceId))
                ) && 
                (
                    this.AppName == input.AppName ||
                    (this.AppName != null &&
                    this.AppName.Equals(input.AppName))
                ) && 
                (
                    this.CredentialsSetup == input.CredentialsSetup ||
                    this.CredentialsSetup.Equals(input.CredentialsSetup)
                ) && 
                (
                    this.Hidden == input.Hidden ||
                    this.Hidden.Equals(input.Hidden)
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Label == input.Label ||
                    (this.Label != null &&
                    this.Label.Equals(input.Label))
                ) && 
                (
                    this.LinkUrl == input.LinkUrl ||
                    (this.LinkUrl != null &&
                    this.LinkUrl.Equals(input.LinkUrl))
                ) && 
                (
                    this.LogoUrl == input.LogoUrl ||
                    (this.LogoUrl != null &&
                    this.LogoUrl.Equals(input.LogoUrl))
                ) && 
                (
                    this.SortOrder == input.SortOrder ||
                    this.SortOrder.Equals(input.SortOrder)
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
                
                if (this.AppAssignmentId != null)
                {
                    hashCode = (hashCode * 59) + this.AppAssignmentId.GetHashCode();
                }
                if (this.AppInstanceId != null)
                {
                    hashCode = (hashCode * 59) + this.AppInstanceId.GetHashCode();
                }
                if (this.AppName != null)
                {
                    hashCode = (hashCode * 59) + this.AppName.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CredentialsSetup.GetHashCode();
                hashCode = (hashCode * 59) + this.Hidden.GetHashCode();
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.Label != null)
                {
                    hashCode = (hashCode * 59) + this.Label.GetHashCode();
                }
                if (this.LinkUrl != null)
                {
                    hashCode = (hashCode * 59) + this.LinkUrl.GetHashCode();
                }
                if (this.LogoUrl != null)
                {
                    hashCode = (hashCode * 59) + this.LogoUrl.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.SortOrder.GetHashCode();
                return hashCode;
            }
        }

    }

}
