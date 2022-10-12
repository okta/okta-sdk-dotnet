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
    /// Defines InlineHookStatus
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of InlineHookStatus values in the Okta API.
    /// </summary>
    public sealed class InlineHookStatus : StringEnum
    {
         /// <summary>
        /// StringEnum InlineHookStatus for value: ACTIVE
        /// </summary>
        public static InlineHookStatus ACTIVE = new InlineHookStatus("ACTIVE");
         /// <summary>
        /// StringEnum InlineHookStatus for value: INACTIVE
        /// </summary>
        public static InlineHookStatus INACTIVE = new InlineHookStatus("INACTIVE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator InlineHookStatus(string value) => new InlineHookStatus(value);

        /// <summary>
        /// Creates a new <see cref="InlineHookStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public InlineHookStatus(string value)
            : base(value)
        {
        }
    }


}
