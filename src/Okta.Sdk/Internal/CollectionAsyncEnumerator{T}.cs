// <copyright file="CollectionAsyncEnumerator{T}.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Enumerates an Okta API collection using the defined paging contract.
    /// </summary>
    /// <remarks>See <a href="https://developer.okta.com/docs/api/getting_started/design_principles.html#pagination">the API documentation on pagination</a>.</remarks>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    public sealed class CollectionAsyncEnumerator<T> : IAsyncEnumerator<T>
        where T : Resource, new()
    {
        private readonly IDataStore _dataStore;
        private readonly RequestContext _requestContext;

        private bool _initialized = false;
        private T[] _localPage;
        private int _localPageIndex;
        private HttpRequest _nextRequest;

        private bool _disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionAsyncEnumerator{T}"/> class.
        /// </summary>
        /// <param name="dataStore">The <see cref="IDataStore">DataStore</see> to use.</param>
        /// <param name="initialRequest">The initial HTTP request options.</param>
        /// <param name="requestContext">The request context.</param>
        public CollectionAsyncEnumerator(
            IDataStore dataStore,
            HttpRequest initialRequest,
            RequestContext requestContext)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            _nextRequest = initialRequest ?? throw new ArgumentNullException(nameof(initialRequest));
            _requestContext = requestContext;
        }

        /// <inheritdoc/>
        public T Current => _localPage[_localPageIndex++];

#pragma warning disable UseAsyncSuffix // Must match interface
        /// <inheritdoc/>
        public async Task<bool> MoveNext(CancellationToken cancellationToken)
#pragma warning restore UseAsyncSuffix // Must match interface
        {
            var hasMoreLocalItems = _initialized && _localPage.Length != 0 && _localPageIndex < _localPage.Length;
            if (hasMoreLocalItems)
            {
                return true;
            }

            if (_nextRequest == null)
            {
                return false;
            }

            var nextPage = await _dataStore.GetArrayAsync<T>(
                _nextRequest,
                _requestContext,
                cancellationToken).ConfigureAwait(false);

            _initialized = true;

            _localPage = nextPage.Payload.ToArray();
            _localPageIndex = 0;

            _nextRequest = GetNextLink(nextPage);

            return _localPage.Any();
        }

        private static HttpRequest GetNextLink(HttpResponse response)
        {
            var linkHeaders = response
                .Headers
                .Where(kvp => kvp.Key.Equals("Link", StringComparison.OrdinalIgnoreCase))
                .Select(kvp => kvp.Value);

            var nextUri = LinkHeaderParser
                .Parse(linkHeaders.SelectMany(x => x))
                .Where(x => x.Relation == "next")
                .SingleOrDefault()
                .Target;

            return string.IsNullOrEmpty(nextUri)
                ? null
                : new HttpRequest { Uri = nextUri };
        }

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose DataStore?
                }

                _disposedValue = true;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
    }
}
