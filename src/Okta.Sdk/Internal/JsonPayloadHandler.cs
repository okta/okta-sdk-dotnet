// <copyright file="JsonPayloadHandler.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Net.Http;
using System.Text;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// A payload handler that serializes the payload to json.
    /// </summary>
    public class JsonPayloadHandler : PayloadHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPayloadHandler"/> class.
        /// </summary>
        public JsonPayloadHandler()
        {
            ContentType = "application/json";
        }

        /// <summary>
        /// Get content for the specified request.
        /// </summary>
        /// <param name="httpRequest">The request whose content is returned.</param>
        /// <returns>Content for the specified request.</returns>
        protected override HttpContent GetContent(HttpRequest httpRequest)
        {
            ValidateRequest(httpRequest);

            var body = httpRequest.GetBody();
            return string.IsNullOrEmpty(body) ? null : new StringContent(body, Encoding.UTF8, ContentType);
        }
    }
}
