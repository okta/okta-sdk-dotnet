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
    /// BulkDeleteRequestBody
    /// </summary>
    [DataContract(Name = "BulkDeleteRequestBody")]
    
    public partial class BulkDeleteRequestBody : IEquatable<BulkDeleteRequestBody>
    {
        /// <summary>
        /// Defines EntityType
        /// </summary>
        [JsonConverter(typeof(StringEnumSerializingConverter))]
        public sealed class EntityTypeEnum : StringEnum
        {
            /// <summary>
            /// StringEnum USERS for value: USERS
            /// </summary>
            
            public static EntityTypeEnum USERS = new EntityTypeEnum("USERS");


            /// <summary>
            /// Implicit operator declaration to accept and convert a string value as a <see cref="EntityTypeEnum"/>
            /// </summary>
            /// <param name="value">The value to use</param>
            public static implicit operator EntityTypeEnum(string value) => new EntityTypeEnum(value);

            /// <summary>
            /// Creates a new <see cref="EntityType"/> instance.
            /// </summary>
            /// <param name="value">The value to use.</param>
            public EntityTypeEnum(string value)
                : base(value)
            {
            }
        }


        /// <summary>
        /// Gets or Sets EntityType
        /// </summary>
        [DataMember(Name = "entityType", EmitDefaultValue = true)]
        
        public EntityTypeEnum EntityType { get; set; }
        
        /// <summary>
        /// Gets or Sets Profiles
        /// </summary>
        [DataMember(Name = "profiles", EmitDefaultValue = true)]
        public List<IdentitySourceUserProfileForDelete> Profiles { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BulkDeleteRequestBody {\n");
            sb.Append("  EntityType: ").Append(EntityType).Append("\n");
            sb.Append("  Profiles: ").Append(Profiles).Append("\n");
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
            return this.Equals(input as BulkDeleteRequestBody);
        }

        /// <summary>
        /// Returns true if BulkDeleteRequestBody instances are equal
        /// </summary>
        /// <param name="input">Instance of BulkDeleteRequestBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BulkDeleteRequestBody input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.EntityType == input.EntityType ||
                    this.EntityType.Equals(input.EntityType)
                ) && 
                (
                    this.Profiles == input.Profiles ||
                    this.Profiles != null &&
                    input.Profiles != null &&
                    this.Profiles.SequenceEqual(input.Profiles)
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
                
                if (this.EntityType != null)
                {
                    hashCode = (hashCode * 59) + this.EntityType.GetHashCode();
                }
                if (this.Profiles != null)
                {
                    hashCode = (hashCode * 59) + this.Profiles.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
