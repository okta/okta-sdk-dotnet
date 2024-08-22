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
    /// AccessPolicyConstraint
    /// </summary>
    [DataContract(Name = "AccessPolicyConstraint")]
    
    public partial class AccessPolicyConstraint : IEquatable<AccessPolicyConstraint>
    {
        /// <summary>
        /// Defines Methods
        /// </summary>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class MethodsEnum : StringEnum
        {
            /// <summary>
            /// StringEnum PASSWORD for value: PASSWORD
            /// </summary>
            
            public static MethodsEnum PASSWORD = new MethodsEnum("PASSWORD");

            /// <summary>
            /// StringEnum SECURITYQUESTION for value: SECURITY_QUESTION
            /// </summary>
            
            public static MethodsEnum SECURITYQUESTION = new MethodsEnum("SECURITY_QUESTION");

            /// <summary>
            /// StringEnum SMS for value: SMS
            /// </summary>
            
            public static MethodsEnum SMS = new MethodsEnum("SMS");

            /// <summary>
            /// StringEnum VOICE for value: VOICE
            /// </summary>
            
            public static MethodsEnum VOICE = new MethodsEnum("VOICE");

            /// <summary>
            /// StringEnum EMAIL for value: EMAIL
            /// </summary>
            
            public static MethodsEnum EMAIL = new MethodsEnum("EMAIL");

            /// <summary>
            /// StringEnum PUSH for value: PUSH
            /// </summary>
            
            public static MethodsEnum PUSH = new MethodsEnum("PUSH");

            /// <summary>
            /// StringEnum SIGNEDNONCE for value: SIGNED_NONCE
            /// </summary>
            
            public static MethodsEnum SIGNEDNONCE = new MethodsEnum("SIGNED_NONCE");

            /// <summary>
            /// StringEnum OTP for value: OTP
            /// </summary>
            
            public static MethodsEnum OTP = new MethodsEnum("OTP");

            /// <summary>
            /// StringEnum TOTP for value: TOTP
            /// </summary>
            
            public static MethodsEnum TOTP = new MethodsEnum("TOTP");

            /// <summary>
            /// StringEnum WEBAUTHN for value: WEBAUTHN
            /// </summary>
            
            public static MethodsEnum WEBAUTHN = new MethodsEnum("WEBAUTHN");

            /// <summary>
            /// StringEnum DUO for value: DUO
            /// </summary>
            
            public static MethodsEnum DUO = new MethodsEnum("DUO");

            /// <summary>
            /// StringEnum IDP for value: IDP
            /// </summary>
            
            public static MethodsEnum IDP = new MethodsEnum("IDP");

            /// <summary>
            /// StringEnum CERT for value: CERT
            /// </summary>
            
            public static MethodsEnum CERT = new MethodsEnum("CERT");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="MethodsEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator MethodsEnum(string value) => new MethodsEnum(value);

            /// <summary>
            /// Creates a new <see cref="Methods"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public MethodsEnum(string value)
                : base(value)
            {
            }
        }



        /// <summary>
        /// The Authenticator methods that are permitted
        /// </summary>
        /// <value>The Authenticator methods that are permitted</value>
        [DataMember(Name = "methods", EmitDefaultValue = true)]
        
        public List<MethodsEnum> Methods { get; set; }
        /// <summary>
        /// Defines Types
        /// </summary>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class TypesEnum : StringEnum
        {
            /// <summary>
            /// StringEnum SECURITYKEY for value: SECURITY_KEY
            /// </summary>
            
            public static TypesEnum SECURITYKEY = new TypesEnum("SECURITY_KEY");

            /// <summary>
            /// StringEnum PHONE for value: PHONE
            /// </summary>
            
            public static TypesEnum PHONE = new TypesEnum("PHONE");

            /// <summary>
            /// StringEnum EMAIL for value: EMAIL
            /// </summary>
            
            public static TypesEnum EMAIL = new TypesEnum("EMAIL");

            /// <summary>
            /// StringEnum PASSWORD for value: PASSWORD
            /// </summary>
            
            public static TypesEnum PASSWORD = new TypesEnum("PASSWORD");

            /// <summary>
            /// StringEnum SECURITYQUESTION for value: SECURITY_QUESTION
            /// </summary>
            
            public static TypesEnum SECURITYQUESTION = new TypesEnum("SECURITY_QUESTION");

            /// <summary>
            /// StringEnum APP for value: APP
            /// </summary>
            
            public static TypesEnum APP = new TypesEnum("APP");

            /// <summary>
            /// StringEnum FEDERATED for value: FEDERATED
            /// </summary>
            
            public static TypesEnum FEDERATED = new TypesEnum("FEDERATED");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="TypesEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator TypesEnum(string value) => new TypesEnum(value);

            /// <summary>
            /// Creates a new <see cref="Types"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public TypesEnum(string value)
                : base(value)
            {
            }
        }



        /// <summary>
        /// The Authenticator types that are permitted
        /// </summary>
        /// <value>The Authenticator types that are permitted</value>
        [DataMember(Name = "types", EmitDefaultValue = true)]
        
        public List<TypesEnum> Types { get; set; }
        
        /// <summary>
        /// This property specifies the precise authenticator and method for authentication. &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt;
        /// </summary>
        /// <value>This property specifies the precise authenticator and method for authentication. &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt;</value>
        [DataMember(Name = "authenticationMethods", EmitDefaultValue = true)]
        public List<AuthenticationMethodObject> AuthenticationMethods { get; set; }

        /// <summary>
        /// This property specifies the precise authenticator and method to exclude from authentication. &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt;
        /// </summary>
        /// <value>This property specifies the precise authenticator and method to exclude from authentication. &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt;</value>
        [DataMember(Name = "excludedAuthenticationMethods", EmitDefaultValue = true)]
        public List<AuthenticationMethodObject> ExcludedAuthenticationMethods { get; set; }

        /// <summary>
        /// The duration after which the user must re-authenticate regardless of user activity. This re-authentication interval overrides the Verification Method object&#39;s &#x60;reauthenticateIn&#x60; interval. The supported values use ISO 8601 period format for recurring time intervals (for example, &#x60;PT1H&#x60;).
        /// </summary>
        /// <value>The duration after which the user must re-authenticate regardless of user activity. This re-authentication interval overrides the Verification Method object&#39;s &#x60;reauthenticateIn&#x60; interval. The supported values use ISO 8601 period format for recurring time intervals (for example, &#x60;PT1H&#x60;).</value>
        [DataMember(Name = "reauthenticateIn", EmitDefaultValue = true)]
        public string ReauthenticateIn { get; set; }

        /// <summary>
        /// This property indicates whether the knowledge or possession factor is required by the assurance. It&#39;s optional in the request, but is always returned in the response. By default, this field is &#x60;true&#x60;. If the knowledge or possession constraint has values for &#x60;excludedAuthenticationMethods&#x60; the &#x60;required&#x60; value is false. &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt;
        /// </summary>
        /// <value>This property indicates whether the knowledge or possession factor is required by the assurance. It&#39;s optional in the request, but is always returned in the response. By default, this field is &#x60;true&#x60;. If the knowledge or possession constraint has values for &#x60;excludedAuthenticationMethods&#x60; the &#x60;required&#x60; value is false. &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt;</value>
        [DataMember(Name = "required", EmitDefaultValue = true)]
        public bool Required { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AccessPolicyConstraint {\n");
            sb.Append("  AuthenticationMethods: ").Append(AuthenticationMethods).Append("\n");
            sb.Append("  ExcludedAuthenticationMethods: ").Append(ExcludedAuthenticationMethods).Append("\n");
            sb.Append("  Methods: ").Append(Methods).Append("\n");
            sb.Append("  ReauthenticateIn: ").Append(ReauthenticateIn).Append("\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
            sb.Append("  Types: ").Append(Types).Append("\n");
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
            return this.Equals(input as AccessPolicyConstraint);
        }

        /// <summary>
        /// Returns true if AccessPolicyConstraint instances are equal
        /// </summary>
        /// <param name="input">Instance of AccessPolicyConstraint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccessPolicyConstraint input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AuthenticationMethods == input.AuthenticationMethods ||
                    this.AuthenticationMethods != null &&
                    input.AuthenticationMethods != null &&
                    this.AuthenticationMethods.SequenceEqual(input.AuthenticationMethods)
                ) && 
                (
                    this.ExcludedAuthenticationMethods == input.ExcludedAuthenticationMethods ||
                    this.ExcludedAuthenticationMethods != null &&
                    input.ExcludedAuthenticationMethods != null &&
                    this.ExcludedAuthenticationMethods.SequenceEqual(input.ExcludedAuthenticationMethods)
                ) && 
                (
                    this.Methods == input.Methods ||
                    this.Methods.SequenceEqual(input.Methods)
                ) && 
                (
                    this.ReauthenticateIn == input.ReauthenticateIn ||
                    (this.ReauthenticateIn != null &&
                    this.ReauthenticateIn.Equals(input.ReauthenticateIn))
                ) && 
                (
                    this.Required == input.Required ||
                    this.Required.Equals(input.Required)
                ) && 
                (
                    this.Types == input.Types ||
                    this.Types.SequenceEqual(input.Types)
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
                
                if (this.AuthenticationMethods != null)
                {
                    hashCode = (hashCode * 59) + this.AuthenticationMethods.GetHashCode();
                }
                if (this.ExcludedAuthenticationMethods != null)
                {
                    hashCode = (hashCode * 59) + this.ExcludedAuthenticationMethods.GetHashCode();
                }
                if (this.Methods != null)
                {
                    hashCode = (hashCode * 59) + this.Methods.GetHashCode();
                }
                if (this.ReauthenticateIn != null)
                {
                    hashCode = (hashCode * 59) + this.ReauthenticateIn.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Required.GetHashCode();
                if (this.Types != null)
                {
                    hashCode = (hashCode * 59) + this.Types.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
