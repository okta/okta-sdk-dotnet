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
    /// Defines PolicyRuleAuthContextType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class PolicyRuleAuthContextType : StringEnum
    {
        /// <summary>
        /// StringEnum PolicyRuleAuthContextType for value: ANY
        /// </summary>
        public static PolicyRuleAuthContextType ANY = new PolicyRuleAuthContextType("ANY");
        /// <summary>
        /// StringEnum PolicyRuleAuthContextType for value: RADIUS
        /// </summary>
        public static PolicyRuleAuthContextType RADIUS = new PolicyRuleAuthContextType("RADIUS");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="PolicyRuleAuthContextType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator PolicyRuleAuthContextType(string value) => new PolicyRuleAuthContextType(value);

        /// <summary>
        /// Creates a new <see cref="PolicyRuleAuthContextType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public PolicyRuleAuthContextType(string value)
            : base(value)
        {
        }
    }


}
