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
    /// Defines OAuth2ClaimValueType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class OAuth2ClaimValueType : StringEnum
    {
        /// <summary>
        /// StringEnum OAuth2ClaimValueType for value: EXPRESSION
        /// </summary>
        public static OAuth2ClaimValueType EXPRESSION = new OAuth2ClaimValueType("EXPRESSION");
        /// <summary>
        /// StringEnum OAuth2ClaimValueType for value: GROUPS
        /// </summary>
        public static OAuth2ClaimValueType GROUPS = new OAuth2ClaimValueType("GROUPS");
        /// <summary>
        /// StringEnum OAuth2ClaimValueType for value: SYSTEM
        /// </summary>
        public static OAuth2ClaimValueType SYSTEM = new OAuth2ClaimValueType("SYSTEM");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OAuth2ClaimValueType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OAuth2ClaimValueType(string value) => new OAuth2ClaimValueType(value);

        /// <summary>
        /// Creates a new <see cref="OAuth2ClaimValueType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OAuth2ClaimValueType(string value)
            : base(value)
        {
        }
    }


}
