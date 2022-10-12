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
    /// Defines EnabledStatus
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of EnabledStatus values in the Okta API.
    /// </summary>
    public sealed class EnabledStatus : StringEnum
    {
         /// <summary>
        /// StringEnum EnabledStatus for value: DISABLED
        /// </summary>
        public static EnabledStatus DISABLED = new EnabledStatus("DISABLED");
         /// <summary>
        /// StringEnum EnabledStatus for value: ENABLED
        /// </summary>
        public static EnabledStatus ENABLED = new EnabledStatus("ENABLED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator EnabledStatus(string value) => new EnabledStatus(value);

        /// <summary>
        /// Creates a new <see cref="EnabledStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public EnabledStatus(string value)
            : base(value)
        {
        }
    }


}
