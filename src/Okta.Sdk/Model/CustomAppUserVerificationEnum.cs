/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.07.0
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
    /// User verification setting
    /// </summary>
    /// <value>User verification setting</value>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class CustomAppUserVerificationEnum : StringEnum
    {
        /// <summary>
        /// StringEnum CustomAppUserVerificationEnum for value: PREFERRED
        /// </summary>
        public static CustomAppUserVerificationEnum PREFERRED = new CustomAppUserVerificationEnum("PREFERRED");
        /// <summary>
        /// StringEnum CustomAppUserVerificationEnum for value: REQUIRED
        /// </summary>
        public static CustomAppUserVerificationEnum REQUIRED = new CustomAppUserVerificationEnum("REQUIRED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="CustomAppUserVerificationEnum"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator CustomAppUserVerificationEnum(string value) => new CustomAppUserVerificationEnum(value);

        /// <summary>
        /// Creates a new <see cref="CustomAppUserVerificationEnum"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public CustomAppUserVerificationEnum(string value)
            : base(value)
        {
        }
    }


}
