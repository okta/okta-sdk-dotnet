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
    /// Limits the authenticators that can be used for a given method. Currently, only the &#x60;otp&#x60; method supports constraints, and Google authenticator (key : &#39;google_otp&#39;) is the only allowed authenticator.
    /// </summary>
    [DataContract(Name = "AuthenticatorMethodConstraint")]
    
    public partial class AuthenticatorMethodConstraint : IEquatable<AuthenticatorMethodConstraint>
    {
        /// <summary>
        /// Defines Method
        /// </summary>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class MethodEnum : StringEnum
        {
            /// <summary>
            /// StringEnum Otp for value: otp
            /// </summary>
            
            public static MethodEnum Otp = new MethodEnum("otp");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="MethodEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator MethodEnum(string value) => new MethodEnum(value);

            /// <summary>
            /// Creates a new <see cref="Method"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public MethodEnum(string value)
                : base(value)
            {
            }
        }


        /// <summary>
        /// Gets or Sets Method
        /// </summary>
        [DataMember(Name = "method", EmitDefaultValue = true)]
        
        public MethodEnum Method { get; set; }
        
        /// <summary>
        /// Gets or Sets AllowedAuthenticators
        /// </summary>
        [DataMember(Name = "allowedAuthenticators", EmitDefaultValue = true)]
        public List<AuthenticatorIdentity> AllowedAuthenticators { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthenticatorMethodConstraint {\n");
            sb.Append("  AllowedAuthenticators: ").Append(AllowedAuthenticators).Append("\n");
            sb.Append("  Method: ").Append(Method).Append("\n");
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
            return this.Equals(input as AuthenticatorMethodConstraint);
        }

        /// <summary>
        /// Returns true if AuthenticatorMethodConstraint instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthenticatorMethodConstraint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthenticatorMethodConstraint input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AllowedAuthenticators == input.AllowedAuthenticators ||
                    this.AllowedAuthenticators != null &&
                    input.AllowedAuthenticators != null &&
                    this.AllowedAuthenticators.SequenceEqual(input.AllowedAuthenticators)
                ) && 
                (
                    this.Method == input.Method ||
                    this.Method.Equals(input.Method)
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
                
                if (this.AllowedAuthenticators != null)
                {
                    hashCode = (hashCode * 59) + this.AllowedAuthenticators.GetHashCode();
                }
                if (this.Method != null)
                {
                    hashCode = (hashCode * 59) + this.Method.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
