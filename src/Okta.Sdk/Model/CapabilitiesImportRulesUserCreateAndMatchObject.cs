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
    /// Rules for matching and creating users
    /// </summary>
    [DataContract(Name = "CapabilitiesImportRulesUserCreateAndMatchObject")]
    
    public partial class CapabilitiesImportRulesUserCreateAndMatchObject : IEquatable<CapabilitiesImportRulesUserCreateAndMatchObject>
    {
        /// <summary>
        /// Determines the attribute to match users
        /// </summary>
        /// <value>Determines the attribute to match users</value>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class ExactMatchCriteriaEnum : StringEnum
        {
            /// <summary>
            /// StringEnum EMAIL for value: EMAIL
            /// </summary>
            
            public static ExactMatchCriteriaEnum EMAIL = new ExactMatchCriteriaEnum("EMAIL");

            /// <summary>
            /// StringEnum USERNAME for value: USERNAME
            /// </summary>
            
            public static ExactMatchCriteriaEnum USERNAME = new ExactMatchCriteriaEnum("USERNAME");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="ExactMatchCriteriaEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator ExactMatchCriteriaEnum(string value) => new ExactMatchCriteriaEnum(value);

            /// <summary>
            /// Creates a new <see cref="ExactMatchCriteria"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public ExactMatchCriteriaEnum(string value)
                : base(value)
            {
            }
        }


        /// <summary>
        /// Determines the attribute to match users
        /// </summary>
        /// <value>Determines the attribute to match users</value>
        [DataMember(Name = "exactMatchCriteria", EmitDefaultValue = true)]
        
        public ExactMatchCriteriaEnum ExactMatchCriteria { get; set; }
        
        /// <summary>
        /// Allows user import upon partial matching. Partial matching occurs when the first and last names of an imported user match those of an existing Okta user, even if the username or email attributes don&#39;t match.
        /// </summary>
        /// <value>Allows user import upon partial matching. Partial matching occurs when the first and last names of an imported user match those of an existing Okta user, even if the username or email attributes don&#39;t match.</value>
        [DataMember(Name = "allowPartialMatch", EmitDefaultValue = true)]
        public bool AllowPartialMatch { get; set; }

        /// <summary>
        /// If set to &#x60;true&#x60;, imported new users are automatically activated.
        /// </summary>
        /// <value>If set to &#x60;true&#x60;, imported new users are automatically activated.</value>
        [DataMember(Name = "autoActivateNewUsers", EmitDefaultValue = true)]
        public bool AutoActivateNewUsers { get; set; }

        /// <summary>
        /// If set to &#x60;true&#x60;, exact-matched users are automatically confirmed on activation. If set to &#x60;false&#x60;, exact-matched users need to be confirmed manually.
        /// </summary>
        /// <value>If set to &#x60;true&#x60;, exact-matched users are automatically confirmed on activation. If set to &#x60;false&#x60;, exact-matched users need to be confirmed manually.</value>
        [DataMember(Name = "autoConfirmExactMatch", EmitDefaultValue = true)]
        public bool AutoConfirmExactMatch { get; set; }

        /// <summary>
        /// If set to &#x60;true&#x60;, imported new users are automatically confirmed on activation. This doesn&#39;t apply to imported users that already exist in Okta.
        /// </summary>
        /// <value>If set to &#x60;true&#x60;, imported new users are automatically confirmed on activation. This doesn&#39;t apply to imported users that already exist in Okta.</value>
        [DataMember(Name = "autoConfirmNewUsers", EmitDefaultValue = true)]
        public bool AutoConfirmNewUsers { get; set; }

        /// <summary>
        /// If set to &#x60;true&#x60;, partially matched users are automatically confirmed on activation. If set to &#x60;false&#x60;, partially matched users need to be confirmed manually.
        /// </summary>
        /// <value>If set to &#x60;true&#x60;, partially matched users are automatically confirmed on activation. If set to &#x60;false&#x60;, partially matched users need to be confirmed manually.</value>
        [DataMember(Name = "autoConfirmPartialMatch", EmitDefaultValue = true)]
        public bool AutoConfirmPartialMatch { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CapabilitiesImportRulesUserCreateAndMatchObject {\n");
            sb.Append("  AllowPartialMatch: ").Append(AllowPartialMatch).Append("\n");
            sb.Append("  AutoActivateNewUsers: ").Append(AutoActivateNewUsers).Append("\n");
            sb.Append("  AutoConfirmExactMatch: ").Append(AutoConfirmExactMatch).Append("\n");
            sb.Append("  AutoConfirmNewUsers: ").Append(AutoConfirmNewUsers).Append("\n");
            sb.Append("  AutoConfirmPartialMatch: ").Append(AutoConfirmPartialMatch).Append("\n");
            sb.Append("  ExactMatchCriteria: ").Append(ExactMatchCriteria).Append("\n");
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
            return this.Equals(input as CapabilitiesImportRulesUserCreateAndMatchObject);
        }

        /// <summary>
        /// Returns true if CapabilitiesImportRulesUserCreateAndMatchObject instances are equal
        /// </summary>
        /// <param name="input">Instance of CapabilitiesImportRulesUserCreateAndMatchObject to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CapabilitiesImportRulesUserCreateAndMatchObject input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AllowPartialMatch == input.AllowPartialMatch ||
                    this.AllowPartialMatch.Equals(input.AllowPartialMatch)
                ) && 
                (
                    this.AutoActivateNewUsers == input.AutoActivateNewUsers ||
                    this.AutoActivateNewUsers.Equals(input.AutoActivateNewUsers)
                ) && 
                (
                    this.AutoConfirmExactMatch == input.AutoConfirmExactMatch ||
                    this.AutoConfirmExactMatch.Equals(input.AutoConfirmExactMatch)
                ) && 
                (
                    this.AutoConfirmNewUsers == input.AutoConfirmNewUsers ||
                    this.AutoConfirmNewUsers.Equals(input.AutoConfirmNewUsers)
                ) && 
                (
                    this.AutoConfirmPartialMatch == input.AutoConfirmPartialMatch ||
                    this.AutoConfirmPartialMatch.Equals(input.AutoConfirmPartialMatch)
                ) && 
                (
                    this.ExactMatchCriteria == input.ExactMatchCriteria ||
                    this.ExactMatchCriteria.Equals(input.ExactMatchCriteria)
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
                
                hashCode = (hashCode * 59) + this.AllowPartialMatch.GetHashCode();
                hashCode = (hashCode * 59) + this.AutoActivateNewUsers.GetHashCode();
                hashCode = (hashCode * 59) + this.AutoConfirmExactMatch.GetHashCode();
                hashCode = (hashCode * 59) + this.AutoConfirmNewUsers.GetHashCode();
                hashCode = (hashCode * 59) + this.AutoConfirmPartialMatch.GetHashCode();
                if (this.ExactMatchCriteria != null)
                {
                    hashCode = (hashCode * 59) + this.ExactMatchCriteria.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
