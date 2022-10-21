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
    /// Defines AllowedForEnum
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class AllowedForEnum : StringEnum
    {
        /// <summary>
        /// StringEnum AllowedForEnum for value: any
        /// </summary>
        public static AllowedForEnum Any = new AllowedForEnum("any");
        /// <summary>
        /// StringEnum AllowedForEnum for value: none
        /// </summary>
        public static AllowedForEnum None = new AllowedForEnum("none");
        /// <summary>
        /// StringEnum AllowedForEnum for value: recovery
        /// </summary>
        public static AllowedForEnum Recovery = new AllowedForEnum("recovery");
        /// <summary>
        /// StringEnum AllowedForEnum for value: sso
        /// </summary>
        public static AllowedForEnum Sso = new AllowedForEnum("sso");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="AllowedForEnum"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator AllowedForEnum(string value) => new AllowedForEnum(value);

        /// <summary>
        /// Creates a new <see cref="AllowedForEnum"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public AllowedForEnum(string value)
            : base(value)
        {
        }
    }


}
