using Okta.Sdk.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed class OktaClient
    {
        private readonly IRequestExecutor _requestExecutor;
        private readonly ISerializer _serializer;
        private readonly IResourceFactory _resourceFactory;

        public OktaClient(
            IRequestExecutor requestExecutor,
            ISerializer serializer,
            IResourceFactory resourceFactory)
        {
            _requestExecutor = requestExecutor ?? throw new ArgumentNullException(nameof(requestExecutor));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _resourceFactory = resourceFactory ?? throw new ArgumentNullException(nameof(resourceFactory));
        }

        public async Task<T> GetAsync<T>(string href, CancellationToken ct = default(CancellationToken))
        {
            var json = await _requestExecutor.GetAsync(href, ct);
            var map = _serializer.Deserialize(json);
            return _resourceFactory.Create<T>(map);
        }
    }
}
