/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.06.1
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
    /// Determines whether a change in a user&#39;s password also updates the user&#39;s password in the application
    /// </summary>
    /// <value>Determines whether a change in a user&#39;s password also updates the user&#39;s password in the application</value>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class ChangeEnum : StringEnum
    {
        /// <summary>
        /// StringEnum ChangeEnum for value: CHANGE
        /// </summary>
        public static ChangeEnum CHANGE = new ChangeEnum("CHANGE");
        /// <summary>
        /// StringEnum ChangeEnum for value: KEEP_EXISTING
        /// </summary>
        public static ChangeEnum KEEPEXISTING = new ChangeEnum("KEEP_EXISTING");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ChangeEnum"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ChangeEnum(string value) => new ChangeEnum(value);

        /// <summary>
        /// Creates a new <see cref="ChangeEnum"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ChangeEnum(string value)
            : base(value)
        {
        }
    }


}
