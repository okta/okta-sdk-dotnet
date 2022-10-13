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
    /// Defines RoleType
    /// </summary>
    [JsonConverter(typeof(Okta.Sdk.Client.StringEnumSerializingConverter))]
    public sealed class RoleType : StringEnum
    {
        /// <summary>
        /// StringEnum RoleType for value: API_ACCESS_MANAGEMENT_ADMIN
        /// </summary>
        public static RoleType APIACCESSMANAGEMENTADMIN = new RoleType("API_ACCESS_MANAGEMENT_ADMIN");
        /// <summary>
        /// StringEnum RoleType for value: APP_ADMIN
        /// </summary>
        public static RoleType APPADMIN = new RoleType("APP_ADMIN");
        /// <summary>
        /// StringEnum RoleType for value: GROUP_MEMBERSHIP_ADMIN
        /// </summary>
        public static RoleType GROUPMEMBERSHIPADMIN = new RoleType("GROUP_MEMBERSHIP_ADMIN");
        /// <summary>
        /// StringEnum RoleType for value: HELP_DESK_ADMIN
        /// </summary>
        public static RoleType HELPDESKADMIN = new RoleType("HELP_DESK_ADMIN");
        /// <summary>
        /// StringEnum RoleType for value: MOBILE_ADMIN
        /// </summary>
        public static RoleType MOBILEADMIN = new RoleType("MOBILE_ADMIN");
        /// <summary>
        /// StringEnum RoleType for value: ORG_ADMIN
        /// </summary>
        public static RoleType ORGADMIN = new RoleType("ORG_ADMIN");
        /// <summary>
        /// StringEnum RoleType for value: READ_ONLY_ADMIN
        /// </summary>
        public static RoleType READONLYADMIN = new RoleType("READ_ONLY_ADMIN");
        /// <summary>
        /// StringEnum RoleType for value: REPORT_ADMIN
        /// </summary>
        public static RoleType REPORTADMIN = new RoleType("REPORT_ADMIN");
        /// <summary>
        /// StringEnum RoleType for value: SUPER_ADMIN
        /// </summary>
        public static RoleType SUPERADMIN = new RoleType("SUPER_ADMIN");
        /// <summary>
        /// StringEnum RoleType for value: USER_ADMIN
        /// </summary>
        public static RoleType USERADMIN = new RoleType("USER_ADMIN");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator RoleType(string value) => new RoleType(value);

        /// <summary>
        /// Creates a new <see cref="RoleType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public RoleType(string value)
            : base(value)
        {
        }
    }


}
