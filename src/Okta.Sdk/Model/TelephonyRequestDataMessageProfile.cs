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
    /// Message profile specifies information about the telephony (sms/voice) message to be sent to the Okta user
    /// </summary>
    [DataContract(Name = "TelephonyRequestData_messageProfile")]
    
    public partial class TelephonyRequestDataMessageProfile : IEquatable<TelephonyRequestDataMessageProfile>
    {
        
        /// <summary>
        /// Default or Okta org configured sms or voice message template
        /// </summary>
        /// <value>Default or Okta org configured sms or voice message template</value>
        [DataMember(Name = "msgTemplate", EmitDefaultValue = true)]
        public string MsgTemplate { get; set; }

        /// <summary>
        /// The Okta&#39;s user&#39;s phone number
        /// </summary>
        /// <value>The Okta&#39;s user&#39;s phone number</value>
        [DataMember(Name = "phoneNumber", EmitDefaultValue = true)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The time when OTP expires
        /// </summary>
        /// <value>The time when OTP expires</value>
        [DataMember(Name = "otpExpires", EmitDefaultValue = true)]
        public string OtpExpires { get; set; }

        /// <summary>
        /// The channel for OTP delivery - SMS or voice
        /// </summary>
        /// <value>The channel for OTP delivery - SMS or voice</value>
        [DataMember(Name = "deliveryChannel", EmitDefaultValue = true)]
        public string DeliveryChannel { get; set; }

        /// <summary>
        /// The OTP code requested by the Okta user
        /// </summary>
        /// <value>The OTP code requested by the Okta user</value>
        [DataMember(Name = "otpCode", EmitDefaultValue = true)]
        public string OtpCode { get; set; }

        /// <summary>
        /// The locale associated with the Okta user
        /// </summary>
        /// <value>The locale associated with the Okta user</value>
        [DataMember(Name = "locale", EmitDefaultValue = true)]
        public string Locale { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TelephonyRequestDataMessageProfile {\n");
            sb.Append("  MsgTemplate: ").Append(MsgTemplate).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  OtpExpires: ").Append(OtpExpires).Append("\n");
            sb.Append("  DeliveryChannel: ").Append(DeliveryChannel).Append("\n");
            sb.Append("  OtpCode: ").Append(OtpCode).Append("\n");
            sb.Append("  Locale: ").Append(Locale).Append("\n");
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
            return this.Equals(input as TelephonyRequestDataMessageProfile);
        }

        /// <summary>
        /// Returns true if TelephonyRequestDataMessageProfile instances are equal
        /// </summary>
        /// <param name="input">Instance of TelephonyRequestDataMessageProfile to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TelephonyRequestDataMessageProfile input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.MsgTemplate == input.MsgTemplate ||
                    (this.MsgTemplate != null &&
                    this.MsgTemplate.Equals(input.MsgTemplate))
                ) && 
                (
                    this.PhoneNumber == input.PhoneNumber ||
                    (this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(input.PhoneNumber))
                ) && 
                (
                    this.OtpExpires == input.OtpExpires ||
                    (this.OtpExpires != null &&
                    this.OtpExpires.Equals(input.OtpExpires))
                ) && 
                (
                    this.DeliveryChannel == input.DeliveryChannel ||
                    (this.DeliveryChannel != null &&
                    this.DeliveryChannel.Equals(input.DeliveryChannel))
                ) && 
                (
                    this.OtpCode == input.OtpCode ||
                    (this.OtpCode != null &&
                    this.OtpCode.Equals(input.OtpCode))
                ) && 
                (
                    this.Locale == input.Locale ||
                    (this.Locale != null &&
                    this.Locale.Equals(input.Locale))
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
                
                if (this.MsgTemplate != null)
                {
                    hashCode = (hashCode * 59) + this.MsgTemplate.GetHashCode();
                }
                if (this.PhoneNumber != null)
                {
                    hashCode = (hashCode * 59) + this.PhoneNumber.GetHashCode();
                }
                if (this.OtpExpires != null)
                {
                    hashCode = (hashCode * 59) + this.OtpExpires.GetHashCode();
                }
                if (this.DeliveryChannel != null)
                {
                    hashCode = (hashCode * 59) + this.DeliveryChannel.GetHashCode();
                }
                if (this.OtpCode != null)
                {
                    hashCode = (hashCode * 59) + this.OtpCode.GetHashCode();
                }
                if (this.Locale != null)
                {
                    hashCode = (hashCode * 59) + this.Locale.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}