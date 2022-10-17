/*
 * Okta Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 3.0.0
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
    /// Defines LogCredentialType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class LogCredentialType : StringEnum
    {
        /// <summary>
        /// StringEnum LogCredentialType for value: ASSERTION
        /// </summary>
        public static LogCredentialType ASSERTION = new LogCredentialType("ASSERTION");
        /// <summary>
        /// StringEnum LogCredentialType for value: EMAIL
        /// </summary>
        public static LogCredentialType EMAIL = new LogCredentialType("EMAIL");
        /// <summary>
        /// StringEnum LogCredentialType for value: IWA
        /// </summary>
        public static LogCredentialType IWA = new LogCredentialType("IWA");
        /// <summary>
        /// StringEnum LogCredentialType for value: JWT
        /// </summary>
        public static LogCredentialType JWT = new LogCredentialType("JWT");
        /// <summary>
        /// StringEnum LogCredentialType for value: OAuth 2.0
        /// </summary>
        public static LogCredentialType OAuth20 = new LogCredentialType("OAuth 2.0");
        /// <summary>
        /// StringEnum LogCredentialType for value: OTP
        /// </summary>
        public static LogCredentialType OTP = new LogCredentialType("OTP");
        /// <summary>
        /// StringEnum LogCredentialType for value: PASSWORD
        /// </summary>
        public static LogCredentialType PASSWORD = new LogCredentialType("PASSWORD");
        /// <summary>
        /// StringEnum LogCredentialType for value: SMS
        /// </summary>
        public static LogCredentialType SMS = new LogCredentialType("SMS");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="LogCredentialType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator LogCredentialType(string value) => new LogCredentialType(value);

        /// <summary>
        /// Creates a new <see cref="LogCredentialType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public LogCredentialType(string value)
            : base(value)
        {
        }
    }


}
