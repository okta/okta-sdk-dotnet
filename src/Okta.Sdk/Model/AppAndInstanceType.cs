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
    /// Type of app
    /// </summary>
    /// <value>Type of app</value>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class AppAndInstanceType : StringEnum
    {
        /// <summary>
        /// StringEnum AppAndInstanceType for value: APP
        /// </summary>
        public static AppAndInstanceType APP = new AppAndInstanceType("APP");
        /// <summary>
        /// StringEnum AppAndInstanceType for value: APP_TYPE
        /// </summary>
        public static AppAndInstanceType APPTYPE = new AppAndInstanceType("APP_TYPE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="AppAndInstanceType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator AppAndInstanceType(string value) => new AppAndInstanceType(value);

        /// <summary>
        /// Creates a new <see cref="AppAndInstanceType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public AppAndInstanceType(string value)
            : base(value)
        {
        }
    }


}
