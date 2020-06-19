// <copyright file="IRequestExecutor.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// A low-level abstraction over HTTP that executes requests and returns responses.
    /// </summary>
    public interface IRequestExecutor
    {
        /// <summary>
        /// Execute the specified request.
        /// </summary>
        /// <param name="request">The request to execute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response.</returns>
        Task<HttpResponse<string>> ExecuteRequestAsync(HttpRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Sends a GET request to the specified <paramref name="href"/>.
        /// </summary>
        /// <param name="href">The request URL.</param>
        /// <param name="headers">The HTTP headers to add to the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response.</returns>
        Task<HttpResponse<string>> GetAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, CancellationToken cancellationToken);

        /// <summary>
        /// Sends the specified POST request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response.</returns>
        Task<HttpResponse<string>> PostAsync(HttpRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Sends a POST request to the specified <paramref name="href"/>.
        /// </summary>
        /// <param name="href">The request URL.</param>
        /// <param name="headers">The HTTP headers to add to the request.</param>
        /// <param name="body">The serialized request body.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response.</returns>
        Task<HttpResponse<string>> PostAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, string body, CancellationToken cancellationToken);

        /// <summary>
        /// Sends a PUT request to the specified <paramref name="href"/>.
        /// </summary>
        /// <param name="href">The request URL.</param>
        /// <param name="headers">The HTTP headers to add to the request.</param>
        /// /// <param name="body">The serialized request body.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response.</returns>
        Task<HttpResponse<string>> PutAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, string body, CancellationToken cancellationToken);

        /// <summary>
        /// Sends a DELETE request to the specified <paramref name="href"/>.
        /// </summary>
        /// <param name="href">The request URL.</param>
        /// <param name="headers">The HTTP headers to add to the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response.</returns>
        Task<HttpResponse<string>> DeleteAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, CancellationToken cancellationToken);
    }
}
