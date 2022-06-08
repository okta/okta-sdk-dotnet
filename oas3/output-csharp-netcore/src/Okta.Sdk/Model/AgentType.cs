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
    /// Agent types that are being monitored
    /// </summary>
    /// <value>Agent types that are being monitored</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AgentType
    {
        /// <summary>
        /// Enum AD for value: AD
        /// </summary>
        [EnumMember(Value = "AD")]
        AD = 1,

        /// <summary>
        /// Enum IWA for value: IWA
        /// </summary>
        [EnumMember(Value = "IWA")]
        IWA = 2,

        /// <summary>
        /// Enum LDAP for value: LDAP
        /// </summary>
        [EnumMember(Value = "LDAP")]
        LDAP = 3,

        /// <summary>
        /// Enum MFA for value: MFA
        /// </summary>
        [EnumMember(Value = "MFA")]
        MFA = 4,

        /// <summary>
        /// Enum OPP for value: OPP
        /// </summary>
        [EnumMember(Value = "OPP")]
        OPP = 5,

        /// <summary>
        /// Enum RUM for value: RUM
        /// </summary>
        [EnumMember(Value = "RUM")]
        RUM = 6,

        /// <summary>
        /// Enum Radius for value: Radius
        /// </summary>
        [EnumMember(Value = "Radius")]
        Radius = 7

    }

}
