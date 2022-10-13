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
    /// Status for one agent regarding the status to auto-update that agent
    /// </summary>
    /// <value>Status for one agent regarding the status to auto-update that agent</value>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class AgentUpdateInstanceStatus : StringEnum
    {
        /// <summary>
        /// StringEnum AgentUpdateInstanceStatus for value: Cancelled
        /// </summary>
        public static AgentUpdateInstanceStatus Cancelled = new AgentUpdateInstanceStatus("Cancelled");
        /// <summary>
        /// StringEnum AgentUpdateInstanceStatus for value: Failed
        /// </summary>
        public static AgentUpdateInstanceStatus Failed = new AgentUpdateInstanceStatus("Failed");
        /// <summary>
        /// StringEnum AgentUpdateInstanceStatus for value: InProgress
        /// </summary>
        public static AgentUpdateInstanceStatus InProgress = new AgentUpdateInstanceStatus("InProgress");
        /// <summary>
        /// StringEnum AgentUpdateInstanceStatus for value: PendingCompletion
        /// </summary>
        public static AgentUpdateInstanceStatus PendingCompletion = new AgentUpdateInstanceStatus("PendingCompletion");
        /// <summary>
        /// StringEnum AgentUpdateInstanceStatus for value: Scheduled
        /// </summary>
        public static AgentUpdateInstanceStatus Scheduled = new AgentUpdateInstanceStatus("Scheduled");
        /// <summary>
        /// StringEnum AgentUpdateInstanceStatus for value: Success
        /// </summary>
        public static AgentUpdateInstanceStatus Success = new AgentUpdateInstanceStatus("Success");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator AgentUpdateInstanceStatus(string value) => new AgentUpdateInstanceStatus(value);

        /// <summary>
        /// Creates a new <see cref="AgentUpdateInstanceStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public AgentUpdateInstanceStatus(string value)
            : base(value)
        {
        }
    }


}
