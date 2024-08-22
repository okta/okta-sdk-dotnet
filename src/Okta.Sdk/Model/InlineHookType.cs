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
    /// Defines InlineHookType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class InlineHookType : StringEnum
    {
        /// <summary>
        /// StringEnum InlineHookType for value: com.okta.import.transform
        /// </summary>
        public static InlineHookType ImportTransform = new InlineHookType("com.okta.import.transform");
        /// <summary>
        /// StringEnum InlineHookType for value: com.okta.oauth2.tokens.transform
        /// </summary>
        public static InlineHookType Oauth2TokensTransform = new InlineHookType("com.okta.oauth2.tokens.transform");
        /// <summary>
        /// StringEnum InlineHookType for value: com.okta.saml.tokens.transform
        /// </summary>
        public static InlineHookType SamlTokensTransform = new InlineHookType("com.okta.saml.tokens.transform");
        /// <summary>
        /// StringEnum InlineHookType for value: com.okta.telephony.provider
        /// </summary>
        public static InlineHookType TelephonyProvider = new InlineHookType("com.okta.telephony.provider");
        /// <summary>
        /// StringEnum InlineHookType for value: com.okta.user.credential.password.import
        /// </summary>
        public static InlineHookType UserCredentialPasswordImport = new InlineHookType("com.okta.user.credential.password.import");
        /// <summary>
        /// StringEnum InlineHookType for value: com.okta.user.pre-registration
        /// </summary>
        public static InlineHookType UserPreRegistration = new InlineHookType("com.okta.user.pre-registration");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="InlineHookType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator InlineHookType(string value) => new InlineHookType(value);

        /// <summary>
        /// Creates a new <see cref="InlineHookType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public InlineHookType(string value)
            : base(value)
        {
        }
    }


}
