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
    /// Operational status of a given agent
    /// </summary>
    /// <value>Operational status of a given agent</value>
    [JsonConverter(typeof(Okta.Sdk.Client.StringEnumSerializingConverter))]
    public sealed class OperationalStatus : StringEnum
    {
        /// <summary>
        /// StringEnum OperationalStatus for value: DEGRADED
        /// </summary>
        public static OperationalStatus DEGRADED = new OperationalStatus("DEGRADED");
        /// <summary>
        /// StringEnum OperationalStatus for value: DISRUPTED
        /// </summary>
        public static OperationalStatus DISRUPTED = new OperationalStatus("DISRUPTED");
        /// <summary>
        /// StringEnum OperationalStatus for value: INACTIVE
        /// </summary>
        public static OperationalStatus INACTIVE = new OperationalStatus("INACTIVE");
        /// <summary>
        /// StringEnum OperationalStatus for value: OPERATIONAL
        /// </summary>
        public static OperationalStatus OPERATIONAL = new OperationalStatus("OPERATIONAL");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OperationalStatus(string value) => new OperationalStatus(value);

        /// <summary>
        /// Creates a new <see cref="OperationalStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OperationalStatus(string value)
            : base(value)
        {
        }
    }


}
