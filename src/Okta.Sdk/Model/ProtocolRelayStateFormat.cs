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
    /// Defines ProtocolRelayStateFormat
    /// </summary>
    [JsonConverter(typeof(Okta.Sdk.Client.StringEnumSerializingConverter))]
    public sealed class ProtocolRelayStateFormat : StringEnum
    {
        /// <summary>
        /// StringEnum ProtocolRelayStateFormat for value: FROM_URL
        /// </summary>
        public static ProtocolRelayStateFormat FROMURL = new ProtocolRelayStateFormat("FROM_URL");
        /// <summary>
        /// StringEnum ProtocolRelayStateFormat for value: OPAQUE
        /// </summary>
        public static ProtocolRelayStateFormat OPAQUE = new ProtocolRelayStateFormat("OPAQUE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ProtocolRelayStateFormat(string value) => new ProtocolRelayStateFormat(value);

        /// <summary>
        /// Creates a new <see cref="ProtocolRelayStateFormat"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ProtocolRelayStateFormat(string value)
            : base(value)
        {
        }
    }


}
