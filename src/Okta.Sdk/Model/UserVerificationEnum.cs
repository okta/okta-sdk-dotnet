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
    /// Defines UserVerificationEnum
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class UserVerificationEnum : StringEnum
    {
        /// <summary>
        /// StringEnum UserVerificationEnum for value: PREFERRED
        /// </summary>
        public static UserVerificationEnum PREFERRED = new UserVerificationEnum("PREFERRED");
        /// <summary>
        /// StringEnum UserVerificationEnum for value: REQUIRED
        /// </summary>
        public static UserVerificationEnum REQUIRED = new UserVerificationEnum("REQUIRED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="UserVerificationEnum"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator UserVerificationEnum(string value) => new UserVerificationEnum(value);

        /// <summary>
        /// Creates a new <see cref="UserVerificationEnum"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public UserVerificationEnum(string value)
            : base(value)
        {
        }
    }


}
