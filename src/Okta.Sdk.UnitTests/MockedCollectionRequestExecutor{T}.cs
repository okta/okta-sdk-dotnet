using Newtonsoft.Json;
using Okta.Sdk.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk.UnitTests
{
    public class MockedCollectionRequestExecutor<T> : IRequestExecutor
    {
        private const string BaseUrl = "foo://mockCollection";
        private readonly int _pageSize;
        private readonly T[] _items;

        private int _currentPage = 0;

        public MockedCollectionRequestExecutor(int pageSize, IEnumerable<T> items)
        {
            _pageSize = pageSize;
            _items = items.ToArray();
        }

        public async Task<HttpResponseWrapper> GetAsync(string href, CancellationToken ct)
        {
            var headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Link", $"<{BaseUrl}?page={_currentPage}>; rel=\"self\""),
                new KeyValuePair<string, string>("Link", $"<{BaseUrl}?page={_currentPage+1}>; rel=\"next\""),
            };

            return new HttpResponseWrapper
            {
                StatusCode = 200,
                Headers = headers,
                Body = await GetBodyAsync(href, ct)
            };
        }

        public Task<string> GetBodyAsync(string href, CancellationToken ct)
        {
            var items = _items
                .Skip(_currentPage * _pageSize)
                .ToArray();

            // Increment page
            _currentPage++;

            return Task.FromResult(JsonConvert.SerializeObject(items));
        }
    }
}
