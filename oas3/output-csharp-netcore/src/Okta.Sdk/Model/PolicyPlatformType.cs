/*
 * Okta API
 *
 * Allows customers to easily access the Okta API
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
    /// Defines PolicyPlatformType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PolicyPlatformType
    {
        /// <summary>
        /// Enum ANY for value: ANY
        /// </summary>
        [EnumMember(Value = "ANY")]
        ANY = 1,

        /// <summary>
        /// Enum DESKTOP for value: DESKTOP
        /// </summary>
        [EnumMember(Value = "DESKTOP")]
        DESKTOP = 2,

        /// <summary>
        /// Enum MOBILE for value: MOBILE
        /// </summary>
        [EnumMember(Value = "MOBILE")]
        MOBILE = 3,

        /// <summary>
        /// Enum OTHER for value: OTHER
        /// </summary>
        [EnumMember(Value = "OTHER")]
        OTHER = 4

    }

}
