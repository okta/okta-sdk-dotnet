// <copyright file="CollectionAsyncEnumerator{T}.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Abstractions;

namespace Okta.Sdk
{
    public sealed class CollectionAsyncEnumerator<T> : IAsyncEnumerator<T>
        where T : Resource, new()
    {
        private readonly IDataStore _dataStore;
        private readonly KeyValuePair<string, object>[] _initialQueryParameters;

        private bool _initialized = false;
        private T[] _currentPage;
        private int _currentPageIndex;
        private string _nextUri;

        private bool _disposedValue = false; // To detect redundant calls

        public CollectionAsyncEnumerator(
            IDataStore dataStore,
            string uri,
            IEnumerable<KeyValuePair<string, object>> queryParameters)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            _nextUri = uri ?? throw new ArgumentNullException(nameof(uri));

            // TODO - currently this enumerator won't pass query string values to the nextUri automatically
            _initialQueryParameters = queryParameters?.ToArray() ?? new KeyValuePair<string, object>[0];
        }

        public T Current => _currentPage[_currentPageIndex++];

#pragma warning disable UseAsyncSuffix // Must match interface
        public async Task<bool> MoveNext(CancellationToken cancellationToken)
#pragma warning restore UseAsyncSuffix // Must match interface
        {
            var hasMoreLocalItems = _initialized && _currentPage.Length != 0 && _currentPageIndex < _currentPage.Length;
            if (hasMoreLocalItems)
            {
                return true;
            }

            if (string.IsNullOrEmpty(_nextUri))
            {
                return false;
            }

            var nextPage = await _dataStore.GetArrayAsync<T>(_nextUri, cancellationToken).ConfigureAwait(false);

            _initialized = true;

            _currentPage = nextPage.Payload.ToArray();
            _currentPageIndex = 0;

            SetNextUri(nextPage);

            return _currentPage.Any();
        }

        private void SetNextUri(HttpResponse response)
        {
            var linkHeaders = response
                .Headers
                .Where(kvp => kvp.Key.Equals("Link", StringComparison.OrdinalIgnoreCase))
                .Select(kvp => kvp.Value);

            _nextUri = LinkHeaderParser
                .Parse(linkHeaders.SelectMany(x => x))
                .Where(x => x.Relation == "next")
                .SingleOrDefault()
                .Target;
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

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
    }
}
