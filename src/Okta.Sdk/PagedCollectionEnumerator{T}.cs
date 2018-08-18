// <copyright file="PagedCollectionEnumerator{T}.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <summary>
    /// Enumerates an Okta collection by retrieving pages of results.
    /// </summary>
    /// <remarks>See <a href="https://developer.okta.com/docs/api/getting_started/design_principles.html#pagination">the API documentation on pagination</a>.</remarks>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    public class PagedCollectionEnumerator<T>
        where T : Resource, new()
    {
        private readonly IDataStore _dataStore;
        private readonly RequestContext _requestContext;

        private HttpRequest _nextRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedCollectionEnumerator{T}"/> class.
        /// </summary>
        /// <param name="dataStore">The <see cref="IDataStore">DataStore</see> to use.</param>
        /// <param name="initialRequest">The initial HTTP request options.</param>
        /// <param name="requestContext">The request context.</param>
        public PagedCollectionEnumerator(
            IDataStore dataStore,
            HttpRequest initialRequest,
            RequestContext requestContext)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            _requestContext = requestContext;
            _nextRequest = initialRequest ?? throw new ArgumentNullException(nameof(initialRequest));
        }

        /// <summary>
        /// Gets the current page of items, or <c>null</c> if <see cref="MoveNextAsync(CancellationToken)"/> has not yet been called.
        /// </summary>
        /// <value>
        /// The current page of items, if any.
        /// </value>
        public CollectionPage<T> CurrentPage { get; private set; }

        /// <summary>
        /// Asynchronously retrieves the next page of results and updates <see cref="CurrentPage"/>. If there are no more pages, this method returns <see langword="false"/>.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// <see langword="true"/> if <see cref="CurrentPage"/> has been updated with new items, <see langword="false"/> if the collection has been exhausted.
        /// </returns>
        public async Task<bool> MoveNextAsync(CancellationToken cancellationToken = default)
        {
            if (_nextRequest == null)
            {
                return false;
            }

            var response = await _dataStore.GetArrayAsync<T>(
                _nextRequest,
                _requestContext,
                cancellationToken).ConfigureAwait(false);

            var items = response?.Payload?.ToArray() ?? new T[0];

            CurrentPage = new CollectionPage<T>
            {
                Items = items,
                Response = response,
                NextLink = GetNextLink(response),
            };

            _nextRequest = null;
            if (!string.IsNullOrEmpty(CurrentPage.NextLink?.Target))
            {
                _nextRequest = new HttpRequest { Uri = CurrentPage.NextLink.Target };
            }

            return true;
        }

        private static WebLink GetNextLink(HttpResponse response)
        {
            if (response?.Headers == null)
            {
                return null;
            }

            var linkHeaders = response
                .Headers
                .Where(kvp => kvp.Key.Equals("Link", StringComparison.OrdinalIgnoreCase))
                .Select(kvp => kvp.Value);

            var nextLink = LinkHeaderParser
                .Parse(linkHeaders.SelectMany(x => x))
                .Where(x => x.Relation == "next")
                .FirstOrDefault();

            return nextLink;
        }
    }
}
