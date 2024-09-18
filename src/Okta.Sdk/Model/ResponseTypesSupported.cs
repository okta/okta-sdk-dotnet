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
    /// Defines ResponseTypesSupported
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class ResponseTypesSupported : StringEnum
    {
        /// <summary>
        /// StringEnum ResponseTypesSupported for value: code
        /// </summary>
        public static ResponseTypesSupported Code = new ResponseTypesSupported("code");
        /// <summary>
        /// StringEnum ResponseTypesSupported for value: code id_token
        /// </summary>
        public static ResponseTypesSupported CodeIdToken = new ResponseTypesSupported("code id_token");
        /// <summary>
        /// StringEnum ResponseTypesSupported for value: code id_token token
        /// </summary>
        public static ResponseTypesSupported CodeIdTokenToken = new ResponseTypesSupported("code id_token token");
        /// <summary>
        /// StringEnum ResponseTypesSupported for value: code token
        /// </summary>
        public static ResponseTypesSupported CodeToken = new ResponseTypesSupported("code token");
        /// <summary>
        /// StringEnum ResponseTypesSupported for value: id_token
        /// </summary>
        public static ResponseTypesSupported IdToken = new ResponseTypesSupported("id_token");
        /// <summary>
        /// StringEnum ResponseTypesSupported for value: id_token token
        /// </summary>
        public static ResponseTypesSupported IdTokenToken = new ResponseTypesSupported("id_token token");
        /// <summary>
        /// StringEnum ResponseTypesSupported for value: token
        /// </summary>
        public static ResponseTypesSupported Token = new ResponseTypesSupported("token");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ResponseTypesSupported"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ResponseTypesSupported(string value) => new ResponseTypesSupported(value);

        /// <summary>
        /// Creates a new <see cref="ResponseTypesSupported"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ResponseTypesSupported(string value)
            : base(value)
        {
        }
    }


}