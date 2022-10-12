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
    /// Defines CatalogApplicationStatus
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of CatalogApplicationStatus values in the Okta API.
    /// </summary>
    public sealed class CatalogApplicationStatus : StringEnum
    {
         /// <summary>
        /// StringEnum CatalogApplicationStatus for value: ACTIVE
        /// </summary>
        public static CatalogApplicationStatus ACTIVE = new CatalogApplicationStatus("ACTIVE");
         /// <summary>
        /// StringEnum CatalogApplicationStatus for value: INACTIVE
        /// </summary>
        public static CatalogApplicationStatus INACTIVE = new CatalogApplicationStatus("INACTIVE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator CatalogApplicationStatus(string value) => new CatalogApplicationStatus(value);

        /// <summary>
        /// Creates a new <see cref="CatalogApplicationStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public CatalogApplicationStatus(string value)
            : base(value)
        {
        }
    }


}
