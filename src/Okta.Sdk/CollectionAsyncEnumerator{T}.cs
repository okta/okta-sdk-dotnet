using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed class CollectionAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IRequestExecutor _requestExecutor;
        private readonly ISerializer _serializer;
        private readonly IResourceFactory _resourceFactory;
        private readonly KeyValuePair<string, object>[] _initialQueryParameters;

        private bool _initialized = false;
        private T[] _currentPage;
        private int _currentPageIndex;
        private string _nextUri;

        private bool _disposedValue = false; // To detect redundant calls

        public CollectionAsyncEnumerator(
            IRequestExecutor requestExecutor,
            ISerializer serializer,
            IResourceFactory resourceFactory,
            string uri,
            IEnumerable<KeyValuePair<string, object>> queryParameters)
        {
            _requestExecutor = requestExecutor ?? throw new ArgumentNullException(nameof(requestExecutor));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _resourceFactory = resourceFactory ?? throw new ArgumentNullException(nameof(resourceFactory));
            _nextUri = uri ?? throw new ArgumentNullException(nameof(uri));
            _initialQueryParameters = queryParameters?.ToArray() ?? new KeyValuePair<string, object>[0];
        }

        public T Current => _currentPage[_currentPageIndex++];

        public async Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            var hasMoreLocalItems = _initialized && _currentPage.Length != 0 && _currentPageIndex < _currentPage.Length;
            if (hasMoreLocalItems) return true;

            if (string.IsNullOrEmpty(_nextUri)) return false;

            var nextPageResponse = await _requestExecutor.GetAsync(_nextUri, cancellationToken);
            _initialized = true;

            SetCurrentItems(nextPageResponse);
            SetNextUri(nextPageResponse);

            return _currentPage.Any();
        }

        private void SetCurrentItems(HttpResponseWrapper response)
        {
            var items = _serializer.DeserializeArray(response.Body);
            _currentPage = items.Select(x => _resourceFactory.Create<T>(x)).ToArray();
            _currentPageIndex = 0;
        }

        private void SetNextUri(HttpResponseWrapper response)
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
