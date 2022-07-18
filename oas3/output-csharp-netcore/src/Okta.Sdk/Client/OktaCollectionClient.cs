using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Okta.Sdk.Client
{
    public interface IOktaCollectionClient<T> : IAsyncEnumerable<T>
    {
        IPagedCollectionEnumerator<T> GetPagedEnumerator(CancellationToken cancellationToken = default);
    }
    public class OktaCollectionClient<T> : IOktaCollectionClient<T>
    {
        private RequestOptions _initialRequest;
        private string _initialPath;
        private IAsynchronousClient _client;
        public OktaCollectionClient(RequestOptions initialRequest, string initialPath, IAsynchronousClient client)
        {
            _initialRequest = initialRequest;
            _client = client;
            _initialPath = initialPath;
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            => new CollectionAsyncEnumerator<T>(_initialRequest, _initialPath, _client, cancellationToken);

        public IPagedCollectionEnumerator<T> GetPagedEnumerator(CancellationToken cancellationToken = default)
            => new PagedCollectionEnumerator<T>(_initialRequest, _initialPath, _client, cancellationToken);
    }
}
