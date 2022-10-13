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
    /// Defines IdentityProviderPolicyProvider
    /// </summary>
    [JsonConverter(typeof(Okta.Sdk.Client.StringEnumSerializingConverter))]
    public sealed class IdentityProviderPolicyProvider : StringEnum
    {
        /// <summary>
        /// StringEnum IdentityProviderPolicyProvider for value: ANY
        /// </summary>
        public static IdentityProviderPolicyProvider ANY = new IdentityProviderPolicyProvider("ANY");
        /// <summary>
        /// StringEnum IdentityProviderPolicyProvider for value: OKTA
        /// </summary>
        public static IdentityProviderPolicyProvider OKTA = new IdentityProviderPolicyProvider("OKTA");
        /// <summary>
        /// StringEnum IdentityProviderPolicyProvider for value: SPECIFIC_IDP
        /// </summary>
        public static IdentityProviderPolicyProvider SPECIFICIDP = new IdentityProviderPolicyProvider("SPECIFIC_IDP");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator IdentityProviderPolicyProvider(string value) => new IdentityProviderPolicyProvider(value);

        /// <summary>
        /// Creates a new <see cref="IdentityProviderPolicyProvider"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public IdentityProviderPolicyProvider(string value)
            : base(value)
        {
        }
    }


}
