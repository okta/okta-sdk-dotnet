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
    /// Defines FipsEnum
    /// </summary>
    [JsonConverter(typeof(Okta.Sdk.Client.StringEnumSerializingConverter))]
    public sealed class FipsEnum : StringEnum
    {
        /// <summary>
        /// StringEnum FipsEnum for value: OPTIONAL
        /// </summary>
        public static FipsEnum OPTIONAL = new FipsEnum("OPTIONAL");
        /// <summary>
        /// StringEnum FipsEnum for value: REQUIRED
        /// </summary>
        public static FipsEnum REQUIRED = new FipsEnum("REQUIRED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator FipsEnum(string value) => new FipsEnum(value);

        /// <summary>
        /// Creates a new <see cref="FipsEnum"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public FipsEnum(string value)
            : base(value)
        {
        }
    }


}
