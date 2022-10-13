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
    /// Defines LogAuthenticationProvider
    /// </summary>
    [JsonConverter(typeof(Okta.Sdk.Client.StringEnumSerializingConverter))]
    public sealed class LogAuthenticationProvider : StringEnum
    {
        /// <summary>
        /// StringEnum LogAuthenticationProvider for value: ACTIVE_DIRECTORY
        /// </summary>
        public static LogAuthenticationProvider ACTIVEDIRECTORY = new LogAuthenticationProvider("ACTIVE_DIRECTORY");
        /// <summary>
        /// StringEnum LogAuthenticationProvider for value: FACTOR_PROVIDER
        /// </summary>
        public static LogAuthenticationProvider FACTORPROVIDER = new LogAuthenticationProvider("FACTOR_PROVIDER");
        /// <summary>
        /// StringEnum LogAuthenticationProvider for value: FEDERATION
        /// </summary>
        public static LogAuthenticationProvider FEDERATION = new LogAuthenticationProvider("FEDERATION");
        /// <summary>
        /// StringEnum LogAuthenticationProvider for value: LDAP
        /// </summary>
        public static LogAuthenticationProvider LDAP = new LogAuthenticationProvider("LDAP");
        /// <summary>
        /// StringEnum LogAuthenticationProvider for value: OKTA_AUTHENTICATION_PROVIDER
        /// </summary>
        public static LogAuthenticationProvider OKTAAUTHENTICATIONPROVIDER = new LogAuthenticationProvider("OKTA_AUTHENTICATION_PROVIDER");
        /// <summary>
        /// StringEnum LogAuthenticationProvider for value: SOCIAL
        /// </summary>
        public static LogAuthenticationProvider SOCIAL = new LogAuthenticationProvider("SOCIAL");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator LogAuthenticationProvider(string value) => new LogAuthenticationProvider(value);

        /// <summary>
        /// Creates a new <see cref="LogAuthenticationProvider"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public LogAuthenticationProvider(string value)
            : base(value)
        {
        }
    }


}
