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
    /// The type of token for token exchange.
    /// </summary>
    /// <value>The type of token for token exchange.</value>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class TokenType : StringEnum
    {
        /// <summary>
        /// StringEnum TokenType for value: urn:ietf:params:oauth:token-type:access_token
        /// </summary>
        public static TokenType IetfparamsoauthtokenTypeaccessToken = new TokenType("urn:ietf:params:oauth:token-type:access_token");
        /// <summary>
        /// StringEnum TokenType for value: urn:ietf:params:oauth:token-type:id_token
        /// </summary>
        public static TokenType IetfparamsoauthtokenTypeidToken = new TokenType("urn:ietf:params:oauth:token-type:id_token");
        /// <summary>
        /// StringEnum TokenType for value: urn:ietf:params:oauth:token-type:jwt
        /// </summary>
        public static TokenType IetfparamsoauthtokenTypejwt = new TokenType("urn:ietf:params:oauth:token-type:jwt");
        /// <summary>
        /// StringEnum TokenType for value: urn:ietf:params:oauth:token-type:refresh_token
        /// </summary>
        public static TokenType IetfparamsoauthtokenTyperefreshToken = new TokenType("urn:ietf:params:oauth:token-type:refresh_token");
        /// <summary>
        /// StringEnum TokenType for value: urn:ietf:params:oauth:token-type:saml1
        /// </summary>
        public static TokenType IetfparamsoauthtokenTypesaml1 = new TokenType("urn:ietf:params:oauth:token-type:saml1");
        /// <summary>
        /// StringEnum TokenType for value: urn:ietf:params:oauth:token-type:saml2
        /// </summary>
        public static TokenType IetfparamsoauthtokenTypesaml2 = new TokenType("urn:ietf:params:oauth:token-type:saml2");
        /// <summary>
        /// StringEnum TokenType for value: urn:okta:oauth:token-type:web_sso_token
        /// </summary>
        public static TokenType OktaoauthtokenTypewebSsoToken = new TokenType("urn:okta:oauth:token-type:web_sso_token");
        /// <summary>
        /// StringEnum TokenType for value: urn:x-oath:params:oauth:token-type:device-secret
        /// </summary>
        public static TokenType XOathparamsoauthtokenTypedeviceSecret = new TokenType("urn:x-oath:params:oauth:token-type:device-secret");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="TokenType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator TokenType(string value) => new TokenType(value);

        /// <summary>
        /// Creates a new <see cref="TokenType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public TokenType(string value)
            : base(value)
        {
        }
    }


}