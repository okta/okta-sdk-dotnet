/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.06.1
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
    /// The synchronization state for the Application User. The Application User&#39;s &#x60;syncState&#x60; depends on whether the &#x60;PROFILE_MASTERING&#x60; feature is enabled for the app.  &gt; **Note:** User provisioning currently must be configured through the Admin Console.
    /// </summary>
    /// <value>The synchronization state for the Application User. The Application User&#39;s &#x60;syncState&#x60; depends on whether the &#x60;PROFILE_MASTERING&#x60; feature is enabled for the app.  &gt; **Note:** User provisioning currently must be configured through the Admin Console.</value>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class AppUserSyncState : StringEnum
    {
        /// <summary>
        /// StringEnum AppUserSyncState for value: DISABLED
        /// </summary>
        public static AppUserSyncState DISABLED = new AppUserSyncState("DISABLED");
        /// <summary>
        /// StringEnum AppUserSyncState for value: ERROR
        /// </summary>
        public static AppUserSyncState ERROR = new AppUserSyncState("ERROR");
        /// <summary>
        /// StringEnum AppUserSyncState for value: OUT_OF_SYNC
        /// </summary>
        public static AppUserSyncState OUTOFSYNC = new AppUserSyncState("OUT_OF_SYNC");
        /// <summary>
        /// StringEnum AppUserSyncState for value: SYNCHRONIZED
        /// </summary>
        public static AppUserSyncState SYNCHRONIZED = new AppUserSyncState("SYNCHRONIZED");
        /// <summary>
        /// StringEnum AppUserSyncState for value: SYNCING
        /// </summary>
        public static AppUserSyncState SYNCING = new AppUserSyncState("SYNCING");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="AppUserSyncState"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator AppUserSyncState(string value) => new AppUserSyncState(value);

        /// <summary>
        /// Creates a new <see cref="AppUserSyncState"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public AppUserSyncState(string value)
            : base(value)
        {
        }
    }


}
