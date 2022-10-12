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
    /// Defines ProvisioningConnectionAuthScheme
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of ProvisioningConnectionAuthScheme values in the Okta API.
    /// </summary>
    public sealed class ProvisioningConnectionAuthScheme : StringEnum
    {
         /// <summary>
        /// StringEnum ProvisioningConnectionAuthScheme for value: TOKEN
        /// </summary>
        public static ProvisioningConnectionAuthScheme TOKEN = new ProvisioningConnectionAuthScheme("TOKEN");
         /// <summary>
        /// StringEnum ProvisioningConnectionAuthScheme for value: UNKNOWN
        /// </summary>
        public static ProvisioningConnectionAuthScheme UNKNOWN = new ProvisioningConnectionAuthScheme("UNKNOWN");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ProvisioningConnectionAuthScheme(string value) => new ProvisioningConnectionAuthScheme(value);

        /// <summary>
        /// Creates a new <see cref="ProvisioningConnectionAuthScheme"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ProvisioningConnectionAuthScheme(string value)
            : base(value)
        {
        }
    }


}
