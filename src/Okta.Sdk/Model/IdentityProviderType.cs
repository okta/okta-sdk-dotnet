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
    /// Defines IdentityProviderType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class IdentityProviderType : StringEnum
    {
        /// <summary>
        /// StringEnum IdentityProviderType for value: AgentlessDSSO
        /// </summary>
        public static IdentityProviderType AgentlessDSSO = new IdentityProviderType("AgentlessDSSO");
        /// <summary>
        /// StringEnum IdentityProviderType for value: FACEBOOK
        /// </summary>
        public static IdentityProviderType FACEBOOK = new IdentityProviderType("FACEBOOK");
        /// <summary>
        /// StringEnum IdentityProviderType for value: GOOGLE
        /// </summary>
        public static IdentityProviderType GOOGLE = new IdentityProviderType("GOOGLE");
        /// <summary>
        /// StringEnum IdentityProviderType for value: IWA
        /// </summary>
        public static IdentityProviderType IWA = new IdentityProviderType("IWA");
        /// <summary>
        /// StringEnum IdentityProviderType for value: LINKEDIN
        /// </summary>
        public static IdentityProviderType LINKEDIN = new IdentityProviderType("LINKEDIN");
        /// <summary>
        /// StringEnum IdentityProviderType for value: MICROSOFT
        /// </summary>
        public static IdentityProviderType MICROSOFT = new IdentityProviderType("MICROSOFT");
        /// <summary>
        /// StringEnum IdentityProviderType for value: OIDC
        /// </summary>
        public static IdentityProviderType OIDC = new IdentityProviderType("OIDC");
        /// <summary>
        /// StringEnum IdentityProviderType for value: OKTA
        /// </summary>
        public static IdentityProviderType OKTA = new IdentityProviderType("OKTA");
        /// <summary>
        /// StringEnum IdentityProviderType for value: SAML2
        /// </summary>
        public static IdentityProviderType SAML2 = new IdentityProviderType("SAML2");
        /// <summary>
        /// StringEnum IdentityProviderType for value: X509
        /// </summary>
        public static IdentityProviderType X509 = new IdentityProviderType("X509");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator IdentityProviderType(string value) => new IdentityProviderType(value);

        /// <summary>
        /// Creates a new <see cref="IdentityProviderType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public IdentityProviderType(string value)
            : base(value)
        {
        }
    }


}
