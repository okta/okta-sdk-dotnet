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
    /// Indicates whether you must use a hardware key store
    /// </summary>
    /// <value>Indicates whether you must use a hardware key store</value>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class PushMethodKeyProtection : StringEnum
    {
        /// <summary>
        /// StringEnum PushMethodKeyProtection for value: ANY
        /// </summary>
        public static PushMethodKeyProtection ANY = new PushMethodKeyProtection("ANY");
        /// <summary>
        /// StringEnum PushMethodKeyProtection for value: HARDWARE
        /// </summary>
        public static PushMethodKeyProtection HARDWARE = new PushMethodKeyProtection("HARDWARE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="PushMethodKeyProtection"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator PushMethodKeyProtection(string value) => new PushMethodKeyProtection(value);

        /// <summary>
        /// Creates a new <see cref="PushMethodKeyProtection"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public PushMethodKeyProtection(string value)
            : base(value)
        {
        }
    }


}
