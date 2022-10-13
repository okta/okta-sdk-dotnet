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
    /// Defines FactorType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class FactorType : StringEnum
    {
        /// <summary>
        /// StringEnum FactorType for value: call
        /// </summary>
        public static FactorType Call = new FactorType("call");
        /// <summary>
        /// StringEnum FactorType for value: email
        /// </summary>
        public static FactorType Email = new FactorType("email");
        /// <summary>
        /// StringEnum FactorType for value: hotp
        /// </summary>
        public static FactorType Hotp = new FactorType("hotp");
        /// <summary>
        /// StringEnum FactorType for value: push
        /// </summary>
        public static FactorType Push = new FactorType("push");
        /// <summary>
        /// StringEnum FactorType for value: question
        /// </summary>
        public static FactorType Question = new FactorType("question");
        /// <summary>
        /// StringEnum FactorType for value: sms
        /// </summary>
        public static FactorType Sms = new FactorType("sms");
        /// <summary>
        /// StringEnum FactorType for value: token
        /// </summary>
        public static FactorType Token = new FactorType("token");
        /// <summary>
        /// StringEnum FactorType for value: token:hardware
        /// </summary>
        public static FactorType Tokenhardware = new FactorType("token:hardware");
        /// <summary>
        /// StringEnum FactorType for value: token:hotp
        /// </summary>
        public static FactorType Tokenhotp = new FactorType("token:hotp");
        /// <summary>
        /// StringEnum FactorType for value: token:software:totp
        /// </summary>
        public static FactorType Tokensoftwaretotp = new FactorType("token:software:totp");
        /// <summary>
        /// StringEnum FactorType for value: u2f
        /// </summary>
        public static FactorType U2f = new FactorType("u2f");
        /// <summary>
        /// StringEnum FactorType for value: web
        /// </summary>
        public static FactorType Web = new FactorType("web");
        /// <summary>
        /// StringEnum FactorType for value: webauthn
        /// </summary>
        public static FactorType Webauthn = new FactorType("webauthn");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator FactorType(string value) => new FactorType(value);

        /// <summary>
        /// Creates a new <see cref="FactorType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public FactorType(string value)
            : base(value)
        {
        }
    }


}
