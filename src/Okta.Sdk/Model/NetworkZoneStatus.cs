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
    /// Defines NetworkZoneStatus
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class NetworkZoneStatus : StringEnum
    {
        /// <summary>
        /// StringEnum NetworkZoneStatus for value: ACTIVE
        /// </summary>
        public static NetworkZoneStatus ACTIVE = new NetworkZoneStatus("ACTIVE");
        /// <summary>
        /// StringEnum NetworkZoneStatus for value: INACTIVE
        /// </summary>
        public static NetworkZoneStatus INACTIVE = new NetworkZoneStatus("INACTIVE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator NetworkZoneStatus(string value) => new NetworkZoneStatus(value);

        /// <summary>
        /// Creates a new <see cref="NetworkZoneStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public NetworkZoneStatus(string value)
            : base(value)
        {
        }
    }


}
