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
    /// Office365 app instance properties
    /// </summary>
    [DataContract(Name = "Office365ApplicationSettingsApplication")]
    
    public partial class Office365ApplicationSettingsApplication : IEquatable<Office365ApplicationSettingsApplication>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Office365ApplicationSettingsApplication" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Office365ApplicationSettingsApplication() { }
        
        /// <summary>
        /// The domain for your Office 365 account
        /// </summary>
        /// <value>The domain for your Office 365 account</value>
        [DataMember(Name = "domain", EmitDefaultValue = true)]
        public string Domain { get; set; }

        /// <summary>
        /// Microsoft tenant name
        /// </summary>
        /// <value>Microsoft tenant name</value>
        [DataMember(Name = "msftTenant", EmitDefaultValue = true)]
        public string MsftTenant { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Office365ApplicationSettingsApplication {\n");
            sb.Append("  Domain: ").Append(Domain).Append("\n");
            sb.Append("  MsftTenant: ").Append(MsftTenant).Append("\n");
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
            return this.Equals(input as Office365ApplicationSettingsApplication);
        }

        /// <summary>
        /// Returns true if Office365ApplicationSettingsApplication instances are equal
        /// </summary>
        /// <param name="input">Instance of Office365ApplicationSettingsApplication to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Office365ApplicationSettingsApplication input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Domain == input.Domain ||
                    (this.Domain != null &&
                    this.Domain.Equals(input.Domain))
                ) && 
                (
                    this.MsftTenant == input.MsftTenant ||
                    (this.MsftTenant != null &&
                    this.MsftTenant.Equals(input.MsftTenant))
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
                
                if (this.Domain != null)
                {
                    hashCode = (hashCode * 59) + this.Domain.GetHashCode();
                }
                if (this.MsftTenant != null)
                {
                    hashCode = (hashCode * 59) + this.MsftTenant.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
