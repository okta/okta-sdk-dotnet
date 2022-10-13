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
    /// Defines UserIdentifierType
    /// </summary>
    [JsonConverter(typeof(Okta.Sdk.Client.StringEnumSerializingConverter))]
    public sealed class UserIdentifierType : StringEnum
    {
        /// <summary>
        /// StringEnum UserIdentifierType for value: ATTRIBUTE
        /// </summary>
        public static UserIdentifierType ATTRIBUTE = new UserIdentifierType("ATTRIBUTE");
        /// <summary>
        /// StringEnum UserIdentifierType for value: IDENTIFIER
        /// </summary>
        public static UserIdentifierType IDENTIFIER = new UserIdentifierType("IDENTIFIER");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator UserIdentifierType(string value) => new UserIdentifierType(value);

        /// <summary>
        /// Creates a new <see cref="UserIdentifierType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public UserIdentifierType(string value)
            : base(value)
        {
        }
    }


}
