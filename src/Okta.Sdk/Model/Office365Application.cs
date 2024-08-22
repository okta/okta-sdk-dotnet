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
    /// Schema for the Microsoft Office 365 app (key name: &#x60;office365&#x60;)  To create a Microsoft Office 365 app, use the [Create an Application](/openapi/okta-management/management/tag/Application/#tag/Application/operation/createApplication) request with the following parameters in the request body. &gt; **Note:** The Office 365 app only supports &#x60;BROWSER_PLUGIN&#x60; and &#x60;SAML_1_1&#x60; sign-on modes. 
    /// </summary>
    [DataContract(Name = "Office365Application")]
    
    public partial class Office365Application : IEquatable<Office365Application>
    {
        /// <summary>
        /// Defines Name
        /// </summary>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class NameEnum : StringEnum
        {
            /// <summary>
            /// StringEnum Office365 for value: office365
            /// </summary>
            
            public static NameEnum Office365 = new NameEnum("office365");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="NameEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator NameEnum(string value) => new NameEnum(value);

            /// <summary>
            /// Creates a new <see cref="Name"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public NameEnum(string value)
                : base(value)
            {
            }
        }


        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        
        public NameEnum Name { get; set; }
        /// <summary>
        /// Defines SignOnMode
        /// </summary>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class SignOnModeEnum : StringEnum
        {
            /// <summary>
            /// StringEnum BROWSERPLUGIN for value: BROWSER_PLUGIN
            /// </summary>
            
            public static SignOnModeEnum BROWSERPLUGIN = new SignOnModeEnum("BROWSER_PLUGIN");

            /// <summary>
            /// StringEnum SAML11 for value: SAML_1_1
            /// </summary>
            
            public static SignOnModeEnum SAML11 = new SignOnModeEnum("SAML_1_1");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="SignOnModeEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator SignOnModeEnum(string value) => new SignOnModeEnum(value);

            /// <summary>
            /// Creates a new <see cref="SignOnMode"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public SignOnModeEnum(string value)
                : base(value)
            {
            }
        }


        /// <summary>
        /// Gets or Sets SignOnMode
        /// </summary>
        [DataMember(Name = "signOnMode", EmitDefaultValue = true)]
        
        public SignOnModeEnum SignOnMode { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = true)]
        
        public ApplicationLifecycleStatus Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Office365Application" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Office365Application() { }
        
        /// <summary>
        /// Gets or Sets Accessibility
        /// </summary>
        [DataMember(Name = "accessibility", EmitDefaultValue = true)]
        public ApplicationAccessibility Accessibility { get; set; }

        /// <summary>
        /// Gets or Sets Credentials
        /// </summary>
        [DataMember(Name = "credentials", EmitDefaultValue = true)]
        public SchemeApplicationCredentials Credentials { get; set; }

        /// <summary>
        /// User-defined display name for app
        /// </summary>
        /// <value>User-defined display name for app</value>
        [DataMember(Name = "label", EmitDefaultValue = true)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or Sets Licensing
        /// </summary>
        [DataMember(Name = "licensing", EmitDefaultValue = true)]
        public ApplicationLicensing Licensing { get; set; }

        /// <summary>
        /// Contains any valid JSON schema for specifying properties that can be referenced from a request (only available to OAuth 2.0 client apps)
        /// </summary>
        /// <value>Contains any valid JSON schema for specifying properties that can be referenced from a request (only available to OAuth 2.0 client apps)</value>
        [DataMember(Name = "profile", EmitDefaultValue = true)]
        public Dictionary<string, Object> Profile { get; set; }

        /// <summary>
        /// Gets or Sets Visibility
        /// </summary>
        [DataMember(Name = "visibility", EmitDefaultValue = true)]
        public ApplicationVisibility Visibility { get; set; }

        /// <summary>
        /// Gets or Sets Settings
        /// </summary>
        [DataMember(Name = "settings", EmitDefaultValue = true)]
        public Office365ApplicationSettings Settings { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Office365Application {\n");
            sb.Append("  Accessibility: ").Append(Accessibility).Append("\n");
            sb.Append("  Credentials: ").Append(Credentials).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  Licensing: ").Append(Licensing).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Profile: ").Append(Profile).Append("\n");
            sb.Append("  SignOnMode: ").Append(SignOnMode).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Visibility: ").Append(Visibility).Append("\n");
            sb.Append("  Settings: ").Append(Settings).Append("\n");
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
            return this.Equals(input as Office365Application);
        }

        /// <summary>
        /// Returns true if Office365Application instances are equal
        /// </summary>
        /// <param name="input">Instance of Office365Application to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Office365Application input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Accessibility == input.Accessibility ||
                    (this.Accessibility != null &&
                    this.Accessibility.Equals(input.Accessibility))
                ) && 
                (
                    this.Credentials == input.Credentials ||
                    (this.Credentials != null &&
                    this.Credentials.Equals(input.Credentials))
                ) && 
                (
                    this.Label == input.Label ||
                    (this.Label != null &&
                    this.Label.Equals(input.Label))
                ) && 
                (
                    this.Licensing == input.Licensing ||
                    (this.Licensing != null &&
                    this.Licensing.Equals(input.Licensing))
                ) && 
                (
                    this.Name == input.Name ||
                    this.Name.Equals(input.Name)
                ) && 
                (
                    this.Profile == input.Profile ||
                    this.Profile != null &&
                    input.Profile != null &&
                    this.Profile.SequenceEqual(input.Profile)
                ) && 
                (
                    this.SignOnMode == input.SignOnMode ||
                    this.SignOnMode.Equals(input.SignOnMode)
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Visibility == input.Visibility ||
                    (this.Visibility != null &&
                    this.Visibility.Equals(input.Visibility))
                ) && 
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
                int hashCode = 41;
                
                if (this.Accessibility != null)
                {
                    hashCode = (hashCode * 59) + this.Accessibility.GetHashCode();
                }
                if (this.Credentials != null)
                {
                    hashCode = (hashCode * 59) + this.Credentials.GetHashCode();
                }
                if (this.Label != null)
                {
                    hashCode = (hashCode * 59) + this.Label.GetHashCode();
                }
                if (this.Licensing != null)
                {
                    hashCode = (hashCode * 59) + this.Licensing.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Profile != null)
                {
                    hashCode = (hashCode * 59) + this.Profile.GetHashCode();
                }
                if (this.SignOnMode != null)
                {
                    hashCode = (hashCode * 59) + this.SignOnMode.GetHashCode();
                }
                if (this.Status != null)
                {
                    hashCode = (hashCode * 59) + this.Status.GetHashCode();
                }
                if (this.Visibility != null)
                {
                    hashCode = (hashCode * 59) + this.Visibility.GetHashCode();
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
