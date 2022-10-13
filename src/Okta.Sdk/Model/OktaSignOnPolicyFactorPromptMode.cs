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
    /// Defines OktaSignOnPolicyFactorPromptMode
    /// </summary>
    [JsonConverter(typeof(Okta.Sdk.Client.StringEnumSerializingConverter))]
    public sealed class OktaSignOnPolicyFactorPromptMode : StringEnum
    {
        /// <summary>
        /// StringEnum OktaSignOnPolicyFactorPromptMode for value: ALWAYS
        /// </summary>
        public static OktaSignOnPolicyFactorPromptMode ALWAYS = new OktaSignOnPolicyFactorPromptMode("ALWAYS");
        /// <summary>
        /// StringEnum OktaSignOnPolicyFactorPromptMode for value: DEVICE
        /// </summary>
        public static OktaSignOnPolicyFactorPromptMode DEVICE = new OktaSignOnPolicyFactorPromptMode("DEVICE");
        /// <summary>
        /// StringEnum OktaSignOnPolicyFactorPromptMode for value: SESSION
        /// </summary>
        public static OktaSignOnPolicyFactorPromptMode SESSION = new OktaSignOnPolicyFactorPromptMode("SESSION");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OktaSignOnPolicyFactorPromptMode(string value) => new OktaSignOnPolicyFactorPromptMode(value);

        /// <summary>
        /// Creates a new <see cref="OktaSignOnPolicyFactorPromptMode"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OktaSignOnPolicyFactorPromptMode(string value)
            : base(value)
        {
        }
    }


}
