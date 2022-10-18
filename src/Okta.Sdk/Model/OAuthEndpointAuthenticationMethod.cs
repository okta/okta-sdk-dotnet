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
    /// Defines OAuthEndpointAuthenticationMethod
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class OAuthEndpointAuthenticationMethod : StringEnum
    {
        /// <summary>
        /// StringEnum OAuthEndpointAuthenticationMethod for value: client_secret_basic
        /// </summary>
        public static OAuthEndpointAuthenticationMethod ClientSecretBasic = new OAuthEndpointAuthenticationMethod("client_secret_basic");
        /// <summary>
        /// StringEnum OAuthEndpointAuthenticationMethod for value: client_secret_jwt
        /// </summary>
        public static OAuthEndpointAuthenticationMethod ClientSecretJwt = new OAuthEndpointAuthenticationMethod("client_secret_jwt");
        /// <summary>
        /// StringEnum OAuthEndpointAuthenticationMethod for value: client_secret_post
        /// </summary>
        public static OAuthEndpointAuthenticationMethod ClientSecretPost = new OAuthEndpointAuthenticationMethod("client_secret_post");
        /// <summary>
        /// StringEnum OAuthEndpointAuthenticationMethod for value: none
        /// </summary>
        public static OAuthEndpointAuthenticationMethod None = new OAuthEndpointAuthenticationMethod("none");
        /// <summary>
        /// StringEnum OAuthEndpointAuthenticationMethod for value: private_key_jwt
        /// </summary>
        public static OAuthEndpointAuthenticationMethod PrivateKeyJwt = new OAuthEndpointAuthenticationMethod("private_key_jwt");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OAuthEndpointAuthenticationMethod"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OAuthEndpointAuthenticationMethod(string value) => new OAuthEndpointAuthenticationMethod(value);

        /// <summary>
        /// Creates a new <see cref="OAuthEndpointAuthenticationMethod"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OAuthEndpointAuthenticationMethod(string value)
            : base(value)
        {
        }
    }


}