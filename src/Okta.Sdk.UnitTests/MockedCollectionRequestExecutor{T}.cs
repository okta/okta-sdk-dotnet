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
        private const string BaseUrl = "http://mock-collection.dev";
        private readonly int _pageSize;
        private readonly T[] _items;

        private int _currentPage = 0;

        public MockedCollectionRequestExecutor(int pageSize, IEnumerable<T> items)
        {
            _pageSize = pageSize;
            _items = items.ToArray();
        }

        public Task<string> GetBodyAsync(string href, CancellationToken ct)
        {
            var items = _items
                .Skip(_currentPage * _pageSize)
                .Take(_pageSize)
                .ToArray();

            // Increment page
            _currentPage++;

            return Task.FromResult(JsonConvert.SerializeObject(items));
        }

        public async Task<HttpResponse<string>> GetAsync(string href, CancellationToken cancellationToken)
        {
            var headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Link", $"<{BaseUrl}?page={_currentPage}>; rel=\"self\""),
            };

            if ((_currentPage + 1) * _pageSize < _items.Length)
            {
                headers.Add(new KeyValuePair<string, string>("Link", $"<{BaseUrl}?page={_currentPage + 1}>; rel=\"next\""));
            }

            return new HttpResponse<string>
            {
                StatusCode = 200,
                Headers = headers,
                Payload = await GetBodyAsync(href, cancellationToken)
            };
        }
    }
}
