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
    /// Defines BehaviorRuleType
    /// </summary>
    [JsonConverter(typeof(Okta.Sdk.Client.StringEnumSerializingConverter))]
    public sealed class BehaviorRuleType : StringEnum
    {
        /// <summary>
        /// StringEnum BehaviorRuleType for value: ANOMALOUS_DEVICE
        /// </summary>
        public static BehaviorRuleType ANOMALOUSDEVICE = new BehaviorRuleType("ANOMALOUS_DEVICE");
        /// <summary>
        /// StringEnum BehaviorRuleType for value: ANOMALOUS_IP
        /// </summary>
        public static BehaviorRuleType ANOMALOUSIP = new BehaviorRuleType("ANOMALOUS_IP");
        /// <summary>
        /// StringEnum BehaviorRuleType for value: ANOMALOUS_LOCATION
        /// </summary>
        public static BehaviorRuleType ANOMALOUSLOCATION = new BehaviorRuleType("ANOMALOUS_LOCATION");
        /// <summary>
        /// StringEnum BehaviorRuleType for value: VELOCITY
        /// </summary>
        public static BehaviorRuleType VELOCITY = new BehaviorRuleType("VELOCITY");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator BehaviorRuleType(string value) => new BehaviorRuleType(value);

        /// <summary>
        /// Creates a new <see cref="BehaviorRuleType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public BehaviorRuleType(string value)
            : base(value)
        {
        }
    }


}
