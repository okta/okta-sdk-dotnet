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
    /// Defines ProvisioningGroupsAction
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of ProvisioningGroupsAction values in the Okta API.
    /// </summary>
    public sealed class ProvisioningGroupsAction : StringEnum
    {
         /// <summary>
        /// StringEnum ProvisioningGroupsAction for value: APPEND
        /// </summary>
        public static ProvisioningGroupsAction APPEND = new ProvisioningGroupsAction("APPEND");
         /// <summary>
        /// StringEnum ProvisioningGroupsAction for value: ASSIGN
        /// </summary>
        public static ProvisioningGroupsAction ASSIGN = new ProvisioningGroupsAction("ASSIGN");
         /// <summary>
        /// StringEnum ProvisioningGroupsAction for value: NONE
        /// </summary>
        public static ProvisioningGroupsAction NONE = new ProvisioningGroupsAction("NONE");
         /// <summary>
        /// StringEnum ProvisioningGroupsAction for value: SYNC
        /// </summary>
        public static ProvisioningGroupsAction SYNC = new ProvisioningGroupsAction("SYNC");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ProvisioningGroupsAction(string value) => new ProvisioningGroupsAction(value);

        /// <summary>
        /// Creates a new <see cref="ProvisioningGroupsAction"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ProvisioningGroupsAction(string value)
            : base(value)
        {
        }
    }


}
