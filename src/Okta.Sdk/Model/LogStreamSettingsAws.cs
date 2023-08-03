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
    /// Specifies the configuration for the &#x60;aws_eventbridge&#x60; Log Stream type. This configuration can&#39;t be modified after creation.
    /// </summary>
    [DataContract(Name = "LogStreamSettingsAws")]
    
    public partial class LogStreamSettingsAws : IEquatable<LogStreamSettingsAws>
    {

        /// <summary>
        /// Gets or Sets Region
        /// </summary>
        [DataMember(Name = "region", EmitDefaultValue = true)]
        
        public AwsRegion Region { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="LogStreamSettingsAws" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public LogStreamSettingsAws() { }
        
        /// <summary>
        /// Your AWS account ID
        /// </summary>
        /// <value>Your AWS account ID</value>
        [DataMember(Name = "accountId", EmitDefaultValue = true)]
        public string AccountId { get; set; }

        /// <summary>
        /// An alphanumeric name (no spaces) to identify this event source in AWS EventBridge
        /// </summary>
        /// <value>An alphanumeric name (no spaces) to identify this event source in AWS EventBridge</value>
        [DataMember(Name = "eventSourceName", EmitDefaultValue = true)]
        public string EventSourceName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LogStreamSettingsAws {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  EventSourceName: ").Append(EventSourceName).Append("\n");
            sb.Append("  Region: ").Append(Region).Append("\n");
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
            return this.Equals(input as LogStreamSettingsAws);
        }

        /// <summary>
        /// Returns true if LogStreamSettingsAws instances are equal
        /// </summary>
        /// <param name="input">Instance of LogStreamSettingsAws to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LogStreamSettingsAws input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AccountId == input.AccountId ||
                    (this.AccountId != null &&
                    this.AccountId.Equals(input.AccountId))
                ) && 
                (
                    this.EventSourceName == input.EventSourceName ||
                    (this.EventSourceName != null &&
                    this.EventSourceName.Equals(input.EventSourceName))
                ) && 
                (
                    this.Region == input.Region ||
                    this.Region.Equals(input.Region)
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
                
                if (this.AccountId != null)
                {
                    hashCode = (hashCode * 59) + this.AccountId.GetHashCode();
                }
                if (this.EventSourceName != null)
                {
                    hashCode = (hashCode * 59) + this.EventSourceName.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Region.GetHashCode();
                return hashCode;
            }
        }

    }

}
