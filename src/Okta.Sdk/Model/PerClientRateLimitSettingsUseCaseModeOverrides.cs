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
    /// A map of Per-Client Rate Limit Use Case to the applicable PerClientRateLimitMode. Overrides the &#x60;defaultMode&#x60; property for the specified use cases.
    /// </summary>
    [DataContract(Name = "PerClientRateLimitSettings_useCaseModeOverrides")]
    
    public partial class PerClientRateLimitSettingsUseCaseModeOverrides : IEquatable<PerClientRateLimitSettingsUseCaseModeOverrides>
    {

        /// <summary>
        /// Gets or Sets LOGIN_PAGE
        /// </summary>
        [DataMember(Name = "LOGIN_PAGE", EmitDefaultValue = false)]
        
        public PerClientRateLimitMode LOGIN_PAGE { get; set; }

        /// <summary>
        /// Gets or Sets OAUTH2AUTHORIZE
        /// </summary>
        [DataMember(Name = "OAUTH2_AUTHORIZE", EmitDefaultValue = false)]
        
        public PerClientRateLimitMode OAUTH2AUTHORIZE { get; set; }

        /// <summary>
        /// Gets or Sets OIE_APP_INTENT
        /// </summary>
        [DataMember(Name = "OIE_APP_INTENT", EmitDefaultValue = false)]
        
        public PerClientRateLimitMode OIE_APP_INTENT { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PerClientRateLimitSettingsUseCaseModeOverrides {\n");
            sb.Append("  LOGIN_PAGE: ").Append(LOGIN_PAGE).Append("\n");
            sb.Append("  OAUTH2AUTHORIZE: ").Append(OAUTH2AUTHORIZE).Append("\n");
            sb.Append("  OIE_APP_INTENT: ").Append(OIE_APP_INTENT).Append("\n");
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
            return this.Equals(input as PerClientRateLimitSettingsUseCaseModeOverrides);
        }

        /// <summary>
        /// Returns true if PerClientRateLimitSettingsUseCaseModeOverrides instances are equal
        /// </summary>
        /// <param name="input">Instance of PerClientRateLimitSettingsUseCaseModeOverrides to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PerClientRateLimitSettingsUseCaseModeOverrides input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.LOGIN_PAGE == input.LOGIN_PAGE ||
                    this.LOGIN_PAGE.Equals(input.LOGIN_PAGE)
                ) && 
                (
                    this.OAUTH2AUTHORIZE == input.OAUTH2AUTHORIZE ||
                    this.OAUTH2AUTHORIZE.Equals(input.OAUTH2AUTHORIZE)
                ) && 
                (
                    this.OIE_APP_INTENT == input.OIE_APP_INTENT ||
                    this.OIE_APP_INTENT.Equals(input.OIE_APP_INTENT)
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
                
                hashCode = (hashCode * 59) + this.LOGIN_PAGE.GetHashCode();
                hashCode = (hashCode * 59) + this.OAUTH2AUTHORIZE.GetHashCode();
                hashCode = (hashCode * 59) + this.OIE_APP_INTENT.GetHashCode();
                return hashCode;
            }
        }

    }

}
