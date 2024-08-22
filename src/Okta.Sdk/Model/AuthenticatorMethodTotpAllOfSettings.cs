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
    /// AuthenticatorMethodTotpAllOfSettings
    /// </summary>
    [DataContract(Name = "AuthenticatorMethodTotp_allOf_settings")]
    
    public partial class AuthenticatorMethodTotpAllOfSettings : IEquatable<AuthenticatorMethodTotpAllOfSettings>
    {

        /// <summary>
        /// Gets or Sets Encoding
        /// </summary>
        [DataMember(Name = "encoding", EmitDefaultValue = true)]
        
        public OtpTotpEncoding Encoding { get; set; }

        /// <summary>
        /// Gets or Sets Algorithm
        /// </summary>
        [DataMember(Name = "algorithm", EmitDefaultValue = true)]
        
        public OtpTotpAlgorithm Algorithm { get; set; }
        
        /// <summary>
        /// Time interval for TOTP in seconds
        /// </summary>
        /// <value>Time interval for TOTP in seconds</value>
        [DataMember(Name = "timeIntervalInSeconds", EmitDefaultValue = true)]
        public int TimeIntervalInSeconds { get; set; }

        /// <summary>
        /// Number of digits in an OTP value
        /// </summary>
        /// <value>Number of digits in an OTP value</value>
        [DataMember(Name = "passCodeLength", EmitDefaultValue = true)]
        public int PassCodeLength { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthenticatorMethodTotpAllOfSettings {\n");
            sb.Append("  TimeIntervalInSeconds: ").Append(TimeIntervalInSeconds).Append("\n");
            sb.Append("  Encoding: ").Append(Encoding).Append("\n");
            sb.Append("  Algorithm: ").Append(Algorithm).Append("\n");
            sb.Append("  PassCodeLength: ").Append(PassCodeLength).Append("\n");
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
            return this.Equals(input as AuthenticatorMethodTotpAllOfSettings);
        }

        /// <summary>
        /// Returns true if AuthenticatorMethodTotpAllOfSettings instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthenticatorMethodTotpAllOfSettings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthenticatorMethodTotpAllOfSettings input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.TimeIntervalInSeconds == input.TimeIntervalInSeconds ||
                    this.TimeIntervalInSeconds.Equals(input.TimeIntervalInSeconds)
                ) && 
                (
                    this.Encoding == input.Encoding ||
                    this.Encoding.Equals(input.Encoding)
                ) && 
                (
                    this.Algorithm == input.Algorithm ||
                    this.Algorithm.Equals(input.Algorithm)
                ) && 
                (
                    this.PassCodeLength == input.PassCodeLength ||
                    this.PassCodeLength.Equals(input.PassCodeLength)
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
                
                hashCode = (hashCode * 59) + this.TimeIntervalInSeconds.GetHashCode();
                if (this.Encoding != null)
                {
                    hashCode = (hashCode * 59) + this.Encoding.GetHashCode();
                }
                if (this.Algorithm != null)
                {
                    hashCode = (hashCode * 59) + this.Algorithm.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PassCodeLength.GetHashCode();
                return hashCode;
            }
        }

    }

}
