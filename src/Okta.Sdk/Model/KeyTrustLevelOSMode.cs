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
    /// Represents the attestation strength used by the Chrome Verified Access API
    /// </summary>
    /// <value>Represents the attestation strength used by the Chrome Verified Access API</value>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class KeyTrustLevelOSMode : StringEnum
    {
        /// <summary>
        /// StringEnum KeyTrustLevelOSMode for value: CHROME_OS_DEVELOPER_MODE
        /// </summary>
        public static KeyTrustLevelOSMode DEVELOPERMODE = new KeyTrustLevelOSMode("CHROME_OS_DEVELOPER_MODE");
        /// <summary>
        /// StringEnum KeyTrustLevelOSMode for value: CHROME_OS_VERIFIED_MODE
        /// </summary>
        public static KeyTrustLevelOSMode VERIFIEDMODE = new KeyTrustLevelOSMode("CHROME_OS_VERIFIED_MODE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="KeyTrustLevelOSMode"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator KeyTrustLevelOSMode(string value) => new KeyTrustLevelOSMode(value);

        /// <summary>
        /// Creates a new <see cref="KeyTrustLevelOSMode"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public KeyTrustLevelOSMode(string value)
            : base(value)
        {
        }
    }


}
