// <copyright file="RequestContext.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Contains information about the downstream request from a client or browser to the application.
    /// </summary>
    /// <remarks>
    /// This class is used to pass request details (like the X-Forwarded-For header) from the client request
    /// through to the Okta API. Null properties are ignored.
    /// </remarks>
    public class RequestContext
    {
        /// <summary>
        /// Gets or sets the User-Agent of the downstream client.
        /// </summary>
        /// <value>
        /// The User-Agent value.
        /// </value>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the X-Forwarded-For value that should be sent to the Okta API.
        /// </summary>
        /// <value>
        /// The X-Forwarded-For value.
        /// </value>
        public string XForwardedFor { get; set; }

        /// <summary>
        /// Gets or sets the X-Forwarded-Proto value that should be sent to the Okta API.
        /// </summary>
        /// <value>
        /// The X-Forwarded-Proto value.
        /// </value>
        public string XForwardedProto { get; set; }

        /// <summary>
        /// Gets or sets the X-Forwarded-Port value that should be sent to the Okta API.
        /// </summary>
        /// <value>
        /// The X-Forwarded-Port value.
        /// </value>
        public string XForwardedPort { get; set; }
    }
}
