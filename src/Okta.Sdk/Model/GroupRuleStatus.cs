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
    /// Defines GroupRuleStatus
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of GroupRuleStatus values in the Okta API.
    /// </summary>
    public sealed class GroupRuleStatus : StringEnum
    {
         /// <summary>
        /// StringEnum GroupRuleStatus for value: ACTIVE
        /// </summary>
        public static GroupRuleStatus ACTIVE = new GroupRuleStatus("ACTIVE");
         /// <summary>
        /// StringEnum GroupRuleStatus for value: INACTIVE
        /// </summary>
        public static GroupRuleStatus INACTIVE = new GroupRuleStatus("INACTIVE");
         /// <summary>
        /// StringEnum GroupRuleStatus for value: INVALID
        /// </summary>
        public static GroupRuleStatus INVALID = new GroupRuleStatus("INVALID");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator GroupRuleStatus(string value) => new GroupRuleStatus(value);

        /// <summary>
        /// Creates a new <see cref="GroupRuleStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public GroupRuleStatus(string value)
            : base(value)
        {
        }
    }


}
