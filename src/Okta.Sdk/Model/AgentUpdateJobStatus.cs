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
    /// Overall state for the auto-update job from admin perspective
    /// </summary>
    /// <value>Overall state for the auto-update job from admin perspective</value>
    [JsonConverter(typeof(Okta.Sdk.Client.StringEnumSerializingConverter))]
    public sealed class AgentUpdateJobStatus : StringEnum
    {
        /// <summary>
        /// StringEnum AgentUpdateJobStatus for value: Cancelled
        /// </summary>
        public static AgentUpdateJobStatus Cancelled = new AgentUpdateJobStatus("Cancelled");
        /// <summary>
        /// StringEnum AgentUpdateJobStatus for value: Failed
        /// </summary>
        public static AgentUpdateJobStatus Failed = new AgentUpdateJobStatus("Failed");
        /// <summary>
        /// StringEnum AgentUpdateJobStatus for value: InProgress
        /// </summary>
        public static AgentUpdateJobStatus InProgress = new AgentUpdateJobStatus("InProgress");
        /// <summary>
        /// StringEnum AgentUpdateJobStatus for value: Paused
        /// </summary>
        public static AgentUpdateJobStatus Paused = new AgentUpdateJobStatus("Paused");
        /// <summary>
        /// StringEnum AgentUpdateJobStatus for value: Scheduled
        /// </summary>
        public static AgentUpdateJobStatus Scheduled = new AgentUpdateJobStatus("Scheduled");
        /// <summary>
        /// StringEnum AgentUpdateJobStatus for value: Success
        /// </summary>
        public static AgentUpdateJobStatus Success = new AgentUpdateJobStatus("Success");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator AgentUpdateJobStatus(string value) => new AgentUpdateJobStatus(value);

        /// <summary>
        /// Creates a new <see cref="AgentUpdateJobStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public AgentUpdateJobStatus(string value)
            : base(value)
        {
        }
    }


}
