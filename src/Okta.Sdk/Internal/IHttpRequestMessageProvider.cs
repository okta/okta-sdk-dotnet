// <copyright file="IHttpRequestMessageProvider.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Net.Http;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// This interface is responsible for creating the corresponding request message.
    /// </summary>
    public interface IHttpRequestMessageProvider
    {
        /// <summary>
        /// Creates an HttpRequestMessage instance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="relativePath">The relative path.</param>
        /// <returns>An HttpRequestMessage instance</returns>
        HttpRequestMessage CreateHttpRequestMessage(HttpRequest request, string relativePath);
    }
}
