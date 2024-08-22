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
    /// The authentication pipeline of the org. &#x60;idx&#x60; means the org is using the Identity Engine, while &#x60;v1&#x60; means the org is using the Classic authentication pipeline.
    /// </summary>
    /// <value>The authentication pipeline of the org. &#x60;idx&#x60; means the org is using the Identity Engine, while &#x60;v1&#x60; means the org is using the Classic authentication pipeline.</value>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class PipelineType : StringEnum
    {
        /// <summary>
        /// StringEnum PipelineType for value: idx
        /// </summary>
        public static PipelineType Idx = new PipelineType("idx");
        /// <summary>
        /// StringEnum PipelineType for value: v1
        /// </summary>
        public static PipelineType V1 = new PipelineType("v1");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="PipelineType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator PipelineType(string value) => new PipelineType(value);

        /// <summary>
        /// Creates a new <see cref="PipelineType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public PipelineType(string value)
            : base(value)
        {
        }
    }


}
