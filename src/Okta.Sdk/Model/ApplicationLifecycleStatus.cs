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
    /// Defines ApplicationLifecycleStatus
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of ApplicationLifecycleStatus values in the Okta API.
    /// </summary>
    public sealed class ApplicationLifecycleStatus : StringEnum
    {
         /// <summary>
        /// StringEnum ApplicationLifecycleStatus for value: ACTIVE
        /// </summary>
        public static ApplicationLifecycleStatus ACTIVE = new ApplicationLifecycleStatus("ACTIVE");
         /// <summary>
        /// StringEnum ApplicationLifecycleStatus for value: DELETED
        /// </summary>
        public static ApplicationLifecycleStatus DELETED = new ApplicationLifecycleStatus("DELETED");
         /// <summary>
        /// StringEnum ApplicationLifecycleStatus for value: INACTIVE
        /// </summary>
        public static ApplicationLifecycleStatus INACTIVE = new ApplicationLifecycleStatus("INACTIVE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ApplicationLifecycleStatus(string value) => new ApplicationLifecycleStatus(value);

        /// <summary>
        /// Creates a new <see cref="ApplicationLifecycleStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ApplicationLifecycleStatus(string value)
            : base(value)
        {
        }
    }


}
