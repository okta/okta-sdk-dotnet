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
    /// Result of a Factor verification attempt
    /// </summary>
    /// <value>Result of a Factor verification attempt</value>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class UserFactorResultType : StringEnum
    {
        /// <summary>
        /// StringEnum UserFactorResultType for value: CANCELLED
        /// </summary>
        public static UserFactorResultType CANCELLED = new UserFactorResultType("CANCELLED");
        /// <summary>
        /// StringEnum UserFactorResultType for value: CHALLENGE
        /// </summary>
        public static UserFactorResultType CHALLENGE = new UserFactorResultType("CHALLENGE");
        /// <summary>
        /// StringEnum UserFactorResultType for value: ERROR
        /// </summary>
        public static UserFactorResultType ERROR = new UserFactorResultType("ERROR");
        /// <summary>
        /// StringEnum UserFactorResultType for value: FAILED
        /// </summary>
        public static UserFactorResultType FAILED = new UserFactorResultType("FAILED");
        /// <summary>
        /// StringEnum UserFactorResultType for value: PASSCODE_REPLAYED
        /// </summary>
        public static UserFactorResultType PASSCODEREPLAYED = new UserFactorResultType("PASSCODE_REPLAYED");
        /// <summary>
        /// StringEnum UserFactorResultType for value: REJECTED
        /// </summary>
        public static UserFactorResultType REJECTED = new UserFactorResultType("REJECTED");
        /// <summary>
        /// StringEnum UserFactorResultType for value: SUCCESS
        /// </summary>
        public static UserFactorResultType SUCCESS = new UserFactorResultType("SUCCESS");
        /// <summary>
        /// StringEnum UserFactorResultType for value: TIMEOUT
        /// </summary>
        public static UserFactorResultType TIMEOUT = new UserFactorResultType("TIMEOUT");
        /// <summary>
        /// StringEnum UserFactorResultType for value: TIME_WINDOW_EXCEEDED
        /// </summary>
        public static UserFactorResultType TIMEWINDOWEXCEEDED = new UserFactorResultType("TIME_WINDOW_EXCEEDED");
        /// <summary>
        /// StringEnum UserFactorResultType for value: WAITING
        /// </summary>
        public static UserFactorResultType WAITING = new UserFactorResultType("WAITING");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="UserFactorResultType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator UserFactorResultType(string value) => new UserFactorResultType(value);

        /// <summary>
        /// Creates a new <see cref="UserFactorResultType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public UserFactorResultType(string value)
            : base(value)
        {
        }
    }


}