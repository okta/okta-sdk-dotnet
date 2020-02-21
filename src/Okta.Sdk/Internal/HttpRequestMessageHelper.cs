// <copyright file="HttpRequestMessageHelper.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Http request helper.
    /// </summary>
    public class HttpRequestMessageHelper
    {
        /// <summary>
        /// Clones the passed request.
        /// </summary>
        /// <param name="request">The request to clone.</param>
        /// <returns>The cloned request.</returns>
        public static async Task<HttpRequestMessage> CloneHttpRequestMessageAsync(HttpRequestMessage request)
        {
            HttpRequestMessage clonedRequest = new HttpRequestMessage(request.Method, request.RequestUri);

            if (request.Content != null)
            {
                // Copy the request's content (via a MemoryStream) into the cloned object
                var memoryStream = new MemoryStream();
                await request.Content.CopyToAsync(memoryStream).ConfigureAwait(false);
                memoryStream.Position = 0;
                clonedRequest.Content = new StreamContent(memoryStream);

                // Copy the content headers
                if (request.Content.Headers != null)
                {
                    foreach (var header in request.Content.Headers)
                    {
                        clonedRequest.Content.Headers.Add(header.Key, header.Value);
                    }
                }
            }

            clonedRequest.Version = request.Version;

            foreach (KeyValuePair<string, object> property in request.Properties)
            {
                clonedRequest.Properties.Add(property);
            }

            foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
            {
                clonedRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return clonedRequest;
        }
    }
}
