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
    /// SAML test details
    /// </summary>
    [DataContract(Name = "TestInfo_samlTestConfiguration")]
    
    public partial class TestInfoSamlTestConfiguration : IEquatable<TestInfoSamlTestConfiguration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestInfoSamlTestConfiguration" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public TestInfoSamlTestConfiguration() { }
        
        /// <summary>
        /// Indicates if your integration supports IdP-initiated sign-in
        /// </summary>
        /// <value>Indicates if your integration supports IdP-initiated sign-in</value>
        [DataMember(Name = "idp", EmitDefaultValue = true)]
        public bool Idp { get; set; }

        /// <summary>
        /// Indicates if your integration supports SP-initiated sign-in
        /// </summary>
        /// <value>Indicates if your integration supports SP-initiated sign-in</value>
        [DataMember(Name = "sp", EmitDefaultValue = true)]
        public bool Sp { get; set; }

        /// <summary>
        /// Indicates if your integration supports Just-In-Time (JIT) provisioning
        /// </summary>
        /// <value>Indicates if your integration supports Just-In-Time (JIT) provisioning</value>
        [DataMember(Name = "jit", EmitDefaultValue = true)]
        public bool Jit { get; set; }

        /// <summary>
        /// URL for SP-initiated sign-in flows (required if &#x60;sp &#x3D; true&#x60;)
        /// </summary>
        /// <value>URL for SP-initiated sign-in flows (required if &#x60;sp &#x3D; true&#x60;)</value>
        [DataMember(Name = "spInitiateUrl", EmitDefaultValue = true)]
        public string SpInitiateUrl { get; set; }

        /// <summary>
        /// Instructions on how to sign in to your app using the SP-initiated flow (required if &#x60;sp &#x3D; true&#x60;)
        /// </summary>
        /// <value>Instructions on how to sign in to your app using the SP-initiated flow (required if &#x60;sp &#x3D; true&#x60;)</value>
        [DataMember(Name = "spInitiateDescription", EmitDefaultValue = true)]
        public string SpInitiateDescription { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TestInfoSamlTestConfiguration {\n");
            sb.Append("  Idp: ").Append(Idp).Append("\n");
            sb.Append("  Sp: ").Append(Sp).Append("\n");
            sb.Append("  Jit: ").Append(Jit).Append("\n");
            sb.Append("  SpInitiateUrl: ").Append(SpInitiateUrl).Append("\n");
            sb.Append("  SpInitiateDescription: ").Append(SpInitiateDescription).Append("\n");
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
            return this.Equals(input as TestInfoSamlTestConfiguration);
        }

        /// <summary>
        /// Returns true if TestInfoSamlTestConfiguration instances are equal
        /// </summary>
        /// <param name="input">Instance of TestInfoSamlTestConfiguration to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TestInfoSamlTestConfiguration input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Idp == input.Idp ||
                    this.Idp.Equals(input.Idp)
                ) && 
                (
                    this.Sp == input.Sp ||
                    this.Sp.Equals(input.Sp)
                ) && 
                (
                    this.Jit == input.Jit ||
                    this.Jit.Equals(input.Jit)
                ) && 
                (
                    this.SpInitiateUrl == input.SpInitiateUrl ||
                    (this.SpInitiateUrl != null &&
                    this.SpInitiateUrl.Equals(input.SpInitiateUrl))
                ) && 
                (
                    this.SpInitiateDescription == input.SpInitiateDescription ||
                    (this.SpInitiateDescription != null &&
                    this.SpInitiateDescription.Equals(input.SpInitiateDescription))
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
                
                hashCode = (hashCode * 59) + this.Idp.GetHashCode();
                hashCode = (hashCode * 59) + this.Sp.GetHashCode();
                hashCode = (hashCode * 59) + this.Jit.GetHashCode();
                if (this.SpInitiateUrl != null)
                {
                    hashCode = (hashCode * 59) + this.SpInitiateUrl.GetHashCode();
                }
                if (this.SpInitiateDescription != null)
                {
                    hashCode = (hashCode * 59) + this.SpInitiateDescription.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}