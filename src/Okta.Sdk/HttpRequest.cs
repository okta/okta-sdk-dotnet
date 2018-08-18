// <copyright file="HttpRequest.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk
{
    /// <summary>
    /// Represents an HTTP request with a URI and optional payload and parameters.
    /// </summary>
    public class HttpRequest
    {
        /// <summary>
        /// Gets or sets the request URI.
        /// </summary>
        /// <value>
        /// The request URI.
        /// </value>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the request payload.
        /// </summary>
        /// <value>
        /// The request payload.
        /// </value>
        public object Payload { get; set; }

        /// <summary>
        /// Gets or sets the set of query parameters to send with the request.
        /// </summary>
        /// <value>
        /// The set of query parameters to send with the request.
        /// </value>
        public IEnumerable<KeyValuePair<string, object>> QueryParameters { get; set; }
            = Enumerable.Empty<KeyValuePair<string, object>>();

        /// <summary>
        /// Gets or sets the set of path parameters to apply to the request URI.
        /// </summary>
        /// <value>
        /// The set of path parameters to apply to the request URI.
        /// </value>
        public IEnumerable<KeyValuePair<string, object>> PathParameters { get; set; }
            = Enumerable.Empty<KeyValuePair<string, object>>();

        /// <summary>
        /// Gets or sets the headers to send with the request.
        /// </summary>
        /// <value>
        /// The headers to send with the request.
        /// </value>
        public IDictionary<string, string> Headers { get; set; }
            = new Dictionary<string, string>();
    }
}
