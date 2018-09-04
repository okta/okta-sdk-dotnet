// <copyright file="IDataStore.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Combines the concerns of making requests and serializing data into one interface.
    /// </summary>
    public interface IDataStore
    {
        /// <summary>
        /// Gets the <see cref="IRequestExecutor">RequestExecutor</see> used by this <see cref="IDataStore">DataStore</see>.
        /// </summary>
        /// <value>
        /// The <see cref="IRequestExecutor">RequestExecutor</see> used by this <see cref="IDataStore">DataStore</see>.
        /// </value>
        IRequestExecutor RequestExecutor { get; }

        /// <summary>
        /// Gets the <see cref="ISerializer">Serializer</see> used by this <see cref="IDataStore">DataStore</see>.
        /// </summary>
        /// <value>
        /// The <see cref="ISerializer">Serializer</see> used by this <see cref="IDataStore">DataStore</see>.
        /// </value>
        ISerializer Serializer { get; }

        /// <summary>
        /// Gets a resource and deserializes it to a <see cref="Resource"/> type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Resource"/> type to deserialize the returned data to.</typeparam>
        /// <param name="request">The HTTP request options.</param>
        /// <param name="requestContext">Information about the upstream request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized resource and <see cref="HttpResponse"/> data.</returns>
        /// <exception cref="OktaApiException">An API error occurred.</exception>
        Task<HttpResponse<T>> GetAsync<T>(HttpRequest request, RequestContext requestContext, CancellationToken cancellationToken)
            where T : Resource, new();

        /// <summary>
        /// Gets an array of resources and deserializes each item to a <see cref="Resource"/> type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Resource"/> type to deserialize the returned data to.</typeparam>
        /// <param name="request">The HTTP request options.</param>
        /// <param name="requestContext">Information about the upstream request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An array of deserialized resources and <see cref="HttpResponse"/> data.</returns>
        /// <exception cref="OktaApiException">An API error occurred.</exception>
        Task<HttpResponse<IEnumerable<T>>> GetArrayAsync<T>(HttpRequest request, RequestContext requestContext, CancellationToken cancellationToken)
            where T : IResource;

        /// <summary>
        /// Posts data to an endpoint and deserializes the response to a <see cref="Resource"/> type.
        /// </summary>
        /// <typeparam name="TResponse">The <see cref="Resource"/> type to deserialize the returned data to.</typeparam>
        /// <param name="request">The HTTP request options.</param>
        /// <param name="requestContext">Information about the upstream request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized response resource and <see cref="HttpResponse"/> data.</returns>
        /// <exception cref="OktaApiException">An API error occurred.</exception>
        Task<HttpResponse<TResponse>> PostAsync<TResponse>(HttpRequest request, RequestContext requestContext, CancellationToken cancellationToken)
            where TResponse : Resource, new();

        /// <summary>
        /// Puts data to an endpoint and deserializes the response to a <see cref="Resource"/> type.
        /// </summary>
        /// <typeparam name="TResponse">The <see cref="Resource"/> type to deserialize the returned data to.</typeparam>
        /// <param name="request">The HTTP request options.</param>
        /// <param name="requestContext">Information about the upstream request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized response resource and <see cref="HttpResponse"/> data.</returns>
        /// <exception cref="OktaApiException">An API error occurred.</exception>
        Task<HttpResponse<TResponse>> PutAsync<TResponse>(HttpRequest request, RequestContext requestContext, CancellationToken cancellationToken)
            where TResponse : Resource, new();

        /// <summary>
        /// Deletes a resource.
        /// </summary>
        /// <param name="request">The HTTP request options.</param>
        /// <param name="requestContext">Information about the upstream request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="HttpResponse"/> data.</returns>
        Task<HttpResponse> DeleteAsync(HttpRequest request, RequestContext requestContext, CancellationToken cancellationToken);
    }
}
