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
    /// SupportedMethodsSettings
    /// </summary>
    [DataContract(Name = "SupportedMethods_settings")]
    
    public partial class SupportedMethodsSettings : IEquatable<SupportedMethodsSettings>
    {
        
        /// <summary>
        /// Gets or Sets KeyProtection
        /// </summary>
        [DataMember(Name = "keyProtection", EmitDefaultValue = false)]
        public string KeyProtection { get; set; }

        /// <summary>
        /// Gets or Sets Algorithms
        /// </summary>
        [DataMember(Name = "algorithms", EmitDefaultValue = false)]
        public List<AuthenticatorMethodAlgorithm> Algorithms { get; set; }

        /// <summary>
        /// Gets or Sets TransactionTypes
        /// </summary>
        [DataMember(Name = "transactionTypes", EmitDefaultValue = false)]
        public List<AuthenticatorMethodTransactionType> TransactionTypes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SupportedMethodsSettings {\n");
            sb.Append("  KeyProtection: ").Append(KeyProtection).Append("\n");
            sb.Append("  Algorithms: ").Append(Algorithms).Append("\n");
            sb.Append("  TransactionTypes: ").Append(TransactionTypes).Append("\n");
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
            return this.Equals(input as SupportedMethodsSettings);
        }

        /// <summary>
        /// Returns true if SupportedMethodsSettings instances are equal
        /// </summary>
        /// <param name="input">Instance of SupportedMethodsSettings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SupportedMethodsSettings input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.KeyProtection == input.KeyProtection ||
                    (this.KeyProtection != null &&
                    this.KeyProtection.Equals(input.KeyProtection))
                ) && 
                (
                    this.Algorithms == input.Algorithms ||
                    this.Algorithms != null &&
                    input.Algorithms != null &&
                    this.Algorithms.SequenceEqual(input.Algorithms)
                ) && 
                (
                    this.TransactionTypes == input.TransactionTypes ||
                    this.TransactionTypes != null &&
                    input.TransactionTypes != null &&
                    this.TransactionTypes.SequenceEqual(input.TransactionTypes)
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
                
                if (this.KeyProtection != null)
                {
                    hashCode = (hashCode * 59) + this.KeyProtection.GetHashCode();
                }
                if (this.Algorithms != null)
                {
                    hashCode = (hashCode * 59) + this.Algorithms.GetHashCode();
                }
                if (this.TransactionTypes != null)
                {
                    hashCode = (hashCode * 59) + this.TransactionTypes.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
