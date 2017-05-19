using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed class DefaultDataStore : IDataStore
    {
        private readonly IRequestExecutor _requestExecutor;
        private readonly ISerializer _serializer;
        private readonly IResourceFactory _resourceFactory;

        public DefaultDataStore(
            IRequestExecutor requestExecutor,
            ISerializer serializer,
            IResourceFactory resourceFactory)
        {
            _requestExecutor = requestExecutor ?? throw new ArgumentNullException(nameof(requestExecutor));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _resourceFactory = resourceFactory ?? throw new ArgumentNullException(nameof(resourceFactory));
        }

        public IRequestExecutor RequestExecutor => _requestExecutor;

        public ISerializer Serializer => _serializer;

        public IResourceFactory ResourceFactory => _resourceFactory;

        public async Task<HttpResponse<IEnumerable<T>>> GetArrayAsync<T>(string href, CancellationToken cancellationToken)
        {
            var response = await _requestExecutor.GetAsync(href, cancellationToken);

            var resources = _serializer
                .DeserializeArray(response.Payload)
                .Select(x => _resourceFactory.Create<T>(x));

            return new HttpResponse<IEnumerable<T>>
            {
                StatusCode = response.StatusCode,
                Headers = response.Headers,
                Payload = resources
            };
        }

        public async Task<HttpResponse<T>> GetAsync<T>(string href, CancellationToken cancellationToken)
        {
            var response = await _requestExecutor.GetAsync(href, cancellationToken);
            var map = _serializer.Deserialize(response.Payload);
            var resource = _resourceFactory.Create<T>(map);

            return new HttpResponse<T>
            {
                StatusCode = response.StatusCode,
                Headers = response.Headers,
                Payload = resource
            };
        }
    }
}
