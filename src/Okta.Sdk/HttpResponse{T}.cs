// <copyright file="HttpResponse{T}.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name must match first type name

    /// <summary>
    /// Represents an HTTP response with no payload.
    /// </summary>
    public class HttpResponse
    {
        /// <summary>
        /// Gets or sets the status code of the response.
        /// </summary>
        /// <value>
        /// The status code of the response.
        /// </value>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the set of headers in the response.
        /// </summary>
        /// <value>
        /// The set of headers in the response.
        /// </value>
        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; set; }
    }

    /// <summary>
    /// Represents an HTTP response with a typed payload.
    /// </summary>
    /// <typeparam name="T">The type of the payload.</typeparam>
    public class HttpResponse<T> : HttpResponse
    {
        /// <summary>
        /// Gets or sets the payload of the response.
        /// </summary>
        /// <value>
        /// The payload of the response.
        /// </value>
        public T Payload { get; set; }
    }

#pragma warning restore SA1649 // File name must match first type name
#pragma warning restore SA1402 // File may only contain a single type
}
