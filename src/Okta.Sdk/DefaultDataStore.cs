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

        public DefaultDataStore(
            IRequestExecutor requestExecutor,
            ISerializer serializer)
        {
            _requestExecutor = requestExecutor ?? throw new ArgumentNullException(nameof(requestExecutor));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        public IRequestExecutor RequestExecutor => _requestExecutor;

        public ISerializer Serializer => _serializer;

        public async Task<HttpResponse<IEnumerable<T>>> GetArrayAsync<T>(string href, CancellationToken cancellationToken)
            where T : Resource, new()
        {
            var response = await _requestExecutor.GetAsync(href, cancellationToken);

            var resources = _serializer
                .DeserializeArray(response.Payload)
                .Select(x => ResourceFactory.Create<T>(x));

            return new HttpResponse<IEnumerable<T>>
            {
                StatusCode = response.StatusCode,
                Headers = response.Headers,
                Payload = resources
            };
        }

        public async Task<HttpResponse<T>> GetAsync<T>(string href, CancellationToken cancellationToken)
            where T : Resource, new()
        {
            var response = await _requestExecutor.GetAsync(href, cancellationToken);
            var data = _serializer.Deserialize(response.Payload);
            var resource = ResourceFactory.Create<T>(data);

            return new HttpResponse<T>
            {
                StatusCode = response.StatusCode,
                Headers = response.Headers,
                Payload = resource
            };
        }

        public Task<HttpResponse<TResponse>> PostAsync<TResponse>(string href, object postData, CancellationToken cancellationToken)
            where TResponse : Resource, new()
        {
            throw new NotImplementedException();
        }
    }
}
