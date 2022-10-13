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
    /// Defines OpenIdConnectRefreshTokenRotationType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class OpenIdConnectRefreshTokenRotationType : StringEnum
    {
        /// <summary>
        /// StringEnum OpenIdConnectRefreshTokenRotationType for value: ROTATE
        /// </summary>
        public static OpenIdConnectRefreshTokenRotationType ROTATE = new OpenIdConnectRefreshTokenRotationType("ROTATE");
        /// <summary>
        /// StringEnum OpenIdConnectRefreshTokenRotationType for value: STATIC
        /// </summary>
        public static OpenIdConnectRefreshTokenRotationType STATIC = new OpenIdConnectRefreshTokenRotationType("STATIC");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OpenIdConnectRefreshTokenRotationType(string value) => new OpenIdConnectRefreshTokenRotationType(value);

        /// <summary>
        /// Creates a new <see cref="OpenIdConnectRefreshTokenRotationType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OpenIdConnectRefreshTokenRotationType(string value)
            : base(value)
        {
        }
    }


}
