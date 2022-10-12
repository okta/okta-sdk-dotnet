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
    /// Defines HostedPageType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of HostedPageType values in the Okta API.
    /// </summary>
    public sealed class HostedPageType : StringEnum
    {
         /// <summary>
        /// StringEnum HostedPageType for value: EXTERNALLY_HOSTED
        /// </summary>
        public static HostedPageType EXTERNALLYHOSTED = new HostedPageType("EXTERNALLY_HOSTED");
         /// <summary>
        /// StringEnum HostedPageType for value: OKTA_DEFAULT
        /// </summary>
        public static HostedPageType OKTADEFAULT = new HostedPageType("OKTA_DEFAULT");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator HostedPageType(string value) => new HostedPageType(value);

        /// <summary>
        /// Creates a new <see cref="HostedPageType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public HostedPageType(string value)
            : base(value)
        {
        }
    }


}
