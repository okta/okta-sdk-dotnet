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
            // todo optional query string parameters

            var response = await _requestExecutor.GetAsync(href, cancellationToken);
            if (response == null) throw new InvalidOperationException("The response from the RequestExecutor was null.");

            var resources = _serializer
                .DeserializeArray(response.Payload ?? string.Empty)
                .Select(x => ResourceFactory.Create<T>(new ChangeTrackingDictionary(x, StringComparer.OrdinalIgnoreCase)));

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
            // todo optional query string parameters

            var response = await _requestExecutor.GetAsync(href, cancellationToken);
            if (response == null) throw new InvalidOperationException("The response from the RequestExecutor was null.");

            var dictionary = _serializer.Deserialize(response.Payload ?? string.Empty);
            var changeTrackingDictionary = new ChangeTrackingDictionary(dictionary, StringComparer.OrdinalIgnoreCase);
            var resource = ResourceFactory.Create<T>(changeTrackingDictionary);

            return new HttpResponse<T>
            {
                StatusCode = response.StatusCode,
                Headers = response.Headers,
                Payload = resource
            };
        }

        public async Task<HttpResponse<TResponse>> PostAsync<TResponse>(string href, object postData, CancellationToken cancellationToken)
            where TResponse : Resource, new()
        {
            var body = _serializer.Serialize(postData);
            // TODO apply query string parameters

            var response = await _requestExecutor.PostAsync(href, body, cancellationToken);

            var returnedDictionary = _serializer.Deserialize(response.Payload);
            var changeTrackingDictionary = new ChangeTrackingDictionary(returnedDictionary, StringComparer.OrdinalIgnoreCase);
            var returnedResource = ResourceFactory.Create<TResponse>(changeTrackingDictionary);

            return new HttpResponse<TResponse>
            {
                StatusCode = response.StatusCode,
                Headers = response.Headers,
                Payload = returnedResource
            };
        }
    }
}
