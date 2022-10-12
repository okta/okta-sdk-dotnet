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
    /// Defines PolicyNetworkConnection
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of PolicyNetworkConnection values in the Okta API.
    /// </summary>
    public sealed class PolicyNetworkConnection : StringEnum
    {
         /// <summary>
        /// StringEnum PolicyNetworkConnection for value: ANYWHERE
        /// </summary>
        public static PolicyNetworkConnection ANYWHERE = new PolicyNetworkConnection("ANYWHERE");
         /// <summary>
        /// StringEnum PolicyNetworkConnection for value: ZONE
        /// </summary>
        public static PolicyNetworkConnection ZONE = new PolicyNetworkConnection("ZONE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator PolicyNetworkConnection(string value) => new PolicyNetworkConnection(value);

        /// <summary>
        /// Creates a new <see cref="PolicyNetworkConnection"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public PolicyNetworkConnection(string value)
            : base(value)
        {
        }
    }


}
