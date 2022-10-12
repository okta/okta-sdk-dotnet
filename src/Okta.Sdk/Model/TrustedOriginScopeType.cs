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
    /// Defines TrustedOriginScopeType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of TrustedOriginScopeType values in the Okta API.
    /// </summary>
    public sealed class TrustedOriginScopeType : StringEnum
    {
         /// <summary>
        /// StringEnum TrustedOriginScopeType for value: CORS
        /// </summary>
        public static TrustedOriginScopeType CORS = new TrustedOriginScopeType("CORS");
         /// <summary>
        /// StringEnum TrustedOriginScopeType for value: IFRAME_EMBED
        /// </summary>
        public static TrustedOriginScopeType IFRAMEEMBED = new TrustedOriginScopeType("IFRAME_EMBED");
         /// <summary>
        /// StringEnum TrustedOriginScopeType for value: REDIRECT
        /// </summary>
        public static TrustedOriginScopeType REDIRECT = new TrustedOriginScopeType("REDIRECT");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator TrustedOriginScopeType(string value) => new TrustedOriginScopeType(value);

        /// <summary>
        /// Creates a new <see cref="TrustedOriginScopeType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public TrustedOriginScopeType(string value)
            : base(value)
        {
        }
    }


}
