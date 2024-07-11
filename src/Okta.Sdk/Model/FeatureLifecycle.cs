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
    /// Defines FeatureLifecycle
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class FeatureLifecycle : StringEnum
    {
        /// <summary>
        /// StringEnum FeatureLifecycle for value: DISABLE
        /// </summary>
        public static FeatureLifecycle DISABLE = new FeatureLifecycle("DISABLE");
        /// <summary>
        /// StringEnum FeatureLifecycle for value: ENABLE
        /// </summary>
        public static FeatureLifecycle ENABLE = new FeatureLifecycle("ENABLE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="FeatureLifecycle"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator FeatureLifecycle(string value) => new FeatureLifecycle(value);

        /// <summary>
        /// Creates a new <see cref="FeatureLifecycle"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public FeatureLifecycle(string value)
            : base(value)
        {
        }
    }


}
