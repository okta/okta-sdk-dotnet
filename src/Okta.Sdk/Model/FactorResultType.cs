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
    /// Defines FactorResultType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class FactorResultType : StringEnum
    {
        /// <summary>
        /// StringEnum FactorResultType for value: CANCELLED
        /// </summary>
        public static FactorResultType CANCELLED = new FactorResultType("CANCELLED");
        /// <summary>
        /// StringEnum FactorResultType for value: CHALLENGE
        /// </summary>
        public static FactorResultType CHALLENGE = new FactorResultType("CHALLENGE");
        /// <summary>
        /// StringEnum FactorResultType for value: ERROR
        /// </summary>
        public static FactorResultType ERROR = new FactorResultType("ERROR");
        /// <summary>
        /// StringEnum FactorResultType for value: FAILED
        /// </summary>
        public static FactorResultType FAILED = new FactorResultType("FAILED");
        /// <summary>
        /// StringEnum FactorResultType for value: PASSCODE_REPLAYED
        /// </summary>
        public static FactorResultType PASSCODEREPLAYED = new FactorResultType("PASSCODE_REPLAYED");
        /// <summary>
        /// StringEnum FactorResultType for value: REJECTED
        /// </summary>
        public static FactorResultType REJECTED = new FactorResultType("REJECTED");
        /// <summary>
        /// StringEnum FactorResultType for value: SUCCESS
        /// </summary>
        public static FactorResultType SUCCESS = new FactorResultType("SUCCESS");
        /// <summary>
        /// StringEnum FactorResultType for value: TIMEOUT
        /// </summary>
        public static FactorResultType TIMEOUT = new FactorResultType("TIMEOUT");
        /// <summary>
        /// StringEnum FactorResultType for value: TIME_WINDOW_EXCEEDED
        /// </summary>
        public static FactorResultType TIMEWINDOWEXCEEDED = new FactorResultType("TIME_WINDOW_EXCEEDED");
        /// <summary>
        /// StringEnum FactorResultType for value: WAITING
        /// </summary>
        public static FactorResultType WAITING = new FactorResultType("WAITING");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="FactorResultType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator FactorResultType(string value) => new FactorResultType(value);

        /// <summary>
        /// Creates a new <see cref="FactorResultType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public FactorResultType(string value)
            : base(value)
        {
        }
    }


}
