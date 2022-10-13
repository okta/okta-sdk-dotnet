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
    /// Defines RequiredEnum
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class RequiredEnum : StringEnum
    {
        /// <summary>
        /// StringEnum RequiredEnum for value: ALWAYS
        /// </summary>
        public static RequiredEnum ALWAYS = new RequiredEnum("ALWAYS");
        /// <summary>
        /// StringEnum RequiredEnum for value: HIGH_RISK_ONLY
        /// </summary>
        public static RequiredEnum HIGHRISKONLY = new RequiredEnum("HIGH_RISK_ONLY");
        /// <summary>
        /// StringEnum RequiredEnum for value: NEVER
        /// </summary>
        public static RequiredEnum NEVER = new RequiredEnum("NEVER");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator RequiredEnum(string value) => new RequiredEnum(value);

        /// <summary>
        /// Creates a new <see cref="RequiredEnum"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public RequiredEnum(string value)
            : base(value)
        {
        }
    }


}
