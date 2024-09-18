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
    /// UserFactorSupported
    /// </summary>
    [DataContract(Name = "UserFactorSupported")]
    
    public partial class UserFactorSupported : IEquatable<UserFactorSupported>
    {
        /// <summary>
        /// Indicates if the Factor is required for the specified user
        /// </summary>
        /// <value>Indicates if the Factor is required for the specified user</value>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class EnrollmentEnum : StringEnum
        {
            /// <summary>
            /// StringEnum OPTIONAL for value: OPTIONAL
            /// </summary>
            
            public static EnrollmentEnum OPTIONAL = new EnrollmentEnum("OPTIONAL");

            /// <summary>
            /// StringEnum REQUIRED for value: REQUIRED
            /// </summary>
            
            public static EnrollmentEnum REQUIRED = new EnrollmentEnum("REQUIRED");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="EnrollmentEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator EnrollmentEnum(string value) => new EnrollmentEnum(value);

            /// <summary>
            /// Creates a new <see cref="Enrollment"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public EnrollmentEnum(string value)
                : base(value)
            {
            }
        }


        /// <summary>
        /// Indicates if the Factor is required for the specified user
        /// </summary>
        /// <value>Indicates if the Factor is required for the specified user</value>
        [DataMember(Name = "enrollment", EmitDefaultValue = true)]
        
        public EnrollmentEnum Enrollment { get; set; }

        /// <summary>
        /// Gets or Sets FactorType
        /// </summary>
        [DataMember(Name = "factorType", EmitDefaultValue = true)]
        
        public UserFactorType FactorType { get; set; }

        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        [DataMember(Name = "provider", EmitDefaultValue = true)]
        
        public UserFactorProvider Provider { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = true)]
        
        public UserFactorStatus Status { get; set; }
        
        /// <summary>
        /// Name of the Factor vendor. This is usually the same as the provider except for On-Prem MFA where it depends on administrator settings.
        /// </summary>
        /// <value>Name of the Factor vendor. This is usually the same as the provider except for On-Prem MFA where it depends on administrator settings.</value>
        [DataMember(Name = "vendorName", EmitDefaultValue = true)]
        public string VendorName { get; private set; }

        /// <summary>
        /// Returns false as VendorName should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeVendorName()
        {
            return false;
        }
        /// <summary>
        /// Embedded resources related to the Factor
        /// </summary>
        /// <value>Embedded resources related to the Factor</value>
        [DataMember(Name = "_embedded", EmitDefaultValue = true)]
        public Dictionary<string, Object> Embedded { get; private set; }

        /// <summary>
        /// Returns false as Embedded should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeEmbedded()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = true)]
        public UserFactorLinks Links { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserFactorSupported {\n");
            sb.Append("  Enrollment: ").Append(Enrollment).Append("\n");
            sb.Append("  FactorType: ").Append(FactorType).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  VendorName: ").Append(VendorName).Append("\n");
            sb.Append("  Embedded: ").Append(Embedded).Append("\n");
            sb.Append("  Links: ").Append(Links).Append("\n");
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
            return this.Equals(input as UserFactorSupported);
        }

        /// <summary>
        /// Returns true if UserFactorSupported instances are equal
        /// </summary>
        /// <param name="input">Instance of UserFactorSupported to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserFactorSupported input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Enrollment == input.Enrollment ||
                    this.Enrollment.Equals(input.Enrollment)
                ) && 
                (
                    this.FactorType == input.FactorType ||
                    this.FactorType.Equals(input.FactorType)
                ) && 
                (
                    this.Provider == input.Provider ||
                    this.Provider.Equals(input.Provider)
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.VendorName == input.VendorName ||
                    (this.VendorName != null &&
                    this.VendorName.Equals(input.VendorName))
                ) && 
                (
                    this.Embedded == input.Embedded ||
                    this.Embedded != null &&
                    input.Embedded != null &&
                    this.Embedded.SequenceEqual(input.Embedded)
                ) && 
                (
                    this.Links == input.Links ||
                    (this.Links != null &&
                    this.Links.Equals(input.Links))
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
                
                if (this.Enrollment != null)
                {
                    hashCode = (hashCode * 59) + this.Enrollment.GetHashCode();
                }
                if (this.FactorType != null)
                {
                    hashCode = (hashCode * 59) + this.FactorType.GetHashCode();
                }
                if (this.Provider != null)
                {
                    hashCode = (hashCode * 59) + this.Provider.GetHashCode();
                }
                if (this.Status != null)
                {
                    hashCode = (hashCode * 59) + this.Status.GetHashCode();
                }
                if (this.VendorName != null)
                {
                    hashCode = (hashCode * 59) + this.VendorName.GetHashCode();
                }
                if (this.Embedded != null)
                {
                    hashCode = (hashCode * 59) + this.Embedded.GetHashCode();
                }
                if (this.Links != null)
                {
                    hashCode = (hashCode * 59) + this.Links.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}