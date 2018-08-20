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
    /// <inheritdoc/>
    public class PagedCollectionEnumerator<T> : IPagedCollectionEnumerator<T>
        where T : IResource
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

        /// <inheritdoc/>
        public CollectionPage<T> CurrentPage { get; private set; }

        /// <inheritdoc/>
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
