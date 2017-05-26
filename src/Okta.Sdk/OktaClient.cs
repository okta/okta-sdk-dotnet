using Okta.Sdk.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public partial class OktaClient
    {
        public OktaClient(IDataStore dataStore)
        {
            DataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        public IDataStore DataStore { get; }

        public UsersClient GetUsersClient => new UsersClient(this);

        public async Task<T> GetAsync<T>(string href, CancellationToken cancellationToken = default(CancellationToken))
            where T : Resource, new()
        {
            var response = await DataStore.GetAsync<T>(href, cancellationToken);
            return response.Payload;
        }

        public async Task<TResponse> PostAsync<TResponse>(
            string href,
            object model,
            CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new()
        {
            var response = await DataStore.PostAsync<TResponse>(href, model, cancellationToken);
            return response.Payload;
        }
    }
}
