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
    /// ContinuousAccessPolicyRuleTerminateSessionSlo
    /// </summary>
    [DataContract(Name = "ContinuousAccessPolicyRuleTerminateSession_slo")]
    
    public partial class ContinuousAccessPolicyRuleTerminateSessionSlo : IEquatable<ContinuousAccessPolicyRuleTerminateSessionSlo>
    {
        /// <summary>
        /// This property defines the session to terminate - everyone, no one, or a specific app instance.
        /// </summary>
        /// <value>This property defines the session to terminate - everyone, no one, or a specific app instance.</value>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class AppSelectionModeEnum : StringEnum
        {
            /// <summary>
            /// StringEnum SPECIFIC for value: SPECIFIC
            /// </summary>
            
            public static AppSelectionModeEnum SPECIFIC = new AppSelectionModeEnum("SPECIFIC");

            /// <summary>
            /// StringEnum ALL for value: ALL
            /// </summary>
            
            public static AppSelectionModeEnum ALL = new AppSelectionModeEnum("ALL");

            /// <summary>
            /// StringEnum NONE for value: NONE
            /// </summary>
            
            public static AppSelectionModeEnum NONE = new AppSelectionModeEnum("NONE");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="AppSelectionModeEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator AppSelectionModeEnum(string value) => new AppSelectionModeEnum(value);

            /// <summary>
            /// Creates a new <see cref="AppSelectionMode"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public AppSelectionModeEnum(string value)
                : base(value)
            {
            }
        }


        /// <summary>
        /// This property defines the session to terminate - everyone, no one, or a specific app instance.
        /// </summary>
        /// <value>This property defines the session to terminate - everyone, no one, or a specific app instance.</value>
        [DataMember(Name = "appSelectionMode", EmitDefaultValue = true)]
        
        public AppSelectionModeEnum AppSelectionMode { get; set; }
        
        /// <summary>
        /// This property defines the app instance access to terminate. Only include this property when &#x60;appSelectionMode&#x60; is set to &#x60;SPECIFIC&#x60;.
        /// </summary>
        /// <value>This property defines the app instance access to terminate. Only include this property when &#x60;appSelectionMode&#x60; is set to &#x60;SPECIFIC&#x60;.</value>
        [DataMember(Name = "appInstanceIds", EmitDefaultValue = true)]
        public List<string> AppInstanceIds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ContinuousAccessPolicyRuleTerminateSessionSlo {\n");
            sb.Append("  AppSelectionMode: ").Append(AppSelectionMode).Append("\n");
            sb.Append("  AppInstanceIds: ").Append(AppInstanceIds).Append("\n");
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
            return this.Equals(input as ContinuousAccessPolicyRuleTerminateSessionSlo);
        }

        /// <summary>
        /// Returns true if ContinuousAccessPolicyRuleTerminateSessionSlo instances are equal
        /// </summary>
        /// <param name="input">Instance of ContinuousAccessPolicyRuleTerminateSessionSlo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ContinuousAccessPolicyRuleTerminateSessionSlo input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AppSelectionMode == input.AppSelectionMode ||
                    this.AppSelectionMode.Equals(input.AppSelectionMode)
                ) && 
                (
                    this.AppInstanceIds == input.AppInstanceIds ||
                    this.AppInstanceIds != null &&
                    input.AppInstanceIds != null &&
                    this.AppInstanceIds.SequenceEqual(input.AppInstanceIds)
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
                
                if (this.AppSelectionMode != null)
                {
                    hashCode = (hashCode * 59) + this.AppSelectionMode.GetHashCode();
                }
                if (this.AppInstanceIds != null)
                {
                    hashCode = (hashCode * 59) + this.AppInstanceIds.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
