using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Okta.Sdk.Client
{
    public interface IPagedCollection<T> 
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

        public ApiResponse<PagedCollection<T>> InitalApiResponse
        {
            set { _initialApiResponse = value; }
        }

        public IAsynchronousClient AsynchronousClient
        {
            set { _asynchronousClient = value; }
        }

        public IReadableConfiguration Configuration
        {
            set { _configuration = value; }
        }


        public PagedCollection(ApiResponse<PagedCollection<T>> initialResponse, IAsynchronousClient asyncClient,
            IReadableConfiguration configuration)
        {
            _initialApiResponse = initialResponse;
            _asynchronousClient = asyncClient;
            _configuration = configuration;
        }

        public PagedCollectionEnumerator<T> GetPagedEnumerator(CancellationToken cancellationToken = default) =>
            new PagedCollectionEnumerator<T>(_initialApiResponse, _asynchronousClient, _configuration, cancellationToken);

    }
}
