// <copyright file="IPayloadHandler.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Net.Http;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// A class responsible for providing body and message content.
    /// </summary>
    public interface IPayloadHandler
    {
        /// <summary>
        /// Gets the content type.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Gets the body for the specified request.
        /// </summary>
        /// <param name="httpRequest">The request whose body is retrieved.</param>
        /// <returns>The request body.</returns>
        string GetBody(HttpRequest httpRequest);

        /// <summary>
        /// Set the content of the specified request message based on the specified request.
        /// </summary>
        /// <param name="httpRequest">The request used to create the message content.</param>
        /// <param name="httpRequestMessage">The message whose content is set.</param>
        void SetMessageContent(HttpRequest httpRequest, HttpRequestMessage httpRequestMessage);
    }
}
