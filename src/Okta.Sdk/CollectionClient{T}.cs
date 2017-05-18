using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk
{
    public sealed class CollectionClient<T> : IAsyncEnumerable<T>
    {
        private readonly IRequestExecutor _requestExecutor;
        private readonly ISerializer _serializer;
        private readonly IResourceFactory _resourceFactory;
        private readonly string _uri;
        private readonly KeyValuePair<string, object>[] _initialQueryParameters;

        public CollectionClient(
            IRequestExecutor requestExecutor,
            ISerializer serializer,
            IResourceFactory resourceFactory,
            string uri,
            IEnumerable<KeyValuePair<string, object>> queryParameters)
        {
            _requestExecutor = requestExecutor ?? throw new ArgumentNullException(nameof(requestExecutor));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _resourceFactory = resourceFactory ?? throw new ArgumentNullException(nameof(resourceFactory));
            _uri = uri ?? throw new ArgumentNullException(nameof(uri));
            _initialQueryParameters = queryParameters?.ToArray() ?? new KeyValuePair<string, object>[0];
        }

        public IAsyncEnumerator<T> GetEnumerator()
            => new CollectionAsyncEnumerator<T>(_requestExecutor, _serializer, _resourceFactory, _uri, _initialQueryParameters);
    }
}
