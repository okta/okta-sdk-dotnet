/*
 * Okta API
 *
 * Allows customers to easily access the Okta API
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
    /// Defines OAuthEndpointAuthenticationMethod
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OAuthEndpointAuthenticationMethod
    {
        /// <summary>
        /// Enum ClientSecretBasic for value: client_secret_basic
        /// </summary>
        [EnumMember(Value = "client_secret_basic")]
        ClientSecretBasic = 1,

        /// <summary>
        /// Enum ClientSecretJwt for value: client_secret_jwt
        /// </summary>
        [EnumMember(Value = "client_secret_jwt")]
        ClientSecretJwt = 2,

        /// <summary>
        /// Enum ClientSecretPost for value: client_secret_post
        /// </summary>
        [EnumMember(Value = "client_secret_post")]
        ClientSecretPost = 3,

        /// <summary>
        /// Enum None for value: none
        /// </summary>
        [EnumMember(Value = "none")]
        None = 4,

        /// <summary>
        /// Enum PrivateKeyJwt for value: private_key_jwt
        /// </summary>
        [EnumMember(Value = "private_key_jwt")]
        PrivateKeyJwt = 5

    }

}
