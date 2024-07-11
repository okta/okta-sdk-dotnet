/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.06.1
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
    /// Defines DiskEncryptionTypeDesktop
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class DiskEncryptionTypeDesktop : StringEnum
    {
        /// <summary>
        /// StringEnum DiskEncryptionTypeDesktop for value: ALL_INTERNAL_VOLUMES
        /// </summary>
        public static DiskEncryptionTypeDesktop ALLINTERNALVOLUMES = new DiskEncryptionTypeDesktop("ALL_INTERNAL_VOLUMES");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="DiskEncryptionTypeDesktop"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator DiskEncryptionTypeDesktop(string value) => new DiskEncryptionTypeDesktop(value);

        /// <summary>
        /// Creates a new <see cref="DiskEncryptionTypeDesktop"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public DiskEncryptionTypeDesktop(string value)
            : base(value)
        {
        }
    }


}
