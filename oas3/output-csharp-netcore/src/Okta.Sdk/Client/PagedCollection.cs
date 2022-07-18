using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Okta.Sdk.Client
{
    public interface IPagedCollection<T> : IList<T>
    {
        PagedCollectionEnumerator<T> GetPagedEnumerator(CancellationToken cancellationToken = default);
    }

    public class PagedCollection<T> : List<T>, IPagedCollection<T>
    {
        private ApiResponse<PagedCollection<T>> _initialApiResponse;
        private IAsynchronousClient _asynchronousClient;
        private IReadableConfiguration _configuration;

        public PagedCollection()
        {

        }

        internal void InitializeEnumerator(ApiResponse<PagedCollection<T>> initialApiResponse, IAsynchronousClient asynchronousClient, IReadableConfiguration configuration)
        {
            _initialApiResponse = initialApiResponse;
            _asynchronousClient = asynchronousClient;
            _configuration = configuration;
        }

        public PagedCollectionEnumerator<T> GetPagedEnumerator(CancellationToken cancellationToken = default) =>
            null;

    }
}
