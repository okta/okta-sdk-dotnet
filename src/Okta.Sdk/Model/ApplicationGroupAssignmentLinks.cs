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
    /// ApplicationGroupAssignmentLinks
    /// </summary>
    [DataContract(Name = "ApplicationGroupAssignment__links")]
    
    public partial class ApplicationGroupAssignmentLinks : IEquatable<ApplicationGroupAssignmentLinks>
    {
        
        /// <summary>
        /// Gets or Sets Self
        /// </summary>
        [DataMember(Name = "self", EmitDefaultValue = true)]
        public HrefObjectSelfLink Self { get; set; }

        /// <summary>
        /// Gets or Sets App
        /// </summary>
        [DataMember(Name = "app", EmitDefaultValue = true)]
        public HrefObjectAppLink App { get; set; }

        /// <summary>
        /// Gets or Sets Group
        /// </summary>
        [DataMember(Name = "group", EmitDefaultValue = true)]
        public HrefObjectGroupLink Group { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ApplicationGroupAssignmentLinks {\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  App: ").Append(App).Append("\n");
            sb.Append("  Group: ").Append(Group).Append("\n");
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
            return this.Equals(input as ApplicationGroupAssignmentLinks);
        }

        /// <summary>
        /// Returns true if ApplicationGroupAssignmentLinks instances are equal
        /// </summary>
        /// <param name="input">Instance of ApplicationGroupAssignmentLinks to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApplicationGroupAssignmentLinks input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Self == input.Self ||
                    (this.Self != null &&
                    this.Self.Equals(input.Self))
                ) && 
                (
                    this.App == input.App ||
                    (this.App != null &&
                    this.App.Equals(input.App))
                ) && 
                (
                    this.Group == input.Group ||
                    (this.Group != null &&
                    this.Group.Equals(input.Group))
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
                
                if (this.Self != null)
                {
                    hashCode = (hashCode * 59) + this.Self.GetHashCode();
                }
                if (this.App != null)
                {
                    hashCode = (hashCode * 59) + this.App.GetHashCode();
                }
                if (this.Group != null)
                {
                    hashCode = (hashCode * 59) + this.Group.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
