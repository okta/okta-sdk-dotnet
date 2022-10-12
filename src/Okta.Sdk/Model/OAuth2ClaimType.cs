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
    /// Defines OAuth2ClaimType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of OAuth2ClaimType values in the Okta API.
    /// </summary>
    public sealed class OAuth2ClaimType : StringEnum
    {
         /// <summary>
        /// StringEnum OAuth2ClaimType for value: IDENTITY
        /// </summary>
        public static OAuth2ClaimType IDENTITY = new OAuth2ClaimType("IDENTITY");
         /// <summary>
        /// StringEnum OAuth2ClaimType for value: RESOURCE
        /// </summary>
        public static OAuth2ClaimType RESOURCE = new OAuth2ClaimType("RESOURCE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OAuth2ClaimType(string value) => new OAuth2ClaimType(value);

        /// <summary>
        /// Creates a new <see cref="OAuth2ClaimType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OAuth2ClaimType(string value)
            : base(value)
        {
        }
    }


}
