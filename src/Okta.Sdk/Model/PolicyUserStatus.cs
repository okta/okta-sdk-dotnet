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
    /// Defines PolicyUserStatus
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of PolicyUserStatus values in the Okta API.
    /// </summary>
    public sealed class PolicyUserStatus : StringEnum
    {
         /// <summary>
        /// StringEnum PolicyUserStatus for value: ACTIVATING
        /// </summary>
        public static PolicyUserStatus ACTIVATING = new PolicyUserStatus("ACTIVATING");
         /// <summary>
        /// StringEnum PolicyUserStatus for value: ACTIVE
        /// </summary>
        public static PolicyUserStatus ACTIVE = new PolicyUserStatus("ACTIVE");
         /// <summary>
        /// StringEnum PolicyUserStatus for value: DELETED
        /// </summary>
        public static PolicyUserStatus DELETED = new PolicyUserStatus("DELETED");
         /// <summary>
        /// StringEnum PolicyUserStatus for value: DELETING
        /// </summary>
        public static PolicyUserStatus DELETING = new PolicyUserStatus("DELETING");
         /// <summary>
        /// StringEnum PolicyUserStatus for value: EXPIRED_PASSWORD
        /// </summary>
        public static PolicyUserStatus EXPIREDPASSWORD = new PolicyUserStatus("EXPIRED_PASSWORD");
         /// <summary>
        /// StringEnum PolicyUserStatus for value: INACTIVE
        /// </summary>
        public static PolicyUserStatus INACTIVE = new PolicyUserStatus("INACTIVE");
         /// <summary>
        /// StringEnum PolicyUserStatus for value: PENDING
        /// </summary>
        public static PolicyUserStatus PENDING = new PolicyUserStatus("PENDING");
         /// <summary>
        /// StringEnum PolicyUserStatus for value: SUSPENDED
        /// </summary>
        public static PolicyUserStatus SUSPENDED = new PolicyUserStatus("SUSPENDED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator PolicyUserStatus(string value) => new PolicyUserStatus(value);

        /// <summary>
        /// Creates a new <see cref="PolicyUserStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public PolicyUserStatus(string value)
            : base(value)
        {
        }
    }


}
