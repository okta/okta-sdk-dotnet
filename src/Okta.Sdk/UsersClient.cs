using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed class UsersClient : OktaClient
    {
        private const string GetUserUri = "/api/v1/users/{id}";

        public UsersClient(OktaClient oktaClient)
            : base(oktaClient.DataStore)
        {
        }

        public IAsyncEnumerable<User> Users { get; }

        public Task<User> GetUserAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsync<User>(string.Format(GetUserUri, id), cancellationToken);

        public Task SaveUserAsync(User user, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }


    }
}
