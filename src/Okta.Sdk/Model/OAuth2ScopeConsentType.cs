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
    /// Defines OAuth2ScopeConsentType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class OAuth2ScopeConsentType : StringEnum
    {
        /// <summary>
        /// StringEnum OAuth2ScopeConsentType for value: ADMIN
        /// </summary>
        public static OAuth2ScopeConsentType ADMIN = new OAuth2ScopeConsentType("ADMIN");
        /// <summary>
        /// StringEnum OAuth2ScopeConsentType for value: IMPLICIT
        /// </summary>
        public static OAuth2ScopeConsentType IMPLICIT = new OAuth2ScopeConsentType("IMPLICIT");
        /// <summary>
        /// StringEnum OAuth2ScopeConsentType for value: REQUIRED
        /// </summary>
        public static OAuth2ScopeConsentType REQUIRED = new OAuth2ScopeConsentType("REQUIRED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OAuth2ScopeConsentType(string value) => new OAuth2ScopeConsentType(value);

        /// <summary>
        /// Creates a new <see cref="OAuth2ScopeConsentType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OAuth2ScopeConsentType(string value)
            : base(value)
        {
        }
    }


}
