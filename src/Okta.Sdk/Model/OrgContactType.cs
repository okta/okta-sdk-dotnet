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
    /// Defines OrgContactType
    /// </summary>
    [JsonConverter(typeof(Okta.Sdk.Client.StringEnumSerializingConverter))]
    public sealed class OrgContactType : StringEnum
    {
        /// <summary>
        /// StringEnum OrgContactType for value: BILLING
        /// </summary>
        public static OrgContactType BILLING = new OrgContactType("BILLING");
        /// <summary>
        /// StringEnum OrgContactType for value: TECHNICAL
        /// </summary>
        public static OrgContactType TECHNICAL = new OrgContactType("TECHNICAL");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OrgContactType(string value) => new OrgContactType(value);

        /// <summary>
        /// Creates a new <see cref="OrgContactType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OrgContactType(string value)
            : base(value)
        {
        }
    }


}
