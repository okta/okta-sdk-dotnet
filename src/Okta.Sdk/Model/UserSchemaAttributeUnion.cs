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
    /// Defines UserSchemaAttributeUnion
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class UserSchemaAttributeUnion : StringEnum
    {
        /// <summary>
        /// StringEnum UserSchemaAttributeUnion for value: DISABLE
        /// </summary>
        public static UserSchemaAttributeUnion DISABLE = new UserSchemaAttributeUnion("DISABLE");
        /// <summary>
        /// StringEnum UserSchemaAttributeUnion for value: ENABLE
        /// </summary>
        public static UserSchemaAttributeUnion ENABLE = new UserSchemaAttributeUnion("ENABLE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator UserSchemaAttributeUnion(string value) => new UserSchemaAttributeUnion(value);

        /// <summary>
        /// Creates a new <see cref="UserSchemaAttributeUnion"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public UserSchemaAttributeUnion(string value)
            : base(value)
        {
        }
    }


}
