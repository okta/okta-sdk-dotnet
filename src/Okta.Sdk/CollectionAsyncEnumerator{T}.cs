using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            var hasMoreLocalItems = _initialized && _currentPage.Length != 0 && _currentPageIndex < _currentPage.Length;
            if (hasMoreLocalItems) return true;

            if (string.IsNullOrEmpty(_nextUri)) return false;

            var nextPage = await _dataStore.GetArrayAsync<T>(_nextUri, cancellationToken);

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
                .Parse(linkHeaders)
                .Where(x => x.Relation == "next")
                .SingleOrDefault()
                .Target;
        }

        void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

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
