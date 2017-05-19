using Okta.Sdk.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed partial class OktaClient
    {
        private readonly IDataStore _dataStore;

        public OktaClient(IDataStore dataStore)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        public async Task<T> GetAsync<T>(string href, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _dataStore.GetAsync<T>(href, cancellationToken);
            return response.Payload;
        }
    }
}
