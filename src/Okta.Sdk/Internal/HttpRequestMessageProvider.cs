// <copyright file="HttpRequestMessageProvider.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Class used to create HttpRequestMessage instances.
    /// </summary>
    public class HttpRequestMessageProvider : IHttpRequestMessageProvider
    {
        private readonly Dictionary<HttpVerb, HttpMethod> _httpMethods = new Dictionary<HttpVerb, HttpMethod>
        {
            { HttpVerb.Get, HttpMethod.Get },
            { HttpVerb.Post, HttpMethod.Post },
            { HttpVerb.Put, HttpMethod.Put },
            { HttpVerb.Delete, HttpMethod.Delete },
        };

        /// <summary>
        /// The default implementation of IHttpRequestMessageProvider.
        /// </summary>
        public static IHttpRequestMessageProvider Default => new HttpRequestMessageProvider();

        /// <summary>
        /// Create an new instance of HttpRequestMessage from the specified request.
        /// </summary>
        /// <param name="httpRequest">The request.</param>
        /// <param name="relativePath">The relative path.</param>
        /// <returns>HttpRequestMessage</returns>
        public HttpRequestMessage CreateHttpRequestMessage(HttpRequest httpRequest, string relativePath)
        {
            var httpRequestMessage = new HttpRequestMessage(_httpMethods[httpRequest.Verb], new Uri(relativePath, UriKind.Relative));
            ApplyHeadersToRequest(
                httpRequestMessage,
                httpRequest.Headers.Keys
                    .Select(header => new KeyValuePair<string, string>(header, httpRequest.Headers[header]))
                    .ToList());
            httpRequest.SetHttpRequestMessageContent(httpRequestMessage);
            return httpRequestMessage;
        }

        private static void ApplyHeadersToRequest(HttpRequestMessage request, IEnumerable<KeyValuePair<string, string>> headers)
        {
            if (headers == null || !headers.Any())
            {
                return;
            }

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }
    }
}
