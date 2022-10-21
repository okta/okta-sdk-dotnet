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
    /// Defines ErrorPageTouchPointVariant
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class ErrorPageTouchPointVariant : StringEnum
    {
        /// <summary>
        /// StringEnum ErrorPageTouchPointVariant for value: BACKGROUND_IMAGE
        /// </summary>
        public static ErrorPageTouchPointVariant BACKGROUNDIMAGE = new ErrorPageTouchPointVariant("BACKGROUND_IMAGE");
        /// <summary>
        /// StringEnum ErrorPageTouchPointVariant for value: BACKGROUND_SECONDARY_COLOR
        /// </summary>
        public static ErrorPageTouchPointVariant BACKGROUNDSECONDARYCOLOR = new ErrorPageTouchPointVariant("BACKGROUND_SECONDARY_COLOR");
        /// <summary>
        /// StringEnum ErrorPageTouchPointVariant for value: OKTA_DEFAULT
        /// </summary>
        public static ErrorPageTouchPointVariant OKTADEFAULT = new ErrorPageTouchPointVariant("OKTA_DEFAULT");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ErrorPageTouchPointVariant"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ErrorPageTouchPointVariant(string value) => new ErrorPageTouchPointVariant(value);

        /// <summary>
        /// Creates a new <see cref="ErrorPageTouchPointVariant"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ErrorPageTouchPointVariant(string value)
            : base(value)
        {
        }
    }


}
