using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk
{
    public sealed class CollectionClient<T> : IAsyncEnumerable<T>
    {
        private readonly IDataStore _dataStore;
        private readonly string _uri;
        private readonly KeyValuePair<string, object>[] _initialQueryParameters;

        public CollectionClient(
            IDataStore dataStore,
            string uri,
            IEnumerable<KeyValuePair<string, object>> queryParameters)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            _uri = uri ?? throw new ArgumentNullException(nameof(uri));
            _initialQueryParameters = queryParameters?.ToArray() ?? new KeyValuePair<string, object>[0];
        }

        public IAsyncEnumerator<T> GetEnumerator()
            => new CollectionAsyncEnumerator<T>(_dataStore, _uri, _initialQueryParameters);
    }
}
