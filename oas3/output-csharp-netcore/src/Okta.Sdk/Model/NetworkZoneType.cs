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
    /// Defines NetworkZoneType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NetworkZoneType
    {
        /// <summary>
        /// Enum DYNAMIC for value: DYNAMIC
        /// </summary>
        [EnumMember(Value = "DYNAMIC")]
        DYNAMIC = 1,

        /// <summary>
        /// Enum IP for value: IP
        /// </summary>
        [EnumMember(Value = "IP")]
        IP = 2

    }

}
