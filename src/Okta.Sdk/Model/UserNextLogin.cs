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
    /// Defines UserNextLogin
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class UserNextLogin : StringEnum
    {
        /// <summary>
        /// StringEnum UserNextLogin for value: changePassword
        /// </summary>
        public static UserNextLogin ChangePassword = new UserNextLogin("changePassword");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator UserNextLogin(string value) => new UserNextLogin(value);

        /// <summary>
        /// Creates a new <see cref="UserNextLogin"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public UserNextLogin(string value)
            : base(value)
        {
        }
    }


}
